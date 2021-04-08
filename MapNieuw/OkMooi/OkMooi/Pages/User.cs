using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OkMooi.Pages
{
    public class User
    {
        [Required(), MinLength(2), MaxLength(50)]
        
        public string Username { get; set; }

        [Required(), MinLength(2), MaxLength(50)]
        
        public string Password { get; set; }
        
        public string Admin { get; set; }

        public string Bookmark { get; set; }
    }
}
