using System.IO;

namespace penobotwithMongo.config
{
    internal class token
    {
        public string discordtoken;
        public token()
        {
            string FileRoute = @"D:\codingstudy\penomiDiscordBot\penodiscordbot\config\config.json";
            string FileBuffer;
            string text;
            try
            {
                FileBuffer = File.ReadAllText(FileRoute);
                text = FileBuffer == "\n" ? "01" : FileBuffer;
            }
            catch
            {
                text = "000";
            }
            this.discordtoken = text;
        }

    }
}