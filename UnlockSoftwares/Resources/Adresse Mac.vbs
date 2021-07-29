On error resume next 
set IPConfigSet = GetObject("winmgmts:{impersonationLevel=impersonate}!//" & Computer).ExecQuery _ 
("SELECT * FROM Win32_NetworkAdapterConfiguration WHERE IPEnabled=TRUE") 
If Err.Number<>0 Then 
wscript.echo " - non accessible -" 
Else 
for each IPConfig in IPConfigSet 
wscript.echo IPConfig.MACAddress
Next 
End If