using Discord;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace penobotwithMongo.discord
{
    internal class QuizBotton
    {
        public ComponentBuilder BottonClass;
        public QuizBotton() {
             this.BottonClass = new ComponentBuilder().WithButton("label", "custom-id");
        }
    }
    internal  class AnswerChack
    {
        public AnswerChack(DiscordSocketClient client) { }
        public async Task MyButtonHandler() { }

    }
}
