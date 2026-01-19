
Partial Class Vehicle_Add_Vehicle_Type
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim objUser As New User
        Dim objDBVehicle As New DBVehicle
        Dim objVehicleType As New VehicleType
        Dim method, id As String

        If Page.IsPostBack = False Then

            If Session.Item("user") Is Nothing Then
                Response.Redirect("..\..\Login.aspx")
            Else
                objUser = CType(Session.Item("user"), User)

                method = Request.QueryString("for")

                If method.Equals("update") Then
                    ID = Request.QueryString("id")

                    objVehicleType = objDBVehicle.Get_Single_VehicleType(id)

                    txtDescription.Text = objVehicleType.Description
                    changeText()
                End If
            End If
        End If
    End Sub

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Dim objDBVehicle As New DBVehicle
        Dim objVehicleType As New VehicleType
        Dim row As Integer
        Dim method, id As String

        objVehicleType.Description = txtDescription.Text

        method = Request.QueryString("for")

        If method.Equals("update") Then
            id = Request.QueryString("id")
            objVehicleType.VehicleTypeID = id

            row = objDBVehicle.Update_VehicleTyre(objVehicleType)

        Else
            row = objDBVehicle.Add_VehicleType(objVehicleType)
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
        lblTitle.Text = "Update Vehicle Type, #" & Request.QueryString("id")
    End Sub
End Class
