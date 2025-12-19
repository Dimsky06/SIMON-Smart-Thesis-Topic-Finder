Public Class Form7
    Private Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "SIMON - Smart Thesis Topic Finder"
        Me.Size = New Size(1400, 800)
        Me.StartPosition = FormStartPosition.CenterScreen

        '  BACKGROUND UTAMA 
        Dim mainBg As New Panel With {
            .Location = New Point(0, 0),
            .Size = New Size(1400, 800),
            .BackColor = Color.FromArgb(249, 250, 251)
        }
        Me.Controls.Add(mainBg)
        mainBg.SendToBack()

        '  DECORATIVE BLOBS 
        Dim blob1 As New Panel With {
            .Size = New Size(400, 400),
            .Location = New Point(-150, 80),
            .BackColor = Color.FromArgb(35, 167, 139, 250)
        }
        AddCircleShape(blob1)
        mainBg.Controls.Add(blob1)

        Dim blob2 As New Panel With {
            .Size = New Size(320, 320),
            .Location = New Point(500, 420),
            .BackColor = Color.FromArgb(30, 251, 146, 60)
        }
        AddCircleShape(blob2)
        mainBg.Controls.Add(blob2)

        Dim blob3 As New Panel With {
            .Size = New Size(280, 280),
            .Location = New Point(280, -80),
            .BackColor = Color.FromArgb(30, 236, 72, 153)
        }
        AddCircleShape(blob3)
        mainBg.Controls.Add(blob3)

        '  KONTEN KIRI 

        ' Label1 - Bingung Pilih Topik Skripsi?
        Label1.Font = New Font("Segoe UI", 38, FontStyle.Bold)
        Label1.Location = New Point(80, 140)
        Label1.Size = New Size(650, 90)
        Label1.ForeColor = Color.FromArgb(17, 24, 39)
        Label1.BackColor = Color.Transparent
        Label1.Text = "Bingung Pilih Topik Skripsi?"

        ' Label2 - Kami Punya Solusinya
        Label2.Font = New Font("Segoe UI", 38, FontStyle.Bold)
        Label2.Location = New Point(80, 225)
        Label2.Size = New Size(650, 90)
        Label2.ForeColor = Color.FromArgb(99, 102, 241)
        Label2.BackColor = Color.Transparent
        Label2.Text = "Kami Punya Solusinya"

        ' Label3 - Deskripsi
        Label3.Font = New Font("Segoe UI", 15)
        Label3.Location = New Point(80, 330)
        Label3.Size = New Size(600, 55)
        Label3.ForeColor = Color.FromArgb(75, 85, 99)
        Label3.BackColor = Color.Transparent
        Label3.Text = "Temukan topik skripsi yang sempurna dengan bantuan AI dan rekomendasi yang dipersonalisasi"

        '  FITUR CARDS 
        Dim featureY As Integer = 420

        Dim featureCardBg As New Panel With {
            .Location = New Point(80, featureY),
            .Size = New Size(600, 250),
            .BackColor = Color.FromArgb(250, 255, 255, 255)
        }
        AddRoundedCorners(featureCardBg, 20)
        AddSoftShadow(featureCardBg)
        Me.Controls.Add(featureCardBg)

        ' Fitur 1
        Dim icon1Bg As New Panel With {
            .Location = New Point(110, featureY + 40),
            .Size = New Size(48, 48),
            .BackColor = Color.FromArgb(240, 253, 244)
        }
        AddRoundedCorners(icon1Bg, 12)
        Me.Controls.Add(icon1Bg)

        Dim icon1 As New Label With {
            .Text = "✓",
            .Font = New Font("Segoe UI", 20, FontStyle.Bold),
            .Location = New Point(110, featureY + 40),
            .Size = New Size(48, 48),
            .ForeColor = Color.FromArgb(16, 185, 129),
            .BackColor = Color.Transparent,
            .TextAlign = ContentAlignment.MiddleCenter
        }
        Me.Controls.Add(icon1)

        Label8.Font = New Font("Segoe UI", 13, FontStyle.Regular)
        Label8.BackColor = Color.Transparent
        Label8.Location = New Point(175, featureY + 48)
        Label8.Size = New Size(480, 35)
        Label8.ForeColor = Color.FromArgb(31, 41, 55)
        Label8.Text = "Rekomendasi topik berdasarkan minat dan keahlianmu"

        ' Fitur 2
        Dim icon2Bg As New Panel With {
            .Location = New Point(110, featureY + 110),
            .Size = New Size(48, 48),
            .BackColor = Color.FromArgb(240, 253, 244)
        }
        AddRoundedCorners(icon2Bg, 12)
        Me.Controls.Add(icon2Bg)

        Dim icon2 As New Label With {
            .Text = "✓",
            .Font = New Font("Segoe UI", 20, FontStyle.Bold),
            .Location = New Point(110, featureY + 110),
            .Size = New Size(48, 48),
            .ForeColor = Color.FromArgb(16, 185, 129),
            .BackColor = Color.Transparent,
            .TextAlign = ContentAlignment.MiddleCenter
        }
        Me.Controls.Add(icon2)

        Label7.Font = New Font("Segoe UI", 13, FontStyle.Regular)
        Label7.Location = New Point(175, featureY + 118)
        Label7.Size = New Size(480, 35)
        Label7.ForeColor = Color.FromArgb(31, 41, 55)
        Label7.BackColor = Color.Transparent
        Label7.Text = "Analisis tren penelitian terkini dengan AI"

        ' Fitur 3
        Dim icon3Bg As New Panel With {
            .Location = New Point(110, featureY + 180),
            .Size = New Size(48, 48),
            .BackColor = Color.FromArgb(240, 253, 244)
        }
        AddRoundedCorners(icon3Bg, 12)
        Me.Controls.Add(icon3Bg)

        Dim icon3 As New Label With {
            .Text = "✓",
            .Font = New Font("Segoe UI", 20, FontStyle.Bold),
            .Location = New Point(110, featureY + 180),
            .Size = New Size(48, 48),
            .ForeColor = Color.FromArgb(16, 185, 129),
            .BackColor = Color.Transparent,
            .TextAlign = ContentAlignment.MiddleCenter
        }
        Me.Controls.Add(icon3)

        Label9.Font = New Font("Segoe UI", 13, FontStyle.Regular)
        Label9.BackColor = Color.Transparent
        Label9.Location = New Point(175, featureY + 188)
        Label9.Size = New Size(480, 35)
        Label9.ForeColor = Color.FromArgb(31, 41, 55)
        Label9.Text = "Simpan dan kelola ide topik skripsimu"

        ' === PANEL KANAN - LOGIN CARD ===

        ' Glass effect background
        Dim glassBase As New Panel With {
            .Location = New Point(780, 140),
            .Size = New Size(500, 560),
            .BackColor = Color.FromArgb(255, 255, 255)
        }
        AddRoundedCorners(glassBase, 24)
        AddSoftShadow(glassBase)
        Me.Controls.Add(glassBase)

        ' Top accent line
        Dim topAccent As New Panel With {
            .Location = New Point(780, 140),
            .Size = New Size(500, 4),
            .BackColor = Color.FromArgb(99, 102, 241)
        }
        AddRoundedCorners(topAccent, 24)
        Me.Controls.Add(topAccent)

        ' Label10 - Mulai Sekarang
        Label10.Font = New Font("Segoe UI", 32, FontStyle.Bold)
        Label10.Location = New Point(820, 190)
        Label10.Size = New Size(420, 60)
        Label10.ForeColor = Color.FromArgb(17, 24, 39)
        Label10.TextAlign = ContentAlignment.MiddleCenter
        Label10.BackColor = Color.Transparent
        Label10.Text = "Mulai Sekarang"

        ' Label4 - Pilih Untuk Melanjutkan
        Label4.Font = New Font("Segoe UI", 13)
        Label4.Location = New Point(820, 255)
        Label4.Size = New Size(420, 30)
        Label4.ForeColor = Color.FromArgb(107, 114, 128)
        Label4.TextAlign = ContentAlignment.MiddleCenter
        Label4.BackColor = Color.Transparent
        Label4.Text = "Pilih untuk melanjutkan"

        ' Button1 - Sign In
        Button1.Font = New Font("Segoe UI", 15, FontStyle.Bold)
        Button1.Location = New Point(840, 320)
        Button1.Size = New Size(380, 58)
        Button1.BackColor = Color.FromArgb(99, 102, 241)
        Button1.ForeColor = Color.White
        Button1.FlatStyle = FlatStyle.Flat
        Button1.FlatAppearance.BorderSize = 0
        Button1.Cursor = Cursors.Hand
        Button1.Text = "Sign In →"
        AddRoundedCorners(Button1, 12)
        AddHandler Button1.MouseEnter, Sub()
                                           Button1.BackColor = Color.FromArgb(79, 70, 229)
                                       End Sub
        AddHandler Button1.MouseLeave, Sub()
                                           Button1.BackColor = Color.FromArgb(99, 102, 241)
                                       End Sub

        ' Label5 - Belum punya akun?
        Label5.Font = New Font("Segoe UI", 11)
        Label5.Location = New Point(840, 390)
        Label5.Size = New Size(380, 28)
        Label5.ForeColor = Color.FromArgb(107, 114, 128)
        Label5.TextAlign = ContentAlignment.MiddleCenter
        Label5.BackColor = Color.Transparent
        Label5.Cursor = Cursors.Hand
        Label5.Text = "Belum punya akun? Daftar di sini"
        AddHandler Label5.MouseEnter, Sub()
                                          Label5.ForeColor = Color.FromArgb(99, 102, 241)
                                          Label5.Font = New Font("Segoe UI", 11, FontStyle.Underline)
                                      End Sub
        AddHandler Label5.MouseLeave, Sub()
                                          Label5.ForeColor = Color.FromArgb(107, 114, 128)
                                          Label5.Font = New Font("Segoe UI", 11)
                                      End Sub

        Dim divLine1 As New Panel With {
            .Location = New Point(840, 453),
            .Size = New Size(170, 2),
            .BackColor = Color.FromArgb(229, 231, 235)
        }
        Me.Controls.Add(divLine1)

        Dim orLabel As New Label With {
            .Text = "ATAU",
            .Font = New Font("Segoe UI", 11, FontStyle.Bold),
            .Location = New Point(1020, 442),
            .Size = New Size(60, 24),
            .ForeColor = Color.FromArgb(156, 163, 175),
            .TextAlign = ContentAlignment.MiddleCenter,
            .BackColor = Color.Transparent
        }
        Me.Controls.Add(orLabel)

        Dim divLine2 As New Panel With {
            .Location = New Point(1090, 453),
            .Size = New Size(170, 2),
            .BackColor = Color.FromArgb(229, 231, 235)
        }
        Me.Controls.Add(divLine2)

        ' Button2 - Log In
        Button2.Font = New Font("Segoe UI", 15, FontStyle.Bold)
        Button2.Location = New Point(840, 495)
        Button2.Size = New Size(380, 58)
        Button2.BackColor = Color.White
        Button2.ForeColor = Color.FromArgb(99, 102, 241)
        Button2.FlatStyle = FlatStyle.Flat
        Button2.FlatAppearance.BorderColor = Color.FromArgb(99, 102, 241)
        Button2.FlatAppearance.BorderSize = 2
        Button2.Cursor = Cursors.Hand
        Button2.Text = "Log In ←"
        AddRoundedCorners(Button2, 12)
        AddHandler Button2.MouseEnter, Sub()
                                           Button2.BackColor = Color.FromArgb(238, 242, 255)
                                       End Sub
        AddHandler Button2.MouseLeave, Sub()
                                           Button2.BackColor = Color.White
                                       End Sub

        ' Label6 - Sudah punya akun?
        Label6.Font = New Font("Segoe UI", 11)
        Label6.Location = New Point(840, 565)
        Label6.Size = New Size(380, 28)
        Label6.ForeColor = Color.FromArgb(107, 114, 128)
        Label6.TextAlign = ContentAlignment.MiddleCenter
        Label6.BackColor = Color.Transparent
        Label6.Cursor = Cursors.Hand
        Label6.Text = "Sudah punya akun? Masuk di sini"
        AddHandler Label6.MouseEnter, Sub()
                                          Label6.ForeColor = Color.FromArgb(99, 102, 241)
                                          Label6.Font = New Font("Segoe UI", 11, FontStyle.Underline)
                                      End Sub
        AddHandler Label6.MouseLeave, Sub()
                                          Label6.ForeColor = Color.FromArgb(107, 114, 128)
                                          Label6.Font = New Font("Segoe UI", 11)
                                      End Sub

        Label1.BringToFront()
        Label2.BringToFront()
        Label3.BringToFront()
        Label8.BringToFront()
        Label7.BringToFront()
        Label9.BringToFront()
        icon1.BringToFront()
        icon2.BringToFront()
        icon3.BringToFront()
        topAccent.BringToFront()
        Label10.BringToFront()
        Label4.BringToFront()
        Button1.BringToFront()
        Label5.BringToFront()
        divLine1.BringToFront()
        orLabel.BringToFront()
        divLine2.BringToFront()
        Button2.BringToFront()
        Label6.BringToFront()
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

    Private Sub AddSoftShadow(ctrl As Control)
        Dim shadow As New Panel With {
            .Size = New Size(ctrl.Width + 6, ctrl.Height + 6),
            .Location = New Point(ctrl.Location.X + 3, ctrl.Location.Y + 3),
            .BackColor = Color.FromArgb(15, 0, 0, 0)
        }
        AddRoundedCorners(shadow, 24)
        Me.Controls.Add(shadow)
        shadow.SendToBack()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Dim daftar As New Form2

        daftar.Show()
        Me.Hide()
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Dim masuk As New Form1
        masuk.Show()
        Me.Hide()
    End Sub
End Class