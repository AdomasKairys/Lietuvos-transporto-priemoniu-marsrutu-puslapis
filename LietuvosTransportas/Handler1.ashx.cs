using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Script.Serialization;

namespace LietuvosTransportas
{
    /// <summary>
    /// Summary description for Handler1
    /// </summary>
    public class Handler1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string prefixText = context.Request.QueryString["q"];

            context.Response.ContentType = "application/json";

            List<string> countries = new List<string>();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString);
            string cmdText = "SELECT CountryName FROM country WHERE CountryName LIKE'" + prefixText + "%'";
            SqlCommand cmd = new SqlCommand(cmdText, con);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            List<string> obj = new List<string>();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj.Add(dr["CountryName"].ToString().Trim());
                }
            }

            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();

            context.Response.Write(jsSerializer.Serialize(obj));

            con.Close();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

    }
}