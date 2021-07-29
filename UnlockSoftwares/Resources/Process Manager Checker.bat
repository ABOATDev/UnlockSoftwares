@echo off
Title "%~n0" by Hackoo 2017
::::::::::::::::::::::::::::
::START
::::::::::::::::::::::::::::
:Main
Color 9E & Mode con cols=80 lines=120
Title "%~n0" by Hackoo 2017
Setlocal EnableDelayedExpansion
PUSHD "%TEMP%"
set ac=
set SPW=0
set offset=
set sorder=
set osetpid=27
set osetmem=60
set osetcpu=141
 
:Reload
cls
Color 9E & Mode con cols=80 lines=120
Title "%~n0" by Hackoo 2017
set num=0
echo  ------------------------------------------------------------------------------
echo  [N]    [Process Name]          [PID]      [MEM]      [CPUTime]      [Type]
echo  ------------------------------------------------------------------------------
if not defined NAME set NAME=All
if "!NAME!" == "All" (
tasklist /FO TABLE /NH /V | SORT !offset! !sorder! >"plist.txt"
) else (
tasklist /FI "USERNAME eq !NAME!" /FO TABLE /NH /V | SORT !offset! !sorder! >"plist.txt"
)
for /f "tokens=*" %%a in (plist.txt) do (
set /a num+=1
set "tempvar=%%a"
if "!tempvar:~34,1!" == " " (
    If !num! LSS 10 (
        set "list= [!num!]    !tempvar:~0,22! |!tempvar:~29,5! | !tempvar:~66,10! | !tempvar:~147,10!  |  !tempvar:~35,8!"
        ) else (
            set "list= [!num!]   !tempvar:~0,22! |!tempvar:~29,5! | !tempvar:~66,10! | !tempvar:~147,10!  |  !tempvar:~35,8!"
    )
set osetpid=29
set osetmem=66
set osetcpu=147
) else (
set "list=[!num!] !tempvar:~0,20! !tempvar:~27,5!    !tempvar:~60,9!      !tempvar:~141,10!"
set osetpid=27
set osetmem=60
set osetcpu=141
)
echo !list!
)
:Reload_End
del /F "plist.txt" >nul 2>&1
echo  -----------------------------------------------------------------------------
if "!NAME!"=="All" (
echo                     All processes - [!num!] Processes running
) else (
echo                        !NAME! - [!num!] Processes running
)
echo  ------------------------------------------------------------------------------
if not defined ac (
    if /i "!NAME!"=="%username%" goto :MNG
    if /i "!NAME!"=="SYSTEM" goto :MNG
    if /i "!NAME!"=="All" goto :MNG
)
if /i "!ac!"=="A" set NAME=
if /i "!ac!"=="C" goto Check_Suspicious_Process
if /i "!ac!"=="R" goto Report
if /i "!ac!"=="V" goto VirusTotal
if /i "!ac!"=="Y" goto Systemexplorer
if /i "!ac!"=="D" goto USB_Cleaner
if /i "!ac!"=="Remove" goto virus_effect_remover
if /i "!ac!"=="U" set NAME=%username%
if /i "!ac!"=="S" set NAME=SYSTEM
if /i "!ac!"=="T" goto :SPW
if /i "!ac!"=="E" goto :Explore
if /i "!ac!"=="K" goto :Kill
if /i "!ac!"=="M" goto :SMEM
if /i "!ac!"=="N" goto :SNAME
if /i "!ac!"=="P" goto :SPID
if /i "!ac!"=="X" EXIT
set ac=
goto :Reload
 
:MNG
echo(
echo  =============================================================================
echo                                   Menu Options                                
echo  =============================================================================
echo  Sort Process by : N=[Name]  P=[PID]      M=[MEM]
echo  -----------------------------------------------------------------------------
echo  Show Process    : A=[All]   S=[System]   U=[User]   T=[Executables Paths]
echo  -----------------------------------------------------------------------------
echo  Functions : C=[Check Legits svchost]  E=[Explore Process]   K=[Kill Process]
echo(
echo              R=[Report Creator]     Y=[Check Process in Systemexplorer.net]
echo(  
echo              V=[Scan Registry Run Keys with VirusTotal]
echo(    
echo              D=[ShortcutRemover and USB Cleaner]        
echo(
echo              Remove=[Virus Effect Remover]                  X=[Exit]
echo(
echo  =============================================================================
echo(
set /p ac="  Manage : "
if "!SPW!" == "1" goto :EOF
goto :Reload
 
:SPW
set SPW=1
cls
Color 9A & Mode con cols=93
wmic process get ExecutablePath,ProcessID
echo.
call :MNG
if /i "!ac!"=="E" set SPW=0&&goto :Explore
if /i "!ac!"=="K" set SPW=0&&goto :Kill
set SPW=0
goto :Reload
 
:Kill
echo Type PID to Kill.
set /p PID=PID:
if not defined PID (
    set ac=
    goto :Reload
)
taskkill /F /PID !PID! >nul 2>&1
if errorlevel 1 (echo No task running with this PID.) else (
    if !PID! geq 0 if !PID! lss 10 (
        echo Cannot kill a critical process.
        goto :clr_var
    ) else (
        echo Success: Task with PID=!PID!
        echo          has been terminated.
    )
)
:clr_var
set ac=
set PID=
set exepath=
del /F "path.txt" >nul 2>&1
Timeout /T 3 /nobreak>nul
goto :Reload
 
:Explore
echo Type PID to explore.
set /p PID=PID:
if not defined PID (
set ac=
goto :Reload
)
if !PID! lss 10 goto :clr_var
if !PID! gtr 10000 goto :clr_var
for /f "tokens=2 delims=," %%I in (
    'wmic process where "ProcessID='!PID!'" get ExecutablePath^,Handle /format:csv ^| find /i "!PID!"'
) do set "exepath=%%~I"
 
if not defined exepath (
    echo No task running with this PID.
    pause >nul
) else (
    explorer /e,/select, "!exepath!"
)
goto :clr_var
 
:SNAME
set offset=
set sorder=
set ac=
goto :Reload
 
:SPID
set offset=/+!osetpid!
set sorder=
set ac=
goto :Reload
 
:SMEM
set offset=/+!osetmem!
set sorder=/R
set ac=
goto :Reload
::*********************************************************************************************
:Check_Suspicious_Process
cls
Set "ProcessName=SVCHOST"
Set "Tmp_Services=%Tmp%\%~n0.txt"
If Exist "%Tmp_Services%" Del "%Tmp_Services%"
Set "ProcessLog=%Tmp%\%ProcessName%.log"
If Exist "%ProcessLog%" Del "%ProcessLog%"
Set "Legits_Services_SVCHOST=%~dp0Legits_Services_%ProcessName%.txt"
Set "Legit_Location=%windir%\system32\svchost.exe"
Set "LogFile=%~dp0%ProcessName%_ProcessList.txt"
Set "Suspicious_LogFile=%~dp0%ComputerName%_%ProcessName%_Suspicious_Paths.txt"
Title Finding all instances and paths of "%ProcessName%" by Hackoo 2017
If Exist "%LogFile%" Del "%LogFile%"
Set /A Counter=0
Taskkill /IM "SMSvcHost.exe" /F >nul 2>&1
Setlocal EnableDelayedExpansion
for /F "skip=1" %%a in ('WMIC Path win32_process where "name like '%%%ProcessName%%%'" get commandline') do (
    for /F "delims=" %%b in ("%%a") do (
        Color 9A
        set /A Counter+=1
        set "p=%%b"
        for /f %%f in ('echo !p! ^|Findstr /LI "%Legit_Location%"') do (
            echo [!Counter!] : !p!
        )
            ( echo "!p!" )>>"%LogFile%"
    )
)
 
Powershell.exe Get-WmiObject Win32_Process ^| select ProcessID,ProcessName,Handle,commandline,ExecutablePath ^| Out-File -Append "%ProcessLog%" -Encoding ascii
Type "%ProcessLog%" | find /i "%Legit_Location%" > "%Tmp_Services%"
 
(
    echo(
    echo Those are legitimes services of "%ProcessName%.exe"
    Tasklist /SVC /FO TABLE /FI "IMAGENAME eq %ProcessName%.exe"
)>con
 
(
    echo(
    echo Those are legitimes services of "%ProcessName%.exe"
    Tasklist /SVC /FO TABLE /FI "IMAGENAME eq %ProcessName%.exe"
)>> "%Tmp_Services%"
CMD /U /C Type "%Tmp_Services%" > "%Legits_Services_SVCHOST%"
echo(
Echo All instances of "%ProcessName%" in this path "%Legit_Location%" are legitimes services
echo(
echo Hit any key to look for a suspicious "%ProcessName%" paths
Findstr /LVI "%Legit_Location%" "%LogFile%" > "%Suspicious_LogFile%"
pause>nul
Start "" "%Suspicious_LogFile%"
Start "" "%Legits_Services_SVCHOST%" & goto :Main
::*********************************************************************************************
:Systemexplorer
SET "URL=http://systemexplorer.net/file-database/file/"
echo Type PID to explore and check it with Systemexplorer.net
set /p PID=PID:
if not defined PID (
set ac=
goto :Reload
)
if !PID! lss 10 goto :clr_var
if !PID! gtr 10000 goto :clr_var
for /f "tokens=2 delims=," %%I in (
    'wmic process where "ProcessID='!PID!'" get ExecutablePath^,ProcessID /format:csv ^| find /i "!PID!"'
) do (
    set "File=%%~nxI"
    Set File=!File:.=-!
)
if not defined File (
    echo No task running with this PID.
    pause >nul
) else (
    Start "" "!URL!!File!"
)
goto :clr_var
::*********************************************************************************************
:Report
cls
Title Execution of "%~nx0" with username : "%username%" on Computer "%Computername%" by Hackoo 2017
Mode con cols=110 lines=5
cls & color 9E & echo.
Set "TmpLog=%Temp%\TmpLog_Keys.txt"
Set "Log=%~dp0%~n0_%Computername%.txt
Set "All_Users=%ProgramData%\Microsoft\Windows\Start Menu\Programs\Startup"
Set "Current_User=%UserProfile%\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Startup"
Set StartupFolders="%All_Users%" "%Current_User%"
Set "Links=url lnk"
If Exist "%TmpLog%" Del "%TmpLog%"
If Exist "%Log%" Del "%Log%"
Set "TmpVbs=%Tmp%\%~n0.vbs"
 
::************************************************************
(
   echo set Ws = CreateObject("WScript.Shell"^)
   echo set Lnk = Ws.Createshortcut(WScript.Arguments(0^)^)
   echo WScript.echo Chr(34^) ^& Lnk.TargetPath ^& Chr(34^)
)>"%Tmpvbs%"
::************************************************************
:: REM "HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall"
:: REM "HKLM\SOFTWARE\Microsoft\Active Setup"^
::************************************************************
 
Set Keys=^
^ "HKCU\SOFTWARE\Microsoft\Windows\CurrentVersion\Run"^
^ "HKLM\Software\Microsoft\Windows\CurrentVersion\Run"^
^ "HKCU\Software\Microsoft\Windows\CurrentVersion\Policies\Explorer\Run"^
^ "HKLM\Software\Microsoft\Windows\CurrentVersion\Policies\Explorer\Run"^
^ "HKCU\SOFTWARE\Microsoft\Windows NT\CurrentVersion\WinLogon"^
^ "HKLM\SOFTWARE\Microsoft\Windows NT\CurrentVersion\WinLogon"^
^ "HKCU\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Windows"^
^ "HKLM\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Windows"^
^ "HKCU\Software\Microsoft\Internet Explorer\Main"^
^ "HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall"^
^ "HKLM\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Image File Execution Options"
 
Set Winlogon_HKLM="HKLM\SOFTWARE\Microsoft\Windows NT\CurrentVersion\WinLogon"
Set ImageFile="HKLM\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Image File Execution Options"
 
Echo              *********************************************************************************
Echo                     Get information about security software on Computer "%Computername%"
Echo              *********************************************************************************
 
(
   echo **************************************************************************************************************************************************
   echo                   Started on %Date% %Time% "%~nx0" with username : "%username%" on Computer "%Computername%"
   echo **************************************************************************************************************************************************
echo.
)>"%TmpLog%"
 
(
   Echo.
   Echo ***************************** General infos ***********************************
   Echo.
   Echo Running under: %username% on profile: %userprofile%
   Echo Computer name: %computername%
   Echo.
    systeminfo
   Echo Operating System:
   wmic os get caption | findstr /v /r /c:"^$" /c:"^Caption"
   Echo PROCESSOR ARCHITECTURE : %PROCESSOR_ARCHITECTURE%
    echo NUMBER_OF_PROCESSORS : %NUMBER_OF_PROCESSORS%
    echo PROCESSOR_IDENTIFIER : %PROCESSOR_IDENTIFIER%
    echo PROCESSOR_LEVEL : %PROCESSOR_LEVEL%
    echo PROCESSOR_REVISION : %PROCESSOR_REVISION%
    echo OS TYPE : %OS%
    echo CMD PATH : %ComSpec%
    echo EXTENSIONS : %PATHEXT%
    echo(
    echo PATH : "%Path%"
    echo(
    echo Program files path : %Programfiles%
    echo Program files(86^) path  : %Programfiles(86^)%
    echo ProgramW6432 path : %ProgramW6432%
    echo PSModulePath : %PSModulePath%
    echo SystemRoot : %SystemRoot%
    echo Temp Folder : %Temp%
   Echo Boot Mode:
   wmic COMPUTERSYSTEM GET BootupState | find "boot"
   Echo Antivirus software installed:
   wmic /Node:localhost /Namespace:\\root\SecurityCenter2 Path AntiVirusProduct Get displayName | findstr /v /r /c:"^$" /c:"displayName"
   Echo.
   Echo **************************** Drives infos *************************************
   Echo.
   Echo Listing currently attached drives:
   wmic logicaldisk get caption,description,volumename | find /v ""
   Echo.
   Echo Physical drives information:
   for /F "tokens=1-3" %%A in ('fltmc volumes^|find ":"') do echo %%A %%B %%C
   Echo.
    Echo ************************** DriverQuery infos **********************************
    DriverQuery
   Echo *******************************************************************************
    echo.
    Echo ************************** GPresult infos **********************************
    gpresult /SCOPE USER /Z
   Echo *******************************************************************************
)>>"%TmpLog%" 2>&1
 
For %%K in (%Keys%) Do (  
   cls
   echo(
   Echo               ***************************** Scanning in progress *****************************
   Echo               %%K
   Echo               ********************************************************************************
   Timeout /T 2 /Nobreak>nul
   (
     IF ["%%~K"]==[%Winlogon_HKLM%] (
            reg query "%%~K" /s | find /I "Shell"
            reg query "%%~K" /s | find /I "Userinit"
        ) else (
            IF ["%%~K"]==[%ImageFile%] (
                reg query "%%~K" /s | find /I "debugger"
            ) else (
                reg query "%%~K" /s
            )
        )
       echo *************************************************************************************************
   )>> "%TmpLog%"
)
 
(
   Echo                                  Startup files in Startup folders
   Echo *****************************************************************************************************
   For %%i in (%StartupFolders%) Do (
       For %%j in (%Links%) Do (
           For /f "delims=" %%L in ('Dir /b /s "%%~i" ^|find /i "%%~j"') Do (
               If "%ErrorLevel%" NEQ "1" (
                   echo  ----------------------------------------------------------------------
                   echo "%%L" & Call:ExtractTarget "%%L"
                   echo  ----------------------------------------------------------------------
               )    
           )
       )          
   )
   Echo.
   Echo ******************************************************************************
)>>"%TmpLog%" 2>&1
 
(
   Echo ******************************************************************************
   Echo                                STARTUP List
   Echo ******************************************************************************
)>>"%TmpLog%" 2>&1
 
wmic /APPEND:"%TmpLog%" STARTUP get /format:list>Nul
 
(
   Echo.
   Echo ******************************************************************************
   Echo                               Process List
   Echo ******************************************************************************
)>>"%TmpLog%" 2>&1
 
Powershell.exe Get-WmiObject Win32_Process ^| select ProcessID,ProcessName,Handle,commandline,ExecutablePath ^| Out-File -Append "%TmpLog%" -Encoding ascii
 
(
   Echo.
   Echo ******************************************************************************
   Echo                               Services List
   Echo ******************************************************************************
    SC queryex
)>>"%TmpLog%" 2>&1
 
(
   Echo.
   Echo ******************************************************************************
   Echo                            Scheduled task list
   Echo ******************************************************************************
Schtasks /query /fo LIST
)>>"%TmpLog%" 2>&1
 
(
   echo.
   echo ******************************************************************************
   echo                         Contents of the Hosts file
   echo ******************************************************************************
   Type "%WINDIR%\system32\drivers\etc\hosts"
)>> "%TmpLog%" 2>&1
 
(
   echo.
   echo ******************************************************************************
   echo                            NetWork Connections
   echo ******************************************************************************
)>> "%TmpLog%" 2>&1
 
(
   rem Netstat -bf
   Netstat -anofb
   Netstat -af
)>> "%TmpLog%"
 
(
   echo.
   echo ******************************************************************************
   echo                                   DNS Cache
   echo ******************************************************************************
   ipconfig /DisplayDNS
)>> "%TmpLog%" 2>&1
 
CMD /U /C Type "%TmpLog%" > "%Log%"
If Exist "%TmpLog%" Del "%TmpLog%"
If Exist "%Tmpvbs%" Del "%Tmpvbs%"
Start "" "%Log%"
Goto :Main
::*************************************************************************
:Virustotal
Mode con cols=90 lines=3 & color 9E
Title "%~n0" for Scanning Registry Run Keys with VirusTotal Uploader by Hackoo 2017
Set "Files_List2Upload=%~dp0FilesList2Upload.txt"
If Exist "%Files_List2Upload%" Del "%Files_List2Upload%"
:Main_Virustotal
Mode con cols=90 lines=3 & color 9E
REM Determine if the OS is (32/64 bits) to set the correct path of VirusTotalUploaderTool.
IF /I "%PROCESSOR_ARCHITECTURE%"=="x86" (
       Set "VirusTotalUploaderTool=%ProgramFiles%\VirusTotalUploader2\VirusTotalUploader2.2.exe"
   ) else (
       Set "VirusTotalUploaderTool=%programfiles(x86)%\VirusTotalUploader2\VirusTotalUploader2.2.exe"
)
 
If Not Exist "%VirusTotalUploaderTool%" ( Call:Downloading )
echo(
echo           Creating a list of all *.exe files located on your the registry run keys ...
Timeout /t 4 /NoBreak>nul
If Not Exist "%Files_List2Upload%" ( Call:CreateFileList2Upload )
For /f "delims=" %%f in ('Type "%Files_List2Upload%"') Do (
    Call:Upload2VirusTotal "%%~f"
)
Taskkill /im "VirusTotalUploader2.2.exe" /f >nul 2>&1
Goto :Main
::*********************************************************************************
:Upload2VirusTotal <File>
Title "%~nx0" for Multi-files VirusTotal Uploader by Hackoo 2017
Cls
Set "File2Upload=%~1"
echo(
echo     Please wait a while ! Uploading file "%~nx1" to VirusTotal is in progress ...
Start "" "%VirusTotalUploaderTool%" "%File2Upload%"
Timeout /t 10 /nobreak>nul
exit /b
::*********************************************************************************
:Downloading
Title Downloading VirusTotal Uploader Tool v2.2 by Hackoo 2017
Set "URL=https://www.virustotal.com/static/bin/vtuploader2.2.exe"
Rem Create "MyDownload" folder in the temporary folder
set "MyDownload_Folder=%temp%\MyDownload"
If Not Exist "%MyDownload_Folder%" MD "%MyDownload_Folder%"
Set "Setup_File=%MyDownload_Folder%\vtuploader2.2.exe"
echo(
echo       Please wait a while ! downloading "vtuploader2.2.exe" is in progress ...
Rem Downloading vtuploader2.2.exe to the temporary folder
Call :Download "%URL%" "%Setup_File%"
cls
Color 9A
Title Installing "vtuploader2.2.exe" is in progress ...
echo(
echo                 Installing "vtuploader2.2.exe" is in progress ...
Rem Silent installation of vtuploader2.2.exe the uploading tool
Call :Install_Silently %Setup_File%
Rem Removing the download folder
rem Call :Clean_Folder %MyDownload_Folder%
Goto :Main_Virustotal
::******************************************************************************************************
:CreateFileList2Upload
Mode con cols=100 lines=5 & color 9E
setlocal ENABLEDELAYEDEXPANSION
Set "TmpFile=%Temp%\TmpFile.txt"
Set "OutPutFile=%~dp0Reg_Paths_EXE.txt"
Set "All_Users=%ProgramData%\Microsoft\Windows\Start Menu\Programs\Startup"
Set "Current_User=%UserProfile%\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Startup"
Set StartupFolders="%All_Users%" "%Current_User%"
Set "Links=url lnk"
If Exist "%TmpFile%" Del "%TmpFile%"
Set "TmpVbs=%Tmp%\%~n0.vbs"
 
::************************************************************
(
   echo set Ws = CreateObject("WScript.Shell"^)
   echo set Lnk = Ws.Createshortcut(WScript.Arguments(0^)^)
   echo WScript.echo Chr(34^) ^& Lnk.TargetPath ^& Chr(34^)
)>"%Tmpvbs%"
 
::************************************************************
Set Keys=^
^ "HKCU\SOFTWARE\Microsoft\Windows\CurrentVersion\Run" ^
^ "HKLM\Software\Microsoft\Windows\CurrentVersion\Run"
 
If Exist "%TmpFile%" Del "%TmpFile%"
If Exist "%OutPutFile%" Del "%OutPutFile%"
 
For %%K in (%Keys%) Do (  
  cls
  echo;
  Echo             ***************************** Scanning in progress *****************************
  Echo             %%K
  Echo             ********************************************************************************
  Timeout /T 2 /Nobreak>nul
  reg query "%%~K" /s >> "%TmpFile%"
)
 
(
   For %%i in (%StartupFolders%) Do (
       For %%j in (%Links%) Do (
           For /f "delims=" %%L in ('Dir /b /s "%%~i" ^|find /i "%%~j"') Do (
              If "%ErrorLevel%" NEQ "1" (
                   echo  ----------------------------------------------------------------------
                   echo "%%L" & Call:ExtractTarget "%%L"
                   echo  ----------------------------------------------------------------------
               )    
           )
       )          
   )
)>> "%TmpFile%"
 
Call :Extract "%TmpFile%" "%OutPutFile%"
 
For /f "delims=" %%a in ('Type "%OutPutFile%"') do (
    echo "%%~a">>"%Files_List2Upload%"
)
 
If Exist "%TmpFile%" Del "%TmpFile%"
If Exist "%OutPutFile%" Del "%OutPutFile%"
Start "" "%Files_List2Upload%"
Goto Main_Virustotal
::****************************************************
:Extract <InputData> <OutPutData>
(
echo Data = WScript.StdIn.ReadAll
echo Data = Extract(Data,"(^?^!.*(REG_SZ^|REG_EXPAND_SZ^)^)\b.*(\w^).*(\.exe^|\.vbs^|\.wsf^|\.vbe^|\.cmd^|\.bat^)"^)
echo WScript.StdOut.WriteLine Data
echo '************************************************
echo Function Extract(Data,Pattern^)
echo    Dim oRE,oMatches,Match,Line
echo    set oRE = New RegExp
echo    oRE.IgnoreCase = True
echo    oRE.Global = True
echo    oRE.Pattern = Pattern
echo    set oMatches = oRE.Execute(Data^)
echo    If not isEmpty(oMatches^) then
echo        For Each Match in oMatches  
echo            Line = Line ^& Trim(Match.Value^) ^& vbcrlf
echo        Next
echo        Extract = Line
echo    End if
echo End Function
echo '************************************************
)>"%Tmpvbs%"
cscript /nologo "%Tmpvbs%" < "%~1" > "%~2"
If Exist "%Tmpvbs%" Del "%Tmpvbs%"
exit /b
::**********************************************************************************
:Download <url> <File>
Powershell.exe -command "(New-Object System.Net.WebClient).DownloadFile('%1','%2')"
exit /b
::**********************************************************************************
:Install_Silently <Setup_File>
"%~1" /S
exit /b
::**********************************************************************************
:virus_effect_remover
cls
Color 9E
Set "URL=https://freefr.dl.sourceforge.net/project/viruseffectremo/binary/3.2.2.26/VirusEffectRemover_3.2.2.26-Setup.exe"
set "MyDownload_Folder=%temp%\MyDownload"
IF /I "%PROCESSOR_ARCHITECTURE%"=="x86" (
        Set "File_EXE=%ProgramFiles%\Virus Secure Lab\Virus Effect Remover\Virus Effect Remover.exe"
    ) else (
        Set "File_EXE=%ProgramFiles(x86)%\Virus Secure Lab\Virus Effect Remover\Virus Effect Remover.exe"
)
If Not Exist "%File_EXE%" (
    Mode con cols=90 lines=3
    If Not Exist "%MyDownload_Folder%" MD "%MyDownload_Folder%"
    Set "Setup_File=%MyDownload_Folder%\VirusEffectRemover_3.2.2.26-Setup.exe"
    echo(
    echo    Please wait a while ! downloading "VirusEffectRemover_Setup.exe" is in progress ...
    Call :Download "%URL%" "%Setup_File%"
    cls
    Title Installing "VirusEffectRemover_3.2.2.26-Setup.exe" is in progress ...
    echo(
    echo           Installing "VirusEffectRemover_3.2.2.26-Setup.exe" is in progress ...
    Start "Installing VirusEffectRemover" /wait "%Setup_File%" /VERYSILENT
    Start "" /MAX "%File_EXE%"
) else (
    Start "" /MAX "%File_EXE%"
)  
Goto :Main
::**********************************************************************************
:ExtractTarget <Link>
cscript //nologo "%Tmpvbs%" "%~1"
Exit /b
::**********************************************************************************
:USB_Cleaner
Set "TmpLogFile=%Tmp%\%~n0_Tmp.txt"
Set "LogUSB=%~dp0%~n0_LogUSB.txt"
If exist "%TmpLogFile%" Del "%TmpLogFile%"
If exist "%LogUSB%" Del "%LogUSB%"
cls
REM Clean USB Drives and restore hidden files
for /f "tokens=2" %%i in ('wmic logicaldisk where "drivetype=2" ^|find /i ":"') do (Set MyUSB=%%i)
setlocal ENABLEDELAYEDEXPANSION
set _drive=%MyUSB%
If exist !_drive! (
Color 9E & Mode con cols=85 lines=6
cls
echo(
echo                ---------------------------------------------------------
echo                           Your usb key is connected as !_drive!
echo                ---------------------------------------------------------
echo(
Timeout /T 3 /NoBreak>nul
Cls
echo(
Color 9E & Mode con cols=85 lines=3
echo(
Echo    Removing malicious files/unhiding files... Please wait, this may take a while...
del /s /f /q !_drive!\*.lnk>>"%TmpLogFile%" 2>&1
Cmd /U /C Type "%TmpLogFile%" > "%LogUSB%"
attrib -s -h -a -r /s /d !_drive!\*.*
Start "" "%LogUSB%"
Explorer "!_drive!\" & Goto Main
) ELSE (
cls
color 9C & Mode con cols=85 lines=6
echo.
echo           ---------------------------------------------------------
echo                         Your usb key is not detected
echo           ---------------------------------------------------------
echo.
Timeout /T 3 /NoBreak>nul
)
Goto :Main