Imports System.IO
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports Microsoft.VisualBasic.ApplicationServices

Public Class Medical_Info



    Dim LastRecord As Integer
    Dim FirstRecord As Integer = 0      'variables to help count amount of records; these are global
    Dim RowIndex As Integer

    Dim NewUser As Boolean = False




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

    Private Function ValidateForm() As Boolean

        'Runs all validation checks for the form
        'Returns True only if ALL fields are valid


        If Not IsNotEmpty(txt_medication.Text) Then

            MessageBox.Show("What medication does the student require?")
            Return False

        End If

        If Not IsNotEmpty(txt_conditions.Text) Then

            MessageBox.Show("Fill in any conditions.")
            Return False

        End If


        Return True

    End Function



    'In the comboBox, we can scroll through every student's data which is extracted right from 
    'Students_File. When a student is clicked, that student's medicalID, name and access level 
    'is displayed onto the DGV. Then, the teacher/receptionist can add in any medication or conditions.
    'When the editor clicks save, all the data in textboxes gets saved onto MedicalInfo_File. 

    'in dgv, have data from medical_File. only 'student' CBox has data from students_file. 


    Private Sub Medical_Info_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ApplyBgTheme()

        'Allow background colour changing and extracting text file data to happen in this form



        GetFiles()
        FIllMedicalGrid()
        FillStudentComboBox()
        FillTextBoxes()

        'Fill the student data grid and fill textboxes with relevant student data to allow it do be modified



        CentreForm(Me)


        '2 variables are set as the form's width and form's height respectively. (screenwidth, screenheight)
        'the other 2 variables take the form's boundaries away from the screen's boundaries which gives us the 
        'position of the form on our screen when it loads. Since we divided both sides' widths and heights by 2,
        'the form is exactly in the screen's centre as it loads. Using variables lets us use this code irrespective of 
        'different widths and heights of different forms.


        Me.Text = FormTitle & ": STUDENT MEDICAL INFORMATION"

        cbox_student.Enabled = False


        lbl_MedicalDetailsQuestion.Hide()
        rad_NoMedical.Hide()
        rad_YesMedical.Hide()


        pbx_first.ImageLocation = MyImages & "FirstRecord1.png"
        pbx_PreviousRecord.ImageLocation = MyImages & "PreviousRecord1.png"
        pbx_NextRecord.ImageLocation = MyImages & "NextRecord1.png"
        pbx_LastRecord.ImageLocation = MyImages & "LastRecord1.png"
        pbx_New.ImageLocation = MyImages & "NewMed1.png"
        pbx_Save.ImageLocation = MyImages & "SaveMed1.png"
        pbx_Delete.ImageLocation = MyImages & "DeleteMed1.png"
        pbx_close.ImageLocation = MyImages & "close1.png"
        pbx_MainMenu.ImageLocation = MyImages & "MainMenu1.png"
        pic_Help.ImageLocation = MyImages & "help.png"

        'Loads images which are saved in the 'images' folder into each PicBox


    End Sub


    Private Sub FIllMedicalGrid()


        Dim Medical_sr As New StreamReader(MedicalInfo_File)


        Dim OneMedicalRecord As String
        Dim Fields() As String
        Dim OneMedicalRecordDecrypted As String


        dgv_Medical.Rows.Clear()



        While Medical_sr.Peek() >= 0

            OneMedicalRecord = Medical_sr.ReadLine
            OneMedicalRecordDecrypted = XORencrypt(OneMedicalRecord)



            Fields = OneMedicalRecordDecrypted.Split(",")       'adding fields to the dynamic array

            dgv_Medical.Rows.Add(Fields)

        End While

        Medical_sr.Close()

        'Using a StreamReader, we read all lines (records) inside MedicalInfo_File and decrypt each line
        'and this decrypted line gets split using the comma terminators. Each splitted data is inserted into a slot 
        'within the Fields() dynamic array and this data is added to each row of the datagrid. This is repeated 
        'all the way to the last line of the txt file. 


        dgv_Medical.ClearSelection()  'removes the blue highlight from cells



        dgv_Medical.Rows(FirstRecord).Selected = True 'look at line 0 (first line). This row needs to be selected.

        RowIndex = FirstRecord
        NewUser = False
        LastRecord = dgv_Medical.Rows.Count - 1


    End Sub



    Private Sub FillStudentComboBox()

        'In this sub, each record gets split up into individual fields for each record.
        'When the drop box gets selected, the second and third field get inserted into the drop down options. 

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
                .DisplayName = Fields(1) & ", " & Fields(2), 'Surname, Name
                .FullRecord = DecryptedLine
            }

            cbox_student.Items.Add(item)

        End While

        Student_sr.Close()

    End Sub


    Private Sub FillTextBoxes()


        If dgv_Medical.Rows.Count > 0 Then
            dgv_Medical.Rows(RowIndex).Selected = True
        End If

        'this textbox is filled with the value contained inside the column (cell) 0 on the row which is highlighted. 
        txt_MedicalID.Text = (dgv_Medical.Rows(RowIndex).Cells(0).Value)
        txt_surname.Text = dgv_Medical.Rows(RowIndex).Cells(1).Value
        txt_name.Text = dgv_Medical.Rows(RowIndex).Cells(2).Value
        txt_accessLevel.Text = dgv_Medical.Rows(RowIndex).Cells(3).Value
        txt_medication.Text = dgv_Medical.Rows(RowIndex).Cells(4).Value
        txt_conditions.Text = dgv_Medical.Rows(RowIndex).Cells(5).Value

        If cbox_student.SelectedIndex = -1 Then Exit Sub           'If no records in DGV, do not fill text boxes. This lets the form load despite no records. 


        'Each textbox gets filled with data located in each row of the datagrid if there are more than 0 rows in the DGV.




    End Sub



    Private Sub cbox_student_SelectedValueChanged(sender As Object, e As EventArgs) Handles cbox_student.SelectedValueChanged

        If cbox_student.SelectedIndex = -1 Then Exit Sub

        ' Cast the selected item back to StudentItem
        Dim selectedItem As StudentItem = CType(cbox_student.SelectedItem, StudentItem)

        ' Get the FULL original record
        Dim Fields() As String = selectedItem.FullRecord.Split(",")

        txt_name.Text = Fields(2)
        txt_surname.Text = Fields(1)
        txt_accessLevel.Text = Fields(9)
        txt_MedicalID.Text = Fields(13)


        'When a user selects a student's record from the Combo Box, the record gets split into fields using the commas as
        'separators. The selected record's fields are copied into the corresponding text boxes.
    End Sub



    Private Sub rad_YesMedical_CheckedChanged(sender As Object, e As EventArgs) Handles rad_YesMedical.CheckedChanged

        lbl_medication.Show()
        txt_medication.Show()

        lbl_conditions.Show()
        txt_conditions.Show()

        'When we switch this button on, the labels and textboxes to allow the user to input
        'a stduent's medical  details will appear. If we do not have any details,
        'we can still save the student, just without an emergency contact.

    End Sub

    Private Sub rad_NoMedical_CheckedChanged(sender As Object, e As EventArgs) Handles rad_NoMedical.CheckedChanged

        lbl_medication.Hide()
        txt_medication.Hide()

        lbl_conditions.Hide()
        txt_conditions.Hide()


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
        dgv_Medical.ClearSelection()

        dgv_Medical.Rows(RowIndex).Selected = True


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


            dgv_Medical.ClearSelection()

            dgv_Medical.Rows(RowIndex).Selected = True


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


            dgv_Medical.ClearSelection()

            dgv_Medical.Rows(RowIndex).Selected = True


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
        dgv_Medical.ClearSelection()

        dgv_Medical.Rows(RowIndex).Selected = True


        FillTextBoxes()

        'Move the selector to the last record and update text boxes.

    End Sub

    Private Sub pbx_New_Click(sender As Object, e As EventArgs) Handles pbx_New.Click

        If ConfirmActions = True Then

            If MsgBox("Are you sure you want to create a new student medical record?",
                  MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation,
                  "Confirm Delete") = MsgBoxResult.No Then

                Exit Sub

            End If

        End If

        Dim max As Integer = 0  'first user ID is 1 so we can use 0 in this case
        Dim counter As Integer


        lbl_MedicalDetailsQuestion.Visible = True
        rad_YesMedical.Visible = True
        rad_NoMedical.Visible = True

        lbl_medication.Hide()
        txt_medication.Hide()

        lbl_conditions.Hide()
        txt_conditions.Hide()

        txt_medication.Clear()
        txt_conditions.Clear()
        txt_name.Clear()
        txt_surname.Clear()
        txt_MedicalID.Clear()
        txt_accessLevel.Clear()

        'All textboxes get cleared, ready for new user's details to be shown.

        cbox_student.Enabled = True

        cbox_student.SelectedIndex = -1
        cbox_student.Text = ""

        'Whe new is selected, only then is the combo box open to be edited. It has no text when new is pressed. 


        For counter = 0 To LastRecord

            If Val(dgv_Medical.Rows(counter).Cells(0).Value) > max Then

                max = Val(dgv_Medical.Rows(counter).Cells(0).Value)

            End If

        Next




        NewUser = True

    End Sub

    Private Sub pbx_New_MouseEnter(sender As Object, e As EventArgs) Handles pbx_New.MouseEnter

        pbx_New.ImageLocation = MyImages & "NewMed2.png"

        'When the mouse hovers over the button, the second part of the rollover image is shown


    End Sub

    Private Sub pbx_New_MouseLeave(sender As Object, e As EventArgs) Handles pbx_New.MouseLeave

        pbx_New.ImageLocation = MyImages & "NewMed1.png"

        'When the mouse leaves the PicBox after hovering over it, we return to the first half
        'of the rollover image

    End Sub

    Private Sub pbx_Save_MouseEnter(sender As Object, e As EventArgs) Handles pbx_Save.MouseEnter

        pbx_Save.ImageLocation = MyImages & "SaveMed2.png"

        'When the mouse hovers over the button, the second part of the rollover image is shown


    End Sub

    Private Sub pbx_Save_MouseLeave(sender As Object, e As EventArgs) Handles pbx_Save.MouseLeave

        pbx_Save.ImageLocation = MyImages & "SaveMed1.png"

        'When the mouse leaves the PicBox after hovering over it, we return to the first half
        'of the rollover image

    End Sub

    Private Sub pbx_Save_Click(sender As Object, e As EventArgs) Handles pbx_Save.Click


        If ConfirmActions = True Then

            If MsgBox("Are you sure you want to save this student medical record?",
                  MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation,
                  "Confirm Delete") = MsgBoxResult.No Then

                Exit Sub

            End If

        End If

        If Not ValidateForm() Then Exit Sub
        'If a SINGLE validation check fails, this procedure doesn't run and a relevant error message appears. 


        Dim counter As Integer
        Dim OneMedicalRecord As String
        Dim Updated As Boolean = False


        lbl_MedicalDetailsQuestion.Hide()
        rad_NoMedical.Hide()
        rad_YesMedical.Hide()

        cbox_student.SelectedIndex = -1
        cbox_student.Text = ""
        cbox_student.Enabled = False


        If NewUser = True Then  'add new record (if a new user) to end of existing file

            Dim Medical_sw As New StreamWriter(MedicalInfo_File, True)    'must select true to append and add, NOT FALSE TO OVERWRITE

            OneMedicalRecord = txt_MedicalID.Text & ","
            OneMedicalRecord = OneMedicalRecord & txt_surname.Text & ","
            OneMedicalRecord = OneMedicalRecord & txt_name.Text & ","
            OneMedicalRecord = OneMedicalRecord & txt_accessLevel.Text & ","
            OneMedicalRecord = OneMedicalRecord & txt_medication.Text & ","
            OneMedicalRecord = OneMedicalRecord & txt_conditions.Text

            Medical_sw.WriteLine(XORencrypt(OneMedicalRecord))



            Medical_sw.Close()

            'Fill OneMedicalRecord with all data inputted into textboxes in the same order separated by commas
            'and encrypt this and write it into the text file. Close the StreamReader to avoid problems like corruption. 

            FIllMedicalGrid()
            RowIndex = LastRecord


            dgv_Medical.ClearSelection()      'highlights the newly added record
            dgv_Medical.Rows(LastRecord).Selected = True




        Else




            Dim Medical_sw As New StreamWriter(MedicalInfo_File, False)   'completely wipes file clean


            For counter = 0 To LastRecord   'loop through each row in datagrid, using sequential FH

                If dgv_Medical.Rows(counter).Cells(0).Value <> txt_MedicalID.Text Then 'this sign means not equal to
                    'copy datagrid row to text file

                    OneMedicalRecord = dgv_Medical.Rows(counter).Cells(0).Value & ","
                    OneMedicalRecord = OneMedicalRecord & dgv_Medical.Rows(counter).Cells(1).Value & ","
                    OneMedicalRecord = OneMedicalRecord & dgv_Medical.Rows(counter).Cells(2).Value & ","
                    OneMedicalRecord = OneMedicalRecord & dgv_Medical.Rows(counter).Cells(3).Value & ","
                    OneMedicalRecord = OneMedicalRecord & dgv_Medical.Rows(counter).Cells(4).Value & ","
                    OneMedicalRecord = OneMedicalRecord & dgv_Medical.Rows(counter).Cells(5).Value



                    Medical_sw.WriteLine(XORencrypt(OneMedicalRecord))

                    'OneMedicalRecord is filled with data from each row in the dgv, separated by commas.
                    'This is repeated until the last record and this overwrites the current Student text file


                Else
                    'copy text boxes to text file

                    OneMedicalRecord = txt_MedicalID.Text & ","
                    OneMedicalRecord = OneMedicalRecord & txt_surname.Text & ","
                    OneMedicalRecord = OneMedicalRecord & txt_name.Text & ","
                    OneMedicalRecord = OneMedicalRecord & txt_accessLevel.Text & ","
                    OneMedicalRecord = OneMedicalRecord & txt_medication.Text & ","
                    OneMedicalRecord = OneMedicalRecord & txt_conditions.Text

                    Medical_sw.WriteLine(XORencrypt(OneMedicalRecord))

                    'when the counter identifies the record which equals the rowIndex (finds the record which needed
                    'appending) it writes this data into the relevant text files. 



                End If

            Next

            Medical_sw.Close()


            FIllMedicalGrid()



            dgv_Medical.ClearSelection()      'highlights the newly added record
            dgv_Medical.Rows(FirstRecord).Selected = True

        End If


    End Sub

    Private Sub pbx_Delete_MouseEnter(sender As Object, e As EventArgs) Handles pbx_Delete.MouseEnter

        pbx_Delete.ImageLocation = MyImages & "DeleteMed2.png"

        'When the mouse hovers over the button, the second part of the rollover image is shown


    End Sub

    Private Sub pbx_Delete_MouseLeave(sender As Object, e As EventArgs) Handles pbx_Delete.MouseLeave

        pbx_Delete.ImageLocation = MyImages & "DeleteMed1.png"

        'When the mouse leaves the PicBox after hovering over it, we return to the first half
        'of the rollover image

    End Sub

    Private Sub pbx_Delete_Click(sender As Object, e As EventArgs) Handles pbx_Delete.Click


        If ConfirmActions = True Then

            If MsgBox("Are you sure you want to delete this medical student record?",
                  MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation,
                  "Confirm Delete") = MsgBoxResult.No Then

                Exit Sub

            End If

        End If

        Dim Medical_sw As New StreamWriter(MedicalInfo_File, False)   'completely wipes file clean
        Dim OneMedicalRecord As String
        Dim counter As Integer



        For counter = 0 To LastRecord   'loop through each row in datagrid, using sequential FH

            If counter <> RowIndex Then 'this sign means not equal to
                'copy datagrid row to text file

                OneMedicalRecord = dgv_Medical.Rows(counter).Cells(0).Value & ","
                OneMedicalRecord = OneMedicalRecord & dgv_Medical.Rows(counter).Cells(1).Value & ","
                OneMedicalRecord = OneMedicalRecord & dgv_Medical.Rows(counter).Cells(2).Value & ","
                OneMedicalRecord = OneMedicalRecord & dgv_Medical.Rows(counter).Cells(3).Value & ","
                OneMedicalRecord = OneMedicalRecord & dgv_Medical.Rows(counter).Cells(4).Value & ","
                OneMedicalRecord = OneMedicalRecord & dgv_Medical.Rows(counter).Cells(5).Value


                Medical_sw.WriteLine(XORencrypt(OneMedicalRecord))

            End If

        Next

        Medical_sw.Close()

        'This is the same process as saving a record if NewUser = False since we are overwriting the file
        'and writing it without the record we wanted to delete. 

        FIllMedicalGrid()



        dgv_Medical.ClearSelection()      'highlights the newly added record
        dgv_Medical.Rows(RowIndex).Selected = True

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
        Help.lbl_helpHeadingEng.Text = "Student Medical Details"
        Help.rtxt_helpInfoEng.Text = "You can only select a student when 'new record' is pressed. This is so that there is only one record per student."

        Help.lbl_helpHeadingWel.Text = "Manylion Meddygol Myfyriwr"
        Help.rtxt_helpInfoWel.Text = "Dim ond pan fyddwch chi'n pwyso 'cofnod newydd' y gallwch chi ddewis myfyriwr. Mae hyn fel mai dim ond un cofnod sydd i bob myfyriwr."


        'when this specific icon is hovered over, Help form is revealed and text is altered as above to match this situation. 

    End Sub





End Class