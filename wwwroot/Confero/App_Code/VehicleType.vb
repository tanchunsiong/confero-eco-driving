Imports Microsoft.VisualBasic

Public Class VehicleType

    Private mVehicleTypeID As Integer
    Private mDescription As String
    Private mCounter As Integer

    Property VehicleTypeID() As Integer
        Get
            Return mVehicleTypeID
        End Get
        Set(ByVal value As Integer)
            mVehicleTypeID = value
        End Set
    End Property

    Property Description() As String
        Get
            Return mDescription
        End Get
        Set(ByVal value As String)
            mDescription = value
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
