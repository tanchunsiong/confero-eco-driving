
Partial Class Web_User_applications
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

                binddata()
            End If
        Catch ex As Exception
            Response.Redirect("login.aspx")
        End Try

    End Sub

    Sub binddata()

        grdData.DataSource = objDBSMS.getAllApplicationsByUserID(loginuser.userID)
        DropDownList1.DataSource = objDBSMS.getAllApplicationsByUserID(loginuser.userID)
        DropDownList1.DataTextField = "appName"
        DropDownList1.DataValueField = "appID"
        DropDownList1.DataBind()

        grdData.DataBind()

    End Sub

    Protected Sub btnChangeCode_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnChangeCode.Click
        lblNotice.Text = objDBSMS.updateSubscriptionIDByAppID(DropDownList1.SelectedValue, TextBox1.Text.Trim)
        grdData.DataBind()
    End Sub

    Private Sub grdData_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdData.PageIndexChanging
        grdData.PageIndex = e.NewPageIndex
        binddata()
    End Sub
End Class
