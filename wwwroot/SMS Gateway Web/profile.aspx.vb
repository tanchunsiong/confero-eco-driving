Public Partial Class profile
    Inherits System.Web.UI.Page
    Dim smsWS As New WebReference.Service1
    Dim loginuser As New user
    Dim objDBUser As New DBUser
    Dim objDBSMS As New DBSMS
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'check for session
        Try
            loginuser = Session("user")
            If loginuser Is Nothing Then
                Response.Redirect("login.aspx")
            ElseIf Not loginuser.type.ToLower.Equals("user") Then
                Response.Redirect("login.aspx")

            Else
                objDBUser.updateUser(loginuser)
                lblUserName.Text = loginuser.username
                lblSMSLeft.Text = loginuser.totallimit - loginuser.currentUsage
               
            End If
        Catch ex As Exception
            Response.Redirect("login.aspx")
        End Try
    End Sub

End Class