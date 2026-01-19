using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Confero
{
    class DBUser
    {

        SqlConnection localconn;
        SqlConnection serverconn;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;
        SqlDataReader objReader;

        public DBUser()
        {
            localconn = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=conferoclient;Integrated Security=True");
            serverconn = new SqlConnection(@"Data Source=192.168.233.128.\sqlexpress;Initial Catalog=CONFEROSERVER;User ID=conferoclient;Password=password");
            cmd = new SqlCommand();
            cmd.Connection = localconn;
            da = new SqlDataAdapter();
            ds = new DataSet();
            
        }

      

        public int Get_UserId(string loginId, string password)
        {

            int userId=0;

          
            cmd = new SqlCommand();
            cmd.Connection = serverconn;

            try
            {
                serverconn.Open();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_Get_UserId";

                {
                    cmd.Parameters.Add("@loginID", SqlDbType.VarChar, 50).Value = loginId;
                    cmd.Parameters.Add("@password", SqlDbType.VarChar, 50).Value = password;
                }

                objReader = cmd.ExecuteReader();

                while ((objReader.Read()))
                {
                    userId =int.Parse( objReader["userID"].ToString());
                }
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
               
            }
            finally
            {
                serverconn.Close();
            }

            return userId;

        }
    }



}
