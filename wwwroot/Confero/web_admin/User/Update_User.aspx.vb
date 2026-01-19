
Partial Class User_Update_User
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
                    id = Request.QueryString("id")

                    objUserUpdate = objDBUSer.Get_Single_User(id)

                    lblTitle.Text = "Update User Account, #" & id

                    txtAddress.Text = objUserUpdate.Address.Trim
                    txtDob.Text = objUserUpdate.Dob.Trim
                    txtEmail.Text = objUserUpdate.Email.Trim
                    lstGender.SelectedValue = objUserUpdate.Gender.Trim
                    txtName.Text = objUserUpdate.Name.Trim
                    txtTelephone.Text = objUserUpdate.Telephone.Trim
                    lstRole.SelectedValue = objUserUpdate.Type.Trim
                    txtUsername.Text = Request.QueryString("user")

                    ViewState("pwd") = objUserUpdate.Password.Trim

                    txtUsername.Enabled = False
                End If
            End If
        End If
    End Sub

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Dim objUser As New User
        Dim objDBUser As New DBUser
        Dim row As Integer
        Dim status As String = ""

        objUser.Address = txtAddress.Text
        objUser.Dob = txtDob.Text
        objUser.Email = txtEmail.Text
        objUser.Gender = lstGender.SelectedValue
        objUser.Name = txtName.Text
        objUser.Telephone = txtTelephone.Text

        If txtPassword.Text.Equals("") Or txtPassword.Text = Nothing Then
            objUser.Password = ViewState("pwd")
            status = "hash"
        Else
            objUser.Password = txtPassword.Text
        End If

        objUser.UserId = Request.QueryString("id")
        objUser.Type = lstRole.SelectedValue

        row = objDBUser.Update_User(objUser, status)

        If row = 0 Then
            lblStatus.Text = "Status: Error in updating data"
            lblStatus.ForeColor = Drawing.Color.Red
        Else
            lblStatus.Text = "Status: Record Updated"
            lblStatus.ForeColor = Drawing.Color.Green
        End If
    End Sub

End Class
