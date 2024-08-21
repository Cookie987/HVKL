<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SettingForm
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
        SettingPanel = New AntdUI.Panel()
        StartTimesLabel = New AntdUI.Label()
        Label2 = New AntdUI.Label()
        Label1 = New AntdUI.Label()
        Divider3 = New AntdUI.Divider()
        SettingLabel = New AntdUI.Label()
        Panel1 = New AntdUI.Panel()
        Label3 = New AntdUI.Label()
        Switch1 = New AntdUI.Switch()
        Divider1 = New AntdUI.Divider()
        Label5 = New AntdUI.Label()
        ButtonCheckUpdate = New AntdUI.Button()
        SettingPanel.SuspendLayout()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' WindowBar1
        ' 
        WindowBar1.Location = New Point(0, -1)
        WindowBar1.MaximizeBox = False
        WindowBar1.MinimizeBox = False
        WindowBar1.Name = "WindowBar1"
        WindowBar1.Size = New Size(625, 23)
        WindowBar1.TabIndex = 5
        WindowBar1.Text = "设置"
        ' 
        ' SettingPanel
        ' 
        SettingPanel.BackColor = Color.Transparent
        SettingPanel.BorderWidth = 1F
        SettingPanel.Controls.Add(StartTimesLabel)
        SettingPanel.Controls.Add(Label2)
        SettingPanel.Controls.Add(Label1)
        SettingPanel.Controls.Add(Divider3)
        SettingPanel.Controls.Add(SettingLabel)
        SettingPanel.Location = New Point(193, 28)
        SettingPanel.Name = "SettingPanel"
        SettingPanel.Shadow = 15
        SettingPanel.ShadowOpacityAnimation = True
        SettingPanel.Size = New Size(234, 171)
        SettingPanel.TabIndex = 6
        SettingPanel.Text = "Panel2"
        ' 
        ' StartTimesLabel
        ' 
        StartTimesLabel.Location = New Point(33, 100)
        StartTimesLabel.Name = "StartTimesLabel"
        StartTimesLabel.Size = New Size(171, 23)
        StartTimesLabel.TabIndex = 5
        StartTimesLabel.Text = "启动游戏次数："
        StartTimesLabel.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label2
        ' 
        Label2.Cursor = Cursors.Hand
        Label2.Font = New Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label2.Location = New Point(80, 68)
        Label2.Name = "Label2"
        Label2.Size = New Size(75, 23)
        Label2.TabIndex = 4
        Label2.Text = "?"
        Label2.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label1
        ' 
        Label1.Font = New Font("Segoe UI Symbol", 10.5F, FontStyle.Regular, GraphicsUnit.Point)
        Label1.Location = New Point(28, 120)
        Label1.Name = "Label1"
        Label1.Size = New Size(183, 23)
        Label1.TabIndex = 3
        Label1.Text = "Made with ❤ by Cookie987"
        Label1.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Divider3
        ' 
        Divider3.Location = New Point(33, 44)
        Divider3.Name = "Divider3"
        Divider3.OrientationMargin = 0F
        Divider3.Size = New Size(172, 16)
        Divider3.TabIndex = 2
        Divider3.Text = ""
        ' 
        ' SettingLabel
        ' 
        SettingLabel.BackColor = Color.Transparent
        SettingLabel.Font = New Font("Microsoft YaHei UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point)
        SettingLabel.Location = New Point(33, 20)
        SettingLabel.Name = "SettingLabel"
        SettingLabel.Size = New Size(171, 33)
        SettingLabel.TabIndex = 1
        SettingLabel.Text = "Hello Vacko Launcher"
        SettingLabel.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.Transparent
        Panel1.BorderWidth = 1F
        Panel1.Controls.Add(Label3)
        Panel1.Controls.Add(Switch1)
        Panel1.Controls.Add(Divider1)
        Panel1.Controls.Add(Label5)
        Panel1.Location = New Point(12, 224)
        Panel1.Name = "Panel1"
        Panel1.Shadow = 15
        Panel1.ShadowOpacityAnimation = True
        Panel1.Size = New Size(585, 161)
        Panel1.TabIndex = 7
        Panel1.Text = "Panel2"
        Panel1.Visible = False
        ' 
        ' Label3
        ' 
        Label3.BackColor = Color.Transparent
        Label3.Font = New Font("Microsoft YaHei UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point)
        Label3.Location = New Point(103, 62)
        Label3.Name = "Label3"
        Label3.Size = New Size(171, 33)
        Label3.TabIndex = 4
        Label3.Text = "使用自定义背景图片"
        ' 
        ' Switch1
        ' 
        Switch1.AutoCheck = True
        Switch1.Location = New Point(53, 66)
        Switch1.Name = "Switch1"
        Switch1.Size = New Size(44, 25)
        Switch1.TabIndex = 3
        Switch1.Text = "12"
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
        Label5.Text = "开发者选项"
        ' 
        ' ButtonCheckUpdate
        ' 
        ButtonCheckUpdate.Location = New Point(258, 193)
        ButtonCheckUpdate.Name = "ButtonCheckUpdate"
        ButtonCheckUpdate.Size = New Size(104, 36)
        ButtonCheckUpdate.TabIndex = 8
        ButtonCheckUpdate.Text = "检查更新"
        ButtonCheckUpdate.Type = AntdUI.TTypeMini.Primary
        ' 
        ' SettingForm
        ' 
        AutoScaleDimensions = New SizeF(7F, 17F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(609, 368)
        Controls.Add(ButtonCheckUpdate)
        Controls.Add(Panel1)
        Controls.Add(SettingPanel)
        Controls.Add(WindowBar1)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Name = "SettingForm"
        Resizable = False
        Text = "SettingForm"
        SettingPanel.ResumeLayout(False)
        Panel1.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents WindowBar1 As AntdUI.WindowBar
    Friend WithEvents SettingPanel As AntdUI.Panel
    Friend WithEvents Divider3 As AntdUI.Divider
    Friend WithEvents SettingLabel As AntdUI.Label
    Friend WithEvents Label1 As AntdUI.Label
    Friend WithEvents Label2 As AntdUI.Label
    Friend WithEvents Panel1 As AntdUI.Panel
    Friend WithEvents Label3 As AntdUI.Label
    Friend WithEvents Switch1 As AntdUI.Switch
    Friend WithEvents Divider1 As AntdUI.Divider
    Friend WithEvents Label5 As AntdUI.Label
    Friend WithEvents ButtonCheckUpdate As AntdUI.Button
    Friend WithEvents StartTimesLabel As AntdUI.Label
End Class
