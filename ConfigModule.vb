Imports System.IO
Imports Newtonsoft.Json

Module ConfigModule

    ' 定义配置类
    Public Class Config
        Public Property HVKLVersion As String
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

    Sub Main()
        '    Dim filePath As String = "config.json"

        '    ' 创建配置实例并写入文件
        '    Dim configToWrite As New Config With {
        '    .Setting1 = "Value1",
        '    .Setting2 = 100,
        '    .Setting3 = True
        '}
        '    WriteConfig(configToWrite, filePath)

        '    ' 从文件读取配置
        '    Dim configRead As Config = ReadConfig(filePath)
        '    Console.WriteLine("读取的配置: ")
        '    Console.WriteLine("Setting1: " & configRead.Setting1)
        '    Console.WriteLine("Setting2: " & configRead.Setting2)
        '    Console.WriteLine("Setting3: " & configRead.Setting3)
    End Sub



End Module
