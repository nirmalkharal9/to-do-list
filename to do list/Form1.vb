Imports System.Diagnostics.Eventing
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports MySql.Data.MySqlClient

Public Class Form1
    Dim mysqlConn As MySqlConnection
    Dim COMMAND As MySqlCommand

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        mysqlConn = New MySqlConnection
        mysqlConn.ConnectionString = "server=localhost;userid=root;password='';database=todo"

        Dim READER As MySqlDataReader
        Dim title As String = TextBox1.Text
        Dim id As String = TextBox2.Text

        Dim datex As DateTime = DateTimePicker1.Value
        If title.Length < 1 Then
            MessageBox.Show("title is empty, please enter title.")
        ElseIf id.Length < 1 Then
            MessageBox.Show("title is empty, please enter your id.")
        Else

            Try
                mysqlConn.Open()
                Dim query As String
                query = "insert into todo.list(id ,title,date) values('" & TextBox2.Text & " ','" & TextBox1.Text & " ','" & datex & " '
)"
                COMMAND = New MySqlCommand(query, mysqlConn)
                READER = COMMAND.ExecuteReader
                MessageBox.Show("Data Saved")

                mysqlConn.Close()
                mysqlConn.Dispose()
            Catch ex As MySqlException
                MessageBox.Show(ex.Message)
                mysqlConn.Close()
            Finally
                mysqlConn.Dispose()
            End Try
        End If
    End Sub



    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        mysqlConn = New MySqlConnection
        mysqlConn.ConnectionString = "server=localhost;userid=root;password='';database=todo"

        Dim READER As MySqlDataReader

        Try
            mysqlConn.Open()
            Dim query As String
            query = "select id , title,date from todo.list where id = '" & TextBox2.Text & " '"

            COMMAND = New MySqlCommand(query, mysqlConn)
            READER = COMMAND.ExecuteReader

            Dim dataTable As New DataTable()
            dataTable.Load(READER)

            DataGridView1.DataSource = dataTable
            READER.Close()



            mysqlConn.Close()
            mysqlConn.Dispose()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
            mysqlConn.Close()
        Finally
            mysqlConn.Dispose()
        End Try
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim data As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
        Dim title As String = data.Cells("title").Value.ToString()
        Dim id As String = data.Cells("id").Value.ToString()


        Dim READER As MySqlDataReader
        Try
            mysqlConn.Open()
            Dim query As String
            query = "delete from todo.list where id = '" & id & " ' and title ='" & title & " ' "

            COMMAND = New MySqlCommand(query, mysqlConn)
            COMMAND.ExecuteReader()

            MessageBox.Show("work deleted.")



            mysqlConn.Close()
            mysqlConn.Dispose()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
            mysqlConn.Close()
        Finally
            mysqlConn.Dispose()
        End Try


    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub
End Class
