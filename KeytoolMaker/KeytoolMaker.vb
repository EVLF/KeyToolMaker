Imports System.IO
Imports System.Threading
Imports System.Threading.Tasks
'----------------Created By EVLF----------------

Public Class KeytoolMaker

    Public Mypath As String = Application.StartupPath
    Public Temppath As String = Application.StartupPath + "\" + "PAS" + ".keystore"
    Public FinalFolder As String = Application.StartupPath + "\" + "OUT"
    Public EVLFSIGN As String = vbNewLine + "-----------------------------" + vbNewLine + vbNewLine + " 
This is free open source tool 
    Created By EVLF Using VB.net 
to Quickly Create Random Signing Keys For Apks
- - - - - - - - - - - -
https://github.com/EVLF"

    Public Sub Logit(Str As String)
        Logger.AppendText("• " + Str + vbNewLine)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Not engine_on Then
            engine_on = True
            Logger.Text = ""
            Logger.TextAlign = HorizontalAlignment.Left
            BW.RunWorkerAsync()
        End If


    End Sub

    Private Sub BW_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BW.DoWork
        Logit("StartWorking")
        Try

            Dim targetpath As String = "null"
            Dim Keytoolpath As String = "null"
            Dim di As New DirectoryInfo("C:\Program Files\Java")

            Dim fiArr As DirectoryInfo() = di.GetDirectories()

            Dim fri As DirectoryInfo
            For Each fri In fiArr

                If fri.Name.ToLower.StartsWith("jre") Or fri.Name.ToLower.StartsWith("jdk") Then
                    targetpath = fri.FullName
                    Exit For
                End If

            Next fri

            If targetpath = "null" Then
                Logit("Java Not Found")
                Return

            Else
                If Not File.Exists(targetpath + "\bin\" + "keytool.exe") Then
                    Logit("keytool Not Found")
                    Return
                Else
                    Keytoolpath = targetpath + "\bin\" + "keytool.exe"
                End If
            End If

            CMD = New Process

            CMD.StartInfo.RedirectStandardOutput = True

            CMD.StartInfo.RedirectStandardInput = True

            CMD.StartInfo.RedirectStandardError = True

            CMD.StartInfo.FileName = "cmd.exe"

            AddHandler CType(CMD, Process).OutputDataReceived, AddressOf Sync_Output


            AddHandler CType(CMD, Process).ErrorDataReceived, AddressOf Sync_Output

            AddHandler CType(CMD, Process).Exited, AddressOf ex

            CMD.StartInfo.UseShellExecute = False

            CMD.StartInfo.CreateNoWindow = True

            CMD.StartInfo.WindowStyle = ProcessWindowStyle.Hidden

            CMD.EnableRaisingEvents = True

            CMD.Start()

            CMD.BeginOutputReadLine()

            CMD.BeginErrorReadLine()

            If thepass Is Nothing Then
                thepass = RandomString(20, 35)
            End If

            CMD.StandardInput.WriteLine("""" + Keytoolpath + """" + " -genkey -v -keystore " + """" + Temppath.Replace("PAS", thepass) + """" + " -alias [alias_name] -keyalg RSA -keysize 4096 -deststoretype pkcs12 -validity 365000".Replace("[alias_name]", RandomString(4, 9)))
            CMD.StandardInput.WriteLine(" ")

        Catch ex As Exception
            Logit("oops somthing Wrong : " + ex.Message)
        End Try
    End Sub


    Private CMD As Object
    Private Sub Close_cmd()

        Application.ExitThread()

        CMD.CancelOutputRead()

        CMD.CancelErrorRead()

        CMD.Kill()

        CMD.Close()

        End

    End Sub
    Delegate Sub Delegate0(ByVal d0 As Object, b0 As Object)
    Public Sub Sync_Output(ByVal d01 As Object, ByVal b01 As Object)
        Try

            If Me.InvokeRequired Then

                Dim iInvoke As New Delegate0(AddressOf Sync_Output)

                Me.Invoke(iInvoke, New Object() {d01, b01})

                Exit Sub

            Else

                If Not String.IsNullOrEmpty(b01.Data) Then
                    Logit(b01.Data)
                    'If b01.Data.ToString.ToLower.Contains("bin") Then

                    'End If

                    If b01.data.ToString.ToLower.Contains("too short") Then

                        CMD.StandardInput.WriteLine(thepass)
                        CMD.StandardInput.WriteLine(thepass)
                    End If

                    'If b01.data.ToString.ToLower.Contains("Re-Enter New password") Then
                    '    CMD.StandardInput.WriteLine(thepass)
                    'End If

                    If b01.data.ToString.ToLower.Contains("what is") Then
                        CMD.StandardInput.WriteLine(RandomString(2, 2).ToUpper)
                    End If


                    If b01.data.ToString.ToLower.Contains("correct?") Then
                        CMD.StandardInput.WriteLine("yes")
                    End If


                    If b01.data.ToString.ToLower.Contains("Enter key password for".ToLower) Then
                        CMD.StandardInput.WriteLine(thepass)
                        ' Thread.Sleep(1)
                        CMD.StandardInput.WriteLine(thepass)
                    End If


                    If b01.data.ToString.ToLower.Contains("Storing".ToLower) Then


                        Dim holdThread As New Thread(Sub()

                                                         If Directory.Exists(FinalFolder) Then
                                                             Directory.Delete(FinalFolder, True)
                                                         End If
                                                         Directory.CreateDirectory(FinalFolder)
hold:
                                                         If Not File.Exists(Temppath.Replace("PAS", thepass)) Then
                                                             Thread.Sleep(1000)
                                                             GoTo hold
                                                         End If

                                                         File.Move(Temppath.Replace("PAS", thepass), FinalFolder + "\NewKey.keystore")
                                                         File.WriteAllText(FinalFolder + "\Key_Password.txt", thepass)
                                                         Threading.Thread.Sleep(1000)
                                                         Process.Start(FinalFolder)
                                                         engine_on = False

                                                     End Sub)
                        holdThread.Start()


                    End If

                End If

            End If

        Catch ex As Exception
        End Try

    End Sub
    Public thepass As String = Nothing
    Public r As Random = Nothing

    Function RandomString(minCharacters As Integer, maxCharacters As Integer) As String
        Dim s As String = "qQaAzZwWsSxXeEdDcCrRfFvVtTgGbByYhHnNuUjJmMikolp"
        If r Is Nothing Then
            r = New Random
        End If

        Dim chactersInString As Integer = r.Next(minCharacters, maxCharacters)
        Dim sb As New System.Text.StringBuilder
        For i As Integer = 1 To chactersInString
            Dim idx As Integer = r.Next(0, s.Length)
            sb.Append(s.Substring(idx, 1))
        Next

        Return sb.ToString()
    End Function
    Private Sub ex()
        MsgBox("cmd.exe Unexpectedly closed !!", MsgBoxStyle.Critical, "")
        Try
            Close_cmd()
        Catch ex As Exception
        Finally
            End
        End Try
    End Sub

    Public engine_on = False
    Public holdthread = False
    Public resumthread = False



    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
    End Sub

    Private Sub Main_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        engine_on = False
        'EngineProcess.Close()
    End Sub

    Private Sub Logger_TextChanged(sender As Object, e As EventArgs)

        Logger.SelectionStart = Len(Logger.Text)

        Logger.ScrollToCaret()

    End Sub
    Dim cont = 0
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If cont < EVLFSIGN.Length Then
            Logger.Text += EVLFSIGN(cont)
            cont += 1
        Else
            Timer1.Stop()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Logger.Text = ""
        Logger.TextAlign = HorizontalAlignment.Center
        Timer1.Start()
    End Sub
End Class
