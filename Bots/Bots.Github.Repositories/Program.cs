using System;

namespace Bots.Github.Repositories
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("What's the username? ");
            string username = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(username))
                Console.WriteLine("Invalid username.");
            else
                Models.Github.LogRepositories(username);

            Console.ReadKey(intercept: true);
        }
    }
}
