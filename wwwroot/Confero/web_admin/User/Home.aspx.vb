
Partial Class Home
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objUser As New User
        Dim objDBMis As New DBMis
        Dim row As Integer

        If Page.IsPostBack = False Then

            If Session.Item("user") Is Nothing Then
                Response.Redirect("..\..\Login.aspx")
            Else
                objUser = CType(Session.Item("user"), User)

                row = objDBMis.Count_Record("tblPropellent")
                lblPropellent.Text = "Total propellent record: " + row.ToString

                row = objDBMis.Count_Record("tblPropellentType")
                lblPropellentType.Text = "Total propellent type record: " + row.ToString

                row = objDBMis.Count_Record("tblTrip")
                lblTrip.Text = "Total trip record: " + row.ToString

                row = objDBMis.Count_Record("tblTyre")
                lblTyre.Text = "Total tyre record: " + row.ToString

                row = objDBMis.Count_Record("tblUser")
                lblUser.Text = "Total user account record: " + row.ToString

                row = objDBMis.Count_Record("tblUserGeneratedInformation")
                lblUserGenerate.Text = "Total user generated info record: " + row.ToString

                row = objDBMis.Count_Record("tblVehicle")
                lblVehicle.Text = "Total vehicle record: " + row.ToString

                row = objDBMis.Count_Record("tblVehicleConfiguration")
                lblConfiguration.Text = "Total vehicle configuration record: " + row.ToString

                row = objDBMis.Count_Record("tblVehicleOwnership")
                lblOwnership.Text = "Total vehicle ownership record: " + row.ToString

                row = objDBMis.Count_Record("tblVehicleType")
                lblType.Text = "Total vehicle type record: " + row.ToString
            End If
        End If
    End Sub
End Class
