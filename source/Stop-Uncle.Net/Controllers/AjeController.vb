Imports System.Web.Mvc

Namespace Controllers
    Public Class AjeController
        Inherits Controller

        Function Index() As ActionResult
            Dim data As String = String.Empty
            Dim question As String = "아재 개그 테스트 문제"
            Dim answer As String = "아재 개그 테스트 정답"

            Select Case RouteData.Values("type")
                Case "json"
                    Response.ContentType = "application/json"

                    Dim jse As Script.Serialization.JavaScriptSerializer = New Script.Serialization.JavaScriptSerializer
                    Dim jsonoutput = jse.Serialize(New With
                    {
                        .que = question,
                        .answer = answer
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

            Return Content(data)
        End Function
    End Class
End Namespace
