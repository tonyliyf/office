using Dapper;
using Learun.Application.Organization;
using Learun.DataBase.Repository;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-02-19 15:47
    /// 描 述：DC_OA_UseHoliday
    /// </summary>
    public class DC_OA_UseHolidayService : RepositoryFactory
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<UserEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append(@"
                   select t1.F_UserId,t1.F_RealName,t1.F_JoinDate,t1.F_StartWorkDate,isnull(t2.F_UserHoliday,0) as F_Password,t1.F_DepartmentId,t1.F_CompanyId
                      from [LR_Base_User] as t1 
                      left join [DC_OA_UseHoliday] as t2
                      on t1.F_UserId=t2.F_UserId
                ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["F_DepartmentId"].IsEmpty())
                {
                    dp.Add("F_DepartmentId", queryParam["F_DepartmentId"].ToString(), DbType.String);
                    strSql.Append(" AND t1.F_DepartmentId = @F_DepartmentId ");
                }
                var list = this.BaseRepository().FindList<UserEntity>(strSql.ToString(), dp, pagination);
                var ruleList = base.BaseRepository().FindList<DC_OA_YearHolidayRuleEntity>().OrderByDescending(c => c.F_YearTop);
                foreach (var item in list)
                {
                    item.F_Account = GetTotalDaysByUserId(item.F_UserId, ruleList).ToString();
                }
                return list;
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

        public int GetTotalDaysByUserId(string userid)
        {
            var user = this.BaseRepository().FindEntity<UserEntity>(userid);
            if (user != null)
            {
                if (user.F_JoinDate.HasValue && user.F_StartWorkDate.HasValue && (DateTime.Now.AddYears(-1) >= user.F_JoinDate))
                {
                    var years = (DateTime.Now - user.F_StartWorkDate.Value).TotalDays / 365;
                    var ruleList = base.BaseRepository().FindList<DC_OA_YearHolidayRuleEntity>().OrderByDescending(c => c.F_YearTop);
                    foreach (var item in ruleList)
                    {
                        if (years > item.F_YearTop)
                        {
                            return item.F_Holiday.Value;
                        }
                    }
                }
            }
            return 0;
        }

        public int GetTotalDaysByUserId(string userid, IEnumerable<DC_OA_YearHolidayRuleEntity> ruleList)
        {
            var user = this.BaseRepository().FindEntity<UserEntity>(userid);
            if (user != null)
            {
                if (user.F_JoinDate.HasValue && user.F_StartWorkDate.HasValue && (DateTime.Now.AddYears(-1) >= user.F_JoinDate))
                {
                    var years = (DateTime.Now - user.F_StartWorkDate.Value).TotalDays / 365;
                    foreach (var item in ruleList)
                    {
                        if (years > item.F_YearTop)
                        {
                            return item.F_Holiday.Value;
                        }
                    }
                }
            }
            return 0;
        }

        public double GetUserDaysByUserId(string userid)
        {
            double days = 0;
            var entity = this.BaseRepository().FindEntity<DC_OA_UseHolidayEntity>(c => c.F_UserId == userid);
            if (entity != null && entity.F_UserHoliday.HasValue)
            {

                days = (double)entity.F_UserHoliday;
            }

            return days;

        }
        /// <summary>
        /// 获取DC_OA_UseHoliday表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public UserEntity GetDC_OA_UseHolidayEntity(string keyValue)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append(@"
                   select t1.F_UserId,t1.F_RealName,t1.F_JoinDate,t1.F_StartWorkDate, 
                       isnull(t2.F_UserHoliday,0) as F_Password,t1.F_DepartmentId,t1.F_CompanyId
                      from [LR_Base_User] as t1 
                      left join [DC_OA_UseHoliday] as t2
                      on t1.F_UserId=t2.F_UserId
                ");
                strSql.Append("  WHERE 1=1 and t1.F_UserId='" + keyValue + "'");
                var dp = new DynamicParameters(new { });
                return this.BaseRepository().FindEntity<UserEntity>(strSql.ToString(), dp);
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
                return this.BaseRepository().FindTable("   select 1,2 ");
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
        public void DeleteEntity()
        {
            try
            {
                this.BaseRepository().Delete<DC_OA_UseHolidayEntity>(t => true);
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
        public void SaveEntity(string keyValue, double days)
        {
            try
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    var entity = this.BaseRepository().FindEntity<DC_OA_UseHolidayEntity>(c => c.F_UserId == keyValue);
                    if (entity != null)
                    {
                        this.BaseRepository().ExecuteBySql("  update DC_OA_UseHoliday set F_UserHoliday=" + days + " where [F_UserId]='" + keyValue + "'");
                    }
                    else
                    {
                        entity = new DC_OA_UseHolidayEntity();
                        entity.Create();
                        entity.F_UserId = keyValue;
                        entity.F_UserHoliday = days;
                        this.BaseRepository().Insert(entity);
                    }
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
