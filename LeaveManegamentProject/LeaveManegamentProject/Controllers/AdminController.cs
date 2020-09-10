using LeaveManegamentProject.DbContexts;
using LeaveManegamentProject.Helper;
using LeaveManegamentProject.ViewModels;
using LeaveManegamentProject.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeaveManegamentProject.Controllers
{
    public class AdminController : Controller
    {
        LeaveContext context = new LeaveContext();
        Response response = new Response();

        [HttpGet]
        public string Index()
        {
            var adminlist = context.Admins.ToList();
            return JsonConvert.SerializeObject(AutoMapper.Mapper.Map<AdminView[]>(adminlist));
        }

        [HttpPost]
        public string Login(string Email, string Password)
        {
            var admin = context.Admins.Find(Email);

            if (string.IsNullOrEmpty(Email))
            {
                response.Message = "Please Provide Email Id";
                response.IsSuccess = false;
                return JsonConvert.SerializeObject(response);
            }
            if (string.IsNullOrEmpty(Password))
            {
                response.Message = "Please Provide Password Id";
                response.IsSuccess = false;
                return JsonConvert.SerializeObject(response);
            }
            if (context.Admins.Any(c => c.Email == Email) && admin.Password == Password)
            {
                response.Message = "Login Successfully";
                response.IsSuccess = true;
                response.Data = admin;
                return JsonConvert.SerializeObject(response);
            }

            response.Message = "check Your Email & Password";
            response.IsSuccess = false;
            return JsonConvert.SerializeObject(response);
        }
        [HttpPost]
        public string Save(AdminView adminview)
        {
            AdminView adminview1 = new AdminView();
            adminview.Fname = "Abhi";
            adminview.Lname = "";

            var Admin = AutoMapper.Mapper.Map<Admin>(adminview);
            if (string.IsNullOrEmpty(adminview.Fname))
            {
                response.Message = "Please provide type name";
                response.IsSuccess = false;
                return JsonConvert.SerializeObject(response);
            }
            if (string.IsNullOrEmpty(adminview.Lname))
            {
                response.Message = "Please provide type name";
                response.IsSuccess = false;
                return JsonConvert.SerializeObject(response);
            }
            if (string.IsNullOrEmpty(adminview.Email))
            {
                response.Message = "Please provide type name";
                response.IsSuccess = false;
                return JsonConvert.SerializeObject(response);
            }
            if (string.IsNullOrEmpty(adminview.Designation))
            {
                response.Message = "Please provide type name";
                response.IsSuccess = false;
                return JsonConvert.SerializeObject(response);

            }
            if (string.IsNullOrEmpty(adminview.Gender))
            {
                response.Message = "Please provide type name";
                response.IsSuccess = false;
                return JsonConvert.SerializeObject(response);
            }
            if (context.Admins.Any(c => c.Email == adminview.Email))
            {
                response.Message = "Please Provide Another Email id";
                response.IsSuccess = false;
                return JsonConvert.SerializeObject(response);
            }
            context.Admins.Add(Admin);
            context.SaveChanges();
            response.Message = "Record Save sucessfully!";
            response.IsSuccess = true;

            return JsonConvert.SerializeObject(response);
        }     

        [HttpPost]
        public string Edit(string Email)
        {
            var admin = context.Admins.Find(Email);
            return JsonConvert.SerializeObject(AutoMapper.Mapper.Map<AdminView>(admin));
        }
        [HttpPost]
        public string UpdateLeave(Int64 AlocatedLeaves)
        {
            var adminlist = context.Admins.ToList();
          
            foreach (var admin in adminlist)
            {

                var ab = AlocatedLeaves - admin.AlocatedLeaves;
                admin.CurrentBalance = admin.CurrentBalance+ ab;
                admin.AlocatedLeaves = AlocatedLeaves;
               

                context.Entry(admin).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                response.IsSuccess = true;
                response.Message = "Record updated succesfully";
            }
               return JsonConvert.SerializeObject(response);
        }
        [HttpPost]
        public string Update(AdminView adminview)
        {
            if (string.IsNullOrEmpty(adminview.Fname))
            {
                response.Message = "Please provide TYpe name";
                response.IsSuccess = false;
                return JsonConvert.SerializeObject(response);
            }
            if (string.IsNullOrEmpty(adminview.Lname))
            {
                response.Message = "Please provide TYpe name";
                response.IsSuccess = false;
                return JsonConvert.SerializeObject(response);
            }
            if (string.IsNullOrEmpty(adminview.Email))
            {
                response.Message = "Please provide TYpe name";
                response.IsSuccess = false;
                return JsonConvert.SerializeObject(response);
            }
            if (string.IsNullOrEmpty(adminview.Designation))
            {
                response.Message = "Please provide TYpe name";
                response.IsSuccess = false;
                return JsonConvert.SerializeObject(response);
            }
            var Admin = AutoMapper.Mapper.Map<Admin>(adminview);
            context.Entry(Admin).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            response.IsSuccess = true;
            response.Message = "Record updated succesfully";

            return JsonConvert.SerializeObject(response);
        }
        [HttpPost]
        public string date(Int64 adminview,string Email)
        {

            var admins = context.Admins.Find(Email);
            if (admins != null)
            {
                admins.CurrentBalance= adminview;
                context.Entry(admins).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                response.IsSuccess = true;
                response.Message = "Record updated succesfully";
            }
            return JsonConvert.SerializeObject(response);
        }
        [HttpGet]
        public string Delete(Int64 UserId)
        {
            var admin = context.Admins.Find(UserId);
            if (admin != null)
            {
                context.Admins.Remove(admin);
                context.SaveChanges();
                response.IsSuccess = true;
                response.Message = "Record deleted successfully!";
            }

            return JsonConvert.SerializeObject(response);
        }
    }
}