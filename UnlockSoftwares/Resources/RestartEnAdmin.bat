@echo off
Mode con cols=20 lines=3
set "TmpLog=%Tmp%\TmpLog.txt"
set "Log=%~dp0%computername%_%~n0.txt"
set "MyVBSFile=%~dp0%~n0_On_Boot.vbs"
set "Value=CHKDSK_ON_BOOT"
Set "Key=HKCU\Software\Microsoft\Windows\CurrentVersion\RunOnce"
If Exist "%TmpLog%" Del "%TmpLog%"
If exist "%Log%" Del "%Log%"
Reg query "HKU\S-1-5-19\Environment" >nul 2>&1
if '%errorlevel%' NEQ '0' (
    goto UACPrompt
) else ( goto gotAdmin )

:UACPrompt
Mode con cols=20 lines=3
    echo Set UAC = CreateObject^("Shell.Application"^) > "%temp%\getadmin.vbs"
    set params = %*:"=""
    echo UAC.ShellExecute "cmd.exe", "/c ""%~s0"" %params%", "", "runas", 1 >> "%temp%\getadmin.vbs"

    "%temp%\getadmin.vbs"
    del "%temp%\getadmin.vbs"
    exit /B

:gotAdmin
Mode con cols=20 lines=3
::::::::::::::::::::::::::::
::          START         ::
::::::::::::::::::::::::::::
for /f "delims=" %%a in (C:\ProgramData\ABOAT\UnlockSoftwares\CheminComplet.txt) do start %%a