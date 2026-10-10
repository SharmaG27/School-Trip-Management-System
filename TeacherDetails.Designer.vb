<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TeacherDetails
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
        Me.dgv_TeacherDetails = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lbl_access = New System.Windows.Forms.Label()
        Me.txt_accessLevel = New System.Windows.Forms.TextBox()
        Me.lbl_password = New System.Windows.Forms.Label()
        Me.lbl_username = New System.Windows.Forms.Label()
        Me.txt_password = New System.Windows.Forms.TextBox()
        Me.txt_usernmae = New System.Windows.Forms.TextBox()
        Me.txt_TeacherID = New System.Windows.Forms.TextBox()
        Me.lbl_TeacherID = New System.Windows.Forms.Label()
        Me.lbl_contactNumber = New System.Windows.Forms.Label()
        Me.lbl_email = New System.Windows.Forms.Label()
        Me.lbl_postCode = New System.Windows.Forms.Label()
        Me.lbl_houseNum = New System.Windows.Forms.Label()
        Me.lbl_surname = New System.Windows.Forms.Label()
        Me.lbl_name = New System.Windows.Forms.Label()
        Me.lbl_title = New System.Windows.Forms.Label()
        Me.txt_contactNum = New System.Windows.Forms.TextBox()
        Me.txt_email = New System.Windows.Forms.TextBox()
        Me.txt_postCode = New System.Windows.Forms.TextBox()
        Me.txt_houseNum = New System.Windows.Forms.TextBox()
        Me.txt_surname = New System.Windows.Forms.TextBox()
        Me.txt_name = New System.Windows.Forms.TextBox()
        Me.txt_title = New System.Windows.Forms.TextBox()
        Me.lbl_DOB = New System.Windows.Forms.Label()
        Me.dtp_dob = New System.Windows.Forms.DateTimePicker()
        Me.pbx_Back = New System.Windows.Forms.PictureBox()
        Me.pbx_Delete = New System.Windows.Forms.PictureBox()
        Me.pbx_SaveRecord = New System.Windows.Forms.PictureBox()
        Me.pbx_NewRecord = New System.Windows.Forms.PictureBox()
        Me.pbx_Close = New System.Windows.Forms.PictureBox()
        Me.pbx_LastRecord = New System.Windows.Forms.PictureBox()
        Me.pbx_NextRecord = New System.Windows.Forms.PictureBox()
        Me.pbx_PreviousRecord = New System.Windows.Forms.PictureBox()
        Me.pbx_first = New System.Windows.Forms.PictureBox()
        Me.pbx_Supervise = New System.Windows.Forms.PictureBox()
        Me.pic_Help = New System.Windows.Forms.PictureBox()
        Me.lbl_Personal = New System.Windows.Forms.Label()
        Me.lbl_Contacts = New System.Windows.Forms.Label()
        Me.lbl_Login = New System.Windows.Forms.Label()
        CType(Me.dgv_TeacherDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbx_Back, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbx_Delete, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbx_SaveRecord, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbx_NewRecord, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbx_Close, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbx_LastRecord, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbx_NextRecord, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbx_PreviousRecord, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbx_first, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbx_Supervise, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pic_Help, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgv_TeacherDetails
        '
        Me.dgv_TeacherDetails.AllowUserToAddRows = False
        Me.dgv_TeacherDetails.AllowUserToDeleteRows = False
        Me.dgv_TeacherDetails.BackgroundColor = System.Drawing.Color.LightSteelBlue
        Me.dgv_TeacherDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_TeacherDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7, Me.Column8, Me.Column9, Me.Column10, Me.Column12, Me.Column13})
        Me.dgv_TeacherDetails.GridColor = System.Drawing.Color.LightGray
        Me.dgv_TeacherDetails.Location = New System.Drawing.Point(13, 77)
        Me.dgv_TeacherDetails.Margin = New System.Windows.Forms.Padding(4)
        Me.dgv_TeacherDetails.Name = "dgv_TeacherDetails"
        Me.dgv_TeacherDetails.ReadOnly = True
        Me.dgv_TeacherDetails.RowHeadersWidth = 51
        Me.dgv_TeacherDetails.Size = New System.Drawing.Size(1432, 349)
        Me.dgv_TeacherDetails.TabIndex = 19
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column1.HeaderText = "Teacher ID"
        Me.Column1.MinimumWidth = 20
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column2.HeaderText = "Surname"
        Me.Column2.MinimumWidth = 6
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column3.HeaderText = "Name"
        Me.Column3.MinimumWidth = 6
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column4.HeaderText = "Title"
        Me.Column4.MinimumWidth = 6
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Column5
        '
        Me.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column5.HeaderText = "House Number"
        Me.Column5.MinimumWidth = 6
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'Column6
        '
        Me.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column6.HeaderText = "Postcode"
        Me.Column6.MinimumWidth = 6
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'Column7
        '
        Me.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column7.HeaderText = "Email"
        Me.Column7.MinimumWidth = 6
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        '
        'Column8
        '
        Me.Column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column8.HeaderText = "Contact Number"
        Me.Column8.MinimumWidth = 6
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        '
        'Column9
        '
        Me.Column9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column9.HeaderText = "DOB"
        Me.Column9.MinimumWidth = 6
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        '
        'Column10
        '
        Me.Column10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column10.HeaderText = "Access"
        Me.Column10.MinimumWidth = 6
        Me.Column10.Name = "Column10"
        Me.Column10.ReadOnly = True
        '
        'Column12
        '
        Me.Column12.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column12.HeaderText = "Username"
        Me.Column12.MinimumWidth = 6
        Me.Column12.Name = "Column12"
        Me.Column12.ReadOnly = True
        Me.Column12.Visible = False
        '
        'Column13
        '
        Me.Column13.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column13.HeaderText = "Password"
        Me.Column13.MinimumWidth = 6
        Me.Column13.Name = "Column13"
        Me.Column13.ReadOnly = True
        Me.Column13.Visible = False
        '
        'lbl_access
        '
        Me.lbl_access.AutoSize = True
        Me.lbl_access.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lbl_access.Location = New System.Drawing.Point(618, 506)
        Me.lbl_access.Name = "lbl_access"
        Me.lbl_access.Size = New System.Drawing.Size(91, 20)
        Me.lbl_access.TabIndex = 75
        Me.lbl_access.Text = "Access Level"
        '
        'txt_accessLevel
        '
        Me.txt_accessLevel.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txt_accessLevel.Location = New System.Drawing.Point(621, 525)
        Me.txt_accessLevel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txt_accessLevel.Name = "txt_accessLevel"
        Me.txt_accessLevel.ReadOnly = True
        Me.txt_accessLevel.Size = New System.Drawing.Size(217, 27)
        Me.txt_accessLevel.TabIndex = 74
        '
        'lbl_password
        '
        Me.lbl_password.AutoSize = True
        Me.lbl_password.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lbl_password.Location = New System.Drawing.Point(618, 621)
        Me.lbl_password.Name = "lbl_password"
        Me.lbl_password.Size = New System.Drawing.Size(70, 20)
        Me.lbl_password.TabIndex = 73
        Me.lbl_password.Text = "Password"
        '
        'lbl_username
        '
        Me.lbl_username.AutoSize = True
        Me.lbl_username.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lbl_username.Location = New System.Drawing.Point(618, 560)
        Me.lbl_username.Name = "lbl_username"
        Me.lbl_username.Size = New System.Drawing.Size(75, 20)
        Me.lbl_username.TabIndex = 72
        Me.lbl_username.Text = "Username"
        '
        'txt_password
        '
        Me.txt_password.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txt_password.Location = New System.Drawing.Point(621, 640)
        Me.txt_password.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txt_password.Name = "txt_password"
        Me.txt_password.Size = New System.Drawing.Size(217, 27)
        Me.txt_password.TabIndex = 71
        '
        'txt_usernmae
        '
        Me.txt_usernmae.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txt_usernmae.Location = New System.Drawing.Point(621, 580)
        Me.txt_usernmae.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txt_usernmae.Name = "txt_usernmae"
        Me.txt_usernmae.Size = New System.Drawing.Size(217, 27)
        Me.txt_usernmae.TabIndex = 70
        '
        'txt_TeacherID
        '
        Me.txt_TeacherID.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txt_TeacherID.Location = New System.Drawing.Point(30, 525)
        Me.txt_TeacherID.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txt_TeacherID.Name = "txt_TeacherID"
        Me.txt_TeacherID.ReadOnly = True
        Me.txt_TeacherID.Size = New System.Drawing.Size(217, 27)
        Me.txt_TeacherID.TabIndex = 69
        '
        'lbl_TeacherID
        '
        Me.lbl_TeacherID.AutoSize = True
        Me.lbl_TeacherID.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lbl_TeacherID.Location = New System.Drawing.Point(26, 506)
        Me.lbl_TeacherID.Name = "lbl_TeacherID"
        Me.lbl_TeacherID.Size = New System.Drawing.Size(79, 20)
        Me.lbl_TeacherID.TabIndex = 68
        Me.lbl_TeacherID.Text = "Teacher ID"
        '
        'lbl_contactNumber
        '
        Me.lbl_contactNumber.AutoSize = True
        Me.lbl_contactNumber.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lbl_contactNumber.Location = New System.Drawing.Point(328, 683)
        Me.lbl_contactNumber.Name = "lbl_contactNumber"
        Me.lbl_contactNumber.Size = New System.Drawing.Size(118, 20)
        Me.lbl_contactNumber.TabIndex = 64
        Me.lbl_contactNumber.Text = "Contact Number"
        '
        'lbl_email
        '
        Me.lbl_email.AutoSize = True
        Me.lbl_email.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lbl_email.Location = New System.Drawing.Point(328, 620)
        Me.lbl_email.Name = "lbl_email"
        Me.lbl_email.Size = New System.Drawing.Size(162, 20)
        Me.lbl_email.TabIndex = 63
        Me.lbl_email.Text = "Personal email Address"
        '
        'lbl_postCode
        '
        Me.lbl_postCode.AutoSize = True
        Me.lbl_postCode.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lbl_postCode.Location = New System.Drawing.Point(328, 560)
        Me.lbl_postCode.Name = "lbl_postCode"
        Me.lbl_postCode.Size = New System.Drawing.Size(149, 20)
        Me.lbl_postCode.TabIndex = 62
        Me.lbl_postCode.Text = "Post Code (LL00 8BB)"
        '
        'lbl_houseNum
        '
        Me.lbl_houseNum.AutoSize = True
        Me.lbl_houseNum.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lbl_houseNum.Location = New System.Drawing.Point(328, 506)
        Me.lbl_houseNum.Name = "lbl_houseNum"
        Me.lbl_houseNum.Size = New System.Drawing.Size(109, 20)
        Me.lbl_houseNum.TabIndex = 61
        Me.lbl_houseNum.Text = "House Number"
        '
        'lbl_surname
        '
        Me.lbl_surname.AutoSize = True
        Me.lbl_surname.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lbl_surname.Location = New System.Drawing.Point(29, 678)
        Me.lbl_surname.Name = "lbl_surname"
        Me.lbl_surname.Size = New System.Drawing.Size(67, 20)
        Me.lbl_surname.TabIndex = 60
        Me.lbl_surname.Text = "Surname"
        '
        'lbl_name
        '
        Me.lbl_name.AutoSize = True
        Me.lbl_name.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lbl_name.Location = New System.Drawing.Point(29, 620)
        Me.lbl_name.Name = "lbl_name"
        Me.lbl_name.Size = New System.Drawing.Size(75, 20)
        Me.lbl_name.TabIndex = 59
        Me.lbl_name.Text = "Forename"
        '
        'lbl_title
        '
        Me.lbl_title.AutoSize = True
        Me.lbl_title.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lbl_title.Location = New System.Drawing.Point(27, 560)
        Me.lbl_title.Name = "lbl_title"
        Me.lbl_title.Size = New System.Drawing.Size(38, 20)
        Me.lbl_title.TabIndex = 58
        Me.lbl_title.Text = "Title"
        '
        'txt_contactNum
        '
        Me.txt_contactNum.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txt_contactNum.Location = New System.Drawing.Point(330, 701)
        Me.txt_contactNum.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txt_contactNum.Name = "txt_contactNum"
        Me.txt_contactNum.Size = New System.Drawing.Size(217, 27)
        Me.txt_contactNum.TabIndex = 57
        '
        'txt_email
        '
        Me.txt_email.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txt_email.Location = New System.Drawing.Point(330, 640)
        Me.txt_email.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txt_email.Name = "txt_email"
        Me.txt_email.Size = New System.Drawing.Size(217, 27)
        Me.txt_email.TabIndex = 56
        '
        'txt_postCode
        '
        Me.txt_postCode.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txt_postCode.Location = New System.Drawing.Point(330, 580)
        Me.txt_postCode.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txt_postCode.Name = "txt_postCode"
        Me.txt_postCode.Size = New System.Drawing.Size(217, 27)
        Me.txt_postCode.TabIndex = 55
        '
        'txt_houseNum
        '
        Me.txt_houseNum.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txt_houseNum.Location = New System.Drawing.Point(330, 525)
        Me.txt_houseNum.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txt_houseNum.Name = "txt_houseNum"
        Me.txt_houseNum.Size = New System.Drawing.Size(217, 27)
        Me.txt_houseNum.TabIndex = 54
        '
        'txt_surname
        '
        Me.txt_surname.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txt_surname.Location = New System.Drawing.Point(32, 701)
        Me.txt_surname.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txt_surname.Name = "txt_surname"
        Me.txt_surname.Size = New System.Drawing.Size(217, 27)
        Me.txt_surname.TabIndex = 53
        '
        'txt_name
        '
        Me.txt_name.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txt_name.Location = New System.Drawing.Point(31, 640)
        Me.txt_name.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txt_name.Name = "txt_name"
        Me.txt_name.Size = New System.Drawing.Size(217, 27)
        Me.txt_name.TabIndex = 52
        '
        'txt_title
        '
        Me.txt_title.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txt_title.Location = New System.Drawing.Point(31, 580)
        Me.txt_title.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txt_title.Name = "txt_title"
        Me.txt_title.Size = New System.Drawing.Size(217, 27)
        Me.txt_title.TabIndex = 51
        '
        'lbl_DOB
        '
        Me.lbl_DOB.AutoSize = True
        Me.lbl_DOB.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lbl_DOB.Location = New System.Drawing.Point(32, 739)
        Me.lbl_DOB.Name = "lbl_DOB"
        Me.lbl_DOB.Size = New System.Drawing.Size(94, 20)
        Me.lbl_DOB.TabIndex = 79
        Me.lbl_DOB.Text = "Date of Birth"
        '
        'dtp_dob
        '
        Me.dtp_dob.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.dtp_dob.Location = New System.Drawing.Point(32, 761)
        Me.dtp_dob.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dtp_dob.Name = "dtp_dob"
        Me.dtp_dob.Size = New System.Drawing.Size(217, 27)
        Me.dtp_dob.TabIndex = 78
        '
        'pbx_Back
        '
        Me.pbx_Back.Location = New System.Drawing.Point(1234, 12)
        Me.pbx_Back.Name = "pbx_Back"
        Me.pbx_Back.Size = New System.Drawing.Size(98, 44)
        Me.pbx_Back.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbx_Back.TabIndex = 88
        Me.pbx_Back.TabStop = False
        '
        'pbx_Delete
        '
        Me.pbx_Delete.Location = New System.Drawing.Point(1306, 605)
        Me.pbx_Delete.Name = "pbx_Delete"
        Me.pbx_Delete.Size = New System.Drawing.Size(127, 57)
        Me.pbx_Delete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbx_Delete.TabIndex = 87
        Me.pbx_Delete.TabStop = False
        '
        'pbx_SaveRecord
        '
        Me.pbx_SaveRecord.Location = New System.Drawing.Point(1143, 605)
        Me.pbx_SaveRecord.Name = "pbx_SaveRecord"
        Me.pbx_SaveRecord.Size = New System.Drawing.Size(127, 57)
        Me.pbx_SaveRecord.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbx_SaveRecord.TabIndex = 86
        Me.pbx_SaveRecord.TabStop = False
        '
        'pbx_NewRecord
        '
        Me.pbx_NewRecord.Location = New System.Drawing.Point(984, 605)
        Me.pbx_NewRecord.Name = "pbx_NewRecord"
        Me.pbx_NewRecord.Size = New System.Drawing.Size(127, 57)
        Me.pbx_NewRecord.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbx_NewRecord.TabIndex = 85
        Me.pbx_NewRecord.TabStop = False
        '
        'pbx_Close
        '
        Me.pbx_Close.Location = New System.Drawing.Point(1347, 12)
        Me.pbx_Close.Name = "pbx_Close"
        Me.pbx_Close.Size = New System.Drawing.Size(98, 44)
        Me.pbx_Close.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbx_Close.TabIndex = 84
        Me.pbx_Close.TabStop = False
        '
        'pbx_LastRecord
        '
        Me.pbx_LastRecord.Location = New System.Drawing.Point(1306, 451)
        Me.pbx_LastRecord.Name = "pbx_LastRecord"
        Me.pbx_LastRecord.Size = New System.Drawing.Size(127, 57)
        Me.pbx_LastRecord.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbx_LastRecord.TabIndex = 83
        Me.pbx_LastRecord.TabStop = False
        '
        'pbx_NextRecord
        '
        Me.pbx_NextRecord.Location = New System.Drawing.Point(1306, 514)
        Me.pbx_NextRecord.Name = "pbx_NextRecord"
        Me.pbx_NextRecord.Size = New System.Drawing.Size(127, 57)
        Me.pbx_NextRecord.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbx_NextRecord.TabIndex = 82
        Me.pbx_NextRecord.TabStop = False
        '
        'pbx_PreviousRecord
        '
        Me.pbx_PreviousRecord.Location = New System.Drawing.Point(984, 514)
        Me.pbx_PreviousRecord.Name = "pbx_PreviousRecord"
        Me.pbx_PreviousRecord.Size = New System.Drawing.Size(127, 57)
        Me.pbx_PreviousRecord.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbx_PreviousRecord.TabIndex = 81
        Me.pbx_PreviousRecord.TabStop = False
        '
        'pbx_first
        '
        Me.pbx_first.Location = New System.Drawing.Point(984, 451)
        Me.pbx_first.Name = "pbx_first"
        Me.pbx_first.Size = New System.Drawing.Size(127, 57)
        Me.pbx_first.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbx_first.TabIndex = 80
        Me.pbx_first.TabStop = False
        '
        'pbx_Supervise
        '
        Me.pbx_Supervise.Location = New System.Drawing.Point(1118, 12)
        Me.pbx_Supervise.Name = "pbx_Supervise"
        Me.pbx_Supervise.Size = New System.Drawing.Size(98, 44)
        Me.pbx_Supervise.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbx_Supervise.TabIndex = 89
        Me.pbx_Supervise.TabStop = False
        '
        'pic_Help
        '
        Me.pic_Help.Location = New System.Drawing.Point(12, 11)
        Me.pic_Help.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pic_Help.Name = "pic_Help"
        Me.pic_Help.Size = New System.Drawing.Size(43, 36)
        Me.pic_Help.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pic_Help.TabIndex = 136
        Me.pic_Help.TabStop = False
        '
        'lbl_Personal
        '
        Me.lbl_Personal.AutoSize = True
        Me.lbl_Personal.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Personal.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Personal.ForeColor = System.Drawing.Color.RoyalBlue
        Me.lbl_Personal.Location = New System.Drawing.Point(47, 451)
        Me.lbl_Personal.Name = "lbl_Personal"
        Me.lbl_Personal.Size = New System.Drawing.Size(164, 28)
        Me.lbl_Personal.TabIndex = 139
        Me.lbl_Personal.Text = "Personal Details"
        '
        'lbl_Contacts
        '
        Me.lbl_Contacts.AutoSize = True
        Me.lbl_Contacts.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Contacts.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Contacts.ForeColor = System.Drawing.Color.RoyalBlue
        Me.lbl_Contacts.Location = New System.Drawing.Point(352, 451)
        Me.lbl_Contacts.Name = "lbl_Contacts"
        Me.lbl_Contacts.Size = New System.Drawing.Size(157, 28)
        Me.lbl_Contacts.TabIndex = 138
        Me.lbl_Contacts.Text = "Contact Details"
        '
        'lbl_Login
        '
        Me.lbl_Login.AutoSize = True
        Me.lbl_Login.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Login.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Login.ForeColor = System.Drawing.Color.RoyalBlue
        Me.lbl_Login.Location = New System.Drawing.Point(649, 451)
        Me.lbl_Login.Name = "lbl_Login"
        Me.lbl_Login.Size = New System.Drawing.Size(136, 28)
        Me.lbl_Login.TabIndex = 137
        Me.lbl_Login.Text = "Login Details"
        '
        'TeacherDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ClientSize = New System.Drawing.Size(1464, 817)
        Me.Controls.Add(Me.lbl_Personal)
        Me.Controls.Add(Me.lbl_Contacts)
        Me.Controls.Add(Me.lbl_Login)
        Me.Controls.Add(Me.pic_Help)
        Me.Controls.Add(Me.pbx_Supervise)
        Me.Controls.Add(Me.pbx_Back)
        Me.Controls.Add(Me.pbx_Delete)
        Me.Controls.Add(Me.pbx_SaveRecord)
        Me.Controls.Add(Me.pbx_NewRecord)
        Me.Controls.Add(Me.pbx_Close)
        Me.Controls.Add(Me.pbx_LastRecord)
        Me.Controls.Add(Me.pbx_NextRecord)
        Me.Controls.Add(Me.pbx_PreviousRecord)
        Me.Controls.Add(Me.pbx_first)
        Me.Controls.Add(Me.lbl_DOB)
        Me.Controls.Add(Me.dtp_dob)
        Me.Controls.Add(Me.lbl_access)
        Me.Controls.Add(Me.txt_accessLevel)
        Me.Controls.Add(Me.lbl_password)
        Me.Controls.Add(Me.lbl_username)
        Me.Controls.Add(Me.txt_password)
        Me.Controls.Add(Me.txt_usernmae)
        Me.Controls.Add(Me.txt_TeacherID)
        Me.Controls.Add(Me.lbl_TeacherID)
        Me.Controls.Add(Me.lbl_contactNumber)
        Me.Controls.Add(Me.lbl_email)
        Me.Controls.Add(Me.lbl_postCode)
        Me.Controls.Add(Me.lbl_houseNum)
        Me.Controls.Add(Me.lbl_surname)
        Me.Controls.Add(Me.lbl_name)
        Me.Controls.Add(Me.lbl_title)
        Me.Controls.Add(Me.txt_contactNum)
        Me.Controls.Add(Me.txt_email)
        Me.Controls.Add(Me.txt_postCode)
        Me.Controls.Add(Me.txt_houseNum)
        Me.Controls.Add(Me.txt_surname)
        Me.Controls.Add(Me.txt_name)
        Me.Controls.Add(Me.txt_title)
        Me.Controls.Add(Me.dgv_TeacherDetails)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "TeacherDetails"
        Me.Text = "TeacherDetails"
        CType(Me.dgv_TeacherDetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbx_Back, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbx_Delete, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbx_SaveRecord, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbx_NewRecord, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbx_Close, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbx_LastRecord, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbx_NextRecord, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbx_PreviousRecord, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbx_first, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbx_Supervise, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pic_Help, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgv_TeacherDetails As DataGridView
    Friend WithEvents lbl_access As Label
    Friend WithEvents txt_accessLevel As TextBox
    Friend WithEvents lbl_password As Label
    Friend WithEvents lbl_username As Label
    Friend WithEvents txt_password As TextBox
    Friend WithEvents txt_usernmae As TextBox
    Friend WithEvents txt_TeacherID As TextBox
    Friend WithEvents lbl_TeacherID As Label
    Friend WithEvents lbl_contactNumber As Label
    Friend WithEvents lbl_email As Label
    Friend WithEvents lbl_postCode As Label
    Friend WithEvents lbl_houseNum As Label
    Friend WithEvents lbl_surname As Label
    Friend WithEvents lbl_name As Label
    Friend WithEvents lbl_title As Label
    Friend WithEvents txt_contactNum As TextBox
    Friend WithEvents txt_email As TextBox
    Friend WithEvents txt_postCode As TextBox
    Friend WithEvents txt_houseNum As TextBox
    Friend WithEvents txt_surname As TextBox
    Friend WithEvents txt_name As TextBox
    Friend WithEvents txt_title As TextBox
    Friend WithEvents lbl_DOB As Label
    Friend WithEvents dtp_dob As DateTimePicker
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents Column8 As DataGridViewTextBoxColumn
    Friend WithEvents Column9 As DataGridViewTextBoxColumn
    Friend WithEvents Column10 As DataGridViewTextBoxColumn
    Friend WithEvents Column12 As DataGridViewTextBoxColumn
    Friend WithEvents Column13 As DataGridViewTextBoxColumn
    Friend WithEvents pbx_Back As PictureBox
    Friend WithEvents pbx_Delete As PictureBox
    Friend WithEvents pbx_SaveRecord As PictureBox
    Friend WithEvents pbx_NewRecord As PictureBox
    Friend WithEvents pbx_Close As PictureBox
    Friend WithEvents pbx_LastRecord As PictureBox
    Friend WithEvents pbx_NextRecord As PictureBox
    Friend WithEvents pbx_PreviousRecord As PictureBox
    Friend WithEvents pbx_first As PictureBox
    Friend WithEvents pbx_Supervise As PictureBox
    Friend WithEvents pic_Help As PictureBox
    Friend WithEvents lbl_Personal As Label
    Friend WithEvents lbl_Contacts As Label
    Friend WithEvents lbl_Login As Label
End Class
