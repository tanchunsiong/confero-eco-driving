Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports System.Data.SqlClient
Imports Microsoft.Win32
Imports System.Threading

Imports Microsoft.VisualBasic
Imports System.Data.Sql
Imports System.Data
Imports System.Web.HttpResponse


<System.Web.Services.WebService(Namespace:="http://labs.innovativesingapore.com/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class WebService
    Inherits System.Web.Services.WebService

    Dim connString As String = ConfigurationManager.ConnectionStrings("DatabaseConnectionString").ConnectionString
    Dim conn As New SqlConnection(connString)


    <WebMethod()> _
    Public Function SendSMS(ByVal message As String, ByVal destinationNumber As String, ByVal username As String, ByVal password As String) As String
        Dim userID As Integer = getUserID(username.Trim, password.Trim)
        Dim returnmessage As String = "Error sending message"
        If userID <> 0 Then
            Dim noOfRowsAffected As Integer = 0
            Dim checkAccountcmd As New SqlCommand
            checkAccountcmd.CommandText = "SELECT COUNT(*) AS Expr1  FRom tbl_Users WHERE     (userID = @userID) AND (currentUsage < totalLimit) AND (status='active') "
            checkAccountcmd.Parameters.Add("@userID", SqlDbType.Int).Value = userID
            checkAccountcmd.Connection = conn
            Try
                conn.Open()
                noOfRowsAffected = checkAccountcmd.ExecuteScalar
                'if the account exist and there is still capacity is send sms, or it is an administrator
                If noOfRowsAffected = 1 Then
                    Dim cmd As New SqlCommand
                    cmd.Connection = conn
                    cmd.CommandText = "INSERT INTO tbl_pendingToSendSMS (message, ownerID, destinationAddress) VALUES (@message,@ownerID,@destinationAddress)"
                    cmd.Parameters.Add("@message", SqlDbType.VarChar).Value = message.Trim
                    cmd.Parameters.Add("@ownerid", SqlDbType.Int).Value = userID
                    cmd.Parameters.Add("@destinationAddress", SqlDbType.VarChar).Value = destinationNumber.Trim
                    noOfRowsAffected = cmd.ExecuteNonQuery()
                    'if added succesfully to the database
                    If noOfRowsAffected = 1 Then

                        'minus credit
                        Dim updateUsageCount As New SqlCommand

                        updateUsageCount.Connection = conn

                        updateUsageCount.CommandText = "UPDATE tbl_Users SET currentUsage = currentUsage + 1 WHERE     (userID = @ownerid)"
                        updateUsageCount.Parameters.Add("@ownerid", SqlDbType.VarChar).Value = userID
                        noOfRowsAffected = updateUsageCount.ExecuteNonQuery()

                        If noOfRowsAffected = 1 Then
                            returnmessage = "Message sending is pending, credit has been deducted"

                        End If
                    End If
                Else
                    returnmessage = "Either you do not have sufficient credit or your account is disabled"
                End If
            Catch ex As Exception
                'below string for debugging only
                '  returnmessage = ex.ToString()
            Finally
                conn.Close()
            End Try

        End If
        Return returnmessage
    End Function

    <WebMethod()> _
      Public Function checkvalidity(ByVal message As String, ByVal destinationNumber As String, ByVal username As String, ByVal password As String) As String
        Dim userID As Integer = getUserID(username.Trim, password.Trim)
        Dim returnmessage As String = "Error getting validity"
        If userID <> 0 Then
            Dim noOfRowsAffected As Integer = 0
            Dim checkAccountcmd As New SqlCommand
            checkAccountcmd.CommandText = "SELECT COUNT(*) AS Expr1  FRom tbl_Users WHERE     (userID = @userID)"
            checkAccountcmd.Parameters.Add("@userID", SqlDbType.Int).Value = userID
            checkAccountcmd.Connection = conn
            Try
                conn.Open()
                noOfRowsAffected = checkAccountcmd.ExecuteScalar
                'if the account exist 
                If noOfRowsAffected = 1 Then
                    Dim cmd As New SqlCommand
                    cmd.Connection = conn
                    cmd.CommandText = "select successful from tbl_SentSMS where message = @message and destinationaddress = @destinationaddress and ownerid =@ownerid"
                    cmd.Parameters.Add("@message", SqlDbType.VarChar).Value = message.Trim
                    cmd.Parameters.Add("@ownerid", SqlDbType.Int).Value = userID
                    cmd.Parameters.Add("@destinationAddress", SqlDbType.VarChar).Value = destinationNumber.Trim
                    returnmessage = cmd.ExecuteScalar


                Else
                    returnmessage = "Your account is invalid"
                End If
            Catch ex As Exception
                'below string for debugging only
                '  returnmessage = ex.ToString()
            Finally
                conn.Close()
            End Try

        End If
        Return returnmessage
    End Function

    <WebMethod()> _
    Public Function getSubscribedMessages(ByVal username As String, ByVal password As String, ByVal applicationID As Integer) As String()
        Dim objArraylist As New ArrayList

        Dim tempString As String

        Dim userID As Integer = 0
        Dim SMSID As Integer = 0
        Dim message As String = Nothing
        Dim datetimereceived As Date
        Dim sourcePhoneNumber As String = Nothing
        Dim messagesubscriptionID As String = Nothing
        Dim noOfRowsAffected As Integer = 0
        Dim objadapter As New SqlDataAdapter
        Dim objds As New DataSet
        Dim objdr As DataRow


        Dim cmd As New SqlCommand
        cmd.Connection = conn
        cmd.CommandText = "SELECT tbl_ReceivedSMS.*, tbl_Users.userID  FROM         tbl_Users INNER JOIN                      tbl_applications INNER JOIN                      tbl_MessageSubscription INNER JOIN                      tbl_ReceivedSMS ON tbl_MessageSubscription.messageSubscriptionID = tbl_ReceivedSMS.messageSubscriptionID ON                       tbl_applications.applicationID = tbl_MessageSubscription.applicationID ON tbl_Users.userID = tbl_MessageSubscription.userID WHERE     (tbl_Users.userName = @username) AND (tbl_Users.password = @password) AND (tbl_applications.applicationID = @applicationID)"
        cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = username
        cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = password
        cmd.Parameters.Add("@applicationID", SqlDbType.Int).Value = applicationID

        Try
            conn.Open()
            objadapter.SelectCommand = cmd
            objadapter.Fill(objds, "tbl_ReceivedSMS")


            For Each objdr In objds.Tables("tbl_ReceivedSMS").Rows
                tempString = ""
                SMSID = objdr("pendingReceivedSMSID")
                message = objdr("message")
                sourcePhoneNumber = objdr("SourcePhoneNumber")
                datetimereceived = objdr("datetimereceived")
                messagesubscriptionID = objdr("messagesubscriptionID")
                userID = objdr("userID")

                tempString = sourcePhoneNumber + "," + message + "," + datetimereceived.ToString()


                Dim addtotblProcessedReceivedSms As New SqlCommand
                addtotblProcessedReceivedSms.Connection = conn
                addtotblProcessedReceivedSms.CommandText = "INSERT INTO tbl_ProcessedReceivedSMS (processedReceivedSMS, message, SourcePhoneNumber, datetimereceived, receivedByUserID, messageSubscriptionID) VALUES        (@id,@message,@source,@datetimereceived,@receivedByUserID,@messageSubscriptionID)"
                addtotblProcessedReceivedSms.Parameters.Add("@id", SqlDbType.Int).Value = SMSID
                addtotblProcessedReceivedSms.Parameters.Add("@message", SqlDbType.VarChar).Value = message
                addtotblProcessedReceivedSms.Parameters.Add("@source", SqlDbType.VarChar).Value = sourcePhoneNumber
                addtotblProcessedReceivedSms.Parameters.Add("@datetimereceived", SqlDbType.DateTime).Value = datetimereceived
                addtotblProcessedReceivedSms.Parameters.Add("@receivedByUserID", SqlDbType.Int).Value = userID
                addtotblProcessedReceivedSms.Parameters.Add("@messageSubscriptionID", SqlDbType.VarChar).Value = messagesubscriptionID
                noOfRowsAffected = addtotblProcessedReceivedSms.ExecuteNonQuery()
                If noOfRowsAffected = 1 Then
                    Dim removeFromtblReceivedSMScmd As New SqlCommand
                    removeFromtblReceivedSMScmd.Connection = conn
                    removeFromtblReceivedSMScmd.CommandText = "DELETE FROM tbl_ReceivedSMS WHERE pendingReceivedSMSID = @id"
                    removeFromtblReceivedSMScmd.Parameters.Add("@id", SqlDbType.Int).Value = SMSID
                    noOfRowsAffected = removeFromtblReceivedSMScmd.ExecuteNonQuery()
                    If noOfRowsAffected = 1 Then

                        objArraylist.Add(tempString)
                    End If
                End If

            Next


        Catch ex As Exception
            'below string for debugging purposes only
            'tempString = ex.ToString()

        Finally
            conn.Close()
        End Try
        Return objArraylist.ToArray(GetType(String))

    End Function

    Private Function getUserID(ByVal username As String, ByVal password As String) As Integer

        Dim cmd As New SqlCommand
        cmd.Connection = conn
        cmd.CommandText = "select count(*) from tbl_users where userName = @username and password = @password and status='active'"
        cmd.Parameters.Add("username", SqlDbType.VarChar).Value = username
        cmd.Parameters.Add("password", SqlDbType.VarChar).Value = password
        Dim noOfResults As Integer
        Dim userID As Integer = 0
        Try
            conn.Open()
            noOfResults = cmd.ExecuteScalar
            If noOfResults >= 1 Then
                Dim cmdQueryUserID As New SqlCommand
                cmdQueryUserID.Connection = conn
                cmdQueryUserID.CommandText = "SELECT userID FROM tbl_Users WHERE (userName = @username) AND (password = @password) AND (status = 'active')"
                cmdQueryUserID.Parameters.Add("@username", SqlDbType.VarChar).Value = username
                cmdQueryUserID.Parameters.Add("@password", SqlDbType.VarChar).Value = password
                userID = cmdQueryUserID.ExecuteScalar
                cmdQueryUserID.Dispose()
            End If
        Catch ex As Exception
            ex.ToString()
        Finally
            conn.Close()
        End Try

        Return userID
    End Function

    Private Sub createKey()
        Dim regkey As RegistryKey
        regkey = Registry.LocalMachine.OpenSubKey("SOFTWARE", True)
        regkey.CreateSubKey("SMSGateway")
        regkey.Close()
    End Sub
    Private Sub updateKey(ByVal path As String)
        Dim regkey As RegistryKey
        regkey = Registry.LocalMachine.OpenSubKey("SOFTWARE\SMSGateway", True)
        Dim newconnString As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=" + path + ";Integrated Security=True;User Instance=True"
        regkey.SetValue("ConnString", newconnString)

    End Sub

    Private Function getKey() As String
        Dim regkey As RegistryKey
        regkey = Registry.LocalMachine.OpenSubKey("SOFTWARE\SMSGateway", True)
        Dim regConnString As String = regkey.GetValue("ConnString").ToString()
        Return regConnString

    End Function

End Class
