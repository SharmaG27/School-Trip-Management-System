<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Emergency_Contacts
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
        Me.dgv_emergencyContacts = New System.Windows.Forms.DataGridView()
        Me.lbl_access = New System.Windows.Forms.Label()
        Me.txt_accessLevel = New System.Windows.Forms.TextBox()
        Me.cbox_student = New System.Windows.Forms.ComboBox()
        Me.lbl_postCode = New System.Windows.Forms.Label()
        Me.txt_postCode = New System.Windows.Forms.TextBox()
        Me.lbl_name = New System.Windows.Forms.Label()
        Me.txt_name = New System.Windows.Forms.TextBox()
        Me.lbl_relationship = New System.Windows.Forms.Label()
        Me.txt_relationship = New System.Windows.Forms.TextBox()
        Me.lbl_Student = New System.Windows.Forms.Label()
        Me.lbl_phoneNum = New System.Windows.Forms.Label()
        Me.lbl_surname = New System.Windows.Forms.Label()
        Me.txt_phoneNum = New System.Windows.Forms.TextBox()
        Me.txt_surname = New System.Windows.Forms.TextBox()
        Me.lbl_emergencyID = New System.Windows.Forms.Label()
        Me.txt_emergencyID = New System.Windows.Forms.TextBox()
        Me.lbl_EmergencyDetailsQuestion = New System.Windows.Forms.Label()
        Me.rad_NoEmergency = New System.Windows.Forms.RadioButton()
        Me.rad_YesEmergency = New System.Windows.Forms.RadioButton()
        Me.pbx_close = New System.Windows.Forms.PictureBox()
        Me.pbx_Delete = New System.Windows.Forms.PictureBox()
        Me.pbx_Save = New System.Windows.Forms.PictureBox()
        Me.pbx_New = New System.Windows.Forms.PictureBox()
        Me.pbx_LastRecord = New System.Windows.Forms.PictureBox()
        Me.pbx_NextRecord = New System.Windows.Forms.PictureBox()
        Me.pbx_PreviousRecord = New System.Windows.Forms.PictureBox()
        Me.pbx_first = New System.Windows.Forms.PictureBox()
        Me.pbx_MainMenu = New System.Windows.Forms.PictureBox()
        Me.pic_Help = New System.Windows.Forms.PictureBox()
        Me.lbl_StudentDetails = New System.Windows.Forms.Label()
        Me.lbl_Contacts = New System.Windows.Forms.Label()
        Me.lbl_Login = New System.Windows.Forms.Label()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgv_emergencyContacts, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbx_close, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbx_Delete, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbx_Save, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbx_New, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbx_LastRecord, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbx_NextRecord, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbx_PreviousRecord, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbx_first, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbx_MainMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pic_Help, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgv_emergencyContacts
        '
        Me.dgv_emergencyContacts.AllowUserToAddRows = False
        Me.dgv_emergencyContacts.AllowUserToDeleteRows = False
        Me.dgv_emergencyContacts.BackgroundColor = System.Drawing.Color.LightSteelBlue
        Me.dgv_emergencyContacts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_emergencyContacts.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column3, Me.Column1, Me.Column2, Me.Column7, Me.Column4, Me.Column5, Me.Column6})
        Me.dgv_emergencyContacts.GridColor = System.Drawing.Color.LightGray
        Me.dgv_emergencyContacts.Location = New System.Drawing.Point(13, 68)
        Me.dgv_emergencyContacts.Margin = New System.Windows.Forms.Padding(4)
        Me.dgv_emergencyContacts.Name = "dgv_emergencyContacts"
        Me.dgv_emergencyContacts.ReadOnly = True
        Me.dgv_emergencyContacts.RowHeadersVisible = False
        Me.dgv_emergencyContacts.RowHeadersWidth = 51
        Me.dgv_emergencyContacts.Size = New System.Drawing.Size(1432, 386)
        Me.dgv_emergencyContacts.TabIndex = 21
        '
        'lbl_access
        '
        Me.lbl_access.AutoSize = True
        Me.lbl_access.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lbl_access.Location = New System.Drawing.Point(20, 607)
        Me.lbl_access.Name = "lbl_access"
        Me.lbl_access.Size = New System.Drawing.Size(155, 20)
        Me.lbl_access.TabIndex = 134
        Me.lbl_access.Text = "Student's Access Level"
        '
        'txt_accessLevel
        '
        Me.txt_accessLevel.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txt_accessLevel.Location = New System.Drawing.Point(22, 629)
        Me.txt_accessLevel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txt_accessLevel.Name = "txt_accessLevel"
        Me.txt_accessLevel.ReadOnly = True
        Me.txt_accessLevel.Size = New System.Drawing.Size(217, 27)
        Me.txt_accessLevel.TabIndex = 133
        '
        'cbox_student
        '
        Me.cbox_student.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cbox_student.FormattingEnabled = True
        Me.cbox_student.Location = New System.Drawing.Point(23, 562)
        Me.cbox_student.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cbox_student.Name = "cbox_student"
        Me.cbox_student.Size = New System.Drawing.Size(216, 28)
        Me.cbox_student.TabIndex = 132
        '
        'lbl_postCode
        '
        Me.lbl_postCode.AutoSize = True
        Me.lbl_postCode.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lbl_postCode.Location = New System.Drawing.Point(513, 543)
        Me.lbl_postCode.Name = "lbl_postCode"
        Me.lbl_postCode.Size = New System.Drawing.Size(145, 20)
        Me.lbl_postCode.TabIndex = 131
        Me.lbl_postCode.Text = "Post Code (LL00 0LL)"
        '
        'txt_postCode
        '
        Me.txt_postCode.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txt_postCode.Location = New System.Drawing.Point(514, 563)
        Me.txt_postCode.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txt_postCode.Name = "txt_postCode"
        Me.txt_postCode.Size = New System.Drawing.Size(217, 27)
        Me.txt_postCode.TabIndex = 130
        '
        'lbl_name
        '
        Me.lbl_name.AutoSize = True
        Me.lbl_name.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lbl_name.Location = New System.Drawing.Point(265, 542)
        Me.lbl_name.Name = "lbl_name"
        Me.lbl_name.Size = New System.Drawing.Size(75, 20)
        Me.lbl_name.TabIndex = 129
        Me.lbl_name.Text = "Forename"
        '
        'txt_name
        '
        Me.txt_name.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txt_name.Location = New System.Drawing.Point(266, 562)
        Me.txt_name.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txt_name.Name = "txt_name"
        Me.txt_name.Size = New System.Drawing.Size(217, 27)
        Me.txt_name.TabIndex = 128
        '
        'lbl_relationship
        '
        Me.lbl_relationship.AutoSize = True
        Me.lbl_relationship.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lbl_relationship.Location = New System.Drawing.Point(513, 609)
        Me.lbl_relationship.Name = "lbl_relationship"
        Me.lbl_relationship.Size = New System.Drawing.Size(164, 20)
        Me.lbl_relationship.TabIndex = 127
        Me.lbl_relationship.Text = "Relationship to Student"
        '
        'txt_relationship
        '
        Me.txt_relationship.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txt_relationship.Location = New System.Drawing.Point(514, 627)
        Me.txt_relationship.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txt_relationship.Name = "txt_relationship"
        Me.txt_relationship.Size = New System.Drawing.Size(217, 27)
        Me.txt_relationship.TabIndex = 126
        '
        'lbl_Student
        '
        Me.lbl_Student.AutoSize = True
        Me.lbl_Student.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lbl_Student.Location = New System.Drawing.Point(20, 542)
        Me.lbl_Student.Name = "lbl_Student"
        Me.lbl_Student.Size = New System.Drawing.Size(60, 20)
        Me.lbl_Student.TabIndex = 125
        Me.lbl_Student.Text = "Student"
        '
        'lbl_phoneNum
        '
        Me.lbl_phoneNum.AutoSize = True
        Me.lbl_phoneNum.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lbl_phoneNum.Location = New System.Drawing.Point(513, 677)
        Me.lbl_phoneNum.Name = "lbl_phoneNum"
        Me.lbl_phoneNum.Size = New System.Drawing.Size(108, 20)
        Me.lbl_phoneNum.TabIndex = 124
        Me.lbl_phoneNum.Text = "Phone Number"
        '
        'lbl_surname
        '
        Me.lbl_surname.AutoSize = True
        Me.lbl_surname.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lbl_surname.Location = New System.Drawing.Point(263, 607)
        Me.lbl_surname.Name = "lbl_surname"
        Me.lbl_surname.Size = New System.Drawing.Size(67, 20)
        Me.lbl_surname.TabIndex = 123
        Me.lbl_surname.Text = "Surname"
        '
        'txt_phoneNum
        '
        Me.txt_phoneNum.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txt_phoneNum.Location = New System.Drawing.Point(516, 695)
        Me.txt_phoneNum.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txt_phoneNum.Name = "txt_phoneNum"
        Me.txt_phoneNum.Size = New System.Drawing.Size(217, 27)
        Me.txt_phoneNum.TabIndex = 122
        '
        'txt_surname
        '
        Me.txt_surname.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txt_surname.Location = New System.Drawing.Point(266, 629)
        Me.txt_surname.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txt_surname.Name = "txt_surname"
        Me.txt_surname.Size = New System.Drawing.Size(217, 27)
        Me.txt_surname.TabIndex = 121
        '
        'lbl_emergencyID
        '
        Me.lbl_emergencyID.AutoSize = True
        Me.lbl_emergencyID.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lbl_emergencyID.Location = New System.Drawing.Point(22, 677)
        Me.lbl_emergencyID.Name = "lbl_emergencyID"
        Me.lbl_emergencyID.Size = New System.Drawing.Size(165, 20)
        Me.lbl_emergencyID.TabIndex = 144
        Me.lbl_emergencyID.Text = "Student's Emergency ID"
        '
        'txt_emergencyID
        '
        Me.txt_emergencyID.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txt_emergencyID.Location = New System.Drawing.Point(24, 699)
        Me.txt_emergencyID.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txt_emergencyID.Name = "txt_emergencyID"
        Me.txt_emergencyID.ReadOnly = True
        Me.txt_emergencyID.Size = New System.Drawing.Size(217, 27)
        Me.txt_emergencyID.TabIndex = 143
        '
        'lbl_EmergencyDetailsQuestion
        '
        Me.lbl_EmergencyDetailsQuestion.AutoSize = True
        Me.lbl_EmergencyDetailsQuestion.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lbl_EmergencyDetailsQuestion.Location = New System.Drawing.Point(24, 754)
        Me.lbl_EmergencyDetailsQuestion.Name = "lbl_EmergencyDetailsQuestion"
        Me.lbl_EmergencyDetailsQuestion.Size = New System.Drawing.Size(373, 20)
        Me.lbl_EmergencyDetailsQuestion.TabIndex = 147
        Me.lbl_EmergencyDetailsQuestion.Text = "Do you have the student's emergency contact's details?"
        '
        'rad_NoEmergency
        '
        Me.rad_NoEmergency.AutoSize = True
        Me.rad_NoEmergency.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rad_NoEmergency.Location = New System.Drawing.Point(161, 774)
        Me.rad_NoEmergency.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.rad_NoEmergency.Name = "rad_NoEmergency"
        Me.rad_NoEmergency.Size = New System.Drawing.Size(50, 24)
        Me.rad_NoEmergency.TabIndex = 146
        Me.rad_NoEmergency.TabStop = True
        Me.rad_NoEmergency.Text = "No"
        Me.rad_NoEmergency.UseVisualStyleBackColor = True
        '
        'rad_YesEmergency
        '
        Me.rad_YesEmergency.AutoSize = True
        Me.rad_YesEmergency.Cursor = System.Windows.Forms.Cursors.Default
        Me.rad_YesEmergency.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rad_YesEmergency.Location = New System.Drawing.Point(28, 774)
        Me.rad_YesEmergency.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.rad_YesEmergency.Name = "rad_YesEmergency"
        Me.rad_YesEmergency.Size = New System.Drawing.Size(51, 24)
        Me.rad_YesEmergency.TabIndex = 145
        Me.rad_YesEmergency.TabStop = True
        Me.rad_YesEmergency.Text = "Yes"
        Me.rad_YesEmergency.UseVisualStyleBackColor = True
        '
        'pbx_close
        '
        Me.pbx_close.Location = New System.Drawing.Point(1347, 12)
        Me.pbx_close.Name = "pbx_close"
        Me.pbx_close.Size = New System.Drawing.Size(98, 44)
        Me.pbx_close.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbx_close.TabIndex = 155
        Me.pbx_close.TabStop = False
        '
        'pbx_Delete
        '
        Me.pbx_Delete.Location = New System.Drawing.Point(1299, 687)
        Me.pbx_Delete.Name = "pbx_Delete"
        Me.pbx_Delete.Size = New System.Drawing.Size(127, 57)
        Me.pbx_Delete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbx_Delete.TabIndex = 154
        Me.pbx_Delete.TabStop = False
        '
        'pbx_Save
        '
        Me.pbx_Save.Location = New System.Drawing.Point(1126, 687)
        Me.pbx_Save.Name = "pbx_Save"
        Me.pbx_Save.Size = New System.Drawing.Size(127, 57)
        Me.pbx_Save.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbx_Save.TabIndex = 153
        Me.pbx_Save.TabStop = False
        '
        'pbx_New
        '
        Me.pbx_New.Location = New System.Drawing.Point(951, 687)
        Me.pbx_New.Name = "pbx_New"
        Me.pbx_New.Size = New System.Drawing.Size(127, 57)
        Me.pbx_New.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbx_New.TabIndex = 152
        Me.pbx_New.TabStop = False
        '
        'pbx_LastRecord
        '
        Me.pbx_LastRecord.Location = New System.Drawing.Point(1299, 515)
        Me.pbx_LastRecord.Name = "pbx_LastRecord"
        Me.pbx_LastRecord.Size = New System.Drawing.Size(127, 57)
        Me.pbx_LastRecord.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbx_LastRecord.TabIndex = 151
        Me.pbx_LastRecord.TabStop = False
        '
        'pbx_NextRecord
        '
        Me.pbx_NextRecord.Location = New System.Drawing.Point(1299, 582)
        Me.pbx_NextRecord.Name = "pbx_NextRecord"
        Me.pbx_NextRecord.Size = New System.Drawing.Size(127, 57)
        Me.pbx_NextRecord.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbx_NextRecord.TabIndex = 150
        Me.pbx_NextRecord.TabStop = False
        '
        'pbx_PreviousRecord
        '
        Me.pbx_PreviousRecord.Location = New System.Drawing.Point(951, 582)
        Me.pbx_PreviousRecord.Name = "pbx_PreviousRecord"
        Me.pbx_PreviousRecord.Size = New System.Drawing.Size(127, 57)
        Me.pbx_PreviousRecord.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbx_PreviousRecord.TabIndex = 149
        Me.pbx_PreviousRecord.TabStop = False
        '
        'pbx_first
        '
        Me.pbx_first.Location = New System.Drawing.Point(951, 515)
        Me.pbx_first.Name = "pbx_first"
        Me.pbx_first.Size = New System.Drawing.Size(127, 57)
        Me.pbx_first.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbx_first.TabIndex = 148
        Me.pbx_first.TabStop = False
        '
        'pbx_MainMenu
        '
        Me.pbx_MainMenu.Location = New System.Drawing.Point(1243, 12)
        Me.pbx_MainMenu.Name = "pbx_MainMenu"
        Me.pbx_MainMenu.Size = New System.Drawing.Size(98, 44)
        Me.pbx_MainMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbx_MainMenu.TabIndex = 156
        Me.pbx_MainMenu.TabStop = False
        '
        'pic_Help
        '
        Me.pic_Help.Location = New System.Drawing.Point(12, 11)
        Me.pic_Help.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pic_Help.Name = "pic_Help"
        Me.pic_Help.Size = New System.Drawing.Size(43, 36)
        Me.pic_Help.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pic_Help.TabIndex = 157
        Me.pic_Help.TabStop = False
        '
        'lbl_StudentDetails
        '
        Me.lbl_StudentDetails.AutoSize = True
        Me.lbl_StudentDetails.BackColor = System.Drawing.Color.Transparent
        Me.lbl_StudentDetails.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_StudentDetails.ForeColor = System.Drawing.Color.RoyalBlue
        Me.lbl_StudentDetails.Location = New System.Drawing.Point(43, 481)
        Me.lbl_StudentDetails.Name = "lbl_StudentDetails"
        Me.lbl_StudentDetails.Size = New System.Drawing.Size(158, 28)
        Me.lbl_StudentDetails.TabIndex = 160
        Me.lbl_StudentDetails.Text = "Student Details"
        '
        'lbl_Contacts
        '
        Me.lbl_Contacts.AutoSize = True
        Me.lbl_Contacts.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Contacts.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Contacts.ForeColor = System.Drawing.Color.RoyalBlue
        Me.lbl_Contacts.Location = New System.Drawing.Point(318, 467)
        Me.lbl_Contacts.Name = "lbl_Contacts"
        Me.lbl_Contacts.Size = New System.Drawing.Size(108, 56)
        Me.lbl_Contacts.TabIndex = 159
        Me.lbl_Contacts.Text = "Parent's" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Full Name"
        Me.lbl_Contacts.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_Login
        '
        Me.lbl_Login.AutoSize = True
        Me.lbl_Login.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Login.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Login.ForeColor = System.Drawing.Color.RoyalBlue
        Me.lbl_Login.Location = New System.Drawing.Point(549, 467)
        Me.lbl_Login.Name = "lbl_Login"
        Me.lbl_Login.Size = New System.Drawing.Size(130, 56)
        Me.lbl_Login.TabIndex = 158
        Me.lbl_Login.Text = "Parent's " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Critical Data"
        Me.lbl_Login.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Column3
        '
        Me.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column3.HeaderText = "Emergency ID"
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
        'Column7
        '
        Me.Column7.HeaderText = "Access Level"
        Me.Column7.MinimumWidth = 6
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.Visible = False
        Me.Column7.Width = 125
        '
        'Column4
        '
        Me.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column4.HeaderText = "Phone Number"
        Me.Column4.MinimumWidth = 6
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Column5
        '
        Me.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column5.HeaderText = "Postcode"
        Me.Column5.MinimumWidth = 6
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'Column6
        '
        Me.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column6.HeaderText = "Relationship"
        Me.Column6.MinimumWidth = 6
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'Emergency_Contacts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ClientSize = New System.Drawing.Size(1464, 817)
        Me.Controls.Add(Me.lbl_StudentDetails)
        Me.Controls.Add(Me.lbl_Contacts)
        Me.Controls.Add(Me.lbl_Login)
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
        Me.Controls.Add(Me.lbl_EmergencyDetailsQuestion)
        Me.Controls.Add(Me.rad_NoEmergency)
        Me.Controls.Add(Me.rad_YesEmergency)
        Me.Controls.Add(Me.lbl_emergencyID)
        Me.Controls.Add(Me.txt_emergencyID)
        Me.Controls.Add(Me.lbl_access)
        Me.Controls.Add(Me.txt_accessLevel)
        Me.Controls.Add(Me.cbox_student)
        Me.Controls.Add(Me.lbl_postCode)
        Me.Controls.Add(Me.txt_postCode)
        Me.Controls.Add(Me.lbl_name)
        Me.Controls.Add(Me.txt_name)
        Me.Controls.Add(Me.lbl_relationship)
        Me.Controls.Add(Me.txt_relationship)
        Me.Controls.Add(Me.lbl_Student)
        Me.Controls.Add(Me.lbl_phoneNum)
        Me.Controls.Add(Me.lbl_surname)
        Me.Controls.Add(Me.txt_phoneNum)
        Me.Controls.Add(Me.txt_surname)
        Me.Controls.Add(Me.dgv_emergencyContacts)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Emergency_Contacts"
        Me.Text = "Emergency_Contacts"
        CType(Me.dgv_emergencyContacts, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbx_close, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbx_Delete, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbx_Save, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbx_New, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbx_LastRecord, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbx_NextRecord, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbx_PreviousRecord, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbx_first, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbx_MainMenu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pic_Help, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgv_emergencyContacts As DataGridView
    Friend WithEvents lbl_access As Label
    Friend WithEvents txt_accessLevel As TextBox
    Friend WithEvents cbox_student As ComboBox
    Friend WithEvents lbl_postCode As Label
    Friend WithEvents txt_postCode As TextBox
    Friend WithEvents lbl_name As Label
    Friend WithEvents txt_name As TextBox
    Friend WithEvents lbl_relationship As Label
    Friend WithEvents txt_relationship As TextBox
    Friend WithEvents lbl_Student As Label
    Friend WithEvents lbl_phoneNum As Label
    Friend WithEvents lbl_surname As Label
    Friend WithEvents txt_phoneNum As TextBox
    Friend WithEvents txt_surname As TextBox
    Friend WithEvents lbl_emergencyID As Label
    Friend WithEvents txt_emergencyID As TextBox
    Friend WithEvents lbl_EmergencyDetailsQuestion As Label
    Friend WithEvents rad_NoEmergency As RadioButton
    Friend WithEvents rad_YesEmergency As RadioButton
    Friend WithEvents pbx_close As PictureBox
    Friend WithEvents pbx_Delete As PictureBox
    Friend WithEvents pbx_Save As PictureBox
    Friend WithEvents pbx_New As PictureBox
    Friend WithEvents pbx_LastRecord As PictureBox
    Friend WithEvents pbx_NextRecord As PictureBox
    Friend WithEvents pbx_PreviousRecord As PictureBox
    Friend WithEvents pbx_first As PictureBox
    Friend WithEvents pbx_MainMenu As PictureBox
    Friend WithEvents pic_Help As PictureBox
    Friend WithEvents lbl_StudentDetails As Label
    Friend WithEvents lbl_Contacts As Label
    Friend WithEvents lbl_Login As Label
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
End Class
