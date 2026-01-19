
Partial Class Propellent_Add_Propellent_Type
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim objUser As New User
        Dim objPropellent As New Propellent
        Dim objDBPropellent As New DBPropellent
        Dim method, id As String

        If Page.IsPostBack = False Then

            If Session.Item("user") Is Nothing Then
                Response.Redirect("..\..\Login.aspx")
            Else
                objUser = CType(Session.Item("user"), User)

                method = Request.QueryString("for")

                If method.Equals("update") Then
                    id = Request.QueryString("id")

                    objPropellent = objDBPropellent.Get_Single_PropellentType(id)
                    txtDescription.Text = objPropellent.Description

                    changeText()
                End If
            End If
        End If
    End Sub

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Dim objDBPropellent As New DBPropellent
        Dim objPropellentType As New Propellent
        Dim description As String
        Dim row As Integer
        Dim method, id As String

        description = txtDescription.Text

        method = Request.QueryString("for")

        If method.Equals("update") Then
            id = Request.QueryString("id")

            objPropellentType.Description = description
            objPropellentType.PropellentTypeID = id

            row = objDBPropellent.Update_PropellentType(objPropellentType)
        Else
            row = objDBPropellent.Add_PropellentType(description)
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
    End Sub

    Sub changeText()
        lblStatus.Text = "Status: No record updated"
        btnAdd.Text = "Update"
        lblTitle.Text = "Update Propellent Type, #" & Request.QueryString("id")
    End Sub

End Class
