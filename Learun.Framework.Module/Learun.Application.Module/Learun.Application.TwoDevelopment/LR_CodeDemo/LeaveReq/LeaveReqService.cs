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
    /// 日 期：2019-02-10 14:12
    /// 描 述：LeaveReq
    /// </summary>
    public class LeaveReqService : RepositoryFactory
    {
        #region 构造函数和属性

        private string fieldSql;
        public LeaveReqService()
        {
            fieldSql=@"
                t.F_Id,
                t.F_Title,
                t.F_Degree,
                t.F_Name,
                t.F_Dept,
                t.F_Branch,
                t.F_ApplyDate,
                t.F_LeaveType,
                t.F_StartDate,
                t.F_EndDate,
                t.F_LeaveDays,
                t.F_RemainDays,
                t.F_LeaveReason,
                t.F_Opinion,
                t.Is_agree
            ";
        }
        #endregion

        #region 获取数据

        /// <summary>
        /// 获取列表数据
        /// <summary>
        /// <returns></returns>
        public IEnumerable<LeaveReqEntity> GetList( string queryJson )
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
                strSql.Append(" FROM LeaveReq t ");
                return this.BaseRepository( ).FindList<LeaveReqEntity>(strSql.ToString());
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


        public IEnumerable<LeaveReqEntity> GetList(DateTime dtStart, DateTime dtEnd)
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
                strSql.Append(" *   ");
                strSql.Append(" FROM LeaveReq t where Is_agree =2 ");

                if (!dtStart.IsEmpty() && !dtEnd.IsEmpty())
                {
                    dp.Add("startTime", dtStart,DbType.DateTime);
                    dp.Add("endTime", dtEnd, DbType.DateTime);
                    strSql.Append(" AND (( t.F_StartDate >= @startTime AND t.F_StartDate < @endTime)or( t.F_EndDate >= @startTime AND t.F_EndDate < @endTime)) ");
                }
                return this.BaseRepository( ).FindList<LeaveReqEntity>(strSql.ToString(),dp);
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
        public IEnumerable<LeaveReqEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(fieldSql);
                strSql.Append(" FROM LeaveReq t ");
                return this.BaseRepository( ).FindList<LeaveReqEntity>(strSql.ToString(), pagination);
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
        public LeaveReqEntity GetEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository( ).FindEntity<LeaveReqEntity>(keyValue);
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
                this.BaseRepository( ).Delete<LeaveReqEntity>(t=>t.F_Id == keyValue);
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
        public void SaveEntity(string keyValue, LeaveReqEntity entity)
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
