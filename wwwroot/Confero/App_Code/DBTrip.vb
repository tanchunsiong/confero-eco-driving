Imports Microsoft.VisualBasic
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.HttpResponse

Public Class DBTrip

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

    Public Function Get_User_Trip(ByVal userId As Integer) As ArrayList

        Dim arraylist As New ArrayList
        Dim counter As Integer = 1

        objCmd = New SqlCommand
        objCmd.Connection = objCn

        Try
            objCn.Open()

            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.CommandText = "sp_Get_User_Trip"

            With objCmd.Parameters
                .Add("@UserID", Data.SqlDbType.Int).Value = userId
            End With

            objReader = objCmd.ExecuteReader

            While (objReader.Read())
                Dim objTrip As New Trip

                objTrip.DistanceTravelled = objReader("DistanceTravelled")
                objTrip.EndTime = objReader("EndTime")
                objTrip.FuelUsage = objReader("FuelUsage")
                objTrip.Horsepower = objReader("Horsepower")
                objTrip.Location = objReader("Location")
                objTrip.MaxGForce = objReader("MaxGForce")
                objTrip.OptimumSpeed = objReader("OptimumSpeed")
                objTrip.StartTime = objReader("StartTime")
                objTrip.TripID = objReader("TripID")
                objTrip.VehicleConfigurationID = objReader("VehicleConfigurationID")
                objTrip.WeatherCondition = objReader("WeatherCondition")
                objTrip.WeightOfVehicle = objReader("WeightOfVehicle")
                objTrip.Counter = counter

                objTrip.Model = objReader("Model")
                objTrip.Make = objReader("Make")
                objTrip.Description = objReader("Description")

                arraylist.Add(objTrip)

                counter += 1
            End While

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            objCn.Close()
        End Try

        Return arraylist

    End Function

    Public Function Search_User_Trip(ByVal col As String, ByVal search As String, ByVal userId As Integer) As ArrayList

        Dim arraylist As New ArrayList
        Dim counter As Integer = 1

        objCmd = New SqlCommand
        objCmd.Connection = objCn

        Try
            objCn.Open()

            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.CommandText = "sp_Search_User_Trip"

            With objCmd.Parameters
                .Add("@UserID", Data.SqlDbType.Int).Value = userId
                .Add("@search", SqlDbType.VarChar, 100).Value = search
                .Add("@col", SqlDbType.VarChar, 100).Value = col
            End With

            objReader = objCmd.ExecuteReader

            While (objReader.Read())
                Dim objTrip As New Trip

                objTrip.DistanceTravelled = objReader("DistanceTravelled")
                objTrip.EndTime = objReader("EndTime")
                objTrip.FuelUsage = objReader("FuelUsage")
                objTrip.Horsepower = objReader("Horsepower")
                objTrip.Location = objReader("Location")
                objTrip.MaxGForce = objReader("MaxGForce")
                objTrip.OptimumSpeed = objReader("OptimumSpeed")
                objTrip.StartTime = objReader("StartTime")
                objTrip.TripID = objReader("TripID")
                objTrip.VehicleConfigurationID = objReader("VehicleConfigurationID")
                objTrip.WeatherCondition = objReader("WeatherCondition")
                objTrip.WeightOfVehicle = objReader("WeightOfVehicle")
                objTrip.Counter = counter

                objTrip.Model = objReader("Model")
                objTrip.Make = objReader("Make")
                objTrip.Description = objReader("Description")

                arraylist.Add(objTrip)

                counter += 1
            End While

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            objCn.Close()
        End Try

        Return arraylist

    End Function

    Public Function Get_User_Top5_Trip(ByVal vehicleId As Integer) As ArrayList

        Dim arraylist As New ArrayList
        Dim counter As Integer = 1

        objCmd = New SqlCommand
        objCmd.Connection = objCn

        Try
            objCn.Open()

            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.CommandText = "sp_Get_User_Top5_Trip"

            With objCmd.Parameters
                .Add("@vehicleId", Data.SqlDbType.Int).Value = vehicleId
            End With

            objReader = objCmd.ExecuteReader

            While (objReader.Read())
                Dim objTrip As New TripTop5

                objTrip.DistanceTravelled = objReader("DistanceTravelled")
                objTrip.FuelUsage = objReader("FuelUsage")
                objTrip.PBrand = objReader("PBrand")
                objTrip.Octane = objReader("Octane")
                objTrip.Description = objReader("Description")
                objTrip.TyreID = objReader("TyreID")
                objTrip.Brand = objReader("Brand")
                objTrip.Width = objReader("Width")
                objTrip.TyreSize = objReader("TyreSize")
                objTrip.Material = objReader("Material")
                objTrip.RollingResistance = objReader("rollingResistance")
                objTrip.Model = objReader("Model")
                objTrip.Type = objReader("Type")

                objTrip.Counter = counter

                arraylist.Add(objTrip)

                counter += 1
            End While

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            objCn.Close()
        End Try

        Return arraylist

    End Function

    Public Function Search_User_Top5_Trip(ByVal col As String, ByVal search As String, ByVal vehicleId As Integer) As ArrayList

        Dim arraylist As New ArrayList
        Dim counter As Integer = 1

        objCmd = New SqlCommand
        objCmd.Connection = objCn

        Try
            objCn.Open()

            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.CommandText = "sp_Search_Top5_Trip"

            With objCmd.Parameters
                .Add("@vehicleId", Data.SqlDbType.Int).Value = vehicleId
                .Add("@search", SqlDbType.VarChar, 100).Value = search
                .Add("@col", SqlDbType.VarChar, 100).Value = col
            End With

            objReader = objCmd.ExecuteReader

            While (objReader.Read())
                Dim objTrip As New TripTop5

                objTrip.DistanceTravelled = objReader("DistanceTravelled")
                objTrip.FuelUsage = objReader("FuelUsage")
                objTrip.PBrand = objReader("PBrand")
                objTrip.Octane = objReader("Octane")
                objTrip.Description = objReader("Description")
                objTrip.TyreID = objReader("TyreID")
                objTrip.Brand = objReader("Brand")
                objTrip.Width = objReader("Width")
                objTrip.TyreSize = objReader("TyreSize")
                objTrip.Material = objReader("Material")
                objTrip.RollingResistance = objReader("rollingResistance")
                objTrip.Model = objReader("Model")
                objTrip.Type = objReader("Type")

                objTrip.Counter = counter

                arraylist.Add(objTrip)

                counter += 1
            End While

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            objCn.Close()
        End Try

        Return arraylist

    End Function

    'admin code -------------------------------------------------------------------
    Public Function Get_All_Trip() As ArrayList

        Dim arraylist As New ArrayList
        Dim counter As Integer = 1

        objCmd = New SqlCommand
        objCmd.Connection = objCn

        Try
            objCn.Open()

            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.CommandText = "sp_Get_All_Trip"

            objReader = objCmd.ExecuteReader

            While (objReader.Read())
                Dim objTrip As New Trip

                objTrip.DistanceTravelled = objReader("DistanceTravelled")
                objTrip.EndTime = objReader("EndTime")
                objTrip.FuelUsage = objReader("FuelUsage")
                objTrip.Horsepower = objReader("Horsepower")
                objTrip.Location = objReader("Location")
                objTrip.MaxGForce = objReader("MaxGForce")
                objTrip.OptimumSpeed = objReader("OptimumSpeed")
                objTrip.StartTime = objReader("StartTime")
                objTrip.TripID = objReader("TripID")
                objTrip.VehicleConfigurationID = objReader("VehicleConfigurationID")
                objTrip.WeatherCondition = objReader("WeatherCondition")
                objTrip.WeightOfVehicle = objReader("WeightOfVehicle")
                objTrip.counter = counter

                arraylist.Add(objTrip)

                counter += 1
            End While

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            objCn.Close()
        End Try

        Return arraylist

    End Function

    Public Function Search_By_Trip(ByVal col As String, ByVal search As String) As ArrayList

        Dim arraylist As New ArrayList
        Dim counter As Integer = 1

        objCmd = New SqlCommand
        objCmd.Connection = objCn

        Try
            objCn.Open()

            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.CommandText = "sp_Search_By_Trip"

            With objCmd.Parameters
                .Add("@search", SqlDbType.VarChar, 100).Value = search
                .Add("@col", SqlDbType.VarChar, 100).Value = col
            End With

            objReader = objCmd.ExecuteReader

            While (objReader.Read())
                Dim objTrip As New Trip

                objTrip.DistanceTravelled = objReader("DistanceTravelled")
                objTrip.EndTime = objReader("EndTime")
                objTrip.FuelUsage = objReader("FuelUsage")
                objTrip.Horsepower = objReader("Horsepower")
                objTrip.Location = objReader("Location")
                objTrip.MaxGForce = objReader("MaxGForce")
                objTrip.OptimumSpeed = objReader("OptimumSpeed")
                objTrip.StartTime = objReader("StartTime")
                objTrip.TripID = objReader("TripID")
                objTrip.VehicleConfigurationID = objReader("VehicleConfigurationID")
                objTrip.WeatherCondition = objReader("WeatherCondition")
                objTrip.WeightOfVehicle = objReader("WeightOfVehicle")
                objTrip.Counter = counter

                arraylist.Add(objTrip)

                counter += 1
            End While

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            objCn.Close()
        End Try

        Return arraylist

    End Function

    Public Function Delete_By_Trip(ByVal id As Integer) As Integer

        Dim rowAffected As Integer

        objCmd = New SqlCommand
        objCmd.Connection = objCn

        Try
            objCn.Open()

            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.CommandText = "sp_Delete_By_Trip"

            With objCmd.Parameters
                .Add("@TripId", SqlDbType.Int).Value = id
            End With

            rowAffected = objCmd.ExecuteNonQuery()

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            objCn.Close()
        End Try

        Return rowAffected

    End Function

    Public Function Add_Trip(ByVal objData As Trip) As Integer

        Dim rowAffected As Integer

        objCmd = New SqlCommand
        objCmd.Connection = objCn

        Try
            objCn.Open()

            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.CommandText = "sp_Add_Trip"

            With objCmd.Parameters
                .Add("@vehicleConfigurationID", SqlDbType.Int).Value = objData.vehicleConfigurationID
                .Add("@optimumSpeed", SqlDbType.Int).Value = objData.OptimumSpeed
                .Add("@weightOfVehicle", SqlDbType.Int).Value = objData.WeightOfVehicle
                .Add("@location", SqlDbType.VarChar, 50).Value = objData.Location
                .Add("@weatherCondition", SqlDbType.VarChar, 50).Value = objData.WeatherCondition
                .Add("@distanceTravelled", SqlDbType.Int).Value = objData.DistanceTravelled
                .Add("@startTime", SqlDbType.DateTime).Value = objData.StartTime
                .Add("@endTime", SqlDbType.DateTime).Value = objData.EndTime
                .Add("@fuelusage", SqlDbType.Int).Value = objData.FuelUsage
                .Add("@maxGForce", SqlDbType.Decimal, 18, 2).Value = objData.MaxGForce
                .Add("@horsepower", SqlDbType.Decimal, 18, 2).Value = objData.Horsepower

            End With

            rowAffected = objCmd.ExecuteNonQuery()

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            objCn.Close()
        End Try

        Return rowAffected

    End Function

    Public Function Update_Trip(ByVal objData As Trip) As Integer

        Dim rowAffected As Integer

        objCmd = New SqlCommand
        objCmd.Connection = objCn

        Try
            objCn.Open()

            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.CommandText = "sp_Update_Trip"

            With objCmd.Parameters
                .Add("@tripIDID", SqlDbType.Int).Value = objData.TripID
                .Add("@vehicleConfigurationID", SqlDbType.Int).Value = objData.VehicleConfigurationID
                .Add("@optimumSpeed", SqlDbType.Int).Value = objData.OptimumSpeed
                .Add("@weightOfVehicle", SqlDbType.Int).Value = objData.WeightOfVehicle
                .Add("@location", SqlDbType.VarChar, 50).Value = objData.Location
                .Add("@weatherCondition", SqlDbType.VarChar, 50).Value = objData.WeatherCondition
                .Add("@distanceTravelled", SqlDbType.Int).Value = objData.DistanceTravelled
                .Add("@startTime", SqlDbType.DateTime).Value = objData.StartTime
                .Add("@endTime", SqlDbType.DateTime).Value = objData.EndTime
                .Add("@fuelusage", SqlDbType.Int).Value = objData.FuelUsage
                .Add("@maxGForce", SqlDbType.Decimal, 18, 2).Value = objData.MaxGForce
                .Add("@horsepower", SqlDbType.Decimal, 18, 2).Value = objData.Horsepower
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
