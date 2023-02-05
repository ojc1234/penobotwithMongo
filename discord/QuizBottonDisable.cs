using Discord;
using Discord.WebSocket;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Runtime.CompilerServices;

namespace penobotwithMongo.discord
{
    internal class OXcalcul
    {

    }

    internal class QuizBotton
    {
        /// <summary>
        /// 퀴즈 버튼 기본 설계
        /// </summary>
        /// <param name="correctWord"></param>
        /// <param name="wrongWord"></param>
        public  ComponentBuilder QuizBottonDisable(string correctWord, List<string> wrongWord, bool disableset = false)
        {
            util.util ramdomList = new util.util();
            var list_5 = ramdomList.ramdomList(5);
            List<ComponentBuilder> words = new List<ComponentBuilder>();
            var BottonClass = new ComponentBuilder();
            list_5.ForEach(x =>
            {
                if (x == 0)
                {
                    words.Add(BottonClass.WithButton(correctWord.Split(",")[0], "correct",disabled : disableset));

                }
                else
                {
                    BottonClass.WithButton(wrongWord[x].Split(",")[0], $"wrong{x}", disabled: disableset);
                }
            }
            
        );

            return BottonClass;


        }
        public ComponentBuilder QuizBottonDisableColor(string correctWord, List<string> wrongWord, bool disableset = false)
        {
            util.util ramdomList = new util.util();
            var list_5 = ramdomList.ramdomList(5);
            List<ComponentBuilder> words = new List<ComponentBuilder>();
            var BottonClass = new ComponentBuilder();
            list_5.ForEach(x =>
            {
                if (x == 0)
                {
                    words.Add(BottonClass.WithButton(correctWord.Split(",")[0], "correct", disabled: disableset,style : ButtonStyle.Success));

                }
                else
                {
                    BottonClass.WithButton(wrongWord[x].Split(",")[0], $"wrong{x}", disabled: disableset,style:ButtonStyle.Danger);
                }
            }

        );

            return BottonClass;


        }
    }
    internal class AnswerChack
    {
        public AnswerChack(DiscordSocketClient client) { }
        public async Task MyButtonHandler(SocketMessageComponent component)
        {
            try
            {
                switch (component.Data.CustomId)
                {
                    // Since we set our buttons custom id as 'custom-id', we can check for it like this:
                    case "correct":
                        // Lets respond by sending a message saying they clicked the button
                        await component.Channel.SendMessageAsync($"{component.User.Mention} 정답을 맞추셨습니다");
                        var requestopt = new RequestOptions();
                        requestopt.Timeout = 10000;
                        requestopt.RatelimitCallback = ((i) => component.Channel.SendMessageAsync("시간끝"));
                        await component.RespondAsync();

                        break;
                    default:
                        await component.RespondAsync("오답");
                        break;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

    }
}
