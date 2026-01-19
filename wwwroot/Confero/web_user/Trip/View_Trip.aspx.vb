
Partial Class User_View_Trip
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
        Dim objDBTrip As New DBTrip

        If Not txtSearch.Text.Trim.Equals("") Then
            objArrayList = objDBTrip.Search_User_Trip(lstSelect.SelectedValue, txtSearch.Text, ViewState("userId"))
            lblSearch.Text = "Search Record: " + objArrayList.Count.ToString
        Else
            objArrayList = objDBTrip.Get_User_Trip(ViewState("userId"))
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

        Dim objDBTrip As New DBTrip
        Dim reply As String

        If (e.CommandName.Equals("delete")) Then
            If IsNumeric(e.Item.Cells(0).Text) Then

                reply = MsgBox("Do you really want to delete record?", MsgBoxStyle.YesNo, "Delete Record")

                If reply = vbYes Then
                    objDBTrip.Delete_By_Trip(e.Item.Cells(0).Text)
                    bindData()
                End If
            End If
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
            query = "SELECT tblVehicleOwnership.OwnershipID, tblVehicleOwnership.userID, tblVehicleType.description, tblTrip.*, tblVehicle.* " & _
                    "FROM  tblVehicleOwnership INNER JOIN " & _
                    "tblUser ON tblVehicleOwnership.userID = tblUser.userID INNER JOIN " & _
                    "tblVehicle ON tblVehicleOwnership.vehicleID = tblVehicle.vehicleID INNER JOIN " & _
                    "tblVehicleType ON tblVehicle.vehicleTypeID = tblVehicleType.vehicleTypeID INNER JOIN " & _
                    "tblVehicleConfiguration ON tblVehicle.vehicleID = tblVehicleConfiguration.vehicleID INNER JOIN " & _
                    "tblTrip ON tblVehicleConfiguration.vehicleConfigurationID = tblTrip.vehicleConfigurationID " & _
                    "WHERE (tblVehicleOwnership.userID = " & ViewState("userId") & ")"
        Else

            query = "SELECT tblVehicleOwnership.OwnershipID, tblVehicleOwnership.userID, tblVehicleType.description, tblTrip.*, tblVehicle.* " & _
                    "FROM  tblVehicleOwnership INNER JOIN " & _
                    "tblUser ON tblVehicleOwnership.userID = tblUser.userID INNER JOIN " & _
                    "tblVehicle ON tblVehicleOwnership.vehicleID = tblVehicle.vehicleID INNER JOIN " & _
                    "tblVehicleType ON tblVehicle.vehicleTypeID = tblVehicleType.vehicleTypeID INNER JOIN " & _
                    "tblVehicleConfiguration ON tblVehicle.vehicleID = tblVehicleConfiguration.vehicleID INNER JOIN " & _
                    "tblTrip ON tblVehicleConfiguration.vehicleConfigurationID = tblTrip.vehicleConfigurationID " & _
                    "WHERE (tblVehicleOwnership.userID = " & ViewState("userId") & "and " & lstSelect.SelectedValue & " like '%" & txtSearch.Text & "%')"
        End If

        header = "List of trip"

        objExcel.Excel_View(query, header)
    End Sub
End Class
