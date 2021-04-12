using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using MySql.Data.MySqlClient;
using System.Data;
using OkMooi.Pages;
using Microsoft.AspNetCore.Mvc;

namespace OkMooi
{


    public class Repository

    {
        [BindProperty]
        User UserById { get; set; }
        private IDbConnection Connect()
        {
            return new MySqlConnection(
                "Server=127.0.0.1;Port=3306;" +
                "Database=legoyoda;" +
                "Uid=root;Pwd=root;"
            );
        }



        public User Get(string Username)
        {
            using var connection = Connect();
            var user = connection.QuerySingleOrDefault<User>(
                "SELECT * FROM User WHERE Username = @Username",

                new { username = Username });
            return user;
        }



        public User AddUser(User user)
        {
            using var connection = Connect();
            User addedTodo = connection.QuerySingleOrDefault<User>(
                @"INSERT INTO User (Username, Admin, password) VALUES (@Username, 1, @password)"
                , user);
            return addedTodo;
        }

        internal IEnumerable<User> Get()
        {
            throw new NotImplementedException();
        }

       

        public User GetUserByUserID(string username)
        {
            var connection = Connect();
            List<User> usercheckers = connection.Query<User>(sql : "SELECT * FROM user").ToList();
            foreach (var user in usercheckers)
            {
                if(user.Username == username)
                {
                    UserById = user;
                    return UserById;
                }
            }
            return null;
        }

        public bool LogInUser(User user)
        {
            var connection = Connect();
            User loggedinUser = connection.QueryFirstOrDefault<User>
               ("SELECT * FROM User WHERE Username = @Username AND Password = @Password",
               new { username = user.Username, password = user.Password });
            if (loggedinUser != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        //to add a comment
        public Comments AddComment(Comments comment)
        {
            comment.Time = DateTime.Now.ToString("HH:mm dd MMM yyyy");

            using var connection = Connect();
            Comments addedComment = connection.QuerySingleOrDefault<Comments>(
                @"INSERT INTO Comments (messagename, postedtime, username, Comment) VALUES (@Name, @Time, 'Anonymous', @Comment)"
                , comment);
            return addedComment;
        }


        List<string> username = new List<string>();
        List<string> commenttime = new List<string>();
        List<string> title = new List<string>();
        List<string> comments = new List<string>();


        public Comments displayComment(Comments comment)
        {
            

            var connection = Connect();
            Comments displayedComment = connection.QueryFirstOrDefault<Comments>
                ("select username, postedtime, messagename, Comment from comments order by Comment_ID desc;");

            username.Add(new ("placeholder"));
            username.Add(new ("placeholder2"));
            commenttime.Add(new ("placeholder"));
            commenttime.Add(new ("placeholder2"));
            title.Add(new ("placeholder"));
            title.Add(new ("placeholder2"));
            comments.Add(new ("placeholder"));
            comments.Add(new ("placeholder2"));

            return displayedComment;
        }
         
    

    }
}
