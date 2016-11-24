using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm_pt2b
{
    class Program
    {
        static void Main(string[] args)
        {
            NEITStoreOrderService.NEITStoreOrderServiceClient proxy = new NEITStoreOrderService.NEITStoreOrderServiceClient();
            string pt1 = proxy.ReturnAmountEarned(100, .05).ToString() + Environment.NewLine;
            string pt2 = proxy.GetBankInformation("12345").ToString() + Environment.NewLine;

            Console.WriteLine(pt1);
            Console.WriteLine(pt2);

            Console.ReadLine();
        }
    }
}
