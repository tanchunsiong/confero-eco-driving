
Partial Class Tyre_Add_Tyre
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim objUser As New User
        Dim objTyre As New Tyre
        Dim objDBTyre As New DBTyre
        Dim method, id, make, model As String

        If Page.IsPostBack = False Then

            If Session.Item("user") Is Nothing Then
                Response.Redirect("..\..\Login.aspx")
            Else
                objUser = CType(Session.Item("user"), User)

                method = Request.QueryString("for")

                If method.Equals("update") Then
                    id = Request.QueryString("id")
                    make = Request.QueryString("make")
                    model = Request.QueryString("model")

                    objTyre = objDBTyre.Get_Single_Tyre(id)
                    txtBrand.Text = objTyre.Brand
                    txtMaterial.Text = objTyre.Material
                    txtResistance.Text = objTyre.RollingResistance
                    txtTyre.Text = objTyre.TyreSize
                    txtWidth.Text = objTyre.Width
                    txtModel.Text = objTyre.Model
                    txtType.Text = objTyre.Type

                    txtCarModel.Text = model
                    txtCarMake.Text = make

                    changeText()
                End If
            End If
        End If

    End Sub

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Dim objDBTyre As New DBTyre
        Dim objTyre As New Tyre
        Dim row As Integer
        Dim method, id As String

        objTyre.Brand = txtBrand.Text
        objTyre.Material = txtMaterial.Text
        objTyre.RollingResistance = txtResistance.Text
        objTyre.TyreSize = txtTyre.Text
        objTyre.Width = txtWidth.Text
        objTyre.Model = txtModel.Text
        objTyre.Type = txtType.Text
        'objTyre.Pressure = txtPressure.Text

        method = Request.QueryString("for")

        If method.Equals("update") Then
            id = Request.QueryString("id")
            objTyre.TyreID = id

            row = objDBTyre.Update_Tyre(objTyre)
        Else
            row = objDBTyre.Add_Tyre(objTyre)
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
        txtMaterial.Text = ""
        txtResistance.Text = ""
        txtTyre.Text = ""
        txtWidth.Text = ""
        txtModel.Text = ""
        txtType.Text = ""
    End Sub

    Sub changeText()
        lblStatus.Text = "Status: No record updated"
        btnAdd.Text = "Update"
        lblTitle.Text = "Update Tyre, #" & Request.QueryString("id")
    End Sub
End Class
