using Discord.WebSocket;
using penobotwithMongo.databasemodel;
using penobotwithMongo.matrix;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Threading.Tasks;
namespace penobotwithMongo.discord
{
    internal class botMessage
    {
        private DiscordSocketClient _client;
        public botMessage(DiscordSocketClient client)
        {
            _client = client;
        }

        public async Task MessageReceivedAsync(SocketMessage message)
        {
            if (message.Author.Id == _client.CurrentUser.Id)
                return;
            //기본 단어 보기
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
            //행렬 보기
            if (message.Content.FirstOrDefault().ToString() == ".")
            {
                string realMessage = message.Content.Remove(0, 1);
                List<int> inputs = realMessage.Split(' ').ToList().ConvertAll((i) => int.Parse(i));
                var mat = new Matrix(new List<int> { inputs[0], inputs[1] }, new List<int> { inputs[2], inputs[3] });
                await message.Channel.SendMessageAsync(embed: new DiscordEmbed()?.matrixEmbed(mat)?.Build());
            }
            // 나의 단어 보기
            if (message.Content == "%")
            {
                var DB = new MongoModel();
                var WordList = DB.DiscordfindEnglish(message.Author.AvatarId);
                await message.Channel.SendMessageAsync(embed: new DiscordEmbed()?.MywordEmbed(WordList)?.Build());
            }
            // 퀴즈 내기
            if (message.Content == "^")
            {

                var DB = new MongoModel();
                var WordList = DB.DiscordfindEnglish(message.Author.AvatarId);

                if (WordList.Count < 4)
                {
                    await message.Channel.SendMessageAsync("단어수가 적습니다 최소 4개여야합니다");


                }
                else
                {
                    var ramdomArray = new List<int>();
                    for (int i = 0; ; i++)
                    {
                        int ramdomInt0_4 = new Random().Next(0, WordList.Count);
                        if (!ramdomArray.Contains(ramdomInt0_4)) ramdomArray.Add(ramdomInt0_4);
                        if (ramdomArray.Count == 4) break;
                    } //0번째가 정답 나머지는 오답
                    var correctWord = WordList[ramdomArray[0]];
                    /*버튼 구현 */
                    WordList.RemoveAt(0); //오답들 리스트
                    var worngWord = WordList.ConvertAll((i) => i.mean);
                    var QuizClass = new QuizBotton(correctWord.mean, worngWord);
                    var outputText = $"단어 {correctWord.englishWord}";

                    await message.Channel.SendMessageAsync(text: outputText, components: QuizClass.BottonClass.Build());
                }

            }
        }
    }
}
