@echo off
Set "Copyright=(C) by Hackoo 2018"
Set "Downloader=%Temp%\Hackoo_Downloader.vbs"
:menuLOOP
Title Download The Lastest Version Of Security And Removal Tools  %Copyright%
Color 9E & Mode 95,19
echo(
echo(       ==================================== Menu ==========================================
echo(
for /f "tokens=2* delims=_ " %%A in ('"findstr /b /c:":menu_" "%~f0""') do echo         %%A  %%B
echo(
echo(       ====================================================================================
set choice=
echo( & set /p choice=Make a choice or press ENTER to exit: || GOTO :EOF
echo( & call :menu_[%choice%]
GOTO:menuLOOP
::*************************************************************************************
:menu_[1] Download and Scan with the lastest version of AdwCleaner Tool
Cls & Mode 70,3
echo(
Set "URL=https://download.toolslib.net/download/file/1/1511"
Title Please wait ... Downloading AdwCleaner is in progress ...
echo        Please wait ... Downloading AdwCleaner is in progress ...
Call :Download %URL%
Explorer %~dp0
Goto:MenuLoop
::*************************************************************************************
:menu_[2] Download and Scan with the lastest version of Malwarebytes Anti-Malware
Title Downloading Malwarebytes Anti-Malware ...
cls & Mode 70,3
echo(
echo       Please wait ... Downloading Malwarebytes is in progress ...
Set "URL=https://downloads.malwarebytes.com/file/mb3/"
Call :Download %URL%
Explorer %~dp0
GOTO:menuLOOP
::*************************************************************************************
:menu_[3] Download and Scan with the lastest version of Kaspersky Virus Removal Tool
Title Downloading Kaspersky Virus Removal Tool ...
Cls & Mode 70,3
echo(
Set "URL=http://devbuilds.kaspersky-labs.com/devbuilds/KVRT/latest/full/KVRT.exe"
echo     Please wait... Downloading Kaspersky Virus Removal Tool....
Call :Download %URL%
Explorer %~dp0
Goto:MenuLoop
::**************************************************************************************
:menu_[4] Download and Scan with the lastest version of Kaspersky System Checker Tool
Title Downloading Kaspersky System Checker Tool ...
Cls & Mode 70,3
echo(
Set "URL=https://prtools.s.kaspersky-labs.com/en-us-xb2c/special/ksch1.2/ksc_launcher.exe"
echo     Please wait... Downloading Kaspersky System Checker Tool....
Call :Download %URL%
Explorer %~dp0
Goto:MenuLoop
::**************************************************************************************
:menu_[5] Download and Scan with the lastest version of Safety Scanner Removal Tool
Title Downloading Safety Scanner Removal Tool ...
Cls & Mode 70,3
echo(
Set "URL=http://definitionupdates.microsoft.com/download/definitionupdates/safetyscanner/x86/msert.exe"
echo       Please wait... Downloading Safety scanner Removal Tool...
Call :Download %URL%
Explorer %~dp0
Goto:MenuLoop
::**************************************************************************************
:menu_[6] Download and Scan with the lastest version of SUPERAntiSpywarePro Removal Tool
Title Downloading SUPERAntiSpywarePro ...
Cls & Mode 70,3
echo(
Set "URL=http://cdn.superantispyware.com/SUPERAntiSpywarePro.exe"
echo         Please wait ... Downloading SUPERAntiSpywarePro ...
Call :Download %URL%
Explorer %~dp0
Goto:MenuLoop
::*************************************************************************************
:menu_[7] Download and Scan with the lastest version of HitMan Pro Tool
Title Downloading HitMan Pro ...
Cls & Mode 70,3
echo(
Set "URL=http://get.hitmanpro.com/"
echo        Please wait ... Downloading HitMan Pro is in progress ...
Call :Download %URL%
Explorer %~dp0
Goto:MenuLoop
::*************************************************************************************
:menu_[8] Download and Scan with the lastest Comodo Cleaning Essentials (x86) Tool
Title Downloading Comodo Cleaning Essentials (x86) ...
Cls & Mode 70,3
echo(
Set "URL=http://cdn.download.comodo.com/cce/download/setups/cce_public_x86.zip"
echo         Please wait ... Comodo Cleaning Essentials(x86) ...
Call :Download %URL%
Explorer %~dp0
Goto:MenuLoop
::*************************************************************************************
:menu_[9] Download and Scan with the lastest Comodo Cleaning Essentials (x64) Tool
Title Downloading Comodo Cleaning Essentials (64 bits) ...
Cls & Mode 70,3
echo(
Set "URL=http://cdn.download.comodo.com/cce/download/setups/cce_public_x64.zip"
echo         Please wait ... Comodo Cleaning Essentials(x64) ...
Call :Download %URL%
Explorer %~dp0
Goto:MenuLoop
::*************************************************************************************
:menu_[10] Download and Scan with the lastest version of Malware-fighter-trial Tool
Title Downloading Malware-fighter-trial ...
Cls & Mode 70,3
echo(
Set "URL=http://update.iobit.com/dl/imfv5-setup-trial.exe"
echo         Please wait ... Downloading Malware-fighter-trial ...
Call :Download %URL%
Explorer %~dp0
Goto:MenuLoop
::*************************************************************************************
:menu_[11] Download and Scan with the lastest version of Malware Defender (32bits) Tool
Title Downloading Malware Defender (cn360) ...
Cls & Mode 70,3
echo(
Set "URL=http://dl.360safe.com/md_setup_en.exe"
echo         Please wait ... Downloading Malware Defender (cn360) ...
Call :Download %URL%
Explorer %~dp0
Goto:MenuLoop
::*************************************************************************************
:Download <url>
(
echo Option Explicit
echo If AppPrevInstance^(^) Then
echo    MsgBox "The script is already launching" ^& vbCrlf ^&_
echo    CommandLineLike^(WScript.ScriptName^),VbExclamation,"The script is already launching"    
echo    WScript.Quit  
echo Else  
echo    Const Copyright =" (C) by Hackoo 2018"
echo    Dim Title : Title = "Download The Lastest Version Of Security And Removal Tools"
echo    Const WHR_EnableRedirects = 6
echo    Dim Base_Link,Dynamic_Link,Flag,Question,DirectLink,Save2File
echo    Dim fso,ws,Temp,WaitingMsg,oExec
echo    Set fso = CreateObject^("Scripting.FileSystemObject"^)
echo    Set ws = CreateObject^("WScript.Shell"^)
echo    Temp = ws.ExpandEnvironmentStrings^("%%Temp%%"^)
echo If WSH.Arguments.Count = 0 Then
echo    MsgBox "Usage in command line : "^& vbCrlf ^&_
echo    "Cscript //nologo "^& DblQuote^(WSH.Scriptname^) ^& " " ^& DblQuote^("URL"^),_
echo    vbExclamation,Title ^& Copyright
echo    Wscript.Quit^(1^)  
echo End If
echo    Base_Link = wscript.Arguments^(0^)
echo    If CheckDirectLink^(Base_Link^) = True And Instr^(Base_Link,"?"^) = 0 Then 'Check if it is a direct link
echo        Save2File = GetFileNamefromDirectLink^(Base_Link^)
echo        If Save2File = "" Then
echo            MsgBox "An unknown error has occurred ! Quitting the script !",vbCritical,Title
echo            Wscript.Quit^(^)
echo        End If
echo        WaitingMsg = "Please wait ... The download of : <font color=Yellow>"^& DblQuote^(Save2File^) ^& "</font> is in progress ..."
echo        Call CreateProgressBar^(Title,WaitingMsg^)'Creation of Waiting Bar
echo        Call LaunchProgressBar^(^) 'Launch of the Waiting Bar
echo        Call Download^(Base_Link,Save2File^)
echo        pause^(3^)
echo        Call CloseProgressBar^(^)
echo        ws.Popup "The download of the file : "^& Save2File ^& vbCrlf ^& "is completed successfully ! ",3,Title,vbInformation
echo        'MsgBox "The download of the file : "^& Save2File ^& vbCrlf ^&_
echo        '"is Completed !",vbInformation,Title
echo        wscript.Quit^(^)
echo    End If
echo    Call GetHeaderLocation^(Base_Link^)
echo    If Flag = True And CheckDirectLink^(GetHeaderLocation^(Base_Link^)^) = True Then 'Checking for a direct link of Malwarebytes
echo        Save2File = GetFileNamefromDirectLink^(GetHeaderLocation^(Base_Link^)^)
echo        If Save2File = "" Then
echo            MsgBox "An unknown error has occurred ! Quitting the script !",vbCritical,Title
echo            Wscript.Quit^(^)
echo        End If
echo        DirectLink = GetHeaderLocation^(Base_Link^)
echo 'wscript.echo DirectLink ^& vbCrlf ^& Save2File
echo        'Question = MsgBox^("Did you want to download this file ?" ^& vbCrlf ^&_
echo        'Save2File,vbQuestion+vbYesNo,Title^)
echo        'If Question = vbYes Then
echo            If Save2File ^<^> "" Then
echo                WaitingMsg = "Please wait ... The download of : <font color=Yellow>"^& DblQuote^(Save2File^) ^& "</font> is in progress ..."
echo                Call CreateProgressBar^(Title,WaitingMsg^)'Creation of Waiting Bar
echo                Call LaunchProgressBar^(^) 'Launch of the Waiting Bar
echo                Call Download^(DirectLink,Save2File^)
echo                Call CloseProgressBar^(^)
echo                ws.Popup "The download of the file : "^& Save2File ^& vbCrlf ^& "is completed successfully ! ",3,Title,vbInformation
echo                'MsgBox "The download of the file : "^& Save2File ^& vbCrlf ^&_
echo                '"is Completed !",vbInformation,Title
echo                Wscript.Quit^(^)
echo            End If 
echo        'End If
echo    ElseIf Instr^(Base_Link,"toolslib"^) ^<^> 0 And Flag = True Then 'for Adwcleaner
echo        Dynamic_Link = Extract_Dynamic_Link^(GetDataFromURL^(Base_Link,"Get", ""^)^)
echo        Save2File = GetFileName^(GetHeaderLocation^(Dynamic_Link^)^)
echo        If Save2File = "" Then
echo            MsgBox "An unknown error has occurred ! Quitting the script !",vbCritical,Title
echo            Wscript.Quit^(^)
echo        End If
echo        'Question = MsgBox^("The Dynamic Link is = "^& Dynamic_Link ^& vbcrlf ^& vbcrlf ^&_
echo        '"Response of The Dynamic Link is : "^& vbcrlf ^& GetHeaderLocation^(Dynamic_Link^) ^& vbCrlf ^& vbCrlf ^&_
echo        '"Extracted FileName is = " ^& Save2File,vbYesNo+vbQuestion,Title^)
echo        'If Question = vbYes Then
echo            WaitingMsg = "Please wait ... The download of : <font color=Yellow>"^& DblQuote^(Save2File^) ^& "</font> is in progress ..."
echo            Call CreateProgressBar^(Title,WaitingMsg^)'Creation of Waiting Bar
echo            Call LaunchProgressBar^(^) 'Launch of the Waiting Bar
echo            Call Download^(Dynamic_Link,Save2File^)
echo            Call CloseProgressBar^(^)
echo            ws.Popup "The download of the file : "^& Save2File ^& vbCrlf ^& "is completed successfully ! ",3,Title,vbInformation
echo            'wscript.echo "The download of the file : "^& Save2File ^& " is Completed !"
echo            'MsgBox "The download of the file : "^& Save2File ^& vbCrlf ^&_
echo            '"is Completed !",vbInformation,Title
echo        'Else
echo            Wscript.Quit^(^)
echo        'End If    
echo    ElseIf Instr^(Base_Link,"php"^) ^> 0 And Flag = False Then
echo        Save2File = GetFileName^(GetHeaderLocation^(Base_Link^)^) ' for site of autoitscript.fr
echo        If Save2File = "" Then
echo            MsgBox "An unknown error has occurred ! Quitting the script !",vbCritical,Title
echo            Wscript.Quit^(^)
echo        End If
echo        'Question = MsgBox^("Did you want to download this file ?" ^& vbCrlf ^&_
echo        'Save2File,vbQuestion+vbYesNo,Title^)
echo        'If Question = vbYes Then
echo            WaitingMsg = "Please wait ... The download of : <font color=Yellow>"^& DblQuote^(Save2File^) ^& "</font> is in progress ..."
echo            Call CreateProgressBar^(Title,WaitingMsg^)'Creation of Waiting Bar
echo            Call LaunchProgressBar^(^) 'Launch of the Waiting Bar
echo            Call Download^(Base_Link,Save2File^)
echo            pause^(3^)
echo            Call CloseProgressBar^(^)
echo            MsgBox "The download of the file : "^& Save2File ^& vbCrlf ^&_
echo            "is Completed !",vbInformation,Title
echo        'Else
echo        '   Wscript.Quit^(^)
echo        'End If
echo    End If
echo End If
echo '------------------------------------------------
echo Function GetHeaderLocation^(URL^)
echo    On Error Resume Next
echo    Dim h,GetLocation
echo    Set h = CreateObject^("WinHttp.WinHttpRequest.5.1"^)
echo    h.Option^(WHR_EnableRedirects^) = False
echo    h.Open "HEAD", URL , False
echo    h.Send^(^)
echo    GetLocation = h.GetResponseHeader^("Location"^)
echo    If Err = 0 Then
echo        Flag = True
echo        GetHeaderLocation = GetLocation
echo    Else
echo        Flag = False
echo        GetHeaderLocation = h.GetResponseHeader^("Content-Disposition"^)
echo    End If 
echo End Function
echo '---------------------------------------------
echo Function GetFileName^(Data^)
echo    Dim regEx, Match, Matches,FileName
echo    Set regEx = New RegExp
echo    regEx.Pattern = "\x27{2}(\w.*)"
echo    regEx.IgnoreCase = True
echo    regEx.Global = True
echo    If regEx.Test^(Data^) Then
echo        Set Matches = regEx.Execute^(Data^)
echo        For Each Match in Matches
echo            FileName = Match.subMatches^(0^)
echo        Next
echo    Else
echo        Set regEx = New RegExp
echo        regEx.Pattern = "\x22(\w.*)\x22"
echo        regEx.IgnoreCase = True
echo        regEx.Global = True
echo        Set Matches = regEx.Execute^(Data^)
echo        For Each Match in Matches
echo            FileName = Match.subMatches^(0^)
echo        Next
echo    End If
echo    GetFileName = FileName
echo End Function
echo '---------------------------------------------
echo Function Extract_Dynamic_Link^(Data^)
echo    Dim regEx, Match, Matches,Dynamic_Link
echo    Set regEx = New RegExp
echo    regEx.Pattern = Base_Link ^& "\?s=[^""]*"
echo    regEx.IgnoreCase = True
echo    regEx.Global = True
echo    Set Matches = regEx.Execute^(Data^)
echo    For Each Match in Matches
echo        Dynamic_Link = Match.Value
echo    Next
echo    Extract_Dynamic_Link = Dynamic_Link
echo End Function
echo '------------------------------------------------
echo Function GetDataFromURL^(strURL, strMethod, strPostData^)
echo    Dim lngTimeout
echo    Dim strUserAgentString
echo    Dim intSslErrorIgnoreFlags
echo    Dim blnEnableRedirects
echo    Dim blnEnableHttpsToHttpRedirects
echo    Dim strHostOverride
echo    Dim strLogin
echo    Dim strPassword
echo    Dim strResponseText
echo    Dim objWinHttp
echo    lngTimeout = 59000
echo    strUserAgentString = "http_requester/0.1"
echo    intSslErrorIgnoreFlags = 13056 ' 13056: ignore all err, 0: accept no err
echo    blnEnableRedirects = True
echo    blnEnableHttpsToHttpRedirects = True
echo    strHostOverride = ""
echo    strLogin = ""
echo    strPassword = ""
echo    Set objWinHttp = CreateObject^("WinHttp.WinHttpRequest.5.1"^)
echo    objWinHttp.SetTimeouts lngTimeout, lngTimeout, lngTimeout, lngTimeout
echo    objWinHttp.Open strMethod, strURL
echo    If strMethod = "POST" Then
echo        objWinHttp.setRequestHeader "Content-type", _
echo        "application/x-www-form-urlencoded"
echo    End If
echo    If strHostOverride ^<^> "" Then
echo        objWinHttp.SetRequestHeader "Host", strHostOverride
echo    End If
echo    objWinHttp.Option^(0^) = strUserAgentString
echo    objWinHttp.Option^(4^) = intSslErrorIgnoreFlags
echo    objWinHttp.Option^(6^) = blnEnableRedirects
echo    objWinHttp.Option^(12^) = blnEnableHttpsToHttpRedirects
echo    If ^(strLogin ^<^> ""^) And ^(strPassword ^<^> ""^) Then
echo        objWinHttp.SetCredentials strLogin, strPassword, 0
echo    End If    
echo    On Error Resume Next
echo    objWinHttp.Send^(strPostData^)
echo    If Err.Number = 0 Then
echo        If objWinHttp.Status = "200" Then
echo            GetDataFromURL = objWinHttp.ResponseText
echo        Else
echo            GetDataFromURL = "HTTP " ^& objWinHttp.Status ^& " " ^& _
echo            objWinHttp.StatusText
echo        End If
echo    Else
echo        GetDataFromURL = "Error " ^& Err.Number ^& " " ^& Err.Source ^& " " ^& _
echo        Err.Description
echo    End If
echo    On Error GoTo 0
echo    Set objWinHttp = Nothing
echo End Function
echo '------------------------------------------------
echo Sub Download^(URL,Save2File^)
echo    Dim File,Line,BS,ws
echo    On Error Resume Next
echo    Set File = CreateObject^("WinHttp.WinHttpRequest.5.1"^)
echo    File.Open "GET",URL, False
echo    File.Send^(^)
echo    If err.number ^<^> 0 then
echo        Line  = Line ^&  vbcrlf ^& "Error Getting File"
echo        Line  = Line ^&  vbcrlf ^& "Error " ^& err.number ^& "(0x" ^& hex^(err.number^) ^& ") " ^& vbcrlf ^&_
echo        err.description
echo        Line  = Line ^&  vbcrlf ^& "Source " ^& err.source
echo        MsgBox Line,vbCritical,"Error getting file"
echo        Err.clear
echo        wscript.quit
echo    End If
echo    If File.Status = 200 Then ' File exists and it is ready to be downloaded
echo        Set BS = CreateObject^("ADODB.Stream"^)
echo        Set ws = CreateObject^("wscript.Shell"^)
echo        BS.type = 1
echo        BS.open
echo        BS.Write File.ResponseBody
echo        BS.SaveToFile Save2File, 2
echo    ElseIf File.Status = 404 Then
echo        MsgBox "File Not found : " ^& File.Status,vbCritical,"Error File Not Found"
echo    Else
echo        MsgBox "Unknown Error : " ^& File.Status,vbCritical,"Error getting file"
echo    End If
echo End Sub
echo '------------------------------------------------
echo Function GetFileNamefromDirectLink^(URL^)
echo    Dim ArrFile,FileName
echo    ArrFile = Split^(URL,"/"^)
echo    FileName = ArrFile^(UBound^(ArrFile^)^)
echo    GetFileNamefromDirectLink = FileName
echo End Function
echo '------------------------------------------------
echo Function CheckDirectLink^(URL^)
echo    Dim regEx
echo    Set regEx = New RegExp
echo    regEx.Pattern = "(.exe|.zip|.rar|.msi|.vbs|.bat|.hta|.txt|.log|.doc" ^& _
echo    "|.docx|.xls|.xlsx|.pdf|.mp3|.mp4|.avi|.png|.jpg|.jpeg|.bmp|.gif)"
echo    regEx.IgnoreCase = True
echo    regEx.Global = False
echo    If regEx.Test^(URL^) Then
echo        CheckDirectLink = True
echo    End If
echo End Function
echo '------------------------------------------------
echo '**********************************************************************************************
echo Sub CreateProgressBar^(Title,WaitingMsg^)
echo    Dim ws,fso,f,f2,ts,ts2,Ligne,i,fread,LireTout,NbLigneTotal,Temp,PathOutPutHTML,fhta,oExec
echo    Set ws = CreateObject^("wscript.Shell"^)
echo    Set fso = CreateObject^("Scripting.FileSystemObject"^)
echo    Temp = WS.ExpandEnvironmentStrings^("%%Temp%%"^)
echo    PathOutPutHTML = Temp ^& "\Barre.hta"
echo    Set fhta = fso.OpenTextFile^(PathOutPutHTML,2,True^)
echo    fhta.WriteLine "<HTML>"
echo    fhta.WriteLine "<HEAD>"
echo    fhta.WriteLine "<Title>  " ^& Title ^& Copyright ^& "</Title>"
echo    fhta.WriteLine "<HTA:APPLICATION"
echo    fhta.WriteLine "ICON = ""magnify.exe"" "
echo    fhta.WriteLine "BORDER=""THIN"" "
echo    fhta.WriteLine "INNERBORDER=""NO"" "
echo    fhta.WriteLine "MAXIMIZEBUTTON=""NO"" "
echo    fhta.WriteLine "MINIMIZEBUTTON=""NO"" "
echo    fhta.WriteLine "SCROLL=""NO"" "
echo    fhta.WriteLine "SYSMENU=""NO"" "
echo    fhta.WriteLine "SELECTION=""NO"" "
echo    fhta.WriteLine "SINGLEINSTANCE=""YES"">"
echo    fhta.WriteLine "</HEAD>"
echo    fhta.WriteLine "<BODY text=""white""><CENTER>"
echo    fhta.WriteLine "<marquee DIRECTION=""LEFT"" SCROLLAMOUNT=""3"" BEHAVIOR=ALTERNATE><font face=""Comic sans MS"">" ^& WaitingMsg ^&"</font></marquee>"
echo    fhta.WriteLine "<img src=""data:image/gif;base64,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"" />"
echo    fhta.WriteLine "</CENTER></BODY></HTML>"
echo    fhta.WriteLine "<SCRIPT LANGUAGE=""VBScript""> "
echo    fhta.WriteLine "Set ws = CreateObject(""wscript.Shell"")"
echo    fhta.WriteLine "Temp = WS.ExpandEnvironmentStrings(""%%Temp%%"")"
echo    fhta.WriteLine "Sub window_onload()"
echo    fhta.WriteLine "    CenterWindow 575,100"
echo    fhta.WriteLine "    Self.document.bgColor = ""DarkOrange"" "
echo    fhta.WriteLine " End Sub"
echo    fhta.WriteLine " Sub CenterWindow(x,y)"
echo    fhta.WriteLine "    Dim iLeft,itop"
echo    fhta.WriteLine "    window.resizeTo x,y"
echo    fhta.WriteLine "    iLeft = window.screen.availWidth/2 - x/2"
echo    fhta.WriteLine "    itop = window.screen.availHeight/2 - y/2"
echo    fhta.WriteLine "    window.moveTo ileft,itop"
echo    fhta.WriteLine "End Sub"
echo    fhta.WriteLine "</script>"
echo    fhta.close
echo End Sub
echo '**********************************************************************************************
echo Sub LaunchProgressBar^(^)
echo    Set oExec = Ws.Exec^("mshta.exe " ^& Temp ^& "\Barre.hta"^)
echo End Sub
echo '**********************************************************************************************
echo Sub CloseProgressBar^(^)
echo    oExec.Terminate
echo End Sub
echo '**********************************************************************************************
echo Function DblQuote^(Str^)
echo    DblQuote = Chr^(34^) ^& Str ^& Chr^(34^)
echo End Function
echo '**********************************************************************************************
echo Sub Pause^(Secs^)    
echo    Wscript.Sleep^(Secs * 1000^)    
echo End Sub  
echo '**********************************************************************************************
echo Function AppPrevInstance^(^)
echo    With GetObject^("winmgmts:" ^& "{impersonationLevel=impersonate}!\\.\root\cimv2"^)  
echo        With .ExecQuery^("SELECT * FROM Win32_Process WHERE CommandLine LIKE " ^& CommandLineLike^(WScript.ScriptFullName^) ^& _
echo            " AND CommandLine LIKE '%%WScript%%'"^)
echo            AppPrevInstance = ^(.Count ^> 1^)
echo        End With
echo    End With
echo End Function    
echo '*********************************************************************************************
echo Function CommandLineLike^(ProcessPath^)
echo    ProcessPath = Replace^(ProcessPath, "\", "\\"^)
echo    CommandLineLike = "'%%" ^& ProcessPath ^& "%%'"
echo End Function
)>"%Downloader%"
Call "%Downloader%" "%~1"
goto :eof
::*************************************************************************************