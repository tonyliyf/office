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
    /// 日 期：2019-03-15 15:20
    /// 描 述：DC_EngineProject_ProjectInfoContract
    /// </summary>
    public class DC_EngineProject_ProjectInfoContractBLL : DC_EngineProject_ProjectInfoContractIBLL
    {
        private DC_EngineProject_ProjectInfoContractService dC_EngineProject_ProjectInfoContractService = new DC_EngineProject_ProjectInfoContractService();

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
                return dC_EngineProject_ProjectInfoContractService.ExportData(queryJson);
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
        public DataTable GetProjectContractType()
        {
            try
            {
                return dC_EngineProject_ProjectInfoContractService.GetProjectContractType();
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
        public IEnumerable<DC_EngineProject_ProjectInfoContractEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                return dC_EngineProject_ProjectInfoContractService.GetPageList(pagination, queryJson);
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
        /// 获取DC_EngineProject_ProjectInfoContract表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_EngineProject_ProjectInfoContractEntity GetDC_EngineProject_ProjectInfoContractEntity(string keyValue)
        {
            try
            {
                return dC_EngineProject_ProjectInfoContractService.GetDC_EngineProject_ProjectInfoContractEntity(keyValue);
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

        ///// <returns></returns>
        //public DC_EngineProject_ProjectInfoContractEntity GetDC_EngineProject_ProjectInfoContractByWeaver(string keyValue)
        //{
        //    try
        //    {
        //        return dC_EngineProject_ProjectInfoContractService.GetDC_EngineProject_ProjectInfoContractByWeaver(keyValue);
        //    }
        //    catch (Exception ex)
        //    {
        //        if (ex is ExceptionEx)
        //        {
        //            throw;
        //        }
        //        else
        //        {
        //            throw ExceptionEx.ThrowBusinessException(ex);
        //        }
        //    }
        //}

        

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
                dC_EngineProject_ProjectInfoContractService.DeleteEntity(keyValue);
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
        public void SaveEntity(string keyValue, DC_EngineProject_ProjectInfoContractEntity entity)
        {
            try
            {
                dC_EngineProject_ProjectInfoContractService.SaveEntity(keyValue, entity);
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
        /// 更新泛微合同数据
        /// </summary>
        public void UpdateProjectContract()
        {
            try
            {
                //dC_EngineProject_ProjectInfoContractService.UpdateProjectContract();
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
