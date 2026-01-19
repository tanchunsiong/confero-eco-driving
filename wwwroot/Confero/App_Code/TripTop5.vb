Imports Microsoft.VisualBasic

Public Class TripTop5
    Private mTyreID As Integer
    Private mBrand As String ' 50 char
    Private mWidth As String ' 50 char
    Private mTyreSize As String ' 50 char
    Private mMaterial As String ' 50 char
    Private mRollingResistance As String ' 50 char
    Private mCounter As Integer
    Private mModel As String ' 50 char
    Private mType As String ' 15 char

    Private mOctane As String '50 char
    Private mPBrand As String '50 char
    Private mDescription As String '10 char

    Private mDistanceTravelled As Integer
    Private mFuelUsage As Integer

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
    '________________________________________________________

    Property Octane() As String
        Get
            Return mOctane
        End Get
        Set(ByVal value As String)
            mOctane = value
        End Set
    End Property

    Property PBrand() As String
        Get
            Return mPBrand
        End Get
        Set(ByVal value As String)
            mPBrand = value
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
    '__________________________________________________________________

    Property DistanceTravelled() As Integer
        Get
            Return mDistanceTravelled
        End Get
        Set(ByVal value As Integer)
            mDistanceTravelled = value
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
End Class
