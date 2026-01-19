Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Imports System.Data.Sql
Imports System.Data
Imports System.Web.HttpResponse

Public Class DBUser

    Public Sub updateUser(ByRef objUser As user)
        Dim conn As New SqlConnection
        conn.ConnectionString = ConfigurationManager.ConnectionStrings("DatabaseConnectionString").ConnectionString
        Dim cmd As New SqlCommand
        cmd.Connection = conn
        cmd.CommandText = "select * from tbl_Users where userID=@userID"
        cmd.Parameters.Add("@userID", SqlDbType.Int).Value = objUser.userID
        Dim reader As SqlDataReader
        Try
            conn.Open()
            reader = cmd.ExecuteReader
            While reader.Read
                objUser.type = reader.GetString(3)

                objUser.currentUsage = reader.GetInt32(4)
                objUser.totallimit = reader.GetInt32(5)
                objUser.status = reader.GetString(6)
                objUser.mobilenumber = reader.GetString(7)
            End While
        Catch ex As Exception
            ex.ToString()
        Finally
            conn.Close()
        End Try

    End Sub

    Public Function createUser(ByRef objUser As user) As String
        Dim returnmessage As String = "Error registering user"
        Dim conn As New SqlConnection
        conn.ConnectionString = ConfigurationManager.ConnectionStrings("DatabaseConnectionString").ConnectionString
        Dim cmd As New SqlCommand
        cmd.Connection = conn
        cmd.CommandText = "select count(*) from tbl_Users where userName=@userName"
        cmd.Parameters.Add("@userName", SqlDbType.VarChar).Value = objUser.username
        Dim noOfRowsAffected As Integer = 0
        Try
            conn.Open()
            noOfRowsAffected = cmd.ExecuteScalar
            If noOfRowsAffected = 1 Then
                returnmessage = "User Name already in use"
            Else
                Dim cmdinserttotblusers As New SqlCommand
                cmdinserttotblusers.Connection = conn
                cmdinserttotblusers.CommandText = "INSERT INTO tbl_Users   (userName, password, mobileNumber) VALUES     (@username,@password,@mobileNumber)"
                cmdinserttotblusers.Parameters.Add("@username", SqlDbType.VarChar).Value = objUser.username.Trim
                cmdinserttotblusers.Parameters.Add("@password", SqlDbType.VarChar).Value = objUser.password.Trim
                cmdinserttotblusers.Parameters.Add("@mobileNumber", SqlDbType.VarChar).Value = objUser.mobilenumber

                noOfRowsAffected = cmdinserttotblusers.ExecuteNonQuery
                If noOfRowsAffected = 1 Then
                    returnmessage = "Registration Successful"
                End If
            End If
        Catch ex As Exception
            ex.ToString()
        Finally
            conn.Close()
        End Try
        Return returnmessage
    End Function

    Public Function getAllUsers() As ArrayList

        Dim objArraylist As New ArrayList
        Dim objAdapter As New SqlDataAdapter
        Dim objDS As New DataSet
        Dim objDr As DataRow

        Dim conn As New SqlConnection
        conn.ConnectionString = ConfigurationManager.ConnectionStrings("DatabaseConnectionString").ConnectionString
        Dim cmd As New SqlCommand
        cmd.Connection = conn
        cmd.CommandText = "select * from tbl_Users"
        Try
            conn.Open()
            objAdapter.SelectCommand = cmd
            objAdapter.Fill(objDS, "tblUsers")
            Dim count As Integer = 1
            For Each objDr In objDS.Tables("tblUsers").Rows
                Dim objUser As New user
                objUser.counter = count
                objUser.userID = objDr("userID")
                Dim cmdcountSMSReceived As New SqlCommand
                cmdcountSMSReceived.Connection = conn
                cmdcountSMSReceived.CommandText = "select count(*) from tbl_ProcessedReceivedSMS where receivedByUserID = @userID"
                cmdcountSMSReceived.Parameters.Add("@userid", SqlDbType.Int).Value = objUser.userID
                objUser.NoOfSMSReceived = cmdcountSMSReceived.ExecuteScalar
                objUser.currentUsage = objDr("currentUsage")
                objUser.username = objDr("userName")
                objUser.password = objDr("password")
                objUser.type = objDr("type")
                objUser.totallimit = objDr("totallimit")
                objUser.SMSLeft = objUser.totallimit - objUser.currentUsage
                objUser.mobilenumber = objDr("mobileNumber")
                objUser.status = objDr("status")
                objArraylist.Add(objUser)
                count += 1
            Next
        Catch ex As Exception
            ex.ToString()
        Finally
            conn.Close()
        End Try
        Return objArraylist
    End Function

    Public Sub disableUser(ByVal userID As Integer)


        Dim conn As New SqlConnection
        conn.ConnectionString = ConfigurationManager.ConnectionStrings("DatabaseConnectionString").ConnectionString
        Dim cmd As New SqlCommand
        cmd.Connection = conn
        cmd.CommandText = "update tbl_Users set status='disabled' where userID = @userID"
        cmd.Parameters.Add("userID", SqlDbType.Int).Value = userID
        Try
            conn.Open()
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            ex.ToString()
        Finally
            conn.Close()
        End Try
    End Sub

    Public Sub enableUser(ByVal userID As Integer)


        Dim conn As New SqlConnection
        conn.ConnectionString = ConfigurationManager.ConnectionStrings("DatabaseConnectionString").ConnectionString
        Dim cmd As New SqlCommand
        cmd.Connection = conn
        cmd.CommandText = "update tbl_Users set status='active' where userID = @userID"
        cmd.Parameters.Add("userID", SqlDbType.Int).Value = userID
        Try
            conn.Open()
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            ex.ToString()
        Finally
            conn.Close()
        End Try
    End Sub

    Public Sub increaselimit(ByVal userID As Integer, ByVal value As Integer)


        Dim conn As New SqlConnection
        conn.ConnectionString = ConfigurationManager.ConnectionStrings("DatabaseConnectionString").ConnectionString
        Dim cmd As New SqlCommand
        cmd.Connection = conn
        cmd.CommandText = "update tbl_Users set totallimit= totallimit + @value where userID = @userID"
        cmd.Parameters.Add("userID", SqlDbType.Int).Value = userID
        cmd.Parameters.Add("@value", SqlDbType.Int).Value = value
        Try
            conn.Open()
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            ex.ToString()
        Finally
            conn.Close()
        End Try
    End Sub

    Public Sub decreaselimit(ByVal userID As Integer, ByVal value As Integer)


        Dim conn As New SqlConnection
        conn.ConnectionString = ConfigurationManager.ConnectionStrings("DatabaseConnectionString").ConnectionString
        Dim cmd As New SqlCommand
        cmd.Connection = conn

        Dim countNoOfSMSLeft As New SqlCommand
        countNoOfSMSLeft.Connection = conn
        countNoOfSMSLeft.CommandText = "select (totalLimit-currentUsage) from tbl_Users where userID=@userID"
        countNoOfSMSLeft.Parameters.Add("@userID", SqlDbType.Int).Value = userID
        Dim noofsmsleft As Integer

        cmd.CommandText = "update tbl_Users set totallimit= totallimit - @value where userID = @userID"
        cmd.Parameters.Add("@userID", SqlDbType.Int).Value = userID
        cmd.Parameters.Add("@value", SqlDbType.Int).Value = value
        Try
            conn.Open()
            noofsmsleft = Integer.Parse(countNoOfSMSLeft.ExecuteScalar)
            If value <= noofsmsleft Then
                cmd.ExecuteNonQuery()
            End If


        Catch ex As Exception
            ex.ToString()
        Finally
            conn.Close()
        End Try
    End Sub

    Public Sub promote(ByVal userID As Integer)


        Dim conn As New SqlConnection
        conn.ConnectionString = ConfigurationManager.ConnectionStrings("DatabaseConnectionString").ConnectionString
        Dim cmd As New SqlCommand
        cmd.Connection = conn
        'dreamtcs, might want to do checking for negative value
        cmd.CommandText = "update tbl_Users set type='admin' where userID = @userID"
        cmd.Parameters.Add("userID", SqlDbType.Int).Value = userID

        Try
            conn.Open()
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            ex.ToString()
        Finally
            conn.Close()
        End Try
    End Sub

    Public Sub demote(ByVal userID As Integer)


        Dim conn As New SqlConnection
        conn.ConnectionString = ConfigurationManager.ConnectionStrings("DatabaseConnectionString").ConnectionString
        Dim cmd As New SqlCommand
        cmd.Connection = conn
        'dreamtcs, might want to do checking for negative value
        cmd.CommandText = "update tbl_Users set type='user' where userID = @userID"
        cmd.Parameters.Add("userID", SqlDbType.Int).Value = userID

        Try
            conn.Open()
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            ex.ToString()
        Finally
            conn.Close()
        End Try
    End Sub

    Public Function updateSubscriptionID(ByVal newID As String, ByVal username As String, ByVal password As String) As String
        Dim noOfRowsAffected As Integer
        Dim returnmessage As String = "Error encountered"
        Dim conn As New SqlConnection
        conn.ConnectionString = ConfigurationManager.ConnectionStrings("DatabaseConnectionString").ConnectionString
        Dim cmdcheckforSameSubscriptionID As New SqlCommand
        cmdcheckforSameSubscriptionID.Connection = conn
        cmdcheckforSameSubscriptionID.CommandText = "select count(*) from tbl_users where messageSubscriptionID = @newID"
        cmdcheckforSameSubscriptionID.Parameters.Add("@newid", SqlDbType.VarChar).Value = newID
        Try
            conn.Open()
            noOfRowsAffected = cmdcheckforSameSubscriptionID.ExecuteScalar()
            If noOfRowsAffected >= 1 Then
                returnmessage = "Subscription ID already exist, please choose another ID"
            Else
                Dim cmd As New SqlCommand
                cmd.Connection = conn
                cmd.CommandText = "update tbl_users set messageSubscriptionID = @newID where userName=@userName and password=@password"
                cmd.Parameters.Add("@newID", SqlDbType.VarChar).Value = newID
                cmd.Parameters.Add("@userName", SqlDbType.VarChar).Value = username
                cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = password

                noOfRowsAffected = cmd.ExecuteNonQuery
                If noOfRowsAffected = 1 Then
                    returnmessage = "Subscription ID changed to successfully" & newID
                End If


            End If
        Catch ex As Exception
            ex.ToString()
        Finally
            conn.Close()

        End Try

        Return returnmessage
    End Function

End Class
