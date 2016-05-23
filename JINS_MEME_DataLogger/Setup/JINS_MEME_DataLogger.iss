;
; �C���X�g�[���[�쐬�p�����[�^�́uhttp://inno-setup.sidefeed.com/�v���Q��
;

; �A�v���P�[�V�����o�[�W�����擾�i�A�v���o�[�W������X.X.X.X�̌`���ɂȂ��Ă���ׁA�蓮���͂Ƃ���j
;#define MyAppVer GetFileVersion("..\JINS_MEME_DataLogger\bin\Release\JINS_MEME_DataLogger.exe")
#define MyAppVer "1.1.10"
#define MyAppVerName "101_10"

; �A�v���P�[�V�����o�[�W�����𐔒l��
#define MyAppVerNum StringChange(MyAppVer, ".", "")

[Setup]
; �A�v����
AppName=JINS MEME Data Logger 

; �A�v�����{�o�[�W����
AppVerName=JINS MEME Data Logger {#MyAppVer}

; �o�̓f�B���N�g��
OutputDir=".\Output"

; �A�[�J�C�u��
OutputBaseFilename=setup_jmd{#MyAppVerName}

; �E�B�U�[�h�y�[�W�ɕ\�������O���t�B�b�N�i*.bmp: W164 x H314�j
WizardImageFile="MEME_164.bmp"
; �E�B�U�[�h�y�[�W�ɕ\�������O���t�B�b�N���g�傳��Ȃ�
WizardImageStretch=no
; ���̌��ԐF
WizardImageBackColor=$ffffff

; �E�B�U�[�h�y�[�W�̉E�㕔���ɂ���摜�i*.bmp: W55 x H58�j
WizardSmallImageFile="MEME_55.bmp" 


;x64�Ή��A�v���A�C���X�g�[����x64���œ������B
ArchitecturesInstallIn64BitMode=x64
;ArchitecturesAllowed=x64

;x86�Ή��A�v���A�C���X�g�[����x86���œ������B
;ArchitecturesInstallIn64BitMode�͋L�q���Ȃ�
;ArchitecturesAllowed=x86

;x86�Ή��A�v���A�C���X�g�[����x64����WOW64�œ������B
;ArchitecturesInstallIn64BitMode�͋L�q���Ȃ�
;ArchitecturesAllowed=x86 x64 


; �����C���X�g�[���f�B���N�g��
DefaultDirName="{pf}\JINS\JINS MEME Data Logger\"
;DefaultDirName={app}\JINS\JINS MEME Data Logger\

; �O��C���X�g�[���f�B���N�g�����g�p����
UsePreviousAppDir=yes

; DefaultDirName �Ɏw�肵�Ă���ŏI�v�f(�ŉ��w�̃f�B���N�g��)�������ŕt�����邩�ǂ���
AppendDefaultDirName=no

; �v���p�e�B��ʂɕ\�������A�C�R���w��
SetupIconFile="MEME.ico"

; �R���g���[���p�l���̃A�v���P�[�V�����̒ǉ��ƍ폜�̏��ɕ\������A�C�R��
UninstallDisplayIcon="{app}\JINS_MEME_DataLogger.exe"

; �v���p�e�B��ʂ̐���
;VersionInfoDescription=

; �v���p�e�B��ʂ̒��쌠
AppCopyright="Copyright (c) 2015 JINS"

; �v���p�e�B��ʂɕ\�������o�[�W�������
VersionInfoVersion={#MyAppVer}

; �g�p�������b�Z�[�W��\���������ꍇ�A�ȉ��Ƀt�@�C�����w�肷��
;LicenseFile=

; ���^README��\���������ꍇ�A�ȉ��Ƀt�@�C�����w�肷��
;InfoBeforeFile=
;InfoAfterFile=

; ���[�U�[���i���[�U�[���A�V���A���j�̓��͕\��
UserInfoPage=yes


; �v���O�����̒ǉ��ƍ폜��ʂɕ\�������T�|�[�g���
; �A�v���P�[�V�������s���̖��O
AppPublisher="JIN CO., LTD."
; �A�v���P�[�V�������s�� Web�T�C�gURL
;AppPublisherURL=
; �A�v���P�[�V�����̃o�[�W�����ԍ�
AppVersion={#MyAppVer}
; �A�����ݒ肷��B
;AppContact=
; �A�v���P�[�V�����ɂ��ẴT�|�[�g�T�C�gURL
;AppSupportURL=
; �����t�@�C���̃t�@�C���p�X
;AppReadmeFile=
; �A�v���P�[�V�����̍X�V���s���T�C�gURL
AppUpdatesURL=
; �A�v���P�[�V�����̐���
AppComments=

; �\�[�X�t�@�C���f�B���N�g��
;SourceDir="..\JINS_MEME_DataLogger\bin\Release"


; �O���[�v��
DefaultGroupName=JINS MEME Data Logger

[Languages]
; �C���X�g�[���[�̌���\���i�Q�w�肷��ƑI���ɂȂ�j
Name: "English"; MessagesFile: "compiler:Default.isl"
;Name: "Japanese"; MessagesFile: "compiler:Languages\Japanese.isl"

[Messages]
English.WelcomeLabel2=This program will install [name/ver] on your computer.%n%nIt is recommended that you close all other applications before continuing.
English.ClickNext=Click Next to continue, or Cancel to exit the setup wizard.
English.SelectDirLabel3=[name] will be installed in the following folder.
English.SelectDirBrowseLabel=Click Next, to use the default location. If you would like to select a different folder, click Browse.
English.SelectStartMenuFolderDesc=Where should shortcuts for the program be placed in the Start Menu?
English.SelectStartMenuFolderLabel3=Setup will create shortcuts in the following Start Menu folder.
English.SelectStartMenuFolderBrowseLabel=Click Next, to use the default location. If you would like to select a different folder, click Browse.
English.SelectTasksLabel2=Select the additional tasks you would like the setup wizard to perform while installing [name], and then click Next.
English.ReadyLabel2a=Click Install to continue with the installation. Click Back to review or change any settings.
English.FinishedLabel=Setup has finished installing [name] on your computer. To launch the application, click on the installed icons.
English.ClickFinish=Click Finish to exit this wizard.
     
[Files]
; �t�@�C���w��iFlags: ignoreversion �͏㏑���j
Source: "..\JINS_MEME_DataLogger\bin\Release\JINS_MEME_DataLogger.exe"; DestDir: {app}; Flags: ignoreversion
Source: "..\JINS_MEME_DataLogger\bin\Release\JINS_MEME_DataLogger.exe.config"; DestDir: {app}; Flags: ignoreversion
Source: "..\JINS_MEME_DataLogger\bin\Release\ZedGraph.dll"; DestDir: {app}; Flags: ignoreversion
Source: "..\JINS_MEME_DataLogger\bin\Release\freeglut.dll"; DestDir: {app}; Flags: ignoreversion
Source: "..\JINS_MEME_DataLogger\bin\Release\Tao.FreeGlut.dll"; DestDir: {app}; Flags: ignoreversion
Source: "..\JINS_MEME_DataLogger\bin\Release\Tao.OpenGl.dll"; DestDir: {app}; Flags: ignoreversion
Source: "..\JINS_MEME_DataLogger\bin\Release\Tao.Platform.Windows.dll"; DestDir: {app}; Flags: ignoreversion
Source: "..\JINS_MEME_DataLogger\bin\Release\LGPL License.txt"; DestDir: {app}; Flags: ignoreversion
Source: "..\JINS_MEME_DataLogger\bin\Release\FreeGLUT License.txt"; DestDir: {app}; Flags: ignoreversion


; 12345678901234567890123456789012345
; x2Jxxx5x-x7xxxx3x-xx8xMxx4-xx6Ixx1x
[Code]
function CheckSerial(strSerial:string): Boolean;

var
  successCount : integer;
  checkString : string;
  checkValue : Longint;

  begin

  Result := False;
  successCount := 0;

  if (Length(strSerial) >= 35 ) then
  begin
    successCount := successCount + 1;

    if(strSerial[3] = 'J') then
    begin
      successCount := successCount + 1;
    end;

    if(strSerial[23] = 'M') then
    begin
      successCount := successCount + 1;
    end;

    if(strSerial[31] = 'I') then
    begin
      successCount := successCount + 1;
    end;
    
    if ((strSerial[9] = '-') and (strSerial[18] = '-') and (strSerial[27] = '-')) then
    begin
      successCount := successCount + 1;
    end;

    checkString := strSerial[34] + strSerial[2] + strSerial[16] + strSerial[26] + strSerial[7] + strSerial[30] + strSerial[11] + strSerial[21];
    checkValue := StrToIntDef(checkString, 0);
    if(checkValue mod 3 = 2) then
    begin
      successCount := successCount + 1;
    end;

    if(successCount = 6) then
    begin
      Result := True;
    end;
  end;

end;

[Tasks]
;"�f�X�N�g�b�v��ɃA�C�R�����쐬����(&D)"
Name: desktopicon; Description: {cm:CreateDesktopIcon};

[Icons]
Name: "{group}\JINS MEME Data Logger"; Filename: "{app}\JINS_MEME_DataLogger.exe"; WorkingDir: "{app}";
Name: "{commondesktop}\JINS MEME Data Logger"; Filename: "{app}\JINS_MEME_DataLogger.exe"; WorkingDir: "{app}"; Tasks: desktopicon

[Run]
; �C���X�g�[����������Ɏ��s����
;Filename: "{app}\JINS_MEME_DataLogger.exe"; Flags: postinstall

