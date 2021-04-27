
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;



namespace OkMooi.Pages
{
    public class IndexModel : PageModel
    {

        
        
            

        [BindProperty] 
        public User NewUser { get; set; } 
        
        public void OnGet()
        {

        }

        //handler for creating new users when register button is clicked
        public IActionResult OnPostCreate()
        {
            if (ModelState.IsValid)
            {
                var addedUser = new Repository().AddUser(NewUser);
                //do something useful with addedTodo
            }

            return Page();
        }

        //if user clicks on loginbutton checks if its correct and checks with database
        public IActionResult OnPostProcessLogin()
        {
            
            
                var loggedinUser = new Repository().LogInUser(NewUser);
                if(loggedinUser)
                {
                    
                    HttpContext.Session.SetString("LoginSession", NewUser.Username);
                    return RedirectToPage("Kloot");
                }
                else
                {
                    ModelState.AddModelError("LoginError", "Error, debiel");
                }
            

            return Page();
        }

        //verifies user and gives it a sessionhandler
        public void OnPostVerifyUser()
        {
            if (new Repository().LogInUser(NewUser))
            {
                Repository uname = new Repository();
                User user = uname.GetUserByUserID(NewUser.Username);
                
                HttpContext.Session.SetString("LoginSesion", user.Username.ToString());
            }
        }














    }
}