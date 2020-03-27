using Dapper;
using Learun.DataBase.Repository;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Learun.Application.TwoDevelopment.SystemDemo;
namespace Learun.Application.TwoDevelopment.ProjectManager
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-03-21 10:45
    /// 描 述：DC_EngineProject_ProjectCompanyRiskControl
    /// </summary>
    public class DC_EngineProject_ProjectCompanyRiskControlService : RepositoryFactory
    {
        #region 获取数据
        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public DataTable ExportData(string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_PCRCId,
                f.F_ProjectName as F_PIId,
                t.F_PCRCDate,
                d.F_FullName as F_PCRCDepartment,
                e.F_RealName as F_PCRCUser,
                t.F_MainFunctions,
                t.F_RiskPoint,
                t.F_RiskControlMeasures,
                t.F_ChargeOpinion,
                t.F_LeaderOpinion
                ");
                strSql.Append(@" from DC_EngineProject_ProjectCompanyRiskControl t 

left join LR_Base_Department d on t.F_PCRCDepartment=d.F_DepartmentId

left join  LR_Base_User e on t.F_PCRCUser=e.F_UserId
left join DC_EngineProject_ProjectInfo f on f.F_PIId=t.F_PIId");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["F_PIId"].IsEmpty())
                {
                    dp.Add("F_PIId", queryParam["F_PIId"].ToString(), DbType.String);
                    strSql.Append(" and F_PIId=@F_PIId");
                }
                DataTable dt = this.BaseRepository().FindTable(strSql.ToString(), dp);
                Dictionary<string, string> dic = new Dictionary<string, string>();
                DataConvertSerivers sevices = new DataConvertSerivers();
                sevices.ConvertDataByDataItem(dt, dic);
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
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_EngineProject_ProjectCompanyRiskControlEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_PCRCId,
                t.F_PIId,
                t.F_PCRCDate,
                t.F_PCRCDepartment,
                t.F_PCRCUser,
                t.F_MainFunctions,
                t.F_RiskPoint,
                t.F_RiskControlMeasures,
                t.F_ChargeOpinion,
                t.F_LeaderOpinion
                ");
                strSql.Append("  FROM DC_EngineProject_ProjectCompanyRiskControl t ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["F_PIId"].IsEmpty())
                {
                    dp.Add("F_PIId", queryParam["F_PIId"].ToString(), DbType.String);
                    strSql.Append(" and F_PIId=@F_PIId");
                }
                return this.BaseRepository().FindList<DC_EngineProject_ProjectCompanyRiskControlEntity>(strSql.ToString(), dp, pagination);
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
        /// 获取DC_EngineProject_ProjectCompanyRiskControl表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_EngineProject_ProjectCompanyRiskControlEntity GetDC_EngineProject_ProjectCompanyRiskControlEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_EngineProject_ProjectCompanyRiskControlEntity>(keyValue);
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
        /// 获取树形数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetSqlTree()
        {
            try
            {
                return this.BaseRepository().FindTable("   select f_piid as id , 0 as pid , f_projectname as name  from dc_engineproject_projectinfo ");
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
                this.BaseRepository().Delete<DC_EngineProject_ProjectCompanyRiskControlEntity>(t => t.F_PCRCId == keyValue);
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
        public void SaveEntity(string keyValue, DC_EngineProject_ProjectCompanyRiskControlEntity entity)
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
