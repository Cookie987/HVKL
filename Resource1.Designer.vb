﻿'------------------------------------------------------------------------------
' <auto-generated>
'     此代码由工具生成。
'     运行时版本:4.0.30319.42000
'
'     对此文件的更改可能会导致不正确的行为，并且如果
'     重新生成代码，这些更改将会丢失。
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System

Namespace My.Resources
    
    '此类是由 StronglyTypedResourceBuilder
    '类通过类似于 ResGen 或 Visual Studio 的工具自动生成的。
    '若要添加或移除成员，请编辑 .ResX 文件，然后重新运行 ResGen
    '(以 /str 作为命令选项)，或重新生成 VS 项目。
    '''<summary>
    '''  一个强类型的资源类，用于查找本地化的字符串等。
    '''</summary>
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0"),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute()>  _
    Friend Class Resource1
        
        Private Shared resourceMan As Global.System.Resources.ResourceManager
        
        Private Shared resourceCulture As Global.System.Globalization.CultureInfo
        
        <Global.System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")>  _
        Friend Sub New()
            MyBase.New
        End Sub
        
        '''<summary>
        '''  返回此类使用的缓存的 ResourceManager 实例。
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend Shared ReadOnly Property ResourceManager() As Global.System.Resources.ResourceManager
            Get
                If Object.ReferenceEquals(resourceMan, Nothing) Then
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("HVKL.Resource1", GetType(Resource1).Assembly)
                    resourceMan = temp
                End If
                Return resourceMan
            End Get
        End Property
        
        '''<summary>
        '''  重写当前线程的 CurrentUICulture 属性，对
        '''  使用此强类型资源类的所有资源查找执行重写。
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend Shared Property Culture() As Global.System.Globalization.CultureInfo
            Get
                Return resourceCulture
            End Get
            Set
                resourceCulture = value
            End Set
        End Property
        
        '''<summary>
        '''  查找类似 &lt;svg xmlns=&quot;http://www.w3.org/2000/svg&quot; viewBox=&quot;0 0 24 24&quot;&gt;&lt;title&gt;folder-outline&lt;/title&gt;&lt;path d=&quot;M20,18H4V8H20M20,6H12L10,4H4C2.89,4 2,4.89 2,6V18A2,2 0 0,0 4,20H20A2,2 0 0,0 22,18V8C22,6.89 21.1,6 20,6Z&quot; /&gt;&lt;/svg&gt; 的本地化字符串。
        '''</summary>
        Friend Shared ReadOnly Property FolderSVG() As String
            Get
                Return ResourceManager.GetString("FolderSVG", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  查找类似 &lt;svg xmlns=&quot;http://www.w3.org/2000/svg&quot; viewBox=&quot;0 0 24 24&quot;&gt;&lt;title&gt;refresh&lt;/title&gt;&lt;path d=&quot;M17.65,6.35C16.2,4.9 14.21,4 12,4A8,8 0 0,0 4,12A8,8 0 0,0 12,20C15.73,20 18.84,17.45 19.73,14H17.65C16.83,16.33 14.61,18 12,18A6,6 0 0,1 6,12A6,6 0 0,1 12,6C13.66,6 15.14,6.69 16.22,7.78L13,11H20V4L17.65,6.35Z&quot; /&gt;&lt;/svg&gt; 的本地化字符串。
        '''</summary>
        Friend Shared ReadOnly Property RefreshSVG() As String
            Get
                Return ResourceManager.GetString("RefreshSVG", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  查找类似 &lt;svg xmlns=&quot;http://www.w3.org/2000/svg&quot; viewBox=&quot;0 0 24 24&quot;&gt;&lt;path d=&quot;M13.13 22.19L11.5 18.36C13.07 17.78 14.54 17 15.9 16.09L13.13 22.19M5.64 12.5L1.81 10.87L7.91 8.1C7 9.46 6.22 10.93 5.64 12.5M21.61 2.39C21.61 2.39 16.66 .269 11 5.93C8.81 8.12 7.5 10.53 6.65 12.64C6.37 13.39 6.56 14.21 7.11 14.77L9.24 16.89C9.79 17.45 10.61 17.63 11.36 17.35C13.5 16.53 15.88 15.19 18.07 13C23.73 7.34 21.61 2.39 21.61 2.39M14.54 9.46C13.76 8.68 13.76 7.41 14.54 6.63S16.59 5.85 17.37 6.63C18.14 7.41 18.15 8.68 17.37 9.46C16 [字符串的其余部分被截断]&quot;; 的本地化字符串。
        '''</summary>
        Friend Shared ReadOnly Property RocketSVG() As String
            Get
                Return ResourceManager.GetString("RocketSVG", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  查找类似 1.1.0 的本地化字符串。
        '''</summary>
        Friend Shared ReadOnly Property Version() As String
            Get
                Return ResourceManager.GetString("Version", resourceCulture)
            End Get
        End Property
    End Class
End Namespace
