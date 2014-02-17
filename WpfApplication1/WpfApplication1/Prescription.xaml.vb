Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Windows.Forms.PrintDialog
Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient
Imports System.Data
Imports System.IO.Path
Imports System.Text.RegularExpressions


Public Class Prescription
    Dim prescriptionsToPrint As String
    Dim specialNote As String
    Dim patientName As String
    Dim prescriptions As List(Of PrescriptionInfo) = New List(Of PrescriptionInfo)
    Dim medicineDefaultQuantity = 10

    Private Sub Prescribe_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Prescribe.Click

        Dim patientId = Me.patientId.Content
        specialNote = Me.Note.Text
        Me.Prescribe.IsEnabled = False


        Try

            Dim con As MySqlConnection = New MySqlConnection(DataAccess.GetConnectionString("databaseConnection"))
            DataAccess.HandleConnection(con)
            Dim cmd = New MySqlCommand("select MAX(medicationId)+1 from visitinfo", con)

            Dim medicationId As String

            If (IsDBNull(cmd.ExecuteScalar)) Then
                medicationId = 1
            Else
                medicationId = cmd.ExecuteScalar()
            End If
            cmd.CommandText = "select CONCAT(patientName,' ',surname) from patient where patientid=" + patientId
            patientName = cmd.ExecuteScalar()


            cmd.CommandText = "insert into visitinfo(patientId,medicationId,visitDate,isFirst,disease,notes) values (@patientId,@medicationId,CURDATE(),0,1,@notes)"
            cmd.Parameters.AddWithValue("patientId", patientId)
            cmd.Parameters.AddWithValue("medicationId", medicationId)
            cmd.Parameters.AddWithValue("notes", specialNote)


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
                    cmd.Parameters.Clear()


                    cmd.CommandText = "insert into medication(medicationId,medicineId,timings,quantity) values (@medicationId,@medicineId,@timings,@quantity)"
                    cmd.Parameters.AddWithValue("medicationId", medicationId)
                    cmd.Parameters.AddWithValue("medicineId", Me.medicine2.SelectedValue)
                    cmd.Parameters.AddWithValue("timings", Me.repetition2.SelectedValue)
                    cmd.Parameters.AddWithValue("quantity", Me.quantity2.Text)
                    resultInsert += cmd.ExecuteNonQuery()

                    cmd.CommandText = "select CONCAT(medicineName,' (',state, ') ') from medicine where medicineId=" + Me.medicine2.SelectedValue
                    Dim medicineName = cmd.ExecuteScalar()
                    prescriptions.Add(New PrescriptionInfo(medicineName, Me.repetition2.SelectedValue, Me.quantity2.Text))

                End If
                If (Not String.IsNullOrWhiteSpace(Me.repetition3.SelectedValue)) Then
                    count += 1
                    cmd.Parameters.Clear()
                    cmd.CommandText = "insert into medication(medicationId,medicineId,timings,quantity) values (@medicationId,@medicineId,@timings,@quantity)"
                    cmd.Parameters.AddWithValue("medicationId", medicationId)
                    cmd.Parameters.AddWithValue("medicineId", Me.medicine3.SelectedValue)
                    cmd.Parameters.AddWithValue("timings", Me.repetition3.SelectedValue)
                    cmd.Parameters.AddWithValue("quantity", Me.quantity3.Text)
                    resultInsert += cmd.ExecuteNonQuery()

                    cmd.CommandText = "select CONCAT(medicineName,' (',state, ') ') from medicine where medicineId=" + Me.medicine3.SelectedValue
                    Dim medicineName = cmd.ExecuteScalar()
                    prescriptions.Add(New PrescriptionInfo(medicineName, Me.repetition3.SelectedValue, Me.quantity3.Text))


                End If


                If (Not String.IsNullOrWhiteSpace(Me.repetition4.SelectedValue)) Then
                    count += 1
                    cmd.Parameters.Clear()
                    cmd.CommandText = "insert into medication(medicationId,medicineId,timings,quantity) values (@medicationId,@medicineId,@timings,@quantity)"
                    cmd.Parameters.AddWithValue("medicationId", medicationId)
                    cmd.Parameters.AddWithValue("medicineId", Me.medicine4.SelectedValue)
                    cmd.Parameters.AddWithValue("timings", Me.repetition4.SelectedValue)
                    cmd.Parameters.AddWithValue("quantity", Me.quantity4.Text)
                    resultInsert += cmd.ExecuteNonQuery()

                    cmd.CommandText = "select CONCAT(medicineName,' (',state, ') ') from medicine where medicineId=" + Me.medicine4.SelectedValue
                    Dim medicineName = cmd.ExecuteScalar()
                    prescriptions.Add(New PrescriptionInfo(medicineName, Me.repetition4.SelectedValue, Me.quantity4.Text))



                End If
                If (Not String.IsNullOrWhiteSpace(Me.repetition5.SelectedValue)) Then
                    count += 1
                    cmd.Parameters.Clear()
                    cmd.CommandText = "insert into medication(medicationId,medicineId,timings,quantity) values (@medicationId,@medicineId,@timings,@quantity)"
                    cmd.Parameters.AddWithValue("medicationId", medicationId)
                    cmd.Parameters.AddWithValue("medicineId", Me.medicine5.SelectedValue)
                    cmd.Parameters.AddWithValue("timings", Me.repetition5.SelectedValue)
                    cmd.Parameters.AddWithValue("quantity", Me.quantity5.Text)
                    resultInsert += cmd.ExecuteNonQuery()

                    cmd.CommandText = "select CONCAT(medicineName,' (',state, ') ') from medicine where medicineId=" + Me.medicine5.SelectedValue
                    Dim medicineName = cmd.ExecuteScalar()
                    prescriptions.Add(New PrescriptionInfo(medicineName, Me.repetition5.SelectedValue, Me.quantity5.Text))


                End If




                If (count = resultInsert) Then
                    ''successful

                End If

                For Each prescription In prescriptions
                    Dim medicine As String = prescription.medicineProperty
                    If Not String.IsNullOrEmpty(medicine) Then
                        medicine = medicine.PadRight(70, " ").ToUpper()
                        Console.Write(medicine & "--" & medicine.Length)


                    End If

                    prescriptionsToPrint &= medicine & prescription.repetitionProperty & "          " & prescription.quantityProperty & vbNewLine
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

        
        Dim fullPath = System.Reflection.Assembly.GetExecutingAssembly().Location
        Dim folderName = System.IO.Path.GetDirectoryName(fullPath)
        Dim imgFilePath = System.IO.Path.Combine(folderName, "\Utils\hospital_logo.jpg")
        Dim newImage As Image
        Try
            newImage = Image.FromFile(imgFilePath)
        Catch ex As Exception
            newImage = Image.FromFile("D:\hospital\hospital_logo.jpg")
        End Try



        Dim rect As Rectangle = New Rectangle()
        Dim imgsz As New SizeF(100 * newImage.Width / newImage.HorizontalResolution, 100 * newImage.Height / newImage.VerticalResolution)
        Dim ratio As Single = (e.PageBounds.Width) / imgsz.Width
        Dim p As New PointF(imgsz.Width * ratio, imgsz.Height * ratio)

        rect.Height = p.Y
        rect.Width = p.X

        ''rect.Width = Page.WidthProperty.ToString
        ''string dir = Path.GetDirectoryName(Application.ExecutablePath);
        'string filename = Path.Combine(dir, @"MyImage.jpg");

        e.Graphics.DrawImage(newImage, rect)





        e.Graphics.DrawString("Date: " & Date.Today, New Font("Arial", 12), Brushes.Black, 10, 130)
        e.Graphics.DrawString("Patient Name:" & patientName, New Font("Arial", 12), Brushes.Black, 10, 110)

        Dim y As Integer = 200
        For Each prescription In prescriptions
            e.Graphics.DrawString(prescription.medicineProperty, New Font("Verdana", 14), Brushes.Black, 10, y)
            e.Graphics.DrawString(prescription.repetitionProperty, New Font("Verdana", 14), Brushes.Black, 400, y)
            e.Graphics.DrawString(prescription.quantityProperty, New Font("Verdana", 14), Brushes.Black, 600, y)

            y = y + 30
        Next
        e.Graphics.DrawString("Note" & vbNewLine & specialNote, New Font("Verdana", 10), Brushes.Black, 10, 500)

    End Sub
    Private Sub quantity1_TextChanged(ByVal sender As System.Object, ByVal e As System.Windows.Controls.TextChangedEventArgs) Handles quantity1.TextChanged
        If (Not Regex.IsMatch(quantity1.Text, "^\d+$")) Then
            quantity1.ToolTip = "This is not a valid number"
            Prescribe.IsEnabled = False
        Else
            quantity1.ToolTip = "Quantity"
            Prescribe.IsEnabled = True
        End If

    End Sub
    Private Sub quantity2_TextChanged(ByVal sender As System.Object, ByVal e As System.Windows.Controls.TextChangedEventArgs) Handles quantity2.TextChanged
        If (Not Regex.IsMatch(quantity2.Text, "^\d+$")) Then
            quantity2.ToolTip = "This is not a valid number"
            Prescribe.IsEnabled = False
        Else
            quantity2.ToolTip = "Quantity"
            Prescribe.IsEnabled = True
        End If

    End Sub
    Private Sub quantity3_TextChanged(ByVal sender As System.Object, ByVal e As System.Windows.Controls.TextChangedEventArgs) Handles quantity3.TextChanged
        If (Not Regex.IsMatch(quantity3.Text, "^\d+$")) Then
            quantity3.ToolTip = "This is not a valid number"
            Prescribe.IsEnabled = False
        Else
            quantity3.ToolTip = "Quantity"
            Prescribe.IsEnabled = True
        End If

    End Sub
    Private Sub quantity4_TextChanged(ByVal sender As System.Object, ByVal e As System.Windows.Controls.TextChangedEventArgs) Handles quantity4.TextChanged
        If (Not Regex.IsMatch(quantity4.Text, "^\d+$")) Then
            quantity4.ToolTip = "This is not a valid number"
            Prescribe.IsEnabled = False
        Else
            quantity4.ToolTip = "Quantity"
            Prescribe.IsEnabled = True
        End If

    End Sub
    Private Sub quantity5_TextChanged(ByVal sender As System.Object, ByVal e As System.Windows.Controls.TextChangedEventArgs) Handles quantity5.TextChanged
        If (Not Regex.IsMatch(quantity5.Text, "^\d+$")) Then
            quantity5.ToolTip = "This is not a valid number"
            Prescribe.IsEnabled = False
        Else
            quantity5.ToolTip = "Quantity"
            Prescribe.IsEnabled = True
        End If

    End Sub

    Private Sub repetition1_SelectionChanged(ByVal sender As System.Object, ByVal e As System.Windows.Controls.SelectionChangedEventArgs) Handles repetition1.SelectionChanged
        quantity1.Text = medicineDefaultQuantity
    End Sub

    Private Sub repetition2_SelectionChanged(ByVal sender As System.Object, ByVal e As System.Windows.Controls.SelectionChangedEventArgs) Handles repetition2.SelectionChanged
        quantity2.Text = medicineDefaultQuantity
    End Sub

    Private Sub repetition3_SelectionChanged(ByVal sender As System.Object, ByVal e As System.Windows.Controls.SelectionChangedEventArgs) Handles repetition3.SelectionChanged
        quantity3.Text = medicineDefaultQuantity
    End Sub

    Private Sub repetition4_SelectionChanged(ByVal sender As System.Object, ByVal e As System.Windows.Controls.SelectionChangedEventArgs) Handles repetition4.SelectionChanged
        quantity4.Text = medicineDefaultQuantity
    End Sub

    Private Sub repetition5_SelectionChanged(ByVal sender As System.Object, ByVal e As System.Windows.Controls.SelectionChangedEventArgs) Handles repetition5.SelectionChanged
        quantity5.Text = medicineDefaultQuantity
    End Sub

    Private Sub Note_TextChanged(ByVal sender As System.Object, ByVal e As System.Windows.Controls.TextChangedEventArgs) Handles Note.TextChanged
        If (String.IsNullOrEmpty(Note.Text)) Then
            Prescribe.IsEnabled = False
        Else
            Prescribe.IsEnabled = True
        End If
    End Sub
End Class
