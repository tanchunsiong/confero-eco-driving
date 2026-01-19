Imports Microsoft.VisualBasic
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.HttpResponse

Public Class DBTyre

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

    Public Function Get_User_Tyre(ByVal userId As Integer) As ArrayList

        Dim arraylist As New ArrayList
        Dim counter As Integer = 1

        objCmd = New SqlCommand
        objCmd.Connection = objCn

        Try
            objCn.Open()

            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.CommandText = "sp_get_user_tyre"

            With objCmd.Parameters
                .Add("@userId", SqlDbType.Int).Value = userId
            End With

            objReader = objCmd.ExecuteReader

            While (objReader.Read())
                Dim objTyre As New Tyre

                objTyre.Brand = objReader("Brand")
                objTyre.Material = objReader("Material")
                objTyre.RollingResistance = objReader("RollingResistance")
                objTyre.TyreSize = objReader("TyreSize")
                objTyre.TyreID = objReader("TyreID")
                objTyre.Width = objReader("Width")
                objTyre.Model = objReader("Model")
                objTyre.Type = objReader("Type")
                objTyre.CarModel = objReader("Car_Model")
                objTyre.CarMake = objReader("make")

                objTyre.Counter = counter

                arraylist.Add(objTyre)
                counter += 1
            End While


        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            objCn.Close()
        End Try

        Return arraylist

    End Function

    Public Function Search_User_Tyre(ByVal col As String, ByVal search As String, ByVal userId As Integer) As ArrayList

        Dim arraylist As New ArrayList
        Dim counter As Integer = 1

        objCmd = New SqlCommand
        objCmd.Connection = objCn

        Try
            objCn.Open()

            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.CommandText = "sp_Search_User_Tyre"

            With objCmd.Parameters
                .Add("@search", SqlDbType.VarChar, 100).Value = search
                .Add("@col", SqlDbType.VarChar, 100).Value = col
                .Add("@userId", SqlDbType.Int).Value = userId
            End With
            objReader = objCmd.ExecuteReader

            While (objReader.Read())
                Dim objTyre As New Tyre

                objTyre.Brand = objReader("Brand")
                objTyre.Material = objReader("Material")
                objTyre.RollingResistance = objReader("RollingResistance")
                objTyre.TyreSize = objReader("TyreSize")
                objTyre.TyreID = objReader("TyreID")
                objTyre.Width = objReader("Width")
                objTyre.Model = objReader("Model")
                objTyre.Type = objReader("Type")
                objTyre.CarModel = objReader("Car_Model")
                objTyre.CarMake = objReader("make")
                objTyre.Counter = counter

                arraylist.Add(objTyre)
                counter += 1
            End While

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            objCn.Close()
        End Try

        Return arraylist

    End Function

    'admin code --------------------------------------------------------------------
    Public Function Get_Single_Tyre(ByVal id As Integer) As Tyre

        Dim objTyre As New Tyre

        objCmd = New SqlCommand
        objCmd.Connection = objCn

        Try
            objCn.Open()

            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.CommandText = "sp_Get_Single_Tyre"

            With objCmd.Parameters
                .Add("@tyreID", SqlDbType.Int).Value = id
            End With

            objReader = objCmd.ExecuteReader

            While (objReader.Read())
                objTyre.Brand = objReader("Brand")
                objTyre.Material = objReader("Material")
                objTyre.RollingResistance = objReader("RollingResistance")
                objTyre.TyreSize = objReader("TyreSize")
                objTyre.TyreID = objReader("TyreID")
                objTyre.Width = objReader("Width")
                objTyre.Model = objReader("Model")
                objTyre.Type = objReader("Type")
            End While

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            objCn.Close()
        End Try

        Return objTyre

    End Function

    Public Function Get_All_Tyre() As ArrayList

        Dim arraylist As New ArrayList
        Dim counter As Integer = 1

        objCmd = New SqlCommand
        objCmd.Connection = objCn

        Try
            objCn.Open()

            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.CommandText = "sp_Get_All_Tyre"

            objReader = objCmd.ExecuteReader

            While (objReader.Read())
                Dim objTyre As New Tyre

                objTyre.Brand = objReader("Brand")
                objTyre.Material = objReader("Material")
                objTyre.RollingResistance = objReader("RollingResistance")
                objTyre.TyreSize = objReader("TyreSize")
                objTyre.TyreID = objReader("TyreID")
                objTyre.Width = objReader("Width")
                objTyre.Model = objReader("Model")
                objTyre.Type = objReader("Type")
                objTyre.counter = counter

                arraylist.Add(objTyre)
                counter += 1
            End While


        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            objCn.Close()
        End Try

        Return arraylist

    End Function

    Public Function Search_By_Tyre(ByVal col As String, ByVal search As String) As ArrayList

        Dim arraylist As New ArrayList
        Dim counter As Integer = 1

        objCmd = New SqlCommand
        objCmd.Connection = objCn

        Try
            objCn.Open()

            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.CommandText = "sp_Search_By_Tyre"

            With objCmd.Parameters
                .Add("@search", SqlDbType.VarChar, 100).Value = search
                .Add("@col", SqlDbType.VarChar, 100).Value = col
            End With
            objReader = objCmd.ExecuteReader

            While (objReader.Read())
                Dim objTyre As New Tyre

                objTyre.Brand = objReader("Brand")
                objTyre.Material = objReader("Material")
                objTyre.RollingResistance = objReader("RollingResistance")
                objTyre.TyreSize = objReader("TyreSize")
                objTyre.TyreID = objReader("TyreID")
                objTyre.Width = objReader("Width")
                objTyre.Model = objReader("Model")
                objTyre.Type = objReader("Type")
                objTyre.Counter = counter

                arraylist.Add(objTyre)
                counter += 1
            End While

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            objCn.Close()
        End Try

        Return arraylist

    End Function

    Public Function Delete_By_Tyre(ByVal id As Integer) As Integer

        Dim rowAffected As Integer

        objCmd = New SqlCommand
        objCmd.Connection = objCn

        Try
            objCn.Open()

            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.CommandText = "sp_Delete_By_Tyre"

            With objCmd.Parameters
                .Add("@TyreId", SqlDbType.Int).Value = id
            End With

            rowAffected = objCmd.ExecuteNonQuery()

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            objCn.Close()
        End Try

        Return rowAffected

    End Function

    Public Function Add_Tyre(ByVal objData As Tyre) As Integer

        Dim rowAffected As Integer

        objCmd = New SqlCommand
        objCmd.Connection = objCn

        Try
            objCn.Open()

            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.CommandText = "sp_Add_Tyre"

            With objCmd.Parameters
                .Add("@brand", SqlDbType.VarChar, 50).Value = objData.Brand
                .Add("@width", SqlDbType.VarChar, 50).Value = objData.Width
                .Add("@tyreSize", SqlDbType.VarChar, 50).Value = objData.TyreSize
                .Add("@material", SqlDbType.VarChar, 50).Value = objData.Material
                .Add("@rollingresistance", SqlDbType.VarChar, 50).Value = objData.RollingResistance
                .Add("@model", SqlDbType.VarChar, 50).Value = objData.Model
                .Add("@type", SqlDbType.VarChar, 15).Value = objData.Type
                '.Add("@pressure", SqlDbType.VarChar, 50).Value = objData.Pressure
            End With

            rowAffected = objCmd.ExecuteNonQuery()

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            objCn.Close()
        End Try

        Return rowAffected

    End Function

    Public Function Update_Tyre(ByVal objData As Tyre) As Integer

        Dim rowAffected As Integer

        objCmd = New SqlCommand
        objCmd.Connection = objCn

        Try
            objCn.Open()

            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.CommandText = "sp_Update_Tyre"

            With objCmd.Parameters
                .Add("@tyreID", SqlDbType.Int).Value = objData.TyreID
                .Add("@brand", SqlDbType.VarChar, 50).Value = objData.Brand
                .Add("@width", SqlDbType.VarChar, 50).Value = objData.Width
                .Add("@tyreSize", SqlDbType.VarChar, 50).Value = objData.TyreSize
                .Add("@material", SqlDbType.VarChar, 50).Value = objData.Material
                .Add("@rollingresistance", SqlDbType.VarChar, 50).Value = objData.RollingResistance
                .Add("@model", SqlDbType.VarChar, 50).Value = objData.Model
                .Add("@type", SqlDbType.VarChar, 15).Value = objData.Type
                '.Add("@pressure", SqlDbType.VarChar, 50).Value = objData.Pressure
            End With

            rowAffected = objCmd.ExecuteNonQuery()

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            objCn.Close()
        End Try

        Return rowAffected

    End Function

End Class
