<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
    Inherits AntdUI.Window

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        DownloadVersionPanel = New AntdUI.Panel()
        DownloadVersionImage = New AntdUI.Image3D()
        Divider1 = New AntdUI.Divider()
        DownloadVersionLabel = New AntdUI.Label()
        ManageVersionPanel = New AntdUI.Panel()
        ManageVersionImage3d = New AntdUI.Image3D()
        Divider2 = New AntdUI.Divider()
        ManageVersionLabel = New AntdUI.Label()
        MainSettingPanel = New AntdUI.Panel()
        SettingImage3d = New AntdUI.Image3D()
        Divider3 = New AntdUI.Divider()
        SettingLabel = New AntdUI.Label()
        Panel1 = New AntdUI.Panel()
        RadioHVKLLogin = New AntdUI.Radio()
        RadioVackoLogin = New AntdUI.Radio()
        Divider7 = New AntdUI.Divider()
        Select1 = New AntdUI.Select()
        Divider4 = New AntdUI.Divider()
        Label1 = New AntdUI.Label()
        Select2 = New AntdUI.Select()
        PanelTools = New AntdUI.Panel()
        ToolsImage3d = New AntdUI.Image3D()
        Divider5 = New AntdUI.Divider()
        LabelTools = New AntdUI.Label()
        Panel2 = New AntdUI.Panel()
        Label3 = New AntdUI.Label()
        Checkbox1 = New AntdUI.Checkbox()
        InputPwd = New AntdUI.Input()
        InputUser = New AntdUI.Input()
        Divider8 = New AntdUI.Divider()
        Label2 = New AntdUI.Label()
        Timer1 = New Timer(components)
        PageHeader1 = New AntdUI.PageHeader()
        DownloadVersionPanel.SuspendLayout()
        ManageVersionPanel.SuspendLayout()
        MainSettingPanel.SuspendLayout()
        Panel1.SuspendLayout()
        PanelTools.SuspendLayout()
        Panel2.SuspendLayout()
        SuspendLayout()
        ' 
        ' DownloadVersionPanel
        ' 
        DownloadVersionPanel.BackColor = Color.Transparent
        DownloadVersionPanel.BorderWidth = 1.0F
        DownloadVersionPanel.Controls.Add(DownloadVersionImage)
        DownloadVersionPanel.Controls.Add(Divider1)
        DownloadVersionPanel.Controls.Add(DownloadVersionLabel)
        DownloadVersionPanel.Cursor = Cursors.Hand
        DownloadVersionPanel.Location = New Point(12, 37)
        DownloadVersionPanel.Name = "DownloadVersionPanel"
        DownloadVersionPanel.Shadow = 15
        DownloadVersionPanel.ShadowOpacityAnimation = True
        DownloadVersionPanel.Size = New Size(180, 180)
        DownloadVersionPanel.TabIndex = 3
        DownloadVersionPanel.Text = "Panel2"
        ' 
        ' DownloadVersionImage
        ' 
        DownloadVersionImage.Image = CType(resources.GetObject("DownloadVersionImage.Image"), Image)
        DownloadVersionImage.Location = New Point(50, 66)
        DownloadVersionImage.Name = "DownloadVersionImage"
        DownloadVersionImage.Size = New Size(75, 76)
        DownloadVersionImage.TabIndex = 3
        DownloadVersionImage.Text = "Image3d1"
        ' 
        ' Divider1
        ' 
        Divider1.Location = New Point(33, 44)
        Divider1.Name = "Divider1"
        Divider1.OrientationMargin = 0F
        Divider1.Size = New Size(116, 16)
        Divider1.TabIndex = 2
        Divider1.Text = ""
        ' 
        ' DownloadVersionLabel
        ' 
        DownloadVersionLabel.BackColor = Color.Transparent
        DownloadVersionLabel.Font = New Font("Microsoft YaHei UI", 10.5F)
        DownloadVersionLabel.Location = New Point(33, 20)
        DownloadVersionLabel.Name = "DownloadVersionLabel"
        DownloadVersionLabel.Size = New Size(116, 33)
        DownloadVersionLabel.TabIndex = 1
        DownloadVersionLabel.Text = "下载版本"
        DownloadVersionLabel.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' ManageVersionPanel
        ' 
        ManageVersionPanel.BackColor = Color.Transparent
        ManageVersionPanel.BorderWidth = 1.0F
        ManageVersionPanel.Controls.Add(ManageVersionImage3d)
        ManageVersionPanel.Controls.Add(Divider2)
        ManageVersionPanel.Controls.Add(ManageVersionLabel)
        ManageVersionPanel.Cursor = Cursors.Hand
        ManageVersionPanel.Location = New Point(198, 37)
        ManageVersionPanel.Name = "ManageVersionPanel"
        ManageVersionPanel.Shadow = 15
        ManageVersionPanel.ShadowOpacityAnimation = True
        ManageVersionPanel.Size = New Size(180, 180)
        ManageVersionPanel.TabIndex = 4
        ManageVersionPanel.Text = "Panel2"
        ' 
        ' ManageVersionImage3d
        ' 
        ManageVersionImage3d.Image = CType(resources.GetObject("ManageVersionImage3d.Image"), Image)
        ManageVersionImage3d.Location = New Point(50, 66)
        ManageVersionImage3d.Name = "ManageVersionImage3d"
        ManageVersionImage3d.Size = New Size(75, 76)
        ManageVersionImage3d.TabIndex = 3
        ManageVersionImage3d.Text = "Image3d1"
        ' 
        ' Divider2
        ' 
        Divider2.Location = New Point(33, 44)
        Divider2.Name = "Divider2"
        Divider2.OrientationMargin = 0F
        Divider2.Size = New Size(116, 16)
        Divider2.TabIndex = 2
        Divider2.Text = ""
        ' 
        ' ManageVersionLabel
        ' 
        ManageVersionLabel.BackColor = Color.Transparent
        ManageVersionLabel.Font = New Font("Microsoft YaHei UI", 10.5F)
        ManageVersionLabel.Location = New Point(33, 20)
        ManageVersionLabel.Name = "ManageVersionLabel"
        ManageVersionLabel.Size = New Size(116, 33)
        ManageVersionLabel.TabIndex = 1
        ManageVersionLabel.Text = "管理版本"
        ManageVersionLabel.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' MainSettingPanel
        ' 
        MainSettingPanel.BackColor = Color.Transparent
        MainSettingPanel.BorderWidth = 1.0F
        MainSettingPanel.Controls.Add(SettingImage3d)
        MainSettingPanel.Controls.Add(Divider3)
        MainSettingPanel.Controls.Add(SettingLabel)
        MainSettingPanel.Cursor = Cursors.Hand
        MainSettingPanel.Location = New Point(570, 37)
        MainSettingPanel.Name = "MainSettingPanel"
        MainSettingPanel.Shadow = 15
        MainSettingPanel.ShadowOpacityAnimation = True
        MainSettingPanel.Size = New Size(180, 180)
        MainSettingPanel.TabIndex = 5
        MainSettingPanel.Text = "Panel2"
        ' 
        ' SettingImage3d
        ' 
        SettingImage3d.Image = CType(resources.GetObject("SettingImage3d.Image"), Image)
        SettingImage3d.Location = New Point(53, 66)
        SettingImage3d.Name = "SettingImage3d"
        SettingImage3d.Size = New Size(75, 76)
        SettingImage3d.TabIndex = 3
        SettingImage3d.Text = "Image3d1"
        ' 
        ' Divider3
        ' 
        Divider3.Location = New Point(33, 44)
        Divider3.Name = "Divider3"
        Divider3.OrientationMargin = 0F
        Divider3.Size = New Size(116, 16)
        Divider3.TabIndex = 2
        Divider3.Text = ""
        ' 
        ' SettingLabel
        ' 
        SettingLabel.BackColor = Color.Transparent
        SettingLabel.Font = New Font("Microsoft YaHei UI", 10.5F)
        SettingLabel.Location = New Point(33, 20)
        SettingLabel.Name = "SettingLabel"
        SettingLabel.Size = New Size(116, 33)
        SettingLabel.TabIndex = 1
        SettingLabel.Text = "设置"
        SettingLabel.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.Transparent
        Panel1.BorderWidth = 1.0F
        Panel1.Controls.Add(RadioHVKLLogin)
        Panel1.Controls.Add(RadioVackoLogin)
        Panel1.Controls.Add(Divider7)
        Panel1.Controls.Add(Select1)
        Panel1.Controls.Add(Divider4)
        Panel1.Controls.Add(Label1)
        Panel1.Cursor = Cursors.Hand
        Panel1.Location = New Point(12, 223)
        Panel1.Name = "Panel1"
        Panel1.Shadow = 15
        Panel1.ShadowOpacityAnimation = True
        Panel1.Size = New Size(311, 180)
        Panel1.TabIndex = 6
        Panel1.Text = "Panel2"
        ' 
        ' RadioHVKLLogin
        ' 
        RadioHVKLLogin.Location = New Point(174, 124)
        RadioHVKLLogin.Name = "RadioHVKLLogin"
        RadioHVKLLogin.Size = New Size(104, 21)
        RadioHVKLLogin.TabIndex = 7
        RadioHVKLLogin.Text = "HVKL内登录"
        ' 
        ' RadioVackoLogin
        ' 
        RadioVackoLogin.Checked = True
        RadioVackoLogin.Location = New Point(36, 124)
        RadioVackoLogin.Name = "RadioVackoLogin"
        RadioVackoLogin.Size = New Size(114, 21)
        RadioVackoLogin.TabIndex = 4
        RadioVackoLogin.Text = "Vacko内登录"
        ' 
        ' Divider7
        ' 
        Divider7.Location = New Point(33, 106)
        Divider7.Name = "Divider7"
        Divider7.OrientationMargin = 0F
        Divider7.Size = New Size(116, 16)
        Divider7.TabIndex = 6
        Divider7.Text = ""
        ' 
        ' Select1
        ' 
        Select1.Location = New Point(33, 62)
        Select1.Name = "Select1"
        Select1.Size = New Size(245, 40)
        Select1.TabIndex = 3
        Select1.Text = "选择版本以启动游戏"
        ' 
        ' Divider4
        ' 
        Divider4.Location = New Point(33, 44)
        Divider4.Name = "Divider4"
        Divider4.OrientationMargin = 0F
        Divider4.Size = New Size(116, 16)
        Divider4.TabIndex = 2
        Divider4.Text = ""
        ' 
        ' Label1
        ' 
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Microsoft YaHei UI", 10.5F)
        Label1.Location = New Point(33, 20)
        Label1.Name = "Label1"
        Label1.Size = New Size(116, 33)
        Label1.TabIndex = 1
        Label1.Text = "选择版本"
        ' 
        ' Select2
        ' 
        Select2.Location = New Point(366, 424)
        Select2.Name = "Select2"
        Select2.Size = New Size(75, 23)
        Select2.TabIndex = 7
        Select2.Text = "Select2"
        Select2.Visible = False
        ' 
        ' PanelTools
        ' 
        PanelTools.BackColor = Color.Transparent
        PanelTools.BorderWidth = 1.0F
        PanelTools.Controls.Add(ToolsImage3d)
        PanelTools.Controls.Add(Divider5)
        PanelTools.Controls.Add(LabelTools)
        PanelTools.Cursor = Cursors.Hand
        PanelTools.Location = New Point(384, 37)
        PanelTools.Name = "PanelTools"
        PanelTools.Shadow = 15
        PanelTools.ShadowOpacityAnimation = True
        PanelTools.Size = New Size(180, 180)
        PanelTools.TabIndex = 6
        PanelTools.Text = "Panel2"
        ' 
        ' ToolsImage3d
        ' 
        ToolsImage3d.Image = CType(resources.GetObject("ToolsImage3d.Image"), Image)
        ToolsImage3d.Location = New Point(53, 66)
        ToolsImage3d.Name = "ToolsImage3d"
        ToolsImage3d.Size = New Size(75, 76)
        ToolsImage3d.TabIndex = 3
        ToolsImage3d.Text = "Image3d1"
        ' 
        ' Divider5
        ' 
        Divider5.Location = New Point(33, 44)
        Divider5.Name = "Divider5"
        Divider5.OrientationMargin = 0F
        Divider5.Size = New Size(116, 16)
        Divider5.TabIndex = 2
        Divider5.Text = ""
        ' 
        ' LabelTools
        ' 
        LabelTools.BackColor = Color.Transparent
        LabelTools.Font = New Font("Microsoft YaHei UI", 10.5F)
        LabelTools.Location = New Point(33, 20)
        LabelTools.Name = "LabelTools"
        LabelTools.Size = New Size(116, 33)
        LabelTools.TabIndex = 1
        LabelTools.Text = "工具"
        LabelTools.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.Transparent
        Panel2.BorderWidth = 1.0F
        Panel2.Controls.Add(Label3)
        Panel2.Controls.Add(Checkbox1)
        Panel2.Controls.Add(InputPwd)
        Panel2.Controls.Add(InputUser)
        Panel2.Controls.Add(Divider8)
        Panel2.Controls.Add(Label2)
        Panel2.Cursor = Cursors.Hand
        Panel2.Location = New Point(329, 223)
        Panel2.Name = "Panel2"
        Panel2.Shadow = 15
        Panel2.ShadowOpacityAnimation = True
        Panel2.Size = New Size(235, 180)
        Panel2.TabIndex = 8
        Panel2.Text = "Panel2"
        ' 
        ' Label3
        ' 
        Label3.Font = New Font("Microsoft YaHei UI", 9.0F, FontStyle.Underline)
        Label3.ForeColor = Color.SteelBlue
        Label3.Location = New Point(37, 133)
        Label3.Name = "Label3"
        Label3.Size = New Size(75, 23)
        Label3.TabIndex = 6
        Label3.Text = "注册账号"
        ' 
        ' Checkbox1
        ' 
        Checkbox1.Location = New Point(118, 132)
        Checkbox1.Name = "Checkbox1"
        Checkbox1.Size = New Size(77, 23)
        Checkbox1.TabIndex = 5
        Checkbox1.Text = "记住密码"
        ' 
        ' InputPwd
        ' 
        InputPwd.Location = New Point(35, 97)
        InputPwd.MaxLength = 12
        InputPwd.Name = "InputPwd"
        InputPwd.PlaceholderText = "密码"
        InputPwd.PrefixSvg = ""
        InputPwd.PrefixText = ""
        InputPwd.Size = New Size(163, 33)
        InputPwd.TabIndex = 4
        InputPwd.UseSystemPasswordChar = True
        ' 
        ' InputUser
        ' 
        InputUser.Location = New Point(35, 62)
        InputUser.MaxLength = 12
        InputUser.Name = "InputUser"
        InputUser.PlaceholderText = "用户名"
        InputUser.PrefixSvg = ""
        InputUser.PrefixText = ""
        InputUser.Size = New Size(163, 33)
        InputUser.TabIndex = 3
        ' 
        ' Divider8
        ' 
        Divider8.Location = New Point(33, 44)
        Divider8.Name = "Divider8"
        Divider8.OrientationMargin = 0F
        Divider8.Size = New Size(116, 16)
        Divider8.TabIndex = 2
        Divider8.Text = ""
        ' 
        ' Label2
        ' 
        Label2.BackColor = Color.Transparent
        Label2.Font = New Font("Microsoft YaHei UI", 10.5F)
        Label2.Location = New Point(33, 20)
        Label2.Name = "Label2"
        Label2.Size = New Size(116, 33)
        Label2.TabIndex = 1
        Label2.Text = "登录信息"
        ' 
        ' Timer1
        ' 
        Timer1.Enabled = True
        Timer1.Interval = 1
        ' 
        ' PageHeader1
        ' 
        PageHeader1.Icon = CType(resources.GetObject("PageHeader1.Icon"), Image)
        PageHeader1.Location = New Point(2, 1)
        PageHeader1.Name = "PageHeader1"
        PageHeader1.ShowButton = True
        PageHeader1.Size = New Size(765, 23)
        PageHeader1.TabIndex = 9
        PageHeader1.Text = "Hello! Vacko Launcher"
        ' 
        ' MainForm
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 17.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(767, 479)
        Controls.Add(PageHeader1)
        Controls.Add(Panel2)
        Controls.Add(PanelTools)
        Controls.Add(Select2)
        Controls.Add(Panel1)
        Controls.Add(MainSettingPanel)
        Controls.Add(ManageVersionPanel)
        Controls.Add(DownloadVersionPanel)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MaximizeBox = False
        Mode = AntdUI.TAMode.Light
        Name = "MainForm"
        Resizable = False
        Text = "Hello Vacko Launcher"
        DownloadVersionPanel.ResumeLayout(False)
        ManageVersionPanel.ResumeLayout(False)
        MainSettingPanel.ResumeLayout(False)
        Panel1.ResumeLayout(False)
        PanelTools.ResumeLayout(False)
        Panel2.ResumeLayout(False)
        ResumeLayout(False)
    End Sub
    Friend WithEvents DownloadVersionPanel As AntdUI.Panel
    Friend WithEvents DownloadVersionLabel As AntdUI.Label
    Friend WithEvents Divider1 As AntdUI.Divider
    Friend WithEvents DownloadVersionImage As AntdUI.Image3D
    Friend WithEvents ManageVersionPanel As AntdUI.Panel
    Friend WithEvents ManageVersionImage3d As AntdUI.Image3D
    Friend WithEvents Divider2 As AntdUI.Divider
    Friend WithEvents ManageVersionLabel As AntdUI.Label
    Friend WithEvents MainSettingPanel As AntdUI.Panel
    Friend WithEvents SettingImage3d As AntdUI.Image3D
    Friend WithEvents Divider3 As AntdUI.Divider
    Friend WithEvents SettingLabel As AntdUI.Label
    Friend WithEvents Panel1 As AntdUI.Panel
    Friend WithEvents Select1 As AntdUI.Select
    Friend WithEvents Divider4 As AntdUI.Divider
    Friend WithEvents Label1 As AntdUI.Label
    Friend WithEvents Select2 As AntdUI.Select
    Friend WithEvents PanelTools As AntdUI.Panel
    Friend WithEvents ToolsImage3d As AntdUI.Image3D
    Friend WithEvents Divider5 As AntdUI.Divider
    Friend WithEvents LabelTools As AntdUI.Label
    Friend WithEvents RadioHVKLLogin As AntdUI.Radio
    Friend WithEvents RadioVackoLogin As AntdUI.Radio
    Friend WithEvents Divider7 As AntdUI.Divider
    Friend WithEvents Panel2 As AntdUI.Panel
    Friend WithEvents Divider8 As AntdUI.Divider
    Friend WithEvents Label2 As AntdUI.Label
    Friend WithEvents InputUser As AntdUI.Input
    Friend WithEvents Checkbox1 As AntdUI.Checkbox
    Friend WithEvents InputPwd As AntdUI.Input
    Friend WithEvents Label3 As AntdUI.Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents PageHeader1 As AntdUI.PageHeader

End Class
