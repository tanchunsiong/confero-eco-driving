
Partial Class Web_Admin_health
    Inherits System.Web.UI.Page

    Dim loginuser As New user
    Dim objDBUser As New DBUser
    Dim objDBSMS As New DBSMS

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            loginuser = Session("user")
            If loginuser Is Nothing Then
                Response.Redirect("login.aspx")
            ElseIf Not loginuser.type.ToLower.Equals("admin") Then
                Response.Redirect("login.aspx")
            Else
                loginuser = Session.Item("user")

                objDBUser.updateUser(loginuser)

                Dim lblSMSLeft As Label = Master.FindControl("lblSMSLeft")
                Dim lblUserName As Label = Master.FindControl("lblUserName")

                lblUserName.Text = "User Name: " + loginuser.username
                lblSMSLeft.Text = "Balance: " + CStr(loginuser.totallimit - loginuser.currentUsage)

                lblMobile.Text = objDBSMS.getReportingPhoneNumber

                bindData()
            End If
        Catch ex As Exception
            Response.Redirect("login.aspx")
        End Try
    End Sub

    Private Sub bindData()
        Dim objarraylist As New ArrayList
        objarraylist = objDBSMS.getAllReport

        DataGrid1.DataSource = objarraylist
        DataGrid1.DataBind()

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        If IsNumeric(TextBox1.Text.Trim) Then
            lblNotice.Text = objDBSMS.updateReportingPhoneNumber(TextBox1.Text.Trim)
            lblMobile.Text = objDBSMS.getReportingPhoneNumber
            TextBox1.Text = ""
        Else
            lblNotice.Text = "Please enter a numeric phone number"
        End If
    End Sub


    Private Sub DataGrid1_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles DataGrid1.PageIndexChanged
        DataGrid1.CurrentPageIndex = e.NewPageIndex
        bindData()

    End Sub

End Class
