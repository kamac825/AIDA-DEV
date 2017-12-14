Imports System.Data.SqlClient
Imports System.IO
'MODULE CREATED ON 11/7/17 BY KAMERON MCELROY, PROJECT BY CHRIS RAPOSO
'HOLDS ALL COMMANDS FOR MAIN_MODULE

'CHANGELOG:

'1.OS INFORMATION METHOD TO BE ADDED LATER 
'2.CONNECT AIDA TO INTERNET (Done Somewhat)


Module Command_Module
    Sub FUNCommand()
        Dim Fun As String = ""
        Console.Clear()
        'Displays the Help Page
        Console.WriteLine("Hello, I am A.I.D.A Fun Help Page, and I would like to talk with you.I have been programmed with these options. Choose One!(More to Come LATER)
                  F for Food       P for Politics      G for Video Games        T for Trivia  or E to Exit")
        'collects input and converts to uppercase
        Call win()
        Fun = Console.ReadLine()
        Fun = Fun.ToUpper()

        'Choose the Selections
        Select Case Fun
            Case "F"
                Call TREATS()
            Case "P"
                Call POLITICS()
            Case "G"
                Call GAMES()
            Case "T"
                Call TRIVIACommand()
            Case "E"
                Main()
            Case Else
                Console.WriteLine("Invalid Input, Please Try Again")
                Console.ReadLine()
                Call FUNCommand()
        End Select
        'goes back to the main module
        Call Module1.Main()
    End Sub
    Sub TRIVIACommand()
        Dim trivia As String = ""
        Dim yesno As String = ""
        ''To Handle Trivia Command
        Console.Clear()
        Console.WriteLine("Knowledge is power said Francis Bacon, and right now we are going to test that. Pick a random number from 1-9.")
        Call win()
        trivia = Console.ReadLine()
        Select Case trivia
            Case "1"
                Do While True
                    Console.WriteLine("The beaver is the national emblem if which country?")
                    Console.WriteLine()
                    trivia = Console.ReadLine()
                    trivia = trivia.ToUpper()
                    If trivia = "CANADA" Then
                        Console.WriteLine("Correct!")
                        Exit Do
                    Else
                        Console.WriteLine("Incorrect, sorry!")
                    End If
                Loop

            Case "2"
                Do While True
                    Console.WriteLine("How many players are there on a basketball team?")
                    Console.WriteLine()
                    trivia = Console.ReadLine()
                    trivia = trivia.ToUpper()
                    If trivia = "9" Or trivia = "NINE" Then
                        Console.WriteLine("Correct!")
                        Exit Do
                    Else
                        Console.WriteLine("Incorrect, sorry!")
                    End If
                Loop
            Case "3"
                Do While True
                    Console.WriteLine("The average human body contains how many pints of blood?")
                    Console.WriteLine()
                    trivia = Console.ReadLine()
                    trivia = trivia.ToUpper()
                    If trivia = "9" Or trivia = "NINE" Then
                        Console.WriteLine("Correct!")
                        Exit Do
                    Else
                        Console.WriteLine("Incorrect, sorry!")
                    End If
                Loop
            Case "4"
                Do While True
                    Console.WriteLine("Which US State is nearest to the old Soviet Union?")
                    Console.WriteLine()
                    trivia = Console.ReadLine()
                    trivia = trivia.ToUpper()
                    If trivia = "ALASKA" Then
                        Console.WriteLine("Correct!")
                        Exit Do
                    Else
                        Console.WriteLine("Incorrect, sorry!")
                    End If
                Loop
            Case "5"
                Do While True
                    Console.Write("Hg is the chemical symbol for what?")
                    Console.WriteLine()
                    trivia = Console.ReadLine()
                    trivia = trivia.ToUpper()
                    If trivia = "MERCURY" Then
                        Console.WriteLine("Correct!")
                        Exit Do
                    Else
                        Console.WriteLine("Incorrect, sorry!")
                    End If
                Loop
            Case "6"
                Do While True
                    Console.WriteLine("The Pyrenees mountain range separates which two European countries?")
                    Console.WriteLine()
                    trivia = Console.ReadLine()
                    trivia = trivia.ToUpper()
                    If trivia = "FRANCE AND SPAIN" Or trivia = "FRANCE, SPAIN" Or trivia = "FRANCE SPAIN" Or trivia = "SPAIN AND FRANCE" Or trivia = "SPAIN, FRANCE" Or trivia = "SPAIN FRANCE" Then
                        Console.WriteLine("Correct!")
                        Exit Do
                    Else
                        Console.WriteLine("Incorrect, sorry!")
                    End If
                Loop
            Case "7"
                Do While True
                    Console.WriteLine("Which of the planets are closest to the Sun?")
                    Console.WriteLine()
                    trivia = trivia.ToUpper()
                    trivia = Console.ReadLine()
                    If trivia = "MERCURY" Then
                        Console.WriteLine("Correct!")
                        Exit Do
                    Else
                        Console.WriteLine("Incorrect, sorry!")
                    End If
                Loop
            Case "8"
                Do While True
                    Console.WriteLine("According to Greek Mythology, who was the first woman on earth?")
                    Console.WriteLine()
                    trivia = trivia.ToUpper()
                    trivia = Console.ReadLine()
                    If trivia = "PANDORA" Then
                        Console.WriteLine("Correct!")
                        Exit Do
                    Else
                        Console.WriteLine("Incorrect, sorry!")
                    End If
                Loop
            Case "9"
                Do While True
                    Console.WriteLine("Which country was formerly known as Abyssinia?")
                    Console.WriteLine()
                    trivia = Console.ReadLine()
                    trivia = trivia.ToUpper()
                    If trivia = "ETHIOPIA" Then
                        Console.WriteLine("Correct!")
                        Exit Do
                    Else
                        Console.WriteLine("Incorrect, sorry!")
                    End If

                Loop

            Case Else
                Console.WriteLine("Invalid Input, Please Try Again")
                Call TRIVIACommand()

        End Select

        'To Come Later...

        'Dim dbcon As New SqlConnection
        'Dim connexionstring As String = "Server=tcp:73.227.61.187,1433;Database=AIDACommand Database;User Id=CommandLogin;Password=Command12"
        'dbcon.ConnectionString = connexionstring
        'Dim com1 As New SqlParameter
        'com1.ParameterName = "@question"
        'com1.Value = trivia
        'com1.Direction = ParameterDirection.Output

        'Try
        '    dbcon.Open()

        '    Dim sql As String = "SELECT * FROM AIDATrivia WHERE id = @question"
        '    Dim cmd1 As New SqlCommand(Command, dbcon)
        '    cmd1.Parameters.Add(com1)
        '    cmd1.CommandText = sql
        '    Dim reader As SqlDataReader

        '    reader = cmd1.ExecuteReader()

        '    If reader.Read() Then
        '        Dim read As Integer
        '        read = reader.GetOrdinal("Question")
        '        Console.WriteLine(reader.GetString(read))
        '        Console.ReadLine()
        '    End If
        'Catch ex As Exception
        '    Dim writer As New StreamWriter("C:\Aida\AidaTrivia.txt")
        '    If IO.File.Exists("C:\Aida\AidaTrivia.txt") = True Then
        '        writer.Write(ex)
        '        writer.Dispose()
        '    Else
        '        IO.File.CreateText("C:\Aida\Aidatrivia.txt")
        '        writer.Write(ex)
        '        writer.Dispose()
        '    End If
        'Finally
        '    dbcon.Dispose()
        'End Try


        'asks if they want to continue
        Console.WriteLine("Would You Like To Continue?")
        yesno = Console.ReadLine()
        yesno = yesno.ToUpper()
        If yesno = "Y" Then
            Call TRIVIACommand()
        ElseIf yesno = "N" Then
            'Goes back to Main 
            Call Module1.Main()
        End If

    End Sub
    Sub OSINFORMATION()
        If gueston1 = True Then
            Console.WriteLine("This feature is locked to Members Only,Please Sign In or Sign Up to enter")
            Console.ReadLine()
        Else
            Dim os As String = ""
            Console.Clear()
            Console.WriteLine("What Operating Systems would you like to learn about")
            Console.ReadLine()
            Console.WriteLine("Windows it is then :)")
            Console.WriteLine("Windows NT 3.1  -1993
                            Windows NT 3.5  -1994
                            Windows NT 3.51  -1995
                            Windows NT 4.0  -1995
                            Windows 2000  -2000
                            Windows XP  -2001
                            Windows Vista  -2007
                            Windows 7  -2009
                            Windows 8  -2012
                            Windows 8.1  -2013
                            Windows 10  -2015")
        End If

        Call Main()
    End Sub

    Sub TREATS()
        'declares variables
        Dim yesno As String = ""
        Dim food As String = ""
        'Collects input
        Console.Clear()
        Console.WriteLine("Food is delicious, says my human creator, but I can't eat food. Duh I'm a computer! What would be your favorite food?")
        Call win()
        food = Console.ReadLine()
        'selects the best choice
        Select Case food
            Case "SHRIMP"
                Console.WriteLine("The food you described is a very commonly liked food in America, so your part of the majority of Americans. ")
                Console.WriteLine()
            Case "PIZZA"
                Console.WriteLine("The food you described is a very commonly liked food in America, so your part of the majority of Americans. ")
                Console.WriteLine()
            Case "ICE CREAM"
                Console.WriteLine("The food you described is a very commonly liked food in America, so your part of the majority of Americans. ")
                Console.WriteLine()
            Case "CHIPS"
                Console.WriteLine("The food you described is a very commonly liked food in America, so your part of the majority of Americans. ")
                Console.WriteLine()
            Case "CHICKEN"
                Console.WriteLine("The food you described is a very commonly liked food in America, so your part of the majority of Americans. ")
                Console.WriteLine()
            Case "STEAK"
                Console.WriteLine("The food you described is a very commonly liked food in America, so your part of the majority of Americans. ")
                Console.WriteLine()
            Case "CRACKERS"
                Console.WriteLine("The food you described is a very commonly liked food in America, so your part of the majority of Americans. ")
                Console.WriteLine()
            Case "SANDWICH"
                Console.WriteLine("The food you described is a very commonly liked food in America, so your part of the majority of Americans. ")
                Console.WriteLine()
            Case "CEREAL"
                Console.WriteLine("The food you described is a very commonly liked food in America, so your part of the majority of Americans. ")
                Console.WriteLine()
            Case "LINGUICA"
                Console.WriteLine("The food you described is a very commonly liked food in America, so your part of the majority of Americans. ")
                Console.WriteLine()
            Case "POPCICLES"
                Console.WriteLine("The food you described is a very commonly liked food in America, so your part of the majority of Americans. ")
                Console.WriteLine()
            Case Else
                Console.WriteLine("Hmmmmmmmmm, I don't know of that food, and I can't look it up because I am just Console application. It would be cool if in later updates I could connect to the internet and look it up!? Foreshadowing much!?")
                Console.WriteLine()

        End Select
        'asks if they want to continue
        Console.WriteLine("Would You Like To Continue?")
        yesno = Console.ReadLine()
        yesno = yesno.ToUpper()
        If yesno = "Y" Then
            Call TREATS()
        ElseIf yesno = "N" Then
            'Goes back to Main 
            Call Module1.Main()
        End If

    End Sub
    Sub POLITICS()
        'declares local variable
        If Module1.gueston1 = True Then
            Console.WriteLine("This feature is locked to Members Only,Please Sign In or Sign Up to enter")
            Console.ReadLine()
        Else

            Dim trump As String = ""
            Dim yesno As String = ""
            'collects input and converts to uppercase
            Console.Clear()
            Console.WriteLine("Ahhhhhhhh, Politics. It can get pretty bad if you really get into it. But, my creator has programmed the two major political parties of the Unites States. Which would you like to here?     Republican or Democrat?")
            Call win()
            trump = Console.ReadLine()
            trump.ToUpper()

            'if user chose republican
            If trump = "REPUBLICAN" Then
                'create blank line
                Console.WriteLine()
                Console.WriteLine("The Republican Party was formed in 1854. They have a conservative, right-leaning philosophy.
                                Economic Ideas- Believe taxes shouldn't be increased for anyone (including the wealthy) and that wages should be set by the free market
                                Social and Human Ideas- Based on individual rights and justice
                                Stance on Gay Marriage- Oppose (some Republicans disagree)
                                Stance on Abortion- Should not be legal (with some exceptions); oppose Roe v. Wade
                                Stance on Taxes- Tend to favor a flat tax (same tax rate regardless of income). Generally opposed to raising taxes")
                'creates blank lines
                Console.WriteLine()
                Console.WriteLine()
                'if user chose democrat
            ElseIf trump = "DEMOCRAT" Then
                'creates blank line
                Console.WriteLine()
                Console.WriteLine("The Democratic Party was formed in 1824. They have a liberal, left-leaning philosophy.
                                Economic Ideas- Minimum wages and progressive taxation, i.e., higher tax rates for higher income brackets. Born out of anti-federalist ideals but evolved over time to favor more government regulation
                                Social and Human Ideas- Based on community and social responsibility
                                Stance on Gay Marriage- Support (some Democrats disagree)
                                Stance on Abortion- Should remain legal; support Roe v. Wade
                                Stance on Taxes- Progressive (high income earners should be taxed at a higher rate). Generally not opposed to raising taxes to fund government")
                'creates blank lines
                Console.WriteLine()
                Console.WriteLine()
            Else
                'If Bad Input
                Console.WriteLine("Sorry, Try Again")
                Call POLITICS()

            End If

            'asks if they want to continue
            Console.WriteLine("Would You Like To Continue?")
            yesno = Console.ReadLine()
            yesno = yesno.ToUpper()
            If yesno = "Y" Then
                Call POLITICS()
            ElseIf yesno = "N" Then
                'Goes back to Main 
                Call Module1.Main()
            End If
        End If
        Call Main()

    End Sub
    Sub GAMES()
        If gueston1 = True Then
            Console.WriteLine("This feature is locked to members only,Please Sign in or Sign up to enter")
        Else
            'declares the variables
            Dim game As String = ""
            Dim yesno As String = ""
            'opening statement
            Console.Clear()
            Console.WriteLine("Video Games, did you know that there are roughly about 1.8 billion video gamers in the world. Which company console timeline would you like to see?   Nintendo        Microsoft       Sony")
            Call win()
            'collects input
            game = Console.ReadLine()
            game = game.ToUpper()
            Select Case game

                Case "MICROSOFT"

                    'creates blank line
                    Console.WriteLine()

                    'outputs to console
                    Console.WriteLine("The Simple History of Microsoft Consoles
                                   2001- Xbox
                                   2005- Xbox 360
                                   2013- Xbox One")
                Case "SONY"

                    'creates blank line
                    Console.WriteLine()

                    'outputs to console
                    Console.WriteLine("The Simple History of Sony Consoles
                                   1995- Playstation
                                   2000- Playstation 2
                                   2005- Playstation Portable
                                   2006- Playstation 3
                                   2012- Playstation Vita
                                   2013- Playstation 4")

                Case "NINTENDO"

                    'creates blank line
                    Console.WriteLine()

                    'outputs to console
                    Console.WriteLine("The Simple History of Nintendo Consoles
                                    1986- Nintendo Entertainment System
                                    1990- Game Boy
                                    1992- Super Nintendo Entertainment System
                                    1997- Nintendo 64
                                    1999- Game Boy Color
                                    2001- Game Boy Advance
                                    2002- Nintendo Gamecube
                                    2003- Game Boy Advance SP
                                    2005- Nintendo DS
                                    2006- Nintendo Wii
                                    2011- Nintendo 3DS
                                    2012- Wii U
                                    2016- Nintendo Switch")
                Case Else
                    Console.WriteLine("Invalid Input, Please Try Again")
                    Call GAMES()
            End Select

            'asks if they want to continue
            Console.WriteLine("Would You Like To Continue?")
            yesno = Console.ReadLine()
            yesno = yesno.ToUpper()
            If yesno = "Y" Then
                Call GAMES()
            ElseIf yesno = "N" Then
                'Goes back to Main 
                Call Module1.Main()
            End If
        End If
        Console.ReadLine()
        Call Main()


    End Sub
    Private Sub win()
        Console.Write(Module1.user & ":\")
    End Sub
End Module
