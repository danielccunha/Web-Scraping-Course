using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using prmToolkit.Selenium;
using prmToolkit.Selenium.Enum;
using System;
using System.Threading;

namespace Bots.Youtube.View.Selenium
{
    class Program
    {
        private static string DriverPath => @"C:\Codes\Web-Scraping-Course\Drivers";
        private static string ExtensionPath => @"C:\Users\danie\AppData\Local\Google\Chrome\User Data\Default\Extensions\gighmmpiobklfepjocnamgkkbiglidom\3.38.1_1";
        private static string Url => @"https://www.youtube.com/watch?v=64qxmuzdX0M";

        static void Main(string[] args)
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument($"load-extension={ExtensionPath}"); // Add AdBlocker to Chrome Driver
            IWebDriver webDriver = new ChromeDriver(DriverPath, options);

            GetView(webDriver);
            
            webDriver.Dispose();
        }

        private static void GetView(IWebDriver webDriver)
        {
            try
            {
                webDriver.LoadPage(TimeSpan.FromSeconds(10), Url);
                Thread.Sleep(30 * 1000);
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
            }
        }
    }
}
