using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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

        private IDbConnection Connect()
        {
            return new MySqlConnection(
                "Server=127.0.0.1;Port=3306;" +
                "Database=Shitfuck;" +
                "Uid=root;Pwd=12345;"
            );
        }

        public User Bookmarkp(User user)
        {
            using var connection = Connect();
            User bookmark = connection.QuerySingleOrDefault<User>(@"
                UPDATE user SET bookmark = 'Klotezooi' WHERE username= @Username", user
            );

            return bookmark;
        }



        public void OnGet(string bookmarks)
        {
            
            string buttonpoep = HttpContext.Session.GetString("LoginSession");
            aars = buttonpoep;
        }
                                                                                                                          
        public IActionResult OnPostBookmark()
        {
            apen.Username = bookmark;
            var boekmark = new Kloot().Bookmarkp(apen);
            if (ModelState.IsValid)
            {
                
                
                new Kloot().Bookmark(bookmark);              
            }

            return Page();
        }

        private IActionResult Bookmark(string bookmark)
        {
            apen.Username = bookmark;
            var boekmark = new Kloot().Bookmarkp(apen);
            return Page();
            
        }
    }
}
