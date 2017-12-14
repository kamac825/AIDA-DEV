'WRITTEN BY CHRIS RAPOSO / EDITED BY KAMERON MCELROY AND NATE CARLSON  
Option Strict Off
Option Explicit Off
Option Infer Off
Module Module1
    Private input As String

    Sub Main()

        'Begining Statements

        Console.WriteLine("A.I.D.A, the Artifical Intelligence Development Application.")
        Call std_input()
        ' Calls Methods Depending on Statements
        Select Case input
            Case "FUN"
                Call FUNCommand()
            Case "Trivia"
                Call TRIVIACommand()
            Case "OSINFO"
                Call OSINFORMATION()
        End Select







    End Sub

    Private Sub std_input()

        Console.Write("win:\")
        input = Console.ReadLine()
        input = input.ToUpper
    End Sub
    Private Sub FUNCommand()
        If input = "FUN" Then
            Dim FunHELP As String = ""

            'Displays the Help Page
            Console.WriteLine("Hello, I am A.I.D.A Fun Help Page, and I would like to talk with you. I have been programmed with these options. Choose One!(More to Come LATER)
                  F for Food       P for Politics      G for Video Games        T for Trivia  ")
            Food = Console.ReadLine()
            Food = Food.ToUpper()

            'Choose the Selections
            Select Case Food
                Case "F"
                    Call TREATS()
                Case "P"
                    Call POLITICS()
                Case "G"
                    Call GAMES()


            End Select

        End If
    End Sub
    Private Sub TRIVIACommand()
        Dim trivia As String = ""
        'To Handle Trivia Command
        Console.WriteLine("Knowledge is power said Francis Bacon, and right now we are going to test that. Pick a random number from 1-9.")
        trivia = Console.ReadLine()
        Select Case trivia
            Case "1"
                Do While True
                    Console.WriteLine("The beaver is the national emblem if which country?")
                    Console.WriteLine()
                    trivia = Console.ReadLine()

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
                    If trivia = "ETHIOPIA" Then
                        Console.WriteLine("Correct!")
                        Exit Do
                    Else
                        Console.WriteLine("Incorrect, sorry!")
                    End If
                Loop
        End Select

        Call Main()
    End Sub
    Private Sub OSINFORMATION()

        Dim os As String = ""
        Console.WriteLine("List of Windows Operating Systems using the NT Kernel")
        Console.WriteLine()
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


        Call Main()
    End Sub

    Private Sub TREATS()

        Dim food As String
        'Collects input
        Console.WriteLine("Food is delicious, says my human creator, but I can't eat food. Duh I'm a computer! What would be your favorite food?")
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

        Call Main()
    End Sub
    Private Sub POLITICS()
        'declares local variable
        Dim trump As String = ""

        'collects input and converts to uppercase
        Console.WriteLine("Ahhhhhhhh, Politics. It can get pretty bad if you really get into it. But, my creator has programmed the two major political parties of the Unites States. Which would you like to here?     Republican or Democrat?")
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


        End If

        Call Main()
    End Sub

    Private Sub GAMES()


        'declares the variables
        Dim game As String = ""
        Console.WriteLine("Video Games, did you know that there are roughly about 1.8 billion video gamers in the world. Which company console timeline would you like to see?   Nintendo        Microsoft       Sony")

        Select Case game
            Case "MICROSOFT"

                'creates blank line
                Console.WriteLine()

                'outputs to console
                Console.WriteLine("The Simple History of Microsoft Consoles
                                   2001- Xbox
                                   2005- Xbox 360
                                   2013- Xbox One")
            Case "PLAYSTATION"

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
        End Select


        Call Main()
    End Sub


End Module
