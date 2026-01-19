
Partial Class Vehicle_View_Vehicle
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
        Dim objDBVehicle As New DBVehicle

        If Not txtSearch.Text.Trim.Equals("") Then
            objArrayList = objDBVehicle.Search_User_Vehicle(lstSelect.SelectedValue, txtSearch.Text, ViewState("userId"))
            lblSearch.Text = "Search Record: " + objArrayList.Count.ToString
        Else
            objArrayList = objDBVehicle.Get_User_Vehicle(ViewState("userId"))
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

        Dim objDBVehicle As New DBVehicle
        Dim objVehicleOwnership As New VehicleOwnership
        Dim objVehicleConfiguration As New VehicleConfiguration
        Dim reply As String

        If (e.CommandName.Equals("delete")) Then
            If IsNumeric(e.Item.Cells(0).Text) Then

                reply = MsgBox("Delete of this record might course error in other database table?", MsgBoxStyle.YesNo, "Delete Record")

                If reply = vbYes Then
                    objVehicleOwnership = objDBVehicle.Get_Single_VehicleOwnership(e.Item.Cells(0).Text)
                    objVehicleConfiguration = objDBVehicle.Get_Single_VehicleConfiguration(e.Item.Cells(0).Text)

                    objDBVehicle.Delete_By_VehicleConfiguration(objVehicleConfiguration.VehicleConfigurationID, objVehicleConfiguration.PropellentID)
                    objDBVehicle.Delete_By_Vehicle(objVehicleOwnership.OwnershipID, e.Item.Cells(0).Text)

                    bindData()
                End If
            End If
        ElseIf (e.CommandName.Equals("update")) Then
            Response.Redirect("~/web_user/Vehicle/Update_Vehicle.aspx?for=update&id=" & e.Item.Cells(0).Text)
        ElseIf (e.CommandName.Equals("mileage")) Then
            Response.Redirect("~/web_user/Trip/Top5_Trip.aspx?&vehicleId=" & e.Item.Cells(0).Text)
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
            query = "SELECT tblVehicleOwnership.OwnershipID, tblVehicleOwnership.userID, tblVehicle.vehicleID, tblVehicle.vehicleTypeID, tblVehicle.model, tblVehicle.make, " & _
                    "tblVehicle.years, tblVehicle.capacity, tblVehicleType.description " & _
                    "FROM tblVehicleOwnership INNER JOIN " & _
                    "tblUser ON tblVehicleOwnership.userID = tblUser.userID INNER JOIN " & _
                    "tblVehicle ON tblVehicleOwnership.vehicleID = tblVehicle.vehicleID INNER JOIN " & _
                    "tblVehicleType ON tblVehicle.vehicleTypeID = tblVehicleType.vehicleTypeID " & _
                    "WHERE (tblVehicleOwnership.userID = " & ViewState("userId") & ")"
        Else
            query = "SELECT tblVehicleType.description, tblUser.loginID, tblVehicle.* " & _
                    "FROM tblVehicle INNER JOIN " & _
                    "tblVehicleType ON tblVehicle.vehicleTypeID = tblVehicleType.vehicleTypeID INNER JOIN " & _
                    "tblVehicleOwnership ON tblVehicle.vehicleID = tblVehicleOwnership.vehicleID INNER JOIN " & _
                    "tblUser ON tblVehicleOwnership.userID = tblUser.userID " & _
                    "where (tblVehicleOwnership.userID = " & ViewState("userId") & " and " & lstSelect.SelectedValue & " like '%" & txtSearch.Text & "%')"

        End If

        header = "List of vehicle"

        objExcel.Excel_View(query, header)
    End Sub
End Class
