using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;


namespace Forxap.Framework.Extensions
{
    public static class DateTimeExtensions
    {

        public static int DifferenceDays(this DateTime dateFrom, DateTime dateTo)
        {
            // Difference in days, hours, and minutes.
            TimeSpan ts = dateTo - dateFrom;

            // Difference in days.
            return   ts.Days;
        }
        public static int Subtract(DateTime date1,DateTime date2 )
        {
            int ret = 0;

            ret = ((date2.Date - date1).Days) + 1;

            return ret;
        }

        //int numerodias = (DateTime.Now - fechaNacimiento).Days;


        public static DateTime StartOfWeek(this DateTime date, DayOfWeek startOfWeek, string languageCode)
        {
            DayOfWeek firstDayOfWeek = new CultureInfo(languageCode).DateTimeFormat.FirstDayOfWeek;
            return date.AddDays((double)-(DateTime.Today.DayOfWeek - firstDayOfWeek));
        }

        public static DateTime GetFirstDayOfWeek(this DateTime date, int weekOffset, string languageCode)
        {
            return StartOfWeek(date, GetFirstDayOfWeekSetting(date, languageCode), languageCode).AddDays((double)(weekOffset * 7));
        }

        public static DayOfWeek GetFirstDayOfWeekSetting(this DateTime date, string languageCode)
        {
            return new CultureInfo(languageCode).DateTimeFormat.FirstDayOfWeek;
        }

        public static int GetFirstDayOfWeekSettingForSql(this DateTime date, string languageCode)
        {
            DayOfWeek dayOfWeekSetting = GetFirstDayOfWeekSetting(date, languageCode);
            if (dayOfWeekSetting == DayOfWeek.Sunday)
                return 7;
            else
                return (int)dayOfWeekSetting;
        }

        public static DateTime FirstDayOfMonth(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1);
        }


        public static DateTime LastDayOfMonth(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));
        }


        public static bool IsWeekend(this DateTime date)
        {
            if (date.DayOfWeek != DayOfWeek.Sunday)
                return date.DayOfWeek == DayOfWeek.Saturday;
            else
                return true;
        }

        public static bool IsWeekend(this DayOfWeek date)
        {
            return !IsWeekday(date);
        }


        public static bool IsWeekday(this DayOfWeek date)
        {
            switch (date)
            {
                case DayOfWeek.Sunday:
                case DayOfWeek.Saturday:
                    return false;
                default:
                    return true;
            }
        }


        public static DateTime AddWorkdays(this DateTime date, int days)
        {
            while (IsWeekday(date.DayOfWeek))
                date = date.AddDays(1.0);
            for (int index = 0; index < days; ++index)
            {
                date = date.AddDays(1.0);
                while (IsWeekday(date.DayOfWeek))
                    date = date.AddDays(1.0);
            }
            return date;
        }


        public static DateTime AddWeekdays(this DateTime date, int days)
        {
            int num1 = days < 0 ? -1 : 1;
            int num2 = System.Math.Abs(days);
            int num3 = 0;
            while (num3 < num2)
            {
                date = date.AddDays((double)num1);
                if (date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday)
                    ++num3;
            }
            return date;
        }


        public static DateTime SetTime(this DateTime date, int hour)
        {
            return SetTime(date, hour, 0, 0, 0);
        }

        public static DateTime SetTime(this DateTime date, int hour, int minute)
        {
            return SetTime(date, hour, minute, 0, 0);
        }

        public static DateTime SetTime(this DateTime date, int hour, int minute, int second)
        {
            return SetTime(date, hour, minute, second, 0);
        }

        public static DateTime SetTime(this DateTime date, int hour, int minute, int second, int millisecond)
        {
            return new DateTime(date.Year, date.Month, date.Day, hour, minute, second, millisecond);
        }

        public static DateTime ClearTime(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 0, 0, 0, 0);
        }

        public static string ToRelativeDateString(this DateTime date)
        {
            return GetRelativeDateValue(date, DateTime.Now);
        }

        public static string ToRelativeDateStringUtc(this DateTime date)
        {
            return GetRelativeDateValue(date, DateTime.UtcNow);
        }

        private static string GetRelativeDateValue(DateTime date, DateTime comparedTo)
        {
            TimeSpan timeSpan = comparedTo.Subtract(date);
            if (timeSpan.TotalDays >= 365.0)
                return "en " + date.ToString("MMMM d, yyyy");
            if (timeSpan.TotalDays >= 7.0)
                return "en " + date.ToString("MMMM d");
            if (timeSpan.TotalDays > 1.0)
                return string.Format("{0:N0} días atras", (object)timeSpan.TotalDays);
            if (timeSpan.TotalDays == 1.0)
                return "ayer";
            if (timeSpan.TotalHours >= 2.0)
                return string.Format("{0:N0} horas atras", (object)timeSpan.TotalHours);
            if (timeSpan.TotalMinutes >= 60.0)
                return "hace más de una hora";
            if (timeSpan.TotalMinutes >= 5.0)
                return string.Format("{0:N0} minutos atras", (object)timeSpan.TotalMinutes);
            return timeSpan.TotalMinutes >= 1.0 ? "hace pocos minutos" : "hace menos de un minuto";
        }

        public static string GetString(this DateTime date)
        {
            if (date.Year == 1)
                return string.Empty;
            else
                return date.ToString();
        }

        public static string GetString(this DateTime? date)
        {
            if (!date.HasValue)
                return string.Empty;
            else
                return GetString(date.Value);
        }

        public static string GetDateString(this DateTime date)
        {
            if (date.Year == 1)
                return string.Empty;
            else
                return date.ToShortDateString();
        }

        public static string GetDateString(this DateTime? date)
        {
            if (!date.HasValue)
                return string.Empty;
            else
                return GetDateString(date.Value);
        }

        public static DateTime ConvertStrToDate(this string dateString, string format)
        {
            try
            {
                DateTime oDate = default(DateTime);
                System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("es-mx", false);
                System.Globalization.CultureInfo newCi = (System.Globalization.CultureInfo)ci.Clone();

                System.Threading.Thread.CurrentThread.CurrentCulture = newCi;
                oDate = System.DateTime.ParseExact(dateString, format, ci.DateTimeFormat);

                return oDate;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }// fin de la clase
    
}// fin del namespace
