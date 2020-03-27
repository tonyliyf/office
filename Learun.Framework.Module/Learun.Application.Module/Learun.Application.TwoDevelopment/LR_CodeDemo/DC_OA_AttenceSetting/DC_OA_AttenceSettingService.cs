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
    /// 日 期：2019-01-16 17:54
    /// 描 述：考勤参数设置
    /// </summary>
    public class DC_OA_AttenceSettingService : RepositoryFactory
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_OA_AttenceSettingEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.DC_OA_AttenceSettingId,
                t.DC_OA_AttenceCenterPlace,
                t.DC_OA_AttenceLongitude,
                t.DC_OA_AttenceLatitude,
                t.DC_OAAttenceType,
                t.DC_OA_AttenceDistance,
                t.DC_OA_AttenceTimeUp1,
                t.DC_OA_AttenceTimeOut1,
                t.DC_OA_AttencetTimeUp2,
                t.DC_OA_AttenceTimeOut2,
                t.DC_OA_AttenceTimeUp3,
                t.DC_OA_AttenceTimeOut3,
                t.DC_OA_AttenceTimeUp4,
                t.DC_OA_AttenceTimeOut4,
                t.F_EnabledMark
                ");
                strSql.Append("  FROM DC_OA_AttenceSetting t ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["DC_OAAttenceType"].IsEmpty())
                {
                    dp.Add("DC_OAAttenceType",queryParam["DC_OAAttenceType"].ToString(), DbType.String);
                    strSql.Append(" AND t.DC_OAAttenceType = @DC_OAAttenceType ");
                }
                return this.BaseRepository().FindList<DC_OA_AttenceSettingEntity>(strSql.ToString(),dp, pagination);
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
        /// 获取DC_OA_AttenceSetting表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_OA_AttenceSettingEntity GetDC_OA_AttenceSettingEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_OA_AttenceSettingEntity>(keyValue);
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
        /// 获取DC_OA_AttenceSetting表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_OA_AttenceSettingEntity GetEnableDC_OA_AttenceSettingEntity()
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_OA_AttenceSettingEntity>(t => t.F_EnabledMark == 1);
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
                this.BaseRepository().Delete<DC_OA_AttenceSettingEntity>(t=>t.DC_OA_AttenceSettingId == keyValue);
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
        public void SaveEntity(string keyValue, DC_OA_AttenceSettingEntity entity)
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



        public void UpdateEntityState(string keyValue)
        {

            if (this.BaseRepository().ExecuteBySql("update DC_OA_AttenceSetting set  F_EnabledMark =0") > 0)
            {
                DC_OA_AttenceSettingEntity entity = GetDC_OA_AttenceSettingEntity(keyValue);
                entity.F_EnabledMark = 1;
                this.BaseRepository().Update(entity);

            }



        }

        #endregion

    }
}
