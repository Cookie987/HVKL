<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VackoSettings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VackoSettings))
        SwitchConvenience2 = New AntdUI.Switch()
        Label3 = New AntdUI.Label()
        Label2 = New AntdUI.Label()
        SwitchConvenience1 = New AntdUI.Switch()
        Label5 = New AntdUI.Label()
        Divider1 = New AntdUI.Divider()
        PageHeader1 = New AntdUI.PageHeader()
        Label1 = New AntdUI.Label()
        Divider2 = New AntdUI.Divider()
        Panel2 = New AntdUI.Panel()
        Label6 = New AntdUI.Label()
        Panel1 = New AntdUI.Panel()
        InputNumber1 = New AntdUI.InputNumber()
        RadioDefault = New AntdUI.Radio()
        RadioSystem = New AntdUI.Radio()
        RadioCustom = New AntdUI.Radio()
        Label4 = New AntdUI.Label()
        ButtonSave = New AntdUI.Button()
        ButtonApply = New AntdUI.Button()
        ButtonCancel = New AntdUI.Button()
        RichTextBox1 = New RichTextBox()
        Panel2.SuspendLayout()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' SwitchConvenience2
        ' 
        SwitchConvenience2.BackColor = Color.Transparent
        SwitchConvenience2.Location = New Point(285, 89)
        SwitchConvenience2.Name = "SwitchConvenience2"
        SwitchConvenience2.Size = New Size(41, 23)
        SwitchConvenience2.TabIndex = 6
        SwitchConvenience2.Text = "拥有免密登录次数时,直接登录"
        ' 
        ' Label3
        ' 
        Label3.BackColor = Color.Transparent
        Label3.Location = New Point(41, 90)
        Label3.Name = "Label3"
        Label3.Size = New Size(219, 23)
        Label3.TabIndex = 5
        Label3.Text = "更新器检测完毕时，总是直接启动游戏"
        ' 
        ' Label2
        ' 
        Label2.BackColor = Color.Transparent
        Label2.Location = New Point(41, 62)
        Label2.Name = "Label2"
        Label2.Size = New Size(196, 23)
        Label2.TabIndex = 4
        Label2.Text = "拥有免密登录次数时，直接登录"
        ' 
        ' SwitchConvenience1
        ' 
        SwitchConvenience1.BackColor = Color.Transparent
        SwitchConvenience1.Location = New Point(285, 60)
        SwitchConvenience1.Name = "SwitchConvenience1"
        SwitchConvenience1.Size = New Size(41, 23)
        SwitchConvenience1.TabIndex = 3
        SwitchConvenience1.Text = "拥有免密登录次数时,直接登录"
        ' 
        ' Label5
        ' 
        Label5.BackColor = Color.Transparent
        Label5.Font = New Font("Microsoft YaHei UI", 10.5F)
        Label5.Location = New Point(31, 22)
        Label5.Name = "Label5"
        Label5.Size = New Size(171, 33)
        Label5.TabIndex = 1
        Label5.Text = ChrW(8221) & "便利性" & ChrW(8220)
        ' 
        ' Divider1
        ' 
        Divider1.BackColor = Color.Transparent
        Divider1.Location = New Point(30, 47)
        Divider1.Name = "Divider1"
        Divider1.OrientationMargin = 0F
        Divider1.Size = New Size(63, 16)
        Divider1.TabIndex = 2
        Divider1.Text = ""
        ' 
        ' PageHeader1
        ' 
        PageHeader1.Icon = CType(resources.GetObject("PageHeader1.Icon"), Image)
        PageHeader1.Location = New Point(1, 0)
        PageHeader1.MaximizeBox = False
        PageHeader1.Name = "PageHeader1"
        PageHeader1.ShowButton = True
        PageHeader1.Size = New Size(705, 23)
        PageHeader1.TabIndex = 11
        PageHeader1.Text = "Vacko 设置"
        ' 
        ' Label1
        ' 
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Microsoft YaHei UI", 10.5F)
        Label1.Location = New Point(31, 22)
        Label1.Name = "Label1"
        Label1.Size = New Size(171, 33)
        Label1.TabIndex = 1
        Label1.Text = ChrW(8221) & "个性化" & ChrW(8220)
        ' 
        ' Divider2
        ' 
        Divider2.BackColor = Color.Transparent
        Divider2.Location = New Point(31, 47)
        Divider2.Name = "Divider2"
        Divider2.OrientationMargin = 0F
        Divider2.Size = New Size(63, 16)
        Divider2.TabIndex = 2
        Divider2.Text = ""
        ' 
        ' Panel2
        ' 
        Panel2.Controls.Add(Divider1)
        Panel2.Controls.Add(SwitchConvenience1)
        Panel2.Controls.Add(Label3)
        Panel2.Controls.Add(Label2)
        Panel2.Controls.Add(SwitchConvenience2)
        Panel2.Controls.Add(Label5)
        Panel2.Location = New Point(12, 33)
        Panel2.Name = "Panel2"
        Panel2.Shadow = 15
        Panel2.Size = New Size(370, 146)
        Panel2.TabIndex = 14
        Panel2.Text = "Panel2"
        ' 
        ' Label6
        ' 
        Label6.BackColor = Color.Transparent
        Label6.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(134))
        Label6.ForeColor = Color.Gray
        Label6.Location = New Point(10, 21)
        Label6.Name = "Label6"
        Label6.Size = New Size(410, 23)
        Label6.TabIndex = 7
        Label6.Text = "本页为方便对照，所有设置说明基本均为Vacko官方说法."
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(InputNumber1)
        Panel1.Controls.Add(RadioDefault)
        Panel1.Controls.Add(RadioSystem)
        Panel1.Controls.Add(RadioCustom)
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(Divider2)
        Panel1.Controls.Add(Label4)
        Panel1.Location = New Point(388, 33)
        Panel1.Name = "Panel1"
        Panel1.Shadow = 15
        Panel1.Size = New Size(304, 266)
        Panel1.TabIndex = 15
        Panel1.Text = "Panel1"
        ' 
        ' InputNumber1
        ' 
        InputNumber1.Location = New Point(189, 114)
        InputNumber1.MaxLength = 2
        InputNumber1.Name = "InputNumber1"
        InputNumber1.Size = New Size(50, 32)
        InputNumber1.TabIndex = 13
        InputNumber1.Text = "0"
        ' 
        ' RadioDefault
        ' 
        RadioDefault.BackColor = Color.Transparent
        RadioDefault.Location = New Point(56, 147)
        RadioDefault.Name = "RadioDefault"
        RadioDefault.Size = New Size(127, 23)
        RadioDefault.TabIndex = 12
        RadioDefault.Text = "默认规则"
        ' 
        ' RadioSystem
        ' 
        RadioSystem.BackColor = Color.Transparent
        RadioSystem.Location = New Point(56, 118)
        RadioSystem.Name = "RadioSystem"
        RadioSystem.Size = New Size(127, 23)
        RadioSystem.TabIndex = 11
        RadioSystem.Text = "系统自带渐变规则"
        ' 
        ' RadioCustom
        ' 
        RadioCustom.BackColor = Color.Transparent
        RadioCustom.Location = New Point(56, 89)
        RadioCustom.Name = "RadioCustom"
        RadioCustom.Size = New Size(127, 23)
        RadioCustom.TabIndex = 10
        RadioCustom.Text = "自定义渐变规则"
        ' 
        ' Label4
        ' 
        Label4.BackColor = Color.Transparent
        Label4.Location = New Point(34, 62)
        Label4.Name = "Label4"
        Label4.Size = New Size(219, 23)
        Label4.TabIndex = 7
        Label4.Text = "进度条颜色："
        ' 
        ' ButtonSave
        ' 
        ButtonSave.Location = New Point(444, 289)
        ButtonSave.Name = "ButtonSave"
        ButtonSave.Size = New Size(75, 35)
        ButtonSave.TabIndex = 16
        ButtonSave.Text = "保存"
        ButtonSave.Type = AntdUI.TTypeMini.Primary
        ' 
        ' ButtonApply
        ' 
        ButtonApply.Location = New Point(525, 289)
        ButtonApply.Name = "ButtonApply"
        ButtonApply.Size = New Size(75, 35)
        ButtonApply.TabIndex = 17
        ButtonApply.Text = "应用"
        ButtonApply.Type = AntdUI.TTypeMini.Primary
        ' 
        ' ButtonCancel
        ' 
        ButtonCancel.Location = New Point(606, 289)
        ButtonCancel.Name = "ButtonCancel"
        ButtonCancel.Size = New Size(75, 35)
        ButtonCancel.TabIndex = 18
        ButtonCancel.Text = "取消"
        ButtonCancel.Type = AntdUI.TTypeMini.Primary
        ' 
        ' RichTextBox1
        ' 
        RichTextBox1.BackColor = SystemColors.InfoText
        RichTextBox1.BorderStyle = BorderStyle.FixedSingle
        RichTextBox1.Location = New Point(28, 185)
        RichTextBox1.Name = "RichTextBox1"
        RichTextBox1.ReadOnly = True
        RichTextBox1.Size = New Size(337, 102)
        RichTextBox1.TabIndex = 19
        RichTextBox1.Text = ""
        ' 
        ' VackoSettings
        ' 
        AutoScaleDimensions = New SizeF(7F, 17F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(704, 338)
        Controls.Add(Label6)
        Controls.Add(RichTextBox1)
        Controls.Add(ButtonCancel)
        Controls.Add(ButtonApply)
        Controls.Add(ButtonSave)
        Controls.Add(Panel1)
        Controls.Add(PageHeader1)
        Controls.Add(Panel2)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Name = "VackoSettings"
        Text = "VackoSettings"
        Panel2.ResumeLayout(False)
        Panel1.ResumeLayout(False)
        ResumeLayout(False)
    End Sub
    Friend WithEvents PageHeader1 As AntdUI.PageHeader
    Friend WithEvents Label5 As AntdUI.Label
    Friend WithEvents Divider1 As AntdUI.Divider
    Friend WithEvents Label1 As AntdUI.Label
    Friend WithEvents Divider2 As AntdUI.Divider
    Friend WithEvents SwitchConvenience2 As AntdUI.Switch
    Friend WithEvents Label3 As AntdUI.Label
    Friend WithEvents Label2 As AntdUI.Label
    Friend WithEvents SwitchConvenience1 As AntdUI.Switch
    Friend WithEvents Panel2 As AntdUI.Panel
    Friend WithEvents Panel1 As AntdUI.Panel
    Friend WithEvents Label4 As AntdUI.Label
    Friend WithEvents ButtonSave As AntdUI.Button
    Friend WithEvents ButtonApply As AntdUI.Button
    Friend WithEvents ButtonCancel As AntdUI.Button
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents RadioCustom As AntdUI.Radio
    Friend WithEvents RadioSystem As AntdUI.Radio
    Friend WithEvents Label6 As AntdUI.Label
    Friend WithEvents InputNumber1 As AntdUI.InputNumber
    Friend WithEvents RadioDefault As AntdUI.Radio
End Class
