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
    public class OfficeCost : RepositoryFactory, IWorkFlowMethod
    {
        private DC_OA_CostReimbursementGatherIBLL costIBll = new DC_OA_CostReimbursementGatherBLL();
        private DC_OA_OfficeWoodsReplyIBLL officeWoodsIBll = new DC_OA_OfficeWoodsReplyBLL();
        private CompanyIBLL companyIBLL = new CompanyBLL();
        private UserIBLL userIBLL = new UserBLL();
        private DepartmentIBLL departmentIBLL = new DepartmentBLL();
        public void Execute(WfMethodParameter parameter)
        {
            var db = this.BaseRepository().BeginTrans();
            try
            {
                DC_OA_OfficeWoodsReplyEntity result = officeWoodsIBll.GetDC_OA_OfficeWoodsReplyEntity(parameter.processId);
                DC_OA_CostReimbursementGatherEntity gather = costIBll.GetEntity(parameter.childProcessId);
                if (gather == null)
                {
                    gather = new DC_OA_CostReimbursementGatherEntity();
                    gather.F_CRGId = parameter.childProcessId;
                }

                CompanyEntity entity = companyIBLL.GetEntity(result.F_CurrentCompanyId);
                DepartmentEntity departEntity = departmentIBLL.GetEntity(result.F_CurrentDeptId);
                UserEntity userEntity = userIBLL.GetEntityByUserId(result.F_CurrentUserId);
                gather.F_ReimbursementDepartmentId = result.F_CurrentDeptId;
                gather.F_ReimbursementDepartment = departEntity.F_FullName;
                gather.F_CreateUserId = result.F_CurrentUserId;
                gather.F_CreateUser = userEntity.F_RealName;
                gather.F_ReimbursementCompanyId = result.F_CurrentCompanyId;
                gather.F_ReimbursementCompany = entity.F_FullName;
                gather.F_ReimbursementMoney = (decimal)result.F_SumMoney;
                gather.F_ReimbursementDate = DateTime.Now;
                gather.F_REimbursementContent = string.Format("{0}年度汇总办公费用报销", result.F_ReplyMonth);
                gather.F_CostTypeId = "办公费";
                gather.F_CostTypeName = "办公费";
                gather.F_CreateDepartmentId = result.F_CurrentDeptId;
                gather.F_CreateDepartment = departEntity.F_FullName;
                gather.F_CreateUser = userEntity.F_RealName;
                gather.F_CreateUserId = result.F_CurrentUserId;
                gather.F_CreateDate = DateTime.Now;
                gather.F_HandleUser = result.F_CurrentUserId;
                gather.F_HandleUser = userEntity.F_RealName;
                gather.Create(false);
                db.Insert(gather);
                db.Commit();
            }
            catch (Exception ex)
            {
               
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
