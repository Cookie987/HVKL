Imports System.ComponentModel
Imports System.IO
Imports System.IO.Compression
Imports System.Threading
Imports AntdUI

Public Class ManageForm
    Private Sub SetRefreshVersion()
        Select1.SelectedValue = ""
        Select2.SelectedValue = ""
        AntdUI.Message.loading(Me, "获取版本中", Sub(config)
                                                ' 指定要列出子文件夹的路径
                                                Dim folderPath As String = "version"
                                                ' 检查路径是否存在
                                                If Directory.Exists(folderPath) Then
                                                    ' 获取所有子文件夹
                                                    Dim subDirectories As String() = Directory.GetDirectories(folderPath)
                                                    Select1.Items.Clear()
                                                    Select2.Items.Clear()
                                                    ' 将子文件夹添加到选择器中
                                                    For Each dir As String In subDirectories
                                                        Try
                                                            Dim optionRead As VersionOption = ReadOption(dir + "\option.json")
                                                            Dim VerName = optionRead.Custom.Name
                                                            Dim Ver = optionRead.VackoVersion
                                                            Select1.Items.Add(Path.GetFileName(VerName + "（" + Ver + "）"))
                                                            Select2.Items.Add(Path.GetFileName(dir))
                                                        Catch ex As Exception
                                                            config.Error("读取版本配置文件错误：" + ex.Message)
                                                        End Try
                                                    Next
                                                    config.OK("读取版本完成")
                                                Else
                                                    config.Warn("未安装任何版本，请先去下载版本")
                                                End If
                                            End Sub,, 2)
    End Sub

    Private Sub ManageForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetRefreshVersion()
    End Sub

    Private Sub DeleteFolder(folderPath As String)
        AntdUI.Message.loading(Me, "删除版本中", Sub(config)
                                                Try
                                                    ' 检查文件夹是否存在
                                                    If Directory.Exists(folderPath) Then
                                                        ' 删除文件夹及其所有内容
                                                        Directory.Delete(folderPath, True)
                                                        config.OK("成功删除该版本")
                                                    Else
                                                        config.Error("指定的文件夹路径不存在")
                                                    End If
                                                Catch ex As Exception
                                                    ' 处理删除过程中的异常
                                                    config.Error("删除文件夹时出错: " + ex.Message)
                                                End Try
                                            End Sub,, 2)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        AntdUI.Modal.open(New AntdUI.Modal.Config(Me, "删除版本", "这个版本及其存档将会失去很久（真的很久）！", AntdUI.TType.Warn) With {
            .OkText = "删除",
            .OkType = TTypeMini.Error,
            .OnOk = Function(config)
                        DeleteFolder(Application.StartupPath + "version\" + Select2.SelectedValue)
                        MainForm.RefreshVersion()
                        SetRefreshVersion()
                        Return True
                    End Function
        })
        SettingPanel.Visible = False
    End Sub

    Private Sub Select1_SelectedIndexChanged() Handles Select1.SelectedIndexChanged
        Select2.SelectedIndex = Select1.SelectedIndex
        Dim parentDirectory As String = Application.StartupPath + "version\" + Select2.SelectedValue
        Dim optionFilePath = Application.StartupPath + "version\" + Select2.SelectedValue + "\option.json"
        If Not Select2.SelectedValue = "" Then
            Try
                GetOption(Me, Select2.SelectedValue)
                SettingPanel.Visible = True
                InputVersionName.Text = CustomName
                InputDirName.Text = Select2.SelectedValue
                Label2.Text = "Vacko版本：" + VackoVersion + "（" + Family + "）"
                Label3.Text = "上次启动：" + LastStartTime
                If Not Family = "MoonBridge" Then
                    Button5.Enabled = True
                Else
                    Button5.Enabled = False
                End If


            Catch ex As Exception
                AntdUI.Notification.error(Me, "读取版本配置文件错误", ex.Message,,, 0)
            End Try
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim parentDirectory As String = Application.StartupPath + "version\" + Select2.SelectedValue
        Dim optionFilePath = Application.StartupPath + "version\" + Select2.SelectedValue + "\option.json"
        Try
            GetOption(Me, Select2.SelectedValue)
            SettingPanel.Visible = True
            CustomName = InputVersionName.Text
            SaveOption(Me, Select2.SelectedValue)
            If Not Select2.SelectedValue = InputDirName.Text Then
                My.Computer.FileSystem.RenameDirectory(Application.StartupPath + "version\" + Select2.SelectedValue, InputDirName.Text)
            End If
            MainForm.RefreshVersion()
            SetRefreshVersion()
            SettingPanel.Visible = False
        Catch ex As Exception
            Notification.error(Me, "保存更改错误", ex.Message,,, 0)
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            AntdUI.Modal.open(New AntdUI.Modal.Config(Me, "警告", "Vacko不同版本之间的兼容性极差，HVKL将不会检查版本之间的兼容性。可能会出现无法正常运行Vacko的情况！", AntdUI.TType.Warn) With {
            .OkText = "更换",
            .OkType = TTypeMini.Warn,
            .OnOk = Function(config)
                        Dim optionFilePath = Application.StartupPath + "version\" + Select2.SelectedValue + "\option.json"
                        Try
                            GetOption(Me, Select2.SelectedValue)
                            OriginalVersion = VackoVersion
                            OriginalDir = Select2.SelectedValue
                            ' 使用 Invoke 保证在主线程中显示对话框
                            Me.Invoke(Sub()
                                          Using replaceVersionForm As New ReplaceVersionForm()
                                              replaceVersionForm.StartPosition = FormStartPosition.CenterParent ' 居中显示
                                              replaceVersionForm.ShowDialog(Me) ' 模态显示
                                          End Using
                                      End Sub)
                        Catch ex As Exception
                            AntdUI.Notification.error(Me, "读取版本配置文件错误", ex.Message,,, 0)
                        End Try
                        Return True
                    End Function
            })
            MainForm.RefreshVersion()
            SetRefreshVersion()
            SettingPanel.Visible = False
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim sourceDir = Application.StartupPath + "version\" + Select2.SelectedValue

        Message.loading(Me, "导出中", Sub(config)
                                       ' 声明一个变量来存储用户选择的路径
                                       Dim zipFilePath As String = Nothing

                                       ' 创建一个新线程并强制 STA 模式
                                       Dim saveFileDialogThread As New Thread(
                                                  Sub()
                                                      ' 初始化保存文件对话框
                                                      Dim saveFileDialog As New SaveFileDialog With {
                                                          .Title = "保存 Vacko 整合包",
                                                          .Filter = "HVKL 整合包文件 (*.hvklzip)|*.hvklzip",
                                                          .DefaultExt = "hvklzip"
                                                      }

                                                      ' 显示对话框并获取用户选择的路径
                                                      If saveFileDialog.ShowDialog = DialogResult.OK Then
                                                          zipFilePath = saveFileDialog.FileName
                                                      End If
                                                  End Sub)
                                       saveFileDialogThread.SetApartmentState(ApartmentState.STA) ' 设置为 STA 模式
                                       saveFileDialogThread.Start()
                                       saveFileDialogThread.Join() ' 等待线程完成

                                       ' 如果用户没有取消保存操作
                                       If Not String.IsNullOrEmpty(zipFilePath) Then
                                           Try
                                               ' 压缩指定目录为 ZIP 文件
                                               ZipFile.CreateFromDirectory(sourceDir, zipFilePath)
                                               config.OK("整合包已成功导出到: " + zipFilePath)
                                           Catch ex As Exception
                                               ' 错误处理
                                               config.Error("导出失败: " + ex.Message)
                                           End Try
                                       Else
                                       End If
                                   End Sub,, 2)
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        MusicForm.Show()
    End Sub

    Private Sub ManageForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If Not MusicDownloadForm.IsDisposed AndAlso Not MusicForm.IsDisposed Then
            MusicForm.Close()
            MusicDownloadForm.Close()
        End If
    End Sub
End Class