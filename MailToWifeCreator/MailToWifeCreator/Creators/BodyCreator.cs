using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailToWifeCreator.Dictionary;
using RestSharp;

namespace MailToWifeCreator.Creators
{
    internal class BodyCreator : IStringCreator
    {
        private const string SPACE = " ";
        private const char ENTER = '\n';

        private int helloDictNumber;
        private int perfixDictNumber;
        private Tuple<int, int> sentenceDictNumber;

        public BodyCreator()
        {
            var random = new Random();

            helloDictNumber = random.Next(HelloDictionary.Hellos.Count);
            perfixDictNumber = random.Next(PrefixNameDictionary.prefixes.Count);

            sentenceDictNumber = new Tuple<int, int>(random.Next(SentenceDictonary.Sentence.Count), random.Next(SentenceDictonary.Sentence.Count));
        }

        public string GetString()
        {
            var body = new StringBuilder();

            body.Append(HelloDictionary.Hellos[helloDictNumber]);
            body.Append(SPACE);
            body.Append(PrefixNameDictionary.prefixes[perfixDictNumber]);
            body.Append(ENTER);
            body.Append(SentenceDictonary.Sentence[sentenceDictNumber.Item1]);
            body.Append(SPACE);
            body.Append(SentenceDictonary.Sentence[sentenceDictNumber.Item2]);


            var subject = this.GetWikiTitle();

            if (!string.IsNullOrEmpty(subject))
            {
                body.AppendLine();
                body.AppendLine();
                body.AppendLine();
                body.AppendLine("PS");
                body.AppendLine();
                body.AppendLine(subject);
            }

            return body.ToString();
        }

        public string GetWikiTitle()
        {
            try
            {
                var client = new RestClient("https://pl.wikipedia.org/w/api.php");

                var request2 = new RestRequest("?action=query&titles=Wikipedia:Artyku%C5%82y_na_medal&prop=extracts&format=json");

                IRestResponse response = client.Execute(request2);

                var content2 = response.Content;

                var art = (string)JObject.Parse(content2)["query"]["pages"]["8603"]["extract"];

                var html = new HtmlDocument();

                html.LoadHtml(art);

                string[] nodes = html.DocumentNode.SelectNodes(@"/p").Where(t => t.InnerHtml.Contains('•')).Select(t => t.InnerHtml.Split('•')).Aggregate((a, b) => a.Concat(b).ToArray());

                var randomNumber = new Random().Next(0, nodes.Count());

                var request = new RestRequest("?format=json&action=query&prop=extracts&exintro=&explaintext=&titles={title}", Method.POST);

                request.AddUrlSegment("title", nodes[randomNumber].Replace(' ', '_'));

                var content = (client.Execute(request)).Content;

                var extract = ((string)JObject.Parse(content)["query"]["pages"].First.First["extract"]);

                return extract.Substring(0, extract.IndexOf("\n"));
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
    }
}
