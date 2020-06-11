Imports System.Data
Imports System.Data.OleDb

Public Class Form1
    Dim con As OleDbConnection
    Dim cmd As OleDbCommand
    Dim adpt As OleDbDataAdapter
    Dim ds As DataSet


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Timer1.Enabled = True
        Timer1.Interval = 100
        WindowState = FormWindowState.Maximized
        con = New OleDbConnection("PROVIDER= MICROSOFT.JET.OLEDB.4.0 ; DATA SOURCE=DATABASE1.MDB")
        con.Open()
        
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        cmd = New OleDbCommand("select * from pass where user like '" & TextBox1.Text & "' and pass like '" & TextBox2.Text & "'", con)
        '  cmd.ExecuteNonQuery()
        'adpt = New OleDbDataAdapter("select * from pass", con)
        'ds = New DataSet
        'adpt.Fill(ds)
        Dim pass As String = ""
        Dim user As String = ""
        Dim read As OleDbDataReader = cmd.ExecuteReader
        If (read.Read() = True) Then
            user = read("user")
            pass = read("pass")
            ' MessageBox.Show("Log In Sucessfully")
            Form2.Show()
            Me.Hide()
        Else
            MessageBox.Show("Invalid User Name of Password")
        End If

    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim n As String = InputBox("Enter Current User Name")
        Dim n1 As String
        cmd = New OleDbCommand("select * from pass where user like'" & n & "'", con)
        Dim read As OleDbDataReader = cmd.ExecuteReader
        Dim user As String = ""
        If (read.Read() = True) Then
            user = read("user")
            n1 = InputBox("Enter New Password")
            cmd = New OleDbCommand("update pass set pass='" & n1 & "'", con)
            cmd.ExecuteNonQuery()
        End If
    End Sub

    Private Sub Form1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        GroupBox1.Top = (Me.Height / 2) - (GroupBox1.Height / 2)
        GroupBox1.Left = (Me.Width / 2) - (GroupBox1.Width / 2)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim n2, p2 As String
        n2 = InputBox("Enter User Name")
        p2 = InputBox("Enter Password")
        cmd = New OleDbCommand("Insert into pass values('" & n2 & "','" & p2 & "')", con)
        cmd.ExecuteNonQuery()


    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If Label3.ForeColor = Color.Green Then
            Label3.ForeColor = Color.Black
            Label4.ForeColor = Color.Green
            Label5.ForeColor = Color.Black
        ElseIf Label4.ForeColor = Color.Green Then
            Label5.ForeColor = Color.Green
            Label3.ForeColor = Color.Black
            Label4.ForeColor = Color.Black
        Else
            Label5.ForeColor = Color.Green
            Label4.ForeColor = Color.Black
            Label5.ForeColor = Color.Black

        End If
    End Sub
End Class
