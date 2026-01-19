
Partial Class User_Add_User
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objUser As New User
        Dim objUserUpdate As New User
        Dim objDBUSer As New DBUser
        Dim method, id As String

        If Page.IsPostBack = False Then

            If Session.Item("user") Is Nothing Then
                Response.Redirect("..\..\Login.aspx")
            Else
                objUser = CType(Session.Item("user"), User)

                method = Request.QueryString("for")

                If method.Equals("update") Then
                    ID = Request.QueryString("id")

                    objUserUpdate = objDBUSer.Get_Single_User(id)
                    lstRole.SelectedValue = objUserUpdate.Type

                    changeText()
                End If
            End If
        End If
    End Sub

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Dim objUser As New User
        Dim objDBUser As New DBUser
        Dim objDBVehicle As New DBVehicle
        Dim objVehicle As New Vehicle
        Dim objVehicleOwnership As New VehicleOwnership
        Dim idenitiyUser, idenitiyVehicle, row As Integer
        Dim checkUserName As Integer

        checkUserName = objDBUser.Check_Username(txtUsername.Text)

        If checkUserName <> 1 Then

            objUser.Address = txtAddress.Text
            objUser.Dob = txtDob.Text
            objUser.Email = txtEmail.Text
            objUser.Gender = lstGender.SelectedValue
            objUser.Name = txtName.Text
            objUser.Telephone = txtTelephone.Text

            objUser.Password = txtPassword.Text
            objUser.LoginId = txtUsername.Text
            objUser.Type = lstRole.SelectedValue

            idenitiyUser = objDBUser.Add_User(objUser)

            If lstRole.SelectedValue.Equals("user") Then
                objVehicle.Capacity = ""
                objVehicle.Make = ""
                objVehicle.Model = ""
                objVehicle.Years = ""
                objVehicle.VehicleTypeID = 1

                idenitiyVehicle = objDBVehicle.Add_Vehicle(objVehicle)

                objVehicleOwnership.VehicleID = idenitiyVehicle
                objVehicleOwnership.UserID = idenitiyUser

                row = objDBVehicle.Add_VehicleOwnership(objVehicleOwnership)
            End If

            If row = 0 And idenitiyUser = 0 Then
                lblStatus.Text = "Status: Error in adding data"
                lblStatus.ForeColor = Drawing.Color.Red
            Else
                lblStatus.Text = "Status: Record Added"
                lblStatus.ForeColor = Drawing.Color.Green
            End If

            clearText()
        Else
            lblStatus.Text = "Status: User name exist"
            lblStatus.ForeColor = Drawing.Color.Red
        End If

    End Sub

    Sub clearText()
        txtPassword.Text = ""
        txtCPassword.Text = ""
        txtUsername.Text = ""
    End Sub

    Sub changeText()
        lblStatus.Text = "Status: No record updated"
        btnAdd.Text = "Update"
        lblTitle.Text = "Update User Account, #" & Request.QueryString("id")
    End Sub
End Class
