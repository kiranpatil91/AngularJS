using LeaveManegamentProject.DbContexts;
using LeaveManegamentProject.Entities;
using LeaveManegamentProject.Helper;
using LeaveManegamentProject.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeaveManegamentProject.Controllers
{
    public class AbsencenameController : Controller
    {
        LeaveContext context = new LeaveContext();
        Response response = new Response();

        [HttpGet]
        public string Index()
        {
            var Absencenamelist = context.Absencenames.ToList();
            return JsonConvert.SerializeObject(AutoMapper.Mapper.Map<AbsencenameView[]>(Absencenamelist));
        }

        
        [HttpPost]
        public string Save(AbsencenameView absencenameview)
        {
            var absencename = AutoMapper.Mapper.Map<Absencename>(absencenameview);
            if (string.IsNullOrEmpty(absencenameview.AbsenceType))
            {
                response.Message = "Please provide type name";
                response.IsSuccess = false;
                return JsonConvert.SerializeObject(response);
            }
            
            
            context.Absencenames.Add(absencename);
            context.SaveChanges();
            response.Message = "Record Save sucessfully!";
            response.IsSuccess = true;

            return JsonConvert.SerializeObject(response);
        }

        [HttpPost]
        public string Edit(Int64 Id)
        {
            var Absencename = context.Absencenames.Find(Id);
            return JsonConvert.SerializeObject(AutoMapper.Mapper.Map<AbsencenameView>(Absencename));
        }

        [HttpPost]
        public string Update(AbsencenameView absencenameview)
        {
            if (string.IsNullOrEmpty(absencenameview.AbsenceType))
            {
                response.Message = "Please provide TYpe name";
                response.IsSuccess = false;
                return JsonConvert.SerializeObject(response);
            }
            



            var absencename = AutoMapper.Mapper.Map<Absencename>(absencenameview);
            context.Entry(absencename).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            response.IsSuccess = true;
            response.Message = "Record updated succesfully";

            return JsonConvert.SerializeObject(response);
        }


        [HttpGet]
        public string Delete(Int64 Id)
        {
            var absencename = context.Absencenames.Find(Id);

            if (absencename != null)
            {
                context.Absencenames.Remove(absencename);
                context.SaveChanges();
                response.IsSuccess = true;
                response.Message = "Record deleted successfully!";
            }

            return JsonConvert.SerializeObject(response);
        }
    }
}