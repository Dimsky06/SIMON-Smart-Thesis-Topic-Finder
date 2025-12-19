Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.Text
Imports Microsoft.Data.SqlClient

Public Class Form2

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "SIMON - Sign Up"
        Me.Size = New Size(1440, 900)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.BackColor = Color.FromArgb(249, 250, 251)

        'BACKGROUND GRADIENT
        Dim leftBg As New Panel With {
            .Location = New Point(0, 0),
            .Size = New Size(650, 900),
            .BackColor = Color.FromArgb(249, 250, 251)
        }
        Me.Controls.Add(leftBg)
        leftBg.SendToBack()

        ' Decorative blobs
        Dim blob1 As New Panel With {
            .Size = New Size(400, 400),
            .Location = New Point(-100, 50),
            .BackColor = Color.FromArgb(40, 167, 139, 250)
        }
        AddCircleShape(blob1)
        leftBg.Controls.Add(blob1)
        blob1.SendToBack()

        Dim blob2 As New Panel With {
            .Size = New Size(300, 300),
            .Location = New Point(400, 550),
            .BackColor = Color.FromArgb(35, 251, 146, 60)
        }
        AddCircleShape(blob2)
        leftBg.Controls.Add(blob2)
        blob2.SendToBack()

        ' KONTEN KIRI 

        ' Back button
        Dim backLabel As New Label()
        backLabel.Text = "←"
        backLabel.Font = New Font("Segoe UI", 28, FontStyle.Bold)
        backLabel.ForeColor = Color.FromArgb(99, 102, 241)
        backLabel.TextAlign = ContentAlignment.MiddleCenter
        backLabel.Cursor = Cursors.Hand
        backLabel.Location = New Point(40, 35)
        backLabel.Size = New Size(50, 50)
        backLabel.BackColor = Color.Transparent
        leftBg.Controls.Add(backLabel)
        backLabel.BringToFront()
        AddHandler backLabel.Click, AddressOf PictureBox2_Click

        ' Logo PictureBox1
        Me.Controls.Remove(PictureBox1)
        PictureBox1.BackColor = Color.Transparent
        PictureBox1.Location = New Point(175, 220)
        PictureBox1.Size = New Size(300, 300)
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        leftBg.Controls.Add(PictureBox1)
        PictureBox1.BringToFront()

        ' Label title
        Dim titleLabel As New Label()
        titleLabel.Text = "Expert System"
        titleLabel.Font = New Font("Segoe UI", 24, FontStyle.Bold)
        titleLabel.ForeColor = Color.FromArgb(17, 24, 39)
        titleLabel.TextAlign = ContentAlignment.MiddleCenter
        titleLabel.Location = New Point(125, 540)
        titleLabel.Size = New Size(400, 45)
        titleLabel.BackColor = Color.Transparent
        leftBg.Controls.Add(titleLabel)
        titleLabel.BringToFront()

        Dim subtitleLabel As New Label()
        subtitleLabel.Text = "Topik Skripsi"
        subtitleLabel.Font = New Font("Segoe UI", 24, FontStyle.Bold)
        subtitleLabel.ForeColor = Color.FromArgb(99, 102, 241)
        subtitleLabel.TextAlign = ContentAlignment.MiddleCenter
        subtitleLabel.Location = New Point(125, 590)
        subtitleLabel.Size = New Size(400, 45)
        subtitleLabel.BackColor = Color.Transparent
        leftBg.Controls.Add(subtitleLabel)
        subtitleLabel.BringToFront()

        ' PANEL KANAN 

        ' Main Card
        Dim formCard As New Panel With {
            .Location = New Point(720, 60),
            .Size = New Size(650, 780),
            .BackColor = Color.White
        }
        AddRoundedCorners(formCard, 24)
        AddEnhancedShadow(formCard)
        Me.Controls.Add(formCard)

        ' Top accent
        Dim topAccent As New Panel With {
            .Location = New Point(0, 0),
            .Size = New Size(650, 6),
            .BackColor = Color.FromArgb(99, 102, 241)
        }
        formCard.Controls.Add(topAccent)
        topAccent.SendToBack()

        ' Title "Sign Up"
        Dim signupTitle As New Label()
        signupTitle.Text = "Sign Up"
        signupTitle.Font = New Font("Segoe UI", 40, FontStyle.Bold)
        signupTitle.ForeColor = Color.FromArgb(17, 24, 39)
        signupTitle.TextAlign = ContentAlignment.TopCenter
        signupTitle.Location = New Point(75, 40)
        signupTitle.Size = New Size(500, 65)
        signupTitle.BackColor = Color.Transparent
        formCard.Controls.Add(signupTitle)
        signupTitle.BringToFront()

        Dim signupSubtitle As New Label()
        signupSubtitle.Text = "Buat akun baru untuk memulai"
        signupSubtitle.Font = New Font("Segoe UI", 13)
        signupSubtitle.ForeColor = Color.FromArgb(107, 114, 128)
        signupSubtitle.TextAlign = ContentAlignment.TopCenter
        signupSubtitle.Location = New Point(75, 110)
        signupSubtitle.Size = New Size(500, 35)
        signupSubtitle.BackColor = Color.Transparent
        formCard.Controls.Add(signupSubtitle)
        signupSubtitle.BringToFront()

        ' FORM FIELDS 
        Dim baseY As Integer = 180
        Dim leftColX As Integer = 75
        Dim rightColX As Integer = 350
        Dim fieldWidth As Integer = 250

        ' Nama & Password 

        ' Label Nama Lengkap
        Dim lblNama As New Label()
        lblNama.Text = "Nama Lengkap *"
        lblNama.Font = New Font("Segoe UI", 11, FontStyle.Bold)
        lblNama.ForeColor = Color.FromArgb(31, 41, 55)
        lblNama.Location = New Point(leftColX, baseY)
        lblNama.Size = New Size(fieldWidth, 25)
        lblNama.BackColor = Color.Transparent
        formCard.Controls.Add(lblNama)
        lblNama.BringToFront()

        ' TextBox1 - Nama
        Me.Controls.Remove(TextBox1)
        TextBox1.BackColor = Color.FromArgb(249, 250, 251)
        TextBox1.Location = New Point(leftColX, baseY + 30)
        TextBox1.Size = New Size(fieldWidth, 45)
        TextBox1.Font = New Font("Segoe UI", 12)
        TextBox1.BorderStyle = BorderStyle.FixedSingle
        formCard.Controls.Add(TextBox1)
        TextBox1.BringToFront()

        ' Label Password
        Dim lblPassword As New Label()
        lblPassword.Text = "Password *"
        lblPassword.Font = New Font("Segoe UI", 11, FontStyle.Bold)
        lblPassword.ForeColor = Color.FromArgb(31, 41, 55)
        lblPassword.Location = New Point(rightColX, baseY)
        lblPassword.Size = New Size(fieldWidth, 25)
        lblPassword.BackColor = Color.Transparent
        formCard.Controls.Add(lblPassword)
        lblPassword.BringToFront()

        ' TextBox4 - Password
        Me.Controls.Remove(TextBox4)
        TextBox4.BackColor = Color.FromArgb(249, 250, 251)
        TextBox4.Location = New Point(rightColX, baseY + 30)
        TextBox4.Size = New Size(fieldWidth, 45)
        TextBox4.Font = New Font("Segoe UI", 12)
        TextBox4.BorderStyle = BorderStyle.FixedSingle
        TextBox4.PasswordChar = "●"c
        formCard.Controls.Add(TextBox4)
        TextBox4.BringToFront()

        ' Label8 - Password Strength
        Me.Controls.Remove(Label8)
        Label8.BackColor = Color.Transparent
        Label8.Location = New Point(rightColX, baseY + 80)
        Label8.Size = New Size(fieldWidth, 20)
        Label8.Font = New Font("Segoe UI", 9, FontStyle.Italic)
        Label8.Text = "Masukkan password"
        Label8.ForeColor = Color.Gray
        formCard.Controls.Add(Label8)
        Label8.BringToFront()

        ' Jenis Kelamin & Prodi 
        baseY += 130

        ' Label Jenis Kelamin
        Dim lblGender As New Label()
        lblGender.Text = "Jenis Kelamin *"
        lblGender.Font = New Font("Segoe UI", 11, FontStyle.Bold)
        lblGender.ForeColor = Color.FromArgb(31, 41, 55)
        lblGender.Location = New Point(leftColX, baseY)
        lblGender.Size = New Size(fieldWidth, 25)
        lblGender.BackColor = Color.Transparent
        formCard.Controls.Add(lblGender)
        lblGender.BringToFront()

        ' ComboBox2 - Jenis Kelamin
        Me.Controls.Remove(ComboBox2)
        ComboBox2.BackColor = Color.FromArgb(249, 250, 251)
        ComboBox2.Location = New Point(leftColX, baseY + 30)
        ComboBox2.Size = New Size(fieldWidth, 45)
        ComboBox2.Font = New Font("Segoe UI", 12)
        ComboBox2.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBox2.FlatStyle = FlatStyle.Flat
        formCard.Controls.Add(ComboBox2)
        ComboBox2.BringToFront()

        ' Label Prodi
        Dim lblProdi As New Label()
        lblProdi.Text = "Program Studi *"
        lblProdi.Font = New Font("Segoe UI", 11, FontStyle.Bold)
        lblProdi.ForeColor = Color.FromArgb(31, 41, 55)
        lblProdi.Location = New Point(rightColX, baseY)
        lblProdi.Size = New Size(fieldWidth, 25)
        lblProdi.BackColor = Color.Transparent
        formCard.Controls.Add(lblProdi)
        lblProdi.BringToFront()

        ' ComboBox1 - Prodi
        Me.Controls.Remove(ComboBox1)
        ComboBox1.BackColor = Color.FromArgb(249, 250, 251)
        ComboBox1.Location = New Point(rightColX, baseY + 30)
        ComboBox1.Size = New Size(fieldWidth, 45)
        ComboBox1.Font = New Font("Segoe UI", 12)
        ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBox1.FlatStyle = FlatStyle.Flat
        formCard.Controls.Add(ComboBox1)
        ComboBox1.BringToFront()

        ' Nomor Telepon & Email 
        baseY += 100

        ' Label Nomor Telepon
        Dim lblTelepon As New Label()
        lblTelepon.Text = "Nomor Telepon"
        lblTelepon.Font = New Font("Segoe UI", 11, FontStyle.Bold)
        lblTelepon.ForeColor = Color.FromArgb(31, 41, 55)
        lblTelepon.Location = New Point(leftColX, baseY)
        lblTelepon.Size = New Size(fieldWidth, 25)
        lblTelepon.BackColor = Color.Transparent
        formCard.Controls.Add(lblTelepon)
        lblTelepon.BringToFront()

        ' TextBox2 - Nomor Telepon
        Me.Controls.Remove(TextBox2)
        TextBox2.BackColor = Color.FromArgb(249, 250, 251)
        TextBox2.Location = New Point(leftColX, baseY + 30)
        TextBox2.Size = New Size(fieldWidth, 45)
        TextBox2.Font = New Font("Segoe UI", 12)
        TextBox2.BorderStyle = BorderStyle.FixedSingle
        formCard.Controls.Add(TextBox2)
        TextBox2.BringToFront()

        ' Label Email
        Dim lblEmail As New Label()
        lblEmail.Text = "Email *"
        lblEmail.Font = New Font("Segoe UI", 11, FontStyle.Bold)
        lblEmail.ForeColor = Color.FromArgb(31, 41, 55)
        lblEmail.Location = New Point(rightColX, baseY)
        lblEmail.Size = New Size(fieldWidth, 25)
        lblEmail.BackColor = Color.Transparent
        formCard.Controls.Add(lblEmail)
        lblEmail.BringToFront()

        ' TextBox3 - Email
        Me.Controls.Remove(TextBox3)
        TextBox3.BackColor = Color.FromArgb(249, 250, 251)
        TextBox3.Location = New Point(rightColX, baseY + 30)
        TextBox3.Size = New Size(fieldWidth, 45)
        TextBox3.Font = New Font("Segoe UI", 12)
        TextBox3.BorderStyle = BorderStyle.FixedSingle
        formCard.Controls.Add(TextBox3)
        TextBox3.BringToFront()

        '  BUTTON SUBMIT 
        Me.Controls.Remove(Button1)
        Button1.Text = "Submit →"
        Button1.Font = New Font("Segoe UI", 16, FontStyle.Bold)
        Button1.BackColor = Color.FromArgb(99, 102, 241)
        Button1.ForeColor = Color.White
        Button1.FlatStyle = FlatStyle.Flat
        Button1.FlatAppearance.BorderSize = 0
        Button1.Cursor = Cursors.Hand
        Button1.Location = New Point(75, baseY + 110)
        Button1.Size = New Size(525, 60)
        Button1.Parent = formCard
        formCard.Controls.Add(Button1)
        Button1.BringToFront()
        AddRoundedCorners(Button1, 14)
        AddHandler Button1.MouseEnter, Sub()
                                           Button1.BackColor = Color.FromArgb(79, 70, 229)
                                       End Sub
        AddHandler Button1.MouseLeave, Sub()
                                           Button1.BackColor = Color.FromArgb(99, 102, 241)
                                       End Sub

        ' Label Login Link
        Dim lblLogin As New Label()
        lblLogin.BackColor = Color.Transparent
        lblLogin.Text = "Sudah punya akun? Masuk disini"
        lblLogin.Font = New Font("Segoe UI", 12)
        lblLogin.ForeColor = Color.FromArgb(107, 114, 128)
        lblLogin.TextAlign = ContentAlignment.MiddleCenter
        lblLogin.Cursor = Cursors.Hand
        lblLogin.Location = New Point(75, baseY + 190)
        lblLogin.Size = New Size(525, 30)
        lblLogin.Parent = formCard
        formCard.Controls.Add(lblLogin)
        lblLogin.Refresh()
        AddHandler lblLogin.Click, Sub()
                                       Dim loginForm As New Form1
                                       loginForm.Show()
                                       Me.Hide()
                                   End Sub
        AddHandler lblLogin.MouseEnter, Sub()
                                            lblLogin.ForeColor = Color.FromArgb(99, 102, 241)
                                            lblLogin.Font = New Font("Segoe UI", 12, FontStyle.Underline)
                                        End Sub
        AddHandler lblLogin.MouseLeave, Sub()
                                            lblLogin.ForeColor = Color.FromArgb(107, 114, 128)
                                            lblLogin.Font = New Font("Segoe UI", 12)
                                        End Sub


        ComboBox2.Items.Clear()
        ComboBox2.Items.Add("Laki-laki")
        ComboBox2.Items.Add("Perempuan")

        ComboBox1.Items.Clear()
        ComboBox1.Items.Add("Teknik Informatika")
        ComboBox1.Items.Add("Teknik Multimedia Jaringan")
        ComboBox1.Items.Add("Teknik Multimedia Digital")
    End Sub

    Private Sub AddRoundedCorners(ctrl As Control, radius As Integer)
        Dim path As New System.Drawing.Drawing2D.GraphicsPath()
        Dim rec As Rectangle = ctrl.ClientRectangle
        path.StartFigure()
        path.AddArc(rec.X, rec.Y, radius, radius, 180, 90)
        path.AddArc(rec.Width - radius, rec.Y, radius, radius, 270, 90)
        path.AddArc(rec.Width - radius, rec.Height - radius, radius, radius, 0, 90)
        path.AddArc(rec.X, rec.Height - radius, radius, radius, 90, 90)
        path.CloseFigure()
        ctrl.Region = New Region(path)
    End Sub

    Private Sub AddCircleShape(ctrl As Control)
        Dim path As New System.Drawing.Drawing2D.GraphicsPath()
        path.AddEllipse(0, 0, ctrl.Width, ctrl.Height)
        ctrl.Region = New Region(path)
    End Sub

    Private Sub AddEnhancedShadow(ctrl As Control)
    End Sub

    Private Function HashPassword(password As String) As String
        If String.IsNullOrEmpty(password) Then Return String.Empty
        Using sha As SHA256 = SHA256.Create()
            Dim bytes() As Byte = Encoding.UTF8.GetBytes(password)
            Dim hash() As Byte = sha.ComputeHash(bytes)
            Dim sb As New StringBuilder()
            For Each b As Byte In hash
                sb.Append(b.ToString("x2"))
            Next
            Return sb.ToString()
        End Using
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Validasi field 
        If String.IsNullOrWhiteSpace(TextBox1.Text) OrElse
           String.IsNullOrWhiteSpace(TextBox4.Text) OrElse
           String.IsNullOrWhiteSpace(ComboBox2.Text) OrElse
           String.IsNullOrWhiteSpace(ComboBox1.Text) OrElse
           String.IsNullOrWhiteSpace(TextBox3.Text) Then
            MessageBox.Show("Isi semua field yang wajib (Nama, Password, Jenis Kelamin, Prodi, Email).",
                            "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        ' Validasi password
        Dim password As String = TextBox4.Text
        If password.Length < 8 OrElse password.All(Function(c) Char.IsWhiteSpace(c)) OrElse Not password.Any(Function(c) Char.IsLetterOrDigit(c)) Then
            MessageBox.Show("Password minimal 8 karakter, harus memiliki karakter selain spasi, dan mengandung huruf atau angka!", "Validasi Password", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TextBox4.Focus()
            Return
        End If

        Try
            Using conn As SqlConnection = GetConnection()
                conn.Open()

                ' Cek email unik
                Dim emailCheckQuery As String = "SELECT COUNT(*) FROM users WHERE email=@email"
                Using checkCmd As New SqlCommand(emailCheckQuery, conn)
                    checkCmd.Parameters.AddWithValue("@email", TextBox3.Text.Trim())
                    Dim count As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())
                    If count > 0 Then
                        MessageBox.Show("Email sudah terdaftar, gunakan email lain!", "Validasi Email", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        TextBox3.Focus()
                        Return
                    End If
                End Using

                ' Hash password
                Dim hashedPassword As String = HashPassword(password)

                ' Insert user baru
                Dim sql As String = "
                    INSERT INTO users
                    (nama_depan, password, jenis_kelamin, prodi, nomor_telepon, email, created_at)
                    VALUES
                    (@nama, @password, @gender, @prodi, @telepon, @email, GETDATE())"

                Using cmd As New SqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@nama", TextBox1.Text.Trim())
                    cmd.Parameters.AddWithValue("@password", hashedPassword)
                    cmd.Parameters.AddWithValue("@gender", ComboBox2.Text.Trim())
                    cmd.Parameters.AddWithValue("@prodi", ComboBox1.Text.Trim())
                    cmd.Parameters.AddWithValue("@telepon", If(String.IsNullOrWhiteSpace(TextBox2.Text), DBNull.Value, TextBox2.Text.Trim()))
                    cmd.Parameters.AddWithValue("@email", TextBox3.Text.Trim())
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Registrasi Berhasil!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Dim loginForm As New Form1
            loginForm.Show()
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Terjadi error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Password strength
    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
        Label8.Text = GetPasswordStrength(TextBox4.Text)
    End Sub

    Private Function GetPasswordStrength(pw As String) As String
        If String.IsNullOrEmpty(pw) OrElse pw.All(Function(c) Char.IsWhiteSpace(c)) Then
            Label8.ForeColor = Color.Gray
            Return "Masukkan password"
        End If

        Dim score As Integer = 0
        If pw.Length >= 8 Then score += 1
        If pw.Any(Function(c) Char.IsLower(c)) Then score += 1
        If pw.Any(Function(c) Char.IsUpper(c)) Then score += 1
        If pw.Any(Function(c) Char.IsDigit(c)) Then score += 1
        If pw.Any(Function(c) Not Char.IsLetterOrDigit(c) AndAlso Not Char.IsWhiteSpace(c)) Then score += 1

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

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Dim landing As New Form7
        landing.Show()
        Me.Hide()
    End Sub
End Class