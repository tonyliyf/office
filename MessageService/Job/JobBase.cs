using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Learun.Application.Message;
using Quartz;
using Learun.Util;

namespace MessageService
{
    public class JobBase
    {
        private LR_StrategyInfoIBLL bll = new LR_StrategyInfoBLL();

        public JobBase(string code)
        {
            this.Code = code;
            var entity = bll.GetEntityByCode(code);
            this.Name = entity.F_StrategyName;
            this.F_ExecuteTimeBefore = entity.F_ExecuteTimeBefore;
            this.F_ExecuteTimeOut = entity.F_ExecuteTimeOut;
            this.F_TimeSpans = entity.F_TimeSpans;
            this.F_SendTimes = entity.F_SendTimes;
            this.F_CornTimes = entity.F_CornTimes;
        }

        public JobBase()
        {

        }

         public void Init(string code)
        {
            this.Code = code;
            var entity = bll.GetEntityByCode(code);
            this.Name = entity.F_StrategyName;
            this.F_ExecuteTimeBefore = entity.F_ExecuteTimeBefore;
            this.F_ExecuteTimeOut = entity.F_ExecuteTimeOut;
            this.F_TimeSpans = entity.F_TimeSpans;
            this.F_SendTimes = entity.F_SendTimes;
            this.F_CornTimes = entity.F_CornTimes;


        }

            public void SendMessage(string userids="",string fromUserid="")
        {
            bll.SendMessageByUserIds(this.Code, this.Content, userids, fromUserid);
        }
        

        /// <summary>
        /// code编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 临近多少小时触发
        /// </summary>
        public int?  F_ExecuteTimeBefore { get; set; }


        /// <summary>
        /// 逾期多少小时不触发
        /// </summary>
         public  int? F_ExecuteTimeOut { get; set; }


        /// <summary>
        ///间隔时长
        /// </summary>
        public decimal? F_TimeSpans { get; set; }

        /// <summary>
        /// 总共发多少次
        /// </summary>
        public int?  F_SendTimes { get; set; }


        /// <summary>
        /// Corn表达式
        /// </summary>
        /// <returns></returns>
        public string F_CornTimes { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }


       
    }
}
