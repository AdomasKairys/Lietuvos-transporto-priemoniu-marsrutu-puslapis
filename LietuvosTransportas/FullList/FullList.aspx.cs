using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Services;

namespace LietuvosTransportas
{
    public partial class Page2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnShowLongDistance_Click(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static List<string> citySearch(string prefixText)
        {
            List<string> customers = new List<string>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select contactName As Name  from Customers where " +
                    "contactName like @SearchText + '%'";
                    cmd.Parameters.AddWithValue("@SearchText", prefixText);
                    cmd.Connection = conn;
                    conn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            customers.Add(dr["Name"].ToString());
                        }
                    }
                    conn.Close();
                }

            }
            return customers;
        }
    }
}