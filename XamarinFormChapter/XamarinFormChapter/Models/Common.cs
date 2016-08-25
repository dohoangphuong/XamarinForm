using System;

namespace XamarinFormChapter.Models
{
    public class CommonDate
    {
        public static DateTime GetFirstOfMonth()
        {
            DateTime date = DateTime.Now;
            var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            return firstDayOfMonth;
        }
    }
}