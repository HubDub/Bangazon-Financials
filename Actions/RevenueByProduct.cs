using System;
using System.Collections.Generic;
using BangazonProductRevenueReports.Factories;

namespace BangazonProductRevenueReports.Actions
{
    //Class Name: RevenueByProduct
    //Author: Debbie Bourne
    //Purpose of this class: to create a total revenue report of all products sold 
    //Methods in Class: Action()
    public class RevenueByProduct
    {
        //Method Name: Action()
        //Purpose of Method: calls factory for data and then displays data for user
        public static void Action()
        {
            SalesFactory salesFactory = SalesFactory.Instance;
            List<Sale> ListOfRevenueByProduct = salesFactory.GetAllSalesByProduct();
            Banner.Action();            
            Console.WriteLine("\r\nProduct Revenue Report:");
            Console.WriteLine("Product                           Revenue");
            Console.WriteLine("=========================================");
            foreach (Sale sale in ListOfRevenueByProduct)
            {
                Console.WriteLine($"{sale.ProductName, -25}         ${sale.ProductRevenue}.00");
            }
            Console.WriteLine("\r\nPlease press any key to continue");
        }
    }
}