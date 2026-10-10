Imports System.IO
Imports Microsoft.VisualBasic.ApplicationServices


Public Class Edit_My_Details



    'Makes sure that a name is not empty or contains letters only (no numbers or symbols)

    Private Function IsNotEmpty(value As String) As Boolean

        Return value.Trim() <> ""

    End Function

    'Makes sure that a name is not empty or contains letters only (no numbers or symbols)

    Private Function IsValidName(value As String) As Boolean

        If value = "" Then Return False


        For Each CharInName As Char In value


            If Not Char.IsLetter(CharInName) Then

                Return False

            End If

        Next

        Return True

    End Function



    'Validates a house number:
    'must not be empty
    'must start with a digit
    'can only contain letters and digits (e.g. 12A)
    Private Function IsValidHouseNumber(value As String) As Boolean

        value = value.Trim().ToUpper()

        If value = "" Then Return False
        If Not Char.IsDigit(value(0)) Then Return False

        For Each HouseNumDigit As Char In value

            If Not (Char.IsDigit(HouseNumDigit) OrElse Char.IsLetter(HouseNumDigit)) Then

                Return False

            End If

        Next

        Return True

    End Function


    'Validates postcode via a kind of format check:
    'must contain exactly one space
    'first part length between 2 and 4
    'second part must be exactly 3 characters
    Private Function IsValidPostcode(value As String) As Boolean

        value = value.Trim().ToUpper()

        If Not value.Contains(" ") Then Return False

        Dim PostCodeParts() As String = value.Split(" "c)
        If PostCodeParts.Length <> 2 Then Return False

        If PostCodeParts(0).Length < 2 OrElse PostCodeParts(0).Length > 4 Then Return False
        If PostCodeParts(1).Length <> 3 Then Return False

        Return True

    End Function


    'Validates an email address, it:
    'must NOT be empty
    'must contain @ and .
    'must NOT start or end with @
    Private Function IsValidEmail(value As String) As Boolean

        value = value.Trim()

        If value = "" Then Return False
        If Not value.Contains("@") Then Return False
        If Not value.Contains(".") Then Return False
        If value.StartsWith("@") OrElse value.EndsWith("@") Then Return False

        Return True

    End Function


    'Validates a UK phone number:
    'removes spaces
    'must be exactly 11 digits
    'must start with 01 or 07. prevents usage of +44
    'must contain digits only
    Private Function IsValidPhone(value As String) As Boolean

        value = value.Replace(" ", "")

        If value.Length <> 11 Then Return False
        If Not (value.StartsWith("07") OrElse value.StartsWith("01")) Then Return False

        For Each PhoneDigit As Char In value

            If Not Char.IsDigit(PhoneDigit) Then Return False

        Next

        Return True

    End Function



    Private Function ValidateForm() As Boolean

        'Runs all validation checks for the form
        'Returns True only if ALL fields are valid

        If Not IsValidName(txt_surname.Text) Then

            MessageBox.Show("Invalid surname")
            Return False

        End If

        If Not IsValidName(txt_name.Text) Then

            MessageBox.Show("Invalid first name")
            Return False

        End If

        If Not IsNotEmpty(txt_title.Text) Then

            MessageBox.Show("Title cannot be empty")
            Return False

        End If

        If Not IsValidHouseNumber(txt_houseNum.Text) Then

            MessageBox.Show("Invalid house number")
            Return False

        End If

        If Not IsValidPostcode(txt_postCode.Text) Then

            MessageBox.Show("Invalid postcode")
            Return False

        End If

        If Not IsValidEmail(txt_email.Text) Then

            MessageBox.Show("Invalid email address")
            Return False

        End If


        If Not IsValidPhone(txt_contactNum.Text) Then

            MessageBox.Show("Invalid contact number")
            Return False

        End If

        If dtp_dob.Value > Today Then

            MessageBox.Show("Date of birth cannot be in the future")
            Return False

        End If



        If txt_usernmae.Visible AndAlso Not IsNotEmpty(txt_usernmae.Text) Then

            MessageBox.Show("Username cannot be empty")
            Return False

        End If

        If txt_password.Visible AndAlso Not IsNotEmpty(txt_password.Text) Then

            MessageBox.Show("Password cannot be empty")
            Return False

        End If



        Return True

    End Function



    Private Sub Edit_My_Details_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        GetFiles()

        ApplyBgTheme()
        'Allow background colour changing and extracting text file data to happen in this form


        FillTextBoxes()
        'Fill the teacher data grid and fill textboxes with relevant teacher data to allow it do be modified




        CentreForm(Me)



        '2 variables are set as the form's width and form's height respectively. (screenwidth, screenheight)
        'the other 2 variables take the form's boundaries away from the screen's boundaries which gives us the 
        'position of the form on our screen when it loads. Since we divided both sides' widths and heights by 2,
        'the form is exactly in the screen's centre as it loads. Using variables lets us use this code irrespective of 
        'different widths and heights of different forms.

        Me.Text = FormTitle & ": STUDENT - VIEW MY DETAILS"


        pbx_saveDetails.ImageLocation = MyImages & "SaveMy1.png"
        pbx_close.ImageLocation = MyImages & "close1.png"
        pbx_back.ImageLocation = MyImages & "MainMenu1.png"


        pic_Help.ImageLocation = MyImages & "help.png"

        pic_chcsLogo.ImageLocation = MyImages & "chcsLogo.png"
        pic_blue.ImageLocation = MyImages & "blue.png"
        pic_blueToCoverLogoWhiteSpace.ImageLocation = MyImages & "blue.png"

        'Loads images which are saved in the 'images' folder into each PicBox


        With rtxt_TripBulletin
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



        lbl_TripBulletinLabel.BackColor = Color.FromArgb(255, 52, 102, 175)

        'Change the labels' BG colout to match the blue bg to make it look transparent


    End Sub




    Private Sub FillTextBoxes()

        Dim Student_sr As New StreamReader(Students_File)


        Dim OneRecord As String
        Dim Fields() As String
        Dim StudentRecordFound As Boolean = False

        While Student_sr.Peek() >= 0



            OneRecord = Student_sr.ReadLine()
            OneRecord = XORencrypt(OneRecord)

            Dim TempFieldsFromStudentFile() As String = OneRecord.Split(",")

            'Using a StreamReader, we read all lines (records) inside Students File and decrypt each line
            'and this decrypted line gets split using the comma terminators. Each splitted data is inserted into a slot 
            'within the Fields() dynamic array and this data is added to each row of the datagrid. This is repeated 
            'all the way to the last line of the txt file. 



            If LoginID_Global = TempFieldsFromStudentFile(0) AndAlso LoginAccessLevel_Global = TempFieldsFromStudentFile(9) Then


                Fields = TempFieldsFromStudentFile
                StudentRecordFound = True

                Exit While

            End If

            'If a match is found using STudent ID and Access Level (of 3), then this student's details are shown.



        End While

        Student_sr.Close()


        If StudentRecordFound = False Then


            MsgBox("Student record not found.")


            Exit Sub


        End If




        ' Populate textboxes ONLY if record found
        txt_StudentID.Text = Fields(0)
        txt_surname.Text = Fields(1)
        txt_name.Text = Fields(2)
        txt_title.Text = Fields(3)
        txt_houseNum.Text = Fields(4)
        txt_postCode.Text = Fields(5)
        txt_email.Text = Fields(6)
        txt_contactNum.Text = Fields(7)
        dtp_dob.Value = CDate(Fields(8))
        txt_accessLevel.Text = Fields(9)
        txt_usernmae.Text = Fields(10)
        txt_password.Text = Fields(11)
        txt_EmergencyID.Text = Fields(12)
        txt_MedicalID.Text = Fields(13)

    End Sub




    Private Sub pbx_saveDetails_MouseEnter(sender As Object, e As EventArgs) Handles pbx_saveDetails.MouseEnter

        pbx_saveDetails.ImageLocation = MyImages & "SaveMy2.png"

        'When the mouse hovers over the button, the second part of the rollover image is shown

    End Sub

    Private Sub pbx_saveDetails_MouseLeave(sender As Object, e As EventArgs) Handles pbx_saveDetails.MouseLeave

        pbx_saveDetails.ImageLocation = MyImages & "SaveMy1.png"

        'When the mouse leaves the PicBox after hovering over it, we return to the first half
        'of the rollover image

    End Sub

    Private Sub pbx_saveDetails_Click(sender As Object, e As EventArgs) Handles pbx_saveDetails.Click

        If Not ValidateForm() Then Exit Sub
        'If a SINGLE validation check fails, this procedure doesn't run and a relevant error message appears. 


        If ConfirmActions = True Then

            If MsgBox("Are you sure you want to save your details?",
                  MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation,
                  "Confirm Save") = MsgBoxResult.No Then

                Exit Sub

            End If

        End If


        'If confirmation setting is enabled, ask the user to confirm before saving their details.


        Dim OneStudentRecord As String
        Dim AllStudentRecords As New List(Of String)
        Dim StudentUpdated As Boolean = False

        'variables made after confirmation message because if confirmation is flase, variables would be useless

        OneStudentRecord = txt_StudentID.Text & ","
        OneStudentRecord = OneStudentRecord & txt_surname.Text & ","
        OneStudentRecord = OneStudentRecord & txt_name.Text & ","
        OneStudentRecord = OneStudentRecord & txt_title.Text & ","
        OneStudentRecord = OneStudentRecord & txt_houseNum.Text & ","
        OneStudentRecord = OneStudentRecord & txt_postCode.Text & ","
        OneStudentRecord = OneStudentRecord & txt_email.Text & ","
        OneStudentRecord = OneStudentRecord & txt_contactNum.Text & ","
        OneStudentRecord = OneStudentRecord & dtp_dob.Value & ","

        OneStudentRecord = OneStudentRecord & txt_accessLevel.Text & ","

        OneStudentRecord = OneStudentRecord & LCase(txt_usernmae.Text) & ","
        OneStudentRecord = OneStudentRecord & txt_password.Text & ","

        OneStudentRecord = OneStudentRecord & txt_EmergencyID.Text & ","
        OneStudentRecord = OneStudentRecord & txt_MedicalID.Text

        'Fill OneStudentRecord with all data inputted into textboxes in the same order separated by commas
        'and encrypt this and write it into the text file. Close the StreamReader to avoid problems like corruption. 


        OneStudentRecord = XORencrypt(OneStudentRecord)
        'Encrypt the full record before storing it in memory.



        Dim NewStudent_sr As New StreamReader(Students_File)

        While NewStudent_sr.Peek() >= 0


            Dim DesiredRecord As String = NewStudent_sr.ReadLine()

            Dim DecryptedDesiredRecord As String = XORencrypt(DesiredRecord)
            Dim Fields() As String = DecryptedDesiredRecord.Split(",")

            ' If this is the logged-in student's record → replace it
            If Fields(0) = LoginID_Global AndAlso Fields(9) = LoginAccessLevel_Global Then

                AllStudentRecords.Add(OneStudentRecord)
                StudentUpdated = True

            Else

                ' Otherwise keep the record unchanged
                AllStudentRecords.Add(DesiredRecord)

            End If


        End While

        NewStudent_sr.Close()

        'Open the Students file and loop through every record.
        'If the logged-in student is found replace their record.
        'Otherwise keep the existing record unchanged.



        If StudentUpdated = False Then

            MsgBox("Your details could not be saved.")
            Exit Sub


        End If


        'If no matching student was found display error and stop sub.

        File.WriteAllLines(Students_File, AllStudentRecords)




        Dim AllLoginRecords As New List(Of String)

        Dim StudentLoginUpdated As Boolean = False

        Dim Login_sr As New StreamReader(UserLogin_File)

        While Login_sr.Peek() >= 0

            Dim LoginLine As String = Login_sr.ReadLine()
            Dim DecryptedLogin As String = XORencrypt(LoginLine)
            Dim LoginFields() As String = DecryptedLogin.Split(",")

            ' Match the currently logged-in user
            If LoginFields(0) = LoginAccessLevel_Global AndAlso LoginFields(1) = LoginID_Global Then

                Dim NewLoginRecord As String = LoginFields(0) & "," & LoginFields(1) & "," & LCase(txt_usernmae.Text) & "," & txt_password.Text


                AllLoginRecords.Add(XORencrypt(NewLoginRecord))
                StudentLoginUpdated = True

            Else

                AllLoginRecords.Add(LoginLine)


            End If

        End While



        Login_sr.Close()

        'Now update username/password in the login file.
        'Same logic: read all records, replace the correct one.


        If StudentLoginUpdated Then

            File.WriteAllLines(UserLogin_File, AllLoginRecords)

        Else

            MsgBox("Warning: login details were not updated.")

        End If

        'Only overwrite login file if record was successfully updated




        MsgBox("Details have been saved.")


    End Sub


    Private Sub pbx_close_Click(sender As Object, e As EventArgs) Handles pbx_close.Click

        If ConfirmActions = True Then

            If MsgBox("Are you sure you want to close the system?",
                  MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation,
                  "Confirm Action") = MsgBoxResult.No Then

                Exit Sub

            End If

        End If

        Application.Exit()

        'completely closes the program


    End Sub


    Private Sub pbx_close_MouseEnter(sender As Object, e As EventArgs) Handles pbx_close.MouseEnter

        pbx_close.ImageLocation = MyImages & "close2.png"

        'When the mouse hovers over the button, the second part of the rollover image is shown

    End Sub


    Private Sub pbx_close_MouseLeave(sender As Object, e As EventArgs) Handles pbx_close.MouseLeave

        pbx_close.ImageLocation = MyImages & "close1.png"

        'When the mouse leaves the PicBox after hovering over it, we return to the first half
        'of the rollover image

    End Sub


    Private Sub pbx_back_MouseEnter(sender As Object, e As EventArgs) Handles pbx_back.MouseEnter

        pbx_back.ImageLocation = MyImages & "MainMenu2.png"

        'When the mouse hovers over the button, the second part of the rollover image is shown

    End Sub


    Private Sub pbx_back_MouseLeave(sender As Object, e As EventArgs) Handles pbx_back.MouseLeave

        pbx_back.ImageLocation = MyImages & "MainMenu1.png"

        'When the mouse leaves the PicBox after hovering over it, we return to the first half
        'of the rollover image

    End Sub


    Private Sub pbx_back_Click(sender As Object, e As EventArgs) Handles pbx_back.Click

        Me.Visible = False
        MAIN_MENU.Visible = True

        'Hides this form and reveals the Main Menu.
    End Sub



    Private Sub pic_Help_MouseLeave(sender As Object, e As EventArgs) Handles pic_Help.MouseLeave
        Help.Visible = False


        'If mouse hovers over then leaves the icon, Help form is hidden.

    End Sub


    Private Sub pic_Help_MouseHover(sender As Object, e As EventArgs) Handles pic_Help.MouseHover
        Help.Visible = True
        Help.lbl_helpHeadingEng.Text = "Edit your details"
        Help.rtxt_helpInfoEng.Text = "Only students can access this page. Edit and see your details here."

        Help.lbl_helpHeadingWel.Text = "Golygwch eich manylion"
        Help.rtxt_helpInfoWel.Text = "Dim ond myfyrwyr all gael mynediad i'r dudalen hon. Golygwch a gweld eich manylion yma."


        'when this specific icon is hovered over, Help form is revealed and text is altered as above to match this situation. 

    End Sub


End Class