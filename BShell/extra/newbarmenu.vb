Imports System.IO

Public Class newbarmenu
    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
        MyBase.OnLoad(e)
        MyBase.Top = Screen.PrimaryScreen.WorkingArea.Bottom - Me.Height
        MyBase.Left = Screen.PrimaryScreen.WorkingArea.Left
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Select Case MsgBox("Are you sure you want to logff?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Bob Pony OS")
            Case MsgBoxResult.Yes
                Shell("logoff")
                End
        End Select
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

    End Sub

    Private Sub newbarmenu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim username As String
        username = Environment.UserName
        Label1.Text = username
    End Sub

    Private Sub newbarmenu_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.MouseLeave

    End Sub

    Private Sub newbarmenu_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        Me.Hide()
    End Sub

    Private Sub LinkLabel10_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel10.LinkClicked
        Process.Start("Newexplorer.exe")
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start("Newexplorer.exe")
    End Sub

    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Process.Start("Newexplorer.exe")
    End Sub

    Private Sub LinkLabel3_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Process.Start("Newexplorer.exe")
    End Sub

    Private Sub LinkLabel4_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        Process.Start("Newexplorer.exe")
    End Sub

    Private Sub LinkLabel5_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel5.LinkClicked
        Process.Start("Newexplorer.exe")
    End Sub

    Private Sub LinkLabel6_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel6.LinkClicked
        Process.Start("Newexplorer.exe")
    End Sub

    Private Sub ListView1_ItemActivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.ItemActivate

    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged



    End Sub

    Private Sub LinkLabel8_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel8.LinkClicked
        Process.Start("winver")
    End Sub

    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox4.Click

        Dim searchbase As String = My.Resources.SearchDoc.ToString.ToString.ToString.ToString
        Dim searh As String = searchbase.Replace("abcdefg", searchbox.Text)
        If My.Computer.FileSystem.FileExists(Application.UserAppDataPath + "\tempsearch.search-ms") = False Then
            File.Create(Application.UserAppDataPath + "\tempsearch.search-ms").Dispose()
        End If
        Dim objWriter As New System.IO.StreamWriter(Application.UserAppDataPath + "\tempsearch.search-ms")
        objWriter.Write(searh)
        objWriter.Close()
        Process.Start("Newexplorer.exe")
    End Sub

    Private Sub searchbox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles searchbox.Click
        searchbox.Clear()
    End Sub

    Private Sub LinkLabel9_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel9.LinkClicked
        pane.Show()
    End Sub

    Private Sub LinkLabel11_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel11.LinkClicked
        runbox.Show()
    End Sub

    Private Sub PictureBox5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox5.Click
        Process.Start("Newexplorer.exe")
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        shutdown.Show()
    End Sub

    Private Sub SMSidePanel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SMSidePanel.Click

    End Sub
End Class