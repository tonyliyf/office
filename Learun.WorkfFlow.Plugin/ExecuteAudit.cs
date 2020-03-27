using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Learun.Application.WorkFlow;
using Learun.DataBase.Repository;
using Learun.Application.TwoDevelopment;
using Learun.Application.TwoDevelopment.LR_CodeDemo;
using Learun.Application.Organization;
using Learun.Util;

namespace Learun.WorkFlow.Plugin
{
    public class ExecuteAudit : RepositoryFactory, IWorkFlowMethod
    {
        private DC_OA_PurchaseReplyIBLL replyaIBll = new DC_OA_PurchaseReplyBLL();
        private DC_OA_PurchaseAuditIBLL auditIBll = new DC_OA_PurchaseAuditBLL();
        private CompanyIBLL companyIBLL = new CompanyBLL();
        private UserIBLL userIBLL = new UserBLL();
        private DepartmentIBLL departmentIBLL = new DepartmentBLL();
        private LogWrite lg = new LogWrite("ExecuteAudit");
        public void Execute(WfMethodParameter parameter)
        {
            var db = this.BaseRepository().BeginTrans();
            try
            {
                DC_OA_PurchaseReplyEntity reply = replyaIBll.GetEntity(parameter.processId);
                DC_OA_PurchaseAuditEntity audit = auditIBll.GetEntity(parameter.childProcessId);
                if(audit==null)
                {
                    audit = new DC_OA_PurchaseAuditEntity();
                    audit.F_PurchaseAuditId = parameter.childProcessId;
                }
                CompanyEntity entity = companyIBLL.GetEntity(reply.F_CurrentCompanyId);
                DepartmentEntity departEntity = departmentIBLL.GetEntity(reply.F_CurrentDeptId);
                UserEntity userEntity = userIBLL.GetEntityByUserId(reply.F_CreateUserId);
                audit.F_PurchaseProjectType = reply.F_PurchaseProjectType;
                audit.F_PurchaseWoodType = reply.F_PurchaseWoodType;
                audit.F_CurrentCompayName = entity.F_FullName;
                audit.F_CurrentDeptName = departEntity.F_FullName;
                audit.F_CreateUserName = userEntity.F_RealName;
                audit.F_CurrentCompanyId = reply.F_CurrentCompanyId;
                audit.F_PurchaseFile = string.Empty;
                audit.F_PurchaseImageFile = string.Empty;
                audit.F_PurchaseListFile = string.Empty;
                audit.F_CurrentDeptId = reply.F_CurrentDeptId;
                audit.F_CreateUserId = reply.F_CreateUserId;
                audit.F_PurchaseProjectNo = reply.F_PurchaseProjectNo;
                audit.F_DealUserPhone = reply.F_DealUserPhone;
                audit.F_DealMoney = reply.F_DealMoney;
                audit.F_PurchaseMethod = reply.F_PurchaseMethod;
                audit.F_buyPlatform = reply.F_buyPlatform;
                audit.F_PurchaseReplyRefid = reply.F_PurchaseReplyId;
                audit.F_PurchaseName = reply.F_PurchaseName;
                audit.Create(false);
                db.Insert(audit);
                db.Commit();
            }
            catch (Exception ex)
            {
                lg.WriteDebugLog("ee", ex.Message);
                db.Rollback();
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }
        }
    }
}
