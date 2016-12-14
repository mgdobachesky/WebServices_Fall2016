using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.XPath;

namespace Dobachesky_Lab3
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGetForecast_Click(object sender, EventArgs e)
        {
            HttpWebRequest myHttpWebRequest = null;     //Declare an HTTP-specific implementation of the WebRequest class.
            HttpWebResponse myHttpWebResponse = null;   //Declare an HTTP-specific implementation of the WebResponse class
            XmlTextReader myXMLReader = null;           //Declare XMLReader           
            XPathNavigator nav;
            XPathDocument docNav;
            XPathNodeIterator nodeIter;
            txtForecast.Text = "";

            //Create Request
            String WeatherURL = "http://api.wunderground.com/api/63192752279e7829/forecast/q/MA/Boston.xml";

            myHttpWebRequest = (HttpWebRequest)HttpWebRequest.Create(WeatherURL);
            myHttpWebRequest.Method = "GET";
            myHttpWebRequest.ContentType = "text/xml; encoding='utf-8'";
            //Get Response
            myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();

            //Load response stream into XMLReader
            myXMLReader = new XmlTextReader(myHttpWebResponse.GetResponseStream());

            docNav = new XPathDocument(myXMLReader);
            // Create a navigator to query with XPath.
            nav = docNav.CreateNavigator();

            //create a XPathNodeIterator for each of the forecast days in the xml data
            nodeIter = nav.Select("//forecastday");
            //loop through each day
            while(nodeIter.MoveNext())
            {
                //create an XPathNodeIterator and assign a variable to it that selects each child element of the day
                XPathNodeIterator dayInfo = nodeIter.Current.SelectChildren(XPathNodeType.Element);
                //select each node that contains the data needed and append it to the text box
                txtForecast.Text += dayInfo.Current.SelectSingleNode("title") + Environment.NewLine;
                txtForecast.Text += dayInfo.Current.SelectSingleNode("fcttext") + Environment.NewLine;
                txtForecast.Text += Environment.NewLine;
            }
        }

        protected void btnGetZipCities_Click(object sender, EventArgs e)
        {
            HttpWebRequest myHttpWebRequest = null;     //Declare an HTTP-specific implementation of the WebRequest class.
            HttpWebResponse myHttpWebResponse = null;   //Declare an HTTP-specific implementation of the WebResponse class
            XmlTextReader myXMLReader = null;           //Declare XMLReader           
            XPathNavigator nav;
            XPathDocument docNav;
            XPathNodeIterator nodeIter;
            txtZipOutput.Text = "";

            //Create Request
            String WeatherURL = "http://api.geonames.org/postalCodeSearch?postalcode=" + txtZip.Text + "&maxRows=10&username=mgdobachesky&style=full";

            myHttpWebRequest = (HttpWebRequest)HttpWebRequest.Create(WeatherURL);
            myHttpWebRequest.Method = "GET";
            myHttpWebRequest.ContentType = "text/xml; encoding='utf-8'";
            //Get Response
            myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();

            //Load response stream into XMLReader
            myXMLReader = new XmlTextReader(myHttpWebResponse.GetResponseStream());

            docNav = new XPathDocument(myXMLReader);
            // Create a navigator to query with XPath.
            nav = docNav.CreateNavigator();

            //create a node iterator to select all the zip codes in the xml data
            nodeIter = nav.Select("//code");
            //loop through the data
            while (nodeIter.MoveNext())
            {
                //create a variable to hold the children of the piece of data that is being looped through in another node iterator
                XPathNodeIterator zipInfo = nodeIter.Current.SelectChildren(XPathNodeType.Element);
                //output the data to the text box
                txtZipOutput.Text += zipInfo.Current.SelectSingleNode("postalcode") + "-" + zipInfo.Current.SelectSingleNode("name") + Environment.NewLine;
            }

        }

        protected void btnGetNearby_Click(object sender, EventArgs e)
        {
            HttpWebRequest myHttpWebRequest = null;     //Declare an HTTP-specific implementation of the WebRequest class.
            HttpWebResponse myHttpWebResponse = null;   //Declare an HTTP-specific implementation of the WebResponse class
            XmlTextReader myXMLReader = null;           //Declare XMLReader           
            XPathNavigator nav;
            XPathDocument docNav;
            XPathNodeIterator nodeIter;
            txtZipOutput.Text = "";

            //Create Request
            String WeatherURL = "http://api.geonames.org/findNearbyPostalCodes?postalcode=" + txtZip.Text + "&country=US&radius=10&username=mgdobachesky&style=full";

            myHttpWebRequest = (HttpWebRequest)HttpWebRequest.Create(WeatherURL);
            myHttpWebRequest.Method = "GET";
            myHttpWebRequest.ContentType = "text/xml; encoding='utf-8'";
            //Get Response
            myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();

            //Load response stream into XMLReader
            myXMLReader = new XmlTextReader(myHttpWebResponse.GetResponseStream());

            docNav = new XPathDocument(myXMLReader);
            // Create a navigator to query with XPath.
            nav = docNav.CreateNavigator();

            //create a node iterator for the code element in the xml data
            nodeIter = nav.Select("//code");
            //loop through each of the returned results
            while (nodeIter.MoveNext())
            {
                //create a node iterator called zipInfo to hold each of the children of the node in question
                XPathNodeIterator zipInfo = nodeIter.Current.SelectChildren(XPathNodeType.Element);
                //append the needed data to the text box
                txtZipOutput.Text += zipInfo.Current.SelectSingleNode("postalcode") + "-" + zipInfo.Current.SelectSingleNode("name") + Environment.NewLine;
            }
        }
    }
}