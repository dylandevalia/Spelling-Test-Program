'Imports'
Imports System.Data.OleDb
Public Class Teacher_Menu_See_Old_Marks

    'Connecting to database'
    Public connstring As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Greenpark_spellingBee.accdb"
    Public conn As New OleDbConnection

    'Navigational buttons'
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Me.Close()
        Teacher_Menu_Create_Test.Show()

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

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click

        Me.Close()
        Teacher_Menu_Account_Management.Show()

    End Sub

    Friend User_Class As String
    Public User_ID As String

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

        Display_Student_Progress(User_Class)

    End Sub

    Private Sub Display_Student_Progress(User_Class)

        If conn.ConnectionString <> connstring Then
            'Console being opened to accept SQL commands'
            conn.ConnectionString = connstring
            conn.Open()
        End If

        'associating user id variable with the text box
        User_ID = txtUser_ID_Display_Info.Text
        'presence check'
        If User_ID = "" Then
            MsgBox("Please Enter a Username")
            Exit Sub
            'length check'
        ElseIf User_ID.Length > 5 Then
            MsgBox("User ID is too Long")
            Exit Sub
        End If

        'fetching records associated with that user class and the username'
        Dim Progress_info As String = "SELECT * FROM tblMark_info WHERE UserID = '" & User_ID & "' AND Class = '" & User_Class & "' "
        'defining the data adapter'
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(Progress_info, conn)
        'defining the the data set'
        Dim ds As DataSet = New DataSet
        'filling the dataset'
        da.Fill(ds, "User_Info")
        'defining the datatable'
        Dim dt As DataTable = ds.Tables("User_Info")

        'checking if the dataable contains any data'
        If ds.Tables("User_Info").Rows.Count = 0 Then
            MsgBox("User Not Found")
            Exit Sub
        End If

        'filling the datagrid view'
        With dgvIndiv_info
            .AutoGenerateColumns = True
            .DataSource = ds
            .DataMember = "User_Info"
        End With

        Progress_Calculator(User_Class)

        'opening the report viewer
        Teacher_Menu_See_Old_Marks_RV.Show()

    End Sub

    Private Sub Get_User_Info()

        If conn.ConnectionString <> connstring Then
            'Console being opened to accept SQL commands'
            conn.ConnectionString = connstring
            conn.Open()
        End If

        'Used to reference User Information'
        'sql string selecting every record that contains that user id'
        Dim User_Data As String = "SELECT * FROM tblMark_info WHERE UserID = '" & txtUser_ID_Display_Info.Text & "' "
        'defining the data adapter'
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(User_Data, conn)
        'defining the dataset'
        Dim ds As DataSet = New DataSet
        'filling the dataset;'
        da.Fill(ds, "Indiv_User_Info2")
        'defining the datatable'
        Dim dt2 As DataTable = ds.Tables("Indiv_User_Info2")

        'filling the data grid view'
        With dgvIndiv_info
            .AutoGenerateColumns = True
            .DataSource = ds
            .DataMember = "Indiv_User_Info2"
        End With

    End Sub

    Private Sub Progress_Calculator(User_ID)

        If conn.ConnectionString <> connstring Then
            'Console being opened to accept SQL commands'
            conn.ConnectionString = connstring
            conn.Open()
        End If

        'fetching all records matching that user id and the users class'
        Dim Progress_info As String = "SELECT * FROM tblMark_info WHERE UserID = '" & txtUser_ID_Display_Info.Text & "' AND Class = '" & User_ID & "' "
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(Progress_info, conn)
        Dim ds As DataSet = New DataSet
        da.Fill(ds, "User_Info")
        Dim dt As DataTable = ds.Tables("User_Info")

        'checking if the datatable contains any information'
        If ds.Tables("User_Info").Rows.Count > 0 Then
        Else
            MsgBox("User not Found")
            Exit Sub
        End If

        ' Average User Score Calculator '
        Dim Average As Single = 0
        Dim Counter As Single = 0

        'this will cycle through each loop adding all the mark info and then making a number of marks counted value'
        For Each row As DataRow In dt.Rows
            Average = Average + ds.Tables("User_Info").Rows(Counter).Item(2)
            Counter = Counter + 1
        Next

        Average = (Average / Counter)
        txtAverage.Text = Average

        ' Yearly Improvement '

        Dim First_Record As Integer
        Dim Last_Record As Integer
        Dim Range_Calculation As Integer

        'defining the calculator values'
        First_Record = ds.Tables("User_Info").Rows(0).Item(2)
        Last_Record = ds.Tables("User_Info").Rows(Counter - 1).Item(2)

        'calculation'
        Range_Calculation = First_Record - Last_Record
        txtRange_Calculator.Text = Range_Calculation

        ' Percentage Improvement Calculator '

        'defining the output datatype'
        Dim Percentage_Increase As Single = 0.0
        Percentage_Increase = (Last_Record - First_Record) / First_Record
        Percentage_Increase = Percentage_Increase * 100
        'This formats it for displaying it in an understandable manor'
        txtPercentage_Increase.Text = FormatNumber(Percentage_Increase, 2) & "%"

        ' Recent Improvement '

        Dim Penultimate_Record As Integer
        Dim recent_improvement As Integer

        'will display a null message if there is not enough data in the database'
        If ds.Tables("User_Info").Rows.Count > 1 Then
        Else
            txtRecent_Improvement.Text = "NULL"
            Exit Sub
        End If

        'calulcation for recent improvement
        Penultimate_Record = ds.Tables("User_Info").Rows(Counter - 2).Item(2)
        recent_improvement = Last_Record - Penultimate_Record

        txtRecent_Improvement.Text = recent_improvement

        ' Recent Percentage Improvement calculator ' 

        Dim Recent_Percentage_Improvement As Single = 0

        'percentage improvement calculation'
        Recent_Percentage_Improvement = (Last_Record - Penultimate_Record) / Penultimate_Record
        Recent_Percentage_Improvement = Recent_Percentage_Improvement * 100
        'Formating.."
        txtRecent_Per_Improvement.Text = FormatNumber(Recent_Percentage_Improvement, 2) & "%"

        'End'

        ' Merit Locator '

        Dim Merit_Counter As Integer = 0

        'this will loop through each record highlighting any merit worthy marks'
        For Each row As DataRow In dt.Rows
            If ds.Tables("User_Info").Rows(Merit_Counter).Item(2) >= 18 Then
                dgvIndiv_info.Rows(Merit_Counter).DefaultCellStyle.BackColor = Color.Gold
            End If
            Merit_Counter = Merit_Counter + 1
        Next

        ' DeMerit Locator '

        Dim demerit_Counter As Integer = 0

        'this will loop through each record highlighting any demerit worthy marks'
        For Each row As DataRow In dt.Rows
            If ds.Tables("User_Info").Rows(demerit_Counter).Item(2) <= 5 Then
                dgvIndiv_info.Rows(demerit_Counter).DefaultCellStyle.BackColor = Color.Red
            End If
            demerit_Counter = demerit_Counter + 1
        Next

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click

        Get_User_Class()

    End Sub

    'This subroutine will run on load'
    Private Sub Teacher_Menu_See_Old_Marks_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub dgvIndiv_info_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvIndiv_info.CellContentClick

    End Sub
End Class