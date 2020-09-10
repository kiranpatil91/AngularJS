using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace LeaveManegamentProject.Helper
{
    public class DateTimeHelper
    {
        private static string timezone = "India Standard Time";
        private static string format = "MM/dd/yyyy";
        private static CultureInfo provider = CultureInfo.InvariantCulture;

        public static DateTime ConvertToDateTime(string datestring)
        {
            return DateTime.ParseExact(datestring, format, provider).Date;
        }
        public static DateTime ConvertToDate(string datestring)
        {
            return DateTime.ParseExact(datestring, format, provider).Date;
        }

        public static DateTime ParseDateTime(string date)
        {
            return
                DateTime.ParseExact(date, date.Length == 10 ? "MM/dd/yyyy" : "MM/dd/yy", CultureInfo.InvariantCulture)
                    .Date;
        }



        public static DateTime LocalDateTime
        {
            get
            {
                return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById(timezone));
            }
        }

        public static DateTime LocalDate
        {
            get
            {
                return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById(timezone)).Date;
            }
        }

        public static string LocalDateTimeString
        {
            get
            {
                return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById(timezone)).ToShortDateString().Replace("/", "_");
            }
        }
    }
}