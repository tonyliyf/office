using Learun.Util;
using System;
using System.Data;
using System.Collections.Generic;
using System.Collections;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-01-26 12:10
    /// 描 述：DC_OA_PerformanceExecute
    /// </summary>
    public class DC_OA_PerformanceExecuteBLL : DC_OA_PerformanceExecuteIBLL
    {
        private DC_OA_PerformanceExecuteService dC_OA_PerformanceExecuteService = new DC_OA_PerformanceExecuteService();

        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_OA_PerformanceExecuteEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                return dC_OA_PerformanceExecuteService.GetPageList(pagination, queryJson);
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
        /// 获取DC_OA_PerformanceExecute表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_OA_PerformanceExecuteEntity GetDC_OA_PerformanceExecuteEntity(string keyValue)
        {
            try
            {
                return dC_OA_PerformanceExecuteService.GetDC_OA_PerformanceExecuteEntity(keyValue);
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
                dC_OA_PerformanceExecuteService.DeleteEntity(keyValue);
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
        public void SaveEntity(string keyValue, DC_OA_PerformanceExecuteEntity entity)
        {
            try
            {
                dC_OA_PerformanceExecuteService.SaveEntity(keyValue, entity);
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
        public List<DC_OA_PerformanceExecuteEntity> GetList(string keyValue)
        {
            try
            {
                return dC_OA_PerformanceExecuteService.GetList(keyValue);
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
        public List<TableHeadModel> GetColumes(string wid)
        {
            try
            {
                return dC_OA_PerformanceExecuteService.GetColumes(wid);
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
        public HeaderInfoData GetHeadData(string wid)
        {
            try
            {
                return dC_OA_PerformanceExecuteService.GetHeadData(wid);
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
        public List<Hashtable> GetRows(string wid)
        {
            try
            {
                return dC_OA_PerformanceExecuteService.GetRows(wid);
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
        public bool IsLeaf(string wpid)
        {
            try
            {
                return dC_OA_PerformanceExecuteService.IsLeaf(wpid);
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
