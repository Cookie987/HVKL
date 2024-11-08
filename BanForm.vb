Public Class BanForm
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub BanForm_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Close()
        End If
    End Sub

    Private Sub Label1_KeyDown(sender As Object, e As KeyEventArgs) Handles Label1.KeyDown
        If e.KeyCode = Keys.Escape Then
            Close()
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim backColor, foreColor
        backColor = Label1.BackColor
        foreColor = Label1.ForeColor
        Label1.BackColor = foreColor
        Label1.ForeColor = backColor
    End Sub

    Private Sub BanForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MainForm.Visible = False
    End Sub
End Class