Imports System.IO
Imports Newtonsoft.Json

Module ConfigModule
    Public HVKLVersion
    Public DeveloperMode
    Public UseCustomBackground
    Public LastStartVersion
    Public TotalStartTimes
    Public ConfigFilePath = "config.json"

    ' 定义配置类
    Public Class Config
        Public Property HVKLVersion As String
        Public Property DeveloperMode As Boolean
        Public Property UseCustomBackground As Boolean
        Public Property LastStartVersion As String
        Public Property TotalStartTimes As Long
    End Class

    ' 写入配置到JSON文件的函数
    Public Sub WriteConfig(ByVal config As Config, ByVal filePath As String)
        Dim json As String = JsonConvert.SerializeObject(config, Formatting.Indented)
        File.WriteAllText(filePath, json)
        Console.WriteLine("配置已保存到 " & filePath)
    End Sub

    ' 从JSON文件读取配置的函数
    Public Function ReadConfig(ByVal filePath As String) As Config
        If Not File.Exists(filePath) Then
            Throw New FileNotFoundException("配置文件未找到: " & filePath)
        End If

        Dim json As String = File.ReadAllText(filePath)
        Return JsonConvert.DeserializeObject(Of Config)(json)
    End Function

    Public Function SaveConfig(form)
        Dim configToWrite As New Config With {
                .HVKLVersion = HVKLVersion,
                .DeveloperMode = DeveloperMode,
                .UseCustomBackground = UseCustomBackground,
                .LastStartVersion = LastStartVersion,
                .TotalStartTimes = TotalStartTimes
                }
        Try
            WriteConfig(configToWrite, "config.json")
        Catch ex As Exception
            AntdUI.Notification.error(form, "写入配置文件错误", ex.Message,,, 0)
            Return ex.Message
        End Try
        Return 0
    End Function
End Module
