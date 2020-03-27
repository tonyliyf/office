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
    /// 日 期：2019-03-07 15:15
    /// 描 述：DC_ASSETS_BusStopBillboardsRentDetail
    /// </summary>
    public class DC_ASSETS_BusStopBillboardsRentDetailService : RepositoryFactory
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_ASSETS_BusStopBillboardsRentDetailEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t1.F_ValuationPrice,
                t1.F_RentReservePrice,
                t1.F_RentDeposit,
                t1.F_RentAge,
                t1.F_ActualPrice,
                t1.F_RentArea,
                t1.F_LeaseState,
                t1.F_TenderType,
                t1.F_RentStartTime,
                t1.F_RentEndTime,
                t1.F_RentReminder,
                t1.F_ExpireReminder,
                t1.F_Renter,
                t1.F_RenterCompany,
                t1.F_RenterPhone,
                t1.F_RenterIDNo,
                t1.F_Remarks,
                t1.F_BSBRDId,
                t1.F_BSBRMId
                ");
                strSql.Append("  FROM DC_ASSETS_BusStopBillboardsRentDetail t1 ");
                //strSql.Append("  LEFT JOIN DC_ASSETS_BusStopBillboardsRentDetail t1 ON t1.F_BSBRMId = t.F_BSBRMId ");
                strSql.Append(" where 1=1");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });

                //F_BSBRMId
                if (!queryParam["F_BSBRMId"].IsEmpty())
                {
                    dp.Add("F_BSBRMId", "%" + queryParam["F_BSBRMId"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t1.F_BSBId Like @F_BSBRMId ");
                }

                if (!queryParam["F_Renter"].IsEmpty())
                {
                    dp.Add("F_Renter", "%" + queryParam["F_Renter"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t1.F_Renter Like @F_Renter ");
                }
                if (!queryParam["F_RenterCompany"].IsEmpty())
                {
                    dp.Add("F_RenterCompany", "%" + queryParam["F_RenterCompany"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t1.F_RenterCompany Like @F_RenterCompany ");
                }
                if (!queryParam["F_TenderType"].IsEmpty())
                {
                    dp.Add("F_TenderType",queryParam["F_TenderType"].ToString(), DbType.String);
                    strSql.Append(" AND t1.F_TenderType = @F_TenderType ");
                }
                return this.BaseRepository().FindList<DC_ASSETS_BusStopBillboardsRentDetailEntity>(strSql.ToString(),dp, pagination);
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
        /// 获取已租广告合同数据
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DC_ASSETS_BusStopBillboardsRentDetailEntity> GetList()
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t1.F_ValuationPrice,
                t1.F_RentReservePrice,
                t1.F_RentDeposit,
                t1.F_RentAge,
                t1.F_ActualPrice,
                t1.F_RentArea,
                t1.F_LeaseState,
                t1.F_TenderType,
                t1.F_RentStartTime,
                t1.F_RentEndTime,
                t1.F_RentReminder,
                t1.F_ExpireReminder,
                t1.F_Renter,
                t1.F_RenterCompany,
                t1.F_RenterPhone,
                t1.F_RenterIDNo,
                t1.F_Remarks,
                t1.F_BSBRDId,
                t1.F_BSBRMId,
                b.F_BillboardsName as F_BSBId,
                b.F_InstallationLocation as F_InstallationLocation
                ");
                strSql.Append("  FROM DC_ASSETS_BusStopBillboardsRentDetail t1 left join DC_ASSETS_BusStopBillboards b on b.F_BSBId=t1.F_BSBId "); 
                strSql.Append(" where t1.F_LeaseState='2'");
             
                return this.BaseRepository().FindList<DC_ASSETS_BusStopBillboardsRentDetailEntity>(strSql.ToString());
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
        public IEnumerable<DC_ASSETS_BusStopBillboardsRentDetailEntity> GetBusStopBillboardsRentList()
        {

            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT * from DC_ASSETS_BusStopBillboardsRentDetail t1 where F_LeaseState =2 ");
              
              return this.BaseRepository().FindList<DC_ASSETS_BusStopBillboardsRentDetailEntity>(strSql.ToString());
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


        public IEnumerable<DC_ASSETS_BusStopBillboardsRentDetailEntity> GetBoardDetailList(string keyValue, string Searchvalue)
        {

            try
            {
                var strSql = new StringBuilder();
                strSql.Append(@"SELECT  t1.* ,p.F_BillboardsName,p.F_InstallationLocation,p.F_CenterpointCoordinates from DC_ASSETS_BusStopBillboardsRentDetail t1 join DC_ASSETS_BusStopBillboards p
on t1.F_BSBId = p.F_BSBId");


                strSql.Append(" where 1=1");
               // 虚拟参数
                var dp = new DynamicParameters(new { });

                //F_BSBRMId
                if (!keyValue.IsEmpty())
                {
                    dp.Add("F_BSBRMId",  keyValue, DbType.String);
                    strSql.Append(" AND t1.F_BSBRMId = @F_BSBRMId ");
                }
                if (!Searchvalue.IsEmpty())
                {
                    dp.Add("Searchvalue", "%" + Searchvalue + "%", DbType.String);
                    strSql.Append(" AND (p.F_BillboardsName like @Searchvalue or p.F_InstallationLocation like @Searchvalue) ");
                }

                SimpleLogUtil.WriteTextLog("BoardDetaillistkeyValue", keyValue, DateTime.Now);
                SimpleLogUtil.WriteTextLog("BoardDetaillistSearchvalue", Searchvalue, DateTime.Now);
                SimpleLogUtil.WriteTextLog("BoardDetaillist", strSql.ToString(), DateTime.Now);
                return this.BaseRepository().FindList<DC_ASSETS_BusStopBillboardsRentDetailEntity>(strSql.ToString(),dp);
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
                t1.F_ValuationPrice,
                t1.F_RentReservePrice,
                t1.F_RentDeposit,
                t1.F_RentAge,
                t1.F_ActualPrice,
                t1.F_RentArea,
                t1.F_LeaseState,
                t1.F_TenderType,
                t1.F_RentStartTime,
                t1.F_RentEndTime,
                t1.F_RentReminder,
                t1.F_ExpireReminder,
                t1.F_Renter,
                t1.F_RenterCompany,
                t1.F_RenterPhone,
                t1.F_RenterIDNo,
                t1.F_Remarks,
                t1.F_BSBRDId,
                t1.F_BSBRMId
                ");
                strSql.Append("  FROM DC_ASSETS_BusStopBillboardsRentDetail t1 ");
                //strSql.Append("  LEFT JOIN DC_ASSETS_BusStopBillboardsRentDetail t1 ON t1.F_BSBRMId = t.F_BSBRMId ");
                strSql.Append(" where 1=1");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });

                //F_BSBRMId
                if (!queryParam["F_BSBRMId"].IsEmpty())
                {
                    dp.Add("F_BSBRMId", "%" + queryParam["F_BSBRMId"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t1.F_BSBRMId Like @F_BSBRMId ");
                }

                if (!queryParam["F_Renter"].IsEmpty())
                {
                    dp.Add("F_Renter", "%" + queryParam["F_Renter"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t1.F_Renter Like @F_Renter ");
                }
                if (!queryParam["F_RenterCompany"].IsEmpty())
                {
                    dp.Add("F_RenterCompany", "%" + queryParam["F_RenterCompany"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t1.F_RenterCompany Like @F_RenterCompany ");
                }
                if (!queryParam["F_TenderType"].IsEmpty())
                {
                    dp.Add("F_TenderType", queryParam["F_TenderType"].ToString(), DbType.String);
                    strSql.Append(" AND t1.F_TenderType = @F_TenderType ");
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
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                c.F_BillboardsName as F_BSBId,
                t1.F_ValuationPrice,
                t1.F_RentReservePrice,
                t1.F_RentDeposit,
                t1.F_RentAge,
                t1.F_ActualPrice,
                t1.F_RentArea,
                t1.F_LeaseState,
                t1.F_TenderType,
                t1.F_RentStartTime,
                t1.F_RentEndTime,
                t1.F_RentReminder,
                t1.F_ExpireReminder,
                t1.F_Renter,
                t1.F_RentReminderDate,
                t1.F_ExpireReminderDate,
                t1.F_RenterCompany,
                t1.F_RenterPhone,
                t1.F_RenterIDNo,
                t1.F_Remarks,
                t1.F_BSBRDId,
                t1.F_BSBRMId
                ");
                strSql.Append("  FROM DC_ASSETS_BusStopBillboardsRentDetail t1  left join DC_ASSETS_BusStopBillboards c on t1.F_BSBId=c.F_BSBId  where t1.F_BSBRDId='" + keyValue+"'");

                IEnumerable < DC_ASSETS_BusStopBillboardsRentDetailEntity > obj = this.BaseRepository().FindList<DC_ASSETS_BusStopBillboardsRentDetailEntity>(strSql.ToString());

                DC_ASSETS_BusStopBillboardsRentDetailEntity num = new DC_ASSETS_BusStopBillboardsRentDetailEntity();

                foreach (DC_ASSETS_BusStopBillboardsRentDetailEntity ob in obj) {
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
        /// 获取DC_ASSETS_BusStopBillboardsRentDetail表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_ASSETS_BusStopBillboardsRentDetailEntity GetDC_ASSETS_BusStopBillboardsRentDetailEntity1(string keyValue)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                 t1.F_BSBId,
                t1.F_ValuationPrice,
                t1.F_RentReservePrice,
                t1.F_RentDeposit,
                t1.F_RentAge,
                t1.F_ActualPrice,
                t1.F_RentArea,
                t1.F_LeaseState,
                t1.F_TenderType,
                t1.F_RentStartTime,
                t1.F_RentEndTime,
                t1.F_RentReminder,
                t1.F_ExpireReminder,
                t1.F_Renter,
                t1.F_RentReminderDate,
                t1.F_ExpireReminderDate,
                t1.F_RenterCompany,
                t1.F_RenterPhone,
                t1.F_RenterIDNo,
                t1.F_Remarks,
                t1.F_BSBRDId,
                t1.F_BSBRMId
                ");
                strSql.Append("  FROM DC_ASSETS_BusStopBillboardsRentDetail t1    where t1.F_BSBRDId='" + keyValue + "'");

                IEnumerable<DC_ASSETS_BusStopBillboardsRentDetailEntity> obj = this.BaseRepository().FindList<DC_ASSETS_BusStopBillboardsRentDetailEntity>(strSql.ToString());

                DC_ASSETS_BusStopBillboardsRentDetailEntity num = new DC_ASSETS_BusStopBillboardsRentDetailEntity();

                foreach (DC_ASSETS_BusStopBillboardsRentDetailEntity ob in obj)
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
        //DC_ASSETS_BusStopBillboardsEntity
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
        /// 获取树形数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetSqlTree()
        {
            try
            {
                return this.BaseRepository().FindTable(" SELECT distinct F_Transferor as id , '' as  pid , F_Transferor as name from DC_ASSETS_LandBaseInfo GROUP BY F_Assignee,F_Transferor union SELECT  f_lbiid as id, F_Transferor as pid, F_LandName as name from DC_ASSETS_LandBaseInfo GROUP BY f_lbiid, F_LandName, F_Assignee, F_Transferor  ");
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
        /// 保存实体数据（新增、修改）
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public void SaveEntity(string keyValue, DC_ASSETS_BusStopBillboardsRentMainEntity entity,DC_ASSETS_BusStopBillboardsRentDetailEntity dC_ASSETS_BusStopBillboardsRentDetailEntity)
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
                    strSql.Append("  FROM DC_ASSETS_BusStopBillboards t1   where t1.F_BSBId='" + dC_ASSETS_BusStopBillboardsRentDetailEntity.F_BSBId + "'");

                    IEnumerable<DC_ASSETS_BusStopBillboardsEntity> obj = this.BaseRepository().FindList<DC_ASSETS_BusStopBillboardsEntity>(strSql.ToString());

                    DC_ASSETS_BusStopBillboardsEntity num = new DC_ASSETS_BusStopBillboardsEntity();

                    foreach (DC_ASSETS_BusStopBillboardsEntity ob in obj)
                    {
                        num = ob;
                    }
                    dC_ASSETS_BusStopBillboardsRentDetailEntity.F_BSBId = num.F_BSBId;
                    dC_ASSETS_BusStopBillboardsRentDetailEntity.F_BillboardsName = num.F_BillboardsName;

                     var dC_ASSETS_BusStopBillboardsRentMainEntityTmp = GetDC_ASSETS_BusStopBillboardsRentMainEntity(keyValue); 

                    entity.Modify(keyValue);
                    db.Update(entity);
                    db.Delete<DC_ASSETS_BusStopBillboardsRentDetailEntity>(t=>t.F_BSBRMId == dC_ASSETS_BusStopBillboardsRentMainEntityTmp.F_BSBRMId);
                    dC_ASSETS_BusStopBillboardsRentDetailEntity.Create();
                    dC_ASSETS_BusStopBillboardsRentDetailEntity.F_BSBRMId = dC_ASSETS_BusStopBillboardsRentMainEntityTmp.F_BSBRMId;
                    db.Insert(dC_ASSETS_BusStopBillboardsRentDetailEntity);
                }
                else
                {
                    entity.Create();
                    dC_ASSETS_BusStopBillboardsRentDetailEntity.Create();
                    dC_ASSETS_BusStopBillboardsRentDetailEntity.F_BSBRMId = entity.F_BSBRMId;
                    db.Insert(dC_ASSETS_BusStopBillboardsRentDetailEntity);
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
