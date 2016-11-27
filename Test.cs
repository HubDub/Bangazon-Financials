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

            List<Sale> ListOfSales = salesFactory.GetAllSalesByDate();
            Assert.Equal(ListOfSales.Count, 1000);
        }

        [Fact]
        public void TestCanSumRevenuePerCustomer()
        {
            
            SalesFactory salesFactory = SalesFactory.Instance;
            List<Sale> ListOfRevenueByCustomer = salesFactory.GetAllSalesByCustomer();

            Assert.Equal(ListOfRevenueByCustomer.Count, 16);
        }

        [Fact]
        public void TestCanSumRevenuePerProduct()
        {
            SalesFactory salesFactory = SalesFactory.Instance;
            List<Sale> ListOfRevenueByProduct = salesFactory.GetAllSalesByCustomer();

            Assert.Equal(ListOfRevenueByProduct.Count, 16);
        }
    }
}