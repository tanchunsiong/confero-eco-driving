Imports Microsoft.VisualBasic

Public Class VehicleConfiguration

    Private mVehicleConfigurationID As Integer
    Private mVehicleID As Integer
    Private mPropellentID As Integer
    Private mTyreID As Integer
    Private mCounter As Integer

    Property VehicleConfigurationID() As Integer
        Get
            Return mVehicleConfigurationID
        End Get
        Set(ByVal value As Integer)
            mVehicleConfigurationID = value
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

    Property PropellentID() As Integer
        Get
            Return mPropellentID
        End Get
        Set(ByVal value As Integer)
            mPropellentID = value
        End Set
    End Property

    Property TyreID() As Integer
        Get
            Return mTyreID
        End Get
        Set(ByVal value As Integer)
            mTyreID = value
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

End Class
