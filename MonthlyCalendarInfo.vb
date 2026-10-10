Imports System.IO

Public Class MonthlyCalendarInfo


    Private _Month As Integer
    Private _Year As Integer

    'This two-dimensional array represents the 6x7 calendar grid and stores the
    'actual DateTime value for each cell in the calendar.
    Private ReadOnly _Days(5, 6) As DateTime



    'This read-only property exposes the currently active month to other classes
    'while preventing it from being modified directly.
    Public ReadOnly Property Month


        Get

            Return _Month

        End Get

    End Property


    'This read-only property exposes the currently active year to other classes
    'while maintaining encapsulation.
    Public ReadOnly Property Year
        Get

            Return _Year

        End Get

    End Property


    'This constructor initialises the calendar using the current system month
    'and year, then generates the calendar grid accordingly.
    Public Sub New()

        _Month = Now.Month
        _Year = Now.Year
        SetDays()

    End Sub



    'This constructor allows a specific month and year to be supplied when the
    'calendar object is created. It validates the inputs to ensure they form
    'a valid date before generating the calendar grid.
    Public Sub New(Year As Integer, Month As Integer)

        If Year < 1 Or Year > 9999 Then

            Throw New ArgumentOutOfRangeException("year")

        End If



        If Month < 1 Or Month > 12 Then

            Throw New ArgumentOutOfRangeException("month")

        End If

        'The calendar is initialised using validated values and the grid is populated.

        _Month = Now.Month
        _Year = Now.Year
        SetDays()

    End Sub


    'This method calculates and fills the 6x7 calendar grid with DateTime values.
    'It determines the first visible date based on the day of the week and then
    'increments day-by-day to fill the entire grid.
    Private Sub SetDays()

        Dim FirstDayOfMonth As DateTime
        Dim column As Integer
        Dim FirstDayOfGrid As DateTime
        Dim GridDate As DateTime

        'The first day of the selected month is identified.

        FirstDayOfMonth = New Date(_Year, _Month, 1)

        'The day-of-week value is used to calculate how far back the grid should start.

        column = CInt(FirstDayOfMonth.DayOfWeek)
        FirstDayOfGrid = FirstDayOfMonth.AddDays(column * -1)


        'The grid is populated sequentially, one day at a time.

        GridDate = FirstDayOfGrid

        For rowIndex = 0 To 5

            For ColumnIndex = 0 To 6

                _Days(rowIndex, ColumnIndex) = GridDate
                GridDate = GridDate.AddDays(1)

            Next

        Next

        Return

    End Sub


    'This method updates the calendar to display a different month and year.
    'Input values are validated before regenerating the calendar grid.
    Public Sub GoToMonth(Year As Integer, Month As Integer)

        If Year < 1 Or Year > 9999 Then

            Throw New ArgumentOutOfRangeException("year")


        End If


        If Month < 1 Or Month > 12 Then

            Throw New ArgumentOutOfRangeException("month")

        End If

        _Month = Month
        _Year = Year
        SetDays()


    End Sub


    'This function returns the numerical day value for a specific row and column
    'within the calendar grid.
    Public Function DayInMonth(row As Integer, column As Integer) As Integer

        If row < 0 Or row > 5 Then

            Throw New ArgumentOutOfRangeException("row")

        End If

        If column < 0 Or column > 6 Then

            Throw New ArgumentOutOfRangeException("column")

        End If

        Return _Days(row, column).Day



    End Function


    'This function determines whether a given calendar cell belongs to the
    'currently active month or to an adjacent month.
    Public Function IsActiveMonth(row As Integer, column As Integer) As Boolean

        If row < 0 Or row > 5 Then

            Throw New ArgumentOutOfRangeException("row")

        End If

        If column < 0 Or column > 6 Then

            Throw New ArgumentOutOfRangeException("column")

        End If

        Return _Days(row, column).Month = Month

    End Function


    'This function checks whether the date at a specific row and column represents
    'the current system date.
    Public Function IsToday(row As Integer, column As Integer) As Boolean

        If row < 0 Or row > 5 Then

            Throw New ArgumentOutOfRangeException("row")

        End If

        If column < 0 Or column > 6 Then

            Throw New ArgumentOutOfRangeException("column")

        End If

        Return _Days(row, column).Date = Now.Date

    End Function


    'This function searches the calendar grid to find the row index that matches
    'a specific DateTime value.
    Public Function Row(dt As DateTime) As Integer

        Dim ColumnIndex = 0
        Dim RowIndex = 0

        For RowIndex = 0 To 5

            For ColumnIndex = 0 To 6

                If _Days(RowIndex, ColumnIndex) = dt Then

                    Return RowIndex

                End If

            Next

        Next

        Return -1

    End Function


    'This function searches the calendar grid to find the column index that matches
    'a specific DateTime value.
    Public Function Column(dt As DateTime) As Integer

        Dim ColumnIndex = 0
        Dim RowIndex = 0

        For RowIndex = 0 To 5

            For ColumnIndex = 0 To 6

                If _Days(RowIndex, ColumnIndex) = dt Then

                    Return ColumnIndex

                End If

            Next

        Next

        Return -1

    End Function


    'This function checks whether a given date exists anywhere within the current
    'calendar grid.
    Public Function DateExists(dt As DateTime) As Boolean

        If Row(dt) > -1 Then

            Return True

        End If

        Return False

    End Function

End Class
