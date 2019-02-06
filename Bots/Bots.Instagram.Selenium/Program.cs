using OpenQA.Selenium;
using prmToolkit.Selenium;
using prmToolkit.Selenium.Enum;
using System;
using System.Threading;

namespace Bots.Instagram.Selenium
{
    class Program
    {
        private static string DriverPath => @"C:\Codes\Web-Scraping-Course\Drivers";
        private static string Username { get; set; }
        private static string Password { get; set; }

        static void Main(string[] args)
        {
            const string username = "YOUR_USERNAME";
            const string password = "YOUR_PASSWORD";
            IWebDriver webDriver = WebDriverFactory.CreateWebDriver(Browser.Chrome, DriverPath);

            try
            {
                webDriver.LoadPage(TimeSpan.FromSeconds(10), "https://www.instagram.com/accounts/login/");
                Login(username, password, webDriver);

                Thread.Sleep(5000);
                webDriver.LoadPage(TimeSpan.FromSeconds(10), "https://www.instagram.com/danielccunha_");
                webDriver.FindElement(By.XPath("//button[contains(text(), 'Seguir')]")).Click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                webDriver.Close();
                webDriver.Dispose();
            }

            Console.ReadKey(intercept: true);
        }

        private static void Login(string username, string password, IWebDriver webDriver)
        {
            webDriver.SetText(By.Name("username"), username);
            webDriver.SetText(By.Name("password"), password);
            webDriver.Submit(By.TagName("button"));
        }
    }
}
