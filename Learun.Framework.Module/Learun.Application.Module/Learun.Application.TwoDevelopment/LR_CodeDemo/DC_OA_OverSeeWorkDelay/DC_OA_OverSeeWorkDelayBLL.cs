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
    /// 日 期：2019-03-02 16:37
    /// 描 述：DC_OA_OverSeeWorkDelay
    /// </summary>
    public class DC_OA_OverSeeWorkDelayBLL : DC_OA_OverSeeWorkDelayIBLL
    {
        private DC_OA_OverSeeWorkDelayService dC_OA_OverSeeWorkDelayService = new DC_OA_OverSeeWorkDelayService();

        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_OA_OverSeeWorkDelayEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                return dC_OA_OverSeeWorkDelayService.GetPageList(pagination, queryJson);
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
        /// 获取DC_OA_OverSeeWorkDelayDetailed表数据
        /// <summary>
        /// <returns></returns>
        public IEnumerable<DC_OA_OverSeeWorkDelayDetailedEntity> GetDC_OA_OverSeeWorkDelayDetailedList(string keyValue)
        {
            try
            {
                return dC_OA_OverSeeWorkDelayService.GetDC_OA_OverSeeWorkDelayDetailedList(keyValue);
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
        /// 获取DC_OA_OverSeeWorkDelay表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_OA_OverSeeWorkDelayEntity GetDC_OA_OverSeeWorkDelayEntity(string keyValue)
        {
            try
            {
                return dC_OA_OverSeeWorkDelayService.GetDC_OA_OverSeeWorkDelayEntity(keyValue);
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
        /// 获取DC_OA_OverSeeWorkDelayDetailed表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_OA_OverSeeWorkDelayDetailedEntity GetDC_OA_OverSeeWorkDelayDetailedEntity(string keyValue)
        {
            try
            {
                return dC_OA_OverSeeWorkDelayService.GetDC_OA_OverSeeWorkDelayDetailedEntity(keyValue);
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
        /// 获取主表实体数据
        /// <param name="processId">流程实例ID</param>
        /// <summary>
        /// <returns></returns>
        public DC_OA_OverSeeWorkDelayEntity GetEntityByProcessId(string processId)
        {
            try
            {
                return dC_OA_OverSeeWorkDelayService.GetEntityByProcessId(processId);
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
                dC_OA_OverSeeWorkDelayService.DeleteEntity(keyValue);
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
        public void SaveEntity(string keyValue, DC_OA_OverSeeWorkDelayEntity entity, List<DC_OA_OverSeeWorkDelayDetailedEntity> dC_OA_OverSeeWorkDelayDetailedList)
        {
            try
            {
                dC_OA_OverSeeWorkDelayService.SaveEntity(keyValue, entity, dC_OA_OverSeeWorkDelayDetailedList);
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
        public List<DC_OA_OverSeeWorkDelayDetailedEntity> StatisticsWorkByWorkIds(string workId)
        {
            try
            {
                return dC_OA_OverSeeWorkDelayService.StatisticsWorkByWorkIds(workId);
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
        public DC_OA_OverSeeWorkEntity GetWorkEntity(string keyValue)
        {
            try
            {
                return dC_OA_OverSeeWorkDelayService.GetWorkEntity(keyValue);
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
        public string Createflow(string MainKeyvalue)
        {
            try
            {
                return dC_OA_OverSeeWorkDelayService.Createflow(MainKeyvalue);
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
    }
}
