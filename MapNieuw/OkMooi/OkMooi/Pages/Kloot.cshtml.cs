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
        [BindProperty] public User apen { get; set; }
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
                                
        public User Bookmarkp(User user)
        {
            using var connection = Connect();
            User bookmark = connection.QuerySingleOrDefault<User>(@"
                UPDATE user SET bookmark = 'Molshoop' WHERE username= @Username", user
            );

            return bookmark;
        }

        public IActionResult OnPostBoekjes()
        {
            if (!ModelState.IsValid)
            {
                new Kloot().Bookmarkp(Bookmark);
                return RedirectToPage("Kloot");
                //do something useful with addedTodo
            }
            

            return Page();
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

        public IActionResult OnPostBookmark()
        {
            apen.Username = bookmark;
            var boekmark = new Kloot().Bookmarkp(apen);
            if (ModelState.IsValid)
            {
                
                
                new Kloot().Bookmarkg(bookmark);              
            }

            return Page();
        }

        private IActionResult Bookmarkg(string bookmark)
        {
            apen.Username = bookmark;
            var boekmark = new Kloot().Bookmarkp(apen);
            return Page();
            
        }
    }
}
