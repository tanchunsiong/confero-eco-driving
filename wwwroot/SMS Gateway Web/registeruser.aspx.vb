
Partial Class registeruser
    Inherits System.Web.UI.Page

    Dim objDBUser As New DBUser
    Dim objUser As New user

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSubmit.Click

        Dim objDBMis As New DBMis

        objUser.username = TextBox1.Text
        objUser.password = objDBMis.GenerateHash(TextBox2.Text)
        objUser.mobilenumber = TextBox4.Text

        If Not IsNumeric(TextBox4.Text) Then
            lblNotice.Text = "Mobile Number must be numeric"
        Else
            lblNotice.Text = objDBUser.createUser(objUser)

            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox4.Text = ""
        End If

    End Sub
End Class
