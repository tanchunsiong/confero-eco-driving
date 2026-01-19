
Partial Class User_Update_User
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objUser As New User
        Dim objUserUpdate As New User
        Dim objDBUSer As New DBUser

        If Page.IsPostBack = False Then

            If Session.Item("user") Is Nothing Then
                Response.Redirect("..\..\Login.aspx")
            Else
                objUser = CType(Session.Item("user"), User)

                objUserUpdate = objDBUSer.Get_Single_User(objUser.UserId)

                txtAddress.Text = objUserUpdate.Address.Trim
                txtDob.Text = objUserUpdate.Dob.Trim
                txtEmail.Text = objUserUpdate.Email.Trim
                lstGender.SelectedValue = objUserUpdate.Gender.Trim
                txtName.Text = objUserUpdate.Name.Trim
                txtTelephone.Text = objUserUpdate.Telephone.Trim

            End If
        End If
    End Sub

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Dim objUser As New User
        Dim objUserUpdate As New User
        Dim objDBUser As New DBUser
        Dim row As Integer

        objUserUpdate = CType(Session.Item("user"), User)

        objUser.Address = txtAddress.Text
        objUser.Dob = txtDob.Text
        objUser.Email = txtEmail.Text
        objUser.Gender = lstGender.SelectedValue
        objUser.Name = txtName.Text
        objUser.Telephone = txtTelephone.Text

        objUser.UserId = objUserUpdate.UserId
        objUser.Password = objUserUpdate.Password
        objUser.Type = objUserUpdate.Type

        row = objDBUser.Update_User(objUser, "hash")

        If row = 0 Then
            lblStatus.Text = "Status: Error in updating data"
            lblStatus.ForeColor = Drawing.Color.Red
        Else
            lblStatus.Text = "Status: Record Updated"
            lblStatus.ForeColor = Drawing.Color.Green
        End If
    End Sub

End Class
