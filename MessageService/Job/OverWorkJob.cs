using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Learun.Util;
using Quartz;
using Learun.Application.TwoDevelopment.LR_CodeDemo;


namespace MessageService
{
    /// <summary>
    /// 督办工作提醒OSNotice
    /// </summary>

    public class OverWorkJob : JobBase
    {

        private DC_OA_OverSeeWorkIBLL ibll = new DC_OA_OverSeeWorkBLL();
        public log4net.ILog log = log4net.LogManager.GetLogger(typeof(OverWorkJob));
        public void Execute()
        {

            //  LoggerFactory.Info("OSNotice start");

            this.Init("OSNotice");
            // Log4Helper.Info(typeof(OverWorkJob), "OSNotice start");
            log.Info(string.Format("督办工作提醒OSNotice start--{0} \r\n", DateTime.Now.ToString()));
            var list = ibll.GetOverSeeWork();
            foreach (var item in list)
            {
                ///逾期
                if (item.F_EndDate.HasValue && item.F_EndDate < DateTime.Now)
                {
                    //负责人
                    if (!item.F_LeaderUserId.IsEmpty())
                    {
                        this.Content = string.Format("{0}：您负责的督办事项：{1}已逾期,请尽快处理！", this.Name, item.F_OSWContent);
                        this.SendMessage(item.F_LeaderUserId, "");
                        log.Info(string.Format(Content + "-{0}\r\n", DateTime.Now.ToString()));
                        //  LoggerFactory.Info(this.Content);
                        //  log.Info(string.Format(this.Content+"接收人{ 0}",item.F_LeaderUser));
                    }
                    //责任领导F_HighLeaderId
                    if (!item.F_HighLeaderId.IsEmpty())
                    {
                        this.Content = string.Format("{0}：您负责督办的督办事项：{1}已逾期,请尽快处理！", this.Name, item.F_OSWContent);
                        this.SendMessage(item.F_HighLeaderId, "");
                        log.Info(string.Format(Content + "-{0}\r\n", DateTime.Now.ToString()));
                        //log.Info(string.Format(this.Content + "接收人{ 0}", item.F_HighLeader));
                    }
                    //督办人F_OverSeeUser
                    if (!item.F_OverSeeUserId.IsEmpty())
                    {
                        this.Content = string.Format("{0}：您督办的督办事项：{1}已逾期,请尽快处理！", this.Name, item.F_OSWContent);
                        this.SendMessage(item.F_OverSeeUserId, "");
                        log.Info(string.Format(Content + "-{0}\r\n", DateTime.Now.ToString()));
                        // log.Info(string.Format(this.Content + "接收人{ 0}", item.F_OverSeeUser));
                    }

                }
                else if (item.F_EndDate.HasValue & this.F_ExecuteTimeBefore.HasValue && item.F_EndDate.Value.AddHours((int)this.F_ExecuteTimeBefore) >= DateTime.Now)
                {
                    //负责人
                    if (!item.F_LeaderUserId.IsEmpty())
                    {
                        this.Content = string.Format("{0}：您负责的督办事项：{1}已临近,请尽快处理！", this.Name, item.F_OSWContent);
                        this.SendMessage(item.F_LeaderUserId, "");
                        // log.Info(string.Format(this.Content + "接收人{ 0}", item.F_LeaderUser));
                        log.Info(string.Format(Content + "-{0}\r\n", DateTime.Now.ToString()));
                    }
                    //责任领导F_HighLeaderId
                    if (!item.F_HighLeaderId.IsEmpty())
                    {
                        this.Content = string.Format("{0}：您负责督办的督办事项：{1}已临近,请尽快处理！", this.Name, item.F_OSWContent);
                        this.SendMessage(item.F_HighLeaderId, "");
                        //log.Info(string.Format(this.Content + "接收人{ 0}", item.F_HighLeader));
                        log.Info(string.Format(Content + "-{0}\r\n", DateTime.Now.ToString()));
                    }
                    //督办人F_OverSeeUser
                    if (!item.F_OverSeeUserId.IsEmpty())
                    {
                        this.Content = string.Format("{0}：您督办的督办事项：{1}已临近,请尽快处理！", this.Name, item.F_OSWContent);
                        this.SendMessage(item.F_OverSeeUserId, "");
                        log.Info(string.Format(Content + "-{0}\r\n", DateTime.Now.ToString()));
                        // log.Info(string.Format(this.Content + "接收人{ 0}", item.F_OverSeeUser));
                    }

                }

                //Log4Helper.Info(typeof(OverWorkJob), Content);
                //log.Info(string.Format(Content + "-{0}\r\n", DateTime.Now.ToString()));


            }
        }

    }
    
}
