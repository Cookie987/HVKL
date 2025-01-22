Imports System.IO
Imports System.IO.Compression
Imports System.Net.Http
Imports AntdUI

Public Class ReplaceVersionForm
    Dim Button2_Clicked = False
    Private Sub ReplaceVersionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        OriginalVerLabel.Text = OriginalVersion
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

    Private Sub ReplaceVersion(ver As String, instMessage As String)
        AntdUI.Message.loading(Me, instMessage, Async Sub(Config)
                                                    If Button2.InvokeRequired Then
                                                        Button2.Invoke(Sub() Button2.Enabled = False)
                                                    Else
                                                        Button2.Enabled = False
                                                    End If
                                                    If CustomDownloadUrl = "" Then
                                                        CustomDownloadUrl = DefaultDownloadUrl
                                                        SaveConfig(Me)
                                                    End If
                                                    ' 云端文件的URL
                                                    Dim fileUrl As String = CustomDownloadUrl +
                                                    ver + ".zip"
                                                    ' 下载后的文件路径
                                                    Dim downloadPath As String = Path.Combine(Application.StartupPath + "version\", "downloadedFile.zip")
                                                    ' 解压缩目标目录
                                                    Dim extractPath As String = Application.StartupPath + "version\" + OriginalDir
                                                    ' 创建HttpClient实例
                                                    Progress1.Text = "%删除旧版本配置中"
                                                    Dim httpClient As New HttpClient()
                                                    GetOption(Me, OriginalDir)
                                                    Dim oldLastStartTime = LastStartTime
                                                    Dim oldName = CustomName
                                                    Try
                                                        My.Computer.FileSystem.DeleteFile(Application.StartupPath + "version\" + OriginalDir + "\option.json", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.SendToRecycleBin, FileIO.UICancelOption.DoNothing)
                                                    Catch ex As Exception
                                                        Config.Error("删除版本配置文件失败：" + ex.Message)
                                                    End Try
                                                    Try
                                                        My.Computer.FileSystem.DeleteFile(Application.StartupPath + "version\" + OriginalDir + "\" + "Game" + "\" + "Vacko2.exe", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.SendToRecycleBin, FileIO.UICancelOption.DoNothing)
                                                        My.Computer.FileSystem.DeleteFile(Application.StartupPath + "version\" + OriginalDir + "\" + SubDirectory + "\" + ExeName, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.SendToRecycleBin, FileIO.UICancelOption.DoNothing)
                                                        Progress1.Value = 0.2
                                                    Catch ex As Exception
                                                        AntdUI.Message.warn(Me, "删除源文件失败：" + ex.Message,, 2)
                                                    End Try

                                                    Try
                                                        Progress1.Text = "%建立连接中"
                                                        ' 获取文件的总大小
                                                        Dim response As HttpResponseMessage = Await httpClient.GetAsync(fileUrl, HttpCompletionOption.ResponseHeadersRead)
                                                        response.EnsureSuccessStatusCode()

                                                        Dim totalBytes As Long = response.Content.Headers.ContentLength.GetValueOrDefault()

                                                        ' 创建文件流来写入下载的内容
                                                        Using fileStream As New FileStream(downloadPath, FileMode.Create, FileAccess.Write, FileShare.None)
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
                                                        ' 使用ZipArchive处理ZIP文件
                                                        Using archive As ZipArchive = ZipFile.OpenRead(downloadPath)
                                                            Progress1.Value = 0.5
                                                            Progress1.Text = "%解压文件中"
                                                            For Each entry As ZipArchiveEntry In archive.Entries
                                                                ' 目标文件路径
                                                                Dim destinationPath As String = Path.Combine(extractPath, entry.FullName)

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
                                                                Progress1.Value += 0.01
                                                            Next
                                                        End Using
                                                        Progress1.Value = 0.7
                                                        Try
                                                            Dim optionRead2 As VersionOption = ReadOption(Application.StartupPath + "version\" + OriginalDir + "\option.json")
                                                            GetOption(Me, OriginalDir)
                                                            CustomName = oldName
                                                            LastStartTime = oldLastStartTime
                                                            SaveOption(Me, OriginalDir)
                                                        Catch ex As Exception
                                                            AntdUI.Message.error(Me, "保存更改错误：" + ex.Message,, 0)
                                                        End Try
                                                        Progress1.Value = 0.9
                                                        Progress1.Value = 1
                                                        Console.WriteLine("ZIP文件已下载并解压到指定目录。")
                                                        File.Delete(Path.Combine(Application.StartupPath + "version\", "downloadedFile.zip"))
                                                        Progress1.Value = 1
                                                        Progress1.State = AntdUI.TType.Success
                                                        Button2.Type = TTypeMini.Success
                                                        Config.OK("更换版本成功")
                                                    Catch ex As Exception
                                                        Progress1.State = AntdUI.TType.Error
                                                        Button2.Type = TTypeMini.Error
                                                        Config.Error("更换版本失败：" + ex.Message)
                                                    End Try
                                                    If Button2.InvokeRequired Then
                                                        Button2.Invoke(Sub() Button2.Enabled = True)
                                                    Else
                                                        Button2.Enabled = True
                                                    End If
                                                End Sub,, 2)
        MainForm.RefreshButton_Click()
        Button2.Text = "关闭"
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Button2_Clicked Then
            Close()
        End If
        Button2_Clicked = True
        ReplaceVersion(Select1.SelectedValue, "更换为版本" + Select1.SelectedValue + "中")
        Progress1.Value = 0.02
    End Sub
End Class