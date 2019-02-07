using OpenQA.Selenium;
using prmToolkit.Selenium;
using prmToolkit.Selenium.Enum;
using System;
using System.Threading;

namespace Bots.WhatsApp.Share.Selenium
{
    class Program
    {
        private static string DriverPath => @"C:\Codes\Web-Scraping-Course\Drivers";
        private static string Url => @"https://web.whatsapp.com/";
        private static string GroupUrl => @"https://chat.whatsapp.com/DhCezxXM1vf1hXu2uu2WTJ";
        private static string Message => "Type your message.";

        static void Main(string[] args)
        {
            IWebDriver webDriver = WebDriverFactory.CreateWebDriver(Browser.Chrome, DriverPath);

            try
            {
                webDriver.LoadPage(TimeSpan.FromSeconds(10), Url);
                Thread.Sleep(TimeSpan.FromSeconds(10));

                webDriver.LoadPage(TimeSpan.FromSeconds(15), GroupUrl);

                webDriver.FindElementOrDefault(By.Id("action-button"))?.Click();
                Thread.Sleep(TimeSpan.FromSeconds(10));

                webDriver.FindElementOrDefault(By.XPath("//*[@id=\"app\"]/div/span[3]/div/div/div/div/div/div/div[2]/div[2]"))?.Click();
                Thread.Sleep(TimeSpan.FromSeconds(5));

                By input = By.XPath("//*[@id=\"main\"]/footer/div[1]/div[2]/div/div[2]");
                
                if (input != null)
                {
                    webDriver.SetText(input, Message);
                    webDriver.FindElement(input).SendKeys(Keys.Enter);
                }


                webDriver.FindElementOrDefault(By.XPath("//*[@id=\"main\"]/header/div[3]/div/div[3]/div"))?.Click();
                webDriver.FindElementOrDefault(By.XPath("//div[text() = 'Sair do grupo']"))?.Click();
                webDriver.FindElementOrDefault(By.XPath("//*[@id=\"app\"]/div/span[3]/div/div/div/div/div/div/div[2]/div[2]"))?.Click();
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
            }
            finally
            {
                webDriver.Close();
                webDriver.Dispose();
            }

            Console.ReadKey();
        }
    }
}
