Public Class SMS
    Private mprocessedReceivedSMS As Integer
    Private mSentSMSID As Integer
    Private mmessage As String
    Private mdestinationAddress As String
    Private mSourcePhoneNumber As String
    Private mdatetimereceived As Date
    Private mdatetimesent As Date
    Private mreceivedByUserID As Integer
    Private mownerID As Integer
    Private mReferenceNo As String
    Private msuccessful As String
    Private mpendingSMSID As Integer
    Private mmessageSubscriptionID As String
    Private mreportingID As String
    Private mdatetimeOfFailure As Date
    Private mrecipientOfReport As String
    Private mreasonForReport As String

    Property reportingID() As String
        Get
            Return mreportingID
        End Get
        Set(ByVal value As String)
            mreportingID = value
        End Set
    End Property
    Property datetimeOfFailure() As Date
        Get
            Return mdatetimeOfFailure
        End Get
        Set(ByVal value As Date)
            mdatetimeOfFailure = value
        End Set
    End Property
    Property recipientOfReport() As String
        Get
            Return mrecipientOfReport
        End Get
        Set(ByVal value As String)
            mrecipientOfReport = value
        End Set
    End Property
    Property reasonForReport() As String
        Get
            Return mreasonForReport
        End Get
        Set(ByVal value As String)
            mreasonForReport = value
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
    Property pendingSMSID() As Integer
        Get
            Return mpendingSMSID
        End Get
        Set(ByVal value As Integer)
            mpendingSMSID = value
        End Set
    End Property
    Property successful() As String
        Get
            Return msuccessful
        End Get
        Set(ByVal value As String)
            msuccessful = value
        End Set
    End Property

    Property ReferenceNo() As String
        Get
            Return mReferenceNo
        End Get
        Set(ByVal value As String)
            mreceivedByUserID = value
        End Set
    End Property
    Property ownerID() As Integer
        Get
            Return mownerID
        End Get
        Set(ByVal value As Integer)
            mownerID = value
        End Set
    End Property
    Property receivedByUserID() As Integer
        Get
            Return mreceivedByUserID
        End Get
        Set(ByVal value As Integer)
            mreceivedByUserID = value
        End Set
    End Property
    Property SentSMSID() As Integer
        Get
            Return mSentSMSID
        End Get
        Set(ByVal value As Integer)
            mSentSMSID = value
        End Set
    End Property

    Property processedReceivedSMS() As Integer
        Get
            Return mprocessedReceivedSMS
        End Get
        Set(ByVal value As Integer)
            mprocessedReceivedSMS = value
        End Set
    End Property

    Property message() As String
        Get
            Return mmessage
        End Get
        Set(ByVal value As String)
            mmessage = value
        End Set
    End Property
    Property destinationAddress() As String
        Get
            Return mdestinationAddress
        End Get
        Set(ByVal value As String)
            mdestinationAddress = value
        End Set
    End Property
    Property SourcePhoneNumber() As String
        Get
            Return mSourcePhoneNumber
        End Get
        Set(ByVal value As String)
            mSourcePhoneNumber = value
        End Set
    End Property
    Property datetimereceived() As Date
        Get
            Return mdatetimereceived
        End Get
        Set(ByVal value As Date)
            mdatetimereceived = value
        End Set
    End Property
    Property datetimesent() As Date
        Get
            Return mdatetimesent
        End Get
        Set(ByVal value As Date)
            mdatetimesent = value
        End Set
    End Property

End Class
