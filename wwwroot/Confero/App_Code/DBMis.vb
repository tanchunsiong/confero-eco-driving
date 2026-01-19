Imports Microsoft.VisualBasic
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.HttpResponse
Imports System.Web
Imports System.Security.Cryptography
Imports System.Xml
Imports System.IO
Imports System.Xml.Serialization

Public Class DBMis
    Inherits System.Web.UI.Page

    Dim conn As New SqlConnection
    Dim sqlstr As New SqlCommand
    Dim objCmd As New SqlCommand
    Dim objCn As New SqlConnection
    Dim objadapter As New SqlDataAdapter
    Dim objDS As New DataSet
    Dim objDataRow As DataRow
    Dim objReader As SqlDataReader

    'Const connstr As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\ConferoServer.mdf;Integrated Security=True;User Instance=True"
    'Dim connstr As String = ConfigurationSettings.AppSettings("ConnectionString")
    Dim connstr As String = System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionString").ToString

    Sub New()
        objCmd.Connection = objCn
        objCn.ConnectionString = connstr
    End Sub

    Public Function Count_Record(ByVal tablename As String) As Integer

        Dim row As Integer

        objCmd = New SqlCommand
        objCmd.Connection = objCn

        Try
            objCn.Open()

            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.CommandText = "sp_Count_Record"

            With objCmd.Parameters
                .Add("@tablename", SqlDbType.VarChar, 50).Value = tablename
            End With

            row = objCmd.ExecuteScalar

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            objCn.Close()
        End Try

        Return row

    End Function

    Public Sub Excel_View(ByVal Query As String, ByVal Report_Title As String)

        Dim dg As New System.Web.UI.WebControls.DataGrid()
        Dim da As New SqlDataAdapter(Query, objCmd.Connection)

        Dim ds As DataSet
        ds = New DataSet()
        'fill datagrid
        da.Fill(ds)
        dg.DataSource = ds
        dg.DataBind()
        'datagrid formatting
        dg.Font.Name = "Verdana"
        dg.BorderStyle = System.Web.UI.WebControls.BorderStyle.Solid
        dg.HeaderStyle.BackColor = System.Drawing.Color.Blue
        dg.HeaderStyle.ForeColor = System.Drawing.Color.White
        dg.HeaderStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Center
        dg.HeaderStyle.Wrap = False
        dg.HeaderStyle.Font.Bold = True

        'export to excel
        context.Response.Buffer = True
        context.Response.ClearContent()
        context.Response.ClearHeaders()
        context.Response.ContentType = "application/vnd.ms-excel"
        EnableViewState = True
        Dim tw As New System.IO.StringWriter()
        Dim hw As New System.Web.UI.HtmlTextWriter(tw)
        dg.RenderControl(hw)
        context.Response.Write(Now)
        context.Response.Write("<b><center><font size=3 face=Verdana color=#0000FF>" & Report_Title & "</font></center></b>")
        Context.Response.Write(tw.ToString())
        Context.Response.Flush()
        context.Response.Close()
        context.Response.End()
        da.Dispose()
        da = Nothing
        ds.Dispose()
        ds = Nothing

        conn.Dispose()
        conn = Nothing
    End Sub

    Public Function Count_User_Record(ByVal tablename As String, ByVal userId As Integer) As Integer

        Dim row As Integer

        objCmd = New SqlCommand
        objCmd.Connection = objCn

        Try
            objCn.Open()

            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.CommandText = "sp_Count_User_Record"

            With objCmd.Parameters
                .Add("@tablename", SqlDbType.VarChar, 50).Value = tablename
                .Add("@userId", SqlDbType.Int).Value = userId
            End With

            row = objCmd.ExecuteScalar

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            objCn.Close()
        End Try

        Return row

    End Function

    Function GenerateHash(ByVal SourceText As String) As String
        'Create an encoding object to ensure the encoding standard for the source text
        Dim Ue As New UnicodeEncoding()
        'Retrieve a byte array based on the source text
        Dim ByteSourceText() As Byte = Ue.GetBytes(SourceText)
        'Instantiate an MD5 Provider object
        Dim Md5 As New MD5CryptoServiceProvider()
        'Compute the hash value from the source
        Dim ByteHash() As Byte = Md5.ComputeHash(ByteSourceText)
        'And convert it to String format for return
        Return Convert.ToBase64String(ByteHash)
    End Function

    Public Function Get_Setting() As Setting

        Dim objSetting As New Setting

        objCmd = New SqlCommand
        objCmd.Connection = objCn

        Try
            objCn.Open()

            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.CommandText = "sp_Get_Setting"

            With objCmd.Parameters
                .Add("@settingId", Data.SqlDbType.Int).Value = 1
            End With

            objReader = objCmd.ExecuteReader

            While (objReader.Read())
                objSetting.SettingId = objReader("SettingId")
                objSetting.Timeout = objReader("Timeout")
                objSetting.Attempts = objReader("Attempts")
            End While

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            objCn.Close()
        End Try

        Return objSetting

    End Function

    Public Function Update_Setting(ByVal objData As Setting) As Integer

        Dim rowAffected As Integer

        objCmd = New SqlCommand
        objCmd.Connection = objCn

        Try
            objCn.Open()

            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.CommandText = "sp_Update_Setting"

            With objCmd.Parameters
                .Add("@settingId", SqlDbType.Int).Value = 1
                .Add("@timeout", SqlDbType.Int).Value = objData.Timeout
                .Add("@attempts", SqlDbType.Int).Value = objData.Attempts
            End With

            rowAffected = objCmd.ExecuteNonQuery()

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            objCn.Close()
        End Try

        Return rowAffected

    End Function

    Public Function SaveTextToXMLFile(ByVal strData As String, ByVal FullPath As String, Optional ByVal ErrInfo As String = "") As Boolean

        Dim bAns As Boolean = False
        Dim objReader As StreamWriter

        Try
            objReader = New StreamWriter(FullPath)
            objReader.Write(strData)
            objReader.Close()
            bAns = True
        Catch Ex As Exception
            ErrInfo = Ex.Message
        End Try

        Return bAns
    End Function

    Public Sub updatePhotoXML(ByVal path As String)

        Dim objImage As ImageDesc
        Dim objArrayList As New ArrayList
        Dim subStr As String
        Dim no As String = Str(New Random().Next(20000))

        Dim objXMLTW As New XmlTextWriter(path, System.Text.Encoding.UTF8)

        objXMLTW.Formatting = Formatting.Indented
        objArrayList = Get_Gallery_Image()

        objXMLTW.WriteStartDocument()
        objXMLTW.WriteStartElement("photos")
        objXMLTW.WriteAttributeString("path", "Photos/")

        For Each objImage In objArrayList
            objXMLTW.WriteStartElement("object")
            subStr = objImage.Url.Substring(0, objImage.Url.IndexOf("."))
            objXMLTW.WriteAttributeString("name", subStr)
            objXMLTW.WriteAttributeString("url", objImage.Url.Trim)
            objXMLTW.WriteEndElement()
        Next

        objXMLTW.WriteEndElement()
        objXMLTW.WriteEndDocument()
        objXMLTW.Close()
    End Sub

    Public Function Get_Gallery_Image() As ArrayList

        Dim count As Integer = 1
        Dim objArraylist As New ArrayList

        objadapter = New SqlDataAdapter
        objDS = New DataSet

        objCmd = New SqlCommand
        objCmd.Connection = objCn

        Try
            objCn.Open()

            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.CommandText = "sp_get_gallery_image"

            objadapter.SelectCommand = objCmd

            objadapter.Fill(objDS, "Image")

            For Each Me.objDataRow In objDS.Tables("Image").Rows

                Dim objImage As New ImageDesc

                objImage.Status = objDataRow.Item("Status")
                objImage.Url = objDataRow.Item("Url")
                objImage.GalleryId = objDataRow.Item("galleryId")
                objImage.Counter = count

                objArraylist.Add(objImage)
                count += 1
            Next

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            objCn.Close()
        End Try

        Return objArraylist

    End Function

    Public Function Add_Gallery_Image(ByVal filename As String) As Integer

        Dim rowAffected As Integer = 0

        objCmd = New SqlCommand
        objCmd.Connection = objCn

        Try
            objCn.Open()

            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.CommandText = "sp_add_image"

            With objCmd.Parameters
                .Add("@url", SqlDbType.NChar, 70).Value = filename
            End With

            rowAffected = objCmd.ExecuteNonQuery()

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally

            objCn.Close()
        End Try

        Return rowAffected
    End Function

    Public Function Delete_Gallery_Image(ByVal galleryId As Integer) As Integer

        Dim rowAffected As Integer = 0

        objCmd = New SqlCommand
        objCmd.Connection = objCn

        Try
            objCn.Open()

            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.CommandText = "sp_delete_image"

            With objCmd.Parameters
                .Add("@galleryId", SqlDbType.Int).Value = galleryId
            End With

            rowAffected = objCmd.ExecuteNonQuery()

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally

            objCn.Close()
        End Try

        Return rowAffected
    End Function

    Public Function Transaction_Propellent(ByVal objProllent As Propellent) As Integer

        Dim objDBUser As New DBUser
        Dim PropollentId As Integer

        objCmd = New SqlCommand
        objCmd.Connection = objCn

        Try
            objCn.Open()

            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.CommandText = "sp_Transaction_Propellent"

            With objCmd.Parameters

                .Add("@pPropellentTypeID", SqlDbType.Int).Value = objProllent.PropellentID
                .Add("@pOctane", SqlDbType.VarChar, 50).Value = objProllent.Octane
                .Add("@pBrand", SqlDbType.VarChar, 50).Value = objProllent.Brand

            End With

            PropollentId = objCmd.ExecuteScalar()

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            objCn.Close()
        End Try

        Return PropollentId
    End Function

    Public Function Transaction_VehicleOwnerShip(ByVal objVehicleOwnerShip As VehicleOwnership) As Integer

        Dim objDBUser As New DBUser
        Dim VehicleOwnerShipId As Integer

        objCmd = New SqlCommand
        objCmd.Connection = objCn

        Try
            objCn.Open()

            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.CommandText = "sp_Transaction_VehicleOwnerShip"

            With objCmd.Parameters
                .Add("@UserID", SqlDbType.Int).Value = objVehicleOwnerShip.UserID
                .Add("@VehicleID", SqlDbType.Int).Value = objVehicleOwnerShip.VehicleID
            End With

            VehicleOwnerShipId = objCmd.ExecuteScalar()

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            objCn.Close()
        End Try

        Return VehicleOwnerShipId
    End Function

    Public Function Transaction_Vehicle(ByVal objVehicle As Vehicle) As Integer

        Dim objDBUser As New DBUser
        Dim VehicleId As Integer

        objCmd = New SqlCommand
        objCmd.Connection = objCn

        Try
            objCn.Open()

            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.CommandText = "sp_Transaction_Vehicle"

            With objCmd.Parameters


                .Add("@vVehicleTypeID", SqlDbType.Int).Value = objVehicle.VehicleTypeID
                .Add("@vModel", SqlDbType.VarChar, 50).Value = objVehicle.Model
                .Add("@vMake", SqlDbType.VarChar, 50).Value = objVehicle.Make
                .Add("@vYears", SqlDbType.VarChar, 50).Value = objVehicle.Years
                .Add("@vCapacity", SqlDbType.VarChar, 50).Value = objVehicle.Capacity

            End With

            VehicleId = objCmd.ExecuteScalar()

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            objCn.Close()
        End Try

        Return VehicleId
    End Function

    Public Function Transaction_Tyre(ByVal objTyre As Tyre) As Integer

        Dim objDBUser As New DBUser
        Dim TyreId As Integer

        objCmd = New SqlCommand
        objCmd.Connection = objCn

        Try
            objCn.Open()

            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.CommandText = "sp_Transaction_Tyre"

            With objCmd.Parameters

                .Add("@tBrand", SqlDbType.VarChar, 50).Value = objTyre.Brand
                .Add("@tWidth", SqlDbType.VarChar, 50).Value = objTyre.Width
                .Add("@tTyreSize", SqlDbType.VarChar, 50).Value = objTyre.TyreSize
                .Add("@tMaterial", SqlDbType.VarChar, 50).Value = objTyre.Material
                .Add("@tRollingresistance", SqlDbType.VarChar, 50).Value = objTyre.RollingResistance
                .Add("@tModel", SqlDbType.VarChar, 50).Value = objTyre.Model
                .Add("@tType", SqlDbType.VarChar, 50).Value = objTyre.Type
            End With

            TyreId = objCmd.ExecuteScalar()

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            objCn.Close()
        End Try

        Return TyreId
    End Function

    Public Function Transaction_VehicleConfiguration(ByVal objVehicleConfiguration As VehicleConfiguration) As Integer

        Dim objDBUser As New DBUser
        Dim VehicleConfigurationId As Integer

        objCmd = New SqlCommand
        objCmd.Connection = objCn

        Try
            objCn.Open()

            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.CommandText = "sp_Transaction_VehicleConfiguration"

            With objCmd.Parameters
                .Add("@TyreID", SqlDbType.Int).Value = objVehicleConfiguration.TyreID
                .Add("@VehicleID", SqlDbType.Int).Value = objVehicleConfiguration.VehicleID
                .Add("@PropellentID", SqlDbType.Int).Value = objVehicleConfiguration.PropellentID

            End With

            VehicleConfigurationId = objCmd.ExecuteScalar()

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            objCn.Close()
        End Try

        Return VehicleConfigurationId
    End Function

    Public Function Transaction_Trip(ByVal objTrip As Trip) As Integer

        Dim objDBUser As New DBUser
        Dim TripId As Integer

        objCmd = New SqlCommand
        objCmd.Connection = objCn

        Try
            objCn.Open()

            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.CommandText = "sp_Transaction_Trip"

            With objCmd.Parameters
                .Add("@rVehicleConfigurationID", SqlDbType.Int).Value = objTrip.VehicleConfigurationID
                .Add("@trOptimumSpeed", SqlDbType.Int).Value = objTrip.OptimumSpeed
                .Add("@trWeightOfVehicle", SqlDbType.Int).Value = objTrip.WeightOfVehicle
                .Add("@trLocation", SqlDbType.VarChar, 50).Value = objTrip.Location
                .Add("@trWeatherCondition", SqlDbType.VarChar, 50).Value = objTrip.WeatherCondition
                .Add("@trDistanceTravelled", SqlDbType.Int).Value = objTrip.DistanceTravelled
                .Add("@trStartTime", SqlDbType.DateTime).Value = objTrip.StartTime
                .Add("@trEndTime", SqlDbType.DateTime).Value = objTrip.EndTime
                .Add("@trFuelusage", SqlDbType.Int).Value = objTrip.FuelUsage
                .Add("@trMaxGForce", SqlDbType.Decimal, 18).Value = objTrip.MaxGForce
                .Add("@trHorsepower", SqlDbType.Decimal, 18).Value = objTrip.Horsepower
            End With

            TripId = objCmd.ExecuteScalar()

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            objCn.Close()
        End Try

        Return TripId
    End Function

End Class
