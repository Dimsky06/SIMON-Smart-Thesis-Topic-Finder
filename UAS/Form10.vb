Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports Microsoft.Data.SqlClient

Public Class Form10
    Private userId As Integer
    Private originalEmail As String

    Public Sub New(id As Integer, nama As String, email As String, telepon As String)
        InitializeComponent()

        userId = id
        originalEmail = email

        ' Set initial values
        TextBox1.Text = nama
        TextBox2.Text = email
        TextBox3.Text = telepon
    End Sub

    Private Sub FormEditProfile_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Pengaturan Form
        Me.Size = New Size(600, 500)
        Me.StartPosition = FormStartPosition.CenterParent
        Me.BackColor = Color.White
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Text = "Edit Profil"

        ' Background
        Dim mainBg As New Panel With {
            .Location = New Point(0, 0),
            .Size = New Size(600, 500),
            .BackColor = Color.FromArgb(249, 250, 251)
        }
        Me.Controls.Add(mainBg)
        mainBg.SendToBack()

        ' Main Card
        Dim card As New Panel With {
            .Location = New Point(40, 40),
            .Size = New Size(520, 420),
            .BackColor = Color.White
        }
        AddRoundedCorners(card, 20)
        Me.Controls.Add(card)

        ' Top accent
        Dim topAccent As New Panel With {
            .Location = New Point(40, 40),
            .Size = New Size(520, 5),
            .BackColor = Color.FromArgb(99, 102, 241)
        }
        AddRoundedCorners(topAccent, 20)
        Me.Controls.Add(topAccent)
        topAccent.BringToFront()

        ' Title
        Dim title As New Label With {
            .Text = "✏️ Edit Profil",
            .Font = New Font("Segoe UI", 22, FontStyle.Bold),
            .Location = New Point(70, 70),
            .Size = New Size(460, 40),
            .ForeColor = Color.FromArgb(17, 24, 39),
            .BackColor = Color.Transparent
        }
        Me.Controls.Add(title)
        title.BringToFront()

        Dim subtitle As New Label With {
            .Text = "Perbarui informasi profil Anda",
            .Font = New Font("Segoe UI", 11),
            .Location = New Point(70, 110),
            .Size = New Size(460, 25),
            .ForeColor = Color.FromArgb(107, 114, 128),
            .BackColor = Color.Transparent
        }
        Me.Controls.Add(subtitle)
        subtitle.BringToFront()

        Dim yPos As Integer = 160

        ' Nama Label
        Dim lblNama As New Label With {
            .Text = "Nama Lengkap *",
            .Font = New Font("Segoe UI", 11, FontStyle.Bold),
            .Location = New Point(70, yPos),
            .Size = New Size(460, 25),
            .ForeColor = Color.FromArgb(31, 41, 55),
            .BackColor = Color.Transparent
        }
        Me.Controls.Add(lblNama)
        lblNama.BringToFront()

        ' TextBox1 - Nama
        TextBox1.Location = New Point(70, yPos + 30)
        TextBox1.Size = New Size(460, 40)
        TextBox1.Font = New Font("Segoe UI", 12)
        TextBox1.BorderStyle = BorderStyle.FixedSingle
        TextBox1.BackColor = Color.FromArgb(249, 250, 251)
        TextBox1.BringToFront()

        yPos += 80

        ' Email Label
        Dim lblEmail As New Label With {
            .Text = "Email *",
            .Font = New Font("Segoe UI", 11, FontStyle.Bold),
            .Location = New Point(70, yPos),
            .Size = New Size(460, 25),
            .ForeColor = Color.FromArgb(31, 41, 55),
            .BackColor = Color.Transparent
        }
        Me.Controls.Add(lblEmail)
        lblEmail.BringToFront()

        ' TextBox2 - Email
        TextBox2.Location = New Point(70, yPos + 30)
        TextBox2.Size = New Size(460, 40)
        TextBox2.Font = New Font("Segoe UI", 12)
        TextBox2.BorderStyle = BorderStyle.FixedSingle
        TextBox2.BackColor = Color.FromArgb(249, 250, 251)
        TextBox2.BringToFront()

        yPos += 80

        ' Telepon Label
        Dim lblTelepon As New Label With {
            .Text = "Nomor Telepon",
            .Font = New Font("Segoe UI", 11, FontStyle.Bold),
            .Location = New Point(70, yPos),
            .Size = New Size(460, 25),
            .ForeColor = Color.FromArgb(31, 41, 55),
            .BackColor = Color.Transparent
        }
        Me.Controls.Add(lblTelepon)
        lblTelepon.BringToFront()

        ' TextBox3 - Telepon
        TextBox3.Location = New Point(70, yPos + 30)
        TextBox3.Size = New Size(460, 40)
        TextBox3.Font = New Font("Segoe UI", 12)
        TextBox3.BorderStyle = BorderStyle.FixedSingle
        TextBox3.BackColor = Color.FromArgb(249, 250, 251)
        TextBox3.BringToFront()

        ' Buttons
        Dim btnSave As New Button With {
            .Text = "💾 Simpan",
            .Location = New Point(350, 410),
            .Size = New Size(180, 45),
            .Font = New Font("Segoe UI", 12, FontStyle.Bold),
            .BackColor = Color.FromArgb(99, 102, 241),
            .ForeColor = Color.White,
            .FlatStyle = FlatStyle.Flat,
            .Cursor = Cursors.Hand
        }
        btnSave.FlatAppearance.BorderSize = 0
        AddRoundedCorners(btnSave, 10)
        AddHandler btnSave.Click, AddressOf BtnSave_Click
        AddHandler btnSave.MouseEnter, Sub()
                                           btnSave.BackColor = Color.FromArgb(79, 70, 229)
                                       End Sub
        AddHandler btnSave.MouseLeave, Sub()
                                           btnSave.BackColor = Color.FromArgb(99, 102, 241)
                                       End Sub
        Me.Controls.Add(btnSave)
        btnSave.BringToFront()

        Dim btnCancel As New Button With {
            .Text = "Batal",
            .Location = New Point(160, 410),
            .Size = New Size(180, 45),
            .Font = New Font("Segoe UI", 12, FontStyle.Bold),
            .BackColor = Color.White,
            .ForeColor = Color.FromArgb(107, 114, 128),
            .FlatStyle = FlatStyle.Flat,
            .Cursor = Cursors.Hand
        }
        btnCancel.FlatAppearance.BorderColor = Color.FromArgb(229, 231, 235)
        btnCancel.FlatAppearance.BorderSize = 2
        AddRoundedCorners(btnCancel, 10)
        AddHandler btnCancel.Click, Sub()
                                        Me.DialogResult = DialogResult.Cancel
                                        Me.Close()
                                    End Sub
        AddHandler btnCancel.MouseEnter, Sub()
                                             btnCancel.BackColor = Color.FromArgb(249, 250, 251)
                                         End Sub
        AddHandler btnCancel.MouseLeave, Sub()
                                             btnCancel.BackColor = Color.White
                                         End Sub
        Me.Controls.Add(btnCancel)
        btnCancel.BringToFront()
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

    Private Sub BtnSave_Click(sender As Object, e As EventArgs)
        ' Validasi
        If String.IsNullOrWhiteSpace(TextBox1.Text) Then
            MessageBox.Show("Nama tidak boleh kosong!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TextBox1.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(TextBox2.Text) Then
            MessageBox.Show("Email tidak boleh kosong!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TextBox2.Focus()
            Return
        End If

        ' Validasi format email
        If Not TextBox2.Text.Contains("@") OrElse Not TextBox2.Text.Contains(".") Then
            MessageBox.Show("Format email tidak valid!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TextBox2.Focus()
            Return
        End If

        Try
            Using conn As SqlConnection = GetConnection()
                conn.Open()

                ' Cek email unik jika email diubah
                If TextBox2.Text.Trim() <> originalEmail Then
                    Dim checkQuery As String = "SELECT COUNT(*) FROM users WHERE email = @email AND id <> @userId"
                    Using checkCmd As New SqlCommand(checkQuery, conn)
                        checkCmd.Parameters.AddWithValue("@email", TextBox2.Text.Trim())
                        checkCmd.Parameters.AddWithValue("@userId", userId)

                        Dim count As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())
                        If count > 0 Then
                            MessageBox.Show("Email sudah digunakan oleh user lain!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            TextBox2.Focus()
                            Return
                        End If
                    End Using
                End If

                ' Update data
                Dim updateQuery As String = "
                    UPDATE users 
                    SET 
                        nama_depan = @nama,
                        email = @email,
                        nomor_telepon = @telepon
                    WHERE id = @userId"

                Using cmd As New SqlCommand(updateQuery, conn)
                    cmd.Parameters.AddWithValue("@nama", TextBox1.Text.Trim())
                    cmd.Parameters.AddWithValue("@email", TextBox2.Text.Trim())
                    cmd.Parameters.AddWithValue("@telepon", If(String.IsNullOrWhiteSpace(TextBox3.Text), DBNull.Value, TextBox3.Text.Trim()))
                    cmd.Parameters.AddWithValue("@userId", userId)

                    cmd.ExecuteNonQuery()
                End Using
            End Using

            Me.DialogResult = DialogResult.OK
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Error update profil: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Validasi input telepon hanya angka
    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
End Class
