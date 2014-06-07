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
            Try
                My.Computer.Network.DownloadFile("http://www.paehl.com/open_source/?download=curl_737_0_ssl.zip", Environment.CurrentDirectory & "\Crash-Detector\curl.zip", "", "", False, 100000, True)
            Catch ex As System.Net.WebException
                My.Computer.Clipboard.SetText("例外狀況(01)-CURL_NOT_FOUND")
                MsgBox("請用留言通知作者" & vbCrLf & "例外狀況(01)-CURL_NOT_FOUND" & vbCrLf & "我會盡快釋出更正後的版本" & vbCrLf & "內容已經自動複製，謝謝合作，程式終止")
                End
            End Try
            My.Computer.FileSystem.WriteAllText(Environment.CurrentDirectory & "\Crash-Detector\unzip.bat", "cd Crash-Detector" & vbCrLf & "cd Crash-Detector" & vbCrLf & "7za.exe e curl.zip", False)

            Shell("cmd /c Crash-Detector\unzip.bat", AppWinStyle.Hide, True)
        End If

        Me.Hide()
        Form1.Show()
    End Sub
End Class
