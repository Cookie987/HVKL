<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MusicForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MusicForm))
        PageHeader1 = New AntdUI.PageHeader()
        Timer1 = New Timer(components)
        Image3d1 = New AntdUI.Image3D()
        Panel1 = New AntdUI.Panel()
        ChromiumWebBrowser1 = New CefSharp.WinForms.ChromiumWebBrowser()
        Label1 = New AntdUI.Label()
        VideoView1 = New LibVLCSharp.WinForms.VideoView()
        Panel2 = New AntdUI.Panel()
        SelectSpeed = New AntdUI.Select()
        Checkbox1 = New AntdUI.Checkbox()
        LblProgress = New AntdUI.Label()
        Button3 = New AntdUI.Button()
        VolSlider = New AntdUI.Slider()
        BtnNext = New AntdUI.Button()
        BtnPlayPause = New AntdUI.Button()
        Slider1 = New AntdUI.Slider()
        Button1 = New AntdUI.Button()
        Select1 = New AntdUI.Select()
        BtnPrevious = New AntdUI.Button()
        Button2 = New AntdUI.Button()
        BtnStop = New AntdUI.Button()
        Tree1 = New AntdUI.Tree()
        Panel3 = New AntdUI.Panel()
        Panel4 = New AntdUI.Panel()
        Label2 = New AntdUI.Label()
        Timer2 = New Timer(components)
        Timer3 = New Timer(components)
        Panel1.SuspendLayout()
        CType(VideoView1, ComponentModel.ISupportInitialize).BeginInit()
        Panel2.SuspendLayout()
        Panel3.SuspendLayout()
        Panel4.SuspendLayout()
        SuspendLayout()
        ' 
        ' PageHeader1
        ' 
        PageHeader1.Icon = CType(resources.GetObject("PageHeader1.Icon"), Image)
        PageHeader1.Location = New Point(0, 0)
        PageHeader1.Margin = New Padding(6, 5, 6, 5)
        PageHeader1.MaximizeBox = False
        PageHeader1.Name = "PageHeader1"
        PageHeader1.ShowButton = True
        PageHeader1.Size = New Size(1838, 42)
        PageHeader1.TabIndex = 11
        PageHeader1.Text = "音乐播放"
        ' 
        ' Timer1
        ' 
        ' 
        ' Image3d1
        ' 
        Image3d1.BackColor = Color.Transparent
        Image3d1.Location = New Point(506, 78)
        Image3d1.Margin = New Padding(6, 5, 6, 5)
        Image3d1.Name = "Image3d1"
        Image3d1.Size = New Size(420, 383)
        Image3d1.TabIndex = 21
        Image3d1.Text = "Image3d1"
        Image3d1.Visible = False
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(ChromiumWebBrowser1)
        Panel1.Controls.Add(Label1)
        Panel1.Location = New Point(0, 53)
        Panel1.Margin = New Padding(6, 5, 6, 5)
        Panel1.Name = "Panel1"
        Panel1.Shadow = 15
        Panel1.ShadowOpacityAnimation = True
        Panel1.Size = New Size(1838, 224)
        Panel1.TabIndex = 29
        Panel1.Text = "Panel1"
        ' 
        ' ChromiumWebBrowser1
        ' 
        ChromiumWebBrowser1.ActivateBrowserOnCreation = False
        ChromiumWebBrowser1.Location = New Point(42, 35)
        ChromiumWebBrowser1.Name = "ChromiumWebBrowser1"
        ChromiumWebBrowser1.Size = New Size(1763, 149)
        ChromiumWebBrowser1.TabIndex = 20
        ' 
        ' Label1
        ' 
        Label1.BackColor = Color.Transparent
        Label1.ColorExtend = ""
        Label1.Font = New Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(134))
        Label1.Location = New Point(42, 42)
        Label1.Margin = New Padding(6, 5, 6, 5)
        Label1.Name = "Label1"
        Label1.Shadow = 5
        Label1.ShadowColor = Color.Black
        Label1.ShadowOffsetX = 2
        Label1.ShadowOffsetY = 2
        Label1.ShadowOpacity = 0.2F
        Label1.Size = New Size(1753, 140)
        Label1.TabIndex = 19
        Label1.TabStop = False
        Label1.Text = "（歌词）"
        Label1.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' VideoView1
        ' 
        VideoView1.BackColor = Color.Black
        VideoView1.Location = New Point(1188, 221)
        VideoView1.Margin = New Padding(6, 5, 6, 5)
        VideoView1.MediaPlayer = Nothing
        VideoView1.Name = "VideoView1"
        VideoView1.Size = New Size(188, 100)
        VideoView1.TabIndex = 32
        VideoView1.Text = "VideoView1"
        VideoView1.Visible = False
        ' 
        ' Panel2
        ' 
        Panel2.Controls.Add(SelectSpeed)
        Panel2.Controls.Add(Checkbox1)
        Panel2.Controls.Add(LblProgress)
        Panel2.Controls.Add(Button3)
        Panel2.Controls.Add(VolSlider)
        Panel2.Controls.Add(BtnNext)
        Panel2.Controls.Add(BtnPlayPause)
        Panel2.Controls.Add(Slider1)
        Panel2.Controls.Add(Button1)
        Panel2.Controls.Add(Select1)
        Panel2.Controls.Add(BtnPrevious)
        Panel2.Controls.Add(Button2)
        Panel2.Controls.Add(BtnStop)
        Panel2.Location = New Point(378, 740)
        Panel2.Margin = New Padding(6, 5, 6, 5)
        Panel2.Name = "Panel2"
        Panel2.Shadow = 15
        Panel2.ShadowOpacityAnimation = True
        Panel2.Size = New Size(1460, 222)
        Panel2.TabIndex = 30
        Panel2.Text = "Panel2"
        ' 
        ' SelectSpeed
        ' 
        SelectSpeed.Items.AddRange(New Object() {"0.5x", "1.0x", "1.5x", "2.0x"})
        SelectSpeed.Location = New Point(1024, 104)
        SelectSpeed.Margin = New Padding(6, 5, 6, 5)
        SelectSpeed.Name = "SelectSpeed"
        SelectSpeed.Size = New Size(136, 64)
        SelectSpeed.TabIndex = 14
        ' 
        ' Checkbox1
        ' 
        Checkbox1.BackColor = Color.Transparent
        Checkbox1.Location = New Point(682, 117)
        Checkbox1.Margin = New Padding(6, 5, 6, 5)
        Checkbox1.Name = "Checkbox1"
        Checkbox1.Size = New Size(118, 42)
        Checkbox1.TabIndex = 13
        Checkbox1.Text = "置顶"
        ' 
        ' LblProgress
        ' 
        LblProgress.BackColor = Color.Transparent
        LblProgress.Location = New Point(1206, 49)
        LblProgress.Margin = New Padding(6, 5, 6, 5)
        LblProgress.Name = "LblProgress"
        LblProgress.Size = New Size(154, 42)
        LblProgress.TabIndex = 12
        LblProgress.Text = "00:00/00:00"
        ' 
        ' Button3
        ' 
        Button3.IconRatio = 1.2F
        Button3.IconSvg = resources.GetString("Button3.IconSvg")
        Button3.Location = New Point(428, 104)
        Button3.Margin = New Padding(6, 5, 6, 5)
        Button3.Name = "Button3"
        Button3.Size = New Size(78, 66)
        Button3.TabIndex = 7
        Button3.Type = AntdUI.TTypeMini.Primary
        ' 
        ' VolSlider
        ' 
        VolSlider.BackColor = Color.Transparent
        VolSlider.Location = New Point(506, 117)
        VolSlider.Margin = New Padding(6, 5, 6, 5)
        VolSlider.Name = "VolSlider"
        VolSlider.ShowValue = True
        VolSlider.Size = New Size(198, 42)
        VolSlider.TabIndex = 8
        VolSlider.Text = "Slider2"
        VolSlider.Value = 50
        ' 
        ' BtnNext
        ' 
        BtnNext.IconRatio = 1.2F
        BtnNext.IconSvg = "<svg xmlns=""http://www.w3.org/2000/svg"" viewBox=""0 0 24 24""><title>skip-next-outline</title><path d=""M6,18L14.5,12L6,6M8,9.86L11.03,12L8,14.14M16,6H18V18H16"" /></svg>"
        BtnNext.Location = New Point(338, 104)
        BtnNext.Margin = New Padding(6, 5, 6, 5)
        BtnNext.Name = "BtnNext"
        BtnNext.Size = New Size(78, 66)
        BtnNext.TabIndex = 6
        BtnNext.Type = AntdUI.TTypeMini.Primary
        ' 
        ' BtnPlayPause
        ' 
        BtnPlayPause.IconRatio = 1.2F
        BtnPlayPause.IconSvg = "<svg xmlns=""http://www.w3.org/2000/svg"" viewBox=""0 0 24 24""><title>play-outline</title><path d=""M8.5,8.64L13.77,12L8.5,15.36V8.64M6.5,5V19L17.5,12"" /></svg>"
        BtnPlayPause.Location = New Point(68, 104)
        BtnPlayPause.Margin = New Padding(6, 5, 6, 5)
        BtnPlayPause.Name = "BtnPlayPause"
        BtnPlayPause.Size = New Size(78, 66)
        BtnPlayPause.TabIndex = 3
        BtnPlayPause.Type = AntdUI.TTypeMini.Primary
        ' 
        ' Slider1
        ' 
        Slider1.BackColor = Color.Transparent
        Slider1.LineSize = 6
        Slider1.Location = New Point(56, 42)
        Slider1.Margin = New Padding(6, 5, 6, 5)
        Slider1.MaxValue = 1000
        Slider1.Name = "Slider1"
        Slider1.Size = New Size(1158, 60)
        Slider1.TabIndex = 2
        Slider1.Text = "Slider1"
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(912, 102)
        Button1.Margin = New Padding(6, 5, 6, 5)
        Button1.Name = "Button1"
        Button1.Size = New Size(110, 66)
        Button1.TabIndex = 10
        Button1.Text = "刷新"
        Button1.Type = AntdUI.TTypeMini.Primary
        ' 
        ' Select1
        ' 
        Select1.Items.AddRange(New Object() {"单曲循环", "列表循环", "随机播放"})
        Select1.Location = New Point(1172, 104)
        Select1.Margin = New Padding(6, 5, 6, 5)
        Select1.Name = "Select1"
        Select1.Size = New Size(176, 64)
        Select1.TabIndex = 11
        ' 
        ' BtnPrevious
        ' 
        BtnPrevious.IconRatio = 1.2F
        BtnPrevious.IconSvg = "<svg xmlns=""http://www.w3.org/2000/svg"" viewBox=""0 0 24 24""><title>skip-previous-outline</title><path d=""M6,6H8V18H6M9.5,12L18,18V6M16,14.14L12.97,12L16,9.86V14.14Z"" /></svg>"
        BtnPrevious.Location = New Point(248, 104)
        BtnPrevious.Margin = New Padding(6, 5, 6, 5)
        BtnPrevious.Name = "BtnPrevious"
        BtnPrevious.Size = New Size(78, 66)
        BtnPrevious.TabIndex = 5
        BtnPrevious.Type = AntdUI.TTypeMini.Primary
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(794, 102)
        Button2.Margin = New Padding(6, 5, 6, 5)
        Button2.Name = "Button2"
        Button2.Size = New Size(114, 66)
        Button2.TabIndex = 9
        Button2.Text = "管理"
        Button2.Type = AntdUI.TTypeMini.Primary
        ' 
        ' BtnStop
        ' 
        BtnStop.IconRatio = 1.2F
        BtnStop.IconSvg = "<svg xmlns=""http://www.w3.org/2000/svg"" viewBox=""0 0 24 24""><title>stop</title><path d=""M18,18H6V6H18V18Z"" /></svg>"
        BtnStop.Location = New Point(158, 104)
        BtnStop.Margin = New Padding(6, 5, 6, 5)
        BtnStop.Name = "BtnStop"
        BtnStop.Size = New Size(78, 66)
        BtnStop.TabIndex = 4
        BtnStop.Type = AntdUI.TTypeMini.Primary
        ' 
        ' Tree1
        ' 
        Tree1.BackColor = Color.Transparent
        Tree1.BlockNode = True
        Tree1.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(134))
        Tree1.Gap = 3
        Tree1.Location = New Point(42, 42)
        Tree1.Margin = New Padding(6, 5, 6, 5)
        Tree1.Name = "Tree1"
        Tree1.Radius = 10
        Tree1.Size = New Size(314, 624)
        Tree1.TabIndex = 1
        Tree1.Text = "Tree1"
        ' 
        ' Panel3
        ' 
        Panel3.Controls.Add(Tree1)
        Panel3.Location = New Point(0, 261)
        Panel3.Margin = New Padding(6, 5, 6, 5)
        Panel3.Name = "Panel3"
        Panel3.Shadow = 15
        Panel3.ShadowOpacityAnimation = True
        Panel3.Size = New Size(398, 702)
        Panel3.TabIndex = 34
        Panel3.Text = "Panel3"
        ' 
        ' Panel4
        ' 
        Panel4.Controls.Add(Image3d1)
        Panel4.Controls.Add(VideoView1)
        Panel4.Controls.Add(Label2)
        Panel4.Location = New Point(378, 261)
        Panel4.Margin = New Padding(6, 5, 6, 5)
        Panel4.Name = "Panel4"
        Panel4.Shadow = 15
        Panel4.ShadowOpacityAnimation = True
        Panel4.Size = New Size(1460, 509)
        Panel4.TabIndex = 35
        Panel4.Text = "Panel4"
        ' 
        ' Label2
        ' 
        Label2.BackColor = Color.Transparent
        Label2.Location = New Point(56, 42)
        Label2.Margin = New Padding(6, 5, 6, 5)
        Label2.Name = "Label2"
        Label2.Size = New Size(1320, 49)
        Label2.TabIndex = 22
        Label2.Text = "未知"
        Label2.TextAlign = ContentAlignment.TopCenter
        ' 
        ' Timer2
        ' 
        ' 
        ' Timer3
        ' 
        Timer3.Interval = 1000
        ' 
        ' MusicForm
        ' 
        AutoScaleDimensions = New SizeF(14F, 31F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1838, 970)
        Controls.Add(Panel4)
        Controls.Add(Panel3)
        Controls.Add(Panel2)
        Controls.Add(PageHeader1)
        Controls.Add(Panel1)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Margin = New Padding(6, 5, 6, 5)
        Name = "MusicForm"
        Text = "MusicForm"
        Panel1.ResumeLayout(False)
        CType(VideoView1, ComponentModel.ISupportInitialize).EndInit()
        Panel2.ResumeLayout(False)
        Panel3.ResumeLayout(False)
        Panel4.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents PageHeader1 As AntdUI.PageHeader
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Image3d1 As AntdUI.Image3D
    Friend WithEvents Panel1 As AntdUI.Panel
    Friend WithEvents Label1 As AntdUI.Label
    Friend WithEvents Panel2 As AntdUI.Panel
    Friend WithEvents BtnNext As AntdUI.Button
    Friend WithEvents BtnPlayPause As AntdUI.Button
    Friend WithEvents VideoView1 As LibVLCSharp.WinForms.VideoView
    Friend WithEvents Slider1 As AntdUI.Slider
    Friend WithEvents Button1 As AntdUI.Button
    Friend WithEvents Select1 As AntdUI.Select
    Friend WithEvents BtnPrevious As AntdUI.Button
    Friend WithEvents Button2 As AntdUI.Button
    Friend WithEvents BtnStop As AntdUI.Button
    Friend WithEvents Tree1 As AntdUI.Tree
    Friend WithEvents Panel3 As AntdUI.Panel
    Friend WithEvents Panel4 As AntdUI.Panel
    Friend WithEvents VolSlider As AntdUI.Slider
    Friend WithEvents Timer2 As Timer
    Friend WithEvents Button3 As AntdUI.Button
    Friend WithEvents Timer3 As Timer
    Friend WithEvents LblProgress As AntdUI.Label
    Friend WithEvents Checkbox1 As AntdUI.Checkbox
    Friend WithEvents Label2 As AntdUI.Label
    Friend WithEvents SelectSpeed As AntdUI.Select
    Friend WithEvents ChromiumWebBrowser1 As CefSharp.WinForms.ChromiumWebBrowser
End Class
