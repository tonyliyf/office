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
    /// 日 期：2019-04-29 11:22
    /// 描 述：会议通知回执
    /// </summary>
    public class DC_OA_MeettingRelationService : RepositoryFactory
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表分页数据
        /// <summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_OA_MeettingRelationEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                UserInfo userInfo = LoginUserInfo.Get();
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.MeettingId,
                t.F_Title,
                t.MeettingType,
                t.F_StartDate,
                t.IsJoin,
                t.F_Reason
                ");
                strSql.Append("  FROM DC_OA_MeettingRelation t ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["F_Title"].IsEmpty())
                {
                    dp.Add("F_Title", "%" + queryParam["F_Title"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_Title Like @F_Title ");
                }
                if (!queryParam["MeettingType"].IsEmpty())
                {
                    dp.Add("MeettingType", queryParam["MeettingType"].ToString(), DbType.String);
                    strSql.Append(" AND t.MeettingType = @MeettingType ");
                }
                 dp.Add("Userid", userInfo.userId, DbType.String);
                strSql.Append(" AND t.Userid = @Userid ");
                return this.BaseRepository().FindList<DC_OA_MeettingRelationEntity>(strSql.ToString(), dp, pagination);
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

        public int GetCount()
        {
            try
            {
                UserInfo userInfo = LoginUserInfo.Get();
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                 count(*) 
                ");
                strSql.Append("  FROM DC_OA_MeettingRelation t ");
                strSql.Append("  WHERE 1=1 ");
                // 虚拟参数
                var dp = new DynamicParameters(new { });
               
                dp.Add("Userid", userInfo.userId, DbType.String);
                strSql.Append(" AND t.Userid = @Userid ");
                return (int)this.BaseRepository().FindObject(strSql.ToString(), dp);
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
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_OA_MeettingRelationEntity> GetList(string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.MeettingId,
                t.F_Title,
                t.MeettingType,
                t.F_StartDate,
                t.IsJoin,
                t.F_Reason
                ");
                strSql.Append("  FROM DC_OA_MeettingRelation t ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["F_Title"].IsEmpty())
                {
                    dp.Add("F_Title", "%" + queryParam["F_Title"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_Title Like @F_Title ");
                }
                if (!queryParam["MeettingType"].IsEmpty())
                {
                    dp.Add("MeettingType", queryParam["MeettingType"].ToString(), DbType.String);
                    strSql.Append(" AND t.MeettingType = @MeettingType ");
                }
                return this.BaseRepository().FindList<DC_OA_MeettingRelationEntity>(strSql.ToString(), dp);
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
        /// 获取DC_OA_MeettingRelation表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_OA_MeettingRelationEntity GetDC_OA_MeettingRelationEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_OA_MeettingRelationEntity>(keyValue);
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
                this.BaseRepository().Delete<DC_OA_MeettingRelationEntity>(t => t.MeettingId == keyValue);
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
        public void SaveEntity(UserInfo userInfo, string keyValue, DC_OA_MeettingRelationEntity entity)
        {
            try
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    entity.Modify(keyValue, userInfo);
                    this.BaseRepository().Update(entity);
                }
                else
                {
                    entity.Create(userInfo);
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

        /// <summary>
        /// 没有填写理由，就默认参加，不参加必须填写原因
        /// </summary>
        /// <param name="id"></param>
        /// <param name="F_Reason"></param>
        public void UpdateEntity(string id, string F_Reason)
        {
            try
            {

                string sql = string.Empty;
                if (F_Reason.IsEmpty())
                {
                    sql = "  update dc_oa_meettingrelation set IsJoin =1,IsReadorReturn=1  where meettingid = @meettingid";
                }
                else
                {
                    sql = string.Format(" update dc_oa_meettingrelation set IsJoin =0,IsReadorReturn=1,F_Reason='{0}' where  meettingid = @meettingid", F_Reason);
                }

                this.BaseRepository().ExecuteBySql(sql, new { userid = LoginUserInfo.Get().userId, meettingid = id });
               
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
