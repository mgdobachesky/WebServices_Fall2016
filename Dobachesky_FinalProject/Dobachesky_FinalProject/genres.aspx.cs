using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dobachesky_FinalProject
{
    public partial class genres : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtn_Click(object sender, CommandEventArgs e)
        {
            //grab track id from event handler and set a sessions variable equal to it
            string args = e.CommandArgument.ToString();
            string[] argsArray = args.Split(',');
            string genreId = argsArray[0];
            string genreName = argsArray[1];

            if (genreName != null)
            {
                Session["genreName"] = genreName;
            }

            if (args != null)
            {
                Response.Redirect("/genres/tracks?genreId=" + genreId);
            }
        }
    }
}