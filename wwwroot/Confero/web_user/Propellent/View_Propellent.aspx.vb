
Partial Class Propellent_View_Propellent
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objUser As New User

        If Page.IsPostBack = False Then

            If Session.Item("user") Is Nothing Then
                Response.Redirect("..\..\Login.aspx")
            Else
                objUser = CType(Session.Item("user"), User)
                ViewState("userId") = objUser.UserId
                bindData()
            End If
        End If
    End Sub

    Sub bindData()

        Dim objArrayList As New ArrayList
        Dim objDBPropellent As New DBPropellent

        If Not txtSearch.Text.Trim.Equals("") Then
            objArrayList = objDBPropellent.Search_User_Propellent(lstSelect.SelectedValue, txtSearch.Text, ViewState("userId"))
            lblSearch.Text = "Search Record: " + objArrayList.Count.ToString
        Else
            objArrayList = objDBPropellent.Get_User_Propellent(ViewState("userId"))
            ViewState("total") = objArrayList.Count.ToString
        End If

        grdData.DataSource = objArrayList

        ' if statment to handle the datagrid paging
        If (objArrayList.Count >= ((grdData.PageSize * grdData.CurrentPageIndex) + 1)) Then

        Else
            grdData.CurrentPageIndex = 0
        End If

        If objArrayList.Count = 0 Then
            btnExport.Enabled = False
        Else
            btnExport.Enabled = True
        End If

        lblTotal.Text = "Total record: " & ViewState("total")
        grdData.DataBind()
    End Sub

    Sub myDataGrid_PageChanger(ByVal Source As Object, ByVal e As DataGridPageChangedEventArgs)
        ' Set the CurrentPageIndex before binding the grid 
        grdData.CurrentPageIndex = e.NewPageIndex
        bindData()
    End Sub

    Sub changeRec(ByVal sender As Object, ByVal e As EventArgs) Handles lstNoRec.SelectedIndexChanged
        'set the page size depend on the number of record select
        grdData.PageSize = CInt(lstNoRec.SelectedItem.Value)
        bindData()
    End Sub

    Protected Sub grdData_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdData.ItemCommand

        Dim objDBropellent As New DBPropellent
        Dim reply As String

        If (e.CommandName.Equals("delete")) Then
            If IsNumeric(e.Item.Cells(0).Text) Then

                reply = MsgBox("Delete of this record might course error in other database table?", MsgBoxStyle.YesNo, "Delete Record")

                If reply = vbYes Then
                    objDBropellent.Delete_By_Propellent(e.Item.Cells(0).Text)
                    bindData()
                End If
            End If
        ElseIf (e.CommandName.Equals("update")) Then
            Response.Redirect("~/web_user/Propellent/Add_Propellent.aspx?for=update&id=" & e.Item.Cells(0).Text & "&model=" & e.Item.Cells(3).Text & "&make=" & e.Item.Cells(4).Text)
        End If
    End Sub

    Protected Sub btnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnView.Click
        txtSearch.Text = ""
        lblSearch.Text = "Search Record: 0"
        bindData()
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        bindData()
    End Sub

    Protected Sub btnExport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Dim objExcel As New DBMis
        Dim query, header As String

        If txtSearch.Text.Trim.Equals("") Then
            query = "SELECT tblPropellent.propellentID, tblPropellent.propellentTypeID, tblPropellentType.description, tblPropellent.octane, tblPropellent.brand, tblVehicle.model, " & _
                     " tblVehicle.make FROM tblVehicleOwnership INNER JOIN " & _
                     " tblUser ON tblVehicleOwnership.userID = tblUser.userID INNER JOIN " & _
                     " tblVehicle ON tblVehicleOwnership.vehicleID = tblVehicle.vehicleID INNER JOIN " & _
                     " tblVehicleConfiguration ON tblVehicle.vehicleID = tblVehicleConfiguration.vehicleID INNER JOIN " & _
                     " tblPropellent ON tblVehicleConfiguration.propellentID = tblPropellent.propellentID INNER JOIN " & _
                     " tblPropellentType ON tblPropellent.propellentTypeID = tblPropellentType.PropellentTypeID " & _
                     " WHERE (tblVehicleOwnership.userID = " & ViewState("userId") & ") ORDER BY tblPropellent.propellentID DESC"

        Else

            query = "SELECT tblPropellent.propellentID, tblPropellent.propellentTypeID, tblPropellentType.description, tblPropellent.octane, tblPropellent.brand, tblVehicle.model, " & _
                    " tblVehicle.make FROM tblVehicleOwnership INNER JOIN " & _
                    " tblUser ON tblVehicleOwnership.userID = tblUser.userID INNER JOIN " & _
                    " tblVehicle ON tblVehicleOwnership.vehicleID = tblVehicle.vehicleID INNER JOIN " & _
                    " tblVehicleConfiguration ON tblVehicle.vehicleID = tblVehicleConfiguration.vehicleID INNER JOIN " & _
                    " tblPropellent ON tblVehicleConfiguration.propellentID = tblPropellent.propellentID INNER JOIN " & _
                    " tblPropellentType ON tblPropellent.propellentTypeID = tblPropellentType.PropellentTypeID " & _
                    " WHERE (tblVehicleOwnership.userID = " & ViewState("userId") & " and " & lstSelect.SelectedValue & "  like '%" & txtSearch.Text & "%') " & _
                    " ORDER BY tblPropellent.propellentID DESC"
        End If

        header = "List of propellent"

        objExcel.Excel_View(query, header)
    End Sub
End Class
