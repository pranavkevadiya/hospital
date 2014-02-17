Public Class VisitInformation


    Private mVisitDate As String
    Private mDisease As String
    Private mMedication As String
    Private mNote As String

    Public Property visitDate() As String
        Get
            Return mVisitDate
        End Get
        Set(ByVal value As String)
            'If value <> vbNull Then
            mVisitDate = value
            'End If
        End Set
    End Property
    Public Property disease() As String
        Get
            Return mDisease
        End Get
        Set(ByVal value As String)
            'If value <> vbNull Then
            mDisease = value
            'End If
        End Set
    End Property
    Public Property medication() As String
        Get
            Return mMedication
        End Get
        Set(ByVal value As String)
            'If value <> vbNull Then
            mMedication = value
            'End If
        End Set
    End Property

    Public Property note() As String
        Get
            Return mNote

        End Get
        Set(ByVal value As String)
            'If value <> vbNull Then
            mNote = value
            'End If
        End Set
    End Property


End Class

