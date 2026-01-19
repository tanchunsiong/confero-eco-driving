
Partial Class web_admin_User_Setting
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim objUser As New User
        Dim objDBSetting As New DBMis
        Dim objSetting As Setting

        If Page.IsPostBack = False Then

            If Session.Item("user") Is Nothing Then
                Response.Redirect("..\..\Login.aspx")
            Else
                objUser = CType(Session.Item("user"), User)

                objSetting = objDBSetting.Get_Setting
                txtTimeout.Text = objSetting.Timeout
                txtAttempts.Text = objSetting.Attempts
            End If
        End If

    End Sub

    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Dim objData As New Setting
        Dim objDBSetting As New DBMis
        Dim row As Integer

        objData.SettingId = 1
        objData.Timeout = txtTimeout.Text
        objData.Attempts = txtAttempts.Text

        row = objDBSetting.Update_Setting(objData)

        If row = 0 Then
            lblStatus.Text = "Status: Error in updating data"
            lblStatus.ForeColor = Drawing.Color.Red
        Else
            lblStatus.Text = "Status: Setting changed"
            lblStatus.ForeColor = Drawing.Color.Green
        End If
    End Sub


End Class
