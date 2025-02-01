Imports System.ComponentModel
Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Net.Http
Imports LibVLCSharp.Shared
Imports AntdUI
Imports Microsoft.Web.WebView2.Core
Imports Microsoft.Win32
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Net
Imports System.Security.Policy

Public Class MusicForm
    Private isProcessing As Boolean = False
    Private mp3Files As List(Of String)
    Private lrcDictionary As New Dictionary(Of Double, String) ' 存储时间戳和歌词
    Private currentLyric As String = "" ' 当前歌词
    Private nextLyric As String = "" ' 下一句歌词
    ' 偏移量，正值表示歌词比音频慢，负值表示歌词比音频快
    Private lrcOffset As Double = 0 ' 根据你的情况调整这个值
    Dim libVLC As LibVLC
    Dim vlcMediaPlayer As MediaPlayer
    Private currentSelectItem As TreeItem
    Dim subtitleText As String
    ' 定义一个标志变量，用来判断是否是手动拖动
    Private isDragging As Boolean = False
    Dim vlcMediaList As MediaList

    Dim defaultHtml = "
            <!DOCTYPE html>
        <html lang=""en"">
        <head>
            <meta charset=""UTF-8"">
            <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
            <title>Subtitle Animation</title>
            <style>
                body {
                    background-color: white;
                    margin: 0;
                    display: flex;
                    justify-content: center;
                    align-items: center;
                    height: 100vh;
                    overflow: hidden;
                }
                #subtitle {
                    font-size: 20px;
                    color: black;
                    text-shadow: 2px 2px 10px rgba(255,255,255,0.8);
                    text-align: center;
                    line-height: 1.5;
                    width: 80%;
                    opacity: 1;
                    transform: translateY(0);
                }
                @keyframes fadeOut {
                    from {
                        opacity: 1;
                        transform: translateY(0);
                    }
                    to {
                        opacity: 0;
                        transform: translateY(20px);
                    }
                }
                @keyframes fadeIn {
                    from {
                        opacity: 0;
                        transform: translateY(20px);
                    }
                    to {
                        opacity: 1;
                        transform: translateY(0);
                    }
                }
                .fadeOut {
                    animation: fadeOut 0.5s forwards;
                }
                .fadeIn {
                    animation: fadeIn 0.5s forwards;
                }
            </style>
        </head>
        <body>
            <div id='subtitle'>(歌词)</div>
            <script>
                function updateSubtitle(text) {
                    let subtitle = document.getElementById('subtitle');

                    // 先淡出旧字幕
                    subtitle.classList.add('fadeOut');
                    subtitle.classList.remove('fadeIn');

                    // 等待动画完成
                    setTimeout(() => {
                        // 更新字幕内容
                        subtitle.innerHTML = text.replace(/\n/g, '<br>');

                        // 淡入新字幕
                        subtitle.classList.remove('fadeOut');
                        subtitle.classList.add('fadeIn');
                    }, 100); // 500ms后替换字幕并淡入
                }
            </script>
        </body>
        </html>
        "

    Private Sub LoadLrcFile(lrcFilePath As String)
        Dim lines = File.ReadAllLines(lrcFilePath)
        ' 支持 [mm:ss] 或 [mm:ss.ms] 的正则
        Dim lrcRegex As New Regex("\[(\d+):(\d+)(?:\.(\d+))?\](.*)")

        For Each line In lines
            Dim match = lrcRegex.Match(line)
            If match.Success Then
                Dim minutes = Integer.Parse(match.Groups(1).Value)
                Dim seconds = Integer.Parse(match.Groups(2).Value)
                Dim milliseconds = If(match.Groups(3).Success, Integer.Parse(match.Groups(3).Value), 0)

                ' 转换为秒的时间戳
                Dim timestamp = minutes * 60 + seconds + milliseconds / 1000.0
                Dim lyric = match.Groups(4).Value.Trim()

                ' 如果时间戳已存在，则用换行符合并歌词
                If lrcDictionary.ContainsKey(timestamp) Then
                    lrcDictionary(timestamp) &= vbCrLf & lyric
                Else
                    lrcDictionary(timestamp) = lyric
                End If
            End If
        Next
    End Sub

    Private Sub MusicForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer3.Enabled = False
        Core.Initialize()
        libVLC = New LibVLC("--verbose=2")

        vlcMediaPlayer = New MediaPlayer(libVLC)

        mp3Files = New List(Of String)()
        ResetStyle()
        WebView21.Source = New Uri("data:text/html," & Uri.EscapeDataString(defaultHtml))
        WebView21.DefaultBackgroundColor = Color.White
        VideoView1.MediaPlayer = vlcMediaPlayer
        Dim filePath = Application.StartupPath + "version\" + ManageForm.Select2.SelectedValue + "\Game\Data\AppData.json"
        Try
            Dim likeSongs As String() = GetLikeArray("path_to_your_file.json")

            ' 输出字符串数组
            For Each song In likeSongs
                Console.WriteLine(song)
            Next
        Catch ex As Exception

        End Try

        Try
            LoadMp3Files(Application.StartupPath + "version\" + ManageForm.Select2.SelectedValue + "\Config\Cache")
        Catch ex As Exception
            AntdUI.Message.error(Me, "无法加载歌曲：" + ex.Message,, 2)
        End Try
        GetConfig(Me)
        Select1.SelectedIndex = MusicPlayMode
        VolSlider.Value = MusicVolume
        vlcMediaPlayer.Volume = MusicVolume
        vlcMediaPlayer.Mute = MusicMute
        TopMost = MusicFormTopMost
        Checkbox1.Checked = MusicFormTopMost
        Try
            Tree1.SelectItem = Tree1.Items(MusicCurrentMusicId - 1)
            PlayMusic(False)
            MsgBox(MusicCurrentMusicProgress)
            vlcMediaPlayer.SeekTo(MusicCurrentMusicProgress)
        Catch ex As Exception
        End Try
        BtnPlayPause.IconSvg = "<svg xmlns=""http://www.w3.org/2000/svg"" viewBox=""0 0 24 24""><title>play-outline</title><path d=""M8.5,8.64L13.77,12L8.5,15.36V8.64M6.5,5V19L17.5,12"" /></svg>"
        Dim installedVersion As String = ""
        If IsKLiteInstalled(installedVersion) Then
            'MessageBox.Show($"检测到 K-Lite Codec Pack 已安装 (版本: {installedVersion})")
        Else
            AntdUI.Modal.open(New AntdUI.Modal.Config(Me, "警告", "Vacko 仍使用老旧的媒体控制接口进行媒体播放，无法播放 HVKL 下载的带歌词音乐，因此需安装 K-Lite Codec 以解决此问题。" + vbCrLf + vbCrLf +
                "点击““下载并安装””将自动从其官网下载并安装 K-Lite Codec (~35MB)", AntdUI.TType.Warn) With {
            .OkText = "下载并安装",
            .OkType = TTypeMini.Primary,
            .OnOk = Function(config)
                        Dim downloadUrl As String = "https://files2.codecguide.com/K-Lite_Codec_Pack_1875_Standard.exe" ' 你的下载链接
                        Dim savePath As String = Path.Combine(Path.GetTempPath(), "K-Lite-Standard.exe") ' 下载到临时目录
                        Dim arguments As String = "/verysilent /norestart /nofileassociations" ' 传递的参数
                        Try
                            ' 阻塞当前线程，执行下载和安装
                            Task.Run(Sub()
                                         ' 下载文件
                                         Using httpClient As New HttpClient()
                                             Console.WriteLine("正在下载: " & downloadUrl)
                                             Dim fileBytes As Byte() = httpClient.GetByteArrayAsync(downloadUrl).Result
                                             File.WriteAllBytes(savePath, fileBytes)
                                             Console.WriteLine("下载完成: " & savePath)
                                         End Using

                                         ' 启动安装程序并阻塞
                                         Dim process As New Process()
                                         process.StartInfo.FileName = savePath
                                         process.StartInfo.Arguments = arguments
                                         process.Start()
                                         Console.WriteLine("已启动: " & savePath & " 参数: " & arguments)
                                         process.WaitForExit() ' 阻塞直到安装完成
                                         Console.WriteLine("安装完成")
                                     End Sub).Wait() ' 阻塞主线程，直到 Task 完成
                        Catch ex As Exception
                            AntdUI.Notification.error(Me, "下载或安装失败", ex.Message,,, 0)
                        End Try
                        Return True
                    End Function
            })
        End If
        SelectSpeed.SelectedIndex = 1
        Timer3.Enabled = True
    End Sub

    Shared Function GetLikeArray(filePath As String) As String()
        Dim json As String = System.IO.File.ReadAllText(filePath)
        Dim obj As JObject = JObject.Parse(json)

        Dim likeArray As JArray = obj("MusicSettings")("Like")
        Dim result As New List(Of String)

        For Each item As JArray In likeArray
            Dim bytes As Byte() = item.Select(Function(e) CByte(e.ToObject(Of Integer))).ToArray()
            result.Add(System.Text.Encoding.UTF8.GetString(bytes))
        Next

        Return result.ToArray()
    End Function

    Private Sub ResetStyle（）
        Label1.Shadow = 5
        Label1.ShadowOffsetX = 2
        Label1.ShadowOffsetY = 2
        Label1.ShadowOpacity = 0.2
        Label1.ShadowColor = Color.Black
        Label1.Font = New Font("Microsoft YaHei UI", 12, FontStyle.Regular, GraphicsUnit.Point, 134)
        Label1.ForeColor = Color.Black
    End Sub

    Public Shared Function IsKLiteInstalled(ByRef version As String) As Boolean
        Dim softwareNameKeywords As String = "K-Lite"
        Dim registryPaths As String() = {
        "SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall",
        "SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall"
    }

        For Each registryPath In registryPaths
            Using key As RegistryKey = Registry.LocalMachine.OpenSubKey(registryPath)
                If key IsNot Nothing Then
                    For Each subKeyName As String In key.GetSubKeyNames()
                        Using subKey As RegistryKey = key.OpenSubKey(subKeyName)
                            Dim displayName As Object = subKey.GetValue("DisplayName")
                            If displayName IsNot Nothing AndAlso
                           displayName.ToString().Contains(softwareNameKeywords, StringComparison.OrdinalIgnoreCase) Then
                                version = If(subKey.GetValue("DisplayVersion")?.ToString(), "未知版本")
                                Return True
                            End If
                        End Using
                    Next
                End If
            End Using
        Next

        version = String.Empty
        Return False
    End Function

    Public Sub ApplyCssToLabel(cssContent As String)
        Try
            ' 创建正则表达式模式，用于提取CSS中的各个属性
            Dim colorPattern As String = "color:\s*(#[0-9A-Fa-f]{6})"
            Dim shadowPattern As String = "Shandow:\s*(\d+);"
            Dim shadowColorPattern As String = "ShandowColor:\s*(#[0-9A-Fa-f]{6})"
            Dim shadowOffsetXPattern As String = "ShandowOffsetX:\s*(-?\d+)"
            Dim shadowOffsetYPattern As String = "ShandowOffsetY:\s*(-?\d+)"
            Dim shadowOpacityPattern As String = "ShandowOpacity:\s*([\d\.]+)"
            Dim fontFamilyPattern As String = "font-family:\s*""(.*?)"";"
            Dim fontSizePattern As String = "font-size:\s*(\d+)"
            Dim fontStylePattern As String = "font-style:\s*(\w+)"
            Dim fontWeightPattern As String = "font-weight:\s*(\w+)"

            ' 提取各个属性
            Dim colorMatch = Regex.Match(cssContent, colorPattern)
            Dim shadowMatch = Regex.Match(cssContent, shadowPattern)
            Dim shadowColorMatch = Regex.Match(cssContent, shadowColorPattern)
            Dim shadowOffsetXMatch = Regex.Match(cssContent, shadowOffsetXPattern)
            Dim shadowOffsetYMatch = Regex.Match(cssContent, shadowOffsetYPattern)
            Dim shadowOpacityMatch = Regex.Match(cssContent, shadowOpacityPattern)
            Dim fontFamilyMatch = Regex.Match(cssContent, fontFamilyPattern)
            Dim fontSizeMatch = Regex.Match(cssContent, fontSizePattern)
            Dim fontStyleMatch = Regex.Match(cssContent, fontStylePattern)
            Dim fontWeightMatch = Regex.Match(cssContent, fontWeightPattern)

            ' 解析并应用属性
            If colorMatch.Success Then
                ' 设置Text颜色
                Label1.ForeColor = ColorTranslator.FromHtml(colorMatch.Groups(1).Value)
            End If

            If shadowMatch.Success Then
                ' 设置Shadow效果
                Label1.Shadow = Integer.Parse(shadowMatch.Groups(1).Value)
            End If

            If shadowColorMatch.Success Then
                ' 设置阴影颜色
                Label1.ShadowColor = ColorTranslator.FromHtml(shadowColorMatch.Groups(1).Value)
            End If

            If shadowOffsetXMatch.Success Then
                ' 设置阴影偏移量X
                Label1.ShadowOffsetX = Integer.Parse(shadowOffsetXMatch.Groups(1).Value)
            End If

            If shadowOffsetYMatch.Success Then
                ' 设置阴影偏移量Y
                Label1.ShadowOffsetY = Integer.Parse(shadowOffsetYMatch.Groups(1).Value)
            End If

            If shadowOpacityMatch.Success Then
                ' 设置阴影透明度
                Label1.ShadowOpacity = Single.Parse(shadowOpacityMatch.Groups(1).Value)
            End If

            If fontFamilyMatch.Success Then
                ' 设置字体
                Label1.Font = New Font(fontFamilyMatch.Groups(1).Value, 12, FontStyle.Regular, GraphicsUnit.Point)
            End If

            If fontSizeMatch.Success Then
                ' 设置字体大小
                Label1.Font = New Font(Label1.Font.FontFamily, Integer.Parse(fontSizeMatch.Groups(1).Value), Label1.Font.Style)
            End If

            If fontStyleMatch.Success Then
                ' 设置字体样式（例如 normal 或 italic）
                If fontStyleMatch.Groups(1).Value.Equals("italic", StringComparison.CurrentCultureIgnoreCase) Then
                    Label1.Font = New Font(Label1.Font.FontFamily, Label1.Font.Size, FontStyle.Italic, GraphicsUnit.Point)
                End If
            End If

            If fontWeightMatch.Success Then
                ' 设置字体粗细（例如 bold）
                If fontWeightMatch.Groups(1).Value.Equals("bold", StringComparison.CurrentCultureIgnoreCase) Then
                    Label1.Font = New Font(Label1.Font.FontFamily, Label1.Font.Size, FontStyle.Bold, GraphicsUnit.Point)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Shared Async Function GetCssFileAsync(url As String) As Task(Of String)
        Try
            Using client As New HttpClient()
                Dim cssContent As String = Await client.GetStringAsync(url)
                Return cssContent
            End Using
        Catch ex As Exception
            Throw
        End Try
    End Function

    Private Sub LoadMp3Files(directoryPath As String)
        If Directory.Exists(directoryPath) Then
            Dim audioExtensions As String() = {"*.mp3", "*.wav", "*.flac", "*.aac", "*.m4a", "*.ogg", "*.wma"}
            Dim files As New List(Of String)()

            For Each ext As String In audioExtensions
                files.AddRange(Directory.GetFiles(directoryPath, ext))
            Next
            Tree1.Items.Clear()
            Dim i = 0
            For Each file In files
                mp3Files.Add(file)
                i += 1
                Dim Item As New AntdUI.TreeItem With {
                .Text = Path.GetFileName(file),
                .ID = i
                }
                Tree1.Items.Add(Item)
            Next
        Else
            AntdUI.Message.error(Me, "音乐目录不存在",, 5)
        End If
    End Sub

    Private Async Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            If vlcMediaPlayer.IsPlaying Then
                ' 获取当前播放时间并应用偏移量
                Dim currentPosition = vlcMediaPlayer.Time / 1000 + lrcOffset
                Dim upcomingLyric = ""
                ' 找到与当前时间最近的歌词
                Dim closestTimestamp As Double = -1
                Dim closestLyric As String = ""

                For Each timestamp In lrcDictionary.Keys
                    If currentPosition >= timestamp Then
                        closestTimestamp = timestamp
                        closestLyric = lrcDictionary(timestamp)
                    Else
                        nextLyric = lrcDictionary(timestamp)
                        Exit For
                    End If
                Next

                ' 如果找到新的歌词，更新标签

                If closestLyric <> currentLyric Then
                    If Label1.Text <> closestLyric Then
                        Label1.Text = closestLyric
                        subtitleText = Replace(closestLyric, vbCrLf, "<br>")
                        Await WebView21.ExecuteScriptAsync($"updateSubtitle(`{subtitleText}`);")
                    End If
                    currentLyric = closestLyric
                    nextLyric = upcomingLyric
                Else
                End If
            End If
        Catch ex As Exception
            ' 忽略异常
        End Try
    End Sub

    Private Sub MusicForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Timer1.Stop()
        vlcMediaPlayer.Stop()
        If Not ManageForm.IsDisposed Then
            ManageForm.Button5.Enabled = False
        End If
        If Not MusicDownloadForm.IsDisposed Then
            MusicDownloadForm.Dispose()
        End If
    End Sub

    Private Sub LoadLyricsFromMp3(mp3FilePath As String)
        Try
            Dim file = TagLib.File.Create(mp3FilePath) ' 使用 TagLibSharp 加载 MP3 文件
            Dim embeddedLyrics As String = file.Tag.Lyrics

            If String.IsNullOrEmpty(embeddedLyrics) Then
                AntdUI.Message.warn(Me, "本歌曲暂无歌词",, 2)
                Return
            End If

            ' 将嵌入歌词处理为时间戳格式
            Dim lines = embeddedLyrics.Split({vbCrLf, vbLf}, StringSplitOptions.RemoveEmptyEntries)
            ' 支持 [mm:ss] 或 [mm:ss.ms] 的正则
            Dim lrcRegex As New Regex("\[(\d+):(\d+)(?:\.(\d+))?\](.*)")

            For Each line In lines
                Dim match = lrcRegex.Match(line)
                If match.Success Then
                    Dim minutes = Integer.Parse(match.Groups(1).Value)
                    Dim seconds = Integer.Parse(match.Groups(2).Value)
                    Dim milliseconds = If(match.Groups(3).Success, Integer.Parse(match.Groups(3).Value), 0)

                    ' 转换为秒的时间戳
                    Dim timestamp = minutes * 60 + seconds + milliseconds / 1000.0
                    Dim lyric = match.Groups(4).Value.Trim()

                    ' 如果时间戳已存在，则用换行符合并歌词
                    If lrcDictionary.ContainsKey(timestamp) Then
                        lrcDictionary(timestamp) &= vbCrLf & lyric
                    Else
                        lrcDictionary(timestamp) = lyric
                    End If
                End If
            Next
        Catch ex As Exception
            AntdUI.Message.error(Me, "无法读取歌词：" + ex.Message,, 2)
        End Try
    End Sub

    Private Async Sub LoadMp3Cover(mp3Path As String, pictureBox As AntdUI.Image3D)
        Try
            ' 使用 TagLib 加载 MP3 文件
            Dim tagFile As TagLib.File = TagLib.File.Create(mp3Path)
            ' 检查是否包含封面图像
            If tagFile.Tag.Pictures IsNot Nothing AndAlso tagFile.Tag.Pictures.Length > 0 Then
                Dim pictureData As Byte() = tagFile.Tag.Pictures(0).Data.Data

                ' 将封面图像数据转换为 Image 对象
                Using ms As New IO.MemoryStream(pictureData)
                    pictureBox.Image = Image.FromStream(ms)
                End Using
                Image3d1.Visible = True
            Else
                ' 如果没有封面，设置为默认图片或清空
                pictureBox.Image = Nothing
                Image3d1.Visible = False
            End If
        Catch ex As Exception
            Image3d1.Visible = False
            AntdUI.Message.error(Me, "无法加载封面：" + ex.Message,, 2)
        End Try
        Try
            Dim cssContent As String = Await GetCssFileAsync("http://vacko.cookie987.top:28987/HVKLData/v1/MusicHtml/" + Path.GetFileNameWithoutExtension(mp3Path) + ".html")
            WebView21.Source = New Uri("data:text/html," & Uri.EscapeDataString(cssContent))
        Catch ex As Exception
            WebView21.Source = New Uri("data:text/html," & Uri.EscapeDataString(defaultHtml))
        End Try


        'ApplyCssToLabel(cssContent)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        mp3Files.Clear()
        Tree1.Items.Clear()

        Try
            LoadMp3Files(Application.StartupPath + "version\" + ManageForm.Select2.SelectedValue + "\Config\Cache")
        Catch ex As Exception
            AntdUI.Message.error(Me, "无法加载歌曲：" + ex.Message,, 2)
        End Try


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MusicDownloadForm.Show()
    End Sub

    Private Sub Select1_SelectedValueChanged() Handles Select1.SelectedValueChanged
        ' 保存播放模式
        GetConfig(Me)
        MusicPlayMode = Select1.SelectedIndex
        SaveConfig(Me)
    End Sub

    Private Sub PlayMusic(autoPlay As Boolean)
        ' 加载歌词和封面
        currentSelectItem = Tree1.SelectItem
        Dim fullPath = mp3Files(Tree1.SelectItem.ID - 1)
        Dim lrcFilePath = Application.StartupPath + "version\" + ManageForm.Select2.SelectedValue + "\Config\Cache\" + Tree1.SelectItem.ToString + ".lrc"
        lrcDictionary.Clear()

        If File.Exists(lrcFilePath) Then
            LoadLrcFile(lrcFilePath)
        Else
            LoadLyricsFromMp3(fullPath)
        End If
        ResetStyle()

        Try
            LoadMp3Cover(fullPath, Image3d1)
        Catch ex As Exception
            ResetStyle()
        End Try

        ' 启动定时器同步歌词
        Timer1.Interval = 1
        Timer1.Start()

        ' 防止递归调用
        If isProcessing Then Exit Sub
        isProcessing = True
        vlcMediaPlayer.Media = New Media(libVLC, fullPath, FromType.FromPath)
        If autoPlay Then
            vlcMediaPlayer.Play()
        Else
            vlcMediaPlayer.Pause()
        End If
        BtnPlayPause.IconSvg = "<svg xmlns=""http://www.w3.org/2000/svg"" viewBox=""0 0 24 24""><title>pause-outline</title><path d=""M14,19H18V5H14M6,19H10V5H6V19Z"" /></svg>"
        isProcessing = False
    End Sub

    Private Sub Tree1_SelectedIndexChanged() Handles Tree1.SelectChanged
        PlayMusic(True)
    End Sub

    Private Sub VolSlider_Scroll(sender As Object, e As EventArgs) Handles VolSlider.ValueChanged
        If vlcMediaPlayer IsNot Nothing Then
            vlcMediaPlayer.Volume = VolSlider.Value
            If VolSlider.Value < 33 Then
                Button3.IconSvg = "<svg xmlns=""http://www.w3.org/2000/svg"" viewBox=""0 0 24 24""><title>volume-low</title><path d=""M7,9V15H11L16,20V4L11,9H7Z""/></svg>"
            ElseIf VolSlider.Value < 66 Then
                Button3.IconSvg = "<svg xmlns=""http://www.w3.org/2000/svg"" viewBox=""0 0 24 24""><title>volume-medium</title><path d=""M5,9V15H9L14,20V4L9,9M18.5,12C18.5,10.23 17.5,8.71 16,7.97V16C17.5,15.29 18.5,13.76 18.5,12Z""/></svg>"
            Else
                Button3.IconSvg = "<svg xmlns=""http://www.w3.org/2000/svg"" viewBox=""0 0 24 24""><title>volume-high</title><path d=""M14,3.23V5.29C16.89,6.15 19,8.83 19,12C19,15.17 16.89,17.84 14,18.7V20.77C18,19.86 21,16.28 21,12C21,7.72 18,4.14 14,3.23M16.5,12C16.5,10.23 15.5,8.71 14,7.97V16C15.5,15.29 16.5,13.76 16.5,12M3,9V15H7L12,20V4L7,9H3Z""/></svg>"
            End If
        Else
            ' Handle the case where vlcMediaPlayer is null
        End If
    End Sub
    ' 当用户手动拖动进度条时触发
    Private Sub Slider1_ValueChanged(sender As Object, e As IntEventArgs) Handles Slider1.ValueChanged
        If isDragging AndAlso vlcMediaPlayer.Length > 0 Then
            ' 只有在用户拖动时，才更新播放器的播放位置
            Dim newPosition As Single = CSng(Slider1.Value / Slider1.MaxValue)
            vlcMediaPlayer.Position = newPosition
        End If
    End Sub

    ' 当定时器触发时更新进度条
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If Not isDragging AndAlso vlcMediaPlayer.Length > 0 Then
            ' 仅在未拖动进度条时更新其位置
            Dim newPosition = vlcMediaPlayer.Position * Slider1.MaxValue
            Slider1.Value = CInt(newPosition)
            LblProgress.Text = TimeSpan.FromMilliseconds(vlcMediaPlayer.Time).ToString("mm\:ss") & "/" & TimeSpan.FromMilliseconds(vlcMediaPlayer.Length).ToString("mm\:ss")
        End If
        VolSlider.Value = vlcMediaPlayer.Volume
        If vlcMediaPlayer.Mute Then
            Button3.Type = TTypeMini.Error
            Button3.IconSvg = "<svg xmlns=""http://www.w3.org/2000/svg"" viewBox=""0 0 24 24""><title>volume-off</title><path d=""M12,4L9.91,6.09L12,8.18M4.27,3L3,4.27L7.73,9H3V15H7L12,20V13.27L16.25,17.53C15.58,18.04 14.83,18.46 14,18.7V20.77C15.38,20.45 16.63,19.82 17.68,18.96L19.73,21L21,19.73L12,10.73M19,12C19,12.94 18.8,13.82 18.46,14.64L19.97,16.15C20.62,14.91 21,13.5 21,12C21,7.72 18,4.14 14,3.23V5.29C16.89,6.15 19,8.83 19,12M16.5,12C16.5,10.23 15.5,8.71 14,7.97V10.18L16.45,12.63C16.5,12.43 16.5,12.21 16.5,12Z"" /></svg>"
        Else
            Button3.Type = TTypeMini.Primary
            If VolSlider.Value < 33 Then
                Button3.IconSvg = "<svg xmlns=""http://www.w3.org/2000/svg"" viewBox=""0 0 24 24""><title>volume-low</title><path d=""M7,9V15H11L16,20V4L11,9H7Z""/></svg>"
            ElseIf VolSlider.Value < 66 Then
                Button3.IconSvg = "<svg xmlns=""http://www.w3.org/2000/svg"" viewBox=""0 0 24 24""><title>volume-medium</title><path d=""M5,9V15H9L14,20V4L9,9M18.5,12C18.5,10.23 17.5,8.71 16,7.97V16C17.5,15.29 18.5,13.76 18.5,12Z""/></svg>"
            Else
                Button3.IconSvg = "<svg xmlns=""http://www.w3.org/2000/svg"" viewBox=""0 0 24 24""><title>volume-high</title><path d=""M14,3.23V5.29C16.89,6.15 19,8.83 19,12C19,15.17 16.89,17.84 14,18.7V20.77C18,19.86 21,16.28 21,12C21,7.72 18,4.14 14,3.23M16.5,12C16.5,10.23 15.5,8.71 14,7.97V16C15.5,15.29 16.5,13.76 16.5,12M3,9V15H7L12,20V4L7,9H3Z""/></svg>"
            End If
        End If
    End Sub

    ' 在用户开始拖动时设置标志
    Private Sub Slider1_MouseDown(sender As Object, e As MouseEventArgs) Handles Slider1.MouseDown
        isDragging = True
    End Sub

    ' 在用户停止拖动时清除标志
    Private Sub Slider1_MouseUp(sender As Object, e As MouseEventArgs) Handles Slider1.MouseUp
        isDragging = False
        ' 在用户松开时，手动更新播放器位置（确保同步）
        If vlcMediaPlayer.Length > 0 Then
            Dim newPosition As Single = CSng(Slider1.Value / Slider1.MaxValue)
            vlcMediaPlayer.Position = newPosition
        End If
    End Sub

    Private Sub BtnPlayPause_Click(sender As Object, e As EventArgs) Handles BtnPlayPause.Click
        If vlcMediaPlayer.IsPlaying = True Then
            vlcMediaPlayer.Pause()
            BtnPlayPause.IconSvg = "<svg xmlns=""http://www.w3.org/2000/svg"" viewBox=""0 0 24 24""><title>play-outline</title><path d=""M8.5,8.64L13.77,12L8.5,15.36V8.64M6.5,5V19L17.5,12"" /></svg>"
        Else
            vlcMediaPlayer.Play()
            vlcMediaPlayer.SeekTo(MusicCurrentMusicProgress)
            BtnPlayPause.IconSvg = "<svg xmlns=""http://www.w3.org/2000/svg"" viewBox=""0 0 24 24""><title>pause-outline</title><path d=""M14,19H18V5H14M6,19H10V5H6V19Z"" /></svg>"
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If vlcMediaPlayer.Mute = True Then
            vlcMediaPlayer.Mute = False
            Button3.Type = TTypeMini.Primary
            If VolSlider.Value < 33 Then
                Button3.IconSvg = "<svg xmlns=""http://www.w3.org/2000/svg"" viewBox=""0 0 24 24""><title>volume-low</title><path d=""M7,9V15H11L16,20V4L11,9H7Z""/></svg>"
            ElseIf VolSlider.Value < 66 Then
                Button3.IconSvg = "<svg xmlns=""http://www.w3.org/2000/svg"" viewBox=""0 0 24 24""><title>volume-medium</title><path d=""M5,9V15H9L14,20V4L9,9M18.5,12C18.5,10.23 17.5,8.71 16,7.97V16C17.5,15.29 18.5,13.76 18.5,12Z""/></svg>"
            Else
                Button3.IconSvg = "<svg xmlns=""http://www.w3.org/2000/svg"" viewBox=""0 0 24 24""><title>volume-high</title><path d=""M14,3.23V5.29C16.89,6.15 19,8.83 19,12C19,15.17 16.89,17.84 14,18.7V20.77C18,19.86 21,16.28 21,12C21,7.72 18,4.14 14,3.23M16.5,12C16.5,10.23 15.5,8.71 14,7.97V16C15.5,15.29 16.5,13.76 16.5,12M3,9V15H7L12,20V4L7,9H3Z""/></svg>"
            End If

        Else
            vlcMediaPlayer.Mute = True
            Button3.Type = TTypeMini.Error
            Button3.IconSvg = "<svg xmlns=""http://www.w3.org/2000/svg"" viewBox=""0 0 24 24""><title>volume-off</title><path d=""M12,4L9.91,6.09L12,8.18M4.27,3L3,4.27L7.73,9H3V15H7L12,20V13.27L16.25,17.53C15.58,18.04 14.83,18.46 14,18.7V20.77C15.38,20.45 16.63,19.82 17.68,18.96L19.73,21L21,19.73L12,10.73M19,12C19,12.94 18.8,13.82 18.46,14.64L19.97,16.15C20.62,14.91 21,13.5 21,12C21,7.72 18,4.14 14,3.23V5.29C16.89,6.15 19,8.83 19,12M16.5,12C16.5,10.23 15.5,8.71 14,7.97V10.18L16.45,12.63C16.5,12.43 16.5,12.21 16.5,12Z"" /></svg>"
        End If
    End Sub

    Private Sub BtnStop_Click(sender As Object, e As EventArgs) Handles BtnStop.Click
        vlcMediaPlayer.Stop()
        BtnPlayPause.IconSvg = "<svg xmlns=""http://www.w3.org/2000/svg"" viewBox=""0 0 24 24""><title>play-outline</title><path d=""M8.5,8.64L13.77,12L8.5,15.36V8.64M6.5,5V19L17.5,12"" /></svg>"
    End Sub

    Private Sub BtnPrevious_Click(sender As Object, e As EventArgs) Handles BtnPrevious.Click
        ' 播放上一首歌曲
        If currentSelectItem IsNot Nothing AndAlso currentSelectItem.ID > 1 Then
            Try
                Tree1.SelectItem = Tree1.Items(currentSelectItem.ID - 2)
                PlayMusic(True)
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub BtnNext_Click(sender As Object, e As EventArgs) Handles BtnNext.Click
        ' 播放下一首歌曲
        If currentSelectItem IsNot Nothing AndAlso currentSelectItem.ID <= Tree1.Items.LongCount Then
            Try
                Tree1.SelectItem = Tree1.Items(currentSelectItem.ID)
                PlayMusic(True)
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        GetConfig(Me)
        If vlcMediaPlayer.State = VLCState.Ended Then
            BtnPlayPause.IconSvg = "<svg xmlns=""http://www.w3.org/2000/svg"" viewBox=""0 0 24 24""><title>play-outline</title><path d=""M8.5,8.64L13.77,12L8.5,15.36V8.64M6.5,5V19L17.5,12"" /></svg>"
            If Select1.SelectedIndex = 0 Then
                Tree1.SelectItem = Tree1.Items(currentSelectItem.ID - 1)
                PlayMusic(True)
            ElseIf Select1.SelectedIndex = 1 Then
                If currentSelectItem.ID < Tree1.Items.Count Then
                    Tree1.SelectItem = Tree1.Items(currentSelectItem.ID)
                    PlayMusic(True)
                Else
                    Try
                        Tree1.SelectItem = Tree1.Items(0)
                        PlayMusic(True)
                    Catch ex As Exception

                    End Try
                End If
            ElseIf Select1.SelectedIndex = 2 Then
                Dim rand As New Random
                Dim nextIndex = rand.Next(0, Tree1.Items.Count)
                Tree1.SelectItem = Tree1.Items(nextIndex)
                PlayMusic(True)
            End If
        ElseIf vlcMediaPlayer.State = VLCState.Playing Then
            Try
                MusicCurrentMusicProgress = TimeSpan.FromMilliseconds(vlcMediaPlayer.Time)
                Label2.Text = vlcMediaPlayer.Media.Meta(MetadataType.Title) + " - " +
                              vlcMediaPlayer.Media.Meta(MetadataType.Artist) + " - " +
                              vlcMediaPlayer.Media.Meta(MetadataType.Album)
                '获取比特率等编码信息
            Catch ex As Exception
                Label2.Text = "未知"
            End Try

        End If
        If currentSelectItem IsNot Nothing Then
            MusicCurrentMusicId = currentSelectItem.ID
        End If
        MusicVolume = VolSlider.Value
        MusicMute = vlcMediaPlayer.Mute
        SaveConfig(Me)
    End Sub

    Private Sub Checkbox1_CheckedChanged(sender As Object, e As BoolEventArgs) Handles Checkbox1.CheckedChanged
        If Checkbox1.Checked Then
            TopMost = True
            GetConfig(Me)
            MusicFormTopMost = True
            SaveConfig(Me)
        Else
            TopMost = False
            GetConfig(Me)
            MusicFormTopMost = False
            SaveConfig(Me)
        End If
    End Sub

    Private Sub SelectSpeed_SelectedIndexChanged(sender As Object, e As IntEventArgs) Handles SelectSpeed.SelectedIndexChanged
        Try
            ' 设置播放速度
            Dim selectedSpeed As Double = 1.0
            Select Case SelectSpeed.SelectedIndex
                Case 0
                    selectedSpeed = 0.5 ' 0.5x
                Case 1
                    selectedSpeed = 1.0 ' 1x
                Case 2
                    selectedSpeed = 1.5 ' 1.5x
                Case 3
                    selectedSpeed = 2.0 ' 2x
            End Select
            vlcMediaPlayer.SetRate(selectedSpeed)
        Catch ex As Exception
            AntdUI.Message.error(Me, "无法设置播放速度：" + ex.Message,, 2)
        End Try
    End Sub
End Class
