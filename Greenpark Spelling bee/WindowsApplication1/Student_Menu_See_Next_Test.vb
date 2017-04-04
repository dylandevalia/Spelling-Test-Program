'Imports'
Imports System.Data.OleDb

Public Class Student_Menu_See_Next_Test

    'Connecting to database'
    Public connstring As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Greenpark_spellingBee.accdb"
    Public conn As New OleDbConnection

    'Navigational Buttons'
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnTake_Test_See_Next_Test.Click

        Me.Close()
        Student_Menu_Take_Test.Show()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnSee_Old_Marks_See_Next_Test.Click

        Me.Close()
        Student_Menu_See_Old_Marks.Show()


    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles btnLogOff.Click

        Me.Close()
        Login_screen.WindowState = FormWindowState.Normal

        'This block clears the entries so that the next user may enter different values (clearing the temporary storage)'
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

    'THis is the load subroutine'
    Private Sub Student_Menu_See_Next_Test_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'This will run this subroutine'
        Get_User_Class()

    End Sub

    'This Defines the User class variable for public use'
    Public User_Class As String

    'This subroutine will generate the user class'
    Public Sub Get_User_Class()

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
        da.Fill(ds, "Indiv_User_Info")
        'Defining the data table'
        Dim dt As DataTable = ds.Tables("Indiv_User_Info")

        'This grabs the User_Class and assigns a variable'
        User_Class = ds.Tables("Indiv_User_Info").Rows(0).Item(3)

        'This will change a label the name of the current User'
        Dim First_Name As String = ds.Tables("Indiv_User_Info").Rows(0).Item(1)
        lblStudent_Name.Text = First_Name

        'This will change the year to the year the user belongs too;
        Dim Year As String = ds.Tables("Indiv_User_Info").Rows(0).Item(3)
        lblStudent_Year.Text = Year

        'THis will run this subroutine'
        Grab_test(User_Class)

    End Sub

    Private Sub Grab_test(User_Class)

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

        Dim Test_ID As Integer = 0

        'This will check if there is only one test in the database'
        If Max < 2 Then
            Test_ID = Max - 1
        Else
            Test_ID = Max - 1
        End If

        'Formating a label to demonstrate the test being displayed'
        Dim Test_ID_Label As String = "T" & (Max)
        'This label will display the test the user is taking'
        lblSee_Next_Test.Text = "The test you will be taking next test day is: " + Test_ID_Label

        'This block will place the words into the appropriate text boxes'
        txtword1.Text = ds.Tables("tblTest").Rows(Test_ID).Item(1)
        txtword2.Text = ds.Tables("tblTest").Rows(Test_ID).Item(3)
        txtword3.Text = ds.Tables("tblTest").Rows(Test_ID).Item(5)
        txtword4.Text = ds.Tables("tblTest").Rows(Test_ID).Item(7)
        txtword5.Text = ds.Tables("tblTest").Rows(Test_ID).Item(9)
        txtword6.Text = ds.Tables("tblTest").Rows(Test_ID).Item(11)
        txtword7.Text = ds.Tables("tblTest").Rows(Test_ID).Item(13)
        txtword8.Text = ds.Tables("tblTest").Rows(Test_ID).Item(15)
        txtword9.Text = ds.Tables("tblTest").Rows(Test_ID).Item(17)
        txtword10.Text = ds.Tables("tblTest").Rows(Test_ID).Item(19)

        'This block will place text into the appropriate text boxes matching the words'
        txtdef1.Text = ds.Tables("tblTest").Rows(Test_ID).Item(2)
        txtdef2.Text = ds.Tables("tblTest").Rows(Test_ID).Item(4)
        txtdef3.Text = ds.Tables("tblTest").Rows(Test_ID).Item(6)
        txtdef4.Text = ds.Tables("tblTest").Rows(Test_ID).Item(8)
        txtdef5.Text = ds.Tables("tblTest").Rows(Test_ID).Item(10)
        txtdef6.Text = ds.Tables("tblTest").Rows(Test_ID).Item(12)
        txtdef7.Text = ds.Tables("tblTest").Rows(Test_ID).Item(14)
        txtdef8.Text = ds.Tables("tblTest").Rows(Test_ID).Item(16)
        txtdef9.Text = ds.Tables("tblTest").Rows(Test_ID).Item(18)
        txtdef10.Text = ds.Tables("tblTest").Rows(Test_ID).Item(20)

        conn.Close()

    End Sub

End Class