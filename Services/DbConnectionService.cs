using System;
using Npgsql;

namespace LoginForm.Services
{
    public class DbConnectionService : IDbConnectionService
    {

        public string HostAddress { get; set; }
        public string HostName { get; set; }
        public string HostPassword { get; set; }
        public string DatabaseName { get; set; }

        public DbConnectionService(string hostAddress, string hostName, string hostPassword, string databaseName)
        {
            HostAddress = hostAddress;
            HostName = hostName;
            HostPassword = hostPassword;
            DatabaseName = databaseName;
        }

        public NpgsqlConnection GetDatabaseConnectionObject()
        {
            string connectionString = $"Host={HostAddress};Username={HostName};Password={HostPassword};Database={DatabaseName}";
            return new NpgsqlConnection(connectionString);
        }
    }
}
