Imports System.IO
Imports System.IO.Compression
Imports System.Net
Imports System.Net.Http
Imports AntdUI

Public Class VersionForm
    Private Sub InstallVersion(ver As String, instMessage As String)
        AntdUI.Message.loading(Me, instMessage, Async Sub(Config)
                                                    ' 云端文件的URL
                                                    Dim zipUrl As String = "https://987assests.s3.bitiful.net/vacko2/version/Vacko" +
                                                    Select1.SelectedValue + ".zip"
                                                    ' 指定要解压到的目录
                                                    Dim extractTo As String = "version/" + ver
                                                    Dim httpClient As New HttpClient()
                                                    If Not Directory.Exists("version/" + ver) Then '检查文件夹是否存在
                                                        Directory.CreateDirectory("version/" + ver)  '不存在，创建文件夹
                                                        Progress1.Value = 0.2
                                                        Try
                                                            Dim fileBytes As Byte() = Await httpClient.GetByteArrayAsync(zipUrl)
                                                            Await File.WriteAllBytesAsync(extractTo + "\downloaded.zip", fileBytes)
                                                            Progress1.Value = 0.3
                                                            ZipFile.ExtractToDirectory(Path.Combine(extractTo, "downloaded.zip"), extractTo)
                                                            Progress1.Value = 0.7
                                                            File.Delete(Path.Combine(extractTo, "downloaded.zip"))
                                                            Progress1.Value = 0.9
                                                            Progress1.Value = 1
                                                            Console.WriteLine("ZIP文件已下载并解压到指定目录。")
                                                            Progress1.Value = 1
                                                            Progress1.State = AntdUI.TType.Success
                                                            MainForm.RefreshVersion()
                                                            Config.OK("安装版本成功")
                                                        Catch ex As Exception
                                                            Progress1.State = AntdUI.TType.Error
                                                            Config.Error("安装版本失败：" + ex.Message)
                                                        End Try
                                                    Else
                                                        Progress1.State = AntdUI.TType.Error
                                                        Config.Error("指定的版本已存在，请先卸载再安装")
                                                    End If

                                                End Sub,, 2)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        InstallVersion(Select1.SelectedValue, "安装版本" + Select1.SelectedValue + "中")
        Progress1.Value = 0.02
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