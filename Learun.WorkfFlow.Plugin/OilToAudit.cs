using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Learun.Application.WorkFlow;
using Learun.DataBase.Repository;
using Learun.Application.TwoDevelopment;
using Learun.Application.TwoDevelopment.LR_CodeDemo;
using Learun.Application.Organization;
using Learun.Util;
using System;

namespace Learun.WorkFlow.Plugin
{
    public  class OilToAudit : RepositoryFactory, IWorkFlowMethod
    {
        private DC_OA_CostReimbursementGatherIBLL costIBll = new DC_OA_CostReimbursementGatherBLL();
        private DC_OA_OilAuidtIBLL oilBll = new DC_OA_OilAuidtBLL();
        private CompanyIBLL companyIBLL = new CompanyBLL();
        private UserIBLL userIBLL = new UserBLL();
        private DepartmentIBLL departmentIBLL = new DepartmentBLL();
        private DC_OA_VehicleIBLL vehicleBLL = new DC_OA_VehicleBLL();
        public void Execute(WfMethodParameter parameter)
        {
            var db = this.BaseRepository().BeginTrans();
            try
            {
                DC_OA_OilAuidtEntity result = oilBll.GetDC_OA_OilAuidtEntity(parameter.processId);
                DC_OA_CostReimbursementGatherEntity gather = costIBll.GetEntity(parameter.childProcessId);
                if (gather == null)
                {
                    gather = new DC_OA_CostReimbursementGatherEntity();
                    gather.F_CRGId = parameter.childProcessId;
                }
                DC_OA_VehicleEntity vehicle = vehicleBLL.GetDC_OA_VehicleEntity(result.F_VehilceId);


                CompanyEntity entity = companyIBLL.GetEntity(result.F_CurrentCompanyId);
                DepartmentEntity departEntity = departmentIBLL.GetEntity(result.F_CurrentDeptId);
                UserEntity userEntity = userIBLL.GetEntityByUserId(result.F_Reply);
                gather.F_ReimbursementDepartmentId = result.F_CurrentDeptId;
                gather.F_ReimbursementDepartment = departEntity.F_FullName;
                gather.F_CreateUserId = result.F_Reply;
                gather.F_CreateUser = userEntity.F_RealName;
                gather.F_ReimbursementCompanyId = result.F_CurrentCompanyId;
                gather.F_ReimbursementCompany = entity.F_FullName;
                gather.F_ReimbursementMoney = (decimal)result.F_Money;
                gather.F_ReimbursementDate = DateTime.Now;
                gather.F_REimbursementContent = string.Format("{0}燃油费用报销", vehicle.F_VehicleName+vehicle.F_VehicleNO);
                gather.F_CostTypeId = "汽车燃料费";
                gather.F_CostTypeName = "汽车燃料费";
                gather.F_CreateDepartmentId = result.F_CurrentDeptId;
                gather.F_CreateDepartment = departEntity.F_FullName;
                gather.F_CreateUser = userEntity.F_RealName;
                gather.F_CreateUserId = result.F_Reply;
                gather.F_CreateDate = DateTime.Now;
                gather.F_HandleUser = result.F_Reply;
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
