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
    public partial class tracks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //get the genre name from a session variable
            string genreName = "";
            if (Session["genreName"] != null && Session["genreName"].ToString() != "")
            {
                genreName = Session["genreName"].ToString();
            }
            else
            {
                genreName = "";
            }

            lblTracks.InnerText = genreName + " Tracks";

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

            //run the api call
            musixmatchApi(pageNumber);
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
            string musixmatchApiKey = "74a4faf48aaa62dbbaa400179d5fc478";
            string genreId = "";
            
            //get the genreId from the query string
            if (Request.QueryString["genreId"] != null && Request.QueryString["genreId"] != "")
            {
                genreId = Request.QueryString["genreId"];
            }
            else
            {
                Response.Redirect("/genres");
            }

            //create musixmatch api url from collected data
            string url = "http://api.musixmatch.com/ws/1.1/track.search?s_track_rating=desc&s_artist_rating=desc&f_lyrics_language=en&f_has_lyrics=1&page_size=20&page=" + pageNumber + "&format=xml&apikey=" + musixmatchApiKey + "&f_music_genre_id=" + genreId;
            
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
                    TableCell tCellTrack = new TableCell();
                    LinkButton trackClick = new LinkButton();
                    TableCell tCellArtist = new TableCell();
                    TableCell tCellAlbum = new TableCell();

                    //prepare the linkbutton to be clicked on
                    trackClick.Text = "" + track.Current.SelectSingleNode("track_name");
                    trackClick.CommandArgument = track.Current.SelectSingleNode("artist_id") 
                        + "," + track.Current.SelectSingleNode("album_id") + "," 
                        + track.Current.SelectSingleNode("track_id") + "," 
                        + track.Current.SelectSingleNode("artist_name") + "," 
                        + track.Current.SelectSingleNode("album_name") + "," 
                        + track.Current.SelectSingleNode("track_name");
                    trackClick.Command += new CommandEventHandler(lbtn_Click);

                    //append data to the appropriate cells
                    tCellTrack.Controls.Add(trackClick);
                    tCellArtist.Text = "" + track.Current.SelectSingleNode("artist_name");
                    tCellAlbum.Text = "" + track.Current.SelectSingleNode("album_name");

                    //append cells to row
                    tRow.Cells.Add(tCellTrack);
                    tRow.Cells.Add(tCellArtist);
                    tRow.Cells.Add(tCellAlbum);

                    //append row to table
                    tblTracks.Rows.Add(tRow);
                }
            }
            catch (Exception error)
            {
                Response.Redirect("/genres");
            }
        }

        //function used to handle the click of a track
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