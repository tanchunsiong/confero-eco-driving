Imports Microsoft.VisualBasic

Public Class VehicleOwnership

    Private mOwnershipID As Integer
    Private mUserID As Integer
    Private mVehicleID As Integer
    Private mCounter As Integer
    Private mUserName As String

    Property OwnershipID() As Integer
        Get
            Return mOwnershipID
        End Get
        Set(ByVal value As Integer)
            mOwnershipID = value
        End Set
    End Property

    Property UserID() As Integer
        Get
            Return mUserID
        End Get
        Set(ByVal value As Integer)
            mUserID = value
        End Set
    End Property

    Property VehicleID() As Integer
        Get
            Return mVehicleID
        End Get
        Set(ByVal value As Integer)
            mVehicleID = value
        End Set
    End Property

    Property Counter() As Integer
        Get
            Return mCounter
        End Get
        Set(ByVal value As Integer)
            mCounter = value
        End Set
    End Property

    Property UserName() As String
        Get
            Return mUserName
        End Get
        Set(ByVal value As String)
            mUserName = value
        End Set
    End Property

End Class
