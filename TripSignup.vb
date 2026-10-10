Imports System.IO

Public Class TripSignup

    Dim LastRecord As Integer
    Dim FirstRecord As Integer = 0      'variables to help count amount of records; these are global
    Dim RowIndex As Integer



    Private Sub TripSignup_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        GetFiles()


        ApplyBgTheme()
        'Allow background colour changing and extracting text file data to happen in this form



        FillSchoolTripGrid()


        CentreForm(Me)


        '2 variables are set as the form's width and form's height respectively. (screenwidth, screenheight)
        'the other 2 variables take the form's boundaries away from the screen's boundaries which gives us the 
        'position of the form on our screen when it loads. Since we divided both sides' widths and heights by 2,
        'the form is exactly in the screen's centre as it loads. Using variables lets us use this code irrespective of 
        'different widths and heights of different forms.





        GetFiles()

        Me.Text = FormTitle & ": TRIP SIGNUP"



        cbox_SortOptions.Items.Clear()


        cbox_SortOptions.Items.Add("Trip Name")
        cbox_SortOptions.Items.Add("Date")
        cbox_SortOptions.Items.Add("Location")
        cbox_SortOptions.SelectedIndex = 0 ' default

        'When this form loads, the Multi select box is filled with the options for the ways data can be sorted. By default, it is filled with 'Trip Name. 


        pbx_first.ImageLocation = MyImages & "FirstRecord1.png"
        pbx_PreviousRecord.ImageLocation = MyImages & "PreviousRecord1.png"
        pbx_NextRecord.ImageLocation = MyImages & "NextRecord1.png"
        pbx_LastRecord.ImageLocation = MyImages & "LastRecord1.png"
        pbx_SignUp.ImageLocation = MyImages & "SignUp1.png"
        pbx_RemoveSignUp.ImageLocation = MyImages & "RemoveMe1.png"
        pbx_close.ImageLocation = MyImages & "close1.png"
        pbx_back.ImageLocation = MyImages & "MainMenu1.png"
        pic_Help.ImageLocation = MyImages & "help.png"

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



    End Sub





    Private Sub FillSchoolTripGrid()

        Dim Trip_sr As New StreamReader(TripDetais_File)


        Dim OneTripRecord As String
        Dim Fields() As String
        Dim OneTripRecordDecrypted As String


        dgv_TripDetails.Rows.Clear()



        While Trip_sr.Peek() >= 0

            OneTripRecord = Trip_sr.ReadLine
            OneTripRecordDecrypted = XORencrypt(OneTripRecord)



            Fields = OneTripRecordDecrypted.Split(",")       'adding fields to the dynamic array

            dgv_TripDetails.Rows.Add(Fields)

        End While

        Trip_sr.Close()


        'Using a StreamReader, we read all lines (records) inside TripDetais_File and decrypt each line
        'and this decrypted line gets split using the comma terminators. Each splitted data is inserted into a slot 
        'within the Fields() dynamic array and this data is added to each row of the datagrid. This is repeated 
        'all the way to the last line of the txt file. 


        dgv_TripDetails.ClearSelection()

        If dgv_TripDetails.Rows.Count = 0 Then


            LastRecord = -1
            RowIndex = -1

            Exit Sub


        End If

        'Records exist even if none have been made so the form can still run and not crash the program.

        FirstRecord = 0
        LastRecord = dgv_TripDetails.Rows.Count - 1
        RowIndex = FirstRecord

        dgv_TripDetails.Rows(RowIndex).Selected = True



        For Each DgvColumn As DataGridViewColumn In dgv_TripDetails.Columns
            DgvColumn.SortMode = DataGridViewColumnSortMode.NotSortable
        Next





    End Sub



    'For the Merge Sort

    'Merge Sort works by:
    'Splitting the array into smaller halves
    'Sorting each half
    'Merging the halves back together in the correct order

    Private Sub MergeSortTrips(ByRef TripRows() As DataGridViewRow, ByVal LeftIndex As Integer, ByVal RightIndex As Integer, ByVal SortColumnIndex As Integer)

        'Only happen if the array contains more than 1 item. Otherwise, no need to sort anything.

        If LeftIndex < RightIndex Then

            Dim MiddleIndex As Integer = (LeftIndex + RightIndex) \ 2       'Find middle item


            'Via recursion, sort the left half and right half, these halves were separated by the middle item.
            MergeSortTrips(TripRows, LeftIndex, MiddleIndex, SortColumnIndex)
            MergeSortTrips(TripRows, MiddleIndex + 1, RightIndex, SortColumnIndex)

            'Join sorted halves together.
            MergeTrips(TripRows, LeftIndex, MiddleIndex, RightIndex, SortColumnIndex)

        End If

    End Sub


    Private Sub MergeTrips(ByRef TripRows() As DataGridViewRow, ByVal LeftIndex As Integer, ByVal MiddleIndex As Integer, ByVal RightIndex As Integer, ByVal SortColumnIndex As Integer)


        'Work out the size of the two temporary arrays, put this size into the variables

        Dim LeftArraySize As Integer = MiddleIndex - LeftIndex + 1
        Dim RightArraySize As Integer = RightIndex - MiddleIndex


        'Create temporary arrays to store each haf

        Dim LeftTripRows(LeftArraySize - 1) As DataGridViewRow
        Dim RightTripRows(RightArraySize - 1) As DataGridViewRow


        'Copy data into the left temporary array

        For LeftCounter As Integer = 0 To LeftArraySize - 1

            LeftTripRows(LeftCounter) = TripRows(LeftIndex + LeftCounter)

        Next


        'Copy data into the right temporary array

        For RightCounter As Integer = 0 To RightArraySize - 1

            RightTripRows(RightCounter) = TripRows(MiddleIndex + 1 + RightCounter)

        Next

        Dim LeftPointer As Integer = 0
        Dim RightPointer As Integer = 0
        Dim MainPointer As Integer = LeftIndex


        'Compare values from both arrays and insert them in order

        While LeftPointer < LeftArraySize AndAlso RightPointer < RightArraySize



            'Get the values from the left and right arrays for the current row and column

            Dim LeftCellValue = LeftTripRows(LeftPointer).Cells(SortColumnIndex).Value
            Dim RightCellValue = RightTripRows(RightPointer).Cells(SortColumnIndex).Value


            'Check if we are sorting the Date column (index 2) and both values are valid dates

            If SortColumnIndex = 3 AndAlso IsDate(LeftCellValue) AndAlso IsDate(RightCellValue) Then


                'Compare the two dates. CDates allows me to compare numbers

                If CDate(LeftCellValue) <= CDate(RightCellValue) Then

                    TripRows(MainPointer) = LeftTripRows(LeftPointer)
                    LeftPointer += 1

                Else

                    TripRows(MainPointer) = RightTripRows(RightPointer)
                    RightPointer += 1

                End If

            Else

                'If not a date column or either value isn't a valid date, compare as strings
                'This keeps alphabetical sorting for Trip Name, Location, etc.

                If LeftCellValue.ToString() <= RightCellValue.ToString() Then

                    TripRows(MainPointer) = LeftTripRows(LeftPointer)
                    LeftPointer += 1

                Else

                    TripRows(MainPointer) = RightTripRows(RightPointer)
                    RightPointer += 1

                End If

            End If


            'Move main pointer forward for the next slot in the merged array

            MainPointer += 1

        End While


        'Add any remaining items from the left array

        While LeftPointer < LeftArraySize

            TripRows(MainPointer) = LeftTripRows(LeftPointer)
            LeftPointer += 1
            MainPointer += 1

        End While


        'Add any remaining items from the right array

        While RightPointer < RightArraySize

            TripRows(MainPointer) = RightTripRows(RightPointer)
            RightPointer += 1
            MainPointer += 1

        End While


    End Sub



    Private Sub cmd_BackToStudentDetails_Click(sender As Object, e As EventArgs)

        Me.Visible = False
        MAIN_MENU.Visible = True

        'Hides the current form and reveals the Stduent Details Form
    End Sub

    Private Sub cmd_close_Click(sender As Object, e As EventArgs)

        Application.Exit()

        'Completely closes the program

    End Sub



    Private Sub cbox_SortOptions_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbox_SortOptions.SelectedIndexChanged

        'This event runs whenever the user selects a different
        'sorting option from the combo box.

        'The selected option determines which column
        'the trips will be sorted by.



        Dim SortColumnIndex As Integer

        Select Case cbox_SortOptions.SelectedItem.ToString()

            Case "Trip Name"

                SortColumnIndex = 1

            Case "Date"

                SortColumnIndex = 3

            Case "Location"

                SortColumnIndex = 2

            Case Else

                Exit Sub

        End Select


        'Case statements are like multiple IF statements put into one block of code. The data is sorted using the column headings in ascending order
        'based on which option in the Combo Box is selected.


        'Copy all rows from the DataGridView into an array
        'This is required because Merge Sort works on arrays, not directly on DataGridViews.

        Dim TripRowArray(dgv_TripDetails.Rows.Count - 1) As DataGridViewRow

        For RowCounter As Integer = 0 To dgv_TripDetails.Rows.Count - 1

            TripRowArray(RowCounter) = dgv_TripDetails.Rows(RowCounter)

        Next


        'Perform merge sort on the array
        MergeSortTrips(TripRowArray, 0, TripRowArray.Length - 1, SortColumnIndex)


        'Clear grid and reinsert sorted rows
        dgv_TripDetails.Rows.Clear()


        'add the sorted rows back into the DataGridView


        For Each SortedRow As DataGridViewRow In TripRowArray

            dgv_TripDetails.Rows.Add(SortedRow.Cells.Cast(Of DataGridViewCell).
                                 Select(Function(Cell) Cell.Value).ToArray())

        Next



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
        dgv_TripDetails.ClearSelection()

        dgv_TripDetails.Rows(RowIndex).Selected = True



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


            dgv_TripDetails.ClearSelection()

            dgv_TripDetails.Rows(RowIndex).Selected = True





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


            dgv_TripDetails.ClearSelection()

            dgv_TripDetails.Rows(RowIndex).Selected = True




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
        dgv_TripDetails.ClearSelection()

        dgv_TripDetails.Rows(RowIndex).Selected = True



        'Move the selector to the last record and update text boxes.

    End Sub

    Private Sub pbx_SignUp_MouseEnter(sender As Object, e As EventArgs) Handles pbx_SignUp.MouseEnter

        pbx_SignUp.ImageLocation = MyImages & "SignUp2.png"

        'When the mouse hovers over the button, the second part of the rollover image is shown

    End Sub

    Private Sub pbx_SignUp_MouseLeave(sender As Object, e As EventArgs) Handles pbx_SignUp.MouseLeave

        pbx_SignUp.ImageLocation = MyImages & "SignUp1.png"

        'When the mouse leaves the PicBox after hovering over it, we return to the first half
        'of the rollover image

    End Sub

    Private Sub pbx_SignUp_Click(sender As Object, e As EventArgs) Handles pbx_SignUp.Click


        If ConfirmActions = True Then

            If MsgBox("Are you sure you want to sign up to this trip?",
                  MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation,
                  "Confirm Signup") = MsgBoxResult.No Then

                Exit Sub

            End If

        End If

        Dim TripID As String
        Dim StudentID As String = LoginID_Global
        Dim TripIsSupervised As Boolean = False


        'variables needed for signup
        'TripID = selected trip
        'StudentID = logged in student
        'TripIsSupervised = used to check teacher assignment



        If dgv_TripDetails.SelectedRows.Count = 0 Then

            MsgBox("Please select a trip to sign up for.")
            Exit Sub

        End If



        'Get the selected trip row
        Dim SelectedRow As DataGridViewRow = dgv_TripDetails.SelectedRows(0)

        'Check if the trip date has already passed
        Dim TripDate As Date

        If Not Date.TryParse(SelectedRow.Cells(3).Value, TripDate) Then

            MsgBox("Trip date is invalid. Cannot sign up.")
            Exit Sub

        End If

        If TripDate < Date.Today Then

            MsgBox("This trip has already taken place. You cannot sign up.")
            Exit Sub
        End If







        TripID = SelectedRow.Cells(0).Value

        'make sure a trip is actually selected but if not, stop here so nothing breaks



        'Check trip is supervised (TeacherID exists in TripDetails file)

        For Each line As String In File.ReadAllLines(TripDetais_File)

            Dim DecryptedBookingRecord As String = XORencrypt(line)

            Dim fields() As String = DecryptedBookingRecord.Split(",")



            If fields(0) = TripID AndAlso fields(1) <> "" Then

                TripIsSupervised = True

                Exit For

            End If



        Next


        'check if the trip is supervised
        'look through TripDetails file. if a teacherID exists for this trip, allow signup



        If TripIsSupervised = False Then

            MsgBox("This trip has not been supervised yet. Try again later.")
            Exit Sub

        End If

        'if no teacher assigned, student cannot sign up




        Dim BookingID As String = ""


        For Each line As String In File.ReadAllLines(TripBookings_File)


            Dim DecryptedBookingRecord As String = XORencrypt(line)
            Dim fields() As String = DecryptedBookingRecord.Split(",")

            'search TripBookings file to match TripID



            If fields.Length >= 3 AndAlso fields(2) = TripID Then

                BookingID = fields(0)

                Exit For

            End If

        Next

        If BookingID = "" Then

            MsgBox("This trip does not have a supervising teacher yet. Try again later")
            Exit Sub

        End If


        'if no booking exists, trip still isn't ready




        'Load existing enrolments
        Dim EnrolmentLines As New List(Of String)


        If File.Exists(TripEnrolment_File) Then

            EnrolmentLines.AddRange(File.ReadAllLines(TripEnrolment_File))

        End If

        'Check for duplicate signup
        For Each line As String In EnrolmentLines


            Dim DecryptedEnrolmentRecord As String = XORencrypt(line)
            Dim fields() As String = DecryptedEnrolmentRecord.Split(",")

            'BookingID, StudentID is the order of the saved text file fields
            If fields.Length >= 2 AndAlso fields(0) = BookingID AndAlso fields(1) = StudentID Then

                MsgBox("You are already signed up for this trip.")
                Exit Sub

            End If


        Next

        'check student isn't already signed up



        'Add student to enrolment file
        Dim NewEnrolment As String = BookingID & "," & StudentID
        EnrolmentLines.Add(XORencrypt(NewEnrolment))
        File.WriteAllLines(TripEnrolment_File, EnrolmentLines)

        MsgBox("You have successfully signed up for this trip.")

        'add new enrolment to file
        'bookingID + studentID, then encrypt and save


    End Sub

    Private Sub cmd_RemoveSignUp_MouseEnter(sender As Object, e As EventArgs) Handles pbx_RemoveSignUp.MouseEnter

        pbx_RemoveSignUp.ImageLocation = MyImages & "RemoveMe2.png"

        'When the mouse hovers over the button, the second part of the rollover image is shown

    End Sub

    Private Sub pbx_RemoveSignUp_MouseLeave(sender As Object, e As EventArgs) Handles pbx_RemoveSignUp.MouseLeave

        pbx_RemoveSignUp.ImageLocation = MyImages & "RemoveMe1.png"

        'When the mouse leaves the PicBox after hovering over it, we return to the first half
        'of the rollover image

    End Sub

    Private Sub pbx_RemoveSignUp_Click(sender As Object, e As EventArgs) Handles pbx_RemoveSignUp.Click

        If ConfirmActions = True Then

            If MsgBox("Are you sure you want to remove yourself from this trip?",
                  MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation,
                  "Confirm Signup Removal") = MsgBoxResult.No Then

                Exit Sub

            End If

        End If

        Dim StudentID As String = LoginID_Global
        Dim BookingID As String = ""



        If dgv_TripDetails.SelectedRows.Count = 0 Then

            MsgBox("Please select a trip to unsign from.")
            Exit Sub


        End If


        'make sure a trip is selected first
        'otherwise there is nothing to remove


        Dim TripID As String = dgv_TripDetails.SelectedRows(0).Cells(0).Value.ToString()

        'Find BookingID for the selected trip
        If File.Exists(TripBookings_File) Then

            For Each line As String In File.ReadAllLines(TripBookings_File)

                Dim DecryptedTripRecord As String = XORencrypt(line)

                Dim fields() As String = DecryptedTripRecord.Split(",") 'BookingID, TeacherID, TripID

                If fields.Length >= 3 AndAlso fields(2) = TripID Then

                    BookingID = fields(0)

                    Exit For

                End If

            Next

        End If


        'find bookingID for the selected trip
        'look through TripBookings file and match TripID




        If BookingID = "" Then

            MsgBox("This trip is not supervised yet. You cannot remove yourself from this trip. You were never signed up to it.")

            Exit Sub

        End If


        'if no bookingID was found
        'trip was never supervised or student was never enrolled


        'Load enrolments
        Dim EnrolmentLines As New List(Of String)

        If File.Exists(TripEnrolment_File) Then

            EnrolmentLines.AddRange(File.ReadAllLines(TripEnrolment_File))

        End If



        'load all enrolments from file needed so we can search and remove the correct onev



        'Find the line to remove
        Dim EnrolmentFound As Boolean = False

        For EnrolmentCount As Integer = EnrolmentLines.Count - 1 To 0 Step -1


            Dim DecryptedEnrolmentRecord As String = XORencrypt(EnrolmentLines(EnrolmentCount))

            Dim fields() As String = DecryptedEnrolmentRecord.Split(",") 'BookingID, StudentID

            If fields.Length >= 2 AndAlso fields(0) = BookingID AndAlso fields(1) = StudentID Then

                EnrolmentLines.RemoveAt(EnrolmentCount)

                EnrolmentFound = True

            End If


        Next


        'look for the student's enrolment
        'loop backwards so we can safely remove lines


        If EnrolmentFound = True Then

            File.WriteAllLines(TripEnrolment_File, EnrolmentLines)

            MsgBox("You have successfully unsigned from this trip.")

        Else

            MsgBox("You are not signed up for this trip.")

        End If


        'if enrolment was found, save changes
        'otherwise tell student they were not signed up



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

        'Comletely close the program

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

        'Hide student details form and reval Main Menu form.

    End Sub



    Private Sub pic_Help_MouseLeave(sender As Object, e As EventArgs) Handles pic_Help.MouseLeave
        Help.Visible = False


        'If mouse hovers over then leaves the icon, Help form is hidden.

    End Sub


    Private Sub pic_Help_MouseHover(sender As Object, e As EventArgs) Handles pic_Help.MouseHover
        Help.Visible = True
        Help.lbl_helpHeadingEng.Text = "Sign up to a trip"
        Help.rtxt_helpInfoEng.Text = "Students can sign themselves up or remove themseves for a trip. You can sign youself up to unlimited trips."

        Help.lbl_helpHeadingWel.Text = "Cofrestrwch ar gyfer taith"
        Help.rtxt_helpInfoWel.Text = "Gall myfyrwyr gofrestru eu hunain neu dynnu eu henwau allan o drip. Gallwch gofrestru eich hun ar gyfer teithiau diderfyn."


        'when this specific icon is hovered over, Help form is revealed and text is altered as above to match this situation. 

    End Sub



End Class





