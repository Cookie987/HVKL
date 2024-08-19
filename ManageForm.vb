Imports System.IO
Imports System.Net
Imports AntdUI

Public Class ManageForm
    Private Sub ManageForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AntdUI.Message.loading(Me, "获取版本中", Sub(config)
                                                ' 指定要列出子文件夹的路径
                                                Dim folderPath As String = "version"
                                                ' 检查路径是否存在
                                                If Directory.Exists(folderPath) Then
                                                    ' 获取所有子文件夹
                                                    Dim subDirectories As String() = Directory.GetDirectories(folderPath)
                                                    ' 清空选择器的项
                                                    Select1.Items.Clear()
                                                    ' 将子文件夹添加到选择器中
                                                    For Each dir As String In subDirectories
                                                        Select1.Items.Add(Path.GetFileName(dir))
                                                    Next
                                                    Progress1.Loading = False
                                                    config.OK("获取版本完成")
                                                Else
                                                    config.Error("指定的文件夹不存在")
                                                End If
                                            End Sub,, 2)

    End Sub

    Private Sub DeleteFolder(folderPath As String)
        AntdUI.Message.loading(Me, "删除版本中", Sub(config)
                                                Try
                                                    ' 检查文件夹是否存在
                                                    If Directory.Exists(folderPath) Then
                                                        ' 删除文件夹及其所有内容
                                                        Directory.Delete(folderPath, True)
                                                        Progress1.Value = 0.5
                                                        Progress1.Value = 1
                                                        Progress1.State = TType.Success
                                                        config.OK("成功删除该版本")
                                                    Else
                                                        Progress1.State = TType.Error
                                                        config.Error("指定的文件夹路径不存在")
                                                    End If

                                                Catch ex As Exception
                                                    ' 处理删除过程中的异常
                                                    Progress1.State = TType.Error
                                                    config.Error("删除文件夹时出错: " + ex.Message)
                                                End Try
                                            End Sub,, 2)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim dialogResult1 = AntdUI.Modal.open(New AntdUI.Modal.Config(Me, "删除版本", "这个版本及其存档将会失去很久（真的很久）！", AntdUI.TType.Warn))
        If dialogResult1 = DialogResult.OK Then
            Progress1.Value = 0.02
            DeleteFolder("version\" + Select1.SelectedValue)
            Progress1.Value = 1
            MainForm.RefreshVersion()
        End If
    End Sub

    Private Sub Select1_SelectedIndexChanged(sender As Object, value As Integer) Handles Select1.SelectedIndexChanged
        Button1.Enabled = True
        Progress1.State = TType.None
        Progress1.Value = 0
    End Sub
End Class