Imports System.IO
Imports System.Net
Imports System.Security.Cryptography
Imports Newtonsoft.Json.Linq

Module DownloadModule
    Dim cachePath As String = "C:\GameCache\"  ' 缓存目录
    Dim targetPath As String = "C:\Vacko2\"    ' 目标游戏目录

    Sub Main()
        Dim jsonFile As String = "C:\game_version.json" ' JSON 文件路径
        DownloadGameFiles(jsonFile)
    End Sub

    Sub DownloadGameFiles(jsonPath As String)
        ' 读取 JSON 文件
        If Not File.Exists(jsonPath) Then
            Console.WriteLine("JSON 文件不存在: " & jsonPath)
            Exit Sub
        End If

        Dim jsonContent As String = File.ReadAllText(jsonPath)
        Dim jsonData As JArray = JArray.Parse(jsonContent)

        ' 确保目录存在
        Directory.CreateDirectory(cachePath)
        Directory.CreateDirectory(targetPath)

        For Each fileEntry In jsonData
            Dim fileName As String = fileEntry("file").ToString()
            Dim fileHash As String = fileEntry("hash").ToString()
            Dim fileUrl As String = fileEntry("url").ToString()

            Dim cachedFilePath As String = Path.Combine(cachePath, fileHash)
            Dim targetFilePath As String = Path.Combine(targetPath, fileName)

            ' **确保目标子目录存在**
            Dim targetDir As String = Path.GetDirectoryName(targetFilePath)
            If Not Directory.Exists(targetDir) Then
                Directory.CreateDirectory(targetDir)
            End If

            ' 检查缓存是否已存在相同哈希的文件
            If File.Exists(cachedFilePath) AndAlso VerifyFileHash(cachedFilePath, fileHash) Then
                Console.WriteLine("复用缓存: " & fileName)
            Else
                ' 下载文件
                Console.WriteLine("下载: " & fileName)
                If DownloadFile(fileUrl, cachedFilePath) Then
                    If Not VerifyFileHash(cachedFilePath, fileHash) Then
                        Console.WriteLine("文件哈希校验失败: " & fileName)
                        File.Delete(cachedFilePath) ' 删除损坏文件
                        Continue For
                    End If
                Else
                    Console.WriteLine("下载失败: " & fileName)
                    Continue For
                End If
            End If

            ' 复制到目标目录
            File.Copy(cachedFilePath, targetFilePath, True)
            Console.WriteLine("已更新: " & fileName)
        Next
    End Sub

    ' 下载文件
    Function DownloadFile(url As String, savePath As String) As Boolean
        Try
            Using client As New WebClient()
                client.DownloadFile(url, savePath)
            End Using
            Return True
        Catch ex As Exception
            Console.WriteLine("下载错误: " & ex.Message)
            Return False
        End Try
    End Function

    ' 校验文件哈希
    Function VerifyFileHash(filePath As String, expectedHash As String) As Boolean
        Try
            Using fs As FileStream = File.OpenRead(filePath)
                Dim sha256 As SHA256 = SHA256.Create()
                Dim hashBytes As Byte() = sha256.ComputeHash(fs)
                Dim hashString As String = BitConverter.ToString(hashBytes).Replace("-", "").ToLower()
                Return hashString = expectedHash.ToLower()
            End Using
        Catch ex As Exception
            Return False
        End Try
    End Function
End Module
