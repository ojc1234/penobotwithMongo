using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using penobotwithMongo.matrix;
using penobotwithMongo.databasemodel;
namespace penobotwithMongo.discord
{
    internal class botMessage
    {
        private DiscordSocketClient _client;
        public botMessage(DiscordSocketClient client) 
        {
            _client= client;
        }
        public async Task MessageReceivedAsync(SocketMessage message)
        {
            if (message.Author.Id == _client.CurrentUser.Id)
                return;

            if (message.Content.FirstOrDefault().ToString() == "!")
            {
                var diction = request.Diction(message.Content.Substring(1));

                if (diction.phenomenon == null)
                {
                    await message.Channel.SendMessageAsync("Not found");
                }
                else
                {
                    await message.Channel.SendMessageAsync(embed: new DiscordEmbed()?.dictEmbed(diction)?.Build());
                    var DB = new MongoModel()
                    {
                        DiscordId = message.Author.AvatarId,
                        englishWord = diction.englishWord,
                        mean = diction.mean,
                        phenomenon = diction.phenomenon.discordString(),
                    };
                    DB.Discordinital();
                }
            }
            if (message.Content.FirstOrDefault().ToString() == ".")
            {
                string realMessage = message.Content.Remove(0,1);
                List<int> inputs = realMessage.Split(' ').ToList().ConvertAll((i)=>int.Parse(i));
                var mat = new Matrix(new List<int> { inputs[0], inputs[1] }, new List<int> { inputs[2], inputs[3] });
                await message.Channel.SendMessageAsync(embed: new DiscordEmbed()?.matrixEmbed(mat)?.Build());
            }
            if (message.Content == "%")
            {
                var DB = new MongoModel();
                var WordList = DB.DiscordfindEnglish(message.Author.AvatarId);
                await message.Channel.SendMessageAsync(embed: new DiscordEmbed()?.MywordEmbed(WordList)?.Build());
            }
        }
    }
}
