Imports MySql.Data.MySqlClient

Public Class VisitInfoPage

    Public Sub populateVisitDetails(ByRef con As MySqlConnection, ByVal patientId As String, ByRef lastVisitTab As TabItem)

        Dim lastVisitsControl = New VisitInfoPage()
        Dim visits As List(Of VisitInformation) = New List(Of VisitInformation)


        Try
            Dim lastvisits_sql As String = "select visitdate,diseasename,medicationid,notes from visitinfo NATURAL JOIN disease where patientid=@patient"
            DataAccess.HandleConnection(con)
            Dim lv_sqlCommand = New MySqlCommand(lastvisits_sql, con)
            lv_sqlCommand.Parameters.AddWithValue("@patient", patientId)
            

            Dim lastvisitData As MySqlDataReader = lv_sqlCommand.ExecuteReader()
            If lastvisitData.HasRows = False Then
                lastVisitTab.Content = "No last visit info found"
                Return
            Else
                While (lastvisitData.Read())
                    Dim visit As VisitInformation = New VisitInformation()
                    visit.visitDate = lastvisitData.GetDateTime("visitDate").ToString("dd-MMM-yyyy")
                    visit.disease = lastvisitData.GetString("diseaseName")
                    visit.note = lastvisitData.GetString("notes")
                    Dim medicationId = lastvisitData.GetInt16("medicationId")


                    Dim localCon = con.Clone()
                    localCon.Open()
                    Dim medication_cmd = New MySqlCommand("select medicineName,power from medication natural join medicine where medicationId=@medicationId", localCon)
                    medication_cmd.Parameters.AddWithValue("medicationId", medicationId)

                    Dim medicineNamesReader = medication_cmd.ExecuteReader()
                    Dim medicines As String = ""
                    While (medicineNamesReader.Read())
                        medicines += medicineNamesReader.GetString("medicinename")
                        Dim power As String = medicineNamesReader.GetString("power")
                        If Not String.IsNullOrEmpty(power) Then
                            medicines += "-" + power + Environment.NewLine
                        End If

                        
                    End While
                    medicineNamesReader.Close()
                    localCon.Close()
                    visit.medication = medicines
                    visits.Add(visit)
                End While
                lastvisitData.Close()
                con.Close()


            End If
        Catch ex As MySql.Data.MySqlClient.MySqlException
            MessageBox.Show(ex.Message)
        End Try
        lastVisitsControl.dgUsers.ItemsSource = visits
        lastVisitTab.Content = lastVisitsControl

        'lastVisitsControl.DataGrid1.DataContext = ds.Tables(0)
        '


        'users.Add(New User("pranav", "21-12-1989"))
        'users.Add(New User("Sammy Doe", "1991, 9, 2"))

        'dgUsers.ItemsSource = users
    End Sub

End Class
