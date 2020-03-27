using Learun.Util;
using System;
using System.Data;
using System.Collections.Generic;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-01-25 17:08
    /// 描 述：DC_OA_PerformanceUserWorkPlan
    /// </summary>
    public class DC_OA_PerformanceUserWorkPlanBLL : DC_OA_PerformanceUserWorkPlanIBLL
    {
        private DC_OA_PerformanceUserWorkPlanService dC_OA_PerformanceUserWorkPlanService = new DC_OA_PerformanceUserWorkPlanService();

        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_OA_PerformanceUserWorkPlanEntity> GetList(string keyValue)
        {
            try
            {
                return dC_OA_PerformanceUserWorkPlanService.GetList(keyValue);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }
        public IEnumerable<DC_OA_PerformanceUserWorkPlanEntity> GetEvaluate2List(string keyValue)
        {
            try
            {
                return dC_OA_PerformanceUserWorkPlanService.GetEvaluate2List(keyValue);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }
        /// <summary>
        /// 获取DC_OA_PerformanceUserWorkPlan表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_OA_PerformanceUserWorkPlanEntity GetDC_OA_PerformanceUserWorkPlanEntity(string keyValue)
        {
            try
            {
                return dC_OA_PerformanceUserWorkPlanService.GetDC_OA_PerformanceUserWorkPlanEntity(keyValue);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }
        public void SaveEvaluate3Entity(string wpid, int? score)
        {
            try
            {
                dC_OA_PerformanceUserWorkPlanService.SaveEvaluate3Entity(wpid, score);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }
        public DC_OA_PerformanceUserWorkPlanEntity GetEvaluateEntity(string keyValue)
        {
            try
            {
                return dC_OA_PerformanceUserWorkPlanService.GetEvaluateEntity(keyValue);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
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
                dC_OA_PerformanceUserWorkPlanService.DeleteEntity(keyValue);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }

        /// <summary>
        /// 保存实体数据（新增、修改）
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public void SaveEntity(string keyValue, DC_OA_PerformanceUserWorkPlanEntity entity)
        {
            try
            {
                dC_OA_PerformanceUserWorkPlanService.SaveEntity(keyValue, entity);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }

        #endregion

    }
}
