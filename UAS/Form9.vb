Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.Text
Imports System.Linq
Imports Microsoft.Data.SqlClient

Public Class Form9
    Public Property CurrentUser As UserModel

    ' UI Elements - Profile Section
    Private mainBg As Panel
    Private profileCard As Panel
    Private topAccent As Panel
    Private pageTitle As Label
    Private sectionTitle As Label
    Private txtNama As TextBox
    Private txtEmail As TextBox
    Private txtTelepon As TextBox
    Private lblBergabungValue As Label

    ' UI Elements - Password Section
    Private passwordCard As Panel
    Private passwordAccent As Panel
    Private passwordTitle As Label
    Private txtNamaPassword As TextBox
    Private txtPasswordBaru As TextBox
    Private txtPasswordKonfirmasi As TextBox
    Private lblPasswordStrength As Label
    Private btnSavePassword As Button

    ' Design Constants
    Private Const FORM_WIDTH As Integer = 1400
    Private Const FORM_HEIGHT As Integer = 850
    Private Const CARD_WIDTH As Integer = 500
    Private Const CARD_HEIGHT As Integer = 480
    Private Const CARD_SPACING As Integer = 30
    Private Const MARGIN_LEFT As Integer = 185
    Private Const MARGIN_TOP As Integer = 180

    ' Color Palette
    Private ReadOnly COLOR_PRIMARY As Color = Color.FromArgb(99, 102, 241)
    Private ReadOnly COLOR_PRIMARY_DARK As Color = Color.FromArgb(79, 70, 229)
    Private ReadOnly COLOR_PRIMARY_LIGHT As Color = Color.FromArgb(238, 242, 255)
    Private ReadOnly COLOR_SUCCESS As Color = Color.FromArgb(16, 185, 129)
    Private ReadOnly COLOR_DANGER As Color = Color.FromArgb(239, 68, 68)
    Private ReadOnly COLOR_DANGER_DARK As Color = Color.FromArgb(220, 38, 38)
    Private ReadOnly COLOR_WARNING As Color = Color.FromArgb(245, 158, 11)
    Private ReadOnly COLOR_TEXT_PRIMARY As Color = Color.FromArgb(17, 24, 39)
    Private ReadOnly COLOR_TEXT_SECONDARY As Color = Color.FromArgb(107, 114, 128)
    Private ReadOnly COLOR_BACKGROUND As Color = Color.FromArgb(249, 250, 251)
    Private ReadOnly COLOR_CARD As Color = Color.White
    Private ReadOnly COLOR_BORDER As Color = Color.FromArgb(229, 231, 235)
    Private ReadOnly COLOR_INPUT_BG As Color = Color.White

    Private Sub Form9_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If CurrentUser Is Nothing Then
            CurrentUser = New UserModel()
            CurrentUser.Id = 1
        End If

        InitializeForm()
        InitializeUIComponents()
        LoadUserProfile()
    End Sub

    Private Sub InitializeForm()
        Me.Size = New Size(FORM_WIDTH, FORM_HEIGHT)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.BackColor = COLOR_BACKGROUND
        Me.FormBorderStyle = FormBorderStyle.Sizable
        Me.MinimumSize = New Size(1200, 750)
        Me.Text = "SIMON - Profile & Security"
    End Sub

    Private Sub InitializeUIComponents()
        CreateBackgroundSection()
        CreateHeaderSection()
        CreateProfileCard()
        CreateProfileFields()
        CreatePasswordCard()
        CreatePasswordFields()
        CreateActionButtons()
    End Sub

    Private Sub CreateBackgroundSection()
        mainBg = New Panel With {.Location = New Point(0, 0), .Size = New Size(Me.ClientSize.Width, Me.ClientSize.Height), .BackColor = COLOR_BACKGROUND, .Dock = DockStyle.Fill}
        Me.Controls.Add(mainBg)
        mainBg.SendToBack()
    End Sub

    Private Sub CreateHeaderSection()
        pageTitle = New Label With {.Text = "👤 Profile & Keamanan", .Font = New Font("Segoe UI", 24, FontStyle.Bold), .Location = New Point(MARGIN_LEFT, MARGIN_TOP - 80), .Size = New Size(CARD_WIDTH * 2 + CARD_SPACING, 40), .ForeColor = COLOR_TEXT_PRIMARY, .BackColor = Color.Transparent}
        Me.Controls.Add(pageTitle)
        pageTitle.BringToFront()
    End Sub

    Private Sub CreateProfileCard()
        profileCard = New Panel With {.Location = New Point(MARGIN_LEFT, MARGIN_TOP), .Size = New Size(CARD_WIDTH, CARD_HEIGHT), .BackColor = COLOR_CARD}
        AddRoundedCorners(profileCard, 16)
        Me.Controls.Add(profileCard)

        topAccent = New Panel With {.Location = New Point(MARGIN_LEFT, MARGIN_TOP), .Size = New Size(CARD_WIDTH, 4), .BackColor = COLOR_PRIMARY}
        AddRoundedCorners(topAccent, 16)
        Me.Controls.Add(topAccent)
        topAccent.BringToFront()

        sectionTitle = New Label With {.Text = "📝 Informasi Pribadi", .Font = New Font("Segoe UI", 15, FontStyle.Bold), .Location = New Point(MARGIN_LEFT + 35, MARGIN_TOP + 28), .Size = New Size(CARD_WIDTH - 70, 28), .ForeColor = COLOR_TEXT_PRIMARY, .BackColor = Color.Transparent}
        Me.Controls.Add(sectionTitle)
        sectionTitle.BringToFront()
    End Sub

    Private Sub CreateProfileFields()
        Dim yPos As Integer = MARGIN_TOP + 75
        Dim fieldSpacing As Integer = 70

        ' Nama
        Dim lblNama As New Label With {.Text = "Nama Lengkap", .Font = New Font("Segoe UI", 9.5F, FontStyle.Bold), .Location = New Point(MARGIN_LEFT + 35, yPos), .Size = New Size(CARD_WIDTH - 70, 20), .ForeColor = COLOR_TEXT_SECONDARY}
        Me.Controls.Add(lblNama)
        lblNama.BringToFront()
        txtNama = New TextBox With {.Location = New Point(MARGIN_LEFT + 35, yPos + 22), .Size = New Size(CARD_WIDTH - 70, 36), .Font = New Font("Segoe UI", 10.5F), .BorderStyle = BorderStyle.FixedSingle, .BackColor = COLOR_INPUT_BG}
        Me.Controls.Add(txtNama)
        txtNama.BringToFront()
        yPos += fieldSpacing

        ' Email
        Dim lblEmail As New Label With {.Text = "Email", .Font = New Font("Segoe UI", 9.5F, FontStyle.Bold), .Location = New Point(MARGIN_LEFT + 35, yPos), .Size = New Size(CARD_WIDTH - 70, 20), .ForeColor = COLOR_TEXT_SECONDARY}
        Me.Controls.Add(lblEmail)
        lblEmail.BringToFront()
        txtEmail = New TextBox With {.Location = New Point(MARGIN_LEFT + 35, yPos + 22), .Size = New Size(CARD_WIDTH - 70, 36), .Font = New Font("Segoe UI", 10.5F), .BorderStyle = BorderStyle.FixedSingle, .BackColor = COLOR_INPUT_BG}
        Me.Controls.Add(txtEmail)
        txtEmail.BringToFront()
        yPos += fieldSpacing

        ' Telepon
        Dim lblTelepon As New Label With {.Text = "Nomor Telepon", .Font = New Font("Segoe UI", 9.5F, FontStyle.Bold), .Location = New Point(MARGIN_LEFT + 35, yPos), .Size = New Size(CARD_WIDTH - 70, 20), .ForeColor = COLOR_TEXT_SECONDARY}
        Me.Controls.Add(lblTelepon)
        lblTelepon.BringToFront()
        txtTelepon = New TextBox With {.Location = New Point(MARGIN_LEFT + 35, yPos + 22), .Size = New Size(CARD_WIDTH - 70, 36), .Font = New Font("Segoe UI", 10.5F), .BorderStyle = BorderStyle.FixedSingle, .BackColor = COLOR_INPUT_BG}
        Me.Controls.Add(txtTelepon)
        txtTelepon.BringToFront()
        yPos += fieldSpacing

        ' Bergabung
        Dim lblBergabung As New Label With {.Text = "Bergabung Sejak", .Font = New Font("Segoe UI", 9.5F, FontStyle.Bold), .Location = New Point(MARGIN_LEFT + 35, yPos), .Size = New Size(CARD_WIDTH - 70, 20), .ForeColor = COLOR_TEXT_SECONDARY}
        Me.Controls.Add(lblBergabung)
        lblBergabung.BringToFront()
        lblBergabungValue = New Label With {.Text = "-", .Font = New Font("Segoe UI", 11.0F, FontStyle.Regular), .Location = New Point(MARGIN_LEFT + 35, yPos + 22), .Size = New Size(CARD_WIDTH - 70, 28), .ForeColor = COLOR_TEXT_PRIMARY}
        Me.Controls.Add(lblBergabungValue)
        lblBergabungValue.BringToFront()
    End Sub

    Private Sub CreatePasswordCard()
        passwordCard = New Panel With {.Location = New Point(MARGIN_LEFT + CARD_WIDTH + CARD_SPACING, MARGIN_TOP), .Size = New Size(CARD_WIDTH, CARD_HEIGHT), .BackColor = COLOR_CARD}
        AddRoundedCorners(passwordCard, 16)
        Me.Controls.Add(passwordCard)

        passwordAccent = New Panel With {.Location = New Point(MARGIN_LEFT + CARD_WIDTH + CARD_SPACING, MARGIN_TOP), .Size = New Size(CARD_WIDTH, 4), .BackColor = COLOR_DANGER}
        AddRoundedCorners(passwordAccent, 16)
        Me.Controls.Add(passwordAccent)
        passwordAccent.BringToFront()

        passwordTitle = New Label With {.Text = "🔒 Ganti Password", .Font = New Font("Segoe UI", 15, FontStyle.Bold), .Location = New Point(MARGIN_LEFT + CARD_WIDTH + CARD_SPACING + 35, MARGIN_TOP + 28), .Size = New Size(CARD_WIDTH - 70, 28), .ForeColor = COLOR_TEXT_PRIMARY, .BackColor = Color.Transparent}
        Me.Controls.Add(passwordTitle)
        passwordTitle.BringToFront()
    End Sub

    Private Sub CreatePasswordFields()
        Dim xPos As Integer = MARGIN_LEFT + CARD_WIDTH + CARD_SPACING
        Dim yPos As Integer = MARGIN_TOP + 75
        Dim fieldSpacing As Integer = 78

        ' Nama Verifikasi
        Dim lblNamaPass As New Label With {.Text = "Nama Lengkap (Verifikasi)", .Font = New Font("Segoe UI", 9.5F, FontStyle.Bold), .Location = New Point(xPos + 35, yPos), .Size = New Size(CARD_WIDTH - 70, 20), .ForeColor = COLOR_TEXT_SECONDARY}
        Me.Controls.Add(lblNamaPass)
        lblNamaPass.BringToFront()
        txtNamaPassword = New TextBox With {.Location = New Point(xPos + 35, yPos + 22), .Size = New Size(CARD_WIDTH - 70, 36), .Font = New Font("Segoe UI", 10.5F), .BorderStyle = BorderStyle.FixedSingle, .BackColor = COLOR_INPUT_BG, .PlaceholderText = "Masukkan nama lengkap Anda"}
        Me.Controls.Add(txtNamaPassword)
        txtNamaPassword.BringToFront()
        yPos += fieldSpacing

        ' Password Baru
        Dim lblPassBaru As New Label With {.Text = "Password Baru", .Font = New Font("Segoe UI", 9.5F, FontStyle.Bold), .Location = New Point(xPos + 35, yPos), .Size = New Size(CARD_WIDTH - 70, 20), .ForeColor = COLOR_TEXT_SECONDARY}
        Me.Controls.Add(lblPassBaru)
        lblPassBaru.BringToFront()
        txtPasswordBaru = New TextBox With {.Location = New Point(xPos + 35, yPos + 22), .Size = New Size(CARD_WIDTH - 70, 36), .Font = New Font("Segoe UI", 10.5F), .BorderStyle = BorderStyle.FixedSingle, .BackColor = COLOR_INPUT_BG, .UseSystemPasswordChar = True, .PlaceholderText = "Minimal 8 karakter"}
        AddHandler txtPasswordBaru.TextChanged, AddressOf TxtPasswordBaru_TextChanged
        Me.Controls.Add(txtPasswordBaru)
        txtPasswordBaru.BringToFront()

        lblPasswordStrength = New Label With {.Text = "Masukkan password baru", .Font = New Font("Segoe UI", 8.5F, FontStyle.Italic), .Location = New Point(xPos + 35, yPos + 60), .Size = New Size(CARD_WIDTH - 70, 16), .ForeColor = Color.Gray}
        Me.Controls.Add(lblPasswordStrength)
        lblPasswordStrength.BringToFront()
        yPos += fieldSpacing

        ' Konfirmasi Password
        Dim lblPassKonfirm As New Label With {.Text = "Konfirmasi Password Baru", .Font = New Font("Segoe UI", 9.5F, FontStyle.Bold), .Location = New Point(xPos + 35, yPos), .Size = New Size(CARD_WIDTH - 70, 20), .ForeColor = COLOR_TEXT_SECONDARY}
        Me.Controls.Add(lblPassKonfirm)
        lblPassKonfirm.BringToFront()
        txtPasswordKonfirmasi = New TextBox With {.Location = New Point(xPos + 35, yPos + 22), .Size = New Size(CARD_WIDTH - 70, 36), .Font = New Font("Segoe UI", 10.5F), .BorderStyle = BorderStyle.FixedSingle, .BackColor = COLOR_INPUT_BG, .UseSystemPasswordChar = True, .PlaceholderText = "Ketik ulang password baru"}
        Me.Controls.Add(txtPasswordKonfirmasi)
        txtPasswordKonfirmasi.BringToFront()
        yPos += fieldSpacing + 8

        ' Button Simpan Password
        btnSavePassword = New Button With {.Location = New Point(xPos + 35, yPos), .Size = New Size(CARD_WIDTH - 70, 46), .Font = New Font("Segoe UI", 11.5F, FontStyle.Bold), .Text = "🔐 Simpan Password Baru", .BackColor = COLOR_DANGER, .ForeColor = Color.White, .FlatStyle = FlatStyle.Flat, .Cursor = Cursors.Hand}
        btnSavePassword.FlatAppearance.BorderSize = 0
        AddRoundedCorners(btnSavePassword, 10)
        AddHandler btnSavePassword.Click, AddressOf BtnSavePassword_Click
        AddHandler btnSavePassword.MouseEnter, Sub() btnSavePassword.BackColor = COLOR_DANGER_DARK
        AddHandler btnSavePassword.MouseLeave, Sub() btnSavePassword.BackColor = COLOR_DANGER
        Me.Controls.Add(btnSavePassword)
        btnSavePassword.BringToFront()
    End Sub

    Private Sub CreateActionButtons()
        Dim buttonY As Integer = MARGIN_TOP + CARD_HEIGHT + 32
        Dim totalWidth As Integer = CARD_WIDTH * 2 + CARD_SPACING
        Dim buttonSpacing As Integer = 20
        Dim totalButtonWidth As Integer = 190 + 160 + buttonSpacing
        Dim startX As Integer = MARGIN_LEFT + (totalWidth - totalButtonWidth) \ 2

        ' Button1 - Simpan Profile
        Button1.Location = New Point(startX, buttonY)
        Button1.Size = New Size(190, 50)
        Button1.Font = New Font("Segoe UI", 11.5F, FontStyle.Bold)
        Button1.Text = "💾 Simpan Profile"
        Button1.BackColor = COLOR_PRIMARY
        Button1.ForeColor = Color.White
        Button1.FlatStyle = FlatStyle.Flat
        Button1.FlatAppearance.BorderSize = 0
        Button1.Cursor = Cursors.Hand
        AddRoundedCorners(Button1, 10)
        AddHandler Button1.MouseEnter, Sub() Button1.BackColor = COLOR_PRIMARY_DARK
        AddHandler Button1.MouseLeave, Sub() Button1.BackColor = COLOR_PRIMARY
        Me.Controls.Add(Button1)
        Button1.BringToFront()

        ' Button3 - Logout
        Button3.Location = New Point(startX + 190 + buttonSpacing, buttonY)
        Button3.Size = New Size(160, 50)
        Button3.Font = New Font("Segoe UI", 11.5F, FontStyle.Bold)
        Button3.Text = "🚪 Logout"
        Button3.BackColor = COLOR_DANGER
        Button3.ForeColor = Color.White
        Button3.FlatStyle = FlatStyle.Flat
        Button3.FlatAppearance.BorderSize = 0
        Button3.Cursor = Cursors.Hand
        AddRoundedCorners(Button3, 10)
        AddHandler Button3.MouseEnter, Sub() Button3.BackColor = COLOR_DANGER_DARK
        AddHandler Button3.MouseLeave, Sub() Button3.BackColor = COLOR_DANGER
        Me.Controls.Add(Button3)
        Button3.BringToFront()
    End Sub

    Private Function HashPassword(pw As String) As String
        Using sha As SHA256 = SHA256.Create()
            Dim bytes = Encoding.UTF8.GetBytes(pw)
            Dim hash = sha.ComputeHash(bytes)
            Return BitConverter.ToString(hash).Replace("-", "").ToLower()
        End Using
    End Function

    Private Sub TxtPasswordBaru_TextChanged(sender As Object, e As EventArgs)
        lblPasswordStrength.Text = GetPasswordStrength(txtPasswordBaru.Text)
    End Sub

    Private Function GetPasswordStrength(pw As String) As String
        If String.IsNullOrEmpty(pw) Then
            lblPasswordStrength.ForeColor = Color.Gray
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
                lblPasswordStrength.ForeColor = COLOR_SUCCESS
                Return "✓ Password Kuat"
            Case 3, 4
                lblPasswordStrength.ForeColor = COLOR_WARNING
                Return "⚠ Password Sedang"
            Case Else
                lblPasswordStrength.ForeColor = COLOR_DANGER
                Return "✗ Password Lemah"
        End Select
    End Function

    Private Sub BtnSavePassword_Click(sender As Object, e As EventArgs)
        Dim namaLengkap = txtNamaPassword.Text.Trim()
        Dim newPass = txtPasswordBaru.Text
        Dim confirmPass = txtPasswordKonfirmasi.Text

        If namaLengkap = "" Or newPass = "" Or confirmPass = "" Then
            MessageBox.Show("Semua field harus diisi!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If newPass <> confirmPass Then
            MessageBox.Show("Password baru dan konfirmasi tidak sama!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If newPass.Length < 8 Then
            MessageBox.Show("Password minimal 8 karakter!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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
                        MessageBox.Show("Nama lengkap tidak ditemukan!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return
                    End If
                End Using

                Dim newPassHash = HashPassword(newPass)
                If newPassHash = oldPassHash Then
                    MessageBox.Show("Password baru tidak boleh sama dengan password lama!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If

                Dim updateQuery = "UPDATE users SET password=@pass WHERE nama_depan=@nama"
                Using updateCmd As New SqlCommand(updateQuery, conn)
                    updateCmd.Parameters.AddWithValue("@pass", newPassHash)
                    updateCmd.Parameters.AddWithValue("@nama", namaLengkap)
                    updateCmd.ExecuteNonQuery()
                End Using

                MessageBox.Show("Password berhasil diubah!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtNamaPassword.Clear()
                txtPasswordBaru.Clear()
                txtPasswordKonfirmasi.Clear()
                lblPasswordStrength.Text = "Masukkan password baru"
                lblPasswordStrength.ForeColor = Color.Gray
            End Using

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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

    Private Sub AddEnhancedShadow(ctrl As Control)
    End Sub

    Private Sub LoadUserProfile()
        Try
            Using conn As SqlConnection = GetConnection()
                conn.Open()
                Dim query As String = "SELECT nama_depan, email, nomor_telepon, created_at FROM users WHERE id = @userId"
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@userId", CurrentUser.Id)
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            txtNama.Text = If(IsDBNull(reader("nama_depan")), "", reader("nama_depan").ToString())
                            txtEmail.Text = If(IsDBNull(reader("email")), "", reader("email").ToString())
                            txtTelepon.Text = If(IsDBNull(reader("nomor_telepon")), "", reader("nomor_telepon").ToString())
                            CurrentUser.Email = txtEmail.Text

                            If Not IsDBNull(reader("created_at")) Then
                                Dim joinDate As DateTime = Convert.ToDateTime(reader("created_at"))
                                lblBergabungValue.Text = joinDate.ToString("dd MMMM yyyy")
                            Else
                                lblBergabungValue.Text = "-"
                            End If
                        Else
                            MessageBox.Show("Data user tidak ditemukan!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading profile: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SaveUserProfile()
        If String.IsNullOrWhiteSpace(txtNama.Text) Then
            MessageBox.Show("Nama tidak boleh kosong!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtNama.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(txtEmail.Text) Then
            MessageBox.Show("Email tidak boleh kosong!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtEmail.Focus()
            Return
        End If

        If Not txtEmail.Text.Contains("@") OrElse Not txtEmail.Text.Contains(".") Then
            MessageBox.Show("Format email tidak valid!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtEmail.Focus()
            Return
        End If

        Try
            Using conn As SqlConnection = GetConnection()
                conn.Open()
                Dim query As String = "UPDATE users SET nama_depan = @nama, email = @email, nomor_telepon = @telepon WHERE id = @userId"
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@nama", txtNama.Text.Trim())
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim())
                    cmd.Parameters.AddWithValue("@telepon", txtTelepon.Text.Trim())
                    cmd.Parameters.AddWithValue("@userId", CurrentUser.Id)
                    Dim rowsAffected = cmd.ExecuteNonQuery()
                    If rowsAffected > 0 Then
                        MessageBox.Show("Perubahan berhasil disimpan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        CurrentUser.Email = txtEmail.Text
                    Else
                        MessageBox.Show("Gagal menyimpan perubahan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                    CurrentUser.NamaDepan = txtNama.Text.Trim()
                    CurrentUser.Email = txtEmail.Text.Trim()
                    CurrentUser.NomorTelepon = txtTelepon.Text.Trim()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error menyimpan data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



    Private Sub Button3_Click(sender As Object, e As EventArgs)
        Dim result = MessageBox.Show("Apakah Anda yakin ingin logout?", "Konfirmasi Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            Dim landing As New Form7
            landing.Show()
            Close()
        End If
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim menu As New Form6

        If CurrentUser IsNot Nothing Then
            menu.CurrentUser = Me.CurrentUser
        End If
        menu.Show()
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SaveUserProfile()
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Dim profil As New Form9
        If CurrentUser IsNot Nothing Then
            profil.CurrentUser = Me.CurrentUser
        End If
        profil.Show()
        Me.Close()
    End Sub

    Private Sub ToolStripDropDownButton1_Click(sender As Object, e As EventArgs) Handles ToolStripDropDownButton1.Click

    End Sub

    Private Sub MulaiKonsultasiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MulaiKonsultasiToolStripMenuItem.Click
        Dim konsultasi As New Form3
        If CurrentUser IsNot Nothing Then
            konsultasi.CurrentUser = Me.CurrentUser
        End If
        konsultasi.Show()
        Me.Hide()
    End Sub

    Private Sub RiwayatKonsultasiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RiwayatKonsultasiToolStripMenuItem.Click
        Dim f8 As New Form8
        If CurrentUser IsNot Nothing Then
            f8.CurrentUser = Me.CurrentUser
        End If
        f8.Show()
        Me.Hide()
    End Sub
End Class