<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TripSignup
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.dgv_TripDetails = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cbox_SortOptions = New System.Windows.Forms.ComboBox()
        Me.lbl_SortOptions = New System.Windows.Forms.Label()
        Me.pbx_LastRecord = New System.Windows.Forms.PictureBox()
        Me.pbx_NextRecord = New System.Windows.Forms.PictureBox()
        Me.pbx_PreviousRecord = New System.Windows.Forms.PictureBox()
        Me.pbx_first = New System.Windows.Forms.PictureBox()
        Me.pbx_SignUp = New System.Windows.Forms.PictureBox()
        Me.pbx_RemoveSignUp = New System.Windows.Forms.PictureBox()
        Me.pbx_back = New System.Windows.Forms.PictureBox()
        Me.pbx_close = New System.Windows.Forms.PictureBox()
        Me.pic_Help = New System.Windows.Forms.PictureBox()
        Me.rtxt_TripBulletin = New System.Windows.Forms.RichTextBox()
        Me.lbl_TripBulletinLabel = New System.Windows.Forms.Label()
        CType(Me.dgv_TripDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbx_LastRecord, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbx_NextRecord, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbx_PreviousRecord, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbx_first, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbx_SignUp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbx_RemoveSignUp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbx_back, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbx_close, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pic_Help, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgv_TripDetails
        '
        Me.dgv_TripDetails.AllowUserToAddRows = False
        Me.dgv_TripDetails.AllowUserToDeleteRows = False
        Me.dgv_TripDetails.BackgroundColor = System.Drawing.Color.LightSteelBlue
        Me.dgv_TripDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_TripDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7})
        Me.dgv_TripDetails.GridColor = System.Drawing.Color.LightGray
        Me.dgv_TripDetails.Location = New System.Drawing.Point(13, 86)
        Me.dgv_TripDetails.Margin = New System.Windows.Forms.Padding(4)
        Me.dgv_TripDetails.Name = "dgv_TripDetails"
        Me.dgv_TripDetails.ReadOnly = True
        Me.dgv_TripDetails.RowHeadersVisible = False
        Me.dgv_TripDetails.RowHeadersWidth = 51
        Me.dgv_TripDetails.Size = New System.Drawing.Size(941, 386)
        Me.dgv_TripDetails.TabIndex = 22
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column1.HeaderText = "Trip ID"
        Me.Column1.MinimumWidth = 6
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Visible = False
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column2.HeaderText = "Name"
        Me.Column2.MinimumWidth = 6
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column3.HeaderText = "Location"
        Me.Column3.MinimumWidth = 6
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column4.HeaderText = "Date"
        Me.Column4.MinimumWidth = 6
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Column5
        '
        Me.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column5.HeaderText = "Departure Time"
        Me.Column5.MinimumWidth = 6
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'Column6
        '
        Me.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column6.HeaderText = "Arrival Time"
        Me.Column6.MinimumWidth = 6
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'Column7
        '
        Me.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column7.HeaderText = "Cost / Pupil (£)"
        Me.Column7.MinimumWidth = 6
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        '
        'cbox_SortOptions
        '
        Me.cbox_SortOptions.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbox_SortOptions.FormattingEnabled = True
        Me.cbox_SortOptions.Location = New System.Drawing.Point(33, 617)
        Me.cbox_SortOptions.Name = "cbox_SortOptions"
        Me.cbox_SortOptions.Size = New System.Drawing.Size(219, 28)
        Me.cbox_SortOptions.TabIndex = 130
        '
        'lbl_SortOptions
        '
        Me.lbl_SortOptions.AutoSize = True
        Me.lbl_SortOptions.Location = New System.Drawing.Point(30, 598)
        Me.lbl_SortOptions.Name = "lbl_SortOptions"
        Me.lbl_SortOptions.Size = New System.Drawing.Size(139, 16)
        Me.lbl_SortOptions.TabIndex = 131
        Me.lbl_SortOptions.Text = "Select a sort by option"
        '
        'pbx_LastRecord
        '
        Me.pbx_LastRecord.Location = New System.Drawing.Point(813, 503)
        Me.pbx_LastRecord.Name = "pbx_LastRecord"
        Me.pbx_LastRecord.Size = New System.Drawing.Size(127, 57)
        Me.pbx_LastRecord.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbx_LastRecord.TabIndex = 135
        Me.pbx_LastRecord.TabStop = False
        '
        'pbx_NextRecord
        '
        Me.pbx_NextRecord.Location = New System.Drawing.Point(813, 584)
        Me.pbx_NextRecord.Name = "pbx_NextRecord"
        Me.pbx_NextRecord.Size = New System.Drawing.Size(127, 57)
        Me.pbx_NextRecord.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbx_NextRecord.TabIndex = 134
        Me.pbx_NextRecord.TabStop = False
        '
        'pbx_PreviousRecord
        '
        Me.pbx_PreviousRecord.Location = New System.Drawing.Point(602, 584)
        Me.pbx_PreviousRecord.Name = "pbx_PreviousRecord"
        Me.pbx_PreviousRecord.Size = New System.Drawing.Size(127, 57)
        Me.pbx_PreviousRecord.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbx_PreviousRecord.TabIndex = 133
        Me.pbx_PreviousRecord.TabStop = False
        '
        'pbx_first
        '
        Me.pbx_first.Location = New System.Drawing.Point(602, 503)
        Me.pbx_first.Name = "pbx_first"
        Me.pbx_first.Size = New System.Drawing.Size(127, 57)
        Me.pbx_first.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbx_first.TabIndex = 132
        Me.pbx_first.TabStop = False
        '
        'pbx_SignUp
        '
        Me.pbx_SignUp.Location = New System.Drawing.Point(33, 503)
        Me.pbx_SignUp.Name = "pbx_SignUp"
        Me.pbx_SignUp.Size = New System.Drawing.Size(127, 57)
        Me.pbx_SignUp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbx_SignUp.TabIndex = 136
        Me.pbx_SignUp.TabStop = False
        '
        'pbx_RemoveSignUp
        '
        Me.pbx_RemoveSignUp.Location = New System.Drawing.Point(187, 503)
        Me.pbx_RemoveSignUp.Name = "pbx_RemoveSignUp"
        Me.pbx_RemoveSignUp.Size = New System.Drawing.Size(127, 57)
        Me.pbx_RemoveSignUp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbx_RemoveSignUp.TabIndex = 137
        Me.pbx_RemoveSignUp.TabStop = False
        '
        'pbx_back
        '
        Me.pbx_back.Location = New System.Drawing.Point(1250, 12)
        Me.pbx_back.Name = "pbx_back"
        Me.pbx_back.Size = New System.Drawing.Size(98, 44)
        Me.pbx_back.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbx_back.TabIndex = 139
        Me.pbx_back.TabStop = False
        '
        'pbx_close
        '
        Me.pbx_close.Location = New System.Drawing.Point(1354, 12)
        Me.pbx_close.Name = "pbx_close"
        Me.pbx_close.Size = New System.Drawing.Size(98, 44)
        Me.pbx_close.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbx_close.TabIndex = 138
        Me.pbx_close.TabStop = False
        '
        'pic_Help
        '
        Me.pic_Help.Location = New System.Drawing.Point(13, 11)
        Me.pic_Help.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pic_Help.Name = "pic_Help"
        Me.pic_Help.Size = New System.Drawing.Size(43, 36)
        Me.pic_Help.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pic_Help.TabIndex = 159
        Me.pic_Help.TabStop = False
        '
        'rtxt_TripBulletin
        '
        Me.rtxt_TripBulletin.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.rtxt_TripBulletin.Location = New System.Drawing.Point(985, 130)
        Me.rtxt_TripBulletin.Margin = New System.Windows.Forms.Padding(4)
        Me.rtxt_TripBulletin.Name = "rtxt_TripBulletin"
        Me.rtxt_TripBulletin.Size = New System.Drawing.Size(455, 342)
        Me.rtxt_TripBulletin.TabIndex = 160
        Me.rtxt_TripBulletin.Text = "No new information."
        '
        'lbl_TripBulletinLabel
        '
        Me.lbl_TripBulletinLabel.AutoSize = True
        Me.lbl_TripBulletinLabel.BackColor = System.Drawing.Color.Transparent
        Me.lbl_TripBulletinLabel.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_TripBulletinLabel.ForeColor = System.Drawing.Color.RoyalBlue
        Me.lbl_TripBulletinLabel.Location = New System.Drawing.Point(1128, 86)
        Me.lbl_TripBulletinLabel.Name = "lbl_TripBulletinLabel"
        Me.lbl_TripBulletinLabel.Size = New System.Drawing.Size(197, 28)
        Me.lbl_TripBulletinLabel.TabIndex = 161
        Me.lbl_TripBulletinLabel.Text = "School Trip Bulletin"
        '
        'TripSignup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ClientSize = New System.Drawing.Size(1464, 817)
        Me.Controls.Add(Me.lbl_TripBulletinLabel)
        Me.Controls.Add(Me.rtxt_TripBulletin)
        Me.Controls.Add(Me.pic_Help)
        Me.Controls.Add(Me.pbx_back)
        Me.Controls.Add(Me.pbx_close)
        Me.Controls.Add(Me.pbx_RemoveSignUp)
        Me.Controls.Add(Me.pbx_SignUp)
        Me.Controls.Add(Me.pbx_LastRecord)
        Me.Controls.Add(Me.pbx_NextRecord)
        Me.Controls.Add(Me.pbx_PreviousRecord)
        Me.Controls.Add(Me.pbx_first)
        Me.Controls.Add(Me.lbl_SortOptions)
        Me.Controls.Add(Me.cbox_SortOptions)
        Me.Controls.Add(Me.dgv_TripDetails)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "TripSignup"
        Me.Text = "TripSignup"
        CType(Me.dgv_TripDetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbx_LastRecord, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbx_NextRecord, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbx_PreviousRecord, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbx_first, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbx_SignUp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbx_RemoveSignUp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbx_back, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbx_close, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pic_Help, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgv_TripDetails As DataGridView
    Friend WithEvents cbox_SortOptions As ComboBox
    Private WithEvents lbl_SortOptions As Label
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents pbx_LastRecord As PictureBox
    Friend WithEvents pbx_NextRecord As PictureBox
    Friend WithEvents pbx_PreviousRecord As PictureBox
    Friend WithEvents pbx_first As PictureBox
    Friend WithEvents pbx_SignUp As PictureBox
    Friend WithEvents pbx_RemoveSignUp As PictureBox
    Friend WithEvents pbx_back As PictureBox
    Friend WithEvents pbx_close As PictureBox
    Friend WithEvents pic_Help As PictureBox
    Friend WithEvents rtxt_TripBulletin As RichTextBox
    Friend WithEvents lbl_TripBulletinLabel As Label
End Class
