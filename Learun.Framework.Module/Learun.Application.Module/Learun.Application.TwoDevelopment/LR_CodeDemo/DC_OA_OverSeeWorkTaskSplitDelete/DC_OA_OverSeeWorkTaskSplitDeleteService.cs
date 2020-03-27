using Dapper;
using Learun.DataBase.Repository;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;
using Learun.Application.Message;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.0 企业敏捷开发框架
    /// Copyright (c) 2018-2019 武汉东雅图科技技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-01-08 15:54
    /// 描 述：DC_OA_OverSeeWorkTaskSplitDelete
    /// </summary>
    public class DC_OA_OverSeeWorkTaskSplitDeleteService : RepositoryFactory
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_OA_OverSeeWorkTaskSplitEntity> GetList(string keyValue, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.*
                ");
                strSql.Append("  FROM DC_OA_OverSeeWorkTaskSplit t ");
                strSql.Append("  WHERE 1=1 and t.F_OSWId=@F_OSWId order by F_code");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                dp.Add("F_OSWId", keyValue, DbType.String);
                return this.BaseRepository().FindList<DC_OA_OverSeeWorkTaskSplitEntity>(strSql.ToString(), dp);
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
        public IEnumerable<DC_OA_OverSeeWorkTaskSplitEntity> GetListEx(string keyValue, string queryJson)
        {
            try
            {
                UserInfo user = LoginUserInfo.Get();
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.*
                ");
                strSql.Append("  FROM DC_OA_OverSeeWorkTaskSplit t ");
                strSql.Append("  WHERE 1=1 and t.F_OSWId=@F_OSWId ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                dp.Add("F_OSWId", keyValue, DbType.String);
                if (user.userId != "System")
                {
                    dp.Add("F_OneUserId", "%"+user.userId+"%", DbType.String);
                    strSql.Append(" and t.F_OneUserId like @F_OneUserId");
                }
                strSql.Append(" order by F_code");
                return this.BaseRepository().FindList<DC_OA_OverSeeWorkTaskSplitEntity>(strSql.ToString(), dp);
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
        /// 获取DC_OA_OverSeeWorkTaskSplit表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_OA_OverSeeWorkTaskSplitEntity GetDC_OA_OverSeeWorkTaskSplitEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_OA_OverSeeWorkTaskSplitEntity>(keyValue);
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
                var result = this.BaseRepository().FindList<DC_OA_OverSeeWorkTaskSplitEntity>(c => c.F_ParentId == keyValue);
                foreach (var item in result)
                {
                    this.BaseRepository().Delete<DC_OA_OverSeeWorkTaskSplitEntity>(item);
                }
                this.BaseRepository().Delete<DC_OA_OverSeeWorkTaskSplitEntity>(t => t.F_SecondId == keyValue);
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
        public void SaveEntity(string keyValue, DC_OA_OverSeeWorkTaskSplitEntity entity)
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

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_OA_OverSeeWorkTaskSplitEntity> GetList(string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.*
                ");
                strSql.Append("  FROM DC_OA_OverSeeWorkTaskSplit t ");
                strSql.Append("  WHERE (t.F_ParentId is null or t.F_ParentId='')");
                var dp = new DynamicParameters(new { });
                var queryParam = queryJson.ToJObject();
                if (!queryParam["F_OSWId"].IsEmpty())
                {
                    dp.Add("F_OSWId", queryParam["F_OSWId"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_OSWId = @F_OSWId ");
                }
                else
                {
                    strSql.Append(" AND 1=2 ");
                }
                strSql.Append(" order by t.F_code ");
                // 虚拟参数
                return this.BaseRepository().FindList<DC_OA_OverSeeWorkTaskSplitEntity>(strSql.ToString(), dp);
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

        public DataTable GetNoticeMembersData(string keyValue, out string noticeContent)
        {
            var entity = this.BaseRepository().FindEntity<DC_OA_OverSeeWorkTaskSplitEntity>(keyValue);
            List<string> userList = new List<string>();
            if (!string.IsNullOrWhiteSpace(entity.F_OneUserId))
            {
                userList.Add(entity.F_OneUserId);
            }
            if (!string.IsNullOrWhiteSpace(entity.F_OneLeaderId))
            {
                userList.Add(entity.F_OneLeaderId);
            }
            if (!string.IsNullOrWhiteSpace(entity.F_TwoUserId))
            {
                string[] arr = entity.F_TwoUserId.Split(',');
                userList.AddRange(arr);
            }
            userList = userList.Distinct().ToList();
            StringBuilder inCondition = new StringBuilder();
            userList.ForEach(s => { inCondition.Append("'" + s + "',"); });
            string strInCondition = inCondition.ToString();
            if (strInCondition.Length > 0)
            {
                strInCondition = strInCondition.Substring(0, strInCondition.Length - 1);
            }
            string sql = "  select f_realname as text,f_userid as value from LR_Base_User where f_userid in (" + strInCondition + ")";
            noticeContent = entity.F_TaskName;
            return this.BaseRepository().FindTable(sql);
        }
    }
}
