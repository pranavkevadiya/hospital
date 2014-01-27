Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Windows.Forms.PrintDialog
Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient
Imports System.Data


Public Class Prescription
    Dim prescriptionsToPrint As String
    Dim prescriptions As List(Of PrescriptionInfo) = New List(Of PrescriptionInfo)
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button2.Click

        Dim patientId = Me.patientId.Content
        Try

            Dim con As MySqlConnection = New MySqlConnection(DataAccess.GetConnectionString("databaseConnection"))
            DataAccess.HandleConnection(con)
            Dim cmd = New MySqlCommand("select MAX(medicationId)+1 from visitinfo", con)
            Dim medicationId As String = cmd.ExecuteScalar()



            cmd.CommandText = "insert into visitinfo(patientId,medicationId,visitDate,isFirst,disease) values (@patientId,@medicationId,CURDATE(),0,1)"
            cmd.Parameters.AddWithValue("patientId", patientId)
            cmd.Parameters.AddWithValue("medicationId", medicationId)

            Dim resultInsert = cmd.ExecuteNonQuery()
            Dim count = 0
            If (resultInsert = 1) Then
                resultInsert = 0
                If (Not String.IsNullOrWhiteSpace(Me.repetition1.SelectedValue)) Then
                    count += 1
                    cmd.CommandText = "insert into medication(medicationId,medicineId,timings,quantity) values (@medicationId,@medicineId,@timings,@quantity)"
                    cmd.Parameters.AddWithValue("medicineId", Me.medicine1.SelectedValue)
                    cmd.Parameters.AddWithValue("timings", Me.repetition1.SelectedValue)
                    cmd.Parameters.AddWithValue("quantity", Me.quantity1.Text)
                    resultInsert += cmd.ExecuteNonQuery()

                    cmd.CommandText = "select CONCAT(medicineName,' (',state, ') ') from medicine where medicineId=" + Me.medicine1.SelectedValue
                    Dim medicineName = cmd.ExecuteScalar()
                    prescriptions.Add(New PrescriptionInfo(medicineName, Me.repetition1.SelectedValue, Me.quantity1.Text))

                End If
                If (Not String.IsNullOrWhiteSpace(Me.repetition2.SelectedValue)) Then
                    count += 1
                    cmd.CommandText = "insert into medication(medicationId,medicineId,timings,quantity) values (@medicationId,@medicineId,@timings,@quantity)"
                    cmd.Parameters.AddWithValue("medicationId", medicationId)
                    cmd.Parameters.AddWithValue("medicineId", Me.medicine2.SelectedValue)
                    cmd.Parameters.AddWithValue("timings", Me.repetition2.SelectedValue)
                    cmd.Parameters.AddWithValue("quantity", Me.quantity2.Text)
                    resultInsert += cmd.ExecuteNonQuery()

                    cmd.CommandText = "select CONCAT(medicineName,' (',state, ') ') from medicine where medicineId=" + Me.medicine1.SelectedValue
                    Dim medicineName = cmd.ExecuteScalar()
                    prescriptions.Add(New PrescriptionInfo(medicineName, Me.repetition2.SelectedValue, Me.quantity2.Text))

                End If
                If (Not String.IsNullOrWhiteSpace(Me.repetition3.SelectedValue)) Then
                    count += 1
                    cmd.CommandText = "insert into medication(medicationId,medicineId,timings,quantity) values (@medicationId,@medicineId,@timings,@quantity)"
                    cmd.Parameters.AddWithValue("medicineId", Me.medicine3.SelectedValue)
                    cmd.Parameters.AddWithValue("timings", Me.repetition3.SelectedValue)
                    cmd.Parameters.AddWithValue("quantity", Me.quantity3.Text)
                    resultInsert += cmd.ExecuteNonQuery()

                    cmd.CommandText = "select CONCAT(medicineName,' (',state, ') ') from medicine where medicineId=" + Me.medicine1.SelectedValue
                    Dim medicineName = cmd.ExecuteScalar()
                    prescriptions.Add(New PrescriptionInfo(medicineName, Me.repetition3.SelectedValue, Me.quantity3.Text))


                End If


                If (Not String.IsNullOrWhiteSpace(Me.repetition4.SelectedValue)) Then
                    count += 1
                    cmd.CommandText = "insert into medication(medicationId,medicineId,timings,quantity) values (@medicationId,@medicineId,@timings,@quantity)"
                    cmd.Parameters.AddWithValue("medicineId", Me.medicine4.SelectedValue)
                    cmd.Parameters.AddWithValue("timings", Me.repetition4.SelectedValue)
                    cmd.Parameters.AddWithValue("quantity", Me.quantity4.Text)
                    resultInsert += cmd.ExecuteNonQuery()

                    cmd.CommandText = "select CONCAT(medicineName,' (',state, ') ') from medicine where medicineId=" + Me.medicine1.SelectedValue
                    Dim medicineName = cmd.ExecuteScalar()
                    prescriptions.Add(New PrescriptionInfo(medicineName, Me.repetition4.SelectedValue, Me.quantity4.Text))


                End If




                If (count = resultInsert) Then
                    ''successful

                End If

                For Each prescription In prescriptions
                    prescriptionsToPrint &= prescription.medicineProperty & "         " & prescription.repetitionProperty & "          " & prescription.quantityProperty & vbNewLine
                Next


            End If
        Catch ex As MySqlException
            MessageBox.Show(ex.StackTrace())
        End Try
        PrintDocument()

    End Sub



    Public Sub PrintDocument()
        'Create an instance of our printer class
        Dim printer As New PrinterClass()
        'Set the font we want to use
        printer.PrinterFont = New Font("Verdana", 20)
      


        Dim dlg As System.Windows.Forms.PrintDialog = New System.Windows.Forms.PrintDialog()

        dlg.Document = printer
        dlg.ShowDialog()

        AddHandler printer.PrintPage, AddressOf Me.PrintDocument1_PrintPage
        printer.Print()





    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)

        Dim rect As Rectangle = New Rectangle()
        rect.Height = 200
        ''rect.Width = Page.WidthProperty.ToString

        Dim newImage As Image = Image.FromFile("C:\Users\Public\Pictures\Sample Pictures\Desert.jpg")
        e.Graphics.DrawImage(newImage, rect)


        ' You also can reference an image to PictureBox1.Image.

        e.Graphics.DrawString(prescriptionsToPrint, New Font("Arial", 16), Brushes.Black, 10, 1000)

        ' You also can reference some text to RichTextBox1.Text, etc.



    End Sub
End Class
