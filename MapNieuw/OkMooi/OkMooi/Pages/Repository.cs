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

        //connectionstring to connect to database
        private IDbConnection Connect()
        {
            return new MySqlConnection(
                "Server=127.0.0.1;Port=3306;" +
                "Database=Shitfuck;" +
                "Uid=root;Pwd=12345;"
            );
        }


        //gets all users
        public User Get(string Username)
        {
            using var connection = Connect();
            var user = connection.QuerySingleOrDefault<User>(
                "SELECT * FROM User WHERE Username = @Username",

                new { username = Username });
            return user;
        }


        //adds new user to database
        public User AddUser(User user)
        {
            using var connection = Connect();
            User addedTodo = connection.QuerySingleOrDefault<User>(
                @"INSERT INTO User (Username, Admin, password) VALUES (@Username, 1, @password)"
                , user);
            return addedTodo;
        }
        
        
        //puts bookmarks in database
        public User Bookmarkp(string username, string bookmark)
        {
            using var connection = Connect();
            User result = connection.QuerySingleOrDefault<User>(@"
                UPDATE user SET bookmark = @Bookmark WHERE username= @Username", new { Username = username, Bookmark = bookmark }
            );

            return result;
        }
        //gets user by the username (id sounds cooler)
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
        //logs in the user if password and username is correct
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

        //ricks poopy comments
        public Comments AddComment(Comments comment)
        {
            comment.Time = DateTime.Now.ToString("HH:mm dd MMM yyyy");

            using var connection = Connect();
            Comments addedComment = connection.QuerySingleOrDefault<Comments>(
                @"INSERT INTO Comments (messagename, postedtime, username, Comment) VALUES (@Name, @Time, 'Anonymous', @Comment)"
                , comment);
            return addedComment;
        }

        //How we insert comment in database
        public int NewComment(User user)
        {
            user.Time = DateTime.Now.ToString("HH:mm dd MMM yyyy");
            using var connection = Connect();
            int AddThem = connection.Execute("INSERT INTO comments(messagename, postedtime, username, reaction, reacted, Comment)" +
                " VALUES (@Name , @Time, @Username, '1', '1', @Comment) ", user);
            return AddThem;

                
        }

        //How we display our comments
        public IEnumerable<User> GetComments()
        {
            using var connection = Connect();
            var comments = connection
                .Query<User>("SELECT * FROM comments") ;
            return comments;
        }


        //idk what this shit is
        List<string> username = new List<string>();
        List<string> commenttime = new List<string>();
        List<string> title = new List<string>();
        List<string> comments = new List<string>();

        
        //Ricks poopy code 
        public Comments displayComment(Comments comment)
        {
            

            var connection = Connect();
            Comments displayedComment = connection.QueryFirstOrDefault<Comments>
                ("select username, postedtime, messagename, Comment from comments order by Comment_ID desc;");

            return displayedComment;
        }
         
    

    }
}
