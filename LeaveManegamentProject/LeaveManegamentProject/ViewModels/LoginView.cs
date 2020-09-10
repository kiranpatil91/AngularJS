using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LeaveManegamentProject.ViewModels
{
    public class LoginView
    {
        [Key]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}