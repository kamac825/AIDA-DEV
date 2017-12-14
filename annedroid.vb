Option Strict Off
Module annedroid
    Public answer2 As String
    Public name As String
    Public answerYeah As String
    Public answer As String
    Public Sub timer(ByVal answer As String)
        Console.WriteLine("How long would you like an alarm for?")
        Console.WriteLine("Minutes or seconds?")
        Dim answer3 As String = Console.ReadLine


        Dim SAPI = CreateObject("SAPI.spvoice")
        SAPI.Volume = 100

        If answer3 = "minutes" Then
            Console.WriteLine("How many minutes?")
            Dim answer4 As String = Console.ReadLine()
            Dim timeraaaa As Integer = answer4
            timeraaaa = timeraaaa * 60000

            Threading.Thread.Sleep(timeraaaa)

            SAPI.Speak("Ding! Timer's done!")

        ElseIf answer3 = "seconds" Then
            Console.WriteLine("How many seconds?")
            Dim answer4 As String = Console.ReadLine()

            Dim timeraaaa As Integer = answer4
            timeraaaa = timeraaaa * 1000
            Threading.Thread.Sleep(timeraaaa)

            SAPI.Speak("Ding! Timer's done!")
            Threading.Thread.Sleep(250)
            Call Main()
        End If
    End Sub
    Public Sub diceRoll()
        'dice
        Dim randGen As New Random
        '    'capture value of die amount
        Console.WriteLine("How many dice would you like to roll?")
        Dim dieAmount As Integer = Console.ReadLine()

        'capture amount of sides
        Console.WriteLine("How many sides?")
        Dim dieSides As Integer = Console.ReadLine()

        'Dim dieTotalSides As Integer
        'dieTotalSides = dieSides * dieAmount

        Dim dieAns As Integer
        Dim ans As Integer

        Do Until ans = dieAmount
            dieAns = randGen.Next(1, (dieSides + 1))
            Console.WriteLine("You rolled a " & dieAns & "!")
            ans += 1
        Loop
        Console.ReadLine()
        System.Threading.Thread.Sleep(1000)
        Call Main()
    End Sub
    Public Sub eightBall()
        '8 ball
        Console.WriteLine("Ask anything!")
        Console.ReadLine()
        'ok this is funny to me because your
        'input doesn't even get put into a variable.
        'it just randomly picks a fortune

        Dim randGen As New Random

        Dim message As String
        message = randGen.Next(1, 21)

        Select Case message
            Case 1
                Console.WriteLine("It is certain.")
            Case 2
                Console.WriteLine("It is decidedly so.")
            Case 3
                Console.WriteLine("Without a doubt.")
            Case 4
                Console.WriteLine("Yes, definitely.")
            Case 5
                Console.WriteLine("You may rely on it.")
            Case 6
                Console.WriteLine("As I see it, yes.")
            Case 7
                Console.WriteLine("Most likely.")
            Case 8
                Console.WriteLine("Outlook good.")
            Case 9
                Console.WriteLine("Yes.")
            Case 10
                Console.WriteLine("Signs point to yes.")
            Case 11
                Console.WriteLine("Reply hazy. Try again.")
            Case 12
                Console.WriteLine("Ask again later.")
            Case 13
                Console.WriteLine("Better not tell you now.")
            Case 14
                Console.WriteLine("Cannot predict now.")
            Case 15
                Console.WriteLine("Concentrate, and try again.")
            Case 16
                Console.WriteLine("Don't count on it.")
            Case 17
                Console.WriteLine("My reply is no.")
            Case 18
                Console.WriteLine("My sources say no.")
            Case 19
                Console.WriteLine("Outlook not so good.")
            Case 20
                Console.WriteLine("Very doubtful.")
        End Select
        Console.ReadLine()
    End Sub
    Public Sub randNum()
        'picks a random number
        Dim randNum As New Random
        Console.WriteLine("Pick a limit to your random number!")
        Dim randTop As String = Console.ReadLine()
        Dim newNum As Integer


        newNum = randNum.Next(1, (randTop + 1))

        Console.WriteLine("Your random number is " & newNum & ".")
        Threading.Thread.Sleep(1000)
        Call Main()
    End Sub
    Public Sub GetIPAddress()
        'gets ip address of local user
        Dim strHostName As String

        Dim strIPAddress As String

        Dim strSubnetMask As String

        strHostName = System.Net.Dns.GetHostName()

        strIPAddress = Net.Dns.GetHostByName(strHostName).AddressList(0).ToString()

        strSubnetMask = Net.Dns.GetHostEntry(strHostName).AddressList(0).ToString()

        Console.WriteLine("Host Name: " & strHostName & vbNewLine & "; IPv4 IP Address: " & strIPAddress & "; IPv6 Link Local Address: " & vbNewLine & strSubnetMask)
        Console.ReadLine()
        Call Main()
    End Sub
    Public Sub searchInt()
        Dim answer2 As String
        Dim webAddress As String
        'SEARCHES INTERNET
        Console.WriteLine("Google, Youtube, or Amazon?")
        Dim answer As String = Console.ReadLine.ToUpper
        If answer = "GOOGLE" Then
            Console.WriteLine("What do you want to search?")
            answer2 = Console.ReadLine
            Console.WriteLine("Loading...")
            Threading.Thread.Sleep(2000)
            webAddress = "https://www.google.com/search?source=hp&ei=QYQlWpjkLuSR_Qblkr6QCw&q=" & answer2 & "&oq=" & answer2 & "&gs_l=psy-ab.3..0l2j0i10k1j0l4j0i10k1j0l2.12614.49957.0.50302.15.14.0.0.0.0.169.1587.0j11.13.0..2..0...1.1.64.psy-ab..2.11.1586.0..46j0i131k1j0i131i46k1j46i131k1j0i46k1.121.le6qKIV_314"

            Process.Start(webAddress)
            Call Main()
        ElseIf answer = "YOUTUBE" Then
            Console.WriteLine("What video?")
            answer2 = Console.ReadLine
            Console.WriteLine("We don't want to be presumptuous, so we'll open up the search page for you,
just so you can pick the video yourself :)")
            Console.WriteLine("Loading...")
            Threading.Thread.Sleep(2000)
            webAddress = "https://www.youtube.com/results?search_query=" & answer2
            Process.Start(webAddress)
            Call Main()
        ElseIf answer = "AMAZON" Then
            Console.WriteLine("What would you like to shop for?")
            answer2 = Console.ReadLine
            Console.WriteLine("Loading...")
            Threading.Thread.Sleep(2000)
            webAddress = "https://www.amazon.com/s/ref=nb_sb_noss_1?url=search-alias%3Daps&field-keywords=" & answer2
            Process.Start(webAddress)
            Call Main()
        Else
            Console.WriteLine("Welcome.")
            webAddress = "F:\try this.html"
            Threading.Thread.Sleep(900)
            Process.Start(webAddress)
            Call Main()
        End If

    End Sub
End Module
