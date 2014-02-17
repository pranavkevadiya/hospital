Public Class Patient
    Dim mPatientName As String
    Dim mPatientID As String
    Public Sub New(ByVal id As String, ByVal name As String)
        mPatientID = id
        mPatientName = name
    End Sub
    Public Property patientName() As String
        Get
            Return mPatientName
        End Get
        Set(ByVal value As String)
            mPatientName = value
        End Set
    End Property
    Public Property patientId() As String
        Get
            Return mPatientID
        End Get
        Set(ByVal value As String)
            mPatientID = value
        End Set
    End Property
End Class
