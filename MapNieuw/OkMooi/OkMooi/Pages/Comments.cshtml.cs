using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;



namespace OkMooi.Pages
{
    public class Comments_page : PageModel
    {





        [BindProperty]
        public Comments NewComment { get; set; }
        public Comments DisplayedComment { get; set; }

        public void OnGet()
        {

        }

        public IActionResult OnPostCreate()
        {
            if (ModelState.IsValid)
            {
                var addedComment = new Repository().AddComment(NewComment);
                var displayedComment = new Repository().displayComment(DisplayedComment);
                
            }

            return Page();
        }



    }
}
