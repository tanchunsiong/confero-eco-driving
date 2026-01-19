
Partial Class Vehicle_View_Vehicle_Configuration
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objUser As New User

        If Page.IsPostBack = False Then

            If Session.Item("user") Is Nothing Then
                Response.Redirect("..\..\Login.aspx")
            Else
                objUser = CType(Session.Item("user"), User)
                lblstatus.text = ""
                bindData()
            End If
        End If
    End Sub

    Sub bindData()

        Dim objArrayList As New ArrayList
        Dim objDBVehicle As New DBVehicle

        If Not txtSearch.Text.Trim.Equals("") Then
            objArrayList = objDBVehicle.Search_By_VehicleConfiguration(lstSelect.SelectedValue, txtSearch.Text)
            lblSearch.Text = "Search Record: " + objArrayList.Count.ToString
        Else
            objArrayList = objDBVehicle.Get_All_VehicleConfiguration
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
        Dim reply As String

        If (e.CommandName.Equals("delete")) Then
            If IsNumeric(e.Item.Cells(0).Text) Then

                reply = MsgBox("Delete of this record might course error in other database table?", MsgBoxStyle.YesNo, "Delete Record")

                If reply = vbYes Then
                    Try
                        objDBVehicle.Delete_By_VehicleConfiguration(e.Item.Cells(0).Text, e.Item.Cells(2).Text)
                        bindData()

                        lblStatus.Text = "Status: 1 record deleted"
                        lblStatus.ForeColor = Drawing.Color.Green
                    Catch ex As Exception
                        lblStatus.Text = "Status: You are not allow to delete this record due to foreign key."
                        lblStatus.ForeColor = Drawing.Color.Red

                    End Try

                End If
            End If
        End If
    End Sub

    Protected Sub btnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnView.Click
        txtSearch.Text = ""
        lblstatus.text = ""
        lblSearch.Text = "Search Record: 0"
        bindData()
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        lblstatus.text = ""
        bindData()
    End Sub

    Protected Sub btnExport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Dim objExcel As New DBMis
        Dim query, header As String

        lblstatus.text = ""

        If txtSearch.Text.Trim.Equals("") Then
            query = "SELECT * FROM tblVehicleConfiguration"
        Else
            query = "SELECT * FROM tblVehicleConfiguration where " & lstSelect.SelectedValue & " like '" & txtSearch.Text & "%'"
        End If

        header = "List of vehicle configuration"

        objExcel.Excel_View(query, header)
    End Sub
End Class
