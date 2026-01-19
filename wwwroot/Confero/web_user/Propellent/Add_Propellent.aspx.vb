
Partial Class Propellent_Add_Propellent
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim PropellentTypeArr As New ArrayList
        Dim objDBPropellent As New DBPropellent
        Dim objPropellent As New Propellent
        Dim method, id As String
        Dim objUser As New User

        If Page.IsPostBack = False Then

            If Session.Item("user") Is Nothing Then
                Response.Redirect("..\..\Login.aspx")
            Else
                objUser = CType(Session.Item("user"), User)

                PropellentTypeArr = objDBPropellent.Get_All_PropellentType

                lstPropellentType.DataSource = PropellentTypeArr
                lstPropellentType.DataTextField = "Description"
                lstPropellentType.DataValueField = "PropellentTypeID"

                method = Request.QueryString("for")

                If method.Equals("update") Then
                    id = Request.QueryString("id")

                    objPropellent = objDBPropellent.Get_Single_Propellent(id)
                    txtBrand.Text = objPropellent.Brand
                    txtOctane.Text = objPropellent.Octane

                    lstPropellentType.SelectedValue = objPropellent.PropellentTypeID
                    changeText()
                End If

                txtModel.Text = Request.QueryString("model")
                txtMake.Text = Request.QueryString("make")

                txtMake.Enabled = False
                txtModel.Enabled = False

                lstPropellentType.DataBind()
            End If
        End If

    End Sub

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Dim objDBPropellent As New DBPropellent
        Dim objPropellent As New Propellent
        Dim row As Integer
        Dim method, id As String

        objPropellent.Brand = txtBrand.Text
        objPropellent.Octane = txtOctane.Text
        objPropellent.PropellentTypeID = CInt(lstPropellentType.SelectedValue)

        method = Request.QueryString("for")

        If method.Equals("update") Then
            id = Request.QueryString("id")
            objPropellent.PropellentID = id
            row = objDBPropellent.Update_Propellent(objPropellent)
        Else
            row = objDBPropellent.Add_Propellent(objPropellent)
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
        txtBrand.Text = ""
        txtOctane.Text = ""
    End Sub


    Sub changeText()
        lblStatus.Text = "Status: No record updated"
        btnAdd.Text = "Update"
        lblTitle.Text = "Update Propellent, #" & Request.QueryString("id")
    End Sub
End Class
