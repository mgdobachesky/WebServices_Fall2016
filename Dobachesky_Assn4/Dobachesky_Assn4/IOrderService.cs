using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Dobachesky_Assn4
{
    [ServiceContract]
    public interface IOrderService
    {
        [OperationContract]
        int GetNumberOfOrders();

        [OperationContract]
        double GetTotalCostForAnOrder(int OrderID);

        [OperationContract]
        string GetItemListForOrder(int OrderID);

        [OperationContract]
        int HowManyOrderedForAPartNo(string sPartNo);

        [OperationContract]
        BillingInfo GetBillingAddressForAnOrder(int OrderID);
    }

    [DataContract]
    public class BillingInfo
    {
        string name;
        string address;
        string city;
        string state;
        string zip;

        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [DataMember]
        public string Address
        {
            get { return address; }
            set { address = value; }
        }


        [DataMember]
        public string City
        {
            get { return city; }
            set { city = value; }
        }

        [DataMember]
        public string State
        {
            get { return state; }
            set { state = value; }
        }

        [DataMember]
        public string Zip
        {
            get { return zip; }
            set { zip = value; }
        }
    }

}
