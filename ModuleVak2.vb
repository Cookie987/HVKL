Imports System.IO
Imports System.Net.Http

Module ModuleVak2
    Public Function SaveVak2File(writestr As String, wdata As String, wlength As Integer, UserNameb As String, vak2FileContent As String, VackoVer As String)
        Try
            Dim WriteDatalengthstr As Integer = writestr.Length
            Dim WriteDataFLO1 As Integer = vak2FileContent.IndexOf(writestr, 0)
            Dim filePath As String = "version\" + VackoVer + "\Game\Usdata\" + UserNameb + "\localdata.vak2"

            Using fs As New FileStream(filePath, FileMode.Open, FileAccess.Write)

                fs.Seek(WriteDataFLO1 + WriteDatalengthstr, SeekOrigin.Begin)

                ' 使用 System.Text.Encoding.Default.GetBytes 将字符串转换为字节数组
                Dim wdataBytes As Byte() = System.Text.Encoding.Default.GetBytes(wdata)
                If wlength > wdataBytes.Length Then
                    wlength = wdataBytes.Length ' 避免越界
                End If

                fs.Write(wdataBytes, 0, wlength)

            End Using
        Catch ex As Exception
            Return ex
        End Try
        Return 0
        ' 写入内容
        ' writestr： 从哪里开始

        ' wdata：写什么

        ' wlength：写入的长度
    End Function


    Public Function ReadVak2File(optionName As String, readLength As Integer, vak2FileContent As String)
        Dim LoadDatalengthstr As Integer = optionName.Length

        Dim LoadDataFLO1 As Integer = vak2FileContent.IndexOf(optionName, 0)
        Return vak2FileContent.Substring(LoadDataFLO1 + LoadDatalengthstr, readLength)

        ' 读取内容

        ' DataResult 为结果

    End Function

    Public Async Function DownloadVak2File(remoteUrl As String) As Task(Of String)
        Try
            Using client As New HttpClient()
                Dim response As HttpResponseMessage = Await client.GetAsync(remoteUrl)
                response.EnsureSuccessStatusCode()

                ' 读取文件内容为字符串
                Dim fileContent As String = Await response.Content.ReadAsStringAsync()
                Return fileContent
            End Using
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Function PadWithNull(inputString As String, totalLength As Integer) As String
        ' 如果输入字符串长度不足指定长度，则补全 vbNullChar
        If inputString.Length < totalLength Then
            inputString = inputString.PadRight(totalLength, vbNullChar)
        End If
        Return inputString
    End Function
End Module
