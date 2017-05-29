using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.XPath;

namespace Dobachesky_Assn2
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            XPathNavigator nav;
            XPathDocument docNav;
            XPathNodeIterator NodeIter;

            //open the xml file
            String rootPath = Server.MapPath("~");
            string strFilename = rootPath + "\\OrderInfo.xml";
            docNav = new XPathDocument(strFilename);

            //create navigator with xml document
            nav = docNav.CreateNavigator();

            lblNumber.Text += nav.Evaluate("count(/Order/Items/Item)").ToString();
            lblTotal.Text += nav.Evaluate("sum(/Order/Items/Item/TotalCost)").ToString();


            //select billing node and place results in iterator
            txtBilling.Text = "";
            NodeIter = nav.Select("/Order/BillingInformation");
            while (NodeIter.MoveNext())
            {
                XPathNodeIterator billingInfo = NodeIter.Current.SelectChildren(XPathNodeType.Element);
                txtBilling.Text += "Name: " + billingInfo.Current.SelectSingleNode("Name") + Environment.NewLine;
                txtBilling.Text += "Address: " + billingInfo.Current.SelectSingleNode("Address") + Environment.NewLine;
                txtBilling.Text += "City: " + billingInfo.Current.SelectSingleNode("City") + Environment.NewLine;
                txtBilling.Text += "State: " + billingInfo.Current.SelectSingleNode("State") + Environment.NewLine;
                txtBilling.Text += "Zip Code: " + billingInfo.Current.SelectSingleNode("ZipCode") + Environment.NewLine;
            }

            //select shipping node and place results in iterator
            txtShipping.Text = "";
            NodeIter = nav.Select("/Order/ShippingInformation");
            while (NodeIter.MoveNext())
            {
                XPathNodeIterator shippingInfo = NodeIter.Current.SelectChildren(XPathNodeType.Element);
                txtShipping.Text += "Name: " + shippingInfo.Current.SelectSingleNode("Name") + Environment.NewLine;
                txtShipping.Text += "Address: " + shippingInfo.Current.SelectSingleNode("Address") + Environment.NewLine;
                txtShipping.Text += "City: " + shippingInfo.Current.SelectSingleNode("City") + Environment.NewLine;
                txtShipping.Text += "State: " + shippingInfo.Current.SelectSingleNode("State") + Environment.NewLine;
                txtShipping.Text += "Zip Code: " + shippingInfo.Current.SelectSingleNode("ZipCode") + Environment.NewLine;
            }

            //select items node and place results in iterator
            txtItem.Text = "";
            NodeIter = nav.Select("/Order/Items");
            while (NodeIter.MoveNext())
            {
                XPathNodeIterator item;
                item = NodeIter.Current.Select("Item");
                while (item.MoveNext())
                {
                    XPathNodeIterator itemInfo = item.Current.SelectChildren(XPathNodeType.Element);
                    txtItem.Text += "Part Number: " + itemInfo.Current.SelectSingleNode("PartNo") + Environment.NewLine;
                    txtItem.Text += "Description: " + itemInfo.Current.SelectSingleNode("Description") + Environment.NewLine;
                    txtItem.Text += "Unit Price: $" + itemInfo.Current.SelectSingleNode("UnitPrice") + Environment.NewLine;
                    txtItem.Text += "Quantity: " + itemInfo.Current.SelectSingleNode("Quantity") + Environment.NewLine;
                    txtItem.Text += "Total Cost: $" + itemInfo.Current.SelectSingleNode("TotalCost") + Environment.NewLine;
                    if (itemInfo.Current.SelectSingleNode("CustomerOptions").HasChildren)
                    {
                        txtItem.Text += "Size: " + itemInfo.Current.SelectSingleNode("CustomerOptions/Size") + Environment.NewLine;
                        txtItem.Text += "Color: " + itemInfo.Current.SelectSingleNode("CustomerOptions/Color") + Environment.NewLine;
                    }
                    txtItem.Text += Environment.NewLine + "--------------" + Environment.NewLine;
                }
            }
        }
    }
}