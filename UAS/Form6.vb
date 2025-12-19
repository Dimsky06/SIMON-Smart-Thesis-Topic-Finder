Imports System.Data.SqlClient
Imports System.Windows.Forms.DataVisualization.Charting
Imports Microsoft.Data.SqlClient

Public Class Form6
    Public Property CurrentUser As UserModel

    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "SIMON - Dashboard"
        Me.Size = New Size(1440, 900)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.BackColor = Color.FromArgb(249, 250, 251)

        ' MAIN CONTENT AREA
        Dim contentPanel As New Panel With {
            .Location = New Point(40, 120),
            .Size = New Size(1360, 720),
            .BackColor = Color.Transparent,
            .AutoScroll = True
        }
        Me.Controls.Add(contentPanel)

        '  WELCOME CARD 
        Dim welcomeCard As New Panel With {
            .Location = New Point(0, 0),
            .Size = New Size(1360, 200),
            .BackColor = Color.White
        }
        AddRoundedCorners(welcomeCard, 20)
        AddSoftShadow(welcomeCard)
        contentPanel.Controls.Add(welcomeCard)

        Dim accentBar As New Panel With {
            .Location = New Point(0, 0),
            .Size = New Size(8, 200),
            .BackColor = Color.FromArgb(99, 102, 241)
        }
        welcomeCard.Controls.Add(accentBar)

        If Me.Controls.Contains(Label1) Then
            Me.Controls.Remove(Label1)
        End If
        Label1.Parent = Nothing
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Segoe UI", 36, FontStyle.Bold)
        Label1.Location = New Point(50, 35)
        Label1.Size = New Size(850, 55)
        welcomeCard.Controls.Add(Label1)
        Label1.BackColor = Color.Transparent

        ' Prodi dengan Label4
        Me.Controls.Remove(Label4)
        Label4.BackColor = Color.Transparent
        Label4.Font = New Font("Segoe UI", 14)
        Label4.Location = New Point(50, 100)
        Label4.Size = New Size(850, 28)
        Label4.ForeColor = Color.FromArgb(107, 114, 128)
        Label4.AutoSize = False
        Label4.Parent = welcomeCard
        welcomeCard.Controls.Add(Label4)
        Label4.BackColor = Color.Transparent

        ' Email dengan Label5
        Me.Controls.Remove(Label5)
        Label5.BackColor = Color.Transparent
        Label5.Font = New Font("Segoe UI", 14)
        Label5.Location = New Point(50, 135)
        Label5.Size = New Size(850, 28)
        Label5.ForeColor = Color.FromArgb(107, 114, 128)
        Label5.AutoSize = False
        Label5.Parent = welcomeCard
        welcomeCard.Controls.Add(Label5)
        Label5.BackColor = Color.Transparent

        Button1.Text = "Mulai Konsultasi"
        Button1.Location = New Point(960, 50)
        Button1.Size = New Size(350, 55)
        Button1.Font = New Font("Segoe UI", 14, FontStyle.Bold)
        Button1.BackColor = Color.FromArgb(99, 102, 241)
        Button1.ForeColor = Color.White
        Button1.FlatStyle = FlatStyle.Flat
        Button1.Cursor = Cursors.Hand
        Button1.FlatAppearance.BorderSize = 0
        AddRoundedCorners(Button1, 12)
        welcomeCard.Controls.Add(Button1)
        Button1.BringToFront()
        AddHandler Button1.MouseEnter, Sub()
                                           Button1.BackColor = Color.FromArgb(79, 70, 229)
                                       End Sub
        AddHandler Button1.MouseLeave, Sub()
                                           Button1.BackColor = Color.FromArgb(99, 102, 241)
                                       End Sub

        Button2.Text = "Lihat Hasil Saya"
        Button2.Location = New Point(960, 120)
        Button2.Size = New Size(350, 55)
        Button2.Font = New Font("Segoe UI", 14)
        Button2.BackColor = Color.White
        Button2.ForeColor = Color.FromArgb(99, 102, 241)
        Button2.FlatStyle = FlatStyle.Flat
        Button2.Cursor = Cursors.Hand
        Button2.FlatAppearance.BorderSize = 2
        Button2.FlatAppearance.BorderColor = Color.FromArgb(99, 102, 241)
        AddRoundedCorners(Button2, 12)
        welcomeCard.Controls.Add(Button2)
        Button2.BringToFront()
        AddHandler Button2.MouseEnter, Sub()
                                           Button2.BackColor = Color.FromArgb(243, 244, 246)
                                       End Sub
        AddHandler Button2.MouseLeave, Sub()
                                           Button2.BackColor = Color.White
                                       End Sub

        '  CONTENT GRID 
        Dim contentRow As Integer = 230

        '  CHART CARD 
        Dim chartCard As New Panel With {
            .Location = New Point(0, contentRow),
            .Size = New Size(840, 460),
            .BackColor = Color.White
        }
        AddRoundedCorners(chartCard, 20)
        AddSoftShadow(chartCard)
        contentPanel.Controls.Add(chartCard)

        Dim chartTitle As New Label With {
            .Text = "Grafik Topik",
            .Font = New Font("Segoe UI", 20, FontStyle.Bold),
            .Location = New Point(35, 25),
            .Size = New Size(770, 40),
            .ForeColor = Color.FromArgb(17, 24, 39),
            .BackColor = Color.Transparent
        }
        chartCard.Controls.Add(chartTitle)

        Dim divider1 As New Panel With {
            .Location = New Point(35, 75),
            .Size = New Size(770, 2),
            .BackColor = Color.FromArgb(229, 231, 235)
        }
        chartCard.Controls.Add(divider1)

        Chart1.Location = New Point(35, 95)
        Chart1.Size = New Size(770, 340)
        Chart1.BackColor = Color.Transparent
        Chart1.BorderlineColor = Color.Transparent
        chartCard.Controls.Add(Chart1)
        Chart1.BringToFront()

        '  RIWAYAT CARD 
        Dim riwayatCard As New Panel With {
            .Location = New Point(870, contentRow),
            .Size = New Size(490, 460),
            .BackColor = Color.White
        }
        AddRoundedCorners(riwayatCard, 20)
        AddSoftShadow(riwayatCard)
        contentPanel.Controls.Add(riwayatCard)

        ' Riwayat title
        Dim riwayatTitle As New Label With {
            .Text = "Riwayat Konsultasi",
            .Font = New Font("Segoe UI", 20, FontStyle.Bold),
            .Location = New Point(30, 25),
            .Size = New Size(430, 40),
            .ForeColor = Color.FromArgb(17, 24, 39),
            .BackColor = Color.Transparent
        }
        riwayatCard.Controls.Add(riwayatTitle)

        Dim divider2 As New Panel With {
            .Location = New Point(30, 75),
            .Size = New Size(430, 2),
            .BackColor = Color.FromArgb(229, 231, 235)
        }
        riwayatCard.Controls.Add(divider2)


        DataGridView1.Location = New Point(30, 95)
        DataGridView1.Size = New Size(430, 340)
        DataGridView1.BackgroundColor = Color.White
        DataGridView1.BorderStyle = BorderStyle.None
        DataGridView1.ColumnHeadersHeight = 45
        DataGridView1.RowTemplate.Height = 50
        DataGridView1.DefaultCellStyle.Font = New Font("Segoe UI", 11)
        DataGridView1.DefaultCellStyle.ForeColor = Color.FromArgb(55, 65, 81)
        DataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(238, 242, 255)
        DataGridView1.DefaultCellStyle.SelectionForeColor = Color.FromArgb(17, 24, 39)
        DataGridView1.DefaultCellStyle.Padding = New Padding(5)
        DataGridView1.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 12, FontStyle.Bold)
        DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(243, 244, 246)
        DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(17, 24, 39)
        DataGridView1.ColumnHeadersDefaultCellStyle.Padding = New Padding(5)
        DataGridView1.EnableHeadersVisualStyles = False
        DataGridView1.GridColor = Color.FromArgb(229, 231, 235)
        DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(249, 250, 251)
        DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        DataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
        riwayatCard.Controls.Add(DataGridView1)
        DataGridView1.BringToFront()

        ' Load data
        If CurrentUser IsNot Nothing Then
            Label1.Text = "Halo, " & CurrentUser.NamaDepan
            Label4.Text = "📚 Program Studi: " & CurrentUser.Prodi
            Label5.Text = "✉️ Email: " & CurrentUser.Email
        Else
            Label1.Text = "Halo, User"
            Label4.Text = "📚 Program Studi: -"
            Label5.Text = "✉️ Email: -"
        End If

        LoadChartData()
        LoadRiwayatKeGrid()
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


    Private Sub LoadChartData()
        Dim query As String =
            "SELECT LTRIM(RTRIM(judul_topik)) AS topik, COUNT(id_hasil) AS total " &
            "FROM hasil " &
            "WHERE judul_topik IS NOT NULL AND judul_topik <> '' " &
            "GROUP BY LTRIM(RTRIM(judul_topik)) " &
            "ORDER BY total DESC"

        Chart1.Series.Clear()
        Chart1.ChartAreas.Clear()
        Chart1.Titles.Clear()
        Chart1.Legends.Clear()

        Dim chartArea As New ChartArea("MainArea")
        chartArea.BackColor = Color.Transparent
        chartArea.AxisX.Enabled = AxisEnabled.False
        chartArea.AxisY.Enabled = AxisEnabled.False
        Chart1.ChartAreas.Add(chartArea)


        Dim legend As New Legend("MainLegend")
        legend.Docking = Docking.Right
        legend.BackColor = Color.Transparent
        legend.Font = New Font("Segoe UI", 9)
        Chart1.Legends.Add(legend)

        Dim series As New Series("Total")
        series.ChartType = SeriesChartType.Pie
        series.IsValueShownAsLabel = True

        series.Label = "#VALY (#PERCENT)"
        series.LegendText = "#VALX"

        series.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        series.LabelForeColor = Color.White

        Chart1.Palette = ChartColorPalette.BrightPastel

        Try
            Using conn As SqlConnection = GetConnection()
                Using cmd As New SqlCommand(query, conn)
                    conn.Open()
                    Dim reader = cmd.ExecuteReader()

                    Dim adaData As Boolean = False
                    While reader.Read()
                        adaData = True
                        Dim topik As String = reader("topik").ToString()
                        Dim total As Integer = Convert.ToInt32(reader("total"))

                        ' Masukkan data
                        series.Points.AddXY(topik, total)
                    End While

                    If Not adaData Then
                        ' Data Dummy jika kosong
                        series.Points.AddXY("Data Kosong", 1)
                    End If
                End Using
            End Using

            Chart1.Series.Add(series)

        Catch ex As Exception
            MessageBox.Show("Gagal Grafik: " & ex.Message)
        End Try
    End Sub

    Private Sub LoadRiwayatKeGrid()
        Dim query As String =
            "
            SELECT TOP 5 
                   FORMAT(tanggal, 'dd/MM/yyyy HH:mm') AS Tanggal,
                   judul_topik AS Topik
            FROM hasil
            WHERE id_user = @id_user
            ORDER BY tanggal DESC
            "
        Dim dt As New DataTable()
        Try
            Using conn As SqlConnection = GetConnection()
                conn.Open()
                Using cmd As New SqlCommand(query, conn)
                    If CurrentUser IsNot Nothing Then
                        cmd.Parameters.AddWithValue("@id_user", CurrentUser.Id)
                    Else
                        cmd.Parameters.AddWithValue("@id_user", 0)
                    End If

                    Using da As New SqlDataAdapter(cmd)
                        da.Fill(dt)
                    End Using
                End Using
            End Using
            DataGridView1.DataSource = dt
            FormatGrid()
        Catch ex As Exception
            MessageBox.Show("Gagal memuat riwayat: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FormatGrid()
        With DataGridView1
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .RowHeadersVisible = False
            .ReadOnly = True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
        End With

        If DataGridView1.Columns.Count > 0 Then
            DataGridView1.Columns("Tanggal").HeaderText = "Tanggal"
            DataGridView1.Columns("Tanggal").Width = 130
            DataGridView1.Columns("Topik").HeaderText = "Topik"
            DataGridView1.Columns("Topik").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End If
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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim f8 As New Form8
        If CurrentUser IsNot Nothing Then
            f8.CurrentUser = Me.CurrentUser
        End If
        f8.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim konsultasi As New Form3
        If CurrentUser IsNot Nothing Then
            konsultasi.CurrentUser = Me.CurrentUser
        End If
        konsultasi.Show()
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

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim menu As New Form6
        If CurrentUser IsNot Nothing Then
            menu.CurrentUser = Me.CurrentUser
        End If
        menu.Show()
        Me.Close()
    End Sub

    Private Sub Chart1_Click(sender As Object, e As EventArgs) Handles Chart1.Click

    End Sub
End Class