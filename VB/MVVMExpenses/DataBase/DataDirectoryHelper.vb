Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Reflection
#If Not REALTORWORLDDEMO Then
Imports System.Deployment.Application
Imports System.Threading
Imports System.Diagnostics
Imports System.Security
Imports System.Runtime.InteropServices
Imports Microsoft.Win32
#End If

Namespace DevExpress.Internal
    Public Class DataDirectoryHelper
#If Not REALTORWORLDDEMO Then
        Private Shared _isClickOnce? As Boolean = Nothing

        Public Shared ReadOnly Property IsClickOnce() As Boolean
            Get
                If _isClickOnce Is Nothing Then
#If DEBUG AndAlso (Not CLICKONCE) Then
                    _isClickOnce = False
#Else
                    _isClickOnce = (Not BrowserInteropHelper.IsBrowserHosted) AndAlso ApplicationDeployment.IsNetworkDeployed
#End If
                End If
                Return CBool(_isClickOnce)
            End Get
        End Property
#End If
        Public Const DataFolderName As String = "Data"
        Public Shared Function GetDataDirectory() As String
#If REALTORWORLDDEMO Then
            Return AppDomain.CurrentDomain.BaseDirectory
#Else
            Return If(IsClickOnce, ApplicationDeployment.CurrentDeployment.DataDirectory, GetEntryAssemblyDirectory())
#End If
        End Function
        Public Shared Function GetFile(ByVal fileName As String, ByVal directoryName As String) As String
            If DataPath IsNot Nothing Then
                Return Path.Combine(DataPath, fileName)
            End If
            Dim dataDirectory As String = GetDataDirectory()
            If dataDirectory Is Nothing Then
                Return Nothing
            End If
            Dim dirName As String = Path.GetFullPath(dataDirectory)
            For n As Integer = 0 To 8
                Dim path As String = dirName & "\" & directoryName & "\" & fileName
                Try
                    If File.Exists(path) OrElse Directory.Exists(path) Then
                        Return path
                    End If
                Catch
                End Try
                dirName &= "\.."
            Next n
            Throw New FileNotFoundException(String.Format("{0} not found. ({1})", fileName, dirName))
        End Function
        Public Shared Function GetDirectory(ByVal directoryName As String) As String
            Dim dataDirectory As String = GetDataDirectory()
            If dataDirectory Is Nothing Then
                Return Nothing
            End If
            Dim dirName As String = Path.GetFullPath(dataDirectory)
            For n As Integer = 0 To 8
                Dim path As String = dirName & "\" & directoryName
                Try
                    If Directory.Exists(path) Then
                        Return path
                    End If
                Catch
                End Try
                dirName &= "\.."
            Next n
            Throw New DirectoryNotFoundException(directoryName & " not found")
        End Function
#If Not REALTORWORLDDEMO Then
        Public Shared Sub SetWebBrowserMode()
            Try
                Dim key As RegistryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Internet Explorer\MAIN\FeatureControl\FEATURE_BROWSER_EMULATION", True)
                If key Is Nothing Then
                    key = Registry.CurrentUser.CreateSubKey("SOFTWARE\Microsoft\Internet Explorer\MAIN\FeatureControl\FEATURE_BROWSER_EMULATION")
                End If
                If key IsNot Nothing Then
                    key.SetValue(Path.GetFileName(Process.GetCurrentProcess().ProcessName & ".exe"), 0, RegistryValueKind.DWord) 'Latest IE
                End If
            Catch
            End Try
        End Sub
        Public Shared Property LocalPrefix() As String
        Public Shared Property DataPath() As String
        Public Shared Function GetFileLocalCopy(ByVal fileName As String, ByVal directoryName As String) As String
            If String.IsNullOrEmpty(LocalPrefix) Then
                Throw New InvalidOperationException()
            End If
            Dim localName As String = LocalPrefix & fileName
            Dim filePath As String = GetFile(fileName, directoryName)
            Dim fileDirectoryPath As String = Path.GetDirectoryName(filePath)
            Dim localFilePath As String = Path.Combine(fileDirectoryPath, localName)
            If File.Exists(localFilePath) Then
                Return localFilePath
            End If
            File.Copy(filePath, localFilePath)
            Dim attributes As FileAttributes = File.GetAttributes(localFilePath)
            If (attributes And FileAttributes.ReadOnly) <> 0 Then
                File.SetAttributes(localFilePath, attributes And (Not FileAttributes.ReadOnly))
            End If
            Return localFilePath
        End Function
        Public Shared Function SingleInstanceApplicationGuard(ByVal applicationName As String, <System.Runtime.InteropServices.Out()> ByRef [exit] As Boolean) As IDisposable
            Dim mutex As New Mutex(True, applicationName & AssemblyInfo.VersionShort)
            If mutex.WaitOne(0, False) Then
                [exit] = False
            Else
                Dim current As Process = Process.GetCurrentProcess()
                For Each process As Process In System.Diagnostics.Process.GetProcessesByName(current.ProcessName)
                    If process.Id <> current.Id AndAlso process.MainWindowHandle <> IntPtr.Zero Then
                        WinApiHelper.SetForegroundWindow(process.MainWindowHandle)
                        WinApiHelper.RestoreWindowAsync(process.MainWindowHandle)
                        Exit For
                    End If
                Next process
                [exit] = True
            End If
            Return mutex
        End Function
        Private NotInheritable Class WinApiHelper

            Private Sub New()
            End Sub

            <SecuritySafeCritical>
            Public Shared Function SetForegroundWindow(ByVal hwnd As IntPtr) As Boolean
                Return Import.SetForegroundWindow(hwnd)
            End Function
            <SecuritySafeCritical>
            Public Shared Function RestoreWindowAsync(ByVal hwnd As IntPtr) As Boolean
                Return Import.ShowWindowAsync(hwnd, If(IsMaxmimized(hwnd), CInt(Import.ShowWindowCommands.ShowMaximized), CInt(Import.ShowWindowCommands.Restore)))
            End Function
            <SecuritySafeCritical>
            Public Shared Function IsMaxmimized(ByVal hwnd As IntPtr) As Boolean
                Dim placement As New Import.WINDOWPLACEMENT()
                placement.length = Marshal.SizeOf(placement)
                If Not Import.GetWindowPlacement(hwnd, placement) Then
                    Return False
                End If
                Return placement.showCmd = Import.ShowWindowCommands.ShowMaximized
            End Function
            Private NotInheritable Class Import

                Private Sub New()
                End Sub

                <DllImport("user32.dll")>
                Public Shared Function GetWindowPlacement(ByVal hWnd As IntPtr, ByRef lpwndpl As WINDOWPLACEMENT) As <MarshalAs(UnmanagedType.Bool)> Boolean
                End Function
                <DllImport("user32.dll")>
                Public Shared Function SetForegroundWindow(ByVal hWnd As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
                End Function
                <DllImport("user32.dll")>
                Public Shared Function ShowWindowAsync(ByVal hWnd As IntPtr, ByVal nCmdShow As Integer) As Boolean
                End Function
                <StructLayout(LayoutKind.Sequential)>
                Public Structure WINDOWPLACEMENT
                    Public length As Integer
                    Public flags As Integer
                    Public showCmd As ShowWindowCommands
                    Public ptMinPosition As System.Drawing.Point
                    Public ptMaxPosition As System.Drawing.Point
                    Public rcNormalPosition As System.Drawing.Rectangle
                End Structure
                Public Enum ShowWindowCommands As Integer
                    Hide = 0
                    Normal = 1
                    ShowMinimized = 2
                    ShowMaximized = 3
                    ShowNoActivate = 4
                    Show = 5
                    Minimize = 6
                    ShowMinNoActive = 7
                    ShowNA = 8
                    Restore = 9
                    ShowDefault = 10
                    ForceMinimize = 11
                End Enum
            End Class
        End Class
        Private Shared Function GetEntryAssemblyDirectory() As String
            Dim entryAssembly As System.Reflection.Assembly = System.Reflection.Assembly.GetEntryAssembly()
            If entryAssembly Is Nothing Then
                Return Nothing
            End If
            Dim appPath As String = entryAssembly.Location
            Return Path.GetDirectoryName(appPath)
        End Function
#End If
    End Class
End Namespace