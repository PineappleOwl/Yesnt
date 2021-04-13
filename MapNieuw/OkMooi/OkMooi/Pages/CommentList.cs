using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OkMooi.Pages
{
    public class CommentList
    {
            public string username { get; set; }
            public string postedtime { get; set; }
            public string title { get; set; }
            public string commentcontent { get; set; }
    }
}
