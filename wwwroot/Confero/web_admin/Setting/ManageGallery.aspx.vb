Imports System.IO

Partial Class web_admin_Setting_ManageGallery
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim objUser As New User
        Dim objDBSetting As New DBMis

        If Page.IsPostBack = False Then

            If Session.Item("user") Is Nothing Then
                Response.Redirect("..\..\Login.aspx")
            Else
                objUser = CType(Session.Item("user"), User)

                bindData()
            End If
        End If

    End Sub

    Sub bindData()
        Dim objArrayList As New ArrayList
        Dim objDBMis As New DBMis

        objArrayList = objDBMis.Get_Gallery_Image

        grdData.DataSource = objArrayList

        ' if statment to handle the datagrid paging
        If (objArrayList.Count >= ((grdData.PageSize * grdData.CurrentPageIndex) + 1)) Then

        Else
            grdData.CurrentPageIndex = 0
        End If
        ViewState("counter") = grdData.CurrentPageIndex * lstNoRec.SelectedValue
        lblTotal.Text = "Total image: " + CStr(objArrayList.Count)
        grdData.DataBind()
    End Sub

    Sub myDataGrid_PageChanger(ByVal Source As Object, ByVal e As DataGridPageChangedEventArgs)
        ' Set the CurrentPageIndex before binding the grid 
        grdData.CurrentPageIndex = e.NewPageIndex
        bindData()
        lblStatus.Text = "Status: No file loaded"
        lblStatus.ForeColor = Drawing.Color.Black
    End Sub

    Sub changeRec(ByVal sender As Object, ByVal e As EventArgs) Handles lstNoRec.SelectedIndexChanged
        ' set the page size depend on the number of record select
        grdData.PageSize = CInt(lstNoRec.SelectedItem.Value)
        bindData()
    End Sub

    Protected Sub grdData_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles grdData.ItemDataBound

        Dim objArrayList As New ArrayList
        Dim objImage As New ImageDesc
        Dim objDBMis As New DBMis
        Dim iNow As Integer = 0

        ' create drop down list in the datagrid
        If e.Item.ItemType <> ListItemType.Header And e.Item.ItemType <> ListItemType.Footer Then

            objArrayList = objDBMis.Get_Gallery_Image

            iNow = ViewState("counter")

            objImage = objArrayList(iNow)

            ViewState("counter") = CInt(iNow + 1)
            Dim photo As Image = e.Item.FindControl("photo")

            photo.ImageUrl = "~/Photos/" + objImage.Url
        End If

    End Sub

    Protected Sub grdData_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdData.ItemCommand

        Dim objDBMis As New DBMis
        Dim reply As String

        If (e.CommandName.Equals("delete")) Then

            If IsNumeric(e.Item.Cells(0).Text) Then

                reply = MsgBox("Delete image?", MsgBoxStyle.YesNo, "Delete Record")

                If reply = vbYes Then
                    Try
                        objDBMis.Delete_Gallery_Image(e.Item.Cells(0).Text)

                        bindData()

                        File.Delete(System.Web.HttpContext.Current.Request.MapPath("../../photos/") + e.Item.Cells(1).Text)
                        objDBMis.updatePhotoXML(System.Web.HttpContext.Current.Request.MapPath("../../photos.xml"))

                        lblStatus.Text = "Status: Image deleted"
                        lblStatus.ForeColor = Drawing.Color.Green
                    Catch ex As Exception

                    End Try
                End If
            End If
        End If
    End Sub

    Protected Sub btnFile_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFile.Click

        Try
            Dim fileName As String = System.IO.Path.GetFileName(browseFile.PostedFile.FileName)
            Dim fileExtension As String = System.IO.Path.GetExtension(browseFile.PostedFile.FileName)
            Dim row As Integer
            Dim objDBMis As New DBMis

            If fileExtension.ToLower.Equals(".gif") Or fileExtension.ToLower.Equals(".jpg") Or fileExtension.ToLower.Equals(".png") Or fileExtension.ToLower.Equals(".bmp") Then

                row = objDBMis.Add_Gallery_Image(fileName)

                If row = 1 Then
                    browseFile.PostedFile.SaveAs(System.Web.HttpContext.Current.Request.MapPath("../../photos/") + fileName)
                    lblStatus.Text = "Status: Image uploaded"
                    lblStatus.ForeColor = Drawing.Color.Green

                    objDBMis.updatePhotoXML(System.Web.HttpContext.Current.Request.MapPath("../../photos.xml"))

                    bindData()
                Else
                    lblStatus.Text = "Status: Error in adding record"
                    lblStatus.ForeColor = Drawing.Color.Red
                End If

            Else
                lblStatus.Text = "Status: Only Gif, Png, Bmp, Jpg image is accepted"
                lblStatus.ForeColor = Drawing.Color.Red
            End If
        Catch ex As Exception
            lblStatus.Text = "Status: Error in uploading image"
            lblStatus.ForeColor = Drawing.Color.Red
        End Try
    End Sub
End Class
