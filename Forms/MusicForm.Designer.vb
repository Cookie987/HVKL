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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MusicForm))
        PageHeader1 = New AntdUI.PageHeader()
        cmbMp3Files = New AntdUI.Select()
        Label1 = New AntdUI.Label()
        AxWindowsMediaPlayer2 = New AxWMPLib.AxWindowsMediaPlayer()
        Button1 = New AntdUI.Button()
        Label2 = New AntdUI.Label()
        CType(AxWindowsMediaPlayer2, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' PageHeader1
        ' 
        PageHeader1.Icon = CType(resources.GetObject("PageHeader1.Icon"), Image)
        PageHeader1.Location = New Point(0, 0)
        PageHeader1.MaximizeBox = False
        PageHeader1.Name = "PageHeader1"
        PageHeader1.ShowButton = True
        PageHeader1.Size = New Size(801, 23)
        PageHeader1.TabIndex = 11
        PageHeader1.Text = "音乐管理"
        ' 
        ' cmbMp3Files
        ' 
        cmbMp3Files.Location = New Point(495, 29)
        cmbMp3Files.Name = "cmbMp3Files"
        cmbMp3Files.Size = New Size(293, 35)
        cmbMp3Files.TabIndex = 17
        ' 
        ' Label1
        ' 
        Label1.Font = New Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(134))
        Label1.Location = New Point(12, 29)
        Label1.Name = "Label1"
        Label1.Shadow = 5
        Label1.ShadowOffsetX = 2
        Label1.ShadowOffsetY = 2
        Label1.ShadowOpacity = 0.2F
        Label1.Size = New Size(429, 45)
        Label1.TabIndex = 18
        Label1.TabStop = False
        Label1.Text = "（歌词）"
        ' 
        ' AxWindowsMediaPlayer2
        ' 
        AxWindowsMediaPlayer2.Enabled = True
        AxWindowsMediaPlayer2.Location = New Point(0, 80)
        AxWindowsMediaPlayer2.Name = "AxWindowsMediaPlayer2"
        AxWindowsMediaPlayer2.OcxState = CType(resources.GetObject("AxWindowsMediaPlayer2.OcxState"), AxHost.State)
        AxWindowsMediaPlayer2.Size = New Size(801, 370)
        AxWindowsMediaPlayer2.TabIndex = 19
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(447, 28)
        Button1.Name = "Button1"
        Button1.Size = New Size(42, 36)
        Button1.TabIndex = 3
        Button1.Text = "刷新"
        Button1.Type = AntdUI.TTypeMini.Primary
        ' 
        ' Label2
        ' 
        Label2.Font = New Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(134))
        Label2.Location = New Point(12, 80)
        Label2.Name = "Label2"
        Label2.Shadow = 5
        Label2.ShadowOffsetX = 2
        Label2.ShadowOffsetY = 2
        Label2.ShadowOpacity = 0.2F
        Label2.Size = New Size(429, 45)
        Label2.TabIndex = 20
        Label2.TabStop = False
        Label2.Text = "（歌词）"
        ' 
        ' MusicForm
        ' 
        AutoScaleDimensions = New SizeF(7F, 17F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(PageHeader1)
        Controls.Add(AxWindowsMediaPlayer2)
        Controls.Add(Label2)
        Controls.Add(Button1)
        Controls.Add(Label1)
        Controls.Add(cmbMp3Files)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Name = "MusicForm"
        Text = "MusicForm"
        CType(AxWindowsMediaPlayer2, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents PageHeader1 As AntdUI.PageHeader
    Friend WithEvents cmbMp3Files As AntdUI.Select
    Friend WithEvents Label1 As AntdUI.Label
    Friend WithEvents AxWindowsMediaPlayer1 As AxWMPLib.AxWindowsMediaPlayer
    Friend WithEvents AxWindowsMediaPlayer2 As AxWMPLib.AxWindowsMediaPlayer
    Friend WithEvents Button1 As AntdUI.Button
    Friend WithEvents Label2 As AntdUI.Label
End Class
