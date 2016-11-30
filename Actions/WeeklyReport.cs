using System;
using System.Collections.Generic;
using BangazonProductRevenueReports.Factories;

namespace BangazonProductRevenueReports.Actions
{
    //Class Name: WeeklyReport
    //Author: Debbie Bourne
    //Purpose of this class: to create a sales report for the last week
    //Methods in Class: Action()
    public class WeeklyReport
    {
        //Method Name: Action()
        //Purpose of Method: calls factory for data and then displays data for user
        public static void Action()
        {
            SalesFactory salesFactory = SalesFactory.Instance;
            List<Sale> ListOfAllSales = salesFactory.GetLastSevenDaysSales();
            Banner.Action();
            Console.WriteLine("\r\n7 Day Sales Report:");
            Console.WriteLine("Product                                                 Amount");
            Console.WriteLine("==============================================================");
            foreach (Sale sale in ListOfAllSales)
            {
                Console.WriteLine($"{sale.ProductName, -25} {sale.PurchaseDate, -30}${sale.ProductRevenue}.00");
            }
            Console.WriteLine("\r\nPlease press any key to continue");
        }
    }
}