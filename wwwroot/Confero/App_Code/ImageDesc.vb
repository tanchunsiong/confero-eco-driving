Imports Microsoft.VisualBasic

Public Class ImageDesc
    Private mGalleryId As Integer
    Private mPropertyId As String
    Private mUrl As String
    Private mStatus As String
    Private mDescription As String
    Private mCounter As Integer

    Property GalleryId() As Integer
        Get
            Return mGalleryId
        End Get
        Set(ByVal value As Integer)
            mGalleryId = value
        End Set
    End Property


    Property Url() As String
        Get
            Return mUrl
        End Get
        Set(ByVal value As String)
            mUrl = value
        End Set
    End Property

    Property Status() As String
        Get
            Return mStatus
        End Get
        Set(ByVal value As String)
            mStatus = value
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
