Imports Microsoft.VisualBasic

Public Class UserGenerateInfo

    Private mUserGenerateInformationID As Integer
    Private mDescription As String ' 250 char
    Private mValue As String ' 50 char
    Private mCounter As Integer
    Private mLong As String ' 10 char
    Private mLat As String ' 10 char
    Private mDateTime As String ' datetime
    Private mPhoneNo As String '  50 char

    Property UserGenerateInformationID() As Integer
        Get
            Return mUserGenerateInformationID
        End Get
        Set(ByVal value As Integer)
            mUserGenerateInformationID = value
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

    Property Value() As String
        Get
            Return mValue
        End Get
        Set(ByVal value As String)
            mValue = value
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

    Property Longitude() As String
        Get
            Return mLong
        End Get
        Set(ByVal value As String)
            mLong = value
        End Set
    End Property

    Property Latitude() As String
        Get
            Return mLat
        End Get
        Set(ByVal value As String)
            mLat = value
        End Set
    End Property

    Property DateTime() As String
        Get
            Return mDateTime
        End Get
        Set(ByVal value As String)
            mDateTime = value
        End Set
    End Property

    Property PhoneNo() As String
        Get
            Return mPhoneNo
        End Get
        Set(ByVal value As String)
            mPhoneNo = value
        End Set
    End Property
End Class
