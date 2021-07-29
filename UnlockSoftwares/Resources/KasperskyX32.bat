echo
reg add HKLM\SOFTWARE\KasperskyLab\AVP17.0.0\settings\ /v Ins_InitMode /d “1” /t REG_DWORD /f
reg delete HKLM\SOFTWARE\KasperskyLab\LicStrg /f
reg delete HKLM\SOFTWARE\Microsoft\SystemCertificates\SPC /f
RD /S /Q "C:\ProgramData\Kaspersky Lab\AVP17.0.0\Report"
reg add HKLM\SOFTWARE\KasperskyLab\AVP17.0.0 /v LastLicenseNotificationTime /d “1500000000” /t REG_SZ /f
reg add HKCU\SOFTWARE\KasperskyLab\AVP17.0.0 /v HidePromo /t REG_DWORD /d “1” /f
pause