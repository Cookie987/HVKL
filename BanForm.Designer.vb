<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BanForm
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Label1 = New AntdUI.Label()
        Button1 = New Button()
        Timer1 = New Timer(components)
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.BackColor = Color.Firebrick
        Label1.Font = New Font("MS Gothic", 15.75F, FontStyle.Bold, GraphicsUnit.Point)
        Label1.ForeColor = Color.White
        Label1.Location = New Point(99, 216)
        Label1.Name = "Label1"
        Label1.Shadow = 5
        Label1.ShadowColor = Color.Black
        Label1.ShadowOffsetX = 5
        Label1.ShadowOffsetY = 5
        Label1.Size = New Size(665, 103)
        Label1.TabIndex = 0
        Label1.Text = "您的账号已被 LeBan 封禁，联系 Lemon Studio 以获得更多信息。" & vbCrLf & vbCrLf & "按下 [ALT]+[F4] 返回。"
        Label1.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(170, 430)
        Button1.Name = "Button1"
        Button1.Size = New Size(75, 23)
        Button1.TabIndex = 1
        Button1.Text = "Button1"
        Button1.UseVisualStyleBackColor = True
        Button1.Visible = False
        ' 
        ' Timer1
        ' 
        Timer1.Enabled = True
        Timer1.Interval = 500
        ' 
        ' BanForm
        ' 
        AutoScaleDimensions = New SizeF(7F, 17F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.Firebrick
        CancelButton = Button1
        ClientSize = New Size(847, 534)
        Controls.Add(Button1)
        Controls.Add(Label1)
        FormBorderStyle = FormBorderStyle.None
        Name = "BanForm"
        Text = "BanForm"
        TopMost = True
        ResumeLayout(False)
    End Sub

    Friend WithEvents Label1 As AntdUI.Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Timer1 As Timer
End Class
