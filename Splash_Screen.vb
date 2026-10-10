Imports System.IO

Public Class Splash_Screen
    Private Sub Splash_Screen_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        CentreForm(Me)


        '2 variables are set as the form's width and form's height respectively. (screenwidth, screenheight)
        'the other 2 variables take the form's boundaries away from the screen's boundaries which gives us the 
        'position of the form on our screen when it loads. Since we divided both sides' widths and heights by 2,
        'the form is exactly in the screen's centre as it loads. Using variables lets us use this code irrespective of 
        'different widths and heights of different forms. 



        GetFiles()

        Me.Text = FormTitle & ": SPLASH SCREEN"     'Name of the form to make it my solution look more bespoke.

        pic_chcsLogo.ImageLocation = MyImages & "chcsLogo.png"
        pbx_Close.ImageLocation = MyImages & "close1.png"
        pbx_GoToLogin.ImageLocation = MyImages & "begin1.png"

        'Loads images which are saved in the 'images' folder into each PicBox


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

        'Entire solution closes. 

    End Sub

    Private Sub pbx_GoToLogin_Click(sender As Object, e As EventArgs) Handles pbx_GoToLogin.Click

        Me.Visible = False
        Login.Visible = True

        'When this button is pressed, splash screen is hidden and the login screen is revealed. 

    End Sub

    Private Sub pbx_GoToLogin_MouseEnter(sender As Object, e As EventArgs) Handles pbx_GoToLogin.MouseEnter

        pbx_GoToLogin.ImageLocation = MyImages & "begin2.png"

        'When the mouse hovers over the button, the second part of the rollover image is shown

    End Sub

    Private Sub pbx_GoToLogin_MouseLeave(sender As Object, e As EventArgs) Handles pbx_GoToLogin.MouseLeave

        pbx_GoToLogin.ImageLocation = MyImages & "begin1.png"
        'When the mouse leaves the PicBox after hovering over it, we return to the first half
        'of the rollover image

    End Sub
End Class