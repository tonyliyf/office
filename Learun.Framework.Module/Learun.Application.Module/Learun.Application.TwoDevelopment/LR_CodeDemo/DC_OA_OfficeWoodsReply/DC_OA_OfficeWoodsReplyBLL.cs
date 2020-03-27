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
    /// 日 期：2019-02-26 16:28
    /// 描 述：DC_OA_OfficeWoodsReply
    /// </summary>
    public class DC_OA_OfficeWoodsReplyBLL : DC_OA_OfficeWoodsReplyIBLL
    {
        private DC_OA_OfficeWoodsReplyService dC_OA_OfficeWoodsReplyService = new DC_OA_OfficeWoodsReplyService();

        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_OA_OfficeWoodsReplyEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                return dC_OA_OfficeWoodsReplyService.GetPageList(pagination, queryJson);
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


        public DataTable GetList(string queryJson)
        {
            try
            {
                return dC_OA_OfficeWoodsReplyService.GetList(queryJson);
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
        /// 获取DC_OA_OfficeWoodsReplyDetail表数据
        /// <summary>
        /// <returns></returns>
        public IEnumerable<DC_OA_OfficeWoodsReplyDetailEntity> GetDC_OA_OfficeWoodsReplyDetailList(string keyValue)
        {
            try
            {
                return dC_OA_OfficeWoodsReplyService.GetDC_OA_OfficeWoodsReplyDetailList(keyValue);
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
        public List<DC_OA_OfficeWoodsReplyDetailEntity> GetDC_OA_OfficeWoodsReplyDetailTotalListByMonth(string month, out double sum)
        {
            try
            {
                return dC_OA_OfficeWoodsReplyService.GetDC_OA_OfficeWoodsReplyDetailTotalListByMonth(month, out sum);
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
        /// 获取DC_OA_OfficeWoodsReply表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_OA_OfficeWoodsReplyEntity GetDC_OA_OfficeWoodsReplyEntity(string keyValue)
        {
            try
            {
                return dC_OA_OfficeWoodsReplyService.GetDC_OA_OfficeWoodsReplyEntity(keyValue);
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
        /// 获取DC_OA_OfficeWoodsReplyDetail表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_OA_OfficeWoodsReplyDetailEntity GetDC_OA_OfficeWoodsReplyDetailEntity(string keyValue)
        {
            try
            {
                return dC_OA_OfficeWoodsReplyService.GetDC_OA_OfficeWoodsReplyDetailEntity(keyValue);
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
        public DC_OA_OfficeWoodsReplyEntity GetEntityByProcessId(string processId)
        {
            try
            {
                return dC_OA_OfficeWoodsReplyService.GetEntityByProcessId(processId);
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
                dC_OA_OfficeWoodsReplyService.DeleteEntity(keyValue);
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
        public void SaveEntity(string keyValue, DC_OA_OfficeWoodsReplyEntity entity, List<DC_OA_OfficeWoodsReplyDetailEntity> dC_OA_OfficeWoodsReplyDetailList)
        {
            try
            {
                dC_OA_OfficeWoodsReplyService.SaveEntity(keyValue, entity, dC_OA_OfficeWoodsReplyDetailList);
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
