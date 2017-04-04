'Imports'
Imports System.Data.OleDb


Public Class Login_screen

    'This defines the username string that will be used throughout the program'
    Public Username As String

    'Connecting to database'
    Public connstring As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Greenpark_spellingBee.accdb"
    Public conn As New OleDbConnection

    'This will run the user verification subroutine'
    Private Sub login()

        If conn.ConnectionString <> connstring Then
            'Console being opened to accept SQL commands'
            conn.ConnectionString = connstring
            conn.Open()
        End If

        'This assigns the username textbox to username variable'
        Username = txtUsername.Text

        'This defines the password variable as the password textbox'
        Dim Password As String = txtPassword.Text
        'This defines the user check string'
        Dim User_Check As String

        If Username = "Admin" And Password = "Admin" Then
            Me.SetDesktopLocation(0, 0)
            Admin_Menu.Show()
        End If

        'This select statement will select everything from the user information table'
        Dim User_Info_Check As String = "SELECT * FROM tblUser_info"
        'Defining the data adapter and command string'
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(User_Info_Check, conn)
        'defining the dataset'
        Dim ds As DataSet = New DataSet
        'telling the data adapter to fill the data set using the datatable'
        da.Fill(ds, "Users")
        'Defining the data table'
        Dim dt As DataTable = ds.Tables("Users")
        conn.Close()

        'This is some validation for the inputs'
        'This is a presence check for my username field'
        If txtUsername.Text = "" Then
            MsgBox("Please enter a Username")
            Exit Sub
            'This is a Length check for my username field'
        ElseIf Username.Length > 5 Then
            MsgBox("Username is too long")
            Exit Sub
            'This is a presence check for my username field'
        ElseIf txtPassword.Text = "" Then
            MsgBox("Please enter a Password")
            Exit Sub
        End If

        'This defines the user type string as the first character of the username string, this being either "T" or "S"'
        User_Check = Username.Substring(0, 1)

        'This will now loop through every record in the database'
        For Each row As DataRow In dt.Rows
            'This will check if the entries match the records found in the database'
            If row.Item(0) = Username And row.Item(2) = Password Then
                'the record having been located, the program will now distinguish whether the user is a teacher or 
                'a student and display the apropriate side of the program'
                If User_Check = "T" Then

                    MsgBox("Welcome User: " + Username)
                    Me.SetDesktopLocation(0, 0)
                    Teacher_Menu_Create_Test.Show()
                    txtPassword.Text = ""
                    txtUsername.Text = ""
                    Exit Sub
                    Exit For
                ElseIf User_Check = "S" Then
                    MsgBox("Welcome User: " + Username)
                    Me.SetDesktopLocation(0, 0)
                    Student_Menu_See_Old_Marks.Show()
                    txtPassword.Text = ""
                    txtUsername.Text = ""
                    Exit Sub
                    Exit For
                End If
            End If
        Next

        'This will only run if no user has been located'
        MsgBox("User not found")

    End Sub

    'This subroutine will establish if there are any user records in the database and will create the first one'
    Private Sub User_Check()

        'This checks to see if the connection has been established and if not will establish it now'
        If conn.State = ConnectionState.Closed Then
            conn.ConnectionString = connstring
            conn.Open()
        End If


        'This select statement will select everything from the user information table'
        Dim User_Info_Check As String = "SELECT * FROM tblUser_info"
        'Defining the data adapter and command string'
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(User_Info_Check, conn)
        'defining the dataset'
        Dim ds As DataSet = New DataSet
        'telling the data adapter to fill the data set using the datatable'
        da.Fill(ds, "Users")
        'Defining the data table'
        Dim dt As DataTable = ds.Tables("Users")

        'This will run a presence check to see if any users are present in the database'
        If ds.Tables("Users").Rows.Count > 0 Then
            Exit Sub
        Else
            'If there arent this message is displayed'
            MsgBox("Generating Admin User ID")
        End If

        'This block is responsible for generating the random number for the admin account'
        Dim r As New Random()
        Dim Gen_pass_1 As Integer = r.Next(9)
        Dim Gen_pass_2 As Integer = r.Next(5)
        Dim Gen_pass_3 As Integer = r.Next(2)
        Dim Gen_pass_4 As Integer = r.Next(6)
        'This combines all the individual numbers into a single string'
        Dim Generated_password As String = Gen_pass_1 & Gen_pass_2 & Gen_pass_3 & Gen_pass_4

        'THis insert statement will insert all the information in the parameters and will create the first user automatically'
        Dim First_User_Insert As String = "INSERT INTO tblUser_info ([UserID],[FirstName],[Password],[Classinfo],[Teacher]) VALUES (@UserID,@FirstName,@Password,@Classinfo,@Teacher)"
        'This will define the console command'
        Dim SQL_Command As New OleDbCommand
        'This block contains a series of parameters that are associated with matching variables and then uses them to be added into the database'
        With SQL_Command
            .CommandText = First_User_Insert
            .Parameters.AddWithValue("@UserID", "T0000")
            .Parameters.AddWithValue("@FirstName", "Admin")
            .Parameters.AddWithValue("@Password", Generated_password)
            .Parameters.AddWithValue("@UserID", "0A")
            .Parameters.AddWithValue("@UserID", "NULL")
            .Connection = conn
            'This will execute all the insert functions and essentially create the admin user'
            .ExecuteNonQuery()
        End With

        'This will display the admin account information'
        MsgBox("This is the admin Username: T0000  This is the Admin Password. " & Generated_password)

    End Sub

    'This will initiate the login subroutine'
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnLogIn.Click

        'This will run when the button is pressed'
        login()

    End Sub

    'This load event will run on form load and will run the user check subroutine'
    Private Sub Login_screen_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'This will run on load'
        User_Check()

    End Sub



End Class
