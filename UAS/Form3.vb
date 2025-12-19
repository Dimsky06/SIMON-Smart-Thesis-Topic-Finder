Imports Microsoft.Data.SqlClient

Public Class Form3
    ' FIELDS & PROPERTIES
    Public Property CurrentUser As UserModel

    Private indexPertanyaan As Integer = 0
    Private daftarPertanyaan As New List(Of String)
    Private daftarKode As New List(Of String)
    Private jawabanUser As New Dictionary(Of String, Boolean?)
    Private isLoading As Boolean = True

    ' UI Elements
    Private headerTitle As Label
    Private subtitleLabel As Label
    Private questionContainer As Panel
    Private questionBadge As Label
    Private questionNumberLabel As Label
    Private answerContainer As FlowLayoutPanel
    Private radioYaContainer As Panel
    Private radioTidakContainer As Panel
    Private progressLabel As Label
    Private progressPercentLabel As Label
    Private navButtonContainer As FlowLayoutPanel
    Private yaIcon As Label
    Private tidakIcon As Label
    Private questionTitle As Label
    Private answerTitleLabel As Label
    Private decorLine As Panel

    ' Design Constants
    Private Const FORM_WIDTH As Integer = 1400
    Private Const FORM_HEIGHT As Integer = 900
    Private Const CONTENT_WIDTH As Integer = 1000
    Private Const MARGIN_HORIZONTAL As Integer = 200

    ' Color Palette
    Private ReadOnly COLOR_PRIMARY As Color = Color.FromArgb(99, 102, 241)
    Private ReadOnly COLOR_PRIMARY_DARK As Color = Color.FromArgb(79, 70, 229)
    Private ReadOnly COLOR_PRIMARY_LIGHT As Color = Color.FromArgb(238, 242, 255)
    Private ReadOnly COLOR_SUCCESS As Color = Color.FromArgb(16, 185, 129)
    Private ReadOnly COLOR_DANGER As Color = Color.FromArgb(239, 68, 68)
    Private ReadOnly COLOR_TEXT_PRIMARY As Color = Color.FromArgb(17, 24, 39)
    Private ReadOnly COLOR_TEXT_SECONDARY As Color = Color.FromArgb(107, 114, 128)
    Private ReadOnly COLOR_BACKGROUND As Color = Color.FromArgb(249, 250, 251)
    Private ReadOnly COLOR_CARD As Color = Color.White

    ' FORM LOAD & INITIALIZATION
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeForm()
        InitializeUIComponents()
        LoadQuestionsFromDatabase()

        If CurrentUser IsNot Nothing Then
            Me.Text = $"SIMON - Konsultasi ({CurrentUser.NamaDepan})"
        End If
    End Sub

    Private Sub InitializeForm()
        Me.Size = New Size(FORM_WIDTH, FORM_HEIGHT)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.BackColor = COLOR_BACKGROUND
        Me.FormBorderStyle = FormBorderStyle.Sizable
        Me.MinimumSize = New Size(1200, 800)
        Me.Text = "SIMON - Konsultasi Expert System"
    End Sub

    Private Sub InitializeUIComponents()
        CreateHeaderSection()
        CreateQuestionSection()
        CreateAnswerSection()
        CreateProgressBar()
        CreateNavigationButtons()
    End Sub

    Private Sub CreateHeaderSection()
        Dim topBar As New Panel With {
            .Location = New Point(0, 0),
            .Size = New Size(Me.ClientSize.Width, 4),
            .BackColor = COLOR_PRIMARY,
            .Dock = DockStyle.Top
        }
        Me.Controls.Add(topBar)

        headerTitle = New Label With {
            .Text = "Expert System Topik Skripsi",
            .Font = New Font("Segoe UI", 28, FontStyle.Bold),
            .Location = New Point(MARGIN_HORIZONTAL, 40),
            .Size = New Size(CONTENT_WIDTH, 50),
            .ForeColor = COLOR_TEXT_PRIMARY,
            .BackColor = Color.Transparent,
            .TextAlign = ContentAlignment.TopCenter
        }
        Me.Controls.Add(headerTitle)

        subtitleLabel = New Label With {
            .Text = "Temukan topik skripsi yang sesuai dengan minat Anda",
            .Font = New Font("Segoe UI", 12, FontStyle.Regular),
            .Location = New Point(MARGIN_HORIZONTAL, 95),
            .Size = New Size(CONTENT_WIDTH, 25),
            .ForeColor = COLOR_TEXT_SECONDARY,
            .BackColor = Color.Transparent,
            .TextAlign = ContentAlignment.TopCenter
        }
        Me.Controls.Add(subtitleLabel)

        decorLine = New Panel With {
            .Location = New Point(MARGIN_HORIZONTAL + 400, 130),
            .Size = New Size(200, 3),
            .BackColor = COLOR_PRIMARY
        }
        Me.Controls.Add(decorLine)
    End Sub

    Private Sub CreateQuestionSection()
        questionNumberLabel = New Label With {
            .Font = New Font("Segoe UI", 10, FontStyle.Bold),
            .Location = New Point(MARGIN_HORIZONTAL, 160),
            .Size = New Size(180, 28),
            .ForeColor = COLOR_PRIMARY,
            .BackColor = COLOR_PRIMARY_LIGHT,
            .TextAlign = ContentAlignment.MiddleCenter
        }
        AddRoundedCorners(questionNumberLabel, 6)
        Me.Controls.Add(questionNumberLabel)

        questionContainer = New Panel With {
            .Location = New Point(MARGIN_HORIZONTAL, 200),
            .Size = New Size(CONTENT_WIDTH, 200),
            .BackColor = COLOR_CARD
        }
        AddRoundedCorners(questionContainer, 16)
        AddEnhancedShadow(questionContainer)
        Me.Controls.Add(questionContainer)

        questionBadge = New Label With {
            .Text = "?",
            .Font = New Font("Segoe UI", 24, FontStyle.Bold),
            .Location = New Point(30, 20),
            .Size = New Size(50, 50),
            .ForeColor = COLOR_PRIMARY,
            .BackColor = COLOR_PRIMARY_LIGHT,
            .TextAlign = ContentAlignment.MiddleCenter,
            .Parent = questionContainer
        }
        AddRoundedCorners(questionBadge, 25)

        questionTitle = New Label With {
            .Text = "Pertanyaan",
            .Font = New Font("Segoe UI", 11, FontStyle.Bold),
            .Location = New Point(95, 30),
            .Size = New Size(120, 25),
            .ForeColor = COLOR_TEXT_PRIMARY,
            .BackColor = Color.Transparent,
            .Parent = questionContainer
        }

        Label5.Font = New Font("Segoe UI", 16, FontStyle.Regular)
        Label5.Location = New Point(30, 85)
        Label5.Size = New Size(940, 100)
        Label5.ForeColor = COLOR_TEXT_PRIMARY
        Label5.BackColor = Color.Transparent
        Label5.TextAlign = ContentAlignment.MiddleCenter
        Label5.Parent = questionContainer
    End Sub

    Private Sub CreateAnswerSection()
        answerTitleLabel = New Label With {
            .Text = "Pilih Jawaban Anda",
            .Font = New Font("Segoe UI", 12, FontStyle.Bold),
            .Location = New Point(MARGIN_HORIZONTAL, 420),
            .Size = New Size(CONTENT_WIDTH, 25),
            .ForeColor = COLOR_TEXT_PRIMARY,
            .BackColor = Color.Transparent,
            .TextAlign = ContentAlignment.TopCenter
        }
        Me.Controls.Add(answerTitleLabel)

        answerContainer = New FlowLayoutPanel With {
            .Location = New Point(MARGIN_HORIZONTAL + 265, 460),
            .Size = New Size(470, 90),
            .FlowDirection = FlowDirection.LeftToRight,
            .BackColor = Color.Transparent,
            .WrapContents = False
        }
        Me.Controls.Add(answerContainer)

        radioYaContainer = New Panel With {
            .Size = New Size(215, 85),
            .BackColor = COLOR_CARD,
            .Margin = New Padding(0, 0, 40, 0),
            .Cursor = Cursors.Hand
        }
        AddRoundedCorners(radioYaContainer, 12)
        AddCardShadow(radioYaContainer)
        answerContainer.Controls.Add(radioYaContainer)

        yaIcon = New Label With {
            .Text = "✓",
            .Font = New Font("Segoe UI", 32, FontStyle.Bold),
            .Location = New Point(25, 15),
            .Size = New Size(50, 50),
            .ForeColor = COLOR_SUCCESS,
            .BackColor = Color.Transparent,
            .TextAlign = ContentAlignment.MiddleCenter,
            .Parent = radioYaContainer
        }

        RadioButton1.Parent = radioYaContainer
        RadioButton1.Location = New Point(85, 20)
        RadioButton1.Size = New Size(120, 45)
        RadioButton1.Font = New Font("Segoe UI", 16, FontStyle.Bold)
        RadioButton1.Text = "Ya"
        RadioButton1.ForeColor = COLOR_SUCCESS
        RadioButton1.BackColor = Color.Transparent
        RadioButton1.Cursor = Cursors.Hand

        radioTidakContainer = New Panel With {
            .Size = New Size(215, 85),
            .BackColor = COLOR_CARD,
            .Cursor = Cursors.Hand
        }
        AddRoundedCorners(radioTidakContainer, 12)
        AddCardShadow(radioTidakContainer)
        answerContainer.Controls.Add(radioTidakContainer)

        tidakIcon = New Label With {
            .Text = "✕",
            .Font = New Font("Segoe UI", 32, FontStyle.Bold),
            .Location = New Point(25, 15),
            .Size = New Size(50, 50),
            .ForeColor = COLOR_DANGER,
            .BackColor = Color.Transparent,
            .TextAlign = ContentAlignment.MiddleCenter,
            .Parent = radioTidakContainer
        }

        RadioButton2.Parent = radioTidakContainer
        RadioButton2.Location = New Point(85, 20)
        RadioButton2.Size = New Size(120, 45)
        RadioButton2.Font = New Font("Segoe UI", 16, FontStyle.Bold)
        RadioButton2.Text = "Tidak"
        RadioButton2.ForeColor = COLOR_DANGER
        RadioButton2.BackColor = Color.Transparent
        RadioButton2.Cursor = Cursors.Hand

        AddHandler radioYaContainer.MouseEnter, Sub() radioYaContainer.BackColor = Color.FromArgb(240, 253, 244)
        AddHandler radioYaContainer.MouseLeave, Sub() radioYaContainer.BackColor = COLOR_CARD
        AddHandler radioTidakContainer.MouseEnter, Sub() radioTidakContainer.BackColor = Color.FromArgb(254, 242, 242)
        AddHandler radioTidakContainer.MouseLeave, Sub() radioTidakContainer.BackColor = COLOR_CARD

        AddHandler radioYaContainer.Click, Sub() RadioButton1.Checked = True
        AddHandler radioTidakContainer.Click, Sub() RadioButton2.Checked = True
        AddHandler yaIcon.Click, Sub() RadioButton1.Checked = True
        AddHandler tidakIcon.Click, Sub() RadioButton2.Checked = True
    End Sub

    Private Sub CreateProgressBar()
        progressLabel = New Label With {
            .Text = "Progress Konsultasi",
            .Font = New Font("Segoe UI", 10, FontStyle.Bold),
            .Location = New Point(MARGIN_HORIZONTAL, 580),
            .Size = New Size(150, 22),
            .ForeColor = COLOR_TEXT_PRIMARY,
            .BackColor = Color.Transparent
        }
        Me.Controls.Add(progressLabel)

        progressPercentLabel = New Label With {
            .Text = "0%",
            .Font = New Font("Segoe UI", 10, FontStyle.Bold),
            .Location = New Point(MARGIN_HORIZONTAL + 850, 580),
            .Size = New Size(150, 22),
            .ForeColor = COLOR_PRIMARY,
            .BackColor = Color.Transparent,
            .TextAlign = ContentAlignment.TopRight
        }
        Me.Controls.Add(progressPercentLabel)

        Dim progressBg As New Panel With {
            .Location = New Point(MARGIN_HORIZONTAL, 610),
            .Size = New Size(CONTENT_WIDTH, 12),
            .BackColor = Color.FromArgb(229, 231, 235)
        }
        AddRoundedCorners(progressBg, 6)
        Me.Controls.Add(progressBg)

        ProgressBar1.Location = New Point(MARGIN_HORIZONTAL, 610)
        ProgressBar1.Size = New Size(CONTENT_WIDTH, 12)
        ProgressBar1.Style = ProgressBarStyle.Continuous
        ProgressBar1.ForeColor = COLOR_PRIMARY
        ProgressBar1.BringToFront()
    End Sub

    Private Sub CreateNavigationButtons()
        navButtonContainer = New FlowLayoutPanel With {
            .Location = New Point(MARGIN_HORIZONTAL + 290, 660),
            .Size = New Size(420, 70),
            .FlowDirection = FlowDirection.LeftToRight,
            .BackColor = Color.Transparent,
            .WrapContents = False
        }
        Me.Controls.Add(navButtonContainer)

        ConfigurePreviousButton()
        navButtonContainer.Controls.Add(Button1)

        Dim spacer As New Panel With {.Size = New Size(20, 60), .BackColor = Color.Transparent}
        navButtonContainer.Controls.Add(spacer)

        ConfigureNextButton()
        navButtonContainer.Controls.Add(Button2)
    End Sub

    Private Sub ConfigurePreviousButton()
        Button1.Size = New Size(200, 55)
        Button1.Font = New Font("Segoe UI", 13, FontStyle.Bold)
        Button1.Text = "← Sebelumnya"
        Button1.BackColor = COLOR_CARD
        Button1.ForeColor = COLOR_PRIMARY
        Button1.FlatStyle = FlatStyle.Flat
        Button1.FlatAppearance.BorderColor = COLOR_PRIMARY
        Button1.FlatAppearance.BorderSize = 2
        Button1.Cursor = Cursors.Hand
        Button1.Margin = New Padding(0)
        AddRoundedCorners(Button1, 10)

        AddHandler Button1.MouseEnter, Sub() Button1.BackColor = COLOR_PRIMARY_LIGHT
        AddHandler Button1.MouseLeave, Sub() Button1.BackColor = COLOR_CARD
    End Sub

    Private Sub ConfigureNextButton()
        Button2.Size = New Size(200, 55)
        Button2.Font = New Font("Segoe UI", 13, FontStyle.Bold)
        Button2.Text = "Selanjutnya →"
        Button2.BackColor = COLOR_PRIMARY
        Button2.ForeColor = Color.White
        Button2.FlatStyle = FlatStyle.Flat
        Button2.FlatAppearance.BorderSize = 0
        Button2.Cursor = Cursors.Hand
        Button2.Margin = New Padding(0)
        AddRoundedCorners(Button2, 10)

        AddHandler Button2.MouseEnter, Sub() Button2.BackColor = COLOR_PRIMARY_DARK
        AddHandler Button2.MouseLeave, Sub() Button2.BackColor = COLOR_PRIMARY
    End Sub

    Private Sub LoadQuestionsFromDatabase()
        Try
            isLoading = True
            Using conn As SqlConnection = GetConnection()
                conn.Open()
                Dim sql As String = "SELECT kode_gejala, teks_pertanyaan FROM pertanyaan ORDER BY id_pertanyaan ASC"
                Using cmd As New SqlCommand(sql, conn)
                    Using rd = cmd.ExecuteReader()
                        While rd.Read()
                            daftarKode.Add(rd("kode_gejala").ToString())
                            daftarPertanyaan.Add(rd("teks_pertanyaan").ToString())
                        End While
                    End Using
                End Using
            End Using

            If daftarPertanyaan.Count = 0 Then
                MessageBox.Show("Tabel pertanyaan kosong! Tambahkan data terlebih dahulu.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
                Exit Sub
            End If

            For Each kode In daftarKode
                jawabanUser(kode) = Nothing
            Next

            ProgressBar1.Minimum = 0
            ProgressBar1.Maximum = daftarPertanyaan.Count
            TampilkanPertanyaan()
            isLoading = False
        Catch ex As Exception
            MessageBox.Show("Error saat memuat pertanyaan: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub TampilkanPertanyaan()
        isLoading = True
        Dim currentNum = indexPertanyaan + 1
        Dim totalNum = daftarPertanyaan.Count
        questionNumberLabel.Text = $"Pertanyaan {currentNum} dari {totalNum}"
        Label5.Text = daftarPertanyaan(indexPertanyaan)
        RadioButton1.Checked = False
        RadioButton2.Checked = False

        Dim kode = daftarKode(indexPertanyaan)
        If jawabanUser(kode).HasValue Then
            If jawabanUser(kode).Value = True Then
                RadioButton1.Checked = True
            Else
                RadioButton2.Checked = True
            End If
        End If

        Button1.Enabled = (indexPertanyaan > 0)
        Button2.Text = If(indexPertanyaan = daftarPertanyaan.Count - 1, "Selesai ✓", "Selanjutnya →")
        ProgressBar1.Value = indexPertanyaan
        Dim percentage = CInt((indexPertanyaan / daftarPertanyaan.Count) * 100)
        progressPercentLabel.Text = $"{percentage}%"
        isLoading = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If indexPertanyaan = 0 Then Exit Sub
        indexPertanyaan -= 1
        TampilkanPertanyaan()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Not RadioButton1.Checked AndAlso Not RadioButton2.Checked Then
            MessageBox.Show("Silakan pilih jawaban terlebih dahulu sebelum melanjutkan.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim kode = daftarKode(indexPertanyaan)
        jawabanUser(kode) = RadioButton1.Checked
        indexPertanyaan += 1

        If indexPertanyaan >= daftarPertanyaan.Count Then
            ShowResults()
        Else
            TampilkanPertanyaan()
        End If
    End Sub

    Private Sub ShowResults()
        Dim jawaban = jawabanUser.ToDictionary(Function(x) x.Key, Function(x) x.Value.Value)
        Dim f4 As New Form4(jawaban)
        If CurrentUser IsNot Nothing Then
            f4.CurrentUser = Me.CurrentUser
        End If
        f4.Show()
        Me.Close()
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

    Private Sub AddCardShadow(ctrl As Panel)
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        ' Kembali ke Menu Utama
        Dim f6 As New Form6
        If CurrentUser IsNot Nothing Then f6.CurrentUser = Me.CurrentUser
        f6.Show()
        Me.Close()
    End Sub

    Private Sub RiwayatKonsultasiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RiwayatKonsultasiToolStripMenuItem.Click
        ' Ke Riwayat (Form8)
        Dim f8 As New Form8
        If CurrentUser IsNot Nothing Then f8.CurrentUser = Me.CurrentUser
        f8.Show()
        Me.Close()
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        ' Tombol Profile
        Dim f9 As New Form9
        If CurrentUser IsNot Nothing Then f9.CurrentUser = Me.CurrentUser
        f9.Show()
        Me.Close()
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub ToolStripDropDownButton1_Click(sender As Object, e As EventArgs) Handles ToolStripDropDownButton1.Click

    End Sub

    Private Sub MulaiKonsultasiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MulaiKonsultasiToolStripMenuItem.Click

    End Sub
End Class