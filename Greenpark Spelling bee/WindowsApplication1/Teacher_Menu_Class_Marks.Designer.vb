<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Teacher_Menu_Class_Marks
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Teacher_Menu_Class_Marks))
        Me.dgvClass_Progress = New System.Windows.Forms.DataGridView()
        Me.TblMarkinfoBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.TblMarkinfoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtTest_ID_Class_Marks = New System.Windows.Forms.TextBox()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblTeacher_Username = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtClass_Average = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        CType(Me.dgvClass_Progress, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblMarkinfoBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblMarkinfoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvClass_Progress
        '
        Me.dgvClass_Progress.AllowUserToAddRows = False
        Me.dgvClass_Progress.AllowUserToDeleteRows = False
        Me.dgvClass_Progress.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvClass_Progress.Location = New System.Drawing.Point(6, 16)
        Me.dgvClass_Progress.Name = "dgvClass_Progress"
        Me.dgvClass_Progress.ReadOnly = True
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        Me.dgvClass_Progress.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvClass_Progress.Size = New System.Drawing.Size(537, 354)
        Me.dgvClass_Progress.TabIndex = 157
        '
        'TblMarkinfoBindingSource1
        '
        Me.TblMarkinfoBindingSource1.DataMember = "tblMark_info"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.AliceBlue
        Me.Label14.Location = New System.Drawing.Point(212, 16)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(115, 20)
        Me.Label14.TabIndex = 156
        Me.Label14.Text = "Class Progress"
        '
        'Button7
        '
        Me.Button7.BackColor = System.Drawing.Color.SandyBrown
        Me.Button7.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Button7.Location = New System.Drawing.Point(12, 419)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(171, 34)
        Me.Button7.TabIndex = 153
        Me.Button7.Text = "Account Management"
        Me.Button7.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.SandyBrown
        Me.Button4.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Button4.Location = New System.Drawing.Point(12, 373)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(171, 34)
        Me.Button4.TabIndex = 152
        Me.Button4.Text = "Test library"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.Color.Brown
        Me.Button6.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Button6.Location = New System.Drawing.Point(12, 12)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(171, 34)
        Me.Button6.TabIndex = 151
        Me.Button6.Text = "Teacher Menu"
        Me.Button6.UseVisualStyleBackColor = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label13.Location = New System.Drawing.Point(53, 58)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(50, 13)
        Me.Label13.TabIndex = 150
        Me.Label13.Text = "Teacher:"
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.Brown
        Me.Button5.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Button5.Location = New System.Drawing.Point(12, 592)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(171, 34)
        Me.Button5.TabIndex = 149
        Me.Button5.Text = "Log Off"
        Me.Button5.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.SandyBrown
        Me.Button1.DialogResult = System.Windows.Forms.DialogResult.No
        Me.Button1.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Button1.Location = New System.Drawing.Point(12, 241)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(171, 34)
        Me.Button1.TabIndex = 146
        Me.Button1.Text = "Make New Test"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.SandyBrown
        Me.Button2.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Button2.Location = New System.Drawing.Point(12, 285)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(171, 34)
        Me.Button2.TabIndex = 147
        Me.Button2.Text = "See Old Marks"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.Chocolate
        Me.Button3.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Button3.Location = New System.Drawing.Point(12, 329)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(171, 34)
        Me.Button3.TabIndex = 148
        Me.Button3.Text = "Class Marks"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(211, 61)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 17)
        Me.Label1.TabIndex = 160
        Me.Label1.Text = "Enter Test ID"
        '
        'txtTest_ID_Class_Marks
        '
        Me.txtTest_ID_Class_Marks.Location = New System.Drawing.Point(310, 61)
        Me.txtTest_ID_Class_Marks.Name = "txtTest_ID_Class_Marks"
        Me.txtTest_ID_Class_Marks.Size = New System.Drawing.Size(144, 20)
        Me.txtTest_ID_Class_Marks.TabIndex = 159
        '
        'Button8
        '
        Me.Button8.BackColor = System.Drawing.Color.SandyBrown
        Me.Button8.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Button8.Location = New System.Drawing.Point(460, 61)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(97, 20)
        Me.Button8.TabIndex = 158
        Me.Button8.Text = "Show Table"
        Me.Button8.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.dgvClass_Progress)
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(203, 91)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(549, 376)
        Me.GroupBox1.TabIndex = 161
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Class Progress "
        '
        'lblTeacher_Username
        '
        Me.lblTeacher_Username.AutoSize = True
        Me.lblTeacher_Username.BackColor = System.Drawing.Color.Transparent
        Me.lblTeacher_Username.ForeColor = System.Drawing.Color.Transparent
        Me.lblTeacher_Username.Location = New System.Drawing.Point(53, 74)
        Me.lblTeacher_Username.Name = "lblTeacher_Username"
        Me.lblTeacher_Username.Size = New System.Drawing.Size(39, 13)
        Me.lblTeacher_Username.TabIndex = 173
        Me.lblTeacher_Username.Text = "Label8"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(25, 35)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(144, 17)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Average Class Score:"
        '
        'txtClass_Average
        '
        Me.txtClass_Average.Location = New System.Drawing.Point(198, 35)
        Me.txtClass_Average.Name = "txtClass_Average"
        Me.txtClass_Average.ReadOnly = True
        Me.txtClass_Average.Size = New System.Drawing.Size(52, 20)
        Me.txtClass_Average.TabIndex = 1
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.txtClass_Average)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.ForeColor = System.Drawing.Color.White
        Me.GroupBox2.Location = New System.Drawing.Point(203, 473)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(549, 153)
        Me.GroupBox2.TabIndex = 176
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Progress Calculations"
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.ForeColor = System.Drawing.Color.White
        Me.GroupBox3.Location = New System.Drawing.Point(203, 46)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(364, 41)
        Me.GroupBox3.TabIndex = 177
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Search Test History"
        '
        'Teacher_Menu_Class_Marks
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.GPSB_System.My.Resources.Resources.Teacher_menu
        Me.ClientSize = New System.Drawing.Size(764, 638)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.lblTeacher_Username)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtTest_ID_Class_Marks)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Teacher_Menu_Class_Marks"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Teacher Menu - See Class Marks"
        CType(Me.dgvClass_Progress, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblMarkinfoBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblMarkinfoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents dgvClass_Progress As System.Windows.Forms.DataGridView
    Private WithEvents Label14 As System.Windows.Forms.Label
    Private WithEvents Button7 As System.Windows.Forms.Button
    Private WithEvents Button4 As System.Windows.Forms.Button
    Private WithEvents Button6 As System.Windows.Forms.Button
    Private WithEvents Label13 As System.Windows.Forms.Label
    Private WithEvents Button5 As System.Windows.Forms.Button
    Private WithEvents Button1 As System.Windows.Forms.Button
    Private WithEvents Button2 As System.Windows.Forms.Button
    Private WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents TblMarkinfoBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TestIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UserIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MarkDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ClassDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents txtTest_ID_Class_Marks As System.Windows.Forms.TextBox
    Private WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents TblMarkinfoBindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblTeacher_Username As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtClass_Average As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
End Class
