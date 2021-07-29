@echo off
REM First release on 01/03/2017 @ 04:45 by Hackoo
REM Updated on 07/03/2017 @ 04:05
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
setlocal enableDelayedExpansion
for /F "skip=1" %%a in ('WMIC Path win32_process where "name like '%%%ProcessName%%%'" get commandline') do (
    for /F "delims=" %%b in ("%%a") do (
        Color 0A
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
Start "" "%Legits_Services_SVCHOST%" & exit
::******************************************************************************?************
This guy is awesome
