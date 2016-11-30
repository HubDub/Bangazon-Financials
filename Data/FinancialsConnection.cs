using System;
using BangazonProductRevenueReports.Factories;
using Microsoft.Data.Sqlite;

namespace BangazonProductRevenueReports.Data
{
    //Class Name: FinancialsConnection
    //Author: Debbie Bourne
    //Purpose of this class: to connect application to the database 
    //Methods in Class: SeedDatabase(), execute()
    public class FinancialsConnection
    {
        private string _connectionString = $"Filename={System.Environment.GetEnvironmentVariable("REPORTING_DB_PATH")}";

        //Method Name: SeedDatabase()
        //Purpose of Method: asks salesfactory to pull first row from database and if null generates new data for database - THIS IS NOT WORKING RIGHT NOW
        public static void SeedDatabase()
        {
            // SalesFactory salesFactory = SalesFactory.Instance;
            // Sale oneOrder = salesFactory.GetOneSale();
            // if (oneOrder = null)
            // {
                //Comment out these two lines for speed purposes after the initial db creation 
                //Uncomment them and run to generate fresh data
                // DatabaseGenerator gen = new DatabaseGenerator();
                // gen.CreateDatabase();
            // }
        }

        //Method Name: execute()
        //Purpose of Method: creates and opens connection to database, executes the sqlreader, then closes connection.
        public void execute(string query, Action<SqliteDataReader> handler)
        {
            
            SqliteConnection databaseConnection = new SqliteConnection(_connectionString);
            databaseConnection.Open();
            SqliteCommand databaseCommand = databaseConnection.CreateCommand();
            databaseCommand.CommandText = query;

            
            using (var reader = databaseCommand.ExecuteReader())
            {
                handler(reader);
            }
            databaseCommand.Dispose();
            databaseConnection.Close();
        }

        //Method Name: execute(v)
        //Purpose of Method: throw an exception
        internal void execute(string v)
        {
            throw new NotImplementedException();
        }
    }
}