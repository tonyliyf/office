using Dapper;
using Learun.DataBase.Repository;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;

namespace Learun.Application.TwoDevelopment.AssetManager
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-04-23 10:20
    /// 描 述：DC_ASSETS_BusStopBillboardsRentIncome
    /// </summary>
    public class DC_ASSETS_BusStopBillboardsRentIncomeService : RepositoryFactory
    {
        #region 获取数据
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
                strSql.Append("  FROM DC_ASSETS_BusStopBillboardsRentDetail t1   where t1.F_BSBRDId='" + keyValue + "'");

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
        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_ASSETS_BusStopBillboardsRentIncomeEntity> GetPageList(Pagination pagination, string queryJson, string F_BSBRDId)
        {
            try
            {
       
      
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_HRInId,
                t.F_Year,
                t.F_YearNumber,
                t.F_ContractNumber,
                t.F_ContractSignDate,
                t.F_ActualPrice,
                t.F_CPI,
                t.F_CalculationFormula,
                t.F_PayingBank,
                t.F_PaymentAccount,
                t.F_PaymentDate
                ");
                strSql.Append("  FROM DC_ASSETS_BusStopBillboardsRentIncome t ");
                strSql.Append("  WHERE 1=1  AND t.F_BSBRDId ='"+ F_BSBRDId + "'");

                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });

                if (!queryParam["F_Year"].IsEmpty())
                {
                    dp.Add("F_Year", "%" + queryParam["F_Year"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_Year Like @F_Year ");
                }
                if (!queryParam["F_YearNumber"].IsEmpty())
                {
                    dp.Add("F_YearNumber", "%" + queryParam["F_YearNumber"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_YearNumber Like @F_YearNumber ");
                }
                if (!queryParam["F_ContractNumber"].IsEmpty())
                {
                    dp.Add("F_ContractNumber", "%" + queryParam["F_ContractNumber"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_ContractNumber Like @F_ContractNumber ");
                }
                return this.BaseRepository().FindList<DC_ASSETS_BusStopBillboardsRentIncomeEntity>(strSql.ToString(),dp, pagination);
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
        public IEnumerable<DC_ASSETS_BusStopBillboardsEntity> GetPageList1()
        {
            try
            {
                //-MM-dd"
                string time = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")).AddMonths(1).ToShortDateString().Split(' ')[0];

                 int num= DateTime.Now.Month.ToInt();

                 int num1= DateTime.Now.Day.ToInt();

                  string nowtime = "";

                if (num<10) {
                    Regex r = new Regex("/");
                     nowtime = r.Replace(time, "/0", 1);
                }
                if (num1<10) {
                    Regex r = new Regex("/");
                    nowtime = r.Replace(time, "/0", 2);
                }
                var strSql = new StringBuilder();

                strSql.Append("  SELECT  * from DC_ASSETS_BusStopBillboards where F_BSBId in(");
         
                strSql.Append("  select F_BSBId from DC_ASSETS_BusStopBillboardsRentDetail where F_BSBRDId in ");
                strSql.Append("  (select F_BSBRDId from DC_ASSETS_BusStopBillboardsRentDetail where convert(nvarchar, F_RentEndTime, 111) like '%"+ nowtime + "%')) ");
        
                return this.BaseRepository().FindList<DC_ASSETS_BusStopBillboardsEntity>(strSql.ToString());
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
        /// 获取DC_ASSETS_BusStopBillboardsRentIncome表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_ASSETS_BusStopBillboardsRentIncomeEntity GetDC_ASSETS_BusStopBillboardsRentIncomeEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_ASSETS_BusStopBillboardsRentIncomeEntity>(keyValue);
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
                this.BaseRepository().Delete<DC_ASSETS_BusStopBillboardsRentIncomeEntity>(t=>t.F_HRInId == keyValue);
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
        public void SaveEntity(string keyValue, DC_ASSETS_BusStopBillboardsRentIncomeEntity entity)
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

        /// <summary>
        /// 保存实体数据（新增、修改）
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public void SaveEntity1(DC_ASSETS_BusStopBillboardsRentDetailEntity entity)
        {
            try
            {
                    this.BaseRepository().Update(entity);

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
