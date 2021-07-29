@Echo Off
Mode con cols=90 lines=30

cscript "C:\Program Files\Microsoft Office\Office14\OSPP.VBS" /dstatus
IF NOT %ERRORLEVEL% == 0 GOTO Suite1
cscript "C:\Program Files\Microsoft Office\Office14\OSPP.VBS" /dstatus > C:\ProgramData\ABOAT\MultiCrack\ConfigOffice.txt & start C:\ProgramData\ABOAT\MultiCrack\ConfigOffice.txt
Exit
:Suite1

CLS
cscript "C:\Program Files\Microsoft Office\Office15\OSPP.VBS" /dstatus
IF NOT %ERRORLEVEL% == 0 GOTO Suite2
cscript "C:\Program Files\Microsoft Office\Office15\OSPP.VBS" /dstatus > C:\ProgramData\ABOAT\MultiCrack\ConfigOffice.txt & start C:\ProgramData\ABOAT\MultiCrack\ConfigOffice.txt
Exit
:Suite2

CLS
cscript "C:\Program Files (x86)\Microsoft Office\Office14\OSPP.VBS" /dstatus
IF NOT %ERRORLEVEL% == 0 GOTO Suite3
cscript "C:\Program Files (x86)\Microsoft Office\Office14\OSPP.VBS" /dstatus > C:\ProgramData\ABOAT\MultiCrack\ConfigOffice.txt & start C:\ProgramData\ABOAT\MultiCrack\ConfigOffice.txt
Exit
:Suite3

CLS
cscript "C:\Program Files\Microsoft Office\Office14\OSPP.VBS" /dstatus
IF NOT %ERRORLEVEL% == 0 GOTO Suite4
cscript "C:\Program Files\Microsoft Office\Office14\OSPP.VBS" /dstatus > C:\ProgramData\ABOAT\MultiCrack\ConfigOffice.txt  & start C:\ProgramData\ABOAT\MultiCrack\ConfigOffice.txt
Exit
:Suite4

CLS
cscript "C:\Program Files (x86)\Microsoft Office\Office15\OSPP.VBS" /dstatus
IF NOT %ERRORLEVEL% == 0 GOTO Suite5
cscript "C:\Program Files (x86)\Microsoft Office\Office15\OSPP.VBS" /dstatus  > C:\ProgramData\ABOAT\MultiCrack\ConfigOffice.txt  & start C:\ProgramData\ABOAT\MultiCrack\ConfigOffice.txt
Exit
:Suite5

CLS
cscript "C:\Program Files\Microsoft Office\Office15\OSPP.VBS" /dstatus > C:\ProgramData\ABOAT\MultiCrack\ConfigOffice.txt
IF NOT %ERRORLEVEL% == 0 GOTO Suite6
cscript "C:\Program Files\Microsoft Office\Office15\OSPP.VBS" /dstatus > C:\ProgramData\ABOAT\MultiCrack\ConfigOffice.txt  & start C:\ProgramData\ABOAT\MultiCrack\ConfigOffice.txt
Exit
:Suite6

CLS
cscript "C:\Program Files\Microsoft Office\Office16\OSPP.VBS" /dstatus
IF NOT %ERRORLEVEL% == 0 GOTO Suite7
cscript "C:\Program Files\Microsoft Office\Office16\OSPP.VBS" /dstatus > C:\ProgramData\ABOAT\MultiCrack\ConfigOffice.txt  & start C:\ProgramData\ABOAT\MultiCrack\ConfigOffice.txt
Exit
:Suite7

CLS
cscript "C:\Program Files (x86)\Microsoft Office\Office16\OSPP.VBS" /dstatus
IF NOT %ERRORLEVEL% == 0 GOTO Suite8
cscript "C:\Program Files (x86)\Microsoft Office\Office16\OSPP.VBS" /dstatus > C:\ProgramData\ABOAT\MultiCrack\ConfigOffice.txt  & start C:\ProgramData\ABOAT\MultiCrack\ConfigOffice.txt
Exit
:Suite8

CLS
Color 4
Echo Echec impossible de retrouver la license Office
Pause