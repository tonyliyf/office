using Dapper;
using Learun.Application.Base.SystemModule;
using Learun.Application.Organization;
using Learun.DataBase.Repository;
using Learun.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Learun.Application.TwoDevelopment.SystemDemo;
namespace Learun.Application.TwoDevelopment.AssetManager
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-02-13 15:11
    /// 描 述：DC_ASSETS_BuildingBaseInfo
    /// </summary>
    public class DC_ASSETS_BuildingBaseInfoService : RepositoryFactory
    {
             
        #region 获取数据
        private CompanyIBLL companyIBLL = new CompanyBLL();
        private CodeRuleIBLL codeRuleIBLL = new CodeRuleBLL();
      //  private DC_ASSETS_HouseInfoIBLL houseIbll = new DC_ASSETS_HouseInfoBLL();
        #region 获取数据


        /// <summary>
        /// 获取树形数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetSqlTree(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindTable("select F_BBIId as id , 0 as pid , F_ConstructionName as name  from  DC_ASSETS_BuildingBaseInfo where F_LBIId='" + keyValue + "'");
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
        /// 获取树形数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetTreeLandbase(string unit)
        {
            try
            {
                if (string.IsNullOrEmpty(unit))
                {
                    return this.BaseRepository().FindTable("select F_BBIId as id , 0 as pid , F_ConstructionName as name  from  DC_ASSETS_BuildingBaseInfo");
                }
                else
                {

                    return this.BaseRepository().FindTable( string.Format("select F_BBIId as id , 0 as pid , F_ConstructionName as name  from  DC_ASSETS_BuildingBaseInfo where F_ConstructionName like '%{0}%'",unit));
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
        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_ASSETS_BuildingBaseInfoEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT  top 50000");
                strSql.Append(@"
                t.F_BBIId,
                t.F_ConstructionCode,
                t.F_AddressCode,
                t.F_Address,
                t.F_ConstructionName,
                t.F_ConstructionHeight,
                t.F_ConstructionFloorCount,
                t.F_UnitCount,
                t.F_ConstructionArea,
                t.F_UsageArea,
                t.F_CoverArea,
                t.F_UseCategories,
                t.F_StructureClassification,
                t.F_AvailableYears,
                t.F_UseSituation,
                t.F_CompletionTime,
                t.F_FireRating,
                t.F_BuildingRecordNumber,
                t.F_FormerUnit,
                t.F_FormerUnitContacts,
                t.F_ContactsPhone,
                t.F_IfUse,
                t.F_PictureAccessories,
                t.F_OtherAccessories,
                t.F_Remarks,
                t.F_BuildingClass,
                t.F_BuildingValue,
                t.F_LBIId,
                t.F_Oldunit
                ");
                strSql.Append("  FROM DC_ASSETS_BuildingBaseInfo t ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["F_ConstructionName"].IsEmpty())
                {
                    dp.Add("F_ConstructionName", "%" + queryParam["F_ConstructionName"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_ConstructionName Like @F_ConstructionName ");
                }
                if (!queryParam["F_Address"].IsEmpty())
                {
                    dp.Add("F_Address", "%" + queryParam["F_Address"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_Address Like @F_Address ");
                }
                if (!queryParam["F_UseSituation"].IsEmpty())
                {
                    dp.Add("F_UseSituation", "%" + queryParam["F_UseSituation"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_UseSituation Like @F_UseSituation ");
                }

                if (!queryParam["F_FormerUnit"].IsEmpty())
                {
                    dp.Add("F_FormerUnit",  queryParam["F_FormerUnit"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_FormerUnit= @F_FormerUnit ");
                }

                if (!queryParam["LBIId"].IsEmpty())
                {
                    dp.Add("LBIId", queryParam["LBIId"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_LBIId= @LBIId ");
                }
                //else
                //{
                //    strSql.Append(" And (select count(*) from DC_ASSETS_LandBaseInfo g where t.F_LBIId = g.F_LBIId)= 0");
                //}
                if (!queryParam["F_BuildingClass"].IsEmpty())
                {
                    dp.Add("F_BuildingClass", queryParam["F_BuildingClass"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_BuildingClass= @F_BuildingClass ");
                }

                strSql.Append(" order by F_Oldunit,F_ConstructionName");
                return this.BaseRepository().FindList<DC_ASSETS_BuildingBaseInfoEntity>(strSql.ToString(), dp, pagination);
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
                t.F_BBIId,
                t.F_ConstructionCode,
                t.F_AddressCode,
                t.F_Address,
                t.F_ConstructionName,
                t.F_ConstructionHeight,
                t.F_ConstructionFloorCount,
                t.F_UnitCount,
                t.F_ConstructionArea,
                t.F_UsageArea,
                t.F_CoverArea,
                t.F_UseCategories,
                t.F_StructureClassification,
                t.F_AvailableYears,
                t.F_UseSituation,
                t.F_CompletionTime,
                t.F_FireRating,
                t.F_BuildingRecordNumber,
                t.F_FormerUnit,
                t.F_FormerUnitContacts,
                t.F_ContactsPhone,
                t.F_IfUse,
                t.F_PictureAccessories,
                t.F_OtherAccessories,
                t.F_Remarks,
                t.F_BuildingClass,
                t.F_BuildingValue,
                t.F_LBIId
                ");
                strSql.Append("  FROM DC_ASSETS_BuildingBaseInfo t ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["F_ConstructionName"].IsEmpty())
                {
                    dp.Add("F_ConstructionName", "%" + queryParam["F_ConstructionName"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_ConstructionName Like @F_ConstructionName ");
                }
                if (!queryParam["F_Address"].IsEmpty())
                {
                    dp.Add("F_Address", "%" + queryParam["F_Address"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_Address Like @F_Address ");
                }
                if (!queryParam["F_UseSituation"].IsEmpty())
                {
                    dp.Add("F_UseSituation", "%" + queryParam["F_UseSituation"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_UseSituation Like @F_UseSituation ");
                }

                if (!queryParam["F_FormerUnit"].IsEmpty())
                {
                    dp.Add("F_FormerUnit", queryParam["F_FormerUnit"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_FormerUnit= @F_FormerUnit ");
                }

                if (!queryParam["LBIId"].IsEmpty())
                {
                    dp.Add("LBIId", queryParam["LBIId"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_LBIId= @LBIId ");
                }
                if (!queryParam["F_BuildingClass"].IsEmpty())
                {
                    dp.Add("F_BuildingClass", queryParam["F_BuildingClass"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_BuildingClass= @F_BuildingClass ");
                }
                DataTable dt = this.BaseRepository().FindTable(strSql.ToString(), dp);
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("F_FormerUnit", "oldManager");
                dic.Add("F_BuildingClass", "BuildingClass");
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
        public DataTable GetMapList(string Typecode, string Street,string pageSize,string index)
        {
            try
            {
                var strSql = new StringBuilder();
                int size =20000;
                int pages = 1;
                if(!pageSize.IsEmpty())
                {
                    size = int.Parse(pageSize);
                }

                if (!index.IsEmpty())
                {
                    pages = int.Parse(index);
                }
                int number = size * (pages - 1);

                //土地分布
                if (Typecode =="1") {

                    strSql.Append(string.Format(@"select  top {0} * from DC_ASSETS_LandBaseInfo t WHERE 1=1 AND t.F_ParcelAddress Like '%{1}%'
and t.F_LBIId not in (select top {2}  t.F_LBIId FROM DC_ASSETS_LandBaseInfo t WHERE 1 = 1 AND t.F_ParcelAddress Like '%{1}%' order by t.F_LBIId)
order by  t.F_LBIId", size, Street, number));
                   
                    //strSql.Append("SELECT ");
                    //strSql.Append(@"
                    //*

                    //");
                    //strSql.Append("  FROM DC_ASSETS_LandBaseInfo t ");

                    //strSql.Append("  WHERE 1=1 AND t.F_ParcelAddress Like '%"+ Street + "%' ");

                    return this.BaseRepository().FindTable(strSql.ToString());
                }
                //房产分布
                else if (Typecode =="2") {

                    strSql.Append(string.Format(@"select  top {0}
                    t.*,t2.F_CenterpointCoordinates  from DC_ASSETS_HouseInfo t  left join dc_assets_buildingbaseinfo t2 on t.F_BBIId=t2.f_bbiid  WHERE 1 = 1 AND t.F_HouseName Like '%{1}%'
and t.F_HouseID not in (select top {2}
                    t.F_HouseID FROM DC_ASSETS_HouseInfo t WHERE 1 = 1 AND t.F_HouseName Like '%{1}%' order by t.F_HouseID)
order by  t.F_HouseID", size, Street, number));
                    return this.BaseRepository().FindTable(strSql.ToString());
                }
                //广告牌
                else if (Typecode =="3")
                {
                    strSql.Append(string.Format(@" select
                t1.f_billboardsnumber as code,
                t1.F_BillboardsName as name,
                isnull((select top 1 f_areaname from lr_base_area where F_AreaId=t1.F_CommunityCode),'未填写') as areaname,
                t1.F_InstallationLocation as address,
                isnull((select top 1 f_itemname from lr_base_dataitemdetail 
                where f_itemvalue=t1.f_usestate and F_ItemId='cbf2def3-53aa-425b-8b62-2e4a5e3ffb32'),'未填写') as usestate,
                isnull((select top 1 f_itemname from lr_base_dataitemdetail 
                where f_itemvalue=t2.F_LeaseState and F_ItemId='c4417fca-b624-46a1-ac21-c291782519f5'),'未填写') as rentstate,
                isnull((select top 1 f_actualprice from dc_assets_busstopbillboardsrentincome where F_BSBRDId=t2.F_BSBRDId),0) as price,
				t1.F_CenterpointCoordinates 
                from dc_assets_busstopbillboards t1
                left join dc_assets_busstopbillboardsrentdetail t2 on t1.F_BSBId=t2.F_BSBId
				where t1.F_CenterpointCoordinates is not null and t1.F_CenterpointCoordinates !='[]' and t1.F_InstallationLocation like '%{0}%'",Street));

                    return this.BaseRepository().FindTable(strSql.ToString());
                }

                return null;
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
        public DataTable GetStreet()
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append(@"SELECT   distinct left(F_Address,CHARINDEX('大道',F_Address)+1)F_street  FROM [dbo].[DC_ASSETS_BuildingBaseInfo] where F_Address like'%大道%'
union all
SELECT   distinct left(F_Address, CHARINDEX('路', F_Address)) F_street  FROM[dbo].[DC_ASSETS_BuildingBaseInfo] where F_Address like'%路%'
");
                return this.BaseRepository().FindTable(strSql.ToString());
               
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
        /// 获取DC_ASSETS_BuildingBaseInfo表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_ASSETS_BuildingBaseInfoEntity GetDC_ASSETS_BuildingBaseInfoEntity(string keyValue)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_BBIId,
                t.F_ConstructionCode,
                t.F_AddressCode,
                t.F_Address,
                t.F_ConstructionName,
                t.F_ConstructionHeight,
                t.F_ConstructionFloorCount,
                t.F_UnitCount,
                t.F_ConstructionArea,
                t.F_UsageArea,
                t.F_CoverArea,
                t.F_UseCategories,
                t.F_StructureClassification,
                t.F_AvailableYears,
                t.F_UseSituation,
                t.F_CompletionTime,
                t.F_FireRating,
                t.F_BuildingRecordNumber,
                t.F_FormerUnit,
                t.F_FormerUnitContacts,
                t.F_ContactsPhone,
                t.F_IfUse,
                t.F_PictureAccessories,
                t.F_OtherAccessories,
                t.F_Remarks,
                t.F_BuildingClass,
                t.F_BuildingValue,
                t.F_LBIId,
                t.F_Oldunit
              
                ");
                strSql.Append("  FROM DC_ASSETS_BuildingBaseInfo t ");
                strSql.Append("  WHERE  t.F_LBIId= '" + keyValue + "'");

                IEnumerable<DC_ASSETS_BuildingBaseInfoEntity> DC_ASSETS_BuildingBaseInfo = this.BaseRepository().FindList<DC_ASSETS_BuildingBaseInfoEntity>(strSql.ToString());

                DC_ASSETS_BuildingBaseInfoEntity num1 = null;

                foreach (DC_ASSETS_BuildingBaseInfoEntity obj in DC_ASSETS_BuildingBaseInfo) {
                    num1 = this.BaseRepository().FindEntity<DC_ASSETS_BuildingBaseInfoEntity>(obj.F_BBIId);
                }

                return num1;
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
        /// 获取DC_ASSETS_BuildingBaseInfo表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_ASSETS_BuildingBaseInfoEntity GetDC_ASSETS_BuildingBaseInfo(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_ASSETS_BuildingBaseInfoEntity>(keyValue);
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
        /// 获取DC_ASSETS_BuildingBaseInfo表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_ASSETS_BuildingBaseInfoEntity GetDC_ASSETS_BuildingInfo(string oldUnit, string BuildingName)
        {
            try
            {

                var list = this.BaseRepository().FindEntity<DC_ASSETS_BuildingBaseInfoEntity>(i => i.F_FormerUnit == oldUnit && i.F_ConstructionName == BuildingName);

                return list;

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
        /// 获取DC_ASSETS_BuildingBaseInfo表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_ASSETS_BuildingBaseInfoEntity GetDC_ASSETS_BuildingBaseInfo(string F_LBIId, string BuildingName)
        {
            try
            {

                var list = this.BaseRepository().FindEntity<DC_ASSETS_BuildingBaseInfoEntity>(i => i.F_LBIId == F_LBIId && i.F_ConstructionName == BuildingName);

                return list;
                
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
                foreach (var item in this.BaseRepository().FindList<DC_ASSETS_HouseInfoEntity>(c=>c.F_BBIId==keyValue))
                {
                    this.BaseRepository().Delete<DC_ASSETS_HouseRentDetailEntity>(t => t.F_HouseID == item.F_HouseID);
                    this.BaseRepository().Delete<DC_ASSETS_HouseInfoEntity>(t => t.F_HouseID == item.F_HouseID);
                }
                this.BaseRepository().Delete<DC_ASSETS_BuildingBaseInfoEntity>(t => t.F_BBIId == keyValue);
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
        public void SaveEntity(string keyValue, DC_ASSETS_BuildingBaseInfoEntity entity)
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


        public bool IsExitsEntity(string name)
        {

            var list = this.BaseRepository().FindEntity<DC_ASSETS_BuildingBaseInfoEntity>(i => i.F_ConstructionName == name);
            if (list != null)
            {
                return true;
            }
            else
            {
                return false;

            }

        }



        public bool ImportBuildingEntity(DataTable dtTable)
        {
            var db = this.BaseRepository().BeginTrans();
            DC_ASSETS_BuildingBaseInfoEntity entity = null;
            DC_ASSETS_HouseInfoEntity houseEntity = null;
            var departmentid = "23ac3ac1-097f-4007-8bd2-20fea87fe377";
            var userid = "d232107b-3b0a-44c2-992c-964e895f6af3";
            int f = 0;
            string temp = string.Empty;
            try
            {
                foreach (DataRow dt in dtTable.Rows)
                {
                    if (dt[0].ToString().Trim() == "序号") continue;
                    if (dt[2].ToString().Trim().IsEmpty()) continue;
                    if (temp != dt[2].ToString())
                    {
                        temp = dt[2].ToString();
                        entity = new DC_ASSETS_BuildingBaseInfoEntity();
                        entity.F_ConstructionName = dt[2].ToString();

                        if (!dt[5].IsEmpty())
                        {
                            entity.F_FormerUnit = dt[5].ToString();
                        }
                        entity.F_Oldunit = dt[1].ToString();
                        //if (!dt[7].IsEmpty())
                        //{
                        //    entity.F_ConstructionFloorCount = int.Parse(dt[7].ToString());
                        //}
                        //if (!dt[9].IsEmpty())
                        //{
                        //    entity.F_ConstructionArea = double.Parse(dt[9].ToString());
                        //}
                        //if (!dt[10].IsEmpty())
                        //{
                        //    entity.F_BuildingValue = double.Parse(dt[10].ToString());
                        //}
                        //  entity.F_BuildingClass = dt[12].ToString();
                        entity.F_Address = dt[4].ToString();
                        entity.F_IfUse = 1;
                        //entity.F_ConstructionCode = codeRuleIBLL.GetBillCode("10012");

                        entity.F_BuildingClass = dt[11].ToString();//经营性，非经营性
                        entity.F_CommunityCode = "420583102";
                        entity.Create();
                        entity.F_CreateUserid = userid;
                        entity.F_CreateDepartmentId = departmentid;
                        db.Insert(entity);
                    }

                    houseEntity = new DC_ASSETS_HouseInfoEntity();

                    houseEntity.F_Address = dt[4].ToString();
                    houseEntity.F_HouseName = dt[3].ToString();
                    houseEntity.F_BuildingAddress = dt[4].ToString();
                    houseEntity.F_CertificateNo = dt[6].ToString();
                    houseEntity.F_UseCategories = "4";
                    // houseEntity.F_FloorNumber = dt[8].ToString();
                    houseEntity.F_RoomUsage = "3";
                    houseEntity.F_RentPurpose = "4";
                    houseEntity.F_IfUse = "1";
                    // houseEntity.F_Remarks = dt[9].ToString();

                    if (!dt[5].IsEmpty())
                    {
                        houseEntity.F_FormerUnit = dt[5].ToString();
                    }
                    //总楼层
                    if (!dt[7].IsEmpty())
                    {
                        houseEntity.F_HouseFloorCount = int.Parse(dt[7].ToString());

                    }
                    //所在楼层

                    houseEntity.F_FloorNumber = dt[8].ToString();

                    if (!dt[9].IsEmpty())
                    {
                        houseEntity.F_HouseArea = double.Parse(dt[9].ToString());
                    }

                    if (!dt[10].IsEmpty())
                    {
                        houseEntity.F_BuildingValue = double.Parse(dt[10].ToString());
                    }
                    //  houseEntity.F_Remarks = dt[11].ToString();
                    houseEntity.F_BBIId = entity.F_BBIId;
                    houseEntity.F_Remarks = dt[14].ToString();
                    houseEntity.F_Oldunit = entity.F_Oldunit;
                    // houseEntity.F_AssetsNumber = entity.F_ConstructionCode;
                    houseEntity.Create();
                    db.Insert(houseEntity);
                    f++;
                }
                db.Commit();
            }
            catch (Exception ex)
            {
                temp = f.ToString();
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
        //public bool ImportBuildingEntity(DataTable dtTable)
        //{
        //    var db = this.BaseRepository().BeginTrans();
        //    DC_ASSETS_BuildingBaseInfoEntity entity = null;
        //    DC_ASSETS_HouseInfoEntity houseEntity = null;
        //    var departmentid = "23ac3ac1-097f-4007-8bd2-20fea87fe377";
        //    var userid = "d232107b-3b0a-44c2-992c-964e895f6af3";
        //    int f = 0;
        //    string temp = string.Empty;
        //    try
        //    {
        //        foreach (DataRow dt in dtTable.Rows)
        //        {
        //            if (dt[0].ToString().Trim() == "序号") continue;
        //            if (dt[1].ToString().Trim().IsEmpty()) continue;
        //            if (temp != dt[1].ToString())
        //            {
        //                temp = dt[1].ToString();
        //                entity = new DC_ASSETS_BuildingBaseInfoEntity();
        //                entity.F_ConstructionName = dt[1].ToString();

        //                if (!dt[3].IsEmpty())
        //                {
        //                    entity.F_FormerUnit = dt[3].ToString();
        //                }
        //                if (!dt[5].IsEmpty())
        //                {
        //                    entity.F_ConstructionFloorCount = int.Parse(dt[5].ToString());
        //                }
        //                if (!dt[6].IsEmpty())
        //                {
        //                    entity.F_ConstructionArea = double.Parse(dt[6].ToString());
        //                }
        //                if (!dt[7].IsEmpty())
        //                {
        //                    entity.F_BuildingValue = double.Parse(dt[7].ToString()) / 10000;
        //                }
        //                entity.F_BuildingClass = dt[8].ToString();
        //                entity.F_Address = dt[2].ToString();
        //                entity.F_IfUse = 1;
        //                entity.F_ConstructionCode = codeRuleIBLL.GetBillCode("10012");
        //                codeRuleIBLL.UseRuleSeed("10012");
        //                entity.F_CommunityCode = "420583102";
        //                entity.Create();
        //                entity.F_CreateUserid = userid;
        //                entity.F_CreateDepartmentId = departmentid;
        //                db.Insert(entity);
        //            }

        //            houseEntity = new DC_ASSETS_HouseInfoEntity();
        //            houseEntity.F_HouseName = dt[1].ToString();
        //            houseEntity.F_BuildingAddress = dt[2].ToString();
        //            houseEntity.F_CertificateNo = dt[4].ToString();
        //            houseEntity.F_UseCategories = "4";
        //            houseEntity.F_RoomUsage = "3";
        //            houseEntity.F_RentPurpose = "4";
        //            houseEntity.F_IfUse = "1";
        //            houseEntity.F_Remarks = dt[9].ToString();
        //            if (!dt[7].IsEmpty())
        //            {
        //                houseEntity.F_BuildingValue = double.Parse(dt[7].ToString()) / 10000;
        //            }
        //             if (!dt[6].IsEmpty())
        //            {
        //                houseEntity.F_HouseArea = double.Parse(dt[6].ToString());
        //            }
        //            if (!dt[3].IsEmpty())
        //            {
        //                houseEntity.F_PropertyOwner = dt[3].ToString();
        //            }
        //            houseEntity.F_BBIId = entity.F_BBIId;
        //            houseEntity.F_AssetsNumber = entity.F_ConstructionCode;
        //            houseEntity.Create();
        //            db.Insert(houseEntity);
        //        }
        //        db.Commit();
        //    }
        //    catch (Exception ex)
        //    {
        //       // temp = f.ToString();
        //        db.Rollback();
        //        if (ex is ExceptionEx)
        //        {
        //            throw;
        //        }
        //        else
        //        {
        //            throw ExceptionEx.ThrowServiceException(ex);
        //        }

        //    }

        //    return true;


        //}


        public int  UpdateBuildValue()
        {
            string sql = @" UPDATE DC_ASSETS_BuildingBaseInfo set  F_BuildingValue =(select sum(h.F_BuildingValue) from DC_ASSETS_HouseInfo h
 where h.F_BBIId = DC_ASSETS_BuildingBaseInfo.F_BBIId)";

           return  this.BaseRepository().ExecuteBySql(sql);
        }

        public int UpdateBuildArea()
        {
            string sql = @" UPDATE DC_ASSETS_BuildingBaseInfo set  F_ConstructionArea =(select sum(h.F_HouseArea) from DC_ASSETS_HouseInfo h
 where h.F_BBIId = DC_ASSETS_BuildingBaseInfo.F_BBIId)";
            return this.BaseRepository().ExecuteBySql(sql);
        }

        public void UpdateHouseInfo()
        {
          //  var list = this.BaseRepository().FindList<DC_ASSETS_BuildingBaseInfoEntity>();

         ///   foreach(var item in list)
         //   {
         //       var houselist = this.BaseRepository().FindList<DC_ASSETS_HouseInfoEntity>(string.Format("select * from DC_ASSETS_HouseInfoEntity where F_BBIId ='{0}'", item.F_BBIId));


         //   }

        }
        public bool ImportEntity(DataTable dtTable)
        {
            var db = this.BaseRepository().BeginTrans();
            DC_ASSETS_BuildingBaseInfoEntity entity = null;
            DC_ASSETS_HouseInfoEntity houseEntity = null;
            DC_ASSETS_HouseRentMainEntity houseRent = null;
           DC_ASSETS_HouseRentDetailEntity houseRentDetail = null;
            DC_ASSETS_HouseRentIncomeEntity incomeEntity = null;

           var departmentid = "23ac3ac1-097f-4007-8bd2-20fea87fe377";
           var userid = "d232107b-3b0a-44c2-992c-964e895f6af3";

            CompanyEntity companyEntity = companyIBLL.GetList().Where(i => i.F_ShortName == "金润源").SingleOrDefault();
            int f = 0;

            try
            {
                foreach (DataRow dt in dtTable.Rows)
                {
                   // if (f < 3) continue;
                    if (!this.IsExitsEntity(dt[2].ToString()))
                    {
                        entity = new DC_ASSETS_BuildingBaseInfoEntity();
                        entity.F_ConstructionName = dt[2].ToString();
                        entity.F_Address = dt[3].ToString();
                        if (dt[5].ToString() != string.Empty)
                        {
                            entity.F_ConstructionArea = double.Parse(dt[5].ToString());

                        }
                       entity.F_ConstructionCode = codeRuleIBLL.GetBillCode("10012");
                        codeRuleIBLL.UseRuleSeed("10012");
                        entity.F_CommunityCode = "420583102";
                        entity.F_FormerUnit = "金润源";
                        entity.F_IfUse = 0;
                        entity.Create();
                        db.Insert(entity);
                    }
                    houseEntity = new DC_ASSETS_HouseInfoEntity();
                    houseEntity.F_AssetsNumber = entity.F_ConstructionCode;
                  //  houseEntity.F_AssetsNumber = codeRuleIBLL.GetBillCode("10013");
                  //  codeRuleIBLL.UseRuleSeed("10013");
                  // houseEntity.F_AssetsNumber =
                    houseEntity.F_HouseName = entity.F_ConstructionName;
                    houseEntity.F_UseCategories = "4";
                    houseEntity.F_RoomUsage = "3";
                    houseEntity.F_RentPurpose = "4";
                    if(dt[8].ToString()!=string.Empty)
                    {
                        houseEntity.F_CertificateNo = dt[8].ToString();
                    }
                    houseEntity.F_BBIId = entity.F_BBIId;
                    houseEntity.F_IfUse = "0";
                    houseEntity.Create();
                    db.Insert(houseEntity);
                  
                    if (dt[9].ToString() != string.Empty)
                    {
                        houseRent = new DC_ASSETS_HouseRentMainEntity();
                        houseRent.F_RentNumber = f.ToString();
                        houseRent.F_RentYear = "2017";
                        houseRent.F_RentName = houseEntity.F_HouseName + "招租";
                        houseRent.F_Unit = "金润源";
                        houseRent.F_RentState = "3";
                        houseRent.Create();
                        db.Insert(houseRent);
                        houseRentDetail = new DC_ASSETS_HouseRentDetailEntity();
                        houseRentDetail.F_HRMId = houseRent.F_HRMId;
                        houseRentDetail.F_HouseID = houseEntity.F_HouseID;
                        houseRentDetail.F_LeaseState = "3";
                        houseRentDetail.F_RentReservePrice = 0;
                        houseRentDetail.F_RentDeposit = 0;
                        houseRentDetail.F_Renter = dt[9].ToString();
                        if (dt[10].ToString() != string.Empty)
                        {
                            houseRentDetail.F_RenterPhone = dt[10].ToString();
                        }
                        if (dt[12].ToString() != string.Empty)
                        {
                            houseRentDetail.F_RentArea = double.Parse(dt[12].ToString());

                        }
                        houseRentDetail.F_RentStartTime = new DateTime(2017, 1, 1);
                        houseRentDetail.F_RentEndTime = new DateTime(2017, 12, 31);
                        houseRentDetail.Create();
                        db.Insert(houseRentDetail);
                        incomeEntity = new DC_ASSETS_HouseRentIncomeEntity();
                        incomeEntity.F_Year = "2017";
                        incomeEntity.F_HRDId = houseRentDetail.F_HRDId;
                        incomeEntity.F_YearNumber = 1;
                        if (dt[13].ToString() != string.Empty)
                        {
                            incomeEntity.F_ContractNumber = dt[13].ToString();
                        }
                        if (dt[16].ToString() != string.Empty)
                        {
                            incomeEntity.F_ActualPrice = double.Parse(dt[16].ToString());
                            incomeEntity.Create();
                            db.Insert(incomeEntity);

                        }
                       
                    }
                   

                  
                    if (dt[17].ToString() != string.Empty)
                    {
                        //2018年的

                        houseRent = new DC_ASSETS_HouseRentMainEntity();
                        houseRent.F_RentNumber = f.ToString();
                        houseRent.F_RentYear = "2018";
                        houseRent.F_RentName = houseEntity.F_HouseName + "招租";
                        houseRent.F_Unit = "金润源";
                        houseRent.F_RentState = "3";
                        houseRent.Create();
                        db.Insert(houseRent);
                        houseRentDetail = new DC_ASSETS_HouseRentDetailEntity();
                        houseRentDetail.F_HRMId = houseRent.F_HRMId;
                        houseRentDetail.F_HouseID = houseEntity.F_HouseID;
                        houseRentDetail.F_LeaseState = "3";
                        houseRentDetail.F_RentReservePrice = 0;
                        houseRentDetail.F_RentDeposit = 0;
                        houseRentDetail.F_Renter = dt[17].ToString();
                        if (dt[18].ToString() != string.Empty)
                        {
                            houseRentDetail.F_RenterPhone = dt[18].ToString();
                        }
                        if (dt[20].ToString() != string.Empty)
                        {
                            houseRentDetail.F_RentArea = double.Parse(dt[20].ToString());

                        }
                        houseRentDetail.F_RentStartTime = new DateTime(2018, 1, 1);
                        houseRentDetail.F_RentEndTime = new DateTime(2018, 12, 31);
                        houseRentDetail.Create();
                        db.Insert(houseRentDetail);
                        incomeEntity = new DC_ASSETS_HouseRentIncomeEntity();
                        incomeEntity.F_Year = "2018";
                        incomeEntity.F_YearNumber = 2;
                        incomeEntity.F_HRDId = houseRentDetail.F_HRDId;
                        if (dt[21].ToString() != string.Empty)
                        {
                            incomeEntity.F_ContractNumber = dt[21].ToString();
                        }
                        if (dt[24].ToString() != string.Empty)
                        {
                            incomeEntity.F_ActualPrice = double.Parse(dt[24].ToString());
                            incomeEntity.Create();
                            db.Insert(incomeEntity);

                        }
                        
                    }
                   
                    f++;

                }
                

                db.Commit();
            }
            catch (Exception ex)
            {
              string temp = f.ToString();
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

        #endregion

         #endregion 

    }
}
