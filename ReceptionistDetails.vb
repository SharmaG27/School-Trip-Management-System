Imports System.IO
Imports System.Runtime.CompilerServices

Public Class ReceptionistDetails

    Dim LastRecord As Integer
    Dim FirstRecord As Integer = 0      'variables to help count amount of records; these are global
    Dim RowIndex As Integer

    Dim NewUser As Boolean = False


    'Checks that a string is not empty or just whitespace

    Private Function IsNotEmpty(value As String) As Boolean

        Return value.Trim() <> ""

    End Function


    'Makes sure that a name is not empty and contains letters only (no numbers or symbols)
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
    'must start with 01 or 07: users cannot use +44
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



    Private Sub ReceptionistDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ApplyBgTheme()

        GetFiles()

        'Allow background colour changing and extracting text file data to happen in this form

        FillReceptionistGrid()

        FillTextBoxes()

        'Fill the receptionist data grid and fill textboxes with relevant receptionist data to allow it do be modified



        CentreForm(Me)


        '2 variables are set as the form's width and form's height respectively. (screenwidth, screenheight)
        'the other 2 variables take the form's boundaries away from the screen's boundaries which gives us the 
        'position of the form on our screen when it loads. Since we divided both sides' widths and heights by 2,
        'the form is exactly in the screen's centre as it loads. Using variables lets us use this code irrespective of 
        'different widths and heights of different forms.




        Me.Text = FormTitle & ": RECEPTIONIST DETAILS"  'Rename the form.


        If LoginAccessLevel_Global <> "0" Then
            pbx_NewReceptionist.Hide()
            pbx_SaveRecord.Hide()
            pbx_Delete.Hide()
        End If

        dgv_ReceptionistDetails.RowHeadersVisible = False       'Hide the pointer row on the datagrid to make it look cleaner

        dgv_ReceptionistDetails.AllowUserToAddRows = False  'Prevent users from adding extra records onto the datagrid by clicking on it



        pbx_Close.ImageLocation = MyImages & "close1.png"
        pbx_first.ImageLocation = MyImages & "FirstRecord1.png"
        pbx_PreviousRecord.ImageLocation = MyImages & "PreviousRecord1.png"
        pbx_NextRecord.ImageLocation = MyImages & "NextRecord1.png"
        pbx_LastRecord.ImageLocation = MyImages & "LastRecord1.png"
        pbx_NewReceptionist.ImageLocation = MyImages & "NewRec1.png"
        pbx_SaveRecord.ImageLocation = MyImages & "SaveRec1.png"
        pbx_Delete.ImageLocation = MyImages & "DeleteRec1.png"
        pbx_BackToMenu.ImageLocation = MyImages & "BackAdminControl1.png"
        pic_Help.ImageLocation = MyImages & "help.png"

        'Loads images which are saved in the 'images' folder into each PicBox


    End Sub



    Private Sub FillReceptionistGrid()

        Dim OneReceptionistRecord As String
        Dim Fields() As String
        Dim OneReceptionistRecordDecrypted As String


        dgv_ReceptionistDetails.Rows.Clear()

        Dim Receptionist_sr As New StreamReader(Receptionists_File)

        While Receptionist_sr.Peek() >= 0

            OneReceptionistRecord = Receptionist_sr.ReadLine
            OneReceptionistRecordDecrypted = XORencrypt(OneReceptionistRecord)



            Fields = OneReceptionistRecordDecrypted.Split(",")       'adding fields to the dynamic array

            dgv_ReceptionistDetails.Rows.Add(Fields)

        End While

        Receptionist_sr.Close()

        'Using a StreamReader, we read all lines (records) inside Receptionist_File and decrypt each line
        'and this decrypted line gets split using the comma terminators. Each splitted data is inserted into a slot 
        'within the Fields() dynamic array and this data is added to each row of the datagrid. This is repeated 
        'all the way to the last line of the txt file. 


        dgv_ReceptionistDetails.ClearSelection()  'removes the blue highlight from cells
        dgv_ReceptionistDetails.Rows(FirstRecord).Selected = True 'look at line 0 (first line). This row needs to be selected.

        RowIndex = FirstRecord
        LastRecord = dgv_ReceptionistDetails.Rows.Count - 1



    End Sub



    Private Sub FillTextBoxes()



        If dgv_ReceptionistDetails.Rows.Count > 0 Then
            dgv_ReceptionistDetails.Rows(RowIndex).Selected = True
        End If

        'this textbox is filled with the value contained inside the column (cell) 0 on the row which is highlighted. 
        txt_ReceptionistID.Text = (dgv_ReceptionistDetails.Rows(RowIndex).Cells(0).Value)
        txt_surname.Text = dgv_ReceptionistDetails.Rows(RowIndex).Cells(1).Value
        txt_name.Text = dgv_ReceptionistDetails.Rows(RowIndex).Cells(2).Value
        txt_title.Text = dgv_ReceptionistDetails.Rows(RowIndex).Cells(3).Value
        txt_houseNum.Text = dgv_ReceptionistDetails.Rows(RowIndex).Cells(4).Value
        txt_postCode.Text = dgv_ReceptionistDetails.Rows(RowIndex).Cells(5).Value
        txt_email.Text = dgv_ReceptionistDetails.Rows(RowIndex).Cells(6).Value
        txt_contactNum.Text = dgv_ReceptionistDetails.Rows(RowIndex).Cells(7).Value



        Dim dobValue As Object = dgv_ReceptionistDetails.Rows(RowIndex).Cells(8).Value
        If IsDate(dobValue) Then
            dtp_dob.Value = CDate(dobValue)
        Else
            dtp_dob.Value = Today
        End If

        txt_accessLevel.Text = dgv_ReceptionistDetails.Rows(RowIndex).Cells(9).Value
        txt_usernmae.Text = dgv_ReceptionistDetails.Rows(RowIndex).Cells(10).Value
        txt_password.Text = dgv_ReceptionistDetails.Rows(RowIndex).Cells(11).Value


        Dim currentAccessLevel As String = txt_accessLevel.Text
        Dim loginAccessLevel As String = LoginAccessLevel_Global
        Dim loginID As String = LoginID_Global
        Dim currentID As String = txt_ReceptionistID.Text

        If loginAccessLevel = "0" Then
            ' Admin: always sees login info
            txt_usernmae.Visible = True
            txt_password.Visible = True
            lbl_username.Visible = True
            lbl_password.Visible = True
        ElseIf loginAccessLevel <> "0" AndAlso currentID = loginID Then
            ' Receptionist viewing their own account
            txt_usernmae.Visible = True
            txt_password.Visible = True
            lbl_username.Visible = True
            lbl_password.Visible = True
            pbx_SaveRecord.Visible = True

        Else
            ' Receptionist viewing someone else's account
            txt_usernmae.Visible = False
            txt_password.Visible = False
            lbl_username.Visible = False
            lbl_password.Visible = False
        End If

        'Each textbox gets filled with data located in each row of the datagrid if there are more than 0 rows in the DGV.

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
        dgv_ReceptionistDetails.ClearSelection()

        dgv_ReceptionistDetails.Rows(RowIndex).Selected = True


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


            dgv_ReceptionistDetails.ClearSelection()

            dgv_ReceptionistDetails.Rows(RowIndex).Selected = True


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


            dgv_ReceptionistDetails.ClearSelection()

            dgv_ReceptionistDetails.Rows(RowIndex).Selected = True


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
        dgv_ReceptionistDetails.ClearSelection()

        dgv_ReceptionistDetails.Rows(RowIndex).Selected = True


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

    Private Sub pbx_NewReceptionist_MouseEnter(sender As Object, e As EventArgs) Handles pbx_NewReceptionist.MouseEnter

        pbx_NewReceptionist.ImageLocation = MyImages & "NewRec2.png"

        'When the mouse hovers over the button, the second part of the rollover image is shown

    End Sub

    Private Sub pbx_NewReceptionist_MouseLeave(sender As Object, e As EventArgs) Handles pbx_NewReceptionist.MouseLeave

        pbx_NewReceptionist.ImageLocation = MyImages & "NewRec1.png"

        'When the mouse leaves the PicBox after hovering over it, we return to the first half
        'of the rollover image
    End Sub

    Private Sub pbx_NewReceptionist_Click(sender As Object, e As EventArgs) Handles pbx_NewReceptionist.Click


        If ConfirmActions = True Then

            If MsgBox("Are you sure you want to make a new receptionist record?",
                  MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation,
                  "Confirm New") = MsgBoxResult.No Then

                Exit Sub

            End If

        End If

        Dim max As Integer = 0  'first user ID is 1 so we can use 0 in this case
        Dim counter As Integer



        txt_ReceptionistID.Clear()
        txt_surname.Clear()
        txt_name.Clear()
        txt_title.Clear()
        txt_houseNum.Clear()
        txt_postCode.Clear()
        txt_email.Clear()
        txt_contactNum.Clear()
        dtp_dob.Value = Today.Date
        txt_accessLevel.Text = "1"
        txt_usernmae.Clear()
        txt_password.Clear()

        'All textboxes get cleared, ready for new user's details to be shown.

        For counter = 0 To LastRecord

            If Val(dgv_ReceptionistDetails.Rows(counter).Cells(0).Value > max) Then

                max = Val(dgv_ReceptionistDetails.Rows(counter).Cells(0).Value)

            End If

        Next

        txt_ReceptionistID.Text = max + 1       'new Id is generatied. It is original since it is a larger number than the previous ones. 
        NewUser = True


    End Sub

    Private Sub pbx_SaveRecord_MouseEnter(sender As Object, e As EventArgs) Handles pbx_SaveRecord.MouseEnter

        pbx_SaveRecord.ImageLocation = MyImages & "SaveRec2.png"
        'When the mouse hovers over the button, the second part of the rollover image is shown


    End Sub

    Private Sub pbx_SaveRecord_MouseLeave(sender As Object, e As EventArgs) Handles pbx_SaveRecord.MouseLeave

        pbx_SaveRecord.ImageLocation = MyImages & "SaveRec1.png"

        'When the mouse leaves the PicBox after hovering over it, we return to the first half
        'of the rollover image
    End Sub

    Private Sub pbx_SaveRecord_Click(sender As Object, e As EventArgs) Handles pbx_SaveRecord.Click


        If Not ValidateForm() Then Exit Sub
        'If validation returned to be false, entire sub is Skipped. user must fix any input errors.

        If ConfirmActions = True Then


            If MsgBox("Are you sure you want to save this receptionist record?",
                  MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation,
                  "Confirm Save") = MsgBoxResult.No Then

                Exit Sub

            End If

        End If

        Dim counter As Integer
        Dim OneReceptionistRecord As String



        If NewUser = True Then  'add new record (if a new user) to end of existing file

            Dim Receptionist_sw As New StreamWriter(Receptionists_File, True)    'must select true to append and add, NOT FALSE TO OVERWRITE

            OneReceptionistRecord = txt_ReceptionistID.Text & ","
            OneReceptionistRecord = OneReceptionistRecord & txt_surname.Text & ","
            OneReceptionistRecord = OneReceptionistRecord & txt_name.Text & ","
            OneReceptionistRecord = OneReceptionistRecord & txt_title.Text & ","
            OneReceptionistRecord = OneReceptionistRecord & txt_houseNum.Text & ","
            OneReceptionistRecord = OneReceptionistRecord & txt_postCode.Text & ","
            OneReceptionistRecord = OneReceptionistRecord & txt_email.Text & ","
            OneReceptionistRecord = OneReceptionistRecord & txt_contactNum.Text & ","
            OneReceptionistRecord = OneReceptionistRecord & dtp_dob.Value & ","

            OneReceptionistRecord = OneReceptionistRecord & txt_accessLevel.Text & ","
            OneReceptionistRecord = OneReceptionistRecord & LCase(txt_usernmae.Text) & ","
            OneReceptionistRecord = OneReceptionistRecord & txt_password.Text

            Receptionist_sw.WriteLine(XORencrypt(OneReceptionistRecord))



            Receptionist_sw.Close()

            'Fill OneReceptionist Record with all data inputted into textboxes in the same order separated by commas
            'and encrypt this and write it into the text file. Close the StreamReader to avoid problems like corruption. 


            FillReceptionistGrid()
            RowIndex = LastRecord
            FillTextBoxes()

            'Run FillTextBoxes to show the saved information.


            dgv_ReceptionistDetails.ClearSelection()      'highlights the newly added record
            dgv_ReceptionistDetails.Rows(LastRecord).Selected = True

        End If

        If NewUser = False Then

            Dim Receptionist_sw As New StreamWriter(Receptionists_File, False)   'completely wipes file clean


            For counter = 0 To LastRecord   'loop through each row in datagrid, using sequential FH

                If counter <> RowIndex Then 'this sign means not equal to
                    'copy datagrid row to text file

                    OneReceptionistRecord = dgv_ReceptionistDetails.Rows(counter).Cells(0).Value & ","
                    OneReceptionistRecord = OneReceptionistRecord & dgv_ReceptionistDetails.Rows(counter).Cells(1).Value & ","
                    OneReceptionistRecord = OneReceptionistRecord & dgv_ReceptionistDetails.Rows(counter).Cells(2).Value & ","
                    OneReceptionistRecord = OneReceptionistRecord & dgv_ReceptionistDetails.Rows(counter).Cells(3).Value & ","
                    OneReceptionistRecord = OneReceptionistRecord & dgv_ReceptionistDetails.Rows(counter).Cells(4).Value & ","
                    OneReceptionistRecord = OneReceptionistRecord & dgv_ReceptionistDetails.Rows(counter).Cells(5).Value & ","
                    OneReceptionistRecord = OneReceptionistRecord & dgv_ReceptionistDetails.Rows(counter).Cells(6).Value & ","
                    OneReceptionistRecord = OneReceptionistRecord & dgv_ReceptionistDetails.Rows(counter).Cells(7).Value & ","

                    OneReceptionistRecord = OneReceptionistRecord & dgv_ReceptionistDetails.Rows(counter).Cells(8).Value & ","
                    OneReceptionistRecord = OneReceptionistRecord & dgv_ReceptionistDetails.Rows(counter).Cells(9).Value & ","
                    OneReceptionistRecord = OneReceptionistRecord & LCase(dgv_ReceptionistDetails.Rows(counter).Cells(10).Value) & ","

                    OneReceptionistRecord = OneReceptionistRecord & dgv_ReceptionistDetails.Rows(counter).Cells(11).Value


                    Receptionist_sw.WriteLine(XORencrypt(OneReceptionistRecord))

                    'OneReceptionistRecord is filled with data from each row in the dgv, separated by commas.
                    'This is repeated until the last record and this overwrites the current Receptionist text file


                Else
                    'copy text boxes to text file

                    OneReceptionistRecord = txt_ReceptionistID.Text & ","
                    OneReceptionistRecord = OneReceptionistRecord & txt_surname.Text & ","
                    OneReceptionistRecord = OneReceptionistRecord & txt_name.Text & ","
                    OneReceptionistRecord = OneReceptionistRecord & txt_title.Text & ","      'all this is to concacenate the record, neater than all in one line

                    OneReceptionistRecord = OneReceptionistRecord & txt_houseNum.Text & ","
                    OneReceptionistRecord = OneReceptionistRecord & txt_postCode.Text & ","
                    OneReceptionistRecord = OneReceptionistRecord & txt_email.Text & ","
                    OneReceptionistRecord = OneReceptionistRecord & txt_contactNum.Text & ","
                    OneReceptionistRecord = OneReceptionistRecord & dtp_dob.Value & ","

                    OneReceptionistRecord = OneReceptionistRecord & txt_accessLevel.Text & ","
                    OneReceptionistRecord = OneReceptionistRecord & LCase(txt_usernmae.Text) & ","
                    OneReceptionistRecord = OneReceptionistRecord & txt_password.Text


                    Receptionist_sw.WriteLine(XORencrypt(OneReceptionistRecord))

                    'when the counter identifies the record which equals the rowIndex (finds the record which needed
                    'appending) it writes this data into the relevant text files. 

                End If

            Next


            Receptionist_sw.Close()



            FillReceptionistGrid()

            FillTextBoxes()


            dgv_ReceptionistDetails.ClearSelection()      'highlights the newly added record
            dgv_ReceptionistDetails.Rows(FirstRecord).Selected = True


        End If



        Dim LoginList As New List(Of String)

        'A list is created which will store all login details from UserLogin text file.
        'This procedure will save login details. 

        If File.Exists(UserLogin_File) Then

            LoginList.AddRange(File.ReadAllLines(UserLogin_File))

        End If

        Dim Updated As Boolean = False

        'If this text file exists, read all lines from file and add them to list.
        'The updated boolean is a flag indicating if the updation process is completed or not. 



        For i = 0 To LoginList.Count - 1

            Dim fields() As String = XORencrypt(LoginList(i)).Split(",")

            If fields(0) = txt_accessLevel.Text AndAlso fields(1) = txt_ReceptionistID.Text Then

                LoginList(i) = XORencrypt(txt_accessLevel.Text & "," & txt_ReceptionistID.Text & "," & LCase(txt_usernmae.Text) & "," & txt_password.Text)

                Updated = True

                Exit For

            End If

        Next


        'For every login record, check if the decrypted accesslevel and ID fields match the textbox inputs
        'Encrypt and update the existing record with the new details and set the boolean to True.

        If Not Updated Then

            LoginList.Add(XORencrypt(txt_accessLevel.Text & "," & txt_ReceptionistID.Text & "," & LCase(txt_usernmae.Text) & "," & txt_password.Text))

        End If

        'If the boolean is still false, create a new encrypted receptionist record.

        File.WriteAllLines(UserLogin_File, LoginList)

        NewUser = False

        'Write all of the updated records into the UserLogin File. 



    End Sub

    Private Sub pbx_Delete_MouseEnter(sender As Object, e As EventArgs) Handles pbx_Delete.MouseEnter

        pbx_Delete.ImageLocation = MyImages & "DeleteRec2.png"

        'When the mouse hovers over the button, the second part of the rollover image is shown

    End Sub

    Private Sub pbx_Delete_MouseLeave(sender As Object, e As EventArgs) Handles pbx_Delete.MouseLeave

        pbx_Delete.ImageLocation = MyImages & "DeleteRec1.png"

        'When the mouse leaves the PicBox after hovering over it, we return to the first half
        'of the rollover image
    End Sub

    Private Sub pbx_Delete_Click(sender As Object, e As EventArgs) Handles pbx_Delete.Click


        If ConfirmActions = True Then

            If MsgBox("Are you sure you want to delete this receptionist record?",
                  MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation,
                  "Confirm Delete") = MsgBoxResult.No Then

                Exit Sub

            End If

        End If


        Dim Receptionist_sw As New StreamWriter(Receptionists_File, False)   'completely wipes file clean
        Dim OneReceptionistRecord As String
        Dim counter As Integer


        For counter = 0 To LastRecord   'loop through each row in datagrid, using sequential FH

            If counter <> RowIndex Then 'this sign means not equal to
                'copy datagrid row to text file

                OneReceptionistRecord = dgv_ReceptionistDetails.Rows(counter).Cells(0).Value & ","
                OneReceptionistRecord = OneReceptionistRecord & dgv_ReceptionistDetails.Rows(counter).Cells(1).Value & ","
                OneReceptionistRecord = OneReceptionistRecord & dgv_ReceptionistDetails.Rows(counter).Cells(2).Value & ","
                OneReceptionistRecord = OneReceptionistRecord & dgv_ReceptionistDetails.Rows(counter).Cells(3).Value & ","
                OneReceptionistRecord = OneReceptionistRecord & dgv_ReceptionistDetails.Rows(counter).Cells(4).Value & ","
                OneReceptionistRecord = OneReceptionistRecord & dgv_ReceptionistDetails.Rows(counter).Cells(5).Value & ","
                OneReceptionistRecord = OneReceptionistRecord & dgv_ReceptionistDetails.Rows(counter).Cells(6).Value & ","
                OneReceptionistRecord = OneReceptionistRecord & dgv_ReceptionistDetails.Rows(counter).Cells(7).Value & ","

                OneReceptionistRecord = OneReceptionistRecord & dgv_ReceptionistDetails.Rows(counter).Cells(8).Value & ","
                OneReceptionistRecord = OneReceptionistRecord & dgv_ReceptionistDetails.Rows(counter).Cells(9).Value & ","
                OneReceptionistRecord = OneReceptionistRecord & LCase(dgv_ReceptionistDetails.Rows(counter).Cells(10).Value) & ","

                OneReceptionistRecord = OneReceptionistRecord & dgv_ReceptionistDetails.Rows(counter).Cells(11).Value


                Receptionist_sw.WriteLine(XORencrypt(OneReceptionistRecord))

            End If

        Next

        Receptionist_sw.Close()

        'This is the same process as saving a record if NewUser = False since we are overwriting the file
        'and writing it without the record we wanted to delete. 




        Dim LoginList As New List(Of String)

        If File.Exists(UserLogin_File) Then

            LoginList.AddRange(File.ReadAllLines(UserLogin_File))

        End If

        'If UserLogin exists, load all data from it into the LoginList List.

        LoginList = LoginList.Where(Function(line)

                                        Dim fields() As String = XORencrypt(line).Split(",")

                                        Return Not (fields(0) = txt_accessLevel.Text AndAlso fields(1) = txt_ReceptionistID.Text AndAlso fields(2) = LCase(txt_usernmae.Text) AndAlso fields(3) = txt_password.Text)

                                    End Function).ToList()

        File.WriteAllLines(UserLogin_File, LoginList)


        'This function finds the record we do NOT want. Then, it splits the decrypted record into slots in Fields()
        'and returns everything but the login details of the record we did not want. 
        'The returned things get written back into txt file. 



        FillReceptionistGrid()

        FillTextBoxes()


        dgv_ReceptionistDetails.ClearSelection()      'highlights the newly added record
        dgv_ReceptionistDetails.Rows(RowIndex).Selected = True


    End Sub



    Private Sub pbx_BackToAdminControl_Click(sender As Object, e As EventArgs) Handles pbx_BackToMenu.Click

        Me.Visible = False
        ReceptionistAdminControl.Visible = True

        'Hide receptionist details form and revel Rceptionist Admin Control form

    End Sub

    Private Sub pbx_BackToMenu_MouseEnter(sender As Object, e As EventArgs) Handles pbx_BackToMenu.MouseEnter

        pbx_BackToMenu.ImageLocation = MyImages & "BackAdminControl2.png"

        'When the mouse hovers over the button, the second part of the rollover image is shown

    End Sub

    Private Sub pbx_BackToMenu_MouseLeave(sender As Object, e As EventArgs) Handles pbx_BackToMenu.MouseLeave

        pbx_BackToMenu.ImageLocation = MyImages & "BackAdminControl1.png"

        'When the mouse leaves the PicBox after hovering over it, we return to the first half
        'of the rollover image

    End Sub


    Private Sub pic_Help_MouseLeave(sender As Object, e As EventArgs) Handles pic_Help.MouseLeave
        Help.Visible = False


        'If mouse hovers over then leaves the icon, Help form is hidden.

    End Sub


    Private Sub pic_Help_MouseHover(sender As Object, e As EventArgs) Handles pic_Help.MouseHover
        Help.Visible = True
        Help.lbl_helpHeadingEng.Text = "Receptionist Details"
        Help.rtxt_helpInfoEng.Text = "You can only view your own login details. You cannot edit others' details in any way. You are free to change your own data. 

If you are an admin user, you can view/change any user's data as you require."

        Help.lbl_helpHeadingWel.Text = "Manylion Derbynnydd"
        Help.rtxt_helpInfoWel.Text = "Dim ond eich manylion mewngofnodi eich hun y gallwch eu gweld. Ni allwch olygu manylion pobl eraill mewn unrhyw ffordd. Mae croeso i chi newid eich data eich hun.

Os ydych chi'n ddefnyddiwr gweinyddol, gallwch weld/newid data unrhyw ddefnyddiwr yn ôl yr angen."



        'when this specific icon is hovered over, Help form is revealed and text is altered as above to match this situation. 

    End Sub


End Class