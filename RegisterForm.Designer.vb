<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RegisterForm
    Inherits AntdUI.Window

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
        WindowBar1 = New AntdUI.WindowBar()
        InputPwd = New AntdUI.Input()
        InputUser = New AntdUI.Input()
        InputEmail = New AntdUI.Input()
        Button1 = New AntdUI.Button()
        Timer1 = New Timer(components)
        InputCode = New AntdUI.Input()
        ButtonReg = New AntdUI.Button()
        Timer2 = New Timer(components)
        SuspendLayout()
        ' 
        ' WindowBar1
        ' 
        WindowBar1.IsMax = False
        WindowBar1.Location = New Point(0, 0)
        WindowBar1.MaximizeBox = False
        WindowBar1.MinimizeBox = False
        WindowBar1.Name = "WindowBar1"
        WindowBar1.Size = New Size(323, 23)
        WindowBar1.TabIndex = 8
        WindowBar1.Text = "注册"
        ' 
        ' InputPwd
        ' 
        InputPwd.Location = New Point(48, 127)
        InputPwd.MaxLength = 10
        InputPwd.Name = "InputPwd"
        InputPwd.PlaceholderText = "密码"
        InputPwd.PrefixSvg = ""
        InputPwd.PrefixText = ""
        InputPwd.Size = New Size(224, 33)
        InputPwd.TabIndex = 4
        InputPwd.UseSystemPasswordChar = True
        ' 
        ' InputUser
        ' 
        InputUser.Location = New Point(48, 94)
        InputUser.MaxLength = 12
        InputUser.Name = "InputUser"
        InputUser.PlaceholderText = "用户名"
        InputUser.PrefixSvg = ""
        InputUser.PrefixText = ""
        InputUser.Size = New Size(224, 33)
        InputUser.TabIndex = 3
        ' 
        ' InputEmail
        ' 
        InputEmail.Location = New Point(48, 29)
        InputEmail.MaxLength = 255
        InputEmail.Name = "InputEmail"
        InputEmail.PlaceholderText = "邮箱"
        InputEmail.PrefixSvg = ""
        InputEmail.PrefixText = ""
        InputEmail.Size = New Size(224, 33)
        InputEmail.TabIndex = 0
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(159, 60)
        Button1.Name = "Button1"
        Button1.Size = New Size(112, 35)
        Button1.TabIndex = 2
        Button1.Text = "发送验证码"
        Button1.Type = AntdUI.TTypeMini.Primary
        ' 
        ' Timer1
        ' 
        Timer1.Interval = 1000
        ' 
        ' InputCode
        ' 
        InputCode.Location = New Point(48, 61)
        InputCode.MaxLength = 12
        InputCode.Name = "InputCode"
        InputCode.PlaceholderText = "验证码"
        InputCode.PrefixSvg = ""
        InputCode.PrefixText = ""
        InputCode.Size = New Size(105, 33)
        InputCode.TabIndex = 1
        ' 
        ' ButtonReg
        ' 
        ButtonReg.Enabled = False
        ButtonReg.Location = New Point(48, 166)
        ButtonReg.Name = "ButtonReg"
        ButtonReg.Size = New Size(223, 35)
        ButtonReg.TabIndex = 5
        ButtonReg.Text = "注册"
        ButtonReg.Type = AntdUI.TTypeMini.Primary
        ' 
        ' Timer2
        ' 
        Timer2.Enabled = True
        ' 
        ' RegisterForm
        ' 
        AutoScaleDimensions = New SizeF(7F, 17F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(306, 175)
        Controls.Add(ButtonReg)
        Controls.Add(InputCode)
        Controls.Add(Button1)
        Controls.Add(WindowBar1)
        Controls.Add(InputUser)
        Controls.Add(InputPwd)
        Controls.Add(InputEmail)
        Name = "RegisterForm"
        Resizable = False
        Text = "RegisterForm"
        ResumeLayout(False)
    End Sub

    Friend WithEvents WindowBar1 As AntdUI.WindowBar
    Friend WithEvents InputPwd As AntdUI.Input
    Friend WithEvents InputUser As AntdUI.Input
    Friend WithEvents InputEmail As AntdUI.Input
    Friend WithEvents Button1 As AntdUI.Button
    Friend WithEvents Timer1 As Timer
    Friend WithEvents InputCode As AntdUI.Input
    Friend WithEvents ButtonReg As AntdUI.Button
    Friend WithEvents Timer2 As Timer
End Class
