
Partial Class Tyre_View_Tyre
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
        Dim objDBTyre As New DBTyre
        Dim objUser As New User

        If Not txtSearch.Text.Trim.Equals("") Then
            objArrayList = objDBTyre.Search_User_Tyre(lstSelect.SelectedValue, txtSearch.Text, ViewState("userId"))
            lblSearch.Text = "Search Record: " + objArrayList.Count.ToString
        Else
            objArrayList = objDBTyre.Get_User_Tyre(ViewState("userId"))
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

        Dim objDBTyre As New DBTyre
        Dim reply As String

        If (e.CommandName.Equals("delete")) Then
            If IsNumeric(e.Item.Cells(0).Text) Then

                reply = MsgBox("Delete of this record might course error in other database table?", MsgBoxStyle.YesNo, "Delete Record")

                If reply = vbYes Then
                    objDBTyre.Delete_By_Tyre(e.Item.Cells(0).Text)
                    bindData()
                End If
            End If
        ElseIf (e.CommandName.Equals("update")) Then
            Response.Redirect("~/web_user/Tyre/Add_Tyre.aspx?for=update&id=" & e.Item.Cells(0).Text & "&model=" & e.Item.Cells(2).Text & "&make=" & e.Item.Cells(3).Text)
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
            query = "SELECT tblVehicle.model AS car_model, tblVehicle.make, tblTyre.tyreID, tblTyre.brand, tblTyre.width, tblTyre.tyreSize, tblTyre.material, " & _
                    "tblTyre.rollingresistance, tblTyre.model, tblTyre.type, tblUser.userID " & _
                    "FROM tblTyre INNER JOIN " & _
                    "tblVehicleConfiguration ON tblTyre.tyreID = tblVehicleConfiguration.tyreID INNER JOIN " & _
                    "tblVehicle ON tblVehicleConfiguration.vehicleID = tblVehicle.vehicleID INNER JOIN " & _
                    "tblVehicleOwnership ON tblVehicle.vehicleID = tblVehicleOwnership.vehicleID INNER JOIN " & _
                    "tblUser ON tblVehicleOwnership.userID = tblUser.userID " & _
                    "WHERE (tblUser.userID = " & ViewState("userId") & ")"
        Else
            query = "SELECT tblVehicle.model AS car_model, tblVehicle.make, tblTyre.tyreID, tblTyre.brand, tblTyre.width, tblTyre.tyreSize, tblTyre.material, " & _
                    "tblTyre.rollingresistance, tblTyre.model, tblTyre.type, tblUser.userID " & _
                    "FROM tblTyre INNER JOIN " & _
                    "tblVehicleConfiguration ON tblTyre.tyreID = tblVehicleConfiguration.tyreID INNER JOIN " & _
                    "tblVehicle ON tblVehicleConfiguration.vehicleID = tblVehicle.vehicleID INNER JOIN " & _
                    "tblVehicleOwnership ON tblVehicle.vehicleID = tblVehicleOwnership.vehicleID INNER JOIN " & _
                    "tblUser ON tblVehicleOwnership.userID = tblUser.userID " & _
                    "WHERE (tblUser.userID = " & ViewState("userId") & " and " & lstSelect.SelectedValue & " like '%" & txtSearch.Text & "%')"
        End If

        header = "List of tyre"

        objExcel.Excel_View(query, header)
    End Sub
End Class
