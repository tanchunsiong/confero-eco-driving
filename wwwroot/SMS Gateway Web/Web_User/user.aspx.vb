
Partial Class Web_User_user
    Inherits System.Web.UI.Page

    Dim smsWS As New WebService
    Dim loginuser As New user
    Dim objDBUser As New DBUser
    Dim objDBSMS As New DBSMS

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

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

                lblDelivered.Text = objDBSMS.getSMSDeliveredByUserThisMonth(loginuser.userID)
                lblReceived.Text = objDBSMS.getSMSReceivedByUserThisMonth(loginuser.userID)
                lblNotDelivered.Text = objDBSMS.getSMSNotDeliveredByUser(loginuser.userID)
                lblPending.Text = objDBSMS.getSMSPendingDeliveredByUser(loginuser.userID)
            End If
        Catch ex As Exception
            Response.Redirect("login.aspx")
        End Try
    End Sub

    Protected Sub btnSendSMS_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSendSMS.Click
        lblError.Text = ""
        If txtMessage.Text = "" Or txtDestination.Text = "" Then
            lblError.Text = "Destination and/or Message cannot be empty"
        Else

            lblError.Text = smsWS.SendSMS(txtMessage.Text, txtDestination.Text, loginuser.username, loginuser.password)
            txtDestination.Text = ""
            txtMessage.Text = ""
        End If
    End Sub

End Class
