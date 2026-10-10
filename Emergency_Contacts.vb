Imports System.IO
Imports Microsoft.VisualBasic.ApplicationServices

Public Class Emergency_Contacts

    Dim LastRecord As Integer
    Dim FirstRecord As Integer = 0      'variables to help count amount of records; these are global
    Dim RowIndex As Integer

    Dim NewContact As Boolean = False


    Private Class StudentItem
        Public Property DisplayName As String
        Public Property FullRecord As String

        Public Overrides Function ToString() As String

            Return DisplayName   'this is what ComboBox shows

        End Function

    End Class


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


    'Validates a UK phone number:
    'removes spaces
    'must be exactly 11 digits
    'must start with 01 or 07: makess sure users use this style using a help menu to prevent usage of +44
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

            MessageBox.Show("Contact's surname is invalid")
            Return False

        End If

        If Not IsValidName(txt_name.Text) Then

            MessageBox.Show("Contact's forename is invalid")
            Return False

        End If


        If Not IsNotEmpty(txt_relationship.Text) Then

            MessageBox.Show("What is the contact's relationship with the student? e.g. Father")
            Return False

        End If

        If Not IsValidPostcode(txt_postCode.Text) Then

            MessageBox.Show("Invalid postcode")
            Return False

        End If

        If Not IsValidPhone(txt_phoneNum.Text) Then

            MessageBox.Show("Invalid contact number")
            Return False

        End If


        Return True


    End Function



    Private Sub Emergency_Contacts_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        ApplyBgTheme()

        'Allow background colour changing and extracting text file data to happen in this form

        GetFiles()
        FIllContactGrid()
        FillStudentComboBox()
        FillTextBoxes()
        'Fill the student data grid and fill textboxes with relevant student data to allow it do be modified



        CentreForm(Me)
        '2 variables are set as the form's width and form's height respectively. (screenwidth, screenheight)
        'the other 2 variables take the form's boundaries away from the screen's boundaries which gives us the 
        'position of the form on our screen when it loads. Since we divided both sides' widths and heights by 2,
        'the form is exactly in the screen's centre as it loads. Using variables lets us use this code irrespective of 
        'different widths and heights of different forms.


        Me.Text = FormTitle & ": STUDENT EMERGENCY CONTACT INFORMATION"


        cbox_student.Enabled = False        'When form loads, there should be no text in the multi select box and look empty.


        lbl_EmergencyDetailsQuestion.Hide()
        rad_NoEmergency.Hide()
        rad_YesEmergency.Hide()



        pbx_first.ImageLocation = MyImages & "FirstRecord1.png"
        pbx_PreviousRecord.ImageLocation = MyImages & "PreviousRecord1.png"
        pbx_NextRecord.ImageLocation = MyImages & "NextRecord1.png"
        pbx_LastRecord.ImageLocation = MyImages & "LastRecord1.png"
        pbx_New.ImageLocation = MyImages & "NewEM1.png"
        pbx_Save.ImageLocation = MyImages & "SaveEM1.png"
        pbx_Delete.ImageLocation = MyImages & "DeleteEM1.png"
        pbx_close.ImageLocation = MyImages & "close1.png"
        pbx_MainMenu.ImageLocation = MyImages & "MainMenu1.png"
        pic_Help.ImageLocation = MyImages & "help.png"

        'Loads images which are saved in the 'images' folder into each PicBox


    End Sub



    Private Sub FillContactGrid()

        Dim Emergency_sr As New StreamReader(EmergencyContactInfo_File)


        Dim OneContactRecord As String
        Dim Fields() As String
        Dim OneContactRecordDecrypted As String


        dgv_emergencyContacts.Rows.Clear()



        While Emergency_sr.Peek() >= 0

            OneContactRecord = Emergency_sr.ReadLine
            OneContactRecordDecrypted = XORencrypt(OneContactRecord)



            Fields = OneContactRecordDecrypted.Split(",")       'adding fields to the dynamic array

            dgv_emergencyContacts.Rows.Add(Fields)

        End While

        Emergency_sr.Close()

        'Using a StreamReader, we read all lines (records) inside EmergencyContactInfo_File and decrypt each line
        'and this decrypted line gets split using the comma terminators. Each splitted data is inserted into a slot 
        'within the Fields() dynamic array and this data is added to each row of the datagrid. This is repeated 
        'all the way to the last line of the txt file. 


        dgv_emergencyContacts.ClearSelection()  'removes the blue highlight from cells



        dgv_emergencyContacts.Rows(FirstRecord).Selected = True 'look at line 0 (first line). This row needs to be selected.

        RowIndex = FirstRecord
        NewContact = False
        LastRecord = dgv_emergencyContacts.Rows.Count - 1

    End Sub



    Private Sub FillStudentComboBox()

        Dim Student_sr As New StreamReader(Students_File)
        Dim EncryptedLine As String
        Dim DecryptedLine As String
        Dim Fields() As String

        cbox_student.Items.Clear()

        While Student_sr.Peek() >= 0

            EncryptedLine = Student_sr.ReadLine()
            DecryptedLine = XORencrypt(EncryptedLine)
            Fields = DecryptedLine.Split(",")

            Dim item As New StudentItem With {
                .DisplayName = Fields(1) & ", " & Fields(2),
                .FullRecord = DecryptedLine
            }

            cbox_student.Items.Add(item)

        End While

        Student_sr.Close()

    End Sub

    'In this sub, each record gets split up into individual fields for each record.
    'When the drop box gets selected, the second and third field get inserted into the drop down options. 


    Private Sub FillTextBoxes()

        If dgv_emergencyContacts.Rows.Count > 0 Then
            dgv_emergencyContacts.Rows(RowIndex).Selected = True
        End If

        'this textbox is filled with the value contained inside the column (cell) 0 on the row which is highlighted. 
        txt_emergencyID.Text = (dgv_emergencyContacts.Rows(RowIndex).Cells(0).Value)
        txt_surname.Text = dgv_emergencyContacts.Rows(RowIndex).Cells(1).Value
        txt_name.Text = dgv_emergencyContacts.Rows(RowIndex).Cells(2).Value
        txt_accessLevel.Text = dgv_emergencyContacts.Rows(RowIndex).Cells(3).Value
        txt_phoneNum.Text = dgv_emergencyContacts.Rows(RowIndex).Cells(4).Value
        txt_postCode.Text = dgv_emergencyContacts.Rows(RowIndex).Cells(5).Value
        txt_relationship.Text = dgv_emergencyContacts.Rows(RowIndex).Cells(6).Value


        If cbox_student.SelectedIndex = -1 Then Exit Sub   'If no records in DGV, do not fill text boxes. This lets the form load despite no records. 

        'Each textbox gets filled with data located in each row of the datagrid if there are more than 0 rows in the DGV.


    End Sub



    Private Sub cmd_MainMenu_Click(sender As Object, e As EventArgs)

        Me.Visible = False
        MAIN_MENU.Visible = True


        'Hide this form and reveal the Main Menu.
    End Sub

    Private Sub cmd_close_Click(sender As Object, e As EventArgs)

        Application.Exit()

        'Completely close the entire program

    End Sub

    Private Sub cbox_student_SelectedValueChanged(sender As Object, e As EventArgs) Handles cbox_student.SelectedValueChanged

        If cbox_student.SelectedIndex = -1 Then Exit Sub

        ' Cast the selected item back to StudentItem
        Dim selectedItem As StudentItem = CType(cbox_student.SelectedItem, StudentItem)

        ' Get the FULL original record
        Dim Fields() As String = selectedItem.FullRecord.Split(",")


        txt_accessLevel.Text = Fields(9)
        txt_emergencyID.Text = Fields(12)

        'When a user selects a student's record from the Combo Box, the record gets split into fields using the commas as
        'separators. The selected record's fields 9 and 12 are copied into the corresponding text boxes.


    End Sub


    Private Sub rad_YesEmergency_CheckedChanged(sender As Object, e As EventArgs) Handles rad_YesEmergency.CheckedChanged

        lbl_name.Show()
        txt_name.Show()

        lbl_surname.Show()
        txt_surname.Show()

        lbl_phoneNum.Show()
        txt_phoneNum.Show()

        lbl_postCode.Show()
        txt_postCode.Show()

        lbl_relationship.Show()
        txt_relationship.Show()

        'When we switch this button on, the labels and textboxes to allow the user to input
        'a stduent's emergency contact details will appear. If we do not have any details,
        'we can still save the student, just without an emergency contact.

    End Sub

    Private Sub rad_NoEmergency_CheckedChanged(sender As Object, e As EventArgs) Handles rad_NoEmergency.CheckedChanged

        lbl_name.Hide()
        txt_name.Hide()

        lbl_surname.Hide()
        txt_surname.Hide()

        lbl_phoneNum.Hide()
        txt_phoneNum.Hide()

        lbl_postCode.Hide()
        txt_postCode.Hide()

        lbl_relationship.Hide()
        txt_relationship.Hide()

        'Conversely, when No is clicked, these buttons and labels are hidden if there are no contacts. 

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
        dgv_emergencyContacts.ClearSelection()

        dgv_emergencyContacts.Rows(RowIndex).Selected = True


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


            dgv_emergencyContacts.ClearSelection()

            dgv_emergencyContacts.Rows(RowIndex).Selected = True


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


            dgv_emergencyContacts.ClearSelection()

            dgv_emergencyContacts.Rows(RowIndex).Selected = True


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
        dgv_emergencyContacts.ClearSelection()

        dgv_emergencyContacts.Rows(RowIndex).Selected = True


        FillTextBoxes()

        'Move the selector to the last record and update text boxes.

    End Sub

    Private Sub pbx_New_MouseEnter(sender As Object, e As EventArgs) Handles pbx_New.MouseEnter

        pbx_New.ImageLocation = MyImages & "NewEM2.png"

        'When the mouse hovers over the button, the second part of the rollover image is shown

    End Sub

    Private Sub pbx_New_MouseLeave(sender As Object, e As EventArgs) Handles pbx_New.MouseLeave

        pbx_New.ImageLocation = MyImages & "NewEM1.png"

        'When the mouse leaves the PicBox after hovering over it, we return to the first half
        'of the rollover image
    End Sub

    Private Sub pbx_New_Click(sender As Object, e As EventArgs) Handles pbx_New.Click

        If ConfirmActions = True Then

            If MsgBox("Are you sure you want to create a new emergency contact for a student?",
                  MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation,
                  "Confirm Delete") = MsgBoxResult.No Then

                Exit Sub

            End If

        End If

        Dim max As Integer = 0  'first user ID is 1 so we can use 0 in this case
        Dim counter As Integer


        lbl_EmergencyDetailsQuestion.Visible = True
        rad_YesEmergency.Visible = True
        rad_NoEmergency.Visible = True

        lbl_name.Hide()
        txt_name.Hide()

        lbl_surname.Hide()
        txt_surname.Hide()

        lbl_phoneNum.Hide()
        txt_phoneNum.Hide()

        lbl_postCode.Hide()
        txt_postCode.Hide()

        lbl_relationship.Hide()
        txt_relationship.Hide()

        txt_emergencyID.Clear()
        txt_name.Clear()
        txt_surname.Clear()
        txt_phoneNum.Clear()
        txt_postCode.Clear()
        txt_relationship.Clear()
        txt_accessLevel.Clear()

        'All textboxes get cleared, ready for new user's details to be shown.


        cbox_student.Enabled = True
        cbox_student.SelectedIndex = -1
        cbox_student.Text = ""

        'Whe new is selected, only then is the combo box open to be edited. It has no text when new is pressed. 

        For counter = 0 To LastRecord

            If Val(dgv_emergencyContacts.Rows(counter).Cells(0).Value) > max Then

                max = Val(dgv_emergencyContacts.Rows(counter).Cells(0).Value)

            End If

        Next


        NewContact = True

    End Sub

    Private Sub pbx_Save_MouseEnter(sender As Object, e As EventArgs) Handles pbx_Save.MouseEnter

        pbx_Save.ImageLocation = MyImages & "SaveEM2.png"

        'When the mouse hovers over the button, the second part of the rollover image is shown


    End Sub

    Private Sub pbx_Save_MouseLeave(sender As Object, e As EventArgs) Handles pbx_Save.MouseLeave

        pbx_Save.ImageLocation = MyImages & "SaveEM1.png"

        'When the mouse leaves the PicBox after hovering over it, we return to the first half
        'of the rollover image

    End Sub

    Private Sub pbx_Save_Click(sender As Object, e As EventArgs) Handles pbx_Save.Click

        If Not ValidateForm() Then Exit Sub
        'If a SINGLE validation check fails, this procedure doesn't run and a relevant error message appears. 

        If ConfirmActions = True Then

            If MsgBox("Are you sure you want to save this emergency contact for a student?",
                  MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation,
                  "Confirm Delete") = MsgBoxResult.No Then

                Exit Sub

            End If

        End If



        Dim counter As Integer
        Dim OneEmergencyRecord As String


        lbl_EmergencyDetailsQuestion.Hide()
        rad_NoEmergency.Hide()
        rad_YesEmergency.Hide()

        cbox_student.SelectedIndex = -1
        cbox_student.Text = ""
        cbox_student.Enabled = False


        If NewContact = True Then  'add new record (if a new user) to end of existing file

            Dim Emergency_sw As New StreamWriter(EmergencyContactInfo_File, True)    'must select true to append and add, NOT FALSE TO OVERWRITE

            OneEmergencyRecord = txt_emergencyID.Text & ","
            OneEmergencyRecord = OneEmergencyRecord & txt_surname.Text & ","
            OneEmergencyRecord = OneEmergencyRecord & txt_name.Text & ","
            OneEmergencyRecord = OneEmergencyRecord & txt_accessLevel.Text & ","
            OneEmergencyRecord = OneEmergencyRecord & txt_phoneNum.Text & ","
            OneEmergencyRecord = OneEmergencyRecord & txt_postCode.Text & ","
            OneEmergencyRecord = OneEmergencyRecord & txt_relationship.Text


            Emergency_sw.WriteLine(XORencrypt(OneEmergencyRecord))



            Emergency_sw.Close()

            'Fill OneEmergencyRecord with all data inputted into textboxes in the same order separated by commas
            'and encrypt this and write it into the text file. Close the StreamReader to avoid problems like corruption. 

            FillContactGrid()
            RowIndex = LastRecord


            dgv_emergencyContacts.ClearSelection()      'highlights the newly added record
            dgv_emergencyContacts.Rows(LastRecord).Selected = True



        Else



            Dim Emergency_sw As New StreamWriter(EmergencyContactInfo_File, False)   'completely wipes file clean


            For counter = 0 To LastRecord   'loop through each row in datagrid, using sequential FH

                If dgv_emergencyContacts.Rows(counter).Cells(0).Value <> txt_emergencyID.Text Then 'this sign means not equal to
                    'copy datagrid row to text file

                    OneEmergencyRecord = dgv_emergencyContacts.Rows(counter).Cells(0).Value & ","
                    OneEmergencyRecord = OneEmergencyRecord & dgv_emergencyContacts.Rows(counter).Cells(1).Value & ","
                    OneEmergencyRecord = OneEmergencyRecord & dgv_emergencyContacts.Rows(counter).Cells(2).Value & ","
                    OneEmergencyRecord = OneEmergencyRecord & dgv_emergencyContacts.Rows(counter).Cells(3).Value & ","
                    OneEmergencyRecord = OneEmergencyRecord & dgv_emergencyContacts.Rows(counter).Cells(4).Value & ","
                    OneEmergencyRecord = OneEmergencyRecord & dgv_emergencyContacts.Rows(counter).Cells(5).Value & ","
                    OneEmergencyRecord = OneEmergencyRecord & dgv_emergencyContacts.Rows(counter).Cells(6).Value




                    Emergency_sw.WriteLine(XORencrypt(OneEmergencyRecord))

                    'OneEmergencyRecord is filled with data from each row in the dgv, separated by commas.
                    'This is repeated until the last record and this overwrites the current Student text file

                Else
                    'copy text boxes to text file

                    OneEmergencyRecord = txt_emergencyID.Text & ","
                    OneEmergencyRecord = OneEmergencyRecord & txt_surname.Text & ","
                    OneEmergencyRecord = OneEmergencyRecord & txt_name.Text & ","
                    OneEmergencyRecord = OneEmergencyRecord & txt_accessLevel.Text & ","
                    OneEmergencyRecord = OneEmergencyRecord & txt_phoneNum.Text & ","
                    OneEmergencyRecord = OneEmergencyRecord & txt_postCode.Text & ","
                    OneEmergencyRecord = OneEmergencyRecord & txt_relationship.Text


                    Emergency_sw.WriteLine(XORencrypt(OneEmergencyRecord))

                    'when the counter identifies the record which equals the rowIndex (finds the record which needed
                    'appending) it writes this data into the relevant text files. 


                End If

            Next

            Emergency_sw.Close()


            FillContactGrid()



            dgv_emergencyContacts.ClearSelection()      'highlights the newly added record
            dgv_emergencyContacts.Rows(FirstRecord).Selected = True

        End If

        NewContact = False


    End Sub

    Private Sub pbx_Delete_MouseEnter(sender As Object, e As EventArgs) Handles pbx_Delete.MouseEnter

        pbx_Delete.ImageLocation = MyImages & "DeleteEM2.png"

        'When the mouse hovers over the button, the second part of the rollover image is shown


    End Sub

    Private Sub pbx_Delete_MouseLeave(sender As Object, e As EventArgs) Handles pbx_Delete.MouseLeave

        pbx_Delete.ImageLocation = MyImages & "DeleteEM1.png"

        'When the mouse leaves the PicBox after hovering over it, we return to the first half
        'of the rollover image

    End Sub

    Private Sub pbx_Delete_Click(sender As Object, e As EventArgs) Handles pbx_Delete.Click


        If ConfirmActions = True Then

            If MsgBox("Are you sure you want to create delete this emergency contact?",
                  MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation,
                  "Confirm Delete") = MsgBoxResult.No Then

                Exit Sub

            End If

        End If


        Dim Emergency_sw As New StreamWriter(EmergencyContactInfo_File, False)   'completely wipes file clean
        Dim OneEmergencyRecord As String
        Dim counter As Integer



        For counter = 0 To LastRecord   'loop through each row in datagrid, using sequential FH

            If counter <> RowIndex Then 'this sign means not equal to
                'copy datagrid row to text file

                OneEmergencyRecord = dgv_emergencyContacts.Rows(counter).Cells(0).Value & ","
                OneEmergencyRecord = OneEmergencyRecord & dgv_emergencyContacts.Rows(counter).Cells(1).Value & ","
                OneEmergencyRecord = OneEmergencyRecord & dgv_emergencyContacts.Rows(counter).Cells(2).Value & ","
                OneEmergencyRecord = OneEmergencyRecord & dgv_emergencyContacts.Rows(counter).Cells(3).Value & ","
                OneEmergencyRecord = OneEmergencyRecord & dgv_emergencyContacts.Rows(counter).Cells(4).Value & ","
                OneEmergencyRecord = OneEmergencyRecord & dgv_emergencyContacts.Rows(counter).Cells(5).Value & ","
                OneEmergencyRecord = OneEmergencyRecord & dgv_emergencyContacts.Rows(counter).Cells(6).Value


                Emergency_sw.WriteLine(XORencrypt(OneEmergencyRecord))

            End If

        Next

        Emergency_sw.Close()


        'This is the same process as saving a record if NewContact = False since we are overwriting the file
        'and writing it without the record we wanted to delete. 



        FillContactGrid()



        dgv_emergencyContacts.ClearSelection()      'highlights the newly added record
        dgv_emergencyContacts.Rows(RowIndex).Selected = True


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

    Private Sub pbx_close_Click(sender As Object, e As EventArgs) Handles pbx_close.Click

        If ConfirmActions = True Then

            If MsgBox("Are you sure you want to close the system?",
                  MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation,
                  "Confirm Action") = MsgBoxResult.No Then

                Exit Sub

            End If

        End If

        Application.Exit()

        'Completely close the program.

    End Sub


    Private Sub pbx_MainMenu_MouseEnter(sender As Object, e As EventArgs) Handles pbx_MainMenu.MouseEnter

        pbx_MainMenu.ImageLocation = MyImages & "MainMenu2.png"

        'When the mouse hovers over the button, the second part of the rollover image is shown


    End Sub

    Private Sub pbx_MainMenu_Click(sender As Object, e As EventArgs) Handles pbx_MainMenu.Click

        Me.Visible = False
        MAIN_MENU.Visible = True

        'Hide this form and reveal the Main Menu. 

    End Sub

    Private Sub pbx_MainMenu_MouseLeave(sender As Object, e As EventArgs) Handles pbx_MainMenu.MouseLeave

        pbx_MainMenu.ImageLocation = MyImages & "MainMenu1.png"


        'When the mouse leaves the PicBox after hovering over it, we return to the first half
        'of the rollover image
    End Sub



    Private Sub pic_Help_MouseLeave(sender As Object, e As EventArgs) Handles pic_Help.MouseLeave
        Help.Visible = False


        'If mouse hovers over then leaves the icon, Help form is hidden.

    End Sub


    Private Sub pic_Help_MouseHover(sender As Object, e As EventArgs) Handles pic_Help.MouseHover
        Help.Visible = True
        Help.lbl_helpHeadingEng.Text = "Emergency Contact for a student"
        Help.rtxt_helpInfoEng.Text = "Each student gets ONE emergency contact. Input the emergency contact's details. Student's details are pre-filled. A student can only be selected from the drop-down box when new is clicked."

        Help.lbl_helpHeadingWel.Text = "Cyswllt Brys ar gyfer myfyriwr"
        Help.rtxt_helpInfoWel.Text = "Mae pob myfyriwr yn cael UN cyswllt brys. Mewnbynnwch fanylion y cyswllt brys. Mae manylion y myfyriwr wedi'u llenwi ymlaen llaw. Dim ond pan gliciwch ar newydd y gellir dewis myfyriwr o'r blwch ostwng."


        'when this specific icon is hovered over, Help form is revealed and text is altered as above to match this situation. 

    End Sub




End Class