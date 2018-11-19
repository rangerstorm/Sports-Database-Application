Imports System.Data.SqlClient

Public Class Update1
    Dim con As New SqlClient.SqlConnection
    Dim da As New SqlClient.SqlDataAdapter
    Dim ds As New DataSet
    Dim sqlquery As String
    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'FIFADataSet1.Products' table. You can move, or remove it, as need
        'TODO: This line of code loads data into the 'FIFADataSet4.Products' table. You can move, or remove it, as needed.
        con.ConnectionString = "Data Source=SHUBHAM;Initial Catalog=FIFA;Integrated Security=True"
        Me.CenterToScreen()
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim cmd As New SqlCommand
        If Not con.State = ConnectionState.Open Then
            con.Open()
            cmd.Connection = con
            cmd.CommandText = "UPDATE Products SET Code='" & Me.TextBox1.Text & "' ,Category='" & Me.TextBox2.Text & "',Name='" & Me.TextBox3.Text & "',Quantity='" & Me.TextBox4.Text & "',Price='" & Me.TextBox5.Text & "' WHERE Code='" & Me.TextBox1.Text & "'"
            cmd.ExecuteNonQuery()
            MessageBox.Show("Products Record updated ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            DisplayData()
            con.Close()
            Me.Close()
            Main.Show()
        End If
    End Sub
    Sub DisplayData()
        Dim da As SqlDataAdapter = New SqlDataAdapter("select * from Products", con)
        Dim ds As DataSet = New DataSet()
        da.Fill(ds)
        Main.DataGridView1.DataSource = ds.Tables(0)
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
        Main.Show()
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub
End Class