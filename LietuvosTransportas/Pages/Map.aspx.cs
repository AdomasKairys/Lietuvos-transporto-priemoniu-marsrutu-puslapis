using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LietuvosTransportas.Pages
{
    public partial class Map : System.Web.UI.Page
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
            PageEmbed.Style["width"] = "1400px";
            PageEmbed.Style["height"] = "800px";
            PageEmbed.Style["border "] = "1";
            string accentedStr = SearchBox.Text;
            byte[] tempBytes = System.Text.Encoding.GetEncoding("ISO-8859-8").GetBytes(accentedStr);
            string asciiStr = System.Text.Encoding.UTF8.GetString(tempBytes);
            asciiStr = asciiStr.ToLower();
            PageEmbed.Src = "https://www.stops.lt/" + $"{asciiStr}/#{asciiStr}/map,max" ;
        }

        protected void BtnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/MainPage.aspx");
        }
    }
}