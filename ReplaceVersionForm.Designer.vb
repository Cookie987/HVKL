﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReplaceVersionForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReplaceVersionForm))
        WindowBar1 = New AntdUI.WindowBar()
        OriginalVerLabel = New AntdUI.Label()
        Image3d1 = New AntdUI.Image3D()
        Select1 = New AntdUI.Select()
        Button2 = New AntdUI.Button()
        Progress1 = New AntdUI.Progress()
        SuspendLayout()
        ' 
        ' WindowBar1
        ' 
        WindowBar1.Location = New Point(1, 0)
        WindowBar1.MaximizeBox = False
        WindowBar1.MinimizeBox = False
        WindowBar1.Name = "WindowBar1"
        WindowBar1.Size = New Size(389, 23)
        WindowBar1.TabIndex = 6
        WindowBar1.Text = "版本更换"
        ' 
        ' OriginalVerLabel
        ' 
        OriginalVerLabel.Font = New Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point)
        OriginalVerLabel.Location = New Point(33, 36)
        OriginalVerLabel.Name = "OriginalVerLabel"
        OriginalVerLabel.Size = New Size(122, 49)
        OriginalVerLabel.TabIndex = 8
        OriginalVerLabel.Text = "?.?.?"
        OriginalVerLabel.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Image3d1
        ' 
        Image3d1.Image = CType(resources.GetObject("Image3d1.Image"), Image)
        Image3d1.Location = New Point(160, 36)
        Image3d1.Name = "Image3d1"
        Image3d1.Size = New Size(59, 49)
        Image3d1.TabIndex = 9
        Image3d1.Text = "Image3d1"
        ' 
        ' Select1
        ' 
        Select1.Location = New Point(249, 44)
        Select1.Name = "Select1"
        Select1.Size = New Size(110, 34)
        Select1.TabIndex = 10
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(266, 123)
        Button2.Name = "Button2"
        Button2.Size = New Size(96, 35)
        Button2.TabIndex = 11
        Button2.Text = "确定"
        Button2.Type = AntdUI.TTypeMini.Primary
        ' 
        ' Progress1
        ' 
        Progress1.ContainerControl = Me
        Progress1.Location = New Point(33, 91)
        Progress1.Name = "Progress1"
        Progress1.ShowInTaskbar = True
        Progress1.ShowText = True
        Progress1.Size = New Size(326, 24)
        Progress1.TabIndex = 12
        Progress1.Text = ""
        ' 
        ' ReplaceVersionForm
        ' 
        AutoScaleDimensions = New SizeF(7F, 17F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(375, 148)
        Controls.Add(Progress1)
        Controls.Add(Button2)
        Controls.Add(Select1)
        Controls.Add(Image3d1)
        Controls.Add(OriginalVerLabel)
        Controls.Add(WindowBar1)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Mode = AntdUI.TAMode.Light
        Name = "ReplaceVersionForm"
        Resizable = False
        Text = "ReplaceVersionForm"
        ResumeLayout(False)
    End Sub

    Friend WithEvents WindowBar1 As AntdUI.WindowBar
    Friend WithEvents OriginalVerLabel As AntdUI.Label
    Friend WithEvents Image3d1 As AntdUI.Image3D
    Friend WithEvents Select1 As AntdUI.Select
    Friend WithEvents Button2 As AntdUI.Button
    Friend WithEvents Progress1 As AntdUI.Progress
End Class