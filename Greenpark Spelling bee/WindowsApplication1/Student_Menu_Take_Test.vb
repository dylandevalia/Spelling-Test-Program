'Imports'
Imports System.Data.OleDb
Public Class Student_Menu_Take_Test

    'Connecting to database'
    Public connstring As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Greenpark_spellingBee.accdb"
    Public conn As New OleDbConnection

    'Navigational Buttons'
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnSee_Next_Test_Take_Test.Click

        Clear()
        Me.Close()
        Student_Menu_See_Next_Test.Show()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnSee_Old_Marks_Take_Test.Click

        Clear()
        Me.Close()
        Student_Menu_See_Old_Marks.Show()


    End Sub
    
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles btnLogOff.Click

        Clear()
        Me.Close()
        Login_screen.Show()

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs)

        conn.Close()

    End Sub

    'Defines the Class the user belongs to variable as global one'
    Public User_Class As String

    'Grabs all the students information for various processing reasons'
    Private Sub Grab_user_Information()

        If conn.ConnectionString <> connstring Then
            'Console being opened to accept SQL commands'
            conn.ConnectionString = connstring
            conn.Open()
        End If

        'Used to reference User Information'
        Dim User_Data As String = "SELECT * FROM tblUser_info WHERE UserID = '" & Login_screen.Username & "' "
        'Defining the data adapter and command string'
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(User_Data, conn)
        'defining the dataset'
        Dim ds As DataSet = New DataSet
        'telling the data adapter to fill the data set using the datatable'
        da.Fill(ds, "Indiv_User_Info2")
        'Defining the data table'
        Dim dt As DataTable = ds.Tables("Indiv_User_Info2")

        'This will change a label to the name of the current user'
        Dim First_Name As String = ds.Tables("Indiv_User_Info2").Rows(0).Item(1)
        lblStudent_Name.Text = First_Name

        'THis will change the year the user belongs too'
        Dim Year As String = ds.Tables("Indiv_User_Info2").Rows(0).Item(3)
        lblStudent_Year.Text = Year

        'THis defines the user class variable'
        User_Class = ds.Tables("Indiv_User_Info2").Rows(0).Item(3)

        'This will run this subroutine'
        Load_Test(User_Class)

        conn.Close()
    End Sub

    'This will find the newest test minus one and displays it to the student to be tested'
    Friend Test_ID As Integer
    Private Sub Load_Test(User_Class)

        'If statment checking to see if the console is open and the connection has been established'
        If conn.ConnectionString <> connstring Then
            'Console being opened to accept SQL commands'
            conn.ConnectionString = connstring
            conn.Open()
        End If

        'This fills a dataset with all the data from the test table of the database'
        Dim Test_ID_search As String = "SELECT * FROM tblTest WHERE Class = '" & User_Class & "' "
        'Defining the data adapter and command string'
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(Test_ID_search, conn)
        'defining the dataset'
        Dim ds As DataSet = New DataSet
        'telling the data adapter to fill the data set using the datatable'
        da.Fill(ds, "tblTest")
        'Defining the data table'
        Dim dt As DataTable = ds.Tables("tblTest")

        'Some presence check validation to check if the database actually contains any tests'
        If ds.Tables("tblTest").Rows.Count = 0 Then
            MsgBox("No Tests Found")
            Exit Sub
        ElseIf ds.Tables("tblTest").Rows.Count = 1 Then
            MsgBox("Only one test in the database, Please add another")
            Exit Sub
        End If

        'Defining the variables'
        Dim Max As Integer = 0
        Dim Counter As Integer = 0
        Dim Test_ID_Update As Integer = 0

        'This block will identify the most up to date test by splitting the variable eg "T1" into the letter "T" and the number "1",' 
        'then it will check if the this number is the highest and if not will move to the next row in the datatable'

        'This loop will check each row in the datatable'
        For Each row As DataRow In dt.Rows
            'This defines the variable test id split, the variable that will split the test id into the two parts'
            Dim Test_ID_Split As String = ds.Tables("tblTest").Rows(Counter).Item(0)
            'length checks to idetify the magnitude of the Test ID in this case T1 - T9'
            If Test_ID_Split.Length = 2 Then
                'This will split the string and then define it as the split variable'
                Test_ID_Update = Test_ID_Split.Substring(Test_ID_Split.Length - 1)
            ElseIf Test_ID_Split.Length = 3 Then
                Test_ID_Update = Test_ID_Split.Substring(Test_ID_Split.Length - 2)
            ElseIf Test_ID_Split.Length = 4 Then
                Test_ID_Update = Test_ID_Split.Substring(Test_ID_Split.Length - 3)
            ElseIf Test_ID_Split.Length = 5 Then
                Test_ID_Update = Test_ID_Split.Substring(Test_ID_Split.Length - 4)
            End If
            'This if statment is responsible for defining the outputted variable and swaping the values until a maximum is found'
            If Test_ID_Update > Max Then
                Max = Test_ID_Update
                Counter = Counter + 1
            End If
        Next

        'This is a bit of validation ensuring that if there is only one test in the database, the following code wont create errors'
        If Max = 1 Then
            Max = 2
        End If

        'This block finaly defines the Test_ID that will be used to display the test definitons and then later for marking'
        Test_ID = Max - 2
        lblTest_ID.Text = "You are taking test: " + "T" & Max - 1

        'This block will place text into the appropriate text boxes matching the words'
        txtDef1.Text = ds.Tables("tblTest").Rows(Test_ID).Item(2)
        txtDef2.Text = ds.Tables("tblTest").Rows(Test_ID).Item(4)
        txtDef3.Text = ds.Tables("tblTest").Rows(Test_ID).Item(6)
        txtDef4.Text = ds.Tables("tblTest").Rows(Test_ID).Item(8)
        txtDef5.Text = ds.Tables("tblTest").Rows(Test_ID).Item(10)
        txtDef6.Text = ds.Tables("tblTest").Rows(Test_ID).Item(12)
        txtDef7.Text = ds.Tables("tblTest").Rows(Test_ID).Item(14)
        txtDef8.Text = ds.Tables("tblTest").Rows(Test_ID).Item(16)
        txtDef9.Text = ds.Tables("tblTest").Rows(Test_ID).Item(18)
        txtDef10.Text = ds.Tables("tblTest").Rows(Test_ID).Item(20)

        MsgBox("Good Luck!")

    End Sub

    'Button to mark the test, followed by the running of the various test marking subroutines'
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles btnFinish_Test.Click

        'This will run when the mark test button is pressed
        Presence_Check(Test_ID, User_Class)

    End Sub

    'Checks if the entries are all full'
    Private Sub Presence_Check(Test_ID, User_Class)

        'If statment checking to see if the console is open and the connection has been established'
        If conn.ConnectionString <> connstring Then
            'Console being opened to accept SQL commands'
            conn.ConnectionString = connstring
            conn.Open()
        End If

        'Defining The current Test ID variable
        Dim Test_ID_Search As String

        'This ensures the formating is correct for the search'
        Test_ID_Search = "T" & (Test_ID + 1)

        'This will pull the current data using a build in module ensuring the date is always as accurate as the computers'
        Dim todaysdate As String = String.Format("{0:dd/MM/yyyy}", DateTime.Now)

        'This select statment has two parameters in its search to narrow down the query results to what is needed'
        Dim Test_Mark As String = "SELECT * FROM tblTest WHERE TestID = '" & Test_ID_Search & "' AND Class = '" & User_Class & "' "
        'This defines the data adapter using and defining what the command string will be'
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(Test_Mark, conn)
        'This defines the data set variable into which query results will be placed within
        Dim ds As DataSet = New DataSet
        'This line tells the da adapter to fill a data set using the table "tblTest_Mark"
        da.Fill(ds, "tblTest_Mark")
        'This Line will define the datatable'
        Dim dt As DataTable = ds.Tables("tblTest_Mark")

        'Defines a few variables for use in the presence check loops
        Dim Counter As Integer = 1
        Dim Word_Count As Integer = 0

        'Defines an array that all the words will be associated with 1 - 10'
        Dim Word(9) As String
        Word(0) = txtAns1.Text
        Word(1) = txtAns2.Text
        Word(2) = txtAns3.Text
        Word(3) = txtAns4.Text
        Word(4) = txtAns5.Text
        Word(5) = txtAns6.Text
        Word(6) = txtAns7.Text
        Word(7) = txtAns8.Text
        Word(8) = txtAns9.Text
        Word(9) = txtAns10.Text

        'If statment that will contain a loop'
        If Counter = 22 Then
            Exit Sub
        Else
            'This Loop will ensure all the entered fields have data present within them and that they are of the length previously specified'
            Do Until Word_Count = 10
                'Presence check'
                If Word(Word_Count) <> "" Then
                    Word_Count = Word_Count + 1
                Else
                    'Prompt if the presence check finds missing data'
                    MsgBox("Please finish the test")
                    Exit Sub
                End If
                'Length Check'
                If Word(Word_Count - 1).Length > 40 Then
                    'Prompt if the length parameters are broken, supplying some information about the  problem field'
                    MsgBox("Answer " & Word_Count & " is Too long")
                    Word_Count = Word_Count + 1
                    Exit Sub
                End If
            Loop
        End If

        'Runs the test redo subroutine passing variables'
        Test_Redo(Test_ID, User_Class)
    End Sub

    'Checks if the user has already taken the test and if they want to delete old data and enter new data'
    Private Sub Test_Redo(Test_ID, User_Class)

        'If statment checking to see if the console is open and the connection has been established'
        If conn.ConnectionString <> connstring Then
            'Console being opened to accept SQL commands'
            conn.ConnectionString = connstring
            conn.Open()
        End If

        'This defines the Test ID string for searching'
        Dim Test_ID_Search As String
        'Some formating'
        Test_ID_Search = "T" & (Test_ID + 1)

        'This very detailed select statment will grab only one or no record in the database this being the one associated with the test the user it taking'
        Dim Test_Mark As String = "SELECT * FROM tblMark_info WHERE TestID = '" & Test_ID_Search & "' AND Class = '" & User_Class & "' AND UserID = '" & Login_screen.Username & "' "
        'Defining the data adapter and command string'
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(Test_Mark, conn)
        'defining the dataset'
        Dim ds As DataSet = New DataSet
        'telling the data adapter to fill the data set using the datatable'
        da.Fill(ds, "tblTest_Mark")
        'Defining the data table'
        Dim dt As DataTable = ds.Tables("tblTest_Mark")

        'variables for option message box'
        Dim msg As String = "You have already taken this test, do you want to overwrite it?"
        Dim style As MsgBoxStyle = MsgBoxStyle.YesNo

        'This will check if the user has already completed the current test being taken'
        If ds.Tables("tblTest_Mark").Rows.Count = 0 Then
            Mark_Test(Test_ID, User_Class)
            Exit Sub
            'This will run if the program locates a record in the database that matches those search parameters'
        ElseIf ds.Tables("tblTest_Mark").Rows(0).Item(1) = Login_screen.Username Then
            'THis select statment will run the configured message box'
            Select Case MsgBox(msg, style)
                'Conditional = No, it will not overwrite previous data'
                Case MsgBoxResult.No
                    MsgBox("Test Not saved")
                    'Unlock()
                    Exit Sub
                    'Conditional = Yes, it will run the overwrite subroutine'
                Case MsgBoxResult.Yes
                    Delete_Old_Mark(Test_ID_Search, User_Class)
                    MsgBox("Test Overwritten")
                    Exit Sub
            End Select
        End If

    End Sub

    'This deletes previous test data from the user to enter new data'
    Private Sub Delete_Old_Mark(Test_ID_Search, User_Class)

        'If statment checking to see if the console is open and the connection has been established'
        If conn.ConnectionString <> connstring Then
            'Console being opened to accept SQL commands'
            conn.ConnectionString = connstring
            conn.Open()
        End If

        'This if statement will check if the connection has been shut and if so will reopen it'
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If

        'Sql Query
        Dim Delete_Mark As String = "DELETE FROM tblMark_info WHERE TestID = @TestID AND Class = @Class "

        'This variable defines the console command'
        Dim SqlCommand As New OleDbCommand
        'This block defines the variables that are to be inserted into the database'
        With SqlCommand
            .CommandText = Delete_Mark
            'These variables are the ones to be inserted'
            .Parameters.AddWithValue("@TestID", Test_ID_Search)
            .Parameters.AddWithValue("@Class", User_Class)
            .Connection = conn
            'Executes the insert'
            .ExecuteNonQuery()
        End With

        'Runs the mark test loop
        Mark_Test(Test_ID, User_Class)

    End Sub

    'This function marks the entire test'
    Private Sub Mark_Test(Test_ID, User_Class)

        'If statment checking to see if the console is open and the connection has been established'
        If conn.ConnectionString <> connstring Then
            'Console being opened to accept SQL commands'
            conn.ConnectionString = connstring
            conn.Open()
        End If

        'This variable defines the Test ID to be searched'
        Dim Test_ID_Search As String
        'Some formating for the label'
        Test_ID_Search = "T" & (Test_ID + 1)

        'Grabs the current data from the computer'
        Dim todaysdate As String = String.Format("{0:dd/MM/yyyy}", DateTime.Now)

        'THis sql statment will grab all the records associated with this test id and the users class, THis should find only one record'
        Dim Test_Mark As String = "SELECT * FROM tblTest WHERE TestID = '" & Test_ID_Search & "' AND Class = '" & User_Class & "' "
        'Defining the data adapter and command string'
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(Test_Mark, conn)
        'Defining the dataset'
        Dim ds As DataSet = New DataSet
        'Telling the data adapter to fill the data set using the datatable'
        da.Fill(ds, "tblTest_Mark")
        'Defining the data table'
        Dim dt As DataTable = ds.Tables("tblTest_Mark")

        'Defining some marking variables;
        Dim Counter As Integer = 1
        Dim Current_Mark As Integer = 0
        Dim Word_Count As Integer = -1
        'THis is the word array, filling each section of the array with a word from this group'
        Dim Word(9) As String
        Word(0) = txtAns1.Text
        Word(1) = txtAns2.Text
        Word(2) = txtAns3.Text
        Word(3) = txtAns4.Text
        Word(4) = txtAns5.Text
        Word(5) = txtAns6.Text
        Word(6) = txtAns7.Text
        Word(7) = txtAns8.Text
        Word(8) = txtAns9.Text
        Word(9) = txtAns10.Text

        'This part of the if statment checks if the test is present in the database'
        If ds.Tables("tblTest_Mark").Rows.Count > 0 Then
            If Counter = 22 Then
                MsgBox("mark complete")
            Else
                'This loop will check each word to see if it matches the corresponding word in the database if not the length, if that fails it awards it no marks'
                Do Until Word_Count = 9
                    Word_Count = Word_Count + 1
                    'This will check the word agaisnt the correct entry in the database'
                    If Word(Word_Count) = ds.Tables("tblTest_Mark").Rows(0).Item(Counter) Then
                        Current_Mark = Current_Mark + 2
                        Counter = Counter + 2
                        'This will see if the word does not match and take it a step further'
                    ElseIf Word(Word_Count) <> ds.Tables("tblTest_Mark").Rows(0).Item(Counter) Then
                        Current_Mark = Current_Mark + 0
                        Counter = Counter + 0
                        'THis will check the length against the origina'
                        If Word(Word_Count).Length = ds.Tables("tblTest_Mark").Rows(0).Item(Counter).Length Then
                            Current_Mark = Current_Mark + 1
                            Counter = Counter + 2
                        Else
                            'This part will then award the word no marks as it matches neither parameter'
                            Current_Mark = Current_Mark + 0
                            Counter = Counter + 2
                        End If
                    End If
                Loop
            End If
        Else
            'This will display if no test matching those parameters is found'
            MsgBox("No test data found")
        End If

        'This will once again check if the connection is open and will open it, if its closed'
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If

        'This will insert the mark group into the table along side the users information, class, user id, test id and the data'
        Dim Test_Finish_Insert As String = " INSERT INTO tblMark_info ([TestID],[UserID],[Mark],[Date],[Class]) VALUES (@TestID,@UserID,@Mark,@Date,@Class)"
        'This defines the console command'
        Dim SQL_Command As New OleDbCommand
        'This will use these parameterers and associated variables to insert data into the database'
        With SQL_Command
            .CommandText = Test_Finish_Insert
            .Parameters.AddWithValue("@TestID", Test_ID_Search)
            .Parameters.AddWithValue("@UserID", Login_screen.Username)
            .Parameters.AddWithValue("@Mark", Current_Mark)
            .Parameters.AddWithValue("@Date", todaysdate)
            .Parameters.AddWithValue("@Class", User_Class)
            .Connection = conn
            'This excutes the add data values'
            .ExecuteNonQuery()
        End With

        'This tells the user the mark they gained signifying that the test was saved successfully'
        MsgBox("Score is: " & Current_Mark)

        'Unlock()

    End Sub



    Private Sub Clear()

        'This block clears the entries so that the user may enter different values  if a mistake is made(clearing the temporary storage)'
        txtAns1.Text = ""
        txtAns2.Text = ""
        txtAns3.Text = ""
        txtAns4.Text = ""
        txtAns5.Text = ""
        txtAns6.Text = ""
        txtAns7.Text = ""
        txtAns8.Text = ""
        txtAns9.Text = ""
        txtAns10.Text = ""

    End Sub

    'Clear Answer Columns'
    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click

        Clear()

    End Sub


    'Private Sub Lockout()

    '    'This disables buttons so that the student cant leave the test until its completed'
    '    btnSee_Next_Test_Take_Test.Enabled = False
    '    btnSee_Old_Marks_Take_Test.Enabled = False
    '    btnTake_Test_Take_Test.Enabled = False

    'End Sub


    'Private Sub Unlock()

    '    'This unlocks the buttons so the student can move after the test is completed.
    '    btnSee_Next_Test_Take_Test.Enabled = True
    '    btnSee_Old_Marks_Take_Test.Enabled = True
    '    btnTake_Test_Take_Test.Enabled = True

    'End Sub


    'Load event starts off all automated functions'
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'This will run this form on load'
        Grab_user_Information()
        'Lockout()

    End Sub

End Class