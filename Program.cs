using System;
using BangazonProductRevenueReports.Actions;
using BangazonProductRevenueReports.Data;

namespace BangazonProductRevenueReports
{
    //Class Name: Program
    //Author: Debbie Bourne
    //Purpose of this class: this class is the entry point of the app 
    //Methods in Class: Main()
    public class Program
    {
        //Method Name: Main()
        //Purpose of Method: starts the app 
        public static void Main(string[] args)
        {
            FinancialsConnection.SeedDatabase();
            bool go_on = true;

            while (go_on)
            {
                try
                {
                    Banner.Action();
                    Console.WriteLine("1 - Last Seven Days Report");
                    Console.WriteLine("2 - Last Thirty Days Report");
                    Console.WriteLine("3 - Last Ninety Days Report");
                    Console.WriteLine("4 - Rev by customer");
                    Console.WriteLine("5 - Rev by product");

                    var UserResponse = Console.ReadLine();

                    switch (UserResponse)
                    {
                        case "1":
                            WeeklyReport.Action();

                            break;
                        case "2":
                            MonthlyReport.Action();
                            
                            break;
                        case "3":
                            NinetyDayReport.Action();
                            
                            break;
                        case "4":
                            RevenueByCustomer.Action();

                            break;
                        case "5":
                            RevenueByProduct.Action();
                            
                            break;
                        default:
                            Console.WriteLine("Invalid input. Try Again.");
                            break;
                    }
                    Console.ReadKey();
                }
                catch (Exception ex)
                {
                    //ADDING ERROR HANDLING
                    Console.WriteLine("Sorry an error has occcured. Please try agin ");
                    Console.WriteLine($"{ex}");
                    go_on = false;
                    Console.ReadKey();
                }
            }       
        }
    }
}
