using LeaveManegamentProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeaveManegamentProject.ViewModels
{
    public class LeaveView
    {

        public Int64 Id { get; set; }
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