Imports System.Runtime.InteropServices

Public Class OverlayWindow
    Inherits Form

    ' 导入 WinAPI 函数
    <DllImport("user32.dll", SetLastError:=True)>
    Private Shared Function SetWindowLong(hWnd As IntPtr, nIndex As Integer, dwNewLong As Integer) As Integer
    End Function

    <DllImport("user32.dll", SetLastError:=True)>
    Private Shared Function GetWindowLong(hWnd As IntPtr, nIndex As Integer) As Integer
    End Function

    Private Const GWL_EXSTYLE As Integer = -20
    Private Const WS_EX_LAYERED As Integer = &H80000
    Private Const WS_EX_TRANSPARENT As Integer = &H20

    Public Sub New()
        ' 设置无边框窗口
        Me.FormBorderStyle = FormBorderStyle.None
        Me.StartPosition = FormStartPosition.Manual
        Me.ShowInTaskbar = False
        Me.TopMost = True
        Me.BackColor = Color.Black
        Me.Opacity = 0.5 ' 半透明效果
        Me.AllowTransparency = True

        ' 添加提示文本
        Dim label As New Label With {
            .Text = "释放 HVKL 整合包文件以导入整合包...",
            .ForeColor = Color.White,
            .Font = New Font("微软雅黑", 16, FontStyle.Bold),
            .AutoSize = False,
            .Dock = DockStyle.Fill,
            .TextAlign = ContentAlignment.MiddleCenter
        }
        Me.Controls.Add(label)
    End Sub

    Protected Overrides Sub OnShown(e As EventArgs)
        MyBase.OnShown(e)
        ' 设置鼠标穿透
        Dim exStyle = GetWindowLong(Me.Handle, GWL_EXSTYLE)
        SetWindowLong(Me.Handle, GWL_EXSTYLE, exStyle Or WS_EX_LAYERED Or WS_EX_TRANSPARENT)
    End Sub
End Class
