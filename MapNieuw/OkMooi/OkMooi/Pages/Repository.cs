using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using MySql.Data.MySqlClient;
using System.Data;
using OkMooi.Pages;

namespace OkMooi.Pages
{
    public class Repository
    {
        private IDbConnection Connect()
        {
            return new MySqlConnection(
                "Server=127.0.0.1;Port=3306;" +
                "Database=Shitfuck;" +
                "Uid=root;Pwd=12345;"
            );
        }

        public IEnumerable<User> Get()
        {
            using var connection = Connect();
            var Users = connection
                .Query<User>("SELECT * FROM User");
            return Users;
        }



        public User AddUser(User user)
        {
            using var connection = Connect();
            User addedTodo = connection.QuerySingleOrDefault<User>(
                @"INSERT INTO User (Username, Admin, password) VALUES (@Username, 1, @password)"
                , user);
            return addedTodo;
        }

        public bool LogInUser(string usernamee, string passworde)
        {
            using var connection = Connect();



            string query = "SELECT password FROM user  WHERE Username = @Username AND password = @pass";

            User updatedUser = connection.QuerySingle<User>(query, connection);
            


            bool output = false;

            

            return output;
        }




    }
}
