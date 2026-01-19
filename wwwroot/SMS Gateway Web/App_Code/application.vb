Public Class application
    Dim mappname As String
    Dim muserid As Integer
    Dim mappid As Integer
    Dim mnoofsms As Integer
    Dim mmessagesubscriptionID As String

    Property appname() As String
        Get
            Return mappname
        End Get
        Set(ByVal value As String)
            mappname = value
        End Set
    End Property
    Property userid() As Integer
        Get
            Return muserid
        End Get
        Set(ByVal value As Integer)
            muserid = value
        End Set
    End Property
    Property appid() As Integer
        Get
            Return mappid
        End Get
        Set(ByVal value As Integer)
            mappid = value
        End Set
    End Property
    Property noofsms() As Integer
        Get
            Return mnoofsms
        End Get
        Set(ByVal value As Integer)
            mnoofsms = value
        End Set
    End Property
    Property messagesubscriptionID() As String
        Get
            Return mmessagesubscriptionID
        End Get
        Set(ByVal value As String)
            mmessagesubscriptionID = value
        End Set
    End Property


End Class
