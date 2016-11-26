using System;

namespace BangazonProductRevenueReports
{
    public class Sale
    {
        public int Id {get; set;}
        public string ProductName {get; set;}
        public double ProductCost {get; set;}
        public double ProductRevenue {get; set;}
        public string ProductSupplierState {get; set;}
        public string CustomerFirstName {get; set;}
        public string CustomerLastName {get; set;}
        public string CustomerAddress {get; set;}
        public string CustomerZipCode {get; set;}
        public DateTime PurchaseDate {get; set;}
    }
}