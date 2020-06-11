Imports System.Data
Imports System.Data.OleDb
Public Class Form2
    Dim con As OleDbConnection
    Dim cmd As OleDbCommand
    Dim ds As DataSet
    Dim adpt As OleDbDataAdapter
    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized
        con = New OleDbConnection("PROVIDER=MICROSOFT.JET.OLEDB.4.0 ; DATA SOURCE=DATABASE1.MDB")
        con.Open()
        adpt = New OleDbDataAdapter("select * from std", con)
        ds = New DataSet
        adpt.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
        MessageBox.Show("Database Is loading......")
        Timer1.Enabled = True
        Timer1.Interval = 30
    End Sub

    Private Sub Form2_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        GroupBox1.Top = (Me.Height / 2) - (GroupBox1.Height / 2)
        GroupBox1.Left = (Me.Width / 2) - (GroupBox1.Width / 2)
    End Sub

    Private Sub InsertToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InsertToolStripMenuItem.Click

        Form3.Show()


    End Sub

    Private Sub RefreshDataToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RefreshDataToolStripMenuItem.Click
        adpt = New OleDbDataAdapter("select * from std", con)
        ds = New DataSet
        adpt.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
    End Sub

    Private Sub UpdateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateToolStripMenuItem.Click
        Form3.Show()
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        Form3.Show()
    End Sub

    Private Sub SearchToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchToolStripMenuItem.Click
        Form5.Show()
    End Sub

    Private Sub DetailsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DetailsToolStripMenuItem.Click
        Form4.Show()
    End Sub

    Private Sub UpdateToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateToolStripMenuItem1.Click

        Form3.Show()
    End Sub

    Private Sub DeleteToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem1.Click
        Form3.Show()
    End Sub

    Private Sub ProfileUpdateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProfileUpdateToolStripMenuItem.Click
        Form4.Show()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Close()
    End Sub

   
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If ToolStripProgressBar1.Value < 100 Then
            ToolStripProgressBar1.Increment(1)
            ToolStripStatusLabel1.Text = ToolStripProgressBar1.Value & "%"
        Else
            Timer1.Enabled = False
            MessageBox.Show("Database Loaded Sucessfully")


        End If
    End Sub

    Private Sub ShowHelpToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowHelpToolStripMenuItem.Click
        Form6.Show()
        Me.Hide()
    End Sub
End Class