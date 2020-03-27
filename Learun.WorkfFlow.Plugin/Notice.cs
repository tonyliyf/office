using Learun.Application.WorkFlow;
using Learun.DataBase.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Learun.WorkFlow.Plugin
{
    public class NoticeMethod : RepositoryFactory, IWorkFlowMethod
    {
        /// <summary>
        /// 节点审核通过执行方法
        /// </summary>
        /// <param name="processId">流程实例主键</param>
        public void Execute(WfMethodParameter parameter)
        {
            this.BaseRepository().ExecuteBySql("insert into DeptNotice (F_Id,F_Title) values('" + parameter.childProcessId +"','" + parameter.nodeName + "[" + parameter.code + "]')");
        }
    }
}
