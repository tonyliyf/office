using Dapper;
using Learun.Application.Organization;
using Learun.DataBase.Repository;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;
using Learun.Application.Base.AuthorizeModule;
namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-01-24 17:30
    /// 描 述：DC_OA_PerformanceRecordRun
    /// </summary>
    public class DC_OA_PerformanceRecordRunService : RepositoryFactory
    {
        #region 获取数据
        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_OA_PerformanceRecordRunEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_PRRId,
                t.F_PATId,
                t.F_AppraisalCycleType,
                t.F_PerformanceName,
                t.F_PRRStartDatetime,
                t.F_PRREndDatetime,
                t.F_SelfWeight,
                t.F_IfRemind,
                t.F_PRRDepartmentId,
                t.F_PRRUserId,
                t.F_PRRCreateDate,
                t.F_IsDelete,
                t.F_RunState
                ");
                strSql.Append("  FROM DC_OA_PerformanceRecordRun t ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                return this.BaseRepository().FindList<DC_OA_PerformanceRecordRunEntity>(strSql.ToString(), dp, pagination);
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
        /// 获取DC_OA_PerformanceRecordRun表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_OA_PerformanceRecordRunEntity GetDC_OA_PerformanceRecordRunEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_OA_PerformanceRecordRunEntity>(keyValue);
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
                this.BaseRepository().Delete<DC_OA_PerformanceRecordRunEntity>(t => t.F_PRRId == keyValue);
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
        public void SaveEntity(string keyValue, DC_OA_PerformanceRecordRunEntity entity)
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
        public List<UserEntity> GetUserList(string tid)
        {
            var rList = this.BaseRepository().FindList<DC_OA_PerformancePostRelationEntity>(c => c.F_PATId == tid).ToList();
            List<UserEntity> list = new List<UserEntity>();
            //找寻岗位
            foreach (var item in rList)
            {
                var idList = this.BaseRepository().FindList<UserRelationEntity>(c => c.F_Category == 2 && c.F_ObjectId == item.F_PostId).
                    Select(c => c.F_UserId).ToList();
                //通过岗位找寻人
                foreach (var userId in idList)
                {
                    var user = this.BaseRepository().FindEntity<UserEntity>(c => c.F_UserId == userId);
                    if (user != null && list.Count(c => c.F_UserId == user.F_UserId) <= 0)
                    {
                        list.Add(user);
                    }
                }
            }
            return list;
        }
        public List<UserEntity> GetCheckerList(string tid)
        {
            var rList = this.BaseRepository().FindList<DC_OA_PerformancePostRelationEntity>(c => c.F_PATId == tid).ToList();
            List<UserEntity> list = new List<UserEntity>();
            foreach (var item in rList)
            {
                var pPost = this.BaseRepository().FindEntity<PostEntity>(c => c.F_PostId == item.F_PostId);
                if (pPost != null)
                {
                    var parentPost = this.BaseRepository().FindEntity<PostEntity>(c => c.F_PostId == pPost.F_ParentId);
                    if (parentPost != null)
                    {
                        var idList = this.BaseRepository().FindList<UserRelationEntity>(c => c.F_Category == 2 && c.F_ObjectId == parentPost.F_PostId).
                   Select(c => c.F_UserId).ToList();
                        foreach (var userId in idList)
                        {
                            var user = this.BaseRepository().FindEntity<UserEntity>(c => c.F_UserId == userId);
                            if (user != null && list.Count(c => c.F_UserId == user.F_UserId) <= 0)
                            {
                                list.Add(user);
                            }
                        }
                    }
                }
            }
            return list;
        }

        public void SaveUserList(string rid, string userIds)
        {
            this.BaseRepository().Delete<DC_OA_PRRSelfUserRelationEntity>(c => c.F_PRRId == rid);
            string[] arr = userIds.Split(',');
            foreach (var str in arr)
            {
                this.BaseRepository().Insert(new DC_OA_PRRSelfUserRelationEntity()
                {
                    F_PRRId = rid,
                    F_PRRSURId = Guid.NewGuid().ToString(),
                    F_SelfUserId = str
                });
            }
        }

        public List<UserEntity> GetUserIdList(string rid, out string userIds)
        {
            var dp = new DynamicParameters(new { });
            dp.Add("F_PRRId", rid, DbType.String);
            List<UserEntity> list = this.BaseRepository().FindList<UserEntity>(@"   select t1.*
                  from LR_Base_User t1,
                  DC_OA_PRRSelfUserRelation t2
                  where t1.F_UserId = t2.F_SelfUserId and t2.F_PRRId = @F_PRRId", dp).ToList();
            var temp = "";
            list.ForEach(c => temp += c.F_UserId + ",");
            if (temp.Length > 0)
            {
                temp = temp.Substring(0, temp.Length - 1);
            }
            userIds = temp;
            return list;
        }
    }
}
