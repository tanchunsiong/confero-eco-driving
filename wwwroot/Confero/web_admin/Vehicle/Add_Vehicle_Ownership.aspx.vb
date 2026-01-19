
Partial Class Vehicle_Add_Vehicle_Ownership
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim UserNameArr As New ArrayList
        Dim objDBUser As New DBUser
        Dim objUser As New User
        Dim VehicleTypeArr As New ArrayList
        Dim objDBVehicle As New DBVehicle

        If Page.IsPostBack = False Then

            If Session.Item("user") Is Nothing Then
                Response.Redirect("..\..\Login.aspx")
            Else
                objUser = CType(Session.Item("user"), User)

                UserNameArr = objDBUser.Get_All_User

                lstUsername.DataSource = UserNameArr
                lstUsername.DataTextField = "LoginId"
                lstUsername.DataValueField = "UserId"
                lstUsername.DataBind()

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
        Dim objVehicleOwnership As New VehicleOwnership
        Dim row As Integer
        Dim identity As Integer

        objVehicle.Capacity = txtCapacity.Text
        objVehicle.Make = txtMake.Text
        objVehicle.Model = txtModel.Text
        objVehicle.Years = txtYears.Text
        objVehicle.VehicleTypeID = CInt(lstVehicleType.SelectedValue)

        identity = objDBVehicle.Add_Vehicle(objVehicle)

        objVehicleOwnership.VehicleID = identity
        objVehicleOwnership.UserID = CInt(lstUsername.SelectedValue)

        row = objDBVehicle.Add_VehicleOwnership(objVehicleOwnership)

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
