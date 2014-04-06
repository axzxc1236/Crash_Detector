Imports System.IO

Public Class Download
    Private Sub Download_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Stop()
        If Not My.Computer.FileSystem.DirectoryExists(My.Computer.FileSystem.CurrentDirectory & "\Crash-Detector") Then My.Computer.FileSystem.CreateDirectory(My.Computer.FileSystem.CurrentDirectory & "\Crash-Detector")
        If Not My.Computer.FileSystem.FileExists(Environment.CurrentDirectory & "\Crash-Detector\7za.exe") Then My.Computer.Network.DownloadFile("https://dl.dropboxusercontent.com/s/07mw2d3o2v8xkq2/7za.exe", Environment.CurrentDirectory & "\Crash-Detector\7za.exe", "", "", False, 100000, True)
        If Not My.Computer.FileSystem.FileExists(Environment.CurrentDirectory & "\Crash-Detector\curl.exe") Then
            My.Computer.Network.DownloadFile("http://www.paehl.com/open_source/?download=curl_735_0_ssl.zip", Environment.CurrentDirectory & "\Crash-Detector\curl.zip", "", "", False, 100000, True)
            My.Computer.FileSystem.WriteAllText(Environment.CurrentDirectory & "\Crash-Detector\unzip.bat", "cd Crash-Detector" & vbCrLf & "cd Crash-Detector" & vbCrLf & "7za.exe e curl.zip", False)

            Shell("cmd /c Crash-Detector\unzip.bat", AppWinStyle.Hide, True)
        End If

        Me.Hide()
        Form1.Show()
    End Sub
End Class