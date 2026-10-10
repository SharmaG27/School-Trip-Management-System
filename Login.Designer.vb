<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Login
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
        Me.txt_password = New System.Windows.Forms.TextBox()
        Me.txt_username = New System.Windows.Forms.TextBox()
        Me.lbl_username = New System.Windows.Forms.Label()
        Me.lbl_password = New System.Windows.Forms.Label()
        Me.pic_chcsLogo = New System.Windows.Forms.PictureBox()
        Me.lbl_motto = New System.Windows.Forms.Label()
        Me.lbl_incorrectLogin = New System.Windows.Forms.Label()
        Me.pic_usernameHelp = New System.Windows.Forms.PictureBox()
        Me.pic_passwordHelp = New System.Windows.Forms.PictureBox()
        Me.pbx_Close = New System.Windows.Forms.PictureBox()
        Me.pbx_login = New System.Windows.Forms.PictureBox()
        Me.pbx_SplashScreen = New System.Windows.Forms.PictureBox()
        CType(Me.pic_chcsLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pic_usernameHelp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pic_passwordHelp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbx_Close, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbx_login, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbx_SplashScreen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txt_password
        '
        Me.txt_password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_password.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txt_password.Location = New System.Drawing.Point(197, 482)
        Me.txt_password.Name = "txt_password"
        Me.txt_password.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txt_password.Size = New System.Drawing.Size(228, 30)
        Me.txt_password.TabIndex = 1
        '
        'txt_username
        '
        Me.txt_username.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_username.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txt_username.Location = New System.Drawing.Point(197, 406)
        Me.txt_username.Name = "txt_username"
        Me.txt_username.Size = New System.Drawing.Size(228, 30)
        Me.txt_username.TabIndex = 2
        '
        'lbl_username
        '
        Me.lbl_username.AutoSize = True
        Me.lbl_username.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lbl_username.Location = New System.Drawing.Point(194, 380)
        Me.lbl_username.Name = "lbl_username"
        Me.lbl_username.Size = New System.Drawing.Size(87, 23)
        Me.lbl_username.TabIndex = 3
        Me.lbl_username.Text = "Username"
        '
        'lbl_password
        '
        Me.lbl_password.AutoSize = True
        Me.lbl_password.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lbl_password.Location = New System.Drawing.Point(194, 456)
        Me.lbl_password.Name = "lbl_password"
        Me.lbl_password.Size = New System.Drawing.Size(80, 23)
        Me.lbl_password.TabIndex = 4
        Me.lbl_password.Text = "Password"
        '
        'pic_chcsLogo
        '
        Me.pic_chcsLogo.Location = New System.Drawing.Point(249, 62)
        Me.pic_chcsLogo.Name = "pic_chcsLogo"
        Me.pic_chcsLogo.Size = New System.Drawing.Size(328, 223)
        Me.pic_chcsLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pic_chcsLogo.TabIndex = 5
        Me.pic_chcsLogo.TabStop = False
        '
        'lbl_motto
        '
        Me.lbl_motto.AutoSize = True
        Me.lbl_motto.Font = New System.Drawing.Font("Times New Roman", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_motto.Location = New System.Drawing.Point(147, 277)
        Me.lbl_motto.Name = "lbl_motto"
        Me.lbl_motto.Size = New System.Drawing.Size(348, 52)
        Me.lbl_motto.TabIndex = 6
        Me.lbl_motto.Text = "'If you believe it, you can achieve it'" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "'Credwch a Gwnewch'" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.lbl_motto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_incorrectLogin
        '
        Me.lbl_incorrectLogin.AutoSize = True
        Me.lbl_incorrectLogin.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lbl_incorrectLogin.ForeColor = System.Drawing.Color.Red
        Me.lbl_incorrectLogin.Location = New System.Drawing.Point(194, 524)
        Me.lbl_incorrectLogin.Name = "lbl_incorrectLogin"
        Me.lbl_incorrectLogin.Size = New System.Drawing.Size(290, 20)
        Me.lbl_incorrectLogin.TabIndex = 7
        Me.lbl_incorrectLogin.Text = "Incorrect username or password. Try again."
        '
        'pic_usernameHelp
        '
        Me.pic_usernameHelp.Location = New System.Drawing.Point(445, 402)
        Me.pic_usernameHelp.Name = "pic_usernameHelp"
        Me.pic_usernameHelp.Size = New System.Drawing.Size(43, 36)
        Me.pic_usernameHelp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pic_usernameHelp.TabIndex = 8
        Me.pic_usernameHelp.TabStop = False
        '
        'pic_passwordHelp
        '
        Me.pic_passwordHelp.Location = New System.Drawing.Point(445, 475)
        Me.pic_passwordHelp.Name = "pic_passwordHelp"
        Me.pic_passwordHelp.Size = New System.Drawing.Size(43, 39)
        Me.pic_passwordHelp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pic_passwordHelp.TabIndex = 9
        Me.pic_passwordHelp.TabStop = False
        '
        'pbx_Close
        '
        Me.pbx_Close.Location = New System.Drawing.Point(558, 12)
        Me.pbx_Close.Name = "pbx_Close"
        Me.pbx_Close.Size = New System.Drawing.Size(98, 44)
        Me.pbx_Close.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbx_Close.TabIndex = 14
        Me.pbx_Close.TabStop = False
        '
        'pbx_login
        '
        Me.pbx_login.Location = New System.Drawing.Point(247, 564)
        Me.pbx_login.Name = "pbx_login"
        Me.pbx_login.Size = New System.Drawing.Size(127, 57)
        Me.pbx_login.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbx_login.TabIndex = 15
        Me.pbx_login.TabStop = False
        '
        'pbx_SplashScreen
        '
        Me.pbx_SplashScreen.Location = New System.Drawing.Point(454, 12)
        Me.pbx_SplashScreen.Name = "pbx_SplashScreen"
        Me.pbx_SplashScreen.Size = New System.Drawing.Size(98, 44)
        Me.pbx_SplashScreen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbx_SplashScreen.TabIndex = 16
        Me.pbx_SplashScreen.TabStop = False
        '
        'Login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ClientSize = New System.Drawing.Size(668, 672)
        Me.Controls.Add(Me.pbx_SplashScreen)
        Me.Controls.Add(Me.pbx_login)
        Me.Controls.Add(Me.pbx_Close)
        Me.Controls.Add(Me.pic_passwordHelp)
        Me.Controls.Add(Me.pic_usernameHelp)
        Me.Controls.Add(Me.lbl_incorrectLogin)
        Me.Controls.Add(Me.lbl_motto)
        Me.Controls.Add(Me.pic_chcsLogo)
        Me.Controls.Add(Me.lbl_password)
        Me.Controls.Add(Me.lbl_username)
        Me.Controls.Add(Me.txt_username)
        Me.Controls.Add(Me.txt_password)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Login"
        Me.Text = "Login"
        CType(Me.pic_chcsLogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pic_usernameHelp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pic_passwordHelp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbx_Close, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbx_login, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbx_SplashScreen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txt_password As TextBox
    Friend WithEvents txt_username As TextBox
    Friend WithEvents lbl_username As Label
    Friend WithEvents lbl_password As Label
    Friend WithEvents pic_chcsLogo As PictureBox
    Friend WithEvents lbl_motto As Label
    Friend WithEvents lbl_incorrectLogin As Label
    Friend WithEvents pic_usernameHelp As PictureBox
    Friend WithEvents pic_passwordHelp As PictureBox
    Friend WithEvents pbx_Close As PictureBox
    Friend WithEvents pbx_login As PictureBox
    Friend WithEvents pbx_SplashScreen As PictureBox
End Class
