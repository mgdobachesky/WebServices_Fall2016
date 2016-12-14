using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dobachesky_Assn4_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderService.OrderServiceClient proxy = new OrderService.OrderServiceClient();

            string billingInfo = "Billing Information for Order 1" + Environment.NewLine;
            billingInfo += "Name = " + proxy.GetBillingAddressForAnOrder(1).Name.ToString() + Environment.NewLine;
            billingInfo += "Address = " + proxy.GetBillingAddressForAnOrder(1).Address.ToString() + Environment.NewLine;
            billingInfo += "City = " + proxy.GetBillingAddressForAnOrder(1).City.ToString() + Environment.NewLine;
            billingInfo += "State = " + proxy.GetBillingAddressForAnOrder(1).State.ToString() + Environment.NewLine;
            billingInfo += "ZipCode = " + proxy.GetBillingAddressForAnOrder(1).Zip.ToString() + Environment.NewLine;

            string numberOrders = "Number of orders = " + proxy.GetNumberOfOrders().ToString() + Environment.NewLine;

            string totalCost = "Total cost for order 1 = " + proxy.GetTotalCostForAnOrder(1).ToString() + Environment.NewLine;

            string orderParts = "The number of orders with part 'JETSWEATER' = " + proxy.HowManyOrderedForAPartNo("JETSWEATER").ToString() + Environment.NewLine;

            string orderItems = "Items in order 1 (Qty. Part. Description)" + Environment.NewLine + proxy.GetItemListForOrder(1).ToString();

            Console.WriteLine(billingInfo);
            Console.WriteLine(numberOrders);
            Console.WriteLine(totalCost);
            Console.WriteLine(orderParts);
            Console.WriteLine(orderItems);

            Console.WriteLine("Enter CR To Exit");
            Console.ReadLine();

        }
    }
}
