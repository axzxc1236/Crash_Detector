﻿Imports System.IO
Imports System.Text

Public Class Form1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            TextBox1.Text = ""
            Dim a As String = OpenFileDialog1.FileName
            Dim b As String
            b = My.Computer.FileSystem.ReadAllText(a)
            'TextBox1.Text = b
            'If b.Contains("") Then TextBox1.Text = ""
            If b.Contains("Bad Video Card Drivers") Then TextBox1.Text = "顯示卡可能不支援Minecraft或是驅動程式顯示卡太舊" & vbCrLf & "顯示卡:" & My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SYSTEM\ControlSet001\Control\Class\{4D36E968-E325-11CE-BFC1-08002BE10318}\0000", "DriverDesc", Nothing) & vbCrLf & "Google這先灌鍵字可能會有幫助:" & vbCrLf & "顯示卡 驅動程式 更新"
            If b.Contains("org.lwjgl.LWJGLException: Pixel format not accelerated") Then TextBox1.Text = "顯示卡可能不支援Minecraft或是驅動程式顯示卡太舊" & vbCrLf & "顯示卡:" & My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SYSTEM\ControlSet001\Control\Class\{4D36E968-E325-11CE-BFC1-08002BE10318}\0000", "DriverDesc", Nothing) & vbCrLf & "Google這先灌鍵字可能會有幫助:" & vbCrLf & "顯示卡 驅動程式 更新"
            If b.Contains("Fatal FML error") Then TextBox1.Text = "你可能在使用1.5.2版的Forge" & vbCrLf & "這篇文章可能有幫助" & vbCrLf & "http://bit.ly/1lyBCjh"
            If b.Contains("There was a fatal error starting up minecraft and FML") Then TextBox1.Text = "你可能在使用1.5.2版的Forge" & vbCrLf & "這篇文章可能有幫助" & vbCrLf & "http://bit.ly/1lyBCjh"
            If b.Contains("requires mods") Then
                Dim lines = System.IO.File.ReadAllLines(a)
                For i = 0 To lines.Length - 1
                    If lines(i).Contains("requires mods") Then
                        Dim c As String = Read_TextFile_Line(a, i + 1)
                        Dim split As String() = c.Split(" ")
                        'MsgBox(Split(6))
                        'MsgBox(split(10).Substring(1, split(10).Length - 2))
                        TextBox1.Text = split(6) & "模組需要" & split(10).Substring(1, split(10).Length - 2) & "模組才能使用"
                    End If
                Next
            End If
            If b.Contains("java.lang.ClassNotFoundException:") Then TextBox1.Text = "可能安裝方式錯誤或缺少檔案"
            If b.Contains("java.lang.NoSuchClassMethod:") Then TextBox1.Text = "可能沒有安裝指定模組或指定模組版本太舊"
            If b.Contains("java.lang.AbstractMethodError") Then TextBox1.Text = "Forge版本太舊，請更換新版"
            If b.Contains("Minecraft Forge was too old") Then TextBox1.Text = "Forge版本太舊，請更換新版"
            If b.Contains("java.lang.IllegelArgumentException") Then TextBox1.Text = "方塊\物品ID衝突"
            If b.Contains("java.lang.Null Pointer Explasion") Then TextBox1.Text = "安裝方式錯誤"
            If b.Contains("java.lang.OutOfMemoryError") Then TextBox1.Text = "你電腦的記憶體不足或分配的記憶體不夠"
            If b.Contains("java.lang.RuntimeException") Then TextBox1.Text = "你電腦的記憶體不足或分配的記憶體不夠"
            If b.Contains("java.lang.IndexOutOfBoundsException") Then TextBox1.Text = "方塊\物品ID設定錯誤(數字太高)"
            If b.Contains("java.lang.ArrayIndexOutOfBoundsException:") Then TextBox1.Text = "方塊\物品ID設定錯誤(數字太高)"
            If b.Contains("java.lang.NoClassDefFoundError: IllegalName:") Then TextBox1.Text = "核心模組不相容，你可能用Modloader去跑Forge的模組"
            If b.Contains("duplicate file name:") Then TextBox1.Text = "模組檔案重複"
            If b.Contains("java.lang.IndexOutOfBoundsException: Index: 0, Size: 0") Then TextBox1.Text = "推測為Optifine與其他模組的不相容"
            If b.Contains("java.lang.RuntimeException") Then TextBox1.Text = "虛擬記憶體可能設定的太小"
            'If b.Contains("") Then TextBox1.Text = ""
            'If b.Contains("") Then TextBox1.Text = ""
            'If b.Contains("") Then TextBox1.Text = ""
            'If b.Contains("") Then TextBox1.Text = ""
            'If b.Contains("") Then TextBox1.Text = ""
            'If b.Contains("") Then TextBox1.Text = ""
            'If b.Contains("") Then TextBox1.Text = ""
            'If b.Contains("") Then TextBox1.Text = ""
            If TextBox1.Text = "" Then TextBox1.Text = "沒有問題或問題沒收錄在程式裡" & "如果是沒有收錄到的crash請使用下面的功能，並在文章下面使用留言"

        Else
            MsgBox("使用者取消動作(error code 1)", 16)
        End If


    End Sub

    Private Function Read_TextFile_Line(ByVal File As String, ByVal Line_Number As Long) As String

        Dim Lines() As String = {String.Empty}
        Dim Line_Length As Long = 0

        Try
            Lines = IO.File.ReadAllLines(File)
            Line_Length = Lines.LongLength - 1
            Return Lines(Line_Number - 1)

        Catch ex As IO.FileNotFoundException
            MessageBox.Show(String.Format("File not found: ""{0}""", _
                                          File), _
                            Nothing, _
                            MessageBoxButtons.OK, _
                            MessageBoxIcon.Error)

        Catch ex As IndexOutOfRangeException
            MessageBox.Show(String.Format("Attempted to read line {0}, but ""{1}"" has {2} lines.", _
                                          Line_Number, _
                                          File, _
                                          Line_Length + 1), _
                            Nothing, _
                            MessageBoxButtons.OK, _
                            MessageBoxIcon.Error)

        Catch ex As Exception
            Throw New Exception(String.Format("{0}: {1}", _
                                              ex.Message, _
                                              ex.StackTrace))

        Finally
            Lines = Nothing
            Line_Length = Nothing

        End Try

        Return Nothing

    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
        '    Dim a As String = My.Computer.FileSystem.ReadAllText(OpenFileDialog1.FileName)
        '    a.Replace(Chr(10), "<New line>")
        '    a.Replace(vbCrLf, "<New line>")
        '    a.Replace(vbCr, "<New line>")
        '    a.Replace(vbLf, "<New line>")
        '    a.Replace(vbTab, "<New line>")
        '    My.Computer.Clipboard.SetText(a)
        '    WebBrowser1.Navigate("http://tny.cz/api/create.json?paste=" & a)
        'Else
        '    MsgBox("使用者取消動作(error code 1)", 16)
        'End If
    End Sub

    Private Sub WebBrowser1_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        Dim b As String() = WebBrowser1.DocumentText.Split("""")
        WebBrowser1.DocumentText = "http://tny.cz/" & b(5)
        'MsgBox(b(5))
    End Sub
End Class