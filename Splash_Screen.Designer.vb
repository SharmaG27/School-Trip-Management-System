<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Splash_Screen
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
        Me.lbl_welcome = New System.Windows.Forms.Label()
        Me.lbl_welcomeMessage = New System.Windows.Forms.Label()
        Me.pic_chcsLogo = New System.Windows.Forms.PictureBox()
        Me.pbx_Close = New System.Windows.Forms.PictureBox()
        Me.pbx_GoToLogin = New System.Windows.Forms.PictureBox()
        CType(Me.pic_chcsLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbx_Close, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbx_GoToLogin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbl_welcome
        '
        Me.lbl_welcome.AutoSize = True
        Me.lbl_welcome.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_welcome.Location = New System.Drawing.Point(136, 116)
        Me.lbl_welcome.Name = "lbl_welcome"
        Me.lbl_welcome.Size = New System.Drawing.Size(378, 62)
        Me.lbl_welcome.TabIndex = 2
        Me.lbl_welcome.Text = "Cefn Hengoed Community School" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Trip Booking System"
        Me.lbl_welcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_welcomeMessage
        '
        Me.lbl_welcomeMessage.AutoSize = True
        Me.lbl_welcomeMessage.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lbl_welcomeMessage.Location = New System.Drawing.Point(206, 508)
        Me.lbl_welcomeMessage.Name = "lbl_welcomeMessage"
        Me.lbl_welcomeMessage.Size = New System.Drawing.Size(255, 69)
        Me.lbl_welcomeMessage.TabIndex = 3
        Me.lbl_welcomeMessage.Text = "Click the button below to log in." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Cliciwch y botwm i fewngofnodi." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.lbl_welcomeMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pic_chcsLogo
        '
        Me.pic_chcsLogo.Location = New System.Drawing.Point(250, 209)
        Me.pic_chcsLogo.Name = "pic_chcsLogo"
        Me.pic_chcsLogo.Size = New System.Drawing.Size(356, 244)
        Me.pic_chcsLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pic_chcsLogo.TabIndex = 6
        Me.pic_chcsLogo.TabStop = False
        '
        'pbx_Close
        '
        Me.pbx_Close.Location = New System.Drawing.Point(558, 12)
        Me.pbx_Close.Name = "pbx_Close"
        Me.pbx_Close.Size = New System.Drawing.Size(98, 44)
        Me.pbx_Close.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbx_Close.TabIndex = 13
        Me.pbx_Close.TabStop = False
        '
        'pbx_GoToLogin
        '
        Me.pbx_GoToLogin.Location = New System.Drawing.Point(263, 567)
        Me.pbx_GoToLogin.Name = "pbx_GoToLogin"
        Me.pbx_GoToLogin.Size = New System.Drawing.Size(127, 57)
        Me.pbx_GoToLogin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbx_GoToLogin.TabIndex = 14
        Me.pbx_GoToLogin.TabStop = False
        '
        'Splash_Screen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ClientSize = New System.Drawing.Size(668, 672)
        Me.Controls.Add(Me.pbx_GoToLogin)
        Me.Controls.Add(Me.pbx_Close)
        Me.Controls.Add(Me.pic_chcsLogo)
        Me.Controls.Add(Me.lbl_welcomeMessage)
        Me.Controls.Add(Me.lbl_welcome)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Splash_Screen"
        Me.Text = "Splash_Screen"
        CType(Me.pic_chcsLogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbx_Close, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbx_GoToLogin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbl_welcome As Label
    Friend WithEvents lbl_welcomeMessage As Label
    Friend WithEvents pic_chcsLogo As PictureBox
    Friend WithEvents pbx_Close As PictureBox
    Friend WithEvents pbx_GoToLogin As PictureBox
End Class
