Imports Microsoft.VisualBasic

Public Class Trip
    Inherits Vehicle

    Private mTripID As Integer
    Private mVehicleConfigurationID As Integer
    Private mOptimumSpeed As Integer
    Private mWeightOfVehicle As Integer
    Private mLocation As String ' 50 char
    Private mWeatherCondition As String ' 50 char
    Private mDistanceTravelled As Integer
    Private mStartTime As String ' datetime
    Private mEndTime As String ' datetime
    Private mFuelUsage As Integer
    Private mMaxGForce As Double ' decimal(18, 2)
    Private mHorsepower As Double ' decimal(18, 2)
    Private mCounter As Integer

    Property TripID() As Integer
        Get
            Return mTripID
        End Get
        Set(ByVal value As Integer)
            mTripID = value
        End Set
    End Property

    Property VehicleConfigurationID() As Integer
        Get
            Return mVehicleConfigurationID
        End Get
        Set(ByVal value As Integer)
            mVehicleConfigurationID = value
        End Set
    End Property

    Property OptimumSpeed() As Integer
        Get
            Return mOptimumSpeed
        End Get
        Set(ByVal value As Integer)
            mOptimumSpeed = value
        End Set
    End Property

    Property WeightOfVehicle() As Integer
        Get
            Return mWeightOfVehicle
        End Get
        Set(ByVal value As Integer)
            mWeightOfVehicle = value
        End Set
    End Property

    Property Location() As String
        Get
            Return mLocation
        End Get
        Set(ByVal value As String)
            mLocation = value
        End Set
    End Property

    Property WeatherCondition() As String
        Get
            Return mWeatherCondition
        End Get
        Set(ByVal value As String)
            mWeatherCondition = value
        End Set
    End Property

    Property DistanceTravelled() As Integer
        Get
            Return mDistanceTravelled
        End Get
        Set(ByVal value As Integer)
            mDistanceTravelled = value
        End Set
    End Property

    Property StartTime() As String
        Get
            Return mStartTime
        End Get
        Set(ByVal value As String)
            mStartTime = value
        End Set
    End Property

    Property EndTime() As String
        Get
            Return mEndTime
        End Get
        Set(ByVal value As String)
            mEndTime = value
        End Set
    End Property

    Property FuelUsage() As Integer
        Get
            Return mFuelUsage
        End Get
        Set(ByVal value As Integer)
            mFuelUsage = value
        End Set
    End Property

    Property MaxGForce() As Double
        Get
            Return mMaxGForce
        End Get
        Set(ByVal value As Double)
            mMaxGForce = value
        End Set
    End Property

    Property Horsepower() As Double
        Get
            Return mHorsepower
        End Get
        Set(ByVal value As Double)
            mHorsepower = value
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
End Class
