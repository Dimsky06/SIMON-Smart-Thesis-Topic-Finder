Imports System.Data.SqlClient
Imports System.Drawing.Printing
Imports Microsoft.Data.SqlClient

Public Class Form4

    Public Property CurrentUser As UserModel

    Private jawabanUser As Dictionary(Of String, Boolean)
    Private pertanyaanDict As New Dictionary(Of String, String)
    Private hasilJudul As String = ""
    Private hasilDeskripsi As String = ""
    Private hasilKodeRule As String = ""

    Private WithEvents printDoc As New PrintDocument
    Private preview As PrintPreviewDialog

    ' Constructor menerima data G1-G5
    Public Sub New(jawab As Dictionary(Of String, Boolean))
        InitializeComponent()
        jawabanUser = jawab
    End Sub

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Pengaturan Form
        Me.Size = New Size(1400, 850)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.BackColor = Color.FromArgb(249, 250, 251)
        Me.FormBorderStyle = FormBorderStyle.Sizable
        Me.Text = "SIMON - Hasil Konsultasi"

        ' MAIN CONTENT CARD
        Dim contentCard As New Panel With {
            .Location = New Point(150, 100),
            .Size = New Size(1100, 580),
            .BackColor = Color.White
        }
        AddRoundedCorners(contentCard, 20)
        AddEnhancedShadow(contentCard)
        Me.Controls.Add(contentCard)

        Dim topAccent As New Panel With {
            .Location = New Point(150, 100),
            .Size = New Size(1100, 5),
            .BackColor = Color.FromArgb(16, 185, 129)
        }
        AddRoundedCorners(topAccent, 20)
        Me.Controls.Add(topAccent)
        topAccent.BringToFront()

        '  HEADER SECTION 
        Dim headerTitle As New Label With {
            .Text = "Expert System Topik Skripsi",
            .Font = New Font("Segoe UI", 24, FontStyle.Bold),
            .Location = New Point(200, 130),
            .Size = New Size(1000, 40),
            .ForeColor = Color.FromArgb(17, 24, 39),
            .BackColor = Color.Transparent,
            .TextAlign = ContentAlignment.TopCenter
        }
        Me.Controls.Add(headerTitle)
        headerTitle.BringToFront()

        Dim subtitle As New Label With {
            .Text = "Hasil Konsultasi",
            .Font = New Font("Segoe UI", 13, FontStyle.Regular),
            .Location = New Point(200, 175),
            .Size = New Size(1000, 25),
            .ForeColor = Color.FromArgb(16, 185, 129),
            .BackColor = Color.Transparent,
            .TextAlign = ContentAlignment.TopCenter
        }
        Me.Controls.Add(subtitle)
        subtitle.BringToFront()

        ' Success badge
        Dim successBadge As New Panel With {
            .Location = New Point(630, 215),
            .Size = New Size(140, 36),
            .BackColor = Color.FromArgb(220, 252, 231)
        }
        AddRoundedCorners(successBadge, 18)
        Me.Controls.Add(successBadge)
        successBadge.BringToFront()

        Dim checkIcon As New Label With {
            .Text = "✓ Selesai",
            .Font = New Font("Segoe UI", 11, FontStyle.Bold),
            .Location = New Point(645, 222),
            .Size = New Size(110, 22),
            .ForeColor = Color.FromArgb(16, 185, 129),
            .BackColor = Color.Transparent,
            .TextAlign = ContentAlignment.MiddleCenter
        }
        Me.Controls.Add(checkIcon)
        checkIcon.BringToFront()

        '  RESULT CONTAINER 
        Dim resultContainer As New Panel With {
            .Location = New Point(220, 280),
            .Size = New Size(960, 310),
            .BackColor = Color.FromArgb(249, 250, 251)
        }
        AddRoundedCorners(resultContainer, 14)
        Me.Controls.Add(resultContainer)
        resultContainer.BringToFront()

        ' Result title badge
        Dim resultBadge As New Label With {
            .Text = "🎯 Rekomendasi Topik",
            .Font = New Font("Segoe UI", 10, FontStyle.Bold),
            .Location = New Point(230, 267),
            .Size = New Size(180, 26),
            .ForeColor = Color.FromArgb(99, 102, 241),
            .BackColor = Color.White,
            .TextAlign = ContentAlignment.MiddleCenter
        }
        AddRoundedCorners(resultBadge, 6)
        Me.Controls.Add(resultBadge)
        resultBadge.BringToFront()

        ' Label3 - Judul Topik
        Label3.Font = New Font("Segoe UI", 20, FontStyle.Bold)
        Label3.Location = New Point(250, 310)
        Label3.Size = New Size(900, 50)
        Label3.ForeColor = Color.FromArgb(17, 24, 39)
        Label3.BackColor = Color.Transparent
        Label3.TextAlign = ContentAlignment.TopCenter
        Label3.BringToFront()

        ' Divider line
        Dim divider As New Panel With {
            .Location = New Point(350, 370),
            .Size = New Size(700, 2),
            .BackColor = Color.FromArgb(229, 231, 235)
        }
        Me.Controls.Add(divider)
        divider.BringToFront()

        ' Description label
        Dim descLabel As New Label With {
            .Text = "Deskripsi Topik:",
            .Font = New Font("Segoe UI", 11, FontStyle.Bold),
            .Location = New Point(250, 385),
            .Size = New Size(900, 22),
            .ForeColor = Color.FromArgb(75, 85, 99),
            .BackColor = Color.Transparent
        }
        Me.Controls.Add(descLabel)
        descLabel.BringToFront()

        ' Label4 - Deskripsi
        Label4.Font = New Font("Segoe UI", 11, FontStyle.Regular)
        Label4.Location = New Point(250, 415)
        Label4.Size = New Size(900, 150)
        Label4.ForeColor = Color.FromArgb(55, 65, 81)
        Label4.BackColor = Color.Transparent
        Label4.BringToFront()

        '  ACTION BUTTONS 
        Dim buttonContainer As New FlowLayoutPanel With {
            .Location = New Point(430, 610),
            .Size = New Size(540, 60),
            .FlowDirection = FlowDirection.LeftToRight,
            .BackColor = Color.Transparent
        }
        Me.Controls.Add(buttonContainer)
        buttonContainer.BringToFront()

        ' Button2 - Kembali (left button)
        Button2.Size = New Size(260, 55)
        Button2.Font = New Font("Segoe UI", 13, FontStyle.Bold)
        Button2.Text = "← Kembali ke Menu"
        Button2.BackColor = Color.White
        Button2.ForeColor = Color.FromArgb(99, 102, 241)
        Button2.FlatStyle = FlatStyle.Flat
        Button2.FlatAppearance.BorderColor = Color.FromArgb(99, 102, 241)
        Button2.FlatAppearance.BorderSize = 2
        Button2.Cursor = Cursors.Hand
        Button2.Margin = New Padding(0, 0, 20, 0)
        AddRoundedCorners(Button2, 10)
        AddHandler Button2.MouseEnter, Sub()
                                           Button2.BackColor = Color.FromArgb(238, 242, 255)
                                       End Sub
        AddHandler Button2.MouseLeave, Sub()
                                           Button2.BackColor = Color.White
                                       End Sub
        buttonContainer.Controls.Add(Button2)

        ' Button1 - Print (right button)
        Button1.Size = New Size(260, 55)
        Button1.Font = New Font("Segoe UI", 13, FontStyle.Bold)
        Button1.Text = "🖨️ Print Hasil"
        Button1.BackColor = Color.FromArgb(99, 102, 241)
        Button1.ForeColor = Color.White
        Button1.FlatStyle = FlatStyle.Flat
        Button1.FlatAppearance.BorderSize = 0
        Button1.Cursor = Cursors.Hand
        Button1.Margin = New Padding(0)
        AddRoundedCorners(Button1, 10)
        AddHandler Button1.MouseEnter, Sub()
                                           Button1.BackColor = Color.FromArgb(79, 70, 229)
                                       End Sub
        AddHandler Button1.MouseLeave, Sub()
                                           Button1.BackColor = Color.FromArgb(99, 102, 241)
                                       End Sub
        buttonContainer.Controls.Add(Button1)

        ' Info note
        Dim infoNote As New Label With {
            .Text = "💡 Konsultasikan lebih lanjut dengan dosen pembimbing untuk hasil terbaik",
            .Font = New Font("Segoe UI", 10, FontStyle.Italic),
            .Location = New Point(200, 690),
            .Size = New Size(1000, 22),
            .ForeColor = Color.FromArgb(107, 114, 128),
            .BackColor = Color.Transparent,
            .TextAlign = ContentAlignment.TopCenter
        }
        Me.Controls.Add(infoNote)
        infoNote.BringToFront()
        Button1.BringToFront()
        Button2.BringToFront()

        ' LOAD DATA 
        AmbilPertanyaanDariDB()
        AmbilHasilAnalisis()
        TampilkanHasil()
        SimpanHasilKeDatabase()
        preview = New PrintPreviewDialog()
        preview.Document = printDoc
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

    Private Sub AmbilPertanyaanDariDB()
        Try
            Using conn As SqlConnection = GetConnection()
                conn.Open()
                Dim sql As String = "SELECT kode_gejala, teks_pertanyaan FROM pertanyaan ORDER BY id_pertanyaan ASC"
                Using cmd As New SqlCommand(sql, conn)
                    Using rd As SqlDataReader = cmd.ExecuteReader()
                        While rd.Read()
                            Dim kode As String = rd("kode_gejala").ToString()
                            Dim teks As String = rd("teks_pertanyaan").ToString()
                            pertanyaanDict(kode) = teks
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error mengambil pertanyaan: " & ex.Message)
        End Try
    End Sub

    Private Sub AmbilHasilAnalisis()
        Try
            Using conn As SqlConnection = GetConnection()
                conn.Open()
                Dim syaratList As New List(Of String)
                For Each kvp In jawabanUser
                    If kvp.Value Then
                        syaratList.Add(kvp.Key)
                    End If
                Next
                syaratList.Sort()
                Dim syaratString As String = String.Join(",", syaratList)

                Dim sql As String = "SELECT kode_rule, syarat, judul_topik, deskripsi_topik FROM rules WHERE syarat = @syarat"
                Using cmd As New SqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@syarat", syaratString)
                    Using rd As SqlDataReader = cmd.ExecuteReader()
                        If rd.Read() Then
                            hasilKodeRule = rd("kode_rule").ToString()
                            hasilJudul = rd("judul_topik").ToString()
                            hasilDeskripsi = rd("deskripsi_topik").ToString()
                        Else
                            hasilKodeRule = "N/A"
                            hasilJudul = "Tidak Ditemukan Rekomendasi"
                            hasilDeskripsi = "Maaf, kombinasi jawaban Anda tidak cocok dengan rule yang tersedia dalam sistem. Silakan konsultasikan dengan dosen pembimbing untuk mendapatkan rekomendasi topik yang sesuai."
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Gagal mengambil hasil: " & ex.Message)
            hasilKodeRule = "ERROR"
            hasilJudul = "Error"
            hasilDeskripsi = "Terjadi kesalahan dalam mengambil data: " & ex.Message
        End Try
    End Sub

    Private Sub SimpanHasilKeDatabase()
        ' Pastikan user sudah login agar id_user tersedia
        If CurrentUser Is Nothing Then Return

        Try
            Using conn As SqlConnection = GetConnection()
                conn.Open()

                ' Query INSERT sesuai dengan struktur tabel 'hasil' di Database1.mdf
                Dim sql As String = "INSERT INTO hasil (id_user, tanggal, g1, g2, g3, g4, g5, judul_topik, deskripsi_topik) " &
                                "VALUES (@uid, @tgl, @g1, @g2, @g3, @g4, @g5, @judul, @deskripsi)"

                Using cmd As New SqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@uid", CurrentUser.Id)
                    cmd.Parameters.AddWithValue("@tgl", DateTime.Now)

                    ' Mengambil nilai jawaban (True/False) dari dictionary jawabanUser
                    ' Pastikan kode gejala "G1", "G2" dst sesuai dengan yang ada di tabel pertanyaan
                    cmd.Parameters.AddWithValue("@g1", If(jawabanUser.ContainsKey("G1"), jawabanUser("G1"), False))
                    cmd.Parameters.AddWithValue("@g2", If(jawabanUser.ContainsKey("G2"), jawabanUser("G2"), False))
                    cmd.Parameters.AddWithValue("@g3", If(jawabanUser.ContainsKey("G3"), jawabanUser("G3"), False))
                    cmd.Parameters.AddWithValue("@g4", If(jawabanUser.ContainsKey("G4"), jawabanUser("G4"), False))
                    cmd.Parameters.AddWithValue("@g5", If(jawabanUser.ContainsKey("G5"), jawabanUser("G5"), False))

                    cmd.Parameters.AddWithValue("@judul", hasilJudul)
                    cmd.Parameters.AddWithValue("@deskripsi", hasilDeskripsi)

                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Gagal menyimpan riwayat: " & ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub TampilkanHasil()
        Label3.Text = hasilJudul
        Label4.Text = hasilDeskripsi
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If String.IsNullOrEmpty(hasilJudul) OrElse hasilJudul = "Tidak ditemukan" Then
                MessageBox.Show("Tidak ada data hasil analisis untuk dicetak.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            printDoc.DefaultPageSettings.Landscape = False
            printDoc.DefaultPageSettings.Margins = New Printing.Margins(50, 50, 50, 50)

            If preview Is Nothing Then
                preview = New PrintPreviewDialog()
            End If

            preview.Document = printDoc
            preview.PrintPreviewControl.Zoom = 1.0
            preview.WindowState = FormWindowState.Maximized
            preview.StartPosition = FormStartPosition.CenterScreen

            Dim result As DialogResult = preview.ShowDialog(Me)

        Catch ex As System.Drawing.Printing.InvalidPrinterException
            MessageBox.Show("Tidak ada printer yang terdeteksi. Preview tetap dapat ditampilkan." & vbCrLf & vbCrLf &
                          "Untuk mencetak, silakan install printer terlebih dahulu.",
                          "Info Printer", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & vbCrLf & vbCrLf & "Detail: " & ex.StackTrace,
                          "Error Print Preview", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub printDoc_PrintPage(sender As Object, e As PrintPageEventArgs) Handles printDoc.PrintPage
        CetakHalaman(e)
    End Sub

    Private Sub CetakHalaman(e As PrintPageEventArgs)
        Dim g As Graphics = e.Graphics
        Dim fontHeader As New Font("Arial", 14, FontStyle.Bold)
        Dim fontSubHeader As New Font("Arial", 11, FontStyle.Bold)
        Dim fontNormal As New Font("Arial", 10)
        Dim fontTableHeader As New Font("Arial", 10, FontStyle.Bold)
        Dim fontTable As New Font("Arial", 10)
        Dim fontSmall As New Font("Arial", 9)

        Dim centerFormat As New StringFormat()
        centerFormat.Alignment = StringAlignment.Center

        Dim x As Integer = 50
        Dim y As Integer = 40
        Dim pageWidth As Integer = e.PageBounds.Width - 100
        Dim centerX As Integer = e.PageBounds.Width / 2

        g.DrawString("POLITEKNIK NEGERI JAKARTA", fontHeader, Brushes.Black, centerX, y, centerFormat)
        y += 22
        g.DrawString("JURUSAN TEKNIK INFORMATIKA DAN KOMPUTER", fontSubHeader, Brushes.Black, centerX, y, centerFormat)
        y += 18
        g.DrawString("PROGRAM STUDI D-IV TEKNIK INFORMATIKA", fontNormal, Brushes.Black, centerX, y, centerFormat)
        y += 16
        g.DrawString("Jl. Prof. DR. G.A. Siwabessy, Kampus Baru UI Depok 16425", fontSmall, Brushes.Black, centerX, y, centerFormat)
        y += 14
        g.DrawString("Telp. (021) 7270036, 7863531, Fax. (021) 7270034", fontSmall, Brushes.Black, centerX, y, centerFormat)
        y += 14
        g.DrawString("Website: www.pnj.ac.id | Email: info@pnj.ac.id", fontSmall, Brushes.Black, centerX, y, centerFormat)
        y += 20

        Dim boxY As Integer = y
        g.DrawRectangle(Pens.Black, x, boxY, pageWidth, 2)
        y = boxY + 15

        Using pen As New Pen(Color.Black, 2)
            g.DrawLine(pen, x, y, x + pageWidth, y)
        End Using
        y += 30

        g.DrawString("LAPORAN HASIL KONSULTASI", fontHeader, Brushes.Black, centerX, y, centerFormat)
        y += 20
        g.DrawString("SISTEM PAKAR PEMILIHAN TOPIK SKRIPSI", fontSubHeader, Brushes.Black, centerX, y, centerFormat)
        y += 15

        Dim tanggalSekarang As String = DateTime.Now.ToString("dd MMMM yyyy")
        g.DrawString("Tanggal Konsultasi: " & tanggalSekarang, fontNormal, Brushes.Black, centerX, y, centerFormat)
        y += 40

        g.DrawString("DATA JAWABAN KONSULTASI", fontSubHeader, Brushes.Black, x, y)
        y += 25

        Dim tableX As Integer = x
        Dim colNo As Integer = 50
        Dim colGejala As Integer = 400
        Dim colJawaban As Integer = 100
        Dim rowH As Integer = 35

        g.FillRectangle(New SolidBrush(Color.LightGray), tableX, y, colNo + colGejala + colJawaban, rowH)
        g.DrawRectangle(Pens.Black, tableX, y, colNo, rowH)
        g.DrawRectangle(Pens.Black, tableX + colNo, y, colGejala, rowH)
        g.DrawRectangle(Pens.Black, tableX + colNo + colGejala, y, colJawaban, rowH)

        g.DrawString("NO.", fontTableHeader, Brushes.Black, tableX + 15, y + 10)
        g.DrawString("PERTANYAAN / GEJALA", fontTableHeader, Brushes.Black, tableX + colNo + 10, y + 10)
        g.DrawString("JAWABAN", fontTableHeader, Brushes.Black, tableX + colNo + colGejala + 20, y + 10)

        y += rowH

        Dim semuaG As New List(Of String)(jawabanUser.Keys)
        semuaG.Sort()
        Dim no As Integer = 1

        For Each gCode As String In semuaG
            Dim nilai As String = If(jawabanUser(gCode), "Ya", "Tidak")
            Dim deskripsi As String = If(pertanyaanDict.ContainsKey(gCode), pertanyaanDict(gCode), gCode)

            Dim rectTemp As New RectangleF(0, 0, colGejala - 20, 1000)
            Dim textSize As SizeF = g.MeasureString(deskripsi, fontTable, rectTemp.Size)
            Dim currentRowH As Integer = Math.Max(rowH, CInt(textSize.Height) + 20)

            If no Mod 2 = 0 Then
                g.FillRectangle(New SolidBrush(Color.FromArgb(245, 245, 245)), tableX, y, colNo + colGejala + colJawaban, currentRowH)
            End If

            g.DrawRectangle(Pens.Black, tableX, y, colNo, currentRowH)
            g.DrawRectangle(Pens.Black, tableX + colNo, y, colGejala, currentRowH)
            g.DrawRectangle(Pens.Black, tableX + colNo + colGejala, y, colJawaban, currentRowH)

            g.DrawString(no.ToString() & ".", fontTable, Brushes.Black, tableX + 15, y + 10)

            Dim rectDeskripsiGejala As New RectangleF(tableX + colNo + 10, y + 10, colGejala - 20, currentRowH - 20)
            g.DrawString(deskripsi, fontTable, Brushes.Black, rectDeskripsiGejala)

            Dim jawabanBrush As Brush = If(nilai = "Ya", Brushes.Green, Brushes.Red)
            g.DrawString(nilai, New Font(fontTable, FontStyle.Bold), jawabanBrush, tableX + colNo + colGejala + 25, y + 10)

            y += currentRowH
            no += 1
        Next

        y += 40

        g.FillRectangle(New SolidBrush(Color.FromArgb(230, 240, 255)), x - 10, y, pageWidth + 20, 30)
        g.DrawString("HASIL REKOMENDASI TOPIK SKRIPSI", fontHeader, Brushes.Black, centerX, y + 5, centerFormat)
        y += 40

        Dim boxHeight As Integer = If(String.IsNullOrEmpty(hasilKodeRule) OrElse hasilKodeRule = "N/A", 40, 60)
        g.FillRectangle(New SolidBrush(Color.FromArgb(255, 255, 220)), x, y, pageWidth, boxHeight)
        g.DrawRectangle(New Pen(Color.Black, 2), x, y, pageWidth, boxHeight)

        Dim yBox As Integer = y + 5

        If Not String.IsNullOrEmpty(hasilKodeRule) AndAlso hasilKodeRule <> "N/A" AndAlso hasilKodeRule <> "ERROR" Then
            g.DrawString("Kode Rule: " & hasilKodeRule, fontTableHeader, Brushes.Black, x + 10, yBox)
            yBox += 17
        End If

        g.DrawString("Topik Rekomendasi:", fontTableHeader, Brushes.Black, x + 10, yBox)
        yBox += 17
        g.DrawString(hasilJudul, New Font("Arial", 12, FontStyle.Bold), Brushes.DarkBlue, x + 10, yBox)

        y += boxHeight + 10

        g.DrawString("Penjelasan dan Deskripsi:", fontTableHeader, Brushes.Black, x, y)
        y += 25

        Dim deskripsiHeight As Integer = 250
        g.DrawRectangle(Pens.Black, x, y, pageWidth, deskripsiHeight)

        Dim rectDeskripsi As New RectangleF(x + 15, y + 15, pageWidth - 30, deskripsiHeight - 30)
        g.DrawString(hasilDeskripsi, fontTable, Brushes.Black, rectDeskripsi)

        y += deskripsiHeight + 30

        g.DrawString("Catatan:", fontTableHeader, Brushes.Black, x, y)
        y += 20
        g.DrawString("Hasil rekomendasi ini dihasilkan oleh sistem pakar berdasarkan jawaban yang Anda berikan.",
                     fontSmall, Brushes.Gray, x, y)
        y += 15
        g.DrawString("Konsultasikan lebih lanjut dengan dosen pembimbing untuk memilih topik yang sesuai.",
                     fontSmall, Brushes.Gray, x, y)
        y += 40

        Dim col1X As Integer = x + 50
        Dim col2X As Integer = x + pageWidth - 250

        g.DrawString("Mahasiswa Konsultan,", fontNormal, Brushes.Black, col1X, y)
        y += 60
        g.DrawString("________________________", fontNormal, Brushes.Black, col1X, y)
        y += 20
        g.DrawString("Nama:", fontSmall, Brushes.Black, col1X, y)
        y += 15
        g.DrawString("NIM:", fontSmall, Brushes.Black, col1X, y)

        Dim yKanan As Integer = y - 95
        g.DrawString("Mengetahui,", fontNormal, Brushes.Black, col2X, yKanan)
        yKanan += 15
        g.DrawString("Koordinator Skripsi", fontNormal, Brushes.Black, col2X, yKanan)
        yKanan += 60
        g.DrawString("________________________", fontNormal, Brushes.Black, col2X, yKanan)
        yKanan += 20
        g.DrawString("NIP:", fontSmall, Brushes.Black, col2X, yKanan)

        fontHeader.Dispose()
        fontSubHeader.Dispose()
        fontNormal.Dispose()
        fontTableHeader.Dispose()
        fontTable.Dispose()
        fontSmall.Dispose()
        centerFormat.Dispose()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim f6 As New Form6
        If CurrentUser IsNot Nothing Then f6.CurrentUser = Me.CurrentUser
        f6.Show()
        Me.Close()
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim f6 As New Form6
        If CurrentUser IsNot Nothing Then f6.CurrentUser = Me.CurrentUser
        f6.Show()
        Me.Close()
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

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Dim profil As New Form9
        If CurrentUser IsNot Nothing Then
            profil.CurrentUser = Me.CurrentUser
        End If
        profil.Show()
        Me.Close()
    End Sub

End Class