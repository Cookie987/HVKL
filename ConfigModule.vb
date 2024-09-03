Imports System.IO
Imports System.Net.Http
Imports Newtonsoft.Json

Module ConfigModule
    Public OriginalVersion
    Public OriginalDir
    Public DefaultDownloadUrl = "https://mirror.ghproxy.com/https://raw.githubusercontent.com/Cookie987/Cookie987.github.io.assets/main/vacko2/version/Vacko"

    Public HVKLVersion
    Public DeveloperMode
    Public UseCustomBackground
    Public LastStartVersion
    Public TotalStartTimes
    Public CustomDownloadUrl
    Public ConfigFilePath = "config.json"

    ' 定义配置类
    Public Class Config
        Public Property HVKLVersion As String
        Public Property CustomDownloadUrl As String
        Public Property DeveloperMode As Boolean
        Public Property DeveloperOptions As DevelopOption
        Public Class DevelopOption
            Public Property UseCustomBackground As Boolean
        End Class
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

    Public Function GetConfig(form)
        Try
            Dim configRead As Config = ReadConfig(ConfigFilePath)
            HVKLVersion = configRead.HVKLVersion
            DeveloperMode = configRead.DeveloperMode
            UseCustomBackground = configRead.DeveloperOptions.UseCustomBackground
            LastStartVersion = configRead.LastStartVersion
            TotalStartTimes = configRead.TotalStartTimes
            CustomDownloadUrl = configRead.CustomDownloadUrl
        Catch ex As Exception
            AntdUI.Notification.error(form, "读取配置文件错误", ex.Message,,, 0)
        End Try
        Return 0
    End Function

    Public Function SaveConfig(form)
        Dim configToWrite As New Config With {
                .HVKLVersion = HVKLVersion,
                .CustomDownloadUrl = CustomDownloadUrl,
                .DeveloperMode = DeveloperMode,
                .DeveloperOptions = New Config.DevelopOption With {
                    .UseCustomBackground = UseCustomBackground
                },
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


    Public Class VersionOption
        Public Property VackoVersion As String
        Public Property StartArgs As StartArg
        Public Class StartArg
            Public Property UpdaterFilePath As String
            Public Property UpdaterFileContent As String
            Public Property SubDirectory As String
            Public Property Args As String
            Public Property MutexName As String
            Public Property ExeName As String
        End Class
        Public Property Custom As CustomOption
        Public Class CustomOption
            Public Property Name As String
        End Class
        Public Property LastStartTime As String
    End Class

    Public VackoVersion
    Public UpdaterFilePath
    Public UpdaterFileContent
    Public SubDirectory
    Public Args
    Public ExeName
    Public CustomName
    Public LastStartTime
    Public MutexName

    ' 写入配置到JSON文件的函数
    Public Sub WriteOption(ByVal VersionOption As VersionOption, ByVal optionPath As String)
        Dim json As String = JsonConvert.SerializeObject(VersionOption, Formatting.Indented)
        File.WriteAllText(optionPath, json)
        Console.WriteLine("配置已保存到 " & optionPath)
    End Sub

    ' 从JSON文件读取配置的函数
    Public Function ReadOption(ByVal optionPath As String) As VersionOption
        If Not File.Exists(optionPath) Then
            Throw New FileNotFoundException("配置文件未找到: " & optionPath)
        End If
        Dim json As String = File.ReadAllText(optionPath)
        Return JsonConvert.DeserializeObject(Of VersionOption)(json)
    End Function

    Public Function GetOption(form, folderName)
        Dim httpClient As New HttpClient()
        Try
            Dim optionRead As VersionOption = ReadOption("version\" + folderName + "\option.json")
            VackoVersion = optionRead.VackoVersion
            UpdaterFilePath = optionRead.StartArgs.UpdaterFilePath
            UpdaterFileContent = optionRead.StartArgs.UpdaterFileContent
            SubDirectory = optionRead.StartArgs.SubDirectory
            Args = optionRead.StartArgs.Args
            MutexName = optionRead.StartArgs.MutexName
            ExeName = optionRead.StartArgs.ExeName
            LastStartTime = optionRead.LastStartTime
            CustomName = optionRead.Custom.Name
        Catch ex As Exception
            AntdUI.Message.error(form, "读取配置文件错误：" + ex.Message,, 0)
        End Try
        Return 0
    End Function

    Public Function SaveOption(form, folderName)
        Dim optionToWrite As New VersionOption With {
                .VackoVersion = VackoVersion,
                .StartArgs = New VersionOption.StartArg With {
                    .Args = Args,
                    .MutexName = MutexName,
                    .ExeName = ExeName,
                    .SubDirectory = SubDirectory,
                    .UpdaterFileContent = UpdaterFileContent,
                    .UpdaterFilePath = UpdaterFilePath
                },
                .Custom = New VersionOption.CustomOption With {
                    .Name = CustomName
                },
                .LastStartTime = LastStartTime
                }
        Try
            WriteOption(optionToWrite, "version\" + folderName + "\option.json")
            AntdUI.Message.success(form, "保存版本配置成功",, 2)
        Catch ex As Exception
            AntdUI.Notification.error(form, "写入配置文件错误", ex.Message,,, 0)
            Return ex.Message
        End Try
        Return 0
    End Function
End Module