using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Learun.Util.Quartz;
using Learun.Application.Base.SystemModule;
using Learun.Util.Operat;
using Learun.Application.Message;

namespace Learun.Application.Web.App_Start
{
    public class LogDelete: JobBase
    {
        public override void Run()
        {
            LogBLL.RemoveLog((int)OperationType.Login, "1");

             LR_StrategyInfoIBLL bll = new LR_StrategyInfoBLL();
            bll.SendMessageByUserIds(this.Code, "消息策略:"+this.Code+"时间:"+DateTime.Now.ToLongDateString()+"----操作日志删除了", "system,462af38a-6164-4b2c-a0eb-1345fa643955");

        }
    }
}