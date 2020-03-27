using Dapper;
using Learun.Application.TwoDevelopment.SystemDemo;
using Learun.DataBase.Repository;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Learun.Application.TwoDevelopment.ProjectManager
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-11-01 16:53
    /// 描 述：DC_EngineProject_ProjectProgress
    /// </summary>
    public class DC_EngineProject_ProjectProgressService : RepositoryFactory
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_EngineProject_ProjectProgressEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_id,
                t.F_PIId,
                t.F_Department,
                t.F_month,
                t.F_proceedings,
                t.F_time,
                t.F_summarize,
                t.F_plan,
                t.F_remark
                ");
                strSql.Append("  FROM DC_EngineProject_ProjectProgress t ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["F_PIId"].IsEmpty())
                {
                    dp.Add("F_PIId",queryParam["F_PIId"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_PIId = @F_PIId ");
                }
                if (!queryParam["F_Department"].IsEmpty())
                {
                    dp.Add("F_Department",queryParam["F_Department"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_Department = @F_Department ");
                }
                return this.BaseRepository().FindList<DC_EngineProject_ProjectProgressEntity>(strSql.ToString(),dp, pagination);
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
        /// 获取页面门户项目进度显示数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public DataTable GetProjectProgress(string projectid)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_id,
                b.F_ProjectName as F_PIId,
                c.F_ShortName as F_Department,
                d.F_RealName as F_CreateUser,
                t.F_month,
                t.F_proceedings,
                t.F_time,
                t.F_summarize,
                t.F_plan,
                t.F_remark
                ");
                strSql.Append("  FROM DC_EngineProject_ProjectProgress t ");
                strSql.Append(" left join  DC_EngineProject_ProjectInfo b on b.F_PIId=t.F_PIId ");
                strSql.Append(" left join  LR_Base_Department c on c.F_DepartmentId=t.F_Department ");
                strSql.Append(" left join  LR_Base_User d on d.F_UserId=t.F_CreateUser ");
                strSql.Append("  WHERE t.F_PIId='"+ projectid + "' order by  t.F_time desc ");
                DataTable dt = this.BaseRepository().FindTable(strSql.ToString());
                //Dictionary<string, string> dic = new Dictionary<string, string>();
                //dic.Add("F_PIId", "DC_EngineProject_ProjectInfo");
                //dic.Add("F_Department", "OA_Department");
                //dic.Add("F_CreateUser", "OA_User");
                //DataConvertSerivers sevices = new DataConvertSerivers();
                //sevices.ConvertDataByDataItem(dt, dic);
       
                return dt;
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
        /// 获取DC_EngineProject_ProjectProgress表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_EngineProject_ProjectProgressEntity GetDC_EngineProject_ProjectProgressEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_EngineProject_ProjectProgressEntity>(keyValue);
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
                this.BaseRepository().Delete<DC_EngineProject_ProjectProgressEntity>(t=>t.F_id == keyValue);
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
        public void SaveEntity(string keyValue, DC_EngineProject_ProjectProgressEntity entity)
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
