<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form9
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
        ToolStrip1 = New ToolStrip()
        ToolStripButton1 = New ToolStripButton()
        ToolStripButton4 = New ToolStripButton()
        ToolStripSeparator1 = New ToolStripSeparator()
        ToolStripDropDownButton1 = New ToolStripDropDownButton()
        MulaiKonsultasiToolStripMenuItem = New ToolStripMenuItem()
        RiwayatKonsultasiToolStripMenuItem = New ToolStripMenuItem()
        Button1 = New Button()
        Button3 = New Button()
        ToolStrip1.SuspendLayout()
        SuspendLayout()
        ' 
        ' ToolStrip1
        ' 
        ToolStrip1.Items.AddRange(New ToolStripItem() {ToolStripButton1, ToolStripButton4, ToolStripSeparator1, ToolStripDropDownButton1})
        ToolStrip1.Location = New Point(0, 0)
        ToolStrip1.Name = "ToolStrip1"
        ToolStrip1.Size = New Size(800, 25)
        ToolStrip1.TabIndex = 6
        ToolStrip1.Text = "ToolStrip1"
        ' 
        ' ToolStripButton1
        ' 
        ToolStripButton1.ImageTransparentColor = Color.Magenta
        ToolStripButton1.Name = "ToolStripButton1"
        ToolStripButton1.Size = New Size(80, 22)
        ToolStripButton1.Text = "Menu Utama"
        ' 
        ' ToolStripButton4
        ' 
        ToolStripButton4.Alignment = ToolStripItemAlignment.Right
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
        ToolStripDropDownButton1.DropDownItems.AddRange(New ToolStripItem() {MulaiKonsultasiToolStripMenuItem, RiwayatKonsultasiToolStripMenuItem})
        ToolStripDropDownButton1.ImageTransparentColor = Color.Magenta
        ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        ToolStripDropDownButton1.Size = New Size(74, 22)
        ToolStripDropDownButton1.Text = "Konsultasi"
        ' 
        ' MulaiKonsultasiToolStripMenuItem
        ' 
        MulaiKonsultasiToolStripMenuItem.Name = "MulaiKonsultasiToolStripMenuItem"
        MulaiKonsultasiToolStripMenuItem.Size = New Size(172, 22)
        MulaiKonsultasiToolStripMenuItem.Text = "Mulai Konsultasi"
        ' 
        ' RiwayatKonsultasiToolStripMenuItem
        ' 
        RiwayatKonsultasiToolStripMenuItem.Name = "RiwayatKonsultasiToolStripMenuItem"
        RiwayatKonsultasiToolStripMenuItem.Size = New Size(172, 22)
        RiwayatKonsultasiToolStripMenuItem.Text = "Riwayat Konsultasi"
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(259, 289)
        Button1.Name = "Button1"
        Button1.Size = New Size(75, 23)
        Button1.TabIndex = 7
        Button1.Text = "Button1"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Button3
        ' 
        Button3.Location = New Point(363, 229)
        Button3.Name = "Button3"
        Button3.Size = New Size(75, 23)
        Button3.TabIndex = 8
        Button3.Text = "Button2"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' Form9
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(800, 480)
        Controls.Add(Button3)
        Controls.Add(Button1)
        Controls.Add(ToolStrip1)
        FormBorderStyle = FormBorderStyle.FixedToolWindow
        Name = "Form9"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Form9"
        ToolStrip1.ResumeLayout(False)
        ToolStrip1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents ToolStripButton4 As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripDropDownButton1 As ToolStripDropDownButton
    Friend WithEvents MulaiKonsultasiToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RiwayatKonsultasiToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Button1 As Button
    Friend WithEvents Button3 As Button
End Class
