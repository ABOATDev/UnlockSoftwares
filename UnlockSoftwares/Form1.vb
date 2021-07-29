Imports System.Environment
Imports System.IO
Imports System
Imports System.Security
Imports System.Security.Permissions
Imports System.Collections
Imports System.Threading
Imports System.Net
Imports System.ComponentModel
Imports Microsoft.Win32
Imports System.Xml
Imports System.Management
Imports System.Text

Public Class Form1
    Public Erreur As String
    Public ValueurDaete As String
    Const VersionActu As String = "2.1"
    Public PROGRAMDATAChemin As String = GetEnvironmentVariable("PROGRAMDATA") & "\"
    'Projet open source disponible sur GitHub, n'hésitez pas à contribuer à son amélioration !


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'On Error Resume Next


        ITalk_Label11.Text = VersionActu
        ITalk_TabControl2.Alignment = System.Windows.Forms.TabAlignment.Right

        If Label3.Text = "0" Then
            MsgBox("Bienvenue sur UnlockSoftwares !", vbInformation + vbOKOnly, "Bienvenue sur UnlockSoftwares !")
            Label3.Text = "1"
            Me.Activate()
            Me.WindowState = FormWindowState.Normal
            Me.ShowInTaskbar = True
        End If

        Dim Instance As System.Security.Principal.WindowsIdentity
        Instance = System.Security.Principal.WindowsIdentity.GetCurrent()
        Dim principal As New System.Security.Principal.WindowsPrincipal(Instance)
        If (principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator) = True) Then
            ITalk_Label12.Text = "Ouvert avec droit Admin : Oui"
        Else
            ITalk_Label12.Text = "Ouvert avec droit Admin : /!\ NON /!\"
            ITalk_Label12.ForeColor = Color.Red
            ITalk_Label12.Font = New Font("Segoe UI", 9)
            ITalk_Button_157.Visible = True
        End If
        If System.Environment.Is64BitOperatingSystem = True Then
            ITalk_Label13.Text = "Architecture : 64"
        Else
            ITalk_Label13.Text = "Architecture : 32"
        End If
        If System.IO.Directory.Exists("C:\ProgramData\ABOAT\UnlockSoftwares") = False Then
            System.IO.Directory.CreateDirectory("C:\ProgramData\ABOAT\UnlockSoftwares")
        End If

        ITalk_TextBox_Small1.Text = Environment.UserName.ToString()
        ValueurDaete = DateTime.Now.ToString
    End Sub
    Public Sub KillProcess(ByVal ProcessName As String)
        For Each p As Process In Process.GetProcessesByName(ProcessName)
            p.Kill()
        Next
    End Sub
    Private Sub btn_info_Click(sender As Object, e As EventArgs) Handles btn_info.Click
        If ITalk_Label12.Text = "Ouvert avec droit Admin : /!\ NON /!\" = True Then
            If MsgBox("UnlockSoftwares n'est pas exécuté en tant qu'administrateur, le crack ne risque de ne pas fonctionner, nous vous conseillons de rouvrir UnlockSoftwares avec les droits Administrateurs" & vbNewLine & vbNewLine & "Oui = Rouvrir UnlockSoftwares avec les droits administrateurs" & vbNewLine & "Non = Continuer la procédure sans les droits administrateurs.", vbYesNo + vbInformation, "Attention, il vous manque les droits administrateurs continuer ?") = vbYes Then
                ITalk_Button_157_Click(sender, New System.EventArgs())
                Exit Sub
            End If
        End If

        Try
            If ITalk_Label12.Text = "Ouvert avec droit Admin : /!\ NON /!\" Then
                ITalk_Label10.Visible = True
                ITalk_Label10.Text = ITalk_Label10.Text & vbNewLine & "*** Veuillez exécuter cette option avec les droits administrateurs requis ***"
            Else

                ITalk_Label18.Text = My.Computer.Info.OSFullName.ToString & " (" & My.Computer.Info.OSVersion & ")"
                ITalk_Label19.Text = My.Computer.Name.ToString
                ITalk_Label20.Text = Environment.UserName.ToString()
                ITalk_Label21.Text = Registry.LocalMachine.OpenSubKey("HARDWARE\DESCRIPTION\System\BIOS", True).GetValue("SystemManufacturer").ToString()
                ITalk_Label22.Text = Registry.LocalMachine.OpenSubKey("HARDWARE\DESCRIPTION\System\BIOS", True).GetValue("SystemProductName").ToString()
                ITalk_Label16.Text = Registry.LocalMachine.OpenSubKey("HARDWARE\DESCRIPTION\System\BIOS", True).GetValue("SystemSKU").ToString()
                ITalk_Label33.Text = Registry.LocalMachine.OpenSubKey("HARDWARE\DESCRIPTION\System\BIOS", True).GetValue("BIOSVersion").ToString()


                If IsConnectionAvailable() = True Then
                    ITalk_Label17.Text = "Connexion internet marche"
                Else
                    ITalk_Label17.Text = "Pas de connexion internet"
                End If
                llbl_link.Visible = True
            End If

        Catch ex As Exception
            infoerreur(ex, "")
        End Try
    End Sub


#Region "Bouton vers des liens webs"
    Private Sub ITalk_LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles ITalk_LinkLabel4.LinkClicked
        Process.Start("https://www.ccleaner.com/fr-fr/ccleaner/download/professional")
    End Sub

    Private Sub ITalk_LinkLabel5_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles ITalk_LinkLabel5.LinkClicked
        Process.Start("https://singularlabs.com/software/ccenhancer/")
    End Sub

    Private Sub ITalk_LinkLabel7_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles ITalk_LinkLabel7.LinkClicked
        Process.Start("https://www.techsmith.fr/camtasia.html")
    End Sub

    Private Sub ITalk_LinkLabel22_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles ITalk_LinkLabel22.LinkClicked
        Process.Start("https://www.techsmith.com/download-camtasia-win-thankyou.html")
    End Sub

    Private Sub ITalk_LinkLabel8_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles ITalk_LinkLabel8.LinkClicked
        Process.Start("https://www.revouninstaller.com/revo_uninstaller_free_download.html")
    End Sub
    Private Sub ITalk_LinkLabel9_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles ITalk_LinkLabel9.LinkClicked
        Process.Start("https://www.win-rar.com")
    End Sub
    Private Sub ITalk_LinkLabel12_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles ITalk_LinkLabel12.LinkClicked
        Process.Start("https://www.ccleaner.com/recuva/download/standard")
    End Sub
    Private Sub ITalk_LinkLabel11_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles ITalk_LinkLabel11.LinkClicked
        Process.Start("https://www.ccleaner.com/recuva/download/portable/")
    End Sub
    Private Sub ITalk_LinkLabel13_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles ITalk_LinkLabel13.LinkClicked
        Process.Start("https://www.adlice.com/fr/download/roguekiller/#download")
    End Sub
    Private Sub ITalk_LinkLabel15_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles ITalk_LinkLabel15.LinkClicked
        Process.Start("https://www.ccleaner.com/defraggler/download/standard")
    End Sub
    Private Sub ITalk_LinkLabel14_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles ITalk_LinkLabel14.LinkClicked
        Process.Start("https://www.ccleaner.com/defraggler/download/portable")
    End Sub
    Private Sub ITalk_LinkLabel16_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles ITalk_LinkLabel16.LinkClicked
        Process.Start("https://www.reddit.com/r/TronScript/")
    End Sub
    Private Sub ITalk_LinkLabel17_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles ITalk_LinkLabel17.LinkClicked
        Process.Start("https://bmrf.org/repos/tron/")
    End Sub
    Private Sub ITalk_LinkLabel19_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles ITalk_LinkLabel19.LinkClicked
        Process.Start("http://www.ccleaner.com/speccy/download/standard")
    End Sub
    Private Sub ITalk_LinkLabel18_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles ITalk_LinkLabel18.LinkClicked
        Process.Start("https://www.ccleaner.com/speccy/download/portable")
    End Sub
    Private Sub ITalk_LinkLabel23_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles ITalk_LinkLabel23.LinkClicked
        Process.Start("https://www.adlice.com/fr/download/ucheck/")
    End Sub

    Private Sub ITalk_LinkLabel25_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles ITalk_LinkLabel25.LinkClicked
        Process.Start("https://www.techsmith.fr/capture-ecran.html")
    End Sub
    Private Sub ITalk_LinkLabel24_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles ITalk_LinkLabel24.LinkClicked
        Process.Start("https://www.techsmith.fr/telechargement-snagit-win-remerciement.html")
    End Sub
    Private Sub llbl_link_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llbl_link.LinkClicked
        Process.Start("https://www.google.com/search?q=" & ITalk_Label21.Text & " " & ITalk_Label22.Text)
    End Sub

#End Region



#Region "Lancer / Arrêter un logiciel"
    'Lancer/ Arrêter un logiciel

    Private Sub ITalk_Button_137_Click(sender As Object, e As EventArgs) Handles ITalk_Button_137.Click
        'On/Off Speccy 
        Dim p As New Process
        Try
            If UBound(Diagnostics.Process.GetProcessesByName("Speccy64")) < 0 Then
                p.StartInfo.FileName = "C:\Program Files\Speccy\Speccy64.exe"
                p.StartInfo.WindowStyle = ProcessWindowStyle.Normal
                p.Start()
            Else
                KillProcess("Speccy64")
                KillProcess("Speccy32")
            End If
        Catch ex As Exception
            infoerreur(ex, "")
        End Try
    End Sub

    Private Sub ITalk_Button_13_Click(sender As Object, e As EventArgs) Handles ITalk_Button_13.Click
        'On/Off Camtasia 
        Dim p As New Process
        Try
            If UBound(Diagnostics.Process.GetProcessesByName("CamtasiaStudio")) < 0 Then
                If System.IO.File.Exists("C:\Program Files\TechSmith\Camtasia 9\CamtasiaStudio.exe") = True Then
                    p.StartInfo.FileName = "C:\Program Files\TechSmith\Camtasia 9\CamtasiaStudio.exe"
                ElseIf System.IO.File.Exists("C:\Program Files\TechSmith\Camtasia 2018\CamtasiaStudio.exe") = True Then
                    p.StartInfo.FileName = "C:\Program Files\TechSmith\Camtasia 2018\CamtasiaStudio.exe"
                ElseIf System.IO.File.Exists("C:\Program Files\TechSmith\Camtasia 8\CamtasiaStudio.exe") = True Then
                    p.StartInfo.FileName = "C:\Program Files\TechSmith\Camtasia 8\CamtasiaStudio.exe"
                ElseIf System.IO.File.Exists("C:\Program Files\TechSmith\Camtasia 2019\CamtasiaStudio.exe") = True Then
                    p.StartInfo.FileName = "C:\Program Files\TechSmith\Camtasia 2019\CamtasiaStudio.exe"
                ElseIf System.IO.File.Exists("C:\Program Files (x86)\TechSmith\Camtasia 2018\CamtasiaStudio.exe") = True Then
                    p.StartInfo.FileName = "C:\Program Files (x86)\TechSmith\Camtasia 2018\CamtasiaStudio.exe"
                ElseIf System.IO.File.Exists("C:\Program Files (x86)\TechSmith\Camtasia 8\CamtasiaStudio.exe") = True Then
                    p.StartInfo.FileName = "C:\Program Files (x86)\TechSmith\Camtasia 8\CamtasiaStudio.exe"
                ElseIf System.IO.File.Exists("C:\Program Files (x86)\TechSmith\Camtasia 2019\CamtasiaStudio.exe") = True Then
                    p.StartInfo.FileName = "C:\Program Files (x86)\TechSmith\Camtasia 2019\CamtasiaStudio.exe"
                ElseIf System.IO.File.Exists("C:\Program Files (x86)\TechSmith\Camtasia 2020\CamtasiaStudio.exe") = True Then
                    p.StartInfo.FileName = "C:\Program Files (x86)\TechSmith\Camtasia 2020\CamtasiaStudio.exe"
                ElseIf System.IO.File.Exists("C:\Program Files (x86)\TechSmith\Camtasia 2021\CamtasiaStudio.exe") = True Then
                    p.StartInfo.FileName = "C:\Program Files (x86)\TechSmith\Camtasia 2021\CamtasiaStudio.exe"
                Else
                    p.StartInfo.FileName = ""
                End If
                If p.StartInfo.FileName = "" Then
                    MsgBox("Dossier CamtasiaStudio non trouvé", vbInformation + vbOKOnly)
                Else
                    p.StartInfo.WindowStyle = ProcessWindowStyle.Normal
                    p.Start()
                End If
            Else
                KillProcess("CamtasiaStudio")
            End If
        Catch ex As Exception
            infoerreur(ex, "")
        End Try
    End Sub

    Private Sub ITalk_Button_16_Click(sender As Object, e As EventArgs) Handles ITalk_Button_16.Click
        'On/Off CCleaner
        Try
            Dim p As New Process
            If UBound(Diagnostics.Process.GetProcessesByName("CCleaner64")) < 0 Then
                p.StartInfo.FileName = "C:\Program Files\CCleaner\CCleaner64.exe"
                p.StartInfo.WindowStyle = ProcessWindowStyle.Normal
                p.Start()
            Else
                KillProcess("CCleaner64")
                KillProcess("CCleaner32")
            End If
        Catch ex As Exception
            infoerreur(ex, "")
        End Try
    End Sub

    Private Sub ITalk_Button_19_Click(sender As Object, e As EventArgs) Handles ITalk_Button_19.Click
        'On/Off Révo
        Dim p As New Process
        Try
            If UBound(Diagnostics.Process.GetProcessesByName("RevoUninPro")) < 0 Then
                p.StartInfo.FileName = "C:\Program Files\VS Revo Group\Revo Uninstaller Pro\RevoUninPro.exe"
                p.StartInfo.WindowStyle = ProcessWindowStyle.Maximized
                p.Start()
            Else
                KillProcess("RevoUninPro")
                KillProcess("RevoUnin")
            End If
        Catch ex As Exception
            infoerreur(ex, "")
        End Try
    End Sub


    Private Sub ITalk_Button_111_Click(sender As Object, e As EventArgs) Handles ITalk_Button_111.Click
        'On/Off WinRAR
        Dim p As New Process
        Try
            If UBound(Diagnostics.Process.GetProcessesByName("WinRAR")) < 0 Then
                Dim WinRarEXE As String
                If System.IO.File.Exists("C:\Program Files\WinRAR\WinRAR.exe") = True Then
                    WinRarEXE = "C:\Program Files\WinRAR\WinRAR.exe"
                ElseIf System.IO.File.Exists("C:\Program Files (x86)\WinRAR\WinRAR.exe") = True Then
                    WinRarEXE = "C:\Program Files (x86)\WinRAR\WinRAR.exe"
                Else
                    WinRarEXE = ""
                End If

                If WinRarEXE = "" Then
                    MsgBox("Impossible d'ouvrir Winrar, programme non trouvé", vbCritical + vbOKOnly, "Impossible d'ouvrir le logiciel")
                Else
                    p.StartInfo.FileName = WinRarEXE
                    p.StartInfo.WindowStyle = ProcessWindowStyle.Normal
                    p.Start()
                End If
            Else
                KillProcess("WinRAR")
            End If
        Catch ex As Exception
            infoerreur(ex, "")
        End Try
    End Sub

    Private Sub ITalk_Button_126_Click(sender As Object, e As EventArgs) Handles ITalk_Button_126.Click
        'On/Off Recuva
        Dim p As New Process
        Try
            If UBound(Diagnostics.Process.GetProcessesByName("recurva64")) < 0 Then
                p.StartInfo.FileName = "C:\Program Files\Recurva\recurva64.exe"
                p.StartInfo.WindowStyle = ProcessWindowStyle.Normal
                p.Start()
            Else
                KillProcess("recurva64")
                KillProcess("recurva32")
            End If
        Catch ex As Exception
            infoerreur(ex, "")
        End Try
    End Sub

    Private Sub ITalk_Button_133_Click(sender As Object, e As EventArgs) Handles ITalk_Button_133.Click
        'On/Off Defraggler
        Dim p As New Process
        Try
            If UBound(Diagnostics.Process.GetProcessesByName("Defraggler64")) < 0 Then
                p.StartInfo.FileName = "C:\Program Files\Defraggler\Defraggler64.exe"
                p.StartInfo.WindowStyle = ProcessWindowStyle.Normal
                p.Start()
            Else
                KillProcess("Defraggler64")
                KillProcess("Defraggler32")
            End If
        Catch ex As Exception
            infoerreur(ex, "")
        End Try
    End Sub


    Private Sub ITalk_Button_118_Click(sender As Object, e As EventArgs) Handles ITalk_Button_118.Click
        'On/Off Snagit
        Dim p As New Process
        Try
            If UBound(Diagnostics.Process.GetProcessesByName("Snagit32")) < 0 Then
                If System.IO.File.Exists("C:\Program Files\TechSmith\Snagit 9\Snagit32.exe") = True Then
                    p.StartInfo.FileName = "C:\Program Files\TechSmith\Snagit 9\Snagit32.exe"
                ElseIf System.IO.File.Exists("C:\Program Files\TechSmith\Snagit 2018\Snagit32.exe") = True Then
                    p.StartInfo.FileName = "C:\Program Files\TechSmith\Snagit 2018\Snagit32.exe"
                ElseIf System.IO.File.Exists("C:\Program Files\TechSmith\Snagit 8\Snagit32.exe") = True Then
                    p.StartInfo.FileName = "C:\Program Files\TechSmith\Snagit 8\Snagit32.exe"
                ElseIf System.IO.File.Exists("C:\Program Files\TechSmith\Snagit 2019\Snagit32.exe") = True Then
                    p.StartInfo.FileName = "C:\Program Files\TechSmith\Snagit 2019\Snagit32.exe"
                ElseIf System.IO.File.Exists("C:\Program Files (x86)\TechSmith\Snagit 2018\Snagit32.exe") = True Then
                    p.StartInfo.FileName = "C:\Program Files (x86)\TechSmith\Snagit 2018\Snagit32.exe"
                ElseIf System.IO.File.Exists("C:\Program Files (x86)\TechSmith\Snagit 8\Snagit32.exe") = True Then
                    p.StartInfo.FileName = "C:\Program Files (x86)\TechSmith\Snagit 8\Snagit32.exe"
                ElseIf System.IO.File.Exists("C:\Program Files (x86)\TechSmith\Snagit 2019\Snagit32.exe") = True Then
                    p.StartInfo.FileName = "C:\Program Files (x86)\TechSmith\Snagit 2019\Snagit32.exe"
                ElseIf System.IO.File.Exists("C:\Program Files (x86)\TechSmith\Snagit 2020\Snagit32.exe") = True Then
                    p.StartInfo.FileName = "C:\Program Files (x86)\TechSmith\Snagit 2020\Snagit32.exe"
                ElseIf System.IO.File.Exists("C:\Program Files (x86)\TechSmith\Snagit 2021\Snagit32.exe") = True Then
                    p.StartInfo.FileName = "C:\Program Files (x86)\TechSmith\Snagit 2021\Snagit32.exe"
                ElseIf System.IO.File.Exists("C:\Program Files (x86)\TechSmith\Snagit 2022\Snagit32.exe") = True Then
                    p.StartInfo.FileName = "C:\Program Files (x86)\TechSmith\Snagit 2022\Snagit32.exe"
                Else
                    p.StartInfo.FileName = ""
                End If
                If p.StartInfo.FileName = "" Then
                    MsgBox("Dossier Snagit non trouvé", vbInformation + vbOKOnly)
                Else
                    p.StartInfo.WindowStyle = ProcessWindowStyle.Normal
                    p.Start()
                End If
            Else
                KillProcess("Snagit32")
            End If
        Catch ex As Exception
            infoerreur(ex, "")
        End Try
    End Sub

#End Region


#Region "Supprimer fichier langues du logiciel"

    Private Sub ITalk_Button_15_Click(sender As Object, e As EventArgs) Handles ITalk_Button_15.Click
        'Fichier langues CCleaner
        Try
            If System.IO.Directory.Exists("C:\Program Files\CCleaner\Lang") Then
                Dim bytes As Integer = 0
                Dim di As System.IO.DirectoryInfo = New System.IO.DirectoryInfo("C:\Program Files\CCleaner\Lang")
                For Each fi As System.IO.FileInfo In di.GetFiles
                    bytes += fi.Length
                Next
                TextBox3.Text = "" & vbNewLine & "CCleaner possède par défaut 56 fichiers (soit 3.58 MO) langue italien espagnol etc..." & vbNewLine & bytes & " Octets de fichier langue, Liberé : " & 218578 - bytes & " d'octets "
                File.Copy("C:\Program Files\CCleaner\Lang\lang-1036.dll", "C:\ProgramData\ABOAT\UnlockSoftwares\CCleaner\lang-1036.dll")
                For Each files As String In System.IO.Directory.GetFiles("C:\Program Files\CCleaner\Lang")
                    If System.IO.Path.GetFileName(files) = "lang-1036.dll" Then
                    Else
                        System.IO.File.Delete(files)
                    End If
                Next
                TextBox3.Text = TextBox3.Text & vbNewLine & vbNewLine & 218578 - bytes & " Octets nettoyer ! " & vbNewLine & vbNewLine & "Sauvegarde du fichier langue disponible : C:\ProgramData\ABOAT\UnlockSoftwares\"
            Else
                Dim FD As FolderBrowserDialog
                FD = New FolderBrowserDialog
                FD.Description = "Sélectionnez le dossier CCleaner"
                FD.RootFolder = Environment.SpecialFolder.MyComputer
                If FD.ShowDialog() = DialogResult.OK Then
                    Dim path As String = FD.SelectedPath
                    Dim bytes As Integer = 0
                    Dim di As System.IO.DirectoryInfo = New System.IO.DirectoryInfo(path & "\Lang")
                    For Each fi As System.IO.FileInfo In di.GetFiles
                        bytes += fi.Length
                    Next
                    TextBox3.Text = "" & vbNewLine & "Speccy possède par défaut 56 fichiers (soit 3.58 MO) langue italien espagnol etc..." & vbNewLine & bytes & " Octets de fichier langue, Liberé : " & 218578 - bytes & " d'octets "
                    File.Copy(path & "\Lang\lang-1036.dll", "C:\ProgramData\ABOAT\UnlockSoftwares\CCleaner\lang-1036.dll")
                    For Each files As String In System.IO.Directory.GetFiles(path & "\Lang")
                        If System.IO.Path.GetFileName(files) = "lang-1036.dll" Then
                        Else
                            System.IO.File.Delete(files)
                        End If
                    Next
                    TextBox3.Text = TextBox3.Text & vbNewLine & vbNewLine & 218578 - bytes & " Octets nettoyer ! " & vbNewLine & vbNewLine & "Sauvegarde du fichier langue disponible : C:\ProgramData\ABOAT\UnlockSoftwares\"
                End If
            End If
        Catch ex As Exception
            infoerreur(ex, "")
        End Try
    End Sub


    Private Sub ITalk_Button_18_Click(sender As Object, e As EventArgs) Handles ITalk_Button_18.Click
        'Fichier langues Revo
        Try
            If System.IO.Directory.Exists("C:\Program Files\VS Revo Group\Revo Uninstaller Pro\lang") Then
                Dim bytes As Integer = 0
                Dim di As System.IO.DirectoryInfo = New System.IO.DirectoryInfo("C:\Program Files\VS Revo Group\Revo Uninstaller Pro\lang\")
                For Each fi As System.IO.FileInfo In di.GetFiles
                    bytes += fi.Length
                Next
                TextBox4.Text = "" & vbNewLine & "Révo possède par défaut plusieurs fichiers de langues." & vbNewLine & bytes & " Octets de fichiers langues, Libérer : " & 218578 - bytes & " d'octets "
                File.Copy("C:\Program Files\VS Revo Group\Revo Uninstaller Pro\lang\french.ini", "C:\ProgramData\ABOAT\UnlockSoftwares\french.ini")
                File.Copy("C:\Program Files\VS Revo Group\Revo Uninstaller Pro\lang\english.ini", "C:\ProgramData\ABOAT\UnlockSoftwares\english.ini")
                For Each files As String In System.IO.Directory.GetFiles("C:\Program Files\VS Revo Group\Revo Uninstaller Pro\lang")
                    System.IO.File.Delete(files)
                Next
                File.Copy("C:\ProgramData\ABOAT\UnlockSoftwares\english.ini", "C:\Program Files\VS Revo Group\Revo Uninstaller Pro\lang\english.ini")
                File.Copy("C:\ProgramData\ABOAT\UnlockSoftwares\french.ini", "C:\Program Files\VS Revo Group\Revo Uninstaller Pro\lang\french.ini")
                TextBox4.Text = TextBox4.Text & vbNewLine & 218578 - bytes & " Octets nettoyés ! "
            End If
        Catch ex As Exception
            infoerreur(ex, "")
        End Try
    End Sub


    Private Sub ITalk_Button_127_Click(sender As Object, e As EventArgs) Handles ITalk_Button_127.Click
        'Fichier langues Recurva
        Try
            If System.IO.Directory.Exists("C:\Program Files\Recurva\Lang") Then
                Dim bytes As Integer = 0
                Dim di As System.IO.DirectoryInfo = New System.IO.DirectoryInfo("C:\Program Files\Recurva\Lang")
                For Each fi As System.IO.FileInfo In di.GetFiles
                    bytes += fi.Length
                Next
                TextBox6.Text = "" & vbNewLine & "Recurva possède par défaut 56 fichiers (soit 3.58 MO) langue italien espagnol etc..." & vbNewLine & bytes & " Octets de fichier langue, Liberé : " & 218578 - bytes & " d'octets "
                File.Copy("C:\Program Files\Recurva\Lang\lang-1036.dll", "C:\ProgramData\ABOAT\UnlockSoftwares\Recurva\lang-1036.dll")
                For Each files As String In System.IO.Directory.GetFiles("C:\Program Files\CCleaner\Lang")
                    If System.IO.Path.GetFileName(files) = "lang-1036.dll" Then
                    Else
                        System.IO.File.Delete(files)
                    End If
                Next
                TextBox6.Text = TextBox6.Text & vbNewLine & vbNewLine & 218578 - bytes & " Octets nettoyer ! " & vbNewLine & vbNewLine & "Sauvegarde du fichier langue disponible : C:\ProgramData\ABOAT\UnlockSoftwares\"
            Else
                Dim FD As FolderBrowserDialog
                FD = New FolderBrowserDialog
                FD.Description = "Sélectionnez le dossier Recurva"
                FD.RootFolder = Environment.SpecialFolder.MyComputer
                If FD.ShowDialog() = DialogResult.OK Then
                    Dim path As String = FD.SelectedPath
                    Dim bytes As Integer = 0
                    Dim di As System.IO.DirectoryInfo = New System.IO.DirectoryInfo(path & "\Lang")
                    For Each fi As System.IO.FileInfo In di.GetFiles
                        bytes += fi.Length
                    Next
                    TextBox6.Text = "" & vbNewLine & "Speccy possède par défaut 56 fichiers (soit 3.58 MO) langue italien espagnol etc..." & vbNewLine & bytes & " Octets de fichier langue, Liberé : " & 218578 - bytes & " d'octets "
                    File.Copy(path & "\Lang\lang-1036.dll", "C:\ProgramData\ABOAT\UnlockSoftwares\Recurva\lang-1036.dll")
                    For Each files As String In System.IO.Directory.GetFiles(path & "\Lang")
                        If System.IO.Path.GetFileName(files) = "lang-1036.dll" Then
                        Else
                            System.IO.File.Delete(files)
                        End If
                    Next
                    TextBox6.Text = TextBox6.Text & vbNewLine & vbNewLine & 218578 - bytes & " Octets nettoyer ! " & vbNewLine & vbNewLine & "Sauvegarde du fichier langue disponible : C:\ProgramData\ABOAT\UnlockSoftwares\"
                End If
            End If
        Catch ex As Exception
            infoerreur(ex, TextBox6)
        End Try
    End Sub


    Private Sub ITalk_Button_134_Click(sender As Object, e As EventArgs) Handles ITalk_Button_134.Click
        'Fichier langues
        Try
            If System.IO.Directory.Exists("C:\Program Files\Defraggler\Lang") Then
                Dim bytes As Integer = 0
                Dim di As System.IO.DirectoryInfo = New System.IO.DirectoryInfo("C:\Program Files\Defraggler\Lang")
                For Each fi As System.IO.FileInfo In di.GetFiles
                    bytes += fi.Length
                Next
                TextBox8.Text = "" & vbNewLine & "Defraggler possède par défaut 56 fichiers (soit 3.58 MO) langue italien espagnol etc..." & vbNewLine & bytes & " Octets de fichier langue, Liberé : " & 218578 - bytes & " d'octets "
                File.Copy("C:\Program Files\Defraggler\Lang\lang-1036.dll", "C:\ProgramData\ABOAT\UnlockSoftwares\Defraggler\lang-1036.dll")
                For Each files As String In System.IO.Directory.GetFiles("C:\Program Files\Defraggler\Lang")
                    If System.IO.Path.GetFileName(files) = "lang-1036.dll" Then
                    Else
                        System.IO.File.Delete(files)
                    End If
                Next
                TextBox8.Text = TextBox8.Text & vbNewLine & vbNewLine & 218578 - bytes & " Octets nettoyer ! " & vbNewLine & vbNewLine & "Sauvegarde du fichier langue disponible : C:\ProgramData\ABOAT\UnlockSoftwares\"
            Else
                Dim FD As FolderBrowserDialog
                FD = New FolderBrowserDialog
                FD.Description = "Sélectionnez le dossier Defraggler"
                FD.RootFolder = Environment.SpecialFolder.MyComputer
                If FD.ShowDialog() = DialogResult.OK Then
                    Dim path As String = FD.SelectedPath
                    Dim bytes As Integer = 0
                    Dim di As System.IO.DirectoryInfo = New System.IO.DirectoryInfo(path & "\Lang")
                    For Each fi As System.IO.FileInfo In di.GetFiles
                        bytes += fi.Length
                    Next
                    TextBox8.Text = "" & vbNewLine & "Defraggler possède par défaut 56 fichiers (soit 3.58 MO) langue italien espagnol etc..." & vbNewLine & bytes & " Octets de fichier langue, Liberé : " & 218578 - bytes & " d'octets "
                    File.Copy(path & "\Lang\lang-1036.dll", "C:\ProgramData\ABOAT\UnlockSoftwares\Defraggler\lang-1036.dll")
                    For Each files As String In System.IO.Directory.GetFiles(path & "\Lang")
                        If System.IO.Path.GetFileName(files) = "lang-1036.dll" Then
                        Else
                            System.IO.File.Delete(files)
                        End If
                    Next
                    TextBox8.Text = TextBox8.Text & vbNewLine & vbNewLine & 218578 - bytes & " Octets nettoyer ! " & vbNewLine & vbNewLine & "Sauvegarde du fichier langue disponible : C:\ProgramData\ABOAT\UnlockSoftwares\"
                End If
            End If
        Catch ex As Exception
            infoerreur(ex, TextBox8)
        End Try
    End Sub


    Private Sub ITalk_Button_138_Click(sender As Object, e As EventArgs) Handles ITalk_Button_138.Click
        'Fichier langues Speccy
        Try
            If System.IO.Directory.Exists("C:\Program Files\Speccy\Lang") Then
                Dim bytes As Integer = 0
                Dim di As System.IO.DirectoryInfo = New System.IO.DirectoryInfo("C:\Program Files\Speccy\Lang")
                For Each fi As System.IO.FileInfo In di.GetFiles
                    bytes += fi.Length
                Next
                TextBox9.Text = "" & vbNewLine & "Speccy possède par défaut 56 fichiers (soit 3.58 MO) langue italien espagnol etc..." & vbNewLine & bytes & " Octets de fichier langue, Liberé : " & 218578 - bytes & " d'octets "
                File.Copy("C:\Program Files\CCleaner\Lang\lang-1036.dll", "C:\ProgramData\ABOAT\UnlockSoftwares\Speccy\lang-1036.dll")
                For Each files As String In System.IO.Directory.GetFiles("C:\Program Files\Speccy\Lang")
                    If System.IO.Path.GetFileName(files) = "lang-1036.dll" Then
                    Else
                        System.IO.File.Delete(files)
                    End If
                Next
                TextBox9.Text = TextBox9.Text & vbNewLine & vbNewLine & 218578 - bytes & " Octets nettoyer ! " & vbNewLine & vbNewLine & "Sauvegarde du fichier langue disponible : C:\ProgramData\ABOAT\UnlockSoftwares\"
            Else
                Dim FD As FolderBrowserDialog
                FD = New FolderBrowserDialog
                FD.Description = "Sélectionnez le dossier Speccy"
                FD.RootFolder = Environment.SpecialFolder.MyComputer
                If FD.ShowDialog() = DialogResult.OK Then
                    Dim path As String = FD.SelectedPath
                    Dim bytes As Integer = 0
                    Dim di As System.IO.DirectoryInfo = New System.IO.DirectoryInfo(path & "\Lang")
                    For Each fi As System.IO.FileInfo In di.GetFiles
                        bytes += fi.Length
                    Next
                    TextBox9.Text = "" & vbNewLine & "Speccy possède par défaut 56 fichiers (soit 3.58 MO) langue italien espagnol etc..." & vbNewLine & bytes & " Octets de fichier langue, Liberé : " & 218578 - bytes & " d'octets "
                    File.Copy(path & "\Lang\lang-1036.dll", "C:\ProgramData\ABOAT\UnlockSoftwares\Speccy\lang-1036.dll")
                    For Each files As String In System.IO.Directory.GetFiles(path & "\Lang")
                        If System.IO.Path.GetFileName(files) = "lang-1036.dll" Then
                        Else
                            System.IO.File.Delete(files)
                        End If
                    Next
                    TextBox9.Text = TextBox9.Text & vbNewLine & vbNewLine & 218578 - bytes & " Octets nettoyer ! " & vbNewLine & vbNewLine & "Sauvegarde du fichier langue disponible : C:\ProgramData\ABOAT\UnlockSoftwares\"
                End If
            End If
        Catch ex As Exception
            infoerreur(ex, TextBox9)
        End Try
    End Sub

#End Region

    Private Sub ITalk_Button_113_Click(sender As Object, e As EventArgs)
        HighLightThe(sender)
        TextBox10.Text = "*Driver Booster*" & vbNewLine & "Activer la version pro de Driver Booster" & vbNewLine & "Désactiver internet puis valider la clé d'Activation" & vbNewLine & vbNewLine & "Clé:" & vbNewLine & "2C280-9605C-CC26F-25D46" & vbNewLine & vbNewLine & vbNewLine & vbNewLine & "Note perso : Je vous conseille plutôt le logiciel SDI (https://sdi-tool.org/) gratuit, open source & plus performant que Driver Booster"
        ITalk_Button_141.Text = "Activer Driver Booster"
        ITalk_Button_141.Visible = True
    End Sub
    Private Sub ITalk_Button_164_Click(sender As Object, e As EventArgs) Handles ITalk_Button_164.Click
        HighLightThe(sender)
        TextBox10.Text = "*Glary Utilities*" & vbNewLine & "Activer la version pro de Glary Utilities" & vbNewLine & "Clé d'Activation pour Professional Edition : " & vbNewLine & vbNewLine & "Clé:" & vbNewLine & "Licence Name  | Licence Code" & vbNewLine & "SoulCourier.com | 2788-6167-9587-68" & vbNewLine & "YaWego.com | 3788-61679-58234-2362" & vbNewLine & "SoleWe.com | 3788-6167-9582-3423-62" & vbNewLine & "AppNee.com | 1788-6167-9583-4282" & vbNewLine & "SAYS | 2788-61679-58768"
    End Sub
    Private Sub ITalk_LinkLabel10_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles ITalk_LinkLabel10.LinkClicked
        Process.Start("C:\Windows\System32\drivers\etc\")
    End Sub
    Private Sub ITalk_Icon_Tick1_Click(sender As Object, e As EventArgs) Handles ITalk_Icon_Tick1.Click
        On Error Resume Next
        If ITalk_CheckBox1.Checked = True Then
            Dim W As System.IO.StreamWriter
            W = New System.IO.StreamWriter("C:\windows\system32\drivers\etc\hosts", True)
            W.WriteLine(ITalk_TextBox_Small3.Text)
            W.Close()
            ITalk_Label29.Text = "Nouvelle ligne ajouté."
        ElseIf ITalk_CheckBox2.Checked = True Then
            If ComboBox1.SelectedIndex.ToString = 0 Then
            Else
                If ComboBox1.SelectedIndex.ToString = 1 Then
                    Process.Start("https://www.reddit.com/r/Piracy/comments/4kn6rq/comprehensive_guide_to_blocking_ads_on_spotify/")
                    MsgBox("A ajouter dans le fichier host : C:\windows\system32\drivers\etc\hosts")

                ElseIf ComboBox1.SelectedIndex.ToString = 2 Then
                    Dim W As System.IO.StreamWriter
                    W = New System.IO.StreamWriter("C:\windows\system32\drivers\etc\hosts", True)
                    W.WriteLine("0.0.0.0 coin-hive.com" & vbNewLine & "0.0.0.0 jsecoin.com" & vbNewLine & "0.0.0.0 minemytraffic.com" & vbNewLine & "0.0.0.0 minero.pw" & vbNewLine & "0.0.0.0 minecrunch.co" & vbNewLine & "0.0.0.0 crypto-loot.com" & vbNewLine & "0.0.0.0 ppoi.org")
                    W.Close()
                    ITalk_Label29.Text = "5 sites WebMiner bloquer, il est conseiller d'installer l'extension :" & vbNewLine & " uBlock sur votre avigateur pour plus de sécurité."
                    Process.Start("https://github.com/greatis/Anti-WebMiner/blob/master/hosts")
                    MsgBox("A ajouter dans le fichier host : C:\windows\system32\drivers\etc\hosts")
                End If
            End If
        End If
    End Sub

    Private Sub ITalk_Button_112_Click(sender As Object, e As EventArgs) Handles ITalk_Button_112.Click
        HighLightThe(sender)

        TextBox10.Text = "*Avast*" & vbNewLine & vbNewLine & "Voulez-vous activer les produits Avast" & vbNewLine & "Activer les produits Avast ?"
        ITalk_Button_141.Text = "Activer Avast"
        ITalk_Button_141.Visible = True
    End Sub
    Private Sub ITalk_Button_125_Click(sender As Object, e As EventArgs) Handles ITalk_Button_125.Click
        HighLightThe(sender)
        TextBox10.Text = "*Avira*" & vbNewLine & "Voulez-vous activer la licence file d'AVIRA UNIVERSAL LICENCE KEY FILES COLLECTION" & vbNewLine & "Activer la licence file d'AVIRA ?" & vbNewLine & vbNewLine & "Activation uniquement : Avira Antivirus Pro (Avira Antivirus Premium, Avira Antivir Premium)"
        ITalk_Button_141.Text = "Activer Avira"
        ITalk_Button_141.Visible = True
    End Sub
    Private Sub ITalk_Button_119_Click(sender As Object, e As EventArgs) Handles ITalk_Button_119.Click
        'Retrouver tous les mots de passe wifi
        HighLightThe(sender)
        If (File.Exists("C:\ProgramData\ABOAT\UnlockSoftwares\Wifi Passwords Recovery.bat")) Then
            Process.Start("C:\ProgramData\ABOAT\UnlockSoftwares\Wifi Passwords Recovery.bat")
        Else
            My.Computer.FileSystem.WriteAllText("C:\ProgramData\ABOAT\UnlockSoftwares\Wifi Passwords Recovery.bat", My.Resources.Wifi_Passwords_Recovery, True, System.Text.Encoding.Default)
            Process.Start("C:\ProgramData\ABOAT\UnlockSoftwares\Wifi Passwords Recovery.bat")
        End If
    End Sub
    Private Sub ITalk_Button_120_Click(sender As Object, e As EventArgs)
        Process.Start("C:\ProgramData\ABOAT\UnlockSoftwares\Liste lien STREAMING HD.txt")
    End Sub
    Private Sub ITalk_Button_121_Click(sender As Object, e As EventArgs)
        If (File.Exists("C:\ProgramData\ABOAT\UnlockSoftwares\Liste_de_clés_d_activation.txt")) Then
            Process.Start("C:\ProgramData\ABOAT\UnlockSoftwares\Liste_de_clés_d_activation.txt")
        Else
            My.Computer.FileSystem.WriteAllText("C:\ProgramData\ABOAT\UnlockSoftwares\Liste_de_clés_d_activation.txt", My.Resources.Crack_Liste_de_clés_d_activation, True, System.Text.Encoding.Default)
            Process.Start("C:\ProgramData\ABOAT\UnlockSoftwares\Liste_de_clés_d_activation.txt")
        End If
    End Sub

    Private Sub ITalk_Button_123_Click(sender As Object, e As EventArgs)
        On Error Resume Next
        If (File.Exists("C:\ProgramData\ABOAT\UnlockSoftwares\LISTE DE COMMANDES.txt")) Then
            Process.Start("C:\ProgramData\ABOAT\UnlockSoftwares\LISTE DE COMMANDES.txt")
        Else
            My.Computer.FileSystem.WriteAllText("C:\ProgramData\ABOAT\UnlockSoftwares\LISTE DE COMMANDES.txt", My.Resources.LISTE_DE_COMMANDES, True, System.Text.Encoding.Default)
            Process.Start("C:\ProgramData\ABOAT\UnlockSoftwares\LISTE DE COMMANDES.txt")
        End If
    End Sub
    Private Sub ITalk_Button_124_Click(sender As Object, e As EventArgs) Handles ITalk_Button_124.Click
        HighLightThe(sender)
        If System.Environment.Is64BitOperatingSystem = True Then
            Process.Start("Http://www.mediafire.com/?s12bfeob3h6pb") ' 64
        Else
            Process.Start("Http://www.mediafire.com/?vc0j3a99nikqr") '32
        End If
    End Sub
    Private Sub ITalk_CheckBox1_CheckedChanged(sender As Object) Handles ITalk_CheckBox1.CheckedChanged
        If ITalk_CheckBox1.Checked = True Then
            ITalk_CheckBox2.Checked = False
            If ComboBox1.SelectedIndex.ToString > 0 Then
                ComboBox1.SelectedIndex = "0"
            End If
        End If
    End Sub
    Private Sub ITalk_CheckBox2_CheckedChanged(sender As Object) Handles ITalk_CheckBox2.CheckedChanged
        If ITalk_CheckBox2.Checked = True Then
            ITalk_CheckBox1.Checked = False
        End If
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        ITalk_CheckBox1.Checked = False
        ITalk_CheckBox2.Checked = True
        If ComboBox1.SelectedIndex.ToString = 0 Then
            ITalk_CheckBox2.Checked = False
        End If
    End Sub
    Private Sub ITalk_TextBox_Small3_TextChanged(sender As Object, e As EventArgs) Handles ITalk_TextBox_Small3.TextChanged
        ITalk_CheckBox2.Checked = False
        ITalk_CheckBox1.Checked = True
    End Sub
    Private Sub ITalk_Label15_Click(sender As Object, e As EventArgs) Handles ITalk_Label15.Click
        On Error Resume Next
        If MsgBox("Une erreur est survenue : " & vbNewLine & Erreur & vbNewLine & "Pour plus d'information cliquez sur 'Oui' ", 4 + 32 + 0, "Une erreur est survenue") = MsgBoxResult.Yes Then
            Process.Start("C:\ProgramData\ABOAT\UnlockSoftwares\Une erreur Contact-Moi.txt")
        Else
            ITalk_Label15.Visible = False
        End If
    End Sub


    Private Sub ITalk_Button_121_Click_1(sender As Object, e As EventArgs) Handles ITalk_Button_121.Click
        'Raccourcis windows
        On Error Resume Next
        HighLightThe(sender)
        My.Computer.FileSystem.WriteAllBytes("C:\ProgramData\ABOAT\UnlockSoftwares\WindowsRaccourci.rar", My.Resources.WindowsRaccourci, True)
        Process.Start("C:\ProgramData\ABOAT\UnlockSoftwares\WindowsRaccourci.rar")
        MsgBox("Les raccourcis se situe dans" & vbCr & vbCr & "C:\ProgramData\ABOAT\UnlockSoftwares\WindowsRaccourci.rar" & vbCr & vbCr & "Vous devez les extraires pour un bon fonctionnement", MsgBoxStyle.Information, "Raccourcis créés")
    End Sub
    Private Sub ITalk_Button_129_Click(sender As Object, e As EventArgs) Handles ITalk_Button_129.Click
        On Error Resume Next
        HighLightThe(sender)
        My.Computer.FileSystem.WriteAllText("C:\ProgramData\ABOAT\UnlockSoftwares\LISTE_DE_COMMANDES.txt", My.Resources.LISTE_DE_COMMANDES, True)
        Process.Start("C:\ProgramData\ABOAT\UnlockSoftwares\LISTE_DE_COMMANDES.txt")
    End Sub
    Private Sub ITalk_Button_122_Click_1(sender As Object, e As EventArgs) Handles ITalk_Button_122.Click
        On Error Resume Next
        HighLightThe(sender)
        Dim rep As Integer
        rep = MsgBox("Activer/Désactiver la touche Numlock/Ver num au démarrage" & vbCr & vbCr & "Oui = Activer la touche Numlock/Ver num au démarrage (recommander)" & vbCr & vbCr & "Non = Désactivé la touche Numlock/Ver num au démarrage", MsgBoxStyle.Information + vbYesNoCancel, "Désactiver l'écran d'accueil ?")
        If rep = vbYes Then
            My.Computer.FileSystem.WriteAllText("C:\ProgramData\ABOAT\UnlockSoftwares\Windows_10_Active_Numlock_au_démarrage.reg", My.Resources.Windows_10___Active_Numlock_au_démarrage, True, System.Text.Encoding.Default)
            Process.Start("C:\ProgramData\ABOAT\UnlockSoftwares\Windows_10_Active_Numlock_au_démarrage.reg")
        ElseIf rep = vbNo Then
            My.Computer.FileSystem.WriteAllText("C:\ProgramData\ABOAT\UnlockSoftwares\Windows_10_Desactive_Numlock_au_démarrage.reg", My.Resources.Windows_10___Désactive_Numlock_au_démarrage, True, System.Text.Encoding.Default)
            Process.Start("C:\ProgramData\ABOAT\UnlockSoftwares\Windows_10_Desactive_Numlock_au_démarrage.reg")
        End If
    End Sub



    Private Sub ITalk_Button_123_Click_1(sender As Object, e As EventArgs) Handles ITalk_Button_123.Click
        'Information Licence Windows
        On Error Resume Next
        HighLightThe(sender)
        If (File.Exists("C:\ProgramData\ABOAT\UnlockSoftwares\WindowsInfoLicense.vbs")) Then
            Process.Start("C:\ProgramData\ABOAT\UnlockSoftwares\WindowsInfoLicense.vbs")
        Else
            My.Computer.FileSystem.WriteAllText("C:\ProgramData\ABOAT\UnlockSoftwares\WindowsInfoLicense.vbs", My.Resources.WindowsInfoLicense, True, System.Text.Encoding.Default)
            Process.Start("C:\ProgramData\ABOAT\UnlockSoftwares\WindowsInfoLicense.vbs")
        End If
    End Sub
    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click
        MsgBox("Tron est un outil, une sorte de couteau suisse qui rassemble un bon nombre d'outils qui permettent de nettoyer, désinfecter, patcher, optimiser, votre PC sous Windows." & vbNewLine & "Faire une bonne partie de tout ce que vous avez l'habitude de faire sur une machine lente ou infectée. " & vbNewLine & "Concrètement vous allez pouvoir gagner énormément de temps avec cet outil, plutôt que de lancer un à un vos outils habituels, " & vbNewLine & "ici Tron le fait pour vous. Vous lancez Tron." & vbNewLine & "Cet outil est extrêmement puissant. " & vbNewLine & "Une mauvaise utilisation de Tron pourrait altérer le fonctionnement de l'ordinateur sur lequel il est exécuté.", vbInformation, "A propos de Tron :")
        MsgBox("Prep: rkill, ProcessKiller, TDSSKiller, Stinger, registry backup, WMI repair, sysrestore clean, oldest VSS Set purge, create pre-run System Restore point, SMART disk check, NTP time sync" & vbNewLine & "Tempclean: TempFileCleanup, CCLeaner, BleachBit, backup & clear Event logs, Windows Update cache cleanup, Internet Explorer cleanup, USB device cleanup" & vbNewLine & "De-bloat: remove OEM bloatware; customizable list Is in \resources\stage_3_de-bloat\oem\; Metro OEM debloat (Win8/8.1/2012 only)" & vbNewLine & "Disinfect: Kaspersky Virus Removal Tool, Sophos Virus Removal Tool, Malwarebytes Anti-Malware, DISM image check (Win8/2012 only)" & vbNewLine & "Repair: Registry Permissions reset, FileSystem permissions reset, SFC / scannow, chkdsk(If necessary)" & vbNewLine & "Patch  Updates 7 - Zip, Java, And Adobe Flash/Reader And disables nag/update screens (uses some of our PDQ packs); then installs any pending Windows updates" & vbNewLine & "Optimize: page File reset, defrag %SystemDrive% (usually C: \; skipped if system drive Is an SSD)" & vbNewLine & "Wrap-up Send job completion email report (if configured; specify SMTP settings in \resources\stage_7_wrap-up\email_report\SwithMailSettings.xml" & vbNewLine & "Manual stuff: Additional tools that can't currently be automated (ComboFix, AdwCleaner, aswMBR, autoruns, etc.)", vbInformation, "Les Étapes de Tron")
    End Sub



    Private Sub ITalk_Button_139_Click(sender As Object, e As EventArgs) Handles ITalk_Button_139.Click
        On Error Resume Next
        HighLightThe(sender)
        If (File.Exists("C:\ProgramData\ABOAT\UnlockSoftwares\WIN10AntiTelemetry.bat")) Then
            Process.Start("C:\ProgramData\ABOAT\UnlockSoftwares\WIN10AntiTelemetry.bat")
        Else
            My.Computer.FileSystem.WriteAllText("C:\ProgramData\ABOAT\UnlockSoftwares\WIN10AntiTelemetry.bat", My.Resources.WIN10AntiTelemetry, True, System.Text.Encoding.Default)
            Process.Start("C:\ProgramData\ABOAT\UnlockSoftwares\WIN10AntiTelemetry.bat")
        End If
    End Sub
    Private Sub ITalk_Button_140_Click(sender As Object, e As EventArgs) Handles ITalk_Button_140.Click
        On Error Resume Next
        HighLightThe(sender)
        Dim rep As Integer
        rep = MsgBox("Activer ou désactiver l'écran de verrouillage de Windows 10 (visible par la combinaison suivante : {WINDOWS} + {L}" & vbNewLine & vbNewLine & "Oui = Désactivé écran de verrouillage (vous tomberais directement sur les session)" & vbNewLine & "No = Activé écran de verrouillage (par défaut si vous avez rien modifier)", vbInformation + vbYesNoCancel)
        If rep = vbYes Then
            My.Computer.FileSystem.WriteAllText("C:\ProgramData\ABOAT\UnlockSoftwares\Disable_Lock_Screen.reg", My.Resources.Disable_Lock_Screen, True, System.Text.Encoding.Default)
            Process.Start("C:\ProgramData\ABOAT\UnlockSoftwares\Disable_Lock_Screen.reg")
        ElseIf rep = vbNo Then
            My.Computer.FileSystem.WriteAllText("C:\ProgramData\ABOAT\UnlockSoftwares\Enable_Lock_Screen.reg", My.Resources.Enable_Lock_Screen, True, System.Text.Encoding.Default)
            Process.Start("C:\ProgramData\ABOAT\UnlockSoftwares\Enable_Lock_Screen.reg")
        End If
    End Sub
    Private Sub ITalk_Button_141_Click(sender As Object, e As EventArgs) Handles ITalk_Button_141.Click
        Try
            If ITalk_Label12.Text = "Ouvert avec droit Admin : /!\ NON /!\" = True Then
                If MsgBox("UnlockSoftwares n'est pas exécuté en tant qu'administrateur, le crack ne risque de ne pas fonctionner, nous vous conseillons de rouvrir UnlockSoftwares avec les droit Administrateurs" & vbNewLine & vbNewLine & "Oui = Rouvrir UnlockSoftwares avec les droits administrateurs" & vbNewLine & "Non = Continuer la procédure sans les droits administrateurs.", vbYesNo + vbInformation, "Attention, il vous manque les droits administrateurs continuer ?") = vbYes Then
                    ITalk_Button_157_Click(sender, New System.EventArgs())
                    Exit Sub
                End If
            End If

            Dim truc As New Process
            truc.StartInfo.WindowStyle = ProcessWindowStyle.Normal

            If ITalk_Button_141.Text = "Activer Avast" Then
                Dim monFichier As String = "C:\windows\system32\drivers\etc\hosts"
                Dim monEcriture As System.IO.StreamWriter
                monEcriture = New System.IO.StreamWriter(monFichier, True)
                monEcriture.WriteLine("127.0.0.1 75.126.120.203" & vbNewLine & "127.0.0.1 46.4.58.71" & vbNewLine & "127.0.0.1 46.4.62.150" & vbNewLine & "127.0.0.1 46.4.28.80" & vbNewLine & "127.0.0.1 www.avast.com" & vbNewLine & "127.0.0.1 www.ns2.avast.com" & vbNewLine & "127.0.0.1 www.pns.avast.com")
                monEcriture.Close()
                TextBox10.Text = TextBox10.Text & vbNewLine & "Blocage de l'application via le fichier host réussi" & vbNewLine & vbNewLine

                TextBox10.Text = TextBox10.Text & vbNewLine & "Le logiciel Avast va s'ouvrir dans quelque instant." & vbNewLine & "- Dans Abonnement, cliquez sur : insérer le fichier de licence" & vbNewLine & "Copier-coller le chemin ci-dessous pour accéder a la licence générée." & vbNewLine & "Sélectionner un fichier dans le Dossier Avast finisant par .avastlic" & vbNewLine & "Chemin d'accès :C:\ProgramData\ABOAT\UnlockSoftwares\Avast\" & vbNewLine & vbNewLine & vbNewLine & "/!\ Clé d'activation de secours /!\ : NXNW5H-4AKMF2-4EU5F2" & vbNewLine & "55GEZF-SC6HDJ-54473J	(Avast Premier 2020, Avast Cleanup 2022, Avast SecureLine VPN 2021)" & vbNewLine & "UMQQ4R-AU5RQ2-4WC486	(Avast Premier 2020)" & vbNewLine & "NPW579-RD2842-4B44BN	(Avast Premier 2020, Avast Cleanup 2020,Avast Passwords 2020)" & vbNewLine & "S2CYJQ-C6MD82-4ZL4LS	(Avast Premier 2021, Avast Cleanup 2021, Avast SecureLine VPN 2021)" & vbNewLine & "RGXUTX-8DJXCJ-4TL73A	(Avast Premier 2020)" & vbNewLine & "8MBYLZ-BVTLSJ-5NC5RE	(Avast Premier 2022, Avast Cleanup 2020, Avast SecureLine VPN 2021,Avast Passwords 2020)" & vbNewLine & "8MBYLZ-BVTLSJ-5NC5RE	(AVAST CLEANUP 2020)" & vbNewLine & "S2CYJQ-C6MD82-4ZL4LS	(AVAST CLEANUP 2021)" & vbNewLine & "NPW579-RD2842-4B44BN	(AVAST CLEANUP 2020)" & vbNewLine & "55GEZF-SC6HDJ-54473J	(AVAST CLEANUP 2022)"

                If System.IO.Directory.Exists("C:\ProgramData\ABOAT\UnlockSoftwares\Avast") = False Then System.IO.Directory.CreateDirectory("C:\ProgramData\ABOAT\UnlockSoftwares\Avast")
                My.Computer.FileSystem.WriteAllBytes("C:\ProgramData\ABOAT\UnlockSoftwares\Avast\2020_07_28.avastlic", My.Resources._2020_07_28, True)
                My.Computer.FileSystem.WriteAllBytes("C:\ProgramData\ABOAT\UnlockSoftwares\Avast\2023_11_21.avastlic", My.Resources._2023_11_21, True)
                My.Computer.FileSystem.WriteAllBytes("C:\ProgramData\ABOAT\UnlockSoftwares\Avast\2026_07_05.avastlic", My.Resources._2026_07_05, True)
                My.Computer.FileSystem.WriteAllBytes("C:\ProgramData\ABOAT\UnlockSoftwares\Avast\2026_11_05.avastlic", My.Resources._2026_11_05, True)
                My.Computer.FileSystem.WriteAllBytes("C:\ProgramData\ABOAT\UnlockSoftwares\Avast\2027_02_28.avastlic", My.Resources._2027_02_28, True)
                My.Computer.FileSystem.WriteAllBytes("C:\ProgramData\ABOAT\UnlockSoftwares\Avast\2029_04_14.avastlic", My.Resources._2029_04_14, True)
                My.Computer.FileSystem.WriteAllBytes("C:\ProgramData\ABOAT\UnlockSoftwares\Avast\2038_01_10.avastlic", My.Resources._2038_01_10, True)
                truc.StartInfo.Arguments = (Chr(34) & "C:\ProgramData\ABOAT\UnlockSoftwares\Avast\" & Chr(34))
                truc.StartInfo.FileName = ("explorer.exe")
                truc.Start()
                Process.Start("C:\ProgramData\ABOAT\UnlockSoftwares\Avast\2038_01_10.avastlic")
                MsgBox("Le logiciel Avast va s'ouvrir dans quelque instant." & vbNewLine & "- Dans Abonnement, cliquez sur : insérer le fichier de licence" & vbNewLine & "Copier-coller le chemin ci-dessous pour accéder a la licence générée." & vbNewLine & "Sélectionner un fichier dans le Dossier Avast finisant par .avastlic" & vbNewLine & "Chemin d'accès :C:\ProgramData\ABOAT\UnlockSoftwares\Avast")

            ElseIf ITalk_Button_141.Text = "Activer Folder Lock" Then
                TextBox10.Text = TextBox10.Text & vbNewLine & vbNewLine & "Serial Number F7-20150610-3-155923" & vbNewLine & "Registration Key 40F41E1C2C8EF2ACF426B00AE6469A6290E2965E" & vbNewLine & vbNewLine & "Serial Number F7-20150610-0-257532" & vbNewLine & "Registration Key BE6266145A06B8C28EBC9A78000AA4EE4E82C820" & vbNewLine & vbNewLine & "Serial Number F7-20150610-2-231462" & vbNewLine & "Registration Key 1886BE148E4E460080AA043A34800EDAF2703CB4" & vbNewLine & vbNewLine & vbNewLine & "Désactivé votre connexion et bloquer les mise a jours du logiciel"

            ElseIf ITalk_Button_141.Text = "Activer 7 Data Recovery" Then
                TextBox10.Text = TextBox10.Text & vbNewLine & vbNewLine & "Name:       LatestUploads.NET [Do Not Change the Name]" & vbNewLine & vbNewLine & "Key: 9AO5ZRkjjlRuvyD4-90909100" & vbNewLine & vbNewLine & "Key:        CKYsdduttvnvplD4-98919988" & vbNewLine & vbNewLine & "Key:        YPexXoQW0gwIj9D4-19819011" & vbNewLine & vbNewLine & "Key:        IQ2EjlGFoHCm6yD4-18090010"

            ElseIf ITalk_Button_141.Text = "Activer Autres clés d'activation" Then
                If File.Exists("C:\ProgramData\ABOAT\UnlockSoftwares\Crack_Liste_de_clés_d_activation.txt") = True Then System.IO.File.Delete("C:\ProgramData\ABOAT\UnlockSoftwares\Crack_Liste_de_clés_d_activation.txt")
                My.Computer.FileSystem.WriteAllText("C:\ProgramData\ABOAT\UnlockSoftwares\Crack_Liste_de_clés_d_activation.txt", My.Resources.Crack_Liste_de_clés_d_activation, True)
                TextBox10.Text = IO.File.ReadAllText("C:\ProgramData\ABOAT\UnlockSoftwares\Crack_Liste_de_clés_d_activation.txt")
            ElseIf ITalk_Button_141.Text = "Activer Office 2016" Then
                If (File.Exists("C:\ProgramData\ABOAT\UnlockSoftwares\activate-office-2016.bat")) Then
                    Process.Start("C:\ProgramData\ABOAT\UnlockSoftwares\activate-office-2016.bat")
                Else
                    My.Computer.FileSystem.WriteAllText("C:\ProgramData\ABOAT\UnlockSoftwares\activate-office-2016.bat", My.Resources.activate_office_2016, True, System.Text.Encoding.Default)
                    Process.Start("C:\ProgramData\ABOAT\UnlockSoftwares\activate-office-2016.bat")
                End If


            ElseIf ITalk_Button_141.Text = "Activer Office 2019" Then
                If (File.Exists("C:\ProgramData\ABOAT\UnlockSoftwares\activate-office-2019.bat")) Then
                    Process.Start("C:\ProgramData\ABOAT\UnlockSoftwares\activate-office-2019.bat")
                Else
                    My.Computer.FileSystem.WriteAllText("C:\ProgramData\ABOAT\UnlockSoftwares\activate-office-2019.bat", My.Resources.activate_office_2019, True, System.Text.Encoding.Default)
                    Process.Start("C:\ProgramData\ABOAT\UnlockSoftwares\activate-office-2019.bat")
                End If


            ElseIf ITalk_Button_141.Text = "Activer Windows 8" Then
                If (File.Exists("C:\ProgramData\ABOAT\UnlockSoftwares\activate-windows-8-8-1.bat")) Then
                    Process.Start("C:\ProgramData\ABOAT\UnlockSoftwares\activate-windows-8-8-1.bat")
                Else
                    My.Computer.FileSystem.WriteAllText("C:\ProgramData\ABOAT\UnlockSoftwares\activate-windows-8-8-1.bat", My.Resources.activate_windows_8_8_1, True, System.Text.Encoding.Default)
                    Process.Start("C:\ProgramData\ABOAT\UnlockSoftwares\activate-windows-8-8-1.bat")
                End If
            ElseIf ITalk_Button_141.Text = "Activer Windows 10" Then
                If (File.Exists("C:\ProgramData\ABOAT\UnlockSoftwares\activate-windows-10.bat")) Then
                    Process.Start("C:\ProgramData\ABOAT\UnlockSoftwares\activate-windows-10.bat")
                Else
                    My.Computer.FileSystem.WriteAllText("C:\ProgramData\ABOAT\UnlockSoftwares\activate-windows-10.bat", My.Resources.activate_windows_10, True, System.Text.Encoding.Default)
                    Process.Start("C:\ProgramData\ABOAT\UnlockSoftwares\activate-windows-10.bat")
                End If

            ElseIf ITalk_Button_141.Text = "Activer Windows 7" Then
                Process.Start("https://msguides.com/microsoft-software-products/3-methods-get-free-windows-7-license.html")
                Process.Start("https://msguides.com/microsoft-software-products/3-methods-get-free-windows-7-license.html" & vbNewLine & "Le lien des clés : https://get.msguides.com/fw.html?aHR0cHM6Ly9hbm9ueW16LmdpdGh1Yi5pbz9odHRwOi8vZ2V0Lm1zZ3VpZGVzLmNvbS93aW5kb3dzN19saWNlbnNla2V5cy50eHQ=")
                TextBox10.Text = TextBox10.Text & vbNewLine & vbNewLine & "Activation : " & vbNewLine & "Le lien : https://msguides.com/microsoft-software-products/3-methods-get-free-windows-7-license.html" & vbNewLine & "Le lien des clés : https://get.msguides.com/fw.html?aHR0cHM6Ly9hbm9ueW16LmdpdGh1Yi5pbz9odHRwOi8vZ2V0Lm1zZ3VpZGVzLmNvbS93aW5kb3dzN19saWNlbnNla2V5cy50eHQ="

            ElseIf ITalk_Button_141.Text = "Activer Visio 2016" Then
                If (File.Exists("C:\ProgramData\ABOAT\UnlockSoftwares\activate-visio2016.bat")) Then
                    Process.Start("C:\ProgramData\ABOAT\UnlockSoftwares\activate-visio2016.bat")
                Else
                    My.Computer.FileSystem.WriteAllText("C:\ProgramData\ABOAT\UnlockSoftwares\activate-visio2016.bat", My.Resources.activate_visio2016, True, System.Text.Encoding.Default)
                    Process.Start("C:\ProgramData\ABOAT\UnlockSoftwares\activate-visio2016.bat")
                End If

            ElseIf ITalk_Button_141.Text = "Activer Kaspersky" Then
                TextBox10.Text = TextBox10.Text & vbNewLine & vbNewLine & "Étape manuelle (a vous de faire) :  " & vbNewLine & vbNewLine & "Désactiver le Self-Defense [setting > Additional > Self-Defence - Unchecked]" & vbNewLine & "Après avoir Désactiver le Self-Defense fermer Kaspersky et cliquer sur le bouton 'Suivant'"
                ITalk_Button_141.Text = "Suivant"
            ElseIf ITalk_Button_141.Text = "Suivant" Then
                If ITalk_Label13.Text = "Architecture : 64" Then
                    If (File.Exists("C:\ProgramData\ABOAT\UnlockSoftwares\KasperskyX64.bat")) Then
                        Process.Start("C:\ProgramData\ABOAT\UnlockSoftwares\KasperskyX64.bat")
                    Else
                        My.Computer.FileSystem.WriteAllText("C:\ProgramData\ABOAT\UnlockSoftwares\KasperskyX64.bat", My.Resources.KasperskyX64, True, System.Text.Encoding.Default)
                        Process.Start("C:\ProgramData\ABOAT\UnlockSoftwares\KasperskyX64.bat")
                    End If
                ElseIf ITalk_Label13.Text = "Architecture : 32" Then
                    If (File.Exists("C:\ProgramData\ABOAT\UnlockSoftwares\KasperskyX32.bat")) Then
                        Process.Start("C:\ProgramData\ABOAT\UnlockSoftwares\KasperskyX32.bat")
                    Else
                        My.Computer.FileSystem.WriteAllText("C:\ProgramData\ABOAT\UnlockSoftwares\KasperskyX32.bat", My.Resources.KasperskyX32, True, System.Text.Encoding.Default)
                        Process.Start("C:\ProgramData\ABOAT\UnlockSoftwares\KasperskyX32.bat")
                    End If
                End If
            End If


        Catch ex As Exception
            infoerreur(ex, "")
        End Try
    End Sub
    Private Sub ITalk_Button_142_Click(sender As Object, e As EventArgs) Handles ITalk_Button_142.Click
        On Error Resume Next
        HighLightThe(sender)
        TextBox10.Text = "*Folder Lock*" & vbNewLine & "Permet de sécuriser, crypter ou cacher un nombre illimité de fichiers, documents, répertoires ou disques."
        ITalk_Button_141.Text = "Activer Folder Lock"

        ITalk_Button_141.Visible = True
    End Sub

    Private Sub ITalk_Button_143_Click(sender As Object, e As EventArgs) Handles ITalk_Button_143.Click
        Try
            HighLightThe(sender)
            If IsConnectionAvailable() = True Then
                Dim AV As New WebClient
                Dim TestAV As String = AV.DownloadString("https://pastebin.com/raw/LYXiuaAK")
                Dim sw As New StreamWriter("C:\ProgramData\ABOAT\UnlockSoftwares\TestAV.txt")
                sw.WriteLine(TestAV)
                sw.Close()
                Process.Start("C:\ProgramData\ABOAT\UnlockSoftwares\TestAV.txt")
            Else
                MsgBox("Activé votre connexion internet pour pouvoir testé cette option, merci.")
            End If
        Catch ex As Exception
            infoerreur(ex, "")
        End Try
    End Sub

    Public Function IsConnectionAvailable() As Boolean
        Dim objUrl As New System.Uri("http://www.google.fr")
        Dim objWebReq As System.Net.WebRequest
        objWebReq = System.Net.WebRequest.Create(objUrl)
        Dim objresp As System.Net.WebResponse

        Try
            objresp = objWebReq.GetResponse
            objresp.Close()
            objresp = Nothing
            Return True

        Catch ex As Exception
            objresp = Nothing
            Return False
        End Try
    End Function


    Private Sub ITalk_Button_145_Click(sender As Object, e As EventArgs) Handles ITalk_Button_145.Click
        HighLightThe(sender)
        If (File.Exists("C:\ProgramData\ABOAT\UnlockSoftwares\Process Manager Checker.bat")) Then
            Process.Start("C:\ProgramData\ABOAT\UnlockSoftwares\Process Manager Checker.bat")
        Else
            My.Computer.FileSystem.WriteAllText("C:\ProgramData\ABOAT\UnlockSoftwares\Process Manager Checker.bat", My.Resources.Process_Manager_Checker, True, System.Text.Encoding.Default)
            Process.Start("C:\ProgramData\ABOAT\UnlockSoftwares\Process Manager Checker.bat")
        End If
    End Sub
    Private Sub ITalk_Button_146_Click(sender As Object, e As EventArgs) Handles ITalk_Button_146.Click
        HighLightThe(sender)
        If (File.Exists("C:\ProgramData\ABOAT\UnlockSoftwares\SVCHOST_CHECKER.bat")) Then
            Process.Start("C:\ProgramData\ABOAT\UnlockSoftwares\SVCHOST_CHECKER.bat")
        Else
            My.Computer.FileSystem.WriteAllText("C:\ProgramData\ABOAT\UnlockSoftwares\SVCHOST_CHECKER.bat", My.Resources.SVCHOST_CHECKER, True, System.Text.Encoding.Default)
            Process.Start("C:\ProgramData\ABOAT\UnlockSoftwares\SVCHOST_CHECKER.bat")
        End If
    End Sub
    Private Sub ITalk_Button_147_Click(sender As Object, e As EventArgs) Handles ITalk_Button_147.Click
        HighLightThe(sender)
        Try
            If MsgBox("Voulez vous avoir des informations sur la batterie de votre PC Portable (fonctionne uniquement sur le ordinateur portable)", vbInformation + vbYesNoCancel) = vbYes Then
                If (File.Exists("C:\ProgramData\ABOAT\UnlockSoftwares\InfoBattery.bat")) Then
                    Process.Start("C:\ProgramData\ABOAT\UnlockSoftwares\InfoBattery.bat")
                Else
                    My.Computer.FileSystem.WriteAllText("C:\ProgramData\ABOAT\UnlockSoftwares\InfoBattery.bat", My.Resources.InfoBattery, True, System.Text.Encoding.Default)
                    Process.Start("C:\ProgramData\ABOAT\UnlockSoftwares\InfoBattery.bat")
                End If
            End If
        Catch ex As Exception
            infoerreur(ex, "")
        End Try
    End Sub
    Private Sub ITalk_Button_148_Click(sender As Object, e As EventArgs) Handles ITalk_Button_148.Click
        HighLightThe(sender)
        Dim rep As Integer
        rep = MsgBox("Le démarrage rapide est activé par défaut sous Windows et est un paramètre qui aide votre PC à démarrer plus rapidement après l'arrêt. Encore plus rapide que l'hibernation. Windows fait ceci en enregistrant une image du noyau Windows et les pilotes chargés dans le fichier hiber lors de l'arrêt, de sorte que lorsque vous redémarrez votre PC, Windows charge simplement le fichier hiber dans la mémoire pour reprendre votre PC au lieu de le redémarrer" & vbNewLine & vbNewLine & "Activer ou désactiver le démarrage rapide ?" & vbNewLine & vbNewLine & "Oui = Activé (recommandé) " & vbNewLine & "No = Désactivé ", vbInformation + vbYesNoCancel)
        If rep = vbYes Then
            My.Computer.FileSystem.WriteAllText("C:\ProgramData\ABOAT\UnlockSoftwares\Turn_On_Fast_Startup.bat", My.Resources.Turn_On_Fast_Startup, True, System.Text.Encoding.Default)
            Process.Start("C:\ProgramData\ABOAT\UnlockSoftwares\Turn_On_Fast_Startup.bat")
        ElseIf rep = vbNo Then
            My.Computer.FileSystem.WriteAllText("C:\ProgramData\ABOAT\UnlockSoftwares\Turn_Off_Fast_Startup.bat", My.Resources.Turn_Off_Fast_Startup, True, System.Text.Encoding.Default)
            Process.Start("C:\ProgramData\ABOAT\UnlockSoftwares\Turn_Off_Fast_Startup.bat")
        End If
    End Sub
    Private Sub ITalk_Button_150_Click(sender As Object, e As EventArgs) Handles ITalk_Button_150.Click
        HighLightThe(sender)
        My.Computer.FileSystem.WriteAllText("C:\ProgramData\ABOAT\UnlockSoftwares\Remove_Share_with_from_context_menu.reg", My.Resources.Remove_Share_with_from_context_menu, True, System.Text.Encoding.Default)
        Process.Start("C:\ProgramData\ABOAT\UnlockSoftwares\Remove_Share_with_from_context_menu.reg")
    End Sub
    Private Sub ITalk_Button_151_Click(sender As Object, e As EventArgs) Handles ITalk_Button_151.Click
        HighLightThe(sender)
        'https://www.tenforums.com/tutorials/83163-remove-add-windows-media-player-list-context-menu-windows-10-a.html
        My.Computer.FileSystem.WriteAllText("C:\ProgramData\ABOAT\UnlockSoftwares\Remove_Add_to_Windows_Media_Player_list_context_menu.reg", My.Resources.Remove_Add_to_Windows_Media_Player_list_context_menu, True, System.Text.Encoding.Default)
        Process.Start("C:\ProgramData\ABOAT\UnlockSoftwares\Remove_Add_to_Windows_Media_Player_list_context_menu.reg")
    End Sub
    Private Sub ITalk_Button_152_Click(sender As Object, e As EventArgs) Handles ITalk_Button_152.Click
        HighLightThe(sender)
        'https://www.tenforums.com/tutorials/29141-add-copy-folder-move-folder-context-menu-windows-10-a.html
        My.Computer.FileSystem.WriteAllText("C:\ProgramData\ABOAT\UnlockSoftwares\Add_Copy_Move_To_Folder_to_context_menu.reg", My.Resources.Add_Copy_Move_To_Folder_to_context_menu, True, System.Text.Encoding.Default)
        Process.Start("C:\ProgramData\ABOAT\UnlockSoftwares\Add_Copy_Move_To_Folder_to_context_menu.reg")
    End Sub
    Private Sub ITalk_Button_153_Click(sender As Object, e As EventArgs) Handles ITalk_Button_153.Click
        HighLightThe(sender)
        'https://www.tenforums.com/tutorials/4844-remove-quick-access-navigation-pane-windows-10-a.html
        My.Computer.FileSystem.WriteAllText("C:\ProgramData\ABOAT\UnlockSoftwares\Remove_Quick_access_from_navigation_pane.reg", My.Resources.Remove_Quick_access_from_navigation_pane, True, System.Text.Encoding.Default)
        Process.Start("C:\ProgramData\ABOAT\UnlockSoftwares\Remove_Quick_access_from_navigation_pane.reg")
    End Sub
    Private Sub ITalk_Button_154_Click(sender As Object, e As EventArgs) Handles ITalk_Button_154.Click
        HighLightThe(sender)
        ITalk_Button_141.Text = "Activer 7 Data Recovery"
        ITalk_Button_141.Visible = True
        TextBox10.Text = "*Activer 7 Data Recovery*"
    End Sub
    Private Sub ITalk_Button_155_Click(sender As Object, e As EventArgs)
        HighLightThe(sender)
        ITalk_Button_141.Text = "Activer TECHSMITH SNAGIT"
        ITalk_Button_141.Visible = True
        TextBox10.Text = "*Activer TECHSMITH SNAGIT*"
    End Sub
    Private Sub ITalk_Button_156_Click(sender As Object, e As EventArgs) Handles ITalk_Button_156.Click
        HighLightThe(sender)
        ITalk_Button_141.Text = "Activer Autres clés d'activation"
        ITalk_Button_141.Visible = True
        TextBox10.Text = "Clés : " & vbNewLine & " Tout Windows ; Office ; Visual Studio ; MALWAREBYTES ; Avast ; Deep Freeze "
    End Sub
    Private Sub ITalk_Button_157_Click(sender As Object, e As EventArgs) Handles ITalk_Button_157.Click
        Dim sw As New StreamWriter("C:\ProgramData\ABOAT\UnlockSoftwares\CheminComplet.txt")
        sw.WriteLine(Environment.GetCommandLineArgs()(0))
        sw.Close()
        If (File.Exists("C:\ProgramData\ABOAT\UnlockSoftwares\RestartEnAdmin.bat")) Then
            Shell("C:\ProgramData\ABOAT\UnlockSoftwares\RestartEnAdmin.bat", AppWinStyle.Hide, True)
            Me.Close()
        Else
            My.Computer.FileSystem.WriteAllText("C:\ProgramData\ABOAT\UnlockSoftwares\RestartEnAdmin.bat", My.Resources.RestartEnAdmin, True, System.Text.Encoding.Default)
            Shell("C:\ProgramData\ABOAT\UnlockSoftwares\RestartEnAdmin.bat", AppWinStyle.Hide, True)
            Me.Close()
        End If
    End Sub
    Private Sub ITalk_LinkLabel21_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles ITalk_LinkLabel21.LinkClicked
        Process.Start("https://www.tech2tech.fr/tronscript-le-script-ultime-pour-desinfecter-un-pc-sous-windows/")
    End Sub
    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        MsgBox("Tester votre antivirus, en utilisant le fichier test eicar, vous pourrez enfin tester votre antivirus et contrôler son efficacité", vbInformation + vbOKOnly, "Faux positif créé par les antivirus")
    End Sub
    Private Sub ITalk_Button_158_Click(sender As Object, e As EventArgs) Handles ITalk_Button_158.Click
        HighLightThe(sender)
        Dim nomFic As String
        Dim cheminFic As String
        With OpenFileDialog1
            .FileName = ""
            .Multiselect = False
            .Title = "Sélectionner le fichier a lancer au démarrage de Windows"
            .Filter = "Tout type de fichier (*.*) |*.*"
            .ShowHelp = False
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                nomFic = System.IO.Path.GetFileNameWithoutExtension(.SafeFileName)
                cheminFic = .FileName
            Else
                Exit Sub
            End If
        End With
        Dim clefExiste As Boolean = False
        Dim teste As Microsoft.Win32.RegistryKey
        teste = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Run", True)
        Dim lit As String = CType(teste.GetValue(nomFic), String)
        If lit <> "" Then
            clefExiste = True
            MsgBox("La clef existe déjà")
        End If
        If clefExiste = True Then Exit Sub
        Dim ecrit As Microsoft.Win32.RegistryKey
        ecrit = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Run", True)
        ecrit.SetValue(nomFic, cheminFic)
        MsgBox("Le fichier : " & vbNewLine & nomFic & " (" & cheminFic & ")" & vbNewLine & "A bien étais rajouté a la liste des programmes qui se lance au démarrage !", vbInformation + vbOKOnly)
        ecrit.Close()
    End Sub
    Private Sub ITalk_Button_159_Click(sender As Object, e As EventArgs) Handles ITalk_Button_159.Click
        HighLightThe(sender)
        TextBox10.Text = "*Office2016*" & vbNewLine & vbNewLine & "Les produits supporté : " & vbNewLine & "– Microsoft Office Standard 2016" & vbNewLine & "– Microsoft Office Professional Plus 2016" & vbNewLine & "Voulez vous activer Office 2016 ?" & vbNewLine & "Activation via un fichier batch qui va tester plusieur clé stocké sur un serveur jusqu'à ce qu'une clé fonctionne"
        ITalk_Button_141.Text = "Activer Office 2016"
        ITalk_Button_141.Visible = True
    End Sub

    Private Sub ITalk_Button_117_Click(sender As Object, e As EventArgs) Handles ITalk_Button_117.Click
        HighLightThe(sender)
        TextBox10.Text = "*Office2019*" & vbNewLine & vbNewLine & "Les produits supporté : " & vbNewLine & "– Microsoft Office Standard 2019" & vbNewLine & "– Microsoft Office Professional Plus 2019" & vbNewLine & "Voulez vous activer Office 2019 ?" & vbNewLine & "Activation via un fichier batch qui va tester plusieur clé stocké sur un serveur jusqu'à ce qu'une clé fonctionne" & vbNewLine & "Vous pouvez vérifier le code ici : https://msguides.com/microsoft-software-products/office-2019.html" & vbNewLine & vbNewLine & "Pour télécharger Microsoft Office Professionnel Plus 2019 : " & vbNewLine & "https://officecdn.microsoft.com/pr/492350f6-3a01-4f97-b9c0-c7c6ddf67d60/media/fr-fr/ProPlus2019Retail.img"
        ITalk_Button_141.Text = "Activer Office 2019"
        ITalk_Button_141.Visible = True
    End Sub


    Private Sub ITalk_Button_160_Click(sender As Object, e As EventArgs) Handles ITalk_Button_160.Click
        HighLightThe(sender)
        TextBox10.Text = "*Windows8*" & vbNewLine & vbNewLine & "Les produits supporté : " & vbNewLine & "– Windows 8" & vbNewLine & "– Windows 8.1" & vbNewLine & "Toute versions" & vbNewLine & "Activation via un fichier batch qui va tester plusieur clé stocké sur un serveur jusqu'a qu'une clé fonctionne" & vbNewLine & "Vous pouvez vérifier le code ici : https://msguides.com/microsoft-software-products/newest-methods-activate-windows-8-8-1-free-without-software.html"
        ITalk_Button_141.Text = "Activer Windows 8"
        ITalk_Button_141.Visible = True
    End Sub
    Private Sub ITalk_Button_161_Click(sender As Object, e As EventArgs) Handles ITalk_Button_161.Click
        HighLightThe(sender)
        TextBox10.Text = "*Windows10*" & vbNewLine & vbNewLine & "Les produits supporté : " & vbNewLine & "– Windows 10 Toute version" & vbNewLine & "Activation via un fichier batch qui va tester plusieur clé stocké sur un serveur jusqu'a qu'une clé fonctionne" & vbNewLine & "Vous pouvez vérifier le code ici : https://msguides.com/microsoft-software-products/2-ways-activate-windows-10-free-without-software.html"
        ITalk_Button_141.Text = "Activer Windows 10"
        ITalk_Button_141.Visible = True
    End Sub
    Private Sub ITalk_Button_162_Click(sender As Object, e As EventArgs) Handles ITalk_Button_162.Click
        HighLightThe(sender)
        TextBox10.Text = "*Windows7*" & vbNewLine & vbNewLine & "Les produits supporté : " & vbNewLine & "– Windows 7 Toute version" & vbNewLine & "Activation via un lien qui va vous donner les dernière clé windows 7 qui marche"
        ITalk_Button_141.Text = "Activer Windows 7"
        ITalk_Button_141.Visible = True
    End Sub
    Private Sub ITalk_Button_163_Click(sender As Object, e As EventArgs) Handles ITalk_Button_163.Click
        HighLightThe(sender)
        TextBox10.Text = "*Visio2016*" & vbNewLine & vbNewLine & "Les produits supporté : " & vbNewLine & "– Visio 2016 Toute version" & vbNewLine & "Activation via un fichier batch qui va tester plusieur clé stocké sur un serveur jusqu'a qu'une clé fonctionne" & vbNewLine & "Vous pouvez vérifier le code ici : https://get.msguides.com/visio2016.txt"
        ITalk_Button_141.Text = "Activer Visio 2016"
        ITalk_Button_141.Visible = True
    End Sub

    Private Sub ITalk_Label9_Click(sender As Object, e As EventArgs) Handles ITalk_Label9.Click
        Process.Start("C:\ProgramData\ABOAT\UnlockSoftwares\")
    End Sub
    Private Sub HighLightThe(b As Object)
        Static lastControl As Control                        'hold the last button clicked

        If lastControl IsNot Nothing Then                    'If we've clicked before
            lastControl.BackColor = Control.DefaultBackColor   '  reset it to the default                         
        End If

        lastControl = DirectCast(b, Control)                 'Save the current button clicked
        lastControl.BackColor = Color.Blue                   'and set its backcolor to blue
    End Sub

    Private Sub ITalk_Button_144_Click(sender As Object, e As EventArgs) Handles ITalk_Button_144.Click

        Dim p As New Process
        p.StartInfo.CreateNoWindow = False
        p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
        p.StartInfo.Arguments = ("/C date " & DateTimePicker1.Value.Date()) '" & PING localhost -n " & ITalk_TextBox_Small5.Text & " & date " & ValueurDaete)
        p.StartInfo.Verb = "runas"
        p.StartInfo.FileName = ("CMD.exe")
        p.Start()
    End Sub


    Private Sub ITalk_Button_113_Click_1(sender As Object, e As EventArgs) Handles ITalk_Button_113.Click
        Dim p As New Process
        p.StartInfo.CreateNoWindow = False
        p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
        p.StartInfo.Arguments = ("/C date " & ValueurDaete)
        p.StartInfo.Verb = "runas"
        p.StartInfo.FileName = ("CMD.exe")
        p.Start()
    End Sub


#Region "Contenu copié"

    Private Sub ITalk_Label18_Click(sender As Object, e As EventArgs) Handles ITalk_Label18.Click
        Clipboard.SetDataObject(ITalk_Label18.Text)
        ITalk_Label10.Text = "Contenu copié"
    End Sub

    Private Sub ITalk_Label19_Click(sender As Object, e As EventArgs) Handles ITalk_Label19.Click
        Clipboard.SetDataObject(ITalk_Label19.Text)
        ITalk_Label10.Text = "Contenu copié"
    End Sub

    Private Sub ITalk_Label20_Click(sender As Object, e As EventArgs) Handles ITalk_Label20.Click
        Clipboard.SetDataObject(ITalk_Label20.Text)
        ITalk_Label10.Text = "Contenu copié"
    End Sub

    Private Sub ITalk_Label21_Click(sender As Object, e As EventArgs) Handles ITalk_Label21.Click
        Clipboard.SetDataObject(ITalk_Label21.Text)
        ITalk_Label10.Text = "Contenu copié"
    End Sub

    Private Sub ITalk_Label22_Click(sender As Object, e As EventArgs) Handles ITalk_Label22.Click
        Clipboard.SetDataObject(ITalk_Label22.Text)
        ITalk_Label10.Text = "Contenu copié"
    End Sub

    Private Sub ITalk_Label16_Click(sender As Object, e As EventArgs) Handles ITalk_Label16.Click
        Clipboard.SetDataObject(ITalk_Label16.Text)
        ITalk_Label10.Text = "Contenu copié"
    End Sub

    Private Sub ITalk_Label33_Click(sender As Object, e As EventArgs) Handles ITalk_Label33.Click
        Clipboard.SetDataObject(ITalk_Label33.Text)
        ITalk_Label10.Text = "Contenu copié"
    End Sub
#End Region


    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        MsgBox("Le rôle du fichier host est d'associer des noms d'hôtes à des adresses IP." & vbNewLine & " Il permet entre autres de bloquer divers sites Web lorsque vous surfez sur Internet.", vbInformation + vbOKOnly, "Info fichier Host")

    End Sub



    Private Sub ITalk_TabControl2_Selecting(sender As Object, e As TabControlCancelEventArgs) Handles ITalk_TabControl2.Selecting
        'Licence gratuite du jour
        If ITalk_TabControl2.SelectedIndex = 10 Then
            ITalk_TabControl2.SelectedIndex = 0
            CreateObject("Wscript.shell").Popup("Chargement ....", 2, "Chargement GiveAwayOfTheDay", vbOKOnly + vbInformation)
            If (File.Exists("C:\ProgramData\ABOAT\UnlockSoftwares\GiveAwayOfTheDay.vbs")) Then
                Process.Start("C:\ProgramData\ABOAT\UnlockSoftwares\GiveAwayOfTheDay.vbs")
            Else
                My.Computer.FileSystem.WriteAllText("C:\ProgramData\ABOAT\UnlockSoftwares\GiveAwayOfTheDay.vbs", My.Resources.GiveAwayOfTheDay, True, System.Text.Encoding.Default)
                Process.Start("C:\ProgramData\ABOAT\UnlockSoftwares\GiveAwayOfTheDay.vbs")
            End If
        End If
    End Sub

    Private Sub ITalk_Button_131_Click(sender As Object, e As EventArgs) Handles ITalk_Button_131.Click
        HighLightThe(sender)

        TextBox10.Text = "*ESET*" &
                 vbNewLine & "Licence Eset NOD32 Security / Antivirus" & vbNewLine & vbNewLine & "A5GR-XP3E-TFWE-UM3A-5A8V" & vbNewLine & "License validity:05/20/2022" &
                 vbNewLine &
                 vbNewLine & "BMJB-X3PD-G7VF-MTP4-58V3" &
                 vbNewLine & "License validity:03/22/2022" &
                 vbNewLine &
                 vbNewLine & "ACHM-XCTV-P4G3-RKSW-S2A3" &
                 vbNewLine & "License validity:03/21/2022" &
                 vbNewLine &
                 vbNewLine & "USAX-W33S-3JCR-R4DT-496V" &
                 vbNewLine & "License validity:07/13/2021" &
                 vbNewLine &
                 vbNewLine & "AA3G-XA2H-7DPP-AJ3W-294A" &
                 vbNewLine & "License validity:03/17/2021" &
                 vbNewLine &
                 vbNewLine & "B9XA-X8CD-A2KV-3VFX-HUF5" &
                 vbNewLine & "License validity:03/02/2021" &
                 vbNewLine &
                 vbNewLine & "VND8-W33A-9XDM-MAPJ-WPN9" &
                 vbNewLine & "License validity:01/17/2021" &
                 vbNewLine &
                 vbNewLine & "VND8-W33A-9T2E-ESPP-VBNP" &
                 vbNewLine & "License validity:01/16/2021" &
                 vbNewLine &
                 vbNewLine & "VND8-W33A-9G9H-H6DE-27K3" &
                 vbNewLine & "VND8-W33A-9W3C-CUHN-3MD3" &
                 vbNewLine & "License validity:01/15/2021" &
                 vbNewLine &
                 vbNewLine & "VND8-W33A-98HB-BJEW-5JW4" &
                 vbNewLine & "License validity:01/14/2021" &
                 vbNewLine &
                 vbNewLine & "VND8-W33A-7S8V-VFTW-N2P8" &
                 vbNewLine & "License validity:12/21/2020" &
                 vbNewLine &
                 vbNewLine & "VND8-W33A-77G6-6TSV-NFGW" &
                 vbNewLine & "License validity:12/13/2020" &
                 vbNewLine &
                 vbNewLine & "FRAJ-WRB5-PR96-6KAT-4UA5" &
                 vbNewLine & "License validity:06/12/2020" &
                 vbNewLine &
                 vbNewLine & "VND8-W335-VRT8-8MGD-2UT3" &
                 vbNewLine & "License validity:07/17/2020" &
                 vbNewLine &
                 vbNewLine & "VND8-W335-VAAX-XBGE-FEN6" &
                 vbNewLine & "VND8-W335-VABS-SCKW-8DV6" &
                 vbNewLine & "VND8-W335-VHTK-K2V6-3GCG" &
                 vbNewLine & "License validity:07/14/2020" &
                 vbNewLine &
                 vbNewLine & "VND8-W335-VF68-8WVC-2B2J" &
                 vbNewLine & "License validity:07/09/2020" &
                 vbNewLine &
                 vbNewLine & "VND8-W335-V9R3-3H83-KX49" &
                 vbNewLine & "License validity:06/25/2020" &
                 vbNewLine &
                 vbNewLine & "VND8-W335-V5KU-UDBK-TU5K" &
                 vbNewLine & "License validity:06/15/2020 " &
                 vbNewLine &
                 vbNewLine & "VND8-W333-7TUM-MM6C-2GWM" &
                 vbNewLine & "License validity:06/13/2020" &
                 vbNewLine &
                 vbNewLine & "VND8-W333-794S-SNCR-M3AD" &
                 vbNewLine & "License validity:04/10/2020" &
                 vbNewLine &
                 vbNewLine & "DWEA-W33N-AMEB-BB8E-FWAV" &
                 vbNewLine & "License validity:09/21/2021." &
                 vbNewLine &
                 vbNewLine & "NAEF-XHNR-NKSU-ABP8-BAVT" &
                 vbNewLine & "License validity:08/31/2021." &
                 vbNewLine &
                 vbNewLine & "USA3-2UUF-29E8-HDE6-F39T" &
                 vbNewLine & "License validity:02/12/2021." &
                 vbNewLine &
                 vbNewLine & "VND8-W33A-7XG9-9RCU-HAER" &
                 vbNewLine & "License validity:11/21/2020." &
                 vbNewLine &
                 vbNewLine & "CNDU-W33J-9MK7-77VH-6UH2" &
                 vbNewLine & "License validity:08/13/2020." &
                 vbNewLine &
                 vbNewLine & "U82P-XP8R-JVRW-CR8W-JDNA" &
                 vbNewLine & "License validity:06/15/2020." &
                 vbNewLine &
                 vbNewLine & "RUAW-W33M-JGNS-SCVA-9ES7" &
                 vbNewLine & "License validity:06/10/2020." &
                 vbNewLine &
                 vbNewLine & "B83W-XKE9-2PSU-54NV-AUPT" &
                 vbNewLine & "License validity:05/28/2020" &
                 vbNewLine &
                 vbNewLine & "UEXD-XXSK-9334-3V5K-AAAB" &
                 vbNewLine & " License validity:03/22/2020." &
                 vbNewLine &
                 vbNewLine & "BRC8-W33X-PGTH-H552-5RH2" &
                 vbNewLine & "License validity:03/12/2020." &
                 vbNewLine &
                 vbNewLine & "DEAS-W33H-C6NE-EX5N-HMNE" &
                 vbNewLine & "B6C2-XT4E-X9D3-A4P3-VSPA " &
                 vbNewLine & "License validity:02/27/2020" &
                 vbNewLine &
                 vbNewLine & "CAP9-XJHV-KRES-36BB-EPD7 " &
                 vbNewLine & "License validity:1/1/2020" &
                 vbNewLine &
                 vbNewLine & "DEAS-W338-K9WA-AUHU-EWDB" &
                 vbNewLine & "License validity:03/01/2020."
        ITalk_Button_141.Text = "Activer ESET"
        ITalk_Button_141.Visible = True
    End Sub

    Private Sub ITalk_TabControl1_Enter(sender As Object, e As EventArgs) Handles ITalk_TabControl1.Enter
        ITalk_Label1.Text = ValueurDaete
    End Sub



#Region "Button activation logiciel "

    Private Sub btn_active_defraggler_Click(sender As Object, e As EventArgs) Handles btn_active_defraggler.Click
        'Activer Defraggler 
        If ITalk_Label12.Text = "Ouvert avec droit Admin : /!\ NON /!\" = True Then
            If MsgBox("UnlockSoftwares n'est pas exécuté en tant qu'administrateur, le crack ne risque de ne pas fonctionner, nous vous conseillons de rouvrir UnlockSoftwares avec les droits Administrateurs" & vbNewLine & vbNewLine & "Oui = Rouvrir UnlockSoftwares avec les droits administrateurs" & vbNewLine & "Non = Continuer la procédure sans les droits administrateurs.", vbYesNo + vbInformation, "Attention, il vous manque les droits administrateurs continuer ?") = vbYes Then
                ITalk_Button_157_Click(sender, New System.EventArgs())
                Exit Sub
            End If
        End If

        Try
            KillProcess("Defraggler64")
            KillProcess("Defraggler32")
            TextBox8.Text = "Fermeture de Defraggler"
            TextBox8.Text = TextBox8.Text & vbNewLine & "Demande de blocage réseau pour l'application via le fichier host"
            Dim monFichier As String = "C:\windows\system32\drivers\etc\hosts"
            Dim monEcriture As System.IO.StreamWriter
            monEcriture = New System.IO.StreamWriter(monFichier, True)
            monEcriture.WriteLine("127.0.0.1   license.piriform.com")
            monEcriture.Close()
            TextBox8.Text = TextBox8.Text & vbNewLine & "blocage de l'application via le fichier host réussi"
            TextBox8.Text = TextBox8.Text & vbNewLine & "Defraggler -> Aide -> A propos : Mettre à jour vers la version Pro :"
            TextBox8.Text = TextBox8.Text & vbNewLine & "Ajouter la clé : " & vbNewLine & "Clé : " & vbNewLine & vbNewLine & "DGN2-UAQN-ADNZ-QEIQ-8VFF" & vbNewLine & "DGN2-HVJZ-XCHC-BZH2-AVFF" & vbNewLine & vbNewLine & "Utilisateur : " & vbNewLine & Environment.UserName.ToString()
        Catch ex As Exception
            infoerreur(ex, "")
        End Try
    End Sub


    Private Sub btn_active_camtasia_Click(sender As Object, e As EventArgs) Handles btn_active_camtasia.Click
        'Activer CamtasiaStudio
        If ITalk_Label12.Text = "Ouvert avec droit Admin : /!\ NON /!\" = True Then
            If MsgBox("UnlockSoftwares n'est pas exécuté en tant qu'administrateur, le crack ne risque de ne pas fonctionner, nous vous conseillons de rouvrir UnlockSoftwares avec les droits Administrateurs" & vbNewLine & vbNewLine & "Oui = Rouvrir UnlockSoftwares avec les droits administrateurs" & vbNewLine & "Non = Continuer la procédure sans les droits administrateurs.", vbYesNo + vbInformation, "Attention, il vous manque les droits administrateurs continuer ?") = vbYes Then
                ITalk_Button_157_Click(sender, New System.EventArgs())
                Exit Sub
            End If
        End If
        Try
            KillProcess("CamtasiaStudio")
            TextBox2.Text = "Fermeture de Camtasia Studio effectué !"
            Dim CamtasiaStudioChemin As String
            Dim ProgrammChemin As String = Environment.GetEnvironmentVariable("ProgramW6432") & "\"
            Dim Programm86Chemin As String = Environment.GetEnvironmentVariable("PROGRAMFILES(X86)") & "\"
            If System.IO.File.Exists(ProgrammChemin & "TechSmith\Camtasia 18\CamtasiaStudio.exe") = True Then
                CamtasiaStudioChemin = ProgrammChemin & "TechSmith\Camtasia 18"
            ElseIf System.IO.File.Exists(Programm86Chemin & "TechSmith\Camtasia 18\CamtasiaStudio.exe") = True Then
                CamtasiaStudioChemin = "C:\Program Files (x86)\TechSmith\Camtasia 18"
            ElseIf System.IO.File.Exists(ProgrammChemin & "TechSmith\Camtasia 2018\CamtasiaStudio.exe") = True Then
                CamtasiaStudioChemin = ProgrammChemin & "TechSmith\Camtasia 2018"
            ElseIf System.IO.File.Exists(Programm86Chemin & "TechSmith\Camtasia 2018\CamtasiaStudio.exe") = True Then
                CamtasiaStudioChemin = Programm86Chemin & "TechSmith\Camtasia 2018"
            ElseIf System.IO.File.Exists(ProgrammChemin & "TechSmith\Camtasia 2019\CamtasiaStudio.exe") = True Then
                CamtasiaStudioChemin = ProgrammChemin & "TechSmith\Camtasia 2019"
            ElseIf System.IO.File.Exists(Programm86Chemin & "TechSmith\Camtasia 2019\CamtasiaStudio.exe") = True Then
                CamtasiaStudioChemin = Programm86Chemin & "TechSmith\Camtasia 2019"
            ElseIf System.IO.File.Exists(ProgrammChemin & "TechSmith\Camtasia 2020\CamtasiaStudio.exe") = True Then
                CamtasiaStudioChemin = ProgrammChemin & "TechSmith\Camtasia 2020"
            ElseIf System.IO.File.Exists(Programm86Chemin & "TechSmith\Camtasia 2020\CamtasiaStudio.exe") = True Then
                CamtasiaStudioChemin = Programm86Chemin & "TechSmith\Camtasia 2020"
            ElseIf System.IO.File.Exists(Programm86Chemin & "TechSmith\Camtasia 2021\CamtasiaStudio.exe") = True Then
                CamtasiaStudioChemin = Programm86Chemin & "TechSmith\Camtasia 2021"
            ElseIf System.IO.File.Exists(Programm86Chemin & "TechSmith\Camtasia 2022\CamtasiaStudio.exe") = True Then
                CamtasiaStudioChemin = Programm86Chemin & "TechSmith\Camtasia 2022"
            Else
                Dim FolderBrowserDialog1 As FolderBrowserDialog = New FolderBrowserDialog
                FolderBrowserDialog1.Description = "Veuillez sélectionner le dossier où vous avez installé Camtasia Studio"
                FolderBrowserDialog1.SelectedPath = "C:\"
                FolderBrowserDialog1.ShowNewFolderButton = False
                If FolderBrowserDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    CamtasiaStudioChemin = FolderBrowserDialog1.SelectedPath
                Else
                    MsgBox("Aucun dossier n'a été sélectionné", MsgBoxStyle.Exclamation, "Aucun dossier sélectionné")
                    Exit Try
                    End
                End If
            End If
            TextBox2.Text = TextBox2.Text & vbNewLine & "Récupération du chemin d'installation de Camtasia Studio par défaut : " & CamtasiaStudioChemin
            Dim FileProperties As FileVersionInfo = FileVersionInfo.GetVersionInfo(Path.GetFullPath(CamtasiaStudioChemin & "\CamtasiaStudio.exe"))
            TextBox2.Text = TextBox2.Text & vbNewLine & "Version de CamtasiaStudio : " & FileProperties.FileVersion & vbNewLine & "Crack réalisé version 19.0.3"
            TextBox2.Text = TextBox2.Text & vbNewLine & "Demande de blocage réseau pour l'application via le fichier host"
            Dim write As System.IO.StreamWriter
            write = New System.IO.StreamWriter("C:\windows\system32\drivers\etc\hosts", True)
            write.WriteLine("127.0.0.1     techsmith.com" & vbNewLine & "127.0.0.1    activation.cloud.techsmith.com" & vbNewLine & "127.0.0.1	 activation.cloud.techsmith.com" & vbNewLine & "127.0.0.1	 updater.techsmith.com" & vbNewLine & "127.0.0.1	 camtasiatudi.techsmith.com" & vbNewLine & "127.0.0.1	 tsccloud.cloudapp.net" & vbNewLine & "127.0.0.1	 assets.cloud.techsmith.com" & vbNewLine & "127.0.0.1	 oscount.techsmith.com")
            write.Close()
            TextBox2.Text = TextBox2.Text & vbNewLine & "blocage de l'application via le fichier host réussi"
            Dim p As New Process
            p.StartInfo.CreateNoWindow = True
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden

            Dim CamtasiaStudioProgramData As String
            If System.IO.Directory.Exists(PROGRAMDATAChemin & "TechSmith\Camtasia Studio 8") = True Then
                CamtasiaStudioProgramData = PROGRAMDATAChemin & "TechSmith\Camtasia Studio 8"
            ElseIf System.IO.Directory.Exists(PROGRAMDATAChemin & "TechSmith\Camtasia Studio 9") = True Then
                CamtasiaStudioProgramData = PROGRAMDATAChemin & "TechSmith\Camtasia Studio 9"
            ElseIf System.IO.Directory.Exists(PROGRAMDATAChemin & "TechSmith\Camtasia Studio 18") = True Then
                CamtasiaStudioProgramData = PROGRAMDATAChemin & "TechSmith\Camtasia Studio 18"
            ElseIf System.IO.Directory.Exists(PROGRAMDATAChemin & "TechSmith\Camtasia Studio 19") = True Then
                CamtasiaStudioProgramData = PROGRAMDATAChemin & "TechSmith\Camtasia Studio 19"
            ElseIf System.IO.Directory.Exists(PROGRAMDATAChemin & "TechSmith\Camtasia Studio 20") = True Then
                CamtasiaStudioProgramData = PROGRAMDATAChemin & "TechSmith\Camtasia Studio 20"
            ElseIf System.IO.Directory.Exists(PROGRAMDATAChemin & "TechSmith\Camtasia Studio 21") = True Then
                CamtasiaStudioProgramData = PROGRAMDATAChemin & "TechSmith\Camtasia Studio 21"
            ElseIf System.IO.Directory.Exists(PROGRAMDATAChemin & "TechSmith\Camtasia Studio 22") = True Then
                CamtasiaStudioProgramData = PROGRAMDATAChemin & "TechSmith\Camtasia Studio 22"
            Else
                MsgBox("Vous devez ouvrir Camtasia Studio après l'installation au moins une fois puis relancer l'activation", vbInformation + vbOKOnly, "Vous devez lancer Camtasia Studio une fois")
                Exit Sub
            End If

            TextBox2.Text = TextBox2.Text & vbNewLine & "Demande d'accès au droit du fichier licence"
            p.StartInfo.Arguments = ("/C takeown /f " & Chr(34) & CamtasiaStudioProgramData & "\RegInfo.ini" & Chr(34) & " & icacls " & Chr(34) & CamtasiaStudioProgramData & "\RegInfo.ini" & Chr(34) & " /grant:r Administrateurs:(OI)(CI)F & Attrib -r -a -s -h " & Chr(34) & CamtasiaStudioProgramData & "\RegInfo.ini" & Chr(34))
            p.StartInfo.FileName = ("CMD.exe")
            p.Start()
            System.Threading.Thread.Sleep(2000)
            TextBox2.Text = TextBox2.Text & vbNewLine & "Droit d'accès au fichier validé"
            System.Threading.Thread.Sleep(2000)
            If System.IO.File.Exists(PROGRAMDATAChemin & "ABOAT\UnlockSoftwares\RegInfoOriginale.ini") = False Then
                If System.IO.File.Exists(CamtasiaStudioProgramData & "\RegInfo.ini") = True Then
                    File.Copy(CamtasiaStudioProgramData & "\RegInfo.ini", PROGRAMDATAChemin & "ABOAT\UnlockSoftwares\RegInfoOriginale.ini")
                    TextBox2.Text = TextBox2.Text & vbNewLine & "Sauvegarde du fichier original effectué = C:\ProgramData\ABOAT\UnlockSoftwares\RegInfoOriginale.ini"
                Else
                    TextBox2.Text = TextBox2.Text & vbNewLine & "Erreur pour la Sauvegarde du fichier original  !"
                End If

            Else
                If System.IO.File.Exists(CamtasiaStudioProgramData & "\RegInfo.ini") = True Then
                    File.Delete(PROGRAMDATAChemin & "ABOAT\UnlockSoftwares\RegInfoOriginale.ini")
                    File.Copy(CamtasiaStudioProgramData & "\RegInfo.ini", PROGRAMDATAChemin & "ABOAT\UnlockSoftwares\RegInfoOriginale.ini")
                    TextBox2.Text = TextBox2.Text & vbNewLine & "Sauvegarde du fichier original effectué = C:\ProgramData\ABOAT\UnlockSoftwares\RegInfoOriginale.ini"
                Else
                    TextBox2.Text = TextBox2.Text & vbNewLine & "Erreur pour la Sauvegarde du fichier original  !"
                End If


            End If
            System.Threading.Thread.Sleep(2000)
            If System.IO.File.Exists(CamtasiaStudioProgramData & "\RegInfo.ini") = True Then
                File.Delete(CamtasiaStudioProgramData & "\RegInfo.ini")
                TextBox2.Text = TextBox2.Text & vbNewLine & "Fichier Original RegInfo.ini supprimé"
            End If

            If System.IO.File.Exists(PROGRAMDATAChemin & "ABOAT\UnlockSoftwares\RegInfo.txt") = True Then File.Delete(PROGRAMDATAChemin & "ABOAT\UnlockSoftwares\RegInfo.txt")

            TextBox2.Text = TextBox2.Text & vbNewLine & "Création du fichier activation Camtasia Studio en cours ..."
            Dim sw As New StreamWriter(PROGRAMDATAChemin & "ABOAT\UnlockSoftwares\RegInfo.txt")
            sw.WriteLine("[RegistrationInfo]" & vbNewLine & "ValidationData3=1" & vbNewLine & "RegistrationKey=AAM4U4U5CMBN54MCUWFAZ5779" & vbNewLine & "RegisteredTo=" & ITalk_TextBox_Small1.Text & vbNewLine & "ValidationData1=" & vbNewLine & "ValidationData2=1")
            sw.Close()
            System.Threading.Thread.Sleep(200)
            File.Move(PROGRAMDATAChemin & "ABOAT\UnlockSoftwares\RegInfo.txt", CamtasiaStudioProgramData & "\RegInfo.ini")
            System.Threading.Thread.Sleep(200)

            If System.IO.File.Exists(CamtasiaStudioProgramData & "\RegInfo.ini") = False Then
                TextBox2.Text = TextBox2.Text & vbNewLine & "Erreur le fichier n'a pu être créé dans : " & CamtasiaStudioProgramData
            Else
                TextBox2.Text = TextBox2.Text & vbNewLine & "Fichier licence créé avec succès"
                If System.IO.File.Exists(CamtasiaStudioProgramData & "\RegInfo.ini") = True Then File.SetAttributes(CamtasiaStudioProgramData & "\RegInfo.ini", FileAttributes.ReadOnly)
                TextBox2.Text = TextBox2.Text & vbNewLine & vbNewLine & "Activation FINI !"
            End If


        Catch ex As Exception
            infoerreur(ex, TextBox2)
        End Try
    End Sub

    Private Sub btn_active_ccleaner_Click(sender As Object, e As EventArgs) Handles btn_active_ccleaner.Click
        'Activer CCleaner
        If ITalk_Label12.Text = "Ouvert avec droit Admin : /!\ NON /!\" = True Then
            If MsgBox("UnlockSoftwares n'est pas exécuté en tant qu'administrateur, le crack ne risque de ne pas fonctionner, nous vous conseillons de rouvrir UnlockSoftwares avec les droits Administrateurs" & vbNewLine & vbNewLine & "Oui = Rouvrir UnlockSoftwares avec les droits administrateurs" & vbNewLine & "Non = Continuer la procédure sans les droits administrateurs.", vbYesNo + vbInformation, "Attention, il vous manque les droits administrateurs continuer ?") = vbYes Then
                ITalk_Button_157_Click(sender, New System.EventArgs())
                Exit Sub
            End If
        End If

        Try
            KillProcess("CCleaner64")
            KillProcess("CCleaner32")
            TextBox3.Text = "Fermeture de CCleaner effectué !"
            TextBox3.Text = TextBox3.Text & vbNewLine & "Demande de blocage réseau pour l'application via le fichier host"
            Dim monFichier As String = "C:\windows\system32\drivers\etc\hosts"
            Dim monEcriture As System.IO.StreamWriter
            monEcriture = New System.IO.StreamWriter(monFichier, True)
            monEcriture.WriteLine("127.0.0.1   license.piriform.com")
            monEcriture.Close()
            TextBox3.Text = TextBox3.Text & vbNewLine & "blocage de l'application via le fichier host réussi"
            TextBox3.Text = TextBox3.Text & vbNewLine & "CCleaner -> Option -> A propos : Passer a la version Pro :"
            TextBox3.Text = TextBox3.Text & vbNewLine & "Ajouter la clé : " & vbNewLine & "Clé : " & vbNewLine & " C2YW-2BAM-ADC2-89RV-YZPC" & vbNewLine & "Utilisateur : " & vbNewLine & Environment.UserName.ToString()
        Catch ex As Exception
            infoerreur(ex, TextBox3)
        End Try
    End Sub

    Private Sub btn_active_recuva_Click(sender As Object, e As EventArgs) Handles btn_active_recuva.Click
        'Activer Recuva
        If ITalk_Label12.Text = "Ouvert avec droit Admin : /!\ NON /!\" = True Then
            If MsgBox("UnlockSoftwares n'est pas exécuté en tant qu'administrateur, le crack ne risque de ne pas fonctionner, nous vous conseillons de rouvrir UnlockSoftwares avec les droits Administrateurs" & vbNewLine & vbNewLine & "Oui = Rouvrir UnlockSoftwares avec les droits administrateurs" & vbNewLine & "Non = Continuer la procédure sans les droits administrateurs.", vbYesNo + vbInformation, "Attention, il vous manque les droits administrateurs continuer ?") = vbYes Then
                ITalk_Button_157_Click(sender, New System.EventArgs())
                Exit Sub
            End If
        End If


        Try
            KillProcess("Recuva64")
            KillProcess("Recuva32")
            TextBox6.Text = "Fermeture de Recuva effectué !"
            TextBox6.Text = TextBox6.Text & vbNewLine & "Demande de blocage réseau pour l'application via le fichier host"
            Dim monFichier As String = "C:\windows\system32\drivers\etc\hosts"
            Dim monEcriture As System.IO.StreamWriter
            monEcriture = New System.IO.StreamWriter(monFichier, True)
            monEcriture.WriteLine("127.0.0.1   license.piriform.com")
            monEcriture.Close()
            TextBox6.Text = TextBox6.Text & vbNewLine & "blocage de l'application via le fichier host réussi"
            TextBox6.Text = TextBox6.Text & vbNewLine & "Recuva -> Option -> A propos : Passer a la version Pro :"
            TextBox6.Text = TextBox6.Text & vbNewLine & "Ajouter la clé : " & vbNewLine & "Clé : " & vbNewLine & " RK98-Q4JY-BS5M-9KKH-A44C" & vbNewLine & "Utilisateur : " & vbNewLine & Environment.UserName.ToString()
        Catch ex As Exception
            infoerreur(ex, TextBox6)
        End Try
    End Sub

    Private Sub btn_active_adlice_Click(sender As Object, e As EventArgs) Handles btn_active_adlice.Click
        'Activer suite adlice : UCheck, RogueKiller, Diag
        If ITalk_Label12.Text = "Ouvert avec droit Admin : /!\ NON /!\" = True Then
            If MsgBox("UnlockSoftwares n'est pas exécuté en tant qu'administrateur, le crack ne risque de ne pas fonctionner, nous vous conseillons de rouvrir UnlockSoftwares avec les droits Administrateurs" & vbNewLine & vbNewLine & "Oui = Rouvrir UnlockSoftwares avec les droits administrateurs" & vbNewLine & "Non = Continuer la procédure sans les droits administrateurs.", vbYesNo + vbInformation, "Attention, il vous manque les droits administrateurs continuer ?") = vbYes Then
                ITalk_Button_157_Click(sender, New System.EventArgs())
                Exit Sub
            End If
        End If


        Try
            TextBox7.Text = "Arrêt des processus UCheck, RogueKiller, Diag : En cours ..." & vbNewLine & "Veuillez patienter quelques minutes"
            KillProcess("RogueKiller_portable64")
            KillProcess("RogueKiller_portable32")
            KillProcess("RogueKiller32")
            KillProcess("RogueKiller64")
            KillProcess("UCheck_portable64")
            KillProcess("UCheck_portable32")
            KillProcess("UCheck64")
            KillProcess("UCheck32")
            KillProcess("UCheck_portable64")
            KillProcess("UCheck_portable32")
            KillProcess("UCheck64")
            KillProcess("UCheck32")
            KillProcess("Diag_portable64")
            KillProcess("Diag_portable32")
            KillProcess("Diag64")
            KillProcess("Diag32")
            TextBox7.Text = "Arrêt de processus UCheck, RogueKiller, Diag : Effectué "

            'RogueKiller
            If System.IO.Directory.Exists(PROGRAMDATAChemin & "RogueKiller") Then 'RogueKiller
                My.Computer.FileSystem.DeleteDirectory(PROGRAMDATAChemin & "RogueKiller\", FileIO.DeleteDirectoryOption.DeleteAllContents)
                If System.IO.Directory.Exists(PROGRAMDATAChemin & "RogueKiller") = True Then
                    TextBox7.Text = TextBox7.Text & vbNewLine & "Un problème est  survenue lors de la suppression du Dossier RogueKiller"
                Else
                    TextBox7.Text = TextBox7.Text & vbNewLine & "Réinitialisation de la licence démonstration RogueKiller réussi !" & vbNewLine & "Ouvrez RogueKiller ,puis 'Activer' et 'Activer l'essais' en bas a droite"
                End If
            Else
                TextBox7.Text = TextBox7.Text & "Dossier RogueKiller introuvable, veuillez lancer le logiciel au moins une fois."
            End If


            If System.IO.Directory.Exists(PROGRAMDATAChemin & "ADiag") Then 'Diag
                My.Computer.FileSystem.DeleteDirectory(PROGRAMDATAChemin & "ADiag\", FileIO.DeleteDirectoryOption.DeleteAllContents)
                If System.IO.Directory.Exists(PROGRAMDATAChemin & "ADiag") = True Then
                    TextBox7.Text = TextBox7.Text & vbNewLine & "Un problème est survenue lors de la suppression du Dossier Diag"
                Else
                    TextBox7.Text = TextBox7.Text & vbNewLine & "Réinitialisation de la licence démonstration Diag réussi !" & vbNewLine & "Ouvrez Diag ,puis 'Activer' et 'Activer l'essaie' en bas a droite"
                End If
            Else
                TextBox7.Text = TextBox7.Text & vbNewLine & "Dossier Diag introuvable, veuillez lancer le logiciel au moins une fois."
            End If


            If System.IO.Directory.Exists(PROGRAMDATAChemin & "UCheck") Then 'Ucheck
                My.Computer.FileSystem.DeleteDirectory(PROGRAMDATAChemin & "UCheck\", FileIO.DeleteDirectoryOption.DeleteAllContents)
                If System.IO.Directory.Exists(PROGRAMDATAChemin & "UCheck") = True Then
                    TextBox7.Text = TextBox7.Text & vbNewLine & "Un problème est survenue lors de la suppression du Dossier UCheck"
                Else
                    TextBox7.Text = TextBox7.Text & vbNewLine & "Réinitialisation de la licence démonstration UCheck réussi !" & vbNewLine & "Ouvrez UCheck ,puis 'Activer' et 'Activer l’essaie' en bas a droite"
                End If
            Else
                TextBox7.Text = TextBox7.Text & vbNewLine & "Dossier UCheck introuvable, veuillez lancer le logiciel au moins une fois."
            End If

        Catch ex As Exception
            infoerreur(ex, TextBox7)
        End Try
    End Sub

    Private Sub btn_active_snagit_Click(sender As Object, e As EventArgs) Handles btn_active_snagit.Click
        'Activer Snagit
        If ITalk_Label12.Text = "Ouvert avec droit Admin : /!\ NON /!\" = True Then
            If MsgBox("UnlockSoftwares n'est pas exécuté en tant qu'administrateur, le crack ne risque de ne pas fonctionner, nous vous conseillons de rouvrir UnlockSoftwares avec les droits Administrateurs" & vbNewLine & vbNewLine & "Oui = Rouvrir UnlockSoftwares avec les droits administrateurs" & vbNewLine & "Non = Continuer la procédure sans les droits administrateurs.", vbYesNo + vbInformation, "Attention, il vous manque les droits administrateurs continuer ?") = vbYes Then
                ITalk_Button_157_Click(sender, New System.EventArgs())
                Exit Sub
            End If
        End If
        Try
            KillProcess("Snagit32")
            KillProcess("Snagit64")
            KillProcess("SnagitEditor")
            TextBox12.Text = "Fermeture de Snagit effectué !"
            Dim SnagitChemin As String
            Dim ProgrammChemin As String = Environment.GetEnvironmentVariable("ProgramW6432") & "\"
            Dim Programm86Chemin As String = Environment.GetEnvironmentVariable("PROGRAMFILES(X86)") & "\"
            If System.IO.File.Exists(ProgrammChemin & "TechSmith\Snagit 18\Snagit32.exe") = True Then
                SnagitChemin = ProgrammChemin & "TechSmith\Snagit 18"
            ElseIf System.IO.File.Exists(Programm86Chemin & "TechSmith\Snagit 18\Snagit32.exe") = True Then
                SnagitChemin = "C:\Program Files (x86)\TechSmith\Snagit 18"
            ElseIf System.IO.File.Exists(ProgrammChemin & "TechSmith\Snagit 2018\Snagit32.exe") = True Then
                SnagitChemin = ProgrammChemin & "TechSmith\Snagit 2018"
            ElseIf System.IO.File.Exists(Programm86Chemin & "TechSmith\Snagit 2018\Snagit32.exe") = True Then
                SnagitChemin = Programm86Chemin & "TechSmith\Snagit 2018"
            ElseIf System.IO.File.Exists(ProgrammChemin & "TechSmith\Snagit 2019\Snagit32.exe") = True Then
                SnagitChemin = ProgrammChemin & "TechSmith\Snagit 2019"
            ElseIf System.IO.File.Exists(Programm86Chemin & "TechSmith\Snagit 2019\Snagit32.exe") = True Then
                SnagitChemin = Programm86Chemin & "TechSmith\Snagit 2019"
            ElseIf System.IO.File.Exists(ProgrammChemin & "TechSmith\Snagit 2020\Snagit32.exe") = True Then
                SnagitChemin = ProgrammChemin & "TechSmith\Snagit 2020"
            ElseIf System.IO.File.Exists(Programm86Chemin & "TechSmith\Snagit 2020\Snagit32.exe") = True Then
                SnagitChemin = Programm86Chemin & "TechSmith\Snagit 2020"
            ElseIf System.IO.File.Exists(ProgrammChemin & "TechSmith\Snagit 2021\Snagit32.exe") = True Then
                SnagitChemin = ProgrammChemin & "TechSmith\Snagit 2021"
            ElseIf System.IO.File.Exists(Programm86Chemin & "TechSmith\Snagit 2021\Snagit32.exe") = True Then
                SnagitChemin = Programm86Chemin & "TechSmith\Snagit 2021"
            ElseIf System.IO.File.Exists(ProgrammChemin & "TechSmith\Snagit 2022\Snagit32.exe") = True Then
                SnagitChemin = ProgrammChemin & "TechSmith\Snagit 2022"
            ElseIf System.IO.File.Exists(Programm86Chemin & "TechSmith\Snagit 2022\Snagit32.exe") = True Then
                SnagitChemin = Programm86Chemin & "TechSmith\Snagit 2022"
            Else
                Dim FolderBrowserDialog1 As FolderBrowserDialog = New FolderBrowserDialog
                FolderBrowserDialog1.Description = "Veuillez sélectionner le dossier où vous avez installé Snagit"
                FolderBrowserDialog1.SelectedPath = "C:\"
                FolderBrowserDialog1.ShowNewFolderButton = False
                If FolderBrowserDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    SnagitChemin = FolderBrowserDialog1.SelectedPath
                Else
                    MsgBox("Aucun dossier n'a été sélectionné", MsgBoxStyle.Exclamation, "Aucun dossier sélectionné")
                    Exit Try
                    End
                End If
            End If
            TextBox12.Text = TextBox12.Text & vbNewLine & "Récupération du chemin d'installation de Snagit par défaut : " & SnagitChemin
            Dim FileProperties As FileVersionInfo = FileVersionInfo.GetVersionInfo(Path.GetFullPath(SnagitChemin & "\Snagit32.exe"))
            TextBox12.Text = TextBox12.Text & vbNewLine & "Version de Snagit : " & FileProperties.FileVersion & vbNewLine & "Crack réalisé version 19.1.2.X"
            TextBox12.Text = TextBox12.Text & vbNewLine & "Demande de blocage réseau pour l'application via le fichier host"
            Dim write As System.IO.StreamWriter
            write = New System.IO.StreamWriter("C:\windows\system32\drivers\etc\hosts", True)
            write.WriteLine("0.0.0.0  oscount.techsmith.com" & vbNewLine & "0.0.0.0  oscount.techsmith.com" & vbNewLine & "0.0.0.0 activation.cloud.techsmith.com" & vbNewLine & "0.0.0.0 updater.techsmith.com" & vbNewLine & "0.0.0.0 camtasiatudi.techsmith.com" & vbNewLine & "0.0.0.0 tsccloud.cloudapp.net" & vbNewLine & "0.0.0.0 assets.cloud.techsmith.com")
            write.Close()
            TextBox12.Text = TextBox12.Text & vbNewLine & "blocage de l'application via le fichier host réussi"
            Dim p As New Process
            p.StartInfo.CreateNoWindow = True
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden

            Dim SnagitProgramData As String
            If System.IO.Directory.Exists(PROGRAMDATAChemin & "TechSmith\Snagit 8") = True Then
                SnagitProgramData = PROGRAMDATAChemin & "TechSmith\Snagit 8"
            ElseIf System.IO.Directory.Exists(PROGRAMDATAChemin & "TechSmith\Snagit 9") = True Then
                SnagitProgramData = PROGRAMDATAChemin & "TechSmith\Snagit 9"
            ElseIf System.IO.Directory.Exists(PROGRAMDATAChemin & "TechSmith\Snagit 18") = True Then
                SnagitProgramData = PROGRAMDATAChemin & "TechSmith\Snagit 18"
            ElseIf System.IO.Directory.Exists(PROGRAMDATAChemin & "TechSmith\Snagit 19") = True Then
                SnagitProgramData = PROGRAMDATAChemin & "TechSmith\Snagit 19"
            ElseIf System.IO.Directory.Exists(PROGRAMDATAChemin & "TechSmith\Snagit 20") = True Then
                SnagitProgramData = PROGRAMDATAChemin & "TechSmith\Snagit 20"
            ElseIf System.IO.Directory.Exists(PROGRAMDATAChemin & "TechSmith\Snagit 21") = True Then
                SnagitProgramData = PROGRAMDATAChemin & "TechSmith\Snagit 21"
            ElseIf System.IO.Directory.Exists(PROGRAMDATAChemin & "TechSmith\Snagit 22") = True Then
                SnagitProgramData = PROGRAMDATAChemin & "TechSmith\Snagit 22"
            Else
                MsgBox("Vous devez ouvrir Snagit après l'installation au moins une fois puis relancer l'activation", vbInformation + vbOKOnly, "Vous devez lancer Snagit une fois")
                Exit Sub
            End If

            TextBox12.Text = TextBox12.Text & vbNewLine & "Demande d'accès au droit du fichier licence"
            p.StartInfo.Arguments = ("/C takeown /f " & Chr(34) & SnagitProgramData & "\RegInfo.ini" & Chr(34) & " & icacls " & Chr(34) & SnagitProgramData & "\RegInfo.ini" & Chr(34) & " /grant:r Administrateurs:(OI)(CI)F & Attrib -r -a -s -h " & Chr(34) & SnagitProgramData & "\RegInfo.ini" & Chr(34))
            p.StartInfo.FileName = ("CMD.exe")
            p.Start()
            System.Threading.Thread.Sleep(2000)
            TextBox12.Text = TextBox12.Text & vbNewLine & "Droit d'accès au fichier validé"
            System.Threading.Thread.Sleep(2000)
            If System.IO.File.Exists(PROGRAMDATAChemin & "ABOAT\UnlockSoftwares\RegInfoOriginale.ini") = False Then
                If System.IO.File.Exists(SnagitProgramData & "\RegInfo.ini") = True Then
                    File.Copy(SnagitProgramData & "\RegInfo.ini", PROGRAMDATAChemin & "ABOAT\UnlockSoftwares\RegInfoOriginale.ini")
                    TextBox12.Text = TextBox12.Text & vbNewLine & "Sauvegarde du fichier original effectué = C:\ProgramData\ABOAT\UnlockSoftwares\RegInfoOriginale.ini"
                Else
                    TextBox12.Text = TextBox12.Text & vbNewLine & "Erreur pour la Sauvegarde du fichier original  !"
                End If

            Else
                If System.IO.File.Exists(SnagitProgramData & "\RegInfo.ini") = True Then
                    File.Delete(PROGRAMDATAChemin & "ABOAT\UnlockSoftwares\RegInfoOriginaleSnagit.ini")
                    File.Copy(SnagitProgramData & "\RegInfo.ini", PROGRAMDATAChemin & "ABOAT\UnlockSoftwares\RegInfoOriginaleSnagit.ini")
                    TextBox12.Text = TextBox12.Text & vbNewLine & "Sauvegarde du fichier original effectué = C:\ProgramData\ABOAT\UnlockSoftwares\RegInfoOriginaleSnagit.ini"
                Else
                    TextBox12.Text = TextBox12.Text & vbNewLine & "Erreur pour la Sauvegarde du fichier original  !"
                End If


            End If
            System.Threading.Thread.Sleep(2000)
            If System.IO.File.Exists(SnagitProgramData & "\RegInfo.ini") = True Then
                File.Delete(SnagitProgramData & "\RegInfo.ini")
                TextBox12.Text = TextBox12.Text & vbNewLine & "Fichier Original RegInfo.ini supprimé"
            End If

            If System.IO.File.Exists(SnagitProgramData & "\RegInfo.txt") = True Then
                File.Delete(SnagitProgramData & "\RegInfo.txt")
                TextBox12.Text = TextBox12.Text & vbNewLine & "Fichier Original RegInfo.txt supprimé"
            End If


            If System.IO.File.Exists(PROGRAMDATAChemin & "ABOAT\UnlockSoftwares\RegInfo.txt") = True Then File.Delete(PROGRAMDATAChemin & "ABOAT\UnlockSoftwares\RegInfo.txt")

            TextBox12.Text = TextBox12.Text & vbNewLine & "Création du fichier activation Snagit en cours ..."
            Dim sw As New StreamWriter(PROGRAMDATAChemin & "ABOAT\UnlockSoftwares\RegInfo.txt")
            sw.WriteLine("[RegistrationInfo]" & vbNewLine & "RegistrationKey=NC8CA5KGCQ98AV8V8GEY7A8BA" & vbNewLine & "RegisteredTo=NC8CA-5KGCQ-98AV8-V8GEY-7A8BA")
            sw.Close()
            System.Threading.Thread.Sleep(200)
            File.Copy(PROGRAMDATAChemin & "ABOAT\UnlockSoftwares\RegInfo.txt", SnagitProgramData & "\RegInfo.txt")
            File.Move(PROGRAMDATAChemin & "ABOAT\UnlockSoftwares\RegInfo.txt", SnagitProgramData & "\RegInfo.ini")
            System.Threading.Thread.Sleep(200)

            If System.IO.File.Exists(SnagitProgramData & "\RegInfo.ini") = False Then
                TextBox12.Text = TextBox12.Text & vbNewLine & "Erreur le fichier n'a pu être créé dans : " & SnagitProgramData
            Else
                TextBox12.Text = TextBox12.Text & vbNewLine & "Fichier licence créé avec succès"
                If System.IO.File.Exists(SnagitProgramData & "\RegInfo.ini") = True Then File.SetAttributes(SnagitProgramData & "\RegInfo.ini", FileAttributes.ReadOnly)
                TextBox12.Text = TextBox12.Text & vbNewLine & vbNewLine & "Activation FINI !"
            End If


        Catch ex As Exception
            infoerreur(ex, TextBox12)
        End Try
    End Sub

    Private Sub btn_active_speccy_Click(sender As Object, e As EventArgs) Handles btn_active_speccy.Click
        'Activer Speccy
        If ITalk_Label12.Text = "Ouvert avec droit Admin : /!\ NON /!\" = True Then
            If MsgBox("UnlockSoftwares n'est pas exécuté en tant qu'administrateur, le crack ne risque de ne pas fonctionner, nous vous conseillons de rouvrir UnlockSoftwares avec les droits Administrateurs" & vbNewLine & vbNewLine & "Oui = Rouvrir UnlockSoftwares avec les droits administrateurs" & vbNewLine & "Non = Continuer la procédure sans les droits administrateurs.", vbYesNo + vbInformation, "Attention, il vous manque les droits administrateurs continuer ?") = vbYes Then
                ITalk_Button_157_Click(sender, New System.EventArgs())
                Exit Sub
            End If
        End If


        Try
            KillProcess("Speccy64")
            KillProcess("Speccy32")
            TextBox9.Text = "Fermeture de Speccy effectué !"
            TextBox9.Text = TextBox9.Text & vbNewLine & "Demande de blocage réseau pour l'application via le fichier host"
            Dim monFichier As String = "C:\windows\system32\drivers\etc\hosts"
            Dim monEcriture As System.IO.StreamWriter
            monEcriture = New System.IO.StreamWriter(monFichier, True)
            monEcriture.WriteLine("127.0.0.1   license.piriform.com")
            monEcriture.Close()
            TextBox9.Text = TextBox9.Text & vbNewLine & "Blocage de l'application via le fichier host réussi"
            TextBox9.Text = TextBox9.Text & vbNewLine & "Speccy -> Aide -> A propos : Passer a la version Pro :"
            TextBox9.Text = TextBox9.Text & vbNewLine & "Ajouter la clé : " & vbNewLine & "Clé : " & vbNewLine & "SQ6D-A595-BBU2-9HBE-29PP" & vbNewLine & vbNewLine & "SQ6D-AT4Z-VMNZ-6BWN-A9PP" & vbNewLine & "Utilisateur : " & vbNewLine & Environment.UserName.ToString()
        Catch ex As Exception
            infoerreur(ex, TextBox9)
        End Try
    End Sub

    Private Sub btn_active_winrar_Click(sender As Object, e As EventArgs) Handles btn_active_winrar.Click
        'Activer WinRAR
        If ITalk_Label12.Text = "Ouvert avec droit Admin : /!\ NON /!\" = True Then
            If MsgBox("UnlockSoftwares n'est pas exécuté en tant qu'administrateur, le crack ne risque de ne pas fonctionner, nous vous conseillons de rouvrir UnlockSoftwares avec les droits Administrateurs" & vbNewLine & vbNewLine & "Oui = Rouvrir UnlockSoftwares avec les droits administrateurs" & vbNewLine & "Non = Continuer la procédure sans les droits administrateurs.", vbYesNo + vbInformation, "Attention, il vous manque les droits administrateurs continuer ?") = vbYes Then
                ITalk_Button_157_Click(sender, New System.EventArgs())
                Exit Sub
            End If
        End If


        Try
            KillProcess("WinRAR")
            TextBox5.Text = "Fermeture de Winrar effectué"
            Dim WinrarChemin As String
            If System.IO.File.Exists("C:\Program Files\WinRAR\WinRAR.exe") = True Then
                WinrarChemin = "C:\Program Files\WinRAR"
            ElseIf System.IO.File.Exists("C:\Program Files (x86)\WinRAR\WinRAR.exe") = True Then
                WinrarChemin = "C:\Program Files (x86)\WinRAR"
            Else
                Dim FolderBrowserDialog2 As FolderBrowserDialog = New FolderBrowserDialog
                FolderBrowserDialog2.Description = "Veuillez sélectionner le dossier où vous avez installé WinRAR"
                FolderBrowserDialog2.SelectedPath = "C:\"
                FolderBrowserDialog2.ShowNewFolderButton = False
                If FolderBrowserDialog2.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    WinrarChemin = FolderBrowserDialog2.SelectedPath
                Else
                    MsgBox("Aucun dossier n'a été sélectionné", MsgBoxStyle.Exclamation, "Aucun dossier sélectionné")
                    End
                End If
            End If
            TextBox5.Text = TextBox5.Text & vbNewLine & "Récupération du chemin d'installation de Winrar par défaut : " & WinrarChemin
            Dim FileProperties As FileVersionInfo = FileVersionInfo.GetVersionInfo(Path.GetFullPath(WinrarChemin & "\WinRAR.exe"))
            TextBox5.Text = TextBox5.Text & vbNewLine & "Version de WinRAR : " & FileProperties.FileVersion
            TextBox5.Text = TextBox5.Text & vbNewLine & "Création du fichier crack rarreg.key en cours"
            Dim sw As New StreamWriter(WinrarChemin & "\rarreg.key")
            sw.WriteLine("RAR registration data" & vbNewLine & "MUMBAI" & vbNewLine & "Unlimited Company License" & vbNewLine & "UID=a9c95181cb1cc6bdfdbf" & vbNewLine & "6412212250fdbf15381d40c19821fe54e3f5e08e2bcbc0e74d54a9" & vbNewLine & "72c0821c2139608f499460fce6cb5ffde62890079861be57638717" & vbNewLine & "7131ced835ed65cc743d9777f2ea71a8e32c7e593cf66794343565" & vbNewLine & "b41bcf56929486b8bcdac33d50ecf77399606da079df26411b62ea" & vbNewLine & "f6783e809c95c1dd56a5247a31da28f019429fb93d2b01854f5757" & vbNewLine & "652f89ba86f989035f4471f39cfeba69c70f49a5978aef1c609ec7" & vbNewLine & "e904cb14db49edd730e5018853425596d8ec5ceefd0c4134353128")
            sw.Close()
            If System.IO.File.Exists(WinrarChemin & "\rarreg.key") = False Then
                TextBox5.Text = TextBox5.Text & vbNewLine & "Erreur le fichier n'a pu être créé dans : " & WinrarChemin
            Else
                TextBox5.Text = TextBox5.Text & vbNewLine & "Fichier créé avec succès dans : " & WinrarChemin
                TextBox5.Text = TextBox5.Text & vbNewLine & vbNewLine & "Activation réussie."
            End If
        Catch ex As Exception
            infoerreur(ex, TextBox5)
        End Try
    End Sub
#End Region


    Private Sub infoerreur(ex, TexboxAfficheErreur)
        'Affiche l'erreur et montre le fichier
        If TypeOf TexboxAfficheErreur Is TextBox Then
            TexboxAfficheErreur.Text = TexboxAfficheErreur.Text & vbNewLine & vbNewLine & "*Une erreur est survenue : " & vbNewLine & ex.Message
            If ITalk_Label12.Text = "Ouvert avec droit Admin : /!\ NON /!\" Then
                TexboxAfficheErreur.Text = TexboxAfficheErreur.Text & vbNewLine & "ERREUR exécuter ce programme en administrateur."
            Else
                TexboxAfficheErreur.Text = TexboxAfficheErreur.Text & vbNewLine & "Si l'erreur persiste merci de contacter l'Auteur"
            End If
        End If
        Erreur = ex.Message
        ITalk_Label15.Visible = True
        Dim sw As New StreamWriter(PROGRAMDATAChemin & "ABOAT\UnlockSoftwares\Une erreur Contact-Moi.txt")

        Dim texteErreur As String =
        "Une erreur semble s'être produite ? Signalez le nous !" & vbNewLine & vbNewLine &
        "Message à envoyer : " & vbNewLine & vbNewLine &
        "---------------(A copier/coller)---------------" & vbNewLine & vbNewLine &
        "Bonjour, j'ai rencontré un problème avec votre logiciel," & vbNewLine &
        "Je m'explique :" & vbNewLine & vbNewLine & "
        Un commentaire a rajouter ?" & vbNewLine & vbNewLine &
        "Le message d'erreur généré automatiquement par l'application : " & vbNewLine & ex.Message & vbNewLine & vbNewLine & ex.ToString & vbNewLine & vbNewLine &
        "Merci beaucoup !" & vbNewLine & "---------------(A copier/coller)---------------"
        sw.WriteLine(texteErreur)
        sw.Close()
    End Sub

    Private Sub btn_active_revo_Click(sender As Object, e As EventArgs) Handles btn_active_revo.Click
        'Activer revo uninstaller
        If ITalk_Label12.Text = "Ouvert avec droit Admin : /!\ NON /!\" = True Then
            If MsgBox("UnlockSoftwares n'est pas exécuté en tant qu'administrateur, le crack ne risque de ne pas fonctionner, nous vous conseillons de rouvrir UnlockSoftwares avec les droits Administrateurs" & vbNewLine & vbNewLine & "Oui = Rouvrir UnlockSoftwares avec les droits administrateurs" & vbNewLine & "Non = Continuer la procédure sans les droits administrateurs.", vbYesNo + vbInformation, "Attention, il vous manque les droits administrateurs continuer ?") = vbYes Then
                ITalk_Button_157_Click(sender, New System.EventArgs())
                Exit Sub
            End If
        End If


        Try

            KillProcess("RevoUninPro")
            TextBox4.Text = "Fermeture de RevoUninPro effectué"
            If System.IO.File.Exists(PROGRAMDATAChemin & "VS Revo Group\Revo Uninstaller Pro\revouninstallerpro4.lic") Then
                TextBox4.Text += NewLine & "Fichier licence trouver"
                File.Copy(PROGRAMDATAChemin & "VS Revo Group\Revo Uninstaller Pro\revouninstallerpro4.lic", PROGRAMDATAChemin & "ABOAT\UnlockSoftwares\revouninstallerpro4ORIGINAL.lic")
                File.Delete(PROGRAMDATAChemin & "VS Revo Group\Revo Uninstaller Pro\revouninstallerpro4.lic")
                TextBox4.Text += NewLine & "Fichier licence original sauvegarder dans  : " & PROGRAMDATAChemin & "ABOAT\UnlockSoftwares\revouninstallerpro4ORIGINAL.lic"
                My.Computer.FileSystem.WriteAllBytes(PROGRAMDATAChemin & "VS Revo Group\Revo Uninstaller Pro\revouninstallerpro4.lic", My.Resources.revouninstallerpro4, True)
                TextBox4.Text += NewLine & "Licence rentrer !"
                TextBox4.Text += vbNewLine & vbNewLine & "Activation fini."
            Else
                TextBox4.Text += NewLine & "/!\ Fichier licence non trouver ! Vous devez lancer RevoUninPro au moins une fois pour l'initialiser ! "
            End If



        Catch ex As Exception
            infoerreur(ex, TextBox5)
        End Try
    End Sub
End Class