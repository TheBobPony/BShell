


Public Class MainForm

    Private wallpaperFileName As String = Nothing


    Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles MyBase.Load


    End Sub


    Private Sub btnBrowseWallpaper_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles btnBrowseWallpaper.Click

        If (DialogResult.OK = Me.wallpaperOpenFileDialog.ShowDialog) Then
            Me.wallpaperFileName = Me.wallpaperOpenFileDialog.FileName
            Me.tbWallpaperFileName.Text = Me.wallpaperFileName

            ' Preview the image in a picture box.
            Dim wallpaper As Image = Image.FromFile(Me.wallpaperFileName)

            If ((wallpaper.Width < Me.pctPreview.Width) AndAlso _
                (wallpaper.Height < Me.pctPreview.Height)) Then
                Me.pctPreview.Image = wallpaper
            Else
                Dim wallpaperRatio As Single = (CSng(wallpaper.Width) / CSng(wallpaper.Height))
                Dim pctPreviewRatio As Single = (CSng(Me.pctPreview.Width) / CSng(Me.pctPreview.Height))

                If (wallpaperRatio >= pctPreviewRatio) Then
                    Me.pctPreview.Image = wallpaper.GetThumbnailImage( _
                        Me.pctPreview.Width, _
                        CInt((CSng(Me.pctPreview.Width) / wallpaperRatio)), _
                        Nothing, IntPtr.Zero)
                Else
                    Me.pctPreview.Image = wallpaper.GetThumbnailImage( _
                        CInt((Me.pctPreview.Height * wallpaperRatio)), _
                        Me.pctPreview.Height, _
                        Nothing, IntPtr.Zero)
                End If
            End If
        End If
    End Sub


    Private Sub btnSetWallpaper_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles btnSetWallpaper.Click
        If Not String.IsNullOrEmpty(Me.wallpaperFileName) Then
            Wallpaper.SetDesktopWallpaper( _
                Me.wallpaperFileName, _
                Me.SelectedWallpaperStyle)
        End If
    End Sub


    Private ReadOnly Property SelectedWallpaperStyle() As WallpaperStyle
        Get
            If Me.radTile.Checked Then
                Return WallpaperStyle.Tile
            End If
            If Me.radCenter.Checked Then
                Return WallpaperStyle.Center
            End If
            If Me.radStretch.Checked Then
                Return WallpaperStyle.Stretch
            End If
            If Me.radFit.Checked Then
                Return WallpaperStyle.Fit
            End If
            Return WallpaperStyle.Fill
        End Get
    End Property

End Class
