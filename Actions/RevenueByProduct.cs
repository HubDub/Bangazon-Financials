using System;
using System.Collections.Generic;
using BangazonProductRevenueReports.Factories;

namespace BangazonProductRevenueReports.Actions
{
    public class RevenueByProduct
    {
        public static void Action()
        {
            SalesFactory salesFactory = SalesFactory.Instance;
            List<Sale> ListOfRevenueByProduct = salesFactory.GetAllSalesByProduct();
            Console.WriteLine("\r\nProduct Revenue Report:\r\n");
            Console.WriteLine("Product                          Revenue");
            foreach (Sale sale in ListOfRevenueByProduct)
            {
                Console.WriteLine($"{sale.ProductName}         ${sale.ProductRevenue}.00");
            }
        }
    }
}