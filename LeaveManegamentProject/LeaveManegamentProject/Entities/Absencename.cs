using LeaveManegamentProject.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LeaveManegamentProject.Entities
{
    public class Absencename
    {
        [Key]
        public Int64 Id { get; set; }
        public string AbsenceType { get; set; }
        
     



    }
}