'Imports'
Imports System.Data.OleDb
Public Class Teacher_Menu_Class_Marks_RV

    'Connecting to database'
    Public connstring As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Greenpark_spellingBee.accdb"
    Public conn As New OleDbConnection

    Private Sub Load_Report()

        If conn.ConnectionString <> connstring Then
            'Console being opened to accept SQL commands'
            conn.ConnectionString = connstring
            conn.Open()
        End If

        Dim Class_progress As String = "SELECT * FROM tblMark_info WHERE Class = '" & Teacher_Menu_Class_Marks.User_Class & "' AND TestID = '" & Teacher_Menu_Class_Marks.Test_ID & "' "
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(Class_progress, conn)
        Dim ds As DataSet = New DataSet
        da.Fill(ds, "Indiv_User_Info2")
        Dim dt2 As DataTable = ds.Tables("Indiv_User_Info2")

        Me.Class_Progress_Report.LocalReport.DataSources.Item(0).Value = dt2
        Me.Class_Progress_Report.RefreshReport()

    End Sub
    Private Sub ReportViewer1_Load(sender As Object, e As EventArgs) Handles Class_Progress_Report.Load

        Load_Report()

    End Sub

    Private Sub Teacher_Menu_Class_Marks_RV_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class