Imports System.Net.Http
Imports System.Text.RegularExpressions
Imports System.Text
Imports Newtonsoft.Json.Linq
Imports System.Net.Http.Headers
Imports System.IO
Imports Renci.SshNet

Public Class RegisterForm
    Dim verifyCode = secretOption
    Dim time = 60
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim email As String = InputEmail.Text
        If IsValidEmail(email) Then
            Timer1.Enabled = True
            AntdUI.Message.loading(Me, "检查中", Async Sub(config)
                                                  Dim url As String = "http://vacko.cookie987.top:28987/VackoData/v1.2.7/PlayerData/PlayerEmi.txt"
                                                  Dim searchString As String = email
                                                  Try
                                                      Dim fileContent As String = Await GetFileContentAsync(url)
                                                      If fileContent.Contains(searchString) Then
                                                          config.Error("邮箱已被占用")
                                                      Else
                                                          ' 生成验证码 
                                                          Dim random As New Random()
                                                          verifyCode = random.Next(0, 1000000).ToString("D6") ' 保证是6位数字
                                                          Dim a = Await GetFileContentAsync("https://987assests.s3.bitiful.net/vacko2/template.html")
                                                          Dim Body As String = a _
                                                            .Replace("{{HEADER_LINK}}", "https://cookie987.top") _
                                                            .Replace("{{HEADER_LINK_TEXT}}", "RedCookieStudios - HVKL") _
                                                            .Replace("{{HEADLINE}}", "您的 Vacko 2 验证码") _
                                                            .Replace("{{BODY}}", $"{verifyCode}")
                                                          Dim newString As String = Body.Replace("-----", verifyCode)
                                                          Dim accessToken = GetAccessTokenAsync().Result
                                                          SendEmailAsync(accessToken, InputEmail.Text, newString, verifyCode, "vacko@cookie987.top").Wait()
                                                          config.OK("发送验证码成功")
                                                      End If
                                                  Catch ex As Exception
                                                      config.Error("检查失败：" + ex.Message)
                                                  End Try
                                              End Sub,, 10)
        Else
            AntdUI.Message.error(Me, "邮箱地址无效",, 2)
        End If
    End Sub

    Private Shared Function IsValidEmail(email As String) As Boolean
        Dim pattern As String = "^[^@\s]+@[^@\s]+\.[^@\s]+$"
        Dim regex As New Regex(pattern)
        Return regex.IsMatch(email)
    End Function

    Private Shared Async Function GetFileContentAsync(url As String) As Task(Of String)
        Using client As New HttpClient()
            Return Await client.GetStringAsync(url)
        End Using
    End Function

    Public Shared Async Function GetAccessTokenAsync() As Task(Of String)
        Dim client As New HttpClient()
        Dim requestBody = New Dictionary(Of String, String) From {
            {"grant_type", "client_credentials"},
            {"client_id", ClientId},
            {"client_secret", ClientSecret},
            {"scope", "https://graph.microsoft.com/.default"}
        }

        Dim content = New FormUrlEncodedContent(requestBody)
        Dim response = Await client.PostAsync($"https://login.microsoftonline.com/{TenantId}/oauth2/v2.0/token", content)
        response.EnsureSuccessStatusCode()

        Dim responseBody = Await response.Content.ReadAsStringAsync()
        Dim json = JObject.Parse(responseBody)
        Return json("access_token").ToString()
    End Function

    Private Const apiEndpoint As String = "https://graph.microsoft.com/v1.0"
    Dim success = 0

    Public Shared Async Function SendEmailAsync(accessToken As String, mail As String, body As String, code As String, userEmailAddress As String) As Task
        Dim client As New HttpClient()
        client.DefaultRequestHeaders.Authorization = New AuthenticationHeaderValue("Bearer", accessToken)

        Dim email = New JObject(
            New JProperty("message", New JObject(
                New JProperty("subject", "您的Vacko2验证码：" + code),
                New JProperty("body", New JObject(
                    New JProperty("contentType", "HTML"),
                    New JProperty("content", body)
                )),
                New JProperty("toRecipients", New JArray(
                    New JObject(
                        New JProperty("emailAddress", New JObject(
                            New JProperty("address", mail)
                        ))
                    )
                ))
            )),
            New JProperty("saveToSentItems", "true")
        )

        Dim content = New StringContent(email.ToString(), Encoding.UTF8, "application/json")
        Dim response = Await client.PostAsync($"{apiEndpoint}/users/{userEmailAddress}/sendMail", content)
        response.EnsureSuccessStatusCode()
    End Function

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        time -= 1
        If time = 0 Then
            Button1.Enabled = True
            Timer1.Enabled = False
            time = 60
            Button1.Text = "发送验证码"
        Else
            Button1.Enabled = False
            Button1.Text = "发送验证码 (" + Str(time) + " )"
        End If
    End Sub

    Private Sub ButtonReg_Click(sender As Object, e As EventArgs) Handles ButtonReg.Click
        If success = 1 Then
            Me.Close()
        Else
            AntdUI.Message.loading(Me, "注册中", Async Sub(config)
                                                  Try
                                                      If InputCode.Text = verifyCode Then
                                                          If Not (InputPwd.Text = "" Or ContainsSymbol(InputPwd.Text) Or InputUser.Text = "" Or InputUser.Text = "User" Or InputUser.Text = "nonelivaccno" Or InputPwd.Text = "nonelivpas") Then
                                                              Dim websiteUrl = "http://vacko.cookie987.top:28987/VackoData/v1.3/PlayerData/"
                                                              Dim directoryNameToCheck = InputUser.Text.Trim
                                                              ' 创建 HttpClient 进行 HTTP 请求
                                                              Using httpClient As New HttpClient
                                                                  Try
                                                                      ' 异步下载目录列表为字符串
                                                                      Dim directoryListing = Await httpClient.GetStringAsync(websiteUrl)
                                                                      ' 提取目录名称（假设列表为简单的 HTML 格式）
                                                                      Dim directories = ExtractDirectories(directoryListing)
                                                                      ' 检查目录名称是否存在
                                                                      If directories.Contains(directoryNameToCheck) Then
                                                                          config.Error("名称已被占用")
                                                                      Else
                                                                          Dim playerUid = "987987987"
                                                                          Dim LatestUid = Await GetFileContentAsync("http://vacko.cookie987.top:28987/VackoData/v1.3/" + "CreUid.txt")
                                                                          Dim PlayerEmi = Await GetFileContentAsync(websiteUrl + "PlayerEmi.txt")
                                                                          Dim NameList = Await GetFileContentAsync(websiteUrl + "NameList.txt")
                                                                          playerUid = LatestUid
                                                                          Dim jsonFile = "
                                                                            {
                                                                            ""AccountInfo"": {
                                                                                ""Password"": """",
                                                                                ""PwdAttemptsLeft"": """",
                                                                                ""Uid"": """",
                                                                                ""User"": """"
                                                                                }
                                                                            }"
                                                                          Dim jsonSettings = "
                                                                            {
                                                                              ""Settings"": {
                                                                                ""Convenience_1"": false,
                                                                                ""Convenience_2"": false,
                                                                                ""Personalized_1_First"": ""0"",
                                                                                ""Personalized_1_Second"": ""0"",
                                                                                ""Personalized_1_SystemColor"": ""00"",
                                                                                ""Personalized_2_Sys"": ""0"",
                                                                                ""Personalized_2_Sysin"": ""0"",
                                                                                ""Personalized_2_Pcs"": ""0""
                                                                              },
                                                                              ""MusicSettings"": {
                                                                                ""Music_Cache_Number"": ""0000"",
                                                                                ""Music_Cache_Time"": ""000"",
                                                                                ""Music_Cache_Status"": ""0"",
                                                                                ""Music_Cache_Speed"": ""1.0x"",
                                                                                ""Volume"": 50,
                                                                                ""PlayMode"": ""0"",
                                                                                ""Like"": [

                                                                                ],
                                                                                ""Cache"": [

                                                                                ]
                                                                              }
                                                                            }"
                                                                          Dim obj As JObject = JObject.Parse(jsonFile)
                                                                          obj("AccountInfo")("Password") = InputPwd.Text
                                                                          obj("AccountInfo")("PwdAttemptsLeft") = 0
                                                                          obj("AccountInfo")("Uid") = playerUid
                                                                          obj("AccountInfo")("User") = InputUser.Text
                                                                          PlayerEmi += InputEmail.Text + vbLf
                                                                          NameList += InputUser.Text + ";" + vbLf
                                                                          Dim tempFilePath As String = Path.GetTempFileName()
                                                                          Dim tempFilePath2 As String = Path.GetTempFileName()
                                                                          Dim tempFilePath3 As String = Path.GetTempFileName()
                                                                          Dim tempFilePath4 As String = Path.GetTempFileName()
                                                                          Dim tempFilePath5 As String = Path.GetTempFileName()
                                                                          Dim tempFilePath6 As String = Path.GetTempFileName()
                                                                          File.WriteAllText(tempFilePath, obj.ToString)
                                                                          File.WriteAllText(tempFilePath2, Str(LatestUid + 1).Trim)
                                                                          File.WriteAllText(tempFilePath3, PlayerEmi)
                                                                          File.WriteAllText(tempFilePath4, NameList)
                                                                          File.WriteAllText(tempFilePath5, "")
                                                                          File.WriteAllText(tempFilePath6, jsonSettings)
                                                                          ' 使用 SFTP 上传文件
                                                                          Using sftp As New SftpClient(remoteHost, remotePort, sftpUser, sftpPassword)
                                                                              Try
                                                                                  ' 连接到远程服务器
                                                                                  sftp.Connect()
                                                                                  If Not sftp.Exists(remoteFilePath + InputUser.Text) Then
                                                                                      CreateRemoteDirectory(sftp, remoteFilePath + InputUser.Text)
                                                                                  End If
                                                                                  ' 打开临时文件进行上传
                                                                                  Using fileStream As New FileStream(tempFilePath, FileMode.Open)
                                                                                      sftp.UploadFile(fileStream, remoteFilePath + "/Player/" + InputUser.Text + "-Data.json")
                                                                                  End Using
                                                                                  Using fileStream As New FileStream(tempFilePath2, FileMode.Open)
                                                                                      sftp.UploadFile(fileStream, remoteFilePath2 + "CreUid.txt")
                                                                                  End Using
                                                                                  Using fileStream As New FileStream(tempFilePath3, FileMode.Open)
                                                                                      sftp.UploadFile(fileStream, remoteFilePath + "PlayerEmi.txt")
                                                                                  End Using
                                                                                  Using fileStream As New FileStream(tempFilePath4, FileMode.Open)
                                                                                      sftp.UploadFile(fileStream, remoteFilePath + "NameList.txt")
                                                                                  End Using
                                                                                  Using fileStream As New FileStream(tempFilePath5, FileMode.Open)
                                                                                      sftp.UploadFile(fileStream, remoteFilePath + "PlayerFriends/" + InputUser.Text + ".txt")
                                                                                  End Using
                                                                                  Using fileStream As New FileStream(tempFilePath6, FileMode.Open)
                                                                                      sftp.UploadFile(fileStream, remoteFilePath + "/Settings/" + InputUser.Text + "-AppData.json")
                                                                                  End Using
                                                                                  ' 确保连接断开
                                                                                  If sftp.IsConnected Then
                                                                                      sftp.Disconnect()
                                                                                  End If
                                                                              Catch ex As Exception
                                                                                  ' 确保连接断开
                                                                                  If sftp.IsConnected Then
                                                                                      sftp.Disconnect()
                                                                                  End If
                                                                                  config.Error("注册失败：" + ex.Message)
                                                                              End Try
                                                                          End Using

                                                                          ' 删除临时文件
                                                                          If File.Exists(tempFilePath) Then
                                                                              File.Delete(tempFilePath)
                                                                              File.Delete(tempFilePath2)
                                                                              File.Delete(tempFilePath3)
                                                                              File.Delete(tempFilePath4)
                                                                              File.Delete(tempFilePath5)
                                                                          End If
                                                                          success = 1
                                                                          config.OK("注册成功")
                                                                      End If
                                                                  Catch ex As Exception
                                                                      config.Error("注册失败：" + ex.Message)
                                                                  End Try
                                                              End Using
                                                          Else
                                                              config.Error("用户名或密码不合法")
                                                          End If
                                                      Else
                                                          config.Error("验证码错误")
                                                      End If
                                                  Catch ex As Exception
                                                      config.Error("注册失败：" + ex.Message)
                                                  End Try
                                              End Sub,, 10)
        End If
    End Sub

    Private Shared Function ExtractDirectories(htmlContent As String) As List(Of String)
        Dim directories As New List(Of String)()

        ' 简单的提取逻辑（可能需要根据实际 HTML 结构进行调整）
        Dim lines As String() = htmlContent.Split(New String() {Environment.NewLine}, StringSplitOptions.None)

        For Each line As String In lines
            If line.Contains("href=") AndAlso line.Contains("/"c) Then
                Dim startIndex As Integer = line.IndexOf("href=") + 6
                Dim endIndex As Integer = line.IndexOf("/", startIndex)
                Dim directoryName As String = line.Substring(startIndex, endIndex - startIndex)
                directories.Add(directoryName)
            End If
        Next

        Return directories
    End Function

    ' 递归创建远程目录
    Shared Sub CreateRemoteDirectory(sftp As SftpClient, remoteDirectory As String)
        Dim directories = remoteDirectory.Split("/"c)
        Dim currentPath As String = ""

        For Each directory In directories
            If String.IsNullOrEmpty(directory) Then Continue For
            currentPath &= "/" & directory

            ' 如果当前目录不存在，创建它
            If Not sftp.Exists(currentPath) Then
                sftp.CreateDirectory(currentPath)
                Console.WriteLine($"创建远程目录: {currentPath}")
            End If
        Next
    End Sub

    Private Sub InputCode_TextChanged(sender As Object, e As EventArgs) Handles InputCode.TextChanged
        Try
            If InputCode.Text = verifyCode Then
                ButtonReg.Enabled = True
            Else
                ButtonReg.Enabled = False
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If success = 1 Then
            ButtonReg.Text = "关闭"
            ButtonReg.Type = AntdUI.TTypeMini.Success
        End If
    End Sub

    Private Function ContainsSymbol(input As String) As Boolean
        ' 定义一个正则表达式，匹配非字母和数字的字符
        Dim pattern As String = "[^\w]"
        Return Regex.IsMatch(input, pattern)
    End Function
End Class