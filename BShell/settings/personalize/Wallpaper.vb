

Imports Microsoft.Win32
Imports System.Environment
Imports System.Drawing.Imaging
Imports System.ComponentModel
Imports System.Runtime.InteropServices


Public Class Wallpaper
    Public Shared ReadOnly Property SupportJpgAsWallpaper()
        Get
            Return (Environment.OSVersion.Version >= New Version(6, 0))
        End Get
    End Property
    Public Shared ReadOnly Property SupportFitFillWallpaperStyles()
        Get
            Return (Environment.OSVersion.Version >= New Version(6, 1))
        End Get
    End Property
    Public Shared Sub SetDesktopWallpaper(ByVal path As String, ByVal style As WallpaperStyle)
        Dim key As RegistryKey = Registry.CurrentUser.OpenSubKey("Control Panel\Desktop", True)

        Select Case style
            Case WallpaperStyle.Tile
                key.SetValue("WallpaperStyle", "0")
                key.SetValue("TileWallpaper", "1")
                Exit Select
            Case WallpaperStyle.Center
                key.SetValue("WallpaperStyle", "0")
                key.SetValue("TileWallpaper", "0")
                Exit Select
            Case WallpaperStyle.Stretch
                key.SetValue("WallpaperStyle", "2")
                key.SetValue("TileWallpaper", "0")
                Exit Select
            Case WallpaperStyle.Fit ' (Windows 7 and later)
                key.SetValue("WallpaperStyle", "6")
                key.SetValue("TileWallpaper", "0")
                Exit Select
            Case WallpaperStyle.Fill ' (Windows 7 and later)
                key.SetValue("WallpaperStyle", "10")
                key.SetValue("TileWallpaper", "0")
                Exit Select
        End Select

        key.Close()


        Dim ext As String = System.IO.Path.GetExtension(path)
        If ((Not ext.Equals(".bmp", StringComparison.OrdinalIgnoreCase) AndAlso _
             Not ext.Equals(".jpg", StringComparison.OrdinalIgnoreCase)) _
            OrElse _
            (ext.Equals(".jpg", StringComparison.OrdinalIgnoreCase) AndAlso _
            (Not SupportJpgAsWallpaper))) Then

            Using image As Image = image.FromFile(path)
                path = String.Format("{0}\Microsoft\Windows\Themes\{1}.bmp", _
                    Environment.GetFolderPath(SpecialFolder.ApplicationData), _
                    System.IO.Path.GetFileNameWithoutExtension(path))
                image.Save(path, ImageFormat.Bmp)
            End Using

        End If

        If Not Wallpaper.SystemParametersInfo(20, 0, path, 3) Then
            Throw New Win32Exception
        End If
    End Sub


    <DllImport("user32.dll", CharSet:=CharSet.Unicode, SetLastError:=True)> _
    Private Shared Function SystemParametersInfo( _
        ByVal uiAction As UInt32, _
        ByVal uiParam As UInt32, _
        ByVal pvParam As String, _
        ByVal fWinIni As UInt32) _
        As <MarshalAs(UnmanagedType.Bool)> Boolean
    End Function

    Private Const SPI_SETDESKWALLPAPER As UInt32 = 20
    Private Const SPIF_SENDWININICHANGE As UInt32 = 2
    Private Const SPIF_UPDATEINIFILE As UInt32 = 1
End Class


Public Enum WallpaperStyle
    Tile
    Center
    Stretch
    Fit
    Fill
End Enum