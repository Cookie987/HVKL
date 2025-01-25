Imports System.ComponentModel
Imports System.IO
Imports System.Text.RegularExpressions

Public Class MusicForm
    Private mp3Files As List(Of String)
    Private lrcDictionary As New Dictionary(Of Double, String) ' 存储时间戳和歌词
    Private WithEvents Timer As New Timer() ' 用于定时同步歌词
    Private currentLyric As String = "" ' 当前歌词
    Private nextLyric As String = "" ' 下一句歌词
    Private isScrolling As Boolean = False ' 是否正在滚动歌词
    ' 偏移量，正值表示歌词比音频慢，负值表示歌词比音频快
    Private lrcOffset As Double = 0 ' 根据你的情况调整这个值

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
        mp3Files = New List(Of String)()
        AddHandler AxWindowsMediaPlayer2.PlayStateChange, AddressOf AxWindowsMediaPlayer2_PlayStateChange
        Try
            LoadMp3Files(Application.StartupPath + "version\" + ManageForm.Select2.SelectedValue + "\Config\Cache")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub AxWindowsMediaPlayer2_PlayStateChange(sender As Object, e As AxWMPLib._WMPOCXEvents_PlayStateChangeEvent)
        ' 检查是否在播放状态
        If e.newState = 3 Then ' 播放中
            Dim currentUrl = AxWindowsMediaPlayer2.currentMedia.sourceURL

            ' 查找当前播放文件的索引
            Dim index = mp3Files.FindIndex(Function(f) f.Equals(currentUrl, StringComparison.OrdinalIgnoreCase))

            ' 更新 ComboBox 的选中项
            If index >= 0 Then
                cmbMp3Files.SelectedIndex = index
            End If
        End If
    End Sub

    Private Sub LoadMp3Files(directoryPath As String)
        If Directory.Exists(directoryPath) Then
            Dim files = Directory.GetFiles(directoryPath, "*.mp3")
            For Each file In files
                mp3Files.Add(file)
                cmbMp3Files.Items.Add(Path.GetFileNameWithoutExtension(file))
                AxWindowsMediaPlayer2.currentPlaylist.appendItem(AxWindowsMediaPlayer2.newMedia(file))
            Next
        Else
            AntdUI.Message.error(Me, "音乐目录不存在",, 5)
        End If
    End Sub

    Private Sub CmbMp3Files_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMp3Files.SelectedIndexChanged
        If cmbMp3Files.SelectedIndex >= 0 AndAlso cmbMp3Files.SelectedIndex < mp3Files.Count Then
            Dim selectedFile = mp3Files(cmbMp3Files.SelectedIndex)
            AxWindowsMediaPlayer2.URL = selectedFile
            Dim lrcFilePath = Application.StartupPath + "version\" + ManageForm.Select2.SelectedValue + "\Config\Cache\" + cmbMp3Files.SelectedValue + ".lrc"
            lrcDictionary.Clear()
            If File.Exists(lrcFilePath) Then
                LoadLrcFile(lrcFilePath)
            Else
                LoadLyricsFromMp3(selectedFile)
            End If
            Timer.Interval = 1
            Timer.Start()
        End If
    End Sub

    Private Sub Timer_Tick(sender As Object, e As EventArgs) Handles Timer.Tick
        Try
            If AxWindowsMediaPlayer2.playState = WMPLib.WMPPlayState.wmppsPlaying Then
                ' 获取当前播放时间并应用偏移量
                Dim currentPosition = AxWindowsMediaPlayer2.Ctlcontrols.currentPosition + lrcOffset
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
                    End If
                    If Label2.Text <> nextLyric Then
                        Label2.Text = nextLyric
                    End If
                    currentLyric = closestLyric
                    nextLyric = upcomingLyric

                Else
                    'ScrollLyric(currentLyric, nextLyric)
                End If
            End If
        Catch ex As Exception
            ' 忽略异常
        End Try
    End Sub

    Private Sub ScrollLyric(current As String, [next] As String)
        If isScrolling Then Return
        isScrolling = True

        Dim originalY = Label1.Top
        Dim animationSpeed = 3
        Label1.Text = current

        ' 设置下一句歌词
        Label2.Text = [next]
        Label2.Top = Label1.Bottom

        Dim animationTimer As New Timer() With {.Interval = 10}
        AddHandler animationTimer.Tick, Sub()
                                            Label1.Top -= animationSpeed
                                            Label2.Top -= animationSpeed

                                            If Label2.Top <= originalY Then
                                                animationTimer.Stop()
                                                Label1.Top = originalY
                                                Label1.Text = [next]
                                                Label2.Top = Label1.Bottom
                                                Label2.Text = ""
                                                isScrolling = False
                                            End If
                                        End Sub
        animationTimer.Start()
    End Sub

    Private Sub MusicForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Timer.Stop()
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
End Class
