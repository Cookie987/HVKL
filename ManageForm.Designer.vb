﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ManageForm
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
        Select1 = New AntdUI.Select()
        Button1 = New AntdUI.Button()
        WindowBar1 = New AntdUI.WindowBar()
        SettingPanel = New AntdUI.Panel()
        InputDirName = New AntdUI.Input()
        Label4 = New AntdUI.Label()
        Button3 = New AntdUI.Button()
        Label3 = New AntdUI.Label()
        Label2 = New AntdUI.Label()
        Button2 = New AntdUI.Button()
        InputVersionName = New AntdUI.Input()
        Label1 = New AntdUI.Label()
        Select2 = New AntdUI.Select()
        SettingPanel.SuspendLayout()
        SuspendLayout()
        ' 
        ' Select1
        ' 
        Select1.Location = New Point(35, 31)
        Select1.Name = "Select1"
        Select1.Size = New Size(450, 34)
        Select1.TabIndex = 7
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(355, 24)
        Button1.Name = "Button1"
        Button1.Size = New Size(96, 35)
        Button1.TabIndex = 6
        Button1.Text = "删除版本"
        Button1.Type = AntdUI.TTypeMini.Error
        ' 
        ' WindowBar1
        ' 
        WindowBar1.IsMax = False
        WindowBar1.Location = New Point(0, 1)
        WindowBar1.MaximizeBox = False
        WindowBar1.MinimizeBox = False
        WindowBar1.Name = "WindowBar1"
        WindowBar1.Size = New Size(509, 23)
        WindowBar1.TabIndex = 4
        WindowBar1.Text = "版本管理"
        ' 
        ' SettingPanel
        ' 
        SettingPanel.BackColor = Color.Transparent
        SettingPanel.BorderWidth = 1F
        SettingPanel.Controls.Add(Select2)
        SettingPanel.Controls.Add(InputDirName)
        SettingPanel.Controls.Add(Label4)
        SettingPanel.Controls.Add(Button3)
        SettingPanel.Controls.Add(Label3)
        SettingPanel.Controls.Add(Label2)
        SettingPanel.Controls.Add(Button2)
        SettingPanel.Controls.Add(InputVersionName)
        SettingPanel.Controls.Add(Label1)
        SettingPanel.Controls.Add(Button1)
        SettingPanel.Location = New Point(23, 57)
        SettingPanel.Name = "SettingPanel"
        SettingPanel.Shadow = 15
        SettingPanel.ShadowOpacityAnimation = True
        SettingPanel.Size = New Size(474, 167)
        SettingPanel.TabIndex = 9
        SettingPanel.Text = "Panel2"
        SettingPanel.Visible = False
        ' 
        ' InputDirName
        ' 
        InputDirName.Location = New Point(87, 108)
        InputDirName.Name = "InputDirName"
        InputDirName.Size = New Size(149, 31)
        InputDirName.TabIndex = 12
        ' 
        ' Label4
        ' 
        Label4.Location = New Point(29, 113)
        Label4.Name = "Label4"
        Label4.Size = New Size(70, 23)
        Label4.TabIndex = 11
        Label4.Text = "目录名称："
        ' 
        ' Button3
        ' 
        Button3.Location = New Point(355, 57)
        Button3.Name = "Button3"
        Button3.Size = New Size(96, 35)
        Button3.TabIndex = 10
        Button3.Text = "更换版本"
        Button3.Type = AntdUI.TTypeMini.Warn
        ' 
        ' Label3
        ' 
        Label3.Location = New Point(29, 86)
        Label3.Name = "Label3"
        Label3.Size = New Size(221, 23)
        Label3.TabIndex = 9
        Label3.Text = "上次启动："
        ' 
        ' Label2
        ' 
        Label2.Location = New Point(29, 59)
        Label2.Name = "Label2"
        Label2.Size = New Size(221, 23)
        Label2.TabIndex = 8
        Label2.Text = "Vacko版本："
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(355, 91)
        Button2.Name = "Button2"
        Button2.Size = New Size(96, 35)
        Button2.TabIndex = 7
        Button2.Text = "保存更改"
        Button2.Type = AntdUI.TTypeMini.Primary
        ' 
        ' InputVersionName
        ' 
        InputVersionName.Location = New Point(62, 25)
        InputVersionName.Name = "InputVersionName"
        InputVersionName.Size = New Size(149, 31)
        InputVersionName.TabIndex = 4
        ' 
        ' Label1
        ' 
        Label1.Location = New Point(29, 29)
        Label1.Name = "Label1"
        Label1.Size = New Size(43, 23)
        Label1.TabIndex = 3
        Label1.Text = "名称："
        ' 
        ' Select2
        ' 
        Select2.Location = New Point(97, 0)
        Select2.Name = "Select2"
        Select2.Size = New Size(75, 23)
        Select2.TabIndex = 10
        Select2.Text = "Select2"
        Select2.Visible = False
        ' 
        ' ManageForm
        ' 
        AutoScaleDimensions = New SizeF(7F, 17F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(511, 223)
        Controls.Add(Select1)
        Controls.Add(SettingPanel)
        Controls.Add(WindowBar1)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Name = "ManageForm"
        Resizable = False
        Text = "ManageForm"
        SettingPanel.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents Select1 As AntdUI.Select
    Friend WithEvents Button1 As AntdUI.Button
    Friend WithEvents WindowBar1 As AntdUI.WindowBar
    Friend WithEvents SettingPanel As AntdUI.Panel
    Friend WithEvents Divider3 As AntdUI.Divider
    Friend WithEvents SettingLabel As AntdUI.Label
    Friend WithEvents InputVersionName As AntdUI.Input
    Friend WithEvents Label1 As AntdUI.Label
    Friend WithEvents Button2 As AntdUI.Button
    Friend WithEvents Select2 As AntdUI.Select
    Friend WithEvents Label2 As AntdUI.Label
    Friend WithEvents Label3 As AntdUI.Label
    Friend WithEvents Button3 As AntdUI.Button
    Friend WithEvents Label4 As AntdUI.Label
    Friend WithEvents InputDirName As AntdUI.Input
End Class
