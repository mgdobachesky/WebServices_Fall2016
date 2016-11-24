using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Midterm_pt2a
{
    [ServiceContract]
    public interface INEITStoreOrderService
    {
        [OperationContract]
        double ReturnAmountEarned(double balance, double interest);

        [OperationContract]
        accountInfo GetBankInformation(string AccountID);
    }

    [DataContract]
    public class accountInfo
    {
        string ownerName;
        string accountId;
        accounts[] accounts = new accounts[2];

        [DataMember]
        public string OwnerName
        {
            get { return ownerName; }
            set { ownerName = value; }
        }

        [DataMember]
        public string AccountId
        {
            get { return accountId; }
            set { accountId = value; }
        }

        [DataMember]
        public accounts[] Accounts
        {
            get { return accounts; }
            set { accounts = value; }
        }
    }

    [DataContract]
    public class accounts
    {
        string accountType;
        options options = new options();

        [DataMember]
        public string AccountType
        {
            get { return accountType; }
            set { accountType = value; }
        }

        [DataMember]
        public options Options
        {
            get { return options; }
            set { options = value; }
        }
    }

    [DataContract]
    public class options
    {
        string freeChecking;
        string overDraftProtection;

        [DataMember]
        public string FreeChecking
        {
            get { return freeChecking; }
            set { freeChecking = value; }
        }

        [DataMember]
        public string OverDraftProtection
        {
            get { return overDraftProtection; }
            set { overDraftProtection = value; }
        }
    }
}
