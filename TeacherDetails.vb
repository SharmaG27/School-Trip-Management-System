Imports System.IO

Public Class TeacherDetails

    Dim LastRecord As Integer
    Dim FirstRecord As Integer = 0      'variables to help count amount of records; these are global
    Dim RowIndex As Integer

    Dim NewUser As Boolean = False



    'Checks that a string is not empty or just whitespace

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
    'must start with 01 or 07, prevents usage of +44
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



    Private Sub TeacherDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        ApplyBgTheme()
        'Allow background colour changing and extracting text file data to happen in this form


        GetFiles()

        FillTeacherGrid()

        FillTextBoxes()
        'Fill the teacher data grid and fill textboxes with relevant teacher data to allow it do be modified



        CentreForm(Me)


        '2 variables are set as the form's width and form's height respectively. (screenwidth, screenheight)
        'the other 2 variables take the form's boundaries away from the screen's boundaries which gives us the 
        'position of the form on our screen when it loads. Since we divided both sides' widths and heights by 2,
        'the form is exactly in the screen's centre as it loads. Using variables lets us use this code irrespective of 
        'different widths and heights of different forms.



        Me.Text = FormTitle & ": TEACHER DETAILS"


        dgv_TeacherDetails.RowHeadersVisible = False    'The pointer column is invisible. Unnecesary to have since we use buttons to navigate.

        dgv_TeacherDetails.AllowUserToAddRows = False       'Makes sure users cannot edit cells in the DataGrid, forced to use textbox.


        pbx_Close.ImageLocation = MyImages & "close1.png"
        pbx_first.ImageLocation = MyImages & "FirstRecord1.png"
        pbx_PreviousRecord.ImageLocation = MyImages & "PreviousRecord1.png"
        pbx_NextRecord.ImageLocation = MyImages & "NextRecord1.png"
        pbx_LastRecord.ImageLocation = MyImages & "LastRecord1.png"
        pbx_NewRecord.ImageLocation = MyImages & "NewTeacher1.png"
        pbx_SaveRecord.ImageLocation = MyImages & "SaveTeacher1.png"
        pbx_Delete.ImageLocation = MyImages & "DeleteTeacher1.png"
        pbx_Back.ImageLocation = MyImages & "MainMenu1.png"
        pbx_Supervise.ImageLocation = MyImages & "SupTrip1.png"
        pic_Help.ImageLocation = MyImages & "help.png"

        'Loads images which are saved in the 'images' folder into each PicBox



        If LoginAccessLevel_Global = "0" OrElse LoginAccessLevel_Global = "1" Then

            pbx_Supervise.Visible = False

        End If

        'Admin or Receptionists can access this form BUT cannot go ahead
        'to the 'supervise trip' form. they cannot see the button to do this. 
        'only teachers can.

    End Sub





    Private Sub FillTeacherGrid()

        Dim Teacher_sr As New StreamReader(Teachers_File)


        Dim OneTeacherRecord As String
        Dim Fields() As String
        Dim OneTeacherRecordDecrypted As String


        dgv_TeacherDetails.Rows.Clear()



        While Teacher_sr.Peek() >= 0

            OneTeacherRecord = Teacher_sr.ReadLine
            OneTeacherRecordDecrypted = XORencrypt(OneTeacherRecord)



            Fields = OneTeacherRecordDecrypted.Split(",")       'adding fields to the dynamic array

            dgv_TeacherDetails.Rows.Add(Fields)

        End While

        Teacher_sr.Close()

        'Using a StreamReader, we read all lines (records) inside Teachers_File and decrypt each line
        'and this decrypted line gets split using the comma terminators. Each splitted data is inserted into a slot 
        'within the Fields() dynamic array and this data is added to each row of the datagrid. This is repeated 
        'all the way to the last line of the txt file. 


        dgv_TeacherDetails.ClearSelection()  'removes the blue highlight from cells
        dgv_TeacherDetails.Rows(FirstRecord).Selected = True 'look at line 0 (first line). This row needs to be selected.

        RowIndex = FirstRecord
        NewUser = False      'Setting to False every time since data is appended before a user ever clicks 'New User' (where NewUser = True)

        LastRecord = dgv_TeacherDetails.Rows.Count - 1



    End Sub



    Private Sub FillTextBoxes()

        If dgv_TeacherDetails.Rows.Count > 0 Then
            dgv_TeacherDetails.Rows(RowIndex).Selected = True
        End If





        'this textbox is filled with the value contained inside the column (cell) 0 on the row which is highlighted. 
        txt_TeacherID.Text = (dgv_TeacherDetails.Rows(RowIndex).Cells(0).Value)
        txt_surname.Text = dgv_TeacherDetails.Rows(RowIndex).Cells(1).Value
        txt_name.Text = dgv_TeacherDetails.Rows(RowIndex).Cells(2).Value
        txt_title.Text = dgv_TeacherDetails.Rows(RowIndex).Cells(3).Value
        txt_houseNum.Text = dgv_TeacherDetails.Rows(RowIndex).Cells(4).Value
        txt_postCode.Text = dgv_TeacherDetails.Rows(RowIndex).Cells(5).Value
        txt_email.Text = dgv_TeacherDetails.Rows(RowIndex).Cells(6).Value
        txt_contactNum.Text = dgv_TeacherDetails.Rows(RowIndex).Cells(7).Value



        Dim dobValue As Object = dgv_TeacherDetails.Rows(RowIndex).Cells(8).Value
        If IsDate(dobValue) Then
            dtp_dob.Value = CDate(dobValue)
        Else
            dtp_dob.Value = Today
        End If

        txt_accessLevel.Text = dgv_TeacherDetails.Rows(RowIndex).Cells(9).Value


        Dim isAdminOrReceptionist As Boolean = (LoginAccessLevel_Global = "0" OrElse LoginAccessLevel_Global = "1")
        Dim isOwnRecord As Boolean = (LoginID_Global = txt_TeacherID.Text AndAlso LoginAccessLevel_Global = "2")

        If isAdminOrReceptionist OrElse isOwnRecord Then
            txt_usernmae.Text = LCase(dgv_TeacherDetails.Rows(RowIndex).Cells(10).Value)
            txt_password.Text = dgv_TeacherDetails.Rows(RowIndex).Cells(11).Value

            txt_usernmae.Show()
            txt_password.Show()
            lbl_username.Show()
            lbl_password.Show()





        Else
            txt_usernmae.Clear()
            txt_password.Clear()

            txt_usernmae.Hide()
            txt_password.Hide()
            lbl_username.Hide()
            lbl_password.Hide()
        End If
        'Each textbox gets filled with data located in each row of the datagrid if there are more than 0 rows in the DGV.

        'teachers can only see THEIR OWN login details. 

        Dim CanEditRecord As Boolean = isAdminOrReceptionist OrElse isOwnRecord

        pbx_NewRecord.Visible = isAdminOrReceptionist
        pbx_SaveRecord.Visible = CanEditRecord
        pbx_Delete.Visible = isAdminOrReceptionist

    End Sub



    Private Sub pbx_first_MouseEnter(sender As Object, e As EventArgs) Handles pbx_first.MouseEnter

        pbx_first.ImageLocation = MyImages & "FirstRecord2.png"

        'When the mouse hovers over the button, the second part of the rollover image is shown


    End Sub

    Private Sub pbx_first_MouseLeave(sender As Object, e As EventArgs) Handles pbx_first.MouseLeave

        pbx_first.ImageLocation = MyImages & "FirstRecord1.png"

        'When the mouse leaves the PicBox after hovering over it, we return to the first half
        'of the rollover image

    End Sub

    Private Sub pbx_first_Click(sender As Object, e As EventArgs) Handles pbx_first.Click


        RowIndex = FirstRecord
        dgv_TeacherDetails.ClearSelection()

        dgv_TeacherDetails.Rows(RowIndex).Selected = True


        FillTextBoxes()

        'Move the selector to the first record and update text boxes.

    End Sub





    Private Sub pbx_PreviousRecord_MouseEnter(sender As Object, e As EventArgs) Handles pbx_PreviousRecord.MouseEnter

        pbx_PreviousRecord.ImageLocation = MyImages & "PreviousRecord2.png"

        'When the mouse hovers over the button, the second part of the rollover image is shown


    End Sub

    Private Sub pbx_PreviousRecord_MouseLeave(sender As Object, e As EventArgs) Handles pbx_PreviousRecord.MouseLeave

        pbx_PreviousRecord.ImageLocation = MyImages & "PreviousRecord1.png"

        'When the mouse leaves the PicBox after hovering over it, we return to the first half
        'of the rollover image

    End Sub

    Private Sub pbx_PreviousRecord_Click(sender As Object, e As EventArgs) Handles pbx_PreviousRecord.Click

        If RowIndex > FirstRecord Then
            RowIndex -= 1


            dgv_TeacherDetails.ClearSelection()

            dgv_TeacherDetails.Rows(RowIndex).Selected = True


            FillTextBoxes()


        End If

        'Move selector to previous one above. 
        'Happens when index of current row is larger than index of First record. 


    End Sub

    Private Sub pbx_NextRecord_MouseEnter(sender As Object, e As EventArgs) Handles pbx_NextRecord.MouseEnter

        pbx_NextRecord.ImageLocation = MyImages & "NextRecord2.png"

        'When the mouse hovers over the button, the second part of the rollover image is shown


    End Sub

    Private Sub pbx_NextRecord_MouseLeave(sender As Object, e As EventArgs) Handles pbx_NextRecord.MouseLeave

        pbx_NextRecord.ImageLocation = MyImages & "NextRecord1.png"

        'When the mouse leaves the PicBox after hovering over it, we return to the first half
        'of the rollover image

    End Sub

    Private Sub pbx_NextRecord_Click(sender As Object, e As EventArgs) Handles pbx_NextRecord.Click

        If RowIndex < LastRecord Then
            RowIndex = RowIndex + 1


            dgv_TeacherDetails.ClearSelection()

            dgv_TeacherDetails.Rows(RowIndex).Selected = True


            FillTextBoxes()


        End If


        'Move the selector to the next record down and update text boxes.
        'Only happens when the index of row we are on is less than the index of the last record.

    End Sub

    Private Sub pbx_LastRecord_MouseEnter(sender As Object, e As EventArgs) Handles pbx_LastRecord.MouseEnter

        pbx_LastRecord.ImageLocation = MyImages & "LastRecord2.png"

        'When the mouse hovers over the button, the second part of the rollover image is shown

    End Sub

    Private Sub pbx_LastRecord_MouseLeave(sender As Object, e As EventArgs) Handles pbx_LastRecord.MouseLeave
        pbx_LastRecord.ImageLocation = MyImages & "LastRecord1.png"

        'When the mouse leaves the PicBox after hovering over it, we return to the first half
        'of the rollover image

    End Sub

    Private Sub pbx_LastRecord_Click(sender As Object, e As EventArgs) Handles pbx_LastRecord.Click



        RowIndex = LastRecord
        dgv_TeacherDetails.ClearSelection()

        dgv_TeacherDetails.Rows(RowIndex).Selected = True


        FillTextBoxes()

        'Move the selector to the last record and update text boxes.

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

        'Comletely close the program

    End Sub

    Private Sub pbx_Back_Click(sender As Object, e As EventArgs) Handles pbx_Back.Click

        Me.Visible = False
        MAIN_MENU.Visible = True

        'Back is clicked. This form is hidden and main menu form is revealed.

    End Sub

    Private Sub pbx_Back_MouseEnter(sender As Object, e As EventArgs) Handles pbx_Back.MouseEnter

        pbx_Back.ImageLocation = MyImages & "MainMenu2.png"

        'When the mouse hovers over the button, the second part of the rollover image is shown


    End Sub

    Private Sub pbx_Back_MouseLeave(sender As Object, e As EventArgs) Handles pbx_Back.MouseLeave

        pbx_Back.ImageLocation = MyImages & "MainMenu1.png"

        'When the mouse leaves the PicBox after hovering over it, we return to the first half
        'of the rollover image

    End Sub

    Private Sub pbx_NewReceptionist_MouseEnter(sender As Object, e As EventArgs) Handles pbx_NewRecord.MouseEnter

        pbx_NewRecord.ImageLocation = MyImages & "NewTeacher2.png"

        'When the mouse hovers over the button, the second part of the rollover image is shown


    End Sub

    Private Sub pbx_NewReceptionist_MouseLeave(sender As Object, e As EventArgs) Handles pbx_NewRecord.MouseLeave

        pbx_NewRecord.ImageLocation = MyImages & "NewTeacher1.png"

        'When the mouse leaves the PicBox after hovering over it, we return to the first half
        'of the rollover image

    End Sub

    Private Sub pbx_NewReceptionist_Click(sender As Object, e As EventArgs) Handles pbx_NewRecord.Click

        If ConfirmActions = True Then

            If MsgBox("Are you sure you want to make a new teacher record?",
                  MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation,
                  "Confirm New") = MsgBoxResult.No Then

                Exit Sub

            End If

        End If

        Dim max As Integer = 0  'first user ID is 1 so we can use 0 in this case
        Dim counter As Integer





        txt_TeacherID.Clear()
        txt_surname.Clear()
        txt_name.Clear()
        txt_title.Clear()
        txt_houseNum.Clear()
        txt_postCode.Clear()
        txt_email.Clear()
        txt_contactNum.Clear()
        dtp_dob.Value = Today.Date
        txt_accessLevel.Text = "2"
        txt_usernmae.Clear()
        txt_password.Clear()

        'All textboxes get cleared, ready for new user's details to be shown.


        For counter = 0 To LastRecord

            If Val(dgv_TeacherDetails.Rows(counter).Cells(0).Value > max) Then

                max = Val(dgv_TeacherDetails.Rows(counter).Cells(0).Value)

            End If

        Next

        txt_TeacherID.Text = max + 1       'new Id is generatied. It is original since it is a larger number than the previous ones. 
        NewUser = True

    End Sub

    Private Sub pbx_SaveRecord_MouseLeave(sender As Object, e As EventArgs) Handles pbx_SaveRecord.MouseLeave

        pbx_SaveRecord.ImageLocation = MyImages & "SaveTeacher1.png"

        'When the mouse leaves the PicBox after hovering over it, we return to the first half
        'of the rollover image

    End Sub

    Private Sub pbx_SaveRecord_MouseEnter(sender As Object, e As EventArgs) Handles pbx_SaveRecord.MouseEnter

        pbx_SaveRecord.ImageLocation = MyImages & "SaveTeacher2.png"

        'When the mouse hovers over the button, the second part of the rollover image is shown


    End Sub

    Private Sub pbx_SaveRecord_Click(sender As Object, e As EventArgs) Handles pbx_SaveRecord.Click

        If Not ValidateForm() Then Exit Sub
        'If a SINGLE validation check fails, this procedure doesn't run and a relevant error message appears. 

        If ConfirmActions = True Then

            If MsgBox("Are you sure you want to save this teacher record?",
                  MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation,
                  "Confirm Save") = MsgBoxResult.No Then

                Exit Sub

            End If

        End If


        Dim counter As Integer
        Dim OneTeacherRecord As String
        Dim Updated As Boolean = False


        Dim isAdminOrReceptionist As Boolean = (LoginAccessLevel_Global = "0" OrElse LoginAccessLevel_Global = "1")
        Dim isOwnRecord As Boolean = (LoginID_Global = txt_TeacherID.Text AndAlso LoginAccessLevel_Global = "2")

        If Not (isAdminOrReceptionist OrElse isOwnRecord) Then
            MessageBox.Show("You are not allowed to edit this record.", "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If


        If NewUser = True Then  'add new record (if a new user) to end of existing file

            Dim Teacher_sw As New StreamWriter(Teachers_File, True)    'must select true to append and add, NOT FALSE TO OVERWRITE

            OneTeacherRecord = txt_TeacherID.Text & ","
            OneTeacherRecord = OneTeacherRecord & txt_surname.Text & ","
            OneTeacherRecord = OneTeacherRecord & txt_name.Text & ","
            OneTeacherRecord = OneTeacherRecord & txt_title.Text & ","
            OneTeacherRecord = OneTeacherRecord & txt_houseNum.Text & ","
            OneTeacherRecord = OneTeacherRecord & txt_postCode.Text & ","
            OneTeacherRecord = OneTeacherRecord & txt_email.Text & ","
            OneTeacherRecord = OneTeacherRecord & txt_contactNum.Text & ","
            OneTeacherRecord = OneTeacherRecord & dtp_dob.Value & ","

            OneTeacherRecord = OneTeacherRecord & txt_accessLevel.Text & ","

            OneTeacherRecord = OneTeacherRecord & LCase(txt_usernmae.Text) & ","
            OneTeacherRecord = OneTeacherRecord & txt_password.Text

            Teacher_sw.WriteLine(XORencrypt(OneTeacherRecord))



            Teacher_sw.Close()

            'Fill OneTeacherRecord with all data inputted into textboxes in the same order separated by commas
            'and encrypt this and write it into the text file. Close the StreamReader to avoid problems like corruption. 


            Dim LoginList As New List(Of String)

            If File.Exists(UserLogin_File) Then

                LoginList.AddRange(File.ReadAllLines(UserLogin_File))

            End If

            'Add the saved Access Level, StudentID, username and password to UserLogin of it is a newUser on a new line.
            'What this does is completely override the file and re-write it, this time including the newly created record.


            For i = 0 To LoginList.Count - 1

                Dim fields() As String = XORencrypt(LoginList(i)).Split(",")

                If fields(0) = txt_accessLevel.Text AndAlso fields(1) = txt_TeacherID.Text Then

                    LoginList(i) = XORencrypt(txt_accessLevel.Text & "," & txt_TeacherID.Text & "," & LCase(txt_usernmae.Text) & "," & txt_password.Text)

                    Updated = True

                    Exit For

                End If

            Next

            'Split up each record into individual fields separated by commas. When a match on Access Level and ID,
            'Replace that entire line in which the two matches occur. This makes sure the exact person is found since 
            'comparing just ID's could lead to duplicate / incorrect replacements. 





            FillTeacherGrid()
            RowIndex = LastRecord
            FillTextBoxes()

            'Run FillTextBoxes to show the saved information.



            dgv_TeacherDetails.ClearSelection()      'highlights the newly added record
            dgv_TeacherDetails.Rows(LastRecord).Selected = True


        End If



        If NewUser = False Then

            Dim Teacher_sw As New StreamWriter(Teachers_File, False)   'completely wipes file clean


            For counter = 0 To LastRecord   'loop through each row in datagrid, using sequential FH

                If dgv_TeacherDetails.Rows(counter).Cells(0).Value <> txt_TeacherID.Text Then 'this sign means not equal to
                    'copy datagrid row to text file

                    OneTeacherRecord = dgv_TeacherDetails.Rows(counter).Cells(0).Value & ","
                    OneTeacherRecord = OneTeacherRecord & dgv_TeacherDetails.Rows(counter).Cells(1).Value & ","
                    OneTeacherRecord = OneTeacherRecord & dgv_TeacherDetails.Rows(counter).Cells(2).Value & ","
                    OneTeacherRecord = OneTeacherRecord & dgv_TeacherDetails.Rows(counter).Cells(3).Value & ","
                    OneTeacherRecord = OneTeacherRecord & dgv_TeacherDetails.Rows(counter).Cells(4).Value & ","
                    OneTeacherRecord = OneTeacherRecord & dgv_TeacherDetails.Rows(counter).Cells(5).Value & ","
                    OneTeacherRecord = OneTeacherRecord & dgv_TeacherDetails.Rows(counter).Cells(6).Value & ","
                    OneTeacherRecord = OneTeacherRecord & dgv_TeacherDetails.Rows(counter).Cells(7).Value & ","

                    OneTeacherRecord = OneTeacherRecord & dgv_TeacherDetails.Rows(counter).Cells(8).Value & ","
                    OneTeacherRecord = OneTeacherRecord & dgv_TeacherDetails.Rows(counter).Cells(9).Value & ","

                    OneTeacherRecord = OneTeacherRecord & LCase(dgv_TeacherDetails.Rows(counter).Cells(10).Value) & ","

                    OneTeacherRecord = OneTeacherRecord & dgv_TeacherDetails.Rows(counter).Cells(11).Value


                    Teacher_sw.WriteLine(XORencrypt(OneTeacherRecord))

                    'OneTeacherRecord is filled with data from each row in the dgv, separated by commas.
                    'This is repeated until the last record and this overwrites the current Student text file

                Else
                    'copy text boxes to text file

                    OneTeacherRecord = txt_TeacherID.Text & ","
                    OneTeacherRecord = OneTeacherRecord & txt_surname.Text & ","
                    OneTeacherRecord = OneTeacherRecord & txt_name.Text & ","
                    OneTeacherRecord = OneTeacherRecord & txt_title.Text & ","      'all this is to concacenate the record, neater than all in one line

                    OneTeacherRecord = OneTeacherRecord & txt_houseNum.Text & ","
                    OneTeacherRecord = OneTeacherRecord & txt_postCode.Text & ","
                    OneTeacherRecord = OneTeacherRecord & txt_email.Text & ","
                    OneTeacherRecord = OneTeacherRecord & txt_contactNum.Text & ","
                    OneTeacherRecord = OneTeacherRecord & dtp_dob.Value & ","

                    OneTeacherRecord = OneTeacherRecord & txt_accessLevel.Text & ","

                    OneTeacherRecord = OneTeacherRecord & LCase(txt_usernmae.Text) & ","
                    OneTeacherRecord = OneTeacherRecord & txt_password.Text


                    Teacher_sw.WriteLine(XORencrypt(OneTeacherRecord))

                    'when the counter identifies the record which equals the rowIndex (finds the record which needed
                    'appending) it writes this data into the relevant text files. 


                End If

            Next

            Teacher_sw.Close()


            Dim LoginList As New List(Of String)

            If File.Exists(UserLogin_File) Then

                LoginList.AddRange(File.ReadAllLines(UserLogin_File))

            End If


            For i = 0 To LoginList.Count - 1

                Dim fields() As String = XORencrypt(LoginList(i)).Split(",")

                ' Match on AccessLevel + TeacherID
                If fields(0) = txt_accessLevel.Text AndAlso fields(1) = txt_TeacherID.Text Then

                    ' Replace the existing login line
                    LoginList(i) = (XORencrypt(txt_accessLevel.Text & "," & txt_TeacherID.Text & "," & LCase(txt_usernmae.Text) & "," & txt_password.Text))

                    Updated = True
                    Exit For
                End If

            Next

            'Split up each record into individual fields separated by commas. When a match on Access Level and ID,
            'Replace that entire line in which the two matches occur. This makes sure the exact person is found since 
            'comparing just ID's could lead to duplicate / incorrect replacements. 



            If Updated = False Then

                LoginList.Add(XORencrypt(txt_accessLevel.Text & "," & txt_TeacherID.Text & "," & LCase(txt_usernmae.Text) & "," & txt_password.Text))

            End If

            File.WriteAllLines(UserLogin_File, LoginList)

            'If no match found (a new record) then wipe the file, rewrite it including the new record at the bottom. 



            FillTeacherGrid()

            FillTextBoxes()


            dgv_TeacherDetails.ClearSelection()      'highlights the newly added record
            dgv_TeacherDetails.Rows(FirstRecord).Selected = True


        End If



    End Sub


    Private Sub pbx_Delete_MouseEnter(sender As Object, e As EventArgs) Handles pbx_Delete.MouseEnter

        pbx_Delete.ImageLocation = MyImages & "DeleteTeacher2.png"

        'When the mouse hovers over the button, the second part of the rollover image is shown


    End Sub



    Private Sub pbx_Delete_MouseLeave(sender As Object, e As EventArgs) Handles pbx_Delete.MouseLeave

        pbx_Delete.ImageLocation = MyImages & "DeleteTeacher1.png"

        'When the mouse leaves the PicBox after hovering over it, we return to the first half
        'of the rollover image

    End Sub

    Private Sub pbx_Delete_Click(sender As Object, e As EventArgs) Handles pbx_Delete.Click

        If ConfirmActions = True Then

            If MsgBox("Are you sure you want to delete this teacher record?",
                  MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation,
                  "Confirm Delete") = MsgBoxResult.No Then

                Exit Sub

            End If

        End If

        Dim Teacher_sw As New StreamWriter(Teachers_File, False)   'completely wipes file clean
        Dim OneTeacherRecord As String
        Dim counter As Integer

        For counter = 0 To LastRecord   'loop through each row in datagrid, using sequential FH

            If counter <> RowIndex Then 'this sign means not equal to
                'copy datagrid row to text file

                OneTeacherRecord = dgv_TeacherDetails.Rows(counter).Cells(0).Value & ","
                OneTeacherRecord = OneTeacherRecord & dgv_TeacherDetails.Rows(counter).Cells(1).Value & ","
                OneTeacherRecord = OneTeacherRecord & dgv_TeacherDetails.Rows(counter).Cells(2).Value & ","
                OneTeacherRecord = OneTeacherRecord & dgv_TeacherDetails.Rows(counter).Cells(3).Value & ","
                OneTeacherRecord = OneTeacherRecord & dgv_TeacherDetails.Rows(counter).Cells(4).Value & ","
                OneTeacherRecord = OneTeacherRecord & dgv_TeacherDetails.Rows(counter).Cells(5).Value & ","
                OneTeacherRecord = OneTeacherRecord & dgv_TeacherDetails.Rows(counter).Cells(6).Value & ","
                OneTeacherRecord = OneTeacherRecord & dgv_TeacherDetails.Rows(counter).Cells(7).Value & ","

                OneTeacherRecord = OneTeacherRecord & dgv_TeacherDetails.Rows(counter).Cells(8).Value & ","
                OneTeacherRecord = OneTeacherRecord & dgv_TeacherDetails.Rows(counter).Cells(9).Value & ","

                OneTeacherRecord = OneTeacherRecord & LCase(dgv_TeacherDetails.Rows(counter).Cells(10).Value) & ","

                OneTeacherRecord = OneTeacherRecord & dgv_TeacherDetails.Rows(counter).Cells(11).Value


                Teacher_sw.WriteLine(XORencrypt(OneTeacherRecord))

            End If

        Next

        Teacher_sw.Close()

        'This is the same process as saving a record if NewUser = False since we are overwriting the file
        'and writing it without the record we wanted to delete. 


        Dim LoginList As New List(Of String)

        If File.Exists(UserLogin_File) Then

            LoginList.AddRange(File.ReadAllLines(UserLogin_File))

        End If

        'If UserLogin exists, load all data from it into the LoginList List.



        LoginList = LoginList.Where(Function(line)

                                        Dim fields() As String = XORencrypt(line).Split(",")

                                        Return Not (fields(0) = txt_accessLevel.Text AndAlso fields(1) = txt_TeacherID.Text)

                                    End Function).ToList()

        File.WriteAllLines(UserLogin_File, LoginList)


        'This function finds the record we do NOT want. Then, it splits the decrypted record into slots in Fields()
        'and returns everything but the login details of the record we did not want. 
        'The returned things get written back into txt file. 




        FillTeacherGrid()

        FillTextBoxes()


        dgv_TeacherDetails.ClearSelection()      'highlights the newly added record
        dgv_TeacherDetails.Rows(RowIndex).Selected = True



    End Sub

    Private Sub pbx_Supervise_MouseEnter(sender As Object, e As EventArgs) Handles pbx_Supervise.MouseEnter

        pbx_Supervise.ImageLocation = MyImages & "SupTrip2.png"

        'When the mouse hovers over the button, the second part of the rollover image is shown


    End Sub

    Private Sub pbx_Supervise_MouseLeave(sender As Object, e As EventArgs) Handles pbx_Supervise.MouseLeave

        pbx_Supervise.ImageLocation = MyImages & "SupTrip1.png"

        'When the mouse leaves the PicBox after hovering over it, we return to the first half
        'of the rollover image

    End Sub

    Private Sub pbx_Supervise_Click(sender As Object, e As EventArgs) Handles pbx_Supervise.Click

        Me.Visible = False
        TripSupervise.Visible = True

        'Hide teacher details form and reveal the form allowing teachers to supervise trips


    End Sub



    Private Sub pic_Help_MouseLeave(sender As Object, e As EventArgs) Handles pic_Help.MouseLeave
        Help.Visible = False


        'If mouse hovers over then leaves the icon, Help form is hidden.

    End Sub


    Private Sub pic_Help_MouseHover(sender As Object, e As EventArgs) Handles pic_Help.MouseHover
        Help.Visible = True
        Help.lbl_helpHeadingEng.Text = "Teacher Details"
        Help.rtxt_helpInfoEng.Text = "If you are a teacher, you can only see your own login details. You cannot edit other teachers' details. Receptionists can change your details."

        Help.lbl_helpHeadingWel.Text = "Manylion yr Athro"
        Help.rtxt_helpInfoWel.Text = "Os ydych chi'n athro/athrawes, dim ond eich manylion mewngofnodi eich hun allwch chi eu gweld. Ni allwch olygu manylion athrawon eraill. Gall derbynyddion newid eich manylion."


        'when this specific icon is hovered over, Help form is revealed and text is altered as above to match this situation. 

    End Sub


End Class