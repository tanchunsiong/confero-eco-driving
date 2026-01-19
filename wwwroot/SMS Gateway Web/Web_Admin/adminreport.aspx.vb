
Partial Class Web_Admin_adminreport
    Inherits System.Web.UI.Page

    Dim smsWS As New WebService
    Dim loginuser As New user
    Dim objDBUser As New DBUser
    Dim objDBSMS As New DBSMS

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            Dim objArray1 As ArrayList = objDBSMS.getAllSMSReceived
            Dim objArray2 As ArrayList = objDBSMS.getAllSMSSent

            DataGrid1.DataSource = objArray1
            DataGrid1.DataBind()

            DataGrid2.DataSource = objArray2
            DataGrid2.DataBind()

            If objArray1.Count = 0 Then
                lblDataGird.Text = "No data in database"
            End If

            If objArray2.Count = 0 Then
                lblDataGird2.Text = "No data in database"
            End If

        End If

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
            End If
        Catch ex As Exception
            Response.Redirect("login.aspx")
        End Try
    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DropDownList1.SelectedIndexChanged

        databind1()
    End Sub

    Protected Sub DropDownList2_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DropDownList2.SelectedIndexChanged
        databind2()

    End Sub

    Private Sub databind1()
        Dim runningmonthid As Integer = Integer.Parse(DropDownList1.SelectedValue)
        If runningmonthid = 0 Then
            DataGrid1.DataSource = objDBSMS.getAllSMSReceived
        Else
            DataGrid1.DataSource = objDBSMS.getAllSMSReceivedonDateMonth(runningmonthid)
        End If

        DataGrid1.DataBind()
    End Sub
    Private Sub databind2()
        Dim runningmonthid As Integer = Integer.Parse(DropDownList2.SelectedValue)
        If runningmonthid = 0 Then
            DataGrid2.DataSource = objDBSMS.getAllSMSSent
        Else
            DataGrid2.DataSource = objDBSMS.getAllSMSsentonDateMonth(runningmonthid)
        End If

        DataGrid2.DataBind()
    End Sub

    Private Sub DataGrid2_PageIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrid2.PageIndexChanged

    End Sub

    Private Sub DataGrid2_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles DataGrid2.PageIndexChanging
        DataGrid2.PageIndex = e.NewPageIndex
        databind2()
    End Sub

    Private Sub DataGrid1_PageIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrid1.PageIndexChanged

    End Sub

    Private Sub DataGrid1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles DataGrid1.PageIndexChanging
        DataGrid1.PageIndex = e.NewPageIndex
        databind1()
    End Sub

    Protected Sub btnDeleteRec_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDeleteRec.Click
        objDBSMS.delAllSMSReceived()

    End Sub

    Protected Sub btnDeleteSent_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDeleteSent.Click
        objDBSMS.delAllSMSSent()
    End Sub

End Class

