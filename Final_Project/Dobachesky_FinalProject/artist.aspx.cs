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
    public partial class artist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if an artist has not been selected then redirect to home page
            if (Session["artistId"] == null || Session["artistId"].ToString() == "")
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
            string artistId = "";
            if (Session["artistId"] != null)
            {
                artistId = Session["artistId"].ToString();
            }

            //create musixmatch api url from collected data
            string url = "http://api.musixmatch.com/ws/1.1/artist.albums.get?artist_id=" + artistId + "&page=" + pageNumber + "&page_size=10&apikey=" + musixmatchApiKey + "&format=xml&s_release_date=desc&g_album_name=1";

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

                //append table name
                lblAlbums.InnerText = myNavigator.SelectSingleNode("//artist_name").ToString();

                //create a node iterator to go through each item in the document
                nodeIterator = myNavigator.Select("//album");

                //clear table
                tblAlbums.Rows.Clear();

                //append required information to table
                while (nodeIterator.MoveNext())
                {
                    //prepare the components needed to fill the data
                    XPathNodeIterator album = nodeIterator.Current.SelectChildren(XPathNodeType.Element);
                    TableRow tRow = new TableRow();
                    TableCell tCellName = new TableCell();
                    LinkButton nameClick = new LinkButton();
                    TableCell tCellType = new TableCell();
                    TableCell tCellDate = new TableCell();

                    //prepare the linkbutton to be clicked on
                    nameClick.Text = "" + album.Current.SelectSingleNode("album_name");
                    nameClick.CommandArgument = album.Current.SelectSingleNode("artist_id") + "," + album.Current.SelectSingleNode("album_id") + "," + album.Current.SelectSingleNode("artist_name") + "," + album.Current.SelectSingleNode("album_name");
                    nameClick.Command += new CommandEventHandler(lbtn_Click);

                    //append data to the appropriate cells
                    tCellName.Controls.Add(nameClick);
                    tCellType.Text = "" + album.Current.SelectSingleNode("album_release_type");
                    tCellDate.Text = "" + album.Current.SelectSingleNode("album_release_date");

                    //append cells to row
                    tRow.Cells.Add(tCellName);
                    tRow.Cells.Add(tCellType);
                    tRow.Cells.Add(tCellDate);

                    //append row to table
                    tblAlbums.Rows.Add(tRow);
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
            if (Session["artistName"] != null)
            {
                artistName = Session["artistName"].ToString();
            }

            //create lastfm api url from collected data
            string url = "http://ws.audioscrobbler.com/2.0/?method=artist.getinfo&artist=" + artistName + "&api_key=" + lastFmApiKey;

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

                //append required information to table
                imgArtist.ImageUrl = myNavigator.SelectSingleNode("//image[@size='extralarge']").ToString();
                lblBio.InnerText = myNavigator.SelectSingleNode("//bio/content").ToString();
            }
            catch (Exception error)
            {
                Response.Redirect("/home");
            }
        }

        //function used to handle the click of an album
        private void lbtn_Click(object sender, CommandEventArgs e)
        {
            //grab album id from event handler and set a session variable equal to it
            string args = e.CommandArgument.ToString();
            string[] argsArray = args.Split(',');
            string artistId = argsArray[0];
            string albumId = argsArray[1];
            string artistName = argsArray[2];
            string albumName = argsArray[3];

            if (artistId != null)
            {
                Session["artistId"] = artistId;
            }

            if (albumId != null)
            {
                Session["albumId"] = albumId;
            }

            if (artistName != null)
            {
                Session["artistName"] = artistName;
            }

            if (albumName != null)
            {
                Session["albumName"] = albumName;
            }

            if (args != null)
            {
                Session["trackId"] = "";
                Session["trackName"] = "";
                Response.Redirect("/artist/album");
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
