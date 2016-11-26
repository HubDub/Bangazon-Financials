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

        public List<Sale> GetAllSales()
        {
            FinancialsConnection connection = new FinancialsConnection();
            List<Sale> ListOfAllSales = new List<Sale>();

            connection.execute($"SELECT Id FROM Revenue",
                (SqliteDataReader reader) =>
                {
                    while (reader.Read())
                    {
                        ListOfAllSales.Add(new Sale
                        {
                            Id = reader.GetInt32(0)
                        });
                    }
                    reader.Dispose();
                });
            return ListOfAllSales;
        }

        public List<Sale> GetLastWeekSales(string FirstDate, string SecondDate)
        {
            FinancialsConnection connection = new FinancialsConnection();
            List<Sale> ListOfLastWeekSales = new List<Sale>();

            connection.execute($"SELECT Id, ProductName, ProductRevenue, PurchaseDate FROM Revenue WHERE PurchaseDate BETWEEN {FirstDate} AND {SecondDate}",
                (SqliteDataReader reader) =>
                {
                    while (reader.Read())
                    {
                        ListOfLastWeekSales.Add(new Sale
                        {
                            Id = reader.GetInt32(0),
                            ProductName = reader[1].ToString(),
                            ProductRevenue = reader.GetInt32(2),
                            PurchaseDate = reader.GetDateTime(3)
                        });
                    }
                    reader.Dispose();
                });
            return ListOfLastWeekSales;
        }
    }
}