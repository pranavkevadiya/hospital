Imports System.Drawing

Public Class PrinterClass : Inherits Printing.PrintDocument
#Region " Property Variables "
    ''' <summary>
    ''' Property variable for the Font the user wishes to use
    ''' </summary>
    ''' <remarks></remarks>
    Private _font As Font

    ''' <summary>
    ''' Property variable for the text to be printed
    ''' </summary>
    ''' <remarks></remarks>
    Private _text As String
#End Region
#Region " Class Properties "
    ''' <summary>
    ''' Property to hold the text that is to be printed
    ''' </summary>
    ''' <value></value>
    ''' <returns>A string</returns>
    ''' <remarks></remarks>
    Public Property TextToPrint() As String
        Get
            Return _text
        End Get
        Set(ByVal Value As String)
            _text = Value
        End Set
    End Property

    ''' <summary>
    ''' Property to hold the font the users wishes to use
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PrinterFont() As Font
        ' Allows the user to override the default font
        Get
            Return _font
        End Get
        Set(ByVal Value As Font)
            _font = Value
        End Set
    End Property
#End Region

#Region " Class Constructors "
    ''' <summary>
    ''' Empty constructor
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        'Call the base classes constructor
        MyBase.New()
        'Instantiate out Text property to an empty string
        _text = String.Empty
    End Sub

    ''' <summary>
    ''' Constructor to initialize our printing object
    ''' and the text it's supposed to be printing
    ''' </summary>
    ''' <param name="str">Text that will be printed</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal str As String)
        'Call the base classes constructor
        MyBase.New()
        'Set our Text property value
        _text = str
    End Sub
#End Region



End Class
