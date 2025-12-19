Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.Text
Imports Microsoft.Data.SqlClient

Public Class Form5

    Private Function HashPassword(pw As String) As String
        Using sha As SHA256 = SHA256.Create()
            Dim bytes = Encoding.UTF8.GetBytes(pw)
            Dim hash = sha.ComputeHash(bytes)
            Return BitConverter.ToString(hash).Replace("-", "").ToLower()
        End Using
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim namaLengkap = TextBox1.Text.Trim()
        Dim newPass = TextBox2.Text
        Dim confirmPass = TextBox3.Text
        If namaLengkap = "" Or newPass = "" Or confirmPass = "" Then
            MessageBox.Show("Semua field harus diisi!")
            Return
        End If
        If newPass <> confirmPass Then
            MessageBox.Show("Password baru dan konfirmasi tidak sama!")
            Return
        End If
        If newPass.Length < 8 Then
            MessageBox.Show("Password minimal 8 karakter!")
            Return
        End If
        Try
            Using conn As SqlConnection = GetConnection()
                conn.Open()
                Dim oldPassHash As String = ""
                Dim selectQuery = "SELECT password FROM users WHERE nama_depan=@nama"
                Using selectCmd As New SqlCommand(selectQuery, conn)
                    selectCmd.Parameters.AddWithValue("@nama", namaLengkap)
                    Dim result = selectCmd.ExecuteScalar()
                    If result IsNot Nothing Then
                        oldPassHash = result.ToString()
                    Else
                        MessageBox.Show("Nama lengkap tidak ditemukan!")
                        Return
                    End If
                End Using
                Dim newPassHash = HashPassword(newPass)
                If newPassHash = oldPassHash Then
                    MessageBox.Show("Password baru tidak boleh sama dengan password lama!")
                    Return
                End If
                Dim updateQuery = "UPDATE users SET password=@pass WHERE nama_depan=@nama"
                Using updateCmd As New SqlCommand(updateQuery, conn)
                    updateCmd.Parameters.AddWithValue("@pass", newPassHash)
                    updateCmd.Parameters.AddWithValue("@nama", namaLengkap)
                    updateCmd.ExecuteNonQuery()
                End Using
                MessageBox.Show("Password berhasil direset!")
                Me.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub
    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        Label8.Text = GetPasswordStrength(TextBox2.Text)
    End Sub
    Private Function GetPasswordStrength(pw As String) As String
        If String.IsNullOrEmpty(pw) Then
            Label8.ForeColor = Color.Gray
            Return "Masukkan password baru"
        End If
        Dim score As Integer = 0
        If pw.Length >= 8 Then score += 1
        If pw.Any(Function(c) Char.IsLower(c)) Then score += 1
        If pw.Any(Function(c) Char.IsUpper(c)) Then score += 1
        If pw.Any(Function(c) Char.IsDigit(c)) Then score += 1
        If pw.Any(Function(c) Not Char.IsLetterOrDigit(c)) Then score += 1
        Select Case score
            Case 5
                Label8.ForeColor = Color.Green
                Return "Password Kuat"
            Case 3, 4
                Label8.ForeColor = Color.Orange
                Return "Password Sedang"
            Case Else
                Label8.ForeColor = Color.Red
                Return "Password Lemah"
        End Select
    End Function
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
