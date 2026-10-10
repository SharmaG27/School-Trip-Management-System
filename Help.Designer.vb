<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Help
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
        Me.lbl_helpHeadingEng = New System.Windows.Forms.Label()
        Me.lbl_helpHeadingWel = New System.Windows.Forms.Label()
        Me.rtxt_helpInfoEng = New System.Windows.Forms.RichTextBox()
        Me.rtxt_helpInfoWel = New System.Windows.Forms.RichTextBox()
        Me.SuspendLayout()
        '
        'lbl_helpHeadingEng
        '
        Me.lbl_helpHeadingEng.AutoSize = True
        Me.lbl_helpHeadingEng.Font = New System.Drawing.Font("Segoe UI", 13.8!)
        Me.lbl_helpHeadingEng.Location = New System.Drawing.Point(12, 22)
        Me.lbl_helpHeadingEng.Name = "lbl_helpHeadingEng"
        Me.lbl_helpHeadingEng.Size = New System.Drawing.Size(81, 31)
        Me.lbl_helpHeadingEng.TabIndex = 1
        Me.lbl_helpHeadingEng.Text = "Label1"
        '
        'lbl_helpHeadingWel
        '
        Me.lbl_helpHeadingWel.AutoSize = True
        Me.lbl_helpHeadingWel.Font = New System.Drawing.Font("Segoe UI", 13.8!)
        Me.lbl_helpHeadingWel.Location = New System.Drawing.Point(12, 378)
        Me.lbl_helpHeadingWel.Name = "lbl_helpHeadingWel"
        Me.lbl_helpHeadingWel.Size = New System.Drawing.Size(81, 31)
        Me.lbl_helpHeadingWel.TabIndex = 3
        Me.lbl_helpHeadingWel.Text = "Label2"
        '
        'rtxt_helpInfoEng
        '
        Me.rtxt_helpInfoEng.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.rtxt_helpInfoEng.Location = New System.Drawing.Point(7, 55)
        Me.rtxt_helpInfoEng.Margin = New System.Windows.Forms.Padding(4)
        Me.rtxt_helpInfoEng.Name = "rtxt_helpInfoEng"
        Me.rtxt_helpInfoEng.Size = New System.Drawing.Size(415, 270)
        Me.rtxt_helpInfoEng.TabIndex = 4
        Me.rtxt_helpInfoEng.Text = ""
        '
        'rtxt_helpInfoWel
        '
        Me.rtxt_helpInfoWel.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.rtxt_helpInfoWel.Location = New System.Drawing.Point(8, 415)
        Me.rtxt_helpInfoWel.Margin = New System.Windows.Forms.Padding(4)
        Me.rtxt_helpInfoWel.Name = "rtxt_helpInfoWel"
        Me.rtxt_helpInfoWel.Size = New System.Drawing.Size(413, 270)
        Me.rtxt_helpInfoWel.TabIndex = 5
        Me.rtxt_helpInfoWel.Text = ""
        '
        'Help
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LemonChiffon
        Me.ClientSize = New System.Drawing.Size(428, 700)
        Me.Controls.Add(Me.rtxt_helpInfoWel)
        Me.Controls.Add(Me.rtxt_helpInfoEng)
        Me.Controls.Add(Me.lbl_helpHeadingWel)
        Me.Controls.Add(Me.lbl_helpHeadingEng)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Help"
        Me.Text = "Help"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbl_helpHeadingEng As Label
    Friend WithEvents lbl_helpHeadingWel As Label
    Friend WithEvents rtxt_helpInfoEng As RichTextBox
    Friend WithEvents rtxt_helpInfoWel As RichTextBox
End Class
