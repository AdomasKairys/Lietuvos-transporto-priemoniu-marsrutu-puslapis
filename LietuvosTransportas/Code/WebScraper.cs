using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;

namespace LietuvosTransportas.Code
{
    public class WebScraper
    {
        private static IWebDriver driver;
        public static void Scraper(string driverPath, string outputPath, string url, string idToScrape)
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("--headless");
            chromeOptions.AddArguments("--disable-gpu");

            driver = new ChromeDriver(driverPath, chromeOptions);

            driver.Navigate().GoToUrl(url);
            var collections = FindElements(By.Id(idToScrape));

            foreach (var collection in collections)
            {
                using (StreamWriter writer = new StreamWriter(outputPath, false))
                {
                    writer.Write(collection.Text);
                }
            }
            driver.Quit();
        }
        static IReadOnlyCollection<IWebElement> FindElements(By by)
        {
            Stopwatch w = Stopwatch.StartNew();
            while (w.ElapsedMilliseconds < 10 * 1000)
            {
                var elements = driver.FindElements(by);
                if (elements.Count > 0)
                    return elements;

                Thread.Sleep(10);
            }
            return null;

        }
        public static void ScrapeTxt(string url, string ouptputPath)
        {
            var resultStops = string.Empty;
            using (var webClient = new System.Net.WebClient())
            {
                resultStops = webClient.DownloadString(url);
            }

            string ffixed = string.Empty;
            using (StreamWriter writer = new StreamWriter(ouptputPath, false))
            using (StringReader reader = new StringReader(resultStops))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] collums = line.Split(';');
                    if (!Regex.IsMatch(collums[0], "\\,") && !String.IsNullOrEmpty(collums[0]))
                        ffixed += string.Join(";", new string[] { collums[0] }) + Environment.NewLine;
                }
                writer.Write(ffixed);
            }
        }
    }
}