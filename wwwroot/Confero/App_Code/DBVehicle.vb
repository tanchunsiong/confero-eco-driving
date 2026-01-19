Imports Microsoft.VisualBasic
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.HttpResponse

Public Class DBVehicle
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

    Public Function Get_User_Vehicle(ByVal userId As Integer) As ArrayList

        Dim arraylist As New ArrayList
        Dim counter As Integer = 1

        objCmd = New SqlCommand
        objCmd.Connection = objCn

        Try
            objCn.Open()

            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.CommandText = "sp_Get_User_Vehicle"

            With objCmd.Parameters
                .Add("@UserID", Data.SqlDbType.Int).Value = userId
            End With

            objReader = objCmd.ExecuteReader

            While (objReader.Read())
                Dim objVehicle As New Vehicle

                objVehicle.Capacity = objReader("Capacity")
                objVehicle.Make = objReader("Make")
                objVehicle.Model = objReader("Model")
                objVehicle.VehicleID = objReader("VehicleID")
                objVehicle.VehicleTypeID = objReader("VehicleTypeID")
                objVehicle.Years = objReader("Years")
                objVehicle.Description = objReader("Description")
                'objVehicle.VehicleConfigureID = objReader("vehicleConfigurationID")
                'objVehicle.UserName = objReader("LoginID")
                objVehicle.Counter = counter

                arraylist.Add(objVehicle)

                counter += 1
            End While

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            objCn.Close()
        End Try

        Return arraylist

    End Function

    Public Function Search_User_Vehicle(ByVal col As String, ByVal search As String, ByVal userId As Integer) As ArrayList

        Dim arraylist As New ArrayList
        Dim counter As Integer = 1

        objCmd = New SqlCommand
        objCmd.Connection = objCn

        Try
            objCn.Open()

            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.CommandText = "sp_Search_User_Vehicle"

            With objCmd.Parameters
                .Add("@search", SqlDbType.VarChar, 100).Value = search
                .Add("@col", SqlDbType.VarChar, 100).Value = col
                .Add("@UserID", Data.SqlDbType.Int).Value = userId
            End With
            objReader = objCmd.ExecuteReader

            While (objReader.Read())
                Dim objVehicle As New Vehicle

                objVehicle.Capacity = objReader("Capacity")
                objVehicle.Make = objReader("Make")
                objVehicle.Model = objReader("Model")
                objVehicle.VehicleID = objReader("VehicleID")
                objVehicle.VehicleTypeID = objReader("VehicleTypeID")
                objVehicle.Years = objReader("Years")
                objVehicle.Description = objReader("Description")
                'objVehicle.UserName = objReader("LoginID")
                objVehicle.Counter = counter

                arraylist.Add(objVehicle)

                counter += 1
            End While

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            objCn.Close()
        End Try

        Return arraylist

    End Function

    Public Function Get_User_VehicleOwnership(ByVal userId As Integer) As ArrayList

        Dim arraylist As New ArrayList
        Dim counter As Integer = 1

        objCmd = New SqlCommand
        objCmd.Connection = objCn

        Try
            objCn.Open()

            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.CommandText = "sp_Get_User_VehicleOwnership"

            With objCmd.Parameters
                .Add("@UserID", Data.SqlDbType.Int).Value = userId
            End With

            objReader = objCmd.ExecuteReader

            While (objReader.Read())

                Dim objVehicleOwnership As New VehicleOwnership

                objVehicleOwnership.OwnershipID = objReader("OwnershipID")
                objVehicleOwnership.UserID = objReader("UserID")
                objVehicleOwnership.VehicleID = objReader("VehicleID")
                objVehicleOwnership.UserName = objReader("LoginID")
                objVehicleOwnership.Counter = counter

                arraylist.Add(objVehicleOwnership)
                counter += 1
            End While

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            objCn.Close()
        End Try

        Return arraylist

    End Function

    ' admin code ---------------------------------------------------------------
    Public Function Get_Single_Vehicle(ByVal id As Integer) As Vehicle

        Dim objVehicle As New Vehicle

        objCmd = New SqlCommand
        objCmd.Connection = objCn

        Try
            objCn.Open()

            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.CommandText = "sp_Get_Single_Vehicle"

            With objCmd.Parameters
                .Add("@VehicleId", Data.SqlDbType.Int).Value = id
            End With

            objReader = objCmd.ExecuteReader

            While (objReader.Read())

                objVehicle.Capacity = objReader("Capacity")
                objVehicle.Make = objReader("Make")
                objVehicle.Model = objReader("Model")
                objVehicle.VehicleID = objReader("VehicleID")
                objVehicle.VehicleTypeID = objReader("VehicleTypeID")
                objVehicle.Years = objReader("Years")
                objVehicle.Description = objReader("Description")
                objVehicle.UserName = objReader("LoginID")
            End While

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            objCn.Close()
        End Try

        Return objVehicle

    End Function

    Public Function Get_All_Vehicle() As ArrayList

        Dim arraylist As New ArrayList
        Dim counter As Integer = 1

        objCmd = New SqlCommand
        objCmd.Connection = objCn

        Try
            objCn.Open()

            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.CommandText = "sp_Get_All_Vehicle"

            objReader = objCmd.ExecuteReader

            While (objReader.Read())
                Dim objVehicle As New Vehicle

                objVehicle.Capacity = objReader("Capacity")
                objVehicle.Make = objReader("Make")
                objVehicle.Model = objReader("Model")
                objVehicle.VehicleID = objReader("VehicleID")
                objVehicle.VehicleTypeID = objReader("VehicleTypeID")
                objVehicle.Years = objReader("Years")
                objVehicle.Description = objReader("Description")
                objVehicle.UserName = objReader("LoginID")
                objVehicle.Counter = counter

                arraylist.Add(objVehicle)

                counter += 1
            End While

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            objCn.Close()
        End Try

        Return arraylist

    End Function

    Public Function Search_By_Vehicle(ByVal col As String, ByVal search As String) As ArrayList

        Dim arraylist As New ArrayList
        Dim counter As Integer = 1

        objCmd = New SqlCommand
        objCmd.Connection = objCn

        Try
            objCn.Open()

            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.CommandText = "sp_Search_By_Vehicle"

            With objCmd.Parameters
                .Add("@search", SqlDbType.VarChar, 100).Value = search
                .Add("@col", SqlDbType.VarChar, 100).Value = col
            End With
            objReader = objCmd.ExecuteReader

            While (objReader.Read())
                Dim objVehicle As New Vehicle

                objVehicle.Capacity = objReader("Capacity")
                objVehicle.Make = objReader("Make")
                objVehicle.Model = objReader("Model")
                objVehicle.VehicleID = objReader("VehicleID")
                objVehicle.VehicleTypeID = objReader("VehicleTypeID")
                objVehicle.Years = objReader("Years")
                objVehicle.Description = objReader("Description")
                objVehicle.UserName = objReader("LoginID")
                objVehicle.Counter = counter

                arraylist.Add(objVehicle)

                counter += 1
            End While

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            objCn.Close()
        End Try

        Return arraylist

    End Function

    Public Function Get_Single_VehicleConfiguration(ByVal id As Integer) As VehicleConfiguration

        Dim objVehicleConfiguration As New VehicleConfiguration

        objCmd = New SqlCommand
        objCmd.Connection = objCn

        Try
            objCn.Open()

            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.CommandText = "sp_Get_Single_VehicleConfiguration"

            With objCmd.Parameters
                .Add("@VehicleId", Data.SqlDbType.Int).Value = id
            End With

            objReader = objCmd.ExecuteReader

            While (objReader.Read())
                objVehicleConfiguration.PropellentID = objReader("PropellentID")
                objVehicleConfiguration.TyreID = objReader("TyreID")
                objVehicleConfiguration.VehicleConfigurationID = objReader("VehicleConfigurationID")
                objVehicleConfiguration.VehicleID = objReader("VehicleID")
            End While

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            objCn.Close()
        End Try

        Return objVehicleConfiguration

    End Function

    Public Function Get_All_VehicleConfiguration() As ArrayList

        Dim arraylist As New ArrayList
        Dim counter As Integer = 1

        objCmd = New SqlCommand
        objCmd.Connection = objCn

        Try
            objCn.Open()

            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.CommandText = "sp_Get_All_VehicleConfiguration"

            objReader = objCmd.ExecuteReader

            While (objReader.Read())
                Dim objVehicleConfiguration As New VehicleConfiguration

                objVehicleConfiguration.PropellentID = objReader("PropellentID")
                objVehicleConfiguration.TyreID = objReader("TyreID")
                objVehicleConfiguration.VehicleConfigurationID = objReader("VehicleConfigurationID")
                objVehicleConfiguration.VehicleID = objReader("VehicleID")
                objVehicleConfiguration.Counter = counter
                arraylist.Add(objVehicleConfiguration)

                counter += 1
            End While

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            objCn.Close()
        End Try

        Return arraylist

    End Function

    Public Function Search_By_VehicleConfiguration(ByVal col As String, ByVal search As String) As ArrayList

        Dim arraylist As New ArrayList
        Dim counter As Integer = 1

        objCmd = New SqlCommand
        objCmd.Connection = objCn

        Try
            objCn.Open()

            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.CommandText = "sp_Search_By_VehicleConfiguration"

            With objCmd.Parameters
                .Add("@search", SqlDbType.VarChar, 100).Value = search
                .Add("@col", SqlDbType.VarChar, 100).Value = col
            End With

            objReader = objCmd.ExecuteReader

            While (objReader.Read())
                Dim objVehicleConfiguration As New VehicleConfiguration

                objVehicleConfiguration.PropellentID = objReader("PropellentID")
                objVehicleConfiguration.TyreID = objReader("TyreID")
                objVehicleConfiguration.VehicleConfigurationID = objReader("VehicleConfigurationID")
                objVehicleConfiguration.VehicleID = objReader("VehicleID")
                objVehicleConfiguration.Counter = counter
                arraylist.Add(objVehicleConfiguration)

                counter += 1
            End While

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            objCn.Close()
        End Try

        Return arraylist

    End Function

    Public Function Get_ByUserID_VehicleOwnership(ByVal id As Integer) As VehicleOwnership

        Dim objVehicleOwnership As New VehicleOwnership

        objCmd = New SqlCommand
        objCmd.Connection = objCn

        Try
            objCn.Open()

            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.CommandText = "sp_Get_UserID_VehicleOwnership"

            With objCmd.Parameters
                .Add("@UserID", Data.SqlDbType.Int).Value = id
            End With

            objReader = objCmd.ExecuteReader

            While (objReader.Read())

                objVehicleOwnership.OwnershipID = objReader("OwnershipID")
                objVehicleOwnership.UserID = objReader("UserID")
                objVehicleOwnership.VehicleID = objReader("VehicleID")
                objVehicleOwnership.UserName = objReader("LoginID")

            End While

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            objCn.Close()
        End Try

        Return objVehicleOwnership

    End Function

    Public Function Get_Single_VehicleOwnership(ByVal id As Integer) As VehicleOwnership

        Dim objVehicleOwnership As New VehicleOwnership

        objCmd = New SqlCommand
        objCmd.Connection = objCn

        Try
            objCn.Open()

            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.CommandText = "sp_Get_Single_VehicleOwnership"

            With objCmd.Parameters
                .Add("@VehicleId", Data.SqlDbType.Int).Value = id
            End With

            objReader = objCmd.ExecuteReader

            While (objReader.Read())

                objVehicleOwnership.OwnershipID = objReader("OwnershipID")
                objVehicleOwnership.UserID = objReader("UserID")
                objVehicleOwnership.VehicleID = objReader("VehicleID")
                objVehicleOwnership.UserName = objReader("LoginID")

            End While

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            objCn.Close()
        End Try

        Return objVehicleOwnership

    End Function

    Public Function Get_All_VehicleOwnership() As ArrayList

        Dim arraylist As New ArrayList
        Dim counter As Integer = 1

        objCmd = New SqlCommand
        objCmd.Connection = objCn

        Try
            objCn.Open()

            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.CommandText = "sp_Get_All_VehicleOwnership"

            objReader = objCmd.ExecuteReader

            While (objReader.Read())
                Dim objVehicleOwnership As New VehicleOwnership

                objVehicleOwnership.OwnershipID = objReader("OwnershipID")
                objVehicleOwnership.UserID = objReader("UserID")
                objVehicleOwnership.VehicleID = objReader("VehicleID")
                objVehicleOwnership.UserName = objReader("LoginID")
                objVehicleOwnership.counter = counter
                arraylist.Add(objVehicleOwnership)
                counter += 1
            End While

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            objCn.Close()
        End Try

        Return arraylist

    End Function

    Public Function Search_By_VehicleOwnership(ByVal col As String, ByVal search As String) As ArrayList

        Dim arraylist As New ArrayList
        Dim counter As Integer = 1

        objCmd = New SqlCommand
        objCmd.Connection = objCn

        Try
            objCn.Open()

            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.CommandText = "sp_Search_By_VehicleOwnership"

            With objCmd.Parameters
                .Add("@search", SqlDbType.VarChar, 100).Value = search
                .Add("@col", SqlDbType.VarChar, 100).Value = col
            End With

            objReader = objCmd.ExecuteReader

            While (objReader.Read())
                Dim objVehicleOwnership As New VehicleOwnership

                objVehicleOwnership.OwnershipID = objReader("OwnershipID")
                objVehicleOwnership.UserID = objReader("UserID")
                objVehicleOwnership.VehicleID = objReader("VehicleID")
                objVehicleOwnership.UserName = objReader("LoginID")
                objVehicleOwnership.Counter = counter
                arraylist.Add(objVehicleOwnership)
                counter += 1
            End While

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            objCn.Close()
        End Try

        Return arraylist

    End Function

    Public Function Get_Single_VehicleType(ByVal id As Integer) As VehicleType

        Dim objVehicleType As New VehicleType

        objCmd = New SqlCommand
        objCmd.Connection = objCn

        Try
            objCn.Open()

            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.CommandText = "sp_Get_Single_VehicleType"

            With objCmd.Parameters
                .Add("@VehicleTypeID", Data.SqlDbType.Int).Value = id
            End With

            objReader = objCmd.ExecuteReader

            While (objReader.Read())
                objVehicleType.Description = objReader("Description")
                objVehicleType.VehicleTypeID = objReader("VehicleTypeID")
            End While

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            objCn.Close()
        End Try

        Return objVehicleType

    End Function

    Public Function Get_All_VehicleType() As ArrayList

        Dim arraylist As New ArrayList
        Dim counter As Integer = 1

        objCmd = New SqlCommand
        objCmd.Connection = objCn

        Try
            objCn.Open()

            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.CommandText = "sp_Get_All_VehicleType"

            objReader = objCmd.ExecuteReader

            While (objReader.Read())
                Dim objVehicleType As New VehicleType

                objVehicleType.Description = objReader("Description")
                objVehicleType.VehicleTypeID = objReader("VehicleTypeID")
                objVehicleType.counter = counter

                arraylist.Add(objVehicleType)
                counter += 1
            End While

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            objCn.Close()
        End Try

        Return arraylist

    End Function

    Public Function Search_By_VehicleType(ByVal col As String, ByVal search As String) As ArrayList

        Dim arraylist As New ArrayList
        Dim counter As Integer = 1

        objCmd = New SqlCommand
        objCmd.Connection = objCn

        Try
            objCn.Open()

            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.CommandText = "sp_Search_By_VehicleType"

            With objCmd.Parameters
                .Add("@search", SqlDbType.VarChar, 100).Value = search
                .Add("@col", SqlDbType.VarChar, 100).Value = col
            End With

            objReader = objCmd.ExecuteReader

            While (objReader.Read())
                Dim objVehicleType As New VehicleType

                objVehicleType.Description = objReader("Description")
                objVehicleType.VehicleTypeID = objReader("VehicleTypeID")
                objVehicleType.Counter = counter

                arraylist.Add(objVehicleType)
                counter += 1
            End While

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            objCn.Close()
        End Try

        Return arraylist

    End Function

    Public Function Delete_By_Vehicle(ByVal OwnershipId As Integer, ByVal VehicleId As Integer) As Integer

        Dim rowAffected As Integer

        objCmd = New SqlCommand
        objCmd.Connection = objCn

        Try
            objCn.Open()

            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.CommandText = "sp_Delete_By_Vehicle"

            With objCmd.Parameters
                .Add("@OwnershipId", SqlDbType.Int).Value = OwnershipId
                .Add("@VehicleId", SqlDbType.Int).Value = VehicleId
            End With

            rowAffected = objCmd.ExecuteNonQuery()

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            objCn.Close()
        End Try

        Return rowAffected

    End Function

    Public Function Delete_By_VehicleConfiguration(ByVal VehicleConfigurationId As Integer, ByVal PropellentId As Integer) As Integer

        Dim rowAffected As Integer

        objCmd = New SqlCommand
        objCmd.Connection = objCn

        Try
            objCn.Open()

            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.CommandText = "sp_Delete_By_VehicleConfiguration"

            With objCmd.Parameters
                .Add("@VehicleConfigurationId", SqlDbType.Int).Value = VehicleConfigurationId
                .Add("@PropellentId", SqlDbType.Int).Value = PropellentId
            End With

            rowAffected = objCmd.ExecuteNonQuery()

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            objCn.Close()
        End Try

        Return rowAffected

    End Function

    Public Function Delete_By_VehicleOwnership(ByVal OwnershipId As Integer, ByVal VehicleId As Integer) As Integer

        Dim rowAffected As Integer

        objCmd = New SqlCommand
        objCmd.Connection = objCn

        Try
            objCn.Open()

            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.CommandText = "sp_Delete_By_VehicleOwnership"

            With objCmd.Parameters
                .Add("@OwnershipId", SqlDbType.Int).Value = OwnershipId
                .Add("@VehicleId", SqlDbType.Int).Value = VehicleId
            End With

            rowAffected = objCmd.ExecuteNonQuery()

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            objCn.Close()
        End Try

        Return rowAffected

    End Function

    Public Function Delete_By_VehicleType(ByVal id As Integer) As Integer

        Dim rowAffected As Integer

        objCmd = New SqlCommand
        objCmd.Connection = objCn

        Try
            objCn.Open()

            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.CommandText = "sp_Delete_By_VehicleType"

            With objCmd.Parameters
                .Add("@VehicleTypeId", SqlDbType.Int).Value = id
            End With

            rowAffected = objCmd.ExecuteNonQuery()

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            objCn.Close()
        End Try

        Return rowAffected

    End Function

    Public Function Add_Vehicle(ByVal objData As Vehicle) As Integer

        Dim identity As Integer

        objCmd = New SqlCommand
        objCmd.Connection = objCn

        Try
            objCn.Open()

            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.CommandText = "sp_Add_Vehicle"

            With objCmd.Parameters
                .Add("@vehicleTypeID", SqlDbType.Int).Value = objData.VehicleTypeID
                .Add("@model", SqlDbType.VarChar, 50).Value = objData.Model
                .Add("@make", SqlDbType.VarChar, 50).Value = objData.Make
                .Add("@years", SqlDbType.VarChar, 50).Value = objData.Years
                .Add("@capacity", SqlDbType.VarChar, 50).Value = objData.Capacity
            End With

            Dim retValParam As New SqlParameter("@RETURN_VALUE", SqlDbType.Int)
            retValParam.Direction = ParameterDirection.ReturnValue
            objCmd.Parameters.Add(retValParam)

            Dim reader As SqlDataReader = objCmd.ExecuteReader()

            identity = Convert.ToInt32(retValParam.Value)

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            objCn.Close()
        End Try

        Return identity

    End Function

    Public Function Add_VehicleConfiguration(ByVal objData As VehicleConfiguration) As Integer

        Dim rowAffected As Integer

        objCmd = New SqlCommand
        objCmd.Connection = objCn

        Try
            objCn.Open()

            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.CommandText = "sp_Add_VehicleConfiguration"

            With objCmd.Parameters
                .Add("@vehicleID", SqlDbType.Int).Value = objData.VehicleID
                .Add("@propellentID", SqlDbType.Int).Value = objData.PropellentID
                .Add("@tyreID", SqlDbType.Int).Value = objData.TyreID
            End With

            rowAffected = objCmd.ExecuteNonQuery()

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            objCn.Close()
        End Try

        Return rowAffected

    End Function

    Public Function Add_VehicleOwnership(ByVal objData As VehicleOwnership) As Integer

        Dim rowAffected As Integer

        objCmd = New SqlCommand
        objCmd.Connection = objCn

        Try
            objCn.Open()

            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.CommandText = "sp_Add_VehicleOwnership"

            With objCmd.Parameters
                .Add("@userID", SqlDbType.Int).Value = objData.UserID
                .Add("@vehicleID", SqlDbType.Int).Value = objData.VehicleID
            End With

            rowAffected = objCmd.ExecuteNonQuery()

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            objCn.Close()
        End Try

        Return rowAffected

    End Function

    Public Function Add_VehicleType(ByVal objData As VehicleType) As Integer

        Dim rowAffected As Integer

        objCmd = New SqlCommand
        objCmd.Connection = objCn

        Try
            objCn.Open()

            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.CommandText = "sp_Add_VehicleType"

            With objCmd.Parameters
                .Add("@description", SqlDbType.VarChar, 50).Value = objData.Description
            End With

            rowAffected = objCmd.ExecuteNonQuery()

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            objCn.Close()
        End Try

        Return rowAffected

    End Function

    Public Function Update_Vehicle(ByVal objData As Vehicle) As Integer

        Dim rowAffected As Integer

        objCmd = New SqlCommand
        objCmd.Connection = objCn

        Try
            objCn.Open()

            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.CommandText = "sp_Update_Vehicle"

            With objCmd.Parameters
                .Add("@vehicleID", SqlDbType.Int).Value = objData.VehicleID
                .Add("@vehicleTypeID", SqlDbType.Int).Value = objData.VehicleTypeID
                .Add("@model", SqlDbType.VarChar, 50).Value = objData.Model
                .Add("@make", SqlDbType.VarChar, 50).Value = objData.Make
                .Add("@years", SqlDbType.VarChar, 50).Value = objData.Years
                .Add("@capacity", SqlDbType.VarChar, 50).Value = objData.Capacity
            End With

            rowAffected = objCmd.ExecuteNonQuery()

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            objCn.Close()
        End Try

        Return rowAffected

    End Function

    Public Function Update_VehicleConfiguration(ByVal objData As VehicleConfiguration) As Integer

        Dim rowAffected As Integer

        objCmd = New SqlCommand
        objCmd.Connection = objCn

        Try
            objCn.Open()

            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.CommandText = "sp_Update_VehicleConfiguration"

            With objCmd.Parameters
                .Add("@vehicleConfigurationID", SqlDbType.Int).Value = objData.VehicleConfigurationID
                .Add("@vehicleID", SqlDbType.Int).Value = objData.VehicleID
                .Add("@propellentID", SqlDbType.Int).Value = objData.PropellentID
                .Add("@tyreID", SqlDbType.Int).Value = objData.TyreID
            End With

            rowAffected = objCmd.ExecuteNonQuery()

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            objCn.Close()
        End Try

        Return rowAffected

    End Function

    Public Function Update_VehicleOwnership(ByVal objData As VehicleOwnership) As Integer

        Dim rowAffected As Integer

        objCmd = New SqlCommand
        objCmd.Connection = objCn

        Try
            objCn.Open()

            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.CommandText = "sp_Update_VehicleOwnership"

            With objCmd.Parameters
                .Add("@ownershipID", SqlDbType.Int).Value = objData.OwnershipID
                .Add("@userID", SqlDbType.Int).Value = objData.UserID
                .Add("@vehicleID", SqlDbType.Int).Value = objData.VehicleID
            End With

            rowAffected = objCmd.ExecuteNonQuery()

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            objCn.Close()
        End Try

        Return rowAffected

    End Function

    Public Function Update_VehicleTyre(ByVal objData As VehicleType) As Integer

        Dim rowAffected As Integer

        objCmd = New SqlCommand
        objCmd.Connection = objCn

        Try
            objCn.Open()

            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.CommandText = "sp_Update_VehicleType"

            With objCmd.Parameters
                .Add("@vehicleTypeID", SqlDbType.Int).Value = objData.VehicleTypeID
                .Add("@description", SqlDbType.VarChar, 50).Value = objData.Description
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
