<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MusicDownloadForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MusicDownloadForm))
        PageHeader1 = New AntdUI.PageHeader()
        lvServerFiles = New ListView()
        lvLocalFiles = New ListView()
        btnDownload = New AntdUI.Button()
        BtnDelete = New AntdUI.Button()
        SuspendLayout()
        ' 
        ' PageHeader1
        ' 
        PageHeader1.Icon = CType(resources.GetObject("PageHeader1.Icon"), Image)
        PageHeader1.Location = New Point(2, 0)
        PageHeader1.MaximizeBox = False
        PageHeader1.Name = "PageHeader1"
        PageHeader1.ShowButton = True
        PageHeader1.Size = New Size(895, 23)
        PageHeader1.TabIndex = 12
        PageHeader1.Text = "音乐下载"
        ' 
        ' lvServerFiles
        ' 
        lvServerFiles.CheckBoxes = True
        lvServerFiles.GridLines = True
        lvServerFiles.Location = New Point(12, 29)
        lvServerFiles.Name = "lvServerFiles"
        lvServerFiles.Size = New Size(375, 365)
        lvServerFiles.TabIndex = 1
        lvServerFiles.UseCompatibleStateImageBehavior = False
        lvServerFiles.View = View.List
        ' 
        ' lvLocalFiles
        ' 
        lvLocalFiles.CheckBoxes = True
        lvLocalFiles.Location = New Point(500, 29)
        lvLocalFiles.Name = "lvLocalFiles"
        lvLocalFiles.Size = New Size(383, 365)
        lvLocalFiles.TabIndex = 4
        lvLocalFiles.UseCompatibleStateImageBehavior = False
        lvLocalFiles.View = View.List
        ' 
        ' btnDownload
        ' 
        btnDownload.Location = New Point(393, 116)
        btnDownload.Name = "btnDownload"
        btnDownload.Size = New Size(101, 36)
        btnDownload.TabIndex = 2
        btnDownload.Text = "下载到本地>"
        btnDownload.Type = AntdUI.TTypeMini.Primary
        ' 
        ' BtnDelete
        ' 
        BtnDelete.Location = New Point(393, 158)
        BtnDelete.Name = "BtnDelete"
        BtnDelete.Size = New Size(101, 36)
        BtnDelete.TabIndex = 3
        BtnDelete.Text = "删除本地"
        BtnDelete.Type = AntdUI.TTypeMini.Error
        ' 
        ' MusicDownloadForm
        ' 
        AutoScaleDimensions = New SizeF(7F, 17F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(895, 406)
        Controls.Add(BtnDelete)
        Controls.Add(btnDownload)
        Controls.Add(lvLocalFiles)
        Controls.Add(lvServerFiles)
        Controls.Add(PageHeader1)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Name = "MusicDownloadForm"
        Text = "MusicDownloadForm"
        ResumeLayout(False)
    End Sub

    Friend WithEvents PageHeader1 As AntdUI.PageHeader
    Friend WithEvents lvServerFiles As ListView
    Friend WithEvents lvLocalFiles As ListView
    Friend WithEvents btnDownload As AntdUI.Button
    Friend WithEvents BtnDelete As AntdUI.Button
End Class
