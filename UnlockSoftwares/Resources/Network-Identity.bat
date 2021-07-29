@goto :batch


=========================================================================================
if there are any updates made to this App newest
version can be found at http://batch.nhserver.ml

by ImDeepWithWindows from http://HackForums.net
=========================================================================================


:batch
@echo off
title %~n0
color 1b
echo.>"%homedrive%\AdminPriv.test"
if exist "%homedrive%\AdminPriv.test" goto :has_uac_elev
cls
echo.--
echo.This App requires UAC elivation to make changes,
echo.run this program as Administrator to use it.
echo.--
echo.
echo.
echo.tap ^<space^> to continue
pause >nul
goto :eof
:has_uac_elev
del /f /q "%homedrive%\AdminPriv.test" >nul
setlocal EnableDelayedExpansion 
:menu
for /f "tokens=5 skip=5" %%A in ('netsh int ipv4 show ipaddress') do set "CurrIP=%%A" & goto :GotIP
:GotIP
cls
echo.--
echo.Current network IP-Address of this computer: [ %CurrIP% ]
echo.Current network DNS-name of this computer: [ \\%computername% ]
echo.--
echo.
echo.
if NOT "%newdns%"=="" echo. & echo.when computer reboots network DNS-name will be: [ \\%newdns% ] & echo. & echo. & echo. 
echo.tap "I" to use a custom network IP-Address
echo.tap "D" to use a custom network DNS-name
choice /c id /n
cls
if %errorlevel% equ 2 goto :changeDNS


for /f "tokens=1,2,3,4 delims=." %%A in ('echo %CurrIP%') do set /a "plusten=%%D+10" & set "defaultnewip=%%A.%%B.%%C.%plusten%"
echo.--
echo.Computer's current Network IP-Address: [ %CurrIP% ]
echo.leave blank for no change
echo.--
echo.
echo.
set/p "newip=[NewIP]:"
if "%newip%"=="" goto :menu
for /f "skip=1 delims=: tokens=2" %%A in ('netsh int ipv4 show ipaddress') do set "tmpvar1=%%A" & set "interface=!tmpvar1:~1!" & goto :GotInterfaceName
:GotInterfaceName
for /f "tokens=2 delims=:" %%A in ('netsh int ipv4 show address ^| find /I "Default Gateway"') do set "tmpvar=%%A" & set "gateway=!tmpvar: =!"
for /f "tokens=2 delims=:" %%A in ('ipconfig ^| find /I "Subnet Mask"') do set "tmpvar2=%%A" & set "mask=!tmpvar2:~1!"
netsh int ipv4 set address name="!interface!" static !newip! !mask! !gateway! >nul
goto :menu

:changeDNS
echo.--
echo.Computer's current Network DNS-Name: [ \\%computername% ]
echo.leave blank for no change
echo.--
echo.
echo.
set/p "newdns=[NewDNS]:"
if "%newdns%"=="" goto :menu
if "%newdns:~0,2%"=="\\" set "newdns=%newdns:~2%"
wmic computersystem where caption="!computername!" rename "!newdns!" >nul
cls
echo.--
echo.changes will take effect on reboot
echo.--
echo.
echo.
echo.tap ^<space^> to continue
@pause >nul
goto :menu