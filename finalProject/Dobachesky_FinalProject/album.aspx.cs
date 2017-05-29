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
    public partial class album : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if an artist has not been selected then redirect to home page
            if (Session["albumId"] == null || Session["albumId"].ToString() == "")
            {
                Response.Redirect("/home");
            }

            //set pageNumber to 1 if this is the first time the page loads
            if (!IsPostBack)
            {
                int page = Convert.ToInt32(Session["pageNumber"]);
                page = 1;
                Session["pageNumber"] = page;
            }

            //set pageNumber to 1 if it is currently 0
            if (Convert.ToInt32(Session["pageNumber"]) == 0 || Session["pageNumber"] == null)
            {
                Session["pageNumber"] = 1;
            }
            //declare a variable to hold the page number
            int pageNumber = Convert.ToInt32(Session["pageNumber"]);

            //run the APIs
            musixmatchApi(pageNumber);
            lastFmApi();
        }

        private void musixmatchApi(int pageNumber)
        {
            //prepare xml tools
            HttpWebRequest myHttpWebRequest = null;
            HttpWebResponse myHttpWebResponse = null;
            XmlTextReader myXmlTextReader = null;
            XPathNavigator myNavigator;
            XPathDocument myDocument;
            XPathNodeIterator nodeIterator;

            //prepare required musixmatch api data
            string musixmatchApiKey = "[API_KEY]";
            string albumId = "";
            if (Session["albumId"] != null)
            {
                albumId = Session["albumId"].ToString();
            }

            //create musixmatch api url from collected data
            string url = "http://api.musixmatch.com/ws/1.1/album.tracks.get?album_id=" + albumId + "&page=" + pageNumber + "&page_size=10&apikey=" + musixmatchApiKey + "&format=xml&f_has_lyrics=1";

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

                //create a node iterator to go through each item in the document
                nodeIterator = myNavigator.Select("//track");

                //clear table
                tblTracks.Rows.Clear();

                //append required information to table
                while (nodeIterator.MoveNext())
                {
                    //prepare the components needed to fill the data
                    XPathNodeIterator track = nodeIterator.Current.SelectChildren(XPathNodeType.Element);
                    TableRow tRow = new TableRow();
                    TableCell tCellName = new TableCell();
                    LinkButton nameClick = new LinkButton();
                    TableCell tCellLyrics = new TableCell();
                    TableCell tCellLength = new TableCell();
                    string hasLyrics = "" + track.Current.SelectSingleNode("has_lyrics");

                    //prepare the linkbutton to be clicked on
                    nameClick.Text = "" + track.Current.SelectSingleNode("track_name");
                    nameClick.CommandArgument = track.Current.SelectSingleNode("artist_id")
                        + "," + track.Current.SelectSingleNode("album_id") + ","
                        + track.Current.SelectSingleNode("track_id") + ","
                        + track.Current.SelectSingleNode("artist_name") + ","
                        + track.Current.SelectSingleNode("album_name") + ","
                        + track.Current.SelectSingleNode("track_name");
                    nameClick.Command += new CommandEventHandler(lbtn_Click);

                    //append data to the appropriate cells
                    tCellName.Controls.Add(nameClick);
                    if (hasLyrics == "1")
                    {
                        tCellLyrics.Text = "Yes";
                    }
                    else if (hasLyrics == "0")
                    {
                        tCellLyrics.Text = "No";
                    }
                    tCellLength.Text = "" + track.Current.SelectSingleNode("track_length") + " seconds";

                    //append cells to row
                    tRow.Cells.Add(tCellName);
                    tRow.Cells.Add(tCellLyrics);
                    tRow.Cells.Add(tCellLength);

                    //append row to table
                    tblTracks.Rows.Add(tRow);
                }
            }
            catch (Exception error)
            {
                Response.Redirect("/home");
            }

        }

        private void lastFmApi()
        {
            //prepare xml tools
            HttpWebRequest myHttpWebRequest = null;
            HttpWebResponse myHttpWebResponse = null;
            XmlTextReader myXmlTextReader = null;
            XPathNavigator myNavigator;
            XPathDocument myDocument;

            //prepare required lastfm api data
            string lastFmApiKey = "[API_KEY]";
            string artistName = "";
            string albumName = "";
            if (Session["artistName"] != null)
            {
                artistName = Session["artistName"].ToString();
            }
            if (Session["albumName"] != null)
            {
                albumName = Session["albumName"].ToString();
            }

            //create lastfm api url from collected data
            string url = "http://ws.audioscrobbler.com/2.0/?method=album.getinfo&artist=" + artistName + "&album=" + albumName + "&api_key=" + lastFmApiKey;

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
                lblArtist.InnerText = "" + myNavigator.SelectSingleNode("//artist");
                lblAlbum.InnerText = "" + myNavigator.SelectSingleNode("//name");
                imgAlbum.ImageUrl = myNavigator.SelectSingleNode("//image[@size='extralarge']").ToString();
            }
            catch (Exception error)
            {
                Response.Redirect("/home");
            }
        }

        private void lbtn_Click(object sender, CommandEventArgs e)
        {
            //grab information from event handler and set session variables for each
            string args = e.CommandArgument.ToString();
            string[] argsArray = args.Split(',');
            string artistId = argsArray[0];
            string albumId = argsArray[1];
            string trackId = argsArray[2];
            string artistName = argsArray[3];
            string albumName = argsArray[4];
            string trackName = argsArray[5];

            if (artistId != null)
            {
                Session["artistId"] = artistId;
            }

            if (albumId != null)
            {
                Session["albumId"] = albumId;
            }

            if (trackId != null)
            {
                Session["trackId"] = trackId;
            }

            if (artistName != null)
            {
                Session["artistName"] = artistName;
            }

            if (albumName != null)
            {
                Session["albumName"] = albumName;
            }

            if (trackName != null)
            {
                Session["trackName"] = trackName;
            }

            if (args != null)
            {
                Response.Redirect("/artist/album/track");
            }
        }

        //when previous is clicked decrement page number
        public void previous_Click(object sender, EventArgs e)
        {
            int pageNumber = Convert.ToInt32(Session["pageNumber"]);
            pageNumber--;
            Session["pageNumber"] = pageNumber;
            musixmatchApi(pageNumber);
        }

        //when next is clicked increment page number
        public void next_Click(object sender, EventArgs e)
        {
            int pageNumber = Convert.ToInt32(Session["pageNumber"]);
            pageNumber++;
            Session["pageNumber"] = pageNumber;
            musixmatchApi(pageNumber);
        }
    }
}
