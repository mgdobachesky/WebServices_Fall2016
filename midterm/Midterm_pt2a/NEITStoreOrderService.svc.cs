using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Midterm_pt2a
{
    public class Service1 : INEITStoreOrderService
    {
       public double ReturnAmountEarned(double balance, double interest)
        {
            double results = balance * interest;
            return results;
        }

        public accountInfo GetBankInformation(string AccountID)
        {
            options options1 = new options();
            options1.FreeChecking = "N";
            options1.OverDraftProtection = "Y";

            accounts account1 = new accounts();
            account1.AccountType = "checking";
            account1.Options = options1;

            options options2 = new options();
            options2.OverDraftProtection = "N";

            accounts account2 = new accounts();
            account2.AccountType = "savings";
            account2.Options = options2;

            accountInfo accountInfo = new accountInfo();
            accountInfo.OwnerName = "Sam Spade";
            accountInfo.AccountId = "12345";
            accountInfo.Accounts[0] = account1;
            accountInfo.Accounts[1] = account2;

            return accountInfo;
        }
    }
}
