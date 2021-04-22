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
        [BindProperty] public string doos { get; set; }

        //makes button
        public void OnGet(string bookmarks)
        {

            doos = HttpContext.Session.GetString("LoginSession");
            User stront = new Repository().Get(doos);
            if (new Repository().LogInUser(stront))
            {
                Repository uname = new Repository();
                User user = uname.GetUserByUserID(doos);

                
            }
            string buttonpoep = HttpContext.Session.GetString("LoginSession");
            aars = buttonpoep;
        }

        
        //sends data to repository on button click
        public IActionResult OnPostBoekjes()
        {
            
            
            string username = HttpContext.Session.GetString("LoginSession");
            new Repository().Bookmarkp(username, nameof(Kloot));
            return RedirectToPage("Kloot");


        }

        public IActionResult OnPostVolgende()
        {
            return RedirectToPage("Comments");
        }

        //verifies user
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

       

        
    }
}
