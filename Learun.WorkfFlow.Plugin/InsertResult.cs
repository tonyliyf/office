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
using Learun.Application.TwoDevelopment.AssetManager;

namespace Learun.WorkFlow.Plugin
{
    public class InsertResult : RepositoryFactory, IWorkFlowMethod
    {

        private DC_OA_PurchaseAuditResultIBLL resultIBll = new DC_OA_PurchaseAuditResultBLL();
        private DC_OA_PurchaseAuditIBLL auditIBll = new DC_OA_PurchaseAuditBLL();
        private CompanyIBLL companyIBLL = new CompanyBLL();
        private UserIBLL userIBLL = new UserBLL();
        private DepartmentIBLL departmentIBLL = new DepartmentBLL();
        private DC_OA_PurchasePublicIBLL publicIBLL = new DC_OA_PurchasePublicBLL();
        private DC_ASSETS_ContactUnitIBLL dc_Assets_ContactUnitIBLL = new DC_ASSETS_ContactUnitBLL();

        private  LogWrite lg = new LogWrite("InsertResult");

        public void Execute(WfMethodParameter parameter)
        {

            var db = this.BaseRepository().BeginTrans();
            try
            {
                DC_OA_PurchaseAuditResultEntity result = resultIBll.GetEntity(parameter.childProcessId);
                DC_OA_PurchaseAuditEntity audit = auditIBll.GetEntity(parameter.processId);
                DC_OA_PurchasePublicEntity publicEntity = new DC_OA_PurchasePublicEntity();
                if (result == null)
                {
                    result = new DC_OA_PurchaseAuditResultEntity();
                    result.F_PurchaseAuditResultId= parameter.childProcessId;
                }
                CompanyEntity entity = companyIBLL.GetEntity(audit.F_CurrentCompanyId);
                DepartmentEntity departEntity = departmentIBLL.GetEntity(audit.F_CurrentDeptId);
                UserEntity userEntity = userIBLL.GetEntityByUserId(audit.F_CreateUserId);
                //插入审核结果数据
                result.F_CurrentCompanyName = entity.F_FullName;
                result.F_PurchaseProjectType = audit.F_PurchaseProjectType;
                result.F_PurchaseWoodType = audit.F_PurchaseWoodType;
                result.F_CurrentDeptName = departEntity.F_FullName;
                result.F_CreateUserName = userEntity.F_RealName;
                result.F_CurrentCompanyId = audit.F_CurrentCompanyId;
                result.F_CurrentDeptId = audit.F_CurrentDeptId;
                result.F_CreateUserId = audit.F_CreateUserId;
                result.F_PurchaseProjectNo = audit.F_PurchaseProjectNo;
                result.F_DealUserPhone = audit.F_DealUserPhone;
                result.F_DealMoney = audit.F_DealMoney;
                result.F_PurchaseMethod = audit.F_PurchaseMethod;
                result.F_buyPlatform = audit.F_buyPlatform;
                result.F_PurchaseAuditRefId = audit.F_PurchaseAuditId;
                result.F_PurchaseName = audit.F_PurchaseName;
                result.F_PurchaseInCompanyId = audit.F_PurchaseCompanyId;
                DC_ASSETS_ContactUnitEntity dailiEntity = dc_Assets_ContactUnitIBLL.GetDC_ASSETS_ContactUnitEntity(audit.F_PurchaseCompanyId);
                if (dailiEntity != null)
                {
                    result.F_PurchaseCompanyName = dailiEntity.F_UnitName;
                }
                result.Create(false);
                db.Insert(result);

                //插入公告数据
                publicEntity.F_CurrentCompanyId = audit.F_CurrentCompanyId;
                publicEntity.F_CurrentCompanyName= entity.F_FullName;
                publicEntity.F_CurrentDeptName = departEntity.F_FullName;
                publicEntity.F_CreateUserName = userEntity.F_RealName;
                publicEntity.F_CurrentDeptId = audit.F_CurrentDeptId;
                publicEntity.F_CreateUserId = audit.F_CreateUserId;
                publicEntity.F_PurchaseProjectNo = audit.F_PurchaseProjectNo;
                publicEntity.F_DealUserPhone = audit.F_DealUserPhone;
                publicEntity.F_DealMoney = audit.F_DealMoney;
                publicEntity.F_PurchaseMethod = audit.F_PurchaseMethod;
                publicEntity.F_buyPlatform = audit.F_buyPlatform;
                publicEntity.F_PurchaseAuditRefId = audit.F_PurchaseAuditId;
                publicEntity.F_PurchaseName = audit.F_PurchaseName;
                publicEntity.Create(false);
                db.Insert(publicEntity);

                db.Commit();
            }
            catch (Exception ex)
            {
                db.Rollback();
                lg.WriteDebugLog("ee", ex.Message);
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
