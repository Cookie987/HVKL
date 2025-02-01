Imports System.IO
Imports System.Net.Http
Imports System.Web
Imports HtmlAgilityPack

Public Class MusicDownloadForm
    Private Sub DownloadWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialize server and local file lists
        LoadServerFiles()
        LoadLocalFiles()
    End Sub

    Private Async Sub LoadServerFiles()
        Try
            ' Fetch file list from the server
            Dim serverFiles = Await GetServerFilesAsync("http://vacko.cookie987.top:28987/HVKLData/v1/Music/")

            lvServerFiles.Items.Clear()
            ' 确保 ListView 的 View 属性是 Details
            lvServerFiles.View = View.Details
            lvServerFiles.FullRowSelect = True ' 确保选中整行
            lvServerFiles.GridLines = True ' 显示网格线

            lvServerFiles.Columns.Add("名称", 300) ' 第一列
            lvServerFiles.Columns.Add("分类", 50) ' 第二列

            ' 添加数据到 ListView
            For Each entry In serverFiles
                Dim item As New ListViewItem(entry.Item2) ' File name (作为主列)
                item.SubItems.Add(entry.Item1) ' Subfolder name (作为副列)
                item.Checked = False
                lvServerFiles.Items.Add(item)
            Next
            AddHandler lvServerFiles.ColumnClick, AddressOf lvServerFiles_ColumnClick
        Catch ex As Exception
            AntdUI.Message.error(Me, "获取服务端文件失败：" + ex.Message,, 5)
        End Try
    End Sub

    ' 排序器类
    Public Class ListViewItemComparer
        Implements IComparer

        Private ReadOnly col As Integer
        Private ReadOnly order As SortOrder

        Public Sub New(column As Integer, sortOrder As SortOrder)
            col = column
            order = sortOrder
        End Sub

        Public Function Compare(x As Object, y As Object) As Integer Implements IComparer.Compare
            Dim itemX As String = DirectCast(x, ListViewItem).SubItems(col).Text
            Dim itemY As String = DirectCast(y, ListViewItem).SubItems(col).Text
            Dim result As Integer = String.Compare(itemX, itemY)
            If order = SortOrder.Descending Then result = -result
            Return result
        End Function
    End Class

    ' 处理列点击事件以启用排序
    Private Sub LvServerFiles_ColumnClick(sender As Object, e As ColumnClickEventArgs)
        Static lastCol As Integer = -1
        Static sortOrder As SortOrder = SortOrder.None

        If e.Column = lastCol Then
            ' 切换排序顺序
            sortOrder = If(sortOrder = SortOrder.Ascending, SortOrder.Descending, SortOrder.Ascending)
        Else
            ' 如果是新列，重置为升序
            sortOrder = SortOrder.Ascending
        End If

        lastCol = e.Column

        ' 设置排序器
        lvServerFiles.ListViewItemSorter = New ListViewItemComparer(e.Column, sortOrder)
        lvServerFiles.Sort()
    End Sub

    Private Async Function GetServerFilesAsync(baseUrl As String) As Task(Of List(Of Tuple(Of String, String)))
        Dim serverFiles As New List(Of Tuple(Of String, String))()

        Try
            Using client As New HttpClient()
                Dim response = Await client.GetStringAsync(baseUrl)

                Dim doc As New HtmlDocument()
                doc.LoadHtml(response)

                Dim nodes = doc.DocumentNode.SelectNodes("//a[@href]")

                If nodes IsNot Nothing Then
                    For Each node In nodes
                        Dim href = HttpUtility.UrlDecode(node.GetAttributeValue("href", ""))

                        ' Check if it's a folder
                        If href.EndsWith("/"c) AndAlso Not href.Equals("../") Then
                            Dim subFolderUrl = baseUrl & href
                            Dim subFolderName = href.TrimEnd("/")

                            Dim subFiles = Await GetFilesInSubFolderAsync(subFolderUrl)
                            For Each file In subFiles
                                serverFiles.Add(Tuple.Create(subFolderName, file))
                            Next
                        End If
                    Next
                End If
            End Using

        Catch ex As Exception
            AntdUI.Message.error(Me, "获取服务端文件失败：" + ex.Message,, 5)
        End Try

        Return serverFiles
    End Function

    Private Async Function GetFilesInSubFolderAsync(folderUrl As String) As Task(Of List(Of String))
        Dim fileList As New List(Of String)()

        Try
            Using client As New HttpClient()
                Dim response = Await client.GetStringAsync(folderUrl)

                Dim doc As New HtmlDocument()
                doc.LoadHtml(response)

                Dim nodes = doc.DocumentNode.SelectNodes("//a[@href]")

                If nodes IsNot Nothing Then
                    For Each node In nodes
                        Dim href = HttpUtility.UrlDecode(node.GetAttributeValue("href", ""))

                        ' Exclude parent directory link and subfolders
                        If Not (href.Equals("../") OrElse href.EndsWith("/"c)) Then
                            fileList.Add(href)
                        End If
                    Next
                End If
            End Using
        Catch ex As Exception
            AntdUI.Message.error(Me, "获取文件失败：" + ex.Message,, 5)
        End Try

        Return fileList
    End Function

    Private Sub LoadLocalFiles()
        ' Fetch files from the local folder
        Dim localFiles = Directory.GetFiles(Application.StartupPath + "version\" + ManageForm.Select2.SelectedValue + "\Config\Cache")

        For Each file In localFiles
            Dim item As New ListViewItem(Path.GetFileName(file)) With {
                .Checked = False
            } ' Subfolder column is empty for local files
            lvLocalFiles.Items.Add(item)
        Next
    End Sub

    Private Async Sub BtnDownload_Click(sender As Object, e As EventArgs) Handles btnDownload.Click
        ' Download selected files from server
        For Each item As ListViewItem In lvServerFiles.Items
            If item.Checked Then
                Dim fileName = item.Text
                Dim folderName = item.SubItems(1).Text
                Dim serverPath = $"http://vacko.cookie987.top:28987/HVKLData/v1/Music/{folderName}/{fileName}"
                Dim localPath = Application.StartupPath + "version\" + ManageForm.Select2.SelectedValue + "\Config\Cache\" + "（" + folderName + "）" + fileName

                Try
                    Directory.CreateDirectory(Path.GetDirectoryName(localPath))

                    Using client As New HttpClient()
                        Dim fileBytes = Await client.GetByteArrayAsync(serverPath)
                        Await File.WriteAllBytesAsync(localPath, fileBytes)
                    End Using

                    AntdUI.Message.info(Me, "成功下载" + fileName,, 2)
                Catch ex As Exception
                    AntdUI.Message.error(Me, "下载" + fileName + "失败：" + ex.Message,, 5)
                End Try
            End If
        Next

        ' Refresh local files list
        lvLocalFiles.Items.Clear()
        LoadLocalFiles()
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        ' Delete selected files from local folder
        For Each item As ListViewItem In lvLocalFiles.Items
            If item.Checked Then
                Dim fileName = item.Text
                Dim localPath = Path.Combine(Application.StartupPath + "version\" + ManageForm.Select2.SelectedValue + "\Config\Cache\", fileName)

                Try
                    If File.Exists(localPath) Then
                        File.Delete(localPath)
                        AntdUI.Message.info(Me, "成功删除" + fileName,, 2)
                    End If
                Catch ex As Exception
                    AntdUI.Message.error(Me, "删除" + fileName + "失败：" + ex.Message,, 5)
                End Try
            End If
        Next

        ' Refresh local files list
        lvLocalFiles.Items.Clear()
        LoadLocalFiles()
    End Sub
End Class
