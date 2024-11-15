Imports System.IO
Imports System.Net.Http
Imports System.Text
Imports System.Threading
Imports AntdUI

Public Class MainForm
    Dim mutex As Mutex
    Private Async Function StartGame(StartVer As String) As Task(Of Integer)
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
            ' 登录
            If RadioHVKLLogin.Checked = True Then
                If SupportHVKLLogin = True Then
                    If InputUser.Text = "User" Or InputUser.Text = "nonelivaccno" Or InputPwd.Text = "nonelivpas" Then
                        AntdUI.Notification.error(Me, "用户名或密码不合法", "请更换",,, 0)
                        Return 1
                    Else
                        Dim remoteUrl As String = "http://vacko.cookie987.top:28987/VackoData/PlayerData/" + LastUsedUser + "/localdata.vak2"

                        ' 获取远程文件中的键值对
                        Dim credentials As Dictionary(Of String, String) = Await GetRemoteCredentials(remoteUrl)
                        If credentials IsNot Nothing AndAlso credentials.ContainsKey("livpass") Then
                            Dim storedPassword As String = credentials("livpass").Replace(Chr(0), "").Trim()

                            If storedPassword = InputPwd.Text Then
                                Dim banlistUrl As String = "http://vacko.cookie987.top:28987/VackoData/PlayerData/BanList.txt"
                                ' 获取远程文件中
                                Dim banlistFile As String = Await DownloadVak2File(banlistUrl)
                                If InStr(banlistFile, InputUser.Text) Then
                                    Return 8
                                End If
                                AntdUI.Message.success(Me, "登录成功",, 2)
                                Dim fileContent As String = Await DownloadVak2File(remoteUrl)
                                If fileContent IsNot Nothing Then
                                    Dim newFilePath As String = "version\" + StartVer + "\Game\Usdata\" + InputUser.Text + "\localdata.vak2" ' 本地保存的新文件路径
                                    Dim folderPath = "version\" + StartVer + "\Game\Usdata\" + InputUser.Text
                                    Try
                                        Directory.CreateDirectory(folderPath)
                                        Directory.Delete("version\" + StartVer + "\Game\Usdata\User", True)
                                    Catch ex As Exception

                                    End Try
                                    ' 将修改后的内容写入文件
                                    File.WriteAllText(newFilePath, fileContent)

                                    Dim rempasstimes = ReadVak2File("rempasstimes:", 4, fileContent)
                                    If rempasstimes = "none" Then
                                        rempasstimes = 1
                                    Else
                                        If rempasstimes > 1 Then
                                            rempasstimes += 1
                                        ElseIf rempasstimes < 1 Then
                                            rempasstimes = 1
                                        End If
                                    End If


                                    SaveVak2File("rempasstimes:", rempasstimes, 4, InputUser.Text, fileContent, StartVer)

                                    Dim filePath = "version\" + StartVer + "\Game\Appdata\opi.vak2"

                                    ' 读取文件内容
                                    fileContent = File.ReadAllText(filePath)

                                    ' 判断文件是否为空
                                    If fileContent.Length > 0 Then
                                        ' 将文件的第一位改为 '1'，其余保持不变
                                        fileContent = String.Concat("1", fileContent.AsSpan(1))
                                    Else
                                        ' 如果文件是空的，添加 '1'
                                        fileContent = "1"
                                    End If

                                    ' 写入修改后的内容
                                    File.WriteAllText(filePath, fileContent)

                                    filePath = "version\" + StartVer + "\Game\Usdata\" + "User"
                                Else
                                    AntdUI.Notification.error(Me, "登录失败", "下载文件失败",,, 0)
                                    Return 114
                                End If
                            Else
                                AntdUI.Notification.error(Me, "登录失败", "密码错误",,, 0)
                                Return 3
                            End If
                        Else
                            AntdUI.Notification.error(Me, "警告", "未找到密码字段",,, 0)
                            Return 4
                        End If
                    End If
                Else
                    AntdUI.Notification.warn(Me, "登录失败", "当前版本暂不支持HVKL内登录，已回退至Vacko内登录",,, 5)
                End If
            End If
        Catch ex As Exception
            AntdUI.Notification.error(Me, "启动错误 ", ex.Message,,, 0)
            Return 12
        End Try


        ' 写入 updater:hrd
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
            'AntdUI.Notification.success(Me, "启动成功", "" + CustomName,,, 5)
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

    Private Async Function GetRemoteCredentials(remoteUrl As String) As Task(Of Dictionary(Of String, String))
        Try
            Using client As New HttpClient()
                Dim response As HttpResponseMessage = Await client.GetAsync(remoteUrl)

                response.EnsureSuccessStatusCode()

                Dim fileContent As String = Await response.Content.ReadAsStringAsync()

                ' 解析键值对
                Dim credentials As New Dictionary(Of String, String)
                Dim keyValuePairs() As String = fileContent.Split(";"c)

                For Each pair As String In keyValuePairs
                    Dim keyValue() As String = pair.Split(":"c)
                    If keyValue.Length = 2 Then
                        credentials.Add(keyValue(0).Trim(), keyValue(1).Trim())
                    End If
                Next

                Return credentials
            End Using
        Catch ex As Exception
            AntdUI.Notification.error(Me, "登录失败", ex.Message,,, 0)
            Return Nothing
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

        Dim FileExists As Boolean
        FileExists = My.Computer.FileSystem.FileExists(ConfigFilePath)

        If FileExists = False Then
            HVKLVersion = My.Resources.Resource1.Version
            DeveloperMode = False
            UseCustomBackground = False
            LastStartVersion = Nothing
            LastUsedLoginMethod = Nothing
            CustomDownloadUrl = DefaultDownloadUrl
            TotalStartTimes = 0
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
                LastUsedLoginMethod = Nothing
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

            InputUser.Text = LastUsedUser
            InputPwd.Text = LastUsedPassword
            If InputPwd.Text IsNot "" Then
                Checkbox1.Checked = True
            End If
            If LastUsedLoginMethod = "HVKL" Then
                RadioHVKLLogin.Checked = True
                RadioVackoLogin.Checked = False
            ElseIf LastUsedLoginMethod = "Vacko" Then
                RadioVackoLogin.Checked = True
                RadioHVKLLogin.Checked = False
            End If

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

    Private Sub Select1_SelectedIndexChanged() Handles Select1.SelectedIndexChanged
        Select2.SelectedIndex = Select1.SelectedIndex
    End Sub

    Private Sub ToolsImage3d_Click(sender As Object, e As EventArgs) Handles ToolsImage3d.Click, LabelTools.Click, PanelTools.Click
        ToolForm.Show()
    End Sub

    Private Sub Input1_TextChanged(sender As Object, e As EventArgs) Handles InputUser.TextChanged
        GetConfig(Me)
        LastUsedUser = InputUser.Text
        SaveConfig(Me)
    End Sub

    Private Sub Checkbox1_CheckedChanged() Handles Checkbox1.CheckedChanged
        GetConfig(Me)
        If Checkbox1.Checked Then
            LastUsedPassword = InputPwd.Text
        Else
            LastUsedPassword = ""
        End If
        SaveConfig(Me)
    End Sub

    Private Sub InputPwd_TextChanged(sender As Object, e As EventArgs) Handles InputPwd.TextChanged
        GetConfig(Me)
        If Checkbox1.Checked Then
            LastUsedPassword = InputPwd.Text
            SaveConfig(Me)
        Else
            LastUsedPassword = ""
        End If
    End Sub

    Private Sub LoginFrameUpdate()
        GetConfig(Me)
        If RadioHVKLLogin.Checked = True Then
            LastUsedLoginMethod = "HVKL"
            Panel2.Visible = True
        End If
        If RadioVackoLogin.Checked = True Then
            LastUsedLoginMethod = "Vacko"
            Panel2.Visible = False
        End If
        SaveConfig(Me)
    End Sub

    Private Sub RadioVackoLogin_CheckedChanged() Handles RadioVackoLogin.CheckedChanged
        LoginFrameUpdate()
    End Sub

    Private Sub RadioHVKLLogin_CheckedChanged() Handles RadioHVKLLogin.CheckedChanged
        LoginFrameUpdate()
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        RegisterForm.Show()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim buttons = New AntdUI.FloatButton.Config(Me, New AntdUI.FloatButton.ConfigBtn() {
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
                       AntdUI.Message.loading(Me, "启动中", Async Sub(config)
                                                             Dim returnVal
                                                             returnVal = Await StartGame(Select2.SelectedValue)
                                                             If returnVal = 0 Then
                                                                 config.OK("启动成功")
                                                             ElseIf returnVal = 8 Then
                                                                 If HorribleBanUI = True Then
                                                                     BanForm.ShowDialog()
                                                                 Else
                                                                     config.Error("登录失败")
                                                                     AntdUI.Modal.open(New AntdUI.Modal.Config(Me, "错误", "您的账户已被 LeBan 封禁" + vbCrLf +
                                                                        "联系 Lemon Studio 以获得更多信息.", AntdUI.TType.Error))
                                                                 End If

                                                             Else
                                                                 config.Error("启动失败")

                                                             End If
                                                         End Sub)
                   Case "Refresh"
                       RefreshButton_Click()
                   Case "OpenVersionDir"
                       Dim relativePath As String = ".\version"
                       Dim folderPath As String = Path.GetFullPath(relativePath)
                       Process.Start("explorer.exe", folderPath)
               End Select
           End Sub)
        FloatButton.open(buttons)
        Timer1.Enabled = False
    End Sub
End Class