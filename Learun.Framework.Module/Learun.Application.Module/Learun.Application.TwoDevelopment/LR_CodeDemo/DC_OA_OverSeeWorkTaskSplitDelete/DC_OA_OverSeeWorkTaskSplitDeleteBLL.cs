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
    /// 日 期：2019-01-08 15:54
    /// 描 述：DC_OA_OverSeeWorkTaskSplitDelete
    /// </summary>
    public class DC_OA_OverSeeWorkTaskSplitDeleteBLL : DC_OA_OverSeeWorkTaskSplitDeleteIBLL
    {
        private DC_OA_OverSeeWorkTaskSplitDeleteService dC_OA_OverSeeWorkTaskSplitDeleteService = new DC_OA_OverSeeWorkTaskSplitDeleteService();

        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_OA_OverSeeWorkTaskSplitEntity> GetList(string keyValue, string queryJson)
        {
            try
            {
                return dC_OA_OverSeeWorkTaskSplitDeleteService.GetList(keyValue, queryJson);
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
        public IEnumerable<DC_OA_OverSeeWorkTaskSplitEntity> GetListEx(string keyValue, string queryJson)
        {
            try
            {
                return dC_OA_OverSeeWorkTaskSplitDeleteService.GetListEx(keyValue, queryJson);
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
                return dC_OA_OverSeeWorkTaskSplitDeleteService.GetDC_OA_OverSeeWorkTaskSplitEntity(keyValue);
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
                dC_OA_OverSeeWorkTaskSplitDeleteService.DeleteEntity(keyValue);
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
        public void SaveEntity(string keyValue, DC_OA_OverSeeWorkTaskSplitEntity entity)
        {
            try
            {
                dC_OA_OverSeeWorkTaskSplitDeleteService.SaveEntity(keyValue, entity);
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
        public IEnumerable<DC_OA_OverSeeWorkTaskSplitEntity> GetList(string queryJson)
        {
            try
            {
                return dC_OA_OverSeeWorkTaskSplitDeleteService.GetList(queryJson);
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
        public DataTable GetNoticeMembersData(string keyValue, out string noticeContent)
        {
            try
            {
                return dC_OA_OverSeeWorkTaskSplitDeleteService.GetNoticeMembersData(keyValue, out noticeContent);
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
