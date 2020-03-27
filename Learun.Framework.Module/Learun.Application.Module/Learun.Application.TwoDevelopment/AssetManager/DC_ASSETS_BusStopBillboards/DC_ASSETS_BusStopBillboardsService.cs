using Dapper;
using Learun.DataBase.Repository;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Learun.Application.TwoDevelopment.SystemDemo;
using Learun.Application.Base.SystemModule;

namespace Learun.Application.TwoDevelopment.AssetManager
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-02-14 10:05
    /// 描 述：DC_ASSETS_BusStopBillboards
    /// </summary>
    public class DC_ASSETS_BusStopBillboardsService : RepositoryFactory
    {
        private CodeRuleIBLL codeRuleIBLL = new CodeRuleBLL();
        #region 获取数据

        /// <summary>
        /// 获取树形数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetSqlTree()
        {
            try
            {
                return this.BaseRepository().FindTable(@"	select F_ItemName as id,'' as pid,F_ItemName as name from LR_Base_DataItemDetail where F_ItemId='e7af8421-d6f6-447b-b218-8c91099c444f'

        union

        select F_BSBId as id, F_BillboardsCategory as pid, F_BillboardsName as name from DC_ASSETS_BusStopBillboards order by name ");
            }
            catch (Exception ex)
            {
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
        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public DataTable ExportData(string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                a.F_BSBId,
                a.F_BillboardsNumber,
                a.F_BillboardsName,
                a.F_SpecificationType,
                a.F_BillboardsCategory,
                b.F_UnitName as F_Manufacturer,
                c.F_UnitName as  F_ServiceProvider,
                a.F_BillboardsIdentification,
                a.F_InstallationTime,
                a.F_InstallationLocation,
                a.F_PictureAccessories, 
                d.F_FullName as F_UseDepartmentId,
                e.F_RealName as F_LeaderId,
                f.F_RealName as F_ManagerId,
                a.F_UseState,
                a.F_Remarks,
                a.F_Remark
                ");
                strSql.Append(@" from DC_ASSETS_BusStopBillboards a left join (SELECT * from  DC_ASSETS_ContactUnit where F_UnitType='3') b  on a.F_Manufacturer=b.F_UnitName 

left join (SELECT * from  DC_ASSETS_ContactUnit where F_UnitType='4') c  on a.F_ServiceProvider=c.F_UnitName 

left join LR_Base_Department d on a.F_UseDepartmentId=d.F_DepartmentId

left join  LR_Base_User e on a.F_LeaderId=e.F_UserId

left join LR_Base_User f on a.F_ManagerId=f.F_UserId");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["F_BillboardsName"].IsEmpty())
                {
                    dp.Add("F_BillboardsName", "%" + queryParam["F_BillboardsName"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_BillboardsName Like @F_BillboardsName ");
                }
                if (!queryParam["F_SpecificationType"].IsEmpty())
                {
                    dp.Add("F_SpecificationType", "%" + queryParam["F_SpecificationType"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_SpecificationType Like @F_SpecificationType ");
                }
                if (!queryParam["F_BillboardsCategory"].IsEmpty())
                {
                    dp.Add("F_BillboardsCategory", queryParam["F_BillboardsCategory"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_BillboardsCategory = @F_BillboardsCategory ");
                }
                if (!queryParam["F_Manufacturer"].IsEmpty())
                {
                    dp.Add("F_Manufacturer", queryParam["F_Manufacturer"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_Manufacturer = @F_Manufacturer ");
                }
                if (!queryParam["F_ServiceProvider"].IsEmpty())
                {
                    dp.Add("F_ServiceProvider", queryParam["F_ServiceProvider"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_ServiceProvider = @F_ServiceProvider ");
                }
                DataTable dt = this.BaseRepository().FindTable(strSql.ToString(), dp);
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("F_BillboardsCategory", "BoardType");
                dic.Add("F_BillboardsIdentification", "BoardContent");
                dic.Add("F_UseState", "AdBoardUseState");
                
                DataConvertSerivers sevices = new DataConvertSerivers();
                sevices.ConvertDataByDataItem(dt, dic);
                return dt;
            }
            catch (Exception ex)
            {
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
        
        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public DataTable GetHouseboardsList()
        {
            try
            {
                var strSql = new StringBuilder();
              
                strSql.Append(@"
             
select F_BillboardsCategory from DC_ASSETS_BusStopBillboards GROUP BY F_BillboardsCategory
                ");
            
                DataTable dt = this.BaseRepository().FindTable(strSql.ToString());
               
                return dt;
            }
            catch (Exception ex)
            {
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
        public DataTable GetboardsAssigneeSearch(string F_BillboardsCategory, string SearchValue)
        {
            try
            {
                var strSql = new StringBuilder();

                if (!string.IsNullOrEmpty(SearchValue))
                {
                    strSql.Append(@"
select F_BillboardsNumber,F_BillboardsName,F_SpecificationType,F_BillboardsCategory,F_BillboardsIdentification,F_InstallationTime,F_InstallationLocation,F_Remarks,F_CenterpointCoordinates from DC_ASSETS_BusStopBillboards where  F_BillboardsCategory='" + F_BillboardsCategory + "' and " +
    "( F_BillboardsName like '%" + SearchValue + "%' or F_InstallationLocation like '%" + SearchValue + "%')");
                }
                else
                {

                    strSql.Append(@"
select F_BillboardsNumber,F_BillboardsName,F_SpecificationType,F_BillboardsCategory,F_BillboardsIdentification,F_InstallationTime,F_InstallationLocation,F_Remarks,F_CenterpointCoordinates from DC_ASSETS_BusStopBillboards where  F_BillboardsCategory='" + F_BillboardsCategory  +"'");
                }

                SimpleLogUtil.WriteTextLog("boards", strSql.ToString(), DateTime.Now);
                DataTable dt = this.BaseRepository().FindTable(strSql.ToString());

                return dt;
            }
            catch (Exception ex)
            {
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
        public DataTable GetboardsAssigneeDetail1(string State, string SearchValue)
        {

            try
            {
                var strSql = new StringBuilder();
                //查询上半年的成功招租的广告牌
                //F_RentState (1,待租，2，已租，3，失败)
                if (State == "1")
                {
                    strSql.Append(@"SELECT
	d.F_BillboardsNumber,
d.F_BillboardsName,
d.F_SpecificationType,
d.F_BillboardsCategory,
d.F_BillboardsIdentification,
d.F_InstallationTime,
d.F_InstallationLocation,
d.F_Remarks,
d.F_CenterpointCoordinates
FROM
	DC_ASSETS_BusStopBillboardsRentMain a
	LEFT JOIN DC_ASSETS_BusStopBillboardsRentDetail b ON a.F_BSBRMId = b.F_BSBRMId
	LEFT JOIN DC_ASSETS_BusStopBillboards d ON d.F_BSBId = b.F_BSBId 
	left join DC_ASSETS_BusStopBillboardsRentIncome n on n.F_BSBRDId=b.F_BSBRDId
WHERE
	a.F_RentState = '2' 
	AND datepart ( yyyy, n.F_ContractSignDate ) = datepart ( yyyy, GETDATE ( ) ) 
	AND datepart ( mm, n.F_ContractSignDate  ) BETWEEN 1 
	AND 6 
	AND ( d.F_BillboardsName LIKE '%" + SearchValue + "%' OR d.F_InstallationLocation LIKE '%"+ SearchValue + "%' )");
                }
                else {
                    strSql.Append(@"SELECT
	d.F_BillboardsNumber,
d.F_BillboardsName,
d.F_SpecificationType,
d.F_BillboardsCategory,
d.F_BillboardsIdentification,
d.F_InstallationTime,
d.F_InstallationLocation,
d.F_Remarks,
d.F_CenterpointCoordinates
FROM
	DC_ASSETS_BusStopBillboardsRentMain a
	LEFT JOIN DC_ASSETS_BusStopBillboardsRentDetail b ON a.F_BSBRMId = b.F_BSBRMId
	LEFT JOIN DC_ASSETS_BusStopBillboards d ON d.F_BSBId = b.F_BSBId 
	left join DC_ASSETS_BusStopBillboardsRentIncome n on n.F_BSBRDId=b.F_BSBRDId
WHERE
	a.F_RentState != '2' 
	AND datepart ( yyyy, n.F_ContractSignDate ) = datepart ( yyyy, GETDATE ( ) ) 
	AND datepart ( mm, n.F_ContractSignDate  ) BETWEEN 1 
	AND 6 
	AND ( d.F_BillboardsName LIKE '%" + SearchValue + "%' OR d.F_InstallationLocation LIKE '%"+ SearchValue + "%' )");

                }

                SimpleLogUtil.WriteTextLog("rentan", strSql.ToString(), DateTime.Now);
                DataTable dt = this.BaseRepository().FindTable(strSql.ToString());

                return dt;
            }
            catch (Exception ex)
            {
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
        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_ASSETS_BusStopBillboardsEntity> GetPageList( string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_BSBId,
                t.F_BillboardsNumber,
                t.F_BillboardsName,
                t.F_SpecificationType,
                t.F_BillboardsCategory,
                t.F_Manufacturer,
                t.F_ServiceProvider,
                t.F_BillboardsIdentification,
                t.F_InstallationTime,
                t.F_InstallationLocation,
                t.F_PictureAccessories,
                t.F_UseDepartmentId,
                t.F_LeaderId,
                t.F_ManagerId,
                t.F_UseState,
                t.F_Remarks,
                t.F_Remark
                ");
                strSql.Append("  FROM DC_ASSETS_BusStopBillboards t ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });

                if (!queryParam["F_BSBId"].IsEmpty())
                {
                    dp.Add("F_BSBId", "%" + queryParam["F_BSBId"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_BSBId Like @F_BSBId ");
                }
                if (!queryParam["F_BillboardsName"].IsEmpty())
                {
                    dp.Add("F_BillboardsName", "%" + queryParam["F_BillboardsName"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_BillboardsName Like @F_BillboardsName ");
                }
                if (!queryParam["F_SpecificationType"].IsEmpty())
                {
                    dp.Add("F_SpecificationType", "%" + queryParam["F_SpecificationType"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_SpecificationType Like @F_SpecificationType ");
                }
                if (!queryParam["F_BillboardsCategory"].IsEmpty())
                {
                    dp.Add("F_BillboardsCategory", queryParam["F_BillboardsCategory"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_BillboardsCategory = @F_BillboardsCategory ");
                }
                if (!queryParam["F_Manufacturer"].IsEmpty())
                {
                    dp.Add("F_Manufacturer", queryParam["F_Manufacturer"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_Manufacturer = @F_Manufacturer ");
                }
                if (!queryParam["F_ServiceProvider"].IsEmpty())
                {
                    dp.Add("F_ServiceProvider", queryParam["F_ServiceProvider"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_ServiceProvider = @F_ServiceProvider ");
                }
                return this.BaseRepository( ).FindList<DC_ASSETS_BusStopBillboardsEntity>(strSql.ToString(), dp);

            }
            catch (Exception ex)
            {
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
        
        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public DataTable GetboardsInfo()
        {
            try
            {
                var strSql = new StringBuilder();
           
                strSql.Append(@"
             select F_BillboardsCategory,count(*) as number from  DC_ASSETS_BusStopBillboards l GROUP BY F_BillboardsCategory
                ");
                DataTable dt = this.BaseRepository().FindTable(strSql.ToString());

                return dt;

            }
            catch (Exception ex)
            {
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
        /// <summary>
        /// 获取DC_ASSETS_BusStopBillboards表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_ASSETS_BusStopBillboardsEntity GetDC_ASSETS_BusStopBillboardsEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_ASSETS_BusStopBillboardsEntity>(keyValue);
            }
            catch (Exception ex)
            {
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

        #endregion

        #region 提交数据

        /// <summary>
        /// 删除实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public void DeleteEntity(string keyValue)
        {
            try
            {
                this.BaseRepository().Delete<DC_ASSETS_BusStopBillboardsEntity>(t => t.F_BSBId == keyValue);
            }
            catch (Exception ex)
            {
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

        /// <summary>
        /// 保存实体数据（新增、修改）
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public void SaveEntity(string keyValue, DC_ASSETS_BusStopBillboardsEntity entity)
        {
            try
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    entity.Modify(keyValue);
                    this.BaseRepository().Update(entity);
                }
                else
                {
                    entity.Create();
                    this.BaseRepository().Insert(entity);
                }
            }
            catch (Exception ex)
            {
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

        #endregion



        public bool ImportLandEntity(DataTable dtTable)
        {
            var db = this.BaseRepository().BeginTrans();
            DC_ASSETS_BusStopBillboardsEntity entity = null;


            try
            {
                foreach (DataRow dt in dtTable.Rows)
                {
                    entity = new DC_ASSETS_BusStopBillboardsEntity();
                    if (dt[0].ToString().Trim() == "序号") continue;
                    if (dt[3].ToString().Trim() == "") continue;
                    entity.F_BillboardsName = dt[1].ToString() +dt[3].ToString()+"广告牌";
                    entity.F_BillboardsCategory = "港湾式公交站台";
                    entity.F_BillboardsIdentification = "1";
                    entity.F_InstallationLocation = dt[1].ToString() + dt[3].ToString();
                    entity.F_UseDepartmentId = "8cbe961b-503a-48de-bd87-823c4112d54c";
                    entity.F_BillboardsNumber = codeRuleIBLL.GetBillCode("10014");
                    entity.F_UseState = "1";
                    codeRuleIBLL.UseRuleSeed("10014");
                    entity.Create();
                    db.Insert(entity);

                }
                db.Commit();
            }
            catch (Exception ex)
            {
                //string temp = f.ToString();
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

            return true;


        }



    }
}
