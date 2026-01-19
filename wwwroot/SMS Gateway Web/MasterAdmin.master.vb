Imports System.Xml
Imports System.IO

Partial Class MasterAdmin
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'GetWeather()
    End Sub

    Protected Sub btnHome_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnHome.Click
        Session.Clear()
        Session.Abandon()
        Response.Redirect("../Login.aspx")
    End Sub

    Sub GetWeather()
        'http://www.webservicex.net/globalweather.asmx
        Dim proxyWeather As net.webservicex.www.GlobalWeather = New net.webservicex.www.GlobalWeather

        Dim result As String
        Dim addTag As String
        Dim m_xmlr As XmlTextReader
        Dim weather As String
        Dim temperture As String
        Dim objDBMis As New DBMis
        Dim locationResult() As String = CountryIP.Split(",")

        Try
            result = proxyWeather.GetWeather(locationResult(0), locationResult(1))
        Catch ex As Exception
            result = proxyWeather.GetWeather("Singapore", "Singapore")
        End Try

        addTag = "<?xml version=""" + "1.0""" + " encoding=""" + "utf-8""" + "?>"

        ' remove the utf=16 tags
        result = result.Remove(0, 39)
        result = addTag + " " + result

        objDBMis.SaveTextToXMLFile(result, System.Web.HttpContext.Current.Request.MapPath("../weather.xml"))

        'Create the XML Reader
        m_xmlr = New XmlTextReader(System.Web.HttpContext.Current.Request.MapPath("../weather.xml"))
        'Disable whitespace so that you don't have to read over whitespaces
        m_xmlr.WhitespaceHandling = WhitespaceHandling.None

        '<SkyConditions> partly cloudy</SkyConditions>
        'http://www.weather.gov.sg/wip/web/home/further_outlook

        Dim temp As String = m_xmlr.ReadElementString()
        temp = m_xmlr.ReadElementString()

        temp = m_xmlr.ReadElementString()
        temp = m_xmlr.ReadElementString()

        weather = (m_xmlr.ReadElementString()).Trim.ToLower

        temperture = (m_xmlr.ReadElementString()).Trim

        ' Refer to the following to determine the cloudy etc.
        'http://www.weather.gov.sg/wip/web/home/further_outlook

        If weather.CompareTo("mostly cloudy") Then

            imgWeather.ImageUrl() = "Weather/cloudy.png"

        ElseIf weather.CompareTo("fair") Then

            imgWeather.ImageUrl() = "Weather/fair.png"

        ElseIf weather.CompareTo("hazy") Then

            imgWeather.ImageUrl() = "Weather/hazy.png"

        ElseIf weather.CompareTo("cloudy") Then

            imgWeather.ImageUrl() = "Weather/cloudy.png"

        ElseIf weather.CompareTo("rain") Then

            imgWeather.ImageUrl() = "Weather/rain.png"

        ElseIf weather.CompareTo("showers") Then

            imgWeather.ImageUrl() = "Weather/showers.png"

        ElseIf weather.CompareTo("thunder storm") Then

            imgWeather.ImageUrl() = "Weather/thunderstorm.png"

        ElseIf weather.CompareTo("windy") Then

            imgWeather.ImageUrl() = "Weather/windy.png"

        End If

        lblWeather.Text = "Temperture: " + temperture + "<br/>" + "Condition: " + weather

        'close the reader
        m_xmlr.Close()
    End Sub

    Public Function CountryIP() As String
        'http://trial.serviceobjects.com/gpp/GeoPinPoint.asmx
        Dim proxyCountry As com.serviceobjects.trial.DOTSGeoPinPoint = New com.serviceobjects.trial.DOTSGeoPinPoint
        Dim totalString As String = "Singapore,Singapore"
        Dim strHostName As String
        Dim strIPAddress As String

        Try
            strHostName = System.Net.Dns.GetHostName()
            strIPAddress = (System.Net.Dns.GetHostEntry(strHostName).AddressList(0).ToString)

            If strIPAddress.Chars(1) = ":" Then ' To trap the error in case of private network
                strIPAddress = (System.Net.Dns.GetHostEntry(strHostName).AddressList(1).ToString)
            End If

            Dim countryByIP As com.serviceobjects.trial.Location

            'WS1-GQN4-HPF1
            countryByIP = proxyCountry.GetLocationByIP(strIPAddress, "WS1-RYI3-BGZ3") 'second string represents validation key

            If countryByIP.Country = Nothing Or countryByIP.City = Nothing Then
                totalString = "Singapore,Singapore"
            Else
                totalString = countryByIP.Country & "," & countryByIP.City
            End If

        Catch ex As Exception
            Return totalString
        End Try

        Return totalString

    End Function

End Class

