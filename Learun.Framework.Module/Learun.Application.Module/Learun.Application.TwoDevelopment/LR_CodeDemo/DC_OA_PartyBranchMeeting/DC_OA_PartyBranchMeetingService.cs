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
    /// 日 期：2019-01-17 22:13
    /// 描 述：党员会议通知
    /// </summary>
    public class DC_OA_PartyBranchMeetingService : RepositoryFactory
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_OA_PartyBranchMeetingEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_PartyBranchMeetingGUID,
                t.F_PartyBranchGUID,
                t.F_MeetingTimeStart,
                t.F_MeetingSummary,
                t.F_MeetingDoc,
                t.F_Attachments,
                t.F_MeetingPlaceId,
                t.F_MeetingCompereCode,
                t.F_MeetingConventionerId
                ");
                strSql.Append("  FROM DC_OA_PartyBranchMeeting t ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["StartTime"].IsEmpty() && !queryParam["EndTime"].IsEmpty())
                {
                    dp.Add("startTime", queryParam["StartTime"].ToDate(), DbType.DateTime);
                    dp.Add("endTime", queryParam["EndTime"].ToDate(), DbType.DateTime);
                    strSql.Append(" AND ( t.F_MeetingTimeStart >= @startTime AND t.F_MeetingTimeStart <= @endTime ) ");
                }
                if (!queryParam["F_PartyBranchGUID"].IsEmpty())
                {
                    dp.Add("F_PartyBranchGUID",queryParam["F_PartyBranchGUID"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_PartyBranchGUID = @F_PartyBranchGUID ");
                }
                if (!queryParam["F_MeetingSummary"].IsEmpty())
                {
                    dp.Add("F_MeetingSummary", "%" + queryParam["F_MeetingSummary"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_MeetingSummary Like @F_MeetingSummary ");
                }
                return this.BaseRepository().FindList<DC_OA_PartyBranchMeetingEntity>(strSql.ToString(),dp, pagination);
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
        /// 获取DC_OA_PartyBranchMeeting表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_OA_PartyBranchMeetingEntity GetDC_OA_PartyBranchMeetingEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_OA_PartyBranchMeetingEntity>(keyValue);
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
                return this.BaseRepository().FindTable(" select * from  DC_OA_PartyBranch ");
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
                this.BaseRepository().Delete<DC_OA_PartyBranchMeetingEntity>(t=>t.F_PartyBranchMeetingGUID == keyValue);
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
        public void SaveEntity(string keyValue, DC_OA_PartyBranchMeetingEntity entity)
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

    }
}
