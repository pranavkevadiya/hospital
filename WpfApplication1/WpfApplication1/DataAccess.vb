Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Configuration.ConfigurationSettings
Imports System.Windows.Forms
Imports System.Data
Imports Microsoft.VisualBasic
Imports System.IO
Imports System.Net.Mail
Imports MySql.Data
Imports MySql.Data.MySqlClient




Public Class DataAccess
    ''' <summary>
    ''' Function to retrieve the connection from the app.config
    ''' </summary>
    ''' <param name="conName">Name of the connectionString to retrieve</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetConnectionString(ByVal conName As String) As String
        'variable to hold our connection string for returning it
        Dim strReturn As New String("")
        'check to see if the user provided a connection string name
        'this is for if your application has more than one connection string
        If Not String.IsNullOrEmpty(conName) Then
            'a connection string name was provided
            'get the connection string by the name provided
            strReturn = ConfigurationManager.ConnectionStrings(conName).ConnectionString
        Else
            'no connection string name was provided
            'get the default connection string
            strReturn = ConfigurationManager.ConnectionStrings("YourConnectionName").ConnectionString
        End If
        'return the connection string to the calling method
        Return strReturn
    End Function
    ''' <summary>
    ''' Method for handling the ConnectionState of 
    ''' the connection object passed to it
    ''' </summary>
    ''' <param name="conn">The SqlConnection Object</param>
    ''' <remarks></remarks>
    Public Shared Sub HandleConnection(ByVal conn As MySqlConnection)
        With conn
            'do a switch on the state of the connection
            Select Case .State
                Case ConnectionState.Open
                    'the connection is open
                    'close then re-open
                    .Close()
                    .Open()
                    Exit Select
                Case ConnectionState.Closed
                    'connection is open
                    'open the connection
                    .Open()
                    Exit Select
                Case Else
                    .Close()
                    .Open()
                    Exit Select
            End Select
        End With
    End Sub



    
    Public Shared Function GetRecords() As MySqlDataReader
        'The value that will be passed to the Command Object (this is a stored procedure)
        Dim sSQL As String = "SELECT * from users"
        'If using inline sql format is as such
        'sSQL = "SELECT * FROM YourTable
        'If not using the Express Edition uncomment the next line
        Dim cnInsert As New MySqlConnection(GetConnectionString("databaseConnection"))
        'If using Express Edition uncomment the next line
        'Dim cnInset As New SqlConnection("YourConnectionStringHere")
        'SqlConnection Object to use
        Dim cmdGetRecords As New MySqlCommand
        'SqlCommand Object to use
        Dim daGetRecords As New SqlDataAdapter()
        Dim dsGetRecords As New DataSet()
        'Clear any parameters
        cmdGetRecords.Parameters.Clear()
        Try
            With cmdGetRecords
                'set the SqlCommand Object Parameters
                .CommandText = sSQL
                'Tell it its a stored procedure (if using inline sql uncomment this line
                '.CommandType = CommandType.StoredProcedure 'CommandType.Text for inline sql
                'If you arent using a stored procedure uncomment the next line
                '.CommandType = CommandType.StoredProcedure 'For inline sql
                'Set the Connection for the Command Object
                .Connection = cnInsert

            End With
            'set the state of the SqlConnection Object
            HandleConnection(cnInsert)
            'create BindingSource to return for our DataGrid Control
            Return cmdGetRecords.ExecuteReader()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Error Retrieving Data")
            Return Nothing
        Finally
            HandleConnection(cnInsert)
        End Try
    End Function



End Class
