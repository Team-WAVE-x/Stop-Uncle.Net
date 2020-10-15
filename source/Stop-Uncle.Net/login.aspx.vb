Public Class login
    Inherits System.Web.UI.Page
    Private Sub btnSignIn_ServerClick(sender As Object, e As EventArgs) Handles btnSignIn.ServerClick
        If inputEmail.Value = ConfigurationManager.AppSettings("dbUser") And inputPassword.Value = ConfigurationManager.AppSettings("dbPass") Then
            FormsAuthentication.RedirectFromLoginPage(inputEmail.Value, True)
            Response.Redirect("dash.aspx")
        End If

        inputEmail.Value = String.Empty
        inputPassword.Value = String.Empty
    End Sub

    Private Sub login_Load(sender As Object, e As EventArgs) Handles Me.Load
        If User.Identity.IsAuthenticated = True Then
            Response.Redirect("dash.aspx")
        End If
    End Sub

End Class