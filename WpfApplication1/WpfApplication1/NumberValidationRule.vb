Imports System
Imports System.Globalization
Imports System.Windows.Controls
    Public Class NumberValidationRule : Inherits ValidationRule

        Public Overrides Function Validate(ByVal value As Object, ByVal cultureInfo As System.Globalization.CultureInfo) As System.Windows.Controls.ValidationResult

            If (value.ToString.Length = 5) Then

                Dim validation As ValidationResult = New ValidationResult(False, "Only Numbers are expected")
                Return validation
            End If
            Return New ValidationResult(True, "Validated")

        End Function







    End Class
