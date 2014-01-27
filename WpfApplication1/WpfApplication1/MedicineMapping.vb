Public Class MedicineMapping
    Dim medicineID As String
    Dim medicineName As String



    Sub New(ByVal id As String, ByVal name As String)
        ' Call MyBase.New if this is a derived class. 
        medicineID = id
        medicineName = name

        ' Place initialization statements here. 
    End Sub
    Public Property medicineIdProperty() As String
        Get
            Return medicineID

        End Get
        Set(ByVal value As String)
            medicineID = value
        End Set
    End Property
   


    Public Property medicineNameProperty() As String
        Get
            Return medicineName
        End Get
        Set(ByVal value As String)
            medicineName = value
        End Set
    End Property
End Class
