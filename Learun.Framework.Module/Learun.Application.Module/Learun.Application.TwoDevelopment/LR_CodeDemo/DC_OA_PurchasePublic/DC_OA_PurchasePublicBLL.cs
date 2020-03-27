
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
    /// 日 期：2019-02-07 14:22 
    /// 描 述：DC_OA_PurchasePublic 
    /// </summary> 
    public class DC_OA_PurchasePublicBLL : DC_OA_PurchasePublicIBLL
    {
        private DC_OA_PurchasePublicService dC_OA_PurchasePublicService = new DC_OA_PurchasePublicService();

        #region 获取数据 

        /// <summary> 
        /// 获取页面显示列表数据 
        /// <summary> 
        /// <param name="queryJson">查询参数</param> 
        /// <returns></returns> 
        public IEnumerable<DC_OA_PurchasePublicEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                return dC_OA_PurchasePublicService.GetPageList(pagination, queryJson);
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

        public DataTable GetList(Pagination pagination, string queryJson)
        {

            try
            {
                return dC_OA_PurchasePublicService.GetList(pagination, queryJson);
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
        /// 获取DC_OA_PurchasePublicDetail表数据 
        /// <summary> 
        /// <returns></returns> 
        public IEnumerable<DC_OA_PurchasePublicDetailEntity> GetDC_OA_PurchasePublicDetailList(string keyValue)
        {
            try
            {
                return dC_OA_PurchasePublicService.GetDC_OA_PurchasePublicDetailList(keyValue);
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
        /// 获取DC_OA_PurchasePublic表实体数据 
        /// <param name="keyValue">主键</param> 
        /// <summary> 
        /// <returns></returns> 
        public DC_OA_PurchasePublicEntity GetDC_OA_PurchasePublicEntity(string keyValue)
        {
            try
            {
                return dC_OA_PurchasePublicService.GetDC_OA_PurchasePublicEntity(keyValue);
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
        /// 获取DC_OA_PurchasePublicDetail表实体数据 
        /// <param name="keyValue">主键</param> 
        /// <summary> 
        /// <returns></returns> 
        public DC_OA_PurchasePublicDetailEntity GetDC_OA_PurchasePublicDetailEntity(string keyValue)
        {
            try
            {
                return dC_OA_PurchasePublicService.GetDC_OA_PurchasePublicDetailEntity(keyValue);
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
                dC_OA_PurchasePublicService.DeleteEntity(keyValue);
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
        public void SaveEntity(string keyValue, DC_OA_PurchasePublicEntity entity, List<DC_OA_PurchasePublicDetailEntity> dC_OA_PurchasePublicDetailList)
        {
            try
            {
                dC_OA_PurchasePublicService.SaveEntity(keyValue, entity, dC_OA_PurchasePublicDetailList);
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
