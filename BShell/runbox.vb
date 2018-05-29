Public Class runbox

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Hide()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            Process.Start(TextBox1.Text)
            Me.Hide()
        Catch ex As Exception
            Me.Hide()
            MsgBox("Bob Pony OS couldn't find " & TextBox1.Text & ". Please make sure you typed the command correctly or make sure that the file exists.", MsgBoxStyle.Exclamation, "An error has occured!")
            Me.Show()
        End Try
    End Sub

    Private Sub TextBox1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                Process.Start(TextBox1.Text)
                Me.Hide()
            Catch ex As Exception
                Me.Hide()
                MsgBox("Bob Pony OS couldn't find " & TextBox1.Text & ". Please make sure you typed the command correctly or make sure that the file exists.", MsgBoxStyle.Exclamation, "An error has occured!")
                Me.Show()
            End Try

        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        OpenFileDialog1.ShowDialog()
    End Sub

    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        TextBox1.Text = OpenFileDialog1.FileName
    End Sub
End Class