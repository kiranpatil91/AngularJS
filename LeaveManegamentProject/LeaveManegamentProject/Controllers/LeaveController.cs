using LeaveManegamentProject.DbContexts;
using LeaveManegamentProject.Entities;
using LeaveManegamentProject.Helper;
using LeaveManegamentProject.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace LeaveManegamentProject.Controllers
{
    public class LeaveController : Controller
    {
        LeaveContext context = new LeaveContext();
        Response response = new Response();

        [HttpGet]
        public string Index()
        {

            
            var leavelist = context.Leaves.ToList();
            return JsonConvert.SerializeObject(AutoMapper.Mapper.Map<LeaveView[]>(leavelist));

        }
        string ManagerEmail = string.Empty;
        string Email = string.Empty;
        [HttpPost]
        public string emailsend(Emailclass ec)
        {
            var adminlist = context.Admins.ToList();
            foreach (var admin in adminlist){
                if (ec.ProjectName == admin.ProjectName)
                {
                    if (admin.Designation == "Manager")
                    {
                        ManagerEmail = admin.Email;
                    }
                    if(admin.Role=="Team Lead")
                    {
                        Console.WriteLine(admin.Email);
                       // Email= admin.Email;
                    }
                }

            }
            string To = ManagerEmail;
            string Cc = ec.From;
            string body = ec.Body;
            string subject = ec.Subject;
            string from = ec.From;
            string Password = ec.Password;


            MailMessage mm = new MailMessage();
            mm.From = new MailAddress(from);
          
            mm.Subject = subject;
            mm.Body = body;
           // mm.Cc = CC;


            mm.To.Add(To);
            mm.To.Add(Cc);
            mm.IsBodyHtml = false;

            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Port = 587;
            smtp.UseDefaultCredentials = true;
            smtp.EnableSsl = true;
            smtp.Credentials = new System.Net.NetworkCredential(ec.From, ec.Password);
            smtp.Send(mm);
            return "The Mail Has Been Sent To" + To.ToString();
        }

        [HttpPost]
        public string Save(LeaveView leaveview)
        {
            var Leave = AutoMapper.Mapper.Map<Leave>(leaveview);

            if (string.IsNullOrEmpty(leaveview.AbsenceType))
            {
                response.Message = "please Provide Absence Name";
                response.IsSuccess = false;
                return JsonConvert.SerializeObject(response);
            }
            if ((leaveview.Days) == 0)
            {
                response.Message = "Calculate Dates";
                response.IsSuccess = false;
                return JsonConvert.SerializeObject(response);
            }



            context.Leaves.Add(Leave);
            context.SaveChanges();
            response.Message = "Record Save sucessfully!";
            response.IsSuccess = true;

            return JsonConvert.SerializeObject(response);
        }





        [HttpGet]
        public string Delete(Int64 id)
        {
            var leave = context.Leaves.Find(id);

            if (leave != null)
            {
                context.Leaves.Remove(leave);
                context.SaveChanges();
                response.IsSuccess = true;
                response.Message = "Record deleted successfully!";
            }

            return JsonConvert.SerializeObject(response);
        }


        [HttpGet]

        public string accept(Int64 id)
        {
            var leave = context.Leaves.Find(id);
            

            if (leave != null )
            {
                leave.Action = "Accept";
                leave.CurrentBalance = leave.CurrentBalance - leave.Days;
                //if (leave.CurrentBalance == 0)
                //{
                //    leave.CurrentBalance = 25 - leave.Days;
                //}
                //else
                //{
                //    leave.CurrentBalance = leave.CurrentBalance - leave.Days;
                //}


                context.Entry(leave).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                response.IsSuccess = true;
                response.Data = leave;
                response.Message = "Record Accept successfully!";
            }

            return JsonConvert.SerializeObject(response);
        }
        [HttpGet]
        public string reject(Int64 id)
        {
            var leave = context.Leaves.Find(id);

            if (leave != null)
            {
                leave.Action = "Reject";

                context.Entry(leave).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                response.IsSuccess = true;
                response.Message = "Record Accept successfully!";
            }

            return JsonConvert.SerializeObject(response);
        }
        [HttpPost]
        public string Reject(Int64 Id)
        {
            var leave = context.Leaves.Find(Email);
            return JsonConvert.SerializeObject(AutoMapper.Mapper.Map<LeaveView>(leave));
        }
        
      
    }
}