Public Class PrescriptionInfo
    Dim medicine As String

    Public Sub New(ByVal med As String, ByVal rep As String, ByVal quan As String)
        medicine = med
        repetition = rep
        quantity = quan

    End Sub

    Public Property medicineProperty() As String
        Get
            Return medicine
        End Get
        Set(ByVal value As String)
            medicine = value
        End Set
    End Property

    Private repetition As String
    Public Property repetitionProperty() As String
        Get
            Return repetition
        End Get
        Set(ByVal value As String)
            repetition = value
        End Set
    End Property
    Private quantity As Integer
    Public Property quantityProperty() As Integer
        Get
            Return quantity
        End Get
        Set(ByVal value As Integer)
            quantity = value
        End Set
    End Property

End Class
