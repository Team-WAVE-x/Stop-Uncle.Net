Imports System.Web.Mvc
Imports MySql.Data.MySqlClient

Namespace Controllers
    Public Class AjeController
        Inherits Controller

        Function Index() As ActionResult
            '변수
            Dim data As String = String.Empty
            Dim question As String = String.Empty
            Dim answer As String = String.Empty

            'MySQL 에서 Row 수 가져오고 랜덤으로 뽑기
            Dim sCon As MySqlConnection = New MySqlConnection($"Server={ConfigurationManager.AppSettings("dbAddress")};Database={ConfigurationManager.AppSettings("dbName")};Uid={ConfigurationManager.AppSettings("dbUser")};Pwd={ConfigurationManager.AppSettings("dbPass")}")
            sCon.Open()
            Dim sqlCom As MySqlCommand = New MySqlCommand()
            sqlCom.Connection = sCon
            sqlCom.CommandText = $"SELECT COUNT(*) FROM {ConfigurationManager.AppSettings("dbTable")};"
            sqlCom.CommandType = CommandType.Text
            Dim Row As Integer = Convert.ToInt32(sqlCom.ExecuteScalar().ToString())
            sCon.Close()
            Dim rd As New Random
            Dim sCon1 As MySqlConnection = New MySqlConnection($"Server={ConfigurationManager.AppSettings("dbAddress")};Database={ConfigurationManager.AppSettings("dbName")};Uid={ConfigurationManager.AppSettings("dbUser")};Pwd={ConfigurationManager.AppSettings("dbPass")}")
            sCon1.Open()
            Dim sqlCom1 As MySqlCommand = New MySqlCommand()
            sqlCom1.Connection = sCon1
            sqlCom1.CommandText = $"SELECT * FROM {ConfigurationManager.AppSettings("dbTable")} WHERE _id=@rd"
            sqlCom1.CommandType = CommandType.Text
            sqlCom1.Parameters.Add(New MySqlParameter("@rd", rd.Next(1, Row + 1)))
            Dim reader As MySqlDataReader = sqlCom1.ExecuteReader()
            While reader.Read()
                question = reader("que")
                answer = reader("answer")
            End While
            sCon1.Close()

            '출력 방법 설정하기
            Select Case RouteData.Values("type")
                Case "json"
                    Response.ContentType = "application/json"
                    Dim jse As Script.Serialization.JavaScriptSerializer = New Script.Serialization.JavaScriptSerializer
                    Dim jsonoutput = jse.Serialize(New With
                    {
                        .que = question,
                        answer
                    })
                    data = jsonoutput
                Case "xml"
                    Response.ContentType = "application/xml"
                    Dim xmlDoc As New System.Xml.XmlDocument
                    Dim rootElement As System.Xml.XmlElement = xmlDoc.CreateElement("root")
                    xmlDoc.AppendChild(rootElement)
                    Dim queElement As System.Xml.XmlElement = xmlDoc.CreateElement("que")
                    queElement.InnerText = question
                    rootElement.AppendChild(queElement)
                    Dim answerElement As System.Xml.XmlElement = xmlDoc.CreateElement("answer")
                    answerElement.InnerText = answer
                    rootElement.AppendChild(answerElement)
                    data = xmlDoc.OuterXml
                Case "plain"
                    Response.ContentType = "text/plain"
                    data = $"{question}/{answer}"
                Case Else
                    Return HttpNotFound()
            End Select

            '출력하기
            Return Content(data)
        End Function
    End Class
End Namespace