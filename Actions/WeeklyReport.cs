using System;
using System.Collections.Generic;
using BangazonProductRevenueReports.Factories;

namespace BangazonProductRevenueReports.Actions
{
    public class WeeklyReport
    {
        public static void Action()
        {
            SalesFactory salesFactory = SalesFactory.Instance;
            List<Sale> ListOfAllSales = salesFactory.GetAllSalesByDate();
            var DateTodayMinusSeven = DateTime.Today.AddDays(-7);
            Console.WriteLine("\r\n7 Day Sales Report:\r\n");
            Console.WriteLine("Product \t\t\t\t\t\tAmount");
            foreach (Sale sale in ListOfAllSales)
            {
                if (sale.PurchaseDate > DateTodayMinusSeven)
                {
                Console.WriteLine($"{sale.ProductName}\t\t{sale.PurchaseDate}\t\t\t\t${sale.ProductRevenue}.00");
                }
            }
        }
    }
}