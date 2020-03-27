using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Quartz;
using Learun.Util.Operat;
using Learun.Application.Base.SystemModule;
using Learun.Application.WorkFlow;
using Learun.Application.TwoDevelopment.LR_CodeDemo;

namespace Learun.Application.Web.App_Start.LogJob
{
    public class LogJob:IJob
    {
        private NWFProcessIBLL nWFProcessIBLL = new NWFProcessBLL();
        private F_Annxles_weaverIBLL bll = new F_Annxles_weaverBLL();
        public void Execute(IJobExecutionContext context)
        {
            bll.MoveMainRecord();
            //LogEntity logEntity = new LogEntity();

            //logEntity.F_CategoryId = 1;

            //logEntity.F_SourceContentJson = "泛微附件获取服务";
            //logEntity.F_Description = "泛微附件获取服务";
            //logEntity.WriteLog();
            //nWFProcessIBLL.MakeTaskTimeout();
            ////移除1个月的登陆日志
            //LogBLL.RemoveLog((int)OperationType.Login, "1");
            ////移除1个月的离开日志
            //LogBLL.RemoveLog((int)OperationType.Leave, "1");
            ////移除1个月的访问日志
            //LogBLL.RemoveLog((int)OperationType.Visit, "1");
        }
    }
}