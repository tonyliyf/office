using Dapper;
using Learun.DataBase.Repository;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Learun.Application.TwoDevelopment.EcologyDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-09-16 16:28
    /// 描 述：formtable_main_131
    /// </summary>
    public class formtable_main_131Service : RepositoryFactory
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<formtable_main_131Entity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
           
                strSql.Append(@"  select d.F_EquipmentName ,h.lastname ,m.* from ecology.dbo.formtable_main_131  m  join  ecology.dbo.workflow_requestbase r
on m.requestid = r.requestid join  DC_ASSETS_EquipmentInfo d on m.sbmc = d.F_EIId join ecology.dbo.hrmresource h on
m.sqyh = h.id where r.currentnodetype = 3 ");
                strSql.Append("   ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["sbmc"].IsEmpty())
                {
                    dp.Add("sbmc", "%" + queryParam["sbmc"].ToString() + "%", DbType.String);
                    strSql.Append(" AND d.F_EquipmentName Like @sbmc ");
                }
                return this.BaseRepository().FindList<formtable_main_131Entity>(strSql.ToString(),dp, pagination);
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


        /// <returns></returns>
        public IEnumerable<formtable_main_131Entity> GetList(string SearchValue)
        {
            try
            {
                var strSql = new StringBuilder();

                strSql.Append(@"  select d.F_EquipmentName ,h.lastname ,m.* from ecology.dbo.formtable_main_131  m  join  ecology.dbo.workflow_requestbase r
on m.requestid = r.requestid join  DC_ASSETS_EquipmentInfo d on m.sbmc = d.F_EIId join ecology.dbo.hrmresource h on
m.sqyh = h.id where r.currentnodetype = 3 ");
                strSql.Append("   ");
               
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!string.IsNullOrEmpty(SearchValue))
                {

                    dp.Add("sbmc", "%" + SearchValue + "%", DbType.String);
                    strSql.Append(" AND d.F_EquipmentName Like @sbmc ");
                }
              
                return this.BaseRepository().FindList<formtable_main_131Entity>(strSql.ToString(), dp);
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
        /// 获取formtable_main_131表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public formtable_main_131Entity Getformtable_main_131Entity(string keyValue)
        {
            try
            {
                return this.BaseRepository("ecologySql").FindEntity<formtable_main_131Entity>(keyValue);
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
        public formtable_main_131Entity GetDC_EngineProject_Getformtable_main_131Entity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<formtable_main_131Entity>(keyValue);
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



        #endregion

    }
}
