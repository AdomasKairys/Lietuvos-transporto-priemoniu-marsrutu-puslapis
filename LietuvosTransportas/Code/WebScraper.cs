using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using System.Net.Http;

namespace LietuvosTransportas.Code
{
    public class WebScraper
    {
        private static IWebDriver driver;
        public static string Scraper(string driverPath, string url, string cssSelector)
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("--headless");
            chromeOptions.AddArguments("--disable-gpu");

            driver = new ChromeDriver(driverPath, chromeOptions);
            driver.Navigate().GoToUrl(url);
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(1));
                var collection = wait.Until(drv => drv.FindElement(By.CssSelector(cssSelector)));
                var retunvalue = collection.GetAttribute("innerHTML");
                driver.Quit();
                return retunvalue;
            }
            catch (Exception ex)
            {
                driver.Quit();
                throw new Exception(url + " " + ex.Message);
            }
            

            
        }
        public static void ScrapeRoutes(string url, string ouptputPath)
        {
            var resultStops = string.Empty;
            var client = new HttpClient();
            using (HttpResponseMessage response = client.GetAsync(url).Result)
            {
                using (HttpContent content = response.Content)
                {
                    resultStops = content.ReadAsStringAsync().Result;
                }
            }

            string ffixed = string.Empty;
            using (StreamWriter writer = new StreamWriter(ouptputPath, false))
            using (StringReader reader = new StringReader(resultStops))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] collums = line.Split(';');
                    if(Regex.IsMatch(collums[0], "\\,"))
                        continue;
                    if (!string.IsNullOrEmpty(collums[0]))
                        ffixed += Environment.NewLine + string.Join(";", new string[] { collums[0], collums[3], collums[4], collums[8], collums[10], collums[13] });
                    else
                        ffixed += ';' + string.Join(";", new string[] { collums[8], collums[10], collums[13] });
                }
                
                writer.Write(ffixed);
            }
        }
    }
}