
Partial Class Index
    Inherits System.Web.UI.Page

    Protected Sub btnIndex_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnIndex.Click
        Response.Redirect("mainInfo.aspx")
    End Sub

    Protected Sub btnLogin_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnLogin.Click
        Response.Redirect("login.aspx")
    End Sub
End Class
