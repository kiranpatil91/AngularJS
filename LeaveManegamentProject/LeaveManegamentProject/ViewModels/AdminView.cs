using LeaveManegamentProject.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LeaveManegamentProject.ViewModels
{
    public class AdminView
    {
        
        public Int64 Id { get; set; }
        
        public Int64 UserId { get; set; }

        public string Fname { get; set; }
        public string Lname { get; set; }
        [Key]
        public string Email { get; set; }
        public string Password { get; set; }
        public string Designation { get; set; }
        public string ProjectName { get; set; }
        public string Gender { get; set; }
        public string Role { get; set; }
        public Int64 AlocatedLeaves { get; set; }
        public Int64 CurrentBalance { get; set; }
             
     
    }
}