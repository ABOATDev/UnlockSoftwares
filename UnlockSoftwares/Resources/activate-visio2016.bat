@echo off
color 0A
Mode con cols=70 lines=5
Title  Automatically check and get admin rights
:::::::::::::::::::::::::::::::::::::::::
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
title Activate Microsoft Visio 2016 ALL versions for FREE!&cls&echo ============================================================================&echo #Project: Activating Microsoft software products for FREE without software&echo ============================================================================&echo.&echo #Supported products:&echo - Microsoft Visio Standard 2016&echo - Microsoft Visio Professional Plus 2016&echo.&echo.&(if exist "%ProgramFiles%\Microsoft Office\Office16\ospp.vbs" cd /d "%ProgramFiles%\Microsoft Office\Office16")&(if exist "%ProgramFiles(x86)%\Microsoft Office\Office16\ospp.vbs" cd /d "%ProgramFiles(x86)%\Microsoft Office\Office16")&cscript //nologo ospp.vbs /inslic:"..\root\Licenses16\VisioProVL_KMS_Client-ppd.xrm-ms"  >nul&cscript //nologo ospp.vbs /inslic:"..\root\Licenses16\VisioProVL_KMS_Client-ul-oob.xrm-ms" >nul&cscript //nologo ospp.vbs /inslic:"..\root\Licenses16\VisioProVL_KMS_Client-ul.xrm-ms" >nul&cscript //nologo ospp.vbs /inslic:"..\root\Licenses16\client-issuance-bridge-office.xrm-ms" >nul&cscript //nologo ospp.vbs /inslic:"..\root\Licenses16\client-issuance-root.xrm-ms" >nul&cscript //nologo ospp.vbs /inslic:"..\root\Licenses16\client-issuance-root-bridge-test.xrm-ms" >nul&cscript //nologo ospp.vbs /inslic:"..\root\Licenses16\client-issuance-stil.xrm-ms" >nul&cscript //nologo ospp.vbs /inslic:"..\root\Licenses16\client-issuance-ul.xrm-ms" >nul&cscript //nologo ospp.vbs /inslic:"..\root\Licenses16\client-issuance-ul-oob.xrm-ms" >nul&cscript //nologo ospp.vbs /inslic:"..\root\Licenses16\pkeyconfig-office.xrm-ms" >nul&echo.&echo ============================================================================&echo Activating your Visio...&cscript //nologo ospp.vbs /unpkey:W8GF4 >nul&cscript //nologo ospp.vbs /unpkey:RJRJK >nul&cscript //nologo ospp.vbs /inpkey:PD3PC-RHNGV-FXJ29-8JK7D-RJRJK >nul&set i=1
:server
if %i%==1 set KMS_Sev=kms7.MSGuides.com
if %i%==2 set KMS_Sev=kms8.MSGuides.com
if %i%==3 set KMS_Sev=kms9.MSGuides.com
if %i%==4 goto notsupported
cscript //nologo ospp.vbs /sethst:%KMS_Sev% >nul&echo ============================================================================&echo.&echo.
cscript //nologo ospp.vbs /act | find /i "successful" && (echo.&echo ============================================================================&echo.&echo #My official blog: MSGuides.com&echo.&echo #How it works: bit.ly/kms-server&echo.&echo #Please feel free to contact me at msguides.com@gmail.com if you have any questions or concerns.&echo.&echo #Please consider supporting this project: donate.msguides.com&echo #Your support is helping me keep my servers running everyday!&echo.&echo ============================================================================&choice /n /c YN /m "Would you like to visit my blog [Y,N]?" & if errorlevel 2 exit) || (echo The connection to my KMS server failed! Trying to connect to another one... & echo Please wait... & echo. & echo. & set /a i+=1 & goto server)
explorer "http://MSGuides.com"&goto halt
:notsupported
echo.&echo ============================================================================&echo Sorry! Your version is not supported.&echo Please try installing the latest version here: bit.ly/downloadmsp
:halt
pause