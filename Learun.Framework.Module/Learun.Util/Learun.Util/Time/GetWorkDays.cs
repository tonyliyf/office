using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learun.Util
{
    /// <summary>
    /// 取工作日
    /// </summary>
    public class GetWorkDays
    {
        /// <summary>
        /// 根据时间差，获取工作日天数（除去了周六周日）
        /// </summary>
        /// <param name="StartTime"></param>
        /// <param name="EndTime"></param>
        /// <returns></returns>
        public int GetWorkDay(DateTime StartTime, DateTime EndTime)
        {
            DateTime start = StartTime;
            DateTime end = EndTime;
            TimeSpan span = end - start;
            //int totleDay=span.Days;
            //DateTime spanNu = DateTime.Now.Subtract(span);
            int AllDays = Convert.ToInt32(span.TotalDays) + 1;//差距的所有天数
            int totleWeek = AllDays / 7;//差别多少周
            int yuDay = AllDays % 7; //除了整个星期的天数
            int lastDay = 0;
            if (yuDay == 0) //正好整个周
            {
                lastDay = AllDays - (totleWeek * 2);
            }
            else
            {
                int weekDay = 0;
                int endWeekDay = 0; //多余的天数有几天是周六或者周日
                switch (start.DayOfWeek)
                {
                    case DayOfWeek.Monday:
                        weekDay = 1;
                        break;
                    case DayOfWeek.Tuesday:
                        weekDay = 2;
                        break;
                    case DayOfWeek.Wednesday:
                        weekDay = 3;
                        break;
                    case DayOfWeek.Thursday:
                        weekDay = 4;
                        break;
                    case DayOfWeek.Friday:
                        weekDay = 5;
                        break;
                    case DayOfWeek.Saturday:
                        weekDay = 6;
                        break;
                    case DayOfWeek.Sunday:
                        weekDay = 7;
                        break;
                }
                if ((weekDay == 6 && yuDay >= 2) || (weekDay == 7 && yuDay >= 1) || (weekDay == 5 && yuDay >= 3) || (weekDay == 4 && yuDay >= 4) || (weekDay == 3 && yuDay >= 5) || (weekDay == 2 && yuDay >= 6) || (weekDay == 1 && yuDay >= 7))
                {
                    endWeekDay = 2;
                }
                if ((weekDay == 6 && yuDay < 1) || (weekDay == 7 && yuDay < 5) || (weekDay == 5 && yuDay < 2) || (weekDay == 4 && yuDay < 3) || (weekDay == 3 && yuDay < 4) || (weekDay == 2 && yuDay < 5) || (weekDay == 1 && yuDay < 6))
                {
                    endWeekDay = 1;
                }
                lastDay = AllDays - (totleWeek * 2) - endWeekDay;
            }
            return lastDay;
        }



        /// <summary>
        /// 获取工作日天数(无节假日)
        /// </summary>
        /// <param name="StartTime"></param>
        /// <param name="EndTime"></param>
        /// <returns></returns>
        public int GetNoHolidayWorkDay(DateTime StartTime, DateTime EndTime)
        {
            TimeSpan t = EndTime - StartTime;
            var tatalDay = Convert.ToInt32(t.TotalDays);

            return tatalDay;
        }

        /// <summary>
        /// 获取一个时间段中（周一有几天,周二有几天,周三有几天。。。。到周日）（从而获取工作日天数）
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="workDay">从数据库中取得的设置的工作日时间（如：周一，周三，周五，周日）</param>
        /// <returns></returns>
        public int GetDate(DateTime startDate, DateTime endDate, string[] workDay)          //这里的workDay数组是我从数据库中取得的字符串（原始格式类似："周一,周三，周六..."），通过split分割而成的。以便进行操作
        {
            int mondayCount = 0, tuesdayCount = 0, wednesdayCount = 0, thursdayCount = 0, fridayCount = 0, satursdayCount = 0, sundayCount = 0;//每个星期日(星期一,星期二...)的总天数

            int LastDay = 0;
            DateTime startDT = startDate; //开始时间
            DateTime endDT = endDate; //结束时间
            TimeSpan dt = endDT - startDT;
            int dayCount = Convert.ToInt32(dt.TotalDays);  //总天数    (后一个日期在中午12点之前，这天不算，超过12点，加上这一天)
            for (int i = 0; i < dayCount; i++)
            {
                switch (startDT.AddDays(i).DayOfWeek)
                {
                    case DayOfWeek.Monday:
                        mondayCount += 1;
                        break;
                    case DayOfWeek.Tuesday:
                        tuesdayCount += 1;
                        break;
                    case DayOfWeek.Wednesday:
                        wednesdayCount += 1;
                        break;
                    case DayOfWeek.Thursday:
                        thursdayCount += 1;
                        break;
                    case DayOfWeek.Friday:
                        fridayCount += 1;
                        break;
                    case DayOfWeek.Saturday:
                        satursdayCount += 1;
                        break;
                    case DayOfWeek.Sunday:
                        sundayCount += 1;
                        break;
                }
            }

            foreach (var item in workDay)
            {
                switch (item)
                {
                    case "周一":
                        LastDay += mondayCount;
                        break;
                    case "周二":
                        LastDay += tuesdayCount;
                        break;
                    case "周三":
                        LastDay += wednesdayCount;
                        break;
                    case "周四":
                        LastDay += thursdayCount;
                        break;
                    case "周五":
                        LastDay += fridayCount;
                        break;
                    case "周六":
                        LastDay += satursdayCount;
                        break;
                    case "周日":
                        LastDay += sundayCount;
                        break;
                }
            }
            //int lastDays = mondayCount + tuesdayCount + wednesdayCount + thursdayCount + fridayCount + satursdayCount + sundayCount;
            return LastDay;
        }
    }
}