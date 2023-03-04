using System;

namespace LietuvosTransportas
{
    public partial class Page1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnShowFull_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/FullList.aspx");
        }

        protected void BtnSearch1_Click(object sender, EventArgs e)
        {

        }

        protected void BtnSearch2_Click(object sender, EventArgs e)
        {

        }

        protected void BtnMap_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Map.aspx");
        }
    }
}