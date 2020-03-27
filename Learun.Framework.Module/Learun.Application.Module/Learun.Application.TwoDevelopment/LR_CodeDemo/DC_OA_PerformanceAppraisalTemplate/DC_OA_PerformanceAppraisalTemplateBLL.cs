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
    /// 日 期：2019-01-24 09:28
    /// 描 述：DC_OA_PerformanceAppraisalTemplate
    /// </summary>
    public class DC_OA_PerformanceAppraisalTemplateBLL : DC_OA_PerformanceAppraisalTemplateIBLL
    {
        private DC_OA_PerformanceAppraisalTemplateService dC_OA_PerformanceAppraisalTemplateService = new DC_OA_PerformanceAppraisalTemplateService();

        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_OA_PerformanceAppraisalTemplateEntity> GetList(string queryJson)
        {
            try
            {
                return dC_OA_PerformanceAppraisalTemplateService.GetList(queryJson);
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
        /// 获取DC_OA_PerformanceAppraisalTemplate表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_OA_PerformanceAppraisalTemplateEntity GetDC_OA_PerformanceAppraisalTemplateEntity(string keyValue)
        {
            try
            {
                return dC_OA_PerformanceAppraisalTemplateService.GetDC_OA_PerformanceAppraisalTemplateEntity(keyValue);
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
                dC_OA_PerformanceAppraisalTemplateService.DeleteEntity(keyValue);
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
        public void SaveEntity(string keyValue, DC_OA_PerformanceAppraisalTemplateEntity entity)
        {
            try
            {
                dC_OA_PerformanceAppraisalTemplateService.SaveEntity(keyValue, entity);
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
