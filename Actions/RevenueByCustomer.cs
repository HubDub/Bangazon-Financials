using System;
using System.Collections.Generic;
using BangazonProductRevenueReports.Factories;

namespace BangazonProductRevenueReports.Actions
{
    public class RevenueByCustomer
    {
        public static void Action()
        {
            SalesFactory salesFactory = SalesFactory.Instance;
            List<Sale> ListOfRevenueByCustomer = salesFactory.GetAllSalesByCustomer();
            Console.WriteLine("\r\nCustomer Revenue Report:\r\n");
            Console.WriteLine("Customer                          Revenue");
            foreach (Sale sale in ListOfRevenueByCustomer)
            {
                Console.WriteLine($"{sale.CustomerFirstName} {sale.CustomerLastName}      ${sale.ProductRevenue}.00");
            }
        }
    }
}