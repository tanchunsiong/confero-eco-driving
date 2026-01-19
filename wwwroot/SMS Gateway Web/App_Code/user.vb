Public Class user
    Private muserID As Integer
    Private mcounter As Integer
    Private mpassword As String
    Private mmessageSubscriptionID As String
    Private musername As String
    Private mtype As String
    Private mmobilenumber As String
    Private mstatus As String
    Private mcurrentUsage As Integer
    Private mtotallimit As Integer
    Private mSMSLeft As Integer
    Private mNoOfSMSReceived As Integer
    Property NoOfSMSReceived() As Integer
        Get
            Return mNoOfSMSReceived
        End Get
        Set(ByVal value As Integer)
            mNoOfSMSReceived = value
        End Set
    End Property

    Property messageSubscriptionID() As String
        Get
            Return mmessageSubscriptionID
        End Get
        Set(ByVal value As String)
            mmessageSubscriptionID = value
        End Set
    End Property

    Property password() As String
        Get
            Return mpassword
        End Get
        Set(ByVal value As String)
            mpassword = value
        End Set
    End Property
    Property currentUsage() As Integer
        Get
            Return mcurrentUsage
        End Get
        Set(ByVal value As Integer)
            mcurrentUsage = value
        End Set
    End Property
    Property totallimit() As Integer
        Get
            Return mtotallimit
        End Get
        Set(ByVal value As Integer)
            mtotallimit = value
        End Set
    End Property
    Property SMSLeft() As Integer
        Get
            Return mSMSLeft
        End Get
        Set(ByVal value As Integer)
            mSMSLeft = value
        End Set
    End Property
    Property userID() As Integer
        Get
            Return muserID
        End Get
        Set(ByVal value As Integer)
            muserID = value
        End Set
    End Property

    Property counter() As Integer
        Get
            Return mcounter
        End Get
        Set(ByVal value As Integer)
            mcounter = value
        End Set
    End Property
    Property username() As String
        Get
            Return musername
        End Get
        Set(ByVal value As String)
            musername = value
        End Set
    End Property

    Property type() As String
        Get
            Return mtype
        End Get
        Set(ByVal value As String)
            mtype = value

        End Set
    End Property

    Property status() As String
        Get
            Return mstatus
        End Get
        Set(ByVal value As String)
            mstatus = value
        End Set
    End Property

    Property mobilenumber() As String
        Get
            Return mmobilenumber
        End Get
        Set(ByVal value As String)
            mmobilenumber = value
        End Set
    End Property
End Class
