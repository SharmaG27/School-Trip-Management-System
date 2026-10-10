Imports System.IO


Public Class Login


    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ApplyBgTheme() 'Execute ApplyBgTheme function. This is created in the global module. 

        txt_username.Text = ""
        txt_password.Text = ""

        'Clear the username and password text fileds the first time this form loads up. 



        GetFiles()  'Execute GetFiles function. This is created in the global module. 

        Me.Text = FormTitle & ": LOGIN"

        'Rename the form to make it look more bespoke. 


        CentreForm(Me)


        '2 variables are set as the form's width and form's height respectively. (screenwidth, screenheight)
        'the other 2 variables take the form's boundaries away from the screen's boundaries which gives us the 
        'position of the form on our screen when it loads. Since we divided both sides' widths and heights by 2,
        'the form is exactly in the screen's centre as it loads. Using variables lets us use this code irrespective of 
        'different widths and heights of different forms.

        pic_chcsLogo.ImageLocation = MyImages & "chcsLogo.png"


        pic_usernameHelp.ImageLocation = MyImages & "help.png"
        pic_passwordHelp.ImageLocation = MyImages & "help.png"

        'Lets the system access my images by finding them through the file paths. 



        lbl_incorrectLogin.Hide()       'Hide the incorrect login text when the form loads since there have been 0 login attempts at this stage. 


        pbx_Close.ImageLocation = MyImages & "close1.png"
        pbx_login.ImageLocation = MyImages & "login1.png"
        pbx_SplashScreen.ImageLocation = MyImages & "BackToSplashScreen1.png"

    End Sub




    Private Sub pic_usernameHelp_MouseLeave(sender As Object, e As EventArgs) Handles pic_usernameHelp.MouseLeave
        Help.Visible = False


        'If mouse hovers over then leaves the icon, Help form is hidden.

    End Sub


    Private Sub pic_usernameHelp_MouseHover(sender As Object, e As EventArgs) Handles pic_usernameHelp.MouseHover
        Help.Visible = True
        Help.lbl_helpHeadingEng.Text = "Username"
        Help.rtxt_helpInfoEng.Text = "Enter your username in the text box. This username will have been assigned to you."

        Help.lbl_helpHeadingWel.Text = "Enw Defnyddiwr"
        Help.rtxt_helpInfoWel.Text = "Rhowch eich enw defnyddiwr yn y blwch testun. Bydd yr enw defnyddiwr hwn wedi ei aseinio i chi."



        'when this specific icon is hovered over, Help form is revealed and text is altered as above to match this situation. 

    End Sub

    Private Sub pic_passwordHelp_MouseHover(sender As Object, e As EventArgs) Handles pic_passwordHelp.MouseHover

        Help.Visible = True
        Help.lbl_helpHeadingEng.Text = "Password"
        Help.rtxt_helpInfoEng.Text = "Enter your password in the text box. This password will have been assigned to you. Rhowch eich cyfrinair."

        Help.lbl_helpHeadingWel.Text = "Cyfrinair"
        Help.rtxt_helpInfoWel.Text = "Rhowch eich cyfrinair yn y blwch testun. Bydd y cyfrinair hwn wedi'i neilltuo i chi. Rhowch eich cyfrinair."


        'when this specific icon is hovered over, Help form is revealed and text is altered as above to match this situation. 

    End Sub

    Private Sub pic_passwordHelp_MouseLeave(sender As Object, e As EventArgs) Handles pic_passwordHelp.MouseLeave
        Help.Visible = False


        'If mouse hovers over then leaves the icon, Help form is hidden.

    End Sub

    Private Sub cmd_SplashScreen_Click(sender As Object, e As EventArgs)
        txt_username.Text = ""
        txt_password.Text = ""
        lbl_incorrectLogin.Hide()
        Me.Visible = False
        Splash_Screen.Visible = True


        'when splash screen is clicked, login form is hidden and splash screen is revealed. 
        'textboxes are cleared so if the user revisits login form, it looks like the page is refreshed. 

    End Sub


    Private Sub pbx_Close_MouseEnter(sender As Object, e As EventArgs) Handles pbx_Close.MouseEnter

        pbx_Close.ImageLocation = MyImages & "close2.png"

        'When the mouse hovers over the button, the second part of the rollover image is shown


    End Sub

    Private Sub pbx_Close_MouseLeave(sender As Object, e As EventArgs) Handles pbx_Close.MouseLeave

        pbx_Close.ImageLocation = MyImages & "close1.png"

        'When the mouse leaves the PicBox after hovering over it, we return to the first half
        'of the rollover image

    End Sub

    Private Sub pbx_Close_Click(sender As Object, e As EventArgs) Handles pbx_Close.Click


        If ConfirmActions = True Then

            If MsgBox("Are you sure you want to close the system?",
                  MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation,
                  "Confirm Action") = MsgBoxResult.No Then

                Exit Sub

            End If

        End If

        Application.Exit()

        'Comletey closes the program

    End Sub

    Private Sub pbx_login_MouseEnter(sender As Object, e As EventArgs) Handles pbx_login.MouseEnter

        pbx_login.ImageLocation = MyImages & "login2.png"

        'When the mouse hovers over the button, the second part of the rollover image is shown


    End Sub

    Private Sub pbx_login_MouseLeave(sender As Object, e As EventArgs) Handles pbx_login.MouseLeave

        pbx_login.ImageLocation = MyImages & "login1.png"

        'When the mouse leaves the PicBox after hovering over it, we return to the first half
        'of the rollover image

    End Sub

    Private Sub pbx_login_Click(sender As Object, e As EventArgs) Handles pbx_login.Click

        Dim Username As String
        Dim Password As String
        Dim MainMenuForm As MAIN_MENU



        Dim OneRecord As String

        Dim fields() As String              'dynamic array

        Dim LoginSuccess As Boolean = False



        Username = LCase(txt_username.Text)
        Password = txt_password.Text

        'Username variable is the lowercase of username. This is since username is not case sensitive while password IS.


        Dim Login_sr As New StreamReader(UserLogin_File)

        'True = append the UserLogin file. Do not overwrite it. 


        While Login_sr.Peek() >= 0

            Dim OneRecordEncrypt As String


            OneRecord = Login_sr.ReadLine

            OneRecordEncrypt = XORencrypt(OneRecord)

            fields = OneRecordEncrypt.Split(",")


            If Username = fields(2) AndAlso Password = fields(3) Then

                LoginSuccess = True
                lbl_incorrectLogin.Hide()

                MsgBox("Successful Login. Welcome!", MsgBoxStyle.OkOnly + MsgBoxStyle.Information)


                LoginID_Global = fields(1)
                LoginAccessLevel_Global = CInt(fields(0))





                Me.Hide()

                MAIN_MENU.Close()
                MainMenuForm = New MAIN_MENU()
                MainMenuForm.Show()




                Exit While



            End If


            'For every line in the UserLogin text file, decrypt the line and split each field in the line by commas
            'and place each field into a singular slot in the fields() dynamic array. If the inputted username and password
            'exactly match fields 2 and 3, which are the designated username and password fields from the line, login is successful.
            'Once the user confirms the message box, login form is hidden and main menu is revealed. Fields 0 and 1 
            '(ID and AccessLevel) are saved into the 2 global variables. 

            'I can see that it should be reserved only for Student ID's, but teachers and receptionists cannot use these
            'anyway since accessLevel AND stduent ID must match to a person when supervising/signing up to a trip. 

            'If login details do not match records, the boolean is set to false and the user is left with blank textboxes
            'and urged to try again. This code is seen below. 



        End While


        Login_sr.Close()


        If LoginSuccess = False Then

            lbl_incorrectLogin.Show()

            txt_username.Text = ""
            txt_password.Text = ""

        ElseIf LoginSuccess = True Then

            txt_username.Text = ""
            txt_password.Text = ""

        End If



    End Sub

    Private Sub pbx_SplashScreen_MouseEnter(sender As Object, e As EventArgs) Handles pbx_SplashScreen.MouseEnter

        pbx_SplashScreen.ImageLocation = MyImages & "BackToSplashScreen2.png"

        'When the mouse hovers over the button, the second part of the rollover image is shown

    End Sub

    Private Sub pbx_SplashScreen_MouseLeave(sender As Object, e As EventArgs) Handles pbx_SplashScreen.MouseLeave

        pbx_SplashScreen.ImageLocation = MyImages & "BackToSplashScreen1.png"

        'When the mouse leaves the PicBox after hovering over it, we return to the first half
        'of the rollover image

    End Sub

    Private Sub pbx_SplashScreen_Click(sender As Object, e As EventArgs) Handles pbx_SplashScreen.Click

        txt_username.Text = ""
        txt_password.Text = ""
        lbl_incorrectLogin.Hide()
        Me.Visible = False
        Splash_Screen.Visible = True


        'when splash screen is clicked, login form is hidden and splash screen is revealed. 
        'textboxes are cleared so if the user revisits login form, it looks like the page is refreshed. 

    End Sub
End Class