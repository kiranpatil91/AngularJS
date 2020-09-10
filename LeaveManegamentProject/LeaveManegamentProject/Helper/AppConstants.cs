using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace LeaveManegamentProject.Helper
{
    public class AppConstants
    {
        public static string TempDir
        {
            get
            {
                var outputfile = AppDomain.CurrentDomain.BaseDirectory + "Temp\\";
                if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["TEMP_DIR"]))
                {
                    outputfile = ConfigurationManager.AppSettings["TEMP_DIR"];
                }
                return outputfile;
            }
        }
    }
}