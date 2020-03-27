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
    /// 日 期：2019-03-01 15:48
    /// 描 述：DC_OA_OverSeeWorkBulletin
    /// </summary>
    public class DC_OA_OverSeeWorkBulletinBLL : DC_OA_OverSeeWorkBulletinIBLL
    {
        private DC_OA_OverSeeWorkBulletinService dC_OA_OverSeeWorkBulletinService = new DC_OA_OverSeeWorkBulletinService();

        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_OA_OverSeeWorkBulletinEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                return dC_OA_OverSeeWorkBulletinService.GetPageList(pagination, queryJson);
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
        public List<DC_OA_OverSeeWorkBulletinDetailedEntity> StatisticsWorkByWorkIds(string workIds)
        {
            try
            {
                return dC_OA_OverSeeWorkBulletinService.StatisticsWorkByWorkIds(workIds);
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
        public List<DC_OA_OverSeeWorkBulletinDetailedEntity> GetDetailList(string keyValue)
        {
            try
            {
                return dC_OA_OverSeeWorkBulletinService.GetDetailList(keyValue);
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
        /// 获取DC_OA_OverSeeWorkBulletinDetailed表数据
        /// <summary>
        /// <returns></returns>
        public IEnumerable<DC_OA_OverSeeWorkBulletinDetailedEntity> GetDC_OA_OverSeeWorkBulletinDetailedList(string keyValue)
        {
            try
            {
                return dC_OA_OverSeeWorkBulletinService.GetDC_OA_OverSeeWorkBulletinDetailedList(keyValue);
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
        /// 获取DC_OA_OverSeeWorkBulletin表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_OA_OverSeeWorkBulletinEntity GetDC_OA_OverSeeWorkBulletinEntity(string keyValue)
        {
            try
            {
                return dC_OA_OverSeeWorkBulletinService.GetDC_OA_OverSeeWorkBulletinEntity(keyValue);
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
        /// 获取DC_OA_OverSeeWorkBulletinDetailed表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_OA_OverSeeWorkBulletinDetailedEntity GetDC_OA_OverSeeWorkBulletinDetailedEntity(string keyValue)
        {
            try
            {
                return dC_OA_OverSeeWorkBulletinService.GetDC_OA_OverSeeWorkBulletinDetailedEntity(keyValue);
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
        public DC_OA_OverSeeWorkBulletinEntity GetEntityByProcessId(string processId)
        {
            try
            {
                return dC_OA_OverSeeWorkBulletinService.GetEntityByProcessId(processId);
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
                dC_OA_OverSeeWorkBulletinService.DeleteEntity(keyValue);
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
        public void SaveEntity(string keyValue, DC_OA_OverSeeWorkBulletinEntity entity, string workIds)
        {
            try
            {
                dC_OA_OverSeeWorkBulletinService.SaveEntity(keyValue, entity, workIds);
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
