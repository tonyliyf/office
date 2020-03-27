using Learun.Util;
using System;
using System.Data;
using System.Collections.Generic;
using Learun.Application.WorkFlow;


namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 DYT-OA V1.0 企业敏捷开发框架
    /// Copyright (c) 2018-2019 武汉东雅图科技技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-01-14 12:10
    /// 描 述：收文管理
    /// </summary>
    public class DC_OA_ReceiveOfficialDocManagerBLL : DC_OA_ReceiveOfficialDocManagerIBLL
    {
        private DC_OA_ReceiveOfficialDocManagerService dC_OA_ReceiveOfficialDocManagerService = new DC_OA_ReceiveOfficialDocManagerService();

        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_OA_ReceiveOfficialDocEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                return dC_OA_ReceiveOfficialDocManagerService.GetPageList(pagination, queryJson);
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

        public IEnumerable<ReciveFileReturnDataModel> GetDealIndexPageList(Pagination pagination, string queryJson)
        {
            try
            {
                return dC_OA_ReceiveOfficialDocManagerService.GetDealIndexPageList(pagination, queryJson);
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
        /// 获取LR_NWF_TaskLog表数据
        /// <summary>
        /// <returns></returns>
        public IEnumerable<NWFTaskLogEntity> GetLR_NWF_TaskLogList(string keyValue)
        {
            try
            {
                return dC_OA_ReceiveOfficialDocManagerService.GetLR_NWF_TaskLogList(keyValue);
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
        /// 获取DC_OA_ReceiveOfficialDoc表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_OA_ReceiveOfficialDocEntity GetDC_OA_ReceiveOfficialDocEntity(string keyValue)
        {
            try
            {
                return dC_OA_ReceiveOfficialDocManagerService.GetDC_OA_ReceiveOfficialDocEntity(keyValue);
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
        /// 获取LR_NWF_TaskLog表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public NWFTaskLogEntity GetNWFTaskLogEntity(string keyValue)
        {
            try
            {
                return dC_OA_ReceiveOfficialDocManagerService.GetNWFTaskLogEntity(keyValue);
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
        public DC_OA_ReceiveOfficialDocEntity GetEntityByProcessId(string processId)
        {
            try
            {
                return dC_OA_ReceiveOfficialDocManagerService.GetEntityByProcessId(processId);
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
                dC_OA_ReceiveOfficialDocManagerService.DeleteEntity(keyValue);
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
        public void SaveEntity(string keyValue, DC_OA_ReceiveOfficialDocEntity entity, List<NWFTaskLogEntity> lR_NWF_TaskLogList)
        {
            try
            {
                dC_OA_ReceiveOfficialDocManagerService.SaveEntity(keyValue, entity, lR_NWF_TaskLogList);
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
        public void DoComplete(string keyValue)
        {
            try
            {
                dC_OA_ReceiveOfficialDocManagerService.DoComplete(keyValue);
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
        public List<string> GetAdviceByProcessId(string keyValue, string signaturePath)
        {
            try
            {
                return dC_OA_ReceiveOfficialDocManagerService.GetAdviceByProcessId(keyValue, signaturePath);
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
        public List<selectdata> GetProcessStep()
        {
            try
            {
                return dC_OA_ReceiveOfficialDocManagerService.GetProcessStep();
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
