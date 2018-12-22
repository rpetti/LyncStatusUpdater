Set oShell = CreateObject ("Wscript.Shell")
scriptdir = CreateObject("Scripting.FileSystemObject").GetParentFolderName(WScript.ScriptFullName)
Dim strArgs
strArgs = Replace("""" & scriptdir & "\bin\Debug\LyncStatusUpdater.exe"" {0}","{0}",Wscript.Arguments.Item(0))
Wscript.Echo strArgs
oShell.Run strArgs, 0, false