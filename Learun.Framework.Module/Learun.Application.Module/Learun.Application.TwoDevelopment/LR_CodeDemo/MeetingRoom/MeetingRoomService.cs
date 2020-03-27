using Dapper;
using Learun.DataBase.Repository;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.0 企业敏捷开发框架
    /// Copyright (c) 2018-2019 武汉东雅图科技技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-01-03 17:44
    /// 描 述：会议室管理
    /// </summary>
    public class MeetingRoomService : RepositoryFactory
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_OA_MeetingRoomEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.Dc_OA_MeetingRoomId,
                t.DC_OA_MeetingRoomName,
                t.DC_OA_MeetingRoomPlace,
                 t.F_Container,
                 t.F_RoomNo
                ");
                strSql.Append("  FROM DC_OA_MeetingRoom t ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                var now = DateTime.Now;
                bool b = false;
                if (pagination.sidx == "DC_OA_MeetingRoomState")
                {
                    b = true;
                    pagination.sidx = "Dc_OA_MeetingRoomId";
                }
                var result = this.BaseRepository().FindList<DC_OA_MeetingRoomEntity>(strSql.ToString(), dp, pagination);
                var result1 = this.BaseRepository().FindList<DC_OA_MeetingEntity>(c => c.DC_OA_StartTime < now && c.DC_OA_EndTime > now && c.DC_OA_Result == "通过");
                foreach (var item in result)
                {
                    item.DC_OA_MeetingRoomState = "空闲中";
                    foreach (var item1 in result1)
                    {
                        if (item1.DC_OA_MeetingRoomRefId == item.Dc_OA_MeetingRoomId)
                        {
                            item.DC_OA_MeetingRoomState = "使用中";
                            break;
                        }
                    }
                }
                if (b)
                {
                    if (pagination.sord == "ASC")
                    {
                        result = result.OrderBy(c => c.DC_OA_MeetingRoomState);
                    }
                    else
                    {
                        result = result.OrderByDescending(c => c.DC_OA_MeetingRoomState);
                    }
                }
                return result;
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
        public List<FullcalendarResult> GetMeettingData(string keyValue)
        {
            var result = this.BaseRepository().FindList<DC_OA_MeetingEntity>(c => c.DC_OA_MeetingRoomRefId == keyValue && c.DC_OA_Result == "通过");
            List<FullcalendarResult> list = new List<FullcalendarResult>();
            foreach (var item in result)
            {
                list.Add(new FullcalendarResult(item.DC_OA_StartTime, item.DC_OA_EndTime, item.DC_OA_MeetingTitle));
            }
            return list;
        }

        /// <summary>
        /// 获取DC_OA_MeetingRoom表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_OA_MeetingRoomEntity GetDC_OA_MeetingRoomEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_OA_MeetingRoomEntity>(keyValue);
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
                this.BaseRepository().Delete<DC_OA_MeetingRoomEntity>(t => t.Dc_OA_MeetingRoomId == keyValue);
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
        public void SaveEntity(string keyValue, DC_OA_MeetingRoomEntity entity)
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
