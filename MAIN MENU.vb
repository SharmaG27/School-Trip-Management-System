Imports System.IO

Public Class MAIN_MENU
    Private Sub MAIN_MENU_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ApplyBgTheme()      'execute this function as this form loads. This is code din the global module. 

        CentreForm(Me)


        '2 variables are set as the form's width and form's height respectively. (screenwidth, screenheight)
        'the other 2 variables take the form's boundaries away from the screen's boundaries which gives us the 
        'position of the form on our screen when it loads. Since we divided both sides' widths and heights by 2,
        'the form is exactly in the screen's centre as it loads. Using variables lets us use this code irrespective of 
        'different widths and heights of different forms.


        GetFiles()      'Allow this form to access any and all text files when needed. 

        Me.Text = FormTitle & ": MAIN MENU"     'Rename the form.


        If LoginAccessLevel_Global = 0 AndAlso LoginID_Global = "7" Then

            lbl_UserName.Text = "Welcome Admin"
            lbl_UserID.Text = "User ID: 7"
            lbl_UserAccessLevel.Text = "Access Level: 0 (Administrator)"

            'There is only one user with access level 0 (admin) so no need to set up separate variables in this case
            'Nobody can delete the Admin record so this is safe.

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



            Dim FileSearch_sr As New StreamReader(FileToSearch)

            Dim OneRecord As String
            Dim Fields() As String


            While FileSearch_sr.Peek() >= 0

                OneRecord = FileSearch_sr.ReadLine()
                OneRecord = XORencrypt(OneRecord)

                Fields = OneRecord.Split(",")



                If LoginID_Global = Fields(0) AndAlso LoginAccessLevel_Global = CInt(Fields(9)) Then

                    LoggedInUserFullName = Fields(2) & " " & Fields(1)
                    LoggedInUserID = Fields(0)
                    LoggedInUserAccessLevel = Fields(9)

                    Exit While

                End If

            End While

            FileSearch_sr.Close()


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


            lbl_UserName.Text = "Welcome " & LoggedInUserFullName
            lbl_UserID.Text = "User ID: " & LoggedInUserID
            lbl_UserAccessLevel.Text = "Access Level: " & LoggedInUserAccessLevel


            'Display the text data so the user knows they are logged into their own account


        End If


        pbx_Close.ImageLocation = MyImages & "close1.png"
        pbx_logOut.ImageLocation = MyImages & "logout1.png"
        pbx_settings.ImageLocation = MyImages & "settings1.png"
        pbx_ReceptionistAdminControl.ImageLocation = MyImages & "ReceptionistAdminControl1.png"
        pbx_TripInfo.ImageLocation = MyImages & "TripInfo1.png"
        pbx_TeacherDetails.ImageLocation = MyImages & "TeacherDetails1.png"
        pbx_StudentDetails.ImageLocation = MyImages & "StudentDetails1.png"
        pbx_Medical.ImageLocation = MyImages & "Medical1.png"
        pbx_EmergencyContact.ImageLocation = MyImages & "EmergencyContact1.png"
        pbx_EditStudentDetails.ImageLocation = MyImages & "EditStudentDetails1.png"
        pbx_SignupToTrip.ImageLocation = MyImages & "SignupToTrip1.png"


        pic_MainMenuHelp.ImageLocation = MyImages & "help.png"
        pic_chcsLogo.ImageLocation = MyImages & "chcsLogo.png"
        pic_blue.ImageLocation = MyImages & "blue.png"
        pic_blue2.ImageLocation = MyImages & "blue.png"

        'Loads images which are saved in the 'images' folder into each PicBox


        lbl_date.Text = Now.Date
        lbl_date.BackColor = Color.FromArgb(255, 52, 102, 175)



        lbl_UserName.BackColor = Color.FromArgb(255, 52, 102, 175)
        lbl_UserID.BackColor = Color.FromArgb(255, 52, 102, 175)
        lbl_UserAccessLevel.BackColor = Color.FromArgb(255, 52, 102, 175)

        'Change the labels' BG colout to match the blue bg to make it look transparent



        AccessLevelHideButtons()

    End Sub


    Private Sub AccessLevelHideButtons()

        'This sub hides and reveals buttons based on the user's access level.
        'Using case statements, I can write different code for each access level.

        Select Case LoginAccessLevel_Global

            Case 0

                pbx_SignupToTrip.Enabled = False
                pbx_SignupToTrip.ImageLocation = MyImages & "SignUpGrey.png"

                pbx_EditStudentDetails.Enabled = False
                pbx_EditStudentDetails.ImageLocation = MyImages & "EditDetailsGrey.png"


            Case 1
                pbx_SignupToTrip.Enabled = False
                pbx_SignupToTrip.ImageLocation = MyImages & "SignUpGrey.png"

                pbx_EditStudentDetails.Enabled = False
                pbx_EditStudentDetails.ImageLocation = MyImages & "EditDetailsGrey.png"


            Case 2
                pbx_SignupToTrip.Enabled = False
                pbx_SignupToTrip.ImageLocation = MyImages & "SignUpGrey.png"


                pbx_EditStudentDetails.Enabled = False
                pbx_EditStudentDetails.ImageLocation = MyImages & "EditDetailsGrey.png"


                pbx_ReceptionistAdminControl.Enabled = False
                pbx_ReceptionistAdminControl.ImageLocation = MyImages & "RecAdminGrey.png"

            Case 3
                pbx_ReceptionistAdminControl.Enabled = False
                pbx_ReceptionistAdminControl.ImageLocation = MyImages & "RecAdminGrey.png"

                pbx_TeacherDetails.Enabled = False
                pbx_TeacherDetails.ImageLocation = MyImages & "TeacherDetailsGrey.png"

                pbx_StudentDetails.Enabled = False
                pbx_StudentDetails.ImageLocation = MyImages & "StuDetailsGrey.png"

                pbx_EmergencyContact.Enabled = False
                pbx_EmergencyContact.ImageLocation = MyImages & "EmInfoGrey.png"

                pbx_Medical.Enabled = False
                pbx_Medical.ImageLocation = MyImages & "MedInfoGrey.png"


        End Select

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

        'The solution is completely closed. 

    End Sub

    Private Sub pbx_logOut_MouseEnter(sender As Object, e As EventArgs) Handles pbx_logOut.MouseEnter

        pbx_logOut.ImageLocation = MyImages & "logout2.png"

        'When the mouse hovers over the button, the second part of the rollover image is shown

    End Sub

    Private Sub pbx_logOut_MouseLeave(sender As Object, e As EventArgs) Handles pbx_logOut.MouseLeave

        pbx_logOut.ImageLocation = MyImages & "logout1.png"

        'When the mouse leaves the PicBox after hovering over it, we return to the first half
        'of the rollover image
    End Sub

    Private Sub pbx_logOut_Click(sender As Object, e As EventArgs) Handles pbx_logOut.Click


        If ConfirmActions = True Then

            If MsgBox("Are you sure you want to log out of the system?",
                  MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation,
                  "Confirm Action") = MsgBoxResult.No Then

                Exit Sub

            End If

        End If


        LoginID_Global = ""
        LoginAccessLevel_Global = ""

        Me.Visible = False
        Login.Visible = True



    End Sub

    Private Sub pbx_settings_MouseEnter(sender As Object, e As EventArgs) Handles pbx_settings.MouseEnter

        pbx_settings.ImageLocation = MyImages & "settings2.png"
        'When the mouse hovers over the button, the second part of the rollover image is shown


    End Sub

    Private Sub pbx_settings_MouseLeave(sender As Object, e As EventArgs) Handles pbx_settings.MouseLeave

        pbx_settings.ImageLocation = MyImages & "settings1.png"
        'When the mouse leaves the PicBox after hovering over it, we return to the first half
        'of the rollover image

    End Sub

    Private Sub pbx_settings_Click(sender As Object, e As EventArgs) Handles pbx_settings.Click

        Me.Visible = False
        Settings.Visible = True


        'Main menu is hidden and the settings menu is revealed. 

    End Sub

    Private Sub pbx_ReceptionistAdminControl_MouseEnter(sender As Object, e As EventArgs) Handles pbx_ReceptionistAdminControl.MouseEnter

        pbx_ReceptionistAdminControl.ImageLocation = MyImages & "ReceptionistAdminControl2.png"
        'When the mouse hovers over the button, the second part of the rollover image is shown


    End Sub

    Private Sub pbx_ReceptionistAdminControl_MouseLeave(sender As Object, e As EventArgs) Handles pbx_ReceptionistAdminControl.MouseLeave

        pbx_ReceptionistAdminControl.ImageLocation = MyImages & "ReceptionistAdminControl1.png"
        'When the mouse leaves the PicBox after hovering over it, we return to the first half
        'of the rollover image

    End Sub

    Private Sub pbx_ReceptionistAdminControl_Click(sender As Object, e As EventArgs) Handles pbx_ReceptionistAdminControl.Click

        Me.Visible = False
        ReceptionistAdminControl.Visible = True

        'Main Menu gets hidden and the Receptionist Admin Control form is revealed to the user. 

    End Sub

    Private Sub pbx_TripInfo_MouseEnter(sender As Object, e As EventArgs) Handles pbx_TripInfo.MouseEnter

        pbx_TripInfo.ImageLocation = MyImages & "TripInfo2.png"

        'When the mouse hovers over the button, the second part of the rollover image is shown

    End Sub

    Private Sub pbx_TripInfo_MouseLeave(sender As Object, e As EventArgs) Handles pbx_TripInfo.MouseLeave

        pbx_TripInfo.ImageLocation = MyImages & "TripInfo1.png"

        'When the mouse leaves the PicBox after hovering over it, we return to the first half
        'of the rollover image
    End Sub

    Private Sub pbx_TripInfo_Click(sender As Object, e As EventArgs) Handles pbx_TripInfo.Click

        Me.Visible = False
        TripInformation.Visible = True

        'Main menu is hidden and the Trip information timetable/calendar is revealed. 


    End Sub

    Private Sub pbx_TeacherDetails_MouseEnter(sender As Object, e As EventArgs) Handles pbx_TeacherDetails.MouseEnter

        pbx_TeacherDetails.ImageLocation = MyImages & "TeacherDetails2.png"
        'When the mouse hovers over the button, the second part of the rollover image is shown


    End Sub

    Private Sub pbx_TeacherDetails_MouseLeave(sender As Object, e As EventArgs) Handles pbx_TeacherDetails.MouseLeave

        pbx_TeacherDetails.ImageLocation = MyImages & "TeacherDetails1.png"

        'When the mouse leaves the PicBox after hovering over it, we return to the first half
        'of the rollover image
    End Sub

    Private Sub pbx_TeacherDetails_Click(sender As Object, e As EventArgs) Handles pbx_TeacherDetails.Click

        Me.Visible = False
        TeacherDetails.Visible = True

        'Main menu is hidden and the Teacher details form is revealed. 

    End Sub

    Private Sub pbx_StudentDetails_MouseEnter(sender As Object, e As EventArgs) Handles pbx_StudentDetails.MouseEnter

        pbx_StudentDetails.ImageLocation = MyImages & "StudentDetails2.png"

        'When the mouse hovers over the button, the second part of the rollover image is shown


    End Sub

    Private Sub pbx_StudentDetails_MouseLeave(sender As Object, e As EventArgs) Handles pbx_StudentDetails.MouseLeave

        pbx_StudentDetails.ImageLocation = MyImages & "StudentDetails1.png"
        'When the mouse leaves the PicBox after hovering over it, we return to the first half
        'of the rollover image

    End Sub

    Private Sub pbx_StudentDetails_Click(sender As Object, e As EventArgs) Handles pbx_StudentDetails.Click

        Me.Visible = False
        StudentDetails.Visible = True

        'Main menu is hidden and the Stduent details form is revealed. 

    End Sub

    Private Sub pbx_Medical_MouseEnter(sender As Object, e As EventArgs) Handles pbx_Medical.MouseEnter

        pbx_Medical.ImageLocation = MyImages & "Medical2.png"

        'When the mouse hovers over the button, the second part of the rollover image is shown

    End Sub

    Private Sub pbx_Medical_MouseLeave(sender As Object, e As EventArgs) Handles pbx_Medical.MouseLeave

        pbx_Medical.ImageLocation = MyImages & "Medical1.png"

        'When the mouse leaves the PicBox after hovering over it, we return to the first half
        'of the rollover image
    End Sub

    Private Sub pbx_Medical_Click(sender As Object, e As EventArgs) Handles pbx_Medical.Click

        Me.Visible = False
        Medical_Info.Visible = True

        'Main menu is hidden and the Student medical details form is revealed. 

    End Sub

    Private Sub pbx_EmergencyContact_MouseEnter(sender As Object, e As EventArgs) Handles pbx_EmergencyContact.MouseEnter

        pbx_EmergencyContact.ImageLocation = MyImages & "EmergencyContact2.png"

        'When the mouse hovers over the button, the second part of the rollover image is shown

    End Sub

    Private Sub pbx_EmergencyContact_MouseLeave(sender As Object, e As EventArgs) Handles pbx_EmergencyContact.MouseLeave

        pbx_EmergencyContact.ImageLocation = MyImages & "EmergencyContact1.png"
        'When the mouse leaves the PicBox after hovering over it, we return to the first half
        'of the rollover image

    End Sub

    Private Sub pbx_EmergencyContact_Click(sender As Object, e As EventArgs) Handles pbx_EmergencyContact.Click

        Me.Visible = False
        Emergency_Contacts.Visible = True

        'Main menu is hidden and the student emergency contact form is revealed. 

    End Sub

    Private Sub pbx_EditStudentDetails_MouseEnter(sender As Object, e As EventArgs) Handles pbx_EditStudentDetails.MouseEnter

        pbx_EditStudentDetails.ImageLocation = MyImages & "EditStudentDetails2.png"

        'When the mouse hovers over the button, the second part of the rollover image is shown

    End Sub

    Private Sub pbx_EditStudentDetails_MouseLeave(sender As Object, e As EventArgs) Handles pbx_EditStudentDetails.MouseLeave

        pbx_EditStudentDetails.ImageLocation = MyImages & "EditStudentDetails1.png"

        'When the mouse leaves the PicBox after hovering over it, we return to the first half
        'of the rollover image
    End Sub

    Private Sub pbx_EditStudentDetails_Click(sender As Object, e As EventArgs) Handles pbx_EditStudentDetails.Click

        Me.Visible = False
        Edit_My_Details.Visible = True


        'Main menu is hidden and the student details form is revealed. 

    End Sub

    Private Sub pbx_SignupToTrip_MouseEnter(sender As Object, e As EventArgs) Handles pbx_SignupToTrip.MouseEnter

        pbx_SignupToTrip.ImageLocation = MyImages & "SignupToTrip2.png"

        'When the mouse hovers over the button, the second part of the rollover image is shown

    End Sub

    Private Sub pbx_SignupToTrip_MouseLeave(sender As Object, e As EventArgs) Handles pbx_SignupToTrip.MouseLeave

        pbx_SignupToTrip.ImageLocation = MyImages & "SignupToTrip1.png"

        'When the mouse leaves the PicBox after hovering over it, we return to the first half
        'of the rollover image
    End Sub

    Private Sub pbx_SignupToTrip_Click(sender As Object, e As EventArgs) Handles pbx_SignupToTrip.Click

        Me.Visible = False
        TripSignup.Visible = True

        'Main menu is hidden and the form which allows students to sign up to trips is revealed. 

    End Sub



    Private Sub pic_MainMenuHelp_MouseHover(sender As Object, e As EventArgs) Handles pic_MainMenuHelp.MouseHover
        Help.Visible = True
        Help.lbl_helpHeadingEng.Text = "Main Menu"
        Help.rtxt_helpInfoEng.Text = "From this form, you can access the different areas of this software. Click the buttons below to navigate as you please."

        Help.lbl_helpHeadingWel.Text = "Prif Ddewislen"
        Help.rtxt_helpInfoWel.Text = "O'r ffurflen hon, gallwch gael mynediad at wahanol feysydd y feddalwedd hon. Cliciwch y botymau isod i lywio fel y mynnwch."



        'when this specific icon is hovered over, Help form is revealed and text is altered as above to match this situation. 

    End Sub

    Private Sub pic_MainMenuHelp_MouseLeave(sender As Object, e As EventArgs) Handles pic_MainMenuHelp.MouseLeave
        Help.Visible = False


        'If mouse hovers over then leaves the icon, Help form is hidden.

    End Sub



End Class