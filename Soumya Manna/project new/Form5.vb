Imports System.Data
Imports System.Data.OleDb
Public Class Form5
    Dim con As OleDbConnection
    Dim cmd As OleDbCommand
    Dim adpt As OleDbDataAdapter
    Dim ds As DataSet
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If RadioButton1.Checked Then
            adpt = New OleDbDataAdapter("select * from std where StudentName like'" & TextBox1.Text & "'", con)
            ds = New DataSet
            adpt.Fill(ds)
            DataGridView1.DataSource = ds.Tables(0)
        ElseIf RadioButton2.Checked Then
            'TextBox1.Enabled = False
            'Dim n, n1 As Integer
            'n = InputBox("Enter Lowest Range")
            'n1 = InputBox("Enter Highest Range")
            adpt = New OleDbDataAdapter("select * from std where total like'" & TextBox1.Text & "'", con)
            ds = New DataSet
            adpt.Fill(ds)
            DataGridView1.DataSource = ds.Tables(0)
        ElseIf RadioButton3.Checked Then
                adpt = New OleDbDataAdapter("select * from std where code like'" & TextBox1.Text & "'", con)
                ds = New DataSet
                adpt.Fill(ds)
                DataGridView1.DataSource = ds.Tables(0)
        Else
                MessageBox.Show("Please Select a Field")
        End If
    End Sub

    Private Sub Form5_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        con = New OleDbConnection("PROVIDER=MICROSOFT.JET.OLEDB.4.0 ; DATA SOURCE=DATABASE1.MDB")
        con.Open()
        adpt = New OleDbDataAdapter("select * from std", con)
        ds = New DataSet
        adpt.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged

    End Sub
End Class