using System.Collections.Generic;
using BangazonProductRevenueReports.Data;
using Microsoft.Data.Sqlite;

namespace BangazonProductRevenueReports.Factories
{
    public class SalesFactory
    {
        private static SalesFactory _instance;
        public static SalesFactory Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SalesFactory();
                }
                return _instance;
            }
        }

        public List<Sale> GetAllSalesByDate()
        {
            FinancialsConnection connection = new FinancialsConnection();
            List<Sale> ListOfAllSales = new List<Sale>();

            connection.execute($"SELECT Id, ProductName, ProductCost, ProductRevenue, ProductSupplierState, CustomerFirstName, CustomerLastName, CustomerAddress, CustomerZipCode, PurchaseDate FROM Revenue ORDER BY PurchaseDate",
                (SqliteDataReader reader) =>
                {
                    while (reader.Read())
                    {
                        ListOfAllSales.Add(new Sale
                        {
                            Id = reader.GetInt32(0),
                            ProductName = reader[1].ToString(),
                            ProductCost = reader.GetInt32(2),
                            ProductRevenue = reader.GetInt32(3),
                            ProductSupplierState = reader[4].ToString(),
                            CustomerFirstName = reader[5].ToString(),
                            CustomerLastName = reader[6].ToString(),
                            CustomerAddress = reader[7].ToString(),
                            CustomerZipCode = reader[8].ToString(),
                            PurchaseDate = reader.GetDateTime(9)
                        });
                    }
                    reader.Dispose();
                });
            return ListOfAllSales;
        }

        public List<Sale> GetAllSalesByCustomer()
        {
            FinancialsConnection connection = new FinancialsConnection();
            List<Sale> ListOfRevenueByCustomer = new List<Sale>();

            connection.execute($"SELECT CustomerFirstName, CustomerLastName, Sum(ProductRevenue) as ProductRevenue FROM Revenue GROUP BY CustomerLastName",
                (SqliteDataReader reader) =>
                {
                    while (reader.Read())
                    {
                        ListOfRevenueByCustomer.Add( new Sale
                        {
                            CustomerFirstName = reader[0].ToString(),
                            CustomerLastName = reader[1].ToString(),
                            ProductRevenue = reader.GetInt32(2)
                        });
                    }
                    reader.Dispose();
                });
            return ListOfRevenueByCustomer;
        }

        public List<Sale> GetAllSalesByProduct()
        {
            FinancialsConnection connection = new FinancialsConnection();
            List<Sale> ListOfRevenueByProduct = new List<Sale>();

            connection.execute($"SELECT ProductName, Sum(ProductRevenue) as ProductRevenue FROM Revenue GROUP BY ProductName",
                (SqliteDataReader reader) =>
                {
                    while (reader.Read())
                    {
                        ListOfRevenueByProduct.Add(new Sale
                        {
                            ProductName = reader[0].ToString(),
                            ProductRevenue = reader.GetInt32(1)
                        });
                    }
                    reader.Dispose();
                });
            return ListOfRevenueByProduct;
        }
    }
}