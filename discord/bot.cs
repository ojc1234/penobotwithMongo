using Discord;
using Discord.WebSocket;
using System;
using System.Linq;
using System.Threading.Tasks;
using penobotwithMongo.config;
using System.Transactions;
using Microsoft.VisualBasic.Logging;

namespace penobotwithMongo.discord
{
    internal class bot
    {
        protected readonly DiscordSocketClient _client;
        protected string token;

        public bot(string inputtoken = null)
        {
            this.token = inputtoken;
            var config = new DiscordSocketConfig()
            {
                GatewayIntents = GatewayIntents.All,
                UseInteractionSnowflakeDate = false

            };
            _client = new DiscordSocketClient(config);

            _client.Log += Log;
            _client.Ready += Ready;
            _client.MessageReceived += new botMessage(_client).MessageReceivedAsync;
            _client.ButtonExecuted += new AnswerChack(_client).MyButtonHandler;
        }

        virtual public async Task MainAsync()
        {
            await _client.LoginAsync(TokenType.Bot, token ?? new token().discordtoken);
            await _client.StartAsync();

            await Task.Delay(-1);
        }

        private Task Log(LogMessage log)
        {
            Console.WriteLine(log.ToString());

            return Task.CompletedTask;
        }

        private Task Ready()
        {
            Console.WriteLine($"{_client.CurrentUser} 연결됨!");
            return Task.CompletedTask;
        }


    }
    
}
