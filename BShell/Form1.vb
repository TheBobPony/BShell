Imports System.Windows.Forms
Imports System.IO
Imports System.Threading
Public Class Form
    Declare Auto Function SetParent Lib "user32.dll" (ByVal hWndChild As IntPtr, ByVal hWndNewParent As IntPtr) As Integer
    Declare Auto Function SendMessage Lib "user32.dll" (ByVal hWnd As IntPtr, ByVal Msg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
    Private Const WM_SYSCOMMAND As Integer = 274
    Private Const SC_MAXIMIZE As Integer = 61488
    Dim proc As Process
    Private i As Integer
    Private dockButton() As Button
    Private buttonsInitialized As Boolean = False
    Private labels() As String = {"T", "L", "B", "R", "F"}
    Dim m_ChildFormNumber As Integer
    'Used to detected if any of the messages are any of these constants values.
    Private Const WM_DEVICECHANGE As Integer = &H219

    Private Const DBT_DEVICEARRIVAL As Integer = &H8000

    Private Const DBT_DEVICEREMOVECOMPLETE As Integer = &H8004

    Private Const DBT_DEVTYP_VOLUME As Integer = &H2  '
    '
    'Get the information about the detected volume.
    Private Structure DEV_BROADCAST_VOLUME

        Dim Dbcv_Size As Integer

        Dim Dbcv_Devicetype As Integer

        Dim Dbcv_Reserved As Integer

        Dim Dbcv_Unitmask As Integer

        Dim Dbcv_Flags As Short

    End Structure
    Protected Overrides Sub WndProc(ByRef M As System.Windows.Forms.Message)
        '
        'These are the required subclassing codes for detecting device based removal and arrival.
        '
        If M.Msg = WM_DEVICECHANGE Then

            Select Case M.WParam
                '
                'Check if a device was added. 
                Case DBT_DEVICEARRIVAL

                    Dim DevType As Integer = Runtime.InteropServices.Marshal.ReadInt32(M.LParam, 4)

                    If DevType = DBT_DEVTYP_VOLUME Then

                        Dim Vol As New DEV_BROADCAST_VOLUME

                        Vol = Runtime.InteropServices.Marshal.PtrToStructure(M.LParam, GetType(DEV_BROADCAST_VOLUME))

                        If Vol.Dbcv_Flags = 0 Then

                            For i As Integer = 0 To 20

                                If Math.Pow(2, i) = Vol.Dbcv_Unitmask Then

                                    Dim Usb As String = Chr(65 + i) + ":\"

                                    MsgBox("A USB device just got plugged in!" & vbNewLine & vbNewLine & "The drive letter is: " & Usb.ToString)

                                    For Each drv As DriveInfo In DriveInfo.GetDrives

                                    Next
                                    NewExplorer.ShowDialog()
                                    Exit For

                                End If


                            Next

                        End If

                    End If
                    '
                    'Check if the message was for the removal of a device. 
                Case DBT_DEVICEREMOVECOMPLETE

                    Dim DevType As Integer = Runtime.InteropServices.Marshal.ReadInt32(M.LParam, 4)

                    If DevType = DBT_DEVTYP_VOLUME Then

                        Dim Vol As New DEV_BROADCAST_VOLUME

                        Vol = Runtime.InteropServices.Marshal.PtrToStructure(M.LParam, GetType(DEV_BROADCAST_VOLUME))

                        If Vol.Dbcv_Flags = 0 Then

                            For i As Integer = 0 To 20

                                If Math.Pow(2, i) = Vol.Dbcv_Unitmask Then

                                    Dim Usb As String = Chr(65 + i) + ":\"

                                    MsgBox("Looks like a volume device was removed!" & vbNewLine & vbNewLine & "The drive letter is: " & Usb.ToString)

                                    Exit For

                                End If

                            Next

                        End If

                    End If

            End Select

        End If

        MyBase.WndProc(M)

    End Sub

    Public Function OSXIsOn() As Boolean
        Dim p = Process.GetProcessesByName("winlogon").Count
        Return (p = 0)
    End Function

    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub clocktime_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles clocktime.Tick

        ToolStripLabel1.Text = Format(Now, "HH:mm:ss tt")
        If My.Computer.Network.IsAvailable() Then
            ToolStripLabel2.Enabled = True
        Else
            ToolStripLabel2.Enabled = False
        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If (Not Wallpaper.SupportFitFillWallpaperStyles) Then
            End
        End If
        'C:\Windows\System32\winver.exe
        Taskbar.BackColor = My.Settings.BarColor
        User2ToolStripMenuItem.Text = System.Environment.UserName
        clocktime.Start()
        Timer1.Start()
        Dim powerstatus As PowerStatus = SystemInformation.PowerStatus
        If powerstatus.BatteryChargeStatus = 128 Then
            UsToolStripMenuItem.Visible = False
        End If
    End Sub
    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        proc = Process.Start("winver.exe")
        proc.WaitForInputIdle()
        Thread.Sleep(10)
        SetParent(proc.MainWindowHandle, Me.Handle)
    End Sub

    Private Sub BottomToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Taskbar.Dock = DockStyle.Bottom
    End Sub

    Private Sub TopToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Taskbar.Dock = DockStyle.Top
    End Sub

    Private Sub LeftToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Taskbar.Dock = DockStyle.Left
    End Sub

    Private Sub RightToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Taskbar.Dock = DockStyle.Right
    End Sub

    Private Sub BarSettingsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        barsetting.Hide()
        barsetting.Show()
    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        proc = Process.Start("sndvol.exe")
        proc.WaitForInputIdle()
        Thread.Sleep(200)
        SetParent(proc.MainWindowHandle, Me.Handle)
    End Sub

    Private Sub DisplayToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Shell("C:\Windows\system32\control.exe desk.cpl")
    End Sub

    Private Sub DevToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Shell("cmd")
    End Sub

    Private Sub LogoffToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Shell("logoff.exe")
    End Sub

    Private Sub RunToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RunToolStripMenuItem.Click
        runbox.MdiParent = Me
        runbox.Show()
    End Sub

    Private Sub BarToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        barsetting.Hide()
        barsetting.Show()
    End Sub

    Private Sub PaneToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        pane.Hide()
        pane.Show()
    End Sub

    Private Sub ScreenshotToolToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem4.Click
        helptopics.MdiParent = Me
        helptopics.Show()
    End Sub

    Private Sub ToolStripDropDownButton2_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub NewExplorerBETAToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewExplorerBETAToolStripMenuItem.Click
        NewExplorer.MdiParent = Me
        NewExplorer.Show()
    End Sub

    Private Sub ProcessesManagerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProcessesManagerToolStripMenuItem.Click
        Process.Start("taskmgr")
    End Sub

    Private Sub ToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Feedback.Hide()
        Feedback.Show()
    End Sub

    Private Sub GoogleChromeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Process.Start("firefox")
        Catch ex As Exception
            MsgBox("BobKIOSK couldn't open Mozilla Firefox! Please reinstall BobKIOSK to fix this problem.", MsgBoxStyle.Exclamation, "An error has occured!")
        End Try
    End Sub

    Private Sub SettingsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SettingsToolStripMenuItem.Click
        pane.MdiParent = Me
        pane.Show()
    End Sub

    Private Sub BPOSSoftwareCenterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPOSSoftwareCenterToolStripMenuItem.Click
        Try
            Shell("bpossc.exe")
        Catch ex As Exception
            bpsc.Show()
        End Try
    End Sub



    Private Sub SearchToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchToolStripMenuItem.Click
        Dim searchinput As String = InputBox("Enter Search Term:", "NewExplorer Search")
        Dim searchbase As String = My.Resources.SearchDoc.ToString.ToString.ToString.ToString
        Dim searh As String = searchbase.Replace("abcdefg", searchinput)
        If My.Computer.FileSystem.FileExists(Application.UserAppDataPath + "\tempsearch.search-ms") = False Then
            File.Create(Application.UserAppDataPath + "\tempsearch.search-ms").Dispose()
        End If
        Dim objWriter As New System.IO.StreamWriter(Application.UserAppDataPath + "\tempsearch.search-ms")
        objWriter.Write(searh)
        objWriter.Close()
        NewExplorer.MdiParent = Me
        NewExplorer.Show()
    End Sub

    Private Sub UsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UsToolStripMenuItem.Click
        Dim powerstatus As PowerStatus = SystemInformation.PowerStatus

        ' Gets the current battery charge status.
        MessageBox.Show("BatteryChargeStatus : " & powerstatus.BatteryChargeStatus)

        ' Gets the reported full charge lifetime of the primary battery power source in seconds.
        MessageBox.Show("BatteryFullLifetime : " & powerstatus.BatteryFullLifetime)

        ' Gets the approximate amount of full battery charge remaining.
        MessageBox.Show("BatteryLifePercent : " & powerstatus.BatteryLifePercent)

        ' Gets the approximate number of seconds of battery time remaining.
        MessageBox.Show("BatteryLifeRemaining : " & powerstatus.BatteryLifeRemaining)

        ' Gets the current system power status.
        MessageBox.Show("PowerLineStatus : " & powerstatus.PowerLineStatus)
    End Sub

    Private Sub OnScreenKeyboardToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Process.Start("osk.exe")
    End Sub

    Private Sub MagnifyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Process.Start("magnify.exe")
    End Sub

    Private Sub NarratorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Process.Start("narrator.exe")
    End Sub

    Private Sub User2ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles User2ToolStripMenuItem.Click
        NewExplorer.Show()
    End Sub

    Private Sub Form_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        e.Cancel = True
    End Sub

    Private Sub BarSettingsToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BarSettingsToolStripMenuItem.Click
        barsetting.MdiParent = Me
        barsetting.Show()
    End Sub

    Private Sub ToolStripDropDownButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewMenuButton.Click
        newbarmenu.Show()
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        Dim searchbase As String = My.Resources.SearchDoc.ToString.ToString.ToString.ToString
        Dim searh As String = searchbase.Replace("abcdefg", ToolStripTextBox1.Text)
        If My.Computer.FileSystem.FileExists(Application.UserAppDataPath + "\tempsearch.search-ms") = False Then
            File.Create(Application.UserAppDataPath + "\tempsearch.search-ms").Dispose()
        End If
        Dim objWriter As New System.IO.StreamWriter(Application.UserAppDataPath + "\tempsearch.search-ms")
        objWriter.Write(searh)
        objWriter.Close()
        Process.Start("Newexplorer.exe")
    End Sub
End Class
