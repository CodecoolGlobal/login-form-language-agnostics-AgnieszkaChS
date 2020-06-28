using System;
using Npgsql;

namespace LoginForm.Services
{
    public interface IDbConnectionService
    {
        NpgsqlConnection GetDatabaseConnectionObject();
    }
}
