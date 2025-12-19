<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form2))
        PictureBox1 = New PictureBox()
        TextBox1 = New TextBox()
        ComboBox1 = New ComboBox()
        ComboBox2 = New ComboBox()
        TextBox2 = New TextBox()
        TextBox3 = New TextBox()
        TextBox4 = New TextBox()
        Button1 = New Button()
        ContextMenuStrip1 = New ContextMenuStrip(components)
        PictureBox2 = New PictureBox()
        Label8 = New Label()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackgroundImageLayout = ImageLayout.Center
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(98, 141)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(177, 181)
        PictureBox1.TabIndex = 2
        PictureBox1.TabStop = False
        ' 
        ' TextBox1
        ' 
        TextBox1.Font = New Font("Poppins", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TextBox1.Location = New Point(426, 141)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(370, 27)
        TextBox1.TabIndex = 5
        ' 
        ' ComboBox1
        ' 
        ComboBox1.Font = New Font("Poppins", 9.75F)
        ComboBox1.FormattingEnabled = True
        ComboBox1.Location = New Point(623, 304)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(173, 31)
        ComboBox1.TabIndex = 9
        ' 
        ' ComboBox2
        ' 
        ComboBox2.Font = New Font("Poppins", 9.75F)
        ComboBox2.FormattingEnabled = True
        ComboBox2.Location = New Point(426, 304)
        ComboBox2.Name = "ComboBox2"
        ComboBox2.Size = New Size(173, 31)
        ComboBox2.TabIndex = 10
        ' 
        ' TextBox2
        ' 
        TextBox2.Font = New Font("Poppins", 9.75F)
        TextBox2.Location = New Point(426, 377)
        TextBox2.Name = "TextBox2"
        TextBox2.Size = New Size(173, 27)
        TextBox2.TabIndex = 12
        ' 
        ' TextBox3
        ' 
        TextBox3.Font = New Font("Poppins", 9.75F)
        TextBox3.Location = New Point(629, 377)
        TextBox3.Name = "TextBox3"
        TextBox3.Size = New Size(167, 27)
        TextBox3.TabIndex = 14
        ' 
        ' TextBox4
        ' 
        TextBox4.Font = New Font("Poppins", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TextBox4.Location = New Point(426, 210)
        TextBox4.Name = "TextBox4"
        TextBox4.Size = New Size(370, 27)
        TextBox4.TabIndex = 16
        TextBox4.UseSystemPasswordChar = True
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.DodgerBlue
        Button1.Font = New Font("Poppins SemiBold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button1.ForeColor = SystemColors.ButtonFace
        Button1.Location = New Point(426, 423)
        Button1.Name = "Button1"
        Button1.Size = New Size(370, 43)
        Button1.TabIndex = 17
        Button1.Text = "Submit"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' ContextMenuStrip1
        ' 
        ContextMenuStrip1.Name = "ContextMenuStrip1"
        ContextMenuStrip1.Size = New Size(61, 4)
        ' 
        ' PictureBox2
        ' 
        PictureBox2.Location = New Point(12, 12)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(53, 50)
        PictureBox2.TabIndex = 20
        PictureBox2.TabStop = False
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Poppins", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label8.Location = New Point(426, 240)
        Label8.Name = "Label8"
        Label8.Size = New Size(143, 23)
        Label8.TabIndex = 18
        Label8.Text = "Masukkan Password"
        ' 
        ' Form2
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(1384, 761)
        Controls.Add(PictureBox2)
        Controls.Add(Label8)
        Controls.Add(Button1)
        Controls.Add(TextBox4)
        Controls.Add(TextBox3)
        Controls.Add(TextBox2)
        Controls.Add(ComboBox2)
        Controls.Add(ComboBox1)
        Controls.Add(TextBox1)
        Controls.Add(PictureBox1)
        FormBorderStyle = FormBorderStyle.FixedToolWindow
        Name = "Form2"
        StartPosition = FormStartPosition.CenterScreen
        Text = " "
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Label8 As Label
End Class
