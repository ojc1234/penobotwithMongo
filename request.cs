using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace penobotwithMongo
{
    public class BoldString
    {
        private string Text;
        private int Position;
        public BoldString(string Text, int position)
        {
            this.Text = Text;
            this.Position = position;
        }
        public string toString()
        {
            return this.Text;
        }
        public string discordString()
        {
            string output = string.Empty;
            output += "```ansi\n";
            for (int i = 0; i < Text.Length; i++)
            {
                if (i == Position)
                {
                    output += "\u001b[0;31;47m";
                    output += Text[i];
                    output += "\u001b[0m";
                }
                else
                    output += Text[i];

            }
            output += "\n```";
            return output;
        }
    }
    public struct penoMean
    {
        public BoldString peno;
        public string Mean;
    }
    internal class request
    {


        public static string postRequest(string Word)
        {
            String callUrl = Word;

            String postData = "a=1&b=2";

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(callUrl);
            // 인코딩 UTF-8
            byte[] sendData = UTF8Encoding.UTF8.GetBytes(postData);
            httpWebRequest.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentLength = sendData.Length;
            Stream requestStream = httpWebRequest.GetRequestStream();
            requestStream.Write(sendData, 0, sendData.Length);
            requestStream.Close();
            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream(), Encoding.GetEncoding("UTF-8"));
            string sRE = streamReader.ReadToEnd();

            streamReader.Close();
            httpWebResponse.Close();
            return sRE;
        }
        public static Dict Diction(string Word)
        {
            penoMean takeData = dictrequest(ahaUrl(Word));
            return new Dict
            {
                mean = takeData.Mean,
                phenomenon = takeData.peno,
                englishWord = Word
            };
        }
        public static string requestTest(string Word)
        {
            return dictrequest(ahaUrl(Word)).Mean;
        }

        private static penoMean dictrequest(string url)
        {
            string html = postRequest(url);
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);
            BoldString peno = htmlParserBoldString(htmlDoc);
            string mean = htmlParserMean(htmlDoc);
            penoMean output;
            output.peno = peno;
            output.Mean = mean;
            return output;
        }
        public static BoldString htmlParserBoldString(HtmlDocument parseHTML)
        {
            var XPath = "//*[@id=\"result\"]/span[3]";
            HtmlDocument htmlDoc = parseHTML;
            string bodyNode = htmlDoc.DocumentNode.SelectSingleNode(XPath)?.InnerText;
            var mainchild = htmlDoc.DocumentNode.SelectSingleNode(XPath)?.ChildNodes;
            List<string> array = new List<string>();
            if (mainchild == null) return null;
            foreach (var child in mainchild)
            {
                array.Add(child.InnerText);
            }
            return new BoldString(bodyNode, array[0].Length);

        }
        public static string htmlParserMean(HtmlDocument parseHTML)
        {
            var XPath = "//*[@id=\"result\"]/ul/li";
            HtmlDocument htmlDoc = parseHTML;
            string bodyNode = htmlDoc.DocumentNode.SelectSingleNode(XPath)?.InnerText;
            return bodyNode;

        }
        public static string ahaUrl(string text)
        {
            return $@"http://aha-dic.com/View.asp?word={text}";
        }
    }
}
