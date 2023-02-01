using Discord;
using Discord.WebSocket;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace penobotwithMongo.discord
{
    internal class OXcalcul
    {

    }

    internal class QuizBotton
    {
        public ComponentBuilder BottonClass;
        public QuizBotton(string correctWord, List<string> wrongWord)
        {

            this.BottonClass = new ComponentBuilder();
            BottonClass.WithButton(correctWord.Split(",")[0], "correct");
            int i = 1;
            wrongWord.ForEach(
                (x) =>
            {
                BottonClass.WithButton(x.Split(",")[0], $"wrong{i}");
                i++;
            });
        }
    }
    internal class AnswerChack
    {
        public AnswerChack(DiscordSocketClient client) { }
        public async Task MyButtonHandler(SocketMessageComponent component)
        {
            switch (component.Data.CustomId)
            {
                // Since we set our buttons custom id as 'custom-id', we can check for it like this:
                case "correct":
                    // Lets respond by sending a message saying they clicked the button
                    await component.Channel.SendMessageAsync($"{component.User.Mention} 정답을 맞추셨습니다");
                    break;
                default:
                    await component.RespondAsync("오답");
                    break;
            }
        }

    }
}
