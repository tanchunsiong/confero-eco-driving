
Partial Class Web_User_sent
    Inherits System.Web.UI.Page

    Dim smshandler As New DBSMS
    Dim loginuser As New user
    Dim objDBUser As New DBUser
    Dim objDBSMS As New DBSMS

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            loginuser = Session("user")
            If loginuser Is Nothing Then
                Response.Redirect("login.aspx")
            Else

                If loginuser.type.ToLower.Equals("user") Then
                    objDBUser.updateUser(loginuser)

                    Dim lblSMSLeft As Label = Master.FindControl("lblSMSLeft")
                    Dim lblUserName As Label = Master.FindControl("lblUserName")

                    lblUserName.Text = "User Name: " + loginuser.username
                    lblSMSLeft.Text = "Balance: " + CStr(loginuser.totallimit - loginuser.currentUsage)

                    binddataUser()
                End If

            End If
        Catch ex As Exception
            Response.Redirect("login.aspx")
        End Try
    End Sub

    Sub binddataUser()

        Dim objArraylist As New ArrayList
        objArraylist = smshandler.getUserSMSSent(loginuser.userID)

        grdData.DataSource = objArraylist
        grdData.DataBind()

        grdData.DataSource = objArraylist
        grdData.DataBind()

        If objArraylist.Count = 0 Then
            lblDataGird.Text = "No data in database"
        Else
            lblDataGird.Text = ""
        End If
    End Sub

    Private Sub grdData_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdData.PageIndexChanging
        grdData.PageIndex = e.NewPageIndex
    End Sub
End Class
