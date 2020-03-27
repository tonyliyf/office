using Learun.Util;
using System;
using System.Data;
using System.Collections.Generic;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.0 企业敏捷开发框架
    /// Copyright (c) 2018-2019 武汉东雅图科技技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-01-07 17:47
    /// 描 述：DC_OA_OverSeeWorkTaskExecute
    /// </summary>
    public class DC_OA_OverSeeWorkTaskExecuteBLL : DC_OA_OverSeeWorkTaskExecuteIBLL
    {
        private DC_OA_OverSeeWorkTaskExecuteService dC_OA_OverSeeWorkTaskExecuteService = new DC_OA_OverSeeWorkTaskExecuteService();

        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_OA_OverSeeWorkTaskSplitEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                return dC_OA_OverSeeWorkTaskExecuteService.GetPageList(pagination, queryJson);
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
        public IEnumerable<DC_OA_OverSeeWorkTaskExecuteEntity> GetPageListEx(Pagination pagination, string queryJson)
        {
            try
            {
                return dC_OA_OverSeeWorkTaskExecuteService.GetPageListEx(pagination, queryJson);
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
        /// 获取DC_OA_OverSeeWorkTaskExecute表数据
        /// <summary>
        /// <returns></returns>
        public IEnumerable<DC_OA_OverSeeWorkTaskExecuteEntity> GetDC_OA_OverSeeWorkTaskExecuteList(string keyValue)
        {
            try
            {
                return dC_OA_OverSeeWorkTaskExecuteService.GetDC_OA_OverSeeWorkTaskExecuteList(keyValue);
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
        /// 获取DC_OA_OverSeeWorkTaskSplit表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_OA_OverSeeWorkTaskSplitEntity GetDC_OA_OverSeeWorkTaskSplitEntity(string keyValue)
        {
            try
            {
                return dC_OA_OverSeeWorkTaskExecuteService.GetDC_OA_OverSeeWorkTaskSplitEntity(keyValue);
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
        /// 获取DC_OA_OverSeeWorkTaskExecute表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_OA_OverSeeWorkTaskExecuteEntity GetDC_OA_OverSeeWorkTaskExecuteEntity(string keyValue)
        {
            try
            {
                return dC_OA_OverSeeWorkTaskExecuteService.GetDC_OA_OverSeeWorkTaskExecuteEntity(keyValue);
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
                dC_OA_OverSeeWorkTaskExecuteService.DeleteEntity(keyValue);
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
        public void DeleteEntityEx(string keyValue)
        {
            try
            {
                dC_OA_OverSeeWorkTaskExecuteService.DeleteEntityEx(keyValue);
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
        public void SaveEntity(string TID, string PID, string keyValue, DC_OA_OverSeeWorkTaskSplitEntity entity)
        {
            try
            {
                dC_OA_OverSeeWorkTaskExecuteService.SaveEntity(TID, PID, keyValue, entity);
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
        public void SaveEntity(string keyValue, DC_OA_OverSeeWorkTaskExecuteEntity entity)
        {
            try
            {
                dC_OA_OverSeeWorkTaskExecuteService.SaveEntity(keyValue, entity);
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
