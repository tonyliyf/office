using Learun.Util;
using System;
using System.Data;
using System.Collections.Generic;
using Learun.Application.Organization;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-01-24 17:30
    /// 描 述：DC_OA_PerformanceRecordRun
    /// </summary>
    public class DC_OA_PerformanceRecordRunBLL : DC_OA_PerformanceRecordRunIBLL
    {
        private DC_OA_PerformanceRecordRunService dC_OA_PerformanceRecordRunService = new DC_OA_PerformanceRecordRunService();

        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_OA_PerformanceRecordRunEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                return dC_OA_PerformanceRecordRunService.GetPageList(pagination, queryJson);
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
        /// 获取DC_OA_PerformanceRecordRun表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_OA_PerformanceRecordRunEntity GetDC_OA_PerformanceRecordRunEntity(string keyValue)
        {
            try
            {
                return dC_OA_PerformanceRecordRunService.GetDC_OA_PerformanceRecordRunEntity(keyValue);
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
        public List<UserEntity> GetUserList(string tid)
        {
            try
            {
                return dC_OA_PerformanceRecordRunService.GetUserList(tid);
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
        public List<UserEntity> GetCheckerList(string tid)
        {
            try
            {
                return dC_OA_PerformanceRecordRunService.GetCheckerList(tid);
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
        public void SaveUserList(string rid, string userIds)
        {
            try
            {
                dC_OA_PerformanceRecordRunService.SaveUserList(rid, userIds);
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

        public List<UserEntity> GetUserIdList(string rid, out string userIds)
        {
            try
            {
                return dC_OA_PerformanceRecordRunService.GetUserIdList(rid, out userIds);
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
                dC_OA_PerformanceRecordRunService.DeleteEntity(keyValue);
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
        public void SaveEntity(string keyValue, DC_OA_PerformanceRecordRunEntity entity)
        {
            try
            {
                dC_OA_PerformanceRecordRunService.SaveEntity(keyValue, entity);
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
