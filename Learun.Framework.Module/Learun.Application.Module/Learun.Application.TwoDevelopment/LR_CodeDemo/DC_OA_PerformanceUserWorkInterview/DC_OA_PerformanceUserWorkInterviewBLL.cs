﻿using Learun.Util;
using System;
using System.Data;
using System.Collections.Generic;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-03-12 12:57
    /// 描 述：DC_OA_PerformanceUserWorkInterview
    /// </summary>
    public class DC_OA_PerformanceUserWorkInterviewBLL : DC_OA_PerformanceUserWorkInterviewIBLL
    {
        private DC_OA_PerformanceUserWorkInterviewService dC_OA_PerformanceUserWorkInterviewService = new DC_OA_PerformanceUserWorkInterviewService();

        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_OA_PerformanceUserWorkInterviewEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                return dC_OA_PerformanceUserWorkInterviewService.GetPageList(pagination, queryJson);
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
        /// 获取DC_OA_PerformanceUserWorkInterview表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_OA_PerformanceUserWorkInterviewEntity GetDC_OA_PerformanceUserWorkInterviewEntity(string keyValue)
        {
            try
            {
                return dC_OA_PerformanceUserWorkInterviewService.GetDC_OA_PerformanceUserWorkInterviewEntity(keyValue);
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
                dC_OA_PerformanceUserWorkInterviewService.DeleteEntity(keyValue);
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
        public void SaveEntity(string keyValue, DC_OA_PerformanceUserWorkInterviewEntity entity)
        {
            try
            {
                dC_OA_PerformanceUserWorkInterviewService.SaveEntity(keyValue, entity);
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
        public void Execute(string cid, int r, string advice = "")
        {
            try
            {
                dC_OA_PerformanceUserWorkInterviewService.Execute(cid,r,advice);
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