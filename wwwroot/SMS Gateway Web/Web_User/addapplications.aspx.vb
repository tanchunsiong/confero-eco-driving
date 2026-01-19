
Partial Class Web_User_addapplications
    Inherits System.Web.UI.Page

    Dim smsWS As New WebService
    Dim loginuser As New user
    Dim objDBUser As New DBUser
    Dim objDBSMS As New DBSMS

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'check for session

        Try
            loginuser = Session("user")
            If loginuser Is Nothing Then
                Response.Redirect("login.aspx")
            ElseIf Not loginuser.type.ToLower.Equals("user") Then
                Response.Redirect("login.aspx")

            Else
                objDBUser.updateUser(loginuser)

                Dim lblSMSLeft As Label = Master.FindControl("lblSMSLeft")
                Dim lblUserName As Label = Master.FindControl("lblUserName")

                lblUserName.Text = "User Name: " + loginuser.username
                lblSMSLeft.Text = "Balance: " + CStr(loginuser.totallimit - loginuser.currentUsage)

            End If
        Catch ex As Exception
            Response.Redirect("login.aspx")
        End Try
    End Sub

    Protected Sub btnChangeCode_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnChangeCode.Click
        If txtAppName.Text <> "" And txtSubID.Text <> "" Then
            lblNotice.Text = objDBSMS.addNewApplication(txtAppName.Text, txtSubID.Text, loginuser.userID)
        Else
            lblNotice.Text = "Message subscription or application name cannot be empty"
        End If
    End Sub
End Class
