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
    /// 日 期：2019-02-27 14:02
    /// 描 述：DC_OA_MeetingSubjectSum
    /// </summary>
    public class DC_OA_MeetingSubjectSumBLL : DC_OA_MeetingSubjectSumIBLL
    {
        private DC_OA_MeetingSubjectSumService dC_OA_MeetingSubjectSumService = new DC_OA_MeetingSubjectSumService();

        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_OA_MeetingSubjectEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                return dC_OA_MeetingSubjectSumService.GetPageList(pagination, queryJson);
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
        /// 获取DC_OA_MeetingSubjectSum表数据
        /// <summary>
        /// <returns></returns>
        public IEnumerable<DC_OA_MeetingSubjectEntity> GetDC_OA_MeetingSubjectSumList(string keyValue)
        {
            try
            {
                return dC_OA_MeetingSubjectSumService.GetDC_OA_MeetingSubjectSumList(keyValue);
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
        /// 获取DC_OA_MeetingSubject表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_OA_MeetingSubjectEntity GetDC_OA_MeetingSubjectEntity(string keyValue)
        {
            try
            {
                return dC_OA_MeetingSubjectSumService.GetDC_OA_MeetingSubjectEntity(keyValue);
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
        /// 获取DC_OA_MeetingSubjectSum表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_OA_MeetingSubjectSumEntity GetDC_OA_MeetingSubjectSumEntity(string keyValue)
        {
            try
            {
                return dC_OA_MeetingSubjectSumService.GetDC_OA_MeetingSubjectSumEntity(keyValue);
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
        public IEnumerable<DC_OA_MeetingSubjectEntity> GetDC_OA_MeetingSubjectList()
        {
            try
            {
                return dC_OA_MeetingSubjectSumService.GetDC_OA_MeetingSubjectList();
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
                dC_OA_MeetingSubjectSumService.DeleteEntity(keyValue);
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
        public void SaveEntity(string keyValue, DC_OA_MeetingSubjectSumEntity entity, List<DC_OA_MeetingSubjectEntity> dC_OA_MeetingSubjectList)
        {
            try
            {
                dC_OA_MeetingSubjectSumService.SaveEntity(keyValue, entity, dC_OA_MeetingSubjectList);
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
