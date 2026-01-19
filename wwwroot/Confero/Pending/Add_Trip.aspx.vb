
Partial Class Trip_Add_Trip
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim VehicleConfigArr As New ArrayList
        Dim objDBVehicle As New DBVehicle
        Dim objUser As New User

        If Page.IsPostBack = False Then

            If Session.Item("user") Is Nothing Then
                Response.Redirect("Login.aspx")
            Else
                objUser = CType(Session.Item("user"), User)

                'VehicleConfigArr = objDBVehicle.Get_All_VehicleType

                'lstVehicleConfig.DataSource = VehicleConfigArr
                'lstVehicleConfig.DataTextField = "Description"
                'lstVehicleConfig.DataValueField = "VehicleTypeID"
                'lstVehicleConfig.DataBind()
            End If
        End If
    End Sub

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click

    End Sub

End Class
