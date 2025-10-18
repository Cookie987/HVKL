Imports System.ComponentModel
Imports System.IO
Imports Newtonsoft.Json.Linq

Public Class VackoSettings
    Dim obj As JObject

    Dim Convenience1 As Boolean
    Dim Convenience2 As Boolean

    Dim Personalized_1_First As String
    Dim Personalized_1_Second As String
    Dim Personalized_1_SystemColor As String
    Dim Personalized_2_Pcs As String
    Dim Personalized_2_Sys As String
    Dim Personalized_2_Sysin As String

    Dim filePath = Application.StartupPath + "version\" + selectedVersion2 + "\Game\Data\AppData.json"


    Dim colorOffset As Integer = 3
    ' ASCII 艺术字（示例）
    Dim asciiText As String() = {
                  " ____   ____              __           ________  ",
                  " \   \ /   /____    ____ |  | ______   \_____  \ ",
                  "  \   Y   /\__  \ _/ ___\|  |/ /  _ \   /  ____/ ",
                  "   \     /  / __ \\ \___ |    <  <_> ) /       \ ",
                  "    \___/  (____  /\___  >__|_ \____/  \_______ \",
                  "                \/     \/     \/               \/"
        }

    ' 颜色数组（按照你提供的数据转换为 RGB）
    Dim colors As Integer(,) = {
            {196, 202, 208, 214, 220, 226, 227, 228, 229, 230}, ' 红色到黄色
            {196, 202, 208, 214, 220, 226, 230, 34, 46, 30},   ' 红色到绿色
            {33, 89, 87, 93, 101, 107, 113, 119, 125, 131},     ' 蓝色到紫色
            {46, 118, 152, 185, 220, 254, 245, 242, 239, 235}, ' 绿色到红色
            {231, 238, 244, 250, 254, 250, 244, 238, 231, 232}, ' 白色到灰色
            {199, 204, 209, 214, 219, 224, 229, 234, 239, 244}, ' 橙色到黄色
            {208, 209, 211, 213, 215, 217, 219, 221, 223, 225}, ' 粉色到白色
            {54, 94, 134, 174, 214, 154, 114, 74, 34, 24},      ' 深蓝色到浅蓝色
            {52, 85, 118, 151, 184, 217, 250, 217, 184, 151},   ' 红色到紫色
            {208, 160, 112, 64, 16, 40, 56, 72, 88, 104},       ' 紫色到黑色
            {33, 64, 95, 126, 157, 188, 219, 250, 200, 150},    ' 蓝色到粉色
            {240, 233, 226, 219, 212, 205, 198, 191, 184, 177}, ' 米色到棕色
            {180, 155, 130, 105, 80, 55, 30, 60, 90, 120},      ' 棕色到蓝色
            {80, 90, 100, 110, 120, 130, 140, 150, 160, 170},   ' 灰色到浅灰色
            {230, 210, 190, 170, 150, 130, 110, 90, 70, 50},    ' 浅红到深红
            {20, 50, 80, 110, 140, 170, 200, 230, 255, 128},    ' 黑色到浅绿色
            {100, 80, 60, 40, 20, 25, 50, 75, 100, 125},        ' 紫色到亮紫色
            {10, 40, 70, 100, 130, 160, 190, 220, 250, 180},    ' 深绿色到浅黄色
            {50, 80, 110, 140, 170, 200, 230, 255, 230, 205},    ' 浅蓝到淡紫
            {16, 32, 64, 96, 128, 160, 192, 224, 240, 255},     ' 黑色到白色
            {230, 200, 170, 140, 110, 80, 50, 20, 10, 0},       ' 黄色到棕色
            {10, 50, 90, 130, 170, 210, 250, 210, 170, 130},    ' 绿色到青色
            {180, 160, 140, 120, 100, 80, 60, 40, 20, 0},       ' 灰色到黑色
            {128, 64, 32, 16, 8, 4, 2, 1, 0, 0},                ' 紫红色到黑色
            {240, 200, 160, 120, 80, 100, 140, 180, 220, 255},  ' 淡黄色到红色
            {245, 210, 175, 140, 105, 70, 85, 100, 115, 130},   ' 浅棕色到深棕色
            {34, 68, 102, 136, 170, 204, 238, 204, 170, 136},   ' 深绿色到浅绿色
            {20, 50, 80, 110, 140, 170, 200, 230, 245, 255},    ' 深蓝到浅蓝
            {255, 230, 205, 180, 155, 130, 105, 80, 55, 30}      ' 米白到橙色
        }

    Private Sub VackoSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PageHeader1.Text += " - 当前管理版本：" + selectedVersion2

        Try
            Dim appDataContent = File.ReadAllText(filePath)
            obj = JObject.Parse(appDataContent)
            Convenience1 = obj("Settings")("Convenience_1")
            Convenience2 = obj("Settings")("Convenience_2")

            Personalized_1_First = obj("Settings")("Personalized_1_First")
            Personalized_1_Second = obj("Settings")("Personalized_1_Second")
            Personalized_1_SystemColor = obj("Settings")("Personalized_1_SystemColor")
            Personalized_2_Pcs = obj("Settings")("Personalized_2_Pcs")
            Personalized_2_Sys = obj("Settings")("Personalized_2_Sys")
            Personalized_2_Sysin = obj("Settings")("Personalized_2_Sysin")
        Catch ex As Exception
            AntdUI.Notification.error(Me, "读取Vacko配置文件错误", ex.Message,,, 0)
        End Try
        SwitchConvenience1.Checked = Convenience1
        SwitchConvenience2.Checked = Convenience2

        If Not Personalized_1_First = "0" AndAlso Personalized_1_Second = "0" Then
            
        ElseIf Not Personalized_1_SystemColor = "00" Then
            RadioSystem.Checked = True
            InputNumber1.Visible = True
            Dim a = obj("Settings")("Personalized_1_SystemColor")
            InputNumber1.Value = Personalized_1_SystemColor
            DisplayVackoLogo("system", Personalized_1_SystemColor - 1, Nothing, Nothing)
        End If
    End Sub

    Private Sub VackoSettings_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        ManageForm.Button6.Enabled = True
    End Sub

    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click
        Dispose()
    End Sub

    Private Sub ButtonSave_Click(sender As Object, e As EventArgs) Handles ButtonSave.Click
        Try
            File.WriteAllText(filePath, obj.ToString)
            Dispose()
        Catch ex As Exception
            AntdUI.Notification.error(Me, "写入Vacko配置文件错误", ex.Message,,, 0)
        End Try
    End Sub

    Private Sub ButtonApply_Click(sender As Object, e As EventArgs) Handles ButtonApply.Click
        Try
            File.WriteAllText(filePath, obj.ToString)
        Catch ex As Exception
            AntdUI.Notification.error(Me, "写入Vacko配置文件错误", ex.Message,,, 0)
        End Try
    End Sub

    ' ANSI 256 颜色转换为 .NET Color
    Private Function GetAnsiColor(ansiCode As Integer) As Color
        If ansiCode < 0 Or ansiCode > 255 Then Return Color.White ' 非法输入返回白色

        ' 标准 16 色 (前 16 个颜色)
        Dim ansi16 As Color() = {
        Color.Black, Color.Maroon, Color.Green, Color.Olive,
        Color.Navy, Color.Purple, Color.Teal, Color.Silver,
        Color.Gray, Color.Red, Color.Lime, Color.Yellow,
        Color.Blue, Color.Magenta, Color.Cyan, Color.White
    }

        If ansiCode < 16 Then Return ansi16(ansiCode) ' 0-15 直接返回标准颜色

        ' 6x6x6 颜色立方体 (16~231)
        If ansiCode >= 16 And ansiCode <= 231 Then
            Dim index As Integer = ansiCode - 16
            Dim r As Integer = (index \ 36) * 51 ' R 通道
            Dim g As Integer = ((index Mod 36) \ 6) * 51 ' G 通道
            Dim b As Integer = (index Mod 6) * 51 ' B 通道
            Return Color.FromArgb(r, g, b)
        End If

        ' 灰阶颜色 (232~255)
        If ansiCode >= 232 And ansiCode <= 255 Then
            Dim gray As Integer = 8 + (ansiCode - 232) * 10
            Return Color.FromArgb(gray, gray, gray)
        End If

        ' 兜底返回白色
        Return Color.White
    End Function

    Private Sub DisplayVackoLogo(type As String, index As Integer, customColor1 As String, customColor2 As String)
        RichTextBox1.Clear()
        Dim rand As New Random
        Dim nextIndex = rand.Next(0, colors.Length / 10)
        Dim colorRowIndex As Integer
        If type = "default" Then
            colorRowIndex = nextIndex
        ElseIf type = "system" Then
            colorRowIndex = index
        ElseIf type = "custom" Then
            colorRowIndex = 14
        End If

        Dim colorGradient As Integer() = Enumerable.Range(0, colors.GetLength(1)).
                                        Select(Function(i) CType(colors(colorRowIndex, i), Integer)).
                                        ToArray()

        RichTextBox1.Font = New Font("Consolas", 8, FontStyle.Bold)

        ' 获取最大列数
        Dim maxWidth As Integer = asciiText.Max(Function(line) line.Length)
        ' 应用颜色渐变（按列）
        ' 逐行处理 ASCII 艺术字
        For row As Integer = 0 To asciiText.Length - 1
            For col As Integer = 0 To asciiText(row).Length - 1
                Dim ch As String = asciiText(row)(col)

                ' 计算颜色索引，加入偏移量
                Dim colorIndex As Integer = ((row + col) Mod colorGradient.Length + colorOffset) Mod colorGradient.Length
                Dim textColor As Color = GetAnsiColor(colorGradient(colorIndex))

                ' 设置字符颜色
                RichTextBox1.SelectionStart = RichTextBox1.TextLength
                RichTextBox1.SelectionColor = textColor
                RichTextBox1.AppendText(ch)
            Next
            RichTextBox1.AppendText(vbCrLf) ' 换行
        Next
    End Sub


    Private Sub AppendColoredText(richtextbox1 As RichTextBox, text As String, color As Color)
        richtextbox1.SelectionStart = richtextbox1.TextLength
        richtextbox1.SelectionLength = 0
        richtextbox1.SelectionColor = color
        richtextbox1.AppendText(text)
        richtextbox1.SelectionColor = richtextbox1.ForeColor ' 还原默认颜色
    End Sub

    Private Sub SwitchConvenience1_CheckedChanged(sender As Object, e As AntdUI.BoolEventArgs) Handles SwitchConvenience1.CheckedChanged
        obj("Settings")("Convenience_1") = e.Value
    End Sub

    Private Sub SwitchConvenience2_CheckedChanged(sender As Object, e As AntdUI.BoolEventArgs) Handles SwitchConvenience2.CheckedChanged
        obj("Settings")("Convenience_2") = e.Value
    End Sub

    Private Sub RadioSystem_CheckedChanged(sender As Object, e As AntdUI.BoolEventArgs) Handles RadioSystem.CheckedChanged
        If e.Value Then
            InputNumber1.Visible = True
            obj("Settings")("Personalized_1_First") = "0"
            obj("Settings")("Personalized_1_Second") = "0"
            obj("Settings")("Personalized_1_SystemColor") = CInt(InputNumber1.Value).ToString("D2")
        Else
            InputNumber1.Visible = False
            obj("Settings")("Personalized_1_SystemColor") = "00"
        End If
    End Sub

    Private Sub InputNumber1_ValueChanged(sender As Object, e As AntdUI.DecimalEventArgs) Handles InputNumber1.ValueChanged
        If e.Value > colors.Length / 10 Or e.Value < 1 Then
        Else
            If RadioSystem.Checked Then
                obj("Settings")("Personalized_1_SystemColor") = CInt(e.Value).ToString("D2") '不足2位补0
                DisplayVackoLogo("system", CInt(e.Value) - 1, Nothing, Nothing)
            End If
        End If
    End Sub
End Class