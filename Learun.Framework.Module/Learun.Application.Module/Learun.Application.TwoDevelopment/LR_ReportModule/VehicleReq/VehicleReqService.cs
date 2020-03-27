using Dapper;
using Learun.DataBase.Repository;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Learun.Application.TwoDevelopment.LR_ReportModule
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-02-27 16:45
    /// 描 述：VehicleReq报表
    /// </summary>
    public class VehicleReqService : RepositoryFactory
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<VehicleReqEntity> GetPageList(string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_Title,
                t.F_Degree,
                V.F_State as F_CarUsage,
			    v.F_VehicleName AS F_Vehicle, 
				B.F_RealName as F_Driver,               
                u.F_RealName as F_User,
                d.F_FullName as F_Dept,
				b.F_RealName as F_Applicant,
                t.F_Cause,
                t.F_Cost,
                t.F_Mileage,
                t.F_TotalPrice,
                t.F_StartTime,
                t.F_EndTime,
                t.F_Note,
                t.F_Manager,
                t.F_Opinion
                ");
                strSql.Append("FROM VehicleReq t ");
                strSql.Append(" left join LR_Base_User u on t.F_User =u.F_UserId");
                strSql.Append("	left join DC_OA_Vehicle V on v.F_VehicleId=t.F_Vehicle");
                strSql.Append("  left join LR_Base_User B on B.F_UserId=t.F_Driver ");
                strSql.Append("  left join LR_Base_Department d  on t.F_Dept =d.F_DepartmentId");
                strSql.Append(" WHERE t.is_agree=2 ");

                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["StartTime"].IsEmpty() && !queryParam["EndTime"].IsEmpty())
                {

                    dp.Add("StartTime", queryParam["StartTime"].ToDate(), DbType.DateTime);
                    dp.Add("EndTime", queryParam["EndTime"].ToDate(), DbType.DateTime);
                    strSql.Append(" AND ( t.F_StartTime >= @StartTime AND t.F_StartTime <= @EndTime ) ");
                }
                if (!queryParam["F_Title"].IsEmpty())
                {
                    dp.Add("F_Title", "%" + queryParam["F_Title"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_Title Like @F_Title ");
                }
                if (!queryParam["F_User"].IsEmpty())
                {
                    dp.Add("F_User", "%" + queryParam["F_User"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_User Like @F_User ");
                }
                if (!queryParam["F_Dept"].IsEmpty())
                {
                    dp.Add("F_Dept", "%" + queryParam["F_Dept"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_Dept Like @F_Dept ");
                }

                return this.BaseRepository().FindList<VehicleReqEntity>(strSql.ToString(), dp);
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
        /// 获取VehicleReq表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public VehicleReqEntity GetVehicleReqEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository("WFDB").FindEntity<VehicleReqEntity>(keyValue);
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
                this.BaseRepository("WFDB").Delete<VehicleReqEntity>(t=>t.F_Id == keyValue);
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
        public void SaveEntity(string keyValue, VehicleReqEntity entity)
        {
            try
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    entity.Modify(keyValue);
                    this.BaseRepository("WFDB").Update(entity);
                }
                else
                {
                    entity.Create();
                    this.BaseRepository("WFDB").Insert(entity);
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
