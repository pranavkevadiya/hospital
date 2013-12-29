Imports MySql.Data.MySqlClient
Public Class Window1
    Dim patient As String

    Private Sub TabControl1_SelectionChanged(ByVal sender As System.Object, ByVal e As System.Windows.Controls.SelectionChangedEventArgs) Handles TabControl1.SelectionChanged
        If TabItem1.IsSelected Then
            'MessageBox.Show("details is selected")
        Else
            'MessageBox.Show("last visit is selected")
        End If

    End Sub

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
            Return
        End If

        Dim patientId As String = ""
        While patientData.Read()
            patientId = patientData.GetString("patientId")
            Dim patientname As String = patientData.GetString("patientname")
            patientname = patientname + " " + patientData.GetString("surname")
            Dim address As String = patientData.GetString("Address")
            Dim dob As String = patientData.GetString("dob")
            Dim mo As String = patientData.GetString("mo")
            Dim gender As String = patientData.GetString("gender")
        End While

        Dim lastvisits_sql As String = "select * from visitinfo where patientid=@patient"
        DataAccess.HandleConnection(conn)
        Dim lv_sqlCommand = New MySqlCommand(lastvisits_sql, conn)
        lv_sqlCommand.Parameters.AddWithValue("@patient", patientId)

        Dim lastvisitData As MySqlDataReader = lv_sqlCommand.ExecuteReader()
        If lastvisitData.HasRows = False Then
            MessageBox.Show("No last visit info found")
            Return
        End If

        While lastvisitData.Read()


        End While



    End Sub
End Class
