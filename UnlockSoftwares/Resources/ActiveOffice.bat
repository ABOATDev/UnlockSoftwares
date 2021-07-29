 @echo off
Mode con cols=90 lines=30
Title Activation Microsoft Office 2016 toutes versions !
echo ============================================================================
echo Activatation Microsoft Software Products Office 2016  for MultiCrack
echo ============================================================================
echo.
echo #Supported products:
echo - Microsoft Office Standard 2016
echo - Microsoft Office Professional Plus 2016
echo.
echo.
(if exist "%ProgramFiles%\Microsoft Office\Office16\ospp.vbs" cd /d "%ProgramFiles%\Microsoft Office\Office16")
(if exist "%ProgramFiles(x86)%\Microsoft Office\Office16\ospp.vbs" cd /d "%ProgramFiles(x86)%\Microsoft Office\Office16")
(for /f %%x in ('dir /b ..\root\Licenses16\proplusvl_kms*.xrm-ms') do cscript ospp.vbs /inslic:"..\root\Licenses16\%%x" >nul)
(for /f %%x in ('dir /b ..\root\Licenses16\proplusvl_mak*.xrm-ms') do cscript ospp.vbs /inslic:"..\root\Licenses16\%%x" >nul)
echo.
echo ============================================================================
echo Activatation de Office...
cscript //nologo ospp.vbs /unpkey:WFG99 >nul
cscript //nologo ospp.vbs /unpkey:DRTFM >nul
cscript //nologo ospp.vbs /unpkey:BTDRB >nul
cscript //nologo ospp.vbs /inpkey:XQNVK-8JYDB-WJ9W3-YJ8YR-WFG99 >nul
set i=1
:server
if %i%==1 set KMS_Sev=rien.com
if %i%==4 goto notsupported
cscript //nologo ospp.vbs /sethst:%KMS_Sev% >nul
echo ============================================================================
echo.
echo.
cscript //nologo ospp.vbs /act | find /i "successful"
goto halt
:notsupported
echo.
echo ============================================================================
echo Désolé! Votre version n'est pas supporté
:halt
pause