Imports System.Drawing.Drawing2D

Public Class FormSplash
    Private progress As Integer = 0
    Private animationStep As Integer = 0
    Private pulseDirection As Integer = 1
    Private pulseSize As Integer = 0
    Private glowIntensity As Single = 0

    ' Design Constants
    Private Const FORM_WIDTH As Integer = 900
    Private Const FORM_HEIGHT As Integer = 600

    Private ReadOnly COLOR_GRADIENT_START As Color = Color.FromArgb(249, 250, 251)
    Private ReadOnly COLOR_GRADIENT_END As Color = Color.FromArgb(255, 255, 255)
    Private ReadOnly COLOR_ACCENT As Color = Color.FromArgb(99, 102, 241)
    Private ReadOnly COLOR_SUCCESS As Color = Color.FromArgb(34, 197, 94)
    Private ReadOnly COLOR_TEXT_PRIMARY As Color = Color.FromArgb(17, 24, 39)
    Private ReadOnly COLOR_TEXT_SECONDARY As Color = Color.FromArgb(107, 114, 128)
    Private ReadOnly COLOR_BACKGROUND As Color = Color.FromArgb(255, 255, 255)
    Private ReadOnly COLOR_GLOW As Color = Color.FromArgb(80, 99, 102, 241)

    ' UI Elements
    Private mainPanel As Panel
    Private gradientPanel As Panel
    Private logoPanel As Panel
    Private logoLabel As Label
    Private appNameLabel As Label
    Private taglineLabel As Label
    Private progressBarBg As Panel
    Private progressBarFill As Panel
    Private progressLabel As Label
    Private progressPercentLabel As Label
    Private versionLabel As Label
    Private copyrightLabel As Label
    Private particlesPanel As Panel

    ' Timers
    Private WithEvents loadTimer As New Timer()
    Private WithEvents animationTimer As New Timer()

    Private Sub FormSplash_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeForm()
        InitializeUIComponents()
        StartLoading()
    End Sub

    Private Sub InitializeForm()
        Me.Size = New Size(FORM_WIDTH, FORM_HEIGHT)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.FormBorderStyle = FormBorderStyle.None
        Me.BackColor = COLOR_BACKGROUND
        Me.ShowInTaskbar = False
        Me.DoubleBuffered = True

        Me.Region = CreateRoundedRegion(New Rectangle(0, 0, FORM_WIDTH, FORM_HEIGHT), 24)
    End Sub

    Private Sub InitializeUIComponents()
        gradientPanel = New Panel With {
            .Location = New Point(0, 0),
            .Size = New Size(FORM_WIDTH, FORM_HEIGHT),
            .BackColor = Color.Transparent
        }
        AddHandler gradientPanel.Paint, AddressOf GradientPanel_Paint
        Me.Controls.Add(gradientPanel)

        particlesPanel = New Panel With {
            .Location = New Point(0, 0),
            .Size = New Size(FORM_WIDTH, FORM_HEIGHT),
            .BackColor = Color.Transparent
        }
        AddHandler particlesPanel.Paint, AddressOf ParticlesPanel_Paint
        Me.Controls.Add(particlesPanel)
        particlesPanel.BringToFront()

        logoPanel = New Panel With {
            .Location = New Point((FORM_WIDTH - 160) \ 2, 100),
            .Size = New Size(160, 160),
            .BackColor = Color.Transparent
        }
        AddHandler logoPanel.Paint, AddressOf LogoPanel_Paint
        Me.Controls.Add(logoPanel)
        logoPanel.BringToFront()

        ' Logo Icon
        logoLabel = New Label With {
            .Text = "🎓",
            .Font = New Font("Segoe UI Emoji", 80, FontStyle.Regular),
            .Location = New Point(0, 20),
            .Size = New Size(160, 120),
            .TextAlign = ContentAlignment.MiddleCenter,
            .BackColor = Color.Transparent,
            .ForeColor = COLOR_ACCENT
        }
        logoPanel.Controls.Add(logoLabel)

        appNameLabel = New Label With {
            .Text = "SIMON",
            .Font = New Font("Segoe UI", 56, FontStyle.Bold),
            .Location = New Point(0, 280),
            .Size = New Size(FORM_WIDTH, 80),
            .ForeColor = COLOR_TEXT_PRIMARY,
            .TextAlign = ContentAlignment.MiddleCenter,
            .BackColor = Color.Transparent
        }
        Me.Controls.Add(appNameLabel)
        appNameLabel.BringToFront()

        taglineLabel = New Label With {
            .Text = "Sistem Pakar Pemilihan Topik Skripsi",
            .Font = New Font("Segoe UI", 15, FontStyle.Regular),
            .Location = New Point(0, 360),
            .Size = New Size(FORM_WIDTH, 35),
            .ForeColor = COLOR_TEXT_SECONDARY,
            .TextAlign = ContentAlignment.MiddleCenter,
            .BackColor = Color.Transparent
        }
        Me.Controls.Add(taglineLabel)
        taglineLabel.BringToFront()

        progressBarBg = New Panel With {
            .Location = New Point(200, 430),
            .Size = New Size(500, 6),
            .BackColor = Color.FromArgb(229, 231, 235)
        }
        progressBarBg.Region = CreateRoundedRegion(New Rectangle(0, 0, 500, 6), 3)
        Me.Controls.Add(progressBarBg)
        progressBarBg.BringToFront()

        progressBarFill = New Panel With {
            .Location = New Point(200, 430),
            .Size = New Size(0, 6),
            .BackColor = Color.Transparent
        }
        AddHandler progressBarFill.Paint, AddressOf ProgressBarFill_Paint
        Me.Controls.Add(progressBarFill)
        progressBarFill.BringToFront()

        ' Progress Text
        progressLabel = New Label With {
            .Text = "Memulai aplikasi...",
            .Font = New Font("Segoe UI", 11, FontStyle.Regular),
            .Location = New Point(200, 450),
            .Size = New Size(400, 25),
            .ForeColor = COLOR_TEXT_SECONDARY,
            .TextAlign = ContentAlignment.MiddleLeft,
            .BackColor = Color.Transparent
        }
        Me.Controls.Add(progressLabel)
        progressLabel.BringToFront()

        progressPercentLabel = New Label With {
            .Text = "0%",
            .Font = New Font("Segoe UI", 11, FontStyle.Bold),
            .Location = New Point(600, 450),
            .Size = New Size(100, 25),
            .ForeColor = COLOR_TEXT_PRIMARY,
            .TextAlign = ContentAlignment.MiddleRight,
            .BackColor = Color.Transparent
        }
        Me.Controls.Add(progressPercentLabel)
        progressPercentLabel.BringToFront()

        versionLabel = New Label With {
            .Text = "v1.0.0",
            .Font = New Font("Segoe UI", 9, FontStyle.Bold),
            .Location = New Point(30, FORM_HEIGHT - 40),
            .Size = New Size(80, 25),
            .ForeColor = COLOR_TEXT_SECONDARY,
            .BackColor = Color.FromArgb(243, 244, 246),
            .TextAlign = ContentAlignment.MiddleCenter
        }
        versionLabel.Region = CreateRoundedRegion(New Rectangle(0, 0, 80, 25), 12)
        Me.Controls.Add(versionLabel)
        versionLabel.BringToFront()

        copyrightLabel = New Label With {
            .Text = "© Kelompok 5",
            .Font = New Font("Segoe UI", 9, FontStyle.Regular),
            .Location = New Point(0, FORM_HEIGHT - 40),
            .Size = New Size(FORM_WIDTH - 30, 25),
            .ForeColor = COLOR_TEXT_SECONDARY,
            .TextAlign = ContentAlignment.MiddleRight,
            .BackColor = Color.Transparent
        }
        Me.Controls.Add(copyrightLabel)
        copyrightLabel.BringToFront()
    End Sub

    Private Sub StartLoading()
        loadTimer.Interval = 35
        loadTimer.Start()

        animationTimer.Interval = 50
        animationTimer.Start()
    End Sub

    Private Sub LoadTimer_Tick(sender As Object, e As EventArgs) Handles loadTimer.Tick
        progress += 1

        If progress <= 100 Then
            Dim targetWidth As Integer = CInt((progress / 100) * 500)
            progressBarFill.Width = targetWidth
            progressPercentLabel.Text = progress.ToString() & "%"

            Select Case progress
                Case 0 To 15
                    progressLabel.Text = "🚀 Memulai aplikasi..."
                Case 16 To 30
                    progressLabel.Text = "⚙️ Memuat komponen sistem..."
                Case 31 To 50
                    progressLabel.Text = "🗄️ Menghubungkan database..."
                Case 51 To 70
                    progressLabel.Text = "📦 Memuat konfigurasi..."
                Case 71 To 85
                    progressLabel.Text = "🎨 Menyiapkan antarmuka..."
                Case 86 To 95
                    progressLabel.Text = "✨ Finalisasi..."
                Case 96 To 100
                    progressLabel.Text = "✅ Selesai!"
                    progressLabel.ForeColor = COLOR_SUCCESS
            End Select
        Else
            loadTimer.Stop()
            animationTimer.Stop()

            Dim fadeTimer As New Timer With {.Interval = 20}
            AddHandler fadeTimer.Tick, Sub(s, ev)
                                           Me.Opacity -= 0.05
                                           If Me.Opacity <= 0 Then
                                               fadeTimer.Stop()
                                               Dim loginForm As New Form7()
                                               loginForm.Show()
                                               Me.Close()
                                           End If
                                       End Sub
            fadeTimer.Start()
        End If
    End Sub

    Private Sub AnimationTimer_Tick(sender As Object, e As EventArgs) Handles animationTimer.Tick
        animationStep += 1

        pulseSize += pulseDirection * 2
        If pulseSize > 20 Then pulseDirection = -1
        If pulseSize < 0 Then pulseDirection = 1

        glowIntensity = CSng(Math.Sin(animationStep * 0.1) * 0.5 + 0.5)

        logoPanel.Invalidate()
        particlesPanel.Invalidate()
        progressBarFill.Invalidate()
    End Sub

    Private Sub GradientPanel_Paint(sender As Object, e As PaintEventArgs)
        Using brush As New LinearGradientBrush(
            New Point(0, 0),
            New Point(FORM_WIDTH, FORM_HEIGHT),
            COLOR_GRADIENT_START,
            COLOR_GRADIENT_END)

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
            e.Graphics.FillRectangle(brush, gradientPanel.ClientRectangle)
        End Using
    End Sub

    Private Sub ParticlesPanel_Paint(sender As Object, e As PaintEventArgs)
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias

        For i As Integer = 0 To 20
            Dim x As Integer = (i * 100 + animationStep * 2) Mod FORM_WIDTH
            Dim y As Integer = (i * 50 + animationStep) Mod FORM_HEIGHT
            Dim size As Integer = 3 + (i Mod 3)
            Dim alpha As Integer = 20 + CInt(Math.Sin(animationStep * 0.05 + i) * 15)

            Using brush As New SolidBrush(Color.FromArgb(alpha, COLOR_ACCENT))
                e.Graphics.FillEllipse(brush, x, y, size, size)
            End Using
        Next
    End Sub

    Private Sub LogoPanel_Paint(sender As Object, e As PaintEventArgs)
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias

        Dim glowSize As Integer = 80 + pulseSize
        Dim glowRect As New Rectangle(
            (logoPanel.Width - glowSize) \ 2,
            (logoPanel.Height - glowSize) \ 2,
            glowSize, glowSize)

        Using path As New GraphicsPath()
            path.AddEllipse(glowRect)
            Using pgb As New PathGradientBrush(path)
                pgb.CenterColor = Color.FromArgb(CInt(glowIntensity * 100), COLOR_GRADIENT_START)
                pgb.SurroundColors = {Color.Transparent}
                e.Graphics.FillPath(pgb, path)
            End Using
        End Using
    End Sub

    Private Sub ProgressBarFill_Paint(sender As Object, e As PaintEventArgs)
        If progressBarFill.Width > 0 Then
            Using brush As New LinearGradientBrush(
                New Point(0, 0),
                New Point(progressBarFill.Width, 0),
                COLOR_ACCENT,
                Color.FromArgb(139, 92, 246))

                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
                e.Graphics.FillRectangle(brush, progressBarFill.ClientRectangle)

                Using shineBrush As New LinearGradientBrush(
                    New Point(0, 0),
                    New Point(0, 6),
                    Color.FromArgb(60, 255, 255, 255),
                    Color.Transparent)
                    e.Graphics.FillRectangle(shineBrush, 0, 0, progressBarFill.Width, 3)
                End Using
            End Using
        End If
    End Sub

    Private Function CreateRoundedRegion(rect As Rectangle, radius As Integer) As Region
        Dim path As New GraphicsPath()
        path.StartFigure()
        path.AddArc(rect.X, rect.Y, radius, radius, 180, 90)
        path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90)
        path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90)
        path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90)
        path.CloseFigure()
        Return New Region(path)
    End Function


    Protected Overrides Sub OnFormClosing(e As FormClosingEventArgs)
        If e.CloseReason = CloseReason.UserClosing Then
            e.Cancel = True
        End If
        MyBase.OnFormClosing(e)
    End Sub
End Class