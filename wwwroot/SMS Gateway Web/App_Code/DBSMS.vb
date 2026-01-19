Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Imports System.Data.Sql
Imports System.Data
Imports System.Web.HttpResponse

Public Class DBSMS

    Dim conn As New SqlConnection(ConfigurationManager.ConnectionStrings("DatabaseConnectionString").ConnectionString)

    Public Function getAllSMSReceived() As ArrayList
        Dim objArraylist As New ArrayList
        Dim objadapter As New SqlDataAdapter
        Dim objDs As New DataSet
        Dim objcmd As New SqlCommand
        Dim objDr As DataRow
        objcmd.Connection = conn

        Try
            conn.Open()
            objcmd.CommandText = "select * from tbl_ProcessedReceivedSMS"
            objadapter.SelectCommand = objcmd
            objadapter.Fill(objDs, "tbl_ReceivedSMS")
            For Each objDr In objDs.Tables("tbl_ReceivedSMS").Rows
                Dim objSMS As New SMS
                objSMS.processedReceivedSMS = objDr("ProcessedReceivedSMS")
                objSMS.message = objDr("message")
                objSMS.SourcePhoneNumber = objDr("sourcePhoneNumber")
                objSMS.datetimereceived = objDr("datetimeReceived")
                objSMS.receivedByUserID = objDr("receivedByUserID")
                objArraylist.Add(objSMS)


            Next
        Catch ex As Exception
            ex.ToString()
        Finally
            conn.Close()
        End Try

        Return objArraylist
    End Function
    Public Function getAllReport() As ArrayList
        Dim objArraylist As New ArrayList
        Dim objadapter As New SqlDataAdapter
        Dim objDs As New DataSet
        Dim objcmd As New SqlCommand
        Dim objDr As DataRow
        objcmd.Connection = conn

        Try
            conn.Open()
            objcmd.CommandText = "select * from tbl_Report"
            objadapter.SelectCommand = objcmd
            objadapter.Fill(objDs, "tbl_Report")
            For Each objDr In objDs.Tables("tbl_Report").Rows
                Dim objSMS As New SMS
                objSMS.reportingID = objDr("reportingID")
                objSMS.datetimeOfFailure = objDr("datetimeOfFailure")
                objSMS.recipientOfReport = objDr("recipientOfReport")
                objSMS.reasonForReport = objDr("reasonForReport")

                objArraylist.Add(objSMS)


            Next
        Catch ex As Exception
            ex.ToString()
        Finally
            conn.Close()
        End Try

        Return objArraylist
    End Function


    Public Function getUserSMSReceived(ByVal UserID As Integer) As ArrayList
        Dim objArraylist As New ArrayList
        Dim objadapter As New SqlDataAdapter
        Dim objDs As New DataSet
        Dim objcmd As New SqlCommand
        Dim objDr As DataRow
        objcmd.Connection = conn

        Try
            conn.Open()
            objcmd.CommandText = "select * from tbl_ProcessedReceivedSMS where receivedByUserID = @userID"
            objcmd.Parameters.Add("@userID", SqlDbType.Int).Value = UserID
            objadapter.SelectCommand = objcmd
            objadapter.Fill(objDs, "tbl_ReceivedSMS")
            For Each objDr In objDs.Tables("tbl_ReceivedSMS").Rows
                Dim objSMS As New SMS
                objSMS.processedReceivedSMS = objDr("ProcessedReceivedSMS")
                objSMS.message = objDr("message")
                objSMS.SourcePhoneNumber = objDr("sourcePhoneNumber")
                objSMS.datetimereceived = objDr("datetimeReceived")
                objSMS.receivedByUserID = objDr("receivedByUserID")
                objSMS.messageSubscriptionID = objDr("messageSubscriptionID")
                objArraylist.Add(objSMS)

            Next
            'new code for yizhe
            objcmd.CommandText = "SELECT        tbl_ReceivedSMS.pendingReceivedSMSID, tbl_ReceivedSMS.message, tbl_ReceivedSMS.SourcePhoneNumber, tbl_ReceivedSMS.datetimereceived, tbl_ReceivedSMS.messageSubscriptionID FROM tbl_ReceivedSMS INNER JOIN tbl_MessageSubscription ON tbl_ReceivedSMS.messageSubscriptionID = tbl_MessageSubscription.messageSubscriptionID where tbl_MessageSubscription.userID=@userID"

            objadapter.SelectCommand = objcmd
            objadapter.Fill(objDs, "tbl_pendingReceivedSMS")
            For Each objDr In objDs.Tables("tbl_pendingReceivedSMS").Rows
                Dim objSMS As New SMS
                objSMS.processedReceivedSMS = objDr("pendingReceivedSMSID")
                objSMS.message = objDr("message")
                objSMS.SourcePhoneNumber = objDr("sourcePhoneNumber")
                objSMS.datetimereceived = objDr("datetimeReceived")
                objSMS.receivedByUserID = Nothing
                objSMS.messageSubscriptionID = objDr("messageSubscriptionID")
                objArraylist.Add(objSMS)

            Next
            'end new code for yizhe
        Catch ex As Exception
            ex.ToString()
        Finally
            conn.Close()
        End Try

        Return objArraylist
    End Function

    Public Function searchAllSMSReceived(ByVal searchString As String) As ArrayList
        Dim objArraylist As New ArrayList
        Dim objadapter As New SqlDataAdapter
        Dim objDs As New DataSet
        Dim objcmd As New SqlCommand
        Dim objDr As DataRow
        objcmd.Connection = conn

        Try
            conn.Open()
            'dreamtcs, might want to improve the search
            objcmd.CommandText = "select * from tbl_ProcessedReceivedSMS where message like @searchString or SourcePhoneNumber like @searchString"
            objcmd.Parameters.Add("@searchString", SqlDbType.VarChar).Value = "%" & searchString & "%"
            objadapter.SelectCommand = objcmd
            objadapter.Fill(objDs, "tbl_ReceivedSMS")
            For Each objDr In objDs.Tables("tbl_ReceivedSMS").Rows
                Dim objSMS As New SMS
                objSMS.receivedByUserID = objDr("pendingReceivedSMSID")
                objSMS.message = objDr("message")
                objSMS.SourcePhoneNumber = objDr("sourcePhoneNumber")
                objSMS.datetimereceived = objDr("datetimeReceived")
                objSMS.receivedByUserID = objDr("receivedByUserID")
                objArraylist.Add(objSMS)


            Next
        Catch ex As Exception
            ex.ToString()

        Finally
            conn.Close()
        End Try

        Return objArraylist
    End Function
    Public Function getAllSMSSent() As ArrayList
        Dim objArraylist As New ArrayList
        Dim objadapter As New SqlDataAdapter
        Dim objDs As New DataSet
        Dim objcmd As New SqlCommand
        Dim objDr As DataRow
        objcmd.Connection = conn

        Try
            conn.Open()
            objcmd.CommandText = "select * from tbl_SentSMS"
            objadapter.SelectCommand = objcmd
            objadapter.Fill(objDs, "tbl_ReceivedSMS")
            For Each objDr In objDs.Tables("tbl_ReceivedSMS").Rows
                Dim objSMS As New SMS
                objSMS.SentSMSID = objDr("SentSMSID")
                objSMS.message = objDr("message")
                objSMS.destinationAddress = objDr("destinationAddress")
                objSMS.ownerID = objDr("ownerID")
                objSMS.successful = objDr("successful")
                If objDr("datetimesent") Is DBNull.Value Then
                    objSMS.datetimesent = Nothing

                Else
                    objSMS.datetimesent = objDr("datetimesent")
                End If

                objArraylist.Add(objSMS)


            Next
        Catch ex As Exception
            ex.ToString()
        Finally
            conn.Close()
        End Try

        Return objArraylist
    End Function

    Public Function addNewApplication(ByVal applicationName As String, ByVal messagesubscriptionID As String, ByVal userid As Integer) As String
        Dim returnmessage As String = ""


        If applicationName <> "" And messagesubscriptionID <> "" Then
            Dim applicationID As Integer
            Dim cmd As New SqlCommand
            cmd.Connection = conn
            cmd.CommandText = "select count(*) from tbl_messagesubscription where messagesubscriptionID =@messagesubscriptionID"
            cmd.Parameters.Add("@messagesubscriptionID", SqlDbType.VarChar).Value = messagesubscriptionID
            Dim noofrowsaffected As Integer = 0
            Try
                conn.Open()
                noofrowsaffected = cmd.ExecuteScalar
                If noofrowsaffected = 1 Then
                    returnmessage = "message subscription ID already exist, please another subscription ID"
                Else
                    cmd.CommandText = "insert into tbl_applications (applicationName) values (@applicationName)"
                    cmd.Parameters.Add("@applicationName", SqlDbType.VarChar).Value = applicationName
                    cmd.ExecuteNonQuery()

                    cmd.CommandText = "select max(applicationID) from tbl_applications where applicationName = @applicationName"
                    applicationID = cmd.ExecuteScalar

                    cmd.CommandText = "insert into tbl_messagesubscription (userID,messageSubscriptionID, applicationID) values (@userID,@messagesubscriptionID,@applicationID)"
                    cmd.Parameters.Add("@applicationID", SqlDbType.Int).Value = applicationID

                    cmd.Parameters.Add("@userID", SqlDbType.Int).Value = userid
                    cmd.ExecuteNonQuery()
                    returnmessage = "Application added successfully"

                End If
            Catch ex As Exception
                ex.ToString()
            Finally
                conn.Close()

            End Try
        Else
            returnmessage = "Message subscription or application name cannot be empty"
        End If

        Return returnmessage
    End Function

    Public Function getUserSMSSent(ByVal userID As Integer) As ArrayList
        Dim objArraylist As New ArrayList
        Dim objadapter As New SqlDataAdapter
        Dim objDs As New DataSet
        Dim objcmd As New SqlCommand
        Dim objDr As DataRow
        objcmd.Connection = conn

        Try
            conn.Open()
            objcmd.CommandText = "select * from tbl_SentSMS where ownerID=@userID"
            objcmd.Parameters.Add("@userid", SqlDbType.Int).Value = userID
            objadapter.SelectCommand = objcmd
            objadapter.Fill(objDs, "tbl_ReceivedSMS")
            For Each objDr In objDs.Tables("tbl_ReceivedSMS").Rows
                Dim objSMS As New SMS
                objSMS.SentSMSID = objDr("SentSMSID")
                objSMS.message = objDr("message")
                objSMS.destinationAddress = objDr("destinationAddress")
                objSMS.ownerID = objDr("ownerID")
                objSMS.successful = objDr("successful")
                If objDr("datetimesent").Equals(DBNull.Value) Then
                Else
                    objSMS.datetimesent = objDr("datetimesent")
                End If

                objArraylist.Add(objSMS)
            Next
        Catch ex As Exception
            ex.ToString()
        Finally
            conn.Close()
        End Try

        Return objArraylist
    End Function

    Public Function getUserSMSPending(ByVal userID As Integer) As ArrayList
        Dim objArraylist As New ArrayList
        Dim objadapter As New SqlDataAdapter
        Dim objDs As New DataSet
        Dim objcmd As New SqlCommand
        Dim objDr As DataRow
        objcmd.Connection = conn

        Try
            conn.Open()
            objcmd.CommandText = "select * from tbl_pendingToSendSMS where ownerID=@userID"
            objcmd.Parameters.Add("@userid", SqlDbType.Int).Value = userID
            objadapter.SelectCommand = objcmd
            objadapter.Fill(objDs, "tbl_PendingSMS")
            For Each objDr In objDs.Tables("tbl_PendingSMS").Rows
                Dim objSMS As New SMS
                objSMS.pendingSMSID = objDr("pendingSMSID")
                objSMS.message = objDr("message")
                objSMS.destinationAddress = objDr("destinationAddress")
                objSMS.ownerID = objDr("ownerID")

                objArraylist.Add(objSMS)
            Next
        Catch ex As Exception
            ex.ToString()
        Finally
            conn.Close()
        End Try

        Return objArraylist
    End Function

    Public Function getAllApplicationsByUserID(ByVal userID As Integer) As ArrayList
        Dim objArraylist As New ArrayList
        Dim objadapter As New SqlDataAdapter
        Dim objDs As New DataSet
        Dim objcmd As New SqlCommand
        Dim objDr As DataRow
        objcmd.Connection = conn

        Try
            conn.Open()
            objcmd.CommandText = "SELECT     tbl_applications.applicationID, tbl_applications.applicationName, tbl_MessageSubscription.messageSubscriptionID FROM         tbl_applications INNER JOIN  tbl_MessageSubscription ON tbl_applications.applicationID = tbl_MessageSubscription.applicationID where userID = @userID"
            objcmd.Parameters.Add("@userid", SqlDbType.Int).Value = userID
            objadapter.SelectCommand = objcmd
            objadapter.Fill(objDs, "tbl_Applications")
            For Each objDr In objDs.Tables("tbl_Applications").Rows
                Dim objApp As New application
                objApp.appid = objDr("applicationID")
                objApp.appname = (objDr("applicationName"))
                objApp.messagesubscriptionID = objDr("MessageSubscriptionID")
                objApp.userid = userID
                Dim countNoOfSMS As New SqlCommand("select count(*) from tbl_ProcessedReceivedSMS where messageSubscriptionID = @messageSubscriptionID", conn)
                countNoOfSMS.Parameters.Add("@messageSubscriptionID", SqlDbType.VarChar).Value = objApp.messagesubscriptionID
                objApp.noofsms = countNoOfSMS.ExecuteScalar
                objArraylist.Add(objApp)
            Next
        Catch ex As Exception
            ex.ToString()
        Finally
            conn.Close()
        End Try

        Return objArraylist
    End Function
    Public Sub delAllSMSSent()

        Dim objcmd As New SqlCommand

        objcmd.Connection = conn

        Try
            conn.Open()
            objcmd.CommandText = "delete from tbl_sentSMS"
            objcmd.ExecuteNonQuery()
        Catch ex As Exception
            ex.ToString()
        Finally
            conn.Close()
        End Try


    End Sub

    Public Sub delAllSMSReceived()
        Dim objcmd As New SqlCommand

        objcmd.Connection = conn

        Try
            conn.Open()
            objcmd.CommandText = "delete from tbl_processedReceivedSMS"
            objcmd.ExecuteNonQuery()
            objcmd.CommandText = "delete from tbl_ReceivedSMS"
            objcmd.ExecuteNonQuery()
        Catch ex As Exception
            ex.ToString()
        Finally
            conn.Close()
        End Try


    End Sub

    Public Function updateSubscriptionIDByAppID(ByVal appID As Integer, ByVal messageSubscriptionID As String) As String
        Dim message As String = "Error updating Subscription ID"
        Dim objcmd As New SqlCommand
        objcmd.Connection = conn

        Dim objcmdcheckforExisting As New SqlCommand
        objcmdcheckforExisting.Connection = conn

        Try
            conn.Open()
            objcmdcheckforExisting.CommandText = "select count(*) from tbl_MessageSubscription where messageSubscriptionID = @messagesubscriptionID"
            objcmdcheckforExisting.Parameters.Add("@messagesubscriptionID", SqlDbType.VarChar).Value = messageSubscriptionID
            Dim noOfRowsAffected As Integer
            noOfRowsAffected = objcmdcheckforExisting.ExecuteScalar
            If noOfRowsAffected = 0 Then
                objcmd.CommandText = "update tbl_MessageSubscription set messageSubscriptionID = @messagesubscriptionID where applicationid=@appid"
                objcmd.Parameters.Add("@appid", SqlDbType.Int).Value = appID
                objcmd.Parameters.Add("@messagesubscriptionID", SqlDbType.VarChar).Value = messageSubscriptionID
                objcmd.ExecuteNonQuery()
                message = "Subscription ID successfully changed"
            Else
                message = "Subscription ID already exist, please choose another ID"
            End If


        Catch ex As Exception
            ex.ToString()
        Finally
            conn.Close()
        End Try

        Return message
    End Function

    Public Function getSMSDeliveredByUserThisMonth(ByVal userid As Integer) As Integer

        Dim noOfRowsAffected As Integer = -1
        Dim objcmd As New SqlCommand
        objcmd.Connection = conn

        Dim countSMSDelivered As New SqlCommand
        countSMSDelivered.Connection = conn

        Try
            conn.Open()
            countSMSDelivered.CommandText = "select count(*) from tbl_SentSMS where ownerID = @ownerID and successful='true' and  (MONTH(datetimesent) = MONTH(CURRENT_TIMESTAMP)) AND (YEAR(datetimesent) = YEAR(CURRENT_TIMESTAMP))"
            countSMSDelivered.Parameters.Add("@ownerID", SqlDbType.Int).Value = userid

            noOfRowsAffected = countSMSDelivered.ExecuteScalar


        Catch ex As Exception
            ex.ToString()
        Finally
            conn.Close()
        End Try

        Return noOfRowsAffected
    End Function
    Public Function getSMSReceivedByUserThisMonth(ByVal userid As Integer) As Integer
        Dim noOfRowsAffected As Integer = -1
        Dim noOfRowsAffected2 As Integer = -1
        Dim objcmd As New SqlCommand
        objcmd.Connection = conn

        Dim countSMSReceived As New SqlCommand
        countSMSReceived.Connection = conn

        Try
            conn.Open()
            countSMSReceived.CommandText = "SELECT     COUNT(*) AS Expr1 FROM         tbl_ProcessedReceivedSMS WHERE     (receivedByUserID = @ownerID) AND (MONTH(datetimereceived) = MONTH(CURRENT_TIMESTAMP)) AND (YEAR(datetimereceived)   = YEAR(CURRENT_TIMESTAMP))"
            countSMSReceived.Parameters.Add("@ownerID", SqlDbType.Int).Value = userid

            noOfRowsAffected = countSMSReceived.ExecuteScalar

            countSMSReceived.CommandText = "SELECT     COUNT(*) AS Expr1 FROM         tbl_ReceivedSMS INNER JOIN  tbl_MessageSubscription ON tbl_ReceivedSMS.messageSubscriptionID = tbl_MessageSubscription.messageSubscriptionID WHERE     (MONTH(tbl_ReceivedSMS.datetimereceived) = MONTH(CURRENT_TIMESTAMP)) AND (YEAR(tbl_ReceivedSMS.datetimereceived)   = YEAR(CURRENT_TIMESTAMP)) AND (tbl_MessageSubscription.userID = @ownerID)"
            countSMSReceived.Parameters.Clear()
            countSMSReceived.Parameters.Add("@ownerID", SqlDbType.Int).Value = userid
            noOfRowsAffected2 = countSMSReceived.ExecuteScalar
        Catch ex As Exception
            ex.ToString()
        Finally
            conn.Close()
        End Try

        Return noOfRowsAffected + noOfRowsAffected2
    End Function


    Public Function getSMSNotDeliveredByUser(ByVal userid As Integer) As Integer

        Dim noOfRowsAffected As Integer = -1
        Dim objcmd As New SqlCommand
        objcmd.Connection = conn

        Dim countSMSDelivered As New SqlCommand
        countSMSDelivered.Connection = conn

        Try
            conn.Open()
            countSMSDelivered.CommandText = "select count(*) from tbl_SentSMS where ownerID = @ownerID and successful='false'"
            countSMSDelivered.Parameters.Add("@ownerID", SqlDbType.Int).Value = userid

            noOfRowsAffected = countSMSDelivered.ExecuteScalar


        Catch ex As Exception
            ex.ToString()
        Finally
            conn.Close()
        End Try

        Return noOfRowsAffected
    End Function

    Public Function getSMSPendingDeliveredByUser(ByVal userid As Integer) As Integer

        Dim noOfRowsAffected As Integer = -1
        Dim objcmd As New SqlCommand
        objcmd.Connection = conn

        Dim countSMSPending As New SqlCommand
        countSMSPending.Connection = conn

        Try
            conn.Open()
            countSMSPending.CommandText = "select count(*) from tbl_pendingToSendSMS where ownerID = @ownerID"
            countSMSPending.Parameters.Add("@ownerID", SqlDbType.Int).Value = userid

            noOfRowsAffected = countSMSPending.ExecuteScalar


        Catch ex As Exception
            ex.ToString()
        Finally
            conn.Close()
        End Try

        Return noOfRowsAffected
    End Function

    Public Function getSMSDeliveredByEveryoneThisMonth() As Integer

        Dim noOfRowsAffected As Integer = -1
        Dim objcmd As New SqlCommand
        objcmd.Connection = conn

        Dim countSMSDelivered As New SqlCommand
        countSMSDelivered.Connection = conn

        Try
            conn.Open()
            countSMSDelivered.CommandText = "select count(*) from tbl_SentSMS where successful='true' and  (MONTH(datetimesent) = MONTH(CURRENT_TIMESTAMP)) AND (YEAR(datetimesent) = YEAR(CURRENT_TIMESTAMP))"


            noOfRowsAffected = countSMSDelivered.ExecuteScalar


        Catch ex As Exception
            ex.ToString()
        Finally
            conn.Close()
        End Try

        Return noOfRowsAffected
    End Function

    Public Function getSMSDeliveredByEveryoneThisMonth2() As Integer

        Dim noOfRowsAffected As Integer = -1
        Dim objcmd As New SqlCommand
        objcmd.Connection = conn

        Dim countSMSDelivered As New SqlCommand
        countSMSDelivered.Connection = conn

        Try
            conn.Open()
            countSMSDelivered.CommandText = "select count(*) from tbl_SentSMS where successful='false' and  (MONTH(datetimesent) = MONTH(CURRENT_TIMESTAMP)) AND (YEAR(datetimesent) = YEAR(CURRENT_TIMESTAMP))"


            noOfRowsAffected = countSMSDelivered.ExecuteScalar


        Catch ex As Exception
            ex.ToString()
        Finally
            conn.Close()
        End Try

        Return noOfRowsAffected
    End Function
    Public Function getSMSDeliveredByEveryoneToDate() As Integer

        Dim noOfRowsAffected As Integer = -1
        Dim objcmd As New SqlCommand
        objcmd.Connection = conn

        Dim countSMSDelivered As New SqlCommand
        countSMSDelivered.Connection = conn

        Try
            conn.Open()
            countSMSDelivered.CommandText = "select count(*) from tbl_SentSMS where successful='true'"


            noOfRowsAffected = countSMSDelivered.ExecuteScalar


        Catch ex As Exception
            ex.ToString()
        Finally
            conn.Close()
        End Try

        Return noOfRowsAffected
    End Function

    Public Function getSMSDeliveredByEveryoneToDate2() As Integer

        Dim noOfRowsAffected As Integer = -1
        Dim objcmd As New SqlCommand
        objcmd.Connection = conn

        Dim countSMSDelivered As New SqlCommand
        countSMSDelivered.Connection = conn

        Try
            conn.Open()
            countSMSDelivered.CommandText = "select count(*) from tbl_SentSMS where successful='false'"


            noOfRowsAffected = countSMSDelivered.ExecuteScalar


        Catch ex As Exception
            ex.ToString()
        Finally
            conn.Close()
        End Try

        Return noOfRowsAffected
    End Function

    Public Function getSMSReceivedByEveryoneToDate() As Integer

        Dim noOfRowsAffected As Integer = -1
        Dim noOfRowsAffected2 As Integer = -1
        Dim objcmd As New SqlCommand
        objcmd.Connection = conn

        Dim countSMSReceived As New SqlCommand
        countSMSReceived.Connection = conn

        Try
            conn.Open()
            countSMSReceived.CommandText = "SELECT     COUNT(*) FROM         tbl_ProcessedReceivedSMS"


            noOfRowsAffected = countSMSReceived.ExecuteScalar

            countSMSReceived.CommandText = "SELECT     COUNT(*)  FROM         tbl_ReceivedSMS "
            countSMSReceived.Parameters.Clear()
            noOfRowsAffected2 = countSMSReceived.ExecuteScalar

        Catch ex As Exception
            ex.ToString()
        Finally
            conn.Close()
        End Try

        Return noOfRowsAffected + noOfRowsAffected2
    End Function
    Public Function getSMSReceivedByEveryoneThisMonth() As Integer

        Dim noOfRowsAffected As Integer = -1
        Dim noOfRowsAffected2 As Integer = -1
        Dim objcmd As New SqlCommand
        objcmd.Connection = conn

        Dim countSMSReceived As New SqlCommand
        countSMSReceived.Connection = conn

        Try
            conn.Open()
            countSMSReceived.CommandText = "SELECT     COUNT(*) FROM         tbl_ProcessedReceivedSMS WHERE     (MONTH(datetimereceived) = MONTH(CURRENT_TIMESTAMP)) AND (YEAR(datetimereceived) = YEAR(CURRENT_TIMESTAMP))"
            noOfRowsAffected = countSMSReceived.ExecuteScalar

            countSMSReceived.CommandText = "SELECT     COUNT(*) FROM         tbl_ReceivedSMS WHERE     (MONTH(datetimereceived) = MONTH(CURRENT_TIMESTAMP)) AND (YEAR(datetimereceived) = YEAR(CURRENT_TIMESTAMP))"
            countSMSReceived.Parameters.Clear()
            noOfRowsAffected2 = countSMSReceived.ExecuteScalar

        Catch ex As Exception
            ex.ToString()
        Finally
            conn.Close()
        End Try

        Return noOfRowsAffected + noOfRowsAffected2
    End Function

    Public Function getReportingPhoneNumber() As String
        Dim phoneNumber As String = ""
        Dim objcmd As New SqlCommand
        objcmd.Connection = conn



        Try
            conn.Open()
            objcmd.CommandText = "SELECT  reportingPhoneNumber FROM tbl_ReportingPhoneNumber where id = 1"
            phoneNumber = objcmd.ExecuteScalar.ToString



        Catch ex As Exception
            ex.ToString()
        Finally
            conn.Close()
        End Try

        Return phoneNumber
    End Function

    Public Function updateReportingPhoneNumber(ByVal newPhoneNumber As String) As String
        Dim message As String = "Error updating phone number"
        Dim objcmd As New SqlCommand
        Dim numberOfRows As Integer
        objcmd.Connection = conn



        Try
            conn.Open()
            objcmd.CommandText = "UPDATE    tbl_ReportingPhoneNumber SET              reportingPhoneNumber = @newPhoneNumber WHERE     (id = 1)"
            objcmd.Parameters.Add("@newPhoneNumber", SqlDbType.VarChar).Value = newPhoneNumber
            numberOfRows = objcmd.ExecuteNonQuery()

            If numberOfRows = 1 Then
                message = "Phone Number Updated"
            End If


        Catch ex As Exception
            ex.ToString()
        Finally
            conn.Close()
        End Try

        Return message
    End Function

    Public Function getMaxThruput() As String
        Dim maxthruput As String = "Error getting thru put"
        Dim objcmd As New SqlCommand

        objcmd.Connection = conn

        Try
            conn.Open()
            objcmd.CommandText = "select max(both) from tbl_benchmark"


            maxthruput = objcmd.ExecuteScalar.ToString

        Catch ex As Exception
            ex.ToString()
        Finally
            conn.Close()
        End Try

        Return maxthruput
    End Function

    Public Function getAllSMSsentonDateMonth(ByVal runningMonthID As Integer) As ArrayList
        Dim objArraylist As New ArrayList
        Dim objadapter As New SqlDataAdapter
        Dim objDs As New DataSet
        Dim objcmd As New SqlCommand
        Dim objDr As DataRow
        objcmd.Connection = conn

        Try
            conn.Open()
            objcmd.CommandText = "SELECT     tbl_SentSMS.SentSMSID, tbl_SentSMS.message, tbl_SentSMS.destinationAddress, tbl_SentSMS.ownerID, tbl_SentSMS.referenceNo,   tbl_SentSMS.successful, tbl_SentSMS.datetimesent FROM         tbl_SentSMS INNER JOIN   tbl_runningMonths ON MONTH(tbl_SentSMS.datetimesent) = MONTH(tbl_runningMonths.datetime) AND YEAR(tbl_SentSMS.datetimesent)    = YEAR(tbl_runningMonths.datetime) AND tbl_runningMonths.id = @id"
            objcmd.Parameters.Add("@id", SqlDbType.Int).Value = runningMonthID
            objadapter.SelectCommand = objcmd
            objadapter.Fill(objDs, "tbl_SentSMS")
            For Each objDr In objDs.Tables("tbl_SentSMS").Rows
                Dim objSMS As New SMS
                objSMS.SentSMSID = objDr("SentSMSID")
                objSMS.message = objDr("message")
                objSMS.destinationAddress = objDr("destinationAddress")
                objSMS.ReferenceNo = objDr("referenceNo")
                objSMS.ownerID = objDr("ownerID")
                objSMS.successful = objDr("successful")
                objSMS.datetimesent = objDr("datetimesent")
                objArraylist.Add(objSMS)


            Next
        Catch ex As Exception
            ex.ToString()
        Finally
            conn.Close()
        End Try

        Return objArraylist
    End Function

    Public Function getAllSMSReceivedonDateMonth(ByVal runningMonthID As Integer) As ArrayList
        Dim objArraylist As New ArrayList
        Dim objadapter As New SqlDataAdapter
        Dim objDs As New DataSet
        Dim objcmd As New SqlCommand
        Dim objDr As DataRow
        objcmd.Connection = conn

        Try
            conn.Open()
            objcmd.CommandText = "SELECT     tbl_ProcessedReceivedSMS.* FROM         tbl_ProcessedReceivedSMS INNER JOIN   tbl_runningMonths ON MONTH(tbl_ProcessedReceivedSMS.datetimereceived) = MONTH(tbl_runningMonths.datetime) AND   YEAR(tbl_ProcessedReceivedSMS.datetimereceived) = YEAR(tbl_runningMonths.datetime) WHERE     (tbl_runningMonths.id = @id)"
            objcmd.Parameters.Add("@id", SqlDbType.Int).Value = runningMonthID
            objadapter.SelectCommand = objcmd
            objadapter.Fill(objDs, "tbl_ReceivedSMS")
            For Each objDr In objDs.Tables("tbl_ReceivedSMS").Rows
                Dim objSMS As New SMS
                objSMS.processedReceivedSMS = objDr("ProcessedReceivedSMS")
                objSMS.message = objDr("message")
                objSMS.SourcePhoneNumber = objDr("sourcePhoneNumber")
                objSMS.datetimereceived = objDr("datetimeReceived")
                objSMS.receivedByUserID = objDr("receivedByUserID")
                objArraylist.Add(objSMS)


            Next
        Catch ex As Exception
            ex.ToString()
        Finally
            conn.Close()
        End Try

        Return objArraylist
    End Function

End Class
