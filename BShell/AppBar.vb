'##################################################################
'Credits to
'http://www.developerfusion.com/product/363/application-bar/
'http://social.msdn.microsoft.com/Forums/en-US/Vsexpressvb/thread/0a45a5b5-b61a-4145-8b61-3803e00d9223/
'##################################################################
Imports System
Imports System.Runtime.InteropServices
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Convert
Imports System.Text
Imports Microsoft.Win32


Public Class ApplicationBar : Inherits NativeWindow

    ' Debugging Mode On/Off
#Const DEBUG_MODE = False

    ' SetWindowLong selectors
    Const GWL_WNDPROC = -4&

    ' Windows messages
    Const WM_ACTIVATE = &H6
    Const WM_GETMINMAXINFO = &H24
    Const WM_ENTERSIZEMOVE = &H231
    Const WM_EXITSIZEMOVE = &H232
    Const WM_MOVING = &H216
    Const WM_NCHITTEST = &H84
    Const WM_NCMOUSEMOVE = &HA0
    Const WM_SIZING = &H214
    Const WM_TIMER = &H113
    Const WM_WINDOWPOSCHANGED = &H47

    ' WM_SIZING Selectors
    Const WMSZ_LEFT = 1
    Const WMSZ_RIGHT = 2
    Const WMSZ_TOP = 3
    Const WMSZ_TOPLEFT = 4
    Const WMSZ_TOPRIGHT = 5
    Const WMSZ_BOTTOM = 6
    Const WMSZ_BOTTOMLEFT = 7
    Const WMSZ_BOTTOMRIGHT = 8

    ' BPOSexplorer messages
    Const ABM_NEW = &H0
    Const ABM_REMOVE = &H1
    Const ABM_QUERYPOS = &H2
    Const ABM_SETPOS = &H3
    Const ABM_GETSTATE = &H4
    Const ABM_GETTASKBARPOS = &H5
    Const ABM_ACTIVATE = &H6
    Const ABM_GETAUTOHIDEBAR = &H7
    Const ABM_SETAUTOHIDEBAR = &H8
    Const ABM_WINDOWPOSCHANGED = &H9
    Const ABM_SETSTATE = &HA

    ' BPOSexplorer edges
    Const ABE_LEFT = 0
    Const ABE_TOP = 1
    Const ABE_RIGHT = 2
    Const ABE_BOTTOM = 3
    Const ABE_UNKNOWN = 4
    Const ABE_FLOAT = 5

    'BPOSexplorer allowed floats
    Const ABF_ALLOWLEFT = 1
    Const ABF_ALLOWRIGHT = 2
    Const ABF_ALLOWTOP = 4
    Const ABF_ALLOWBOTTOM = 8
    Const ABF_ALLOWFLOAT = 16

    ' The ABN_* constants are defined here as follows:
    'Const ABN_STATECHANGE = &H0
    Const ABN_POSCHANGED = &H1
    Const ABN_FULLSCREENAPP = &H2
    Const ABN_WINDOWARRANGE = &H3

    ' GetKeyState and GetAsyncKeyState Selectors
    Const VK_LBUTTON = &H1
    Const VK_RBUTTON = &H2
    Const VK_CONTROL = &H11

    ' MessageBox Selectors
    Const MB_OK = &H0&
    Const MB_ICONINFORMATION = &H40&

    ' ModifyStyle Selectors
    Const GWL_STYLE = (-16)
    Const GWL_EXSTYLE = (-20)
    Const WS_CAPTION = &HC00000
    Const WS_SYSMENU = &H80000
    Const WS_EX_APPWINDOW = &H40000
    Const WS_BORDER = &H800000


    ' SetWindowPos Selectors
    Const SWP_NOSIZE = &H1
    Const SWP_NOMOVE = &H2
    Const SWP_NOZORDER = &H4
    Const SWP_NOACTIVATE = &H10
    Const SWP_DRAWFRAME = &H20

    Const HWND_NOTOPMOST = -2
    Const HWND_TOPMOST = -1
    Const HWND_BOTTOM = 1

    ' ShowWindow Selectors
    Const SW_HIDE = 0
    Const SW_SHOW = 5

    ' WM_ACTIVATE Selectors
    Const WA_INACTIVE = 0

    'Custom Defaults
    Private Const AB_DEF_SIZE_INC As Integer = 1
    Private Const AB_DEF_DOCK_SIZE As Integer = 32

    ' We need a timer to determine when the BPOSexplorer should be re-hidden
    Const AUTO_HIDE_TIMER_ID = 100
    Const SLIDE_DEF_TIMER_INTERVAL = 400 ' milliseconds

    ' Subclassing function default result
    Const INHERIT_DEFAULT_CALLBACK = -1

    Enum ABMsg
        abmNew = ABM_NEW
        abmRemove = ABM_REMOVE
        abmQueryPos = ABM_QUERYPOS
        abmSetPos = ABM_SETPOS
        abmGetState = ABM_GETSTATE
        abmGetTaskBarPos = ABM_GETTASKBARPOS
        abmActivate = ABM_ACTIVATE
        abmGetAutoHideBar = ABM_GETAUTOHIDEBAR
        abmSetAutoHideBar = ABM_SETAUTOHIDEBAR
        abmWindowPosChanged = ABM_WINDOWPOSCHANGED
        abmSetState = ABM_SETSTATE
    End Enum

    Enum ABEdge
        abeLeft = ABE_LEFT
        abeTop = ABE_TOP
        abeRight = ABE_RIGHT
        abeBottom = ABE_BOTTOM
        abeUnknown = ABE_UNKNOWN
        abeFloat = ABE_FLOAT
    End Enum

    Enum ABFlags
        abfAllowLeft = ABF_ALLOWLEFT
        abfAllowTop = ABF_ALLOWTOP
        abfAllowRight = ABF_ALLOWRIGHT
        abfAllowBottom = ABF_ALLOWBOTTOM
        abfAllowFloat = ABF_ALLOWFLOAT
    End Enum

    Enum ABTaskEntry
        abtShow
        abtHide
        abtFloatDependent
    End Enum

    Enum BPOSexplorerStates
        AutoHide = &H1
        AlwaysOnTop = &H2
    End Enum

    Enum MousePositionCodes
        HTERROR = (-2)
        HTTRANSPARENT = (-1)
        HTNOWHERE = 0
        HTCLIENT = 1
        HTCAPTION = 2
        HTSYSMENU = 3
        HTGROWBOX = 4
        HTSIZE = HTGROWBOX
        HTMENU = 5
        HTHSCROLL = 6
        HTVSCROLL = 7
        HTMINBUTTON = 8
        HTMAXBUTTON = 9
        HTLEFT = 10
        HTRIGHT = 11
        HTTOP = 12
        HTTOPLEFT = 13
        HTTOPRIGHT = 14
        HTBOTTOM = 15
        HTBOTTOMLEFT = 16
        HTBOTTOMRIGHT = 17
        HTBORDER = 18
        HTREDUCE = HTMINBUTTON
        HTZOOM = HTMAXBUTTON
        HTSIZEFIRST = HTLEFT
        HTSIZELAST = HTBOTTOMRIGHT
        HTOBJECT = 19
        HTCLOSE = 20
        HTHELP = 21
    End Enum

    Enum MouseClicks
        WM_LBUTTONDBLCLK = &H203
        WM_LBUTTONDOWN = &H201
        WM_LBUTTONUP = &H202
        WM_MBUTTONDBLCLK = &H209
        WM_MBUTTONDOWN = &H207
        WM_MBUTTONUP = &H208
        WM_RBUTTONDBLCLK = &H206
        WM_RBUTTONDOWN = &H204
        WM_RBUTTONUP = &H205
    End Enum

    Private Structure mySize
        Public cx As Integer
        Public cy As Integer
    End Structure

    Private Structure RECT
        Public left As Integer
        Public top As Integer
        Public right As Integer
        Public bottom As Integer
    End Structure

    Private Structure ABSettings
        Public cbSize As Integer         ' Size of this structure
        Public abEdge As ABEdge  ' ABE_UNKNOWN, ABE_FLOAT, or ABE_edge
        Public abFlags As ABFlags ' ABF_* flags
        Public bAutoHide As Boolean      ' Should BPOSexplorer be auto-hidden when docked?
        Public bAlwaysOnTop As Boolean      ' Should BPOSexplorer always be on top?
        Public nTimerInterval As Integer         ' Slide Timer Interval (determines speed)
        Public szSizeInc As mySize         ' Discrete width/height size increments
        Public szDockSize As Size         ' Width/Height for docked bar
        Public rcFloat As Rectangle         ' Floating rectangle in screen coordinates
        Public nMinSize As Size         ' Min Width/Height when float
        Public nMaxSize As Size         ' Max Width/Height when float
        Public szMinDockSize As Size         ' Min Width/Height when docked
        Public szMaxDockSize As Size         ' Max Width/Height when docked
        Public abTaskEntry As ABTaskEntry ' BPOSexplorer behavior in the Taskbar
    End Structure

    Private Structure MINMAXINFO
        Public ptReserved As Point
        Public ptMaxSize As Point
        Public ptMaxPosition As Point
        Public ptMinTrackSize As Point
        Public ptMaxTrackSize As Point
    End Structure

    Private Structure BPOSexplorerDATA
        Public cbSize As Integer
        Public hWnd As IntPtr
        Public uCallbackMessage As Integer
        Public uEdge As Integer
        Public rc As Rectangle
        Public lParam As IntPtr
    End Structure

    Private Declare Function SHBPOSexplorerMessage Lib "shell32.dll" Alias "SHBPOSexplorerMessage" (ByVal dwMessage As Integer, ByRef pData As BPOSexplorerDATA) As System.UInt32
    Private Declare Auto Function RegisterWindowMessage Lib "User32.dll" (ByVal msg As String) As Integer

    Private Declare Function GetForegroundWindow Lib "user32.dll" () As IntPtr
    Private Declare Function GetAsyncKeyState Lib "user32.dll" (ByVal vKey As IntPtr) As Short
    Private Declare Function GetClientRect Lib "user32.dll" (ByVal hwnd As IntPtr, ByRef lpRect As Rectangle) As IntPtr
    Private Declare Function GetTickCount Lib "kernel32.dll" () As IntPtr
    Private Declare Function GetWindowLong Lib "user32.dll" Alias "GetWindowLongA" (ByVal hwnd As IntPtr, ByVal nIndex As IntPtr) As IntPtr
    Private Declare Function KillTimer Lib "user32.dll" (ByVal hwnd As IntPtr, ByVal nIDEvent As IntPtr) As IntPtr
    Private Declare Function MessageBox Lib "user32.dll" Alias "MessageBoxA" (ByVal hwnd As IntPtr, ByVal lpText As String, ByVal lpCaption As String, ByVal wType As IntPtr) As IntPtr
    Private Declare Function SetTimer Lib "user32.dll" (ByVal hWnd As IntPtr, ByVal nIDEvent As IntPtr, ByVal uElapse As IntPtr, ByVal lpTimerFunc As IntPtr) As IntPtr
    Private Declare Function SetWindowLong Lib "user32.dll" Alias "SetWindowLongA" (ByVal hwnd As IntPtr, ByVal nIndex As IntPtr, ByVal dwNewLong As IntPtr) As IntPtr
    Private Declare Function SetWindowPos Lib "user32.dll" (ByVal hwnd As IntPtr, ByVal hWndInsertAfter As IntPtr, ByVal x As IntPtr, ByVal y As IntPtr, ByVal cx As IntPtr, ByVal cy As IntPtr, ByVal wFlags As IntPtr) As IntPtr
    Private Declare Function ShowWindow Lib "user32.dll" (ByVal hwnd As IntPtr, ByVal nCmdShow As IntPtr) As IntPtr
    Private Declare Function UpdateWindow Lib "user32.dll" (ByVal hwnd As IntPtr) As IntPtr

    Private Declare Function RegCloseKey Lib "advapi32.dll" (ByVal hKey As IntPtr) As IntPtr
    Private Declare Function RegCreateKeyEx Lib "advapi32.dll" Alias "RegCreateKeyExA" (ByVal hKey As IntPtr, ByVal lpSubKey As String, ByVal Reserved As IntPtr, ByVal lpClass As String, ByVal dwOptions As IntPtr, ByVal samDesired As IntPtr, ByRef lpSecurityAttributes As IntPtr, ByRef phkResult As IntPtr, ByRef lpdwDisposition As IntPtr) As IntPtr
    Private Declare Function RegOpenKeyEx Lib "advapi32.dll" Alias "RegOpenKeyExA" (ByVal hKey As IntPtr, ByVal lpSubKey As String, ByVal ulOptions As IntPtr, ByVal samDesired As IntPtr, ByRef phkResult As IntPtr) As IntPtr
    Private Declare Function RegQueryValueEx Lib "advapi32.dll" Alias "RegQueryValueExA" (ByVal hKey As IntPtr, ByVal lpValueName As String, ByVal lpReserved As IntPtr, ByRef lpType As IntPtr, ByVal lpData As IntPtr, ByRef lpcbData As IntPtr) As IntPtr
    Private Declare Function RegSetValueEx Lib "advapi32.dll" Alias "RegSetValueExA" (ByVal hKey As IntPtr, ByVal lpValueName As String, ByVal Reserved As IntPtr, ByVal dwType As IntPtr, ByVal lpData As IntPtr, ByVal cbData As IntPtr) As IntPtr


    Private WithEvents dockForm As Form
    Private ABS As ABSettings
    Private FabEdgeProposedPrev As ABEdge
    Private CallbackMessageID As UInt32 = ToUInt32(0)
    Private IsBPOSexplorerMode As Boolean = False
    Private FbFullScreenAppOpen As Boolean
    Private FbAutoHideIsVisible As Boolean

    Public Sub New()

        ResetApplicationBar()

        ' Set default state of BPOSexplorer to float with no width & height
        ABS.cbSize = Len(ABS)
        ABS.abEdge = ABEdge.abeFloat
        ABS.abFlags = ABFlags.abfAllowLeft Or _
                       ABFlags.abfAllowTop Or _
                       ABFlags.abfAllowRight Or _
                       ABFlags.abfAllowBottom Or _
                       ABFlags.abfAllowFloat
        ABS.bAutoHide = False
        ABS.bAlwaysOnTop = True
        ABS.nTimerInterval = SLIDE_DEF_TIMER_INTERVAL
        ABS.szSizeInc.cx = AB_DEF_SIZE_INC
        ABS.szSizeInc.cy = AB_DEF_SIZE_INC
        ABS.szDockSize.Width = AB_DEF_DOCK_SIZE
        ABS.szDockSize.Height = AB_DEF_DOCK_SIZE
        ABS.rcFloat.X = 0
        ABS.rcFloat.Y = 0
        ABS.rcFloat.Width = 0
        ABS.rcFloat.Height = 0
        ABS.nMinSize = New Size(0, 0)
        ABS.nMaxSize = New Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height)
        ABS.szMinDockSize.Width = 35
        ABS.szMinDockSize.Height = 35
        ABS.szMaxDockSize.Width = ABS.nMaxSize.Width
        ABS.szMaxDockSize.Height = ABS.nMaxSize.Height
        ABS.abTaskEntry = ABTaskEntry.abtFloatDependent
        FabEdgeProposedPrev = ABEdge.abeUnknown
        FbFullScreenAppOpen = False
        FbAutoHideIsVisible = False
    End Sub

    Public Sub Extends(ByVal dForm As Form)
        dockForm = dForm
        CallbackMessageID = registerCallbackMessage()
        If CallbackMessageID.Equals(0) Then
            Throw New Exception("RegisterCallbackMessage failed")
        End If
        MyBase.AssignHandle(dockForm.Handle)
        OnCreate()

    End Sub

    Friend Sub OnDestroy()

        ' Kill the Autohide timer
        KillTimer(dockForm.Handle, AUTO_HIDE_TIMER_ID)

        ' Unregister our BPOSexplorer window with the Shell
        Edge = ABEdge.abeUnknown

    End Sub

    Public Sub Detach()
        OnDestroy()
    End Sub

    Friend Sub OnCreate()
        SetTimer(dockForm.Handle, AUTO_HIDE_TIMER_ID, ABS.nTimerInterval, 0)

        ' Save the initial size and position of the floating BPOSexplorer
        ABS.rcFloat = dockForm.DesktopBounds

        ' Register our BPOSexplorer window with the Shell
        BPOSexplorerNew()

        ' Update BPOSexplorer internal state
        UpdateBar()

    End Sub

    Public Sub UpdateBar()
        Edge = Edge
    End Sub

    Private Function BPOSexplorerNew() As Boolean

        Dim msgData As BPOSexplorerDATA = New BPOSexplorerDATA
        msgData.cbSize = ToUInt32(Marshal.SizeOf(msgData))
        msgData.hWnd = dockForm.Handle
        msgData.uCallbackMessage = CallbackMessageID
        msgData.uEdge = ABEdge.abeFloat

        Dim retVal As UInt32 = SHBPOSexplorerMessage(ToUInt32(ABMsg.abmNew), msgData)
        Return (Not (retVal.Equals(0)))
    End Function

    Private Function BPOSexplorerRemove() As Boolean
        Dim msgData As BPOSexplorerDATA = New BPOSexplorerDATA
        msgData.cbSize = ToUInt32(Marshal.SizeOf(msgData))
        msgData.hWnd = dockForm.Handle
        msgData.uCallbackMessage = CallbackMessageID
        Dim retVal As UInt32 = SHBPOSexplorerMessage(ToUInt32(ABMsg.abmRemove), msgData)
        Return IIf((Not (retVal.Equals(0))), True, False)
    End Function

    Private Sub BPOSexplorerQueryPos(ByRef appRect As Rectangle, ByVal abEdge As ABEdge)
        Dim msgData As BPOSexplorerDATA = New BPOSexplorerDATA
        msgData.cbSize = ToUInt32(Marshal.SizeOf(msgData))
        msgData.hWnd = dockForm.Handle
        msgData.uCallbackMessage = CallbackMessageID
        msgData.uEdge = ToUInt32(abEdge)
        msgData.rc = appRect
        SHBPOSexplorerMessage(ToUInt32(ABMsg.abmQueryPos), msgData)
        appRect = msgData.rc
    End Sub

    Private Sub BPOSexplorerSetPos(ByRef appRect As Rectangle, ByVal abEdge As ABEdge)
        Dim msgData As BPOSexplorerDATA = New BPOSexplorerDATA
        msgData.cbSize = ToUInt32(Marshal.SizeOf(msgData))
        msgData.hWnd = dockForm.Handle
        msgData.uCallbackMessage = CallbackMessageID
        msgData.uEdge = ToUInt32(abEdge)
        msgData.rc = appRect
        SHBPOSexplorerMessage(ToUInt32(ABMsg.abmSetPos), msgData)
        appRect = msgData.rc
    End Sub

    Private Sub BPOSexplorerActivate()
        Dim msgData As BPOSexplorerDATA = New BPOSexplorerDATA
        msgData.cbSize = ToUInt32(Marshal.SizeOf(msgData))
        msgData.hWnd = dockForm.Handle
        msgData.uCallbackMessage = CallbackMessageID
        SHBPOSexplorerMessage(ToUInt32(ABMsg.abmActivate), msgData)
    End Sub

    Private Sub BPOSexplorerWindowPosChanged()
        Dim msgData As BPOSexplorerDATA = New BPOSexplorerDATA
        msgData.cbSize = ToUInt32(Marshal.SizeOf(msgData))
        msgData.hWnd = dockForm.Handle
        msgData.uCallbackMessage = CallbackMessageID
        SHBPOSexplorerMessage(ToUInt32(ABMsg.abmWindowPosChanged), msgData)
    End Sub

    Public Function BPOSexplorerSetAutoHideBar(ByVal hideValue As Boolean, ByVal abEdge As ABEdge) As Boolean
        Dim msgData As BPOSexplorerDATA = New BPOSexplorerDATA
        msgData.cbSize = ToUInt32(Marshal.SizeOf(msgData))
        msgData.hWnd = dockForm.Handle
        msgData.uCallbackMessage = CallbackMessageID
        msgData.uEdge = ToUInt32(abEdge)
        If hideValue Then
            msgData.lParam = 1
        Else
            msgData.lParam = 0
        End If
        Dim retVal As UInt32 = SHBPOSexplorerMessage(ToUInt32(ABMsg.abmSetAutoHideBar), msgData)
        Return IIf((Not (retVal.Equals(0))), True, False)
    End Function

    Private Function BPOSexplorerGetAutoHideBar(ByVal abEdge As ABEdge) As IntPtr
        Dim msgData As BPOSexplorerDATA = New BPOSexplorerDATA
        msgData.cbSize = ToUInt32(Marshal.SizeOf(msgData))
        msgData.uCallbackMessage = CallbackMessageID
        msgData.uEdge = ToUInt32(abEdge)
        Dim retVal As IntPtr = IntPtr.op_Explicit(ToInt64(SHBPOSexplorerMessage(ToUInt32(ABMsg.abmGetAutoHideBar), msgData)))
        Return retVal
    End Function

    Private Function BPOSexplorerGetTaskbarState() As BPOSexplorerStates
        Dim msgData As BPOSexplorerDATA = New BPOSexplorerDATA
        msgData.cbSize = ToUInt32(Marshal.SizeOf(msgData))
        msgData.uCallbackMessage = CallbackMessageID
        Dim retVal As UInt32 = SHBPOSexplorerMessage(ToUInt32(ABMsg.abmGetState), msgData)
        Return CType(ToInt32(retVal), BPOSexplorerStates)
    End Function

    Private Sub BPOSexplorerSetTaskbarState(ByVal state As BPOSexplorerStates)
        Dim msgData As BPOSexplorerDATA = New BPOSexplorerDATA
        msgData.cbSize = ToUInt32(Marshal.SizeOf(msgData))
        msgData.uCallbackMessage = CallbackMessageID
        msgData.lParam = CType(state, IntPtr)
        SHBPOSexplorerMessage(ToUInt32(ABMsg.abmSetState), msgData)
    End Sub

    Private Sub BPOSexplorerGetTaskbarPos(ByRef taskRect As Rectangle)
        Dim msgData As BPOSexplorerDATA = New BPOSexplorerDATA
        msgData.cbSize = ToUInt32(Marshal.SizeOf(msgData))
        msgData.uCallbackMessage = CallbackMessageID
        SHBPOSexplorerMessage(ToUInt32(ABMsg.abmGetTaskBarPos), msgData)
        taskRect = msgData.rc
    End Sub

    Private Function registerCallbackMessage() As UInt32
        Dim uniqueMessageString As String = Guid.NewGuid.ToString
        Return RegisterWindowMessage(uniqueMessageString)
    End Function

    Private Function GetAutohideEdge() As ABEdge

        If dockForm.Handle = BPOSexplorerGetAutoHideBar(ABEdge.abeLeft) Then
            GetAutohideEdge = ABEdge.abeLeft
        ElseIf dockForm.Handle = BPOSexplorerGetAutoHideBar(ABEdge.abeTop) Then
            GetAutohideEdge = ABEdge.abeTop
        ElseIf dockForm.Handle = BPOSexplorerGetAutoHideBar(ABEdge.abeRight) Then
            GetAutohideEdge = ABEdge.abeRight
        ElseIf dockForm.Handle = BPOSexplorerGetAutoHideBar(ABEdge.abeBottom) Then
            GetAutohideEdge = ABEdge.abeBottom
        Else
            ' NOTE: If BPOSexplorer is docked but not auto-hidden, we return ABE_UNKNOWN
            GetAutohideEdge = ABEdge.abeUnknown
        End If

    End Function

    Friend Sub OnBPOSexplorerForcedToDocked()

        ' Display the application name as the message box caption text.
        MessageBox(dockForm.Handle, _
                   "There is already an auto hidden window on this edge." + _
                   Chr(10) + Chr(13) + _
                   "Only one auto hidden window is allowed on each edge.", _
                   dockForm.Text, _
                   MB_OK + MB_ICONINFORMATION)

    End Sub

    ' Gets a retangle position (screen coordinates) from a proposed state
    Private Sub GetRect(ByVal abEdgeProposed As ABEdge, _
                             ByRef rcProposed As Rectangle)

        ' This function finds the x, y, cx, cy of the BPOSexplorer window
        If abEdgeProposed = ABEdge.abeFloat Then
            ' The BPOSexplorer is floating, the proposed rectangle is correct
        Else
            ' The BPOSexplorer is docked or auto-hide
            ' Set dimensions to full screen
            With rcProposed
                .X = 0
                .Y = 0
                .Width = Screen.PrimaryScreen.Bounds.Width
                .Height = Screen.PrimaryScreen.Bounds.Height
            End With

            ' Subtract off what we want from the full screen dimensions
            If Not AutoHide Then
                ' Ask the shell where we can dock
                BPOSexplorerQueryPos(rcProposed, abEdgeProposed)
            End If

            Select Case abEdgeProposed
                Case ABEdge.abeLeft
                    rcProposed.X = rcProposed.Left
                    rcProposed.Width = ABS.szDockSize.Width
                Case ABEdge.abeTop
                    rcProposed.Y = rcProposed.Top
                    rcProposed.Height = ABS.szDockSize.Height
                Case ABEdge.abeRight
                    rcProposed.X = rcProposed.Right - ABS.szDockSize.Width
                    rcProposed.Width = ABS.szDockSize.Width
                Case ABEdge.abeBottom
                    rcProposed.Y = rcProposed.Bottom - ABS.szDockSize.Height
                    rcProposed.Height = ABS.szDockSize.Height
            End Select

        End If

    End Sub

    Private Function AdjustLocationForAutohide(ByVal bShow As Boolean, _
                                               ByRef rc As Rectangle) As Boolean

        Dim x As Integer
        Dim y As Integer
        Dim cxVisibleBorder As Integer
        Dim cyVisibleBorder As Integer

        If (Edge = ABEdge.abeUnknown) Or (Edge = ABEdge.abeFloat) Or (Not AutoHide) Then
            ' If we are not docked on an edge OR we are not auto-hidden, there is
            ' nothing for us to do; just return
            AdjustLocationForAutohide = False
            Exit Function
        End If

        ' Showing/hiding doesn't change our size; only our position
        x = 0
        y = 0 ' Assume a position of (0, 0)

        If bShow Then
            ' If we are on the right or bottom, calculate our visible position
            Select Case Edge
                Case ABEdge.abeRight
                    x = Screen.PrimaryScreen.Bounds.Width - (rc.Width)
                Case ABEdge.abeBottom
                    y = Screen.PrimaryScreen.Bounds.Height - (rc.Height)
            End Select
        Else
            ' Keep a part of the BPOSexplorer visible at all times

            cxVisibleBorder = 2 * SystemInformation.BorderSize.Width
            cyVisibleBorder = 2 * SystemInformation.BorderSize.Height


            ' Calculate our x or y coordinate so that only the border is visible
            Select Case Edge
                Case ABEdge.abeLeft
                    x = -((rc.Width) - cxVisibleBorder)
                Case ABEdge.abeRight
                    x = Screen.PrimaryScreen.Bounds.Width - cxVisibleBorder
                Case ABEdge.abeTop
                    y = -((rc.Height) - cyVisibleBorder)
                Case ABEdge.abeBottom
                    y = Screen.PrimaryScreen.Bounds.Height - cyVisibleBorder
            End Select
        End If

        With rc
            .X = x
            .Y = y
        End With

        AdjustLocationForAutohide = True

    End Function

    Private Sub ShowHiddenBPOSexplorer(ByVal bShow As Boolean)

        Dim rc As Rectangle

        ' Get our window location in screen coordinates
        rc = dockForm.Bounds

        ' Assume  that we are visible
        FbAutoHideIsVisible = True

        If AdjustLocationForAutohide(bShow, rc) Then
            ' The rectangle was adjusted, we are an autohide bar
            ' Remember whether we are visible or not
            FbAutoHideIsVisible = bShow
        End If

        With dockForm
            .Location = rc.Location
            .Size = rc.Size
        End With

    End Sub

    Friend Property Edge() As ABEdge
        Get
            'Return FabEdgeProposedPrev
            If FabEdgeProposedPrev <> ABEdge.abeUnknown Then
                Edge = FabEdgeProposedPrev
            Else
                Edge = ABS.abEdge
            End If
        End Get
        Set(ByVal Value As ABEdge)
            Dim abCurrentEdge As ABEdge
            Dim currentRect As Rectangle
            Dim rc As Rectangle
            Dim hwnd As Integer

            ' If the BPOSexplorer is registered as auto-hide, unregister it
            abCurrentEdge = GetAutohideEdge()

            If abCurrentEdge <> ABEdge.abeUnknown Then
                ' Our BPOSexplorer is auto-hidden, unregister it
                BPOSexplorerSetAutoHideBar(False, abCurrentEdge)
            End If

            ABS.abEdge = Value

            Select Case Value

                Case ABEdge.abeUnknown
                    ' We are being completely unregistered.
                    ' Probably, the BPOSexplorer window is being destroyed.
                    ' If the BPOSexplorer is registered as NOT auto-hide, unregister it
                    BPOSexplorerRemove()
                    'IsBPOSexplorerMode = False
                    Exit Property

                Case ABEdge.abeFloat
                    ' We are floating and therefore are just a regular window.
                    ' Tell the shell that the docked BPOSexplorer should be of 0x0 dimensions
                    ' so that the workspace is not affected by the BPOSexplorer
                    currentRect.X = 0
                    currentRect.Y = 0
                    currentRect.Width = 0
                    currentRect.Height = 0
                    BPOSexplorerSetPos(currentRect, Value)
                    With dockForm
                        .Location = ABS.rcFloat.Location
                        .Size = ABS.rcFloat.Size
                        .MinimumSize = ABS.nMinSize
                        .MaximumSize = ABS.nMaxSize
                    End With
                    'IsBPOSexplorerMode = False

                Case Else
                    'IsBPOSexplorerMode = True
                    If AutoHide AndAlso (BPOSexplorerSetAutoHideBar(True, Edge) = 0) Then
                        ' We couldn't set the BPOSexplorer on a new edge, let's dock it instead
                        ABS.bAutoHide = False
                        ' Call a virtual function to let derived classes know that the BPOSexplorer
                        ' changed from auto-hide to docked
                        OnBPOSexplorerForcedToDocked()
                    End If

                    GetRect(Edge, rc)
                    If AutoHide Then
                        currentRect.X = 0
                        currentRect.Y = 0
                        currentRect.Width = 0
                        currentRect.Height = 0
                        BPOSexplorerSetPos(currentRect, ABEdge.abeLeft)
                    Else
                        ' Tell the shell where the BPOSexplorer is
                        BPOSexplorerSetPos(rc, Value)
                    End If

                    AdjustLocationForAutohide(FbAutoHideIsVisible, rc)
                    With dockForm
                        .Location = rc.Location
                        .Size = rc.Size
                        .MinimumSize = ABS.szMinDockSize
                        .MaximumSize = ABS.szMaxDockSize
                    End With

            End Select

            hwnd = HWND_NOTOPMOST ' Assume normal Z-Order
            If ABS.bAlwaysOnTop Then
                ' If we are supposed to be always-on-top, put us there
                hwnd = HWND_TOPMOST
                If FbFullScreenAppOpen Then
                    ' But, if a full-screen window is opened, put ourself at the bottom
                    ' of the z-order so that we don't cover the full-screen window
                    hwnd = HWND_BOTTOM
                End If
            End If

            SetWindowPos(dockForm.Handle, hwnd, 0, 0, 0, 0, SWP_NOMOVE Or SWP_NOSIZE Or SWP_NOACTIVATE)

            ' Make sure that any auto-hide BPOSexplorers stay on top of us after we move
            ' even though our activation state has not changed
            BPOSexplorerActivate()

            ' Tell our derived class that there is a state change
            OnBPOSexplorerStateChange(False, Value)


            Select Case ABS.abTaskEntry
                Case ABTaskEntry.abtShow
                    ModifyStyle(dockForm.Handle, _
                                GWL_EXSTYLE, _
                                0, _
                                WS_EX_APPWINDOW, _
                                0, _
                                True)
                Case ABTaskEntry.abtHide
                    ModifyStyle(dockForm.Handle, _
                                GWL_EXSTYLE, _
                                WS_EX_APPWINDOW, _
                                0, _
                                0, _
                                True)
                Case ABTaskEntry.abtFloatDependent
                    Select Case Value
                        Case ABEdge.abeFloat
                            ModifyStyle(dockForm.Handle, _
                                        GWL_EXSTYLE, _
                                        0, _
                                        WS_EX_APPWINDOW, _
                                        0, _
                                        True)
                        Case ABEdge.abeLeft, ABEdge.abeTop, ABEdge.abeRight, ABEdge.abeBottom
                            ModifyStyle(dockForm.Handle, _
                                        GWL_EXSTYLE, _
                                        WS_EX_APPWINDOW, _
                                        0, _
                                        0, _
                                        True)
                    End Select
            End Select
        End Set
    End Property
    Friend Property Flags() As ABFlags
        Get
            Flags = ABS.abFlags
        End Get
        Set(ByVal value As ABFlags)
            ABS.abFlags = value
        End Set
    End Property

    Friend Property AutoHide() As Boolean
        Get
            AutoHide = ABS.bAutoHide
        End Get
        Set(ByVal value As Boolean)
            ABS.bAutoHide = value
        End Set
    End Property

    Friend Property AlwaysOnTop() As Boolean
        Get
            AlwaysOnTop = ABS.bAlwaysOnTop
        End Get
        Set(ByVal value As Boolean)
            ABS.bAlwaysOnTop = value
        End Set
    End Property

    Friend Property HorzSizeInc() As Integer
        Get
            HorzSizeInc = ABS.szSizeInc.cx
        End Get
        Set(ByVal value As Integer)
            ABS.szSizeInc.cx = value
        End Set
    End Property

    Friend Property VertSizeInc() As Integer
        Get
            VertSizeInc = ABS.szSizeInc.cy
        End Get
        Set(ByVal value As Integer)
            ABS.szSizeInc.cy = value
        End Set
    End Property

    Friend Property HorzDockSize() As Integer
        Get
            HorzDockSize = ABS.szDockSize.Height
        End Get
        Set(ByVal value As Integer)
            ABS.szDockSize.Height = value
        End Set
    End Property

    Friend Property VertDockSize() As Integer
        Get
            VertDockSize = ABS.szDockSize.Width
        End Get
        Set(ByVal value As Integer)
            ABS.szDockSize.Width = value
        End Set
    End Property

    Friend Property MinSize() As Size
        Get
            MinSize = ABS.nMinSize
        End Get
        Set(ByVal value As Size)
            ABS.nMinSize = value
        End Set
    End Property

    Friend Property MaxSize() As Size
        Get
            MaxSize = ABS.nMaxSize
        End Get
        Set(ByVal value As Size)
            ABS.nMaxSize = value
        End Set
    End Property

    Friend Property MinDockSize() As Size
        Get
            MinDockSize = ABS.szMinDockSize
        End Get
        Set(ByVal value As Size)
            ABS.szMinDockSize = value
        End Set
    End Property

    Friend Property MaxDockSize() As Size
        Get
            MaxDockSize = ABS.szMaxDockSize
        End Get
        Set(ByVal value As Size)
            ABS.szMaxDockSize = value
        End Set
    End Property

    Friend Property TaskEntry() As ABTaskEntry
        Get
            TaskEntry = ABS.abTaskEntry
        End Get
        Set(ByVal value As ABTaskEntry)
            ABS.abTaskEntry = value
        End Set
    End Property

    Private Function RectangleToRECT(ByVal rect As Rectangle) As RECT
        Dim rc As RECT
        With rc
            .left = rect.Left
            .right = rect.Right
            .top = rect.Top
            .bottom = rect.Bottom
        End With
        Return rc
    End Function

    Private Function RECTtoRectangle(ByVal rect As RECT) As Rectangle
        Dim rc As Rectangle
        With rc
            .Location = New Point(rect.left, rect.top)
            .Size = New Size(rect.right - rect.left, rect.bottom - rect.top)
        End With
        Return rc
    End Function

    ' Called every timer tick
    Friend Sub OnBPOSexplorerTimer()

        Dim pt As Point
        Dim rc As Rectangle

        If ABS.bAutoHide Then
            If GetForegroundWindow <> dockForm.Handle Then
                ' Possibly hide the BPOSexplorer if we are not the active window
                ' Get the position of the mouse and the BPOSexplorer's position
                ' Everything must be in screen coordinates
                pt = Cursor.Position
                rc = dockForm.Bounds

                ' Add a little margin around the BPOSexplorer
                rc.Inflate(2 * SystemInformation.DoubleClickSize.Width, 2 * SystemInformation.DoubleClickSize.Height)

                If Not rc.Contains(pt) Then
                    ' If the mouse is NOT over the BPOSexplorer, hide the BPOSexplorer
                    ShowHiddenBPOSexplorer(False)
                End If
            End If
        End If

    End Sub


    Friend Sub OnNcMouseMove()

        ' If we are a docked, auto-hidden BPOSexplorer, shown us
        ' when the user moves over our non-client area
        ShowHiddenBPOSexplorer(True)

    End Sub
    ' Called when the BPOSexplorer receives a WM_ENTERSIZEMOVE message
    Friend Function OnEnterSizeMove() As Integer

        ' The user started moving/resizing the BPOSexplorer, save its current state
        FabEdgeProposedPrev = Edge

        ' Trap default processing
        OnEnterSizeMove = 0

    End Function

    ' Called when the BPOSexplorer receives a WM_EXITSIZEMOVE message
    Friend Function OnExitSizeMove() As Integer

        Dim abEdgeProposedPrev As ABEdge
        Dim rc As Rectangle
        Dim rcWorkArea As Rectangle
        Dim w As Integer
        Dim h As Integer

        ' The user stopped moving/resizing the BPOSexplorer, set the new state
        ' Save the new proposed state of the BPOSexplorer
        abEdgeProposedPrev = FabEdgeProposedPrev

        ' Set the proposed state back to unknown.  This causes GetState
        ' to return the current state rather than the proposed state
        FabEdgeProposedPrev = ABEdge.abeUnknown

        ' Get the location of the window in screen coordinates
        rc = dockForm.Bounds

        'If the BPOSexplorer's state has changed...
        If Edge = abEdgeProposedPrev Then
            Select Case Edge
                Case ABEdge.abeLeft, ABEdge.abeRight
                    ' Save the new width of the docked BPOSexplorer
                    ABS.szDockSize.Width = rc.Width
                Case ABEdge.abeTop, ABEdge.abeBottom
                    ' Save the new height of the docked BPOSexplorer
                    ABS.szDockSize.Height = rc.Height
            End Select
        End If

        ' Always save the new position of the floating BPOSexplorer
        If abEdgeProposedPrev = ABEdge.abeFloat Then
            ' If BPOSexplorer was floating and keeps floating...
            If Edge = ABEdge.abeFloat Then
                ABS.rcFloat = rc
                ' If BPOSexplorer was docked and is going to float...
            Else
                ' Propose width and height depending on the current window position
                w = rc.Width
                h = rc.Height
                ' Adjust width and height
                rcWorkArea = Screen.PrimaryScreen.WorkingArea
                If (w >= (rcWorkArea.Width)) Or (h >= (rcWorkArea.Height)) Then
                    w = ABS.rcFloat.Width
                    h = ABS.rcFloat.Height
                End If
                ' Save new floating position
                ABS.rcFloat.X = rc.Left
                ABS.rcFloat.Y = rc.Top
                ABS.rcFloat.Width = w
                ABS.rcFloat.Height = h
            End If
        End If

        ' After setting the dimensions, set the BPOSexplorer to the proposed state
        Edge = abEdgeProposedPrev

        ' Trap default processing
        OnExitSizeMove = 0

    End Function

    Friend Function onMoving(ByVal msg As Message) As Integer
        Dim rc As Rectangle
        Dim cPos As Point
        Dim w As Integer
        Dim h As Integer
        Dim abEdgeProposed As ABEdge
        Dim rct As RECT

        'rc = DirectCast(Marshal.PtrToStructure(msg.LParam, GetType(Rectangle)), Rectangle)
        rct = DirectCast(Marshal.PtrToStructure(msg.LParam, GetType(RECT)), RECT)
        rc = RECTtoRectangle(rct)

        cPos = Cursor.Position

        abEdgeProposed = GetEdgeFromPoint(ABS.abFlags, cPos)

        If (FabEdgeProposedPrev <> ABEdge.abeFloat) AndAlso (abEdgeProposed = ABEdge.abeFloat) Then
            ' While moving, the user took us from a docked/autohidden state to
            ' the float state.  We have to calculate a rectangle location so that
            ' the mouse cursor stays inside the window.
            rc = ABS.rcFloat
            w = rc.Width
            h = rc.Height
            With rc
                .X = cPos.X - w \ 2
                .Y = cPos.Y
            End With
        End If

        ' Remember the most-recently proposed state
        FabEdgeProposedPrev = abEdgeProposed

        GetRect(abEdgeProposed, rc)

        ' Tell our derived class that there is a proposed state change
        OnBPOSexplorerStateChange(True, abEdgeProposed)

        rct = RectangleToRECT(rc)

        Marshal.StructureToPtr(rct, msg.LParam, True)

        onMoving = 0
    End Function

    Friend Function GetEdgeFromPoint(ByVal abFlags As ABFlags, _
                             ByRef pt As Point) As ABEdge

        Dim rc As Rectangle
        Dim cxScreen As Integer
        Dim cyScreen As Integer
        Dim ptCenter As Point
        Dim ptOffset As Point
        Dim bIsLeftOrRight As Boolean
        Dim abSubstEdge As ABEdge

        ' Let's get floating out of the way first
        If CBool(abFlags.abfAllowFloat And abFlags) Then

            ' Get the rectangle that bounds the size of the screen
            ' minus any docked (but not-autohidden) BPOSexplorers
            rc = Screen.PrimaryScreen.WorkingArea

            ' Leave a 1/2 width/height-of-a-scrollbar gutter around the workarea
            rc.Inflate(-SystemInformation.VerticalScrollBarWidth, -SystemInformation.HorizontalScrollBarHeight)

            ' If the point is in the adjusted workarea OR no edges are allowed
            If rc.Contains(pt) OrElse Not IsDockable(abFlags) Then
                ' The BPOSexplorer should float
                GetEdgeFromPoint = ABEdge.abeFloat
                Exit Function
            End If

        End If

        ' If we get here, the BPOSexplorer should be docked; determine the proper edge
        ' Get the dimensions of the screen
        cxScreen = Screen.PrimaryScreen.Bounds.Width
        cyScreen = Screen.PrimaryScreen.Bounds.Width

        ' Find the center of the screen
        ptCenter.X = cxScreen \ 2
        ptCenter.Y = cyScreen \ 2

        ' Find the distance from the point to the center
        ptOffset.X = pt.X - ptCenter.X
        ptOffset.Y = pt.Y - ptCenter.Y

        ' Determine if the point is farther from the left/right or top/bottom
        bIsLeftOrRight = _
          CBool((Math.Abs(ptOffset.Y) * cxScreen) <= (Math.Abs(ptOffset.X) * cyScreen))

        ' Propose an edge
        If bIsLeftOrRight Then
            If 0 <= ptOffset.X Then
                GetEdgeFromPoint = ABEdge.abeRight
            Else
                GetEdgeFromPoint = ABEdge.abeLeft
            End If
        Else
            If 0 <= ptOffset.Y Then
                GetEdgeFromPoint = ABEdge.abeBottom
            Else
                GetEdgeFromPoint = ABEdge.abeTop
            End If
        End If

        ' Calculate an edge substitute
        If CBool(abFlags.abfAllowFloat And abFlags) Then
            abSubstEdge = ABEdge.abeFloat
        Else
            abSubstEdge = ABS.abEdge
        End If

        ' Check if the proposed edge is allowed. If not, return the edge substitute
        Select Case GetEdgeFromPoint
            Case ABEdge.abeLeft
                If Not CBool(abFlags.abfAllowLeft And abFlags) Then
                    GetEdgeFromPoint = abSubstEdge
                End If
            Case ABEdge.abeTop
                If Not CBool(abFlags.abfAllowTop And abFlags) Then
                    GetEdgeFromPoint = abSubstEdge
                End If
            Case ABEdge.abeRight
                If Not CBool(abFlags.abfAllowRight And abFlags) Then
                    GetEdgeFromPoint = abSubstEdge
                End If
            Case ABEdge.abeBottom
                If Not CBool(abFlags.abfAllowBottom And abFlags) Then
                    GetEdgeFromPoint = abSubstEdge
                End If
        End Select

    End Function

    Friend Sub OnBPOSexplorerStateChange(ByVal bProposed As Boolean, _
                                    ByVal abEdgeProposed As ABEdge)

        Dim bFullDragOn As Boolean

        ' Find out if the user has FullDrag turned on
        bFullDragOn = SystemInformation.DragFullWindows

        ' If FullDrag is turned on OR the BPOSexplorer has changed position
        If bFullDragOn OrElse Not bProposed Then
            If abEdgeProposed = ABEdge.abeFloat Then
                ' Show the window adornments
                ModifyStyle(dockForm.Handle, _
                            GWL_STYLE, _
                            0, _
                            WS_CAPTION Or WS_SYSMENU Or WS_BORDER, _
                            SWP_DRAWFRAME, _
                            False)
            Else
                ' Hide the window adornments
                ModifyStyle(dockForm.Handle, _
                            GWL_STYLE, _
                            WS_CAPTION Or WS_SYSMENU Or WS_BORDER, _
                            0, _
                            SWP_DRAWFRAME, _
                            False)
            End If
        End If

    End Sub

    Private Function ModifyStyle(ByVal hwnd As Integer, _
                             ByVal nStyleOffset As Integer, _
                             ByVal dwRemove As Integer, _
                             ByVal dwAdd As Integer, _
                             ByVal nFlags As Integer, _
                             ByVal bRefresh As Boolean) As Boolean

        Dim dwStyle As Integer
        Dim dwNewStyle As Integer

        dwStyle = GetWindowLong(hwnd, nStyleOffset)
        dwNewStyle = (dwStyle And (Not dwRemove)) Or dwAdd

        If dwStyle = dwNewStyle Then
            ModifyStyle = False
            Exit Function
        End If

        If bRefresh Then
            ShowWindow(hwnd, SW_HIDE)
        End If

        SetWindowLong(hwnd, nStyleOffset, dwNewStyle)

        If bRefresh Then
            ShowWindow(hwnd, SW_SHOW)
        End If

        If nFlags <> 0 Then
            SetWindowPos(hwnd, 0, 0, 0, 0, 0, SWP_NOSIZE Or SWP_NOMOVE Or SWP_NOZORDER Or SWP_NOACTIVATE Or nFlags)
        End If

        ModifyStyle = True

    End Function

    Friend Function IsDocked() As Boolean
        If (Edge = ABEdge.abeLeft) Or (Edge = ABEdge.abeRight) Or (Edge = ABEdge.abeTop) Or (Edge = ABEdge.abeBottom) Then
            IsDocked = True
        Else
            IsDocked = False
        End If
    End Function

    Friend Function IsDockable(ByVal abFlags As ABFlags) As Boolean

        IsDockable = abFlags And _
                     (abFlags.abfAllowLeft Or abFlags.abfAllowTop Or abFlags.abfAllowRight Or abFlags.abfAllowBottom)

    End Function

    ' Returns TRUE if abEdge is ABE_LEFT or ABE_RIGHT, else FALSE is returned
    Friend Function IsEdgeLeftOrRight(ByVal abEdge As ABEdge) As Boolean

        If (abEdge = ApplicationBar.ABEdge.abeLeft) OrElse (abEdge = ApplicationBar.ABEdge.abeRight) Then
            IsEdgeLeftOrRight = True
        Else
            IsEdgeLeftOrRight = False
        End If

    End Function

    ' Returns TRUE if abEdge is ABE_TOP or ABE_BOTTOM, else FALSE is returned
    Friend Function IsEdgeTopOrBottom(ByVal abEdge As ABEdge) As Boolean

        If (abEdge = ApplicationBar.ABEdge.abeTop) OrElse (abEdge = ApplicationBar.ABEdge.abeBottom) Then
            IsEdgeTopOrBottom = True
        Else
            IsEdgeTopOrBottom = False
        End If

    End Function

    ' Called when BPOSexplorer gets an ABN_FULLSCREENAPP notification
    Friend Sub OnABNFullScreenApp(ByVal bOpen As Boolean)

        ' This function is called when a FullScreen window is openning or
        ' closing. A FullScreen window is a top-level window that has its caption
        ' above the top of the screen allowing the entire screen to be occupied
        ' by the window's client area.

        ' If the BPOSexplorer is a topmost window when a FullScreen window is activated,
        ' we need to change our window to a non-topmost window so that the BPOSexplorer
        ' doesn't cover the FullScreen window's client area.

        ' If the FullScreen window is closing, we need to set the BPOSexplorer's
        ' Z-Order back to when the user wants it to be.
        Dim tempbool As Boolean = FbFullScreenAppOpen
        FbFullScreenAppOpen = bOpen
        If Not tempbool = bOpen Then
            UpdateBar()
        End If

    End Sub

    ' Called when BPOSexplorer gets an ABN_POSCHANGED notification
    Friend Sub OnABNPosChanged()

        ' The TaskBar or another BPOSexplorer has changed its size or position
        If (Edge <> ABEdge.abeFloat) AndAlso (Not AutoHide) Then
            ' If we're not floating and we're not auto-hidden, we have to
            ' reposition our window
            UpdateBar()
        End If

    End Sub

    ' Called when BPOSexplorer gets an ABN_WINDOWARRANGE notification
    Friend Sub OnABNWindowArrange(ByVal bBeginning As Boolean)

        ' This function intentionally left blank

    End Sub

    Friend Function onBPOSexplorerNotification(ByVal msg As Message) As Integer
        Select Case msg.WParam.ToInt32
            Case ABN_FULLSCREENAPP
                OnABNFullScreenApp(CBool(msg.LParam.ToInt32))
            Case ABN_POSCHANGED
                OnABNPosChanged()
            Case ABN_WINDOWARRANGE
                OnABNWindowArrange(CBool(msg.LParam.ToInt32))
        End Select
        onBPOSexplorerNotification = 0
    End Function

    Private Function onNcHitTest(ByRef msg As Message) As IntPtr
        MyBase.DefWndProc(msg)

        Dim u As Integer
        Dim bPrimaryMouseBtnDown As Boolean
        Dim rcClient As RECT
        Dim pt As Point
        Dim vKey As Integer
        Dim XPos As Integer
        Dim YPos As Integer

        ' Find out what the system thinks is the hit test code
        u = msg.Result.ToInt32

        ' Get cursor position in screen coordinates
        XPos = Cursor.Position.X
        YPos = Cursor.Position.Y

        ' NOTE: If the user presses the secondary mouse button, pretend that the
        ' user clicked on the client area so that we get WM_CONTEXTMENU messages

        If SystemInformation.MouseButtonsSwapped <> 0 Then
            vKey = VK_RBUTTON
        Else
            vKey = VK_LBUTTON
        End If

        bPrimaryMouseBtnDown = CBool(GetAsyncKeyState(vKey) And &H8000)

        pt.X = XPos
        pt.Y = YPos

        pt = dockForm.PointToClient(pt)

        If (u = MousePositionCodes.HTCLIENT) And bPrimaryMouseBtnDown _
                And Not ControlAtPos(pt, False) Then
            ' User clicked in client area, allow BPOSexplorer to move.  We get this
            ' behavior by pretending that the user clicked on the caption area
            u = MousePositionCodes.HTCAPTION
        End If

        If ((Edge = ABEdge.abeFloat) And _
            (MousePositionCodes.HTSIZEFIRST <= u) And (u <= MousePositionCodes.HTSIZELAST)) Then
            Select Case u
                Case MousePositionCodes.HTLEFT, MousePositionCodes.HTRIGHT
                    If ABS.szSizeInc.cx = 0 Then
                        u = MousePositionCodes.HTBORDER
                    End If
                Case MousePositionCodes.HTTOP, MousePositionCodes.HTBOTTOM
                    If ABS.szSizeInc.cy = 0 Then
                        u = MousePositionCodes.HTBORDER
                    End If
                Case MousePositionCodes.HTTOPLEFT
                    If (ABS.szSizeInc.cx = 0) And (ABS.szSizeInc.cy = 0) Then
                        u = MousePositionCodes.HTBORDER
                    ElseIf (ABS.szSizeInc.cx = 0) And (ABS.szSizeInc.cy <> 0) Then
                        u = MousePositionCodes.HTTOP
                    ElseIf (ABS.szSizeInc.cx <> 0) And (ABS.szSizeInc.cy = 0) Then
                        u = MousePositionCodes.HTLEFT
                    End If
                Case MousePositionCodes.HTTOPRIGHT
                    If (ABS.szSizeInc.cx = 0) And (ABS.szSizeInc.cy = 0) Then
                        u = MousePositionCodes.HTBORDER
                    ElseIf (ABS.szSizeInc.cx = 0) And (ABS.szSizeInc.cy <> 0) Then
                        u = MousePositionCodes.HTTOP
                    ElseIf (ABS.szSizeInc.cx <> 0) And (ABS.szSizeInc.cy = 0) Then
                        u = MousePositionCodes.HTRIGHT
                    End If
                Case MousePositionCodes.HTBOTTOMLEFT
                    If (ABS.szSizeInc.cx = 0) And (ABS.szSizeInc.cy = 0) Then
                        u = MousePositionCodes.HTBORDER
                    ElseIf (ABS.szSizeInc.cx = 0) And (ABS.szSizeInc.cy <> 0) Then
                        u = MousePositionCodes.HTBOTTOM
                    ElseIf (ABS.szSizeInc.cx <> 0) And (ABS.szSizeInc.cy = 0) Then
                        u = MousePositionCodes.HTLEFT
                    End If
                Case MousePositionCodes.HTBOTTOMRIGHT
                    If (ABS.szSizeInc.cx = 0) And (ABS.szSizeInc.cy = 0) Then
                        u = MousePositionCodes.HTBORDER
                    ElseIf (ABS.szSizeInc.cx = 0) And (ABS.szSizeInc.cy <> 0) Then
                        u = MousePositionCodes.HTBOTTOM
                    ElseIf (ABS.szSizeInc.cx <> 0) And (ABS.szSizeInc.cy = 0) Then
                        u = MousePositionCodes.HTRIGHT
                    End If
            End Select
        End If

        If ((Edge <> ABEdge.abeFloat) And (Edge <> ABEdge.abeUnknown) And _
        (MousePositionCodes.HTSIZEFIRST <= u) And (u <= MousePositionCodes.HTSIZELAST)) Then

            If (IsEdgeLeftOrRight(Edge) And (ABS.szSizeInc.cx = 0)) Or _
               (Not IsEdgeLeftOrRight(Edge) And (ABS.szSizeInc.cy = 0)) Then
                ' If the width/height size increment is zero, then resizing is NOT
                ' allowed for the edge that the BPOSexplorer is docked on
                u = MousePositionCodes.HTBORDER ' Pretend that the mouse is not on a resize border
            Else
                ' Resizing IS allowed for the edge that the BPOSexplorer is docked on
                ' Get the location of the BPOSexplorer's client area in screen coordinates
                rcClient = RectangleToRECT(dockForm.ClientRectangle)
                pt.X = rcClient.left
                pt.Y = rcClient.top
                pt = dockForm.PointToScreen(pt)
                rcClient.left = pt.X
                rcClient.top = pt.Y
                pt.X = rcClient.right
                pt.Y = rcClient.bottom
                pt = dockForm.PointToScreen(pt)
                rcClient.right = pt.X
                rcClient.bottom = pt.Y

                u = MousePositionCodes.HTBORDER ' Assume that we can't resize
                Select Case Edge
                    Case ABEdge.abeLeft
                        If XPos > rcClient.right Then
                            u = MousePositionCodes.HTRIGHT
                        End If
                    Case ABEdge.abeTop
                        If YPos > rcClient.bottom Then
                            u = MousePositionCodes.HTBOTTOM
                        End If
                    Case ABEdge.abeRight
                        If XPos < rcClient.left Then
                            u = MousePositionCodes.HTLEFT
                        End If
                    Case ABEdge.abeBottom
                        If YPos < rcClient.top Then
                            u = MousePositionCodes.HTTOP
                        End If
                End Select
            End If
        End If

        ' Return the hittest code
        msg.Result = New IntPtr(u)
    End Function

    Private Function ControlAtPos(ByRef Pos As Point, _
                              ByVal AllowDisabled As Boolean) As Boolean
        Dim Control As Control
        Dim pt As Point
        Dim rc As Rectangle

        ControlAtPos = False
        For Each Control In dockForm.Controls
            With Control
                pt.X = Pos.X - .Left
                pt.Y = Pos.Y - .Top
                rc.X = 0
                rc.Y = 0
                rc.Width = .Width
                rc.Height = .Height
                If rc.Contains(pt) And .Visible And (.Enabled Or AllowDisabled) Then
                    ControlAtPos = True
                    Exit Function
                End If
            End With
        Next Control

    End Function

    Protected Overloads Overrides Sub WndProc(ByRef uMsg As Message)

        If uMsg.HWnd = dockForm.Handle Then

            uMsg.Result = INHERIT_DEFAULT_CALLBACK

            Select Case uMsg.Msg

                Case CallbackMessageID
                    uMsg.Result = onBPOSexplorerNotification(uMsg)

                Case WM_ENTERSIZEMOVE
                    uMsg.Result = OnEnterSizeMove()

                Case WM_EXITSIZEMOVE
                    uMsg.Result = OnExitSizeMove()

                Case WM_GETMINMAXINFO
                    'result = OnGetMinMaxInfo(uMsg)

                Case WM_MOVING
                    uMsg.Result = onMoving(uMsg)

                Case WM_NCMOUSEMOVE
                    OnNcMouseMove()

                Case WM_SIZING
                    'result = OnSizing(uMsg)

                Case WM_TIMER
                    OnBPOSexplorerTimer()
                    'End Select

                    '' If the subclassing function did not provide a return value
                    '' or wants to inherit the default procedure
                    'If uMsg.Result = INHERIT_DEFAULT_CALLBACK Then
                    '    ' Call the default window procedure
                    '    MyBase.DefWndProc(uMsg)
                    'End If

                    '' Subclass some events AFTER the default window procedure
                    'Select Case uMsg.Msg

                Case WM_ACTIVATE
                    If uMsg.WParam = WA_INACTIVE Then
                        ' Hide the BPOSexplorer if we are docked and auto-hidden
                        ShowHiddenBPOSexplorer(False)
                    End If
                    BPOSexplorerActivate()

                Case WM_NCHITTEST
                    onNcHitTest(uMsg)
                    Return

                Case WM_WINDOWPOSCHANGED
                    BPOSexplorerWindowPosChanged()
            End Select
            MyBase.WndProc(uMsg)
        End If
    End Sub

    Friend Sub ResetApplicationBar()

#If DEBUG_MODE Then
        Dim abd As BPOSexplorerDATA
        abd.cbSize = Len(abd)
        abd.hWnd = 0
        SHBPOSexplorerMessage(ToUInt32(ABMsg.abmRemove), abd)
#Else
        ' nothing to do when not in debug mode
#End If

    End Sub

    Protected Overrides Sub Finalize()
        'OnDestroy()
        ResetApplicationBar()
        MyBase.Finalize()
    End Sub

    Public Function LoadBPOSexplorerSettings() As Boolean

        Dim abSetting As ABSettings
        Dim absByte() As Byte = {}
        Dim buffer As IntPtr
        Dim rawsize As Integer = Marshal.SizeOf(abSetting)
        Dim regLoad As RegistryKey

        LoadBPOSexplorerSettings = False

        Try
            regLoad = Registry.CurrentUser.OpenSubKey("Software\" & Application.ProductName, False)

            If (regLoad Is Nothing) Then
                Return LoadBPOSexplorerSettings
                Exit Function
            End If
            regLoad.GetValue("ABSet")

            If Not regLoad.GetValue("ABSet") Is Nothing Then
                absByte = DirectCast(regLoad.GetValue("ABSet"), Byte())
            Else
                Return LoadBPOSexplorerSettings
                Exit Function
            End If

            If rawsize > absByte.Length Then
                Return LoadBPOSexplorerSettings
                Exit Function
            End If

            buffer = Marshal.AllocHGlobal(rawsize)
            Marshal.Copy(absByte, 0, buffer, rawsize)
            abSetting = DirectCast(Marshal.PtrToStructure(buffer, GetType(ABSettings)), ABSettings)
            Marshal.FreeHGlobal(buffer)

            ABS = abSetting
            UpdateBar()
            LoadBPOSexplorerSettings = True
        Catch ex As Exception
            Console.WriteLine(ex.Message)
            LoadBPOSexplorerSettings = False
        End Try

    End Function

    Public Function SaveBPOSexplorerSettings() As Boolean

        Dim absByte() As Byte
        Dim ptr As IntPtr
        Dim regSave As RegistryKey

        ' Set the default return value
        SaveBPOSexplorerSettings = False

        Try

            ReDim absByte(Marshal.SizeOf(ABS) - 1)

            ptr = Marshal.AllocHGlobal(Marshal.SizeOf(ABS))
            Marshal.StructureToPtr(ABS, ptr, True)
            Marshal.Copy(ptr, absByte, 0, Marshal.SizeOf(ABS))
            Marshal.FreeHGlobal(ptr)

            regSave = Registry.CurrentUser.OpenSubKey("Software\" & Application.ProductName, True)

            If (regSave Is Nothing) Then
                regSave = Registry.CurrentUser.CreateSubKey("Software\" & Application.ProductName)
            End If

            regSave.SetValue("ABSet", absByte, RegistryValueKind.Binary)

            SaveBPOSexplorerSettings = True
        Catch ex As Exception
            SaveBPOSexplorerSettings = False
        End Try


    End Function

    Public Function DeleteBPOSexplorerSettings() As Boolean

        Dim regDelete As RegistryKey
        ' Set the default return value
        DeleteBPOSexplorerSettings = False

        Try

            regDelete = Registry.CurrentUser.OpenSubKey("Software\" & Application.ProductName, True)

            If (regDelete Is Nothing) Then
                Return DeleteBPOSexplorerSettings
                Exit Function
            End If

            If Not regDelete.GetValue("ABSet") Is Nothing Then
                regDelete.DeleteValue("ABSet")
            End If

            DeleteBPOSexplorerSettings = True
        Catch ex As Exception
            DeleteBPOSexplorerSettings = False
        End Try


    End Function

End Class
