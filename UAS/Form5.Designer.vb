<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form5
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form5))
        Label1 = New Label()
        PictureBox1 = New PictureBox()
        TextBox2 = New TextBox()
        Label3 = New Label()
        TextBox1 = New TextBox()
        Label2 = New Label()
        TextBox3 = New TextBox()
        Label4 = New Label()
        Button1 = New Button()
        Label8 = New Label()
        Button2 = New Button()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Poppins SemiBold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(107, 220)
        Label1.Name = "Label1"
        Label1.Size = New Size(233, 28)
        Label1.TabIndex = 3
        Label1.Text = "Expert System Topik Skripsi"
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackgroundImageLayout = ImageLayout.Center
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(137, 36)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(177, 181)
        PictureBox1.TabIndex = 2
        PictureBox1.TabStop = False
        ' 
        ' TextBox2
        ' 
        TextBox2.Location = New Point(34, 403)
        TextBox2.Name = "TextBox2"
        TextBox2.Size = New Size(370, 23)
        TextBox2.TabIndex = 9
        TextBox2.UseSystemPasswordChar = True
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Poppins", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(28, 372)
        Label3.Name = "Label3"
        Label3.Size = New Size(129, 28)
        Label3.TabIndex = 8
        Label3.Text = "Password Baru"
        ' 
        ' TextBox1
        ' 
        TextBox1.Location = New Point(34, 333)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(370, 23)
        TextBox1.TabIndex = 7
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Poppins", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(28, 302)
        Label2.Name = "Label2"
        Label2.Size = New Size(133, 28)
        Label2.TabIndex = 6
        Label2.Text = "Nama Lengkap"
        ' 
        ' TextBox3
        ' 
        TextBox3.Location = New Point(34, 496)
        TextBox3.Name = "TextBox3"
        TextBox3.Size = New Size(370, 23)
        TextBox3.TabIndex = 11
        TextBox3.UseSystemPasswordChar = True
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Poppins", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(28, 465)
        Label4.Name = "Label4"
        Label4.Size = New Size(168, 28)
        Label4.TabIndex = 10
        Label4.Text = "Konfirmasi Pasword"
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.DodgerBlue
        Button1.Font = New Font("Poppins SemiBold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button1.ForeColor = SystemColors.ButtonFace
        Button1.Location = New Point(34, 538)
        Button1.Name = "Button1"
        Button1.Size = New Size(370, 43)
        Button1.TabIndex = 12
        Button1.Text = "Konfirmasi"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Poppins", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label8.Location = New Point(34, 429)
        Label8.Name = "Label8"
        Label8.Size = New Size(176, 23)
        Label8.TabIndex = 19
        Label8.Text = "Masukkan Password Baru"
        ' 
        ' Button2
        ' 
        Button2.BackColor = Color.GhostWhite
        Button2.Font = New Font("Poppins SemiBold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button2.ForeColor = SystemColors.ActiveCaptionText
        Button2.Location = New Point(34, 589)
        Button2.Name = "Button2"
        Button2.Size = New Size(370, 43)
        Button2.TabIndex = 20
        Button2.Text = "Batal"
        Button2.UseVisualStyleBackColor = False
        ' 
        ' Form5
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(439, 666)
        Controls.Add(Button2)
        Controls.Add(Label8)
        Controls.Add(Button1)
        Controls.Add(TextBox3)
        Controls.Add(Label4)
        Controls.Add(TextBox2)
        Controls.Add(Label3)
        Controls.Add(TextBox1)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(PictureBox1)
        FormBorderStyle = FormBorderStyle.FixedToolWindow
        Name = "Form5"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Reset Password"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents Button2 As Button
End Class
