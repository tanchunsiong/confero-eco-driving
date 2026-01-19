
Partial Class Web_Admin_admin
    Inherits System.Web.UI.Page

    Dim smsWS As New WebService
    Dim loginuser As New user
    Dim objDBUser As New DBUser
    Dim objDBSMS As New DBSMS

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load



        'check for session
        Try
            If Session.Item("user") Is Nothing Then
                Response.Redirect("..\Login.aspx")
            Else

                loginuser = Session.Item("user")

                objDBUser.updateUser(loginuser)

                Dim lblSMSLeft As Label = Master.FindControl("lblSMSLeft")
                Dim lblUserName As Label = Master.FindControl("lblUserName")

                lblUserName.Text = "User Name: " + loginuser.username
                lblSMSLeft.Text = "Balance: " + CStr(loginuser.totallimit - loginuser.currentUsage)

                lblReceivedMessages.Text = objDBSMS.getSMSReceivedByEveryoneThisMonth
                lblTotalReceivedMessages.Text = objDBSMS.getSMSReceivedByEveryoneToDate
                lblSentMessages.Text = objDBSMS.getSMSDeliveredByEveryoneThisMonth
                lblSentMessages2.Text = objDBSMS.getSMSDeliveredByEveryoneThisMonth2
                lblTotalSentMessages.Text = objDBSMS.getSMSDeliveredByEveryoneToDate
                lblTotalSentMessages2.Text = objDBSMS.getSMSDeliveredByEveryoneToDate2
                lblThruput.Text = objDBSMS.getMaxThruput
            End If

        Catch ex As Exception
            Response.Redirect("..\Login.aspx")
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
