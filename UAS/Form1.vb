Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.Text
Imports Microsoft.Data.SqlClient

Public Class Form1

    Private Function HashPassword(pw As String) As String
        Using sha As SHA256 = SHA256.Create()
            Dim bytes = Encoding.UTF8.GetBytes(pw)
            Dim hash = sha.ComputeHash(bytes)
            Return BitConverter.ToString(hash).Replace("-", "").ToLower()
        End Using
    End Function

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "SIMON - Login"
        Me.Size = New Size(1440, 900)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.BackColor = Color.FromArgb(249, 250, 251)

        ' BACKGROUND GRADIENT
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
        Dim backLabel As New Label With {
            .Text = "←",
            .Font = New Font("Segoe UI", 28, FontStyle.Bold),
            .Location = New Point(40, 35),
            .Size = New Size(50, 50),
            .ForeColor = Color.FromArgb(99, 102, 241),
            .BackColor = Color.Transparent,
            .TextAlign = ContentAlignment.MiddleCenter,
            .Cursor = Cursors.Hand
        }
        leftBg.Controls.Add(backLabel)
        backLabel.BringToFront()
        AddHandler backLabel.Click, Sub()
                                        Dim landing As New Form7
                                        landing.Show()
                                        Me.Hide()
                                    End Sub

        ' Logo placeholder
        Me.Controls.Remove(PictureBox1)
        PictureBox1.BackColor = Color.Transparent
        PictureBox1.Location = New Point(175, 220)
        PictureBox1.Size = New Size(300, 300)
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        leftBg.Controls.Add(PictureBox1)
        PictureBox1.BringToFront()

        ' Label title
        Dim titleLabel As New Label()
        titleLabel.BackColor = Color.Transparent
        titleLabel.Text = "Expert System"
        titleLabel.Font = New Font("Segoe UI", 24, FontStyle.Bold)
        titleLabel.Location = New Point(125, 540)
        titleLabel.Size = New Size(400, 45)
        titleLabel.ForeColor = Color.FromArgb(17, 24, 39)
        titleLabel.TextAlign = ContentAlignment.MiddleCenter
        titleLabel.Parent = leftBg
        leftBg.Controls.Add(titleLabel)

        ' Label subtitle 
        Dim subtitleLabel As New Label()
        subtitleLabel.BackColor = Color.Transparent
        subtitleLabel.Text = "Topik Skripsi"
        subtitleLabel.Font = New Font("Segoe UI", 24, FontStyle.Bold)
        subtitleLabel.Location = New Point(125, 590)
        subtitleLabel.Size = New Size(400, 45)
        subtitleLabel.ForeColor = Color.FromArgb(99, 102, 241)
        subtitleLabel.TextAlign = ContentAlignment.MiddleCenter
        subtitleLabel.Parent = leftBg
        leftBg.Controls.Add(subtitleLabel)

        ' PANEL KANAN 

        ' Main Card
        Dim formCard As New Panel With {
            .Location = New Point(720, 100),
            .Size = New Size(650, 680),
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

        ' Title 
        Dim loginTitle As New Label()
        loginTitle.Text = "Login"
        loginTitle.Font = New Font("Segoe UI", 40, FontStyle.Bold)
        loginTitle.ForeColor = Color.FromArgb(17, 24, 39)
        loginTitle.TextAlign = ContentAlignment.TopCenter
        loginTitle.Location = New Point(75, 60)
        loginTitle.Size = New Size(500, 65)
        loginTitle.BackColor = Color.Transparent
        formCard.Controls.Add(loginTitle)
        loginTitle.BringToFront()

        ' Subtitle
        Dim loginSubtitle As New Label()
        loginSubtitle.Text = "Masuk ke akun Anda"
        loginSubtitle.Font = New Font("Segoe UI", 13)
        loginSubtitle.ForeColor = Color.FromArgb(107, 114, 128)
        loginSubtitle.TextAlign = ContentAlignment.TopCenter
        loginSubtitle.Location = New Point(75, 130)
        loginSubtitle.Size = New Size(500, 35)
        loginSubtitle.BackColor = Color.Transparent
        formCard.Controls.Add(loginSubtitle)
        loginSubtitle.BringToFront()

        ' FORM FIELDS 
        Dim baseY As Integer = 210
        Dim centerX As Integer = 75

        ' Label Username
        Dim lblUsername As New Label With {
            .Text = "Username *",
            .Font = New Font("Segoe UI", 12, FontStyle.Bold),
            .Location = New Point(centerX, baseY),
            .Size = New Size(500, 30),
            .ForeColor = Color.FromArgb(31, 41, 55),
            .BackColor = Color.Transparent
        }
        formCard.Controls.Add(lblUsername)
        lblUsername.BringToFront()

        ' TextBox1 - Username
        Me.Controls.Remove(TextBox1)
        TextBox1.BackColor = Color.FromArgb(249, 250, 251)
        TextBox1.Location = New Point(centerX, baseY + 35)
        TextBox1.Size = New Size(500, 50)
        TextBox1.Font = New Font("Segoe UI", 13)
        TextBox1.BorderStyle = BorderStyle.FixedSingle
        formCard.Controls.Add(TextBox1)
        TextBox1.BringToFront()

        ' Label Password
        Dim lblPassword As New Label With {
            .Text = "Password *",
            .Font = New Font("Segoe UI", 12, FontStyle.Bold),
            .Location = New Point(centerX, baseY + 105),
            .Size = New Size(500, 30),
            .ForeColor = Color.FromArgb(31, 41, 55),
            .BackColor = Color.Transparent
        }
        formCard.Controls.Add(lblPassword)
        lblPassword.BringToFront()

        ' TextBox2 - Password
        Me.Controls.Remove(TextBox2)
        TextBox2.BackColor = Color.FromArgb(249, 250, 251)
        TextBox2.Location = New Point(centerX, baseY + 140)
        TextBox2.Size = New Size(500, 50)
        TextBox2.Font = New Font("Segoe UI", 13)
        TextBox2.BorderStyle = BorderStyle.FixedSingle
        TextBox2.PasswordChar = "●"c
        formCard.Controls.Add(TextBox2)
        TextBox2.BringToFront()

        ' CheckBox1 - Remember Me
        Me.Controls.Remove(CheckBox1)
        CheckBox1.BackColor = Color.Transparent
        CheckBox1.Location = New Point(centerX, baseY + 210)
        CheckBox1.Size = New Size(500, 35)
        CheckBox1.Font = New Font("Segoe UI", 11)
        CheckBox1.Text = "Ingat Saya"
        CheckBox1.ForeColor = Color.FromArgb(107, 114, 128)
        formCard.Controls.Add(CheckBox1)
        CheckBox1.BringToFront()

        ' Button1 - Login
        Me.Controls.Remove(Button1)
        Button1.Location = New Point(centerX, baseY + 265)
        Button1.Size = New Size(500, 60)
        Button1.Font = New Font("Segoe UI", 16, FontStyle.Bold)
        Button1.Text = "Login →"
        Button1.BackColor = Color.FromArgb(99, 102, 241)
        Button1.ForeColor = Color.White
        Button1.FlatStyle = FlatStyle.Flat
        Button1.FlatAppearance.BorderSize = 0
        Button1.Cursor = Cursors.Hand
        AddRoundedCorners(Button1, 14)
        formCard.Controls.Add(Button1)
        Button1.BringToFront()
        AddHandler Button1.MouseEnter, Sub()
                                           Button1.BackColor = Color.FromArgb(79, 70, 229)
                                       End Sub
        AddHandler Button1.MouseLeave, Sub()
                                           Button1.BackColor = Color.FromArgb(99, 102, 241)
                                       End Sub

        ' Button2 - Sign Up 
        Dim lblSignup As New Label With {
            .Text = "Belum punya akun? Daftar disini",
            .Font = New Font("Segoe UI", 12),
            .Location = New Point(centerX, baseY + 345),
            .Size = New Size(500, 30),
            .ForeColor = Color.FromArgb(107, 114, 128),
            .BackColor = Color.Transparent,
            .TextAlign = ContentAlignment.MiddleCenter,
            .Cursor = Cursors.Hand
        }
        formCard.Controls.Add(lblSignup)
        lblSignup.BringToFront()
        AddHandler lblSignup.Click, Sub()
                                        Dim signup As New Form2
                                        signup.Show()
                                        Me.Hide()
                                    End Sub
        AddHandler lblSignup.MouseEnter, Sub()
                                             lblSignup.ForeColor = Color.FromArgb(99, 102, 241)
                                             lblSignup.Font = New Font("Segoe UI", 12, FontStyle.Underline)
                                         End Sub
        AddHandler lblSignup.MouseLeave, Sub()
                                             lblSignup.ForeColor = Color.FromArgb(107, 114, 128)
                                             lblSignup.Font = New Font("Segoe UI", 12)
                                         End Sub

        ' Load Remember Me settings
        If My.Settings.RememberMe = True Then
            TextBox1.Text = My.Settings.Username
            CheckBox1.Checked = True
        End If
    End Sub

    ' Helper: Rounded Corners
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

    ' Helper: Circle Shape
    Private Sub AddCircleShape(ctrl As Control)
        Dim path As New System.Drawing.Drawing2D.GraphicsPath()
        path.AddEllipse(0, 0, ctrl.Width, ctrl.Height)
        ctrl.Region = New Region(path)
    End Sub

    ' Helper: Enhanced Shadow
    Private Sub AddEnhancedShadow(ctrl As Control)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Using conn As SqlConnection = GetConnection()
                conn.Open()
                Dim query As String = "
                    SELECT id, nama_depan, jenis_kelamin, prodi, nomor_telepon, email
                    FROM users
                    WHERE nama_depan = @nama AND password = @pass
                "
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@nama", TextBox1.Text)
                    cmd.Parameters.AddWithValue("@pass", HashPassword(TextBox2.Text))
                    Dim rd = cmd.ExecuteReader()
                    If rd.Read() Then
                        ' SIMPAN USER KE DALAM MODEL
                        Dim u As New UserModel With {
                            .Id = rd("id"),
                            .NamaDepan = rd("nama_depan").ToString(),
                            .JenisKelamin = rd("jenis_kelamin").ToString(),
                            .Prodi = rd("prodi").ToString(),
                            .NomorTelepon = rd("nomor_telepon").ToString(),
                            .Email = rd("email").ToString()
                        }
                        ' Remember Me
                        If CheckBox1.Checked Then
                            My.Settings.Username = TextBox1.Text
                            My.Settings.RememberMe = True
                        Else
                            My.Settings.Username = ""
                            My.Settings.RememberMe = False
                        End If
                        My.Settings.Save()
                        ' BAWA USER KE FORM6
                        Dim menuutama As New Form6
                        menuutama.CurrentUser = u
                        menuutama.Show()
                        Me.Hide()
                    Else
                        MessageBox.Show("Username atau password salah!", "Login Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        Dim signup As New Form2
        signup.Show()
        Hide()
    End Sub
End Class