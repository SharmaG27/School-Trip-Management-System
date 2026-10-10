<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Manage_Trips
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
        Me.dgv_TripDetails = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txt_TripID = New System.Windows.Forms.TextBox()
        Me.lbl_TripID = New System.Windows.Forms.Label()
        Me.lbl_TripDate = New System.Windows.Forms.Label()
        Me.lbl_CostperPupil = New System.Windows.Forms.Label()
        Me.lbl_ArrivalTime = New System.Windows.Forms.Label()
        Me.lbl_DepartureTime = New System.Windows.Forms.Label()
        Me.lbl_TripLocation = New System.Windows.Forms.Label()
        Me.lbl_TripName = New System.Windows.Forms.Label()
        Me.dtp_TripDate = New System.Windows.Forms.DateTimePicker()
        Me.txt_CostperPupil = New System.Windows.Forms.TextBox()
        Me.txt_TripLocation = New System.Windows.Forms.TextBox()
        Me.txt_TripName = New System.Windows.Forms.TextBox()
        Me.cmd_deleteRecord = New System.Windows.Forms.Button()
        Me.dtp_ArrivalTime = New System.Windows.Forms.DateTimePicker()
        Me.dtp_DepartureTime = New System.Windows.Forms.DateTimePicker()
        Me.pbx_First = New System.Windows.Forms.PictureBox()
        Me.pbx_Previous = New System.Windows.Forms.PictureBox()
        Me.pbx_Next = New System.Windows.Forms.PictureBox()
        Me.pbx_Last = New System.Windows.Forms.PictureBox()
        Me.pbx_NewTrip = New System.Windows.Forms.PictureBox()
        Me.pbx_SaveTrip = New System.Windows.Forms.PictureBox()
        Me.pbx_DeleteTrip = New System.Windows.Forms.PictureBox()
        Me.pbx_Close = New System.Windows.Forms.PictureBox()
        Me.pic_Help = New System.Windows.Forms.PictureBox()
        Me.lbl_TripDetails = New System.Windows.Forms.Label()
        Me.lbl_TripLogistics = New System.Windows.Forms.Label()
        Me.pbx_SearchTrip = New System.Windows.Forms.PictureBox()
        Me.pbx_BackToAdmin = New System.Windows.Forms.PictureBox()
        CType(Me.dgv_TripDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbx_First, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbx_Previous, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbx_Next, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbx_Last, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbx_NewTrip, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbx_SaveTrip, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbx_DeleteTrip, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbx_Close, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pic_Help, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbx_SearchTrip, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbx_BackToAdmin, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.dgv_TripDetails.Location = New System.Drawing.Point(13, 71)
        Me.dgv_TripDetails.Margin = New System.Windows.Forms.Padding(4)
        Me.dgv_TripDetails.Name = "dgv_TripDetails"
        Me.dgv_TripDetails.ReadOnly = True
        Me.dgv_TripDetails.RowHeadersVisible = False
        Me.dgv_TripDetails.RowHeadersWidth = 51
        Me.dgv_TripDetails.Size = New System.Drawing.Size(1432, 350)
        Me.dgv_TripDetails.TabIndex = 20
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column1.HeaderText = "Trip ID"
        Me.Column1.MinimumWidth = 6
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.HeaderText = "Name"
        Me.Column2.MinimumWidth = 6
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 125
        '
        'Column3
        '
        Me.Column3.HeaderText = "Location"
        Me.Column3.MinimumWidth = 6
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 125
        '
        'Column4
        '
        Me.Column4.HeaderText = "Date"
        Me.Column4.MinimumWidth = 6
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 125
        '
        'Column5
        '
        Me.Column5.HeaderText = "Departure Time"
        Me.Column5.MinimumWidth = 6
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 125
        '
        'Column6
        '
        Me.Column6.HeaderText = "Arrival Time"
        Me.Column6.MinimumWidth = 6
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Width = 125
        '
        'Column7
        '
        Me.Column7.HeaderText = "Cost / Pupil (£)"
        Me.Column7.MinimumWidth = 6
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.Width = 125
        '
        'txt_TripID
        '
        Me.txt_TripID.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txt_TripID.Location = New System.Drawing.Point(32, 546)
        Me.txt_TripID.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txt_TripID.Name = "txt_TripID"
        Me.txt_TripID.ReadOnly = True
        Me.txt_TripID.Size = New System.Drawing.Size(217, 27)
        Me.txt_TripID.TabIndex = 65
        '
        'lbl_TripID
        '
        Me.lbl_TripID.AutoSize = True
        Me.lbl_TripID.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lbl_TripID.Location = New System.Drawing.Point(28, 523)
        Me.lbl_TripID.Name = "lbl_TripID"
        Me.lbl_TripID.Size = New System.Drawing.Size(53, 20)
        Me.lbl_TripID.TabIndex = 64
        Me.lbl_TripID.Text = "Trip ID"
        '
        'lbl_TripDate
        '
        Me.lbl_TripDate.AutoSize = True
        Me.lbl_TripDate.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lbl_TripDate.Location = New System.Drawing.Point(329, 704)
        Me.lbl_TripDate.Name = "lbl_TripDate"
        Me.lbl_TripDate.Size = New System.Drawing.Size(70, 20)
        Me.lbl_TripDate.TabIndex = 63
        Me.lbl_TripDate.Text = "Trip Date"
        '
        'lbl_CostperPupil
        '
        Me.lbl_CostperPupil.AutoSize = True
        Me.lbl_CostperPupil.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lbl_CostperPupil.Location = New System.Drawing.Point(328, 587)
        Me.lbl_CostperPupil.Name = "lbl_CostperPupil"
        Me.lbl_CostperPupil.Size = New System.Drawing.Size(123, 20)
        Me.lbl_CostperPupil.TabIndex = 60
        Me.lbl_CostperPupil.Text = "Cost per Pupil (£)"
        '
        'lbl_ArrivalTime
        '
        Me.lbl_ArrivalTime.AutoSize = True
        Me.lbl_ArrivalTime.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lbl_ArrivalTime.Location = New System.Drawing.Point(328, 528)
        Me.lbl_ArrivalTime.Name = "lbl_ArrivalTime"
        Me.lbl_ArrivalTime.Size = New System.Drawing.Size(89, 20)
        Me.lbl_ArrivalTime.TabIndex = 59
        Me.lbl_ArrivalTime.Text = "Arrival Time"
        '
        'lbl_DepartureTime
        '
        Me.lbl_DepartureTime.AutoSize = True
        Me.lbl_DepartureTime.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lbl_DepartureTime.Location = New System.Drawing.Point(329, 647)
        Me.lbl_DepartureTime.Name = "lbl_DepartureTime"
        Me.lbl_DepartureTime.Size = New System.Drawing.Size(113, 20)
        Me.lbl_DepartureTime.TabIndex = 58
        Me.lbl_DepartureTime.Text = "Departure Time"
        '
        'lbl_TripLocation
        '
        Me.lbl_TripLocation.AutoSize = True
        Me.lbl_TripLocation.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lbl_TripLocation.Location = New System.Drawing.Point(27, 647)
        Me.lbl_TripLocation.Name = "lbl_TripLocation"
        Me.lbl_TripLocation.Size = New System.Drawing.Size(134, 20)
        Me.lbl_TripLocation.TabIndex = 57
        Me.lbl_TripLocation.Text = "Trip Location (City)"
        '
        'lbl_TripName
        '
        Me.lbl_TripName.AutoSize = True
        Me.lbl_TripName.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lbl_TripName.Location = New System.Drawing.Point(27, 587)
        Me.lbl_TripName.Name = "lbl_TripName"
        Me.lbl_TripName.Size = New System.Drawing.Size(78, 20)
        Me.lbl_TripName.TabIndex = 56
        Me.lbl_TripName.Text = "Trip Name"
        '
        'dtp_TripDate
        '
        Me.dtp_TripDate.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.dtp_TripDate.Location = New System.Drawing.Point(332, 726)
        Me.dtp_TripDate.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dtp_TripDate.Name = "dtp_TripDate"
        Me.dtp_TripDate.Size = New System.Drawing.Size(217, 27)
        Me.dtp_TripDate.TabIndex = 55
        '
        'txt_CostperPupil
        '
        Me.txt_CostperPupil.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txt_CostperPupil.Location = New System.Drawing.Point(332, 609)
        Me.txt_CostperPupil.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txt_CostperPupil.Name = "txt_CostperPupil"
        Me.txt_CostperPupil.Size = New System.Drawing.Size(217, 27)
        Me.txt_CostperPupil.TabIndex = 52
        '
        'txt_TripLocation
        '
        Me.txt_TripLocation.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txt_TripLocation.Location = New System.Drawing.Point(31, 668)
        Me.txt_TripLocation.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txt_TripLocation.Name = "txt_TripLocation"
        Me.txt_TripLocation.Size = New System.Drawing.Size(217, 27)
        Me.txt_TripLocation.TabIndex = 49
        '
        'txt_TripName
        '
        Me.txt_TripName.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txt_TripName.Location = New System.Drawing.Point(32, 609)
        Me.txt_TripName.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txt_TripName.Name = "txt_TripName"
        Me.txt_TripName.Size = New System.Drawing.Size(217, 27)
        Me.txt_TripName.TabIndex = 48
        '
        'cmd_deleteRecord
        '
        Me.cmd_deleteRecord.Location = New System.Drawing.Point(1572, 551)
        Me.cmd_deleteRecord.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmd_deleteRecord.Name = "cmd_deleteRecord"
        Me.cmd_deleteRecord.Size = New System.Drawing.Size(155, 96)
        Me.cmd_deleteRecord.TabIndex = 121
        Me.cmd_deleteRecord.Text = "Delete Student Record"
        Me.cmd_deleteRecord.UseVisualStyleBackColor = True
        '
        'dtp_ArrivalTime
        '
        Me.dtp_ArrivalTime.CustomFormat = "HH:mm"
        Me.dtp_ArrivalTime.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.dtp_ArrivalTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_ArrivalTime.Location = New System.Drawing.Point(332, 550)
        Me.dtp_ArrivalTime.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dtp_ArrivalTime.Name = "dtp_ArrivalTime"
        Me.dtp_ArrivalTime.ShowUpDown = True
        Me.dtp_ArrivalTime.Size = New System.Drawing.Size(217, 27)
        Me.dtp_ArrivalTime.TabIndex = 122
        Me.dtp_ArrivalTime.Value = New Date(2025, 12, 24, 0, 0, 0, 0)
        '
        'dtp_DepartureTime
        '
        Me.dtp_DepartureTime.CustomFormat = "HH:mm"
        Me.dtp_DepartureTime.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.dtp_DepartureTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_DepartureTime.Location = New System.Drawing.Point(332, 666)
        Me.dtp_DepartureTime.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dtp_DepartureTime.Name = "dtp_DepartureTime"
        Me.dtp_DepartureTime.ShowUpDown = True
        Me.dtp_DepartureTime.Size = New System.Drawing.Size(217, 27)
        Me.dtp_DepartureTime.TabIndex = 123
        Me.dtp_DepartureTime.Value = New Date(2025, 12, 24, 0, 0, 0, 0)
        '
        'pbx_First
        '
        Me.pbx_First.Location = New System.Drawing.Point(953, 486)
        Me.pbx_First.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pbx_First.Name = "pbx_First"
        Me.pbx_First.Size = New System.Drawing.Size(127, 57)
        Me.pbx_First.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbx_First.TabIndex = 125
        Me.pbx_First.TabStop = False
        '
        'pbx_Previous
        '
        Me.pbx_Previous.Location = New System.Drawing.Point(953, 550)
        Me.pbx_Previous.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pbx_Previous.Name = "pbx_Previous"
        Me.pbx_Previous.Size = New System.Drawing.Size(127, 57)
        Me.pbx_Previous.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbx_Previous.TabIndex = 126
        Me.pbx_Previous.TabStop = False
        '
        'pbx_Next
        '
        Me.pbx_Next.Location = New System.Drawing.Point(1305, 550)
        Me.pbx_Next.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pbx_Next.Name = "pbx_Next"
        Me.pbx_Next.Size = New System.Drawing.Size(127, 57)
        Me.pbx_Next.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbx_Next.TabIndex = 127
        Me.pbx_Next.TabStop = False
        '
        'pbx_Last
        '
        Me.pbx_Last.Location = New System.Drawing.Point(1305, 486)
        Me.pbx_Last.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pbx_Last.Name = "pbx_Last"
        Me.pbx_Last.Size = New System.Drawing.Size(127, 57)
        Me.pbx_Last.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbx_Last.TabIndex = 128
        Me.pbx_Last.TabStop = False
        '
        'pbx_NewTrip
        '
        Me.pbx_NewTrip.Location = New System.Drawing.Point(953, 647)
        Me.pbx_NewTrip.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pbx_NewTrip.Name = "pbx_NewTrip"
        Me.pbx_NewTrip.Size = New System.Drawing.Size(127, 57)
        Me.pbx_NewTrip.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbx_NewTrip.TabIndex = 129
        Me.pbx_NewTrip.TabStop = False
        '
        'pbx_SaveTrip
        '
        Me.pbx_SaveTrip.Location = New System.Drawing.Point(1132, 647)
        Me.pbx_SaveTrip.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pbx_SaveTrip.Name = "pbx_SaveTrip"
        Me.pbx_SaveTrip.Size = New System.Drawing.Size(127, 57)
        Me.pbx_SaveTrip.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbx_SaveTrip.TabIndex = 130
        Me.pbx_SaveTrip.TabStop = False
        '
        'pbx_DeleteTrip
        '
        Me.pbx_DeleteTrip.Location = New System.Drawing.Point(1305, 647)
        Me.pbx_DeleteTrip.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pbx_DeleteTrip.Name = "pbx_DeleteTrip"
        Me.pbx_DeleteTrip.Size = New System.Drawing.Size(127, 57)
        Me.pbx_DeleteTrip.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbx_DeleteTrip.TabIndex = 131
        Me.pbx_DeleteTrip.TabStop = False
        '
        'pbx_Close
        '
        Me.pbx_Close.Location = New System.Drawing.Point(1355, 12)
        Me.pbx_Close.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pbx_Close.Name = "pbx_Close"
        Me.pbx_Close.Size = New System.Drawing.Size(98, 44)
        Me.pbx_Close.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbx_Close.TabIndex = 132
        Me.pbx_Close.TabStop = False
        '
        'pic_Help
        '
        Me.pic_Help.Location = New System.Drawing.Point(12, 11)
        Me.pic_Help.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pic_Help.Name = "pic_Help"
        Me.pic_Help.Size = New System.Drawing.Size(43, 36)
        Me.pic_Help.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pic_Help.TabIndex = 134
        Me.pic_Help.TabStop = False
        '
        'lbl_TripDetails
        '
        Me.lbl_TripDetails.AutoSize = True
        Me.lbl_TripDetails.BackColor = System.Drawing.Color.Transparent
        Me.lbl_TripDetails.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_TripDetails.ForeColor = System.Drawing.Color.RoyalBlue
        Me.lbl_TripDetails.Location = New System.Drawing.Point(75, 486)
        Me.lbl_TripDetails.Name = "lbl_TripDetails"
        Me.lbl_TripDetails.Size = New System.Drawing.Size(120, 28)
        Me.lbl_TripDetails.TabIndex = 136
        Me.lbl_TripDetails.Text = "Trip Details"
        '
        'lbl_TripLogistics
        '
        Me.lbl_TripLogistics.AutoSize = True
        Me.lbl_TripLogistics.BackColor = System.Drawing.Color.Transparent
        Me.lbl_TripLogistics.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_TripLogistics.ForeColor = System.Drawing.Color.RoyalBlue
        Me.lbl_TripLogistics.Location = New System.Drawing.Point(369, 486)
        Me.lbl_TripLogistics.Name = "lbl_TripLogistics"
        Me.lbl_TripLogistics.Size = New System.Drawing.Size(136, 28)
        Me.lbl_TripLogistics.TabIndex = 135
        Me.lbl_TripLogistics.Text = "Trip Logistics"
        '
        'pbx_SearchTrip
        '
        Me.pbx_SearchTrip.Location = New System.Drawing.Point(1132, 722)
        Me.pbx_SearchTrip.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pbx_SearchTrip.Name = "pbx_SearchTrip"
        Me.pbx_SearchTrip.Size = New System.Drawing.Size(127, 57)
        Me.pbx_SearchTrip.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbx_SearchTrip.TabIndex = 137
        Me.pbx_SearchTrip.TabStop = False
        '
        'pbx_BackToAdmin
        '
        Me.pbx_BackToAdmin.Location = New System.Drawing.Point(1245, 10)
        Me.pbx_BackToAdmin.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pbx_BackToAdmin.Name = "pbx_BackToAdmin"
        Me.pbx_BackToAdmin.Size = New System.Drawing.Size(104, 54)
        Me.pbx_BackToAdmin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbx_BackToAdmin.TabIndex = 138
        Me.pbx_BackToAdmin.TabStop = False
        '
        'Manage_Trips
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ClientSize = New System.Drawing.Size(1464, 817)
        Me.Controls.Add(Me.pbx_BackToAdmin)
        Me.Controls.Add(Me.pbx_SearchTrip)
        Me.Controls.Add(Me.lbl_TripDetails)
        Me.Controls.Add(Me.lbl_TripLogistics)
        Me.Controls.Add(Me.pic_Help)
        Me.Controls.Add(Me.pbx_Close)
        Me.Controls.Add(Me.pbx_DeleteTrip)
        Me.Controls.Add(Me.pbx_SaveTrip)
        Me.Controls.Add(Me.pbx_NewTrip)
        Me.Controls.Add(Me.pbx_Last)
        Me.Controls.Add(Me.pbx_Next)
        Me.Controls.Add(Me.pbx_Previous)
        Me.Controls.Add(Me.pbx_First)
        Me.Controls.Add(Me.dtp_DepartureTime)
        Me.Controls.Add(Me.dtp_ArrivalTime)
        Me.Controls.Add(Me.cmd_deleteRecord)
        Me.Controls.Add(Me.txt_TripID)
        Me.Controls.Add(Me.lbl_TripID)
        Me.Controls.Add(Me.lbl_TripDate)
        Me.Controls.Add(Me.lbl_CostperPupil)
        Me.Controls.Add(Me.lbl_ArrivalTime)
        Me.Controls.Add(Me.lbl_DepartureTime)
        Me.Controls.Add(Me.lbl_TripLocation)
        Me.Controls.Add(Me.lbl_TripName)
        Me.Controls.Add(Me.dtp_TripDate)
        Me.Controls.Add(Me.txt_CostperPupil)
        Me.Controls.Add(Me.txt_TripLocation)
        Me.Controls.Add(Me.txt_TripName)
        Me.Controls.Add(Me.dgv_TripDetails)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Manage_Trips"
        Me.Text = "Manage_Trips"
        CType(Me.dgv_TripDetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbx_First, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbx_Previous, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbx_Next, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbx_Last, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbx_NewTrip, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbx_SaveTrip, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbx_DeleteTrip, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbx_Close, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pic_Help, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbx_SearchTrip, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbx_BackToAdmin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgv_TripDetails As DataGridView
    Friend WithEvents txt_TripID As TextBox
    Friend WithEvents lbl_TripID As Label
    Friend WithEvents lbl_TripDate As Label
    Friend WithEvents lbl_CostperPupil As Label
    Friend WithEvents lbl_ArrivalTime As Label
    Friend WithEvents lbl_DepartureTime As Label
    Friend WithEvents lbl_TripLocation As Label
    Friend WithEvents lbl_TripName As Label
    Friend WithEvents dtp_TripDate As DateTimePicker
    Friend WithEvents txt_CostperPupil As TextBox
    Friend WithEvents txt_TripLocation As TextBox
    Friend WithEvents txt_TripName As TextBox
    Friend WithEvents cmd_deleteRecord As Button
    Friend WithEvents dtp_ArrivalTime As DateTimePicker
    Friend WithEvents dtp_DepartureTime As DateTimePicker
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents pbx_First As PictureBox
    Friend WithEvents pbx_Previous As PictureBox
    Friend WithEvents pbx_Next As PictureBox
    Friend WithEvents pbx_Last As PictureBox
    Friend WithEvents pbx_NewTrip As PictureBox
    Friend WithEvents pbx_SaveTrip As PictureBox
    Friend WithEvents pbx_DeleteTrip As PictureBox
    Friend WithEvents pbx_Close As PictureBox
    Friend WithEvents pic_Help As PictureBox
    Friend WithEvents lbl_TripDetails As Label
    Friend WithEvents lbl_TripLogistics As Label
    Friend WithEvents pbx_SearchTrip As PictureBox
    Friend WithEvents pbx_BackToAdmin As PictureBox
End Class
