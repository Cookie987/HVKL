Imports System.Net.Http
Imports System.Threading

Public Class SettingForm
    Public ClickTimes = 0
    Private Sub SettingForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label2.Text = My.Resources.Resource1.Version
        StartTimesLabel.Text = "启动游戏次数：" + Str(TotalStartTimes)
        If DeveloperMode = True Then
            Panel1.Visible = True
            If UseCustomBackground = True Then
                Switch1.Checked = True
            End If
        End If
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        ClickTimes += 1
        If ClickTimes = 8 Then
            DeveloperMode = True
            SaveConfig(Me)
        End If
    End Sub

    Private Sub Switch1_CheckedChanged(sender As Object, value As Boolean) Handles Switch1.CheckedChanged
        UseCustomBackground = Switch1.Checked
        SaveConfig(Me)
    End Sub

    Private Sub ButtonCheckUpdate_Click(sender As Object, e As EventArgs) Handles ButtonCheckUpdate.Click
        Dim t As Thread
        t = New Thread(AddressOf Me.CheckUpdate)
        t.Start()
    End Sub

    Private Sub CheckUpdate()
        Dim cloudUrl As String = "https://987assests.s3.bitiful.net/vacko2/HVKLVer.txt"
        ' 初始化HttpClient
        Dim client As New HttpClient()
        Try
            Dim cloudVersion As String = client.GetStringAsync(cloudUrl).Result.Trim()
            If Not HVKLVersion = cloudVersion Then
                ' 获取更新日志
                Dim logUrl As String = "https://987assests.s3.bitiful.net/vacko2/updateLog/" + cloudVersion + ".txt"
                Dim updateLog As String = client.GetStringAsync(logUrl).Result
                AntdUI.Modal.open(New AntdUI.Modal.Config(Me, "有新版本可用：" + cloudVersion, "更新日志：" + vbCrLf + updateLog, AntdUI.TType.Info))
                ButtonCheckUpdate.Type = AntdUI.TTypeMini.Success
            Else
                AntdUI.Modal.open(New AntdUI.Modal.Config(Me, "检查更新", "当前版本已是最新版", AntdUI.TType.Info))
                ButtonCheckUpdate.Type = AntdUI.TTypeMini.Success
            End If
        Catch ex As Exception
            AntdUI.Message.error(Me, "检查更新错误：" + ex.Message)
            ButtonCheckUpdate.Type = AntdUI.TTypeMini.Error
        End Try
    End Sub
End Class