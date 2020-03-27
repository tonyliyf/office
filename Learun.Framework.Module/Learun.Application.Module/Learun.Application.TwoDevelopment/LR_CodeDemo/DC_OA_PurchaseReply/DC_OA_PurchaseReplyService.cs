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
    /// 日 期：2019-02-05 15:16
    /// 描 述：DC_OA_PurchaseReply
    /// </summary>
    public class DC_OA_PurchaseReplyService : RepositoryFactory
    {
        #region 构造函数和属性

        private string fieldSql;
        public DC_OA_PurchaseReplyService()
        {
            fieldSql = @"
                t.F_PurchaseReplyId,
                t.F_PurchaseReplyNo,
                t.F_DealUserPhone,
                t.F_DealMoney,
                t.F_IsPolicy,
                t.F_SummaryNo,
                t.F_SummaryFile,
                t.F_AuditInfo,
                t.F_AuditFile,
                t.F_PurchaseInfo,
                t.F_PurchaseMethod,
                t.F_ServiceMoney,
                t.F_buyPlatform,
                t.F_CurrentCompanyId,
                t.F_EnabledMark,
                t.F_CreateUserId,
                t.F_CurrentDeptId,
                t.F_ModifyUserName,
                t.F_CurrentUserId,
                t.F_ModifyUserId,
                t.F_DeleteMark,
                t.F_SortCode,
                t.F_ModifyDate,
                t.F_CreateUserName,
                t.F_CreateDate,
                t.F_Description,
                t.F_DescriptionFile,
                t.F_PurchaseName,
                t.F_PurchaseProjectNo,
                t.Is_agree,
                t.F_PurchaseProjectType,
                t.F_PurchaseWoodType
            ";
        }
        #endregion

        #region 获取数据

        /// <summary>
        /// 获取列表数据
        /// <summary>
        /// <returns></returns>
        public IEnumerable<DC_OA_PurchaseReplyEntity> GetList(string queryJson)
        {
            try
            {
                //参考写法
                //var queryParam = queryJson.ToJObject();
                // 虚拟参数
                //var dp = new DynamicParameters(new { });
                //dp.Add("startTime", queryParam["StartTime"].ToDate(), DbType.DateTime);
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(fieldSql);
                strSql.Append(" FROM DC_OA_PurchaseReply t ");
                return this.BaseRepository().FindList<DC_OA_PurchaseReplyEntity>(strSql.ToString());
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
        public IEnumerable<DC_OA_PurchaseReplyEntity> GetListbyUserid(string userid)
        {
            try
            {
                //参考写法
                //var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                dp.Add("userid", userid, DbType.String);
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(fieldSql);
                strSql.Append(" FROM DC_OA_PurchaseReply t where 1=1 and  Is_agree=2  ");

                strSql.Append("  AND t.F_CreateUserId = @userid ");
               
                return this.BaseRepository().FindList<DC_OA_PurchaseReplyEntity>(strSql.ToString());
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



        

        public DataTable GetList(Pagination pagination, string queryJson)
        {


            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@" 
                t.f_purchasename,
                t.f_purchaseprojectno,
                t.f_purchasereplyno,
                t.f_dealuserphone,
                t.f_dealmoney,
                t.f_summaryno,
                t.f_purchaseinfo,
                t.f_purchasemethod,
                t.f_servicemoney,
                t.f_buyplatform,
                t.f_currentdeptid,
                t.f_createuserid,
                t.F_PurchaseReplyId
                ");
                strSql.Append(" FROM DC_OA_PurchaseReply t ");
                return this.BaseRepository().FindTable(strSql.ToString(), pagination);
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
        /// 获取列表分页数据
        /// <param name="pagination">分页参数</param>
        /// <summary>
        /// <returns></returns>
        public IEnumerable<DC_OA_PurchaseReplyEntity> GetPageList(Pagination pagination, string queryJson,string isPower)
        {
            try
            {
                UserInfo user = LoginUserInfo.Get();
                 var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(fieldSql);
                strSql.Append(" FROM DC_OA_PurchaseReply t  where t.is_agree =2 ");
                if (!isPower.IsEmpty())
                {
                    if (user.F_Level == 1)
                    {
                        strSql.Append(string.Format(" and  t.F_CreateUserId = '{0}'", user.userId));

                    }
                    else if (user.F_Level == 2)
                    {
                        strSql.Append(string.Format(" and  t.F_CurrentDeptId = '{0}'", user.departmentId));
                    }
                    else if (user.F_Level == 3)
                    {
                        strSql.Append(string.Format(" and  t.F_CurrentCompanyId = '{0}'", user.companyId));
                    }
                }
                return this.BaseRepository().FindList<DC_OA_PurchaseReplyEntity>(strSql.ToString(), pagination);
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
        /// 获取实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_OA_PurchaseReplyEntity GetEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_OA_PurchaseReplyEntity>(keyValue);
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
                this.BaseRepository().Delete<DC_OA_PurchaseReplyEntity>(t => t.F_PurchaseReplyId == keyValue);
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
        public void SaveEntity(string keyValue, DC_OA_PurchaseReplyEntity entity)
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

        public DataTable GetEntityEx(string keyValue)
        {
            string sql = @"SELECT t.[F_PurchaseProjectNo] as projectno
                        ,t.[F_DealUserPhone] as tel
                        ,t.F_PurchaseProjectType as projectType
                        ,t.F_PurchaseWoodType  as woodtype
                        ,round(t.[F_DealMoney],2) as [money]
                        ,round(t.[F_ServiceMoney],2) as [money2]
                        ,t.[F_PurchaseMethod] as [method]
                        ,t.F_AuditNo as review
                        ,t.[F_buyPlatform] as [platform]
                        ,t.[F_PurchaseName] as [projectname]
                        ,(select top 1 F_FullName from LR_Base_Department where F_DepartmentId=t.F_CurrentDeptId) as [department]
                        ,(select top 1 F_RealName from LR_Base_User where F_UserId=t.F_CreateUserId) as [contract]
                        ,t.[F_Description] as [remark]
                        ,case when t.F_AuditInfo is null then null else t.F_AuditInfo+'审批' end as [auditinfo]
                        ,t.[F_PurchaseReplyNo] as [replyno]
                        ,t.F_SummaryNo as [contentno]
                        ,case when t.F_IsPolicy =1 then '是' else '否'end as [yesorno1]
                        FROM [DC_OA_PurchaseReply] t where t.F_PurchaseReplyId=@F_PurchaseReplyId";
            return this.BaseRepository().FindTable(sql, new { F_PurchaseReplyId = keyValue });
        }

        #endregion

    }
}
