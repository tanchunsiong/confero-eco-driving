
Partial Class Vehicle_Update_Vehicle
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objUser As New User
        Dim objDBVehicle As New DBVehicle
        Dim objVehicle As New Vehicle
        Dim method, id As String
        Dim VehicleTypeArr As New ArrayList

        If Page.IsPostBack = False Then

            If Session.Item("user") Is Nothing Then
                Response.Redirect("..\..\Login.aspx")
            Else
                objUser = CType(Session.Item("user"), User)

                method = Request.QueryString("for")

                If method.Equals("update") Then
                    id = Request.QueryString("id")

                    objVehicle = objDBVehicle.Get_Single_Vehicle(id)

                    txtCapacity.Text = objVehicle.Capacity
                    txtMake.Text = objVehicle.Make
                    txtModel.Text = objVehicle.Model
                    txtYears.Text = objVehicle.Years

                    VehicleTypeArr = objDBVehicle.Get_All_VehicleType

                    lstVehicleType.DataSource = VehicleTypeArr
                    lstVehicleType.DataTextField = "Description"
                    lstVehicleType.DataValueField = "VehicleTypeID"
                    lstVehicleType.SelectedValue = objVehicle.VehicleTypeID
                    lstVehicleType.DataBind()

                    lblTitle.Text = "Update Vehicle, #" & objVehicle.VehicleID
                  
                End If
            End If
        End If
    End Sub

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Dim objDBVehicle As New DBVehicle
        Dim objVehicle As New Vehicle
        Dim objVehicleOwnership As New VehicleOwnership
        Dim row As Integer
        Dim id As String

        objVehicle.Capacity = txtCapacity.Text
        objVehicle.Make = txtMake.Text
        objVehicle.Model = txtModel.Text
        objVehicle.Years = txtYears.Text
        objVehicle.VehicleTypeID = CInt(lstVehicleType.SelectedValue)

        id = Request.QueryString("id")
        objVehicle.VehicleID = id

        row = objDBVehicle.Update_Vehicle(objVehicle)

        If row = 0 Then
            lblStatus.Text = "Status: Error in updating data"
            lblStatus.ForeColor = Drawing.Color.Red
        Else
            lblStatus.Text = "Status: Record Updated"
            lblStatus.ForeColor = Drawing.Color.Green
        End If


    End Sub

End Class
