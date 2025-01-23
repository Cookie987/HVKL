Imports System.IO
Imports System.IO.Compression
Imports System.Net.Http
Imports System.Threading
Imports AntdUI

Public Class MainForm
    Dim mutex As Mutex
    Private overlay As OverlayWindow ' 覆盖层窗体
    Private Async Function StartGame(StartVer As String) As Task(Of Integer)
        ' 定义父目录路径
        If StartVer = "" Then
            AntdUI.Notification.error(Me, "错误", "未选择启动版本",,, 5)
            Return 1
        End If
        Dim parentDirectory As String = Application.StartupPath + "version\" + StartVer
        Dim optionFilePath = Application.StartupPath + "version\" + StartVer + "\option.json"

        Try
            GetOption(Me, Select2.SelectedValue)
            UpdaterFilePath = Application.StartupPath + "version\" + StartVer + "\" + UpdaterFilePath
        Catch ex As Exception
            AntdUI.Notification.error(Me, "读取版本配置文件错误", ex.Message,,, 0)
            Return 1
        End Try

        If Family = "StarLake" Then
            ' StarLake架构
            Try
                ' 登录
                If RadioHVKLLogin.Checked = True Then
                    If SupportHVKLLogin = True Then
                        If InputUser.Text = "User" Or InputUser.Text = "nonelivaccno" Or InputPwd.Text = "nonelivpas" Then
                            AntdUI.Notification.error(Me, "用户名或密码不合法", "请更换",,, 0)
                            Return 1
                        Else
                            Dim remoteUrl As String = "http://vacko.cookie987.top:28987/VackoData/v1.2.7/PlayerData/" + LastUsedUser + "/localdata.vak2"

                            ' 获取远程文件中的键值对
                            Dim credentials As Dictionary(Of String, String) = Await GetRemoteCredentials(remoteUrl)

                            Dim value As String = Nothing

                            If credentials IsNot Nothing AndAlso credentials.TryGetValue("livpass", value) Then
                                Dim storedPassword As String = value.Replace(Chr(0), "").Trim()

                                If storedPassword = InputPwd.Text Then
                                    Dim banlistUrl As String = "http://vacko.cookie987.top:28987/VackoData/v1.2.7/PlayerData/BanList.txt"
                                    ' 获取远程文件中
                                    Dim banlistFile As String = Await DownloadVak2File(banlistUrl)
                                    If InStr(banlistFile, InputUser.Text) Then
                                        Return 8
                                    End If
                                    AntdUI.Message.success(Me, "登录成功",, 2)
                                    Dim fileContent As String = Await DownloadVak2File(remoteUrl)
                                    If fileContent IsNot Nothing Then
                                        Dim newFilePath As String = Application.StartupPath + "version\" + StartVer + "\Game\Data\User\" + InputUser.Text + "\localdata.vak2" ' 本地保存的新文件路径
                                        Dim folderPath = Application.StartupPath + "version\" + StartVer + "\Game\Data\User\" + InputUser.Text
                                        Try
                                            Directory.CreateDirectory(folderPath)
                                            Directory.Delete(Application.StartupPath + "version\" + StartVer + "\Game\Data\User\User", True)
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

                                        Dim filePath = Application.StartupPath + "version\" + StartVer + "\Game\Data\App\opi.vak2"

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

                                        filePath = Application.StartupPath + "version\" + StartVer + "\Game\Data\User\" + "User"
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
        ElseIf Family = "MoonBridge" Then
            ' MoonBridge架构
            Try
                ' 登录
                If RadioHVKLLogin.Checked = True Then
                    If SupportHVKLLogin = True Then
                        If InputUser.Text = "User" Or InputUser.Text = "nonelivaccno" Or InputPwd.Text = "nonelivpas" Then
                            AntdUI.Notification.error(Me, "用户名或密码不合法", "请更换",,, 0)
                            Return 1
                        Else
                            Dim remoteUrl As String = "http://vacko.cookie987.top:28987/VackoData/v1.2.7/PlayerData/" + LastUsedUser + "/localdata.vak2"

                            ' 获取远程文件中的键值对
                            Dim credentials As Dictionary(Of String, String) = Await GetRemoteCredentials(remoteUrl)

                            Dim value As String = Nothing

                            If credentials IsNot Nothing AndAlso credentials.TryGetValue("livpass", value) Then
                                Dim storedPassword As String = value.Replace(Chr(0), "").Trim()

                                If storedPassword = InputPwd.Text Then
                                    Dim banlistUrl As String = "http://vacko.cookie987.top:28987/VackoData/v1.2.7/PlayerData/BanList.txt"
                                    ' 获取远程文件中
                                    Dim banlistFile As String = Await DownloadVak2File(banlistUrl)
                                    If InStr(banlistFile, InputUser.Text) Then
                                        Return 8
                                    End If
                                    AntdUI.Message.success(Me, "登录成功",, 2)
                                    Dim fileContent As String = Await DownloadVak2File(remoteUrl)
                                    If fileContent IsNot Nothing Then
                                        Dim newFilePath As String = Application.StartupPath + "version\" + StartVer + "\Game\Usdata\" + InputUser.Text + "\localdata.vak2" ' 本地保存的新文件路径
                                        Dim folderPath = Application.StartupPath + "version\" + StartVer + "\Game\Usdata\" + InputUser.Text
                                        Try
                                            Directory.CreateDirectory(folderPath)
                                            Directory.Delete(Application.StartupPath + "version\" + StartVer + "\Game\Usdata\User", True)
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

                                        Dim filePath = Application.StartupPath + "version\" + StartVer + "\Game\Appdata\opi.vak2"

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

                                        filePath = Application.StartupPath + "version\" + StartVer + "\Game\Usdata\" + "User"
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
        ElseIf Family = vbEmpty Then
            ' 未定义架构
            AntdUI.Notification.error(Me, "错误", "未定义架构",,, 5)
            Return 1
        End If





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
        PageHeader1.Text += " v" + My.Resources.Resource1.Version

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
        Dim isDirExist = Directory.Exists(Application.StartupPath + "version\")
        If isDirExist Then
        Else
            My.Computer.FileSystem.CreateDirectory(Application.StartupPath + "version\")
        End If

        ' 设置窗口支持拖放
        Me.AllowDrop = True
        ' 初始化覆盖窗口，但初始不显示
        overlay = New OverlayWindow() With {
            .Visible = False,
            .Bounds = Me.Bounds ' 确保覆盖主窗口
        }
    End Sub

    Private Sub MainWindow_Move(sender As Object, e As EventArgs) Handles Me.Move
        If overlay IsNot Nothing Then
            overlay.Bounds = Me.Bounds
        End If
    End Sub

    Private Sub MainWindow_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If overlay IsNot Nothing Then
            overlay.Bounds = Me.Bounds
        End If
    End Sub

    Private Sub MainWindow_DragEnter(sender As Object, e As DragEventArgs) Handles Me.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim files = CType(e.Data.GetData(DataFormats.FileDrop), String())
            If files.Length = 1 AndAlso Path.GetExtension(files(0)).Equals(".hvklzip", StringComparison.CurrentCultureIgnoreCase) Then
                e.Effect = DragDropEffects.Copy
                overlay.Visible = True ' 显示覆盖层
            Else
                e.Effect = DragDropEffects.None
            End If
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub MainWindow_DragOver(sender As Object, e As DragEventArgs) Handles Me.DragOver
        ' 确保鼠标拖动时保持覆盖窗口显示
        If Not overlay.Visible Then
            overlay.Show()
        End If
    End Sub

    Private Sub MainWindow_DragLeave(sender As Object, e As EventArgs) Handles Me.DragLeave
        ' 只有在鼠标真正离开时才隐藏覆盖窗口
        If overlay.Visible Then
            overlay.Hide()
        End If
    End Sub

    ' 放下文件时触发
    Private Sub MainWindow_DragDrop(sender As Object, e As DragEventArgs) Handles Me.DragDrop
        overlay.Visible = False

        Dim files = CType(e.Data.GetData(DataFormats.FileDrop), String())
        If files.Length = 1 AndAlso Path.GetExtension(files(0)).Equals(".hvklzip", StringComparison.CurrentCultureIgnoreCase) Then
            Dim zipFilePath = files(0)

            AntdUI.Modal.open(New AntdUI.Modal.Config(Me, "提示", "是否导入整合包？" + vbCrLf + "整合包将会导入到" + Path.Combine(Application.StartupPath, "version", Path.GetFileNameWithoutExtension(zipFilePath)), AntdUI.TType.Info) With {
                .OkText = "导入",
                .OkType = TTypeMini.Primary,
                .OnOk = Function(config)
                            Try
                                ' 指定解压路径
                                Dim targetDir As String = Path.Combine(Application.StartupPath, "version", Path.GetFileNameWithoutExtension(zipFilePath))
                                ' 如果目录不存在，则创建
                                If Not Directory.Exists(targetDir) Then
                                    Directory.CreateDirectory(targetDir)
                                End If
                                ' 解压 ZIP 文件
                                ZipFile.ExtractToDirectory(zipFilePath, targetDir)
                                ' 显示成功消息
                                AntdUI.Notification.success(Me, "导入整合包", "整合包 " + Path.GetFileNameWithoutExtension(zipFilePath) + " 已成功导入",,, 5)
                                Return True
                            Catch ex As Exception
                                ' 错误处理
                                AntdUI.Notification.error(Me, "导入整合包错误", ex.Message,,, 0)
                                Return True
                            End Try
                        End Function
                })
        Else
        End If
    End Sub

    Private Sub VersionListPanel_Click(sender As Object, e As EventArgs) Handles DownloadVersionPanel.Click, DownloadVersionLabel.Click, DownloadVersionImage.Click
        VersionForm.ShowDialog()
        VersionForm.Dispose()
    End Sub

    Private Sub ManageVersionImage3d_Click(sender As Object, e As EventArgs) Handles ManageVersionImage3d.Click, ManageVersionLabel.Click, ManageVersionPanel.Click
        ManageForm.ShowDialog()
        ManageForm.Dispose()
    End Sub

    Private Sub SettingImage3d_Click(sender As Object, e As EventArgs) Handles SettingImage3d.Click, SettingLabel.Click, MainSettingPanel.Click
        SettingForm.ShowDialog()
        SettingForm.Dispose()
    End Sub

    Private Sub Select1_Click(sender As Object, e As EventArgs) Handles Select1.Click
        RefreshVersion()
    End Sub

    Public Sub RefreshButton_Click()
        AntdUI.Message.loading(Me, "获取版本中", Sub(config)
                                                ' 指定要列出子文件夹的路径
                                                Dim folderPath As String = Application.StartupPath + "\version"
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
        ToolForm.ShowDialog()
        ToolForm.Dispose()
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
        RegisterForm.ShowDialog()
        RegisterForm.Dispose()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        Timer1.Enabled = False

        ' 导入整合包
        ' 获取命令行参数
        Dim args As String() = Environment.GetCommandLineArgs()

        ' 检查是否传入文件路径
        If args.Length > 1 Then
            Dim zipFilePath As String = args(1) ' 第一个参数是拖入的文件路径

            ' 检查文件扩展名是否为 .hvklzip
            If Path.GetExtension(zipFilePath).Equals(".hvklzip", StringComparison.CurrentCultureIgnoreCase) Then
                AntdUI.Modal.open(New AntdUI.Modal.Config(Me, "提示", "是否导入整合包？" + vbCrLf + "整合包将会导入到" + Path.Combine(Application.StartupPath, "version", Path.GetFileNameWithoutExtension(zipFilePath)), AntdUI.TType.Info) With {
                .OkText = "导入",
                .OkType = TTypeMini.Primary,
                .OnOk = Function(config)
                            Try
                                ' 指定解压路径
                                Dim targetDir As String = Path.Combine(Application.StartupPath, "version", Path.GetFileNameWithoutExtension(zipFilePath))
                                ' 如果目录不存在，则创建
                                If Not Directory.Exists(targetDir) Then
                                    Directory.CreateDirectory(targetDir)
                                End If
                                ' 解压 ZIP 文件
                                ZipFile.ExtractToDirectory(zipFilePath, targetDir)
                                ' 显示成功消息
                                AntdUI.Notification.success(Me, "导入整合包", "整合包 " + Path.GetFileNameWithoutExtension(zipFilePath) + " 已成功导入",,, 5)
                                Return True
                            Catch ex As Exception
                                ' 错误处理
                                AntdUI.Notification.error(Me, "导入整合包错误", ex.Message,,, 0)
                                Return True
                            End Try
                        End Function
                })
            Else
            End If
        Else
        End If

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
                       Dim relativePath As String = Application.StartupPath + "\version"
                       Dim folderPath As String = Path.GetFullPath(relativePath)
                       Process.Start("explorer.exe", folderPath)
               End Select
           End Sub)
        FloatButton.open(buttons)
    End Sub
End Class