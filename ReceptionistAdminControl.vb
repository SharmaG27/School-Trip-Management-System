Imports System.IO

Public Class ReceptionistAdminControl
    Private Sub ReceptionistAdminControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ApplyBgTheme()

        GetFiles()


        'Allow background colour changing and extracting text file data to happen in this form

        CentreForm(Me)


        '2 variables are set as the form's width and form's height respectively. (screenwidth, screenheight)
        'the other 2 variables take the form's boundaries away from the screen's boundaries which gives us the 
        'position of the form on our screen when it loads. Since we divided both sides' widths and heights by 2,
        'the form is exactly in the screen's centre as it loads. Using variables lets us use this code irrespective of 
        'different widths and heights of different forms.



        Me.Text = FormTitle & ": RECEPTIONIST ADMINISTRATION CONTROL"   'Rename the form.


        pbx_Close.ImageLocation = MyImages & "close1.png"
        pbx_MainMenu.ImageLocation = MyImages & "MainMenu1.png"
        pbx_ReceptionistDetails.ImageLocation = MyImages & "ReceptionistDetails1.png"
        pbx_ManageTrips.ImageLocation = MyImages & "ManageTrips1.png"
        pic_Help.ImageLocation = MyImages & "help.png"
        pic_blue.ImageLocation = MyImages & "blue.png"

        'Loads images which are saved in the 'images' folder into each PicBox



        If LoginAccessLevel_Global = 0 AndAlso LoginID_Global = "7" Then

            lbl_UserName.Text = "Welcome Admin"
            lbl_UserID.Text = "User ID: 7"
            lbl_UserAccessLevel.Text = "Access Level: 0 (Administrator)"

            'There is only one user with access level 0 (admin) so no need to set up separate variables in this case


        Else

            Dim LoggedInUserFullName As String = ""
            Dim LoggedInUserID As String = ""
            Dim LoggedInUserAccessLevel As String = ""

            Dim FileToSearch As String = ""

            Select Case LoginAccessLevel_Global

                Case 0
                    FileToSearch = Receptionists_File
                Case 1
                    FileToSearch = Receptionists_File
                Case 2
                    FileToSearch = Teachers_File
                Case 3
                    FileToSearch = Students_File
            End Select

            'uses access level of logged in user to search the correct files for logged in user's data



            Dim SelectedFile_sr As New StreamReader(FileToSearch)

            Dim OneRecord As String
            Dim Fields() As String


            While SelectedFile_sr.Peek() >= 0

                OneRecord = SelectedFile_sr.ReadLine()
                OneRecord = XORencrypt(OneRecord)

                Fields = OneRecord.Split(",")


                If LoginID_Global = Fields(0) AndAlso LoginAccessLevel_Global = Fields(9) Then

                    LoggedInUserFullName = Fields(2) & " " & Fields(1)
                    LoggedInUserID = Fields(0)
                    LoggedInUserAccessLevel = Fields(9)
                    Exit While

                End If

            End While

            SelectedFile_sr.Close()

            'go though each record, splitting up each record into its fields.
            'if a match on ID and access level is found, we extract the user's name, ID and access level
            'to display

            Dim AccessLevelString As String

            If LoggedInUserAccessLevel = "1" Then

                AccessLevelString = "Receptionist"

            ElseIf LoggedInUserAccessLevel = "2" Then

                AccessLevelString = "Teacher (Supervisor)"

            ElseIf LoggedInUserAccessLevel = "3" Then

                AccessLevelString = "Student"

            End If

            'Display the text data so the user knows they are logged into their own account



            lbl_UserName.Text = "Welcome " & LoggedInUserFullName
            lbl_UserID.Text = "User ID: " & LoggedInUserID
            lbl_UserAccessLevel.Text = "Access Level: " & LoggedInUserAccessLevel


        End If



        lbl_UserName.BackColor = Color.FromArgb(255, 52, 102, 175)
        lbl_UserID.BackColor = Color.FromArgb(255, 52, 102, 175)
        lbl_UserAccessLevel.BackColor = Color.FromArgb(255, 52, 102, 175)

        lbl_ReceptionistInfoTitle.BackColor = Color.FromArgb(255, 52, 102, 175)


        'Change the labels' BG colout to match the blue bg to make it look transparent


        With rtxt_ReceptionistUpdates
            .ReadOnly = True
            .BorderStyle = BorderStyle.FixedSingle
            .BackColor = Color.WhiteSmoke
            .ForeColor = Color.DimGray
            .Font = New Font("Segoe UI", 10, FontStyle.Italic)
            .Cursor = Cursors.Default
            .TabStop = False
            .ScrollBars = RichTextBoxScrollBars.None
            .DetectUrls = False
        End With

        'Formatting for the Rich TextBox. Difficult to format through the Design section in VB.


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

        'COmpletely closes the application


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

        'Hide receptionist admin control form and reveal the main menu

    End Sub

    Private Sub pbx_ReceptionistDetails_MouseEnter(sender As Object, e As EventArgs) Handles pbx_ReceptionistDetails.MouseEnter

        pbx_ReceptionistDetails.ImageLocation = MyImages & "ReceptionistDetails2.png"

        'When the mouse hovers over the button, the second part of the rollover image is shown


    End Sub

    Private Sub pbx_ReceptionistDetails_MouseLeave(sender As Object, e As EventArgs) Handles pbx_ReceptionistDetails.MouseLeave

        pbx_ReceptionistDetails.ImageLocation = MyImages & "ReceptionistDetails1.png"

        'When the mouse leaves the PicBox after hovering over it, we return to the first half
        'of the rollover image

    End Sub

    Private Sub pbx_ReceptionistDetails_Click(sender As Object, e As EventArgs) Handles pbx_ReceptionistDetails.Click

        Me.Visible = False
        ReceptionistDetails.Visible = True

        'Hides this form, reveals receptionist details form


    End Sub

    Private Sub pbx_ManageTrips_MouseEnter(sender As Object, e As EventArgs) Handles pbx_ManageTrips.MouseEnter

        pbx_ManageTrips.ImageLocation = MyImages & "ManageTrips2.png"

        'When the mouse hovers over the button, the second part of the rollover image is shown


    End Sub

    Private Sub pbx_ManageTrips_MouseLeave(sender As Object, e As EventArgs) Handles pbx_ManageTrips.MouseLeave

        pbx_ManageTrips.ImageLocation = MyImages & "ManageTrips1.png"

        'When the mouse leaves the PicBox after hovering over it, we return to the first half
        'of the rollover image


    End Sub

    Private Sub pbx_ManageTrips_Click(sender As Object, e As EventArgs) Handles pbx_ManageTrips.Click

        Me.Visible = False
        Manage_Trips.Visible = True

        'Hide receptionist admin control form and reveal the form which allows to manage school trips

    End Sub


    Private Sub pic_Help_MouseLeave(sender As Object, e As EventArgs) Handles pic_Help.MouseLeave
        Help.Visible = False


        'If mouse hovers over then leaves the icon, Help form is hidden.

    End Sub


    Private Sub pic_Help_MouseHover(sender As Object, e As EventArgs) Handles pic_Help.MouseHover
        Help.Visible = True
        Help.lbl_helpHeadingEng.Text = "Receptionist Administration Control"
        Help.rtxt_helpInfoEng.Text = "Using this form, you can access receptionist-only controls. The Manage Trips button takes you to the trip management section where you can create/edit trips."

        Help.lbl_helpHeadingWel.Text = "Rheolaeth Weinyddol Derbynnydd"
        Help.rtxt_helpInfoWel.Text = "Gan ddefnyddio'r ffurflen hon, gallwch gael mynediad at reolaethau derbynnydd yn unig. Mae'r botwm Rheoli Teithiau yn mynd â chi i'r adran rheoli teithiau lle gallwch greu/golygu teithiau."



        'when this specific icon is hovered over, Help form is revealed and text is altered as above to match this situation. 

    End Sub


End Class