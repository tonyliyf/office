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
    public class InsertReturn : RepositoryFactory, IWorkFlowMethod
    {
        private DC_OA_PurchaseAuditResultIBLL resultIBll = new DC_OA_PurchaseAuditResultBLL();
        private DC_OA_PurchaseDepositIBLL depositIBll = new DC_OA_PurchaseDepositBLL();
        private DC_OA_PurchaseAuditIBLL auditIBLL = new DC_OA_PurchaseAuditBLL();
        private CompanyIBLL companyIBLL = new CompanyBLL();
        private UserIBLL userIBLL = new UserBLL();
        private DepartmentIBLL departmentIBLL = new DepartmentBLL();

        private LogWrite lg = new LogWrite("InsertReturn");

        public void Execute(WfMethodParameter parameter)
        {
            var db = this.BaseRepository().BeginTrans();
            try
            {
                DC_OA_PurchaseAuditResultEntity result = resultIBll.GetEntity(parameter.processId);
                DC_OA_PurchaseDepositEntity deoposit = depositIBll.GetDC_OA_PurchaseDepositEntity(parameter.childProcessId);
                DC_OA_PurchaseAuditEntity audit = auditIBLL.GetEntity(result.F_PurchaseAuditRefId);
                if (deoposit == null)
                {
                    deoposit = new DC_OA_PurchaseDepositEntity();
                    deoposit.F_PurchaseDepositId = parameter.childProcessId;
                }
                if (audit.F_DepositMoney > 0)//是否有保证金
                {
                    CompanyEntity entity = companyIBLL.GetEntity(result.F_CurrentCompanyId);
                    DepartmentEntity departEntity = departmentIBLL.GetEntity(result.F_CurrentDeptId);
                    UserEntity userEntity = userIBLL.GetEntityByUserId(result.F_CreateUserId);
                    deoposit.F_CurrentCompanyName = entity.F_FullName;
                    deoposit.F_CurrentDeptName = departEntity.F_FullName;
                    deoposit.F_CreateUserName = userEntity.F_RealName;
                    deoposit.F_CurrentCompanyId = result.F_CurrentCompanyId;
                    deoposit.F_CurrentDeptId = result.F_CurrentDeptId;
                    deoposit.F_CreateUserId = result.F_CreateUserId;
                    deoposit.F_PurchaseProjectNo = result.F_PurchaseProjectNo;
                    deoposit.F_DC_OAPurchaseAydutRefid = result.F_PurchaseAuditResultId;
                    deoposit.F_PurchaseName = result.F_PurchaseName;
                    deoposit.F_DepositMoney = audit.F_DepositMoney;
                    deoposit.Create(false);
                    db.Insert(deoposit);
                    db.Commit();
                }
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
