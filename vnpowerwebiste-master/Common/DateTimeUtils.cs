using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class DateTimeUtils
    {
        public static List<DayInWeek> GetDayWeek()
        {
            var beginDay = DateTime.Now;
            var list = new List<DayInWeek>();
            for(int i = 1; i<=7; i++)
            {
                var day = new DayInWeek()
                {
                    DayOfWeek = beginDay.DayOfWeek.GetHashCode(),
                    DayName = GetNameDay(beginDay.DayOfWeek),
                    Day = beginDay,
                    DayFormat = beginDay.ToString("dd/MM")
                };
                list.Add(day);
                beginDay = beginDay.AddDays(1);
            }

            return list;
        }

        public static List<DayInWeek> GetWholeDayOfWeek()
        {
          
            var list = new List<DayInWeek>();
            for (int i = 0; i <= 6; i++)
            {
                var day = new DayInWeek()
                {
                    DayOfWeek = i,
                    DayName = GetNameDay((DayOfWeek)i),
                    //Day = beginDay,
                    DayFormat = $"day_{i}"
                };
                list.Add(day);
            }

            return list;
        }
        public static bool IsWeekend()
        {
            var dayOfWeek = DateTime.Now.DayOfWeek;
            if (dayOfWeek == DayOfWeek.Saturday || dayOfWeek == DayOfWeek.Sunday)
            {
                return true;
            }
            return false;
        }
        private static string GetNameDay(DayOfWeek dayOfWeek)
        {
            string name = string.Empty;
            switch(dayOfWeek)
            {
                case DayOfWeek.Monday:
                    name = "Thứ hai";
                    break;
                case DayOfWeek.Tuesday:
                    name = "Thứ ba";
                    break;
                case DayOfWeek.Wednesday:
                    name = "Thứ tư";
                    break;
                case DayOfWeek.Thursday:
                    name = "Thứ năm";
                    break;
                case DayOfWeek.Friday:
                    name = "Thứ sáu";
                    break;
                case DayOfWeek.Saturday:
                    name = "Thứ bảy";
                    break;
                case DayOfWeek.Sunday:
                    name = "Chủ nhật";
                    break;
                default:
                    // code block
                    break;
                   
            }
            return name;

        }
    }
    public class DayInWeek
    {
        public int DayOfWeek { get; set; }
        public string DayName { get; set; }
        public DateTime Day { get; set; }
        public string DayFormat { get; set; }
        public List<HourInDay> Times { get; set; } = new List<HourInDay>();
    }
    public class HourInDay
    {
        public int Value { get; set; }
        public string Name { get; set; }
        public int OrderDisplay { get; set; }
        public bool IsActive { get; set; }
    }

}
