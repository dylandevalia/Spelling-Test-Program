'Imports'
Imports System.Data.OleDb
Imports System.Net.Mime.MediaTypeNames
Imports System.Data.SqlClient

Public Class Teacher_Menu_Account_Management

    'Connecting to database'
    Public connstring As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Greenpark_spellingBee.accdb"
    Public conn As New OleDbConnection

    'Defining the user id as a global variable'
    Dim User_ID As String

    'Navigational buttons'
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Me.Close()
        Teacher_Menu_Create_Test.Show()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Me.Close()
        Teacher_Menu_See_Old_Marks.Show()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Me.Close()
        Teacher_Menu_Class_Marks.Show()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        Me.Close()
        Teacher_Menu_Test_Library.Show()

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        Me.Close()
        Login_screen.Show()

    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click

        Generate_User_ID()

    End Sub

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

        'This is a boolean check box that defines whether a teacher is to be made or a student is'
        If cbTeacher_box.Checked = True Then
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
        Else
            'Associates the class with the generated class from the Current user'
            Class_1 = User_Class
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

    'Second delete subroutine'
    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click

        Delete_User2()

    End Sub

    'This defines the FirstName variable for global user throughout the form'
    Public TeacherName As String
    'Fetches all user information from the user table where the username equals that which was entered during the login
    Private Sub Grab_user_Information()

        If conn.ConnectionString <> connstring Then
            'Console being opened to accept SQL commands'
            conn.ConnectionString = connstring
            conn.Open()
        End If

        'Used to reference User Information'
        Dim User_Data As String = "SELECT * FROM tblUser_info WHERE UserID = '" & Login_screen.Username & "' "
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(User_Data, conn)
        Dim ds As DataSet = New DataSet
        da.Fill(ds, "Indiv_User_Info2")
        Dim dt As DataTable = ds.Tables("Indiv_User_Info2")

        TeacherName = ds.Tables("Indiv_User_Info2").Rows(0).Item(1)
        lblTeacher_Username.Text = TeacherName

        txtTeacher.Enabled = False
        txtTeacher.Text = TeacherName

        Insert_User_Automation(TeacherName)

    End Sub

    'Formats which text boxes can be used depending on the user type'
    Private Sub Insert_User_Automation(TeacherName)

        'this if statment will be called everytime the check box state is changed' 
        If cbTeacher_box.Checked = False Then
            'these format the entry fields so that a teacher and a student cant be confused, by enabling and disabling certain boxes'
            txtClass.Enabled = False
            txtPassword_1.Enabled = False
            txtPassword_2.Enabled = False
            txtTeacher.Text = TeacherName
            txtTeacher.Enabled = False
        ElseIf cbTeacher_box.Checked = True Then
            txtTeacher.Text = ""
            txtTeacher.Enabled = False
            txtClass.Enabled = True
            txtPassword_1.Enabled = True
            txtPassword_2.Enabled = True
        End If

    End Sub

    'Load event running all subroutines that need to run at form load'
    Private Sub Teacher_Menu_Account_Management_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'this runs all the preliminary subroutines like filling tables, disabling buttons, inserting the side bar information etc'
        Button8.Enabled = False
        Grab_user_Information()
        cbEditing_A_User.Enabled = False
        Insert_User_Automation(TeacherName)
        Get_User_Class()


    End Sub

    'Defining a global variable for the users class'
    Friend User_Class As String
    'This subroutine will grab the users Class
    Public Sub Get_User_Class()

        If conn.ConnectionString <> connstring Then
            'Console being opened to accept SQL commands'
            conn.ConnectionString = connstring
            conn.Open()
        End If


        'Used to reference User Information'
        'This sql string will call all records that match the user id used to enter the system'
        Dim User_Data As String = "SELECT * FROM tblUser_info WHERE UserID = '" & Login_screen.Username & "' "
        'this will define the data adapter'
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(User_Data, conn)
        'this defiens the dataset'
        Dim ds As DataSet = New DataSet
        'this tells the data adapter to fill the data table which is defined next'
        da.Fill(ds, "Indiv_User_Info")
        'defining the datatable'
        Dim dt As DataTable = ds.Tables("Indiv_User_Info")

        'defining the user class string'
        User_Class = ds.Tables("Indiv_User_Info").Rows(0).Item(3)

        Fill_user_table(User_Class)


    End Sub

    'This sub will fill the username table with all the students that belong to the current users class'
    Private Sub Fill_user_table(User_Class)

        If conn.ConnectionString <> connstring Then
            'Console being opened to accept SQL commands'
            conn.ConnectionString = connstring
            conn.Open()
        End If

        'this uses the user class string to locate all the students within the teachers class'
        Dim User_Library As String = "SELECT * FROM tblUser_info WHERE Classinfo = '" & User_Class & "' "
        'this will define the data adapter'
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(User_Library, conn)
        'this defiens the dataset'
        Dim ds As DataSet = New DataSet
        'this tells the data adapter to fill the data table which is defined next'
        da.Fill(ds, "User_Info")
        'defining the datatable'
        Dim dt As DataTable = ds.Tables("User_Info")

        'this with statement will fill the datagrid with all the data located in the previous block and insert them into the table'
        With dvgUser_Info
            .AutoGenerateColumns = True
            .DataSource = ds
            .DataMember = "User_Info"
        End With


    End Sub

    'This button refreshes the users table after changes have been made'
    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click

        Fill_user_table(User_Class)

    End Sub

    'This is the search function for users'
    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click

        If conn.ConnectionString <> connstring Then
            'Console being opened to accept SQL commands'
            conn.ConnectionString = connstring
            conn.Open()
        End If

        Dim User_Search As String = txtSearch_Users.Text
        If User_Search = "" Then
            MsgBox("No user entered.")
            Exit Sub
        End If

        Dim User_Library As String = "SELECT * FROM tblUser_info WHERE Classinfo = '" & User_Class & "' "
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(User_Library, conn)
        Dim ds As DataSet = New DataSet
        da.Fill(ds, "User_Info")
        Dim dt As DataTable = ds.Tables("User_Info")

        Dim counter As Integer = 0

        For Each row As DataRow In dt.Rows
            dvgUser_Info.Rows(counter).DefaultCellStyle.BackColor = Color.White
            counter = counter + 1
        Next

        counter = 0

        For Each row As DataRow In dt.Rows
            If ds.Tables("User_Info").Rows(counter).Item(1) = User_Search Then
                dvgUser_Info.Rows(counter).DefaultCellStyle.BackColor = Color.PaleGreen
            ElseIf ds.Tables("User_Info").Rows(counter).Item(1).contains(User_Search) Then
                dvgUser_Info.Rows(counter).DefaultCellStyle.BackColor = Color.LightSalmon
                counter = counter + 1
            Else
                counter = counter + 1
            End If
        Next

        counter = 0

    End Sub

    'This will, when pressed, adjust the text fields availablity depending on which teacher is to be entered'
    Private Sub cbTeacher_box_CheckedChanged(sender As Object, e As EventArgs) Handles cbTeacher_box.CheckedChanged

        'this if statment will call the subroutines incharge of changing the structure of the input forms for student creationg'
        If cbTeacher_box.Checked = True Then
            'calling the sub if box is checked'
            Insert_User_Automation(TeacherName)
        ElseIf cbTeacher_box.Checked = False Then
            'calling the sub if box is not checked'
            Insert_User_Automation(TeacherName)
        End If


    End Sub

    'This will run a delete subroutine deleting all the user with the corresponding Username'
    Private Sub Delete_User()

        If conn.ConnectionString <> connstring Then
            'Console being opened to accept SQL commands'
            conn.ConnectionString = connstring
            conn.Open()
        End If

        'User variable for deletion'
        Dim Delete_User As String = txtDelete_User.Text

        'some validation on the user id entry'
        If Delete_User = "" Then
            MsgBox("Please enter a username")
            Exit Sub
            'length check validation'
        ElseIf Delete_User.Length > 5 Then
            MsgBox("UserID Exceeds Maximum Length")
            Exit Sub
        End If

        'sql statment that calls all records associated with the user class and user id'
        Dim User_Library As String = "SELECT * FROM tblUser_info WHERE Classinfo = '" & User_Class & "' AND UserID = '" & Delete_User & "' "
        'This defines the data adapter'
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(User_Library, conn)
        'This defines the data set'
        Dim ds As DataSet = New DataSet
        'this fills the data set'
        da.Fill(ds, "User_Info")
        'this defines the datatable'
        Dim dt As DataTable = ds.Tables("User_Info")

        If ds.Tables("User_Info").Rows.Count = 0 Then
            MsgBox("User does not exist")
            Exit Sub
        End If

        'Sql Query
        Dim Delete_User_Record As String = "DELETE * FROM tblUser_info WHERE UserID = @User_ID"
        'Adding information to the database'
        Dim SqlCommand As New OleDbCommand
        With SqlCommand
            .CommandText = Delete_User_Record
            .Parameters.AddWithValue("@User_ID", Delete_User)
            .Connection = conn
            .ExecuteNonQuery()
        End With

        'Empties content of textbox for next input'
        txtDelete_User.Text = ""
        Fill_user_table(User_Class)

        MsgBox("User Deleted")

    End Sub

    'This will run a delete subroutine deleting all the user with the corresponding Username for the second button'
    Private Sub Delete_User2()

        If conn.ConnectionString <> connstring Then
            'Console being opened to accept SQL commands'
            conn.ConnectionString = connstring
            conn.Open()
        End If

        'User variable for deletion'
        Dim Delete_User As String = txtDelete_User.Text

        'some validation on the user id entry'
        If Delete_User = "" Then
            MsgBox("Please enter a username")
            Exit Sub
            'length check validation'
        ElseIf Delete_User.Length > 5 Then
            MsgBox("UserID Exceeds Maximum Length")
            Exit Sub
        End If

        'sql statment that calls all records associated with the user class and user id'
        Dim User_Library As String = "SELECT * FROM tblUser_info WHERE Classinfo = '" & User_Class & "' AND UserID = '" & Delete_User & "' "
        'This defines the data adapter'
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(User_Library, conn)
        'This defines the data set'
        Dim ds As DataSet = New DataSet
        'this fills the data set'
        da.Fill(ds, "User_Info")
        'this defines the datatable'
        Dim dt As DataTable = ds.Tables("User_Info")

        If ds.Tables("User_Info").Rows.Count = 0 Then
            MsgBox("User does not exist")
            Exit Sub
        End If

        'Sql Query
        Dim Delete_User_Record As String = "DELETE * FROM tblUser_info WHERE UserID = @User_ID"
        'Adding information to the database'
        Dim SqlCommand As New OleDbCommand
        With SqlCommand
            .CommandText = Delete_User_Record
            .Parameters.AddWithValue("@User_ID", Delete_User)
            .Connection = conn
            .ExecuteNonQuery()
        End With

        'Empties content of textbox for next input'
        txtDelete_User.Text = ""
        Fill_user_table(User_Class)

        MsgBox("User Deleted")

    End Sub

    'Button addressing the delete user subroutine'
    Private Sub btnDelete_User_Click(sender As Object, e As EventArgs) Handles btnDelete_User.Click

        Delete_User()

    End Sub

    'Experimental import Statment '

    ' 'Private Sub Excel_Import()

    '    Dim filepath As String = "C:\Markt.xls"
    '    Dim Version As Type

    '    Version = Mid(filepath, filepath.LastIndexOf(".") + 1, 5)

    '    Try
    '        If Version = ".xls" Then                 'Execute when MS EXCEL 2003 Format
    '            Dim MyConnection As System.Data.OleDb.OleDbConnection
    '            Dim DtSet As System.Data.DataSet
    '            Dim MyCommand As System.Data.OleDb.OleDbDataAdapter
    '            MyConnection = New System.Data.OleDb.OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0; Data Source='" & filepath & "';Extended Properties=Excel 8.0;")
    '            MyCommand = New System.Data.OleDb.OleDbDataAdapter("select * from [Sheet1$]", MyConnection)
    '            DtSet = New System.Data.DataSet
    '            MyCommand.Fill(DtSet, "[Sheet1$]")
    '            dt = DtSet.Tables(0)
    '            MyConnection.Close()

    '        ElseIf Version = ".xlsx" Then           'Execute when MS EXCEL 2007 Format

    '            Dim MyConnection As System.Data.OleDb.OleDbConnection
    '            Dim DtSet As System.Data.DataSet
    '            Dim MyCommand As System.Data.OleDb.OleDbDataAdapter
    '            MyConnection = New System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" & filepath & "';Extended Properties=Excel 12.0;")
    '            MyCommand = New System.Data.OleDb.OleDbDataAdapter("select * from [Sheet1$]", MyConnection)
    '            DtSet = New System.Data.DataSet
    '            MyCommand.Fill(DtSet, "[Sheet1$]")
    '            dt = DtSet.Tables(0)
    '            MyConnection.Close()

    '        Else

    '            Label1.Text = "This Version is not Support!"
    '            Exit Sub
    '        End If


    '        If dt.Rows.Count > 0 Then
    '            For i = 0 To dt.Rows.Count - 1
    '                dr = dt.Rows(i)
    '                fetch = "insert into StudentList(Regno,Sname,Class) values("
    '                fetch += "'" & dt.Rows(i).Item(0) & "',"
    '                fetch += "'" & dt.Rows(i).Item(1) & "',"
    '                fetch += "'" & dt.Rows(i).Item(2) & "')"
    '                sqlcmd = New SqlCommand(fetch, sqlcon)
    '                sqlcmd.CommandType = CommandType.Text
    '                sqlcmd.ExecuteNonQuery()
    '                fetch = ""
    '            Next
    '            Label1.Text = "successfully Imported values to SQL Server"
    '        End If

    '    Catch ex As Exception
    '        MsgBox(ex.ToString)
    '    End Try

    'End Sub'

End Class