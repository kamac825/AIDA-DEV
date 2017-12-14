Imports System.Windows.Forms
Imports System.Threading
Imports System.Data.SqlClient
Imports System.IO
Public Class Login

    ' TODO: Insert code to perform custom authentication using the provided username and password 
    ' (See https://go.microsoft.com/fwlink/?LinkId=35339).  
    ' The custom principal can then be attached to the current thread's principal as follows: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' where CustomPrincipal is the IPrincipal implementation used to perform authentication. 
    ' Subsequently, My.User will return identity information encapsulated in the CustomPrincipal object
    ' such as the username, display name, etc.

    Public Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click




        Call Okbutton()

    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()

    End Sub

    Function LOGIN(Username As String, Password As String) As String
        If Username = "Guest" Then

            MessageBox.Show("You can login as 'Guest' but your features are limited." & ControlChars.NewLine & "You can learn more about this restriction in the help page or at http://www.Aidaapp.tk", "Guest", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Me.Close()
            Call Main()

        Else
            'Checks autologin txt file
            Dim read As String = "0"
            Dim reader1 As New StreamReader("C:\Aida\MachineIDAutoLogin.txt")
            If IO.File.Exists("C:\Aida\MachineIDAutoLogin.txt") Then
                read = reader1.Read.ToString()

            End If


            Dim conextion As New SqlConnection
            Dim conextionstring As String = "Server=tcp:73.227.61.187,1433;Database=User Database;User Id=NormLogin1;Password=Connection12;"
            conextion.ConnectionString = conextionstring
            Dim comand As String = "SELECT * FROM User_Production_Table WHERE Username = @user"
            Dim userparm1 As New SqlParameter()
            userparm1.ParameterName = "@user"
            userparm1.Value = Username.ToLower
            userparm1.Direction = ParameterDirection.InputOutput
            Dim read1 As New SqlParameter()
            read1.ParameterName = "@ID"
            read1.Value = read
            conextion.Open()
            Dim cmd5 As New SqlCommand(comand)
            cmd5.Parameters.Add(userparm1)
            cmd5.Parameters.Add(read1)
            cmd5.Connection = conextion
            Dim reader5 As SqlDataReader
            reader5 = cmd5.ExecuteReader()

            If reader5.Read() Then
                Dim ID As Integer
                Dim ID2 As String
                ID = reader5.GetOrdinal("Machine_ID")
                ID2 = reader5.GetInt64(ID).ToString
                If read = ID2 Then
                    Module1.signedon = True
                    Module1.gueston1 = False
                    Module1.user = Username
                    Me.Close()
                Else

                    Dim connextionstring As String = "Server=tcp:73.227.61.187,1433;Database=User Database;User Id=NormLogin1;Password=Connection12;"
                    Using dbcon As New SqlConnection() With {
                .ConnectionString = connextionstring
                }
                        Dim userparm As New SqlParameter()
                        userparm.ParameterName = "@user"
                        userparm.Value = Username.ToLower
                        userparm.Direction = ParameterDirection.InputOutput
                        Dim passparm As New SqlParameter()
                        passparm.ParameterName = "@pass"
                        passparm.Value = Password
                        passparm.Direction = ParameterDirection.InputOutput
                        Try
                            dbcon.Open()
                            Dim cmd As New SqlCommand(connextionstring)
                            cmd.Parameters.Add(userparm)
                            cmd.Parameters.Add(passparm)
                            cmd.Connection = dbcon
                            cmd.CommandText = "SELECT * FROM User_Production_Table WHERE Username = @user AND Password = @pass"
                            Dim reader As SqlDataReader
                            reader = cmd.ExecuteReader()

                            If reader.Read() Then

                                Module1.signedon = True
                                Module1.gueston1 = False
                                Module1.user = Username
                                Thread.Sleep(1000)
                                dbcon.Dispose()
                                Me.Close()
                            Else

                                MessageBox.Show("Username and Password are incorrect, Please Try Again or" & ControlChars.NewLine & "Sign Up for a new account at the Login Page or Sign Up at Aidaapp.tk", "Login")
                            End If


                        Catch ex As Exception
                            Dim writer As New StreamWriter("C:\Aida\AidaLogin.txt")
                            If IO.File.Exists("C:\Aida\AidaLogin.txt") = True Then
                                writer.Write(ex)
                                writer.Dispose()
                            Else
                                IO.File.CreateText("C:\Aida\AidaLogin.txt")
                                writer.Write(ex)
                                writer.Dispose()
                            End If
                        Finally
                            dbcon.Dispose()
                            Main()

                        End Try

                    End Using

                End If
            End If


        End If

    End Function

    Private Sub btnGuest_Click(sender As Object, e As EventArgs) Handles btnGuest.Click
        UsernameTextBox.Text = "Guest"
        Module1.gueston1 = True
        Module1.signedon = False
        Module1.user = "Guest"
        Call LOGIN("Guest", "")
    End Sub

    Private Sub btnSignUP_Click(sender As Object, e As EventArgs) Handles btnSignUP.Click
        Dim yesno As DialogResult



        'ask are you sure
        yesno = MessageBox.Show("Are You Sure", "Sign Up", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)


        If yesno = DialogResult.Yes Then

            Call Signup()


        ElseIf yesno = DialogResult.No Then
            Call Main()



        End If



    End Sub
    Public Sub Signup()
        Dim signupthread As New System.Threading.Thread(AddressOf SIGNUPSTART)
        signupthread.Start()
    End Sub

    Private Sub login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UsernameTextBox.Text = String.Empty
        PasswordTextBox.Text = String.Empty
    End Sub
    Private Sub SIGNUPSTART()
        Application.EnableVisualStyles()
        Application.Run(New SignUp)
    End Sub
    Private Sub Okbutton()
        Dim User As String = ""
        Dim Pass As String = ""
        Dim result As String = ""

        User = UsernameTextBox.Text
        Pass = PasswordTextBox.Text

        result = LOGIN(User, Pass)

    End Sub
End Class
