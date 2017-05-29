using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dobachesky_FinalProject
{
    public partial class FinalProject : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //function that stores a search parameter from a textbox on the navbar
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //reload the page with new search parameters
            Response.Redirect("/home?artistName=" + txtSearch.Text);
        }
    }
}