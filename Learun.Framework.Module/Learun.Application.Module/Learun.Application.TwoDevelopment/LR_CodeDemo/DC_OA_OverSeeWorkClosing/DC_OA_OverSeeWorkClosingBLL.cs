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
    /// 日 期：2019-03-02 12:34
    /// 描 述：DC_OA_OverSeeWorkClosing
    /// </summary>
    public class DC_OA_OverSeeWorkClosingBLL : DC_OA_OverSeeWorkClosingIBLL
    {
        private DC_OA_OverSeeWorkClosingService dC_OA_OverSeeWorkClosingService = new DC_OA_OverSeeWorkClosingService();

        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_OA_OverSeeWorkClosingEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                return dC_OA_OverSeeWorkClosingService.GetPageList(pagination, queryJson);
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
        /// 获取DC_OA_OverSeeWorkClosingDetailed表数据
        /// <summary>
        /// <returns></returns>
        public IEnumerable<DC_OA_OverSeeWorkClosingDetailedEntity> GetDC_OA_OverSeeWorkClosingDetailedList(string keyValue)
        {
            try
            {
                return dC_OA_OverSeeWorkClosingService.GetDC_OA_OverSeeWorkClosingDetailedList(keyValue);
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
        /// 获取DC_OA_OverSeeWorkClosing表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_OA_OverSeeWorkClosingEntity GetDC_OA_OverSeeWorkClosingEntity(string keyValue)
        {
            try
            {
                return dC_OA_OverSeeWorkClosingService.GetDC_OA_OverSeeWorkClosingEntity(keyValue);
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
        /// 获取DC_OA_OverSeeWorkClosingDetailed表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_OA_OverSeeWorkClosingDetailedEntity GetDC_OA_OverSeeWorkClosingDetailedEntity(string keyValue)
        {
            try
            {
                return dC_OA_OverSeeWorkClosingService.GetDC_OA_OverSeeWorkClosingDetailedEntity(keyValue);
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
        public DC_OA_OverSeeWorkClosingEntity GetEntityByProcessId(string processId)
        {
            try
            {
                return dC_OA_OverSeeWorkClosingService.GetEntityByProcessId(processId);
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
                dC_OA_OverSeeWorkClosingService.DeleteEntity(keyValue);
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
        public void SaveEntity(string keyValue, DC_OA_OverSeeWorkClosingEntity entity, List<DC_OA_OverSeeWorkClosingDetailedEntity> dC_OA_OverSeeWorkClosingDetailedList)
        {
            try
            {
                dC_OA_OverSeeWorkClosingService.SaveEntity(keyValue, entity, dC_OA_OverSeeWorkClosingDetailedList);
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
        public List<DC_OA_OverSeeWorkClosingDetailedEntity> StatisticsWorkByWorkIds(string workId)
        {
            try
            {
                return dC_OA_OverSeeWorkClosingService.StatisticsWorkByWorkIds(workId);
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
                return dC_OA_OverSeeWorkClosingService.GetWorkEntity(keyValue);
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
                return dC_OA_OverSeeWorkClosingService.Createflow(MainKeyvalue);
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
