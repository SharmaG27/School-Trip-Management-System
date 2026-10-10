<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TripSupervise
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
        Me.dgv_TripStudents = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pbx_Last = New System.Windows.Forms.PictureBox()
        Me.pbx_Next = New System.Windows.Forms.PictureBox()
        Me.pbx_Previous = New System.Windows.Forms.PictureBox()
        Me.pbx_first = New System.Windows.Forms.PictureBox()
        Me.pbx_close = New System.Windows.Forms.PictureBox()
        Me.pbx_supervise = New System.Windows.Forms.PictureBox()
        Me.pbx_back = New System.Windows.Forms.PictureBox()
        Me.pic_Help = New System.Windows.Forms.PictureBox()
        CType(Me.dgv_TripDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_TripStudents, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbx_Last, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbx_Next, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbx_Previous, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbx_first, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbx_close, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbx_supervise, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbx_back, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.dgv_TripDetails.Location = New System.Drawing.Point(13, 76)
        Me.dgv_TripDetails.Margin = New System.Windows.Forms.Padding(4)
        Me.dgv_TripDetails.Name = "dgv_TripDetails"
        Me.dgv_TripDetails.ReadOnly = True
        Me.dgv_TripDetails.RowHeadersVisible = False
        Me.dgv_TripDetails.RowHeadersWidth = 51
        Me.dgv_TripDetails.Size = New System.Drawing.Size(887, 386)
        Me.dgv_TripDetails.TabIndex = 21
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
        'dgv_TripStudents
        '
        Me.dgv_TripStudents.AllowUserToAddRows = False
        Me.dgv_TripStudents.AllowUserToDeleteRows = False
        Me.dgv_TripStudents.BackgroundColor = System.Drawing.Color.LightSteelBlue
        Me.dgv_TripStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_TripStudents.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.Column8})
        Me.dgv_TripStudents.GridColor = System.Drawing.Color.LightGray
        Me.dgv_TripStudents.Location = New System.Drawing.Point(922, 76)
        Me.dgv_TripStudents.Margin = New System.Windows.Forms.Padding(4)
        Me.dgv_TripStudents.Name = "dgv_TripStudents"
        Me.dgv_TripStudents.ReadOnly = True
        Me.dgv_TripStudents.RowHeadersVisible = False
        Me.dgv_TripStudents.RowHeadersWidth = 51
        Me.dgv_TripStudents.Size = New System.Drawing.Size(527, 386)
        Me.dgv_TripStudents.TabIndex = 124
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn1.HeaderText = "Student ID"
        Me.DataGridViewTextBoxColumn1.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn2.HeaderText = "Student Surname"
        Me.DataGridViewTextBoxColumn2.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn3.HeaderText = "Student Forename"
        Me.DataGridViewTextBoxColumn3.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'Column8
        '
        Me.Column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column8.HeaderText = "Supervised by Teacher:"
        Me.Column8.MinimumWidth = 6
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        '
        'pbx_Last
        '
        Me.pbx_Last.Location = New System.Drawing.Point(544, 504)
        Me.pbx_Last.Name = "pbx_Last"
        Me.pbx_Last.Size = New System.Drawing.Size(127, 57)
        Me.pbx_Last.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbx_Last.TabIndex = 128
        Me.pbx_Last.TabStop = False
        '
        'pbx_Next
        '
        Me.pbx_Next.Location = New System.Drawing.Point(544, 576)
        Me.pbx_Next.Name = "pbx_Next"
        Me.pbx_Next.Size = New System.Drawing.Size(127, 57)
        Me.pbx_Next.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbx_Next.TabIndex = 127
        Me.pbx_Next.TabStop = False
        '
        'pbx_Previous
        '
        Me.pbx_Previous.Location = New System.Drawing.Point(237, 576)
        Me.pbx_Previous.Name = "pbx_Previous"
        Me.pbx_Previous.Size = New System.Drawing.Size(127, 57)
        Me.pbx_Previous.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbx_Previous.TabIndex = 126
        Me.pbx_Previous.TabStop = False
        '
        'pbx_first
        '
        Me.pbx_first.Location = New System.Drawing.Point(237, 504)
        Me.pbx_first.Name = "pbx_first"
        Me.pbx_first.Size = New System.Drawing.Size(127, 57)
        Me.pbx_first.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbx_first.TabIndex = 125
        Me.pbx_first.TabStop = False
        '
        'pbx_close
        '
        Me.pbx_close.Location = New System.Drawing.Point(1351, 11)
        Me.pbx_close.Name = "pbx_close"
        Me.pbx_close.Size = New System.Drawing.Size(98, 44)
        Me.pbx_close.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbx_close.TabIndex = 129
        Me.pbx_close.TabStop = False
        '
        'pbx_supervise
        '
        Me.pbx_supervise.Location = New System.Drawing.Point(395, 676)
        Me.pbx_supervise.Name = "pbx_supervise"
        Me.pbx_supervise.Size = New System.Drawing.Size(127, 57)
        Me.pbx_supervise.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbx_supervise.TabIndex = 130
        Me.pbx_supervise.TabStop = False
        '
        'pbx_back
        '
        Me.pbx_back.Location = New System.Drawing.Point(1241, 11)
        Me.pbx_back.Name = "pbx_back"
        Me.pbx_back.Size = New System.Drawing.Size(104, 54)
        Me.pbx_back.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbx_back.TabIndex = 131
        Me.pbx_back.TabStop = False
        '
        'pic_Help
        '
        Me.pic_Help.Location = New System.Drawing.Point(12, 11)
        Me.pic_Help.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pic_Help.Name = "pic_Help"
        Me.pic_Help.Size = New System.Drawing.Size(43, 36)
        Me.pic_Help.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pic_Help.TabIndex = 137
        Me.pic_Help.TabStop = False
        '
        'TripSupervise
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ClientSize = New System.Drawing.Size(1464, 817)
        Me.Controls.Add(Me.pic_Help)
        Me.Controls.Add(Me.pbx_back)
        Me.Controls.Add(Me.pbx_supervise)
        Me.Controls.Add(Me.pbx_close)
        Me.Controls.Add(Me.pbx_Last)
        Me.Controls.Add(Me.pbx_Next)
        Me.Controls.Add(Me.pbx_Previous)
        Me.Controls.Add(Me.pbx_first)
        Me.Controls.Add(Me.dgv_TripStudents)
        Me.Controls.Add(Me.dgv_TripDetails)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "TripSupervise"
        Me.Text = "TripSupervise"
        CType(Me.dgv_TripDetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_TripStudents, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbx_Last, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbx_Next, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbx_Previous, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbx_first, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbx_close, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbx_supervise, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbx_back, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pic_Help, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgv_TripDetails As DataGridView
    Friend WithEvents dgv_TripStudents As DataGridView
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents Column8 As DataGridViewTextBoxColumn
    Friend WithEvents pbx_Last As PictureBox
    Friend WithEvents pbx_Next As PictureBox
    Friend WithEvents pbx_Previous As PictureBox
    Friend WithEvents pbx_first As PictureBox
    Friend WithEvents pbx_close As PictureBox
    Friend WithEvents pbx_supervise As PictureBox
    Friend WithEvents pbx_back As PictureBox
    Friend WithEvents pic_Help As PictureBox
End Class
