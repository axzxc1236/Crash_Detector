Imports System.IO
Imports System.Text

Public Class Form1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            TextBox1.Text = ""
            Dim a As String = OpenFileDialog1.FileName
            Dim b As String
            b = My.Computer.FileSystem.ReadAllText(a)
            Dim lines = System.IO.File.ReadAllLines(a)

            If b.Contains("Bad Video Card Drivers") Then TextBox1.Text = "顯示卡可能不支援Minecraft或是驅動程式顯示卡太舊" & vbCrLf & "顯示卡:" & My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SYSTEM\ControlSet001\Control\Class\{4D36E968-E325-11CE-BFC1-08002BE10318}\0000", "DriverDesc", Nothing) & vbCrLf & "Google這些關鍵字可能會有幫助:" & vbCrLf & "顯示卡 驅動程式 更新"
            If b.Contains("org.lwjgl.LWJGLException: Pixel format not accelerated") Then TextBox1.Text = "顯示卡可能不支援Minecraft或是驅動程式顯示卡太舊" & vbCrLf & "顯示卡:" & My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SYSTEM\ControlSet001\Control\Class\{4D36E968-E325-11CE-BFC1-08002BE10318}\0000", "DriverDesc", Nothing) & vbCrLf & "Google這些關鍵字可能會有幫助:" & vbCrLf & "顯示卡 驅動程式 更新"
            If b.Contains("Fatal FML error") Then TextBox1.Text = "你可能在使用1.5.2版的Forge" & vbCrLf & "這篇文章可能有幫助" & vbCrLf & "http://bit.ly/1lyBCjh"
            If b.Contains("There was a fatal error starting up minecraft and FML") Then TextBox1.Text = "你可能在使用1.5.2版的Forge" & vbCrLf & "這篇文章可能有幫助" & vbCrLf & "http://bit.ly/1lyBCjh"
            If b.Contains("requires mods") Then
                For i = 0 To lines.Length - 1
                    If lines(i).Contains("requires mods") Then
                        Dim c As String = lines(i)
                        Dim split As String() = c.Split(" ")
                        TextBox1.Text = TextBox1.Text & split(6) & "模組需要" & split(10).Substring(1, split(10).Length - 2) & "模組才能使用" & vbCrLf
                    End If
                Next
            End If
            If b.Contains("java.lang.ClassNotFoundException:") Then TextBox1.Text = TextBox1.Text & "可能安裝方式錯誤或缺少檔案" & vbCrLf
            If b.Contains("java.lang.NoSuchClassMethod:") Then TextBox1.Text = TextBox1.Text & "可能沒有安裝指定模組或指定模組版本太舊" & vbCrLf
            If b.Contains("java.lang.AbstractMethodError") Then TextBox1.Text = TextBox1.Text & "Forge版本太舊，請更換新版" & vbCrLf
            If b.Contains("Minecraft Forge was too old") Then TextBox1.Text = TextBox1.Text & "Forge版本太舊，請更換新版" & vbCrLf
            If b.Contains("java.lang.IllegelArgumentException") Then TextBox1.Text = TextBox1.Text & "方塊\物品ID衝突" & vbCrLf
            If b.Contains("java.lang.Null Pointer Explasion") Then TextBox1.Text = TextBox1.Text & "安裝方式錯誤" & vbCrLf
            If b.Contains("java.lang.OutOfMemoryError") Then TextBox1.Text = TextBox1.Text & "你電腦的記憶體不足或分配的記憶體不夠" & vbCrLf
            If b.Contains("java.lang.IndexOutOfBoundsException") Then TextBox1.Text = TextBox1.Text & "方塊\物品ID設定錯誤(數字太高)" & vbCrLf
            If b.Contains("java.lang.ArrayIndexOutOfBoundsException:") Then TextBox1.Text = TextBox1.Text & "方塊\物品ID設定錯誤(數字太高)" & vbCrLf
            If b.Contains("java.lang.NoClassDefFoundError: IllegalName:") Then TextBox1.Text = TextBox1.Text & "核心模組不相容，你可能用Modloader去跑Forge的模組" & vbCrLf
            If b.Contains("duplicate file name:") Then TextBox1.Text = TextBox1.Text & "模組檔案重複" & vbCrLf
            If b.Contains("java.lang.IndexOutOfBoundsException: Index: 0, Size: 0") Then TextBox1.Text = TextBox1.Text & "推測為Optifine與其他模組的不相容(例如1.7.2的IC2)" & vbCrLf
            If b.Contains("A fatal error has been detected by the Java Runtime Environment:") Then TextBox1.Text = "這是Core dump，基本上應該不常出現，如果頻繁地出現你可以嘗試:" & vbCrLf & "1.刪除.minecraft(建議先備份)" & vbCrLf & "2.更新Java到最新的版本" & vbCrLf & vbCrLf & "如果以上的方法都幫不了你，我也不知道" & vbCrLf & "如果你有解決的好方法，請告訴開發者" & vbCrLf & "請不要上傳此崩潰紀錄"
            'If b.Contains("") Then TextBox1.Text = ""
            'If b.Contains("") Then TextBox1.Text = ""
            'If b.Contains("") Then TextBox1.Text = ""
            'If b.Contains("") Then TextBox1.Text = ""
            'If b.Contains("") Then TextBox1.Text = ""
            'If b.Contains("") Then TextBox1.Text = ""
            'If b.Contains("") Then TextBox1.Text = ""
            If TextBox1.Text = "" Then TextBox1.Text = "沒有問題或問題沒收錄在程式裡" & vbCrLf & "如果是沒有收錄到的crash請使用下面的功能，並在文章下面使用留言"

        Else
            MsgBox("使用者取消動作(error code 1)", 16)
        End If


    End Sub
   Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            My.Computer.FileSystem.WriteAllText(Environment.CurrentDirectory & "\Crash-Detector\upload.bat", "cd Crash-Detector" & vbCrLf & "cd Crash-Detector" & vbCrLf & "curl -d lang=text --data-urlencode text@" & OpenFileDialog1.FileName & " https://cantbuyit.com/pastebin/api/create -k >123", False)
            Shell("cmd /c Crash-Detector\upload.bat", AppWinStyle.Hide, True)
            TextBox2.Text = My.Computer.FileSystem.ReadAllText(Environment.CurrentDirectory & "\Crash-Detector\123")
            If TextBox2.Text.Contains("Error: Missing paste text") Then TextBox2.Text = "未知錯誤"
        Else
            MsgBox("使用者取消動作(error code 1)", 16)
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        MsgBox("Crash detector - A program help you to solve crash problems" & vbCrLf & "    Copyright (C) 2014  21(21999125、x21999125x、axzxc1236)" & vbCrLf & vbCrLf & "    This program is free software: you can redistribute it and/or modify" & vbCrLf & "    it under the terms of the GNU General Public License as published by" & vbCrLf & "    the Free Software Foundation, either version 3 of the License, or" & vbCrLf & "    (at your option) any later version." & vbCrLf & vbCrLf & "    This program is distributed in the hope that it will be useful," & vbCrLf & "    but WITHOUT ANY WARRANTY; without even the implied warranty of" & vbCrLf & "    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the" & vbCrLf & "    GNU General Public License for more details." & vbCrLf & vbCrLf & "    You should have received a copy of the GNU General Public License" & vbCrLf & "    along with this program.  If not, see <http://www.gnu.org/licenses/>.")
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        End
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        My.Computer.Clipboard.SetText(TextBox2.Text)
    End Sub
End Class
