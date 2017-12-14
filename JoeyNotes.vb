Imports System.Data.SqlClient
Imports System.IO

Module JoeyNotes
    Public Sub Joeys_notes()
        Console.Clear()
        Dim date1 As String
        Console.WriteLine("Search the Database for Joeys Notes by date (m/dd/yy) or " & vbNewLine & " Type (Dates) For The Date Of Each Note in the Database ")
        Console.Write(Module1.user & ":\")
        date1 = Console.ReadLine()
        date1 = date1.ToUpper()
        If date1 = "EXIT" Then
            Call Module1.Main()

        ElseIf date1 = "DATES" Then
            Call JoeyNoteSelect()
        Else
            If date1.Length >= 6 Then
                Console.WriteLine("Searching Now....")
                Call TheJoeArchive(date1)
            Else
                Console.WriteLine("Please Search using m/dd/yy format")
                Console.ReadLine()
                Console.Clear()
                Joeys_notes()
            End If

        End If

    End Sub

    Private Sub TheJoeArchive(date15 As String)
        Dim dbcon As New SqlConnection
        Dim connexionstring As String = "Server=tcp:73.227.61.187,1433;Database=The Joe Archive;User Id=NormLogin1;Password=Connection12;"

        dbcon.ConnectionString() = connexionstring
        Dim date12 As New SqlParameter
        date12.ParameterName = "@date"
        date12.Value = date15
        date12.Direction = ParameterDirection.Input
        Dim command As String = "SELECT * FROM Joey_Notes WHERE Date = @date"

        Try

            dbcon.Open()
            Dim cmd1 As New SqlCommand(command, dbcon)
            cmd1.Parameters.Add(date12)
            cmd1.Connection = dbcon
            Dim reader As SqlDataReader

            reader = cmd1.ExecuteReader()

            If reader.Read() Then
                Dim read As Int32 = reader.GetOrdinal("Message")
                Console.WriteLine(reader.GetString(read))
                Console.ReadLine()
                reader.Close()
                Console.Clear()
                Call Joeys_notes()
            Else
                MsgBox("Invalid Date,Please Try Again")
                reader.Close()
                Console.Clear()
                Call Joeys_notes()
            End If
            Console.Clear()
            dbcon.Dispose()

        Catch ex As Exception
            MsgBox("Sorry Joeys Notes are not available at this time,Please Try Again Later")
            Dim writer As New StreamWriter("C:\Aida\AidaJoey.txt")
            If IO.File.Exists("C:\Aida\AidaJoey.txt") = True Then
                writer.Write(ex)
                writer.Dispose()
            Else
                IO.File.CreateText("C:\Aida\AidaJoey.txt")
                writer.Write(ex)
                writer.Dispose()
            End If
            System.Threading.Thread.Sleep(1000)
            Call Main()
        Finally
            dbcon.Dispose()
        End Try

    End Sub

    Private Sub JoeyNoteSelect()
        Dim dbcon As New SqlConnection
        Dim connexionstring As String = "Server=tcp:73.227.61.187,1433;Database=The Joe Archive;User Id=NormLogin1;Password=Connection12;"

        dbcon.ConnectionString() = connexionstring

        Dim command As String = "SELECT * FROM Joey_Notes"

        Try

            dbcon.Open()
            Dim cmd1 As New SqlCommand(command, dbcon)

            cmd1.Connection = dbcon
            Dim reader As SqlDataReader

            reader = cmd1.ExecuteReader()

            While reader.Read()
                Dim read As Int32 = reader.GetOrdinal("Date")

                Console.WriteLine(reader.GetString(read))

            End While
            Console.ReadLine()
            dbcon.Dispose()
            Call Joeys_notes()
        Catch ex As Exception
            MsgBox("Sorry Joeys Notes are not available at this time,Please Try Again Later")
            Dim writer As New StreamWriter("C:\Aida\AidaJoey.txt")
            If IO.File.Exists("C:\Aida\AidaJoey.txt") = True Then
                writer.Write(ex)
                writer.Dispose()
            Else
                IO.File.CreateText("C:\Aida\AidaJoey.txt")
                writer.Write(ex)
                writer.Dispose()
            End If
            System.Threading.Thread.Sleep(1000)
            Call Main()
        Finally
            dbcon.Dispose()
        End Try
    End Sub
End Module
