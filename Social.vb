Imports System.Data.SqlClient
Imports System.IO


Public Class Social

    Private Sub txtMessage_TextChanged(sender As Object, e As EventArgs) Handles txtMessage.TextChanged

    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Call SocialDB()
    End Sub

    Private Sub SocialDB()
        Dim userto As String
        Dim userfrom As String
        Dim message As String
        Dim time As DateTime = DateTime.Now.ToUniversalTime

        userto = txtUser.Text.ToLower()
        userfrom = lblUser.Text.ToLower()
        message = txtMessage.Text

        'build sql connection and connection string
        Dim dbcon1 As New SqlConnection()
        Dim dbcon2 As New SqlConnection()
        Dim connexionstring As String = "Server=tcp:73.227.61.187,1433;Database=AidaSocial;User Id=AIDASocialLogin;Password=Social12"
        Dim connexionstring2 As String = "Server=tcp:73.227.61.187,1433;Database=User Database;User Id=NormLogin1;Password=Connection12"
        dbcon1.ConnectionString = connexionstring2
        dbcon2.ConnectionString = connexionstring
        Dim usertoparm As New SqlParameter
        usertoparm.ParameterName = "@userto"
        usertoparm.Value = userto
        Dim messageparm As New SqlParameter
        messageparm.ParameterName = "@message"
        messageparm.Value = message

        Dim userform As New SqlParameter
        userform.ParameterName = "@userfrom"
        userform.Value = userfrom
        Dim timeparm As New SqlParameter
        timeparm.ParameterName = "@time"
        timeparm.Value = time
        timeparm.DbType = DbType.DateTime

        Try
            'open social connection
            dbcon1.Open()

            Dim command1 As String = "SELECT * FROM User_Production_Table WHERE Username = @userto"
            Dim command3 As String = "SELECT * From User_Production_Table WHERE Online = 'T'"
            Dim cmd1 As New SqlCommand(command1)
            cmd1.Parameters.Add(usertoparm)
            cmd1.Connection = dbcon1
            Dim reader As SqlDataReader
            reader = cmd1.ExecuteReader()

            If reader.Read() Then
                reader.Dispose()
                cmd1.Parameters.Clear()
                Dim cmd3 As New SqlCommand(command3)
                cmd1.Parameters.Add(usertoparm)
                cmd1.Connection = dbcon1
                Dim reader2 As SqlDataReader
                reader2 = cmd1.ExecuteReader()

                If reader2.Read() Then
                    dbcon1.Dispose()
                    dbcon2.Open()
                    reader2.Dispose()
                    Dim usertoparm1 As New SqlParameter
                    usertoparm1.ParameterName = "@userto"
                    usertoparm1.Value = userto
                    Dim command2 As String = "INSERT INTO Social_Table([User-TO],[User-From],Message,Time) VALUES(@userto,@userfrom,@message,@time)"
                    Dim cmd2 As New SqlCommand(command2)
                    cmd2.Parameters.Add(userform)
                    cmd2.Parameters.Add(messageparm)
                    cmd2.Parameters.Add(usertoparm1)
                    cmd2.Parameters.Add(timeparm)
                    cmd2.Connection = dbcon2

                    cmd2.ExecuteNonQuery()
                    Messages.Items.Add(Module1.user & "-->" & message)
                    Call ReadMyMessages()




                Else
                    MsgBox("The User that you specified is not currently Online")
                End If


            Else
                'User was not found
                MsgBox("User was not found,Please try again or enter a different valid user")
            End If

        Catch ex As Exception
            Dim writer As New StreamWriter("C:\Aida\AidaSocial.txt")
            If IO.File.Exists("C:\Aida\AidaSocial.txt") = True Then
                writer.Write(ex)
                writer.Dispose()
            Else
                IO.File.CreateText("C:\Aida\AidaSocial.txt")
                writer.Write(ex)
                writer.Dispose()
            End If
        Finally
            dbcon1.Dispose()
        End Try
    End Sub

    Private Sub Social_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblUser.Text = user
        Dim dbcon As New SqlConnection()
        Dim connexionstring As String = "Server=tcp:73.227.61.187,1433;Database=User Database;User Id=NormLogin1;Password=Connection12"
        Dim command1 As String = "UPDATE User_Production_Table SET Online = 'T' WHERE Username = @user"
        Dim userparm As New SqlParameter
        userparm.ParameterName = "@user"
        userparm.Value = txtUser.Text
        dbcon.ConnectionString = connexionstring
        Try
            dbcon.Open()

            Dim cmd1 As New SqlCommand(command1)
            cmd1.Parameters.Add(userparm)
            cmd1.Connection = dbcon
            cmd1.ExecuteNonQuery()
        Catch ex As Exception
            Dim writer As New StreamWriter("C:\Aida\AidaSocial.txt")
            If IO.File.Exists("C:\Aida\AidaSocial.txt") = True Then
                writer.Write(ex)
                writer.Dispose()
            Else
                IO.File.CreateText("C:\Aida\AidaSocial.txt")
                writer.Write(ex)
                writer.Dispose()
            End If

        Finally

            dbcon.Dispose()

        End Try
    End Sub

    Private Sub ReadMyMessages()

        'Allows reader to read his/her messages
        Dim dbcon As New SqlConnection()
        Dim connexionstring As String = "Server=tcp:73.227.61.187,1433;Database=AidaSocial;User Id=AIDASocialLogin;Password=Social12"
        Dim command1 As String = "SELECT * FROM Social_Table WHERE [User-TO] = @user"
        Dim userparm As New SqlParameter
        userparm.ParameterName = "@user"
        userparm.Value = lblUser.Text
        dbcon.ConnectionString = connexionstring
        Try

            dbcon.Open()

            Dim cmd1 As New SqlCommand(command1)
            cmd1.Connection = dbcon
            cmd1.Parameters.Add(userparm)
            Dim reader As SqlDataReader
            reader = cmd1.ExecuteReader()

            Do Until reader.Read() = False
                Dim read As Integer
                Dim read2 As Integer

                read2 = reader.GetOrdinal("User-From")
                read = reader.GetOrdinal("Message")
                Dim stringread As String = reader.GetString(read2) & "-->" & reader.GetString(read)
                reader.Close()
                cmd1.Parameters.Clear()
                Messages.Items.Add(stringread)
                Dim cmd3 As New SqlCommand()
                cmd3.Parameters.Add(userparm)
                cmd3.Connection = dbcon
                cmd3.CommandText = "DELETE FROM Social_Table WHERE [User-TO] = @user"
                cmd3.ExecuteNonQuery()
                Call ReadMyMessages()

            Loop

        Catch ex As Exception
            Dim writer As New StreamWriter("C:\Aida\AidaSocial.txt")
            If IO.File.Exists("C:\Aida\AidaSocial.txt") = True Then
                writer.Write(ex)
                writer.Dispose()
            Else
                IO.File.CreateText("C:\Aida\AidaSocial.txt")
                writer.Write(ex)
                writer.Dispose()
            End If

        Finally

            dbcon.Dispose()

        End Try



    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Social.ActiveForm.Close()
    End Sub

    Private Sub btnCheck_Click(sender As Object, e As EventArgs) Handles btnCheck.Click
        'check status of user 
        Dim dbcon As New SqlConnection()
        Dim connexionstring As String = "Server=tcp:73.227.61.187,1433;Database=User Database;User Id=NormLogin1;Password=Connection12"
        Dim command1 As String = "SELECT * FROM User_Production_Table WHERE Username = @user AND Online = 'T'"
        Dim userparm As New SqlParameter
        userparm.ParameterName = "@user"
        userparm.Value = txtUser.Text
        dbcon.ConnectionString = connexionstring
        Try
            dbcon.Open()

            Dim cmd1 As New SqlCommand(command1)
            cmd1.Parameters.Add(userparm)
            cmd1.Connection = dbcon
            Dim reader As SqlDataReader
            reader = cmd1.ExecuteReader()

            If reader.Read() Then
                MsgBox("The User Is Currently Online")
            End If
        Catch ex As Exception
            Dim writer As New StreamWriter("C:\Aida\AidaSocial.txt")
            If IO.File.Exists("C:\Aida\AidaSocial.txt") = True Then
                writer.Write(ex)
                writer.Dispose()
            Else
                IO.File.CreateText("C:\Aida\AidaSocial.txt")
                writer.Write(ex)
                writer.Dispose()
            End If

        Finally

            dbcon.Dispose()

        End Try

    End Sub

    Private Sub btnRead_Click(sender As Object, e As EventArgs) Handles btnRead.Click
        Call ReadMyMessages()
    End Sub
End Class