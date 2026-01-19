Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.Web.Configuration

Partial Class login
    Inherits System.Web.UI.Page


    'Public Sub Encrypt(ByVal protectProvider As String)
    '    Dim config As Configuration = WebConfigurationManager.OpenWebConfiguration(Request.ApplicationPath)
    '    Dim configsection As ConfigurationSection = config.Sections("connectionStrings")
    '    configsection.SectionInformation.ProtectSection(protectProvider)
    '    config.Save()
    'End Sub

    'Public Sub Decrypt()
    '    Dim config As Configuration = WebConfigurationManager.OpenWebConfiguration(Request.ApplicationPath)
    '    Dim configsection As ConfigurationSection = config.Sections("connectionStrings")
    '    configsection.SectionInformation.UnprotectSection()
    '    config.Save()
    'End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Encrypt("DataProtectionConfigurationProvider")
        Dim convertSec As Integer = CInt(DateTime.Now.Hour) * 3600 + CInt(DateTime.Now.Minute) * 60

        Dim objDBSetting As New DBMis
        Dim objSetting As New Setting

        If ViewState("maxAttempts") = Nothing Then
            objSetting = objDBSetting.Get_Setting()

            ViewState("maxAttempts") = objSetting.Attempts
            ViewState("timeout_Mins") = objSetting.Timeout
            ViewState("attempts") = 0
        End If

        'If ViewState("attempts") = Nothing Then
        '    ViewState("attempts") = 0
        'End If

        If ViewState("lockout_time") = Nothing Then
            ViewState("lockout_time") = 0
        Else
            If ViewState("attempts").Equals(ViewState("maxAttempts")) Then
                If convertSec - CInt(ViewState("lockout_time")) >= CInt(ViewState("timeout_Mins")) * 60 Then
                    ViewState("attempts") = 0
                End If
            End If
        End If

        'MsgBox("convertSec:" + CStr(convertSec - CInt(ViewState("lockout_time"))) + " current:" + convertSec.ToString)

    End Sub

    Protected Sub btnLogin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        Dim record As New Integer
        Dim objDBUser As New DBUser
        Dim objDBMis As New DBMis
        Dim username As String = txtLoginID.Text
        Dim password As String = objDBMis.GenerateHash(txtPassword.Text).Trim
        Dim convertSec As Integer = CInt(DateTime.Now.Hour) * 3600 + CInt(DateTime.Now.Minute) * 60
        Dim convertMins As Integer = (convertSec - CInt(ViewState("lockout_time"))) / 60

        If checkEmpty() = False Then

            If ImageVerifier1.Text = txtImgVerifyCode.Text Then

                If ViewState("attempts").Equals(ViewState("maxAttempts")) Then

                    lblStatus.Text = "Status: " + ViewState("maxAttempts").ToString + " times login attempts you are lockout for " & CStr(ViewState("timeout_Mins") - convertMins) & " minutes."
                    clearText()
                Else
                    record = objDBUser.ValidateUser(username, password)

                    ViewState("attempts") = CInt(ViewState("attempts")) + 1

                    If ViewState("attempts").Equals(ViewState("maxAttempts")) Then
                        ViewState("lockout_time") = convertSec
                    End If

                    If record = 1 Then
                        Dim user As Object = objDBUser.Get_Login_User(username, password)
                        Dim objUser As New User

                        objUser = user

                        Session.Add("user", user)

                        ViewState("attempts") = 0

                        If objUser.Type.Trim.Equals("admin") Then
                            Response.Redirect("~/web_admin/User/Home.aspx")
                        Else
                            Response.Redirect("~/web_user/User/Home.aspx")
                        End If

                    Else
                        lblStatus.Text = "Status: Access denied, " + CStr(ViewState("attempts")) + " attempts."
                        clearText()
                    End If
                End If

            Else
                clearText()
                lblStatus.Text = "Status: Invalid image verify."
            End If
            txtLoginID.Focus()
        Else
            lblStatus.Text = ""
        End If
    End Sub

    Sub clearText()
        txtLoginID.Text = ""
        txtPassword.Text = ""
        txtImgVerifyCode.Text = ""
    End Sub

    Protected Sub ImgLogo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgLogo.Click
        Response.Redirect("Index.aspx")
    End Sub

    Public Function checkEmpty() As Boolean

        Dim b1, b2, b3, result As Boolean

        If txtLoginID.Text.Equals("") Then
            lblErrorName.Text = "*"
            b1 = True
        Else
            lblErrorName.Text = ""
            b1 = False
        End If

        If txtPassword.Text.Equals("") Then
            lblErrorPwd.Text = "*"
            b2 = True
        Else
            lblErrorPwd.Text = ""
            b2 = False
        End If

        If txtImgVerifyCode.Text.Equals("") Then
            lblErrorVerify.Text = "*"
            b3 = True
        Else
            lblErrorVerify.Text = ""
            b3 = False
        End If

        If b1 = True Or b2 = True Or b3 = True Then
            result = True
        Else
            result = False
        End If

        Return result
    End Function

End Class
