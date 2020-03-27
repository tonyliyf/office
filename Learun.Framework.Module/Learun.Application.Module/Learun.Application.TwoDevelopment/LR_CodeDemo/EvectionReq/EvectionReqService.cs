using Dapper;
using Learun.DataBase.Repository;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-02-10 14:28
    /// 描 述：EvectionReq
    /// </summary>
    public class EvectionReqService : RepositoryFactory
    {
        #region 构造函数和属性

        private string fieldSql;
        public EvectionReqService()
        {
            fieldSql=@"
                t.F_Id,
                t.F_Title,
                t.F_Degree,
                t.F_Name,
                t.F_Dept,
                t.F_ApplyDate,
                t.F_OutType,
                t.F_StartDate,
                t.F_EndDate,
                t.F_OutDays,
                t.F_OutReason,
                t.F_IsBorrow,
                t.F_BorrowMoney,
                t.F_ReturnDate,
                t.F_Customer,
                t.F_CustManager,
                t.F_ContractId,
                t.F_Project,
                t.F_ProjManager,
                t.F_File,
                t.F_Process,
                t.F_Opinion,
                t.F_UserId,
                t.F_CompanyId,
                t.Is_agree
            ";
        }
        #endregion

        #region 获取数据

        /// <summary>
        /// 获取列表数据
        /// <summary>
        /// <returns></returns>
        public IEnumerable<EvectionReqEntity> GetList( string queryJson )
        {
            try
            {
                //参考写法
                //var queryParam = queryJson.ToJObject();
                // 虚拟参数
                //var dp = new DynamicParameters(new { });
                //dp.Add("startTime", queryParam["StartTime"].ToDate(), DbType.DateTime);
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(fieldSql);
                strSql.Append(" FROM EvectionReq t ");
                return this.BaseRepository( ).FindList<EvectionReqEntity>(strSql.ToString());
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



        public IEnumerable<EvectionReqEntity> GetList(DateTime dtStart, DateTime dtEnd)
        {
            try
            {
                //参考写法
                //var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                //dp.Add("startTime", queryParam["StartTime"].ToDate(), DbType.DateTime);
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(fieldSql);
                strSql.Append(" FROM EvectionReq t where Is_agree =2 ");

                if (!dtStart.IsEmpty() && !dtEnd.IsEmpty())
                {
                    dp.Add("startTime", dtStart, DbType.DateTime);
                    dp.Add("endTime", dtEnd, DbType.DateTime);
                    strSql.Append(" and  (( t.F_StartDate >= @startTime AND t.F_StartDate < @endTime)or( t.F_EndDate >= @startTime AND t.F_EndDate < @endTime)) ");
                }
                return this.BaseRepository( ).FindList<EvectionReqEntity>(strSql.ToString(),dp);
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
        /// 获取列表分页数据
        /// <param name="pagination">分页参数</param>
        /// <summary>
        /// <returns></returns>
        public IEnumerable<EvectionReqEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(fieldSql);
                strSql.Append(" FROM EvectionReq t ");
                return this.BaseRepository( ).FindList<EvectionReqEntity>(strSql.ToString(), pagination);
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
        /// 获取实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public EvectionReqEntity GetEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository( ).FindEntity<EvectionReqEntity>(keyValue);
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
                this.BaseRepository( ).Delete<EvectionReqEntity>(t=>t.F_Id == keyValue);
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
        public void SaveEntity(string keyValue, EvectionReqEntity entity)
        {
            try
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    entity.Modify(keyValue);
                    this.BaseRepository( ).Update(entity);
                }
                else
                {
                    entity.Create();
                    this.BaseRepository( ).Insert(entity);
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
