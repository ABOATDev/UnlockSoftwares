@echo off & setlocal enabledelayedexpansion
Set ""
Title  %~n0 %Copyright%
Mode con cols=90 lines=30
cls & color 0A & echo.
    echo             ***********************************************
    echo                 %~n0 %Copyright%
    echo             ***********************************************
    echo(
if _%1_==_Main_  goto :Main
Set Count=0
Set L=0
:getadmin
    echo               %~nx0 : self elevating
    set vbs=%temp%\getadmin.vbs
(
    echo Set UAC = CreateObject^("Shell.Application"^)
    echo UAC.ShellExecute "%~s0", "Main %~sdp0 %*", "", "runas", 1
)> "%vbs%"
    "%temp%\getadmin.vbs"
    del "%temp%\getadmin.vbs"
goto :eof
::*************************************************************************************
:Main
Call :init
Call :CountLines
Set "PasswordLog=%~dp0Wifi_Passwords_on_%ComputerName%.txt"
%Mod%
    echo(
    echo             ***********************************************
    echo                 %~n0 %Copyright%
    echo             ***********************************************
    echo(
Call :Color 0E "                 [N][SSID] ================ Password" 1
echo(
(
    echo             ***********************************************
    echo                 %~n0 %Copyright%
    echo             ***********************************************
    echo(
    echo                  [N][SSID] ==============^> "Password"
    echo(
   
)>"%PasswordLog%"
for /f "skip=2 delims=: tokens=2" %%a in ('netsh wlan show profiles') do (
    if not "%%a"=="" (
        set "ssid=%%a"
        set "ssid=!ssid:~1!"
        call :Getpassword "!ssid!"
    )
)
echo(
echo Done
If exist "%PasswordLog%" start "" "%PasswordLog%"
pause>nul
exit
::*************************************************************************************
:Getpassword
set "name=%1"
set "name=!name:"=!"
Set "passwd="
for /f "delims=: tokens=2" %%a in ('netsh wlan show profiles %1 key^=clear ^|find /I "Cont"') do (
    set "passwd=%%a"
    Set /a Count+=1
)
 
If defined passwd (
    set passwd=!passwd:~1!
    echo                  [!Count!][!name!] ====^> "!passwd!"
    echo                  [!Count!][!name!] ====^> "!passwd!" >> "%PasswordLog%"
) else (
    Set /a Count+=1
call :color 0C "                 [!Count!][!name!] The Password is empty" 1
    echo                  [!Count!][!name!] The Password is empty >> "%PasswordLog%"
)
exit /b
::*************************************************************************************
:init
prompt $g
for /F "delims=." %%a in ('"prompt $H. & for %%b in (1) do rem"') do set "BS=%%a"
exit /b
::*************************************************************************************
:color
set nL=%3
if not defined nL echo requires third argument & pause > nul & goto :eof
if %3 == 0 (
   <nul set /p ".=%bs%">%2 & findstr /v /a:%1 /r "^$" %2 nul & del %2 2>&1 & goto :eof
) else if %3 == 1 (
   echo %bs%>%2 & findstr /v /a:%1 /r "^$" %2 nul & del %2 2>&1 & goto :eof
)
exit /b
::*************************************************************************************
:CountLines
for /f "skip=2 delims=: tokens=2" %%a in ('netsh wlan show profiles') do (
   if not "%%a"=="" (
        set /a L+=1
    )
)
set /a L=!L! + 10
Set Mod=Mode con cols=75 Lines=!L!
exit /b
::*************************************************************************************