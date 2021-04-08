using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using MySql.Data.MySqlClient;
using System.Data;
using OkMooi.Pages;

namespace OkMooi
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

        

        public User Get(string Username)
        {
            using var connection = Connect();
            var user = connection.QuerySingleOrDefault<User>(
                "SELECT * FROM Todo WHERE Username = @Username",

                new { username = Username });
            return user;
        }



        public User AddUser(User user)
        {
            using var connection = Connect();
            User addedTodo = connection.QuerySingleOrDefault<User>(
                @"INSERT INTO User (Username, Admin, password, bookmark) VALUES (@Username, 1, @password, kloot)"
                , user);
            return addedTodo;
        }

        internal IEnumerable<User> Get()
        {
            throw new NotImplementedException();
        }

        public bool LogInUser(User user)
        {
            var connection = Connect();
             User loggedinUser = connection.QueryFirstOrDefault<User>
                ("SELECT * FROM User WHERE Username = @Username AND Password = @Password", 
                new { username = user.Username, password = user.Password });
            if(loggedinUser !=null)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        






    }
}
