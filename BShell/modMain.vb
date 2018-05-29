Module modMain
    Public Const strDonate As String = "http://www.aiglemedia.com/donate.php"

    Public formMain As Form
    Public formSettings As barsetting


    Public BPOSexplorer As ApplicationBar
    Public niMain As New NotifyIcon

    Private frmToload As New Form
    Private mainMenu As New ContextMenu
    Public MainFormLoaded As Boolean

    Public Sub main()

        formMain = New Form
        formSettings = New barsetting

        AddHandler niMain.MouseDoubleClick, AddressOf niMain_MouseDoubleClick
        AddHandler niMain.MouseDown, AddressOf niMain_MouseDown

        niMain.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath)
        niMain.Visible = True

        MainFormLoaded = False

        frmToload = formMain

        frmToload.Show()
        Application.Run()
    End Sub

    Public Sub ExitApp()
 
    End Sub

    Private Sub niMain_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        formMain.Activate()
    End Sub

    Private Sub niMain_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        mainMenu.MenuItems.Clear()
        If MainFormLoaded Then
            With mainMenu.MenuItems.Add("&Show")
                .Name = "mnuShow"
                AddHandler .Click, AddressOf mainMenu_Click
            End With
        End If
        With mainMenu.MenuItems.Add("&Donate")
            .Name = "mnuDonate"
            AddHandler .Click, AddressOf mainMenu_Click
        End With
        With mainMenu.MenuItems.Add("&About")
            .Name = "mnuAbout"
            AddHandler .Click, AddressOf mainMenu_Click
        End With
        With mainMenu.MenuItems.Add("&Exit")
            .Name = "mnuExit"
            AddHandler .Click, AddressOf mainMenu_Click
        End With
        niMain.ContextMenu = mainMenu
    End Sub

    Private Sub mainMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Select Case CType(sender, MenuItem).Name

        End Select
    End Sub

    Public Sub donate()
        System.Diagnostics.Process.Start(strDonate)
    End Sub

End Module
