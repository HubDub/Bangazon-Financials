using Xunit;
using BangazonProductRevenueReports.Factories;
using System;
using System.Collections.Generic;
using BangazonProductRevenueReports;

namespace BangazonFinancialTests
{
    //Class Name: FinancialTests
    //Author: Debbie Bourne
    //Purpose of this class: To test database interactions
    //Methods in Class: TestOfTesting(), TestSalesFactoryIsSingleton(), TestCanPullAllSalesFromDB(), TestCanPullLastSevenDaysSalesFromDB(), TestCanPullLast30DaysSalesFromDB(), TestCanPullLast90DaysSalesFromDB(), TestCanSumRevenuePerCustomer(), TestCanSumRevenuePerProduct() 
    public class FinancialTests
    {
        //Method Name: TestOfTesting()
        //Purpose of Method: Test that the testing is working
        [Fact]
        public void TestOfTesting()
        {
            bool isMonday = true;
            Assert.True(isMonday);
        }

        //Method Name: TestSalesFactoryIsSingleton()
        //Purpose of Method: Test that there is only one salesFactory at a time
        [Fact]
        public void TestSalesFactoryIsSingleton()
        {
            SalesFactory salesFactory = SalesFactory.Instance;
            SalesFactory salesFactory2 = SalesFactory.Instance;
            Assert.Equal(salesFactory, salesFactory2); 
        }

        //Method Name: TestCanPullAllSalesFromDB()
        //Purpose of Method: Test that all sales data can be pulled from DB
        [Fact]
        public void TestCanPullAllSalesFromDB()
        {
            SalesFactory salesFactory = SalesFactory.Instance;

            List<Sale> ListOfAllSales = salesFactory.GetAllSalesByDate();
            Assert.Equal(ListOfAllSales.Count, 1000);
        }

        //Method Name: TestCanPullLastSevenDaysSalesFromDB()
        //Purpose of Method: Test that last seven days of data can be pulled from DB
        [Fact]
        public void TestCanPullLastSevenDaysSalesFromDB()
        {
            SalesFactory salesFactory = SalesFactory.Instance;
            List<Sale> ListOfLastSevenDaysSales = salesFactory.GetLastSevenDaysSales();
            Assert.NotEqual(ListOfLastSevenDaysSales.Count, 0);
        }

        //Method Name: TestCanPullLast30DaysSalesFromDB()
        //Purpose of Method: Test that last thirty days of data can be pulled from DB
        [Fact]
        public void TestCanPullLast30DaysSalesFromDB()
        {
        SalesFactory salesFactory = SalesFactory.Instance;
        List<Sale> ListOfLastThirtyDaysSales = salesFactory.GetLastThirtyDaysSales();
        Assert.NotEqual(ListOfLastThirtyDaysSales.Count, 0);
        }

        //Method Name: TestCanPullLastNinetyDaysSalesFromDB()
        //Purpose of Method: Test that last ninety days of data can be pulled from DB
        [Fact]
        public void TestCanPullLast90DaysSalesFromDB()
        {
        SalesFactory salesFactory = SalesFactory.Instance;
        List<Sale> ListOfLastNinetyDaysSales = salesFactory.GetLastNinetyDaysSales();
        Assert.NotEqual(ListOfLastNinetyDaysSales.Count, 0);
        }

        //Method Name: TestCanSumRevenuePerCustomer()
        //Purpose of Method: Test that a sum of all revenue by customer can be pulled from DB
        [Fact]
        public void TestCanSumRevenuePerCustomer()
        {
            
            SalesFactory salesFactory = SalesFactory.Instance;
            List<Sale> ListOfRevenueByCustomer = salesFactory.GetAllSalesByCustomer();

            Assert.NotEqual(ListOfRevenueByCustomer.Count, 16);
        }

        //Method Name: TestCanSumRevenuePerProduct()
        //Purpose of Method: Test that a sum of all revenue by product can be pulled from DB
        [Fact]
        public void TestCanSumRevenuePerProduct()
        {
            SalesFactory salesFactory = SalesFactory.Instance;
            List<Sale> ListOfRevenueByProduct = salesFactory.GetAllSalesByCustomer();

            Assert.Equal(ListOfRevenueByProduct.Count, 16);
        }
    }
}