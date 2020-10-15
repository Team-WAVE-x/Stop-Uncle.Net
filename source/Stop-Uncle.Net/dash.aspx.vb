Imports MySql.Data.MySqlClient

Public Class dash
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If User.Identity.IsAuthenticated = False Then
            Response.Redirect("login.aspx")
        Else
            form1.Visible = True

            Try
                Dim sCon As MySqlConnection = New MySqlConnection($"Server={ConfigurationManager.AppSettings("dbAddress")};Database={ConfigurationManager.AppSettings("dbName")};Uid={ConfigurationManager.AppSettings("dbUser")};Pwd={ConfigurationManager.AppSettings("dbPass")}")
                sCon.Open()
                Dim sqlCom As MySqlCommand = New MySqlCommand()
                sqlCom.Connection = sCon
                sqlCom.CommandText = $"SELECT * FROM {ConfigurationManager.AppSettings("dbTable")};"
                sqlCom.CommandType = CommandType.Text
                Dim reader As MySqlDataReader = sqlCom.ExecuteReader()

                While reader.Read()
                    Dim row As TableRow = New TableRow()

                    Dim cell1 As TableCell = New TableCell()
                    cell1.Text = reader("_id")
                    row.Cells.Add(cell1)

                    Dim cell2 As TableCell = New TableCell()
                    cell2.Text = reader("que")
                    row.Cells.Add(cell2)

                    Dim cell3 As TableCell = New TableCell()
                    cell3.Text = reader("answer")
                    row.Cells.Add(cell3)

                    Table1.Rows.Add(row)
                End While

                sCon.Close()
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub btnLogout_ServerClick(sender As Object, e As EventArgs) Handles btnLogout.ServerClick
        If User.Identity.IsAuthenticated = True Then
            FormsAuthentication.SignOut()
            Response.Redirect("login.aspx")
        End If
    End Sub
End Class