using Dapper;
using Learun.Application.Organization;
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
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-03-01 15:48
    /// 描 述：DC_OA_OverSeeWorkBulletin
    /// </summary>
    public class DC_OA_OverSeeWorkBulletinService : RepositoryFactory
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_OA_OverSeeWorkBulletinEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_DOBId,
                t.F_Title,
                t.F_FileContent,
                t.F_Attachments,
                t.F_FlowState
                ");
                strSql.Append("  FROM DC_OA_OverSeeWorkBulletin t ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                return this.BaseRepository().FindList<DC_OA_OverSeeWorkBulletinEntity>(strSql.ToString(), dp, pagination);
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
        /// 获取DC_OA_OverSeeWorkBulletinDetailed表数据
        /// <summary>
        /// <returns></returns>
        public IEnumerable<DC_OA_OverSeeWorkBulletinDetailedEntity> GetDC_OA_OverSeeWorkBulletinDetailedList(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindList<DC_OA_OverSeeWorkBulletinDetailedEntity>(t => t.F_DOBId == keyValue);
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
        /// 获取DC_OA_OverSeeWorkBulletin表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_OA_OverSeeWorkBulletinEntity GetDC_OA_OverSeeWorkBulletinEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_OA_OverSeeWorkBulletinEntity>(keyValue);
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
        /// 获取DC_OA_OverSeeWorkBulletinDetailed表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_OA_OverSeeWorkBulletinDetailedEntity GetDC_OA_OverSeeWorkBulletinDetailedEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_OA_OverSeeWorkBulletinDetailedEntity>(t => t.F_DOBId == keyValue);
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
        public DC_OA_OverSeeWorkBulletinEntity GetEntityByProcessId(string processId)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_OA_OverSeeWorkBulletinEntity>(t => t.F_DOBId == processId);
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
            var db = this.BaseRepository().BeginTrans();
            try
            {
                var dC_OA_OverSeeWorkBulletinEntity = GetDC_OA_OverSeeWorkBulletinEntity(keyValue);
                db.Delete<DC_OA_OverSeeWorkBulletinEntity>(t => t.F_DOBId == keyValue);
                db.Delete<DC_OA_OverSeeWorkBulletinDetailedEntity>(t => t.F_DOBId == dC_OA_OverSeeWorkBulletinEntity.F_DOBId);
                db.Commit();
            }
            catch (Exception ex)
            {
                db.Rollback();
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
        public void SaveEntity(string keyValue, DC_OA_OverSeeWorkBulletinEntity entity, string workIds)
        {
            var db = this.BaseRepository().BeginTrans();
            try
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    entity.Modify(keyValue);
                    db.Update(entity);
                }
                else
                {
                    entity.Create();
                    db.Insert(entity);
                    var list = StatisticsWorkByWorkIds(workIds);
                    foreach (DC_OA_OverSeeWorkBulletinDetailedEntity item in list)
                    {
                        item.Create();
                        item.F_DOBId = entity.F_DOBId;
                        db.Insert(item);
                    }
                }
                db.Commit();
            }
            catch (Exception ex)
            {
                db.Rollback();
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
        public List<DC_OA_OverSeeWorkBulletinDetailedEntity> GetDetailList(string keyValue)
        {
            return this.BaseRepository().FindList<DC_OA_OverSeeWorkBulletinDetailedEntity>(c => c.F_DOBId == keyValue).ToList();
        }
        public List<DC_OA_OverSeeWorkBulletinDetailedEntity> StatisticsWorkByWorkIds(string workIds)
        {
            List<DC_OA_OverSeeWorkBulletinDetailedEntity> result = new List<DC_OA_OverSeeWorkBulletinDetailedEntity>();
            Func<int, string> Func0 = state =>
            {
                switch (state)
                {
                    case 0: return "执行";
                    case 1: return "暂停";
                    case 2: return "终止";
                    case 3: return "完成";
                    default:
                        return "";
                }
            };
            Func<string, string> Func1 = userid =>
            {
                var user = this.BaseRepository().FindEntity<UserEntity>(c => c.F_UserId == userid);
                return user == null ? "" : user.F_RealName;
            };
            Func<string, string> Func2 = departmentid =>
            {
                var department = this.BaseRepository().FindEntity<DepartmentEntity>(c => c.F_DepartmentId == departmentid);
                return department == null ? "" : department.F_FullName;
            };
            Func<string, string> Func3 = userids =>
            {
                if (string.IsNullOrWhiteSpace(userids))
                {
                    return string.Empty;
                }
                var userIdArr = userids.Split(',');
                List<string> userNameList = new List<string>();
                foreach (var userid in userIdArr)
                {
                    userNameList.Add(Func1(userid));
                }
                string userNames = string.Empty;
                userNameList.ForEach(c => userNames += c + ",");
                if (userNames.Length > 0)
                {
                    userNames=userNames.Substring(0, userNames.Length - 1);
                }
                return userNames;
            };
            Func<string, string> Func4 = departmentids =>
            {
                if (string.IsNullOrWhiteSpace(departmentids))
                {
                    return string.Empty;
                }
                var userDepartmentIdArr = departmentids.Split(',');
                List<string> userDepartmentList = new List<string>();
                foreach (var departmentid in userDepartmentIdArr)
                {
                    userDepartmentList.Add(Func2(departmentid));
                }
                string userDeparmentIds = string.Empty;
                userDepartmentList.ForEach(c => userDeparmentIds += c + ",");
                if (userDeparmentIds.Length > 0)
                {
                    userDeparmentIds=userDeparmentIds.Substring(0, userDeparmentIds.Length - 1);
                }
                return userDeparmentIds;
            };
            Action<List<DC_OA_OverSeeWorkBulletinDetailedEntity>, DC_OA_OverSeeWorkEntity, DC_OA_OverSeeWorkTaskSplitEntity> Func5 =
            (list, workEntity, splitEntity) =>
            {
                var tempSplitEntity = splitEntity;
                var executeData = this.BaseRepository().FindList<DC_OA_OverSeeWorkTaskExecuteEntity>(c => c.F_SecondId == tempSplitEntity.F_SecondId)
                .OrderBy(c => c.F_ExecuteDate);
                StringBuilder tempExecute = new StringBuilder();
                foreach (var executeItem in executeData)
                {
                    tempExecute.Append(executeItem.F_ExecuteDate.ToString("yyyy年MM月dd日") + "，" +
                        Func1(executeItem.F_CreateUserId)
                        + "：" + executeItem.F_ExecuteContent + "；");
                }
                list.Add(new DC_OA_OverSeeWorkBulletinDetailedEntity()
                {
                    F_OneDepartment = tempSplitEntity.F_OneDepartmentId,
                    F_OneLeader = workEntity.F_HighLeaderId,
                    F_OneUser = tempSplitEntity.F_OneUserId,
                    F_TaskNodeDate = tempSplitEntity.F_TaskNodeDate.HasValue ? tempSplitEntity.F_TaskNodeDate : workEntity.F_EndDate,
                    F_ExecuteContent = tempExecute.ToString(),
                    F_State = tempSplitEntity.F_State,
                    F_TwoDepartment = Func4(tempSplitEntity.F_TwoDepartmentId),
                    F_TwoUser = Func3(tempSplitEntity.F_TwoUserId),
                    F_code = tempSplitEntity.F_code,
                    F_TaskContent = tempSplitEntity.F_TaskContent,
                    F_TaskName = tempSplitEntity.F_TaskName,
                    F_TaskNode = tempSplitEntity.F_TaskNode,
                    F_TaskNodeDateFirst = tempSplitEntity.F_TaskNodeDateFirst.HasValue ? tempSplitEntity.F_TaskNodeDateFirst : workEntity.F_BeginDate,
                    F_DOBId = "",
                    F_OSWBDId = tempSplitEntity.F_SecondId,
                    F_ParentId = tempSplitEntity.F_ParentId,
                    F_SecondId = tempSplitEntity.F_SecondId
                });
            };
            var workData = this.BaseRepository().FindList<DC_OA_OverSeeWorkEntity>(c => workIds.Contains(c.F_OSWId));
            foreach (var workItem in workData)
            {
                var workSplit1Data = this.BaseRepository().FindList<DC_OA_OverSeeWorkTaskSplitEntity>(c => c.F_OSWId == workItem.F_OSWId);
                foreach (var workSplit1 in workSplit1Data)
                {
                    Func5(result, workItem, workSplit1);
                }
            }
            return result.OrderBy(c => c.F_code).ToList();
        }
    }
}
