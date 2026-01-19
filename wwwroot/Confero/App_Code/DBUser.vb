Imports Microsoft.VisualBasic
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.HttpResponse
Imports System.Web.Configuration
Imports System.Configuration

Public Class DBUser

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

    Public Function Get_UserId(ByVal loginId As String, ByVal password As String) As Integer

        Dim userId As Integer

        objadapter = New SqlDataAdapter
        objDS = New DataSet
        objCmd = New SqlCommand
        objCmd.Connection = objCn

        Try
            objCn.Open()

            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.CommandText = "sp_Get_UserId"

            With objCmd.Parameters
                .Add("@loginID", SqlDbType.VarChar, 50).Value = loginId
                .Add("@password", SqlDbType.VarChar, 50).Value = password
            End With

            objReader = objCmd.ExecuteReader

            While (objReader.Read())
                userId = objReader("userId")
            End While

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            objCn.Close()
        End Try

        Return userId

    End Function

    Public Function Check_Username(ByVal userID As String) As Integer

        Dim user As Integer

        objadapter = New SqlDataAdapter
        objDS = New DataSet
        objCmd = New SqlCommand
        objCmd.Connection = objCn

        Try
            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.CommandText = "sp_check_username"

            objCn.Open()

            With objCmd.Parameters
                .Add("@loginID", SqlDbType.VarChar, 50).Value = userID
            End With

            user = objCmd.ExecuteScalar()

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            objCn.Close()
        End Try

        Return user

    End Function

    Function ValidateUser(ByVal loginID As String, ByVal password As String) As Integer

        Dim rowAffected As Integer

        objCmd = New SqlCommand
        objCmd.Connection = objCn

        Try
            objCn.Open()

            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.CommandText = "sp_Validate_User"

            With objCmd.Parameters
                .Add("@loginID", Data.SqlDbType.VarChar).Value = loginID
                .Add("@password", Data.SqlDbType.VarChar).Value = password
            End With

            rowAffected = objCmd.ExecuteScalar()

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            objCn.Close()
        End Try

        Return rowAffected

    End Function

    Public Function Get_Login_User(ByVal userID As String, ByVal password As String) As Object

        Dim user As Object = Nothing
        Dim objUser As New User

        objadapter = New SqlDataAdapter
        objDS = New DataSet
        objCmd = New SqlCommand
        objCmd.Connection = objCn

        Try
            objCn.Open()

            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.CommandText = "sp_Get_Login_User"

            With objCmd.Parameters
                .Add("@loginID", SqlDbType.VarChar, 50).Value = userID
                .Add("@password", SqlDbType.VarChar, 50).Value = password
            End With

            objReader = objCmd.ExecuteReader

            While (objReader.Read())

                objUser.LoginId = objReader("LoginId")
                objUser.UserId = objReader("UserId")
                objUser.Type = objReader("Type")
                objUser.Password = objReader("Password")
                objUser.Address = objReader("Address")
                objUser.Dob = objReader("Dob")
                objUser.Email = objReader("Email")
                objUser.Gender = objReader("Gender")
                objUser.Name = objReader("fullname")
                objUser.Telephone = objReader("Telephone")
            End While

            user = objUser

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            objCn.Close()
        End Try

        Return user

    End Function

    Public Function Get_Single_User(ByVal id As String) As User

        Dim objUser As New User

        objadapter = New SqlDataAdapter
        objDS = New DataSet
        objCmd = New SqlCommand
        objCmd.Connection = objCn

        Try
            objCn.Open()

            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.CommandText = "sp_Get_Single_User"

            With objCmd.Parameters
                .Add("@userID", SqlDbType.Int).Value = id
            End With

            objReader = objCmd.ExecuteReader

            While (objReader.Read())
                objUser.LoginId = objReader("LoginId")
                objUser.UserId = objReader("UserId")
                objUser.Type = objReader("Type")
                objUser.Password = objReader("Password")
                objUser.Address = objReader("Address")
                objUser.Dob = objReader("Dob")
                objUser.Email = objReader("Email")
                objUser.Gender = objReader("Gender")
                objUser.Name = objReader("fullname")
                objUser.Telephone = objReader("Telephone")
            End While

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            objCn.Close()
        End Try

        Return objUser

    End Function

    Public Function Get_All_User() As ArrayList

        Dim arraylist As New ArrayList
        Dim counter As Integer = 1

        objCmd = New SqlCommand
        objCmd.Connection = objCn

        Try
            objCn.Open()

            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.CommandText = "sp_Get_All_User"

            objReader = objCmd.ExecuteReader

            While (objReader.Read())
                Dim objUser As New User

                objUser.LoginId = objReader("LoginId")
                objUser.UserId = objReader("UserId")
                objUser.Type = objReader("Type")
                objUser.Password = objReader("Password")
                objUser.Address = objReader("Address")
                objUser.Dob = objReader("Dob")
                objUser.Email = objReader("Email")
                objUser.Gender = objReader("Gender")
                objUser.Name = objReader("fullname")
                objUser.Telephone = objReader("Telephone")

                objUser.Counter = counter
                arraylist.Add(objUser)

                counter += 1
            End While

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            objCn.Close()
        End Try

        Return arraylist

    End Function

    Public Function Search_By_User(ByVal col As String, ByVal search As String) As ArrayList

        Dim arraylist As New ArrayList
        Dim counter As Integer = 1

        objCmd = New SqlCommand
        objCmd.Connection = objCn

        Try
            objCn.Open()

            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.CommandText = "sp_Search_By_User"

            With objCmd.Parameters
                .Add("@search", SqlDbType.VarChar, 100).Value = search
                .Add("@col", SqlDbType.VarChar, 100).Value = col
            End With

            objReader = objCmd.ExecuteReader

            While (objReader.Read())
                Dim objUser As New User

                objUser.LoginId = objReader("LoginId")
                objUser.UserId = objReader("UserId")
                objUser.Type = objReader("Type")
                objUser.Password = objReader("Password")
                objUser.Address = objReader("Address")
                objUser.Dob = objReader("Dob")
                objUser.Email = objReader("Email")
                objUser.Gender = objReader("Gender")
                objUser.Name = objReader("fullname")
                objUser.Telephone = objReader("Telephone")

                objUser.Counter = counter
                arraylist.Add(objUser)

                counter += 1
            End While

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            objCn.Close()
        End Try

        Return arraylist

    End Function

    Public Function Get_Single_UserGenerateInfo(ByVal id As Integer) As UserGenerateInfo

        Dim user As Object = Nothing
        Dim objUserGenerateInfo As New UserGenerateInfo

        objadapter = New SqlDataAdapter
        objDS = New DataSet
        objCmd = New SqlCommand
        objCmd.Connection = objCn

        Try
            objCn.Open()

            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.CommandText = "sp_Get_Single_UserGenerateInfo"

            With objCmd.Parameters
                .Add("@UserGenerateInformationID", SqlDbType.Int).Value = id
            End With

            objReader = objCmd.ExecuteReader

            While (objReader.Read())

                objUserGenerateInfo.Description = objReader("Description")
                objUserGenerateInfo.UserGenerateInformationID = objReader("UserGenerateInformationID")
                objUserGenerateInfo.Value = objReader("Value")

            End While


        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            objCn.Close()
        End Try

        Return objUserGenerateInfo

    End Function

    Public Function Get_All_UserGenerateInfo() As ArrayList

        Dim arraylist As New ArrayList
        Dim counter As Integer = 1

        objCmd = New SqlCommand
        objCmd.Connection = objCn

        Try
            objCn.Open()

            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.CommandText = "sp_Get_All_UserGenerateInfo"

            objReader = objCmd.ExecuteReader

            While (objReader.Read())
                Dim objUserGenerateInfo As New UserGenerateInfo

                objUserGenerateInfo.Description = objReader("Description")
                objUserGenerateInfo.UserGenerateInformationID = objReader("UserGenerateInformationID")
                objUserGenerateInfo.Value = objReader("Value")
                objUserGenerateInfo.Longitude = objReader("Long")
                objUserGenerateInfo.Latitude = objReader("Lat")
                objUserGenerateInfo.DateTime = objReader("DateTime")
                objUserGenerateInfo.PhoneNo = objReader("PhoneNumber")
                objUserGenerateInfo.Counter = counter

                arraylist.Add(objUserGenerateInfo)
                counter += 1
            End While


        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            objCn.Close()
        End Try

        Return arraylist

    End Function

    Public Function Search_By_UserGenerateInfo(ByVal col As String, ByVal search As String) As ArrayList

        Dim arraylist As New ArrayList
        Dim counter As Integer = 1

        objCmd = New SqlCommand
        objCmd.Connection = objCn

        Try
            objCn.Open()

            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.CommandText = "sp_Search_By_UserGenerateInfo"

            With objCmd.Parameters
                .Add("@search", SqlDbType.VarChar, 100).Value = search
                .Add("@col", SqlDbType.VarChar, 100).Value = col
            End With

            objReader = objCmd.ExecuteReader

            While (objReader.Read())
                Dim objUserGenerateInfo As New UserGenerateInfo

                objUserGenerateInfo.Description = objReader("Description")
                objUserGenerateInfo.UserGenerateInformationID = objReader("UserGenerateInformationID")
                objUserGenerateInfo.Value = objReader("Value")
                objUserGenerateInfo.Longitude = objReader("Long")
                objUserGenerateInfo.Latitude = objReader("Lat")
                objUserGenerateInfo.DateTime = objReader("DateTime")
                objUserGenerateInfo.PhoneNo = objReader("PhoneNumber")
                objUserGenerateInfo.Counter = counter

                arraylist.Add(objUserGenerateInfo)
                counter += 1
            End While


        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            objCn.Close()
        End Try

        Return arraylist

    End Function

    Public Function Delete_By_User(ByVal id As Integer) As Integer

        Dim rowAffected As Integer

        objCmd = New SqlCommand
        objCmd.Connection = objCn

        Try
            objCn.Open()

            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.CommandText = "sp_Delete_By_User"

            With objCmd.Parameters
                .Add("@UserId", SqlDbType.Int).Value = id
            End With

            rowAffected = objCmd.ExecuteNonQuery()

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            objCn.Close()
        End Try

        Return rowAffected

    End Function

    Public Function Delete_By_UserGenerateInfo(ByVal id As Integer) As Integer

        Dim rowAffected As Integer

        objCmd = New SqlCommand
        objCmd.Connection = objCn

        Try
            objCn.Open()

            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.CommandText = "sp_Delete_By_UserGenerateInfo"

            With objCmd.Parameters
                .Add("@UserGenerateInformationId", SqlDbType.Int).Value = id
            End With

            rowAffected = objCmd.ExecuteNonQuery()

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            objCn.Close()
        End Try

        Return rowAffected

    End Function

    Public Function Add_User(ByVal objData As User) As Integer

        Dim identity As Integer
        Dim objDBMis As New DBMis

        objCmd = New SqlCommand
        objCmd.Connection = objCn

        Try
            objCn.Open()

            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.CommandText = "sp_Add_User"

            With objCmd.Parameters
                .Add("@loginID", SqlDbType.VarChar, 50).Value = objData.LoginId
                .Add("@password", SqlDbType.VarChar, 50).Value = objDBMis.GenerateHash(objData.Password)
                .Add("@type", SqlDbType.VarChar, 50).Value = objData.Type
                .Add("@address", SqlDbType.VarChar, 50).Value = objData.Address
                .Add("@dob", SqlDbType.VarChar, 50).Value = objData.Dob
                .Add("@email", SqlDbType.VarChar, 50).Value = objData.Email
                .Add("@gender", SqlDbType.VarChar, 50).Value = objData.Gender
                .Add("@name", SqlDbType.VarChar, 50).Value = objData.Name
                .Add("@telephone", SqlDbType.VarChar, 50).Value = objData.Telephone
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

    Public Function Add_UserGenerateInfo(ByVal objData As UserGenerateInfo) As Integer

        Dim rowAffected As Integer

        objCmd = New SqlCommand
        objCmd.Connection = objCn

        Try
            objCn.Open()

            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.CommandText = "sp_Add_UserGenerateInfo"

            With objCmd.Parameters
                .Add("@description", SqlDbType.VarChar, 50).Value = objData.Description
                .Add("@value", SqlDbType.VarChar, 50).Value = objData.Value
            End With

            rowAffected = objCmd.ExecuteNonQuery()

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            objCn.Close()
        End Try

        Return rowAffected

    End Function

    Public Function Change_Password(ByVal objData As User) As Integer

        Dim rowAffected As Integer
        Dim objDBMis As New DBMis

        objCmd = New SqlCommand
        objCmd.Connection = objCn

        Try
            objCn.Open()

            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.CommandText = "sp_Change_Password"

            With objCmd.Parameters
                .Add("@userID", SqlDbType.Int).Value = objData.UserId
                .Add("@password", SqlDbType.VarChar, 50).Value = objDBMis.GenerateHash(objData.Password)
            End With

            rowAffected = objCmd.ExecuteNonQuery()

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            objCn.Close()
        End Try

        Return rowAffected

    End Function

    Public Function Update_UserGenerateInfo(ByVal objData As UserGenerateInfo) As Integer

        Dim rowAffected As Integer

        objCmd = New SqlCommand
        objCmd.Connection = objCn

        Try
            objCn.Open()

            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.CommandText = "sp_Update_UserGenerateInfo"

            With objCmd.Parameters
                .Add("@userGenerateInformationId", SqlDbType.Int).Value = objData.UserGenerateInformationID
                .Add("@description", SqlDbType.VarChar, 50).Value = objData.Description
                .Add("@value", SqlDbType.VarChar, 50).Value = objData.Value
            End With

            rowAffected = objCmd.ExecuteNonQuery()

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            objCn.Close()
        End Try

        Return rowAffected

    End Function

    Public Function Update_User(ByVal objData As User, ByVal status As String) As Integer

        Dim rowAffected As Integer
        Dim objDBMis As New DBMis

        objCmd = New SqlCommand
        objCmd.Connection = objCn

        Try
            objCn.Open()

            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.CommandText = "sp_Update_User"

            With objCmd.Parameters
                .Add("@userId", SqlDbType.Int).Value = objData.UserId

                If status.Equals("hash") Then
                    .Add("@password", SqlDbType.NChar, 50).Value = objData.Password
                Else
                    .Add("@password", SqlDbType.NChar, 50).Value = objDBMis.GenerateHash(objData.Password)
                End If

                .Add("@type", SqlDbType.NChar, 50).Value = objData.Type
                .Add("@address", SqlDbType.NChar, 50).Value = objData.Address
                .Add("@dob", SqlDbType.NChar, 50).Value = objData.Dob
                .Add("@email", SqlDbType.NChar, 50).Value = objData.Email
                .Add("@gender", SqlDbType.NChar, 50).Value = objData.Gender
                .Add("@name", SqlDbType.NChar, 50).Value = objData.Name
                .Add("@telephone", SqlDbType.NChar, 50).Value = objData.Telephone
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
