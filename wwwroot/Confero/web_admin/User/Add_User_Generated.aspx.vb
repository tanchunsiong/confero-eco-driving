
Partial Class User_Add_User_Generated
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objUser As New User
        Dim objUserGenerateInfo As New UserGenerateInfo
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

                    objUserGenerateInfo = objDBUSer.Get_Single_UserGenerateInfo(id)
                    txtDescription.Text = objUserGenerateInfo.Description
                    txtValue.Text = objUserGenerateInfo.Value

                    changeText()
                End If

            End If
        End If
    End Sub

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Dim objUser As New UserGenerateInfo
        Dim objDBUser As New DBUser
        Dim row As Integer
        Dim method, id As String

        objUser.Description = txtDescription.Text
        objUser.Value = txtValue.Text

        method = Request.QueryString("for")

        If method.Equals("update") Then

            id = Request.QueryString("id")
            objUser.UserGenerateInformationID = id

            row = objDBUser.Update_UserGenerateInfo(objUser)
        Else
            row = objDBUser.Add_UserGenerateInfo(objUser)
            clearText()
        End If

        If method.Equals("update") Then
            If row = 0 Then
                lblStatus.Text = "Status: Error in updating data"
                lblStatus.ForeColor = Drawing.Color.Red
            Else
                lblStatus.Text = "Status: Record Updated"
                lblStatus.ForeColor = Drawing.Color.Green
            End If
        Else
            If row = 0 Then
                lblStatus.Text = "Status: Error in adding data"
                lblStatus.ForeColor = Drawing.Color.Red
            Else
                lblStatus.Text = "Status: Record Added"
                lblStatus.ForeColor = Drawing.Color.Green
            End If
        End If
    End Sub

    Sub clearText()
        txtDescription.Text = ""
        txtValue.Text = ""
    End Sub

    Sub changeText()
        lblStatus.Text = "Status: No record updated"
        btnAdd.Text = "Update"
        lblTitle.Text = "Update User Generated Info, #" & Request.QueryString("id")
    End Sub
   
End Class
