:: https://github.com/byte3ater/Batch-Utilities/blob/master/Battery-Report.bat
::Detects the version of windows and runs the correct powercfg.
::        Written by 4C1DB3RN


@echo off
color 0A
Mode con cols=70 lines=5
Title  Automatically check and get admin rights

:: Automatically check and get admin rights
:::::::::::::::::::::::::::::::::::::::::
Set TmpLogFile=TmpLogkey.txt
Set LogFile=Startup_key_Log.txt
If Exist %TmpLogFile% Del %TmpLogFile%
If Exist %LogFile% Del %LogFile%
REM  --> Check for permissions
Reg query "HKU\S-1-5-19\Environment" >%TmpLogFile% 2>&1
REM --> If error flag set, we do not have admin.
if '%errorlevel%' NEQ '0' (
Echo.
ECHO                 **************************************
ECHO                  Running Admin shell... Please wait...
ECHO                 **************************************
 
    goto UACPrompt
) else ( goto gotAdmin )
 
:UACPrompt
    echo Set UAC = CreateObject^("Shell.Application"^) > "%temp%\getadmin.vbs"
    set params = %*:"=""
    echo UAC.ShellExecute "cmd.exe", "/c ""%~s0"" %params%", "", "runas", 1 >> "%temp%\getadmin.vbs"
 
    "%temp%\getadmin.vbs"
    del "%temp%\getadmin.vbs"
    exit /B
 
:gotAdmin
 
::::::::::::::::::::::::::::
::START
::::::::::::::::::::::::::::
REM start code here

chcp 28591 > nul
@echo off

Title title Battery Report Generator FazCode

powercfg /batteryreport /Output C:\ProgramData\ABOAT\UnlockSoftwares\battery-report.html
Start C:\ProgramData\ABOAT\UnlockSoftwares\battery-report.html