Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient
Imports System.Data
Imports System.Windows.Forms
Imports Microsoft.Windows.Controls


Public Class MainWindow
    Dim patient As String
    Dim detailsTab As TabItem = TabItem1
    Dim lastVisitTab As TabItem = TabItem2
    Dim prescriptionTab As TabItem = TabItem3
    Dim medicineList As List(Of MedicineMapping) = New List(Of MedicineMapping)
    Dim mList As Collection = New Collection()
    Dim repetitionsList As List(Of String) = New List(Of String)(New String() {"1-0-1", "1-1-1", "0-1-0", "0-0-1", "1-0-0", "0-1-1", "1-1-0"})

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Loaded
        Me.Top = 0
        Me.Left = 0
        Me.Height = Screen.PrimaryScreen.WorkingArea.Height
        Me.Width = Screen.PrimaryScreen.WorkingArea.Width
        Dim conn As New MySqlConnection

        Dim details As String = "select patientId,CONCAT(patientName,' ',surname) from patient;"
        conn.ConnectionString = DataAccess.GetConnectionString("databaseConnection")
        DataAccess.HandleConnection(conn)
        Dim cmd = New MySqlCommand(details, conn)
        Dim patients As List(Of Patient) = New List(Of Patient)
        Dim reader As MySqlDataReader = cmd.ExecuteReader()

        While reader.Read
            patients.Add(New Patient(reader.GetString(0), reader.GetString(1)))
        End While

        'Dim da As MySqlDataAdapter = New MySqlDataAdapter(details, conn)
        'Dim theTable As DataTable = New DataTable()
        ' da.Fill(theTable)


        Me.autotextbox.ItemsSource = New CollectionView(patients)
        'Me.autotextbox.ValueMemberPath = "patientName"

    End Sub





    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button1.Click
        patient = Me.autotextbox.Text
        Dim conn As New MySqlConnection
        Dim details As String = "select * from patient where patientid=@patient OR CONCAT(patientname,' ',surname)=@patient"
        conn.ConnectionString = DataAccess.GetConnectionString("databaseConnection")
        DataAccess.HandleConnection(conn)
        Dim details_sqlCommand As MySqlCommand = New MySqlCommand(details, conn)
        details_sqlCommand.Parameters.AddWithValue("@patient", patient)

        Dim patientData As MySqlDataReader = details_sqlCommand.ExecuteReader()
        If patientData.HasRows = False Then
            System.Windows.MessageBox.Show("No such patient found")
            If (Not IsNothing(detailsTab)) Then
                detailsTab.Content = ""
            End If
            If (Not IsNothing(lastVisitTab)) Then
                lastVisitTab.Content = ""
            End If
            If (Not IsNothing(prescriptionTab)) Then
                prescriptionTab.Content = ""
            End If
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

        DataAccess.HandleConnection(conn)

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
            Dim collectionMedicines5 As CollectionView = New CollectionView(medicineList)


            prescription.patientId.Content = patientId
            prescription.medicine1.ItemsSource = collectionMedicines1
            prescription.medicine2.ItemsSource = collectionMedicines2
            prescription.medicine3.ItemsSource = collectionMedicines3
            prescription.medicine4.ItemsSource = collectionMedicines4
            prescription.medicine5.ItemsSource = collectionMedicines5
            prescription.repetition1.ItemsSource = repetitionsList
            prescription.repetition2.ItemsSource = repetitionsList
            prescription.repetition3.ItemsSource = repetitionsList
            prescription.repetition4.ItemsSource = repetitionsList
            prescription.repetition5.ItemsSource = repetitionsList


            prescriptionTab.Content = prescription


        End If




        conn.Close()


    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button2.Click
        Dim newPatientWindow As NewPatient = New NewPatient()
        newPatientWindow.Show()
        newPatientWindow.Focus()
    End Sub

    Private Sub TabControl1_SelectionChanged(ByVal sender As System.Object, ByVal e As System.Windows.Controls.SelectionChangedEventArgs) Handles TabControl1.SelectionChanged

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button3.Click
        Dim newMedicineWindow As NewMedicine = New NewMedicine()
        newMedicineWindow.Show()
        newMedicineWindow.Focus()
    End Sub

    Private Sub autotextbox_TextChanged(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles autotextbox.TextChanged
        

    End Sub
End Class
