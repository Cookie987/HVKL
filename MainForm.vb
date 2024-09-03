Imports System.IO
Imports System.Threading

Public Class MainForm
    Dim mutex As Mutex
    Private Function StartGame(StartVer As String)
        ' 定义父目录路径
        If StartVer = "" Then
            AntdUI.Notification.error(Me, "错误", "未选择启动版本",,, 5)
            Return 1
        End If
        Dim parentDirectory As String = "version\" + StartVer
        Dim optionFilePath = "version\" + StartVer + "\option.json"

        Try
            GetOption(Me, Select2.SelectedValue)
            UpdaterFilePath = "version\" + StartVer + "\" + UpdaterFilePath
        Catch ex As Exception
            AntdUI.Notification.error(Me, "读取版本配置文件错误", ex.Message,,, 0)
            Return 1
        End Try

        Try
            Using writer As New StreamWriter(UpdaterFilePath, False)
                writer.WriteLine(UpdaterFileContent)
            End Using
        Catch ex As Exception
            AntdUI.Notification.error(Me, "启动错误 ", ex.Message,,, 0)
            Return 1
        End Try

        Dim appPath As String = Path.Combine(parentDirectory, SubDirectory, ExeName)

        ' 创建互斥锁 （Vacko1.2.2）
        mutex = New Mutex(False, MutexName)

        ' 创建 ProcessStartInfo 对象
        Dim startInfo As New ProcessStartInfo With {
            .FileName = appPath,
            .WorkingDirectory = parentDirectory,
            .RedirectStandardOutput = False,  ' 将工作目录设置为父目录
            .UseShellExecute = False,
            .Arguments = Args
            }

        Dim process As New Process With {
            .StartInfo = startInfo
        }
        ' 启动应用程序
        Try
            process.Start()
            LastStartVersion = Select1.SelectedIndex
            AntdUI.Notification.success(Me, "启动成功", "" + CustomName,,, 5)
            Try
                Dim optionRead As VersionOption = ReadOption(optionFilePath)
                GetOption(Me, Select2.SelectedValue)
                LastStartTime = Now
                SaveOption(Me, Select2.SelectedValue)
            Catch ex As Exception
                AntdUI.Notification.error(Me, "写入版本配置文件错误", ex.Message,,, 0)
            End Try
            TotalStartTimes += 1
            SaveConfig(Me)
            Return 0
        Catch ex As Exception
            AntdUI.Notification.error(Me, "启动错误 ", ex.Message,,, 0)
            Return 1
        End Try
    End Function
    Public Function RefreshVersion()
        Select1.SelectedValue = ""
        Select2.SelectedValue = ""
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
                    'AntdUI.Notification.error(Me, "读取版本配置文件错误", ex.Message,,, 0)
                End Try
            Next
        Else
            AntdUI.Message.warn(Me, "未安装任何版本，请先去下载版本",, 5)
        End If
        Return 0
    End Function

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AntdUI.Config.ShowInWindow = True
        RefreshVersion()
        WindowBar1.SubText += "v" + My.Resources.Resource1.Version
        Dim floatButton = AntdUI.FloatButton.open(New AntdUI.FloatButton.Config(Me, New AntdUI.FloatButton.ConfigBtn() {
            New AntdUI.FloatButton.ConfigBtn("OpenVersionDir", My.Resources.Resource1.FolderSVG, True) With {
                .Badge = "",
                .Tooltip = "打开version文件夹",
                .Round = True,
                .Type = AntdUI.TTypeMini.Default
            },
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

                       StartGame(Select2.SelectedValue)
                   Case "Refresh"
                       RefreshButton_Click()
                   Case "OpenVersionDir"
                       Dim relativePath As String = ".\version"
                       Dim folderPath As String = Path.GetFullPath(relativePath)
                       Process.Start("explorer.exe", folderPath)
               End Select
           End Sub))
        Dim FileExists As Boolean
        FileExists = My.Computer.FileSystem.FileExists(ConfigFilePath)

        If FileExists = False Then
            HVKLVersion = My.Resources.Resource1.Version
            CustomDownloadUrl = DefaultDownloadUrl
            SaveConfig(Me)
        Else
            Try
                GetConfig(Me)
            Catch ex As Exception
                AntdUI.Notification.error(Me, "读取配置文件错误，已重置", ex.Message,,, 0)
                HVKLVersion = My.Resources.Resource1.Version
                DeveloperMode = False
                UseCustomBackground = False
                LastStartVersion = Nothing
                CustomDownloadUrl = DefaultDownloadUrl
                TotalStartTimes = 0
                SaveConfig(Me)
            End Try

            If Not HVKLVersion = My.Resources.Resource1.Version Then
                AntdUI.Message.info(Me, "已迁移旧版本HVKL数据")
                CustomDownloadUrl = DefaultDownloadUrl
                HVKLVersion = My.Resources.Resource1.Version
                SaveConfig(Me)
            End If
            Try
                Select1.SelectedIndex = LastStartVersion
                Select2.SelectedIndex = LastStartVersion
            Catch ex As Exception
                LastStartVersion = 0
            End Try

            If DeveloperMode = True Then
                If UseCustomBackground = True Then
                    ' 指定图片文件的路径
                    Dim imagePath As String = "background.png"

                    If File.Exists(imagePath) Then
                        ' 从文件加载图片并设置为背景
                        Try
                            BackgroundImage = Image.FromFile(imagePath)
                            BackgroundImageLayout = ImageLayout.Stretch
                        Catch ex As Exception
                            AntdUI.Message.error(Me, "背景文件加载错误：" + ex.Message)
                        End Try

                    Else
                        AntdUI.Message.warn(Me, "未定义自定义背景图片，请把背景图片重命名为background.png并放在程序目录下")
                    End If
                Else
                    BackgroundImage = Nothing
                End If
            End If
        End If
        Dim isDirExist = Directory.Exists("version\")
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

    Private Sub SettingImage3d_Click(sender As Object, e As EventArgs) Handles SettingImage3d.Click, SettingLabel.Click, MainSettingPanel.Click
        SettingForm.Show()
    End Sub

    Private Sub Select1_Click(sender As Object, e As EventArgs) Handles Select1.Click
        RefreshVersion()
    End Sub

    Public Sub RefreshButton_Click()
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
                                                    config.OK("获取版本完成")
                                                Else
                                                    config.Warn("未安装任何版本，请先去下载版本")
                                                End If
                                            End Sub,, 2)
    End Sub

    Private Sub Select1_SelectedIndexChanged(sender As Object, value As Integer) Handles Select1.SelectedIndexChanged
        Select2.SelectedIndex = Select1.SelectedIndex
    End Sub

    Private Sub ToolsImage3d_Click(sender As Object, e As EventArgs) Handles ToolsImage3d.Click, LabelTools.Click, PanelTools.Click
        ToolForm.Show()
    End Sub
End Class