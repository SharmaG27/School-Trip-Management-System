Imports System.IO


Public Class TripInformation

    Private _CalendarInfo As MonthlyCalendarInfo


    Private Sub TripInformation_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        'Allow background colour changing and extracting text file data to happen in this form
        ApplyBgTheme()

        CentreForm(Me)



        '2 variables are set as the form's width and form's height respectively. (screenwidth, screenheight)
        'the other 2 variables take the form's boundaries away from the screen's boundaries which gives us the 
        'position of the form on our screen when it loads. Since we divided both sides' widths and heights by 2,
        'the form is exactly in the screen's centre as it loads. Using variables lets us use this code irrespective of 
        'different widths and heights of different forms.


        GetFiles()

        Me.Text = FormTitle & ": TRIP INFORMATION"



        SizeContainers()
        CreateMonthYear()
        SizeMonthYear()

        CreateDaysOfWeek()      'days of week e.g. monday
        SizeDaysOfWeek()
        CreateDays()            'individual dates 27th
        SizeDays()

        _CalendarInfo = New MonthlyCalendarInfo(2025, 12)
        PopulateCalendar()
        LoadTripData()


        pbx_Back.ImageLocation = MyImages & "MainMenu1.png"
        pbx_PreviousMonth.ImageLocation = MyImages & "PreviousMonth1.png"
        pbx_NextMonth.ImageLocation = MyImages & "NextMonth1.png"
        pbx_Close.ImageLocation = MyImages & "close1.png"
        pic_Help.ImageLocation = MyImages & "help.png"


    End Sub

    Private Sub TripInformation_ClientSizeChanged(sender As Object, e As EventArgs) Handles Me.ClientSizeChanged

        'Resize all calendar components when form size changes

        SizeContainers()
        SizeMonthYear()
        SizeDaysOfWeek()

    End Sub


    Private Sub SizeContainers()

        'sizes and positions the main calendar containers, including the
        'month header, day-of-week header, and the six rows used to display dates.

        Dim daysHeight As Integer
        Dim daysYStart As Integer

        Pnl_MonthYearContainer.Size = New Size(ClientSize.Width, 50)
        Pnl_MonthYearContainer.Location = New Point(0, 0)

        Pnl_DaysOfWeekContainer.Size = New Size(ClientSize.Width, 30)
        Pnl_DaysOfWeekContainer.Location = New Point(0, Pnl_MonthYearContainer.Height)


        'The height of each row is calculated dynamically based on the available space
        'so that the calendar always fills the form evenly.

        daysHeight = ((ClientSize.Height - Pnl_MonthYearContainer.Height - Pnl_DaysOfWeekContainer.Height) - 70) / 6
        daysYStart = Pnl_MonthYearContainer.Height + Pnl_DaysOfWeekContainer.Height

        Pnl_DaysRow0Container.Size = New Size(ClientSize.Width, daysHeight)
        Pnl_DaysRow0Container.Location = New Point(0, daysYStart)

        Pnl_DaysRow1Container.Size = New Size(ClientSize.Width, daysHeight)
        Pnl_DaysRow1Container.Location = New Point(0, daysYStart + (daysHeight))

        Pnl_DaysRow2Container.Size = New Size(ClientSize.Width, daysHeight)
        Pnl_DaysRow2Container.Location = New Point(0, daysYStart + (daysHeight * 2))

        Pnl_DaysRow3Container.Size = New Size(ClientSize.Width, daysHeight)
        Pnl_DaysRow3Container.Location = New Point(0, daysYStart + (daysHeight * 3))

        Pnl_DaysRow4Container.Size = New Size(ClientSize.Width, daysHeight)
        Pnl_DaysRow4Container.Location = New Point(0, daysYStart + (daysHeight * 4))

        Pnl_DaysRow5Container.Size = New Size(ClientSize.Width, daysHeight)
        Pnl_DaysRow5Container.Location = New Point(0, daysYStart + (daysHeight * 5))



    End Sub


    Private Sub CreateMonthYear()

        'This method creates a label that displays the current month and year at the top
        'of the calendar.

        Dim label As Label = New Label()

        label.Name = "lbl_MonthYear"
        label.Font = New Font("Segoe UI", 14, FontStyle.Regular)
        label.AutoSize = True
        label.Text = "Month Year"

        Pnl_MonthYearContainer.Controls.Add(label)

    End Sub


    Private Sub SizeMonthYear()

        'centres the month and year label horizontally and vertically within
        'its container whenever the form or text changes.

        Dim labelX As Integer
        Dim labelY As Integer

        Dim labelFound = Pnl_MonthYearContainer.Controls.Find("lbl_MonthYear", False)

        If labelFound.Length = 0 Then
            Exit Sub
        End If

        Dim label As Label = CType(labelFound(0), Label)

        labelX = (Pnl_MonthYearContainer.Width - label.Width) \ 2
        labelY = (Pnl_MonthYearContainer.Height - label.Height) \ 2

        label.Location = New Point(labelX, labelY)




    End Sub


    Private Sub CreateDaysOfWeek()

        ' creates the seven day-of-week labelels and adds them
        'to the header container.

        Dim label As Label
        Dim days As String() = New String(6) {"Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"}

        For AmountOfDays = 0 To 6
            label = New Label
            label.Name = String.Format("label{0}", days(AmountOfDays))
            label.Font = New Font("Segoe UI", 7, FontStyle.Regular)
            label.AutoSize = False
            label.Text = days(AmountOfDays)
            label.TextAlign = ContentAlignment.MiddleCenter
            Pnl_DaysOfWeekContainer.Controls.Add(label)

        Next


    End Sub



    Private Sub SizeDaysOfWeek()

        'ensures that each day-of-week label is given an equal width so that
        'the header aligns  with the calendar grid.

        SizeWidthEqually(Pnl_DaysOfWeekContainer)

    End Sub



    Private Sub SizeWidthEqually(ByVal c As Control)

        'distributes all child controls within a container evenly
        'across its width, which is used for both the day headers and the calendar rows.

        Dim width As Integer
        Dim xLocation As Integer

        If c.Controls.Count = 0 Then

            Return

        End If


        width = c.Width / c.Controls.Count

        For Each ctrl As Control In c.Controls

            ctrl.Height = c.Height
            ctrl.Width = width
            ctrl.Location = New Point(xLocation, 0)
            xLocation += width

        Next

    End Sub



    Private Sub CreateDays()

        'creates the 6x7 grid of panels that represent individual days in the
        'calendar, with each panel containing a label for the day number.

        Dim DayPanel As Panel
        Dim DayOfMonthLabel As Label


        For rowIndex = 0 To 5

            For ColumnIndex = 0 To 6

                DayPanel = New Panel
                DayPanel.Name = String.Format("PnlDay{0}{1}", rowIndex, ColumnIndex)
                DayOfMonthLabel = New Label
                DayOfMonthLabel.Name = String.Format("LblDayOfMonth{0}{1}", rowIndex, ColumnIndex)
                DayOfMonthLabel.Text = DayOfMonthLabel.Name

                DayPanel.Controls.Add(DayOfMonthLabel)


                Select Case rowIndex

                    Case 0
                        Pnl_DaysRow0Container.Controls.Add(DayPanel)

                    Case 1
                        Pnl_DaysRow1Container.Controls.Add(DayPanel)

                    Case 2
                        Pnl_DaysRow2Container.Controls.Add(DayPanel)

                    Case 3
                        Pnl_DaysRow3Container.Controls.Add(DayPanel)

                    Case 4
                        Pnl_DaysRow4Container.Controls.Add(DayPanel)

                    Case 5
                        Pnl_DaysRow5Container.Controls.Add(DayPanel)


                End Select

            Next

        Next

    End Sub



    Private Sub SizeDays()

        'sizes all calendar day panels evenly so that each week row aligns
        'correctly with the others.

        SizeWidthEqually(Pnl_DaysRow0Container)
        SizeWidthEqually(Pnl_DaysRow1Container)
        SizeWidthEqually(Pnl_DaysRow2Container)
        SizeWidthEqually(Pnl_DaysRow3Container)
        SizeWidthEqually(Pnl_DaysRow4Container)
        SizeWidthEqually(Pnl_DaysRow5Container)


    End Sub



    Private Sub PopulateCalendar()

        'populates the calendar with the correct dates for the currently
        'active month and year. It also visually distinguishes between days that belong
        'to the active month, days from adjacent months, and the current day.


        Dim labelName As String


        'The month and year label is updated to reflect the active calendar state.

        Dim found = Pnl_MonthYearContainer.Controls.Find("lbl_MonthYear", False)
        If found.Length = 0 Then Exit Sub

        Dim label As Control = found(0)



        label.Text = String.Format("{0} {1}", MonthName(_CalendarInfo.Month), _CalendarInfo.Year)


        'Each cell in the 6x7 calendar grid is populated with the correct day number
        'based on its row and column position.

        For RowIndex = 0 To 5


            For ColumnIndex = 0 To 6

                labelName = String.Format("LblDayOfMonth{0}{1}", RowIndex, ColumnIndex)

                Dim dayFound = Me.Controls.Find(labelName, True)
                If dayFound.Length = 0 Then Continue For
                label = dayFound(0)

                label.Text = _CalendarInfo.DayInMonth(RowIndex, ColumnIndex)

                'Days that belong to the active month are shown in black, while days
                'from the previous or next month are shown in grey.

                If _CalendarInfo.IsActiveMonth(RowIndex, ColumnIndex) Then

                    label.ForeColor = Color.Black

                Else

                    label.ForeColor = Color.Gray

                End If

                'The current day is highlighted in red so it is easily identifiable.

                If _CalendarInfo.IsToday(RowIndex, ColumnIndex) Then

                    label.ForeColor = Color.Red

                End If

            Next


        Next


        SizeMonthYear()

    End Sub



    Private Sub LoadTripData()

        'reads encrypted trip data from a file, decrypts it, and stores
        'the trip names and dates. Each trip is then displayed on the corresponding
        'calendar day if it exists within the active month.

        Dim dates As New List(Of DateTime)
        Dim info As New List(Of String)
        Dim Column As Integer
        Dim Row As Integer
        Dim Panel As Panel
        Dim TripLabel As Label
        Dim PanelName As String


        'Variables used to read and decode each trip record.

        Dim OneTripRecord As String
        Dim OneTripRecordDecrypted As String
        Dim TripFields() As String
        Dim TripName As String
        Dim TripDate As DateTime

        Dim Trip_sr As New StreamReader(TripDetais_File)


        While Trip_sr.Peek() >= 0

            OneTripRecord = Trip_sr.ReadLine
            OneTripRecordDecrypted = XORencrypt(OneTripRecord)


            'Each decrypted record is split into fields to extract the trip name and date.

            TripFields = OneTripRecordDecrypted.Split(",")

            TripName = TripFields(1)
            TripDate = TripFields(3)

            dates.Add(TripDate)
            info.Add(TripName)

        End While



        Trip_sr.Close()

        'Each trip is placed onto the correct calendar cell using its date.


        For i = 0 To dates.Count - 1

            If _CalendarInfo.DateExists(dates(i)) Then

                Column = _CalendarInfo.Column(dates(i))
                Row = _CalendarInfo.Row(dates(i))
                PanelName = String.Format("PnlDay{0}{1}", Row, Column)
                Panel = Controls.Find(PanelName, True).First

                'A label is dynamically created to display the trip name inside the day cell.

                TripLabel = New Label
                TripLabel.Name = String.Format("LblTest{0}{1}", Row, Column)
                TripLabel.BackColor = Color.Thistle
                TripLabel.Text = info(i)
                TripLabel.TextAlign = ContentAlignment.MiddleLeft
                TripLabel.Location = New Point(0, 25)
                Panel.Controls.Add(TripLabel)

            End If

        Next



    End Sub


    Private Sub RemoveTripData(c As Control)

        'This recursive sub removes all dynamically created trip labels from the form.
        'It is used when changing months to prevent duplicate trip entries being displayed.

        For Each ctrl As Control In c.Controls.OfType(Of Control)().ToList

            RemoveTripData(ctrl)

        Next

        If c.Name.Contains("LblTest") Then

            c.Parent.Controls.Remove(c)

        End If

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

    Private Sub pbx_Back_Click(sender As Object, e As EventArgs) Handles pbx_Back.Click

        Me.Visible = False
        MAIN_MENU.Visible = True

        'Trip infor form is hidden and the mian menu is revealed again.


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


    End Sub

    Private Sub pbx_PreviousMonth_MouseEnter(sender As Object, e As EventArgs) Handles pbx_PreviousMonth.MouseEnter

        pbx_PreviousMonth.ImageLocation = MyImages & "PreviousMonth2.png"

        'When the mouse hovers over the button, the second part of the rollover image is shown

    End Sub

    Private Sub pbx_PreviousMonth_MouseLeave(sender As Object, e As EventArgs) Handles pbx_PreviousMonth.MouseLeave

        pbx_PreviousMonth.ImageLocation = MyImages & "PreviousMonth1.png"

        'When the mouse leaves the PicBox after hovering over it, we return to the first half
        'of the rollover image

    End Sub

    Private Sub pbx_PreviousMonth_Click(sender As Object, e As EventArgs) Handles pbx_PreviousMonth.Click


        'This button moves the calendar back to the previous month and refreshes both
        'the calendar layout and the displayed trip data.

        Dim ActiveMonth As DateTime
        Dim PreviousMonth As DateTime

        ActiveMonth = New Date(_CalendarInfo.Year, _CalendarInfo.Month, 1)
        PreviousMonth = ActiveMonth.AddMonths(-1)

        _CalendarInfo.GoToMonth(PreviousMonth.Year, PreviousMonth.Month)


        PopulateCalendar()
        RemoveTripData(Me)
        LoadTripData()



    End Sub

    Private Sub pbx_NextMonth_MouseEnter(sender As Object, e As EventArgs) Handles pbx_NextMonth.MouseEnter

        pbx_NextMonth.ImageLocation = MyImages & "NextMonth2.png"

        'When the mouse hovers over the button, the second part of the rollover image is shown


    End Sub

    Private Sub pbx_NextMonth_MouseLeave(sender As Object, e As EventArgs) Handles pbx_NextMonth.MouseLeave

        pbx_NextMonth.ImageLocation = MyImages & "NextMonth1.png"

        'When the mouse leaves the PicBox after hovering over it, we return to the first half
        'of the rollover image

    End Sub

    Private Sub pbx_NextMonth_Click(sender As Object, e As EventArgs) Handles pbx_NextMonth.Click

        'advances the calendar to the next month, updates the calendar display,
        'and reloads all relevant trip data.

        Dim ActiveMonth As DateTime
        Dim NextMonth As DateTime

        ActiveMonth = New Date(_CalendarInfo.Year, _CalendarInfo.Month, 1)
        NextMonth = ActiveMonth.AddMonths(1)

        _CalendarInfo.GoToMonth(NextMonth.Year, NextMonth.Month)



        PopulateCalendar()
        RemoveTripData(Me)
        LoadTripData()


    End Sub



    Private Sub pic_Help_MouseLeave(sender As Object, e As EventArgs) Handles pic_Help.MouseLeave
        Help.Visible = False


        'If mouse hovers over then leaves the icon, Help form is hidden.

    End Sub


    Private Sub pic_Help_MouseHover(sender As Object, e As EventArgs) Handles pic_Help.MouseHover
        Help.Visible = True
        Help.lbl_helpHeadingEng.Text = "Trip Information"
        Help.rtxt_helpInfoEng.Text = "This is the trip calendar. Shift between months to see what dates trips are on. Today's date is highlighted red."

        Help.lbl_helpHeadingWel.Text = "Gwybodaeth Taith"
        Help.rtxt_helpInfoWel.Text = "Dyma'r calendr teithiau. Symudwch rhwng misoedd i weld pa ddyddiadau mae teithiau arnynt. Mae dyddiad heddiw wedi'i amlygu'n goch.
"


        'when this specific icon is hovered over, Help form is revealed and text is altered as above to match this situation. 

    End Sub


End Class