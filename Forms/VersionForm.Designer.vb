﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VersionForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VersionForm))
        Button1 = New AntdUI.Button()
        Select1 = New AntdUI.Select()
        Progress1 = New AntdUI.Progress()
        PageHeader1 = New AntdUI.PageHeader()
        SuspendLayout()
        ' 
        ' Button1
        ' 
        Button1.Enabled = False
        Button1.Location = New Point(368, 29)
        Button1.Name = "Button1"
        Button1.Size = New Size(114, 35)
        Button1.TabIndex = 2
        Button1.Text = "安装版本"
        Button1.Type = AntdUI.TTypeMini.Primary
        ' 
        ' Select1
        ' 
        Select1.Location = New Point(38, 30)
        Select1.Name = "Select1"
        Select1.Size = New Size(324, 34)
        Select1.TabIndex = 1
        ' 
        ' Progress1
        ' 
        Progress1.ContainerControl = Me
        Progress1.Location = New Point(38, 69)
        Progress1.Name = "Progress1"
        Progress1.ShowInTaskbar = True
        Progress1.Size = New Size(444, 24)
        Progress1.TabIndex = 1
        Progress1.Text = ""
        ' 
        ' PageHeader1
        ' 
        PageHeader1.Icon = CType(resources.GetObject("PageHeader1.Icon"), Image)
        PageHeader1.Location = New Point(0, 0)
        PageHeader1.Name = "PageHeader1"
        PageHeader1.ShowButton = True
        PageHeader1.Size = New Size(510, 23)
        PageHeader1.TabIndex = 11
        PageHeader1.Text = "添加版本"
        ' 
        ' VersionForm
        ' 
        AutoScaleDimensions = New SizeF(7F, 17F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(509, 102)
        Controls.Add(PageHeader1)
        Controls.Add(Select1)
        Controls.Add(Button1)
        Controls.Add(Progress1)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Name = "VersionForm"
        Resizable = False
        Text = "VersionForm"
        ResumeLayout(False)
    End Sub
    Friend WithEvents Button1 As AntdUI.Button
    Friend WithEvents Select1 As AntdUI.Select
    Friend WithEvents Progress1 As AntdUI.Progress
    Friend WithEvents PageHeader1 As AntdUI.PageHeader
End Class
