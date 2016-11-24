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
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //set pageNumber to 1 if this is the first time the page loads
            if(!IsPostBack)
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
            //run the api call for this page
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
            string artistName = "";
            if (Request.QueryString["artistName"] != null && Request.QueryString["artistName"] != "")
            {
                artistName = Request.QueryString["artistName"];
            }
            else
            {
                artistName = "";
            }

            //create musixmatch api url from collected data
            string url = "http://api.musixmatch.com/ws/1.1/artist.search?q_artist=" + artistName + "&page=" + pageNumber.ToString() + "&page_size=20&apikey=" + musixmatchApiKey + "&format=xml&s_artist_rating=desc";
            
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
                nodeIterator = myNavigator.Select("//artist");

                //clear table 
                tblArtists.Rows.Clear();

                //append artist link and details to a displayed table for each row returned
                while (nodeIterator.MoveNext())
                {
                    //prepare the components needed to fill the data
                    XPathNodeIterator artist = nodeIterator.Current.SelectChildren(XPathNodeType.Element);
                    TableRow tRow = new TableRow();
                    TableCell tCellName = new TableCell();
                    LinkButton nameClick = new LinkButton();
                    TableCell tCellGenre = new TableCell();
                    TableCell tCellRating = new TableCell();
                    string genre = "" + artist.Current.SelectSingleNode("primary_genres//music_genre_name");

                    //prepare the linkbutton to be clicked on
                    nameClick.Text = "" + artist.Current.SelectSingleNode("artist_name");
                    nameClick.CommandArgument = artist.Current.SelectSingleNode("artist_id") + "," + artist.Current.SelectSingleNode("artist_name");
                    nameClick.Command += new CommandEventHandler(lbtn_Click);

                    //append data to the appropriate cells
                    tCellName.Controls.Add(nameClick);
                    if (genre != "")
                    {
                        tCellGenre.Text = genre;
                    }
                    else if (genre == "")
                    {
                        tCellGenre.Text = "N/A";
                    }
                    tCellRating.Text = "" + artist.Current.SelectSingleNode("artist_rating");

                    //append cells to row
                    tRow.Cells.Add(tCellName);
                    tRow.Cells.Add(tCellGenre);
                    tRow.Cells.Add(tCellRating);

                    //append row to table
                    tblArtists.Rows.Add(tRow);
                }
            }
            catch(Exception error)
            {
                Response.Redirect("/home");
            }
        }

        //function used to handle the click of an artist
        private void lbtn_Click(object sender, CommandEventArgs e)
        {
            //grab artist id from event handler and set a session variable equal to it
            string args = e.CommandArgument.ToString();
            string[] argsArray = args.Split(',');
            string artistId = argsArray[0];
            string artistName = argsArray[1];

            if (artistName != null)
            {
                Session["artistId"] = artistId;
            }

            if (artistName != null)
            {
                Session["artistName"] = artistName;
            }
            
            if (args != null)
            {
                Session["albumId"] = "";
                Session["trackId"] = "";
                Session["albumName"] = "";
                Session["trackName"] = "";
                Response.Redirect("/artist");
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