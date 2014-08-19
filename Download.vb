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
                My.Computer.Network.DownloadFile("https://dl.dropboxusercontent.com/s/vyix28q206hnsjt/curl.exe", Environment.CurrentDirectory & "\Crash-Detector\curl.exe", "", "", False, 100000, True)
            Catch ex As System.Net.WebException
                MsgBox("請使用留言告知'Curl載點出現問題'" & vbCrLf & "已將錯誤通知複製起來，請用ctrl + v貼上在文章留言" & vbCrLf & "謝謝合作!")
                End
            End Try
        End If

        Me.Hide()
        Form1.Show()
    End Sub
End Class