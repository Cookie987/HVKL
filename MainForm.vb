Imports AntdUI
Imports System.IO

Public Class MainForm
    Private Function StartGame()
        ' 定义父目录路径
        If Select1.SelectedValue = "" Then
            AntdUI.Notification.error(Me, "错误", "未选择启动版本",,, 5)
            Return 1
        End If
        Dim parentDirectory As String = "version\" + Select1.SelectedValue

        ' 定义文件路径
        Dim filePath As String = parentDirectory + "\Game\Appdata\Updater.vak2"

        ' 定义要写入的内容
        Dim content As String = "updater:hrd" + vbCrLf

        ' 写入文件
        Try
            ' 使用 StreamWriter 打开文件并写入内容
            Using writer As New StreamWriter(filePath, False) ' True 表示追加内容，False 表示覆盖
                writer.WriteLine(content)
            End Using
        Catch ex As Exception
            AntdUI.Notification.error(Me, "启动错误 ", ex.Message,,, 5)
            Return 1
        End Try

        ' 定义子目录名称和应用程序名称
        Dim subDirectory As String = "Game"
        Dim appName As String = "Vacko2.exe"

        ' 组合成完整的应用程序路径
        Dim appPath As String = System.IO.Path.Combine(parentDirectory, subDirectory, appName)

        ' 创建 ProcessStartInfo 对象
        Dim startInfo As New ProcessStartInfo()
        startInfo.FileName = appPath
        startInfo.WorkingDirectory = parentDirectory ' 将工作目录设置为父目录

        ' 启动应用程序
        Try
            Process.Start(startInfo)
            AntdUI.Notification.info(Me, "启动成功", "Vacko #." + Select1.SelectedValue,,, 5)
            Return 0
        Catch ex As Exception
            AntdUI.Notification.error(Me, "启动错误 ", ex.Message,,, 5)
            Return 1
        End Try
    End Function
    Private Function Refresh()
        AntdUI.Message.loading(Me, "获取版本中", Sub(config)
                                                ' 指定要列出子文件夹的路径
                                                Dim folderPath As String = "version"
                                                ' 检查路径是否存在
                                                If Directory.Exists(folderPath) Then
                                                    ' 获取所有子文件夹
                                                    Dim subDirectories As String() = Directory.GetDirectories(folderPath)
                                                    ' 清空选择器的项
                                                    Select1.Items.Clear()
                                                    ' 将子文件夹添加到选择器中
                                                    For Each dir As String In subDirectories
                                                        Select1.Items.Add(Path.GetFileName(dir))
                                                    Next
                                                    config.OK("获取版本完成")
                                                Else
                                                    config.Error("指定的文件夹不存在")
                                                End If
                                            End Sub,, 2)
        Return 0
    End Function
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Refresh()
        WindowBar1.Text += " v" + My.Resources.Resource1.Version
        AntdUI.Config.ShowInWindow = True
        Dim floatButton = AntdUI.FloatButton.open(New AntdUI.FloatButton.Config(Me, New AntdUI.FloatButton.ConfigBtn() {
            New AntdUI.FloatButton.ConfigBtn("Refresh", My.Resources.Resource1.RefreshSVG, True) With {
                .Badge = "",
                .Tooltip = "刷新",
                .Round = True,
                .Type = AntdUI.TTypeMini.Default
            },
            New AntdUI.FloatButton.ConfigBtn("StartGame", My.Resources.Resource1.RocketSVG, True) With {
                .Badge = "",
                .Tooltip = "启动选择的Vacko2版本",
                .Round = True,
                .Type = AntdUI.TTypeMini.Primary
            }
        }, Sub(btn)

               Select Case btn.Name
                   Case "StartGame"
                       StartGame()
                   Case "Refresh"
                       Refresh()
               End Select
           End Sub))
        Dim FileExists As Boolean
        Dim filePath = "config.json"
        FileExists = My.Computer.FileSystem.FileExists(filePath)

        If FileExists = False Then
            Try
                Dim configToWrite As New Config With {
                .HVKLVersion = My.Resources.Resource1.Version
                }
                WriteConfig(configToWrite, filePath)
            Catch ex As Exception
                AntdUI.Notification.open(Me, "写入配置文件错误", ex.Message,,, 0)
            End Try
        Else
            Dim configRead As Config = ReadConfig("config.json")
            If configRead.DeveloperMode = True Then
                If configRead.UseCustomBackground = True Then
                    ' 指定图片文件的路径
                    Dim imagePath As String = "background.png"

                    ' 检查图片文件是否存在
                    If System.IO.File.Exists(imagePath) Then
                        ' 从文件加载图片并设置为背景
                        Me.BackgroundImage = Image.FromFile(imagePath)
                        Me.BackgroundImageLayout = ImageLayout.Stretch ' 可根据需要调整布局方式
                    Else
                        AntdUI.Message.warn(Me, "未定义自定义背景图片，请把背景图片重命名为background.png并放在程序目录下")
                    End If
                Else
                    Me.BackgroundImage = Nothing
                End If
            End If
        End If
        Dim isDirExist = System.IO.Directory.Exists("version\")
        If isDirExist Then
        Else
            My.Computer.FileSystem.CreateDirectory("version\")
        End If
    End Sub

    Private Sub VersionListPanel_Click(sender As Object, e As EventArgs) Handles DownloadVersionPanel.Click, DownloadVersionLabel.Click, DownloadVersionImage.Click
        VersionForm.Show()
    End Sub

    Private Sub ManageVersionImage3d_Click(sender As Object, e As EventArgs) Handles ManageVersionImage3d.Click, ManageVersionLabel.Click, ManageVersionPanel.Click
        ManageForm.Show()
    End Sub

    Private Sub SettingImage3d_Click(sender As Object, e As EventArgs) Handles SettingImage3d.Click, SettingLabel.Click, SettingPanel.Click
        SettingForm.Show()
    End Sub
End Class
