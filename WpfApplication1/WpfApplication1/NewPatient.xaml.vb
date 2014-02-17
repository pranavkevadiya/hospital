Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Configuration.ConfigurationSettings
Imports System.Windows.Forms
Imports System.Data
Imports MySql.Data.MySqlClient
Public Class NewPatient

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button1.Click

        Dim conn As New MySqlConnection
        Try
            conn.ConnectionString = DataAccess.GetConnectionString("databaseConnection")
            DataAccess.HandleConnection(conn)
            Dim addPatient As String = "insert into patient (patientname,surname,gender,dob,address,mo,emailid) values (@name,@surname,@gender,@dob,@address,@mo,@emailid)"
            'local initializations
            Dim firstName As String = Me.firstName.Text
            Dim surname As String = Me.surname.Text
            Dim gender As String = "F"
            If (Me.male.IsChecked) Then
                gender = "M"
            Else
                gender = "F"
            End If
            Dim dob As Date = Me.dob.DisplayDate
            Dim address As String = Me.address.Text
            If (Not String.IsNullOrEmpty(address)) Then
                address = address.Replace(vbCr, ",").Replace(vbLf, ",")
            End If
            Dim mo As String = Me.mo.Text
            Dim emailId As String = Me.emailId.Text

            Dim cmd As MySqlCommand = New MySqlCommand(addPatient, conn)
            cmd.Parameters.AddWithValue("name", firstName)
            cmd.Parameters.AddWithValue("surname", surname)
            cmd.Parameters.AddWithValue("emailId", emailId)
            cmd.Parameters.AddWithValue("mo", mo)
            cmd.Parameters.AddWithValue("address", address)
            cmd.Parameters.AddWithValue("dob", dob)
            cmd.Parameters.AddWithValue("gender", gender)


            Dim result As Integer = cmd.ExecuteNonQuery()

            If (result = 0) Then
                Me.errorLabel.Content = "The Patient could not be added."
            Else
                Me.errorLabel.Content = ""
                Me.Close()
            End If
        Catch ex As MySqlException
            Me.errorLabel.Content = "The Patient could not be added."

        Finally
            conn.Close()
        End Try


    End Sub
End Class
