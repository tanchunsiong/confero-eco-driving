Imports Microsoft.VisualBasic

Public Class Vehicle
    Inherits VehicleType

    Private mVehicleID As Integer
    'Private mVehicleTypeID As Integer
    Private mModel As String ' 50 char
    Private mMake As String ' 50 char
    Private mYears As String ' 50 char
    Private mCapacity As String ' 50 char
    'Private mCounter As Integer
    Private mUserName As String
    Private mVehicleConfigureID As Integer

    Property VehicleID() As Integer
        Get
            Return mVehicleID
        End Get
        Set(ByVal value As Integer)
            mVehicleID = value
        End Set
    End Property

    'Property VehicleTypeID() As Integer
    '    Get
    '        Return mVehicleTypeID
    '    End Get
    '    Set(ByVal value As Integer)
    '        mVehicleTypeID = value
    '    End Set
    'End Property

    Property Model() As String
        Get
            Return mModel
        End Get
        Set(ByVal value As String)
            mModel = value
        End Set
    End Property

    Property Make() As String
        Get
            Return mMake
        End Get
        Set(ByVal value As String)
            mMake = value
        End Set
    End Property

    Property Years() As String
        Get
            Return mYears
        End Get
        Set(ByVal value As String)
            mYears = value
        End Set
    End Property

    Property Capacity() As String
        Get
            Return mCapacity
        End Get
        Set(ByVal value As String)
            mCapacity = value
        End Set
    End Property

    'Property Counter() As Integer
    '    Get
    '        Return mCounter
    '    End Get
    '    Set(ByVal value As Integer)
    '        mCounter = value
    '    End Set
    'End Property

    Property UserName() As String
        Get
            Return mUserName
        End Get
        Set(ByVal value As String)
            mUserName = value
        End Set
    End Property

    Property VehicleConfigureID() As Integer
        Get
            Return mVehicleConfigureID
        End Get
        Set(ByVal value As Integer)
            mVehicleConfigureID = value
        End Set
    End Property
End Class
