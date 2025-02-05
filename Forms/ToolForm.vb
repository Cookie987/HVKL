Imports System.Net.Http
Imports System.Text.RegularExpressions

Public Class ToolForm
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        AntdUI.Message.loading(Me, "检查中", Async Sub(config)
                                              Dim websiteUrl = "http://"+remoteHost+":"+remotePort+"/VackoData/v1.3/PlayerData/"
                                              Dim directoryNameToCheck = Input1.Text.Trim
                                              ' 创建 HttpClient 进行 HTTP 请求
                                              Using httpClient As New HttpClient
                                                  Try
                                                      ' 异步下载目录列表为字符串
                                                      Dim directoryListing = Await httpClient.GetStringAsync(websiteUrl)
                                                      ' 提取目录名称（假设列表为简单的 HTML 格式）
                                                      Dim directories = ExtractDirectories(directoryListing)
                                                      ' 检查目录名称是否存在
                                                      If directories.Contains(directoryNameToCheck) Then
                                                          config.Warn("名称已被占用")
                                                      Else
                                                          config.OK("名称未占用")
                                                      End If
                                                  Catch ex As Exception
                                                      config.Error("检查失败：" + ex.Message)
                                                  End Try
                                              End Using
                                          End Sub)

    End Sub

    Private Shared Function ExtractDirectories(htmlContent As String) As List(Of String)
        Dim directories As New List(Of String)()

        ' 简单的提取逻辑（可能需要根据实际 HTML 结构进行调整）
        Dim lines As String() = htmlContent.Split(New String() {Environment.NewLine}, StringSplitOptions.None)

        For Each line As String In lines
            If line.Contains("href=") AndAlso line.Contains("/"c) Then
                Dim startIndex As Integer = line.IndexOf("href=") + 6
                Dim endIndex As Integer = line.IndexOf("/"c, startIndex)
                Dim directoryName As String = line.Substring(startIndex, endIndex - startIndex)
                directories.Add(directoryName)
            End If
        Next

        Return directories
    End Function

    Private Shared Async Function GetFileContentAsync(url As String) As Task(Of String)
        Using client As New HttpClient()
            Return Await client.GetStringAsync(url)
        End Using
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim email As String = Input2.Text
        If IsValidEmail(email) Then
            AntdUI.Message.loading(Me, "检查中", Async Sub(config)
                                                  Dim url As String = "http://"+remoteHost+":"+remotePort+"/VackoData/v1.3/PlayerData/PlayerEmi.txt"
                                                  Dim searchString As String = Input2.Text
                                                  Try
                                                      Dim fileContent As String = Await GetFileContentAsync(url)
                                                      If fileContent.Contains(searchString) Then
                                                          config.Warn("邮箱已被占用")
                                                      Else
                                                          config.OK("邮箱未占用")
                                                      End If
                                                  Catch ex As Exception
                                                      config.Error("检查失败：" + ex.Message)
                                                  End Try
                                              End Sub)
        Else
            AntdUI.Message.warn(Me, "邮箱地址无效",, 2)
        End If
    End Sub

    Private Shared Function IsValidEmail(email As String) As Boolean
        Dim pattern As String = "^[^@\s]+@[^@\s]+\.[^@\s]+$"
        Dim regex As New Regex(pattern)
        Return regex.IsMatch(email)
    End Function
End Class