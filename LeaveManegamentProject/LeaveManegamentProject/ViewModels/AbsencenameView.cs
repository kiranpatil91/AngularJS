using LeaveManegamentProject.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LeaveManegamentProject.ViewModels
{
    public class AbsencenameView
    {
        [Key]
        public Int64 Id { get; set; }
        public string AbsenceType { get; set; }

      
    }
}