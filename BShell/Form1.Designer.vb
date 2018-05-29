<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form))
        Me.Taskbar = New System.Windows.Forms.ToolStrip()
        Me.taskbaroptions = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ShowSearchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HiddenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShowSearchIconToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShowSearchBoxToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ProcessesManagerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.GripableToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChangeColorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarSettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.User2ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.BPOSSoftwareCenterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewExplorerBETAToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SearchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.RunToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewMenuButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripTextBox1 = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.clocktime = New System.Windows.Forms.Timer(Me.components)
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.Taskbar.SuspendLayout()
        Me.taskbaroptions.SuspendLayout()
        Me.SuspendLayout()
        '
        'Taskbar
        '
        Me.Taskbar.ContextMenuStrip = Me.taskbaroptions
        Me.Taskbar.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Taskbar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.NewMenuButton, Me.ToolStripSeparator2, Me.ToolStripLabel1, Me.ToolStripButton4, Me.ToolStripButton2, Me.ToolStripLabel2, Me.ToolStripSeparator6, Me.ToolStripTextBox1, Me.ToolStripButton3})
        Me.Taskbar.Location = New System.Drawing.Point(0, 514)
        Me.Taskbar.Name = "Taskbar"
        Me.Taskbar.Size = New System.Drawing.Size(652, 39)
        Me.Taskbar.TabIndex = 2
        Me.Taskbar.Text = "Fullscreen"
        '
        'taskbaroptions
        '
        Me.taskbaroptions.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ShowSearchToolStripMenuItem, Me.ToolStripSeparator5, Me.ProcessesManagerToolStripMenuItem, Me.ToolStripSeparator8, Me.GripableToolStripMenuItem, Me.ChangeColorToolStripMenuItem, Me.BarSettingsToolStripMenuItem})
        Me.taskbaroptions.Name = "taskbaroptions"
        Me.taskbaroptions.Size = New System.Drawing.Size(194, 126)
        '
        'ShowSearchToolStripMenuItem
        '
        Me.ShowSearchToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HiddenToolStripMenuItem, Me.ShowSearchIconToolStripMenuItem, Me.ShowSearchBoxToolStripMenuItem})
        Me.ShowSearchToolStripMenuItem.Image = CType(resources.GetObject("ShowSearchToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ShowSearchToolStripMenuItem.Name = "ShowSearchToolStripMenuItem"
        Me.ShowSearchToolStripMenuItem.Size = New System.Drawing.Size(193, 22)
        Me.ShowSearchToolStripMenuItem.Text = "Search"
        '
        'HiddenToolStripMenuItem
        '
        Me.HiddenToolStripMenuItem.Enabled = False
        Me.HiddenToolStripMenuItem.Name = "HiddenToolStripMenuItem"
        Me.HiddenToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.HiddenToolStripMenuItem.Text = "Hidden"
        '
        'ShowSearchIconToolStripMenuItem
        '
        Me.ShowSearchIconToolStripMenuItem.Enabled = False
        Me.ShowSearchIconToolStripMenuItem.Name = "ShowSearchIconToolStripMenuItem"
        Me.ShowSearchIconToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.ShowSearchIconToolStripMenuItem.Text = "Show as icon"
        '
        'ShowSearchBoxToolStripMenuItem
        '
        Me.ShowSearchBoxToolStripMenuItem.Checked = True
        Me.ShowSearchBoxToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ShowSearchBoxToolStripMenuItem.Name = "ShowSearchBoxToolStripMenuItem"
        Me.ShowSearchBoxToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.ShowSearchBoxToolStripMenuItem.Text = "Show as text box"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(190, 6)
        '
        'ProcessesManagerToolStripMenuItem
        '
        Me.ProcessesManagerToolStripMenuItem.Name = "ProcessesManagerToolStripMenuItem"
        Me.ProcessesManagerToolStripMenuItem.Size = New System.Drawing.Size(193, 22)
        Me.ProcessesManagerToolStripMenuItem.Text = "Start Task Manager"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(190, 6)
        '
        'GripableToolStripMenuItem
        '
        Me.GripableToolStripMenuItem.Checked = True
        Me.GripableToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.GripableToolStripMenuItem.Name = "GripableToolStripMenuItem"
        Me.GripableToolStripMenuItem.Size = New System.Drawing.Size(193, 22)
        Me.GripableToolStripMenuItem.Text = "Grip-able"
        '
        'ChangeColorToolStripMenuItem
        '
        Me.ChangeColorToolStripMenuItem.Enabled = False
        Me.ChangeColorToolStripMenuItem.Name = "ChangeColorToolStripMenuItem"
        Me.ChangeColorToolStripMenuItem.Size = New System.Drawing.Size(193, 22)
        Me.ChangeColorToolStripMenuItem.Text = "Change color"
        '
        'BarSettingsToolStripMenuItem
        '
        Me.BarSettingsToolStripMenuItem.Image = CType(resources.GetObject("BarSettingsToolStripMenuItem.Image"), System.Drawing.Image)
        Me.BarSettingsToolStripMenuItem.Name = "BarSettingsToolStripMenuItem"
        Me.BarSettingsToolStripMenuItem.Size = New System.Drawing.Size(193, 22)
        Me.BarSettingsToolStripMenuItem.Text = "Bar and menu Settings"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.User2ToolStripMenuItem, Me.AboutToolStripMenuItem, Me.UsToolStripMenuItem, Me.ToolStripSeparator3, Me.BPOSSoftwareCenterToolStripMenuItem, Me.NewExplorerBETAToolStripMenuItem, Me.SearchToolStripMenuItem, Me.ToolStripSeparator4, Me.ToolStripMenuItem4, Me.RunToolStripMenuItem, Me.ToolStripSeparator1, Me.SettingsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.ShowDropDownArrow = False
        Me.ToolStripButton1.Size = New System.Drawing.Size(33, 36)
        Me.ToolStripButton1.Text = "Start"
        Me.ToolStripButton1.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
        '
        'User2ToolStripMenuItem
        '
        Me.User2ToolStripMenuItem.BackColor = System.Drawing.Color.Black
        Me.User2ToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.User2ToolStripMenuItem.Enabled = False
        Me.User2ToolStripMenuItem.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.User2ToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.User2ToolStripMenuItem.Name = "User2ToolStripMenuItem"
        Me.User2ToolStripMenuItem.Size = New System.Drawing.Size(196, 38)
        Me.User2ToolStripMenuItem.Text = "user2"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(196, 38)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'UsToolStripMenuItem
        '
        Me.UsToolStripMenuItem.Name = "UsToolStripMenuItem"
        Me.UsToolStripMenuItem.Size = New System.Drawing.Size(196, 38)
        Me.UsToolStripMenuItem.Text = "Battery Check (WIP)"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(193, 6)
        '
        'BPOSSoftwareCenterToolStripMenuItem
        '
        Me.BPOSSoftwareCenterToolStripMenuItem.Enabled = False
        Me.BPOSSoftwareCenterToolStripMenuItem.Image = CType(resources.GetObject("BPOSSoftwareCenterToolStripMenuItem.Image"), System.Drawing.Image)
        Me.BPOSSoftwareCenterToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BPOSSoftwareCenterToolStripMenuItem.Name = "BPOSSoftwareCenterToolStripMenuItem"
        Me.BPOSSoftwareCenterToolStripMenuItem.Size = New System.Drawing.Size(196, 38)
        Me.BPOSSoftwareCenterToolStripMenuItem.Text = "Software Center"
        Me.BPOSSoftwareCenterToolStripMenuItem.Visible = False
        '
        'NewExplorerBETAToolStripMenuItem
        '
        Me.NewExplorerBETAToolStripMenuItem.Image = CType(resources.GetObject("NewExplorerBETAToolStripMenuItem.Image"), System.Drawing.Image)
        Me.NewExplorerBETAToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.NewExplorerBETAToolStripMenuItem.Name = "NewExplorerBETAToolStripMenuItem"
        Me.NewExplorerBETAToolStripMenuItem.Size = New System.Drawing.Size(196, 38)
        Me.NewExplorerBETAToolStripMenuItem.Text = "File Explorer"
        '
        'SearchToolStripMenuItem
        '
        Me.SearchToolStripMenuItem.Enabled = False
        Me.SearchToolStripMenuItem.Image = CType(resources.GetObject("SearchToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SearchToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.SearchToolStripMenuItem.Name = "SearchToolStripMenuItem"
        Me.SearchToolStripMenuItem.Size = New System.Drawing.Size(196, 38)
        Me.SearchToolStripMenuItem.Text = "Search Files"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(193, 6)
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Image = CType(resources.GetObject("ToolStripMenuItem4.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(196, 38)
        Me.ToolStripMenuItem4.Text = "Help Topics"
        '
        'RunToolStripMenuItem
        '
        Me.RunToolStripMenuItem.Image = CType(resources.GetObject("RunToolStripMenuItem.Image"), System.Drawing.Image)
        Me.RunToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.RunToolStripMenuItem.Name = "RunToolStripMenuItem"
        Me.RunToolStripMenuItem.Size = New System.Drawing.Size(196, 38)
        Me.RunToolStripMenuItem.Text = "Run"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(193, 6)
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.Image = CType(resources.GetObject("SettingsToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SettingsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(196, 38)
        Me.SettingsToolStripMenuItem.Text = "Settings"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Image = CType(resources.GetObject("ExitToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ExitToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(196, 38)
        Me.ExitToolStripMenuItem.Text = "End Session"
        '
        'NewMenuButton
        '
        Me.NewMenuButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.NewMenuButton.Enabled = False
        Me.NewMenuButton.Image = CType(resources.GetObject("NewMenuButton.Image"), System.Drawing.Image)
        Me.NewMenuButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.NewMenuButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.NewMenuButton.Name = "NewMenuButton"
        Me.NewMenuButton.Size = New System.Drawing.Size(33, 36)
        Me.NewMenuButton.Text = "Start"
        Me.NewMenuButton.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
        Me.NewMenuButton.Visible = False
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 39)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(37, 36)
        Me.ToolStripLabel1.Text = "Clock"
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton4.Image = CType(resources.GetObject("ToolStripButton4.Image"), System.Drawing.Image)
        Me.ToolStripButton4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(36, 36)
        Me.ToolStripButton4.Text = "Volume"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton2.Enabled = False
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(56, 36)
        Me.ToolStripButton2.Text = "My apps"
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripLabel2.Image = CType(resources.GetObject("ToolStripLabel2.Image"), System.Drawing.Image)
        Me.ToolStripLabel2.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.ToolStripLabel2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(32, 36)
        Me.ToolStripLabel2.Text = "Internet Status"
        Me.ToolStripLabel2.ToolTipText = "Internet Status"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 39)
        Me.ToolStripSeparator6.Visible = False
        '
        'ToolStripTextBox1
        '
        Me.ToolStripTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ToolStripTextBox1.Name = "ToolStripTextBox1"
        Me.ToolStripTextBox1.Size = New System.Drawing.Size(150, 39)
        Me.ToolStripTextBox1.Text = "Search Files"
        Me.ToolStripTextBox1.ToolTipText = "Search Files"
        Me.ToolStripTextBox1.Visible = False
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(28, 36)
        Me.ToolStripButton3.Text = "Search"
        Me.ToolStripButton3.Visible = False
        '
        'clocktime
        '
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(151, 22)
        Me.ToolStripMenuItem1.Text = "Tile Horizontal"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(151, 22)
        Me.ToolStripMenuItem2.Text = "Tile Vertical"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(151, 22)
        Me.ToolStripMenuItem3.Text = "Cascade"
        '
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripDropDownButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ToolStripMenuItem2, Me.ToolStripMenuItem3})
        Me.ToolStripDropDownButton1.Image = CType(resources.GetObject("ToolStripDropDownButton1.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(69, 19)
        Me.ToolStripDropDownButton1.Text = "Windows"
        '
        'Timer1
        '
        Me.Timer1.Interval = 10000000
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.MenuStrip1.Size = New System.Drawing.Size(652, 24)
        Me.MenuStrip1.TabIndex = 4
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'Form
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(652, 553)
        Me.Controls.Add(Me.Taskbar)
        Me.Controls.Add(Me.MenuStrip1)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MinimizeBox = False
        Me.Name = "Form"
        Me.Opacity = 0.99R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "GUI"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Taskbar.ResumeLayout(False)
        Me.Taskbar.PerformLayout()
        Me.taskbaroptions.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Taskbar As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents clocktime As System.Windows.Forms.Timer
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents taskbaroptions As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents SettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProcessesManagerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripDropDownButton1 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents RunToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewExplorerBETAToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BPOSSoftwareCenterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BarSettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SearchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents User2ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewMenuButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ShowSearchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HiddenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShowSearchIconToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShowSearchBoxToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripTextBox1 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents GripableToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ChangeColorToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripButton4 As ToolStripButton
End Class
