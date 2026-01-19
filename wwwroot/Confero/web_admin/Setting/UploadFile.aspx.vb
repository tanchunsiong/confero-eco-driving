Imports System.IO

Partial Class web_admin_Setting_UploadFile
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim objUser As New User

        If Page.IsPostBack = False Then

            If Session.Item("user") Is Nothing Then
                Response.Redirect("..\..\Login.aspx")
            Else
                objUser = CType(Session.Item("user"), User)

                Dim UpPath As String
                Dim UpName As String

                UpPath = System.Web.HttpContext.Current.Request.MapPath("../../")
                UpName = Dir(UpPath, vbDirectory)

                If UpName = "" Then
                    MkDir(UpPath)
                End If
            End If
        End If
       
    End Sub

    Protected Sub btnFile_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFile.Click

        Try
            'Dim fileName As String = System.IO.Path.GetFileName(browseFile.PostedFile.FileName)
            Dim fileExtension As String = System.IO.Path.GetExtension(browseFile.PostedFile.FileName)

            If fileExtension.ToLower.Equals(".pdf") Then

                File.Delete(System.Web.HttpContext.Current.Request.MapPath("../../") + radFile.SelectedValue)

                browseFile.PostedFile.SaveAs(System.Web.HttpContext.Current.Request.MapPath("../../") + radFile.SelectedValue)
                lblStatus.Text = "Status: File uploaded"
                lblStatus.ForeColor = Drawing.Color.Green
            Else
                lblStatus.Text = "Status: Only PDF file is accepted"
                lblStatus.ForeColor = Drawing.Color.Red
            End If
        Catch ex As Exception
            lblStatus.Text = "Status: Error in uploading file"
            lblStatus.ForeColor = Drawing.Color.Red
        End Try

    End Sub

    Protected Sub btnVideo_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVideo.Click
        Try
            'Dim fileName As String = System.IO.Path.GetFileName(browseVideo.PostedFile.FileName)
            Dim fileExtension As String = System.IO.Path.GetExtension(browseVideo.PostedFile.FileName)

            If fileExtension.ToLower.Equals(".flv") Then

                File.Delete(System.Web.HttpContext.Current.Request.MapPath("../../flash/") + radVideo.SelectedValue)

                browseVideo.PostedFile.SaveAs(System.Web.HttpContext.Current.Request.MapPath("../../flash/") + radVideo.SelectedValue)
                lblStatus.Text = "Status: Video uploaded"
                lblStatus.ForeColor = Drawing.Color.Green
            Else
                lblStatus.Text = "Status: Only Flv video is accepted"
                lblStatus.ForeColor = Drawing.Color.Red
            End If

        Catch ex As Exception
            lblStatus.Text = "Status: Error in uploading video"
            lblStatus.ForeColor = Drawing.Color.Red
        End Try
    End Sub
End Class
