using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;

namespace OkMooi.Pages
{
    public class Kloot : PageModel
    {

        [BindProperty] public string aars { get; set; }
        [BindProperty] public string bookmark { get; set; }
        
        [BindProperty] public User Bookmark { get; set; }
        [BindProperty] public string doos { get; set; }

        private IDbConnection Connect()
        {
            return new MySqlConnection(
                "Server=127.0.0.1;Port=3306;" +
                "Database=Shitfuck;" +
                "Uid=root;Pwd=12345;"
            );
        }

        public void OnGet(string bookmarks)
        {

            doos = HttpContext.Session.GetString("LoginSession");
            User stront = new Repository().Get(doos);
            if (new Repository().LogInUser(stront))
            {
                Repository uname = new Repository();
                User user = uname.GetUserByUserID(doos);

                HttpContext.Session.SetString("LoginSesion", user.Username.ToString());
            }
            string buttonpoep = HttpContext.Session.GetString("LoginSession");
            aars = buttonpoep;
        }

        public User Bookmarkp(string username, string bookmark)
        {
            using var connection = Connect();
            User result = connection.QuerySingleOrDefault<User>(@"
                UPDATE user SET bookmark = @Bookmark WHERE username= @Username", new { Username = username, Bookmark = bookmark }
            );

            return result;
        }

        public IActionResult OnPostBoekjes()
        {
            
            
            string username = HttpContext.Session.GetString("LoginSession");
            
            
            
                new Kloot().Bookmarkp(username, nameof(Kloot));
                return RedirectToPage("Kloot");
                //do something useful with addedTodo
            
            

            
        }

        public void OnPostVerifyUser()
        {
            doos = HttpContext.Session.GetString("LoginSession");
            User stront = new Repository().Get(doos);
            if (new Repository().LogInUser(stront))
            {
                Repository uname = new Repository();
                User user = uname.GetUserByUserID(doos);

                HttpContext.Session.SetString("LoginSesion", user.Username.ToString());
            }
        }

       

        //private iactionresult bookmarkg(string bookmark)
        //{
        //    apen.username = bookmark;
        //    var boekmark = new kloot().bookmarkp(bookmark);
        //    return page();
            
        //}
    }
}
