Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Configuration.ConfigurationSettings
Imports System.Windows.Forms
Imports System.Data
Imports MySql.Data.MySqlClient



Class LoginWindow

    Dim username As String
    Dim password As String

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Loaded
        Me.Top = 0
        Me.Left = 0
        Me.Height = Screen.PrimaryScreen.WorkingArea.Height
        Me.Width = Screen.PrimaryScreen.WorkingArea.Width
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button1.Click
        username = TextBox1.Text
        password = PasswordBox1.Password

        'Dim output As BindingSource = DataAccess.GetRecords()

        Dim conn As New MySqlConnection
        Try
            conn.ConnectionString = DataAccess.GetConnectionString("databaseConnection")
            conn.Open()
            Dim sql As String = "SELECT * from users where username=@username AND password=@password AND isActive=1"
            Dim command As MySqlCommand = New MySqlCommand(sql, conn)
            command.Parameters.AddWithValue("@username", username)
            command.Parameters.AddWithValue("@password", password)

            Dim reader As MySqlDataReader = command.ExecuteReader()
            If reader.HasRows() Then
                reader.Read()
                MessageBox.Show("Login Successfull. Welcome Dr." + reader.GetString(0))

                Dim window As MainWindow = New MainWindow()
                window.Show()
                Close()

            Else
                MessageBox.Show("Invalid username or password")
            End If



            reader.Close()
        Catch ex As MySql.Data.MySqlClient.MySqlException
            MessageBox.Show(ex.Message)
        Finally
            conn.Close()

        End Try





    End Sub


End Class
