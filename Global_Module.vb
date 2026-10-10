Imports System.IO

Module Global_Module

    Public ConfirmActions As Boolean = True


    Public MyImages As String = Application.StartupPath & "\images\"            'creates a file called MyImages by tagging it onto the end of the path of the project
    'so any system using this program can access this file.


    Public Const FormTitle As String = "CHCS Trip System"

    Public FilePath As String = Application.StartupPath & "\files\"

    Public Receptionists_File As String       'make a file for each type of user
    Public Teachers_File As String
    Public Students_File As String
    Public UserLogin_File As String
    Public TripDetais_File As String
    Public MedicalInfo_File As String
    Public EmergencyContactInfo_File As String
    Public TripBookings_File As String
    Public TripEnrolment_File As String


    Public LoginID_Global As String     'Both global variables allow system to identify a student and how much they can access
    Public LoginAccessLevel_Global As String   'by saving their studentID and access level, allowing students to be independently
    'identified from every other user wherever reuqired. 

    Public BgLightBlue As Boolean = True


    Public Sub CentreForm(ByVal EachFormInProject As Form)

        Dim ScreenWidth As Integer
        Dim ScreenHeight As Integer
        Dim FormStartPosX As Integer
        Dim FormStartPosY As Integer

        ScreenWidth = Screen.PrimaryScreen.Bounds.Width
        ScreenHeight = Screen.PrimaryScreen.Bounds.Height
        FormStartPosX = (ScreenWidth / 2) - (EachFormInProject.Width / 2)
        FormStartPosY = (ScreenHeight / 2) - (EachFormInProject.Height / 2)

        EachFormInProject.StartPosition = FormStartPosition.Manual
        EachFormInProject.Location = New Point(FormStartPosX, FormStartPosY)


        '2 variables are set as the form's width and form's height respectively. (screenwidth, screenheight)
        'the other 2 variables take the form's boundaries away from the screen's boundaries which gives us the 
        'position of the form on our screen when it loads. Since we divided both sides' widths and heights by 2,
        'the form is exactly in the screen's centre as it loads. Using variables lets us use this code irrespective of 
        'different widths and heights of different forms.


    End Sub


    Public Sub GetFiles()

        'Sub - procedure allows any form which calls this to be abel to access file location of every text file. 



        If Not Directory.Exists(FilePath) Then

            Directory.CreateDirectory(FilePath)
        End If


        'Creates FilePath if it is somehow not accessible



        Receptionists_File = FilePath & "receptionists.txt"
        Teachers_File = FilePath & "teachers.txt"
        Students_File = FilePath & "students.txt"
        UserLogin_File = FilePath & "logins.txt"
        TripDetais_File = FilePath & "schooltrip.txt"
        MedicalInfo_File = FilePath & "medicalinfo.txt"
        EmergencyContactInfo_File = FilePath & "emergencycontact.txt"
        TripBookings_File = FilePath & "bookings.txt"
        TripEnrolment_File = FilePath & "enrolments.txt"

        'Determining exact file path of all text files so they can be accessed over any system.
        'This is needed so the school's computer system can also utilise this software. 


        If Dir(Receptionists_File) = "" Then
            Dim sw As New StreamWriter(Receptionists_File, True)
            sw.Close()
        End If


        If Dir(Teachers_File) = "" Then
            Dim sw As New StreamWriter(Teachers_File, True)
            MsgBox("New teacher file has been created.")
            sw.Close()
        End If

        If Dir(Students_File) = "" Then
            Dim sw As New StreamWriter(Students_File, True)
            MsgBox("New student file has been created.")
            sw.Close()
        End If


        If Dir(UserLogin_File) = "" Then
            Dim sw As New StreamWriter(UserLogin_File, True)
            MsgBox("New Logins file has been created.")
            sw.Close()
        End If

        'Userlogin is organised as access level, ID, username, password


        If Dir(TripDetais_File) = "" Then
            Dim sw As New StreamWriter(TripDetais_File, True)
            MsgBox("New school trip details file has been created.")
            sw.Close()
        End If


        If Dir(MedicalInfo_File) = "" Then
            Dim sw As New StreamWriter(MedicalInfo_File, True)
            MsgBox("New medical information file has been created.")
            sw.Close()
        End If


        If Dir(EmergencyContactInfo_File) = "" Then
            Dim sw As New StreamWriter(EmergencyContactInfo_File, True)
            MsgBox("New emergency contact information file has been created.")
            sw.Close()
        End If


        If Dir(TripBookings_File) = "" Then
            Dim sw As New StreamWriter(TripBookings_File, True)
            MsgBox("New trip bookings (linking table) file has been created.")
            sw.Close()
        End If


        If Dir(TripEnrolment_File) = "" Then
            Dim sw As New StreamWriter(TripEnrolment_File, True)
            MsgBox("New trip enrolment file for students has been created.")
            sw.Close()
        End If


        'all above "Dir" files create new text files if, for any reason, the text file is not already there.

    End Sub



    'Public Boolean variable allows us to check if the "High Contrast Setting" has been clicked or not, letting us change the BG colour

    Public Sub ApplyBgTheme()

        'Within EVERY form in this solution, if the above boolean is true, we see the light blue (standard) colour.
        'If False, the colour is white. This boolean is flipped between true and false in Settings.vb form. 
        'Using a For loop here, I do not need to repeat this code for every new form I create. 

        For Each ProjectForm As Form In Application.OpenForms

            If BgLightBlue = True Then

                ProjectForm.BackColor = Color.FromArgb(215, 228, 242)

            Else

                ProjectForm.BackColor = Color.White


            End If

        Next


    End Sub


    Public Function XORencrypt(ByVal UserDataInput As String) As String


        'Sub handles encryption *AND DECRYPTION* throughout every text file across this solution. 
        'Every character in given string is converted to its ASCII counterpart (8 bit) and is
        'XOR'd with the binary version of 150 denary. 150 is the constant key which allows us to
        'easily revert back to a character's decrypted version by simply reversing the process by XORing 
        'the encrypted character with 150 too. 


        Dim OriginalDataInput As String = ""
        Dim EncryptedDataOutput As String = ""
        Dim output As String = ""

        Dim counter As Integer

        For counter = 0 To UserDataInput.Length - 1

            OriginalDataInput = UserDataInput(counter)

            EncryptedDataOutput = Chr(Asc(OriginalDataInput) Xor 150)

            output = output & EncryptedDataOutput



        Next

        Return output

    End Function



End Module
