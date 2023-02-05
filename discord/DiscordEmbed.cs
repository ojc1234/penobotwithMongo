using Discord;
using penobotwithMongo.matrix;
using System.Collections.Generic;

namespace penobotwithMongo.discord

{
    internal class DiscordEmbed
    {
        /// <summary>
        /// 사전인베드
        /// </summary>
        /// <param name="dict"></param>
        /// <returns></returns>
        public EmbedBuilder dictEmbed(Dict dict)
        {
            var eb = new EmbedBuilder { Title = dict.englishWord, Description = dict.phenomenon?.discordString() };
            eb.AddField("뜻", dict.mean);
            eb.AddField("출처", request.ahaUrl(dict.englishWord));
            eb.WithAuthor("노니#2196 클릭하면 초대되요", url: "https://discord.gg/QkdVQPNN");
            return eb;
        }
        /// <summary>
        /// 행렬 인베드
        /// </summary>
        /// <param name="matrix">
        /// 행렬 인풋
        /// </param>
        /// <returns>행렬 인베드</returns>
        public EmbedBuilder matrixEmbed(Matrix matrix)
        {
            var eb = new EmbedBuilder { Title = "만들어진 행렬" };
            eb.AddField("행렬식", $"[1] {matrix.Fildmatrix[0][0]} {matrix.Fildmatrix[0][1]}\n[2] {matrix.Fildmatrix[1][0]} {matrix.Fildmatrix[1][0]}", true);
            eb.WithAuthor("노니#2196 클릭하면 초대되요", url: "https://discord.gg/QkdVQPNN");
            return eb;

        }
        public EmbedBuilder MywordEmbed(List<Word> inputs)
        {
            var eb = new EmbedBuilder { Title = "나의단어" };
            inputs.ForEach(i =>  eb.AddField(i.englishWord, i.mean) );
            eb.WithAuthor("노니#2196 클릭하면 초대되요", url: "https://discord.gg/QkdVQPNN");
            return eb;

        }
        /// <summary>
        /// 도움말
        /// </summary>
        public EmbedBuilder assistance()
        {
            var eb = new EmbedBuilder { Title = "도움말" };
            eb.WithAuthor("노니#2196 클릭하면 초대되요", url: "https://discord.gg/QkdVQPNN");
            eb.AddField("!", "!이후 단어를 검색 이후 자신에 디비에 단어 추가");
            eb.AddField("%", "자신의 단어 목록을 볼수 있다");
            eb.AddField("^", "자신의 디비에 있는 단어들로 문제를 풀수 있다");
            return eb;
        }
    }
}
