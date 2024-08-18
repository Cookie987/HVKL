Imports AntdUI.Svg

Public Class MainForm
    Private Sub ButtonStartGame_Click(sender As Object, e As EventArgs) Handles ButtonStartGame.Click

    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim FileExists As Boolean

        Dim filePath = "config.json"

        FileExists = My.Computer.FileSystem.FileExists(filePath)

        If FileExists = False Then
            Try
                Dim configToWrite As New Config With {
                .HVKLVersion = "1.0.0"
                }
                WriteConfig(configToWrite, filePath)
            Catch ex As Exception
                AntdUI.Notification.open(Me, "写入配置文件错误", ex.Message,,, 0)
            End Try
        Else
        End If
        Dim isDirExist = System.IO.Directory.Exists("version\")
        If isDirExist Then

        Else
            My.Computer.FileSystem.CreateDirectory("version\")
        End If

    End Sub
End Class
