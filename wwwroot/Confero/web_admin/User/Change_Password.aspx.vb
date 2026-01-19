
Partial Class User_Change_Password
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objUser As New User

        If Page.IsPostBack = False Then

            If Session.Item("user") Is Nothing Then
                Response.Redirect("..\..\Login.aspx")
            Else
                objUser = CType(Session.Item("user"), User)

                txtUsername.Text = objUser.LoginId
            End If
        End If
    End Sub

    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click

        Dim objUser As New User
        Dim objSession As New User
        Dim objDBUser As New DBUser
        Dim row As Integer

        objSession = CType(Session.Item("user"), User)

        objUser.Password = txtPassword.Text
        objUser.UserId = objSession.UserId

        row = objDBUser.Change_Password(objUser)

        If row = 0 Then
            lblStatus.Text = "Status: Error in updating data"
            lblStatus.ForeColor = Drawing.Color.Red
        Else
            lblStatus.Text = "Status: Password changed"
            lblStatus.ForeColor = Drawing.Color.Green
        End If

        clearText()

    End Sub

    Sub clearText()
        txtPassword.Text = ""
        txtCPassword.Text = ""
    End Sub
End Class
