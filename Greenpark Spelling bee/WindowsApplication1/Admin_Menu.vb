'Imports'
Imports System.Data.OleDb
Imports System.Net.Mime.MediaTypeNames
Imports System.Data.SqlClient
Imports System.Text.RegularExpressions
Public Class Admin_Menu

    'Connecting to database'
    Public connstring As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Greenpark_spellingBee.accdb"
    Public conn As New OleDbConnection

    'Defining the user id as a global variable'
    Dim User_ID As String
    Public TeacherName As String

    'This Subroutine will generate the user id automatically ensuring it is different to all the other users'
    Private Sub Generate_User_ID()

        If conn.ConnectionString <> connstring Then
            'Console being opened to accept SQL commands'
            conn.ConnectionString = connstring
            conn.Open()
        End If

        Dim User_Type_string As String = ""

        'Check box to define whether the use is a student or a teacher'
        If cbTeacher_box.Checked = True Then
            'User type definer is defined as T'
            User_Type_string = "T"
        ElseIf cbTeacher_box.Checked = False Then
            'User type definer is defined as S'
            User_Type_string = "S"
        End If

        'SQL Select Statement Searching for the highest UserID assciated with that user type'
        Dim User_ID As String = "SELECT MAX(UserID) FROM tblUser_info WHERE UserID LIKE '" & User_Type_string & "%%%%' "
        'Data adapter defined'
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(User_ID, conn)
        'Dataset defined'
        Dim ds As DataSet = New DataSet
        'Data adapter told to fill the da   taset
        da.Fill(ds, "tblUser_info")
        'Defining the datatable
        Dim dt As DataTable = ds.Tables("tblUser_info")

        'Associating User ID to the first item on the first row of the datatabl whilst converting the data to a string'
        User_ID = dt.Rows(0).Item(0).ToString


        'For defining the first student in the class;
        If User_ID = "" Then
            'this is some "Fake Data" that is used to calculate the first User ID'
            User_ID = "S0000"
        End If

        'This strips off the User Type Identified'
        User_ID = User_ID.Substring(1, 4)
        'This removes the leading zero's from the stripped string'
        User_ID = User_ID.TrimStart("0"c)

        'This catches the User ID string if it is something like "S0000", after all the stripping and formating, would leave nothing, this code repairs it'
        If User_ID = "" Then
            'Re-Defines the User_ID to 0'
            User_ID = 0
        End If

        'Converts the split string into an integer'
        User_ID = CType(User_ID, Integer) + 1

        'This block is responsible for adding the appropriate value onto the end of the user ID'
        'This converts the User ID to a string'
        User_ID = CType(User_ID, String)
        'Length check's used to identify the different tiers of the user id'
        If User_ID.Length = 1 Then
            'This combines the User ID's componants into a full id'
            User_ID = User_Type_string & "000" & User_ID
            'Length check's used to identify the different tiers of the user id'
        ElseIf User_ID.Length = 2 Then
            'This combines the User ID's componants into a full id'
            User_ID = User_Type_string & "00" & User_ID
            'Length check's used to identify the different tiers of the user id'
        ElseIf User_ID.Length = 3 Then
            'This combines the User ID's componants into a full id'
            User_ID = User_Type_string & "0" & User_ID
        Else
            'This combines the User ID's componants into a full id'
            User_ID = User_Type_string & User_ID
        End If

        'Runs the insert user Subroutine'
        Insert_User(User_ID, TeacherName)

    End Sub

    'This sub will auto generate a 4 char password, identify what kind of user is to be entered, along with some validation will enter the user into the database'
    Private Sub Insert_User(User_ID, TeacherName)

        If conn.ConnectionString <> connstring Then
            'Console being opened to accept SQL commands'
            conn.ConnectionString = connstring
            conn.Open()
        End If

        'Defines a random variable'
        Dim r As New Random()

        'This block defines four random numbers'
        Dim Gen_pass_1 As Integer = r.Next(9)
        Dim Gen_pass_2 As Integer = r.Next(5)
        Dim Gen_pass_3 As Integer = r.Next(2)
        Dim Gen_pass_4 As Integer = r.Next(6)

        Dim counter As Integer = 0

        'This combines all the random numbers into a password'
        Dim Generated_password As String = Gen_pass_1 & Gen_pass_2 & Gen_pass_3 & Gen_pass_4

        'User information block'
        Dim Firstname As String = txtFirstname.Text
        'Presence check'
        If Firstname = "" Then
            'Error message'
            MsgBox("Please enter a Username eg 'Mr.Teacher' or 'Firstname Lastname'")
            Exit Sub
            'Checks for numbers in the name string'
        ElseIf Firstname = Firstname Then
            'loop cycling through every character in the string'
            Do Until counter = Firstname.Length
                'if it finds an invalid character in the name then it exits the subroutine displaying this message'
                If Char.IsNumber(Firstname, counter) = True Then
                    'error message'
                    MsgBox("Invalid Firstname")
                    Exit Sub
                ElseIf Char.IsSymbol(Firstname, counter) = True Then
                    MsgBox("Invalid Firstname")
                    Exit Sub
                ElseIf Char.IsPunctuation(Firstname, counter) = True Then
                    MsgBox("Invalid Firstname")
                    Exit Sub
                Else
                    'this counter moves foward a letter if the current is not a number'
                    counter = counter + 1
                End If
            Loop
            'Lenth Check'
        ElseIf Firstname.Length > 25 Then
            'error message'
            MsgBox("Name is too large for database")
            Exit Sub
        End If

        'Defines the first and second passswords as the first and second password textboxes'
        Dim Password_1 As String = txtPassword_1.Text
        Dim Password_2 As String = txtPassword_2.Text

        'Defining the class string'
        Dim Class_1 As String

        'assiociates the class variable with the class text box'
        Class_1 = txtClass.Text
        'Class presence check'
        If Class_1 = "" Then
            'error message'
            MsgBox("Enter a class")
            Exit Sub
            'Class length check'
        ElseIf Class_1.Length > 2 Then
            'Error message'
            MsgBox("Class Entry is too long, eg '3A' ")
            Exit Sub
        End If


        'Check box boolean referenced again'
        If cbTeacher_box.Checked = True Then
            'associating the password with the password textbox'
            Password_1 = txtPassword_1.Text
            'Presence check'
            If Password_1 = "" Then
                'error message'
                MsgBox("Enter a password")
                Exit Sub
                'Length check'
            ElseIf Password_1.Length >= 20 Then
                'Error message'
                MsgBox("Password Exceeds Maximum Length (20)")
                Exit Sub
            End If
            'Associating the password 2 variable with the password textbox'
            Password_2 = txtPassword_2.Text
            'Presence check'
            If Password_2 = "" Then
                'error message'
                MsgBox("Enter a second password")
                Exit Sub
                'Length check'
            ElseIf Password_2.Length >= 20 Then
                'Error message'
                MsgBox("Password Exceed Maximum Length (20)")
                Exit Sub
            End If
        Else
            'Automated password association'
            Password_1 = Generated_password
            Password_2 = Generated_password
        End If

        'disabling the Teacher Text field'
        txtTeacher.Enabled = False
        'Inputing the teacher name into the teacher text box'
        txtTeacher.Text = TeacherName

        'Password match verification"
        If Password_1 <> Password_2 Then
            'error message'
            MsgBox("Passwords do not match")
            Exit Sub
        End If

        'Sql insert statement'
        Dim Insert_new_user As String = "INSERT INTO tblUser_info ([UserID],[FirstName],[Password],[Classinfo],[Teacher]) VALUES (@UserID,@FirstName,@Password,@Classinfo,@Teacher)"
        'Adding information to the database'
        Dim SQL_Insert_Statment As New OleDbCommand
        With SQL_Insert_Statment
            .CommandText = Insert_new_user
            'Parameters along side the references of the data that is being inserted'
            .Parameters.AddWithValue("@UserID", User_ID)
            .Parameters.AddWithValue("@FirstName", Firstname)
            .Parameters.AddWithValue("@Password", Password_1)
            .Parameters.AddWithValue("@Classinfo", Class_1)
            .Parameters.AddWithValue("@Teacher", TeacherName)
            .Connection = conn
            .ExecuteNonQuery()
        End With

        'Final message declaring a successful insert'
        MsgBox("User: " + User_ID + " saved!")

        'Emptying all the text boxes'
        txtFirstname.Text = ""
        txtClass.Text = ""
        txtTeacher.Text = ""
        txtPassword_1.Text = ""
        txtPassword_2.Text = ""

    End Sub

    'Formats which text boxes can be used depending on the user type'
    Private Sub Insert_User_Automation(TeacherName)

        If cbTeacher_box.Checked = False Then

            txtPassword_1.Enabled = False
            txtPassword_2.Enabled = False
        ElseIf cbTeacher_box.Checked = True Then
            txtTeacher.Text = ""
            txtTeacher.Enabled = False
            txtClass.Enabled = True
            txtPassword_1.Enabled = True
            txtPassword_2.Enabled = True
        End If

    End Sub

    'Load event running all subroutines that need to run at form load'
    

    'Defining a global variable for the users class'
    Friend User_Class As String

    'This will, when pressed, adjust the text fields availablity depending on which teacher is to be entered'
    Private Sub cbTeacher_box_CheckedChanged(sender As Object, e As EventArgs) Handles cbTeacher_box.CheckedChanged

        If cbTeacher_box.Checked = True Then
            Insert_User_Automation(TeacherName)
        ElseIf cbTeacher_box.Checked = False Then
            Insert_User_Automation(TeacherName)
        End If

    End Sub

    Private Sub System_Stats()

        txtnumUsers.Text = "Test"
        txtnumClasses.Text = "Test"
        txtnumStudents.Text = "Test"
        txtnumTeachers.Text = "Test"
        txtnumTests.Text = "Test"

        Dim User_Count As String = "SELECT * FROM tblUser_info"
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(User_Count, conn)
        'Dataset defined'
        Dim ds As DataSet = New DataSet
        'Data adapter told to fill the da   taset
        da.Fill(ds, "tbluser")
        'Defining the datatable
        Dim dt As DataTable = ds.Tables("tbluser")

        Dim counter As Integer = 0
        Dim Student_Counter As Integer = 0

        txtnumUsers.Text = ds.Tables("tbluser").Rows.Count

        MsgBox(ds.Tables("tbluser").Rows.Count)

        For Each row As DataRow In dt.Rows
            If ds.Tables("tbluser").Rows(0).Item(counter).substring(0, 1) = "S" Then
                Student_Counter = Student_Counter + 1
                counter = counter + 1
            End If
        Next

        txtnumStudents.Text = Student_Counter
        txtnumTeachers.Text = (ds.Tables("tbluser").Rows.Count) - Student_Counter

    End Sub

    Private Sub Admin_Menu_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        System_Stats()
        cbEditing_A_User.Enabled = False
        Insert_User_Automation(TeacherName)

    End Sub

End Class