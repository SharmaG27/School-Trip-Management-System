Imports System.IO

Public Class TripSupervise

    Dim LastRecord As Integer
    Dim FirstRecord As Integer = 0      'variables to help count amount of records; these are global
    Dim RowIndex As Integer


    Private Sub TripSupervise_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        GetFiles()

        ApplyBgTheme()

        'Allow background colour changing and extracting text file data to happen in this form


        FillSchoolTripGrid()

        'Fill the schooltrip grid and fill textboxes with relevant student data to allow it do be modified


        LoadEnroledStudents()

        CentreForm(Me)


        '2 variables are set as the form's width and form's height respectively. (screenwidth, screenheight)
        'the other 2 variables take the form's boundaries away from the screen's boundaries which gives us the 
        'position of the form on our screen when it loads. Since we divided both sides' widths and heights by 2,
        'the form is exactly in the screen's centre as it loads. Using variables lets us use this code irrespective of 
        'different widths and heights of different forms.



        Me.Text = FormTitle & ": SUPERVISE A TRIP"


        pbx_first.ImageLocation = MyImages & "FirstTrip1.png"
        pbx_Next.ImageLocation = MyImages & "NextTrip1.png"
        pbx_Previous.ImageLocation = MyImages & "PreviousTrip1.png"
        pbx_Last.ImageLocation = MyImages & "LastTrip1.png"
        pbx_close.ImageLocation = MyImages & "close1.png"
        pbx_supervise.ImageLocation = MyImages & "Supervise1.png"
        pbx_back.ImageLocation = MyImages & "BackTeacher1.png"
        pic_Help.ImageLocation = MyImages & "help.png"

        'Loads images which are saved in the 'images' folder into each PicBox



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

        'Using a StreamReader, we read all lines (records) inside Stduent_File and decrypt each line
        'and this decrypted line gets split using the comma terminators. Each splitted data is inserted into a slot 
        'within the Fields() dynamic array and this data is added to each row of the datagrid. This is repeated 
        'all the way to the last line of the txt file. 


        dgv_TripDetails.ClearSelection()

        If dgv_TripDetails.Rows.Count = 0 Then


            LastRecord = -1
            RowIndex = -1

            Exit Sub


        End If

        'If there are no records, give these 2 variables values which still allow the form to actually load.

        FirstRecord = 0
        LastRecord = dgv_TripDetails.Rows.Count - 1
        RowIndex = FirstRecord

        dgv_TripDetails.Rows(RowIndex).Selected = True

    End Sub



    Private Sub dgv_TripDetails_SelectionChanged(sender As Object, e As EventArgs) Handles dgv_TripDetails.SelectionChanged

        LoadEnroledStudents()

        'every time a different trip is selcted on the DGV, run the sub below

    End Sub




    Private Sub LoadEnroledStudents()


        dgv_TripStudents.Rows.Clear()

        If dgv_TripDetails.SelectedRows.Count = 0 Then Exit Sub


        Dim TripID As String = dgv_TripDetails.SelectedRows(0).Cells(0).Value.ToString()
        Dim BookingID As String = ""
        Dim TeacherID As String = ""
        Dim TeacherName As String = ""





        ' Find BookingID for this trip
        If File.Exists(TripBookings_File) Then
            For Each line As String In File.ReadAllLines(TripBookings_File)

                Dim DecryptedBookingRecord As String = XORencrypt(line)
                Dim fields() As String = DecryptedBookingRecord.Split(",")

                ' BookingID, TeacherID, TripID
                If fields.Length >= 3 AndAlso fields(2) = TripID Then

                    BookingID = fields(0)
                    TeacherID = fields(1)
                    Exit For

                End If

            Next

        End If


        'STAGE 1: FIND THE BOOKING LINKED TO THE SELECTED TRIP
        ' ----------------------------------------------------------
        'Each trip must have a booking before students can be
        'enrolled. This stage above searches the TripBookings file to
        'find the BookingID and TeacherID linked to the selected
        'TripID.




        If BookingID = "" Then Exit Sub 'Trip not supervised yet so no students will be shown.




        'Find Teacher Name
        If File.Exists(Teachers_File) Then

            For Each line As String In File.ReadAllLines(Teachers_File)

                Dim DecryptedTeacherRecord As String = XORencrypt(line)

                Dim fields() As String = DecryptedTeacherRecord.Split(",")  'teacherID, surname, forename

                If fields.Length >= 3 AndAlso fields(0) = TeacherID Then

                    TeacherName = fields(2) & " " & fields(1)   'Forename + Surname

                    Exit For

                End If

            Next

        End If


        'STAGE 2: FIND THE TEACHER NAME USING THE TEACHER ID
        '---------------------------------------------------------
        'Once the TeacherID is known, this stage looks up the
        'teacher's forename and surname so it can be displayed
        'alongside each enrolled student.





        'Load enrolled students
        If File.Exists(TripEnrolment_File) Then

            For Each line As String In File.ReadAllLines(TripEnrolment_File)

                Dim DecryptedEnrolmentRecord As String = XORencrypt(line)

                Dim fields() As String = DecryptedEnrolmentRecord.Split(",")

                'BookingID, StudentID
                If fields.Length >= 2 AndAlso fields(0) = BookingID Then

                    Dim StudentID As String = fields(1)


                    'Look up student surname and forename from Students_File
                    Dim StudentSurname As String = ""

                    Dim StudentForename As String = ""




                    'STAGE 3: LOAD ALL STUDENTS ENROLLED ON THIS BOOKING
                    '----------------------------------------------------------
                    'This stage loops through the enrolment file to find all
                    'students linked to the BookingID, then looks up each
                    'student's name before adding them to the DataGridView.





                    If File.Exists(Students_File) Then

                        For Each studentLine As String In File.ReadAllLines(Students_File)

                            Dim studentDecrypted As String = XORencrypt(studentLine)
                            Dim studentFields() As String = studentDecrypted.Split(",")

                            ' studentID(0), surname(1), forename(2)
                            If studentFields.Length >= 3 AndAlso studentFields(0) = StudentID Then

                                StudentSurname = studentFields(1)
                                StudentForename = studentFields(2)

                                Exit For

                            End If

                        Next

                    End If

                    dgv_TripStudents.Rows.Add(StudentID, StudentSurname, StudentForename, TeacherName)

                End If

            Next

        End If


        'STAGE 4: LOOK UP STUDENT DETAILS
        '--------------------------------------------------
        'Uses the StudentID to find the student's surname and forename from the Students file.



    End Sub

    Private Sub pbx_first_MouseEnter(sender As Object, e As EventArgs) Handles pbx_first.MouseEnter

        pbx_first.ImageLocation = MyImages & "FirstTrip2.png"

        'When the mouse hovers over the button, the second part of the rollover image is shown

    End Sub

    Private Sub pbx_first_MouseLeave(sender As Object, e As EventArgs) Handles pbx_first.MouseLeave

        pbx_first.ImageLocation = MyImages & "FirstTrip1.png"

        'When the mouse leaves the PicBox after hovering over it, we return to the first half
        'of the rollover image

    End Sub

    Private Sub pbx_first_Click(sender As Object, e As EventArgs) Handles pbx_first.Click

        RowIndex = FirstRecord
        dgv_TripDetails.ClearSelection()


        If RowIndex >= 0 Then

            dgv_TripDetails.Rows(RowIndex).Selected = True

        End If

        'Move the selector to the first record and update text boxes.

    End Sub

    Private Sub pbx_Previous_MouseEnter(sender As Object, e As EventArgs) Handles pbx_Previous.MouseEnter

        pbx_Previous.ImageLocation = MyImages & "PreviousTrip2.png"

        'When the mouse hovers over the button, the second part of the rollover image is shown


    End Sub

    Private Sub cmd_previous_MouseLeave(sender As Object, e As EventArgs) Handles pbx_Previous.MouseLeave

        pbx_Previous.ImageLocation = MyImages & "PreviousTrip1.png"

        'When the mouse leaves the PicBox after hovering over it, we return to the first half
        'of the rollover image

    End Sub

    Private Sub pbx_Previous_Click(sender As Object, e As EventArgs) Handles pbx_Previous.Click


        If RowIndex > FirstRecord Then
            RowIndex -= 1


            dgv_TripDetails.ClearSelection()

            If RowIndex >= 0 Then

                dgv_TripDetails.Rows(RowIndex).Selected = True

            End If



        End If


        'Move selector to previous one above. 
        'Happens when index of current row is larger than index of First record. 

    End Sub

    Private Sub pbx_Next_MouseEnter(sender As Object, e As EventArgs) Handles pbx_Next.MouseEnter

        pbx_Next.ImageLocation = MyImages & "NextTrip2.png"

        'When the mouse hovers over the button, the second part of the rollover image is shown


    End Sub

    Private Sub pbx_Next_MouseLeave(sender As Object, e As EventArgs) Handles pbx_Next.MouseLeave

        pbx_Next.ImageLocation = MyImages & "NextTrip1.png"

        'When the mouse leaves the PicBox after hovering over it, we return to the first half
        'of the rollover image

    End Sub

    Private Sub pbx_Next_Click(sender As Object, e As EventArgs) Handles pbx_Next.Click

        If RowIndex < LastRecord Then
            RowIndex = RowIndex + 1


            dgv_TripDetails.ClearSelection()

            If RowIndex >= 0 Then

                dgv_TripDetails.Rows(RowIndex).Selected = True

            End If


        End If


        'Move the selector to the next record down and update text boxes.
        'Only happens when the index of row we are on is less than the index of the last record.


    End Sub

    Private Sub pbx_Last_MouseEnter(sender As Object, e As EventArgs) Handles pbx_Last.MouseEnter

        pbx_Last.ImageLocation = MyImages & "LastTrip2.png"

        'When the mouse hovers over the button, the second part of the rollover image is shown

    End Sub

    Private Sub pbx_Last_MouseLeave(sender As Object, e As EventArgs) Handles pbx_Last.MouseLeave

        pbx_Last.ImageLocation = MyImages & "LastTrip1.png"

        'When the mouse leaves the PicBox after hovering over it, we return to the first half
        'of the rollover image

    End Sub

    Private Sub pbx_Last_Click(sender As Object, e As EventArgs) Handles pbx_Last.Click


        RowIndex = LastRecord
        dgv_TripDetails.ClearSelection()

        If RowIndex >= 0 Then

            dgv_TripDetails.Rows(RowIndex).Selected = True

        End If

        'Move the selector to the last record and update text boxes.


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
        'Close the program completely 

    End Sub

    Private Sub pbx_supervise_MouseEnter(sender As Object, e As EventArgs) Handles pbx_supervise.MouseEnter

        pbx_supervise.ImageLocation = MyImages & "Supervise2.png"

        'When the mouse hovers over the button, the second part of the rollover image is shown


    End Sub

    Private Sub pbx_supervise_MouseLeave(sender As Object, e As EventArgs) Handles pbx_supervise.MouseLeave

        pbx_supervise.ImageLocation = MyImages & "Supervise1.png"

        'When the mouse leaves the PicBox after hovering over it, we return to the first half
        'of the rollover image

    End Sub

    Private Sub pbx_supervise_Click(sender As Object, e As EventArgs) Handles pbx_supervise.Click


        If ConfirmActions = True Then

            If MsgBox("Are you sure you want to supervise this trip? This decision cannot be changed later.",
                  MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation,
                  "Confirm Delete") = MsgBoxResult.No Then

                Exit Sub

            End If

        End If

        Dim BookingID As Integer = 1

        Dim TeacherID As String = LoginID_Global        'Using teacher's ID from their UserLogin file details which we got when the user logs in



        If File.Exists(TripBookings_File) Then


            Dim AllBookingRecords() As String = File.ReadAllLines(TripBookings_File)

            If AllBookingRecords.Length > 0 Then


                Dim LastBookingRecord As String = XORencrypt(AllBookingRecords(AllBookingRecords.Length - 1))
                Dim LastFields() As String = LastBookingRecord.Split(",")
                BookingID = CInt(LastFields(0)) + 1  ' first field = BookingID


            End If


        End If

        'extracts the first field in a record (Booking ID) to see if there is one at all.
        'If there is, we increment new booking ID by one. If no records, it is initialised to bookingID = 1




        If dgv_TripDetails.SelectedRows.Count = 0 Then

            MsgBox("Please select a trip to supervise.")
            Exit Sub

        End If


        Dim TripID As String = dgv_TripDetails.SelectedRows(0).Cells(0).Value.ToString()    'Getting TripID from the first column of the DGV



        If File.Exists(TripBookings_File) Then

            For Each line As String In File.ReadAllLines(TripBookings_File)

                Dim decrypted As String = XORencrypt(line)
                Dim fields() As String = decrypted.Split(",")

                ' BookingID, TeacherID, TripID
                If fields.Length >= 3 AndAlso fields(2) = TripID Then

                    MsgBox("This trip is already supervised and cannot be supervised again.")
                    Exit Sub

                End If

            Next

        End If




        Dim OneCreatedBookingRecord As String = BookingID & "," & TeacherID & "," & TripID

        Dim EncryptedOneCreatedBookingRecord As String = XORencrypt(OneCreatedBookingRecord)

        'write the booking record whihc has booking id, teacher id, trip id. 




        Dim Booking_sr As New StreamWriter(TripBookings_File, True)

        Booking_sr.WriteLine(EncryptedOneCreatedBookingRecord)

        Booking_sr.Close()

        MsgBox("You have successfully supervised this trip.")


    End Sub

    Private Sub pbx_back_MouseEnter(sender As Object, e As EventArgs) Handles pbx_back.MouseEnter

        pbx_back.ImageLocation = MyImages & "BackTeacher2.png"

        'When the mouse hovers over the button, the second part of the rollover image is shown


    End Sub

    Private Sub pbx_back_MouseLeave(sender As Object, e As EventArgs) Handles pbx_back.MouseLeave

        pbx_back.ImageLocation = MyImages & "BackTeacher1.png"

        'When the mouse leaves the PicBox after hovering over it, we return to the first half
        'of the rollover image

    End Sub

    Private Sub pbx_back_Click(sender As Object, e As EventArgs) Handles pbx_back.Click

        Me.Visible = False
        TeacherDetails.Visible = True

        'Make this form invisible and reveal the Teacher Details form again.



    End Sub



    Private Sub pic_Help_MouseLeave(sender As Object, e As EventArgs) Handles pic_Help.MouseLeave
        Help.Visible = False


        'If mouse hovers over then leaves the icon, Help form is hidden.

    End Sub


    Private Sub pic_Help_MouseHover(sender As Object, e As EventArgs) Handles pic_Help.MouseHover
        Help.Visible = True
        Help.lbl_helpHeadingEng.Text = "Supervise a Trip"
        Help.rtxt_helpInfoEng.Text = "Supervise a trip. Search through the trips and choose. NOTE: THIS ACTION CANNOT BE UNDONE."

        Help.lbl_helpHeadingWel.Text = "Goruchwylio Taith"
        Help.rtxt_helpInfoWel.Text = "Goruchwylio taith. Chwiliwch drwy'r teithiau a dewiswch. NODYN: NI ELIR DADDWNEUD Y WEITHRED HON.
"


        'when this specific icon is hovered over, Help form is revealed and text is altered as above to match this situation. 

    End Sub


End Class