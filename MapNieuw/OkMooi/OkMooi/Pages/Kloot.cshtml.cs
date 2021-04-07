using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OkMooi.Pages
{
    public class Kloot : PageModel
    {

        [BindProperty] public string aars { get; set; }
        
        public void OnGet()
        {
            string buttonpoep = HttpContext.Session.GetString("LoginSession");
            aars = buttonpoep;
        }

        
    }
}
