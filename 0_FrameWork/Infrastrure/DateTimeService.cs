using System;
using System.Globalization;

namespace _01_Framework.Infrastrure
{
    public static class DateTimeService
    {
        public static string ToShamsi(this DateTime date)
        {
            PersianCalendar persian = new PersianCalendar();

            return string.Format("{0}/{1}/{2}",persian.GetYear(date),
                persian.GetMonth(date),persian.GetDayOfMonth(date));
        }
    }
}
