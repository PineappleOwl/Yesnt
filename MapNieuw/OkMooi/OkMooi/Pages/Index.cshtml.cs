using System;
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

        public void OnPost()
        {

        }

        
        public IEnumerable<User> Users
        {
            get { return new Repository().Get(); }
        }
        public IActionResult OnPostCreate()
        {
            if (ModelState.IsValid)
            {
                var addedTodo = new Repository().AddUser(NewUser);
                //do something useful with addedTodo
            }

            return Page();
        }


    }
}