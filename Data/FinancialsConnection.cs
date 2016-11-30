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
        //Purpose of Method: checks to see if the revenue table exists and if null generates new data for database
        public static void SeedDatabase()
        {
            try
            {
            SalesFactory salesFactory = SalesFactory.Instance;
            FinancialsConnection connection = new FinancialsConnection();
            // Sale TestOrder = new Sale();
            connection.execute($"SELECT Id FROM Revenue LIMIT 1",
                (SqliteDataReader reader) =>
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("Database was already seeded");
                    }
                    reader.Dispose();
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                // Comment out these two lines for speed purposes after the initial db creation 
                // Uncomment them and run to generate fresh data
                DatabaseGenerator gen = new DatabaseGenerator();
                gen.CreateDatabase();
                Console.WriteLine("just seeded database");
            }
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