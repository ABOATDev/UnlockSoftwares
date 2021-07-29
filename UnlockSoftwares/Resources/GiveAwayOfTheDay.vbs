Option Explicit
Dim URL,fso,ws,LogFile,sSrcUrl,oHTTP,bGetAsAsync,HTA,Data
Set fso = CreateObject("Scripting.FileSystemObject")
Set ws = CreateObject("Wscript.Shell")
LogFile = Left(Wscript.ScriptFullName,InstrRev(Wscript.ScriptFullName, ".")) & "hta"
if fso.FileExists(LogFile) Then
    fso.DeleteFile LogFile
end If
 
If IsInternetConnected = True Then
   If Lang = True Then
       sSrcUrl = "https://fr.giveawayoftheday.com/"
   Else
       sSrcUrl = "https://www.giveawayoftheday.com/"
   End if
End If
 
Set oHTTP = CreateObject("MSXML2.ServerXMLHTTP.6.0")
bGetAsAsync = False
oHTTP.open "GET", sSrcUrl, bGetAsAsync
oHTTP.send
If oHTTP.status <> 200 Then
WScript.Echo "unexpected status = " & oHTTP.status & vbCrLf & oHTTP.statusText
WScript.Quit
End If
Data = oHTTP.responseText
HTA = "<html>" & vbCrLf &_
"<title>Le cadeau du jour logiciel</title>" & vbCrLf &_
"<head>" & vbCrLf &_
"<HTA:APPLICATION" & vbCrLf &_
  "APPLICATIONNAME=""GiveAway of the Day""" & vbCrLf &_
  "Icon=DxDiag.exe" & vbCrLf &_
  "BORDER=""thin""" & vbCrLf &_
  "MAXIMIZEBUTTON=""no""" & vbCrLf &_
  "MINIMIZEBUTTON=""no""" & vbCrLf &_
  "SCROLL=""no""" & vbCrLf &_
  "SINGLEINSTANCE=""yes""" & vbCrLf &_
  "CONTEXTMENU=""no""" & vbCrLf &_
  "SELECTION=""no""/>" & vbCrLf &_
"<SCRIPT language=""VBScript"">" & vbCrLf &_
"Sub Window_OnLoad" & vbCrLf &_
    "window.resizeTo 450,380" & vbCrLf &_
    "WindowLeft = (window.screen.availWidth - 450)" & vbCrLf &_
    "WindowTop  = (window.screen.availHeight - 380)" & vbCrLf &_
    "window.moveTo WindowLeft, WindowTop" & vbCrLf &_
"end sub" & vbCrLf &_
"</script>" & vbCrLf &_
"</head>" & vbCrLf &_
"<center>" & vbCrLf &_
"<meta http-equiv=""Content-Type"" content=""text/html; charset=UTF-8"" />" & vbCrLf &_
"<meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">" & vbCrLf &_
"<link rel=""stylesheet"" href=""https://www.giveawayoftheday.com/css/main.css"" />"
WriteLog HTA,LogFile
WriteLog Extract(Data),LogFile
WriteLog "</html>",LogFile
ws.run chr(34) & LogFile & chr(34)
'****************************************************************
Function Extract(Data)
    Dim oRE,oMatches,Match,Line
    set oRE = New RegExp
    oRE.IgnoreCase = True
    oRE.Global = True
    oRE.MultiLine = True
    oRE.Pattern = "<div class=""giveaway_wrap cf"">(?:(?!""giveaway_counter first"">)[\s\S])*</div>"
    set oMatches = oRE.Execute(Data)
    If not isEmpty(oMatches) then
        For Each Match in oMatches
            Line = Match.Value
            Extract = Line
        Next
    End if
End Function
'*****************************************************************
Sub WriteLog(strText,LogFile)
    Dim fs,ts
    Const ForAppending = 8
    Set fs = CreateObject("Scripting.FileSystemObject")
    Set ts = fs.OpenTextFile(LogFile,ForAppending,True,-1)
    ts.WriteLine strText
    ts.Close
End Sub
'*****************************************************************
Function Lang()
Dim sComputer,oWMI,colOperatingSystems,oOS,iOSLang
    sComputer = "."
    Set oWMI = GetObject("winmgmts:" _
        & "{impersonationLevel=impersonate}!\\" _
        & sComputer _
        & "\root\cimv2")
Set colOperatingSystems = oWMI.ExecQuery _
        ("Select * from Win32_OperatingSystem")
For Each oOS in colOperatingSystems
   iOSLang = oOS.OSLanguage
Next
If (iOSLang = 1036) Then
   Lang = True
Else
   Lang = False
End If
End Function
'*****************************************************************
Function IsInternetConnected()
Dim MyLoop,strComputer,objPing,objStatus
IsInternetConnected = False
MyLoop = True
While MyLoop = True
    strComputer = "smtp.gmail.com"
    Set objPing = GetObject("winmgmts:{impersonationLevel=impersonate}!\\").ExecQuery _
    ("select * from Win32_PingStatus where address = '" & strComputer & "'")
    For Each objStatus in objPing
        If objStatus.Statuscode = 0 Then
            MyLoop = False
           IsInternetConnected = True
            Exit Function
        End If
    Next
   MsgBox "Check your internet connection !",vbExclamation,"Check your internet connection !"
    Pause(10) 'To sleep for 10 secondes
Wend
End Function
'******************************************************************
 Sub Pause(NSeconds)
    Wscript.Sleep(NSeconds*1000)
 End Sub
'****************************************************************