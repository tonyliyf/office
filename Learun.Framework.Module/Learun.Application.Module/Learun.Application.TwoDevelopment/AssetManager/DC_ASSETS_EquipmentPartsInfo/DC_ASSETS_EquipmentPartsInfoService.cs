using Dapper;
using Learun.DataBase.Repository;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;
using Learun.Application.TwoDevelopment.SystemDemo;
namespace Learun.Application.TwoDevelopment.AssetManager
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-02-14 13:32
    /// 描 述：DC_ASSETS_EquipmentPartsInfo
    /// </summary>
    public class DC_ASSETS_EquipmentPartsInfoService : RepositoryFactory
    {
        #region 获取数据
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
                a.F_EPIId,
                a.F_PartsCode,
                a.F_PartsName,
                a.F_PartsType,
                a.F_SpecificationType,
                a.F_MeasurementUnit,
                a.F_UnitPrice,
                b.F_UnitName as F_Manufacturer,
                c.F_UnitName as F_Distributor,
                a.F_StorageLocation,
                a.F_InitialInventory,
                a.F_MaximumInventory,
                a.F_MinimumInventory,
                a.F_PictureAccessories,
                a.F_CreateUserid,
                a.F_PartsState,
                a.F_Remarks,
                d.F_EquipmentName as RelativeDevic
                ");
                strSql.Append(@"  from DC_ASSETS_EquipmentPartsInfo a left join (SELECT * from  DC_ASSETS_ContactUnit where F_UnitType='3') b  on a.F_Manufacturer=b.F_UnitName 

left join(SELECT * from DC_ASSETS_ContactUnit where F_UnitType = '2') c  on a.F_Distributor = c.F_UnitName

left join DC_ASSETS_EquipmentInfo d on a.RelativeDevice = d.F_EIId ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["F_PartsName"].IsEmpty())
                {
                    dp.Add("F_PartsName", "%" + queryParam["F_PartsName"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_PartsName Like @F_PartsName ");
                }
                if (!queryParam["F_PartsType"].IsEmpty())
                {
                    dp.Add("F_PartsType", queryParam["F_PartsType"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_PartsType = @F_PartsType ");
                }
                if (!queryParam["F_Manufacturer"].IsEmpty())
                {
                    dp.Add("F_Manufacturer", queryParam["F_Manufacturer"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_Manufacturer = @F_Manufacturer ");
                }
                DataTable dt = this.BaseRepository().FindTable(strSql.ToString(), dp);
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("F_PartsType", "DevicePartType");
                dic.Add("F_PartsState", "DevicePartState");
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
        public IEnumerable<DC_ASSETS_EquipmentPartsInfoEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_EPIId,
                t.F_PartsCode,
                t.F_PartsName,
                t.F_PartsType,
                t.F_SpecificationType,
                t.F_MeasurementUnit,
                t.F_UnitPrice,
                t.F_Manufacturer,
                t.F_Distributor,
                t.F_StorageLocation,
                t.F_InitialInventory,
                t.F_MaximumInventory,
                t.F_MinimumInventory,
                t.F_PictureAccessories,
                t.F_CreateUserid,
                t.F_PartsState,
                t.F_Remarks
                ");
                strSql.Append("  FROM DC_ASSETS_EquipmentPartsInfo t ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["F_PartsName"].IsEmpty())
                {
                    dp.Add("F_PartsName", "%" + queryParam["F_PartsName"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_PartsName Like @F_PartsName ");
                }
                if (!queryParam["F_PartsType"].IsEmpty())
                {
                    dp.Add("F_PartsType", queryParam["F_PartsType"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_PartsType = @F_PartsType ");
                }
                if (!queryParam["F_Manufacturer"].IsEmpty())
                {
                    dp.Add("F_Manufacturer", queryParam["F_Manufacturer"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_Manufacturer = @F_Manufacturer ");
                }
                return this.BaseRepository().FindList<DC_ASSETS_EquipmentPartsInfoEntity>(strSql.ToString(), dp, pagination);
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
        /// 获取DC_ASSETS_EquipmentPartsInfo表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_ASSETS_EquipmentPartsInfoEntity GetDC_ASSETS_EquipmentPartsInfoEntity(string keyValue, out string relativeDevice)
        {
            try
            {
                var list = this.BaseRepository().FindList<DC_ASSETS_EquipmentPartsRelationEntity>(c => c.F_EPIId == keyValue);
                relativeDevice = "";
                if (list.Count() > 0)
                {
                    foreach (var item in list)
                    {
                        relativeDevice += item.F_EIId + ",";
                    }
                    relativeDevice = relativeDevice.Substring(0, relativeDevice.Length - 1);
                }
                return this.BaseRepository().FindEntity<DC_ASSETS_EquipmentPartsInfoEntity>(keyValue);
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
                this.BaseRepository().Delete<DC_ASSETS_EquipmentPartsRelationEntity>(c => c.F_EPIId == keyValue);
                this.BaseRepository().Delete<DC_ASSETS_EquipmentPartsIntoDetailEntity>(c => c.F_EPIId == keyValue);
                this.BaseRepository().Delete<DC_ASSETS_EquipmentPartsOutDetailEntity>(c => c.F_EPIId == keyValue);
                this.BaseRepository().Delete<DC_ASSETS_EquipmentPartsInfoEntity>(t => t.F_EPIId == keyValue);
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
        public void SaveEntity(string keyValue, DC_ASSETS_EquipmentPartsInfoEntity entity, string RelativeDevice)
        {
            var db = this.BaseRepository().BeginTrans();
            try
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    entity.Modify(keyValue);
                    db.Update(entity);
                    db.Delete<DC_ASSETS_EquipmentPartsRelationEntity>(c => c.F_EPIId == keyValue);
                    if (!string.IsNullOrWhiteSpace(RelativeDevice))
                    {
                        var strarr = RelativeDevice.Split(',');
                        foreach (var str in strarr)
                        {
                            DC_ASSETS_EquipmentPartsRelationEntity rEntity = new DC_ASSETS_EquipmentPartsRelationEntity();
                            rEntity.Create();
                            rEntity.F_EIId = str;
                            rEntity.F_EPIId = entity.F_EPIId;
                            db.Insert(rEntity);
                        }
                    }
                }
                else
                {
                    entity.Create();
                    db.Insert(entity);
                    if (!string.IsNullOrWhiteSpace(RelativeDevice))
                    {
                        var strarr = RelativeDevice.Split(',');
                        foreach (var str in strarr)
                        {
                            DC_ASSETS_EquipmentPartsRelationEntity rEntity = new DC_ASSETS_EquipmentPartsRelationEntity();
                            rEntity.Create();
                            rEntity.F_EIId = str;
                            rEntity.F_EPIId = entity.F_EPIId;
                            db.Insert(rEntity);
                        }
                    }
                }
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

        #endregion

    }
}
