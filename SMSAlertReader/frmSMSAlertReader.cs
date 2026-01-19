using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;



namespace SMSAlertReader
{
    public partial class frmSMSAlertReader : Form
    {

        WebReference.Service1 ws = new WebReference.Service1();
        SqlConnection conn = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=conferoserver;Integrated Security=True");
        String userid = "";
        String password = "";
        int applicationID = 0;
        public frmSMSAlertReader()
        {
            
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            String[] allnewRawStrings;

            allnewRawStrings = ws.getSubscribedMessages(userid, password, applicationID).ToArray();

            if (allnewRawStrings.Length != 0)
            {
                lblErrpr.Text = "Message received and processing";

                foreach (String singleString in allnewRawStrings)
                {
                    try
                    {

                        String[] arrayOfAttributes;
                        arrayOfAttributes = singleString.Split(',');

                        //dreamtcs, this one to be fixed

                        String sourcePhoneNumber = arrayOfAttributes[0].ToString();
                        String message = arrayOfAttributes[1].ToString();
                        DateTime datetime = DateTime.Parse(arrayOfAttributes[2].ToString());

                        arrayOfAttributes = message.Split(':');
                        if (arrayOfAttributes.Length == 4)
                        {
                            String description = arrayOfAttributes[0].ToString();
                            String value = arrayOfAttributes[1].ToString();
                            //the below is to purposely check to see if the string is in double format for long lat
                            String longtitude =(double.Parse( arrayOfAttributes[2].ToString())).ToString();
                            String latitude = (double.Parse( arrayOfAttributes[3].ToString())).ToString();

                            conn.Open();
                            SqlCommand cmd = new SqlCommand("INSERT INTO tblUserGeneratedInformation (description, value, long, lat, datetime,phoneNumber) VALUES     (@description,@value,@long,@lat,@datetime,@phoneNumber)", conn);
                            cmd.Parameters.Add("@description", SqlDbType.VarChar).Value = description;
                            cmd.Parameters.Add("@value", SqlDbType.VarChar).Value = value;
                            cmd.Parameters.Add("@long", SqlDbType.VarChar).Value = longtitude;
                            cmd.Parameters.Add("@lat", SqlDbType.VarChar).Value = latitude;
                            cmd.Parameters.Add("@datetime", SqlDbType.DateTime).Value = datetime;
                            cmd.Parameters.Add("@phoneNumber", SqlDbType.VarChar).Value = sourcePhoneNumber;
                            int rowaffected = -1;
                            rowaffected = cmd.ExecuteNonQuery();

                        }

                    }
                    catch (Exception ex)
                    {
                        lblErrpr.Text = ex.ToString();
                    }
                    finally
                    {

                        conn.Close();
                    }

                }

            }

            else {
                lblErrpr.Text = "No messages or invalid user";
            }


        }

        private void btnStart_Click(object sender, EventArgs e)
        {
          
            userid = txtUserName.Text;
            password = txtPassword.Text;
          
            try
            {
                applicationID = int.Parse(txtApplicationID.Text);
                btnStart.Enabled = false;
                btnStop.Enabled = true;
                pollingTimer.Start();
            }
            catch (Exception ex){
                lblErrpr.Text = "Application ID must in numeric";
            }
              
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            pollingTimer.Stop();
            btnStop.Enabled = false;
            btnStart.Enabled = true;
        }
    }
}
