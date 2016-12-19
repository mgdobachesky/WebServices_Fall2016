using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.XPath;

namespace Midterm_pt3
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnMidterm_Click(object sender, EventArgs e)
        {
            XPathNavigator nav;
            XPathDocument docNav;
            XPathNodeIterator NodeIter;

            //open the xml file
            String rootPath = Server.MapPath("~");
            string strFilename = rootPath + "\\catalog.xml";
            docNav = new XPathDocument(strFilename);

            //create navigator with xml document
            nav = docNav.CreateNavigator();

            NodeIter = nav.Select("//catalog_item[price<40]");

            while (NodeIter.MoveNext())
            {
                XPathNodeIterator firstText = NodeIter.Current.SelectChildren(XPathNodeType.Element);
                txtMidterm3a.Text += firstText.Current.SelectSingleNode("price") + Environment.NewLine;
                txtMidterm3a.Text += firstText.Current.GetAttribute("gender", "") + Environment.NewLine;

                txtMidterm3a.Text += Environment.NewLine;
            }

            NodeIter = nav.Select("//catalog_item/size[@description='Small']/../item_number");

            while (NodeIter.MoveNext())
            {
                txtMidterm3b.Text += NodeIter.Current;

                txtMidterm3b.Text += Environment.NewLine;
            }
        }
    }
}