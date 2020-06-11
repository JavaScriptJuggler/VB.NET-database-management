Imports System.Data
Imports System.Data.OleDb
Public Class Form4
    Dim con As OleDbConnection
    Dim cmd As OleDbCommand
    Dim adpt As OleDbDataAdapter
    Dim ds As DataSet
    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow
            row = Me.DataGridView1.Rows(e.RowIndex)
            TextBox1.Text = row.Cells("student_roll").Value.ToString
            TextBox2.Text = row.Cells("Student_Name").Value.ToString
            TextBox3.Text = row.Cells("phone_Number").Value.ToString
            TextBox4.Text = row.Cells("Addmission_Date").Value.ToString
            TextBox5.Text = row.Cells("Address").Value.ToString
          

        End If
    End Sub

    Private Sub Form4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        con = New OleDbConnection("PROVIDER= MICROSOFT.JET.OLEDB.4.0 ; DATA SOURCE=DATABASE1.MDB")
        con.Open()
        adpt = New OleDbDataAdapter("select * from details", con)
        ds = New DataSet
        adpt.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
    End Sub

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        TextBox4.Text = Format(DateTimePicker1.Text, "short date")
    End Sub

    Dim i As Boolean = True
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If i = True Then
            TextBox1.Enabled = True
            TextBox2.Enabled = True
            TextBox3.Enabled = True
            TextBox4.Enabled = False
            TextBox5.Enabled = True
            DateTimePicker1.Enabled = True
           
            Button1.BackColor = Color.Green
            Button1.Text = "Save"
            TextBox1.Select()
            i = False
        Else
            cmd = New OleDbCommand("insert into details values('" & UCase(TextBox1.Text) & "','" & UCase(TextBox2.Text) & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & UCase(TextBox5.Text) & "')", con)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Data Inserted Sucessfully")
            adpt = New OleDbDataAdapter("select * from details", con)
            ds = New DataSet
            adpt.Fill(ds)
            DataGridView1.DataSource = ds.Tables(0)
            i = True
        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        cmd = New OleDbCommand("delete * from details where student_roll like'" & TextBox1.Text & "'", con)
        Dim mg As Integer
        mg = MsgBox("Are You Sure You Want To delete This Data?", vbOKCancel + vbInformation, "Comfirm")
        If mg = 1 Then

            cmd.ExecuteNonQuery()
            adpt = New OleDbDataAdapter("select * from details", con)
            ds = New DataSet
            adpt.Fill(ds)
            DataGridView1.DataSource = ds.Tables(0)
            MessageBox.Show("Deleted", "Delete")
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox4.Clear()
            TextBox5.Clear()

        End If


    End Sub

    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged
        Dim l As Integer
        Dim str As String
        str = TextBox3.Text
        l = Len(str)
        If l > 10 Or l < 10 Then
            Label6.Visible = True
        Else
            Label6.Visible = False

        End If
    End Sub
End Class