
Partial Class Vehicle_Add_Vehicle
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim VehicleTypeArr As New ArrayList
        Dim objDBVehicle As New DBVehicle
        Dim objUser As New User

        If Page.IsPostBack = False Then

            If Session.Item("user") Is Nothing Then
                Response.Redirect("Login.aspx")
            Else
                objUser = CType(Session.Item("user"), User)

                VehicleTypeArr = objDBVehicle.Get_All_VehicleType

                lstVehicleType.DataSource = VehicleTypeArr
                lstVehicleType.DataTextField = "Description"
                lstVehicleType.DataValueField = "VehicleTypeID"
                lstVehicleType.DataBind()
            End If
        End If

    End Sub

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Dim objDBVehicle As New DBVehicle
        Dim objVehicle As New Vehicle
        Dim row As Integer

        objVehicle.Capacity = txtCapacity.Text
        objVehicle.Make = txtMake.Text
        objVehicle.Model = txtModel.Text
        objVehicle.Years = txtYears.Text
        objVehicle.VehicleTypeID = CInt(lstVehicleType.SelectedValue)

        row = objDBVehicle.Add_Vehicle(objVehicle)

        If row = 0 Then
            lblStatus.Text = "Status: Error in adding data"
            lblStatus.ForeColor = Drawing.Color.Red
        Else
            lblStatus.Text = "Status: Record Added"
            lblStatus.ForeColor = Drawing.Color.Green
        End If

        clearText()
    End Sub

    Sub clearText()
        txtCapacity.Text = ""
        txtMake.Text = ""
        txtModel.Text = ""
        txtYears.Text = ""
    End Sub
End Class
