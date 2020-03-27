using Dapper;
using Learun.DataBase.Repository;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;
using Learun.Application.Organization;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.0 企业敏捷开发框架
    /// Copyright (c) 2018-2019 武汉东雅图科技技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-01-07 17:47
    /// 描 述：DC_OA_OverSeeWorkTaskExecute
    /// </summary>
    public class DC_OA_OverSeeWorkTaskExecuteService : RepositoryFactory
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_OA_OverSeeWorkTaskSplitEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_SecondId,
                t.F_code,
                t.F_TaskName,
                t.F_TaskContent,
                t.F_TaskNode,
                t.F_TaskNodeDate,
                t.F_OneDepartmentId,
                t.F_OneUserId,
                t.F_OneLeaderId,
                t.F_TwoDepartmentId,
                t.F_TwoUserId,
                t.F_State，
                t.F_TaskNodeDateFirst
                ");
                strSql.Append("  FROM DC_OA_OverSeeWorkTaskSplit t ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                return this.BaseRepository().FindList<DC_OA_OverSeeWorkTaskSplitEntity>(strSql.ToString(), dp, pagination);
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
        public IEnumerable<DC_OA_OverSeeWorkTaskExecuteEntity> GetPageListEx(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.*
                ");
                strSql.Append("  FROM DC_OA_OverSeeWorkTaskExecute t ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["keyValue"].IsEmpty())
                {
                    dp.Add("F_SecondId", queryParam["keyValue"].ToString(), DbType.String);
                    strSql.Append(" and F_SecondId=@F_SecondId ");
                }

                return this.BaseRepository().FindList<DC_OA_OverSeeWorkTaskExecuteEntity>(strSql.ToString(), dp, pagination);
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
        /// 获取DC_OA_OverSeeWorkTaskExecute表数据
        /// <summary>
        /// <returns></returns>
        public IEnumerable<DC_OA_OverSeeWorkTaskExecuteEntity> GetDC_OA_OverSeeWorkTaskExecuteList(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindList<DC_OA_OverSeeWorkTaskExecuteEntity>(t => t.F_SecondId == keyValue);
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

        /// <summary>
        /// 获取DC_OA_OverSeeWorkTaskExecute表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_OA_OverSeeWorkTaskExecuteEntity GetDC_OA_OverSeeWorkTaskExecuteEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_OA_OverSeeWorkTaskExecuteEntity>(keyValue);
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
                var dC_OA_OverSeeWorkTaskSplitEntity = GetDC_OA_OverSeeWorkTaskSplitEntity(keyValue);
                db.Delete<DC_OA_OverSeeWorkTaskSplitEntity>(t => t.F_SecondId == keyValue);
                db.Delete<DC_OA_OverSeeWorkTaskExecuteEntity>(t => t.F_SecondId == dC_OA_OverSeeWorkTaskSplitEntity.F_SecondId);
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
        public void DeleteEntityEx(string keyValue)
        {
            try
            {
                this.BaseRepository().Delete<DC_OA_OverSeeWorkTaskExecuteEntity>(c => c.F_ThirdId == keyValue);
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
        public void SaveEntity(string TID, string PID, string keyValue, DC_OA_OverSeeWorkTaskSplitEntity entity)
        {
            var db = this.BaseRepository().BeginTrans();
            try
            {
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
                Action<DC_OA_OverSeeWorkTaskSplitEntity> InitNames = m =>
                {
                    string Names;
                    List<string> arrIds;
                    m.F_OSWId = TID;
                    if (!string.IsNullOrWhiteSpace(m.F_OneDepartmentId))
                    {
                        m.F_OneDepartment = this.BaseRepository().FindEntity<DepartmentEntity>(x => x.F_DepartmentId == m.F_OneDepartmentId).F_FullName;
                    }
                    if (!string.IsNullOrWhiteSpace(m.F_OneUserId))
                    {
                        m.F_OneUser = Func3(m.F_OneUserId);
                    }
                    if (!string.IsNullOrWhiteSpace(m.F_OneLeaderId))
                    {
                        m.F_OneLeader = Func3(m.F_OneLeaderId);
                    }
                    if (!string.IsNullOrWhiteSpace(m.F_TwoDepartmentId))
                    {
                        arrIds = m.F_TwoDepartmentId.Split(',').ToList();
                        if (arrIds.Count > 0)
                        {
                            Names = string.Empty;
                            arrIds.ForEach(c =>
                            {
                                Names += this.BaseRepository().FindEntity<DepartmentEntity>(x => x.F_DepartmentId == c).F_FullName + ",";
                            });
                            entity.F_TwoDepartment = Names.Substring(0, Names.Length - 1);
                        }
                    }
                    if (!string.IsNullOrWhiteSpace(m.F_TwoUserId))
                    {
                        arrIds = m.F_TwoUserId.Split(',').ToList();
                        if (arrIds.Count > 0)
                        {
                            Names = string.Empty;
                            arrIds.ForEach(c =>
                            {
                                Names += this.BaseRepository().FindEntity<UserEntity>(x => x.F_UserId == c).F_RealName + ",";
                            });
                            entity.F_TwoUser = Names.Substring(0, Names.Length - 1);
                        }
                    }
                };
                if (!string.IsNullOrEmpty(keyValue) && string.IsNullOrWhiteSpace(PID))
                {
                    var dC_OA_OverSeeWorkTaskSplitEntityTmp = GetDC_OA_OverSeeWorkTaskSplitEntity(keyValue);
                    entity.Modify(keyValue);
                    InitNames(entity);
                    db.Update(entity);
                }
                else if (!string.IsNullOrWhiteSpace(PID))
                {
                    var parentEntity = this.BaseRepository().FindEntity<DC_OA_OverSeeWorkTaskSplitEntity>(c => c.F_SecondId == PID);
                    entity.Create();
                    entity.F_OneDepartment = parentEntity.F_OneDepartment;
                    entity.F_OneDepartmentId = parentEntity.F_OneDepartmentId;
                    entity.F_OneLeader = parentEntity.F_OneLeader;
                    entity.F_OneLeaderId = parentEntity.F_OneLeaderId;
                    entity.F_OneUser = parentEntity.F_OneUser;
                    entity.F_OneUserId = parentEntity.F_OneUserId;
                    entity.F_TwoDepartmentId = parentEntity.F_TwoDepartmentId;
                    entity.F_TwoDepartment = parentEntity.F_TwoDepartment;
                    entity.F_TwoUserId = parentEntity.F_TwoUserId;
                    entity.F_TwoUser = parentEntity.F_TwoUser;
                    entity.F_OSWId = parentEntity.F_OSWId;
                    entity.F_ParentId = PID;
                    db.Insert(entity);
                }
                else
                {
                    entity.Create();
                    InitNames(entity);
                    db.Insert(entity);
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
        public void SaveEntity(string keyValue, DC_OA_OverSeeWorkTaskExecuteEntity entity)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(keyValue))
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
