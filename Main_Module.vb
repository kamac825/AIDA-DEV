
Option Strict Off
Option Explicit Off
Option Infer Off
Imports System.Windows.Forms

'WRITTEN BY CHRIS RAPOSO / EDITED BY KAMERON MCELROY 
'MAIN MODULE FOR THE PROJECT,COMMAND MODULE TO HOLD ALL COMMANDS

'CHANGELOG

'1.OS INFORMATION METHOD TO BE ADDED LATER
'1.CONNECT AIDA TO INTERNET

Module Module1
    Public input As String
    Public user As String
    Public gueston1 As Boolean = False
    Public signedon As Boolean = False
    Private count As Integer = 0
    Public loginthread As New System.Threading.Thread(AddressOf LOGIN)
    Sub Main()
        'Begining Statements\
        'Login to the app
        Dim socialthread As New System.Threading.Thread(AddressOf SOCIAL)
        Console.Clear()
        If signedon = False And gueston1 = False Then

            LOGIN()

        Else
            Console.WriteLine("A.I.D.A, the Artifical Intelligence Development Application.")
            Call Std_input()
            ' Calls Methods Depending on Statements
            Select Case input
                Case "FUN"
                    Call FUNCommand()
                Case "TRIVIA"
                    Call Command_Module.TRIVIACommand()
                Case "OSINFO"
                    Call OSINFORMATION()
                Case "DICEROLL"
                    Call diceRoll()
                Case "RANDNUM"
                    Call randNum()
                Case "EIGHTBALL"
                    Call eightBall()
                Case "GETIP"
                    Call GetIPAddress()
                Case "SEARCHNET"
                    Call searchInt()
                Case "SOCIAL"
                    socialthread.Start()
                Case "TIMER"
                    Call timer("")
                Case "EXIT"
                    Dim yesno As String = ""
                    'Ask if sure
                    Console.WriteLine("Are You Sure?")
                    yesno = Console.ReadLine()
                    yesno = yesno.ToUpper()
                    If yesno = "Y" Then
                        Environment.Exit(0)

                    ElseIf yesno = "N" Then
                        Call Main()
                    End If
                Case "LOGIN"
                    loginthread.Start()
                Case "NOTES"
                    Call Joeys_notes()
                Case Else
                    Console.WriteLine("Invalid Input, Please Try Again")
                    Console.ReadLine()
                    Call Main()
            End Select
        End If
    End Sub

    Public Sub Std_input()

        Console.Write(user & ":\")
        input = Console.ReadLine()
        input = input.ToUpper
    End Sub

    Private Sub LOGIN()

        If count = 0 Then
            count = 1
            Application.EnableVisualStyles()
            Application.Run(New Login)
        ElseIf count = 1 Then
            'do nothing
        End If


    End Sub
    Private Sub SOCIAL()
        Application.EnableVisualStyles()
        Application.Run(New Social)
    End Sub

End Module
