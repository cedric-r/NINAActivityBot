[Setup]
AppID={{3a7e63ad-c813-44f0-9489-e1744c9c2992}}
AppName=NINA Activity Bot
AppVersion=0.0.9
WizardStyle=modern
DefaultDirName={autopf}\NINAActivityBot
DefaultGroupName=NINA Activity Bot
UninstallDisplayIcon={app}\NINAActivityBotUI.exe
Compression=lzma2
SolidCompression=yes
OutputDir="."
OutputBaseFilename="NINA Activity Bot Setup"
LicenseFile="k:\astro\ASCOM.HomeMade.SBIGCamera\License"


[Files]
Source: "c:\Users\cedric\source\NINAActivityBot\NINAActivityBotUI\bin\Release\net6.0-windows\publish\win-x86\License"; DestDir: "{app}"; Flags: comparetimestamp overwritereadonly ignoreversion
Source: "c:\Users\cedric\source\NINAActivityBot\NINAActivityBotUI\bin\Release\net6.0-windows\publish\win-x86\README.md"; DestDir: "{app}"; Flags: comparetimestamp overwritereadonly ignoreversion
Source: "c:\Users\cedric\source\NINAActivityBot\NINAActivityBotUI\bin\Release\net6.0-windows\publish\win-x86\NINAActivityBotUI.exe"; DestDir: "{app}"; Flags: comparetimestamp overwritereadonly ignoreversion

[Icons]
Name: "{group}\NINA Activity Bot"; Filename: "{app}\NINAActivityBotUI.exe"