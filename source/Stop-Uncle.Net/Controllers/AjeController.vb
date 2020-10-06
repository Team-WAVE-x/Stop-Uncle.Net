Imports System.Web.Mvc

Namespace Controllers
    Public Class AjeController
        Inherits Controller

        ' GET: Aje
        Function Index() As ActionResult
            Dim data As String = String.Empty

            Select Case RouteData.Values("type")
                Case "json"
                    Response.ContentType = "application/json"

                    Dim jse As Script.Serialization.JavaScriptSerializer = New Script.Serialization.JavaScriptSerializer
                    Dim jsonoutput = jse.Serialize(New With
                    {
                        .status = "ok",
                        .que = "아재 개그 테스트 문제",
                        .answer = "아재 개그 테스트 정답"
                    })

                    data = jsonoutput
                Case "xml"
                    Response.ContentType = "application/xml"

                    Dim xmlDoc As New System.Xml.XmlDocument

                    Dim rootElement As System.Xml.XmlElement = xmlDoc.CreateElement("root")
                    xmlDoc.AppendChild(rootElement)

                    Dim statusElement As System.Xml.XmlElement = xmlDoc.CreateElement("status")
                    statusElement.InnerText = "ok"
                    rootElement.AppendChild(statusElement)

                    Dim queElement As System.Xml.XmlElement = xmlDoc.CreateElement("que")
                    queElement.InnerText = "아재 개그 테스트 문제"
                    rootElement.AppendChild(queElement)

                    Dim answerElement As System.Xml.XmlElement = xmlDoc.CreateElement("answer")
                    answerElement.InnerText = "아재 개그 테스트 정답"
                    rootElement.AppendChild(answerElement)

                    data = xmlDoc.OuterXml
                Case "plain"
                    Response.ContentType = "text/plain"
                    data = "아재 개그 테스트 문제/아재 개그 테스트 정답"
                Case Else
                    Return HttpNotFound()
            End Select

            Return Content(data)
        End Function
    End Class
End Namespace