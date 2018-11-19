Imports System.Data.SqlClient
Public Class Main
    Dim con As New SqlClient.SqlConnection
    Dim da As New SqlClient.SqlDataAdapter
    Dim ds As New DataSet
    Dim sqlquery As String
    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'FIFADataSet1.Products' table. You can move, or remove it, as needed.
        Me.ProductsTableAdapter.Fill(Me.FIFADataSet1.Products)
        'TODO: This line of code loads data into the 'FIFADataSet4.Products' table. You can move, or remove it, as needed.
        con.ConnectionString = "Data Source=SHUBHAM;Initial Catalog=FIFA;Integrated Security=True"
        Me.CenterToScreen()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        AddData.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim index As Integer
        index = DataGridView1.CurrentCell.RowIndex
        DataGridView1.Rows.RemoveAt(index)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
        Login.Show()
        AddData.Close()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Hide()
        Update1.Show()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim index As Integer
        index = e.RowIndex
        Dim selectedRow As DataGridViewRow
        selectedRow = DataGridView1.Rows(index)
        Update1.TextBox1.Text = selectedRow.Cells(0).Value.ToString
        Update1.TextBox2.Text = selectedRow.Cells(1).Value.ToString
        Update1.TextBox3.Text = selectedRow.Cells(2).Value.ToString
        Update1.TextBox4.Text = selectedRow.Cells(3).Value.ToString
        Update1.TextBox5.Text = selectedRow.Cells(4).Value.ToString
    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim searchQuery As String = "SELECT * From Products WHERE CONCAT(Code, Category, Name, Quantity, Price) like '%" & TextBox1.Text & "%'"

        Dim command As New SqlCommand(searchQuery, con)
        Dim adapter As New SqlDataAdapter(command)
        Dim table As New DataTable()

        adapter.Fill(table)

        DataGridView1.DataSource = table
    End Sub
    Sub DisplayData()
        Dim da As SqlDataAdapter = New SqlDataAdapter("select * from Products", con)
        Dim ds As DataSet = New DataSet()
        da.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If TextBox1.TextLength < 1.0 Then
            Label1.Show()
        Else
            Label1.Hide()
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        DisplayData()
    End Sub
End Class