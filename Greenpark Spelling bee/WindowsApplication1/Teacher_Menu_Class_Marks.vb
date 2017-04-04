'Imports'
Imports System.Data.OleDb

Public Class Teacher_Menu_Class_Marks

    'Connecting to database'
    Public connstring As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Greenpark_spellingBee.accdb"
    Public conn As New OleDbConnection

    'Navigational buttons'
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Me.Close()
        Teacher_Menu_Create_Test.Show()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Me.Close()
        Teacher_Menu_See_Old_Marks.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        Me.Close()
        Teacher_Menu_Test_Library.Show()


    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click

        Me.Close()
        Teacher_Menu_Account_Management.Show()

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        Me.Close()
        Login_screen.Show()


    End Sub

    'This variable defines the Class the user belongs to as a global variable'
    Public User_Class As String

    Public Test_ID As String
    'Generates the User Class using the login username'
    Public Sub Get_User_Class()

        If conn.ConnectionString <> connstring Then
            'Console being opened to accept SQL commands'
            conn.ConnectionString = connstring
            conn.Open()
        End If

        'Used to reference User Information'
        'sql string that will fetch all records associated with the user name used to log in'
        Dim User_Data As String = "SELECT * FROM tblUser_info WHERE UserID = '" & Login_screen.Username & "' "
        'defining the data adapter'
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(User_Data, conn)
        'defining the data set'
        Dim ds As DataSet = New DataSet
        'filling the dataset'
        da.Fill(ds, "Indiv_User_Info2")
        'defining the datatable'
        Dim dt2 As DataTable = ds.Tables("Indiv_User_Info2")

        'associating the user class variable with the forth item on the first record found'
        User_Class = ds.Tables("Indiv_User_Info2").Rows(0).Item(3)

        'associating the user class variable with the second item on the first record found'
        lblTeacher_Username.Text = ds.Tables("Indiv_User_Info2").Rows(0).Item(1)

        Search_Marks(User_Class)

    End Sub

    'This sub will search the mark information table for any records that match the test id searched, from students within his class'
    Private Sub Search_Marks(User_Class)

        If conn.ConnectionString <> connstring Then
            'Console being opened to accept SQL commands'
            conn.ConnectionString = connstring
            conn.Open()
        End If

        'associating test id variable with the text box
        Test_ID = txtTest_ID_Class_Marks.Text

        'presence check for test id'
        If Test_ID = "" Then
            MsgBox("Please Enter a Test ID")
            Exit Sub
            'length check for the test id'
        ElseIf Test_ID.Length > 5 Then
            MsgBox("Test ID is too long")
            'secondary length check for test id'
        ElseIf Test_ID.Length = 1 Then
            MsgBox("Test ID Format Incorrect")
            Exit Sub
        End If

        'substring split for further format checking'
        Dim Test_ID_Format As String = Test_ID.Substring(0, 1)

        'this checks to see if the test formating is correct'
        If Test_ID_Format <> "T" Then
            MsgBox("Test ID Format Incorrect")
            Exit Sub
        End If

        'Checks if the Test ID's Length'
        If Test_ID.Length = 1 Then
            MsgBox("Test ID Format Incorrect")
        End If

        'counter variable'
        Dim counter As Integer = 0

        'further type checking'
        Do Until counter = Test_ID_Format.Length
            'if it finds an invalid character in the name then it exits the subroutine displaying this message'
            If Char.IsNumber(Test_ID_Format, counter) = True Then
                'error message'
                MsgBox("Invalid Test ID")
                Exit Sub
            ElseIf Char.IsSymbol(Test_ID_Format, counter) = True Then
                MsgBox("Invalid Test ID")
                Exit Sub
            ElseIf Char.IsPunctuation(Test_ID_Format, counter) = True Then
                MsgBox("Invalid Test ID")
                Exit Sub
            Else
                'this counter moves foward a letter if the current is not a number'
                counter = counter + 1
            End If
        Loop

        'sql string that will fetch all records associated with the users class and the type/format checked test id input'
        Dim Test_Marks As String = "SELECT * FROM tblMark_info WHERE TestID = '" & Test_ID & "' AND Class = '" & User_Class & "' "
        'defining the data adapter'
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(Test_Marks, conn)
        'defining the the data set
        Dim ds As DataSet = New DataSet
        'filling the data set'
        da.Fill(ds, "Test_Mark")
        'defining the data table'
        Dim dt As DataTable = ds.Tables("Test_Mark")

        'checking if the datatable contains anything "presence check"'
        If ds.Tables("Test_Mark").Rows.Count = 0 Then
            MsgBox("Test ID not Found")
            Exit Sub
        End If

        'with statement that will fill a data grid view'
        With dgvClass_Progress
            .AutoGenerateColumns = True
            .DataSource = ds
            .DataMember = "Test_Mark"
        End With

        Progress_Calculator(User_Class)

        'report form'
        Teacher_Menu_Class_Marks_RV.Show()

    End Sub

    'This subroutine will calculate all the averages associated with class data'
    Private Sub Progress_Calculator(User_Class)

        If conn.ConnectionString <> connstring Then
            'Console being opened to accept SQL commands'
            conn.ConnectionString = connstring
            conn.Open()
        End If

        'sql string that will fetch all records associated with the users class and the type/format checked test id input'
        Dim Progress_info As String = "SELECT * FROM tblMark_info WHERE Class = '" & User_Class & "' AND TestID = '" & txtTest_ID_Class_Marks.Text & "' "
        'defining the data adapter'
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(Progress_info, conn)
        'defining the the data set
        Dim ds As DataSet = New DataSet
        'filling the data set'
        da.Fill(ds, "User_Info")
        'defining the data table'
        Dim dt As DataTable = ds.Tables("User_Info")

        'checking if the datatable contains anything "presence check"'
        If ds.Tables("User_Info").Rows.Count = 0 Then
            Exit Sub
        End If

        ' Average User Score Calculator '
        Dim Class_Average As Integer = 0
        Dim Counter As Integer = 0

        'this will cycle through each loop adding all the mark info and then making a number of marks counted value'
        For Each row As DataRow In dt.Rows
            Class_Average = Class_Average + ds.Tables("User_Info").Rows(Counter).Item(2)
            Counter = Counter + 1
        Next

        ' Class Average '
        'average calculation'
        Class_Average = Class_Average / Counter
        txtClass_Average.Text = Class_Average

        ' Highest Score ' 

        ' Lowest Score '

        ' Merit Locator '

        Dim Merit_Counter As Integer = 0

        'this will highlight all the rows that are merit worthy gold, a mark equal to or greater then 18'
        For Each row As DataRow In dt.Rows
            If ds.Tables("User_Info").Rows(Merit_Counter).Item(2) >= 18 Then
                dgvClass_Progress.Rows(Merit_Counter).DefaultCellStyle.BackColor = Color.Gold
            End If
            Merit_Counter = Merit_Counter + 1
        Next

        ' DeMerit Locator '

        Dim demerit_Counter As Integer = 0

        'this will highlight all the rows that are merit worthy red, a mark equal to or less then 5'
        For Each row As DataRow In dt.Rows
            If ds.Tables("User_Info").Rows(demerit_Counter).Item(2) <= 5 Then
                dgvClass_Progress.Rows(demerit_Counter).DefaultCellStyle.BackColor = Color.Red
            End If
            demerit_Counter = demerit_Counter + 1
        Next


    End Sub

    'This will run all the subroutines to search the database'
    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click

        Get_User_Class()

    End Sub

    Private Sub dgvClass_Progress_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvClass_Progress.CellContentClick

    End Sub
End Class