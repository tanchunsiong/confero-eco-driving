Imports Microsoft.VisualBasic

Public Class User

    Private mUserId As Integer
    Private mLoginId As String
    Private mPassword As String
    Private mType As String
    Private mCounter As Integer
    Private mName As String
    Private mAddress As String
    Private mTelephone As String
    Private mGender As String
    Private mEmail As String
    Private mDob As String

    Property UserId() As Integer
        Get
            Return mUserId
        End Get
        Set(ByVal value As Integer)
            mUserId = value
        End Set
    End Property

    Property LoginId() As String
        Get
            Return mLoginId
        End Get
        Set(ByVal value As String)
            mLoginId = value
        End Set
    End Property

    Property Password() As String
        Get
            Return mPassword
        End Get
        Set(ByVal value As String)
            mPassword = value
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

    Property Counter() As Integer
        Get
            Return mCounter
        End Get
        Set(ByVal value As Integer)
            mCounter = value
        End Set
    End Property

    Property Name() As String
        Get
            Return mName
        End Get
        Set(ByVal value As String)
            mName = value
        End Set
    End Property

    Property Address() As String
        Get
            Return mAddress
        End Get
        Set(ByVal value As String)
            mAddress = value
        End Set
    End Property

    Property Telephone() As String
        Get
            Return mTelephone
        End Get
        Set(ByVal value As String)
            mTelephone = value
        End Set
    End Property

    Property Gender() As String
        Get
            Return mGender
        End Get
        Set(ByVal value As String)
            mGender = value
        End Set
    End Property

    Property Email() As String
        Get
            Return mEmail
        End Get
        Set(ByVal value As String)
            mEmail = value
        End Set
    End Property

    Property Dob() As String
        Get
            Return mDob
        End Get
        Set(ByVal value As String)
            mDob = value
        End Set
    End Property

End Class
