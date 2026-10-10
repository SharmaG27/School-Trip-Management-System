Imports System.Configuration
Imports System.IO

Public Class Help
    Private Sub Help_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim ScreenWidth As Integer
        Dim FormStartPosX As Integer
        Dim FormStartPosY As Integer

        ScreenWidth = Screen.PrimaryScreen.Bounds.Width
        FormStartPosX = ScreenWidth - (Me.Width + 10)
        FormStartPosY = 10

        Me.StartPosition = FormStartPosition.Manual
        Me.Location = New Point(FormStartPosX, FormStartPosY)


        ''2 variables are set as the form's width and form's height respectively. (screenwidth, screenheight)
        'the other 2 variables take the form's boundaries away from the screen's boundaries which gives us the 
        'position of the form on our screen when it loads. on the x axis, the form is positioned to the right side of the screen,
        'the right border of the screen and form are separated by 10 pixels. The form is moved up the screen too. 

    End Sub

    Private Sub Help_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged

        rtxt_helpInfoEng.SelectionStart = 0
        rtxt_helpInfoWel.SelectionStart = 0

        'Users cannot see the typing icon in the Rich Textbox.


        rtxt_helpInfoEng.ReadOnly = True
        rtxt_helpInfoWel.ReadOnly = True

        'Users cannot edit the textbox

        rtxt_helpInfoEng.TabStop = False
        rtxt_helpInfoWel.TabStop = False

        'Users cannot use Tab key to select the textbox.


        With rtxt_helpInfoEng
            .SelectAll()
            .SelectionIndent = 1
            .SelectionRightIndent = 1
            .DeselectAll()
        End With



        With rtxt_helpInfoWel
            .SelectAll()
            .SelectionIndent = 1
            .SelectionRightIndent = 1
            .DeselectAll()
        End With

        'Formatting both textboxes so the text does not touch the borders which does not look good.


    End Sub
End Class