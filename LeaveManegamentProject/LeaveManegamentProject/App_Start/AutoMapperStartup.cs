
using AutoMapper;
using LeaveManegamentProject.Entities;
using LeaveManegamentProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace LeaveManegamentProject.App_Start
{
    public class AutoMapperStartup
    {


       
        public static void Map()
        {


            Mapper.CreateMap<Admin, AdminView>();
            Mapper.CreateMap<AdminView, Admin>();

            Mapper.CreateMap<Leave, LeaveView>();
            Mapper.CreateMap<LeaveView, Leave>();

            Mapper.CreateMap<Login, LoginView>();
            Mapper.CreateMap<LoginView, Login>();

            Mapper.CreateMap<Absencename, AbsencenameView>();
            Mapper.CreateMap<AbsencenameView, Absencename>();



           




        }
    }
}