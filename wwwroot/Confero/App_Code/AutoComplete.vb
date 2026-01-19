'Imports System.Web
'Imports System.Web.Services
'Imports System.Web.Services.Protocols
'Imports Microsoft.VisualBasic
'Imports System.Data.Sql
'Imports System.Data.SqlClient
'Imports System.Data
'Imports System.Web.HttpResponse

'<WebService(Namespace:="http://tempuri.org/")> _
'<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
'<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
'Public Class AutoComplete
'    Inherits System.Web.Services.WebService

'    Dim conn As New SqlConnection
'    Dim sqlstr As New SqlCommand
'    Dim objCmd As New SqlCommand
'    Dim objCn As New SqlConnection
'    Dim objadapter As New SqlDataAdapter
'    Dim objDS As New DataSet
'    Dim objDataRow As DataRow
'    Dim objReader As SqlDataReader

'    Dim connstr As String = System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionString").ToString

'    Sub New()
'        objCmd.Connection = objCn
'        objCn.ConnectionString = connstr
'    End Sub

'    <WebMethod()> _
'    Public Function GetCompletionList(ByVal prefixText As String, ByVal count As Integer) As String()

'        Dim items As New List(Of String)

'        objCmd = New SqlCommand
'        objCmd.Connection = objCn

'        If (count = 0) Then
'            count = 10
'        End If

'        Try
'            objCn.Open()

'            objCmd.CommandType = CommandType.StoredProcedure
'            objCmd.CommandText = "sp_Search_By_Propellent"

'            With objCmd.Parameters
'                .Add("@search", SqlDbType.VarChar, 100).Value = prefixText
'                .Add("@col", SqlDbType.VarChar, 100).Value = "tblPropellent.Brand"
'            End With

'            objReader = objCmd.ExecuteReader

'            While (objReader.Read())

'                'objPropellent.Brand = objReader("Brand")
'                'objPropellent.Octane = objReader("Octane")
'                'objPropellent.Description = objReader("Description")
'                'objPropellent.PropellentID = objReader("PropellentID")
'                'objPropellent.PropellentTypeID = objReader("PropellentTypeID")

'                items.Add(objReader("Brand"))
'            End While

'        Catch ex As Exception
'            Throw New Exception(ex.Message)
'        Finally
'            objCn.Close()
'        End Try

'        Return items.ToArray()


'    End Function

'End Class
