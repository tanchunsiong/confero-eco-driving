
Partial Class Home
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objUser As New User
        Dim objDBPropellent As New DBPropellent
        Dim objDBTrip As New DBTrip
        Dim objDBUser As New DBUser
        Dim objDBVehicle As New DBVehicle
        Dim arraylist As ArrayList
        Dim userId As Integer

        If Page.IsPostBack = False Then

            If Session.Item("user") Is Nothing Then
                Response.Redirect("..\..\Login.aspx")
            Else
                objUser = CType(Session.Item("user"), User)

                userId = objUser.UserId

                arraylist = objDBPropellent.Get_User_Propellent(userId)
                lblPropellent.Text = "Total propellent record: " + arraylist.Count.ToString

                arraylist = objDBTrip.Get_User_Trip(userId)
                lblTrip.Text = "Total trip record: " + arraylist.Count.ToString

                arraylist = objDBUser.Get_All_UserGenerateInfo()
                lblUserGenerate.Text = "Total user generated info record: " + arraylist.Count.ToString

                arraylist = objDBVehicle.Get_User_Vehicle(userId)
                lblVehicle.Text = "Total vehicle record: " + arraylist.Count.ToString

            End If
        End If
    End Sub
End Class
