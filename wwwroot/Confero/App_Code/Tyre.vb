Imports Microsoft.VisualBasic

Public Class Tyre

    Private mTyreID As Integer
    Private mBrand As String ' 50 char
    Private mWidth As String ' 50 char
    Private mTyreSize As String ' 50 char
    Private mMaterial As String ' 50 char
    Private mRollingResistance As String ' 50 char
    Private mCounter As Integer
    Private mModel As String ' 50 char
    Private mType As String ' 15 char
    Private mPressure As String
    Private mCarMake As String
    Private mCarModel As String

    Property TyreID() As Integer
        Get
            Return mTyreID
        End Get
        Set(ByVal value As Integer)
            mTyreID = value
        End Set
    End Property

    Property Brand() As String
        Get
            Return mBrand
        End Get
        Set(ByVal value As String)
            mBrand = value
        End Set
    End Property

    Property Width() As String
        Get
            Return mWidth
        End Get
        Set(ByVal value As String)
            mWidth = value
        End Set
    End Property

    Property TyreSize() As String
        Get
            Return mTyreSize
        End Get
        Set(ByVal value As String)
            mTyreSize = value
        End Set
    End Property

    Property Material() As String
        Get
            Return mMaterial
        End Get
        Set(ByVal value As String)
            mMaterial = value
        End Set
    End Property

    Property RollingResistance() As String
        Get
            Return mRollingResistance
        End Get
        Set(ByVal value As String)
            mRollingResistance = value
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

    Property Model() As String
        Get
            Return mModel
        End Get
        Set(ByVal value As String)
            mModel = value
        End Set
    End Property

    Property Type() As String
        Get
            Return mType
        End Get
        Set(ByVal value As String)
            mType = value
        End Set
    End Property

    Property Pressure() As String
        Get
            Return mPressure
        End Get
        Set(ByVal value As String)
            mPressure = value
        End Set
    End Property

    Property CarMake() As String
        Get
            Return mCarMake
        End Get
        Set(ByVal value As String)
            mCarMake = value
        End Set
    End Property

    Property CarModel() As String
        Get
            Return mCarModel
        End Get
        Set(ByVal value As String)
            mCarModel = value
        End Set
    End Property
End Class
