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
    /// 日 期：2019-02-14 16:09
    /// 描 述：DC_ASSETS_EquipmentPartsInto
    /// </summary>
    public class DC_ASSETS_EquipmentPartsIntoService : RepositoryFactory
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
                a.F_EPInId,
                a.F_IntoNumber,
                a.F_IntoDatetime,
                a.F_IntoType,
                d.F_FullName as F_UseDepartmentId,
                a.F_Remarks
                ");
                strSql.Append("  from DC_ASSETS_EquipmentPartsInto a left join LR_Base_Department d on a.F_UseDepartmentId=d.F_DepartmentId");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["F_IntoNumber"].IsEmpty())
                {
                    dp.Add("F_IntoNumber", "%" + queryParam["F_IntoNumber"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_IntoNumber Like @F_IntoNumber ");
                }
                if (!queryParam["F_IntoType"].IsEmpty())
                {
                    dp.Add("F_IntoType", queryParam["F_IntoType"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_IntoType = @F_IntoType ");
                }
                if (!queryParam["F_UseDepartmentId"].IsEmpty())
                {
                    dp.Add("F_UseDepartmentId", queryParam["F_UseDepartmentId"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_UseDepartmentId = @F_UseDepartmentId ");
                }
                DataTable dt = this.BaseRepository().FindTable(strSql.ToString(), dp);
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("F_IntoType", "AssetPartIntoType");
              
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
        public IEnumerable<DC_ASSETS_EquipmentPartsIntoEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_EPInId,
                t.F_IntoNumber,
                t.F_IntoDatetime,
                t.F_IntoType,
                t.F_UseDepartmentId,
                t.F_Remarks
                ");
                strSql.Append("  FROM DC_ASSETS_EquipmentPartsInto t ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["F_IntoNumber"].IsEmpty())
                {
                    dp.Add("F_IntoNumber", "%" + queryParam["F_IntoNumber"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_IntoNumber Like @F_IntoNumber ");
                }
                if (!queryParam["F_IntoType"].IsEmpty())
                {
                    dp.Add("F_IntoType", queryParam["F_IntoType"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_IntoType = @F_IntoType ");
                }
                if (!queryParam["F_UseDepartmentId"].IsEmpty())
                {
                    dp.Add("F_UseDepartmentId", queryParam["F_UseDepartmentId"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_UseDepartmentId = @F_UseDepartmentId ");
                }
                return this.BaseRepository().FindList<DC_ASSETS_EquipmentPartsIntoEntity>(strSql.ToString(), dp, pagination);
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
        public List<DeviceDetailModel> GetDetail(string keyValue)
        {
            var data = base.BaseRepository().FindList<DC_ASSETS_EquipmentPartsIntoDetailEntity>(c => c.F_EPInId == keyValue);
            List<DeviceDetailModel> list = new List<DeviceDetailModel>();
            foreach (var item in data)
            {
                var deviceData = this.BaseRepository().FindEntity<DC_ASSETS_EquipmentPartsInfoEntity>(c => c.F_EPIId == item.F_EPIId);

                int currentNum = deviceData.F_InitialInventory;
                int decNum = Convert.ToInt32(this.BaseRepository().FindObject("select sum(F_OutNum) from [DC_ASSETS_EquipmentPartsOutDetail] where F_EPIId='"+ item.F_EPIId + "'") ?? 0);
                int incNum = Convert.ToInt32(this.BaseRepository().FindObject("select sum(F_IntoNum)  from [DC_ASSETS_EquipmentPartsIntoDetail] where F_EPIId='" + item.F_EPIId + "'") ?? 0);
                DeviceDetailModel model = new DeviceDetailModel()
                {
                    code = deviceData.F_PartsCode,
                    currentNum = currentNum+incNum-decNum,
                    initNum = deviceData.F_InitialInventory,
                    name = deviceData.F_PartsName,
                    num = item.F_IntoNum,
                    type = deviceData.F_SpecificationType
                };
                list.Add(model);
            }
            return list;
        }
        /// <summary>
        /// 获取DC_ASSETS_EquipmentPartsIntoDetail表数据
        /// <summary>
        /// <returns></returns>
        public IEnumerable<DC_ASSETS_EquipmentPartsIntoDetailEntity> GetDC_ASSETS_EquipmentPartsIntoDetailList(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindList<DC_ASSETS_EquipmentPartsIntoDetailEntity>(t => t.F_EPInId == keyValue);
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
        /// 获取DC_ASSETS_EquipmentPartsInto表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_ASSETS_EquipmentPartsIntoEntity GetDC_ASSETS_EquipmentPartsIntoEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_ASSETS_EquipmentPartsIntoEntity>(keyValue);
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
        /// 获取DC_ASSETS_EquipmentPartsIntoDetail表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_ASSETS_EquipmentPartsIntoDetailEntity GetDC_ASSETS_EquipmentPartsIntoDetailEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_ASSETS_EquipmentPartsIntoDetailEntity>(t => t.F_EPInId == keyValue);
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
            var db = this.BaseRepository().BeginTrans();
            try
            {
                var dC_ASSETS_EquipmentPartsIntoEntity = GetDC_ASSETS_EquipmentPartsIntoEntity(keyValue);
                db.Delete<DC_ASSETS_EquipmentPartsIntoEntity>(t => t.F_EPInId == keyValue);
                db.Delete<DC_ASSETS_EquipmentPartsIntoDetailEntity>(t => t.F_EPInId == dC_ASSETS_EquipmentPartsIntoEntity.F_EPInId);
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

        /// <summary>
        /// 保存实体数据（新增、修改）
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public void SaveEntity(string keyValue, DC_ASSETS_EquipmentPartsIntoEntity entity, List<DC_ASSETS_EquipmentPartsIntoDetailEntity> dC_ASSETS_EquipmentPartsIntoDetailList)
        {
            var db = this.BaseRepository().BeginTrans();
            try
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    var dC_ASSETS_EquipmentPartsIntoEntityTmp = GetDC_ASSETS_EquipmentPartsIntoEntity(keyValue);
                    entity.Modify(keyValue);
                    db.Update(entity);
                    db.Delete<DC_ASSETS_EquipmentPartsIntoDetailEntity>(t => t.F_EPInId == dC_ASSETS_EquipmentPartsIntoEntityTmp.F_EPInId);
                    foreach (DC_ASSETS_EquipmentPartsIntoDetailEntity item in dC_ASSETS_EquipmentPartsIntoDetailList)
                    {
                        item.Create();
                        item.F_EPInId = dC_ASSETS_EquipmentPartsIntoEntityTmp.F_EPInId;
                        db.Insert(item);
                    }
                }
                else
                {
                    entity.Create();
                    db.Insert(entity);
                    foreach (DC_ASSETS_EquipmentPartsIntoDetailEntity item in dC_ASSETS_EquipmentPartsIntoDetailList)
                    {
                        item.Create();
                        item.F_EPInId = entity.F_EPInId;
                        db.Insert(item);
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
