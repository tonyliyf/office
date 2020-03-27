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
    /// 日 期：2019-02-15 13:51
    /// 描 述：DC_ASSETS_EquipmentPartsOut
    /// </summary>
    public class DC_ASSETS_EquipmentPartsOutService : RepositoryFactory
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
                t.F_EPOId,
                t.F_OutNumber,
                t.F_OutDatetime,
                t.F_OutType,
                d.F_FullName as F_UseDepartmentId,
                t.F_Remarks
                ");
                strSql.Append("  FROM DC_ASSETS_EquipmentPartsOut t left join LR_Base_Department d on t.F_UseDepartmentId = d.F_DepartmentId");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["F_OutNumber"].IsEmpty())
                {
                    dp.Add("F_OutNumber", "%" + queryParam["F_OutNumber"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_OutNumber Like @F_OutNumber ");
                }
                if (!queryParam["F_OutType"].IsEmpty())
                {
                    dp.Add("F_OutType", queryParam["F_OutType"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_OutType = @F_OutType ");
                }
                if (!queryParam["F_UseDepartmentId"].IsEmpty())
                {
                    dp.Add("F_UseDepartmentId", queryParam["F_UseDepartmentId"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_UseDepartmentId = @F_UseDepartmentId ");
                }
                DataTable dt = this.BaseRepository().FindTable(strSql.ToString(), dp);
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("F_OutType", "AssetPartOutType");
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
        public IEnumerable<DC_ASSETS_EquipmentPartsOutEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_EPOId,
                t.F_OutNumber,
                t.F_OutDatetime,
                t.F_OutType,
                t.F_UseDepartmentId,
                t.F_Remarks
                ");
                strSql.Append("  FROM DC_ASSETS_EquipmentPartsOut t ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["F_OutNumber"].IsEmpty())
                {
                    dp.Add("F_OutNumber", "%" + queryParam["F_OutNumber"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_OutNumber Like @F_OutNumber ");
                }
                if (!queryParam["F_OutType"].IsEmpty())
                {
                    dp.Add("F_OutType", queryParam["F_OutType"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_OutType = @F_OutType ");
                }
                if (!queryParam["F_UseDepartmentId"].IsEmpty())
                {
                    dp.Add("F_UseDepartmentId", queryParam["F_UseDepartmentId"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_UseDepartmentId = @F_UseDepartmentId ");
                }
                return this.BaseRepository().FindList<DC_ASSETS_EquipmentPartsOutEntity>(strSql.ToString(), dp, pagination);
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
        /// 获取DC_ASSETS_EquipmentPartsOutDetail表数据
        /// <summary>
        /// <returns></returns>
        public IEnumerable<DC_ASSETS_EquipmentPartsOutDetailEntity> GetDC_ASSETS_EquipmentPartsOutDetailList(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindList<DC_ASSETS_EquipmentPartsOutDetailEntity>(t => t.F_EPOId == keyValue);
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
        /// 获取DC_ASSETS_EquipmentPartsOut表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_ASSETS_EquipmentPartsOutEntity GetDC_ASSETS_EquipmentPartsOutEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_ASSETS_EquipmentPartsOutEntity>(keyValue);
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
        /// 获取DC_ASSETS_EquipmentPartsOutDetail表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_ASSETS_EquipmentPartsOutDetailEntity GetDC_ASSETS_EquipmentPartsOutDetailEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_ASSETS_EquipmentPartsOutDetailEntity>(t => t.F_EPOId == keyValue);
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
                var dC_ASSETS_EquipmentPartsOutEntity = GetDC_ASSETS_EquipmentPartsOutEntity(keyValue);
                db.Delete<DC_ASSETS_EquipmentPartsOutEntity>(t => t.F_EPOId == keyValue);
                db.Delete<DC_ASSETS_EquipmentPartsOutDetailEntity>(t => t.F_EPOId == dC_ASSETS_EquipmentPartsOutEntity.F_EPOId);
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
        public bool SaveEntity(string keyValue, DC_ASSETS_EquipmentPartsOutEntity entity, List<DC_ASSETS_EquipmentPartsOutDetailEntity> dC_ASSETS_EquipmentPartsOutDetailList)
        {
            var db = this.BaseRepository().BeginTrans();
            try
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    var dC_ASSETS_EquipmentPartsOutEntityTmp = GetDC_ASSETS_EquipmentPartsOutEntity(keyValue);
                    entity.Modify(keyValue);
                    db.Update(entity);
                    db.Delete<DC_ASSETS_EquipmentPartsOutDetailEntity>(t => t.F_EPOId == dC_ASSETS_EquipmentPartsOutEntityTmp.F_EPOId);
                    foreach (DC_ASSETS_EquipmentPartsOutDetailEntity item in dC_ASSETS_EquipmentPartsOutDetailList)
                    {
                        item.Create();
                        item.F_EPOId = dC_ASSETS_EquipmentPartsOutEntityTmp.F_EPOId;
                        db.Insert(item);
                    }
                }
                else
                {
                    entity.Create();
                    db.Insert(entity);
                    foreach (DC_ASSETS_EquipmentPartsOutDetailEntity item in dC_ASSETS_EquipmentPartsOutDetailList)
                    {
                        var deviceData = this.BaseRepository().FindEntity<DC_ASSETS_EquipmentPartsInfoEntity>(c => c.F_EPIId == item.F_EPIId);
                        int currentNum = deviceData.F_InitialInventory;
                        int decNum = Convert.ToInt32(this.BaseRepository().FindObject("select sum(F_OutNum) from [DC_ASSETS_EquipmentPartsOutDetail] where F_EPIId='" + item.F_EPIId + "'") ?? 0);
                        int incNum = Convert.ToInt32(this.BaseRepository().FindObject("select sum(F_IntoNum)  from [DC_ASSETS_EquipmentPartsIntoDetail] where F_EPIId='" + item.F_EPIId + "'") ?? 0);
                        if (currentNum - decNum + incNum < item.F_OutNum)
                        {
                            db.Rollback();
                            return false;
                        }
                        item.Create();
                        item.F_EPOId = entity.F_EPOId;
                        db.Insert(item);
                    }
                }
                db.Commit();
                return true;
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
        public List<DeviceDetailModel> GetDetail(string keyValue)
        {
            var data = base.BaseRepository().FindList<DC_ASSETS_EquipmentPartsOutDetailEntity>(c => c.F_EPOId == keyValue);
            List<DeviceDetailModel> list = new List<DeviceDetailModel>();
            foreach (var item in data)
            {
                var deviceData = this.BaseRepository().FindEntity<DC_ASSETS_EquipmentPartsInfoEntity>(c => c.F_EPIId == item.F_EPIId);
                int currentNum = deviceData.F_InitialInventory;
                int decNum = Convert.ToInt32(this.BaseRepository().FindObject("select sum(F_OutNum) from [DC_ASSETS_EquipmentPartsOutDetail] where F_EPIId='" + item.F_EPIId + "'") ?? 0);
                int incNum = Convert.ToInt32(this.BaseRepository().FindObject("select sum(F_IntoNum)  from [DC_ASSETS_EquipmentPartsIntoDetail] where F_EPIId='" + item.F_EPIId + "'") ?? 0);
                DeviceDetailModel model = new DeviceDetailModel()
                {
                    code = deviceData.F_PartsCode,
                    currentNum = currentNum + incNum - decNum,
                    initNum = deviceData.F_InitialInventory,
                    name = deviceData.F_PartsName,
                    num = item.F_OutNum,
                    type = deviceData.F_SpecificationType
                };
                list.Add(model);
            }
            return list;
        }
    }
}
