Imports System.Data.SqlClient
Imports Microsoft.Data.SqlClient

Public Class Form8
    Public Property CurrentUser As UserModel

    ' UI Elements
    Private mainBg As Panel
    Private contentCard As Panel
    Private topAccent As Panel
    Private pageTitle As Label
    Private subtitle As Label
    Private dividerLine As Panel
    Private filterContainer As Panel
    Private filterLabel As Label
    Private statsBadge As Panel
    Private statsLabel As Label
    Private infoNote As Label

    ' Design Constants
    Private Const FORM_WIDTH As Integer = 1450
    Private Const FORM_HEIGHT As Integer = 900
    Private Const CARD_WIDTH As Integer = 1240
    Private Const CARD_HEIGHT As Integer = 650
    Private Const MARGIN_LEFT As Integer = 105
    Private Const MARGIN_TOP As Integer = 110

    ' Color Palette
    Private ReadOnly COLOR_PRIMARY As Color = Color.FromArgb(99, 102, 241)
    Private ReadOnly COLOR_PRIMARY_DARK As Color = Color.FromArgb(79, 70, 229)
    Private ReadOnly COLOR_PRIMARY_LIGHT As Color = Color.FromArgb(238, 242, 255)
    Private ReadOnly COLOR_DANGER As Color = Color.FromArgb(239, 68, 68)
    Private ReadOnly COLOR_DANGER_DARK As Color = Color.FromArgb(220, 38, 38)
    Private ReadOnly COLOR_TEXT_PRIMARY As Color = Color.FromArgb(17, 24, 39)
    Private ReadOnly COLOR_TEXT_SECONDARY As Color = Color.FromArgb(107, 114, 128)
    Private ReadOnly COLOR_BACKGROUND As Color = Color.FromArgb(249, 250, 251)
    Private ReadOnly COLOR_CARD As Color = Color.White
    Private ReadOnly COLOR_BORDER As Color = Color.FromArgb(229, 231, 235)

    Private Sub Form8_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeForm()
        InitializeUIComponents()

        ' Validasi Sesi Login
        If CurrentUser Is Nothing Then
            MessageBox.Show("Sesi tidak ditemukan. Silakan login kembali.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
            Return
        End If

        LoadFilterTanggal()
        LoadRiwayat()
        FormatTabel()
    End Sub

    Private Sub InitializeForm()
        Me.Size = New Size(FORM_WIDTH, FORM_HEIGHT)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.BackColor = COLOR_BACKGROUND
        Me.FormBorderStyle = FormBorderStyle.Sizable
        Me.MinimumSize = New Size(1300, 800)
        Me.Text = "SIMON - Riwayat Konsultasi"
    End Sub

    Private Sub InitializeUIComponents()
        CreateBackgroundSection()
        CreateContentCard()
        CreateHeaderSection()
        CreateFilterSection()
        CreateDataGridView()
        CreateActionButtons()
        CreateInfoNote()
    End Sub

    Private Sub CreateBackgroundSection()
        mainBg = New Panel With {
            .Location = New Point(0, 0),
            .Size = New Size(Me.ClientSize.Width, Me.ClientSize.Height),
            .BackColor = COLOR_BACKGROUND,
            .Dock = DockStyle.Fill
        }
        Me.Controls.Add(mainBg)
        mainBg.SendToBack()
    End Sub

    Private Sub CreateContentCard()
        contentCard = New Panel With {
            .Location = New Point(MARGIN_LEFT, MARGIN_TOP),
            .Size = New Size(CARD_WIDTH, CARD_HEIGHT),
            .BackColor = COLOR_CARD
        }
        AddRoundedCorners(contentCard, 20)
        Me.Controls.Add(contentCard)

        topAccent = New Panel With {
            .Location = New Point(MARGIN_LEFT, MARGIN_TOP),
            .Size = New Size(CARD_WIDTH, 5),
            .BackColor = COLOR_PRIMARY
        }
        AddRoundedCorners(topAccent, 20)
        Me.Controls.Add(topAccent)
        topAccent.BringToFront()
    End Sub

    Private Sub CreateHeaderSection()
        pageTitle = New Label With {
            .Text = "📋 Riwayat Konsultasi",
            .Font = New Font("Segoe UI", 28, FontStyle.Bold),
            .Location = New Point(MARGIN_LEFT + 30, MARGIN_TOP + 30),
            .Size = New Size(CARD_WIDTH - 60, 45),
            .ForeColor = COLOR_TEXT_PRIMARY,
            .BackColor = Color.Transparent
        }
        Me.Controls.Add(pageTitle)
        pageTitle.BringToFront()

        subtitle = New Label With {
            .Text = "Lihat dan kelola riwayat konsultasi topik skripsi Anda",
            .Font = New Font("Segoe UI", 12, FontStyle.Regular),
            .Location = New Point(MARGIN_LEFT + 30, MARGIN_TOP + 80),
            .Size = New Size(CARD_WIDTH - 60, 25),
            .ForeColor = COLOR_TEXT_SECONDARY,
            .BackColor = Color.Transparent
        }
        Me.Controls.Add(subtitle)
        subtitle.BringToFront()

        dividerLine = New Panel With {
            .Location = New Point(MARGIN_LEFT + 30, MARGIN_TOP + 115),
            .Size = New Size(CARD_WIDTH - 60, 2),
            .BackColor = COLOR_BORDER
        }
        Me.Controls.Add(dividerLine)
        dividerLine.BringToFront()
    End Sub

    Private Sub CreateFilterSection()
        filterContainer = New Panel With {
            .Location = New Point(MARGIN_LEFT + 30, MARGIN_TOP + 135),
            .Size = New Size(CARD_WIDTH - 60, 55),
            .BackColor = Color.FromArgb(243, 244, 246)
        }
        AddRoundedCorners(filterContainer, 12)
        Me.Controls.Add(filterContainer)
        filterContainer.BringToFront()

        filterLabel = New Label With {
            .Text = "🔍 Filter:",
            .Font = New Font("Segoe UI", 11, FontStyle.Bold),
            .Location = New Point(MARGIN_LEFT + 45, MARGIN_TOP + 148),
            .Size = New Size(75, 30),
            .ForeColor = Color.FromArgb(31, 41, 55),
            .BackColor = Color.Transparent,
            .TextAlign = ContentAlignment.MiddleLeft
        }
        Me.Controls.Add(filterLabel)
        filterLabel.BringToFront()

        ComboBox1.Location = New Point(MARGIN_LEFT + 130, MARGIN_TOP + 146)
        ComboBox1.Size = New Size(220, 35)
        ComboBox1.Font = New Font("Segoe UI", 11)
        ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBox1.BackColor = COLOR_CARD
        ComboBox1.FlatStyle = FlatStyle.Flat
        ComboBox1.BringToFront()

        Button1.Location = New Point(MARGIN_LEFT + 370, MARGIN_TOP + 143)
        Button1.Size = New Size(140, 42)
        Button1.Font = New Font("Segoe UI", 11, FontStyle.Bold)
        Button1.Text = "🔄 Refresh"
        Button1.BackColor = COLOR_PRIMARY
        Button1.ForeColor = Color.White
        Button1.FlatStyle = FlatStyle.Flat
        Button1.FlatAppearance.BorderSize = 0
        Button1.Cursor = Cursors.Hand
        Button1.Margin = New Padding(0)
        AddRoundedCorners(Button1, 10)
        AddHandler Button1.MouseEnter, Sub() Button1.BackColor = COLOR_PRIMARY_DARK
        AddHandler Button1.MouseLeave, Sub() Button1.BackColor = COLOR_PRIMARY
        Button1.BringToFront()

        statsBadge = New Panel With {
            .Location = New Point(MARGIN_LEFT + CARD_WIDTH - 300, MARGIN_TOP + 140),
            .Size = New Size(270, 48),
            .BackColor = Color.FromArgb(239, 246, 255)
        }
        AddRoundedCorners(statsBadge, 10)
        Me.Controls.Add(statsBadge)
        statsBadge.BringToFront()

        statsLabel = New Label With {
            .Text = "📊 Total: 0 Konsultasi",
            .Font = New Font("Segoe UI", 11, FontStyle.Bold),
            .Location = New Point(MARGIN_LEFT + CARD_WIDTH - 290, MARGIN_TOP + 151),
            .Size = New Size(250, 26),
            .ForeColor = Color.FromArgb(59, 130, 246),
            .BackColor = Color.Transparent,
            .TextAlign = ContentAlignment.MiddleLeft
        }
        Me.Controls.Add(statsLabel)
        statsLabel.BringToFront()

        AddHandler DataGridView1.DataSourceChanged, Sub() statsLabel.Text = $"📊 Total: {DataGridView1.Rows.Count} Konsultasi"
    End Sub

    Private Sub CreateDataGridView()
        DataGridView1.Location = New Point(MARGIN_LEFT + 30, MARGIN_TOP + 215)
        DataGridView1.Size = New Size(CARD_WIDTH - 60, 345)
        DataGridView1.BackgroundColor = COLOR_CARD
        DataGridView1.BorderStyle = BorderStyle.None
        DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        DataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        DataGridView1.EnableHeadersVisualStyles = False
        DataGridView1.GridColor = COLOR_BORDER
        DataGridView1.RowHeadersVisible = False
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.AllowUserToDeleteRows = False
        DataGridView1.ReadOnly = True
        DataGridView1.MultiSelect = False
        DataGridView1.Font = New Font("Segoe UI", 10)
        DataGridView1.RowTemplate.Height = 45
        DataGridView1.ColumnHeadersHeight = 45

        With DataGridView1.ColumnHeadersDefaultCellStyle
            .BackColor = COLOR_PRIMARY
            .ForeColor = Color.White
            .Font = New Font("Segoe UI", 11, FontStyle.Bold)
            .Padding = New Padding(10, 6, 10, 6)
            .Alignment = DataGridViewContentAlignment.MiddleLeft
        End With

        With DataGridView1.DefaultCellStyle
            .SelectionBackColor = COLOR_PRIMARY_LIGHT
            .SelectionForeColor = COLOR_TEXT_PRIMARY
            .BackColor = COLOR_CARD
            .ForeColor = Color.FromArgb(31, 41, 55)
            .Padding = New Padding(10, 6, 10, 6)
        End With

        With DataGridView1.AlternatingRowsDefaultCellStyle
            .BackColor = COLOR_BACKGROUND
        End With

        DataGridView1.BringToFront()
    End Sub

    Private Sub CreateActionButtons()
        Button3.Location = New Point(MARGIN_LEFT + CARD_WIDTH - 170, MARGIN_TOP + 580)
        Button3.Size = New Size(140, 48)
        Button3.Font = New Font("Segoe UI", 12, FontStyle.Bold)
        Button3.Text = "🗑️ Hapus"
        Button3.BackColor = COLOR_DANGER
        Button3.ForeColor = Color.White
        Button3.FlatStyle = FlatStyle.Flat
        Button3.FlatAppearance.BorderSize = 0
        Button3.Cursor = Cursors.Hand
        Button3.Margin = New Padding(0)
        AddRoundedCorners(Button3, 10)
        AddHandler Button3.MouseEnter, Sub() Button3.BackColor = COLOR_DANGER_DARK
        AddHandler Button3.MouseLeave, Sub() Button3.BackColor = COLOR_DANGER
        Button3.BringToFront()
    End Sub

    Private Sub CreateInfoNote()
        infoNote = New Label With {
            .Text = "💡 Tip: Pilih baris untuk melihat detail atau menghapus riwayat konsultasi",
            .Font = New Font("Segoe UI", 10, FontStyle.Italic),
            .Location = New Point(MARGIN_LEFT + 30, MARGIN_TOP + 587),
            .Size = New Size(900, 30),
            .ForeColor = COLOR_TEXT_SECONDARY,
            .BackColor = Color.Transparent,
            .TextAlign = ContentAlignment.MiddleLeft
        }
        Me.Controls.Add(infoNote)
        infoNote.BringToFront()
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

    Private Sub AddSoftShadow(ctrl As Control)
    End Sub


    Private Sub LoadFilterTanggal()
        ComboBox1.Items.Clear()
        ComboBox1.Items.Add("📅 Semua Periode")
        ComboBox1.Items.Add("📅 7 Hari Terakhir")
        ComboBox1.Items.Add("📅 30 Hari Terakhir")
        ComboBox1.Items.Add("📅 Tahun Ini")
        ComboBox1.SelectedIndex = 0
    End Sub

    Private Sub LoadRiwayat()
        Dim query As String = "
        SELECT id_hasil,
               FORMAT(tanggal, 'dd/MM/yyyy HH:mm') AS Tanggal,
               judul_topik AS [Topik Rekomendasi]
        FROM hasil
        WHERE id_user = @uid
        ORDER BY tanggal DESC
        "
        Dim dt As New DataTable()
        Try
            Using conn As SqlConnection = GetConnection()
                conn.Open()
                Using da As New SqlDataAdapter(query, conn)
                    da.SelectCommand.Parameters.AddWithValue("@uid", CurrentUser.Id)
                    da.Fill(dt)
                End Using
            End Using
            DataGridView1.DataSource = dt
            If DataGridView1.Columns.Contains("id_hasil") Then
                DataGridView1.Columns("id_hasil").Visible = False
            End If
        Catch ex As Exception
            MessageBox.Show("Gagal memuat data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FormatTabel()
        With DataGridView1
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .RowHeadersVisible = False
            .ReadOnly = True
            .MultiSelect = False
            .AllowUserToResizeRows = False
        End With

        If DataGridView1.Columns.Count > 0 Then
            If DataGridView1.Columns.Contains("Tanggal") Then
                DataGridView1.Columns("Tanggal").HeaderText = "📅 Tanggal Konsultasi"
                DataGridView1.Columns("Tanggal").Width = 200
            End If
            If DataGridView1.Columns.Contains("Topik Rekomendasi") Then
                DataGridView1.Columns("Topik Rekomendasi").HeaderText = "📝 Topik Rekomendasi"
            End If
        End If
    End Sub


    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedIndex = -1 Then Exit Sub
        Dim filter As String = ComboBox1.SelectedItem.ToString()

        Dim query As String = "
        SELECT id_hasil,
               FORMAT(tanggal, 'dd/MM/yyyy HH:mm') AS Tanggal,
               judul_topik AS [Topik Rekomendasi]
        FROM hasil
        WHERE id_user = @uid
        "

        If filter.Contains("7 Hari") Then
            query &= " AND tanggal >= DATEADD(day, -7, GETDATE())"
        ElseIf filter.Contains("30 Hari") Then
            query &= " AND tanggal >= DATEADD(day, -30, GETDATE())"
        ElseIf filter.Contains("Tahun Ini") Then
            query &= " AND YEAR(tanggal) = YEAR(GETDATE())"
        End If

        query &= " ORDER BY tanggal DESC"

        Dim dt As New DataTable()
        Try
            Using conn As SqlConnection = GetConnection()
                conn.Open()
                Using da As New SqlDataAdapter(query, conn)
                    da.SelectCommand.Parameters.AddWithValue("@uid", CurrentUser.Id)
                    da.Fill(dt)
                End Using
            End Using
            DataGridView1.DataSource = dt
            If DataGridView1.Columns.Contains("id_hasil") Then
                DataGridView1.Columns("id_hasil").Visible = False
            End If
            FormatTabel()
        Catch ex As Exception
            MessageBox.Show("Gagal memfilter data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        LoadRiwayat()
        FormatTabel()
        MessageBox.Show("Data berhasil di-refresh!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If DataGridView1.CurrentRow Is Nothing Then
            MessageBox.Show("Silakan pilih data yang ingin dihapus terlebih dahulu.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim id As Integer = DataGridView1.CurrentRow.Cells("id_hasil").Value
        Dim topik As String = DataGridView1.CurrentRow.Cells("Topik Rekomendasi").Value.ToString()

        Dim result = MessageBox.Show($"Apakah Anda yakin ingin menghapus riwayat konsultasi dengan topik:{Environment.NewLine}{Environment.NewLine}""{topik}""?",
                                     "Konfirmasi Hapus",
                                     MessageBoxButtons.YesNo,
                                     MessageBoxIcon.Question)

        If result = DialogResult.No Then Return

        Try
            Using conn As SqlConnection = GetConnection()
                conn.Open()
                Dim cmd As New SqlCommand("DELETE FROM hasil WHERE id_hasil = @id AND id_user = @uid", conn)
                cmd.Parameters.AddWithValue("@id", id)
                cmd.Parameters.AddWithValue("@uid", CurrentUser.Id)
                Dim rowsAffected = cmd.ExecuteNonQuery()

                If rowsAffected > 0 Then
                    MessageBox.Show("Riwayat konsultasi berhasil dihapus!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LoadRiwayat()
                    FormatTabel()
                Else
                    MessageBox.Show("Data tidak ditemukan atau Anda tidak memiliki akses.", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Gagal menghapus data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim f6 As New Form6
        If Me.CurrentUser IsNot Nothing Then
            f6.CurrentUser = Me.CurrentUser
        End If
        f6.Show()
        Me.Close()
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Dim profil As New Form9
        If CurrentUser IsNot Nothing Then
            profil.CurrentUser = Me.CurrentUser
        End If
        profil.Show()
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
End Class