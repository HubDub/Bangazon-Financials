using System;
using System.Collections.Generic;
using BangazonProductRevenueReports.Factories;

namespace BangazonProductRevenueReports.Actions
{
    //Class Name: NinetyDayReport
    //Author: Debbie Bourne
    //Purpose of this class: to create a report of sales for the last 90 days 
    //Methods in Class: Action()
    public class NinetyDayReport
    {
        //Method Name: Action()
        //Purpose of Method: calls factory for data and then displays data for user
        public static void Action()
        {
            SalesFactory salesFactory = SalesFactory.Instance;
            List<Sale> ListOfAllSales = salesFactory.GetLastNinetyDaysSales();
            Banner.Action();
            Console.WriteLine("\r\n90 Day Sales Report:");
            Console.WriteLine("Product                                                  Amount");
            Console.WriteLine("===============================================================");
            foreach (Sale sale in ListOfAllSales)
            {
                Console.WriteLine($"{sale.ProductName, -25} {sale.PurchaseDate, -30} ${sale.ProductRevenue}.00");
            }
            Console.WriteLine("\r\nPlease press any key to continue");
        }
    }
}