using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Services;
using System.Web.UI.WebControls;
using System.Xml.Linq;

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
            }
        }

        protected void BtnShowLongDistance_Click(object sender, EventArgs e)
        {

        }

        protected void SearchBox_TextChanged(object sender, EventArgs e)
        {
            string accentedStr = SearchBox.Text;
            byte[] tempBytes = System.Text.Encoding.GetEncoding("ISO-8859-8").GetBytes(accentedStr);
            string asciiStra = System.Text.Encoding.UTF8.GetString(tempBytes);
            asciiStra = asciiStra.ToLower();

            PageEmbed.Style["width"] = "1400px";
            PageEmbed.Style["height"] = "800px";
            PageEmbed.Style["border "] = "1";
            PageEmbed.Src = "https://www.stops.lt/" + asciiStra;
            var resultRoutes = string.Empty;
            var resultStops = string.Empty;
            using (var webClient = new System.Net.WebClient())
            {
                resultRoutes = webClient.DownloadString($"{PageEmbed.Src}/{asciiStra}/routes.txt");
                resultStops = webClient.DownloadString($"{PageEmbed.Src}/{asciiStra}/stops.txt");
            }
            using (StreamWriter writer = new StreamWriter(Server.MapPath("/App_Data/routes.txt")))
            {
                writer.Write(resultRoutes);
            }
            using (StreamWriter writer = new StreamWriter(Server.MapPath("/App_Data/stops.txt")))
            {
                writer.Write(resultStops);
            }
            FixStopsFile();
        }

        protected void FixStopsFile()
        {
            string ffixed = string.Empty;
            using (StreamReader reader = new StreamReader(Server.MapPath("/App_Data/stops.txt")))
            {
                while (!reader.EndOfStream)
                {
                    string[] collums = reader.ReadLine().Split(';');
                    ffixed += string.Join(";", new string[] { collums[0] , collums[4] }) + '\n';
                }
            }
            
            using (StreamWriter writer = new StreamWriter(Server.MapPath("/App_Data/stops.txt"), false))
            {
                writer.Write(ffixed);
            }
        }

        protected void BtnReturn_Click(object sender, EventArgs e)
        {
           Response.Redirect("~/MainPage.aspx");
        }
    }
}