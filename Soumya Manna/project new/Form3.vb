Imports System.Data
Imports System.Data.OleDb

Public Class Form3
    Dim con As OleDbConnection
    Dim cmd As OleDbCommand
    Dim ds As DataSet
    Dim adpt As OleDbDataAdapter
    Dim h As Integer = 0
    Sub showdata()
        adpt = New OleDbDataAdapter("select * from std", con)
        ds = New DataSet
        adpt.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
    End Sub
    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
        Timer1.Interval = 1000
        WindowState = FormWindowState.Maximized
        con = New OleDbConnection("PROVIDER=MICROSOFT.JET.OLEDB.4.0 ; DATA SOURCE=DATABASE1.MDB")
        con.Open()
        showdata()


    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Form3_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        GroupBox1.Top = (Me.Height / 2) - (GroupBox1.Height / 2)
        GroupBox1.Left = (Me.Width / 2) - (GroupBox1.Width / 2)
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Label11.Text = Format(Now, "short date")
        Label12.Text = TimeOfDay
        If Label12.ForeColor = Color.Red Then
            Label12.ForeColor = Color.Green
        Else
            Label12.ForeColor = Color.Red
        End If
    End Sub
    Dim i As Boolean = True
    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If i = True Then
            TextBox1.Enabled = True
            TextBox2.Enabled = True
            TextBox3.Enabled = True
            TextBox4.Enabled = True
            TextBox5.Enabled = True
            TextBox6.Enabled = True
            TextBox7.Enabled = True
            TextBox1.BackColor = Color.LightPink
            TextBox2.BackColor = Color.LightPink
            TextBox3.BackColor = Color.LightPink
            TextBox4.BackColor = Color.LightPink
            TextBox5.BackColor = Color.LightPink
            TextBox6.BackColor = Color.LightPink
            TextBox7.BackColor = Color.LightPink
            TextBox8.BackColor = Color.LightPink
            TextBox9.BackColor = Color.LightPink
            TextBox10.BackColor = Color.LightPink

            Button1.BackColor = Color.Yellow
            Button1.Text = "Save"
            TextBox1.Select()
            i = False
        Else
            cmd = New OleDbCommand("insert into std values('" & UCase(TextBox1.Text) & "','" & UCase(TextBox2.Text) & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & TextBox6.Text & "','" & TextBox7.Text & "','" & TextBox8.Text & "','" & TextBox9.Text & "','" & TextBox10.Text & "')", con)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Data Inserted Sucessfully", "Confirm")
            showdata()

        End If
    End Sub

    Private Sub Button3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        cmd = New OleDbCommand("delete * from std where code='" & TextBox1.Text & "'", con)

        Dim mg As Integer
        mg = MsgBox("Are You Sure You Want To delete This Data?", vbOKCancel + vbInformation, "Comfirm")
        If mg = 1 Then
            cmd.ExecuteNonQuery()

            MessageBox.Show("Deleted", "Delete")
            showdata()
        End If
    End Sub

    Private Sub TextBox8_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox8.TextChanged
        Dim n, a As Integer
        n = TextBox8.Text
        a = n / 5
        TextBox9.Text = Val(a)
        If a >= 70 And a <= 100 Then
            TextBox10.Text = "E"
        ElseIf a >= 40 And a <= 69 Then
            TextBox10.Text = "A"
        ElseIf a >= 25 And a <= 39 Then
            TextBox10.Text = "B"
        Else
            TextBox10.Text = "Fail"
        End If
    End Sub

    Private Sub TextBox7_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox7.TextChanged
        TextBox8.Text = Val(TextBox3.Text) + Val(TextBox4.Text) + Val(TextBox5.Text) + Val(TextBox6.Text) + Val(TextBox7.Text)
    End Sub

    Private Sub DataGridView1_CellContentClick_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow
            row = Me.DataGridView1.Rows(e.RowIndex)
            TextBox1.Text = row.Cells("code").Value.ToString
            TextBox2.Text = row.Cells("StudentName").Value.ToString
            TextBox3.Text = row.Cells("Module 1").Value.ToString
            TextBox4.Text = row.Cells("Module 2").Value.ToString
            TextBox5.Text = row.Cells("Module 3").Value.ToString
            TextBox6.Text = row.Cells("Module 4").Value.ToString
            TextBox7.Text = row.Cells("Module 5").Value.ToString
            TextBox8.Text = row.Cells("Total").Value.ToString
            TextBox9.Text = row.Cells("Average").Value.ToString
            TextBox10.Text = row.Cells("Grade").Value.ToString


        End If
    End Sub

    Private Sub Button8_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Form5.Show()
        Me.Hide()
    End Sub

    Private Sub Button4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Form4.Show()
        Me.Hide()
    End Sub
    Dim g As Boolean = True

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim sql As String
        sql = "UPDATE std SET StudentName ='" & TextBox2.Text & "', where code='" & TextBox1.Text & "'"
        If g = True Then
            TextBox1.Enabled = False
            'TextBox1.Enabled = True
            TextBox2.Enabled = True
            TextBox3.Enabled = True
            TextBox4.Enabled = True
            TextBox5.Enabled = True
            TextBox6.Enabled = True
            TextBox7.Enabled = True
            Button2.Text = "Save"
            Button2.BackColor = Color.GreenYellow

            g = False
        Else
            cmd = New OleDbCommand("UPDATE [std] SET [StudentName] ='" & TextBox2.Text & "', [Module 1] ='" & Val(TextBox3.Text) & "', [Module 2] ='" & Val(TextBox4.Text) & "', [Module 3] ='" & Val(TextBox5.Text) & "', [Module 4] ='" & Val(TextBox6.Text) & "', [Module 5] ='" & Val(TextBox7.Text) & "', [Total] ='" & Val(TextBox8.Text) & "', [Average] ='" & Val(TextBox9.Text) & "', [Grade] ='" & TextBox10.Text & "' where [code] ='" & TextBox1.Text & "'", con)
            cmd.ExecuteNonQuery()
            showdata()
            MessageBox.Show("Data Updated", "Sucessfull")
        End If
    End Sub


    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click

        If (h < ds.Tables(0).Rows.Count - 1) Then
            h = h + 1
            DataGridView1.CurrentCell = DataGridView1.Rows(h).Cells(0)
            TextBox1.Text = ds.Tables(0).Rows(h)(0)
            TextBox2.Text = ds.Tables(0).Rows(h)(1)
            TextBox3.Text = ds.Tables(0).Rows(h)(2)
            TextBox4.Text = ds.Tables(0).Rows(h)(3)
            TextBox5.Text = ds.Tables(0).Rows(h)(4)
            TextBox6.Text = ds.Tables(0).Rows(h)(5)
            TextBox7.Text = ds.Tables(0).Rows(h)(6)
            TextBox8.Text = ds.Tables(0).Rows(h)(7)
            TextBox9.Text = ds.Tables(0).Rows(h)(8)
            TextBox10.Text = ds.Tables(0).Rows(h)(9)
        Else
            MessageBox.Show("Last Record", "Information")
        End If

        
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        DataGridView1.FirstDisplayedScrollingRowIndex = DataGridView1.RowCount - 1
        Me.DataGridView1.Rows(Me.DataGridView1.RowCount - 2).Selected = True
        Dim i As Integer = 0
        DataGridView1.CurrentCell = DataGridView1.Rows(DataGridView1.RowCount - 2).Cells(0)
        TextBox1.Text = ds.Tables(0).Rows(DataGridView1.RowCount - 2)(0)
        TextBox2.Text = ds.Tables(0).Rows(DataGridView1.RowCount - 2)(1)
        TextBox3.Text = ds.Tables(0).Rows(DataGridView1.RowCount - 2)(2)
        TextBox4.Text = ds.Tables(0).Rows(DataGridView1.RowCount - 2)(3)
        TextBox5.Text = ds.Tables(0).Rows(DataGridView1.RowCount - 2)(4)
        TextBox6.Text = ds.Tables(0).Rows(DataGridView1.RowCount - 2)(5)
        TextBox7.Text = ds.Tables(0).Rows(DataGridView1.RowCount - 2)(6)
        TextBox8.Text = ds.Tables(0).Rows(DataGridView1.RowCount - 2)(7)
        TextBox9.Text = ds.Tables(0).Rows(DataGridView1.RowCount - 2)(8)
        TextBox10.Text = ds.Tables(0).Rows(DataGridView1.RowCount - 2)(9)
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If (h > 0) Then
            h = h - 1
            DataGridView1.CurrentCell = DataGridView1.Rows(h).Cells(0)
            TextBox1.Text = ds.Tables(0).Rows(h)(0)
            TextBox2.Text = ds.Tables(0).Rows(h)(1)
            TextBox3.Text = ds.Tables(0).Rows(h)(2)
            TextBox4.Text = ds.Tables(0).Rows(h)(3)
            TextBox5.Text = ds.Tables(0).Rows(h)(4)
            TextBox6.Text = ds.Tables(0).Rows(h)(5)
            TextBox7.Text = ds.Tables(0).Rows(h)(6)
            TextBox8.Text = ds.Tables(0).Rows(h)(7)
            TextBox9.Text = ds.Tables(0).Rows(h)(8)
            TextBox10.Text = ds.Tables(0).Rows(h)(9)
        Else
            MessageBox.Show("First Record", "Information")
        End If
    End Sub

    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged
        TextBox8.Text = Val(TextBox3.Text)
    End Sub

    Private Sub TextBox4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox4.TextChanged
        TextBox8.Text = Val(TextBox3.Text) + Val(TextBox4.Text)
    End Sub

    Private Sub TextBox5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox5.TextChanged
        TextBox8.Text = Val(TextBox3.Text) + Val(TextBox4.Text) + Val(TextBox5.Text)
    End Sub

    Private Sub TextBox6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox6.TextChanged
        TextBox8.Text = Val(TextBox3.Text) + Val(TextBox4.Text) + Val(TextBox5.Text) + Val(TextBox6.Text)
    End Sub
End Class