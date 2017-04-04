'Imports'
Imports System.Data.OleDb
Public Class Teacher_Menu_Test_Library

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

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Me.Close()
        Teacher_Menu_Class_Marks.Show()

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        Me.Close()
        Login_screen.Show()

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click

        Me.Close()
        Teacher_Menu_Account_Management.Show()

    End Sub

    'This will populate all the text fields with data associated with the test id searched'
    Private Sub Load_Tests(User_Class)

        If conn.ConnectionString <> connstring Then
            'Console being opened to accept SQL commands'
            conn.ConnectionString = connstring
            conn.Open()
        End If

        Dim Test_Display As String

        Test_Display = txtTest_Name.Text

        If Test_Display = "" Then
            MsgBox("Please Enter A Test")
            Clear_Tab2()
            Exit Sub
        ElseIf Test_Display.Length > 5 Then
            MsgBox("Test ID is too long")
            Clear_Tab2()
            Exit Sub
        End If

        Dim Test_ID_Populate_Fields As String = "SELECT * FROM tblTest WHERE TestID = '" & Test_Display & "' AND Class = '" & User_Class & "' "
        'defining the data adapter'
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(Test_ID_Populate_Fields, conn)
        'defining the data set'
        Dim ds As DataSet = New DataSet
        'filling the data set'
        da.Fill(ds, "tblTest")
        'defining the datatable'
        Dim dt As DataTable = ds.Tables("tblTest")

        'try that will fill the output text boxes, if no data is present it will run the catch exception'
        Try
            'This block will place the words into the appropriate text boxes'
            txtword1.Text = ds.Tables("tblTest").Rows(0).Item(1)
            txtword2.Text = ds.Tables("tblTest").Rows(0).Item(3)
            txtword3.Text = ds.Tables("tblTest").Rows(0).Item(5)
            txtword4.Text = ds.Tables("tblTest").Rows(0).Item(7)
            txtword5.Text = ds.Tables("tblTest").Rows(0).Item(9)
            txtword6.Text = ds.Tables("tblTest").Rows(0).Item(11)
            txtword7.Text = ds.Tables("tblTest").Rows(0).Item(13)
            txtword8.Text = ds.Tables("tblTest").Rows(0).Item(15)
            txtword9.Text = ds.Tables("tblTest").Rows(0).Item(17)
            txtword10.Text = ds.Tables("tblTest").Rows(0).Item(19)

            'This block will place text into the appropriate text boxes matching the words'
            txtdef1.Text = ds.Tables("tblTest").Rows(0).Item(2)
            txtdef2.Text = ds.Tables("tblTest").Rows(0).Item(4)
            txtdef3.Text = ds.Tables("tblTest").Rows(0).Item(6)
            txtdef4.Text = ds.Tables("tblTest").Rows(0).Item(8)
            txtdef5.Text = ds.Tables("tblTest").Rows(0).Item(10)
            txtdef6.Text = ds.Tables("tblTest").Rows(0).Item(12)
            txtdef7.Text = ds.Tables("tblTest").Rows(0).Item(14)
            txtdef8.Text = ds.Tables("tblTest").Rows(0).Item(16)
            txtdef9.Text = ds.Tables("tblTest").Rows(0).Item(18)
            txtdef10.Text = ds.Tables("tblTest").Rows(0).Item(20)
        Catch ex As Exception
            MsgBox("Test not found")
            Clear_Tab2()
        End Try

    End Sub

    'This defines the user class string for public access'
    Public User_Class As String
    'This subroutine fetches all the information from the database'
    Private Sub Grab_user_Information()

        If conn.ConnectionString <> connstring Then
            'Console being opened to accept SQL commands'
            conn.ConnectionString = connstring
            conn.Open()
        End If

        'Used to reference User Information'
        Dim User_Data As String = "SELECT * FROM tblUser_info WHERE UserID = '" & Login_screen.Username & "' "
        'defining the data adapter'
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(User_Data, conn)
        'defining the dataset'
        Dim ds As DataSet = New DataSet
        'filling the dataset'
        da.Fill(ds, "Indiv_User_Info2")
        'defining the datatable'
        Dim dt2 As DataTable = ds.Tables("Indiv_User_Info2")

        lblTeacher_Username.Text = ds.Tables("Indiv_User_Info2").Rows(0).Item(1)
        User_Class = ds.Tables("Indiv_User_Info2").Rows(0).Item(3)

        Fill_Table(User_Class)

    End Sub

    'This load event will run all the subroutines within it when the form loads'
    Private Sub Teacher_Menu_Test_Library_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Fill_Table(User_Class)
        Grab_user_Information()

    End Sub

    'This will populate the Data grid view with all available tests associated with that users class'
    Private Sub Fill_Table(User_Class)

        If conn.ConnectionString <> connstring Then
            'Console being opened to accept SQL commands'
            conn.ConnectionString = connstring
            conn.Open()
        End If

        'sql string that fetches all the test records that match the class'
        Dim Test_Library As String = "SELECT * FROM tblTest WHERE Class = '" & User_Class & "' "
        'defining the data adapter'
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(Test_Library, conn)
        'defining the dataset'
        Dim ds As DataSet = New DataSet
        'filling the dataset'
        da.Fill(ds, "Test_History")
        'defining the datatable'
        Dim dt As DataTable = ds.Tables("Test_History")

        'This defines where the data is sourced, that will be used to populate the datagrid view'
        With dgvTest_History
            .AutoGenerateColumns = True
            .DataSource = ds
            .DataMember = "Test_History"
        End With

        'This hides all the superflous columns in the database as only the first two are needed for a sufficient preview'
        dgvTest_History.Columns(3).Visible = False
        dgvTest_History.Columns(4).Visible = False
        dgvTest_History.Columns(5).Visible = False
        dgvTest_History.Columns(6).Visible = False
        dgvTest_History.Columns(7).Visible = False
        dgvTest_History.Columns(8).Visible = False
        dgvTest_History.Columns(9).Visible = False
        dgvTest_History.Columns(10).Visible = False
        dgvTest_History.Columns(11).Visible = False
        dgvTest_History.Columns(12).Visible = False
        dgvTest_History.Columns(13).Visible = False
        dgvTest_History.Columns(14).Visible = False
        dgvTest_History.Columns(15).Visible = False
        dgvTest_History.Columns(16).Visible = False
        dgvTest_History.Columns(17).Visible = False
        dgvTest_History.Columns(18).Visible = False
        dgvTest_History.Columns(19).Visible = False
        dgvTest_History.Columns(20).Visible = False


    End Sub

    'This will delete a test from the database using the id entered'
    Private Sub Delete_Test(User_Class)

        If conn.ConnectionString <> connstring Then
            'Console being opened to accept SQL commands'
            conn.ConnectionString = connstring
            conn.Open()
        End If

        'User variable for deletion'
        Dim Delete_Test As String = txtDelete_Test.Text

        'Presence checking the input box'
        If Delete_Test = "" Then
            'Presence check prompt'
            MsgBox("Please Enter A Test For Deletion")

            Exit Sub
        ElseIf Delete_Test.Length > 5 Then
            MsgBox("Test ID is too long")
            Exit Sub
        End If

        Dim Test_Library As String = "SELECT * FROM tblTest WHERE Class = '" & User_Class & "' AND TestID = '" & Delete_Test & "' "
        'defining the data adapter'
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(Test_Library, conn)
        'defining the dataset'
        Dim ds As DataSet = New DataSet
        'filling the dataset'
        da.Fill(ds, "Test_History")
        'defining the datatable'
        Dim dt As DataTable = ds.Tables("Test_History")

        'checking that the datatable contains any data'
        If ds.Tables("Test_History").Rows.Count = 0 Then
            MsgBox("No test located")
            Exit Sub
        End If

        'This sql statment will be used to delete a test from the database'
        Dim Delete_Test_Record As String = "DELETE FROM tblTest WHERE TestID = @Test_ID AND Class = '" & User_Class & "' "
        'Adding information to the database'
        Dim SqlCommand As New OleDbCommand
        With SqlCommand
            .CommandText = Delete_Test_Record
            'This is the parameter that associates the sql statment with the variable containing the Test ID'
            .Parameters.AddWithValue("@Test_ID", txtDelete_Test.Text)
            .Connection = conn
            .ExecuteNonQuery()
        End With


        'This will prompt the user telling them they have deleted a test successfully'
        MsgBox("Test Deleted")

        'Empties content of textbox for next input'
        txtDelete_Test.Text = ""

    End Sub

    'This button will run the delete function'
    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click

        Delete_Test(User_Class)
        Fill_Table(User_Class)
        Grab_user_Information()

    End Sub

    'subroutine that will clear the output text boxes'
    Private Sub Clear_Tab2()

        'This will clear the word column clearing the data'
        txtword1.Text = ""
        txtword2.Text = ""
        txtword3.Text = ""
        txtword4.Text = ""
        txtword5.Text = ""
        txtword6.Text = ""
        txtword7.Text = ""
        txtword8.Text = ""
        txtword9.Text = ""
        txtword10.Text = ""

        'This will clear the defintion column clearing the data'
        txtdef1.Text = ""
        txtdef2.Text = ""
        txtdef3.Text = ""
        txtdef4.Text = ""
        txtdef5.Text = ""
        txtdef6.Text = ""
        txtdef7.Text = ""
        txtdef8.Text = ""
        txtdef9.Text = ""
        txtdef10.Text = ""


    End Sub

    'THis will run the load test subroutine'
    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click

        Load_Tests(User_Class)

    End Sub

End Class