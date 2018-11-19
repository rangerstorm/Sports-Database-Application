Imports System.Data.SqlClient
Imports System.Speech.Synthesis

Public Class Login
    Dim con As New SqlClient.SqlConnection
    Dim da As New SqlClient.SqlDataAdapter
    Dim ds As New DataSet
    Dim sqlquery As String
    Private Sub Login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        con.ConnectionString = "Data Source=SHUBHAM;Initial Catalog=FIFA;Integrated Security=True"
        TextBox2.UseSystemPasswordChar = True
        Me.CenterToScreen()
        Blank.Show()
        Dim synth = New SpeechSynthesizer
        synth.Speak("Hello, Welcome to our Visual Basic Database Project.")
    End Sub
    Private Sub Form2_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove, PictureBox1.MouseMove
        Me.CenterToScreen()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles B.Click
        Try
            'checking if the username and password field is null

            If Len(Trim(TextBox1.Text)) = 0 Then
                MessageBox.Show("Enter the user name", "Input Error !", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
                TextBox1.Focus()
            End If
            If Len(Trim(TextBox2.Text)) = 0 Then
                MessageBox.Show("Enter the password", "Input Error !", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
                TextBox2.Focus()
            End If

            'executing SQL Query for retrieving the username and password from the database table

            con.Open()
            sqlquery = "SELECT * FROM Login WHERE username='" & TextBox1.Text & "' and password='" & TextBox2.Text & "' "
            da = New SqlClient.SqlDataAdapter(sqlquery, con)
            da.Fill(ds, "Login")
            If ds.Tables("Login").Rows.Count <> 0 Then
                Me.Hide()
                Main.Show()
            Else
                MessageBox.Show("Invalid user name and password", "Access denied", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            con.Close()

            Clear()    'calling clear method here

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Exception generated", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' declaring a method for clearing the controls
    Public Sub Clear()
        TextBox1.Clear()
        TextBox2.Clear()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        ' code for show password
        'Private Sub chkshowpass_CheckedChanged(sender As Object, e As EventArgs) Handles chkshowpass.CheckedChanged
        If CheckBox1.CheckState = CheckState.Checked Then
            'IF TRUE, IT SHOWS THE TEXT
            TextBox2.UseSystemPasswordChar = False
        Else
            'IF FALSE, IT WILL HIDE THE TEXT AND IT WILL TURN INTO BULLETS.
            TextBox2.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Dim synth = New SpeechSynthesizer
        synth.Speak("Thank You. Come back later.")
        Me.Close()
        Blank.Close()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If TextBox1.TextLength < 1.0 Then
            Label1.Show()
        Else
            Label1.Hide()
        End If
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        If TextBox2.TextLength < 1.0 Then
            Label2.Show()
        Else
            Label2.Hide()
        End If
    End Sub


End Class