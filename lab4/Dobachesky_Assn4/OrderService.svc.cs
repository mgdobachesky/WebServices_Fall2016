using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web;
using System.Xml.XPath;

namespace Dobachesky_Assn4
{
    public class OrderService : IOrderService
    {
        public int GetNumberOfOrders()
        {
            XPathNavigator nav;
            XPathDocument docNav;
            int result;

            string directory = HttpContext.Current.Server.MapPath(".");
            string fileName = directory + "\\" + "orderInfoLab3.xml";

            docNav = new XPathDocument(fileName);

            nav = docNav.CreateNavigator();

            result = Convert.ToInt32(nav.Evaluate("count(//Order)").ToString());
            return result;
        }

        public double GetTotalCostForAnOrder(int OrderID)
        {
            XPathNavigator nav;
            XPathDocument docNav;
            double result;

            string directory = HttpContext.Current.Server.MapPath(".");
            string fileName = directory + "\\" + "orderInfoLab3.xml";
            docNav = new XPathDocument(fileName);

            nav = docNav.CreateNavigator();
            result = Convert.ToDouble(nav.Evaluate("sum(//Order[@id=" + OrderID + "]//TotalCost)").ToString());

            return result;
        }

        public string GetItemListForOrder(int OrderID)
        {
            XPathNavigator nav;
            XPathDocument docNav;
            XPathNodeIterator nodeIter;
            string itemsInfo;

            string directory = HttpContext.Current.Server.MapPath(".");
            string fileName = directory + "\\" + "orderInfoLab3.xml";
            docNav = new XPathDocument(fileName);
            nav = docNav.CreateNavigator();

            itemsInfo = "";

            nodeIter = nav.Select("//Order[@id=" + OrderID + "]//Item");
            while (nodeIter.MoveNext())
            {
                XPathNodeIterator itemInfo = nodeIter.Current.SelectChildren(XPathNodeType.Element);
                itemsInfo += itemInfo.Current.SelectSingleNode("Quantity");
                itemsInfo += " " + itemInfo.Current.SelectSingleNode("PartNo");
                itemsInfo += " " + itemInfo.Current.SelectSingleNode("Description");
                //itemsInfo += " " + itemInfo.Current.SelectSingleNode("UnitPrice");
                //itemsInfo += " " + itemInfo.Current.SelectSingleNode("TotalCost");
                //XPathNodeIterator customerOptions = itemInfo.Current.SelectSingleNode("TotalCost").SelectChildren(XPathNodeType.Element);
                //itemsInfo += " " + customerOptions.Current.SelectSingleNode("Size");
                //itemsInfo += " " + customerOptions.Current.SelectSingleNode("Color");
                itemsInfo += Environment.NewLine;
            }

            return itemsInfo;
        }

        public int HowManyOrderedForAPartNo(string sPartNo)
        {
            XPathNavigator nav;
            XPathDocument docNav;
            int result;

            string directory = HttpContext.Current.Server.MapPath(".");
            string fileName = directory + "\\" + "orderInfoLab3.xml";
            docNav = new XPathDocument(fileName);

            nav = docNav.CreateNavigator();

            result = Convert.ToInt32(nav.Evaluate("count(//Order//Item[PartNo='" + sPartNo + "']//PartNo)"));

            return result;
        }

        public BillingInfo GetBillingAddressForAnOrder(int OrderID)
        {
            XPathNavigator nav;
            XPathDocument docNav;
            XPathNodeIterator nodeIter;
            BillingInfo newBillingInfo = new BillingInfo();

            string directory = HttpContext.Current.Server.MapPath(".");
            string fileName = directory + "\\" + "orderInfoLab3.xml";
            docNav = new XPathDocument(fileName);

            nav = docNav.CreateNavigator();

            nodeIter = nav.Select("//Order[@id=" + OrderID + "]/BillingInformation");
            while (nodeIter.MoveNext())
            {
                XPathNodeIterator billingDetails = nodeIter.Current.SelectChildren(XPathNodeType.Element);
                newBillingInfo.Name = billingDetails.Current.SelectSingleNode("Name").ToString();
                newBillingInfo.Address = billingDetails.Current.SelectSingleNode("Address").ToString();
                newBillingInfo.City = billingDetails.Current.SelectSingleNode("City").ToString();
                newBillingInfo.State = billingDetails.Current.SelectSingleNode("State").ToString();
                newBillingInfo.Zip = billingDetails.Current.SelectSingleNode("ZipCode").ToString();
            }

            return newBillingInfo;
        }
    }
}
