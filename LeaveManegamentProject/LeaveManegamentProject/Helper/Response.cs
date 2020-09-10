using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeaveManegamentProject.Helper
{
    public class Response
    {

        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public string GetReponse()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}