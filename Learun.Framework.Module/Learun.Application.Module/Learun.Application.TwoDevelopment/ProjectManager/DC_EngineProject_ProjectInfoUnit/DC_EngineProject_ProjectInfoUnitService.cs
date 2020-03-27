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
    /// 日 期：2019-03-09 15:56
    /// 描 述：工程项目单位信息管理
    /// </summary>
    public class DC_EngineProject_ProjectInfoUnitService : RepositoryFactory
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
                 *
                ");
                strSql.Append(" from DC_EngineProject_ProjectInfoUnit t ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["F_UnitName"].IsEmpty())
                {
                    dp.Add("F_UnitName", "%" + queryParam["F_UnitName"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_UnitName Like @F_UnitName ");
                }
                if (!queryParam["F_UnitContact"].IsEmpty())
                {
                    dp.Add("F_UnitContact", "%" + queryParam["F_UnitContact"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_UnitContact Like @F_UnitContact ");
                }
                DataTable dt = this.BaseRepository().FindTable(strSql.ToString(), dp);
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("F_UnitType", "EngineeringManageUnitType");
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
        public IEnumerable<DC_EngineProject_ProjectInfoUnitEntity> GetPageList(Pagination pagination, string queryJson, string F_UnitType)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                 *
                ");
              
                strSql.Append(" from DC_EngineProject_ProjectInfoUnit t ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["F_UnitName"].IsEmpty())
                {
                    dp.Add("F_UnitName", "%" + queryParam["F_UnitName"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_UnitName Like @F_UnitName ");
                }
                if (!queryParam["F_UnitContact"].IsEmpty())
                {
                    dp.Add("F_UnitContact", "%" + queryParam["F_UnitContact"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_UnitContact Like @F_UnitContact ");
                }
                if(!F_UnitType.IsEmpty())
                {

                    dp.Add("F_UnitType", F_UnitType, DbType.String);
                    strSql.Append(" AND t.F_UnitType= @F_UnitType ");
                }
                return this.BaseRepository().FindList<DC_EngineProject_ProjectInfoUnitEntity>(strSql.ToString(),dp, pagination);
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
        /// 获取DC_EngineProject_ProjectInfoUnit表数据
        /// <summary>
        /// <returns></returns>
        public IEnumerable<DC_EngineProject_ProjectInfoUnitEntity> GetDC_EngineProject_ProjectInfoUnitList(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindList<DC_EngineProject_ProjectInfoUnitEntity>(t=>t.F_PIId == keyValue );
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
        /// 获取DC_EngineProject_ProjectInfo表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_EngineProject_ProjectInfoEntity GetDC_EngineProject_ProjectInfoEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_EngineProject_ProjectInfoEntity>(keyValue);
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
        /// 获取DC_EngineProject_ProjectInfoUnit表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_EngineProject_ProjectInfoUnitEntity GetDC_EngineProject_ProjectInfoUnitEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_EngineProject_ProjectInfoUnitEntity>(t=>t.F_PIUId == keyValue);
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
               
                db.Delete<DC_EngineProject_ProjectInfoUnitEntity>(t=>t.F_PIUId == keyValue);
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
        public void SaveEntity(string keyValue, DC_EngineProject_ProjectInfoUnitEntity entity)
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
