using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learun.Util
{
    public class HolidayInit
    {

        public  static  List<HolidayInfo>  InitHoliday(int startyear,int endyear)
        {

            List<HolidayInfo> list = new List<HolidayInfo>();
            HolidayInfo info = new HolidayInfo();

            DateTime dtstart = new DateTime(startyear, 1, 1);
            DateTime dtEnd = new DateTime(endyear + 1, 1, 1);

            while(dtstart<dtEnd)
            {
                info.DC_OA_Date = dtstart;
                info.DC_OA_Remarks = "工作日";
                info.DC_OA_Week = dtstart.DayOfWeek.ToString();
                info.DC_OA_IsWork = 0;
                if (dtstart.DayOfWeek==DayOfWeek.Sunday||dtstart.DayOfWeek==DayOfWeek.Saturday)
                {
                    info.DC_OA_Remarks = "周未";
                    info.DC_OA_IsWork = 1;
                }
                if(dtstart.Day ==1)
                {
                    if(dtstart.Month==1)
                    {
                        info.DC_OA_Remarks = "元旦";
                        info.DC_OA_IsWork = 2;
                    }
                    if (dtstart.Month == 5)
                    {
                        info.DC_OA_Remarks = "劳动节";
                        info.DC_OA_IsWork = 2;
                    }

                    if (dtstart.Month == 10)
                    {
                        info.DC_OA_Remarks = "国庆节";
                        info.DC_OA_IsWork = 2;
                    }
                

                }

                list.Add(info);
                info = new HolidayInfo();
                dtstart= dtstart.AddDays(1);


            }
            return list;

        }



       
    }

    public class HolidayInfo
    {
        public DateTime DC_OA_Date { get; set; }
      
        public string DC_OA_Week { get; set; }
     
        public string DC_OA_Remarks { get; set; }

         public int DC_OA_IsWork { get; set; }

    }
}
