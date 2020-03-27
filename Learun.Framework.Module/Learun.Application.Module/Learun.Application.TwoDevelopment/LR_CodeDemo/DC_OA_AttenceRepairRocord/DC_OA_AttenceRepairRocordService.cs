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
    /// 日 期：2019-02-10 14:09
    /// 描 述：DC_OA_AttenceRepairRocord
    /// </summary>
    public class DC_OA_AttenceRepairRocordService : RepositoryFactory
    {
        #region 构造函数和属性

        private string fieldSql;
        public DC_OA_AttenceRepairRocordService()
        {
            fieldSql=@"
                t.DC_OA_RepairRecordId,
                t.DC_OA_RepairRecordUserId,
                t.DC_OA_RepairReason,
                t.DC_OA_RepairDeptId,
                t.DC_OA_RepairCompanyId,
                t.Dc_OA_RepairType,
                t.F_EnabledMark,
                t.F_CreateUserId,
                t.F_ModifyUserName,
                t.F_ModifyUserId,
                t.F_DeleteMark,
                t.F_SortCode,
                t.F_CreateUserName,
                t.F_CreateDate,
                t.F_Description,
                t.F_RepairDate,
                t.Is_agree
            ";
        }
        #endregion

        #region 获取数据

        /// <summary>
        /// 获取列表数据
        /// <summary>
        /// <returns></returns>
        public IEnumerable<DC_OA_AttenceRepairRocordEntity> GetList( string queryJson )
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
                strSql.Append(" FROM DC_OA_AttenceRepairRocord t ");
                return this.BaseRepository( ).FindList<DC_OA_AttenceRepairRocordEntity>(strSql.ToString());
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



        public IEnumerable<DC_OA_AttenceRepairRocordEntity> GetList(DateTime dtStart, DateTime dtEnd)
        {
            try
            {
                //参考写法
                //var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                //dp.Add("startTime", queryParam["StartTime"].ToDate(), DbType.DateTime);
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(fieldSql);
                strSql.Append(" FROM DC_OA_AttenceRepairRocord t where Is_agree =2");

                if (!dtStart.IsEmpty() && !dtEnd.IsEmpty())
                {
                    dp.Add("startTime", dtStart, DbType.DateTime);
                    dp.Add("endTime", dtEnd, DbType.DateTime);
                    strSql.Append(" and  t.F_RepairDate >= @startTime AND t.F_RepairDate < @endTime ");
                }
                return this.BaseRepository( ).FindList<DC_OA_AttenceRepairRocordEntity>(strSql.ToString(),dp);
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
        public IEnumerable<DC_OA_AttenceRepairRocordEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(fieldSql);
                strSql.Append(" FROM DC_OA_AttenceRepairRocord t ");
                return this.BaseRepository( ).FindList<DC_OA_AttenceRepairRocordEntity>(strSql.ToString(), pagination);
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
        public DC_OA_AttenceRepairRocordEntity GetEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository( ).FindEntity<DC_OA_AttenceRepairRocordEntity>(keyValue);
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
                this.BaseRepository( ).Delete<DC_OA_AttenceRepairRocordEntity>(t=>t.DC_OA_RepairRecordId == keyValue);
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
        public void SaveEntity(string keyValue, DC_OA_AttenceRepairRocordEntity entity)
        {
            try
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    entity.Modify(keyValue);
                    this.BaseRepository( ).Update(entity);
                }
                else
                {
                    entity.Create();
                    this.BaseRepository( ).Insert(entity);
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
