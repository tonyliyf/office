using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Quartz;
using Learun.Util.Operat;
using Learun.Application.Base.SystemModule;
using Learun.Application.WorkFlow;
using Learun.Application.TwoDevelopment.EcologyDemo;

namespace Learun.Application.Web.App_Start.BaseJob
{
    public class BaseJob : IJob
    {
        private HrmSubCompanyIBLL companyBll = new HrmSubCompanyBLL();
        private HrmDepartmentIBLL departBll = new HrmDepartmentBLL();
        private HrmResourceIBLL userBLL = new HrmResourceBLL();
        public void Execute(IJobExecutionContext context)
        {
            companyBll.UpdateCompany();
            departBll.UpdateDept();
            userBLL.UpdateEntity();

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