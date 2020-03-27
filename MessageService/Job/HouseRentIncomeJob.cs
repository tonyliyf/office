using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using Learun.Application.TwoDevelopment.AssetManager;


namespace MessageService
{
    /// <summary>
    /// 房屋租金到期提醒HouseIncome
    /// </summary>
    /// 
   
    public class HouseRentIncomeJob :JobBase
    {
      
        private DC_ASSETS_HouseRentDetailIBLL iBll = new DC_ASSETS_HouseRentDetailBLL();
        private DC_ASSETS_HouseInfoIBLL iBllhouse = new DC_ASSETS_HouseInfoBLL();
        public log4net.ILog log = log4net.LogManager.GetLogger(typeof(HouseRentIncomeJob));

        //public HouseRentIncomeJob(string code):base(code)
        //{

        //}
        public void Execute()
        {
          //  LoggerFactory.Info("房屋租金到期提醒HouseIncome start");

            this.Init("HouseIncome");
            //  Log4Helper.Info(typeof(HouseRentIncomeJob), "HouseIncome start");
            // log.Info("HouseIncome start");

            log.Info(string.Format("房屋租金到期提醒HouseIncome start--{0} \r\n", DateTime.Now.ToString()));
            // LoggerFactory.Info("OSNotice start");
            var list = iBll.GetHouseRentDetailList();

            foreach (var item in list)
            {
                //租金提醒日期
                if (item.F_RentReminderDate <= DateTime.Now && item.F_ExpireReminderDate > DateTime.Now)
                {
                    DC_ASSETS_HouseInfoEntity houseinfo = iBllhouse.GetDC_ASSETS_HouseInfoEntity(item.F_HouseID);
                    this.Content = string.Format("{0}：{1}{2}租金快到期了,请尽快处理", this.Name, houseinfo.F_BuildingAddress, item.F_HouseName);
                    this.SendMessage("", "");
                  //  Log4Helper.Info(typeof(HouseRentIncomeJob), Content);
                    //LoggerFactory.Info(this.Content);
                    // log.Info(Content);
                }
                //租金到期提醒
                else if (item.F_ExpireReminderDate <= DateTime.Now)
                {
                    DC_ASSETS_HouseInfoEntity houseinfo = iBllhouse.GetDC_ASSETS_HouseInfoEntity(item.F_HouseID);
                    this.Content = string.Format("{0}：{1}{2}租金已到期了,请抓紧处理", this.Name, houseinfo.F_BuildingAddress, item.F_HouseName);
                    this.SendMessage("", "");
                    Log4Helper.Info(typeof(HouseRentIncomeJob), Content);
                    // LoggerFactory.Info(this.Content);
                    // log.Info(Content);
                }

                log.Info(string.Format(this.Content + "-{0}\r\n", DateTime.Now.ToString()));
            }

        }
    }
}
