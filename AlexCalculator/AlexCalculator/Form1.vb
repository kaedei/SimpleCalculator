Imports System.Text.RegularExpressions

Public Class Form1


    Private Sub ButtonNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click, Button8.Click, Button7.Click, Button6.Click, Button5.Click, Button4.Click, Button3.Click, Button2.Click, Button10.Click, Button1.Click
        'get the clicked button
        Dim btn As Button = CType(sender, Button)

        'append Button text to result textbox
        txtResult.Text += btn.Text

    End Sub

    Private Sub btnCE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCE.Click
		txtResult.Text = ""
    End Sub

    Private Sub btnPlus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPlus.Click
        txtResult.Text += "+"
    End Sub

    Private Sub btnMinus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMinus.Click
        txtResult.Text += "-"
    End Sub

    Private Sub btnMultipy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMultipy.Click
        txtResult.Text += "x"
    End Sub

    Private Sub btnDivide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDivide.Click
        txtResult.Text += "/"
    End Sub

	Private Sub btnCalculate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalculate.Click
		If (String.IsNullOrEmpty(txtResult.Text.Trim())) Then
			Return
		End If
		Try
			Dim numbers As New List(Of Double)()
			Dim operators As New List(Of Char)()

			'get all numbers from expression
			Dim rNumber As New Regex("[\d\.]+")
			Dim mcNumber = rNumber.Matches(txtResult.Text)
			For Each m As Match In mcNumber
				numbers.Add(Double.Parse(m.Value))
			Next

			'get all operators from expression
			Dim rOperator As New Regex("[\+\-x\/]")	'include + - x /
			Dim mcOperator = rOperator.Matches(txtResult.Text)
			For Each m As Match In mcOperator
				operators.Add(Char.Parse(m.Value))
			Next

			'defined the result variable
			Dim result As Double = numbers(0)



			'calculate
			For index As Integer = 1 To numbers.Count - 1
				Dim currentNumber = result
				Dim nextNumber = numbers(index)
				Dim currentOperator = operators(index - 1)
				Select Case currentOperator
					Case "+"c
						result += nextNumber
					Case "-"c
						result -= nextNumber
					Case "x"c
						result *= nextNumber
					Case "/"c
						result /= nextNumber
				End Select
			Next

			txtResult.Text = result
		Catch
			txtResult.Text = ""
			MessageBox.Show("An error occured", "Calculator", MessageBoxButtons.OK, MessageBoxIcon.Error)
		End Try

	End Sub
End Class

