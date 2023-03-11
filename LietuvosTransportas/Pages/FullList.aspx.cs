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
using System.Web.UI.HtmlControls;
using System.Xml.Linq;

namespace LietuvosTransportas
{
    public partial class Page2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                WebScraper.ScrapeRoutes("https://stops.lt/kautra/kautra/routes.txt", Server.MapPath("/App_Data/routes.txt"));
                WebScraper.ScrapeStops("https://stops.lt/kautra/kautra/stops.txt", Server.MapPath("/App_Data/stops.txt"));

                // Load the XML file into a DataSet
                DataSet ds = new DataSet();
                ds.ReadXml(Server.MapPath("/App_Data/CityNames.xml"));
                using (StreamReader reader = new StreamReader(Server.MapPath("/App_Data/stops.txt")))
                {
                    reader.ReadLine();
                    reader.ReadLine();
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        SearchBox1.Items.Add(line.Split(';')[1]);
                        SearchBox2.Items.Add(line.Split(';')[1]);
                    }
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

        protected void BtnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/MainPage.aspx");
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            using (StreamReader readerRoute = new StreamReader(Server.MapPath("/App_Data/routes.txt")))
            using (StreamReader readerStops = new StreamReader(Server.MapPath("/App_Data/stops.txt")))
            {
                readerStops.ReadLine();
                readerStops.ReadLine();
                string line;
                string startID = "";
                string endID = "";
                while ((line = readerStops.ReadLine()) != null)
                {
                    string[] split = line.Split(';');
                    if (SearchBox1.SelectedValue == SearchBox2.SelectedValue)
                        throw new Exception("NO");
                    if (split[1] == SearchBox1.SelectedValue)
                        startID = split[0];
                    else if (split[1] == SearchBox2.SelectedValue)
                        endID = split[0];
                    if (endID != startID)
                        break;
                }

                readerRoute.ReadLine();
                readerRoute.ReadLine();
                string routeID = "";
                string routeType = "";
                string transport = "";
                while ((line = readerRoute.ReadLine()) != null)
                {
                    string[] split = line.Split(';');
                    
                    if (!string.IsNullOrEmpty(split[1]))
                        transport = split[1];
                    for (int i = 3; i < split.Length - 2; i += 3)
                    {
                        if(Regex.IsMatch(split[i + 2], startID) && Regex.IsMatch(split[i + 2], endID))
                        {
                            routeID = split[0];
                            routeType = split[i];
                            break;
                        }
                    }
                }
                HtmlIframe iframe = new HtmlIframe();
                iframe.Src = $"https://stops.lt/kautra/#{transport}/{routeID}/{routeType}";
                form1.Controls.Add(iframe);

            }
        }
    }
}