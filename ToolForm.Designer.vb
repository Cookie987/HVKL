<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ToolForm
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
        WindowBar1 = New AntdUI.WindowBar()
        Panel1 = New AntdUI.Panel()
        Button1 = New AntdUI.Button()
        Input1 = New AntdUI.Input()
        Divider1 = New AntdUI.Divider()
        Label5 = New AntdUI.Label()
        Panel2 = New AntdUI.Panel()
        Button2 = New AntdUI.Button()
        Input2 = New AntdUI.Input()
        Divider2 = New AntdUI.Divider()
        Label1 = New AntdUI.Label()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        SuspendLayout()
        ' 
        ' WindowBar1
        ' 
        WindowBar1.IsMax = False
        WindowBar1.Location = New Point(1, -1)
        WindowBar1.MaximizeBox = False
        WindowBar1.MinimizeBox = False
        WindowBar1.Name = "WindowBar1"
        WindowBar1.Size = New Size(441, 23)
        WindowBar1.TabIndex = 7
        WindowBar1.Text = "工具"
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.Transparent
        Panel1.BorderWidth = 1F
        Panel1.Controls.Add(Button1)
        Panel1.Controls.Add(Input1)
        Panel1.Controls.Add(Divider1)
        Panel1.Controls.Add(Label5)
        Panel1.Location = New Point(5, 19)
        Panel1.Name = "Panel1"
        Panel1.Shadow = 15
        Panel1.ShadowOpacityAnimation = True
        Panel1.Size = New Size(431, 140)
        Panel1.TabIndex = 8
        Panel1.Text = "Panel2"
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(278, 62)
        Button1.Name = "Button1"
        Button1.Size = New Size(114, 35)
        Button1.TabIndex = 4
        Button1.Text = "查找"
        Button1.Type = AntdUI.TTypeMini.Primary
        ' 
        ' Input1
        ' 
        Input1.Location = New Point(47, 62)
        Input1.Name = "Input1"
        Input1.PlaceholderText = "输入用户名"
        Input1.Size = New Size(207, 35)
        Input1.TabIndex = 3
        ' 
        ' Divider1
        ' 
        Divider1.Location = New Point(33, 44)
        Divider1.Name = "Divider1"
        Divider1.OrientationMargin = 0F
        Divider1.Size = New Size(172, 16)
        Divider1.TabIndex = 2
        Divider1.Text = ""
        ' 
        ' Label5
        ' 
        Label5.BackColor = Color.Transparent
        Label5.Font = New Font("Microsoft YaHei UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point)
        Label5.Location = New Point(33, 20)
        Label5.Name = "Label5"
        Label5.Size = New Size(171, 33)
        Label5.TabIndex = 1
        Label5.Text = "查找Vacko2用户名可用性"
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.Transparent
        Panel2.BorderWidth = 1F
        Panel2.Controls.Add(Button2)
        Panel2.Controls.Add(Input2)
        Panel2.Controls.Add(Divider2)
        Panel2.Controls.Add(Label1)
        Panel2.Location = New Point(5, 165)
        Panel2.Name = "Panel2"
        Panel2.Shadow = 15
        Panel2.ShadowOpacityAnimation = True
        Panel2.Size = New Size(431, 140)
        Panel2.TabIndex = 9
        Panel2.Text = "Panel2"
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(278, 62)
        Button2.Name = "Button2"
        Button2.Size = New Size(114, 35)
        Button2.TabIndex = 4
        Button2.Text = "查找"
        Button2.Type = AntdUI.TTypeMini.Primary
        ' 
        ' Input2
        ' 
        Input2.Location = New Point(47, 62)
        Input2.Name = "Input2"
        Input2.PlaceholderText = "输入邮箱"
        Input2.Size = New Size(207, 35)
        Input2.TabIndex = 3
        ' 
        ' Divider2
        ' 
        Divider2.Location = New Point(33, 44)
        Divider2.Name = "Divider2"
        Divider2.OrientationMargin = 0F
        Divider2.Size = New Size(172, 16)
        Divider2.TabIndex = 2
        Divider2.Text = ""
        ' 
        ' Label1
        ' 
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Microsoft YaHei UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point)
        Label1.Location = New Point(33, 20)
        Label1.Name = "Label1"
        Label1.Size = New Size(171, 33)
        Label1.TabIndex = 1
        Label1.Text = "查找Vacko2邮箱可用性"
        ' 
        ' ToolForm
        ' 
        AutoScaleDimensions = New SizeF(7F, 17F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(439, 302)
        Controls.Add(Panel2)
        Controls.Add(WindowBar1)
        Controls.Add(Panel1)
        Name = "ToolForm"
        Resizable = False
        Text = "ToolForm"
        Panel1.ResumeLayout(False)
        Panel2.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents WindowBar1 As AntdUI.WindowBar
    Friend WithEvents Panel1 As AntdUI.Panel
    Friend WithEvents Divider1 As AntdUI.Divider
    Friend WithEvents Label5 As AntdUI.Label
    Friend WithEvents Input1 As AntdUI.Input
    Friend WithEvents Button1 As AntdUI.Button
    Friend WithEvents Panel2 As AntdUI.Panel
    Friend WithEvents Button2 As AntdUI.Button
    Friend WithEvents Input2 As AntdUI.Input
    Friend WithEvents Divider2 As AntdUI.Divider
    Friend WithEvents Label1 As AntdUI.Label
End Class
