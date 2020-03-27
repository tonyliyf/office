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
    /// 日 期：2019-02-27 15:58
    /// 描 述：DC_OA_Meeting
    /// </summary>
    public class DC_OA_MeetingService : RepositoryFactory
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public DataTable GetPageList(string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.DC_OA_MeetingTitle as [title],
                t.DC_OA_MeetingTopic as [topic],
                t.DC_OA_MeetingContent as [content],
                (select top 1 F_RealName from lr_base_user where F_UserId=t.DC_OA_MeetingManageId) as [managername],
                t.DC_OA_StartTime as [starttime],
                t.DC_OA_EndTime as [endtime],
                (select top 1 DC_OA_MeetingRoomName from [DC_OA_MeetingRoom] where Dc_OA_MeetingRoomId = t.DC_OA_MeetingRoomRefId) as [roomname]
                ");
                strSql.Append("  FROM DC_OA_Meeting t ");
                strSql.Append("  WHERE is_agree=2");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["StartTime"].IsEmpty() && !queryParam["EndTime"].IsEmpty())
                {
                    dp.Add("startTime", queryParam["StartTime"].ToDate(), DbType.DateTime);
                    dp.Add("endTime", queryParam["EndTime"].ToDate(), DbType.DateTime);
                    strSql.Append(" AND ( t.DC_OA_StartTime >= @startTime AND t.DC_OA_StartTime <= @endTime ) ");
                }
                return this.BaseRepository().FindTable(strSql.ToString(), dp);
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
        /// 获取DC_OA_Meeting表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_OA_MeetingEntity GetDC_OA_MeetingEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_OA_MeetingEntity>(keyValue);
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
        /// 获取主表实体数据
        /// <param name="processId">流程实例ID</param>
        /// <summary>
        /// <returns></returns>
        public DC_OA_MeetingEntity GetEntityByProcessId(string processId)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_OA_MeetingEntity>(t => t.DC_OA_MeetingId == processId);
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
                this.BaseRepository().Delete<DC_OA_MeetingEntity>(t => t.DC_OA_MeetingId == keyValue);
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
        public void SaveEntity(string keyValue, DC_OA_MeetingEntity entity)
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
                if (entity.F_SubjectSumId != null)
                {
                    var temp = this.BaseRepository().FindEntity<DC_OA_MeetingSubjectSumEntity>(entity.F_SubjectSumId);
                    temp.Is_agree = "3";
                    this.BaseRepository().Update(temp);
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

        public DataTable GetMeetingList()
        {
            return this.BaseRepository().FindTable(@"  select top 7
                  (select top 1 dc_oa_meetingroomname from dc_oa_meetingroom where dc_oa_meetingroomid = t.dc_oa_meetingroomrefid) as room,
                  t.dc_oa_meetingtitle as [name],
                  t.dc_oa_starttime as [date]
                  from dc_oa_meeting t
                  where is_agree = 2 and dc_oa_meetingids like @userid order by dc_oa_starttime desc ", new { userid = "%" + LoginUserInfo.Get().userId + "%" });
        }

    }
}
