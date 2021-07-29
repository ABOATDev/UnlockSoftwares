@echo off
Color 0A & Mode con cols=65 lines=3 
Title Profils with Wifi Passwords Keys
echo.
Echo      Please Wait ... Export Wifi profiles is in progress ...
netsh wlan show profiles  | Findstr /i "Profil" > C:\ProgramData\ABOAT\MultiCrack\Profiles.txt
for /f "delims=: Tokens=2" %%a in (C:\ProgramData\ABOAT\MultiCrack\Profiles.txt) do (netsh wlan show profiles key=clear name=%%a >> C:\ProgramData\ABOAT\MultiCrack\Profiles_WifiTmp.txt)
Cmd /U /C Type C:\ProgramData\ABOAT\MultiCrack\Profiles_WifiTmp.txt > C:\ProgramData\ABOAT\MultiCrack\Profiles_Wifi.txt
Del C:\ProgramData\ABOAT\MultiCrack\Profiles_WifiTmp.txt & Del C:\ProgramData\ABOAT\MultiCrack\Profiles.txt
start C:\ProgramData\ABOAT\MultiCrack\profiles_Wifi.txt