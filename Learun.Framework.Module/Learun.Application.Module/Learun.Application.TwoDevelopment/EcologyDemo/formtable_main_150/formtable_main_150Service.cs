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
    /// 日 期：2019-12-04 14:52
    /// 描 述：formtable_main_150
    /// </summary>
    public class formtable_main_150Service : RepositoryFactory
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<formtable_main_150Entity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();

                strSql.Append(@"
             select 
d.departmentname as bm, h.F_ProjectName as xmmc,m.yd,m.jd,m.txsj,m.hbnr,m.xyjh,m.bz
from ecology.dbo.formtable_main_150  m  
join  ecology.dbo.workflow_requestbase r on m.requestid = r.requestid 

join  ecology.dbo.HrmDepartment d on m.bm = d.id 

join DC_EngineProject_ProjectInfo h on h.F_PIId = m.xmmc


where r.currentnodetype = 3
                ");
                // 虚拟参数
                var dp = new DynamicParameters(new { });
               
                return this.BaseRepository().FindList<formtable_main_150Entity>(strSql.ToString(),dp, pagination);
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
        public DataTable Getformtable_main_150List(string F_PIId)
        {
            try
            {
                var strSql = new StringBuilder();

                strSql.Append(@"
                        select 
d.departmentname as bm, h.F_ProjectName ,f.subcompanyname, m.xmmc,m.yd,m.jd,m.txsj,m.hbnr,m.xyjh,m.bz
from ecology.dbo.formtable_main_150  m  
join  ecology.dbo.workflow_requestbase r on m.requestid = r.requestid 

join  ecology.dbo.HrmDepartment d on m.bm = d.id 

join DC_EngineProject_ProjectInfo h on h.F_PIId = m.xmmc

join ecology.dbo.HrmSubCompany f on f.id=m.dwzj

where r.currentnodetype = 3 AND m.xmmc='" + F_PIId + "'");
              

                DataTable dt = this.BaseRepository().FindTable(strSql.ToString());

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
        /// 获取formtable_main_150表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public formtable_main_150Entity GetLastformtable_main_150Entity(string F_PIId)
        {
            try
            {
                var strSql = new StringBuilder();

                strSql.Append(@"
             select  top 1
 h.F_ProjectName , m.xmmc,m.yd,m.jd,m.txsj
from ecology.dbo.formtable_main_150  m  
join  ecology.dbo.workflow_requestbase r on m.requestid = r.requestid 

join  ecology.dbo.HrmDepartment d on m.bm = d.id 

join DC_EngineProject_ProjectInfo h on h.F_PIId = m.xmmc


where r.currentnodetype = 3 AND m.xmmc='" + F_PIId + "'");


                strSql.Append("  order by txsj desc");

                return this.BaseRepository().FindEntity<formtable_main_150Entity>(strSql.ToString(), null);
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
        /// 获取formtable_main_150表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public formtable_main_150Entity Getformtable_main_150Entity(string keyValue)
        {
            try
            {
                return this.BaseRepository("ecologySql").FindEntity<formtable_main_150Entity>(keyValue);
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
                this.BaseRepository("ecologySql").Delete<formtable_main_150Entity>(t=>t.id == keyValue.ToInt());
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
        public void SaveEntity(string keyValue, formtable_main_150Entity entity)
        {
            try
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    entity.Modify(keyValue.ToInt());
                    this.BaseRepository("ecologySql").Update(entity);
                }
                else
                {
                    entity.Create();
                    this.BaseRepository("ecologySql").Insert(entity);
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
