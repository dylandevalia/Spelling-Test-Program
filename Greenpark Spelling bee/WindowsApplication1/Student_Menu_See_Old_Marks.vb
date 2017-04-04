'Imports'
Imports System.Data.OleDb
Public Class Student_Menu_See_Old_Marks

    'Connecting to database'
    Public connstring As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Greenpark_spellingBee.accdb"
    Public conn As New OleDbConnection

    'Navigational Buttons'
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnTake_Test_See_Old_Marks.Click

        Me.Close()
        Student_Menu_Take_Test.Show()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btSee_Next_Test_See_Old_Marks.Click

        Me.Close()
        Student_Menu_See_Next_Test.Show()

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles btnLogOff.Click

        Me.Close()
        Login_screen.Show()

    End Sub

    'This subroutine will fetch all data linked with the username used to login with'
    Private Sub Grab_user_Information()

        If conn.ConnectionString <> connstring Then
            'Console being opened to accept SQL commands'
            conn.ConnectionString = connstring
            conn.Open()
        End If

        'Used to reference User Information'
        Dim User_Data As String = "SELECT * FROM tblUser_info WHERE UserID = '" & Login_screen.Username & "' "
        'Defines the data adapter'
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(User_Data, conn)
        'This defines the dataset'
        Dim ds As DataSet = New DataSet
        'This fills the dataset with information from the data adapter'
        da.Fill(ds, "Indiv_User_Info2")
        'This defines the data table'
        Dim dt2 As DataTable = ds.Tables("Indiv_User_Info2")

        'This defines the Firstname variable that will display the first name of the user on the nav pannel'
        Dim First_Name As String = ds.Tables("Indiv_User_Info2").Rows(0).Item(1)
        'This assiocates the variable first name with the text box first name
        lblStudent_Name.Text = First_Name

        'Defines the year string as the class the use belongs to'
        Dim Year As String = ds.Tables("Indiv_User_Info2").Rows(0).Item(3)
        'Associates the year variable with the year text box'
        lblStudent_Year.Text = Year

        conn.Close()

    End Sub

    'This collection of functions will provide the user with various averages pertaining to the scores they have acheived'
    Private Sub Progress_Calculator(User_Class)

        If conn.ConnectionString <> connstring Then
            'Console being opened to accept SQL commands'
            conn.ConnectionString = connstring
            conn.Open()
        End If

        Dim Progress_info As String = "SELECT * FROM tblMark_info WHERE UserID = '" & Login_screen.Username & "' AND Class = '" & User_Class & "' "
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(Progress_info, conn)
        Dim ds As DataSet = New DataSet
        da.Fill(ds, "User_Info")
        Dim dt As DataTable = ds.Tables("User_Info")

        ' Merit Locator '

        Dim Merit_Counter As Integer = 0

        'This loop will search each row in the datatable and will color them Gold if their mark equals 18 or is greater then 18'
        For Each row As DataRow In dt.Rows
            If ds.Tables("User_Info").Rows(Merit_Counter).Item(2) >= 18 Then
                'Colour change code'
                dgvStudent_Results.Rows(Merit_Counter).DefaultCellStyle.BackColor = Color.Gold
            End If
            Merit_Counter = Merit_Counter + 1
        Next

        ' Demerit Locator '

        Dim Demerit_Counter As Integer = 0

        'This loop will search each row in the datatable and will color them Red if their mark equals 5 or is lower then 5'
        For Each row As DataRow In dt.Rows
            If ds.Tables("User_Info").Rows(Demerit_Counter).Item(2) <= 5 Then
                'Colour change code'
                dgvStudent_Results.Rows(Demerit_Counter).DefaultCellStyle.BackColor = Color.Red
            End If
            Demerit_Counter = Demerit_Counter + 1
        Next

        ' Average User Score Calculator '
        Dim Average As Single = 0
        Dim Counter As Integer = 0

        'THis will go through each row in the datatable and will add them all up'
        For Each row As DataRow In dt.Rows
            Average = Average + ds.Tables("User_Info").Rows(Counter).Item(2)
            Counter = Counter + 1
        Next

        'this is a simple average function'
        Average = Average / Counter
        txtAverage.Text = Average

        ' Yearly Improvement '

        Dim First_Record As Integer
        Dim Last_Record As Integer
        Dim Range_Calculation As Integer

        'This will define the variable taking the value of the first test taken's mark'
        First_Record = ds.Tables("User_Info").Rows(0).Item(2)
        'This will define the variable taking the value of the most recent mark'
        Last_Record = ds.Tables("User_Info").Rows(Counter - 1).Item(2)

        'This simple function will find the total range
        Range_Calculation = First_Record - Last_Record
        txtRange_Calculator.Text = Range_Calculation

        ' Percentage Improvement Calculator '
        Dim Percentage_Increase As Single = 0.0

        'This function will find the improvement in decimal percentages
        Percentage_Increase = (Last_Record - First_Record) / First_Record
        'This multiplies the value by 100 to bring into an understandable range'
        Percentage_Increase = Percentage_Increase * 100
        'This formats it for displaying it in an understandable manor'
        txtPercentage_Increase.Text = FormatNumber(Percentage_Increase, 2) & "%"

        ' Recent Improvement '

        Dim Penultimate_Record As Integer
        Dim recent_improvement As Integer

        'This defines the variable that takes the value of the penultmate test taken's mark'
        Penultimate_Record = ds.Tables("User_Info").Rows(Counter - 2).Item(2)
        'This function will work out the recent range'
        recent_improvement = Last_Record - Penultimate_Record
        'Associates the text box with the recent improvement variable'
        txtRecent_Improvement.Text = recent_improvement

        ' Recent Percentage Improvement calculator ' 

        Dim Recent_Percentage_Improvement As Single = 0

        'This will work out the recent % increase by using the penultimate records value and the most recent records value'
        Recent_Percentage_Improvement = (Last_Record - Penultimate_Record) / Penultimate_Record
        'Formating.."
        Recent_Percentage_Improvement = Recent_Percentage_Improvement * 100
        'Formating.."
        txtRecent_Per_Improvement.Text = FormatNumber(Recent_Percentage_Improvement, 2) & "%"

        'End'

    End Sub

    'This subroutine will fill the datagrid view with the users test history'
    Private Sub Fill_Table()

        If conn.ConnectionString <> connstring Then
            'Console being opened to accept SQL commands'
            conn.ConnectionString = connstring
            conn.Open()
        End If

        'Used to reference test history'
        Dim User_Info As String = "SELECT * FROM tblMark_info WHERE UserID = '" & Login_screen.Username & "' "
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(User_Info, conn)
        Dim ds As DataSet = New DataSet
        da.Fill(ds, "Indiv_User_Info")
        Dim dt As DataTable = ds.Tables("Indiv_User_Info")

        'Presence check to see if any tests exist within the database'
        If ds.Tables("Indiv_User_Info").Rows.Count = 0 Then
            MsgBox("No Testing History Found")
            Exit Sub
        End If

        'This with statment fill the data grid viewer with the data pulled from the database using the select query above, any records are found are displayed using this group'
        With dgvStudent_Results
            .AutoGenerateColumns = True
            .DataSource = ds
            .DataMember = "Indiv_User_Info"
        End With

        'This is defining the user's class
        Dim User_Class As String = ds.Tables("Indiv_User_Info").Rows(0).Item(4)

        conn.Close()

        Progress_Calculator(User_Class)

        conn.Close()

    End Sub

    'This load event will run on form load'
    Private Sub Student_Menu_See_Old_Marks_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'The subroutines that will run on the load event'
        Grab_user_Information()
        Fill_Table()

    End Sub

End Class