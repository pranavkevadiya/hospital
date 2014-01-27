Public Class PatientDetails
    Private patientName As String
    Public Property patientNameProperty() As String
        Get
            Return patientName
        End Get
        Set(ByVal value As String)
            'If value <> vbNull Then
            patientName = value
            Me.patientNameValueLabel.Content = value
            'End If
        End Set
    End Property

    Private dob As String
    Public Property dobProperty() As String
        Get
            Return dob
        End Get
        Set(ByVal value As String)
            'If value <> vbNull Then
            dob = value
            Me.dobValueLabel.Content = value
            'End If
        End Set
    End Property


    Private address As String
    Public Property addressProperty() As String
        Get
            Return address
        End Get
        Set(ByVal value As String)
            'If value <> vbNull Then
            address = value
            Me.addressValueLabel.Content = value
            'End If
        End Set
    End Property

    Private gender As String
    Public Property genderProperty() As String
        Get
            Return gender
        End Get
        Set(ByVal value As String)
            'If value <> vbNull Then
            gender = value
            Me.genderValueLabel.Content = value
            'End If
        End Set
    End Property

    Private mo As String
    Public Property moProperty() As String
        Get
            Return mo
        End Get
        Set(ByVal value As String)
            'If value <> vbNull Then
            mo = value
            Me.moValueLabel.Content = value
            'End If
        End Set
    End Property

    Private age As String
    Public Property ageProperty() As String
        Get
            Return age
        End Get
        Set(ByVal value As String)
            'If value <> vbNull Then
            age = value
            Me.ageValueLabel.Content = value
            'End If
        End Set
    End Property
    
End Class
