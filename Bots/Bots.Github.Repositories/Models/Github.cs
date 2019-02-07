using HtmlAgilityPack;
using System;
using System.Net;

namespace Bots.Github.Repositories.Models
{
    public static class Github
    {
        public static void LogRepositories(string username)
        {
            const string XPath = "//*[@id=\"user-repositories-list\"]/ul/li";
            HtmlDocument doc = GetHtmlDocument(username);
            HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes(XPath);

            Console.WriteLine($"\nRepositories ({nodes.Count}):");

            foreach (HtmlNode node in nodes)
            {
                string name = node.InnerText.Split("\n")[5].Trim();
                Console.WriteLine($"\t{name}");
            }
        }

        private static HtmlDocument GetHtmlDocument(string username)
        {
            string url = $"https://github.com/{username}?tab=repositories";
            string html = string.Empty;

            using (WebClient client = new WebClient())
                html = client.DownloadString(url);

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);

            return doc;
        }
    }
}
