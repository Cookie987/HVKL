<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
    Inherits System.Windows.Forms.Form

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
        WindowBar1 = New AntdUI.WindowBar()
        ButtonStartGame = New AntdUI.Button()
        Panel1 = New AntdUI.Panel()
        Label2 = New AntdUI.Label()
        Label1 = New AntdUI.Label()
        ButtonSetting = New AntdUI.Button()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' WindowBar1
        ' 
        WindowBar1.Location = New Point(2, 0)
        WindowBar1.MaximizeBox = False
        WindowBar1.Name = "WindowBar1"
        WindowBar1.Size = New Size(798, 23)
        WindowBar1.TabIndex = 0
        WindowBar1.Text = "Hello Vacko Launcher"
        ' 
        ' ButtonStartGame
        ' 
        ButtonStartGame.Font = New Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point)
        ButtonStartGame.Location = New Point(623, 388)
        ButtonStartGame.Name = "ButtonStartGame"
        ButtonStartGame.Size = New Size(152, 66)
        ButtonStartGame.TabIndex = 1
        ButtonStartGame.Text = "启动游戏"
        ButtonStartGame.Type = AntdUI.TTypeMini.Primary
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(Label2)
        Panel1.Controls.Add(Label1)
        Panel1.Location = New Point(120, 31)
        Panel1.Name = "Panel1"
        Panel1.Shadow = 6
        Panel1.ShadowOpacityAnimation = True
        Panel1.Size = New Size(655, 351)
        Panel1.TabIndex = 2
        Panel1.Text = "Panel1"
        ' 
        ' Label2
        ' 
        Label2.Font = New Font("Microsoft YaHei UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point)
        Label2.Location = New Point(31, 64)
        Label2.Name = "Label2"
        Label2.Size = New Size(323, 33)
        Label2.TabIndex = 1
        Label2.Text = "一个更好的 Vacko2 启动器"
        ' 
        ' Label1
        ' 
        Label1.Font = New Font("Microsoft YaHei UI", 18F, FontStyle.Bold, GraphicsUnit.Point)
        Label1.Location = New Point(19, 20)
        Label1.Name = "Label1"
        Label1.Size = New Size(422, 48)
        Label1.TabIndex = 0
        Label1.Text = "欢迎使用 Hello Vacko Launcher"
        ' 
        ' ButtonSetting
        ' 
        ButtonSetting.Location = New Point(6, 38)
        ButtonSetting.Name = "ButtonSetting"
        ButtonSetting.Size = New Size(110, 32)
        ButtonSetting.TabIndex = 3
        ButtonSetting.Text = "设置"
        ' 
        ' MainForm
        ' 
        AutoScaleDimensions = New SizeF(7F, 17F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(800, 466)
        Controls.Add(ButtonSetting)
        Controls.Add(Panel1)
        Controls.Add(ButtonStartGame)
        Controls.Add(WindowBar1)
        FormBorderStyle = FormBorderStyle.None
        MaximizeBox = False
        Name = "MainForm"
        Text = "Hello Vacko Launcher"
        Panel1.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents WindowBar1 As AntdUI.WindowBar
    Friend WithEvents ButtonStartGame As AntdUI.Button
    Friend WithEvents Panel1 As AntdUI.Panel
    Friend WithEvents Label1 As AntdUI.Label
    Friend WithEvents Label2 As AntdUI.Label
    Friend WithEvents ButtonSetting As AntdUI.Button

End Class
