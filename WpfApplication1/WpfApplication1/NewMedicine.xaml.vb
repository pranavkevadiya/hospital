Imports System.Windows.Forms
Imports MySql.Data.MySqlClient
Imports WpfApplication1
Imports System.Text.RegularExpressions


Public Class NewMedicine
    Dim _medicine As String
   
    Public Property Medicine() As String
        Get
            Return _medicine

        End Get
        Set(ByVal value As String)
            _medicine = value
        End Set
    End Property

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Loaded
        Me.Top = 0
        Me.Left = 0
        Me.stateValues.ItemsSource = New List(Of String)(New String() {"TABLET", "GEL"})
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button1.Click
        Dim conn As New MySqlConnection
        Try
            conn.ConnectionString = DataAccess.GetConnectionString("databaseConnection")
            DataAccess.HandleConnection(conn)
            Dim addMedicine As String = "insert into medicine (medicinename,power,state) values (@medicinename,@power,@state)"
            'local initializations
            Dim medicinename As String = Me.Medicine1.Text

            Dim power As String = Me.power.Text
            Dim state As String = Me.stateValues.SelectedValue
           
         

            Dim cmd As MySqlCommand = New MySqlCommand(addMedicine, conn)
            cmd.Parameters.AddWithValue("medicinename", medicinename)
            cmd.Parameters.AddWithValue("power", power)
            cmd.Parameters.AddWithValue("state", state)
           

            Dim result As Integer = cmd.ExecuteNonQuery()

            If (result = 0) Then
                Me.errorLabel.Content = "The Medicine was not added."
            Else
                Me.errorLabel.Content = ""
                Me.Close()
            End If
        Catch ex As MySqlException
            Me.errorLabel.Content = "The Medicine was not added."

        Finally
            conn.Close()
        End Try

    End Sub

    Private Sub power_TextChanged(ByVal sender As System.Object, ByVal e As System.Windows.Controls.TextChangedEventArgs) Handles power.TextChanged
        Dim tb As System.Windows.Controls.TextBox = DirectCast(sender, System.Windows.Controls.TextBox)
        Dim newStyle As Style = New Style()
        newStyle.BasedOn = tb.Style

        newStyle.TargetType = sender.GetType()
        If (Not Regex.IsMatch(power.Text, "^\d+$")) Then
            power.ToolTip = "This is not a valid number"
            Button1.IsEnabled = False

            newStyle.Setters.Add(New Setter(BorderBrushProperty, Brushes.Red))
            tb.Style = newStyle

        ElseIf (Not String.IsNullOrEmpty(Medicine1.Text)) Then
            power.ToolTip = "Power of medicine"
            Button1.IsEnabled = True

            newStyle.Setters.Add(New Setter(BorderBrushProperty, Brushes.Gray))
            tb.Style = newStyle

        End If



    End Sub

    Private Sub Medicine1_FocusChanged(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Medicine1.LostFocus
        Dim tb As System.Windows.Controls.TextBox = DirectCast(sender, System.Windows.Controls.TextBox)
        Dim newStyle As Style = New Style()
        newStyle.BasedOn = tb.Style
        newStyle.TargetType = sender.GetType()

        If (String.IsNullOrEmpty(Medicine1.Text)) Then
            Medicine1.ToolTip = "Please enter value of the medicine"
            Button1.IsEnabled = False
           
            newStyle.Setters.Add(New Setter(BorderBrushProperty, Brushes.Red))
            tb.Style = newStyle

        ElseIf (Regex.IsMatch(power.Text, "^\d+$")) Then
            Medicine1.ToolTip = "Medicine Name"
            Button1.IsEnabled = True

            newStyle.Setters.Add(New Setter(BorderBrushProperty, Brushes.Gray))
            tb.Style = newStyle
        End If
    End Sub
End Class