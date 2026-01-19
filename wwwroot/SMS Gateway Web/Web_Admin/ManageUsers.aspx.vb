
Partial Class Web_Admin_ManageUsers
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

                bindData()

            End If

        Catch ex As Exception
            Response.Redirect("login.aspx")
        End Try

    End Sub

    Sub bindData()

        Dim objArrayList As New ArrayList
        Dim objDBUser As New DBUser
        objArrayList = objDBUser.getAllUsers
        If (objArrayList.Count >= ((grdData.PageSize * grdData.CurrentPageIndex) + 1)) Then

        Else
            grdData.CurrentPageIndex = 0
        End If
        grdData.DataSource = objArrayList
        grdData.DataBind()
    End Sub





    Protected Sub grdData_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles grdData.ItemDataBound

        If e.Item.ItemType <> ListItemType.Header And e.Item.ItemType <> ListItemType.Footer Then

            e.Item.Cells(2).Text = "<input type=""checkbox"" value=""" & _
            e.Item.Cells(0).Text & """ name=""chkRecordId"" id=""chkRecordId"">"
        Else
            e.Item.Cells(2).Text = "<input type=""checkbox"" value=""0"" name=""chkRecordId"" id=""chkRecordId"">"

        End If

    End Sub


    Protected Sub btnDisable_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDisable.Click
        Dim objArrayList As New ArrayList
        Dim strRecordId As String
        Dim intRecordId As Integer
        Dim recordsaffected As Integer
        Dim aryRecordId() As String = Nothing
        Dim objDBUser As New DBUser
        strRecordId = Request.Form("chkRecordId")

        If strRecordId = "" Then

            lblNotice.Text = "Select on disable to delete record."
        Else


            aryRecordId = strRecordId.Split(",")
            recordsaffected = aryRecordId.Length
            For Each intRecordId In aryRecordId
                objDBUser.disableUser(intRecordId)
            Next


            objArrayList = objDBUser.getAllUsers
            grdData.DataSource = objArrayList
            grdData.DataBind()
            lblNotice.Text = "<u>" & recordsaffected & "</u> records disabled."

        End If
    End Sub

    Protected Sub btnActivate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnActivate.Click
        Dim objArrayList As New ArrayList
        Dim strRecordId As String
        Dim intRecordId As Integer
        Dim recordsaffected As Integer
        Dim aryRecordId() As String = Nothing
        Dim objDBUser As New DBUser
        strRecordId = Request.Form("chkRecordId")

        If strRecordId = "" Then

            lblNotice.Text = "Select on checkbox to Activate record."
        Else


            aryRecordId = strRecordId.Split(",")
            recordsaffected = aryRecordId.Length
            For Each intRecordId In aryRecordId
                objDBUser.enableUser(intRecordId)
            Next


            objArrayList = objDBUser.getAllUsers
            grdData.DataSource = objArrayList
            grdData.DataBind()
            lblNotice.Text = "<u>" & recordsaffected & "</u> records activated."

        End If
    End Sub

    Protected Sub btnIncrease_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnIncrease.Click
        Dim objArrayList As New ArrayList
        Dim strRecordId As String
        Dim intRecordId As Integer
        Dim recordsaffected As Integer
        Dim aryRecordId() As String = Nothing
        Dim objDBUser As New DBUser
        strRecordId = Request.Form("chkRecordId")

        If strRecordId = "" Then

            lblNotice.Text = "Select on checkbox to increase limit."
        ElseIf Not IsNumeric(txtSMS.Text) Then
            lblNotice.Text = "Number of SMS to be added must be a number."
        ElseIf Integer.Parse(txtSMS.Text) <= 0 Or Integer.Parse(txtSMS.Text) > 1000 Then
            lblNotice.Text = "Can only increase or decrease limit by 1 to 1000 per transaction"
        Else


            aryRecordId = strRecordId.Split(",")
            recordsaffected = aryRecordId.Length
            For Each intRecordId In aryRecordId
                objDBUser.increaseLimit(intRecordId, Integer.Parse(txtSMS.Text))
            Next


            objArrayList = objDBUser.getAllUsers
            grdData.DataSource = objArrayList
            grdData.DataBind()
            lblNotice.Text = "<u>" & recordsaffected & "</u> records activated."

        End If
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDecrease.Click
        Dim objArrayList As New ArrayList
        Dim strRecordId As String
        Dim intRecordId As Integer
        Dim recordsaffected As Integer
        Dim aryRecordId() As String = Nothing
        Dim objDBUser As New DBUser
        strRecordId = Request.Form("chkRecordId")

        If strRecordId = "" Then

            lblNotice.Text = "Select on checkbox to increase limit."
        ElseIf Not IsNumeric(txtSMS.Text) Then
            lblNotice.Text = "Number of SMS to be added must be a number."
        ElseIf Integer.Parse(txtSMS.Text) <= 0 Or Integer.Parse(txtSMS.Text) > 1000 Then
            lblNotice.Text = "Can only increase or decrease limit by 1 to 1000 per transaction"
        Else


            aryRecordId = strRecordId.Split(",")
            recordsaffected = aryRecordId.Length
            For Each intRecordId In aryRecordId
                objDBUser.decreaselimit(intRecordId, Integer.Parse(txtSMS.Text))
            Next


            objArrayList = objDBUser.getAllUsers
            grdData.DataSource = objArrayList
            grdData.DataBind()
            lblNotice.Text = "<u>" & recordsaffected & "</u> records activated."

        End If
    End Sub

    Protected Sub btnPromote_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnPromote.Click
        Dim objArrayList As New ArrayList
        Dim strRecordId As String
        Dim intRecordId As Integer
        Dim recordsaffected As Integer
        Dim aryRecordId() As String = Nothing
        Dim objDBUser As New DBUser
        strRecordId = Request.Form("chkRecordId")

        If strRecordId = "" Then

            lblNotice.Text = "Select on checkbox to increase limit."

        Else


            aryRecordId = strRecordId.Split(",")
            recordsaffected = aryRecordId.Length
            For Each intRecordId In aryRecordId
                objDBUser.promote(intRecordId)
            Next


            objArrayList = objDBUser.getAllUsers
            grdData.DataSource = objArrayList
            grdData.DataBind()
            lblNotice.Text = "<u>" & recordsaffected & "</u> records activated."
        End If

    End Sub

    Protected Sub Button4_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button4.Click
        Dim objArrayList As New ArrayList
        Dim strRecordId As String
        Dim intRecordId As Integer
        Dim recordsaffected As Integer
        Dim aryRecordId() As String = Nothing
        Dim objDBUser As New DBUser
        strRecordId = Request.Form("chkRecordId")

        If strRecordId = "" Then

            lblNotice.Text = "Select on checkbox to increase limit."

        Else


            aryRecordId = strRecordId.Split(",")
            recordsaffected = aryRecordId.Length
            For Each intRecordId In aryRecordId
                objDBUser.demote(intRecordId)
            Next


            objArrayList = objDBUser.getAllUsers
            grdData.DataSource = objArrayList
            grdData.DataBind()
            lblNotice.Text = "<u>" & recordsaffected & "</u> records activated."
        End If

    End Sub

    Private Sub grdData_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles grdData.PageIndexChanged

        grdData.CurrentPageIndex = e.NewPageIndex
        bindData()

    End Sub

End Class
