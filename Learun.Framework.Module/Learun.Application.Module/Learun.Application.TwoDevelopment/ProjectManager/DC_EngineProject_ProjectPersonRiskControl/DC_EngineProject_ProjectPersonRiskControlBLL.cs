using Learun.Util;
using System;
using System.Data;
using System.Collections.Generic;

namespace Learun.Application.TwoDevelopment.ProjectManager
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-03-21 11:44
    /// 描 述：DC_EngineProject_ProjectPersonRiskControl
    /// </summary>
    public class DC_EngineProject_ProjectPersonRiskControlBLL : DC_EngineProject_ProjectPersonRiskControlIBLL
    {
        private DC_EngineProject_ProjectPersonRiskControlService dC_EngineProject_ProjectPersonRiskControlService = new DC_EngineProject_ProjectPersonRiskControlService();

        #region 获取数据
        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public DataTable ExportData(string queryJson)
        {
            try
            {
                return dC_EngineProject_ProjectPersonRiskControlService.ExportData(queryJson);
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
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_EngineProject_ProjectPersonRiskControlEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                return dC_EngineProject_ProjectPersonRiskControlService.GetPageList(pagination, queryJson);
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
        /// 获取DC_EngineProject_ProjectPersonRiskControlAssessment表数据
        /// <summary>
        /// <returns></returns>
        public IEnumerable<DC_EngineProject_ProjectPersonRiskControlAssessmentEntity> GetDC_EngineProject_ProjectPersonRiskControlAssessmentList(string keyValue)
        {
            try
            {
                return dC_EngineProject_ProjectPersonRiskControlService.GetDC_EngineProject_ProjectPersonRiskControlAssessmentList(keyValue);
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
        /// 获取DC_EngineProject_ProjectPersonRiskControl表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_EngineProject_ProjectPersonRiskControlEntity GetDC_EngineProject_ProjectPersonRiskControlEntity(string keyValue)
        {
            try
            {
                return dC_EngineProject_ProjectPersonRiskControlService.GetDC_EngineProject_ProjectPersonRiskControlEntity(keyValue);
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
        /// 获取DC_EngineProject_ProjectPersonRiskControlAssessment表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_EngineProject_ProjectPersonRiskControlAssessmentEntity GetDC_EngineProject_ProjectPersonRiskControlAssessmentEntity(string keyValue)
        {
            try
            {
                return dC_EngineProject_ProjectPersonRiskControlService.GetDC_EngineProject_ProjectPersonRiskControlAssessmentEntity(keyValue);
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
                dC_EngineProject_ProjectPersonRiskControlService.DeleteEntity(keyValue);
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
        public void SaveEntity(string keyValue, DC_EngineProject_ProjectPersonRiskControlEntity entity,List<DC_EngineProject_ProjectPersonRiskControlAssessmentEntity> dC_EngineProject_ProjectPersonRiskControlAssessmentList)
        {
            try
            {
                dC_EngineProject_ProjectPersonRiskControlService.SaveEntity(keyValue, entity,dC_EngineProject_ProjectPersonRiskControlAssessmentList);
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
