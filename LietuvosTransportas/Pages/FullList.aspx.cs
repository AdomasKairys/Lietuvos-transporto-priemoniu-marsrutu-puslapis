using LietuvosTransportas.Code;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;

namespace LietuvosTransportas
{
    public partial class Page2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Load the XML file into a DataSet
                DataSet ds = new DataSet();
                ds.ReadXml(Server.MapPath("/App_Data/CityNames.xml"));

                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    SearchBox.Items.Add(row[0].ToString());
                }
                //Code.WebScraper.Scraper(Server.MapPath("/App_Data"), Server.MapPath("/App_Data/Route_Times/times.txt"), "https://stops.lt/kautra/#bus/106/a-b/2486-1", "divScheduleContentInner");
                //Code.WebScraper.Scraper(Server.MapPath("/App_Data"), "https://stops.lt/kautra/#bus/106/a-b/2486-1", "//div[@id='divScheduleStop']/strong");
                //using (StreamWriter writer = new StreamWriter(Server.MapPath("/App_Data/Route_Times/route_name.txt"), false))
                //using (StreamReader reader = new StreamReader(Server.MapPath("/App_Data/routes.txt")))
                //{
                //    reader.ReadLine();
                //    reader.ReadLine();
                //    string line;
                //    string transport = "";
                //    while ((line = reader.ReadLine()) != null)
                //    {
                //        string[] elements = line.Split(';');
                //        if (!string.IsNullOrEmpty(elements[1]))
                //            transport = elements[1];
                //        string route = elements[0];
                //        for (int i = 3; i < elements.Length - 2; i += 3)
                //        {
                //            string[] stops = elements[i + 2].Split(',');
                //            foreach (string stop in stops)
                //            {
                //                string stopname = WebScraper.Scraper(Server.MapPath("/App_Data"), $"https://stops.lt/kaunas/#{transport}/{route}/{elements[i]}/{stop.Trim()}", "#divScheduleStop>strong");
                //                writer.WriteLine(route + ';' + elements[i] + ';' + stop + ';' + stopname);
                //            }
                //        }
                //    }
                //}

            }
        }

        protected void BtnShowLongDistance_Click(object sender, EventArgs e)
        {

        }

        protected void SearchBox_TextChanged(object sender, EventArgs e)
        {
            string accentedStr = SearchBox.Text;
            byte[] tempBytes = System.Text.Encoding.GetEncoding("ISO-8859-8").GetBytes(accentedStr);
            string asciiStr = System.Text.Encoding.UTF8.GetString(tempBytes);
            asciiStr = asciiStr.ToLower();

            PageEmbed.Style["width"] = "1400px";
            PageEmbed.Style["height"] = "800px";
            PageEmbed.Style["border "] = "1";
            PageEmbed.Src = "https://www.stops.lt/" + asciiStr;
            Code.WebScraper.ScrapeRoutes($"{PageEmbed.Src}/{asciiStr}/routes.txt", Server.MapPath("/App_Data/routes.txt"));
        }
        protected void BtnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/MainPage.aspx");
        }
    }
}