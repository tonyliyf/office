using Dapper;
using Learun.DataBase.Repository;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.0 企业敏捷开发框架
    /// Copyright (c) 2018-2019 武汉东雅图科技技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-01-04 11:32
    /// 描 述：节假日设置
    /// </summary>
    public class DC_OA_HolidaySettingService : RepositoryFactory
    {
        #region 构造函数和属性

        private string fieldSql;
        public DC_OA_HolidaySettingService()
        {
            fieldSql = @"
                t.DC_OA_Holiday,
                t.DC_OA_Date,
                t.DC_OA_Week,
                t.DC_OA_Remarks,
                t.DC_OA_IsWork,
                t.F_ModifyUserName,
                t.F_ModifyUserId,
                t.F_ModifyDate,
                t.F_CreateUserName,
                t.F_CurrentUserId,
                t.F_CreateDate,
                t.F_Description
            ";
        }
        #endregion

        #region 获取数据
        public IEnumerable<DC_OA_HolidaySettingEntity> GetHolidayDataByMonth(DateTime time)
        {
            DateTime start = new DateTime(time.Year, time.Month, 1, 0, 0, 0);
            DateTime end = start.AddMonths(1);
            try
            {
                var result = this.BaseRepository().FindList<DC_OA_HolidaySettingEntity>(c => c.DC_OA_Date >= start && c.DC_OA_Date <= end && c.DC_OA_IsWork != 0);
                return result.OrderBy(c => c.DC_OA_Date);
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
        public IEnumerable<DC_OA_HolidaySettingEntity> GetList(DateTime dtStart, DateTime dtEnd)
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
                strSql.Append(" FROM DC_OA_HolidaySetting t ");
                return this.BaseRepository().FindList<DC_OA_HolidaySettingEntity>(c => c.DC_OA_Date >= dtStart && c.DC_OA_Date <dtEnd);
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
        public IEnumerable<DC_OA_HolidaySettingEntity> GetList(string queryJson)
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
                strSql.Append(" FROM DC_OA_HolidaySetting t ");
                return this.BaseRepository().FindList<DC_OA_HolidaySettingEntity>(strSql.ToString());
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
        public IEnumerable<DC_OA_HolidaySettingEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(fieldSql);
                strSql.Append(" FROM DC_OA_HolidaySetting t ");
                return this.BaseRepository().FindList<DC_OA_HolidaySettingEntity>(strSql.ToString(), pagination);
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
        public DC_OA_HolidaySettingEntity GetEntity(string keyValue)
        {
            try
            {
                DateTime time = Convert.ToDateTime(keyValue);
                return this.BaseRepository().FindEntity<DC_OA_HolidaySettingEntity>(c=>c.DC_OA_Date==time);
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
                this.BaseRepository().Delete<DC_OA_HolidaySettingEntity>(t => t.DC_OA_Holiday == keyValue);
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
        public void SaveEntity(string keyValue, DC_OA_HolidaySettingEntity entity)
        {
            try
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    DateTime time = Convert.ToDateTime(keyValue);
                    var model = this.BaseRepository().FindEntity<DC_OA_HolidaySettingEntity>(c=>c.DC_OA_Date==time);
                    model.DC_OA_Remarks = entity.DC_OA_Remarks;
                    model.DC_OA_IsWork = entity.DC_OA_IsWork;
                    model.Modify(model.DC_OA_Holiday);
                    this.BaseRepository().Update(model);
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


        public void SaveHolidayInfo(List<HolidayInfo> list)
        {

            var db = this.BaseRepository().BeginTrans();
            DC_OA_HolidaySettingEntity entity = new DC_OA_HolidaySettingEntity();
            try
            {
                foreach (HolidayInfo item in list)
                {
                    entity = new DC_OA_HolidaySettingEntity();
                    entity.DC_OA_Date = item.DC_OA_Date;
                    entity.DC_OA_IsWork = item.DC_OA_IsWork;
                    entity.DC_OA_Remarks = item.DC_OA_Remarks;
                    entity.DC_OA_Week = item.DC_OA_Week;
                    entity.Create();
                    db.Insert(entity);

                }

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
        #endregion

    }
}
