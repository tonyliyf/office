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
    /// 日 期：2019-08-02 15:33
    /// 描 述：HrmDepartment
    /// </summary>
    public class HrmDepartmentService : RepositoryFactory
    {
        #region 构造函数和属性

        private string fieldSql;
        public HrmDepartmentService()
        {
            fieldSql=@"
                t.id,
                t.departmentmark,
                t.departmentname,
                t.subcompanyid1,
                t.supdepid,
                t.allsupdepid,
                t.showorder,
                t.canceled,
                t.departmentcode,
                t.coadjutant,
                t.zzjgbmfzr,
                t.zzjgbmfgld,
                t.jzglbmfzr,
                t.jzglbmfgld,
                t.bmfzr,
                t.bmfgld,
                t.outkey,
                t.budgetAtuoMoveOrder,
                t.ecology_pinyin_search,
                t.tlevel,
                t.created,
                t.creater,
                t.modified,
                t.modifier
            ";
        }
        #endregion

        #region 获取数据

        /// <summary>
        /// 获取列表数据
        /// <summary>
        /// <returns></returns>
        public IEnumerable<HrmDepartmentEntity> GetList( string queryJson )
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
                strSql.Append(" FROM ecology.dbo.HrmDepartment t ");
                return this.BaseRepository().FindList<HrmDepartmentEntity>(strSql.ToString());
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
        public IEnumerable<HrmDepartmentEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(fieldSql);
                strSql.Append(" FROM HrmDepartment t ");
                return this.BaseRepository("ecologySql").FindList<HrmDepartmentEntity>(strSql.ToString(), pagination);
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
        public HrmDepartmentEntity GetEntity(int keyValue)
        {
            try
            {
                return this.BaseRepository("ecologySql").FindEntity<HrmDepartmentEntity>(keyValue);
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
        public void DeleteEntity(int keyValue)
        {
            try
            {
                this.BaseRepository("ecologySql").Delete<HrmDepartmentEntity>(t=>t.id == keyValue);
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
        public void SaveEntity(int keyValue, HrmDepartmentEntity entity)
        {
            try
            {
                if (!keyValue.IsEmpty())
                {
                    entity.Modify(keyValue);
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
