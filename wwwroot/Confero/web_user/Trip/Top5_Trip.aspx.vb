
Partial Class Top5_Trip
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objUser As New User

        If Page.IsPostBack = False Then

            If Session.Item("user") Is Nothing Then
                Response.Redirect("..\..\Login.aspx")
            Else
                objUser = CType(Session.Item("user"), User)
                ViewState("userId") = objUser.UserId
                ViewState("vehicleID") = Request.QueryString("vehicleId")
                bindData()
            End If
        End If
    End Sub

    Sub bindData()

        Dim objArrayList As New ArrayList
        Dim objDBTrip As New DBTrip

        If Not txtSearch.Text.Trim.Equals("") Then
            objArrayList = objDBTrip.Search_User_Top5_Trip(lstSelect.SelectedValue, txtSearch.Text, ViewState("vehicleID"))
            lblSearch.Text = "Search Record: " + objArrayList.Count.ToString
        Else
            objArrayList = objDBTrip.Get_User_Top5_Trip(ViewState("vehicleID"))
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
            query = "SELECT TOP (5) tblTrip.distanceTravelled, tblTrip.fuelusage, tblVehicleConfiguration.vehicleID, tblPropellentType.description, tblPropellent.octane, " & _
                    "tblPropellent.brand AS PBrand, tblTyre.* " & _
                    "FROM tblTrip INNER JOIN " & _
                    "tblVehicleConfiguration ON tblTrip.vehicleConfigurationID = tblVehicleConfiguration.vehicleConfigurationID INNER JOIN " & _
                    "tblTyre ON tblVehicleConfiguration.tyreID = tblTyre.tyreID INNER JOIN " & _
                    "tblPropellent ON tblVehicleConfiguration.propellentID = tblPropellent.propellentID INNER JOIN " & _
                    "tblPropellentType ON tblPropellent.propellentTypeID = tblPropellentType.PropellentTypeID " & _
                    "WHERE (tblVehicleConfiguration.vehicleID = " & ViewState("vehicleID") & ") " & _
                    "ORDER BY tblTrip.fuelusage DESC, tblTrip.distanceTravelled DESC"
        Else

            query = "SELECT TOP (5) tblTrip.distanceTravelled, tblTrip.fuelusage, tblVehicleConfiguration.vehicleID, tblPropellentType.description, tblPropellent.octane, " & _
                    "tblPropellent.brand AS PBrand, tblTyre.* " & _
                    "FROM tblTrip INNER JOIN " & _
                    "tblVehicleConfiguration ON tblTrip.vehicleConfigurationID = tblVehicleConfiguration.vehicleConfigurationID INNER JOIN " & _
                    "tblTyre ON tblVehicleConfiguration.tyreID = tblTyre.tyreID INNER JOIN " & _
                    "tblPropellent ON tblVehicleConfiguration.propellentID = tblPropellent.propellentID INNER JOIN " & _
                    "tblPropellentType ON tblPropellent.propellentTypeID = tblPropellentType.PropellentTypeID " & _
                    "WHERE (tblVehicleConfiguration.vehicleID = " & ViewState("vehicleID") & " and " & lstSelect.SelectedValue & " like '%" & txtSearch.Text & "%') " & _
                    "ORDER BY tblTrip.fuelusage DESC, tblTrip.distanceTravelled DESC"
        End If

        header = "List of top 5 fuel & tyre"

        objExcel.Excel_View(query, header)
    End Sub
End Class
