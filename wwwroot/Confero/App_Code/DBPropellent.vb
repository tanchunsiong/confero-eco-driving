Imports Microsoft.VisualBasic
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.HttpResponse

Public Class DBPropellent

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

    Public Function Get_User_Propellent(ByVal userId As Integer) As ArrayList

        Dim arraylist As New ArrayList
        Dim counter As Integer = 1

        objCmd = New SqlCommand
        objCmd.Connection = objCn

        Try
            objCn.Open()

            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.CommandText = "sp_Get_User_Propellent"

            With objCmd.Parameters
                .Add("@UserID", Data.SqlDbType.Int).Value = userId
            End With

            objReader = objCmd.ExecuteReader

            While (objReader.Read())
                Dim objPropellent As New Propellent

                objPropellent.Brand = objReader("Brand")
                objPropellent.Octane = objReader("Octane")
                objPropellent.Description = objReader("Description")
                objPropellent.PropellentID = objReader("PropellentID")
                objPropellent.PropellentTypeID = objReader("PropellentTypeID")
                objPropellent.Counter = counter

                objPropellent.Make = objReader("Make")
                objPropellent.Model = objReader("Model")

                arraylist.Add(objPropellent)

                counter += 1
            End While


        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            objCn.Close()
        End Try

        Return arraylist

    End Function

    Public Function Search_User_Propellent(ByVal col As String, ByVal search As String, ByVal userId As Integer) As ArrayList

        Dim arraylist As New ArrayList
        Dim counter As Integer = 1

        objCmd = New SqlCommand
        objCmd.Connection = objCn

        Try
            objCn.Open()

            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.CommandText = "sp_Get_Search_Propellent"

            With objCmd.Parameters
                .Add("@search", SqlDbType.VarChar, 100).Value = search
                .Add("@col", SqlDbType.VarChar, 100).Value = col
                .Add("@UserID", Data.SqlDbType.Int).Value = userId
            End With

            objReader = objCmd.ExecuteReader

            While (objReader.Read())
                Dim objPropellent As New Propellent

                objPropellent.Brand = objReader("Brand")
                objPropellent.Octane = objReader("Octane")
                objPropellent.Description = objReader("Description")
                objPropellent.PropellentID = objReader("PropellentID")
                objPropellent.PropellentTypeID = objReader("PropellentTypeID")
                objPropellent.Counter = counter

                objPropellent.Make = objReader("Make")
                objPropellent.Model = objReader("Model")

                arraylist.Add(objPropellent)

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
    Public Function Get_Single_Propellent(ByVal id As Integer) As Propellent

        Dim objPropellent As New Propellent

        objCmd = New SqlCommand
        objCmd.Connection = objCn

        Try
            objCn.Open()

            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.CommandText = "sp_Get_Single_Propellent"

            With objCmd.Parameters
                .Add("@PropellentID", SqlDbType.Int).Value = id
            End With

            objReader = objCmd.ExecuteReader

            While (objReader.Read())
                objPropellent.Brand = objReader("Brand")
                objPropellent.Octane = objReader("Octane")
                objPropellent.Description = objReader("Description")
                objPropellent.PropellentID = objReader("PropellentID")
                objPropellent.PropellentTypeID = objReader("PropellentTypeID")
            End While


        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            objCn.Close()
        End Try

        Return objPropellent

    End Function

    Public Function Get_All_Propellent() As ArrayList

        Dim arraylist As New ArrayList
        Dim counter As Integer = 1

        objCmd = New SqlCommand
        objCmd.Connection = objCn

        Try
            objCn.Open()

            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.CommandText = "sp_Get_All_Propellent"

            objReader = objCmd.ExecuteReader

            While (objReader.Read())
                Dim objPropellent As New Propellent

                objPropellent.Brand = objReader("Brand")
                objPropellent.Octane = objReader("Octane")
                objPropellent.Description = objReader("Description")
                objPropellent.PropellentID = objReader("PropellentID")
                objPropellent.PropellentTypeID = objReader("PropellentTypeID")
                objPropellent.Counter = counter

                arraylist.Add(objPropellent)

                counter += 1
            End While


        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            objCn.Close()
        End Try

        Return arraylist

    End Function

    Public Function Search_By_Propellent(ByVal col As String, ByVal search As String) As ArrayList

        Dim arraylist As New ArrayList
        Dim counter As Integer = 1

        objCmd = New SqlCommand
        objCmd.Connection = objCn

        Try
            objCn.Open()

            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.CommandText = "sp_Search_By_Propellent"

            With objCmd.Parameters
                .Add("@search", SqlDbType.VarChar, 100).Value = search
                .Add("@col", SqlDbType.VarChar, 100).Value = col
            End With

            objReader = objCmd.ExecuteReader

            While (objReader.Read())
                Dim objPropellent As New Propellent

                objPropellent.Brand = objReader("Brand")
                objPropellent.Octane = objReader("Octane")
                objPropellent.Description = objReader("Description")
                objPropellent.PropellentID = objReader("PropellentID")
                objPropellent.PropellentTypeID = objReader("PropellentTypeID")
                objPropellent.Counter = counter
                arraylist.Add(objPropellent)

                counter += 1

            End While


        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            objCn.Close()
        End Try

        Return arraylist

    End Function

    Public Function Get_Single_PropellentType(ByVal id As Integer) As Propellent

        Dim objPropellent As New Propellent

        objCmd = New SqlCommand
        objCmd.Connection = objCn

        Try
            objCn.Open()

            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.CommandText = "sp_Get_Single_PropellentType"

            With objCmd.Parameters
                .Add("@PropellentTypeID", SqlDbType.VarChar, 50).Value = id
            End With

            objReader = objCmd.ExecuteReader

            While (objReader.Read())
                objPropellent.Description = objReader("Description")
                objPropellent.PropellentTypeID = objReader("PropellentTypeID")
            End While


        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            objCn.Close()
        End Try

        Return objPropellent

    End Function

    Public Function Get_All_PropellentType() As ArrayList

        Dim arraylist As New ArrayList
        Dim counter As Integer = 1

        objCmd = New SqlCommand
        objCmd.Connection = objCn

        Try
            objCn.Open()

            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.CommandText = "sp_Get_All_PropellentType"

            objReader = objCmd.ExecuteReader

            While (objReader.Read())
                Dim objPropellent As New Propellent

                objPropellent.Description = objReader("Description")
                objPropellent.PropellentTypeID = objReader("PropellentTypeID")
                objPropellent.Counter = counter
                arraylist.Add(objPropellent)

                counter += 1
            End While


        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            objCn.Close()
        End Try

        Return arraylist

    End Function

    Public Function Search_By_PropellentType(ByVal col As String, ByVal search As String) As ArrayList

        Dim arraylist As New ArrayList
        Dim counter As Integer = 1

        objCmd = New SqlCommand
        objCmd.Connection = objCn

        Try
            objCn.Open()

            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.CommandText = "sp_Search_By_PropellentType"


            With objCmd.Parameters
                .Add("@search", SqlDbType.VarChar, 100).Value = search
                .Add("@col", SqlDbType.VarChar, 100).Value = col
            End With
            objReader = objCmd.ExecuteReader

            While (objReader.Read())
                Dim objPropellent As New Propellent

                objPropellent.Description = objReader("Description")
                objPropellent.PropellentTypeID = objReader("PropellentTypeID")
                objPropellent.Counter = counter
                arraylist.Add(objPropellent)

                counter += 1
            End While


        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            objCn.Close()
        End Try

        Return arraylist

    End Function

    Public Function Delete_By_Propellent(ByVal id As Integer) As Integer

        Dim rowAffected As Integer

        objCmd = New SqlCommand
        objCmd.Connection = objCn

        Try
            objCn.Open()

            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.CommandText = "sp_Delete_By_Propellent"

            With objCmd.Parameters
                .Add("@PropellentId", SqlDbType.Int).Value = id
            End With

            rowAffected = objCmd.ExecuteNonQuery()

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            objCn.Close()
        End Try

        Return rowAffected

    End Function

    Public Function Delete_By_PropellentType(ByVal id As Integer) As Integer

        Dim rowAffected As Integer

        objCmd = New SqlCommand
        objCmd.Connection = objCn

        Try
            objCn.Open()

            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.CommandText = "sp_Delete_By_PropellentType"

            With objCmd.Parameters
                .Add("@PropellentTypeId", SqlDbType.Int).Value = id
            End With

            rowAffected = objCmd.ExecuteNonQuery()

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            objCn.Close()
        End Try

        Return rowAffected

    End Function

    Public Function Add_Propellent(ByVal objData As Propellent) As Integer

        Dim rowAffected As Integer

        objCmd = New SqlCommand
        objCmd.Connection = objCn

        Try
            objCn.Open()

            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.CommandText = "sp_Add_Propellent"

            With objCmd.Parameters
                .Add("@propellentTypeID", SqlDbType.Int).Value = objData.PropellentTypeID
                .Add("@octane", SqlDbType.VarChar, 50).Value = objData.Octane
                .Add("@brand", SqlDbType.VarChar, 50).Value = objData.Brand
            End With

            rowAffected = objCmd.ExecuteNonQuery()

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            objCn.Close()
        End Try

        Return rowAffected

    End Function

    Public Function Add_PropellentType(ByVal description As String) As Integer

        Dim rowAffected As Integer

        objCmd = New SqlCommand
        objCmd.Connection = objCn

        Try
            objCn.Open()

            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.CommandText = "sp_Add_PropellentType"

            With objCmd.Parameters
                .Add("@Description", SqlDbType.NChar, 10).Value = description
            End With

            rowAffected = objCmd.ExecuteNonQuery()

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            objCn.Close()
        End Try

        Return rowAffected

    End Function

    Public Function Update_Propellent(ByVal objData As Propellent) As Integer

        Dim rowAffected As Integer

        objCmd = New SqlCommand
        objCmd.Connection = objCn

        Try
            objCn.Open()

            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.CommandText = "sp_Update_Propellent"

            With objCmd.Parameters
                .Add("@propellentID", SqlDbType.Int).Value = objData.PropellentID
                .Add("@propellentTypeID", SqlDbType.Int).Value = objData.PropellentTypeID
                .Add("@octane", SqlDbType.VarChar, 50).Value = objData.Octane
                .Add("@brand", SqlDbType.VarChar, 50).Value = objData.Brand
            End With

            rowAffected = objCmd.ExecuteNonQuery()

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            objCn.Close()
        End Try

        Return rowAffected

    End Function

    Public Function Update_PropellentType(ByVal objData As Propellent) As Integer

        Dim rowAffected As Integer

        objCmd = New SqlCommand
        objCmd.Connection = objCn

        Try
            objCn.Open()

            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.CommandText = "sp_Update_PropellentType"

            With objCmd.Parameters
                .Add("@propellentTypeID", SqlDbType.Int).Value = objData.PropellentTypeID
                .Add("@description", SqlDbType.NChar, 10).Value = objData.Description
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
