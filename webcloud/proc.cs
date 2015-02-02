using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace webcloud
{
    public class proc
    {
        //string conn = ConfigurationSettings.AppSettings["conn"];
         
        public DataSet getdatakh()
        { 
            SqlConnection cnn;
           //cnn  =new SqlConnection(conn);
           //cnn.Open();
           DataSet ds = new DataSet();
            SqlCommand com = new SqlCommand("select*from tbl_KhachHang");
            SqlDataAdapter adap = new SqlDataAdapter(com);
            adap.Fill(ds);
           // cnn.Close();
           return ds;
        }
    }
}