using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LeaveManegamentProject.Entities
{
    public class Leave
    {


      [Key]
        public Int64  Id { get; set; }
        public Int64 UserId { get; set; }
        
        public string Email { get; set; }

        public DateTime Date1 { get; set; }
        public DateTime Date2 { get; set; }
        public string AbsenceType { get; set; }
        public Int64 CurrentBalance { get; set; }
        public Int64 Days { get; set; }
      

        public string Action { get; set; }
        





    }
}