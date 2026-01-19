Imports Microsoft.VisualBasic

Public Class Setting
    Private mSettingId As Integer
    Private mAttempts As Integer
    Private mTimeout As Integer

    Property SettingId() As Integer
        Get
            Return mSettingId
        End Get
        Set(ByVal value As Integer)
            mSettingId = value
        End Set
    End Property

    Property Attempts() As Integer
        Get
            Return mAttempts
        End Get
        Set(ByVal value As Integer)
            mAttempts = value
        End Set
    End Property

    Property Timeout() As Integer
        Get
            Return mTimeout
        End Get
        Set(ByVal value As Integer)
            mTimeout = value
        End Set
    End Property
End Class
