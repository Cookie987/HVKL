Imports System.IO
Imports System.IO.Compression
Imports System.Net
Imports System.Net.Http
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports AntdUI

Public Class VersionForm
    Private Sub InstallVersion(ver As String, instMessage As String)
        AntdUI.Message.loading(Me, instMessage, Async Sub(Config)
                                                    If Button1.InvokeRequired Then
                                                        Button1.Invoke(Sub() Button1.Enabled = False)
                                                    Else
                                                        Button1.Enabled = False
                                                    End If
                                                    GetConfig(Me)
                                                    If CustomDownloadUrl = "" Then
                                                        CustomDownloadUrl = DefaultDownloadUrl
                                                        SaveConfig(Me)
                                                    End If
                                                    ' 云端文件的URL
                                                    Dim zipUrl As String = CustomDownloadUrl +
                                                    ver + ".zip"
                                                    Progress1.Text = "%建立连接中"
                                                    Progress1.Loading = True
                                                    ' 指定要解压到的目录
                                                    Dim extractTo As String = "version\" + ver
                                                    Dim httpClient As New HttpClient()
                                                    If Not Directory.Exists("version\" + ver) Then '检查文件夹是否存在
                                                        Directory.CreateDirectory("version\" + ver)  '不存在，创建文件夹
                                                        Progress1.Value = 0
                                                        Try
                                                            ' 获取文件的总大小
                                                            Dim response As HttpResponseMessage = Await httpClient.GetAsync(zipUrl, HttpCompletionOption.ResponseHeadersRead)
                                                            response.EnsureSuccessStatusCode()

                                                            Dim totalBytes As Long = response.Content.Headers.ContentLength.GetValueOrDefault()

                                                            ' 创建文件流来写入下载的内容
                                                            Using fileStream As New FileStream(Path.Combine(extractTo, "downloaded.zip"), FileMode.Create, FileAccess.Write, FileShare.None)
                                                                ' 下载文件
                                                                Using stream = Await response.Content.ReadAsStreamAsync()
                                                                    Dim buffer(8192) As Byte
                                                                    Dim bytesRead As Integer
                                                                    Dim totalBytesRead As Long = 0
                                                                    Progress1.Loading = False
                                                                    Progress1.Text = "%下载文件中"
                                                                    Do
                                                                        bytesRead = Await stream.ReadAsync(buffer)
                                                                        If bytesRead = 0 Then Exit Do

                                                                        Await fileStream.WriteAsync(buffer.AsMemory(0, bytesRead))
                                                                        totalBytesRead += bytesRead

                                                                        ' 更新进度条
                                                                        Progress1.Value = totalBytesRead / totalBytes
                                                                    Loop
                                                                End Using
                                                            End Using
                                                            Progress1.Text = "%解压中"
                                                            Progress1.Value = 0.0
                                                            ' 使用ZipArchive处理ZIP文件
                                                            Using archive As ZipArchive = ZipFile.OpenRead(Path.Combine(extractTo, "downloaded.zip"))
                                                                For Each entry As ZipArchiveEntry In archive.Entries
                                                                    ' 目标文件路径
                                                                    Dim destinationPath As String = Path.Combine(extractTo, entry.FullName)

                                                                    ' 确保目录存在
                                                                    Dim directoryPath As String = Path.GetDirectoryName(destinationPath)
                                                                    If Not Directory.Exists(directoryPath) Then
                                                                        Directory.CreateDirectory(directoryPath)
                                                                    End If
                                                                    ' 检查文件是否已经存在
                                                                    If Not File.Exists(destinationPath) AndAlso Not String.IsNullOrEmpty(entry.Name) Then
                                                                        ' 解压缩文件
                                                                        entry.ExtractToFile(destinationPath)
                                                                    End If
                                                                    Progress1.Value += 0.1
                                                                Next
                                                            End Using
                                                            ' ZipFile.ExtractToDirectory(Path.Combine(extractTo, "downloaded.zip"), extractTo)
                                                            Progress1.Value = 0.7
                                                            Progress1.Text = "删除临时文件中"
                                                            File.Delete(Path.Combine(extractTo, "downloaded.zip"))
                                                            Progress1.Value = 0.9
                                                            Progress1.Value = 1
                                                            Console.WriteLine("ZIP文件已下载并解压到指定目录。")
                                                            Progress1.Value = 1
                                                            Progress1.State = AntdUI.TType.Success
                                                            Progress1.Text = "安装成功"
                                                            Config.OK("安装版本成功")
                                                        Catch ex As Exception
                                                            Progress1.State = AntdUI.TType.Error
                                                            Progress1.Loading = False
                                                            Try
                                                                ' 检查文件夹是否存在
                                                                If Directory.Exists("version\" + ver) Then
                                                                    ' 删除文件夹及其所有内容
                                                                    Directory.Delete("version\" + ver, True)
                                                                Else
                                                                End If
                                                            Catch exp As Exception
                                                            End Try
                                                            Config.Error("安装版本失败：" + ex.Message)
                                                        End Try
                                                    Else
                                                        Progress1.State = AntdUI.TType.Error
                                                        Progress1.Loading = False
                                                        Config.Error("指定的版本已存在，请先改变目录名称")
                                                    End If
                                                    If Button1.InvokeRequired Then
                                                        Button1.Invoke(Sub() Button1.Enabled = True)
                                                    Else
                                                        Button1.Enabled = True
                                                    End If
                                                End Sub,, 2)
        MainForm.RefreshButton_Click()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        InstallVersion(Select1.SelectedValue, "安装版本" + Select1.SelectedValue + "中")
        Progress1.Value = 0
        Progress1.Text = "%准备中"
    End Sub

    Private Sub VersionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Select1.Items.Clear()
        AntdUI.Message.loading(Me, "获取版本中", Async Sub(config)
                                                ' 云端文件的URL
                                                Dim fileUrl As String = "https://987assests.s3.bitiful.net/vacko2/versions.txt"
                                                Progress1.Loading = True
                                                ' 下载文本文件并处理
                                                Try
                                                    Dim httpClient As New HttpClient()
                                                    ' 异步下载文件内容
                                                    Dim fileContent As String = Await httpClient.GetStringAsync(fileUrl)
                                                    ' 将文件内容按行分割
                                                    Dim lines() As String = fileContent.Split(New String() {vbCrLf, vbLf, vbCr}, StringSplitOptions.None)
                                                    ' 将每一行添加到选择器（ComboBox）
                                                    For Each line As String In lines
                                                        If Not String.IsNullOrWhiteSpace(line) Then
                                                            Select1.Items.Add(line.Trim())
                                                        End If
                                                    Next
                                                    Progress1.Loading = False
                                                    config.OK("获取版本成功")
                                                Catch ex As Exception
                                                    Progress1.Loading = False
                                                    Progress1.State = AntdUI.TType.Error
                                                    config.Error("获取版本列表错误：" + ex.Message)
                                                End Try
                                            End Sub,, 2)
    End Sub

    Private Sub Select1_SelectedValueChanged(sender As Object, value As Object) Handles Select1.SelectedValueChanged
        Button1.Enabled = True
        Progress1.State = TType.None
        Progress1.Value = 0
    End Sub
End Class