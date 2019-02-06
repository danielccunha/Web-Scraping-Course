using System;

namespace Bots.Instagram.Profile
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("What's the username? ");
            string username = Console.ReadLine();

            Profile profile = Instagram.GetProfileByUser(username);
            LogProfile(profile);

            Console.ReadKey(intercept: true);
        }

        private static void LogProfile(Profile profile)
        {
            Console.WriteLine($"\n{nameof(profile.Username)}: {profile.Username}");
            Console.WriteLine($"{nameof(profile.Title)}: {profile.Title}");
            Console.WriteLine($"{nameof(profile.Description)}: {profile.Description}");
            Console.WriteLine("\nAnd many other properties...");
        }
    }
}
