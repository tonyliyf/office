﻿using Learun.Util;
using System;
using System.Data;
using System.Collections.Generic;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.0 企业敏捷开发框架
    /// Copyright (c) 2018-2019 武汉东雅图科技技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-12-31 16:09
    /// 描 述：办公物品管理
    /// </summary>
    public class DC_OA_OfficeWoodsBLL : DC_OA_OfficeWoodsIBLL
    {
        private DC_OA_OfficeWoodsService dC_OA_OfficeWoodsService = new DC_OA_OfficeWoodsService();

        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_OA_OfficeWoodsEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                return dC_OA_OfficeWoodsService.GetPageList(pagination, queryJson);
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
        /// 获取DC_OA_OfficeWoods表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_OA_OfficeWoodsEntity GetDC_OA_OfficeWoodsEntity(string keyValue)
        {
            try
            {
                return dC_OA_OfficeWoodsService.GetDC_OA_OfficeWoodsEntity(keyValue);
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
                dC_OA_OfficeWoodsService.DeleteEntity(keyValue);
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
        public void SaveEntity(string keyValue, DC_OA_OfficeWoodsEntity entity)
        {
            try
            {
                dC_OA_OfficeWoodsService.SaveEntity(keyValue, entity);
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