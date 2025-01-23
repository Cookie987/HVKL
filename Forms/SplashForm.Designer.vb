<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SplashForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SplashForm))
        Image3d1 = New AntdUI.Image3D()
        Panel1 = New AntdUI.Panel()
        Label1 = New AntdUI.Label()
        Label2 = New AntdUI.Label()
        Image3d2 = New AntdUI.Image3D()
        Label3 = New AntdUI.Label()
        Image3d3 = New AntdUI.Image3D()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Image3d1
        ' 
        Image3d1.Back = Color.FromArgb(CByte(0), CByte(32), CByte(57))
        Image3d1.Image = CType(resources.GetObject("Image3d1.Image"), Image)
        Image3d1.Location = New Point(8, 7)
        Image3d1.Name = "Image3d1"
        Image3d1.Size = New Size(50, 49)
        Image3d1.TabIndex = 0
        Image3d1.Text = "Image3d1"
        ' 
        ' Panel1
        ' 
        Panel1.Back = Color.FromArgb(CByte(0), CByte(32), CByte(57))
        Panel1.Controls.Add(Image3d1)
        Panel1.Location = New Point(35, 31)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(64, 64)
        Panel1.TabIndex = 1
        Panel1.Text = "Panel1"
        ' 
        ' Label1
        ' 
        Label1.Font = New Font("Trebuchet MS", 15.75F, FontStyle.Bold)
        Label1.ForeColor = Color.FromArgb(CByte(0), CByte(32), CByte(57))
        Label1.Location = New Point(106, 52)
        Label1.Name = "Label1"
        Label1.Size = New Size(234, 23)
        Label1.TabIndex = 2
        Label1.Text = "Hello! Vacko Launcher"
        ' 
        ' Label2
        ' 
        Label2.ForeColor = SystemColors.GrayText
        Label2.Location = New Point(36, 169)
        Label2.Name = "Label2"
        Label2.Size = New Size(286, 71)
        Label2.TabIndex = 3
        Label2.Text = "HVKL 为 Vacko 授权的的启动器。" & vbCrLf & "Vacko™ 是 Lemon Studio 的商标。" & vbCrLf & "©2025 RedCookieStudios. All rights reserved."
        Label2.TextAlign = ContentAlignment.TopLeft
        ' 
        ' Image3d2
        ' 
        Image3d2.Image = CType(resources.GetObject("Image3d2.Image"), Image)
        Image3d2.Location = New Point(-8, 334)
        Image3d2.Name = "Image3d2"
        Image3d2.Size = New Size(177, 94)
        Image3d2.TabIndex = 4
        Image3d2.Text = "Image3d2"
        ' 
        ' Label3
        ' 
        Label3.ForeColor = SystemColors.GrayText
        Label3.Location = New Point(36, 236)
        Label3.Name = "Label3"
        Label3.Size = New Size(286, 71)
        Label3.TabIndex = 5
        Label3.Text = "启动中"
        Label3.TextAlign = ContentAlignment.TopLeft
        ' 
        ' Image3d3
        ' 
        Image3d3.Image = My.Resources.Resource1.WinterBox
        Image3d3.Location = New Point(346, 31)
        Image3d3.Name = "Image3d3"
        Image3d3.Radius = 10
        Image3d3.Size = New Size(347, 394)
        Image3d3.Speed = 20
        Image3d3.TabIndex = 6
        Image3d3.Text = "Image3d3"
        ' 
        ' SplashForm
        ' 
        AutoScaleDimensions = New SizeF(7F, 17F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(705, 443)
        Controls.Add(Image3d3)
        Controls.Add(Label3)
        Controls.Add(Image3d2)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(Panel1)
        Name = "SplashForm"
        Resizable = False
        StartPosition = FormStartPosition.CenterScreen
        Text = "SplashForm"
        Panel1.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents Image3d1 As AntdUI.Image3D
    Friend WithEvents Panel1 As AntdUI.Panel
    Friend WithEvents Label1 As AntdUI.Label
    Friend WithEvents Label2 As AntdUI.Label
    Friend WithEvents Image3d2 As AntdUI.Image3D
    Friend WithEvents Label3 As AntdUI.Label
    Friend WithEvents Image3d3 As AntdUI.Image3D
End Class
