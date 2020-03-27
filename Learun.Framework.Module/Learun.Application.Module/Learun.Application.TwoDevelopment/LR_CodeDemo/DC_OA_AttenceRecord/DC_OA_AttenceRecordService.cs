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
    /// 日 期：2019-01-26 16:32
    /// 描 述：打卡记录
    /// </summary>
    public class DC_OA_AttenceRecordService : RepositoryFactory
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表分页数据
        /// <summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_OA_AttenceRecordEntity> GetPageList(Pagination pagination, string queryJson)
        {

            string time = "";

            string Month = DateTime.Now.Month.ToString();

            if (Convert.ToInt32(Month) < 10)
            {
                time = DateTime.Now.Year.ToString() + "-0" + DateTime.Now.Month.ToString();
            }
            else {
                time = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString();
            }
            UserInfo userInfo = LoginUserInfo.Get();
           

            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                F_CreateUserName,
                DC_OA_AttenceDate,
                DC_OA_AttenceDateTime,
                F_Description,
                F_OA_RepairType,
                F_GpsLocation,
                F_RecordFrom
                ");
                strSql.Append("  FROM DC_OA_AttenceRecord  ");
                strSql.Append("  WHERE F_CreateUserId='"+ userInfo.userId + "' and DC_OA_AttenceDate like '%"+ time + "%' ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
               return this.BaseRepository().FindList<DC_OA_AttenceRecordEntity>(strSql.ToString(),dp, pagination);
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


        public IEnumerable<DC_OA_AttenceRecordEntity> GetMyPageList(UserInfo userInfo,Pagination pagination, string queryJson)
        {

            string time = DateTime.Now.ToString("yyyy-MM");

            //string Month = DateTime.Now.Month.ToString();
            
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                F_CreateUserName,
                DC_OA_AttenceDate,
                DC_OA_AttenceDateTime,
                F_Description,
                F_OA_RepairType,
                F_GpsLocation,
                F_RecordFrom
                ");
                strSql.Append("  FROM DC_OA_AttenceRecord  ");
                strSql.Append("  WHERE  F_CreateUserId='" + userInfo.userId + "' and DC_OA_AttenceDate like '%" + time + "%' ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
               // var dp = new DynamicParameters(new { });
                return this.BaseRepository().FindList<DC_OA_AttenceRecordEntity>(strSql.ToString(),null, pagination);
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



        public DataTable GetList(Pagination pagination, string queryJson)
        {

            string time = "";

            string Month = DateTime.Now.Month.ToString();

            if (Convert.ToInt32(Month) < 10)
            {
                time = DateTime.Now.Year.ToString() + "-0" + DateTime.Now.Month.ToString();
            }
            else
            {
                time = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString();
            }
            UserInfo userInfo = LoginUserInfo.Get();


            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@" 
                f_createusername,
                dc_oa_attencedate,
                dc_oa_attencedatetime,
                f_oa_repairtype,
                f_description,
                f_enabledmark,
                DC_OA_AttenceRecordId
                                 
                ");
                strSql.Append("  FROM DC_OA_AttenceRecord  ");
                strSql.Append("  WHERE F_CreateUserId='" + userInfo.userId + "' and DC_OA_AttenceDate like '%" + time + "%' ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                return this.BaseRepository().FindTable(strSql.ToString(), dp, pagination);
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
        public IEnumerable<DC_OA_AttenceRecordEntity> GetList(string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.DC_OA_AttenceRecordId,
                t.F_Description
                ");
                strSql.Append("  FROM DC_OA_AttenceRecord t ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                return this.BaseRepository().FindList<DC_OA_AttenceRecordEntity>(strSql.ToString(),dp);
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
        public IEnumerable<DC_OA_AttenceRecordEntity> GetList(DateTime dtStart, DateTime dtEnd)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.DC_OA_AttenceRecordId,
                t.F_Description
                ");
                strSql.Append("  FROM DC_OA_AttenceRecord t ");
                strSql.Append("  WHERE F_EnabledMark =1 and F_OA_RepairType is not null ");

               // 虚拟参数
                var dp = new DynamicParameters(new { });

                if (!dtStart.IsEmpty() && !dtEnd.IsEmpty())
                {
                    dp.Add("startTime", dtStart, DbType.DateTime);
                    dp.Add("endTime", dtEnd, DbType.DateTime);
                    strSql.Append(" AND ( t.DC_OA_AttenceDate >= @startTime AND t.DC_OA_AttenceDate < @endTime) ");
                }
                return this.BaseRepository().FindList<DC_OA_AttenceRecordEntity>(strSql.ToString(), dp);
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
        /// 获取DC_OA_AttenceRecord表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_OA_AttenceRecordEntity GetDC_OA_AttenceRecordEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_OA_AttenceRecordEntity>(keyValue);
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
                this.BaseRepository().Delete<DC_OA_AttenceRecordEntity>(t=>t.DC_OA_AttenceRecordId == keyValue);
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
        public void SaveEntity( UserInfo userInfo, string keyValue, DC_OA_AttenceRecordEntity entity)
        {
            try
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    entity.Modify(keyValue,userInfo);
                    this.BaseRepository().Update(entity);
                }
                else
                {
                    entity.Create(userInfo);
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
        public void SaveEntity( DC_OA_AttenceRecordEntity entity)
        {
            try
            {
                                 
                    this.BaseRepository().Insert(entity);
             
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
