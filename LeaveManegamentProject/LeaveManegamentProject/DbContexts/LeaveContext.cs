using LeaveManegamentProject.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LeaveManegamentProject.DbContexts
{
    public class LeaveContext : DbContext
    {

        public LeaveContext() : base("LM") { }


        public DbSet<Admin> Admins { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<Leave> Leaves { get; set; }
       public DbSet<Absencename> Absencenames { get; set; }
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    // Configure StudentId as FK for StudentAddress
        //    modelBuilder.Entity<Leave>()
        //                .HasRequired(s => s.AbsenceType)
        //                .WithRequiredPrincipal(ad => ad.Leave);

        //}
    }

}
