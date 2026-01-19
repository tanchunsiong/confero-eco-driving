using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics;

using Microsoft.Win32;

using GsmComm.PduConverter;
using GsmComm.PduConverter.SmartMessaging;
using GsmComm.GsmCommunication;
using GsmComm.Interfaces;
using GsmComm.Server;

namespace SMSGateway
{
    public partial class frmSMSGateway : Form
    {
        private GsmCommMain comm;
        private delegate void SetTextCallback(string text);
        private SqlConnection conn;
        private static DateTime starttime = DateTime.Now;
        private String connString = @"Data Source=.\SQLEXPRESS;Database=SMSGateway;Integrated Security=True;";



                
        public frmSMSGateway()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            conn = new SqlConnection(connString);
            try
            {
                this.initialiseModem();
                conn.Open();
                SqlCommand updateTblLogging = new SqlCommand();
                updateTblLogging.Connection = conn;
                DateTime currentTime;
                currentTime = DateTime.Now;
                updateTblLogging.CommandText = "insert into tbl_logging (startDatetime, datetime) values (@currenttime,@datetime)";
                updateTblLogging.Parameters.Add("@currenttime", SqlDbType.DateTime).Value = currentTime;
                updateTblLogging.Parameters.Add("@datetime", SqlDbType.DateTime).Value = currentTime;
                updateTblLogging.ExecuteNonQuery();
                timerSendSMS.Start();
                timerReadSMS.Start();
                timerLogging.Start();
                timerBenchMark.Start();
            }
            catch (Exception ex)
            {
                Output(ex.ToString());
            }

            finally
            {
                conn.Close();
            }



        }//end form load

        private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            timerSendSMS.Stop();
            timerReadSMS.Stop();
            timerLogging.Stop();
            timerBenchMark.Stop();

            try
            {
                conn.Close();
            }
            catch (Exception ex)
            {
                Output(ex.ToString());
            }
            try
            {

                if (comm != null)
                {
                    // Unregister events
                    comm.PhoneConnected -= new EventHandler(comm_PhoneConnected);
                    comm.PhoneDisconnected -= new EventHandler(comm_PhoneDisconnected);


                    // Close connection to phone
                    if (comm != null && comm.IsOpen())
                        comm.Close();

                    comm = null;
                }

            } // Clean up comm object
            catch (Exception ex)
            {

                Output(ex.ToString());

            }
            foreach (Process p in Process.GetProcesses())
            {
                if (p.ProcessName.ToLower() == "SMSGateway.exe")
                    p.Kill();
            }

        }//end form closing

        private void initialiseModem()
        {

            try
            {
                comm = new GsmCommMain(4, 115200, 300);
                comm.PhoneConnected += new EventHandler(comm_PhoneConnected);
                comm.PhoneDisconnected += new EventHandler(comm_PhoneDisconnected);
                comm.Open();
                while (!comm.IsConnected())
                {

                    if (MessageBox.Show(this, "No phone connected.", "Connection setup",
                        MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation) == DialogResult.Cancel)
                    {
                        comm.Close();
                        return;
                    }

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Connection error: " + ex.Message, "Connection setup", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private string SendMessage(String message, String number)
        {
            string referenceNo = "0";
            try
            {

                // Send an SMS message
                SmsSubmitPdu pdu;

                pdu = new SmsSubmitPdu(message, number, "");

                //implementated as advanced feature    
                pdu.RequestStatusReport = true;


                comm.SendMessage(pdu);
                referenceNo = pdu.MessageReference.ToString();





            }
            catch (Exception ex)
            {
                ex.ToString();
            }

            return referenceNo;
        }

        private void Output(string text)
        {
            if (this.txtoutput.InvokeRequired)
            {
                SetTextCallback stc = new SetTextCallback(Output);
                this.Invoke(stc, new object[] { text });
            }
            else
            {
                txtoutput.AppendText(text);
                txtoutput.AppendText("\r\n");
            }
        }

        private string StatusToString(PhoneMessageStatus status)
        {
            // Map a message status to a string
            string ret;
            switch (status)
            {
                case PhoneMessageStatus.All:
                    ret = "All";
                    break;
                case PhoneMessageStatus.ReceivedRead:
                    ret = "Read";
                    break;
                case PhoneMessageStatus.ReceivedUnread:
                    ret = "Unread";
                    break;
                case PhoneMessageStatus.StoredSent:
                    ret = "Sent";
                    break;
                case PhoneMessageStatus.StoredUnsent:
                    ret = "Unsent";
                    break;
                default:
                    ret = "Unknown (" + status.ToString() + ")";
                    break;
            }
            return ret;
        }

        private void ShowMessage(SmsPdu pdu)
        {
            if (pdu is SmsSubmitPdu)
            {
                // Stored (sent/unsent) message
                SmsSubmitPdu data = (SmsSubmitPdu)pdu;
                Output("SENT/UNSENT MESSAGE");
                Output("Recipient: " + data.DestinationAddress);
                Output("Message text: " + data.UserDataText);
                Output("-------------------------------------------------------------------");
                return;
            }
            if (pdu is SmsDeliverPdu)
            {
                // Received message
                SmsDeliverPdu data = (SmsDeliverPdu)pdu;
                Output("RECEIVED MESSAGE");
                Output("Sender: " + data.OriginatingAddress);
                Output("Sent: " + data.SCTimestamp.ToString());
                Output("Message text: " + data.UserDataText);
                Output("-------------------------------------------------------------------");
                return;
            }
            if (pdu is SmsStatusReportPdu)
            {
                // Status report
                SmsStatusReportPdu data = (SmsStatusReportPdu)pdu;
                Output("STATUS REPORT");
                Output("Recipient: " + data.RecipientAddress);
                Output("Status: " + data.Status.ToString());
                Output("Timestamp: " + data.DischargeTime.ToString());
                Output("Message ref: " + data.MessageReference.ToString());
                Output("-------------------------------------------------------------------");
                return;
            }
            Output("Unknown message type: " + pdu.GetType().ToString());
        }

        private delegate void ConnectedHandler(bool connected);
      
        private void OnPhoneConnectionChange(bool connected)
        {

        }
      
        private void comm_PhoneConnected(object sender, EventArgs e)
        {
            this.Invoke(new ConnectedHandler(OnPhoneConnectionChange), new object[] { true });
        }

        private void comm_PhoneDisconnected(object sender, EventArgs e)
        {
            this.Invoke(new ConnectedHandler(OnPhoneConnectionChange), new object[] { false });
        }

        private void timerSendSMS_Tick(object sender, EventArgs e)
        {
            int noOfRowsAffected = 0;
            try
            {
                conn.Open();
                SqlCommand cmdSelectAllPendingSendSMS = new SqlCommand("select * from tbl_pendingToSendSMS", conn);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmdSelectAllPendingSendSMS;
                da.Fill(ds, "pendingSMS");
                //for each pending SMS in the database
                foreach (DataRow dr in ds.Tables["pendingSMS"].Rows)
                {

                    String referenceNo = "0";
                    referenceNo = SendMessage(dr[1].ToString(), dr[2].ToString());
                    //if reference number is given
                    if (!referenceNo.Equals("0"))
                    {
                        SqlCommand addtoSentDatabase = new SqlCommand("INSERT INTO tbl_SentSMS(SentSMSID, message, destinationAddress, ownerID, referenceNo) VALUES (@SMSID,@message,@destinationAddress,@ownerID,@referenceNo)", conn);
                        addtoSentDatabase.Parameters.Add("@SMSID", SqlDbType.Int).Value = int.Parse(dr[0].ToString());
                        addtoSentDatabase.Parameters.Add("@message", SqlDbType.VarChar).Value = dr[1].ToString();
                        addtoSentDatabase.Parameters.Add("@destinationAddress", SqlDbType.VarChar).Value = dr[2].ToString();
                        addtoSentDatabase.Parameters.Add("@ownerID", SqlDbType.Int).Value = int.Parse(dr[3].ToString());
                        addtoSentDatabase.Parameters.Add("@referenceNo", SqlDbType.VarChar).Value = referenceNo;
                        noOfRowsAffected = addtoSentDatabase.ExecuteNonQuery();
                        //if added successfully to database
                        if (noOfRowsAffected == 1)
                        {
                            SqlCommand removefromPendingDatabase = new SqlCommand("DELETE FROM tbl_pendingToSendSMS where pendingSMSID = @SMSID", conn);
                            removefromPendingDatabase.Parameters.Add("SMSID", SqlDbType.Int).Value = int.Parse(dr[0].ToString());
                            removefromPendingDatabase.ExecuteNonQuery();
                        }

                    }
                    //if no reference number is given
                    else
                    {

                        SqlCommand addtoSentDatabase = new SqlCommand("INSERT INTO tbl_SentSMS(SentSMSID, message, destinationAddress, ownerID, referenceNo) VALUES (@SMSID,@message,@destinationAddress,@ownerID,@referenceNo)", conn);
                        addtoSentDatabase.Parameters.Add("@SMSID", SqlDbType.Int).Value = int.Parse(dr[0].ToString());
                        addtoSentDatabase.Parameters.Add("@message", SqlDbType.VarChar).Value = dr[1].ToString();
                        addtoSentDatabase.Parameters.Add("@destinationAddress", SqlDbType.VarChar).Value = dr[2].ToString();
                        addtoSentDatabase.Parameters.Add("@ownerID", SqlDbType.Int).Value = int.Parse(dr[3].ToString());
                        addtoSentDatabase.Parameters.Add("@referenceNo", SqlDbType.VarChar).Value = "Failed to sent";
                        noOfRowsAffected = addtoSentDatabase.ExecuteNonQuery();
                        //if added successfully to database
                        if (noOfRowsAffected == 1)
                        {
                            SqlCommand removefromPendingDatabase = new SqlCommand("DELETE FROM tbl_pendingToSendSMS where pendingSMSID = @SMSID", conn);
                            removefromPendingDatabase.Parameters.Add("SMSID", SqlDbType.Int).Value = int.Parse(dr[0].ToString());
                            removefromPendingDatabase.ExecuteNonQuery();
                        }
                    }//end if message send



                }//end for each


            }
            catch (Exception ex)
            {
                Output(ex.ToString());
            }
            finally
            {
                conn.Close();
            }


        }//end timer

        private void timerReadSMS_Tick(object sender, EventArgs e)
        {
            int noOfRowsAffected = 0;

            try
            {

                string storage = PhoneStorageType.Sim;
                //can be PhoneStorageType.Phone;

                // Read all SMS messages from the storage
                DecodedShortMessage[] messages = comm.ReadMessages(PhoneMessageStatus.All, storage);
                foreach (DecodedShortMessage message in messages)
                {


                    SmsPdu pdu;
                    pdu = message.Data;
              
                    //if sms is special
                    if (pdu is SmsSubmitPdu)
                    {

                        // Stored (sent/unsent) message in to database
                        SmsSubmitPdu data = (SmsSubmitPdu)pdu;
                        SqlCommand insertintospecialreceivedsms = new SqlCommand();
                        insertintospecialreceivedsms.Connection = conn;
                        insertintospecialreceivedsms.CommandText = "INSERT INTO tbl_specialReceivedSMS (message, destination, typeofsms) VALUES     (@message,@destination,@type)";
                        insertintospecialreceivedsms.Parameters.Add("@message", SqlDbType.VarChar).Value = data.UserDataText;
                        insertintospecialreceivedsms.Parameters.Add("@destination", SqlDbType.VarChar).Value = data.DestinationAddress;
                        insertintospecialreceivedsms.Parameters.Add("@type", SqlDbType.VarChar).Value = data.GetType().ToString();

                        try
                        {
                            conn.Open();
                            noOfRowsAffected = insertintospecialreceivedsms.ExecuteNonQuery();
                            //if successfully added to database, delete message phone
                            if (noOfRowsAffected == 1)
                            {
                                int index = message.Index;
                                try
                                {
                                    // Delete the message with the specified index from storage

                                    comm.DeleteMessage(index, storage);

                                }
                                catch (Exception ex)
                                {
                                    Output(ex.ToString());
                                }
                            }//end if successfully added to database, delete message from phone
                        }

                        catch (Exception ex)
                        {
                            Output(ex.ToString());
                        }//end try catch
                        finally
                        {
                            conn.Close();
                        }//end try catch to insert and delete from phone
                    }//end if sms is special

                    //if sms from person
                    if (pdu is SmsDeliverPdu)
                    {


                        SmsDeliverPdu data = (SmsDeliverPdu)pdu; //casting
                        String originator = data.OriginatingAddress;
                        DateTime datetimereceived = data.SCTimestamp.ToDateTime();
                        String receivedmessage = data.UserDataText;
                        receivedmessage.Trim();
                        //try to insert into database
                        Char[] whitespace = {' '};
                        
                        try
                        {
                            conn.Open();
                            SqlCommand checkforexistingSubID = new SqlCommand("SELECT     COUNT(*) AS Expr1 FROM         tbl_MessageSubscription WHERE     (messageSubscriptionID = @messagesubscriptionID)", conn);
                            try
                            {

                                if (receivedmessage.IndexOfAny(whitespace) != -1)
                                {
                                    checkforexistingSubID.Parameters.Add("@messagesubscriptionID", SqlDbType.VarChar).Value = (receivedmessage.Remove(receivedmessage.IndexOfAny(whitespace))).ToLower();
                                    noOfRowsAffected = int.Parse(checkforexistingSubID.ExecuteScalar().ToString());
                                }
    
                              
                            }
                            catch (Exception ex)
                            {

                                checkforexistingSubID.Parameters.Add("@messagesubscriptionID", SqlDbType.VarChar).Value = null;
                                noOfRowsAffected = 0;
                                Output(ex.ToString());

                            }

                            //message subscription ID exist
                            if (noOfRowsAffected == 1)
                            {

                                SqlCommand insertintoreceivedsms = new SqlCommand();
                                insertintoreceivedsms.Connection = conn;
                                insertintoreceivedsms.CommandText = "INSERT INTO tbl_ReceivedSMS (message, SourcePhoneNumber, datetimereceived, messageSubscriptionID) VALUES     (@message,@sourcePhoneNumber,@datetimereceived, @messageSubscriptionID)";
                                insertintoreceivedsms.Parameters.Add("@message", SqlDbType.VarChar).Value = receivedmessage.Substring(receivedmessage.IndexOfAny(whitespace) + 1).Trim();
                                insertintoreceivedsms.Parameters.Add("@messagesubscriptionID", SqlDbType.VarChar).Value = (receivedmessage.Remove(receivedmessage.IndexOfAny(whitespace))).ToLower();
                                insertintoreceivedsms.Parameters.Add("@sourcePhoneNumber", SqlDbType.VarChar).Value = originator;
                                insertintoreceivedsms.Parameters.Add("@datetimereceived", SqlDbType.DateTime).Value = datetimereceived;
                                noOfRowsAffected = insertintoreceivedsms.ExecuteNonQuery();
                                //if successfully added to database
                                if (noOfRowsAffected == 1)
                                {
                                    int index = message.Index;
                                    try
                                    {
                                        // Delete the message with the specified index from storage

                                        comm.DeleteMessage(index, storage);

                                    }
                                    catch (Exception ex)
                                    {
                                        Output(ex.ToString());
                                    }
                                }//end if succesfully added to database
                            }//end if subscription exist
                            //message subscription ID does not exist
                            else {
                                //remove message from phone
                                int index = message.Index;
                                try
                                {
                                    // Delete the message with the specified index from storage

                                    comm.DeleteMessage(index, storage);

                                }
                                catch (Exception ex)
                                {
                                    Output(ex.ToString());
                                }
                            }
                        }
                        catch (Exception Ex)
                        {
                            Output(Ex.ToString());
                        }
                        finally
                        {
                            conn.Close();
                        }

                    }//end if message from  person

                    //if message status report from service provider
                    if (pdu is SmsStatusReportPdu)
                    {
                        // Status report
                        SmsStatusReportPdu data = (SmsStatusReportPdu)pdu;

                        //if message is successfully sent by the sms modem
                        if (data.Status.ToString().Trim().Equals("OK_Received"))
                        {
                            //update the database
                            SqlCommand updateSentSMS = new SqlCommand();
                            updateSentSMS.Connection = conn;
                            updateSentSMS.CommandText = "UPDATE tbl_SentSMS SET successful = @status, datetimesent = @datetimesent where referenceNo = @referenceNo";
                            updateSentSMS.Parameters.Add("@referenceNo", SqlDbType.VarChar).Value = data.MessageReference.ToString();
                            updateSentSMS.Parameters.Add("@status", SqlDbType.VarChar).Value = "true";
                            updateSentSMS.Parameters.Add("@datetimesent", SqlDbType.DateTime).Value = data.DischargeTime.ToDateTime();

                            //update usage of user, + 1 to usage
                            SqlCommand updateUsageCount = new SqlCommand();
                            updateUsageCount.Connection = conn;

                            //to disable crediting
                          //  updateUsageCount.CommandText = "UPDATE    tbl_Users SET              currentUsage = currentUsage + 1 WHERE     (userID =  (SELECT     ownerID  FROM          tbl_SentSMS  WHERE      (referenceNo = @referenceNo)))";
                          // updateUsageCount.Parameters.Add("@referenceNo", SqlDbType.VarChar).Value = data.MessageReference.ToString();


                            try
                            {
                                conn.Open();
                                noOfRowsAffected = updateSentSMS.ExecuteNonQuery();
                                //if SMS status successfully updated
                                if (noOfRowsAffected == 1)
                                {
                                    //to disable crediting
                                    //   noOfRowsAffected = updateUsageCount.ExecuteNonQuery();
                                   
                                        int index = message.Index;
                                        try
                                        {
                                            // Delete the message with the specified index from storage

                                            comm.DeleteMessage(index, storage);

                                        }
                                        catch (Exception ex)
                                        {
                                            Output(ex.ToString());
                                        }
                                    }//end if usage count successfully updated, delete from phone
                                }// end if SMS status successfully updated
                            

                            catch (Exception ex)
                            {
                                Output(ex.ToString());
                            }//end try catch
                            finally
                            {
                                conn.Close();
                            }
                        }//end if message is successfully sent to person
                        else 
                        {
                            //update the database
                            SqlCommand updateSentSMS = new SqlCommand();
                            updateSentSMS.Connection = conn;
                            updateSentSMS.CommandText = "UPDATE tbl_SentSMS SET successful = @status, datetimesent = @datetimesent where referenceNo = @referenceNo";
                            updateSentSMS.Parameters.Add("@referenceNo", SqlDbType.VarChar).Value = data.MessageReference.ToString();
                            updateSentSMS.Parameters.Add("@status", SqlDbType.VarChar).Value = data.Status.ToString().Trim();
                            updateSentSMS.Parameters.Add("@datetimesent", SqlDbType.DateTime).Value = data.DischargeTime.ToDateTime();

                        

                            try
                            {
                                conn.Open();
                                noOfRowsAffected = updateSentSMS.ExecuteNonQuery();
                                //if SMS status successfully updated
                                if (noOfRowsAffected == 1)
                                {
                                   
                                    
                                        int index = message.Index;
                                        try
                                        {
                                            // Delete the message with the specified index from storage

                                            comm.DeleteMessage(index, storage);

                                        }
                                        catch (Exception ex)
                                        {
                                            Output(ex.ToString());
                                        }
                                    }//end if usage count successfully updated, delete from phone

                            }// end if SMS status successfully updated

                            catch (Exception ex)
                            {
                                Output(ex.ToString());
                            }//end try catch
                            finally
                            {
                                conn.Close();
                            }
                        }
                    }//end if its a pdu report

                }//end for each

            }
            catch (Exception ex)
            {
                Output(ex.ToString());

            }//end try catch for reaching all messages in phone

        }//end timer read sms

        private void timerLogging_Tick(object sender, EventArgs e)
        {
            //dreamtcs, need to think of way to only run this once and register into memory
            //try
            //{
            //    if (!comm.IsConnected())
            //    {

            //        WebClient client = new WebClient();
            //        client.Headers.Add("user-agent", "Mozillia/4.0 (compatible; MSIE 6.0, Windows NT 5.2; .NET CLR 1.00.3705;)");
            //        client.QueryString.Add("user", "micsmsgateway");
            //        client.QueryString.Add("password", "test123");
            //        client.QueryString.Add("api_id", "3077985");
            //        client.QueryString.Add("to", getReportingPhoneNumber());
            //        client.QueryString.Add("text", "Modem+is+disconnected+or+powered+off");

            //        String baseurl = "http://api.clickatell.com/http/sendmsg";

            //        Stream data = client.OpenRead(baseurl);
            //        StreamReader reader = new StreamReader(data);
            //        String s = reader.ReadToEnd();

            //        data.Close();
            //        reader.Close();

            //         Output( s);

            //        SqlCommand insertReport = new SqlCommand("insert into tbl_Report (datetimeOfFailure, recipientOfReport, reasonforreport) values (@datetimeofFailure, @recipientOfReport,@reasonforreport)", conn);
            //        insertReport.Parameters.Add("@datetimeOfFailure", SqlDbType.DateTime).Value = lastaccesseddate;
            //        insertReport.Parameters.Add("@recipientOfReport", SqlDbType.VarChar).Value = getReportingPhoneNumber();
            //        insertReport.Parameters.Add("@reasonforreport", SqlDbType.VarChar).Value = "Modem is disconnected or powered off";
            //        insertReport.ExecuteNonQuery();
            //    }
            //    else
            //    { 
            //    }
            //}
            //catch (Exception ex)
            //{
            //   Output( ex.ToString());
            //}

            SqlCommand updateTblLogging = new SqlCommand();
            updateTblLogging.Connection = conn;
            DateTime currentime;
            currentime = DateTime.Now;
            TimeSpan ts = currentime.Subtract(starttime);
            lblUptime.Text = "Gateway has been running for " + ts + " since " + starttime.ToString();
            updateTblLogging.CommandText = "update tbl_logging set Datetime=@currenttime where LoggingID = (select max(loggingID) from tbl_logging)";
            updateTblLogging.Parameters.Add("@currenttime", SqlDbType.DateTime).Value = currentime;
            try
            {
                conn.Open();
                updateTblLogging.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                Output(ex.ToString());
            }
            finally
            {
                conn.Close();
            }


            SqlCommand checkifexist = new SqlCommand("SELECT     COUNT(*) AS tbl_runningMonths FROM         tbl_runningMonths WHERE     (month = @month) AND (year = @year)", conn);
            checkifexist.Parameters.Add("@month", SqlDbType.Int).Value = DateTime.Now.Month;
            checkifexist.Parameters.Add("@year", SqlDbType.Int).Value = DateTime.Now.Year;



            try
            {
                conn.Open();
                //if current month doesn't exist yet
                if (int.Parse(checkifexist.ExecuteScalar().ToString()) != 1)
                {
                    SqlCommand updateRunningMonth = new SqlCommand("INSERT INTO tbl_runningMonths (month, year, monthyear, datetime) VALUES (@month, @year, @monthyear, @datetime)", conn);
                    updateRunningMonth.Parameters.Add("@month", SqlDbType.Int).Value = DateTime.Now.Month;
                    updateRunningMonth.Parameters.Add("@year", SqlDbType.Int).Value = DateTime.Now.Year;
                    updateRunningMonth.Parameters.Add("@datetime", SqlDbType.DateTime).Value = DateTime.Now;
                    String monthString = "";
                    int monthInt = DateTime.Now.Month;
                    if (monthInt == 1)
                    {
                        monthString = "Jan";
                    }
                    if (monthInt == 2)
                    {
                        monthString = "Feb";
                    }
                    if (monthInt == 3)
                    {
                        monthString = "Mar";
                    }
                    if (monthInt == 4)
                    {
                        monthString = "Apr";
                    }
                    if (monthInt == 5)
                    {
                        monthString = "May";
                    }
                    if (monthInt == 6)
                    {
                        monthString = "Jun";
                    }
                    if (monthInt == 7)
                    {
                        monthString = "July";
                    }
                    if (monthInt == 8)
                    {
                        monthString = "Aug";
                    }
                    if (monthInt == 9)
                    {
                        monthString = "Sep";
                    }
                    if (monthInt == 10)
                    {
                        monthString = "Oct";
                    }
                    if (monthInt == 11)
                    {
                        monthString = "Nov";
                    }
                    if (monthInt == 12)
                    {
                        monthString = "Dec";
                    }

                    updateRunningMonth.Parameters.Add("@monthyear", SqlDbType.VarChar).Value = monthString + " " + DateTime.Now.Year.ToString();
                    updateRunningMonth.ExecuteNonQuery();
                }
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

       
        private void timerBenchMark_Tick(object sender, EventArgs e)
        {
            SqlCommand countsent = new SqlCommand("SELECT     COUNT(*) AS Expr1 FROM         tbl_SentSMS WHERE     (datetimesent > DATEADD(mi, - 1, CURRENT_TIMESTAMP))", conn);
            SqlCommand countreceived = new SqlCommand("SELECT     COUNT(*) AS Expr1 FROM         tbl_ProcessedReceivedSMS WHERE     (datetimereceived > DATEADD(mi, - 1, CURRENT_TIMESTAMP))", conn);
            SqlCommand countpendingreceived = new SqlCommand("SELECT     COUNT(*) AS Expr1 FROM  tbl_ReceivedSMS WHERE     (datetimereceived > DATEADD(mi, - 1, CURRENT_TIMESTAMP))", conn);



            try
            {
                conn.Open();

                int noofsmssent = int.Parse(countsent.ExecuteScalar().ToString());
                int noofsmsreceived = int.Parse(countreceived.ExecuteScalar().ToString());
                int noofsmspendingreceived = int.Parse(countpendingreceived.ExecuteScalar().ToString());
                //if there are messages processed in the last minute
                if (noofsmsreceived != 0 && noofsmsreceived != 0 && noofsmspendingreceived != 0)
                {
                    SqlCommand insertintoBenchmark = new SqlCommand("INSERT INTO tbl_benchmark   (smsSent, smsReceived, datetime, both) VALUES     (@smsSent,@smsReceived,@datetime,@both)", conn);
                    insertintoBenchmark.Parameters.Add("@smsSent", SqlDbType.Int).Value = noofsmssent;
                    int totalsmsreceived = noofsmspendingreceived + noofsmsreceived;
                    insertintoBenchmark.Parameters.Add("@smsReceived", SqlDbType.Int).Value = totalsmsreceived;
                    insertintoBenchmark.Parameters.Add("@datetime", SqlDbType.DateTime).Value = DateTime.Now;
                    insertintoBenchmark.Parameters.Add("@both", SqlDbType.Int).Value = (totalsmsreceived + noofsmssent);
                    insertintoBenchmark.ExecuteNonQuery();
                }
            }

            catch (Exception ex)
            {
                Output(ex.ToString());
            }
            finally
            {
                conn.Close();
            }



        }//end timer benchmark

        public bool testConnection()
        {
            bool returnvalue = false;
            try
            {
                conn.Open();
                returnvalue = true;
            }
            catch (Exception ex)
            {
                Output(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
            return returnvalue;
        }

    }//end class



}//end namespace
