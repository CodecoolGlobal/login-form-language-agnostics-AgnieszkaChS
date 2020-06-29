using System;
using System.Collections.Generic;
using LoginForm.Models;
using LoginForm.Services;
using Npgsql;

namespace LoginForm.DAO
{
    public class UserDB : IUser
    {
        private readonly IDbConnectionService _dbConnectionService;

        public UserDB(string hostAddress, string hostName, string hostPassword, string databaseName)
        {
            _dbConnectionService = new DbConnectionService(hostAddress, hostName, hostPassword, databaseName);
        }

        public User GetUserByEmail(string email)
        {
            using var con = _dbConnectionService.GetDatabaseConnectionObject();
            string sql = @$"SELECT * FROM users
                            WHERE email = '{email}';";

            con.Open();
            using var cmd = new NpgsqlCommand(sql, con);
            using NpgsqlDataReader reader = cmd.ExecuteReader();

            return ParseUser(reader);
        }

        public User GetUserById(int id)
        {
            using var con = _dbConnectionService.GetDatabaseConnectionObject();
            string sql = @$"SELECT * FROM users
                            WHERE id = '{id}';";

            con.Open();
            using var cmd = new NpgsqlCommand(sql, con);
            using NpgsqlDataReader reader = cmd.ExecuteReader();

            return ParseUser(reader);
        }

        public bool IsEmailRegistered(string email)
        {
            using var con = _dbConnectionService.GetDatabaseConnectionObject();
            string sql = @$"SELECT * FROM users
                            WHERE email = '{email}';";

            con.Open();
            using var cmd = new NpgsqlCommand(sql, con);
            using NpgsqlDataReader reader = cmd.ExecuteReader();
            List<User> userWithSelectedEmail = new List<User>();
            while (reader.Read())
            {

                userWithSelectedEmail.Add(ParseUser(reader));
            }
            return Convert.ToBoolean(userWithSelectedEmail.Count);
        }

        private User ParseUser(NpgsqlDataReader reader)
        {
            User user = new User();

            while (reader.Read())
            {
                user.Id = reader.GetInt32(0);
                user.Name = reader.GetString(1);
                user.Email = reader.GetString(2);
                user.Pass = reader.GetString(3);
            }

            return user;
        }
    }
}
