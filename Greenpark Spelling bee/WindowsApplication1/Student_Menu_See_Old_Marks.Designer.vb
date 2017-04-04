<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Student_Menu_See_Old_Marks
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Student_Menu_See_Old_Marks))
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.btnLogOff = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dgvStudent_Results = New System.Windows.Forms.DataGridView()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.btnSee_Old_Marks_See_Old_Marks = New System.Windows.Forms.Button()
        Me.btnTake_Test_See_Old_Marks = New System.Windows.Forms.Button()
        Me.btSee_Next_Test_See_Old_Marks = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtRecent_Per_Improvement = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtRecent_Improvement = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtPercentage_Increase = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtRange_Calculator = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtAverage = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblStudent_Name = New System.Windows.Forms.Label()
        Me.lblStudent_Year = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvStudent_Results, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label14.Location = New System.Drawing.Point(71, 97)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(32, 13)
        Me.Label14.TabIndex = 46
        Me.Label14.Text = "Year:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label13.Location = New System.Drawing.Point(53, 58)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(78, 13)
        Me.Label13.TabIndex = 45
        Me.Label13.Text = "Student Name:"
        '
        'btnLogOff
        '
        Me.btnLogOff.BackColor = System.Drawing.Color.Brown
        Me.btnLogOff.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnLogOff.Location = New System.Drawing.Point(12, 592)
        Me.btnLogOff.Name = "btnLogOff"
        Me.btnLogOff.Size = New System.Drawing.Size(171, 34)
        Me.btnLogOff.TabIndex = 44
        Me.btnLogOff.Text = "Log Off"
        Me.btnLogOff.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.dgvStudent_Results)
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.GroupBox1.Location = New System.Drawing.Point(203, 58)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(552, 384)
        Me.GroupBox1.TabIndex = 43
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Test Results"
        '
        'dgvStudent_Results
        '
        Me.dgvStudent_Results.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvStudent_Results.Location = New System.Drawing.Point(6, 14)
        Me.dgvStudent_Results.Name = "dgvStudent_Results"
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        Me.dgvStudent_Results.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvStudent_Results.Size = New System.Drawing.Size(540, 364)
        Me.dgvStudent_Results.TabIndex = 0
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.Color.Brown
        Me.Button6.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Button6.Location = New System.Drawing.Point(12, 12)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(171, 34)
        Me.Button6.TabIndex = 47
        Me.Button6.Text = "Student Menu"
        Me.Button6.UseVisualStyleBackColor = False
        '
        'btnSee_Old_Marks_See_Old_Marks
        '
        Me.btnSee_Old_Marks_See_Old_Marks.BackColor = System.Drawing.SystemColors.Highlight
        Me.btnSee_Old_Marks_See_Old_Marks.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnSee_Old_Marks_See_Old_Marks.Location = New System.Drawing.Point(12, 285)
        Me.btnSee_Old_Marks_See_Old_Marks.Name = "btnSee_Old_Marks_See_Old_Marks"
        Me.btnSee_Old_Marks_See_Old_Marks.Size = New System.Drawing.Size(171, 34)
        Me.btnSee_Old_Marks_See_Old_Marks.TabIndex = 40
        Me.btnSee_Old_Marks_See_Old_Marks.Text = "See Old Marks"
        Me.btnSee_Old_Marks_See_Old_Marks.UseVisualStyleBackColor = False
        '
        'btnTake_Test_See_Old_Marks
        '
        Me.btnTake_Test_See_Old_Marks.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnTake_Test_See_Old_Marks.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnTake_Test_See_Old_Marks.Location = New System.Drawing.Point(12, 241)
        Me.btnTake_Test_See_Old_Marks.Name = "btnTake_Test_See_Old_Marks"
        Me.btnTake_Test_See_Old_Marks.Size = New System.Drawing.Size(171, 34)
        Me.btnTake_Test_See_Old_Marks.TabIndex = 39
        Me.btnTake_Test_See_Old_Marks.Text = "Take Test"
        Me.btnTake_Test_See_Old_Marks.UseVisualStyleBackColor = False
        '
        'btSee_Next_Test_See_Old_Marks
        '
        Me.btSee_Next_Test_See_Old_Marks.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btSee_Next_Test_See_Old_Marks.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btSee_Next_Test_See_Old_Marks.Location = New System.Drawing.Point(12, 329)
        Me.btSee_Next_Test_See_Old_Marks.Name = "btSee_Next_Test_See_Old_Marks"
        Me.btSee_Next_Test_See_Old_Marks.Size = New System.Drawing.Size(171, 34)
        Me.btSee_Next_Test_See_Old_Marks.TabIndex = 41
        Me.btSee_Next_Test_See_Old_Marks.Text = "See Next Test"
        Me.btSee_Next_Test_See_Old_Marks.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label1.Location = New System.Drawing.Point(207, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(189, 20)
        Me.Label1.TabIndex = 48
        Me.Label1.Text = "Lets See How your Doing"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.txtRecent_Per_Improvement)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txtRecent_Improvement)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.txtPercentage_Increase)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.txtRange_Calculator)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.txtAverage)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.ForeColor = System.Drawing.Color.White
        Me.GroupBox2.Location = New System.Drawing.Point(203, 448)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(552, 178)
        Me.GroupBox2.TabIndex = 49
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Your Progress"
        '
        'txtRecent_Per_Improvement
        '
        Me.txtRecent_Per_Improvement.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtRecent_Per_Improvement.Location = New System.Drawing.Point(463, 81)
        Me.txtRecent_Per_Improvement.Name = "txtRecent_Per_Improvement"
        Me.txtRecent_Per_Improvement.ReadOnly = True
        Me.txtRecent_Per_Improvement.Size = New System.Drawing.Size(52, 20)
        Me.txtRecent_Per_Improvement.TabIndex = 19
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(290, 81)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(154, 17)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Recent % Improvement"
        '
        'txtRecent_Improvement
        '
        Me.txtRecent_Improvement.Location = New System.Drawing.Point(463, 45)
        Me.txtRecent_Improvement.Name = "txtRecent_Improvement"
        Me.txtRecent_Improvement.ReadOnly = True
        Me.txtRecent_Improvement.Size = New System.Drawing.Size(52, 20)
        Me.txtRecent_Improvement.TabIndex = 17
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(290, 45)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(142, 17)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Recent Improvement:"
        '
        'txtPercentage_Increase
        '
        Me.txtPercentage_Increase.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtPercentage_Increase.Location = New System.Drawing.Point(210, 115)
        Me.txtPercentage_Increase.Name = "txtPercentage_Increase"
        Me.txtPercentage_Increase.ReadOnly = True
        Me.txtPercentage_Increase.Size = New System.Drawing.Size(52, 20)
        Me.txtPercentage_Increase.TabIndex = 15
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(37, 115)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(170, 17)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Percentage Improvement:"
        '
        'txtRange_Calculator
        '
        Me.txtRange_Calculator.Location = New System.Drawing.Point(210, 79)
        Me.txtRange_Calculator.Name = "txtRange_Calculator"
        Me.txtRange_Calculator.ReadOnly = True
        Me.txtRange_Calculator.Size = New System.Drawing.Size(52, 20)
        Me.txtRange_Calculator.TabIndex = 13
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(37, 79)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(121, 17)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Range Calculator:"
        '
        'txtAverage
        '
        Me.txtAverage.Location = New System.Drawing.Point(210, 44)
        Me.txtAverage.Name = "txtAverage"
        Me.txtAverage.ReadOnly = True
        Me.txtAverage.Size = New System.Drawing.Size(52, 20)
        Me.txtAverage.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(37, 44)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(144, 17)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Average User Score: "
        '
        'lblStudent_Name
        '
        Me.lblStudent_Name.AutoSize = True
        Me.lblStudent_Name.BackColor = System.Drawing.Color.Transparent
        Me.lblStudent_Name.ForeColor = System.Drawing.Color.White
        Me.lblStudent_Name.Location = New System.Drawing.Point(53, 77)
        Me.lblStudent_Name.Name = "lblStudent_Name"
        Me.lblStudent_Name.Size = New System.Drawing.Size(39, 13)
        Me.lblStudent_Name.TabIndex = 50
        Me.lblStudent_Name.Text = "Label2"
        '
        'lblStudent_Year
        '
        Me.lblStudent_Year.AutoSize = True
        Me.lblStudent_Year.BackColor = System.Drawing.Color.Transparent
        Me.lblStudent_Year.ForeColor = System.Drawing.Color.White
        Me.lblStudent_Year.Location = New System.Drawing.Point(53, 115)
        Me.lblStudent_Year.Name = "lblStudent_Year"
        Me.lblStudent_Year.Size = New System.Drawing.Size(39, 13)
        Me.lblStudent_Year.TabIndex = 51
        Me.lblStudent_Year.Text = "Label3"
        '
        'Student_Menu_See_Old_Marks
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.GPSB_System.My.Resources.Resources.Student_Menu1
        Me.ClientSize = New System.Drawing.Size(764, 638)
        Me.Controls.Add(Me.lblStudent_Year)
        Me.Controls.Add(Me.lblStudent_Name)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.btnLogOff)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.btnSee_Old_Marks_See_Old_Marks)
        Me.Controls.Add(Me.btnTake_Test_See_Old_Marks)
        Me.Controls.Add(Me.btSee_Next_Test_See_Old_Marks)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Student_Menu_See_Old_Marks"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Student Menu - See Old Marks"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgvStudent_Results, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents btnLogOff As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents btnSee_Old_Marks_See_Old_Marks As System.Windows.Forms.Button
    Friend WithEvents btnTake_Test_See_Old_Marks As System.Windows.Forms.Button
    Friend WithEvents btSee_Next_Test_See_Old_Marks As System.Windows.Forms.Button
    Friend WithEvents dgvStudent_Results As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lblStudent_Name As System.Windows.Forms.Label
    Friend WithEvents lblStudent_Year As System.Windows.Forms.Label
    Friend WithEvents txtRecent_Per_Improvement As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtRecent_Improvement As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtPercentage_Increase As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtRange_Calculator As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtAverage As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
