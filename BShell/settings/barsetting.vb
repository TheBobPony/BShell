Public Class barsetting


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Feedback.Hide()
        Feedback.Show()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
       
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Form.Taskbar.BackColor = Color.White
    End Sub

    Private Sub rbTop_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbTop.CheckedChanged
        Form.Taskbar.Dock = DockStyle.Top
    End Sub
    Private Sub InitDialog()

        With BPOSexplorer


            cbAutoHide.Checked = CBool(.AutoHide)

            rbLeft.Checked = CBool(.Edge = ApplicationBar.ABEdge.abeLeft)
            rbTop.Checked = CBool(.Edge = ApplicationBar.ABEdge.abeTop)
            rbRight.Checked = CBool(.Edge = ApplicationBar.ABEdge.abeRight)
            rbBottom.Checked = CBool(.Edge = ApplicationBar.ABEdge.abeBottom)


        End With
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ApplyChanges()
        Me.Close()
    End Sub
    Private Sub ApplyChanges()
        With BPOSexplorer



        End With
    End Sub

    Private Sub removeitemlist_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles removeitemlist.SelectedIndexChanged
        
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        GroupBox6.Enabled = False
        Form.ToolStripButton1.Visible = False
        Form.NewMenuButton.Visible = True
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        GroupBox6.Enabled = True
        Form.ToolStripButton1.Visible = True
        Form.NewMenuButton.Visible = False
    End Sub

    Private Sub Button5_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If removeitemlist.GetItemChecked(0) Then
            Form.User2ToolStripMenuItem.Visible = False
        Else
            Form.User2ToolStripMenuItem.Visible = True
        End If
        If removeitemlist.GetItemChecked(1) Then
            Form.AboutToolStripMenuItem.Visible = False
        Else
            Form.AboutToolStripMenuItem.Visible = True
        End If


        If removeitemlist.GetItemChecked(4) Then
            Form.BPOSSoftwareCenterToolStripMenuItem.Visible = False
        Else
            Form.BPOSSoftwareCenterToolStripMenuItem.Visible = True
        End If

        If removeitemlist.GetItemChecked(6) Then
            Form.NewExplorerBETAToolStripMenuItem.Visible = False
        Else
            Form.NewExplorerBETAToolStripMenuItem.Visible = True
        End If
        If removeitemlist.GetItemChecked(7) Then
            Form.SettingsToolStripMenuItem.Visible = False
        Else
            Form.SettingsToolStripMenuItem.Visible = True
        End If

        If removeitemlist.GetItemChecked(9) Then
            Form.UsToolStripMenuItem.Visible = False
        Else
            Form.UsToolStripMenuItem.Visible = True
        End If
        If removeitemlist.GetItemChecked(10) Then
            Form.ToolStripMenuItem4.Visible = False
        Else
            Form.ToolStripMenuItem4.Visible = True
        End If
        If removeitemlist.GetItemChecked(11) Then
            Form.SearchToolStripMenuItem.Visible = False
        Else
            Form.SearchToolStripMenuItem.Visible = True
        End If
        If removeitemlist.GetItemChecked(12) Then
            Form.RunToolStripMenuItem.Visible = False
        Else
            Form.RunToolStripMenuItem.Visible = True
        End If
        If removeitemlist.GetItemChecked(13) Then
            Form.ExitToolStripMenuItem.Visible = False
        Else
            Form.ExitToolStripMenuItem.Visible = True
        End If
        If legacybarsmallicon.CheckState Then
            Form.User2ToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.SizeToFit
            Form.AboutToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.SizeToFit

            Form.BPOSSoftwareCenterToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.SizeToFit

            Form.NewExplorerBETAToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.SizeToFit
            Form.SettingsToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.SizeToFit

            Form.UsToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.SizeToFit
            Form.ToolStripMenuItem4.ImageScaling = ToolStripItemImageScaling.SizeToFit
            Form.SearchToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.SizeToFit
            Form.RunToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.SizeToFit
            Form.ExitToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.SizeToFit
        Else
            Form.User2ToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None
            Form.AboutToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None


            Form.BPOSSoftwareCenterToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None

            Form.NewExplorerBETAToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None
            Form.SettingsToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None
            Form.UsToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None
            Form.ToolStripMenuItem4.ImageScaling = ToolStripItemImageScaling.None
            Form.SearchToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None
            Form.RunToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None
            Form.ExitToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None
        End If
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Me.Close()
    End Sub

    Private Sub CheckBox4_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox4.CheckStateChanged
        If CheckBox4.CheckState Then
            Form.ToolStripButton2.Visible = True
        Else
            Form.ToolStripButton2.Visible = False
        End If
    End Sub

    Private Sub CheckBox5_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'ded
    End Sub

    Private Sub CheckBox1_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckStateChanged
        If CheckBox1.CheckState Then
            Form.ToolStripLabel1.Visible = True
        Else
            Form.ToolStripLabel1.Visible = False
        End If
    End Sub

    Private Sub CheckBox3_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox3.CheckStateChanged
        If CheckBox3.CheckState Then
            Form.ToolStripButton4.Visible = True
        Else
            Form.ToolStripButton4.Visible = False
        End If
    End Sub

    Private Sub CheckBox2_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckStateChanged
        If CheckBox2.CheckState Then
            Form.ToolStripLabel2.Visible = True
        Else
            Form.ToolStripLabel2.Visible = False
        End If
    End Sub

    Private Sub rbBottom_CheckedChanged(sender As Object, e As EventArgs) Handles rbBottom.CheckedChanged
        Form.Taskbar.Dock = DockStyle.Bottom
    End Sub

    Private Sub rbRight_CheckedChanged(sender As Object, e As EventArgs) Handles rbRight.CheckedChanged
        Form.Taskbar.Dock = DockStyle.Right
    End Sub

    Private Sub rbLeft_CheckedChanged(sender As Object, e As EventArgs) Handles rbLeft.CheckedChanged
        Form.Taskbar.Dock = DockStyle.Left
    End Sub
End Class