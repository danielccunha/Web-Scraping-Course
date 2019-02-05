using Newtonsoft.Json;
using System;
using System.Net;

namespace Bots.MegaSena.Json
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
            string url = $"http://loterias.caixa.gov.br/wps/portal/loterias/landing/megasena/!ut/p/a1/04_Sj9CPykssy0xPLMnMz0vMAfGjzOLNDH0MPAzcDbwMPI0sDBxNXAOMwrzCjA0sjIEKIoEKnN0dPUzMfQwMDEwsjAw8XZw8XMwtfQ0MPM2I02-AAzgaENIfrh-FqsQ9wNnUwNHfxcnSwBgIDUyhCvA5EawAjxsKckMjDDI9FQE-F4ca/dl5/d5/L2dBISEvZ0FBIS9nQSEh/pw/Z7_HGK818G0KO6H80AU71KG7J0072/res/id=buscaResultado/c=cacheLevelPage/=/?timestampAjax=1549410165865&concurso={numeroConcurso}";
            string json = string.Empty;

            using (WebClient client = new WebClient())
            {
                client.Headers[HttpRequestHeader.Cookie] = "security=true";
                json = client.DownloadString(url);
            }

            ContestResult result = JsonConvert.DeserializeObject<ContestResult>(json);
            Console.WriteLine($"Result: {result.ResultadoOrdenado.Replace("-", ", ")}");
        }
    }
}
