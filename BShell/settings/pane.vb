Public Class pane

    Private FixHeight As Integer   '= 1024 'default height
    Private FixWidth As Integer    '= 768 'default width
    Dim XRes As Short
    Dim YRes As Short
    Dim DidResChange As Boolean
    Private DirName As String = "C:\WINDOWS\system32\"
    Private Sub LinkLabel4_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        Shell("control mmsys.cpl sounds")
    End Sub

    Private Sub LinkLabel5_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel5.LinkClicked
        Shell("control main.cpl")
    End Sub

    Private Sub LinkLabel6_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        Shell("control desk.cpl,screensaver,@screensaver")
    End Sub

    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        personalization.MdiParent = Form
        personalization.Show()
    End Sub

    Private Sub LinkLabel3_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        'CHECK SCREEN RESOLUTION
        XRes = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width
        YRes = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height
        MessageBox.Show("Horizontal Resolution = " & XRes.ToString() _
           & Environment.NewLine & "Vertical Resolution = " _
           & YRes.ToString)
        Shell("control screen.cpl")
    End Sub

    Private Sub LinkLabel8_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel8.LinkClicked
        Shell("control intl.cpl")
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        barsetting.Show()
    End Sub

    Private Sub LinkLabel9_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel9.LinkClicked
        Shell("control userpasswords2")
    End Sub

    Private Sub LinkLabel10_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)

        Shell("rundll32.exe shell32.dll,Control_RunDLL desk.cpl,,5")
    End Sub

    Private Sub LinkLabel11_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel11.LinkClicked

    End Sub

    Private Sub LinkLabel7_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel7.LinkClicked
        Shell("control TimeDate.cpl")
    End Sub

    Private Sub PictureBox8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox8.Click

    End Sub

    Private Sub LinkLabel12_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)

    End Sub

    Private Sub LinkLabel14_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel14.LinkClicked
        helptopics.Show()
    End Sub

    Private Sub LinkLabel13_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel13.LinkClicked
        Feedback.Show()
    End Sub

    Private Sub LinkLabel15_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel15.LinkClicked
        Process.Start("OptionalFeatures.exe")
    End Sub

    Private Sub LinkLabel16_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        Shell("rundll32.exe shell32.dll,Options_RunDLL 0")
    End Sub

    Private Sub LinkLabel17_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel17.LinkClicked
        Shell("control.exe sysdm.cpl")
    End Sub

    Private Sub LinkLabel6_LinkClicked_1(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel6.LinkClicked

    End Sub
End Class