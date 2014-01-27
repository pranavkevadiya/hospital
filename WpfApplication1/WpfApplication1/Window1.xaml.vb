Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient
Imports System.Data

Public Class Window1
    Dim patient As String
    Dim detailsTab As TabItem
    Dim lastVisitTab As TabItem
    Dim prescriptionTab As TabItem
    Dim medicineList As List(Of MedicineMapping) = New List(Of MedicineMapping)
    Dim mList As Collection = New Collection()
    Dim repetitionsList As List(Of String) = New List(Of String)(New String() {"1-0-1", "1-1-1", "0-1-0", "0-0-1"})







    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button1.Click
        patient = TextBox1.Text
        Dim conn As New MySqlConnection
        Dim details As String = "select * from patient where patientid=@patient OR patientname=@patient"
        conn.ConnectionString = DataAccess.GetConnectionString("databaseConnection")
        DataAccess.HandleConnection(conn)
        Dim details_sqlCommand As MySqlCommand = New MySqlCommand(details, conn)
        details_sqlCommand.Parameters.AddWithValue("@patient", patient)

        Dim patientData As MySqlDataReader = details_sqlCommand.ExecuteReader()
        If patientData.HasRows = False Then
            MessageBox.Show("No such patient found")
            detailsTab.Content = ""
            lastVisitTab.Content = ""
            prescriptionTab.Content = ""
            Return
        End If

        Dim detailsControl = New PatientDetails()
        Dim patientId As String = ""
        While patientData.Read()
            patientId = patientData.GetString("patientId")
            Dim patientname As String = patientData.GetString("patientname")
            patientname = patientname + " " + patientData.GetString("surname")
            detailsControl.patientNameProperty = patientname
            detailsControl.addressProperty = patientData.GetString("Address")
            detailsControl.moProperty = patientData.GetString("mo")
            detailsControl.genderProperty = patientData.GetString("gender")
            Dim dob As Date = patientData.GetDateTime("dob")

            Dim age As Integer = "0"
            If Not IsDBNull(dob) Then
                detailsControl.dobProperty = dob.ToString("dd-MMM-yyyy")
                Dim ageDays As TimeSpan = Date.Now - dob
                age = ageDays.TotalDays / 365
            End If

            detailsControl.ageProperty = age


        End While

        detailsTab = TabItem1
        lastVisitTab = TabItem2
        prescriptionTab = TabItem3



        detailsTab.Content = detailsControl
        patientData.Close()

        Dim visitinfo As VisitInfoPage = New VisitInfoPage()
        visitinfo.populateVisitDetails(conn, patientId, lastVisitTab)

        If (Not String.IsNullOrEmpty(patientId)) Then

            Dim prescription As Prescription = New Prescription()
            If (medicineList.Count = 0) Then


                Dim medicineFetch = "select CONCAT(medicineName,'-',power),medicineId from medicine"
                Dim medicineFetchCmd = New MySqlCommand(medicineFetch, conn)

                Dim medicinesReader As MySqlDataReader = medicineFetchCmd.ExecuteReader()

                While medicinesReader.Read()
                    medicineList.Add(New MedicineMapping(medicinesReader.GetString(1), medicinesReader.GetString(0)))
                End While
                medicinesReader.Close()
                conn.Close()

            End If

            Dim collectionMedicines1 As CollectionView = New CollectionView(medicineList)
            Dim collectionMedicines2 As CollectionView = New CollectionView(medicineList)
            Dim collectionMedicines3 As CollectionView = New CollectionView(medicineList)
            Dim collectionMedicines4 As CollectionView = New CollectionView(medicineList)

           
            prescription.patientId.Content = patientId
            prescription.medicine1.ItemsSource = collectionMedicines1
            prescription.medicine2.ItemsSource = collectionMedicines2
            prescription.medicine3.ItemsSource = collectionMedicines3
            prescription.medicine4.ItemsSource = collectionMedicines4
            prescription.repetition1.ItemsSource = repetitionsList
            prescription.repetition2.ItemsSource = repetitionsList
            prescription.repetition3.ItemsSource = repetitionsList
            prescription.repetition4.ItemsSource = repetitionsList


            prescriptionTab.Content = prescription


        End If




        conn.Close()


    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button2.Click
        Dim newPatientWindow As NewPatient = New NewPatient()
        newPatientWindow.Show()
        newPatientWindow.Focus()
    End Sub
End Class
