using System;
using System.Collections.Generic;
using BangazonProductRevenueReports.Factories;

namespace BangazonProductRevenueReports.Actions
{
    //Class Name: RevenueByCustomer
    //Author: Debbie Bourne
    //Purpose of this class: to create a report of total revenue from all customers 
    //Methods in Class: Action()
    public class RevenueByCustomer
    {
        //Method Name: Action()
        //Purpose of Method: calls factory for data and then displays data for user
        public static void Action()
        {
            SalesFactory salesFactory = SalesFactory.Instance;
            List<Sale> ListOfRevenueByCustomer = salesFactory.GetAllSalesByCustomer();
            Banner.Action();
            Console.WriteLine("\r\nCustomer Revenue Report:");
            Console.WriteLine("Customer              Revenue");
            Console.WriteLine("=============================");
            foreach (Sale sale in ListOfRevenueByCustomer)
            {
                Console.WriteLine($"{sale.CustomerFirstName, -10} {sale.CustomerLastName, -10} ${sale.ProductRevenue}.00");
            }
            Console.WriteLine("\r\nPlease press any key to continue");
        }
    }
}