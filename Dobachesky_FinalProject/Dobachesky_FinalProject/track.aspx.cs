using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.XPath;

namespace Dobachesky_FinalProject
{
    public partial class track : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if an artist has not been selected then redirect to home page
            if (Session["trackId"] == null || Session["trackId"].ToString() == "")
            {
                Response.Redirect("/home");
            }

            //run the API calls
            musixmatchApiLyrics();
            musixmatchApiTrack();
        }

        private void musixmatchApiLyrics()
        {
            //prepare xml tools
            HttpWebRequest myHttpWebRequest = null;
            HttpWebResponse myHttpWebResponse = null;
            XmlTextReader myXmlTextReader = null;
            XPathNavigator myNavigator;
            XPathDocument myDocument;

            //prepare required musixmatch api data
            string musixmatchApiKey = "74a4faf48aaa62dbbaa400179d5fc478";
            string trackId = "";
            if (Session["trackId"] != null)
            {
                trackId = Session["trackId"].ToString();
            }

            //create musixmatch api url from collected data
            string url = "http://api.musixmatch.com/ws/1.1/track.lyrics.get?track_id=" + trackId + "&apikey=" + musixmatchApiKey + "&format=xml";
            
            try
            {
                //create and deploy an http request to defined url
                myHttpWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);
                myHttpWebRequest.Method = "GET";
                myHttpWebRequest.ContentType = "text/xml; encoding='utf-8'";

                //get http response
                myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();

                //load response into an xml reader
                myXmlTextReader = new XmlTextReader(myHttpWebResponse.GetResponseStream());

                //use the information from the reader to create a new XPath document
                myDocument = new XPathDocument(myXmlTextReader);

                //create a way to navigate the XPath document
                myNavigator = myDocument.CreateNavigator();

                //append required information to page
                lblLyrics.InnerText = "" + myNavigator.SelectSingleNode("//lyrics_body");
            }
            catch (Exception error)
            {
                Response.Redirect("/home");
            }

        }

        private void musixmatchApiTrack()
        {
            //prepare xml tools
            HttpWebRequest myHttpWebRequest = null;
            HttpWebResponse myHttpWebResponse = null;
            XmlTextReader myXmlTextReader = null;
            XPathNavigator myNavigator;
            XPathDocument myDocument;

            //prepare required musixmatch api data
            string musixmatchApiKey = "74a4faf48aaa62dbbaa400179d5fc478";
            string trackId = "";
            if (Session["trackId"] != null)
            {
                trackId = Session["trackId"].ToString();
            }

            //create lastfm api url from collected data
            string url = "http://api.musixmatch.com/ws/1.1/track.get?track_id=" + trackId + "&apikey=" + musixmatchApiKey + "&format=xml";
            
            try
            {
                //create and deploy an http request to defined url
                myHttpWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);
                myHttpWebRequest.Method = "GET";
                myHttpWebRequest.ContentType = "text/xml; encoding='utf-8'";

                //get http response
                myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();

                //load response into an xml reader
                myXmlTextReader = new XmlTextReader(myHttpWebResponse.GetResponseStream());

                //use the information from the reader to create a new XPath document
                myDocument = new XPathDocument(myXmlTextReader);

                //create a way to navigate the XPath document
                myNavigator = myDocument.CreateNavigator();

                //append required information to page
                lblArtist.InnerText = "" + myNavigator.SelectSingleNode("//artist_name");
                lblAlbum.InnerText = "" + myNavigator.SelectSingleNode("//album_name");
                lblTrack.InnerText = "" + myNavigator.SelectSingleNode("//track_name");
            }
            catch (Exception error)
            {
                Response.Redirect("/home");
            }
        }
    }
}