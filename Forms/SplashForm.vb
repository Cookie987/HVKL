Imports System.Runtime.InteropServices
Imports HVKL.My.Resources

Public Class SplashForm
    ' 通过 DllImport 调用 SetCurrentProcessExplicitAppUserModelID 函数
    <DllImport("shell32.dll", CharSet:=CharSet.Unicode, SetLastError:=True)>
    Private Shared Function SetCurrentProcessExplicitAppUserModelID(ByVal AppID As String) As Integer
    End Function


    Private Sub SplashForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' 设置应用的 AppUserModelID（请替换为你自己的唯一标识符）
        Dim appId As String = "RCS.HVKL"
        Dim hr As Integer = SetCurrentProcessExplicitAppUserModelID(appId)
        If hr <> 0 Then
            MessageBox.Show("设置 AppUserModelID 失败，错误代码：" & hr.ToString())
        End If
    End Sub
End Class