Imports Microsoft.Win32
Imports System.Runtime.InteropServices
Imports System.IO   'Import System.IO For File Operations

Public Class screenres

    Private FixHeight As Integer   '= 1024 'default height
    Private FixWidth As Integer    '= 768 'default width
    Dim XRes As Short
    Dim YRes As Short
    Dim DidResChange As Boolean
    Private DirName As String = "C:\WINDOWS\system32\"
    Private StyleDir As String = "C:\WINDOWS\Resources\Themes"
    Private StyleColorDir As String
    Private ScreenNames() As String
    Private StyleNames() As String

    Private StyleFont As String
    Private StyleColor As String
    Private StyleDisplayName As String
    Private Sub screenres_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class