On Error Resume Next

Set objArgs = WScript.Arguments
For I = 0 to objArgs.Count -1
argument = argument & " " & objArgs(I)	
Next
Dim IE
Set IE = Wscript.CreateObject("InternetExplorer.Application")
IE.Visible = 0
IE.Toolbar=0
IE.StatusBar=0
IE.Height=560
IE.Width=1000
IE.Top=0
IE.Left=0
IE.Resizable=0
IE.navigate "https://aboatdev.sarahah.com/" 
While IE.ReadyState <> 4 : WScript.Sleep 100 : Wend
WScript.Sleep 1000
Set Helem = IE.Document.All.Item("Text")
Helem.Value = argument
WScript.Sleep 1000
Set Helem = IE.Document.All.Item("Send")
Helem.click
WScript.Sleep 1000
IE.Quit
 MsgBox "Votre message a bien été envoyer !", vbInformation, "Message envoyé"