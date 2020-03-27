using Dapper;
using Learun.DataBase.Repository;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Learun.Application.TwoDevelopment.SystemDemo;

namespace Learun.Application.TwoDevelopment.AssetManager
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-02-14 11:09
    /// 描 述：DC_ASSETS_EquipmentInfo
    /// </summary>
    public class DC_ASSETS_EquipmentInfoService : RepositoryFactory
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
                a.F_EIId,
                a.F_EquipmentNumber,
                a.F_EquipmentName,
                a.F_SpecificationType,
                a.F_EquipmentCategory,
                a.F_Manufacturer,
                a.F_OriginalValueAssets,
                a.F_TotalPowerKW,
                a.F_Distributor,
                a.F_DeviceIdentification,
                a.F_AcquisitionTime,
                d.F_FullName as F_UseDepartmentId,
                e.F_RealName as F_LeaderId,
                a.F_OperatorId,
                a.F_NetSalvageValue,
                a.F_InstallationLocation,
                a.F_DepreciationMethod,
                a.F_UsefulYear,
                a.F_DepreciationThisMonth,
                a.F_AccumulatedDepreciation,
                a.F_PictureAccessories,
                a.F_UseState,
                a.F_Remarks
                ");
                strSql.Append(@" from DC_ASSETS_EquipmentInfo a 

left join LR_Base_Department d on a.F_UseDepartmentId=d.F_DepartmentId

left join  LR_Base_User e on a.F_LeaderId=e.F_UserId");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["F_DeviceIdentification"].IsEmpty())
                {
                    dp.Add("F_DeviceIdentification", queryParam["F_DeviceIdentification"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_DeviceIdentification = @F_DeviceIdentification ");
                }
                if (!queryParam["F_EquipmentName"].IsEmpty())
                {
                    dp.Add("F_EquipmentName", "%" + queryParam["F_EquipmentName"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_EquipmentName Like @F_EquipmentName ");
                }
                if (!queryParam["F_EquipmentCategory"].IsEmpty())
                {
                    dp.Add("F_EquipmentCategory", queryParam["F_EquipmentCategory"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_EquipmentCategory = @F_EquipmentCategory ");
                }
                DataTable dt = this.BaseRepository().FindTable(strSql.ToString(), dp);
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("F_EquipmentCategory", "EquipmentType");
                dic.Add("F_DepreciationMethod", "DepreciationMethod");
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
        public IEnumerable<DC_ASSETS_EquipmentInfoEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_EIId,
                t.F_EquipmentNumber,
                t.F_EquipmentName,
                t.F_SpecificationType,
                t.F_EquipmentCategory,
                t.F_Manufacturer,
                t.F_OriginalValueAssets,
                t.F_TotalPowerKW,
                t.F_Distributor,
                t.F_DeviceIdentification,
                t.F_AcquisitionTime,
                t.F_UseDepartmentId,
                t.F_LeaderId,
                t.F_OperatorId,
                t.F_NetSalvageValue,
                t.F_InstallationLocation,
                t.F_DepreciationMethod,
                t.F_UsefulYear,
                t.F_DepreciationThisMonth,
                t.F_AccumulatedDepreciation,
                t.F_PictureAccessories,
                t.F_UseState,
                t.F_Remarks
                ");
                strSql.Append("  FROM DC_ASSETS_EquipmentInfo t ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["F_DeviceIdentification"].IsEmpty())
                {
                    dp.Add("F_DeviceIdentification",queryParam["F_DeviceIdentification"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_DeviceIdentification = @F_DeviceIdentification ");
                }
                if (!queryParam["F_EquipmentName"].IsEmpty())
                {
                    dp.Add("F_EquipmentName", "%" + queryParam["F_EquipmentName"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_EquipmentName Like @F_EquipmentName ");
                }
                if (!queryParam["F_EquipmentCategory"].IsEmpty())
                {
                    dp.Add("F_EquipmentCategory",queryParam["F_EquipmentCategory"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_EquipmentCategory = @F_EquipmentCategory ");
                }
                return this.BaseRepository().FindList<DC_ASSETS_EquipmentInfoEntity>(strSql.ToString(),dp, pagination);
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
        /// 获取DC_ASSETS_EquipmentInfo表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_ASSETS_EquipmentInfoEntity GetDC_ASSETS_EquipmentInfoEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_ASSETS_EquipmentInfoEntity>(keyValue);
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
                this.BaseRepository().Delete<DC_ASSETS_EquipmentInfoEntity>(t=>t.F_EIId == keyValue);
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
        public void SaveEntity(string keyValue, DC_ASSETS_EquipmentInfoEntity entity)
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

    }
}
