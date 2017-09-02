using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot
{
    using Discord;
    using Discord.Commands;
    using System;

    class YourBot
    {
        static void Main(string[] args)
        {
            new YourBot().Start();
        }

        private DiscordClient _client;

        public void Start()
        {






            _client = new DiscordClient(x => // App config
            {
                x.AppName = "YourBot";
                x.LogLevel = LogSeverity.Info;
                x.LogHandler = Log;
            });

            _client.UsingCommands(x => // Command settings
            {
                x.PrefixChar = '!';
                x.AllowMentionPrefix = true;
            });

            CreateCommands(_client); // Initialize commands

            // Add event functions to events when you have them



            // Connection
            var token = "tokenhere";
            _client.ExecuteAndWait(async () =>
            {
                await _client.Connect(token, TokenType.Bot);
            });
        }

        public static void CreateCommands(DiscordClient _client)
        {
            var cService = _client.GetService<CommandService>();

            string[] pancakenudes = new string[]
{
                "D:/Documents/Visual Basic projects/astrobotNUDES/astrobotNUDES/nudz/1.jpg",
                "D:/Documents/Visual Basic projects/astrobotNUDES/astrobotNUDES/nudz/2.jpg",
                "D:/Documents/Visual Basic projects/astrobotNUDES/astrobotNUDES/nudz/3.jpg",
                "D:/Documents/Visual Basic projects/astrobotNUDES/astrobotNUDES/nudz/4.jpg",
                "D:/Documents/Visual Basic projects/astrobotNUDES/astrobotNUDES/nudz/5.jpg",
                "D:/Documents/Visual Basic projects/astrobotNUDES/astrobotNUDES/nudz/6.jpg",
                "D:/Documents/Visual Basic projects/astrobotNUDES/astrobotNUDES/nudz/7.jpg",
                "D:/Documents/Visual Basic projects/astrobotNUDES/astrobotNUDES/nudz/8.jpg",
                "D:/Documents/Visual Basic projects/astrobotNUDES/astrobotNUDES/nudz/9.jpg"
};

            Random rand = new Random();

            cService.CreateCommand("nudes")
                .Description("sendspancakepic")
                //.[OLD] Parameter("keywords", ParameterType.Required) //
                .Do(async (e) =>
                {
                    int randomNudeIndex = rand.Next(pancakenudes.Length);
                    string nudesToPost = pancakenudes[randomNudeIndex];
                    await e.Channel.SendFile(nudesToPost);
                });
        }

        // Log manager
        public void Log(object sender, LogMessageEventArgs e)
        {
            Console.WriteLine($"[{e.Severity}] {e.Message}");
        }
    }
}
