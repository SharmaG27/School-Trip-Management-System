Imports System.Security.Cryptography.X509Certificates

Public Class Settings
    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        GetFiles()


        ApplyBgTheme()

        'Allow background colour changing and extracting text file data to happen in this form


        CentreForm(Me)


        '2 variables are set as the form's width and form's height respectively. (screenwidth, screenheight)
        'the other 2 variables take the form's boundaries away from the screen's boundaries which gives us the 
        'position of the form on our screen when it loads. Since we divided both sides' widths and heights by 2,
        'the form is exactly in the screen's centre as it loads. Using variables lets us use this code irrespective of 
        'different widths and heights of different forms.


        Me.Text = FormTitle & ": SETTINGS"


        If ConfirmActions = True Then

            rad_ConfirmationChangesTrue.Checked = True

        Else

            rad_ConfirmationChangesFalse.Checked = True

        End If


        pbx_MainMenu.ImageLocation = MyImages & "MainMenu1.png"
        pic_SettingsHelp.ImageLocation = MyImages & "help.png"
        pic_chcsLogo.ImageLocation = MyImages & "chcsLogo.png"
        'Loads images which are saved in the 'images' folder into each PicBox


    End Sub



    Private Sub rad_whiteBG_CheckedChanged(sender As Object, e As EventArgs) Handles rad_whiteBG.CheckedChanged

        BgLightBlue = False
        ApplyBgTheme()

        'When white is selected, we set the boolean to False, indicating that BG colour needs to turn to White.
        'This boolean is turned to False in Global (it is a global boolean) and ApplyBgTheme() is ran to show
        'the updated changes.

    End Sub

    Private Sub rad_LightBlueBG_CheckedChanged(sender As Object, e As EventArgs) Handles rad_LightBlueBG.CheckedChanged

        BgLightBlue = True
        ApplyBgTheme()


        'When blue is selected, we set the boolean to True, indicating that BG colour needs to turn to Blue.
        'This boolean is turned to True in Global (it is a global boolean) and ApplyBgTheme() is ran to show
        'the updated changes.

    End Sub

    Private Sub rad_ConfirmationChangesTrue_CheckedChanged(sender As Object, e As EventArgs) Handles rad_ConfirmationChangesTrue.CheckedChanged


        If rad_ConfirmationChangesTrue.Checked Then
            ConfirmActions = True
        End If

        'if this button clicked, global confirmactions is true. 
        'all major actions like saving, deleting records, closing forms etc will ask for confirmation first.

    End Sub

    Private Sub rad_ConfirmationChangesFalse_CheckedChanged(sender As Object, e As EventArgs) Handles rad_ConfirmationChangesFalse.CheckedChanged


        If rad_ConfirmationChangesFalse.Checked Then
            ConfirmActions = False
        End If

        'if button clicked, global variable is set to false. all confirmation messages will be deactivated.

    End Sub

    Private Sub pbx_MainMenu_MouseEnter(sender As Object, e As EventArgs) Handles pbx_MainMenu.MouseEnter

        pbx_MainMenu.ImageLocation = MyImages & "MainMenu2.png"

        'When the mouse hovers over the button, the second part of the rollover image is shown


    End Sub

    Private Sub pbx_MainMenu_MouseLeave(sender As Object, e As EventArgs) Handles pbx_MainMenu.MouseLeave

        pbx_MainMenu.ImageLocation = MyImages & "MainMenu1.png"

        'When the mouse leaves the PicBox after hovering over it, we return to the first half
        'of the rollover image

    End Sub

    Private Sub pbx_MainMenu_Click(sender As Object, e As EventArgs) Handles pbx_MainMenu.Click

        Me.Visible = False
        MAIN_MENU.Visible = True

        'Hide teacher details form and reveal Main Menu form.

    End Sub



    Private Sub pic_SettingsHelp_MouseLeave(sender As Object, e As EventArgs) Handles pic_SettingsHelp.MouseLeave
        Help.Visible = False


        'If mouse hovers over then leaves the icon, Help form is hidden.

    End Sub


    Private Sub pic_SettingsHelp_MouseHover(sender As Object, e As EventArgs) Handles pic_SettingsHelp.MouseHover
        Help.Visible = True
        Help.lbl_helpHeadingEng.Text = "Settings"
        Help.rtxt_helpInfoEng.Text = "Use the select buttons below to adjust the background colour and whether you require confirmation before actions."

        Help.lbl_helpHeadingWel.Text = "Gosodiadaun"
        Help.rtxt_helpInfoWel.Text = "Defnyddiwch y botymau dewis isod i addasu'r lliw cefndir ac a oes angen cadarnhad arnoch cyn gweithredu."



        'when this specific icon is hovered over, Help form is revealed and text is altered as above to match this situation. 

    End Sub



End Class