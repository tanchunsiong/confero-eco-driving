Imports System.Data.SqlClient
Imports System.Data

Partial Class Login
    Inherits System.Web.UI.Page

    Protected Sub btnLogin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogin.Click

        Dim objDBMis As New DBMis
        Dim conn As New SqlConnection
        conn.ConnectionString = ConfigurationManager.ConnectionStrings("DatabaseConnectionString").ConnectionString
        Dim cmd As New SqlCommand
        cmd.Connection = conn
        cmd.CommandText = "SELECT COUNT(*) FROM tbl_Users WHERE (userName = @username) AND (password = @password) AND (status='active') "
        cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = txtLoginID.Text
        cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = objDBMis.GenerateHash(txtPassword.Text)

        If checkEmpty() = False Then
            Try
                conn.Open()
                Dim noOfRowsAffected As Integer = 0
                noOfRowsAffected = cmd.ExecuteScalar
                If noOfRowsAffected = 1 Then
                    Dim loginuser As New user

                    Dim getUser As New SqlCommand
                    getUser.Connection = conn
                    getUser.CommandText = "select * from tbl_users where username=@username and password = @password"
                    getUser.Parameters.Add("@username", SqlDbType.VarChar).Value = txtLoginID.Text
                    getUser.Parameters.Add("@password", SqlDbType.VarChar).Value = objDBMis.GenerateHash(txtPassword.Text)

                    Dim reader As SqlDataReader
                    reader = getUser.ExecuteReader

                    While reader.Read
                        loginuser.userID = reader.GetInt32(0)
                        loginuser.username = reader.GetString(1)
                        loginuser.password = reader.GetString(2)
                        loginuser.type = reader.GetString(3)

                    End While
                    Session.Add("user", loginuser)

                    loginuser = CType(Session.Item("user"), user)

                    If loginuser.type.ToLower.Equals("admin") Then
                        Response.Redirect("~/web_admin/admin.aspx")
                    ElseIf loginuser.type.ToLower.Equals("user") Then
                        Response.Redirect("~/web_user/user.aspx")
                    End If
                Else
                    lblStatus.Text = "Invalid login credentials/ Account Disabled"
                End If

            Catch ex As Exception
                ex.ToString()
            Finally
                conn.Close()
            End Try
        Else
            lblStatus.Text = ""
        End If

    End Sub

    Public Function checkEmpty() As Boolean

        Dim b1, b2, b3, result As Boolean

        If txtLoginID.Text.Equals("") Then
            lblErrorName.Text = "*"
            b1 = True
        Else
            lblErrorName.Text = ""
            b1 = False
        End If

        If txtPassword.Text.Equals("") Then
            lblErrorPwd.Text = "*"
            b2 = True
        Else
            lblErrorPwd.Text = ""
            b2 = False
        End If

        If txtImgVerifyCode.Text.Equals("") Then
            lblErrorVerify.Text = "*"
            b3 = True
        Else
            lblErrorVerify.Text = ""
            b3 = False
        End If

        If b1 = True Or b2 = True Or b3 = True Then
            result = True
        Else
            result = False
        End If

        Return result
    End Function


End Class
