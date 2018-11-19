Imports System.Data.SqlClient
Public Class AddData
    Dim con As New SqlClient.SqlConnection
    Dim da As New SqlClient.SqlDataAdapter
    Dim ds As New DataSet
    Dim sqlquery As String
    Private Sub UpdateForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'FIFADataSet.Products' table. You can move, or remove it, as needed.
        Me.ProductsTableAdapter.Fill(Me.FIFADataSet.Products)
        con.ConnectionString = "Data Source=SHUBHAM;Initial Catalog=FIFA;Integrated Security=True"
        Me.CenterToScreen()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If Len(Trim(TextBox1.Text)) = 0 Then
                MessageBox.Show("Enter the Code", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
                TextBox1.Focus()
            End If

            If Len(Trim(TextBox3.Text)) = 0 Then
                MessageBox.Show("Enter the Name", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
                TextBox3.Focus()
            End If

            If Len(Trim(TextBox4.Text)) = 0 Then
                MessageBox.Show("Enter the Quantity", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
                TextBox4.Focus()
            End If

            If Len(Trim(TextBox5.Text)) = 0 Then
                MessageBox.Show("Enter the Price", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
                TextBox5.Focus()
            End If


            ' reading radio button values in a string variable

            Dim cmd As New SqlCommand
            If Not con.State = ConnectionState.Open Then
                con.Open()
                cmd.Connection = con

                'checking whether any existing value is in db or not if yes then update otherwise insert
                If Me.TextBox1.Tag & "" = "" Then

                    ' if not any data then add new one

                    cmd = New SqlCommand("insert into Products([Code],[Category],[Name],[Quantity],[Price]) values ('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "')", con)
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("Data Added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

                ' refreshing data
                DisplayData()

                clear() 'clearing textboxes

                con.Close()   'closing connection 
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Exception occurred", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub DisplayData()
        Dim da As SqlDataAdapter = New SqlDataAdapter("select * from Products", con)
        Dim ds As DataSet = New DataSet()
        da.Fill(ds)
        Main.DataGridView1.DataSource = ds.Tables(0)
    End Sub
    Sub clear()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
        Main.Show()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged, TextBox2.TextChanged, TextBox3.TextChanged, TextBox4.TextChanged, TextBox5.TextChanged
        If TextBox1.TextLength < 1.0 Then
            Label1.Show()
        Else
            Label1.Hide()
        End If
        If TextBox2.TextLength < 1.0 Then
            Label2.Show()
        Else
            Label2.Hide()
        End If
        If TextBox3.TextLength < 1.0 Then
            Label3.Show()
        Else
            Label3.Hide()
        End If
        If TextBox4.TextLength < 1.0 Then
            Label4.Show()
        Else
            Label4.Hide()
        End If
        If TextBox5.TextLength < 1.0 Then
            Label5.Show()
        Else
            Label5.Hide()
        End If

    End Sub
End Class