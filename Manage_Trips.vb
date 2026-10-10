Imports System.IO
Imports Microsoft.VisualBasic.ApplicationServices

Public Class Manage_Trips


    Dim LastRecord As Integer
    Dim FirstRecord As Integer = 0      'variables to help count amount of records; these are global
    Dim RowIndex As Integer

    Dim NewSchoolTrip As Boolean = False



    'Code below is a function to find a trip using the (aleady sorted in ascending order) Trip ID's.
    'It finds how many trips there are and divides this amount in half.
    'If the ID of the trip is greater than all IDs in one half, it drops this half
    'and looks in the other half. This way, the search range keeps halving 
    'until we find the desired trip or we are left with no more trips to search through,
    'implying it was NOT found. 

    'Time complxit of O(log n)
    Private Function FindTripRowIndexByTripID(targetTripID As Integer) As Integer


        'upper and lower boundss of the range
        Dim lowerSearchBoundIndex As Integer = FirstRecord
        Dim upperSearchBoundIndex As Integer = LastRecord

        While lowerSearchBoundIndex <= upperSearchBoundIndex

            Dim middleRowIndex As Integer =
            (lowerSearchBoundIndex + upperSearchBoundIndex) \ 2

            Dim middleTripID As Integer =
            CInt(dgv_TripDetails.Rows(middleRowIndex).Cells(0).Value)

            If middleTripID = targetTripID Then

                Return middleRowIndex

            ElseIf middleTripID < targetTripID Then

                lowerSearchBoundIndex = middleRowIndex + 1

            Else

                upperSearchBoundIndex = middleRowIndex - 1

            End If

        End While

        Return -1   'if Trip not found

    End Function



    'Checks that a string is not empty or just whitespace
    Private Function IsNotEmpty(value As String) As Boolean

        Return value.Trim() <> ""

    End Function

    Private Function ValidateForm() As Boolean

        'Runs all validation checks for the form
        'Returns True only if ALL fields are valid


        If Not IsNotEmpty(txt_TripName.Text) Then

            MessageBox.Show("Trip name cannot be empty")
            Return False

        End If

        If Not IsNotEmpty(txt_TripLocation.Text) Then

            MessageBox.Show("Trip location cannot be empty")
            Return False

        End If


        If Not IsNotEmpty(txt_CostperPupil.Text) Then
            MessageBox.Show("Cost per pupil cannot be empty")
            Return False
        End If

        Dim cost As Integer

        If Not Integer.TryParse(txt_CostperPupil.Text, cost) Then
            MessageBox.Show("Cost per pupil must be a whole number")
            Return False
        End If

        'ensures a decimal value is not inputted.

        If cost < 0 Then
            MessageBox.Show("Cost per pupil cannot be below £0")
            Return False
        End If

        'cost cannot be negative


        If dtp_TripDate.Value.Date < Today Then
            MessageBox.Show("Trip date cannot be in the past")
            Return False
        End If



        ' Combine date + time to compare properly
        Dim departureDateTime As DateTime = dtp_TripDate.Value.Date + dtp_DepartureTime.Value.TimeOfDay

        Dim arrivalDateTime As DateTime = dtp_TripDate.Value.Date + dtp_ArrivalTime.Value.TimeOfDay

        ' Validate Arrival is after Departure
        If arrivalDateTime <= departureDateTime Then

            MessageBox.Show("Arrival time must be after departure time")

            Return False
        End If

        Return True

    End Function


    Private Sub Manage_Trips_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        GetFiles()

        ApplyBgTheme()

        'Allow background colour changing and extracting text file data to happen in this form


        FillSchoolTripGrid()

        FillTextBoxes()

        CentreForm(Me)


        '2 variables are set as the form's width and form's height respectively. (screenwidth, screenheight)
        'the other 2 variables take the form's boundaries away from the screen's boundaries which gives us the 
        'position of the form on our screen when it loads. Since we divided both sides' widths and heights by 2,
        'the form is exactly in the screen's centre as it loads. Using variables lets us use this code irrespective of 
        'different widths and heights of different forms.


        Me.Text = FormTitle & ": MANAGE SCHOOL TRIPS"


        pbx_Close.ImageLocation = MyImages & "close1.png"
        pbx_First.ImageLocation = MyImages & "FirstTrip1.png"
        pbx_Previous.ImageLocation = MyImages & "PreviousTrip1.png"
        pbx_Next.ImageLocation = MyImages & "NextTrip1.png"
        pbx_Last.ImageLocation = MyImages & "LastTrip1.png"
        pbx_NewTrip.ImageLocation = MyImages & "NewTrip1.png"
        pbx_SaveTrip.ImageLocation = MyImages & "SaveTrip1.png"
        pbx_DeleteTrip.ImageLocation = MyImages & "DeleteTrip1.png"
        pbx_BackToAdmin.ImageLocation = MyImages & "BackAdminControl1.png"
        pbx_SearchTrip.ImageLocation = MyImages & "SearchTrip1.png"
        pic_Help.ImageLocation = MyImages & "help.png"

        'Loads images which are saved in the 'images' folder into each PicBox


    End Sub


    Private Sub ClearTripTextBoxes()


        txt_TripID.Clear()
        txt_TripName.Clear()
        txt_TripLocation.Clear()
        dtp_TripDate.Value = Today
        dtp_DepartureTime.Value = Today.AddHours(9)
        dtp_ArrivalTime.Value = dtp_DepartureTime.Value.AddHours(6.5)
        txt_CostperPupil.Clear()

        'when ran, it clears all textboxes and resets date to today and all others to factory settings

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

        dgv_TripDetails.ClearSelection()

        If dgv_TripDetails.Rows.Count = 0 Then


            LastRecord = -1
            RowIndex = -1
            NewSchoolTrip = True
            ClearTripTextBoxes()

            Exit Sub


        End If

        'Using a StreamReader, we read all lines (records) inside the file and decrypt each line
        'and this decrypted line gets split using the comma terminators. Each splitted data is inserted into a slot 
        'within the Fields() dynamic array and this data is added to each row of the datagrid. This is repeated 
        'all the way to the last line of the txt file. 

        ' Records exist
        FirstRecord = 0
        LastRecord = dgv_TripDetails.Rows.Count - 1
        RowIndex = FirstRecord
        NewSchoolTrip = False

        dgv_TripDetails.Rows(RowIndex).Selected = True

    End Sub



    Private Sub FillTextBoxes()



        If RowIndex < 0 OrElse dgv_TripDetails.Rows.Count = 0 Then
            ClearTripTextBoxes()
            Exit Sub
        End If


        If dgv_TripDetails.Rows.Count > 0 Then
            dgv_TripDetails.Rows(RowIndex).Selected = True
        End If

        'this textbox is filled with the value contained inside the column (cell) 0 on the row which is highlighted. 
        txt_TripID.Text = (dgv_TripDetails.Rows(RowIndex).Cells(0).Value)
        txt_TripName.Text = dgv_TripDetails.Rows(RowIndex).Cells(1).Value
        txt_TripLocation.Text = dgv_TripDetails.Rows(RowIndex).Cells(2).Value

        Dim dobValue As Object = dgv_TripDetails.Rows(RowIndex).Cells(3).Value
        If IsDate(dobValue) Then
            dtp_TripDate.Value = CDate(dobValue)
        Else
            dtp_TripDate.Value = Today
        End If

        dtp_DepartureTime.Value = dgv_TripDetails.Rows(RowIndex).Cells(4).Value
        dtp_ArrivalTime.Value = dgv_TripDetails.Rows(RowIndex).Cells(5).Value
        txt_CostperPupil.Text = dgv_TripDetails.Rows(RowIndex).Cells(6).Value


    End Sub



    Private Sub pbx_First_MouseEnter(sender As Object, e As EventArgs) Handles pbx_First.MouseEnter

        pbx_First.ImageLocation = MyImages & "FirstTrip2.png"

        'When the mouse hovers over the button, the second part of the rollover image is shown


    End Sub

    Private Sub pbx_First_MouseLeave(sender As Object, e As EventArgs) Handles pbx_First.MouseLeave

        pbx_First.ImageLocation = MyImages & "FirstTrip1.png"

        'When the mouse leaves the PicBox after hovering over it, we return to the first half
        'of the rollover image
    End Sub

    Private Sub pbx_First_Click(sender As Object, e As EventArgs) Handles pbx_First.Click

        RowIndex = FirstRecord
        dgv_TripDetails.ClearSelection()


        If RowIndex >= 0 Then

            dgv_TripDetails.Rows(RowIndex).Selected = True

        End If


        FillTextBoxes()

        NewSchoolTrip = False

        'Move the selector to the first record and update text boxes.


    End Sub

    Private Sub pbx_Previous_MouseEnter(sender As Object, e As EventArgs) Handles pbx_Previous.MouseEnter

        pbx_Previous.ImageLocation = MyImages & "PreviousTrip2.png"

        'When the mouse hovers over the button, the second part of the rollover image is shown


    End Sub

    Private Sub pbx_Previous_MouseLeave(sender As Object, e As EventArgs) Handles pbx_Previous.MouseLeave

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


            FillTextBoxes()
            NewSchoolTrip = False


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


            FillTextBoxes()
            NewSchoolTrip = False

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


        FillTextBoxes()
        NewSchoolTrip = False

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

        'Completely close the program.


    End Sub

    Private Sub pbx_NewTrip_MouseEnter(sender As Object, e As EventArgs) Handles pbx_NewTrip.MouseEnter

        pbx_NewTrip.ImageLocation = MyImages & "NewTrip2.png"

        'When the mouse hovers over the button, the second part of the rollover image is shown

    End Sub

    Private Sub pbx_NewTrip_MouseLeave(sender As Object, e As EventArgs) Handles pbx_NewTrip.MouseLeave

        pbx_NewTrip.ImageLocation = MyImages & "NewTrip1.png"

        'When the mouse leaves the PicBox after hovering over it, we return to the first half
        'of the rollover image
    End Sub

    Private Sub pbx_NewTrip_Click(sender As Object, e As EventArgs) Handles pbx_NewTrip.Click


        If ConfirmActions = True Then

            If MsgBox("Are you sure you want to make a new trip?",
                  MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation,
                  "Confirm New Trip") = MsgBoxResult.No Then

                Exit Sub

            End If

        End If

        Dim max As Integer = 0  'first user ID is 1 so we can use 0 in this case
        Dim counter As Integer



        txt_TripID.Clear()
        txt_TripName.Clear()
        txt_TripLocation.Clear()
        dtp_TripDate.Value = Today.Date
        dtp_DepartureTime.Value = dtp_TripDate.Value.Date.AddHours(9)
        dtp_ArrivalTime.Value = dtp_DepartureTime.Value.AddHours(6.5) 'arrival is 6.5hrs ahead of departure as a preset
        txt_CostperPupil.Clear()



        For counter = 0 To LastRecord

            If Val(dgv_TripDetails.Rows(counter).Cells(0).Value) > max Then

                max = Val(dgv_TripDetails.Rows(counter).Cells(0).Value)

            End If

        Next

        txt_TripID.Text = Str(max + 1)      'new Id is generatied. It is original since it is a larger number than the previous ones. 
        NewSchoolTrip = True




    End Sub

    Private Sub pbx_SaveTrip_MouseEnter(sender As Object, e As EventArgs) Handles pbx_SaveTrip.MouseEnter

        pbx_SaveTrip.ImageLocation = MyImages & "SaveTrip2.png"

        'When the mouse hovers over the button, the second part of the rollover image is shown

    End Sub

    Private Sub pbx_SaveTrip_MouseLeave(sender As Object, e As EventArgs) Handles pbx_SaveTrip.MouseLeave

        pbx_SaveTrip.ImageLocation = MyImages & "SaveTrip1.png"

        'When the mouse leaves the PicBox after hovering over it, we return to the first half
        'of the rollover image
    End Sub

    Private Sub pbx_SaveTrip_Click(sender As Object, e As EventArgs) Handles pbx_SaveTrip.Click

        If Not ValidateForm() Then Exit Sub
        'If a SINGLE validation check fails, this procedure doesn't run and a relevant error message appears. 


        If ConfirmActions = True Then

            If MsgBox("Are you sure you want to save this trip?",
                  MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation,
                  "Confirm Save") = MsgBoxResult.No Then

                Exit Sub

            End If

        End If


        Dim counter As Integer
        Dim OneTripRecord As String




        If NewSchoolTrip = True Then  'add new record (if a new user) to end of existing file

            Dim Trip_sw As New StreamWriter(TripDetais_File, True)    'must select true to append and add, NOT FALSE TO OVERWRITE

            OneTripRecord = txt_TripID.Text & ","
            OneTripRecord = OneTripRecord & txt_TripName.Text & ","
            OneTripRecord = OneTripRecord & txt_TripLocation.Text & ","
            OneTripRecord = OneTripRecord & dtp_TripDate.Value & ","
            OneTripRecord = OneTripRecord & dtp_DepartureTime.Value & ","
            OneTripRecord = OneTripRecord & dtp_ArrivalTime.Value & ","
            OneTripRecord = OneTripRecord & txt_CostperPupil.Text & ","



            Trip_sw.WriteLine(XORencrypt(OneTripRecord))



            Trip_sw.Close()



            FillSchoolTripGrid()
            RowIndex = LastRecord
            FillTextBoxes()


            dgv_TripDetails.ClearSelection()      'highlights the newly added record


            If RowIndex >= 0 Then

                dgv_TripDetails.Rows(RowIndex).Selected = True

            End If



        Else



            Dim Trip_sw As New StreamWriter(TripDetais_File, False)   'completely wipes file clean


            For counter = 0 To LastRecord   'loop through each row in datagrid, using sequential FH

                If dgv_TripDetails.Rows(counter).Cells(0).Value <> txt_TripID.Text Then 'this sign means not equal to
                    'copy datagrid row to text file

                    OneTripRecord = dgv_TripDetails.Rows(counter).Cells(0).Value & ","
                    OneTripRecord = OneTripRecord & dgv_TripDetails.Rows(counter).Cells(1).Value & ","
                    OneTripRecord = OneTripRecord & dgv_TripDetails.Rows(counter).Cells(2).Value & ","
                    OneTripRecord = OneTripRecord & dgv_TripDetails.Rows(counter).Cells(3).Value & ","
                    OneTripRecord = OneTripRecord & dgv_TripDetails.Rows(counter).Cells(4).Value & ","
                    OneTripRecord = OneTripRecord & dgv_TripDetails.Rows(counter).Cells(5).Value & ","
                    OneTripRecord = OneTripRecord & dgv_TripDetails.Rows(counter).Cells(6).Value & ","




                    Trip_sw.WriteLine(XORencrypt(OneTripRecord))

                Else
                    'copy text boxes to text file

                    OneTripRecord = txt_TripID.Text & ","
                    OneTripRecord = OneTripRecord & txt_TripName.Text & ","
                    OneTripRecord = OneTripRecord & txt_TripLocation.Text & ","
                    OneTripRecord = OneTripRecord & dtp_TripDate.Value & ","
                    OneTripRecord = OneTripRecord & dtp_DepartureTime.Value & ","
                    OneTripRecord = OneTripRecord & dtp_ArrivalTime.Value & ","
                    OneTripRecord = OneTripRecord & txt_CostperPupil.Text & ","


                    Trip_sw.WriteLine(XORencrypt(OneTripRecord))


                End If

            Next

            Trip_sw.Close()



            FillSchoolTripGrid()

            FillTextBoxes()


            dgv_TripDetails.ClearSelection()      'highlights the newly added record


            If RowIndex >= 0 Then

                dgv_TripDetails.Rows(RowIndex).Selected = True

            End If

        End If


    End Sub

    Private Sub pbx_DeleteTrip_MouseEnter(sender As Object, e As EventArgs) Handles pbx_DeleteTrip.MouseEnter

        pbx_DeleteTrip.ImageLocation = MyImages & "DeleteTrip2.png"

        'When the mouse hovers over the button, the second part of the rollover image is shown

    End Sub

    Private Sub pbx_DeleteTrip_MouseLeave(sender As Object, e As EventArgs) Handles pbx_DeleteTrip.MouseLeave

        pbx_DeleteTrip.ImageLocation = MyImages & "DeleteTrip1.png"

        'When the mouse leaves the PicBox after hovering over it, we return to the first half
        'of the rollover image
    End Sub

    Private Sub pbx_DeleteTrip_Click(sender As Object, e As EventArgs) Handles pbx_DeleteTrip.Click


        If ConfirmActions = True Then

            If MsgBox("Are you sure you want to delete this trip?",
                  MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation,
                  "Confirm Delete") = MsgBoxResult.No Then

                Exit Sub

            End If

        End If

        Dim Trip_sw As New StreamWriter(TripDetais_File, False)   'completely wipes file clean
        Dim OneTripRecord As String
        Dim counter As Integer



        For counter = 0 To LastRecord   'loop through each row in datagrid, using sequential FH

            If counter <> RowIndex Then 'this sign means not equal to
                'copy datagrid row to text file

                OneTripRecord = dgv_TripDetails.Rows(counter).Cells(0).Value & ","
                OneTripRecord = OneTripRecord & dgv_TripDetails.Rows(counter).Cells(1).Value & ","
                OneTripRecord = OneTripRecord & dgv_TripDetails.Rows(counter).Cells(2).Value & ","
                OneTripRecord = OneTripRecord & dgv_TripDetails.Rows(counter).Cells(3).Value & ","
                OneTripRecord = OneTripRecord & dgv_TripDetails.Rows(counter).Cells(4).Value & ","
                OneTripRecord = OneTripRecord & dgv_TripDetails.Rows(counter).Cells(5).Value & ","
                OneTripRecord = OneTripRecord & dgv_TripDetails.Rows(counter).Cells(6).Value & ","



                Trip_sw.WriteLine(XORencrypt(OneTripRecord))

            End If

        Next

        Trip_sw.Close()


        FillSchoolTripGrid()

        If RowIndex > LastRecord Then

            RowIndex = LastRecord

        End If


        FillTextBoxes()


        dgv_TripDetails.ClearSelection()      'highlights the newly added record


        If RowIndex >= 0 Then

            dgv_TripDetails.Rows(RowIndex).Selected = True

        End If

    End Sub

    Private Sub pbx_BackToAdmin_MouseEnter(sender As Object, e As EventArgs) Handles pbx_BackToAdmin.MouseEnter

        pbx_BackToAdmin.ImageLocation = MyImages & "BackAdminControl2.png"

        'When the mouse hovers over the button, the second part of the rollover image is shown


    End Sub

    Private Sub pbx_BackToAdmin_MouseLeave(sender As Object, e As EventArgs) Handles pbx_BackToAdmin.MouseLeave

        pbx_BackToAdmin.ImageLocation = MyImages & "BackAdminControl1.png"

        'When the mouse leaves the PicBox after hovering over it, we return to the first half
        'of the rollover image
    End Sub

    Private Sub pbx_BackToAdmin_Click(sender As Object, e As EventArgs) Handles pbx_BackToAdmin.Click

        Me.Visible = False
        ReceptionistAdminControl.Visible = True

    End Sub



    Private Sub pic_Help_MouseLeave(sender As Object, e As EventArgs) Handles pic_Help.MouseLeave
        Help.Visible = False


        'If mouse hovers over then leaves the icon, Help form is hidden.

    End Sub


    Private Sub pic_Help_MouseHover(sender As Object, e As EventArgs) Handles pic_Help.MouseHover
        Help.Visible = True
        Help.lbl_helpHeadingEng.Text = "Manage Trips"
        Help.rtxt_helpInfoEng.Text = "Create, edit and delete trips for stduents and teachers to take part in."

        Help.lbl_helpHeadingWel.Text = "Rheoli Teithiau"
        Help.rtxt_helpInfoWel.Text = "Creu, golygu a dileu teithiau i fyfyrwyr ac athrawon gymryd rhan ynddynt."


        'when this specific icon is hovered over, Help form is revealed and text is altered as above to match this situation. 

    End Sub

    Private Sub pbx_SearchTrip_MouseEnter(sender As Object, e As EventArgs) Handles pbx_SearchTrip.MouseEnter

        pbx_SearchTrip.ImageLocation = MyImages & "SearchTrip2.png"

        'When the mouse hovers over the button, the second part of the rollover image is shown

    End Sub

    Private Sub pbx_SearchTrip_MouseLeave(sender As Object, e As EventArgs) Handles pbx_SearchTrip.MouseLeave

        pbx_SearchTrip.ImageLocation = MyImages & "SearchTrip1.png"
        'When the mouse leaves the PicBox after hovering over it, we return to the first half
        'of the rollover image

    End Sub

    Private Sub pbx_SearchTrip_Click(sender As Object, e As EventArgs) Handles pbx_SearchTrip.Click

        'Make sure there are actually trips to search for. No trips then skip this sub
        If dgv_TripDetails.Rows.Count = 0 Then

            MsgBox("There are no available trips to search for.")

            Exit Sub

        End If


        'Use InputBox to ask user to enter the trip they want to find. 
        Dim userInput As String = InputBox("Enter the Trip ID to search for:", "Search Trip")

        ' User pressed Cancel or left it blank
        If userInput.Trim() = "" Then Exit Sub

        Dim enteredTripID As Integer


        'ID must be an integer for this to work. below code is validation for this. 
        If Not Integer.TryParse(userInput, enteredTripID) Then

            MsgBox("Trip ID must be a whole number", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Invalid Input")

            Exit Sub

        End If


        'Do the binary search (code for this at top). try to find inputted target. 
        Dim foundRowIndex As Integer = FindTripRowIndexByTripID(enteredTripID)



        'If search fully exhaused and no matches found, search is done. 
        If foundRowIndex = -1 Then

            MsgBox("No trip found with this ID", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Trip not found")

            Exit Sub

        End If

        ' Highlight the found trip
        RowIndex = foundRowIndex
        dgv_TripDetails.ClearSelection()
        dgv_TripDetails.Rows(RowIndex).Selected = True
        dgv_TripDetails.FirstDisplayedScrollingRowIndex = RowIndex

        FillTextBoxes()
        NewSchoolTrip = False


    End Sub

End Class