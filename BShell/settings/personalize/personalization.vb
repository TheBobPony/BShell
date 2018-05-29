Public Class personalization

    Private Sub personalization_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'C:\Windows\System32\winver.exe
        If System.IO.File.Exists("C:\Windows\System32\winver.exe") Then
            Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon("C:\Windows\System32\winver.exe")
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        MainForm.Show()
    End Sub
End Class