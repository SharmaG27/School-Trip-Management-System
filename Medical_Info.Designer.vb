<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Medical_Info
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
        Me.dgv_Medical = New System.Windows.Forms.DataGridView()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lbl_medication = New System.Windows.Forms.Label()
        Me.txt_medication = New System.Windows.Forms.TextBox()
        Me.lbl_Access = New System.Windows.Forms.Label()
        Me.txt_accessLevel = New System.Windows.Forms.TextBox()
        Me.lbl_conditions = New System.Windows.Forms.Label()
        Me.txt_conditions = New System.Windows.Forms.TextBox()
        Me.lbl_Student = New System.Windows.Forms.Label()
        Me.lbl_surname = New System.Windows.Forms.Label()
        Me.lbl_name = New System.Windows.Forms.Label()
        Me.txt_surname = New System.Windows.Forms.TextBox()
        Me.txt_name = New System.Windows.Forms.TextBox()
        Me.cbox_student = New System.Windows.Forms.ComboBox()
        Me.lbl_medicalID = New System.Windows.Forms.Label()
        Me.txt_MedicalID = New System.Windows.Forms.TextBox()
        Me.rad_YesMedical = New System.Windows.Forms.RadioButton()
        Me.rad_NoMedical = New System.Windows.Forms.RadioButton()
        Me.lbl_MedicalDetailsQuestion = New System.Windows.Forms.Label()
        Me.pbx_LastRecord = New System.Windows.Forms.PictureBox()
        Me.pbx_NextRecord = New System.Windows.Forms.PictureBox()
        Me.pbx_PreviousRecord = New System.Windows.Forms.PictureBox()
        Me.pbx_first = New System.Windows.Forms.PictureBox()
        Me.pbx_Delete = New System.Windows.Forms.PictureBox()
        Me.pbx_Save = New System.Windows.Forms.PictureBox()
        Me.pbx_New = New System.Windows.Forms.PictureBox()
        Me.pbx_close = New System.Windows.Forms.PictureBox()
        Me.pbx_MainMenu = New System.Windows.Forms.PictureBox()
        Me.pic_Help = New System.Windows.Forms.PictureBox()
        Me.lbl_Personal = New System.Windows.Forms.Label()
        Me.lbl_MedDetails = New System.Windows.Forms.Label()
        Me.pbx_back = New System.Windows.Forms.PictureBox()
        CType(Me.dgv_Medical, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbx_LastRecord, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbx_NextRecord, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbx_PreviousRecord, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbx_first, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbx_Delete, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbx_Save, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbx_New, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbx_close, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbx_MainMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pic_Help, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbx_back, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgv_Medical
        '
        Me.dgv_Medical.AllowUserToAddRows = False
        Me.dgv_Medical.AllowUserToDeleteRows = False
        Me.dgv_Medical.BackgroundColor = System.Drawing.Color.LightSteelBlue
        Me.dgv_Medical.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_Medical.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column3, Me.Column1, Me.Column2, Me.Column4, Me.Column5, Me.Column6})
        Me.dgv_Medical.GridColor = System.Drawing.Color.LightGray
        Me.dgv_Medical.Location = New System.Drawing.Point(19, 75)
        Me.dgv_Medical.Margin = New System.Windows.Forms.Padding(4)
        Me.dgv_Medical.Name = "dgv_Medical"
        Me.dgv_Medical.ReadOnly = True
        Me.dgv_Medical.RowHeadersVisible = False
        Me.dgv_Medical.RowHeadersWidth = 51
        Me.dgv_Medical.Size = New System.Drawing.Size(1432, 386)
        Me.dgv_Medical.TabIndex = 20
        '
        'Column3
        '
        Me.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column3.HeaderText = "Medical ID"
        Me.Column3.MinimumWidth = 20
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column1.HeaderText = "Surname"
        Me.Column1.MinimumWidth = 6
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column2.HeaderText = "Name"
        Me.Column2.MinimumWidth = 6
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column4.HeaderText = "Access Level"
        Me.Column4.MinimumWidth = 6
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Column5
        '
        Me.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column5.HeaderText = "Medication"
        Me.Column5.MinimumWidth = 6
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'Column6
        '
        Me.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column6.HeaderText = "Conditions"
        Me.Column6.MinimumWidth = 6
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'lbl_medication
        '
        Me.lbl_medication.AutoSize = True
        Me.lbl_medication.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lbl_medication.Location = New System.Drawing.Point(359, 544)
        Me.lbl_medication.Name = "lbl_medication"
        Me.lbl_medication.Size = New System.Drawing.Size(84, 20)
        Me.lbl_medication.TabIndex = 89
        Me.lbl_medication.Text = "Medication"
        '
        'txt_medication
        '
        Me.txt_medication.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txt_medication.Location = New System.Drawing.Point(360, 564)
        Me.txt_medication.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txt_medication.Name = "txt_medication"
        Me.txt_medication.Size = New System.Drawing.Size(217, 27)
        Me.txt_medication.TabIndex = 88
        '
        'lbl_Access
        '
        Me.lbl_Access.AutoSize = True
        Me.lbl_Access.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lbl_Access.Location = New System.Drawing.Point(29, 605)
        Me.lbl_Access.Name = "lbl_Access"
        Me.lbl_Access.Size = New System.Drawing.Size(91, 20)
        Me.lbl_Access.TabIndex = 87
        Me.lbl_Access.Text = "Access Level"
        '
        'txt_accessLevel
        '
        Me.txt_accessLevel.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txt_accessLevel.Location = New System.Drawing.Point(32, 625)
        Me.txt_accessLevel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txt_accessLevel.Name = "txt_accessLevel"
        Me.txt_accessLevel.ReadOnly = True
        Me.txt_accessLevel.Size = New System.Drawing.Size(217, 27)
        Me.txt_accessLevel.TabIndex = 86
        '
        'lbl_conditions
        '
        Me.lbl_conditions.AutoSize = True
        Me.lbl_conditions.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lbl_conditions.Location = New System.Drawing.Point(358, 605)
        Me.lbl_conditions.Name = "lbl_conditions"
        Me.lbl_conditions.Size = New System.Drawing.Size(80, 20)
        Me.lbl_conditions.TabIndex = 85
        Me.lbl_conditions.Text = "Conditions"
        '
        'txt_conditions
        '
        Me.txt_conditions.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txt_conditions.Location = New System.Drawing.Point(360, 625)
        Me.txt_conditions.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txt_conditions.Name = "txt_conditions"
        Me.txt_conditions.Size = New System.Drawing.Size(217, 27)
        Me.txt_conditions.TabIndex = 84
        '
        'lbl_Student
        '
        Me.lbl_Student.AutoSize = True
        Me.lbl_Student.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lbl_Student.Location = New System.Drawing.Point(27, 545)
        Me.lbl_Student.Name = "lbl_Student"
        Me.lbl_Student.Size = New System.Drawing.Size(60, 20)
        Me.lbl_Student.TabIndex = 82
        Me.lbl_Student.Text = "Student"
        '
        'lbl_surname
        '
        Me.lbl_surname.AutoSize = True
        Me.lbl_surname.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lbl_surname.Location = New System.Drawing.Point(28, 738)
        Me.lbl_surname.Name = "lbl_surname"
        Me.lbl_surname.Size = New System.Drawing.Size(67, 20)
        Me.lbl_surname.TabIndex = 81
        Me.lbl_surname.Text = "Surname"
        '
        'lbl_name
        '
        Me.lbl_name.AutoSize = True
        Me.lbl_name.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lbl_name.Location = New System.Drawing.Point(28, 671)
        Me.lbl_name.Name = "lbl_name"
        Me.lbl_name.Size = New System.Drawing.Size(75, 20)
        Me.lbl_name.TabIndex = 80
        Me.lbl_name.Text = "Forename"
        '
        'txt_surname
        '
        Me.txt_surname.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txt_surname.Location = New System.Drawing.Point(31, 758)
        Me.txt_surname.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txt_surname.Name = "txt_surname"
        Me.txt_surname.ReadOnly = True
        Me.txt_surname.Size = New System.Drawing.Size(217, 27)
        Me.txt_surname.TabIndex = 79
        '
        'txt_name
        '
        Me.txt_name.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txt_name.Location = New System.Drawing.Point(30, 691)
        Me.txt_name.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txt_name.Name = "txt_name"
        Me.txt_name.ReadOnly = True
        Me.txt_name.Size = New System.Drawing.Size(217, 27)
        Me.txt_name.TabIndex = 78
        '
        'cbox_student
        '
        Me.cbox_student.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cbox_student.FormattingEnabled = True
        Me.cbox_student.Location = New System.Drawing.Point(32, 564)
        Me.cbox_student.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cbox_student.Name = "cbox_student"
        Me.cbox_student.Size = New System.Drawing.Size(216, 28)
        Me.cbox_student.TabIndex = 90
        '
        'lbl_medicalID
        '
        Me.lbl_medicalID.AutoSize = True
        Me.lbl_medicalID.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lbl_medicalID.Location = New System.Drawing.Point(359, 738)
        Me.lbl_medicalID.Name = "lbl_medicalID"
        Me.lbl_medicalID.Size = New System.Drawing.Size(81, 20)
        Me.lbl_medicalID.TabIndex = 120
        Me.lbl_medicalID.Text = "Medical ID"
        '
        'txt_MedicalID
        '
        Me.txt_MedicalID.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txt_MedicalID.Location = New System.Drawing.Point(360, 758)
        Me.txt_MedicalID.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txt_MedicalID.Name = "txt_MedicalID"
        Me.txt_MedicalID.ReadOnly = True
        Me.txt_MedicalID.Size = New System.Drawing.Size(217, 27)
        Me.txt_MedicalID.TabIndex = 119
        '
        'rad_YesMedical
        '
        Me.rad_YesMedical.AutoSize = True
        Me.rad_YesMedical.Cursor = System.Windows.Forms.Cursors.Default
        Me.rad_YesMedical.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rad_YesMedical.Location = New System.Drawing.Point(359, 691)
        Me.rad_YesMedical.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.rad_YesMedical.Name = "rad_YesMedical"
        Me.rad_YesMedical.Size = New System.Drawing.Size(51, 24)
        Me.rad_YesMedical.TabIndex = 122
        Me.rad_YesMedical.TabStop = True
        Me.rad_YesMedical.Text = "Yes"
        Me.rad_YesMedical.UseVisualStyleBackColor = True
        '
        'rad_NoMedical
        '
        Me.rad_NoMedical.AutoSize = True
        Me.rad_NoMedical.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rad_NoMedical.Location = New System.Drawing.Point(493, 691)
        Me.rad_NoMedical.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.rad_NoMedical.Name = "rad_NoMedical"
        Me.rad_NoMedical.Size = New System.Drawing.Size(50, 24)
        Me.rad_NoMedical.TabIndex = 123
        Me.rad_NoMedical.TabStop = True
        Me.rad_NoMedical.Text = "No"
        Me.rad_NoMedical.UseVisualStyleBackColor = True
        '
        'lbl_MedicalDetailsQuestion
        '
        Me.lbl_MedicalDetailsQuestion.AutoSize = True
        Me.lbl_MedicalDetailsQuestion.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lbl_MedicalDetailsQuestion.Location = New System.Drawing.Point(356, 671)
        Me.lbl_MedicalDetailsQuestion.Name = "lbl_MedicalDetailsQuestion"
        Me.lbl_MedicalDetailsQuestion.Size = New System.Drawing.Size(331, 20)
        Me.lbl_MedicalDetailsQuestion.TabIndex = 124
        Me.lbl_MedicalDetailsQuestion.Text = "Does the student need any medical information?"
        '
        'pbx_LastRecord
        '
        Me.pbx_LastRecord.Location = New System.Drawing.Point(1303, 515)
        Me.pbx_LastRecord.Name = "pbx_LastRecord"
        Me.pbx_LastRecord.Size = New System.Drawing.Size(127, 57)
        Me.pbx_LastRecord.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbx_LastRecord.TabIndex = 128
        Me.pbx_LastRecord.TabStop = False
        '
        'pbx_NextRecord
        '
        Me.pbx_NextRecord.Location = New System.Drawing.Point(1304, 577)
        Me.pbx_NextRecord.Name = "pbx_NextRecord"
        Me.pbx_NextRecord.Size = New System.Drawing.Size(127, 57)
        Me.pbx_NextRecord.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbx_NextRecord.TabIndex = 127
        Me.pbx_NextRecord.TabStop = False
        '
        'pbx_PreviousRecord
        '
        Me.pbx_PreviousRecord.Location = New System.Drawing.Point(1010, 575)
        Me.pbx_PreviousRecord.Name = "pbx_PreviousRecord"
        Me.pbx_PreviousRecord.Size = New System.Drawing.Size(127, 57)
        Me.pbx_PreviousRecord.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbx_PreviousRecord.TabIndex = 126
        Me.pbx_PreviousRecord.TabStop = False
        '
        'pbx_first
        '
        Me.pbx_first.Location = New System.Drawing.Point(1010, 515)
        Me.pbx_first.Name = "pbx_first"
        Me.pbx_first.Size = New System.Drawing.Size(127, 57)
        Me.pbx_first.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbx_first.TabIndex = 125
        Me.pbx_first.TabStop = False
        '
        'pbx_Delete
        '
        Me.pbx_Delete.Location = New System.Drawing.Point(1303, 669)
        Me.pbx_Delete.Name = "pbx_Delete"
        Me.pbx_Delete.Size = New System.Drawing.Size(127, 57)
        Me.pbx_Delete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbx_Delete.TabIndex = 131
        Me.pbx_Delete.TabStop = False
        '
        'pbx_Save
        '
        Me.pbx_Save.Location = New System.Drawing.Point(1157, 669)
        Me.pbx_Save.Name = "pbx_Save"
        Me.pbx_Save.Size = New System.Drawing.Size(127, 57)
        Me.pbx_Save.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbx_Save.TabIndex = 130
        Me.pbx_Save.TabStop = False
        '
        'pbx_New
        '
        Me.pbx_New.Location = New System.Drawing.Point(1010, 669)
        Me.pbx_New.Name = "pbx_New"
        Me.pbx_New.Size = New System.Drawing.Size(127, 57)
        Me.pbx_New.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbx_New.TabIndex = 129
        Me.pbx_New.TabStop = False
        '
        'pbx_close
        '
        Me.pbx_close.Location = New System.Drawing.Point(1354, 11)
        Me.pbx_close.Name = "pbx_close"
        Me.pbx_close.Size = New System.Drawing.Size(98, 44)
        Me.pbx_close.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbx_close.TabIndex = 132
        Me.pbx_close.TabStop = False
        '
        'pbx_MainMenu
        '
        Me.pbx_MainMenu.Location = New System.Drawing.Point(1250, 11)
        Me.pbx_MainMenu.Name = "pbx_MainMenu"
        Me.pbx_MainMenu.Size = New System.Drawing.Size(98, 44)
        Me.pbx_MainMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbx_MainMenu.TabIndex = 133
        Me.pbx_MainMenu.TabStop = False
        '
        'pic_Help
        '
        Me.pic_Help.Location = New System.Drawing.Point(12, 11)
        Me.pic_Help.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pic_Help.Name = "pic_Help"
        Me.pic_Help.Size = New System.Drawing.Size(43, 36)
        Me.pic_Help.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pic_Help.TabIndex = 139
        Me.pic_Help.TabStop = False
        '
        'lbl_Personal
        '
        Me.lbl_Personal.AutoSize = True
        Me.lbl_Personal.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Personal.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Personal.ForeColor = System.Drawing.Color.RoyalBlue
        Me.lbl_Personal.Location = New System.Drawing.Point(51, 496)
        Me.lbl_Personal.Name = "lbl_Personal"
        Me.lbl_Personal.Size = New System.Drawing.Size(172, 28)
        Me.lbl_Personal.TabIndex = 144
        Me.lbl_Personal.Text = "Student's Details"
        '
        'lbl_MedDetails
        '
        Me.lbl_MedDetails.AutoSize = True
        Me.lbl_MedDetails.BackColor = System.Drawing.Color.Transparent
        Me.lbl_MedDetails.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_MedDetails.ForeColor = System.Drawing.Color.RoyalBlue
        Me.lbl_MedDetails.Location = New System.Drawing.Point(383, 496)
        Me.lbl_MedDetails.Name = "lbl_MedDetails"
        Me.lbl_MedDetails.Size = New System.Drawing.Size(159, 28)
        Me.lbl_MedDetails.TabIndex = 143
        Me.lbl_MedDetails.Text = "Medical Details"
        '
        'pbx_back
        '
        Me.pbx_back.Location = New System.Drawing.Point(1257, -121)
        Me.pbx_back.Name = "pbx_back"
        Me.pbx_back.Size = New System.Drawing.Size(98, 44)
        Me.pbx_back.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbx_back.TabIndex = 142
        Me.pbx_back.TabStop = False
        '
        'Medical_Info
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ClientSize = New System.Drawing.Size(1464, 817)
        Me.Controls.Add(Me.lbl_Personal)
        Me.Controls.Add(Me.lbl_MedDetails)
        Me.Controls.Add(Me.pbx_back)
        Me.Controls.Add(Me.pic_Help)
        Me.Controls.Add(Me.pbx_MainMenu)
        Me.Controls.Add(Me.pbx_close)
        Me.Controls.Add(Me.pbx_Delete)
        Me.Controls.Add(Me.pbx_Save)
        Me.Controls.Add(Me.pbx_New)
        Me.Controls.Add(Me.pbx_LastRecord)
        Me.Controls.Add(Me.pbx_NextRecord)
        Me.Controls.Add(Me.pbx_PreviousRecord)
        Me.Controls.Add(Me.pbx_first)
        Me.Controls.Add(Me.lbl_MedicalDetailsQuestion)
        Me.Controls.Add(Me.rad_NoMedical)
        Me.Controls.Add(Me.rad_YesMedical)
        Me.Controls.Add(Me.lbl_medicalID)
        Me.Controls.Add(Me.txt_MedicalID)
        Me.Controls.Add(Me.cbox_student)
        Me.Controls.Add(Me.lbl_medication)
        Me.Controls.Add(Me.txt_medication)
        Me.Controls.Add(Me.lbl_Access)
        Me.Controls.Add(Me.txt_accessLevel)
        Me.Controls.Add(Me.lbl_conditions)
        Me.Controls.Add(Me.txt_conditions)
        Me.Controls.Add(Me.lbl_Student)
        Me.Controls.Add(Me.lbl_surname)
        Me.Controls.Add(Me.lbl_name)
        Me.Controls.Add(Me.txt_surname)
        Me.Controls.Add(Me.txt_name)
        Me.Controls.Add(Me.dgv_Medical)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Medical_Info"
        Me.Text = "Medical_Info"
        CType(Me.dgv_Medical, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbx_LastRecord, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbx_NextRecord, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbx_PreviousRecord, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbx_first, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbx_Delete, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbx_Save, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbx_New, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbx_close, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbx_MainMenu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pic_Help, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbx_back, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgv_Medical As DataGridView
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents lbl_medication As Label
    Friend WithEvents txt_medication As TextBox
    Friend WithEvents lbl_Access As Label
    Friend WithEvents txt_accessLevel As TextBox
    Friend WithEvents lbl_conditions As Label
    Friend WithEvents txt_conditions As TextBox
    Friend WithEvents lbl_Student As Label
    Friend WithEvents lbl_surname As Label
    Friend WithEvents lbl_name As Label
    Friend WithEvents txt_surname As TextBox
    Friend WithEvents txt_name As TextBox
    Friend WithEvents cbox_student As ComboBox
    Friend WithEvents lbl_medicalID As Label
    Friend WithEvents txt_MedicalID As TextBox
    Friend WithEvents rad_YesMedical As RadioButton
    Friend WithEvents rad_NoMedical As RadioButton
    Friend WithEvents lbl_MedicalDetailsQuestion As Label
    Friend WithEvents pbx_LastRecord As PictureBox
    Friend WithEvents pbx_NextRecord As PictureBox
    Friend WithEvents pbx_PreviousRecord As PictureBox
    Friend WithEvents pbx_first As PictureBox
    Friend WithEvents pbx_Delete As PictureBox
    Friend WithEvents pbx_Save As PictureBox
    Friend WithEvents pbx_New As PictureBox
    Friend WithEvents pbx_close As PictureBox
    Friend WithEvents pbx_MainMenu As PictureBox
    Friend WithEvents pic_Help As PictureBox
    Friend WithEvents lbl_Personal As Label
    Friend WithEvents lbl_MedDetails As Label
    Friend WithEvents pbx_back As PictureBox
End Class
