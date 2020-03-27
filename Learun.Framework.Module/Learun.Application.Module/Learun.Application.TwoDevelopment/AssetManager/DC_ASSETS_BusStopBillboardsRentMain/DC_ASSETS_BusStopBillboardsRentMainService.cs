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
    /// 日 期：2019-03-07 11:49
    /// 描 述：广告招租
    /// </summary>
    public class DC_ASSETS_BusStopBillboardsRentMainService : RepositoryFactory
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_ASSETS_BusStopBillboardsRentMainEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_BSBRMId,
                t.F_RentYear,
                t.F_RentNumber,
                t.F_RentName,
                t.F_Unit,
                t.F_Remarks,
                t.F_Accessories
                ");
                strSql.Append("  FROM DC_ASSETS_BusStopBillboardsRentMain t ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["F_RentYear"].IsEmpty())
                {
                    dp.Add("F_RentYear", "%" + queryParam["F_RentYear"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_RentYear Like @F_RentYear ");
                }
                if (!queryParam["F_RentName"].IsEmpty())
                {
                    dp.Add("F_RentName", "%" + queryParam["F_RentName"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_RentName Like @F_RentName ");
                }
                if (!queryParam["F_Unit"].IsEmpty())
                {
                    dp.Add("F_Unit", "%" + queryParam["F_Unit"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_Unit Like @F_Unit ");
                }
                return this.BaseRepository().FindList<DC_ASSETS_BusStopBillboardsRentMainEntity>(strSql.ToString(),dp, pagination);
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
        public IEnumerable<DC_ASSETS_BusStopBillboardsRentMainEntity> GetMainList()
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_BSBRMId,
                t.F_RentYear,
                 t.F_RentName,
              
                t.F_Accessories
                ");
                strSql.Append("  FROM DC_ASSETS_BusStopBillboardsRentMain t ");
                strSql.Append("  WHERE 1=1 ");
                
                return this.BaseRepository().FindList<DC_ASSETS_BusStopBillboardsRentMainEntity>(strSql.ToString());
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
        public DataTable GetboardInfo()
        {
            try
            {
                var strSql = new StringBuilder();
          
                strSql.Append(@"
               SELECT
 top 6 m.F_RentName, m.F_CreateDatetime ,
 SUM(CASE WHEN F_LeaseState= '2'  THEN 1 ELSE 0 END) AS SuccessNumber,
 count(F_BSBRDId) totalnumber
FROM
 DC_ASSETS_BusStopBillboardsRentMain m
 JOIN DC_ASSETS_BusStopBillboardsRentDetail l ON m.F_BSBRMId = l.F_BSBRMId 

GROUP BY
 F_RentName,
 m.F_CreateDatetime 
ORDER BY
 m.F_CreateDatetime DESC
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
                t.F_BSBRMId,
                t.F_RentYear,
                t.F_RentNumber,
                t.F_RentName,
                t.F_Unit,
                t.F_Remarks,
                t.F_Accessories
                ");
                strSql.Append("  FROM DC_ASSETS_BusStopBillboardsRentMain t ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["F_RentYear"].IsEmpty())
                {
                    dp.Add("F_RentYear", "%" + queryParam["F_RentYear"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_RentYear Like @F_RentYear ");
                }
                if (!queryParam["F_RentName"].IsEmpty())
                {
                    dp.Add("F_RentName", "%" + queryParam["F_RentName"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_RentName Like @F_RentName ");
                }
                if (!queryParam["F_Unit"].IsEmpty())
                {
                    dp.Add("F_Unit", "%" + queryParam["F_Unit"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_Unit Like @F_Unit ");
                }
                DataTable dt = this.BaseRepository().FindTable(strSql.ToString(), dp);
                Dictionary<string, string> dic = new Dictionary<string, string>();
             
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
        /// 获取DC_ASSETS_BusStopBillboardsRentDetail表数据
        /// <summary>
        /// <returns></returns>
        public IEnumerable<DC_ASSETS_BusStopBillboardsRentDetailEntity> GetDC_ASSETS_BusStopBillboardsRentDetailList(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindList<DC_ASSETS_BusStopBillboardsRentDetailEntity>(t=>t.F_BSBRMId == keyValue );
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
        /// 获取DC_ASSETS_BusStopBillboardsRentMain表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_ASSETS_BusStopBillboardsRentMainEntity GetDC_ASSETS_BusStopBillboardsRentMainEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_ASSETS_BusStopBillboardsRentMainEntity>(keyValue);
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
        /// 获取DC_ASSETS_BusStopBillboardsRentDetail表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_ASSETS_BusStopBillboardsRentDetailEntity GetDC_ASSETS_BusStopBillboardsRentDetailEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_ASSETS_BusStopBillboardsRentDetailEntity>(t=>t.F_BSBRMId == keyValue);
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
                var dC_ASSETS_BusStopBillboardsRentMainEntity = GetDC_ASSETS_BusStopBillboardsRentMainEntity(keyValue); 
                db.Delete<DC_ASSETS_BusStopBillboardsRentMainEntity>(t=>t.F_BSBRMId == keyValue);
                db.Delete<DC_ASSETS_BusStopBillboardsRentDetailEntity>(t=>t.F_BSBRMId == dC_ASSETS_BusStopBillboardsRentMainEntity.F_BSBRMId);
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
        /// 获取DC_ASSETS_BusStopBillboardsRentDetail表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_ASSETS_BusStopBillboardsEntity GetDC_ASSETS_BusStopBillboardsEntity(string keyValue)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                *
                ");
                strSql.Append("  FROM DC_ASSETS_BusStopBillboards t1   where t1.F_BillboardsName='" + keyValue + "'");

                IEnumerable<DC_ASSETS_BusStopBillboardsEntity> obj = this.BaseRepository().FindList<DC_ASSETS_BusStopBillboardsEntity>(strSql.ToString());

                DC_ASSETS_BusStopBillboardsEntity num = new DC_ASSETS_BusStopBillboardsEntity();

                foreach (DC_ASSETS_BusStopBillboardsEntity ob in obj)
                {
                    num = ob;
                }


                return num;


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
        public void SaveEntity(string keyValue, DC_ASSETS_BusStopBillboardsRentMainEntity entity,List<DC_ASSETS_BusStopBillboardsRentDetailEntity> dC_ASSETS_BusStopBillboardsRentDetailList)
        {
            var db = this.BaseRepository().BeginTrans();
            try
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    var strSql = new StringBuilder();
                    strSql.Append("SELECT ");
                    strSql.Append(@"
                *
                ");
                    strSql.Append("  FROM DC_ASSETS_BusStopBillboards t1   where t1.F_BillboardsName='" + dC_ASSETS_BusStopBillboardsRentDetailList[0].F_BillboardsName + "'");

                    IEnumerable<DC_ASSETS_BusStopBillboardsEntity> obj = this.BaseRepository().FindList<DC_ASSETS_BusStopBillboardsEntity>(strSql.ToString());

                    DC_ASSETS_BusStopBillboardsEntity num = new DC_ASSETS_BusStopBillboardsEntity();

                    foreach (DC_ASSETS_BusStopBillboardsEntity ob in obj)
                    {
                        num = ob;
                    }
                    dC_ASSETS_BusStopBillboardsRentDetailList[0].F_BillboardsName = num.F_BillboardsName;
                    dC_ASSETS_BusStopBillboardsRentDetailList[0].F_BSBId = num.F_BSBId;

                    var dC_ASSETS_BusStopBillboardsRentMainEntityTmp = GetDC_ASSETS_BusStopBillboardsRentMainEntity(keyValue); 
                    entity.Modify(keyValue);
                    db.Update(entity);
                    db.Delete<DC_ASSETS_BusStopBillboardsRentDetailEntity>(t=>t.F_BSBRMId == dC_ASSETS_BusStopBillboardsRentMainEntityTmp.F_BSBRMId);
                    foreach (DC_ASSETS_BusStopBillboardsRentDetailEntity item in dC_ASSETS_BusStopBillboardsRentDetailList)
                    {
                        item.Create();
                        item.F_BSBRMId = dC_ASSETS_BusStopBillboardsRentMainEntityTmp.F_BSBRMId;
                        db.Insert(item);
                    }
                }
                else
                {
                    entity.Create();
                    db.Insert(entity);
                    foreach (DC_ASSETS_BusStopBillboardsRentDetailEntity item in dC_ASSETS_BusStopBillboardsRentDetailList)
                    {
                        item.Create();
                        item.F_BSBRMId = entity.F_BSBRMId;
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
        public DataTable StatisticsRentAmountByYear()
        {
            return this.BaseRepository().FindTable(@"
              select 
              f_year as [year],
              sum(f_actualprice) as price
              from dc_assets_busstopbillboardsrentincome
              group by f_year
            ");
        }
    }
}
