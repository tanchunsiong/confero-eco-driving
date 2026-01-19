using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Collections;



namespace Confero
{
    class CDBSync
    {
        public ArrayList getUserGeneratedInformation(){
            ArrayList objarraylist = new ArrayList();
            CUserGeneratedInformation cugi;

            SqlConnection conn = new SqlConnection(@"Data Source=192.168.233.128\sqlexpress;Initial Catalog=CONFEROSERVER;User ID=conferoclient;Password=password");
         //dreamtcs disabled
          string sqlcommand = "SELECT        UserGenerateInformationID, description, value, long, lat, dateTime, phoneNumber FROM            tblUserGeneratedInformation WHERE        (dateTime > DATEADD(mi, - 15, { fn NOW() }))";
         //   string sqlcommand = "SELECT        tblUserGeneratedInformation.* FROM            tblUserGeneratedInformation";
            SqlCommand cmd = new SqlCommand(sqlcommand, conn);

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            
            try
            {
                conn.Open();
                
                da.Fill(ds);
                foreach (DataRow dr in ds.Tables[0].Rows) {
                    cugi = new CUserGeneratedInformation();
                    cugi.Description = dr[1].ToString();
                    cugi.Value = dr[2].ToString();
                    cugi.longti = dr[3].ToString();
                    cugi.Lat = dr[4].ToString();
                    objarraylist.Add(cugi);
                }
            }

            catch (Exception ex) {
                ex.ToString();
            }
            finally
            {
                conn.Close();
            }
            return objarraylist;
        }
    }
}
