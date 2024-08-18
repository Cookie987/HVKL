Public Class SettingForm
    Public ClickTimes = 0
    Private Sub SettingForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label2.Text = My.Resources.Resource1.Version
        Dim configRead As Config = ReadConfig("config.json")
        If configRead.DeveloperMode = True Then
            Panel1.Visible = True
            If configRead.UseCustomBackground = True Then
                Switch1.Checked = True
            End If
        End If
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        ClickTimes += 1
        If ClickTimes = 8 Then
            Dim filePath = "config.json"
            Dim configToWrite As New Config With {
                .HVKLVersion = My.Resources.Resource1.Version,
                .DeveloperMode = True
                }
            WriteConfig(configToWrite, filePath)
        End If
    End Sub

    Private Sub Switch1_CheckedChanged(sender As Object, value As Boolean) Handles Switch1.CheckedChanged
        Dim filePath = "config.json"
        Dim configToWrite As New Config With {
            .HVKLVersion = My.Resources.Resource1.Version,
            .DeveloperMode = True,
            .UseCustomBackground = Switch1.Checked
            }
        WriteConfig(configToWrite, filePath)
    End Sub
End Class