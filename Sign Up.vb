Imports System.Data.SqlClient
Imports System.IO
Imports System.Windows.Forms

Public Class SignUp
    Private Sub SignUp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim connectionstring As String = ""
        txtPassword.Text = String.Empty
        txtUsername.Text = String.Empty
        cboGender.Items.Add("Male")
        cboGender.Items.Add("Female")
        lblStatus.Text = "Ready"

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click

        Call Login()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub txtPassword_TextChanged(sender As Object, e As EventArgs) Handles txtPassword.TextChanged, txtUsername.TextChanged
        chkTerms.Visible = True
        lblStatus.Text = "Ready"
    End Sub
    Private Sub Login()
        Dim User As String = ""
        Dim pass As String = ""
        Dim ip As String = GetIP()
        Dim machine As String = Machineid()
        Dim machine1 As Integer
        Integer.TryParse(machine, machine1)

        Dim connextionstring As String = "server=73.227.61.187,1433;Database=User Database;User Id=NormSignUp;Password=Signup12;"
        Dim insertcom As String = "INSERT INTO User_Production_Table(Username,Password,Email,Phone,Gender,Verified,Date_Of_Creation,IP_Address,Aida_Version,Machine_ID) VALUES (@user,@pass,@Email,@Phone,@gender,'F',@date,@IP,@AIDA,@ID)"
        Dim checkdata As String = "SELECT * FROM User_Production_Table WHERE Username = @user1 AND Password = @pass1"
        Dim userparm As New SqlParameter("@user", SqlDbType.NVarChar, 50)
        userparm.Direction = ParameterDirection.Input
        userparm.Value = txtUsername.Text.ToLower
        Dim passparm As New SqlParameter("@pass", SqlDbType.NVarChar, 50)
        passparm.Direction = ParameterDirection.Input
        passparm.Value = txtPassword.Text

        Dim userparm1 As New SqlParameter("@user1", SqlDbType.NVarChar, 50)
        userparm1.Direction = ParameterDirection.Input
        userparm1.Value = txtUsername.Text.ToLower
        Dim passparm1 As New SqlParameter("@pass1", SqlDbType.NVarChar, 50)
        passparm1.Direction = ParameterDirection.Input
        passparm1.Value = txtPassword.Text

        Dim Emailparm As New SqlParameter("@Email", SqlDbType.NVarChar, 100)
        Emailparm.Direction = ParameterDirection.Input
        Emailparm.Value = txtEmail.Text.ToLower
        Dim Phoneparm As New SqlParameter("@Phone", SqlDbType.NVarChar, 10)
        Phoneparm.Direction = ParameterDirection.Input
        Phoneparm.Value = txtPhone.Text
        Dim Genderparm As New SqlParameter("@Gender", SqlDbType.NVarChar, 10)
        Genderparm.Direction = ParameterDirection.Input
        Genderparm.Value = cboGender.Text.ToLower
        Dim Dateparm As New SqlParameter("@date", SqlDbType.Date)
        Dateparm.Direction = ParameterDirection.Input
        Dateparm.Value = Date.Now.Date
        Dim IPparm As New SqlParameter("@IP", SqlDbType.NVarChar, 50)
        IPparm.Direction = ParameterDirection.Input
        IPparm.Value = ip
        Dim AIDAparm As New SqlParameter("@AIDA", SqlDbType.NVarChar, 20)
        AIDAparm.Direction = ParameterDirection.Input
        AIDAparm.Value = "Version 2.0.0"
        Dim IDparm As New SqlParameter("@ID", SqlDbType.NVarChar, 50)
        IDparm.Direction = ParameterDirection.Input
        IDparm.Value = machine1


        'Connect to database
        If txtPassword.Text = txtConfirm.Text Then
            User = txtUsername.Text
            pass = txtPassword.Text
            Dim dbcon As New SqlConnection(connextionstring)
            If pass.Length >= 8 And chkTerms.Checked Then
                Try

                    dbcon.Open()
                    Dim cmd1 As New SqlCommand(checkdata, dbcon)

                    cmd1.Parameters.Add(userparm1)
                    cmd1.Parameters.Add(passparm1)
                    Dim reader As SqlDataReader
                    reader = cmd1.ExecuteReader()
                    If reader.Read() = True Then
                        reader.Close()
                        MessageBox.Show("This Login Is Already Taken,Please Try Another", "Sign Up")

                    Else
                        reader.Close()
                        Dim cmd As New SqlCommand(insertcom, dbcon)


                        cmd.Parameters.Add(userparm)
                        cmd.Parameters.Add(passparm)
                        cmd.Parameters.Add(Emailparm)
                        cmd.Parameters.Add(Phoneparm)
                        cmd.Parameters.Add(Genderparm)
                        cmd.Parameters.Add(Dateparm)
                        cmd.Parameters.Add(IPparm)
                        cmd.Parameters.Add(AIDAparm)
                        cmd.Parameters.Add(IDparm)

                        cmd.ExecuteNonQuery()

                        SignUp.ActiveForm.Close()

                    End If
                Catch ex As Exception
                    Dim writer As New StreamWriter("C:\Aida\AidaSignup.txt")
                    If IO.File.Exists("C:\Aida\AidaSignup.txt") = True Then
                        writer.Write(ex)
                        writer.Dispose()
                    Else
                        IO.File.CreateText("C:\Aida\AidaSignup.txt")
                        writer.Write(ex)
                        writer.Dispose()
                    End If
                Finally
                    dbcon.Close()
                End Try
            Else
                If chkTerms.Checked = False Then
                    lblStatus.Text = "Please Read and check the Terms Of Service/EULA Checkbox"
                Else
                    lblStatus.Text = "Password must be at least 8 characters long,Please Try Again"
                End If

            End If

        Else
            MessageBox.Show("Your Passwords Do Not Match,Please Try Again", "Signup")
            txtConfirm.Text = String.Empty

        End If

    End Sub
    Private Function GetIP() As String
        Dim result As String = String.Empty
        Try

        Catch ex As Exception
            Dim writer As New StreamWriter("C:\Aida\AidaSignup.txt")
            If IO.File.Exists("C:\Aida\AidaSignup.txt") = True Then
                writer.Write(ex)
                writer.Dispose()
            Else
                IO.File.CreateText("C:\Aida\AidaSignup.txt")
                writer.Write(ex)
                writer.Dispose()
            End If
        Finally

        End Try



        Return result
    End Function
    Private Function Machineid() As String
        Dim random As New Random
        Dim machineids As Integer
        Dim writestring As String = "########################################THIS IS A AIDA PROGRAM FILE!! MODIFICATION MAY CAUSE INSTABILITY WITHIN AIDA!! DO NOT MODIFY!!########################################"
        machineids = random.Next(11111, 99999)

        'save Machine ID in Text File For AutoLogin
        Dim writer As New StreamWriter("C:\Aida\MachineIDAutoLogin.txt")
        If IO.File.Exists("C:\Aida\MachineIDAutoLogin.txt") Then
            writer.Write(writestring & ControlChars.NewLine & "Machine IDs:" & machineids.ToString())
            writer.Dispose()
        Else
            IO.File.CreateText("C:\Aida\MachineIDAutoLogin.txt")
            writer.Write(writestring & vbNewLine & "Machine IDs:" & vbNewLine & machineids.ToString())
            writer.Dispose()
        End If
        Return machineids.ToString
    End Function
End Class