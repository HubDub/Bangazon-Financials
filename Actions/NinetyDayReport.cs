using System;
using System.Collections.Generic;
using BangazonProductRevenueReports.Factories;

namespace BangazonProductRevenueReports.Actions
{
    public class NinetyDayReport
    {
        public static void Action()
        {
            SalesFactory salesFactory = SalesFactory.Instance;
            List<Sale> ListOfAllSales = salesFactory.GetAllSalesByDate();
            var DateTodayMinusSeven = DateTime.Today.AddDays(-90);
            Console.WriteLine("\r\n90 Day Sales Report:\r\n");
            Console.WriteLine("Product                        Amount");

            foreach (Sale sale in ListOfAllSales)
            {
                if (sale.PurchaseDate > DateTodayMinusSeven)
                {
                Console.WriteLine($"{sale.ProductName}    {sale.PurchaseDate}     ${sale.ProductRevenue}.00");
                }
            }
        }
    }
}