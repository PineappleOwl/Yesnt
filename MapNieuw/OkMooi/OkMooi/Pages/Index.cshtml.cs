
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OkMooi.Pages;



namespace OkMooi.Pages
{
    public class IndexModel : PageModel
    {

        

        [BindProperty] 
        public User NewUser { get; set; } 
        
        public void OnGet()
        {

        }

        public IActionResult OnPostCreate()
        {
            if (ModelState.IsValid)
            {
                var addedUser = new Repository().AddUser(NewUser);
                //do something useful with addedTodo
            }

            return Page();
        }




        public IEnumerable<User> Users
        {
            get { return new Repository().Get(); }
        }



        
        public IActionResult OnPostProcessLogin()
        {
            if(ModelState.IsValid)
            {
                var loggedinUser = new Repository().LogInUser(NewUser);
                if(loggedinUser)
                {
                    return RedirectToPage("Kloot");
                }
                else
                {
                    ModelState.AddModelError("LoginError", "Error, debiel");
                }
            }

            return Page();
        }

        
        









    }
}