using Dapper;
using Learun.Application.TwoDevelopment.SystemDemo;
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
    /// 日 期：2020-01-02 10:05
    /// 描 述：督办任务评论
    /// </summary>
    public class Uf_DbrwplbService : RepositoryFactory
    {

        public HrmResourceIBLL resource = new HrmResourceBLL();

        #region 构造函数和属性

        private string fieldSql;
        public Uf_DbrwplbService()
        {
            fieldSql= @"
                t.id,
                t.requestId,
                t.maxzrwid,
                t.minzrwid,
                t.plbm,
                t.plr,
                t.plsj,
                t.pllr,
                t.bz,
                t.maxzrwmc,
                t.minzrwmc,
                t.plzt,
                t.plsjx,
                t.replyid
            ";
        }
        #endregion

        #region 获取数据

        /// <summary>
        /// 获取列表数据
        /// <summary>
        /// <returns></returns>
        public IEnumerable<uf_dbrwplbEntity> GetList( string taskid,string subtaskid )
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
                strSql.Append(" FROM ecology.dbo.uf_dbrwplb t where 1=1 ");


                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!string.IsNullOrEmpty(taskid))
                {

                    dp.Add("sbmc", "'" + taskid + "'", DbType.String);
                    strSql.Append(" AND t.maxzrwid = @sbmc ");
                }

                if (!string.IsNullOrEmpty(subtaskid))
                {

                    dp.Add("subsbmc", "'" + subtaskid + "'", DbType.String);
                    strSql.Append(" AND t.minzrwid = @subsbmc ");
                }
                else
                {

                    strSql.Append(" AND t.minzrwid is null ");
                }

                return this.BaseRepository().FindList<uf_dbrwplbEntity>(strSql.ToString());
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
        /// 获取列表数据
        /// <summary>
        /// <returns></returns>
        public DataSet GettableList(string taskid, string subtaskid)
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
                strSql.Append(" FROM ecology.dbo.uf_dbrwplb t where 1=1 ");


                var strSql2 = new StringBuilder();
                strSql2.Append("SELECT ");
                strSql2.Append(fieldSql);
                strSql2.Append(" FROM ecology.dbo.uf_dbrwplb t where 1=1 ");


                // 虚拟参数
                // var dp = new DynamicParameters(new { });
                if (!string.IsNullOrEmpty(taskid))
                {

                    //dp.Add("sbmc", "'" + taskid + "'", DbType.String);
                    strSql.Append(" AND t.maxzrwid =  '" +taskid  +"'");
                    strSql2.Append(" AND t.maxzrwid =  '" + taskid + "'");
                }

                if (!string.IsNullOrEmpty(subtaskid))
                {

                   // dp.Add("subsbmc", "'" + subtaskid + "'", DbType.String);
                    strSql.Append(" AND t.minzrwid = '"+subtaskid +"'");
                    strSql2.Append(" AND t.minzrwid = '" + subtaskid + "'");
                }
                else
                {

                    strSql.Append(" AND t.minzrwid is null ");
                    strSql2.Append(" AND t.minzrwid is null ");
                }
                strSql.Append(" And replyid is null");
                strSql.Append(" order by id desc");

                strSql2.Append(" And replyid >0");
                strSql2.Append(" order by replyid,id desc");
                //SimpleLogUtil.WriteTextLog("subtaskeeeeee", strSql.ToString(), DateTime.Now);
                DataTable dt = this.BaseRepository().FindTable(strSql.ToString());
                dt.TableName = "dt1";
                DataTable dt2 = this.BaseRepository().FindTable(strSql2.ToString());
                dt2.TableName = "dt2";
                DataConvertSerivers sevices = new DataConvertSerivers();
                sevices.ConvertDataByWeaveDepartment(dt, new string[] { "plbm" });
                sevices.ConvertDataByWeaveHrmResouce(dt, new string[] { "plr" });

                sevices.ConvertDataByWeaveDepartment(dt2, new string[] { "plbm" });
                sevices.ConvertDataByWeaveHrmResouce(dt2, new string[] { "plr" });

                DataSet dtSet = new DataSet();
                dtSet.Tables.Add(dt);
                dtSet.Tables.Add(dt2);
                //dtSet.AcceptChanges();
                //  SimpleLogUtil.WriteTextLog("wwww",strSql.ToString(),DateTime.Now);

                return dtSet;
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
        public IEnumerable<uf_dbrwplbEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(fieldSql);
                strSql.Append(" FROM ecology.dbo.uf_dbrwplb t ");
                return this.BaseRepository().FindList<uf_dbrwplbEntity>(strSql.ToString(), pagination);
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
        public uf_dbrwplbEntity GetEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository("ecologySql").FindEntity<uf_dbrwplbEntity>(keyValue);
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
                this.BaseRepository("ecologySql").Delete<uf_dbrwplbEntity>(t=>t.id == int.Parse(keyValue));
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
        public void SaveEntity(string keyValue, uf_dbrwplbEntity entity)
        {
            try
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    entity.Modify(int.Parse(keyValue));
                    this.BaseRepository("ecologySql").Update(entity);
                }
                else
                {
                  //  SimpleLogUtil.WriteTextLog("uf_dbrwplbEntityid", entity.plr.ToString(), DateTime.Now);
                    if (!string.IsNullOrEmpty(entity.plr.ToString()))
                    {
                        HrmResourceEntity userentity = resource.GetEntity((int)entity.plr);
                        entity.plbm = userentity.departmentid;


                    }
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
        /// <summary>
        /// 保存实体数据（评论回复）
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public void SavePLHF(string keyValue, uf_dbrwplbEntity entity, string replyid)
        {
            try
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    entity.Modify(int.Parse(keyValue));
                    this.BaseRepository("ecologySql").Update(entity);
                }
                else
                {
                    //  SimpleLogUtil.WriteTextLog("uf_dbrwplbEntityid", entity.plr.ToString(), DateTime.Now);
                    if (!string.IsNullOrEmpty(entity.plr.ToString())&& !string.IsNullOrEmpty(replyid))
                    {
                        HrmResourceEntity userentity = resource.GetEntity((int)entity.plr);
                        entity.plbm = userentity.departmentid;
                        entity.replyid =Convert.ToInt32(replyid);
                    }
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
