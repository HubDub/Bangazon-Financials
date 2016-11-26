using System;
using Microsoft.Data.Sqlite;

namespace BangazonProductRevenueReports.Data
{
    public class FinancialsConnection
    {
        private string _connectionString = $"Filename={System.Environment.GetEnvironmentVariable("REPORTING_DB_PATH")}";

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
    }
}