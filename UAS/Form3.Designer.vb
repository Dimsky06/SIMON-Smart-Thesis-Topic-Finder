<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form3
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form3))
        ProgressBar1 = New ProgressBar()
        Label4 = New Label()
        Label5 = New Label()
        RadioButton1 = New RadioButton()
        RadioButton2 = New RadioButton()
        Timer1 = New Timer(components)
        ToolStrip1 = New ToolStrip()
        ToolStripButton1 = New ToolStripButton()
        ToolStripButton4 = New ToolStripButton()
        ToolStripSeparator1 = New ToolStripSeparator()
        ToolStripDropDownButton1 = New ToolStripDropDownButton()
        MulaiKonsultasiToolStripMenuItem = New ToolStripMenuItem()
        RiwayatKonsultasiToolStripMenuItem = New ToolStripMenuItem()
        Button1 = New Button()
        Button2 = New Button()
        ToolStrip1.SuspendLayout()
        SuspendLayout()
        ' 
        ' ProgressBar1
        ' 
        ProgressBar1.Location = New Point(516, 47)
        ProgressBar1.Maximum = 200
        ProgressBar1.Name = "ProgressBar1"
        ProgressBar1.Size = New Size(261, 17)
        ProgressBar1.TabIndex = 6
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.BackColor = Color.Transparent
        Label4.Font = New Font("Poppins", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.ForeColor = Color.Black
        Label4.Location = New Point(122, 202)
        Label4.Name = "Label4"
        Label4.Size = New Size(0, 28)
        Label4.TabIndex = 8
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Cursor = Cursors.Cross
        Label5.Font = New Font("Poppins", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label5.Location = New Point(122, 230)
        Label5.MaximumSize = New Size(900, 0)
        Label5.Name = "Label5"
        Label5.Size = New Size(865, 56)
        Label5.TabIndex = 9
        Label5.Text = "Apakah Anda tertarik pada kecerdasan buatan seperti pengenalan wajah, chatbot, atau prediksi berbasis data?"
        ' 
        ' RadioButton1
        ' 
        RadioButton1.AutoSize = True
        RadioButton1.Font = New Font("Poppins", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        RadioButton1.Location = New Point(125, 304)
        RadioButton1.Name = "RadioButton1"
        RadioButton1.Size = New Size(53, 32)
        RadioButton1.TabIndex = 11
        RadioButton1.TabStop = True
        RadioButton1.Text = "Ya."
        RadioButton1.UseVisualStyleBackColor = True
        ' 
        ' RadioButton2
        ' 
        RadioButton2.AutoSize = True
        RadioButton2.Font = New Font("Poppins", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        RadioButton2.Location = New Point(222, 304)
        RadioButton2.Name = "RadioButton2"
        RadioButton2.Size = New Size(73, 32)
        RadioButton2.TabIndex = 12
        RadioButton2.TabStop = True
        RadioButton2.Text = "Tidak"
        RadioButton2.UseVisualStyleBackColor = True
        ' 
        ' ToolStrip1
        ' 
        ToolStrip1.Items.AddRange(New ToolStripItem() {ToolStripButton1, ToolStripButton4, ToolStripSeparator1, ToolStripDropDownButton1})
        ToolStrip1.Location = New Point(0, 0)
        ToolStrip1.Name = "ToolStrip1"
        ToolStrip1.Size = New Size(1384, 25)
        ToolStrip1.TabIndex = 13
        ToolStrip1.Text = "ToolStrip1"
        ' 
        ' ToolStripButton1
        ' 
        ToolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Text
        ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), Image)
        ToolStripButton1.ImageTransparentColor = Color.Magenta
        ToolStripButton1.Name = "ToolStripButton1"
        ToolStripButton1.Size = New Size(80, 22)
        ToolStripButton1.Text = "Menu Utama"
        ' 
        ' ToolStripButton4
        ' 
        ToolStripButton4.Alignment = ToolStripItemAlignment.Right
        ToolStripButton4.DisplayStyle = ToolStripItemDisplayStyle.Text
        ToolStripButton4.Image = CType(resources.GetObject("ToolStripButton4.Image"), Image)
        ToolStripButton4.ImageTransparentColor = Color.Magenta
        ToolStripButton4.Name = "ToolStripButton4"
        ToolStripButton4.Size = New Size(39, 22)
        ToolStripButton4.Text = "Profil"
        ' 
        ' ToolStripSeparator1
        ' 
        ToolStripSeparator1.Name = "ToolStripSeparator1"
        ToolStripSeparator1.Size = New Size(6, 25)
        ' 
        ' ToolStripDropDownButton1
        ' 
        ToolStripDropDownButton1.DisplayStyle = ToolStripItemDisplayStyle.Text
        ToolStripDropDownButton1.DropDownItems.AddRange(New ToolStripItem() {MulaiKonsultasiToolStripMenuItem, RiwayatKonsultasiToolStripMenuItem})
        ToolStripDropDownButton1.Image = CType(resources.GetObject("ToolStripDropDownButton1.Image"), Image)
        ToolStripDropDownButton1.ImageTransparentColor = Color.Magenta
        ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        ToolStripDropDownButton1.Size = New Size(74, 22)
        ToolStripDropDownButton1.Text = "Konsultasi"
        ' 
        ' MulaiKonsultasiToolStripMenuItem
        ' 
        MulaiKonsultasiToolStripMenuItem.Name = "MulaiKonsultasiToolStripMenuItem"
        MulaiKonsultasiToolStripMenuItem.Size = New Size(180, 22)
        MulaiKonsultasiToolStripMenuItem.Text = "Mulai Konsultasi"
        ' 
        ' RiwayatKonsultasiToolStripMenuItem
        ' 
        RiwayatKonsultasiToolStripMenuItem.Name = "RiwayatKonsultasiToolStripMenuItem"
        RiwayatKonsultasiToolStripMenuItem.Size = New Size(180, 22)
        RiwayatKonsultasiToolStripMenuItem.Text = "Riwayat Konsultasi"
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(26, 230)
        Button1.Name = "Button1"
        Button1.Size = New Size(75, 56)
        Button1.TabIndex = 14
        Button1.Text = "Button1"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(873, 230)
        Button2.Name = "Button2"
        Button2.Size = New Size(75, 56)
        Button2.TabIndex = 15
        Button2.Text = "Button2"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Form3
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(1384, 761)
        Controls.Add(Button2)
        Controls.Add(Button1)
        Controls.Add(ToolStrip1)
        Controls.Add(RadioButton2)
        Controls.Add(RadioButton1)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(ProgressBar1)
        FormBorderStyle = FormBorderStyle.FixedToolWindow
        Name = "Form3"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Form3"
        ToolStrip1.ResumeLayout(False)
        ToolStrip1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents Timer1 As Timer
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents ToolStripButton4 As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripDropDownButton1 As ToolStripDropDownButton
    Friend WithEvents MulaiKonsultasiToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RiwayatKonsultasiToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
End Class
