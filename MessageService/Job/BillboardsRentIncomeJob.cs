using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;

using Learun.Application.TwoDevelopment;
using Learun.Application.TwoDevelopment.AssetManager;
using Learun.Application.Message;
using log4net;

namespace MessageService
{
    /// <summary>
    /// 广告租金到期提醒Advance
    /// </summary>
    
    public class BillboardsRentIncomeJob : JobBase
    {

        private DC_ASSETS_BusStopBillboardsRentDetailIBLL iBLL = new DC_ASSETS_BusStopBillboardsRentDetailBLL();
        private DC_ASSETS_BusStopBillboardsIBLL boardsIBll = new DC_ASSETS_BusStopBillboardsBLL();
        public log4net.ILog log = log4net.LogManager.GetLogger(typeof(HouseRentIncomeJob));

        //public BillboardsRentIncomeJob(string code) : base(code)
        //{

        //}
        public void Execute()
        {

            //Log4Helper.Info(typeof(BillboardsRentIncomeJob), "Advance start");
            this.Init("Advance");
            var list = iBLL.GetBusStopBillboardsRentList();
            log.Info(string .Format("广告租金到期Advance start--{0} \r\n", DateTime.Now.ToString()));
            //Console.Write(list.Count());

            foreach (var item in list)
            {
                //租金提醒日期
                if (item.F_RentReminderDate<= DateTime.Now && item.F_ExpireReminderDate > DateTime.Now)
                {
                    DC_ASSETS_BusStopBillboardsEntity entity = boardsIBll.GetDC_ASSETS_BusStopBillboardsEntity(item.F_BSBId);
                    this.Content = string.Format("{0}：{1}{2}租金快到期了,请尽快处理", this.Name, entity.F_InstallationLocation,item.F_BillboardsName);
                   this.SendMessage("", "");
                  //  LoggerFactory.Info(this.Content);

                }
                //租金到期提醒
                else if (item.F_ExpireReminderDate <= DateTime.Now)
                {
                    DC_ASSETS_BusStopBillboardsEntity entity = boardsIBll.GetDC_ASSETS_BusStopBillboardsEntity(item.F_BSBId);
                    this.Content = string.Format("{0}：{1}租金已到期了,请抓紧处理", this.Name, entity.F_InstallationLocation, item.F_BillboardsName);
                    this.SendMessage("", "");
                    Log4Helper.Info(typeof(BillboardsRentIncomeJob), Content);
                  //  LoggerFactory.Info(this.Content);

                }
                log.Info(string.Format(this.Content+ "-{0}\r\n", DateTime.Now.ToString()));
            }
        }
    }
}
