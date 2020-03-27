using Dapper;
using Learun.Application.Organization;
using Learun.Application.WorkFlow;
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
    /// 日 期：2019-03-02 16:37
    /// 描 述：DC_OA_OverSeeWorkDelay
    /// </summary>
    public class DC_OA_OverSeeWorkDelayService : RepositoryFactory
    {
        private DC_OA_OverSeeWorkIBLL dc_OA_OverSeeWorkIBLL = new DC_OA_OverSeeWorkBLL();
        private NWFProcessIBLL nWFProcessIBLL = new NWFProcessBLL();
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_OA_OverSeeWorkDelayEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_OSWDId,
                t.F_OSWId,
                t.F_EndDelayDate,
                t.F_Attachments,
                t.F_DelayExplain,
                t.F_BeginDate,
                t.F_EndDate,
                t.F_DepartmentId,
                t.F_LeaderUserId,
                t.F_OverSeeUserId,
                t.F_HighLeaderId,
                t.F_OSWType
                ");
                strSql.Append("  FROM DC_OA_OverSeeWorkDelay t ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                return this.BaseRepository().FindList<DC_OA_OverSeeWorkDelayEntity>(strSql.ToString(), dp, pagination);
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
        /// 获取DC_OA_OverSeeWorkDelayDetailed表数据
        /// <summary>
        /// <returns></returns>
        public IEnumerable<DC_OA_OverSeeWorkDelayDetailedEntity> GetDC_OA_OverSeeWorkDelayDetailedList(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindList<DC_OA_OverSeeWorkDelayDetailedEntity>(t => t.F_OSWDId == keyValue);
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
        /// 获取DC_OA_OverSeeWorkDelay表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_OA_OverSeeWorkDelayEntity GetDC_OA_OverSeeWorkDelayEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_OA_OverSeeWorkDelayEntity>(keyValue);
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
        /// 获取DC_OA_OverSeeWorkDelayDetailed表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_OA_OverSeeWorkDelayDetailedEntity GetDC_OA_OverSeeWorkDelayDetailedEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_OA_OverSeeWorkDelayDetailedEntity>(t => t.F_OSWDId == keyValue);
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
        public DC_OA_OverSeeWorkDelayEntity GetEntityByProcessId(string processId)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_OA_OverSeeWorkDelayEntity>(t => t.F_OSWDId == processId);
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
                var dC_OA_OverSeeWorkDelayEntity = GetDC_OA_OverSeeWorkDelayEntity(keyValue);
                db.Delete<DC_OA_OverSeeWorkDelayEntity>(t => t.F_OSWDId == keyValue);
                db.Delete<DC_OA_OverSeeWorkDelayDetailedEntity>(t => t.F_OSWDId == dC_OA_OverSeeWorkDelayEntity.F_OSWDId);
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
        public void SaveEntity(string keyValue, DC_OA_OverSeeWorkDelayEntity entity, List<DC_OA_OverSeeWorkDelayDetailedEntity> dC_OA_OverSeeWorkDelayDetailedList)
        {
            Func<string, string> GetUserName = userid =>
            {
                var user = this.BaseRepository().FindEntity<UserEntity>(userid);
                return user == null ? "" : user.F_RealName;
            };
            Func<string, string> GetDepartmentName = departmentid =>
            {
                var department = this.BaseRepository().FindEntity<DepartmentEntity>(departmentid);
                return department == null ? "" : department.F_FullName;
            };
            Func<string, string> GetCompanyName = companyid =>
            {
                var company = this.BaseRepository().FindEntity<CompanyEntity>(companyid);
                return company == null ? "" : company.F_FullName;
            };
            var db = this.BaseRepository().BeginTrans();
            try
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    var dC_OA_OverSeeWorkDelayEntityTmp = GetDC_OA_OverSeeWorkDelayEntity(keyValue);
                    entity.Modify(keyValue);
                    entity.F_Department = GetDepartmentName(entity.F_DepartmentId);
                    entity.F_HighLeader = GetUserName(entity.F_HighLeaderId);
                    entity.F_OverSeeUser = GetUserName(entity.F_OverSeeUserId);
                    entity.F_LeaderUser = GetUserName(entity.F_LeaderUser);
                    db.Update(entity);
                    db.Delete<DC_OA_OverSeeWorkDelayDetailedEntity>(t => t.F_OSWDId == dC_OA_OverSeeWorkDelayEntityTmp.F_OSWDId);
                    foreach (DC_OA_OverSeeWorkDelayDetailedEntity item in dC_OA_OverSeeWorkDelayDetailedList)
                    {
                        item.Create();
                        item.F_OSWDId = dC_OA_OverSeeWorkDelayEntityTmp.F_OSWDId;
                        db.Insert(item);
                    }
                }
                else
                {
                    entity.Create();
                    db.Insert(entity);
                    foreach (DC_OA_OverSeeWorkDelayDetailedEntity item in dC_OA_OverSeeWorkDelayDetailedList)
                    {
                        item.Create();
                        entity.F_Department = GetDepartmentName(entity.F_DepartmentId);
                        entity.F_HighLeader = GetUserName(entity.F_HighLeaderId);
                        entity.F_OverSeeUser = GetUserName(entity.F_OverSeeUserId);
                        entity.F_LeaderUser = GetUserName(entity.F_LeaderUser);
                        item.F_OSWDId = entity.F_OSWDId;
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
        public DC_OA_OverSeeWorkEntity GetWorkEntity(string keyValue)
        {
            return this.BaseRepository().FindEntity<DC_OA_OverSeeWorkEntity>(keyValue);
        }
        public List<DC_OA_OverSeeWorkDelayDetailedEntity> StatisticsWorkByWorkIds(string workId)
        {
            List<DC_OA_OverSeeWorkDelayDetailedEntity> result = new List<DC_OA_OverSeeWorkDelayDetailedEntity>();
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
                    userNames = userNames.Substring(0, userNames.Length - 1);
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
                    userDeparmentIds = userDeparmentIds.Substring(0, userDeparmentIds.Length - 1);
                }
                return userDeparmentIds;
            };
            Action<List<DC_OA_OverSeeWorkDelayDetailedEntity>, DC_OA_OverSeeWorkEntity, DC_OA_OverSeeWorkTaskSplitEntity> Func5 =
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
                list.Add(new DC_OA_OverSeeWorkDelayDetailedEntity()
                {
                    F_OneDepartment = Func2(tempSplitEntity.F_OneDepartmentId),
                    F_OneLeader = Func3(workEntity.F_HighLeaderId),
                    F_OneUser = Func3(tempSplitEntity.F_OneUserId),
                    F_TaskNodeDate = tempSplitEntity.F_TaskNodeDate.HasValue ? tempSplitEntity.F_TaskNodeDate : workEntity.F_EndDate,
                    F_ExecuteContent = tempExecute.ToString(),
                    F_State = Func0(tempSplitEntity.F_State),
                    F_TwoDepartment = Func4(tempSplitEntity.F_TwoDepartmentId),
                    F_TwoUser = Func3(tempSplitEntity.F_TwoUserId),
                    F_code = tempSplitEntity.F_code,
                    F_TaskContent = tempSplitEntity.F_TaskContent,
                    F_TaskName = tempSplitEntity.F_TaskName,
                    F_TaskNode = tempSplitEntity.F_TaskNode,
                    F_TaskNodeDateFirst = tempSplitEntity.F_TaskNodeDateFirst.HasValue ? tempSplitEntity.F_TaskNodeDateFirst : workEntity.F_BeginDate,
                    F_OSWDDId = Guid.NewGuid().ToString(),
                    F_ParentId = tempSplitEntity.F_ParentId,
                    F_SecondId = tempSplitEntity.F_SecondId
                });
            };
            var workData = this.BaseRepository().FindList<DC_OA_OverSeeWorkEntity>(c => workId == c.F_OSWId);
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

        public string Createflow(string mainkeyvalue)
        {

            DC_OA_OverSeeWorkDelayEntity entity = new DC_OA_OverSeeWorkDelayEntity();
            var DC_OA_OverSeeWork = new DC_OA_OverSeeWorkBLL().GetDC_OA_OverSeeWorkEntity(mainkeyvalue);
            entity.F_OSWId = DC_OA_OverSeeWork.F_OSWId;
            entity.F_LeaderUser = DC_OA_OverSeeWork.F_LeaderUser;
            entity.F_LeaderUserId = DC_OA_OverSeeWork.F_LeaderUserId;
            entity.F_OverSeeUserId = DC_OA_OverSeeWork.F_OverSeeUserId;
            entity.F_DepartmentId = DC_OA_OverSeeWork.F_DepartmentId;
            entity.F_BeginDate = DC_OA_OverSeeWork.F_BeginDate;
            entity.F_EndDate = DC_OA_OverSeeWork.F_EndDate;
            entity.F_OSWDId = Guid.NewGuid().ToString();
            entity.F_EndDelayDate = DateTime.Now;
            entity.F_OSWType = DC_OA_OverSeeWork.F_OSWType;
            entity.F_HighLeaderId = DC_OA_OverSeeWork.F_HighLeaderId;
            entity.F_HighLeader = DC_OA_OverSeeWork.F_HighLeader;
            entity.Create();
            this.BaseRepository().Insert(entity);
            var list = StatisticsWorkByWorkIds(mainkeyvalue);
            foreach (var item in list)
            {
                item.F_OSWDId = entity.F_OSWDId;
                this.BaseRepository().Insert(item);
            }
            UserInfo userInfo = LoginUserInfo.Get();
            nWFProcessIBLL.SaveDraft(entity.F_OSWDId, "DC_OA_OverSeeWorkDelay", userInfo);
            return entity.F_OSWDId;
        }
    }
}
