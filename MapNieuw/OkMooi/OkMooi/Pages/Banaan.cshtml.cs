using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;

namespace OkMooi.Pages
{
    public class BanaanModel : PageModel
    {
        [BindProperty] public User NewUser { get; set; } = new User();
        public string CooleNaam;

        //Gets loginsession to use it elsewhere easier
        public void OnGet()
        {
            CooleNaam = HttpContext.Session.GetString("LoginSession");
        }

        //Gets all comments
        public IEnumerable<User> Users
        {

            get { return new Repository().GetComments(); }
        }

        //Gets loginsession (username) and sends it to repository same with filled in data
        public void OnPostComment()
        {
            string YoNaam = HttpContext.Session.GetString("LoginSession");
            NewUser.Username = YoNaam;
            new Repository().NewComment(NewUser);
            Response.Redirect("Banaan");
        }
    }
}
