using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net;
using System.IO;
using System.Threading;
using System.Diagnostics;
using Microsoft.Win32;




namespace SMSGatewayHBM
{
    public partial class frmSMSGatewayHBM : Form
    {
        private SqlConnection conn;
        private SqlCommand cmdSelectIdentity;
        Process proc = new Process();
        public frmSMSGatewayHBM()
        {
          

            
            InitializeComponent();
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            try {

                openFileDialog1.ShowDialog();

                //proc.StartInfo = new ProcessStartInfo(@"C:\Program Files\SMSGateway\bin\SMSGateway.exe");
                proc.StartInfo = new ProcessStartInfo(openFileDialog1.FileName);

                proc.Start();
                conn = new SqlConnection(@"Data Source=SERVER20-F46E99\SQLEXPRESS;Database=SMSGateway;Integrated Security=True;");

                
                cmdSelectIdentity = new SqlCommand("SELECT DateTime FROM         tbl_Logging WHERE     (LoggingID =  (SELECT     MAX(LoggingID) AS Expr1  FROM          tbl_Logging AS tbl_Logging_1))", conn);
              
                timerHeartBeat.Start();
            }
            
            catch (Exception ex){
                Output(ex.ToString());
            }
        }

        private void timerHeartBeat_Tick(object sender, EventArgs e)
        {
            DateTime lastaccesseddate;
            DateTime now = DateTime.Now;

            try
            {
                conn.Open();
                lastaccesseddate = DateTime.Parse(cmdSelectIdentity.ExecuteScalar().ToString());
                if (lastaccesseddate.AddMinutes(1) < now)
                {
                    //dreamtcs

                    SqlCommand checkifreportdone = new SqlCommand("select count(*) from tbl_report where datetimeOfFailure = @datetimeOfFailure", conn);
                    checkifreportdone.Parameters.Add("@datetimeOfFailure", SqlDbType.DateTime).Value = lastaccesseddate;
                    int noOfRowsAffected = int.Parse(checkifreportdone.ExecuteScalar().ToString());

                    //if report not done
                    if (noOfRowsAffected == 0)
                    {
                        SqlCommand insertReport = new SqlCommand("insert into tbl_Report (datetimeOfFailure, recipientOfReport, reasonforreport) values (@datetimeofFailure, @recipientOfReport,@reasonforreport)", conn);
                        insertReport.Parameters.Add("@datetimeOfFailure", SqlDbType.DateTime).Value = lastaccesseddate;
                        insertReport.Parameters.Add("@recipientOfReport", SqlDbType.VarChar).Value = getReportingPhoneNumber();
                        insertReport.Parameters.Add("@reasonforreport", SqlDbType.VarChar).Value = "SMS Gateway Application stopped running";

                        noOfRowsAffected = insertReport.ExecuteNonQuery();
                        if (noOfRowsAffected == 1) {
                            WebClient client = new WebClient();
                            client.Headers.Add("user-agent", "Mozillia/4.0 (compatible; MSIE 6.0, Windows NT 5.2; .NET CLR 1.00.3705;)");
                            client.QueryString.Add("user", "micsmsgateway");
                            client.QueryString.Add("password", "test123");
                            client.QueryString.Add("api_id", "3077985");
                            client.QueryString.Add("to", getReportingPhoneNumber());
                            client.QueryString.Add("text", "SMS+Gateway+has+stopped+running");

                            String baseurl = "http://api.clickatell.com/http/sendmsg";

                            Stream data = client.OpenRead(baseurl);
                            StreamReader reader = new StreamReader(data);
                            String s = reader.ReadToEnd();
                            data.Close();
                            reader.Close();
                            txtoutput.Text = s;
                            proc.Kill();
                            Thread.Sleep(10000);
                            proc.Start();
                        }//end if report inserted
                       
                      

                      
                    }//end if report is not done
                }//if last accessed is long time ago
            }
            catch (Exception ex)
            {
                Output(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
           
        }

        private void Output(string text)
        {
          
                txtoutput.AppendText(text);
                txtoutput.AppendText("\r\n");
            
        }

        private String getReportingPhoneNumber()
        {
            SqlCommand getPhoneNumber;
            String reportingPhoneNumber="";
            try
            {
                getPhoneNumber = new SqlCommand("select reportingPhoneNumber from tbl_reportingPhoneNumber", conn);
                reportingPhoneNumber = getPhoneNumber.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                Output(ex.ToString());
            }

            return reportingPhoneNumber;
        }


    }
}
