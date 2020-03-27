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
using System.Data;

namespace Learun.WorkFlow.Plugin
{
    public class BusinessReceptionExecute : RepositoryFactory, IWorkFlowMethod
    {
        public void Execute(WfMethodParameter parameter)
        {
            DataTable dt = this.BaseRepository().FindTable(@"  select * from DC_OA_BusinessReception where F_BusinessReceptionId =@F_BusinessReceptionId",
                new { F_BusinessReceptionId = parameter.processId });
            if (dt != null && dt.Rows.Count > 0)
            {
                DC_OA_CostReimbursementGatherEntity childEntity = new DC_OA_CostReimbursementGatherEntity();
                childEntity.Create();
                childEntity.F_CRGId = parameter.childProcessId;
                childEntity.F_CostTypeId = "接待费";
                childEntity.F_CostTypeName = "接待费";
                DataTable dt1 = this.BaseRepository().FindTable(@"  select * from lr_base_user where f_userid =@f_userid",
                new { f_userid = (dt.Rows[0]["f_applyuser"] ?? "").ToString() });
                childEntity.F_ReimbursementCompanyId = dt1.Rows[0]["f_companyid"].ToString();
                childEntity.F_ReimbursementMoney = Convert.ToDecimal(dt.Rows[0]["f_cost"] ?? 0m);
                childEntity.F_CreateDate = DateTime.Now;
                childEntity.F_CreateDepartmentId = dt1.Rows[0]["f_companyid"].ToString();
                childEntity.F_HandleUserId = (dt.Rows[0]["f_applyuser"] ?? "").ToString();
                childEntity.F_REimbursementContent = (dt.Rows[0]["f_activitycontent"] ?? "").ToString();
                childEntity.F_ReimbursementDepartmentId = (dt.Rows[0]["f_applydepartment"] ?? "").ToString();
                childEntity.F_ReimbursementDate = Convert.ToDateTime((dt.Rows[0]["f_applydate"] ?? DateTime.Now));
                this.BaseRepository().Insert(childEntity);
            }
        }
    }
}
