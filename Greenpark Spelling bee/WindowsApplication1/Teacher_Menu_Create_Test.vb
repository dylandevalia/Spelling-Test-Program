'Imports'
Imports System.Data.OleDb

Public Class Teacher_Menu_Create_Test

    'Connecting to database'
    Public connstring As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Greenpark_spellingBee.accdb"
    Public conn As New OleDbConnection

    'Navigational buttons'
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

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click

        Me.Close()
        Teacher_Menu_Account_Management.Show()

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        Me.Close()
        Login_screen.Show()

    End Sub

    'This defines the Class the user belongs to variable as a public variable' 
    Friend User_Class As String
    'This defines the Test ID string that is used throughout this Form'
    Friend Final_ID As String

    'This subroutine Ensures data is present in all the fields and doesnt exceed the maximum capacity'
    Private Sub Presence_Check()

        Dim Counter As Integer = 1
        Dim Current_Mark As Integer = 0
        Dim Word(19) As String
        Word(0) = txtword1.Text
        Word(1) = txtword2.Text
        Word(2) = txtword3.Text
        Word(3) = txtword4.Text
        Word(4) = txtword5.Text
        Word(5) = txtword6.Text
        Word(6) = txtword7.Text
        Word(7) = txtword8.Text
        Word(8) = txtword9.Text
        Word(9) = txtword10.Text
        Word(10) = txtdef1.Text
        Word(11) = txtdef2.Text
        Word(12) = txtdef3.Text
        Word(13) = txtdef4.Text
        Word(14) = txtdef5.Text
        Word(15) = txtdef6.Text
        Word(16) = txtdef7.Text
        Word(17) = txtdef8.Text
        Word(18) = txtdef9.Text
        Word(19) = txtdef10.Text

        Dim Word_Count As Integer = 0

        If Counter = 19 Then
            Exit Sub
        Else
            Do Until Word_Count = 20
                If Word(Word_Count) <> "" Then
                    Word_Count = Word_Count + 1
                Else
                    MsgBox("Please Fill all Text boxes to complete the text")
                    Exit Sub
                End If
                If Word_Count < 10 Then
                    If Word(Word_Count - 1).Length > 40 Then
                        MsgBox("Word " & Word_Count & " is Too long")
                        Word_Count = Word_Count + 1
                        Exit Sub
                    End If
                ElseIf Word_Count >= 10 Then
                    If Word(Word_Count - 1).Length > 200 Then
                        MsgBox("Defintion " & Word_Count & " is Too long")
                        Word_Count = Word_Count + 1
                        Exit Sub
                    End If

                End If
            Loop
        End If

        Get_User_Class()

    End Sub

    'This button initiates the validation sub routine'
    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click

        Presence_Check()

    End Sub

    'This load event fills the side panel with user data'
    Private Sub Teacher_Menu_Create_Test_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Grab_user_Information()

    End Sub

    'This subroutine inserts all the test data and data associated with the test into the database (Words, Definitions, dates, classes) ' 
    Private Sub Create_Test(User_Class, Final_ID)

        If conn.ConnectionString <> connstring Then
            'Console being opened to accept SQL commands'
            conn.ConnectionString = connstring
            conn.Open()
        End If

        Dim todaysdate As String = String.Format("{0:dd/MM/yyyy}", DateTime.Now)

        Generate_Test_ID(User_Class)

        Dim SQL_Insert As String = "INSERT INTO tblTest (TestID,Word_1,Word_2,Word_3,Word_4,Word_5,Word_6,Word_7,Word_8,Word_9,Word_10,Definition_1,Definition_2,Definition_3,Definition_4,Definition_5,Definition_6,Definition_7,Definition_8,Definition_9,Definition_10,Class,Date_now) VALUES (@Test_ID_Update,@word_1,@word_2,@word_3,@word_4,@word_5,@word_6,@word_7,@word_8,@word_9,@word_10,@definition_1,@definition_2,@definition_3,@definition_4,@definition_5,@definition_6,@definition_7,@definition_8,@definition_9,@definition_10,@Class,@date_now)"
        Dim SQL_Command As New OleDbCommand
        With SQL_Command
            .CommandText = SQL_Insert
            .Parameters.AddWithValue("@Test_ID_Update", Final_ID)
            .Parameters.AddWithValue("@word_1", txtword1.Text)
            .Parameters.AddWithValue("@word_2", txtword2.Text)
            .Parameters.AddWithValue("@word_3", txtword3.Text)
            .Parameters.AddWithValue("@word_4", txtword4.Text)
            .Parameters.AddWithValue("@word_5", txtword5.Text)
            .Parameters.AddWithValue("@word_6", txtword6.Text)
            .Parameters.AddWithValue("@word_7", txtword7.Text)
            .Parameters.AddWithValue("@word_8", txtword8.Text)
            .Parameters.AddWithValue("@word_9", txtword9.Text)
            .Parameters.AddWithValue("@word_10", txtword10.Text)
            .Parameters.AddWithValue("@defintion_1", txtdef1.Text)
            .Parameters.AddWithValue("@defintion_2", txtdef2.Text)
            .Parameters.AddWithValue("@defintion_3", txtdef3.Text)
            .Parameters.AddWithValue("@defintion_4", txtdef4.Text)
            .Parameters.AddWithValue("@defintion_5", txtdef5.Text)
            .Parameters.AddWithValue("@defintion_6", txtdef6.Text)
            .Parameters.AddWithValue("@defintion_7", txtdef7.Text)
            .Parameters.AddWithValue("@defintion_8", txtdef8.Text)
            .Parameters.AddWithValue("@defintion_9", txtdef9.Text)
            .Parameters.AddWithValue("@defintion_10", txtdef10.Text)
            .Parameters.AddWithValue("@Class", User_Class)
            .Parameters.AddWithValue("@date_now", todaysdate)
            .Connection = conn
            .ExecuteNonQuery()
        End With

        MsgBox("Test: " + Final_ID + " Saved successfully")

    End Sub

    'This subroutine generates a test id to be inserted with the test'
    Public Sub Generate_Test_ID(User_Class)

        If conn.ConnectionString <> connstring Then
            'Console being opened to accept SQL commands'
            conn.ConnectionString = connstring
            conn.Open()
        End If

        Dim Test_ID_Initial_Check As String = "SELECT * FROM tblTest WHERE Class = '" & User_Class & "' "
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(Test_ID_Initial_Check, conn)
        Dim ds As DataSet = New DataSet
        da.Fill(ds, "tblTest")
        Dim dt As DataTable = ds.Tables("tblTest")

        Dim Max As Integer = 0
        Dim Counter As Integer = 0
        Dim Test_ID_Update As Integer = 0

        If ds.Tables.Count = 0 Then
            ds.Tables("tblTest").Rows(Counter).Item(0) = "T1"
        Else
            For Each row As DataRow In dt.Rows
                Dim Test_ID_Split As String = ds.Tables("tblTest").Rows(Counter).Item(0)
                If Test_ID_Split.Length = 2 Then
                    Test_ID_Update = Test_ID_Split.Substring(Test_ID_Split.Length - 1)
                ElseIf Test_ID_Split.Length = 3 Then
                    Test_ID_Update = Test_ID_Split.Substring(Test_ID_Split.Length - 2)
                ElseIf Test_ID_Split.Length = 4 Then
                    Test_ID_Update = Test_ID_Split.Substring(Test_ID_Split.Length - 3)
                ElseIf Test_ID_Split.Length = 5 Then
                    Test_ID_Update = Test_ID_Split.Substring(Test_ID_Split.Length - 4)
                End If
                If Test_ID_Update > Max Then
                    Max = Test_ID_Update
                    Counter = Counter + 1
                End If
            Next
        End If

        Max = Max + 1
        Final_ID = "T" & Max

        Dim todaysdate As String = String.Format("{0:dd/MM/yyyy}", DateTime.Now)
        txtCurrent_Date.Text = todaysdate

        txtTest_Number.Text = Final_ID

    End Sub

    'This subroutine generates the class the user belongs to
    Public Sub Grab_user_Information()

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
        Dim dt2 As DataTable = ds.Tables("Indiv_User_Info2")

        Dim First_Name As String = ds.Tables("Indiv_User_Info2").Rows(0).Item(1)
        lblTeacher_Username.Text = First_Name

        User_Class = ds.Tables("Indiv_User_Info2").Rows(0).Item(3)

        Generate_Test_ID(User_Class)

    End Sub

    Public Sub Get_User_Class()

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
        Dim dt2 As DataTable = ds.Tables("Indiv_User_Info2")

        User_Class = ds.Tables("Indiv_User_Info2").Rows(0).Item(3)

        Create_Test(User_Class, Final_ID)

    End Sub

End Class