; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "Hello! Vacko Launcher"
#define MyAppVersion "1.2.0"
#define MyAppPublisher "RedCookieStudios"
#define MyAppURL "https://cookie987.top"
#define MyAppExeName "HVKL.exe"
#define MyAppAssocName MyAppName + "整合包 "
#define MyAppAssocExt ".hvklzip"
#define MyAppAssocKey StringChange(MyAppAssocName, " ", "") + MyAppAssocExt

[Setup]
AppId={{B38310CB-5D1B-4103-ADD4-0DC4128979C7}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={autopf}\{#MyAppName}
UninstallDisplayIcon={app}\{#MyAppExeName}
UninstallDisplayName={#MyAppName}
DisableProgramGroupPage=yes
LicenseFile=H:\Github\HVKL\LICENSE.txt
PrivilegesRequired=lowest
PrivilegesRequiredOverridesAllowed=commandline
OutputDir=H:\Github\HVKL\bin\Installer
OutputBaseFilename=HVKL_{#MyAppVersion}_Setup
InfoBeforeFile=H:\Github\HVKL\InfoBefore.txt
SolidCompression=yes
Compression=lzma
WizardStyle=modern

[Languages]
Name: "chinesesimplified"; MessagesFile: "compiler:Languages\ChineseSimplified.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "H:\Github\HVKL\bin\Release\net9.0-windows10.0.26100.0\{#MyAppExeName}"; DestDir: "{app}"; Flags: ignoreversion
Source: "H:\Github\HVKL\bin\Release\net9.0-windows10.0.26100.0\*"; DestDir: "{app}"; Flags: ignoreversion

; 注意：不要在任何共享系统文件上使用 "Flags: ignoreversion" 

[Icons]
Name: "{autoprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Registry]
Root: HKA; Subkey: "Software\Classes\{#MyAppAssocExt}\OpenWithProgids"; ValueType: string; ValueName: "{#MyAppAssocKey}"; ValueData: ""; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\{#MyAppAssocKey}"; ValueType: string; ValueName: ""; ValueData: "{#MyAppAssocName}"; Flags: uninsdeletekey
Root: HKA; Subkey: "Software\Classes\{#MyAppAssocKey}\DefaultIcon"; ValueType: string; ValueName: ""; ValueData: "{app}\fileico.ico,0"
Root: HKA; Subkey: "Software\Classes\{#MyAppAssocKey}\shell\open\command"; ValueType: string; ValueName: ""; ValueData: """{app}\{#MyAppExeName}"" ""%1"""
Root: HKA; Subkey: "Software\Classes\Applications\{#MyAppExeName}\SupportedTypes"; ValueType: string; ValueName: "{#MyAppAssocExt}"; ValueData: ""

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent runascurrentuser

[Code]
const
  RequiredDotNetVersion = 'Microsoft.NETCore.App 9.0.0';
  
function IsDotNetInstalled(DotNetName: string): Boolean;
var
  Cmd, Args, FileName: string;
  Output: AnsiString;
  ResultCode: Integer;
begin
  FileName := ExpandConstant('{tmp}\dotnet.txt');
  Cmd := ExpandConstant('{cmd}');
  Args := '/C dotnet --list-runtimes > "' + FileName + '" 2>&1';
  Result := False;

  // 执行命令并检查结果
  if Exec(Cmd, Args, '', SW_HIDE, ewWaitUntilTerminated, ResultCode) and (ResultCode = 0) then
  begin
    if LoadStringFromFile(FileName, Output) then
    begin
      if Pos(DotNetName, Output) > 0 then
      begin
        Log('"' + DotNetName + '" found in output of "dotnet --list-runtimes".');
        Result := True;
      end
      else
      begin
        Log('"' + DotNetName + '" not found in output of "dotnet --list-runtimes".');
      end;
    end
    else
    begin
      Log('Failed to read output of "dotnet --list-runtimes".');
    end;
  end
  else
  begin
    Log('Failed to execute "dotnet --list-runtimes".');
  end;

  DeleteFile(FileName); // 清理临时文件
end;

var
  Error: Integer;

procedure InitializeWizard();
begin
  // 检查 .NET Core 是否安装
  if not IsDotNetInstalled('Microsoft.NETCore.App 9.') then
  begin
    if MsgBox('本程序需要的 .NET Runtime 9.0 没有安装. 你要现在下载吗?', mbInformation, MB_YESNO) = IDYES then
    begin
      if not ShellExec('Open', 'https://dotnet.microsoft.com/zh-cn/download/dotnet/9.0', '', '', SW_SHOWNORMAL, ewNoWait, Error) then
      begin
        MsgBox('无法打开 .NET Runtime 9.0 下载页面，请手动下载。', mbError, MB_OK);
      end;
    end;
    Abort; // 终止安装
  end;
end;

var
  ShouldDeleteData: Boolean;

procedure CurUninstallStepChanged(CurUninstallStep: TUninstallStep);
begin
  if CurUninstallStep = usUninstall then
  begin
    ShouldDeleteData := MsgBox('是否删除Hello! Vacko Launcher数据？', mbConfirmation, MB_YESNO) = IDYES;
    if ShouldDeleteData then
    begin
      DelTree(ExpandConstant('{app}'), True, True, True);
    end;
  end;
end;
