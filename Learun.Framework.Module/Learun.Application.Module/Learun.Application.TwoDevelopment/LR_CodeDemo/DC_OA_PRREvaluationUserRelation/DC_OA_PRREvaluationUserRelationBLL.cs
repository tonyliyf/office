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
    /// 日 期：2019-01-25 15:26
    /// 描 述：DC_OA_PRREvaluationUserRelation
    /// </summary>
    public class DC_OA_PRREvaluationUserRelationBLL : DC_OA_PRREvaluationUserRelationIBLL
    {
        private DC_OA_PRREvaluationUserRelationService dC_OA_PRREvaluationUserRelationService = new DC_OA_PRREvaluationUserRelationService();

        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_OA_PRREvaluationUserRelationEntity> GetList(string rid)
        {
            try
            {
                return dC_OA_PRREvaluationUserRelationService.GetList(rid);
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
        /// 获取DC_OA_PRREvaluationUserRelation表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_OA_PRREvaluationUserRelationEntity GetDC_OA_PRREvaluationUserRelationEntity(string keyValue)
        {
            try
            {
                return dC_OA_PRREvaluationUserRelationService.GetDC_OA_PRREvaluationUserRelationEntity(keyValue);
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
                dC_OA_PRREvaluationUserRelationService.DeleteEntity(keyValue);
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
        public bool SaveEntity(string keyValue, DC_OA_PRREvaluationUserRelationEntity entity)
        {
            try
            {
                return dC_OA_PRREvaluationUserRelationService.SaveEntity(keyValue, entity);
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
