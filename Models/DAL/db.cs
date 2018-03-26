using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
namespace WebApi.Models.DAL
{
    public class db
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ToString());

        public DataSet getrecord()
        {
            string sqlcomd = "select StudentID,FirstName,LastName,Email,Address from tbl_Student";
            SqlCommand cmd = new SqlCommand(sqlcomd, con);
            con.Open();
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;

        }
       

            
            }
}