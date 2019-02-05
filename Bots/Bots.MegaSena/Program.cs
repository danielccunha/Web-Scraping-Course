using System;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;

namespace Bots.MegaSena.Html
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("What's the number: ");
            string numeroConcurso = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(numeroConcurso) || !int.TryParse(numeroConcurso, out int numero))            
                Console.WriteLine("Invalid number. It must be an integer.");
            else            
                LogResult(numeroConcurso);

            Console.ReadKey(intercept: true);
        }

        private static void LogResult(string numeroConcurso)
        {
            string url = $"http://www1.caixa.gov.br/loterias/loterias/megasena/megasena_pesquisa_new.asp?submeteu=sim&opcao=concurso&txtConcurso={numeroConcurso}";
            string html = Scrapy(url);

            string[] vet = Regex.Split(html, "<li>");
            List<string> result = new List<string> { vet[1], vet[2], vet[3], vet[4], vet[5], vet[6].Substring(0, 2) };

            result.Sort();
            Console.WriteLine($"Result: {string.Join(", ", result)}");
        }

        private static string Scrapy(string url)
        {
            string html = string.Empty;

            using (WebClient client = new WebClient())
            {
                client.Headers[HttpRequestHeader.Cookie] = "security=true";
                html = client.DownloadString(url);
            }

            html = html.Replace("<span class=\"num_sorteio\"><ul>", "");
            html = html.Replace("</ul></span>", "");
            html = html.Replace("</li>", "");
            return html;
        }
    }
}
