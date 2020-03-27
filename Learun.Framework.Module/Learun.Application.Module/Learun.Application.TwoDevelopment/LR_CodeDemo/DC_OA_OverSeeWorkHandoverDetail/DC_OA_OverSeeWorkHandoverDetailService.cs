using Dapper;
using Learun.Application.Organization;
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
    /// 日 期：2019-02-28 14:09
    /// 描 述：DC_OA_OverSeeWorkHandoverDetail
    /// </summary>
    public class DC_OA_OverSeeWorkHandoverDetailService : RepositoryFactory
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_OA_OverSeeWorkHandoverDetailEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.*
                ");
                strSql.Append("  FROM DC_OA_OverSeeWorkHandoverDetail t ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["F_DOHId"].IsEmpty())
                {
                    dp.Add("F_DOHId", queryParam["F_DOHId"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_DOHId = @F_DOHId ");
                }
                return this.BaseRepository().FindList<DC_OA_OverSeeWorkHandoverDetailEntity>(strSql.ToString(), dp, pagination);
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
        /// 获取DC_OA_OverSeeWorkHandoverDetail表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_OA_OverSeeWorkHandoverDetailEntity GetDC_OA_OverSeeWorkHandoverDetailEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_OA_OverSeeWorkHandoverDetailEntity>(keyValue);
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
                this.BaseRepository().Delete<DC_OA_OverSeeWorkHandoverDetailEntity>(t => t.F_OWHDId == keyValue);
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
        public void SaveEntity(string keyValue, DC_OA_OverSeeWorkHandoverDetailEntity entity)
        {
            try
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

                Func<string, string> Func1 = userid =>
                {
                    var user = this.BaseRepository().FindEntity<UserEntity>(c => c.F_UserId == userid);
                    return user == null ? "" : user.F_RealName;
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
                    if (userNames.Length >= 0)
                    {
                        userNames.Substring(0, userNames.Length - 1);
                    }
                    return userNames;
                };
                if (!string.IsNullOrEmpty(keyValue))
                {
                    entity.Modify(keyValue);
                    entity.F_Department = GetDepartmentName(entity.F_DepartmentId);
                    entity.F_HighLeader = GetUserName(entity.F_HighLeaderId);
                    entity.F_LeaderUser = Func3(entity.F_LeaderUserId);
                    entity.F_OverSeeUser = GetUserName(entity.F_OverSeeUserId);
                    this.BaseRepository().Update(entity);
                }
                else
                {
                    entity.Create();
                    entity.F_Department = GetDepartmentName(entity.F_DepartmentId);
                    entity.F_HighLeader = GetUserName(entity.F_HighLeaderId);
                    entity.F_LeaderUser = Func3(entity.F_LeaderUserId);
                    entity.F_OverSeeUser = GetUserName(entity.F_OverSeeUserId);
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
