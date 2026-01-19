Imports Microsoft.VisualBasic

Public Class Propellent
 
    Private mPropellentID As Integer
    Private mPropellentTypeID As Integer
    Private mOctane As String '50 char
    Private mBrand As String '50 char
    Private mDescription As String '10 char
    Private mCounter As Integer

    Private mMake As String
    Private mModel As String

    Property PropellentID() As Integer
        Get
            Return mPropellentID
        End Get
        Set(ByVal value As Integer)
            mPropellentID = value
        End Set
    End Property

    Property PropellentTypeID() As Integer
        Get
            Return mPropellentTypeID
        End Get
        Set(ByVal value As Integer)
            mPropellentTypeID = value
        End Set
    End Property

    Property Octane() As String
        Get
            Return mOctane
        End Get
        Set(ByVal value As String)
            mOctane = value
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
End Class
