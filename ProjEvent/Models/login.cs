using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProjEvent.Models
{
    public class login
    {
        [Required(ErrorMessage ="pls enter user name")]
        public string email { get; set; }
        [Required(ErrorMessage = "pls enter password")]
        public string password { get; set; }
    }
}