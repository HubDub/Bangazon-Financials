using System;
using BangazonProductRevenueReports.Actions;

namespace BangazonProductRevenueReports
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Bangazon Reports");
            bool go_on = true;

            while (go_on)
            {
                try
                {

                    Console.WriteLine("1 - Last Week Report");
                    Console.WriteLine("2 - Last Month Report");
                    Console.WriteLine("3 - Last 3 months Report");
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
