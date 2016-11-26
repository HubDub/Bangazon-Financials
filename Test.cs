using Xunit;
using BangazonProductRevenueReports.Factories;
using System;
using System.Collections.Generic;
using BangazonProductRevenueReports;

namespace BangazonFinancialTests
{
    public class FinancialTests
    {
        [Fact]
        public void TestOfTesting()
        {
            bool isMonday = true;
            Assert.True(isMonday);
        }

        [Fact]
        public void TestSalesFactoryIsSingleton()
        {
            SalesFactory salesFactory = SalesFactory.Instance;
            SalesFactory salesFactory2 = SalesFactory.Instance;
            Assert.Equal(salesFactory, salesFactory2); 
        }

        [Fact]
        public void TestCanPullSalesFromDB()
        {
            SalesFactory salesFactory = SalesFactory.Instance;

            List<Sale> ListOfSales = salesFactory.GetAllSales();
            Assert.Equal(ListOfSales.Count, 1000);
        }

        [Fact]
        public void TestCanPullSalesFromDBBetweenTwoDates()
        {
            SalesFactory salesFactory = SalesFactory.Instance;

            String FirstDate = "2016/11/03";
            String SecondDate = "2016/11/04";

            List<Sale> ListOfSalesByWeek = salesFactory.GetLastWeekSales(FirstDate,  SecondDate);
            Assert.Equal(ListOfSalesByWeek.Count, 0);
        }
    }
}