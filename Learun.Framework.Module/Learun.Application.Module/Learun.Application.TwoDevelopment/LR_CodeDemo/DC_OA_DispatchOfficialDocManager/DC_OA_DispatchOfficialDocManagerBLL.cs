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
    /// 日 期：2019-01-12 15:16
    /// 描 述：发文管理
    /// </summary>
    public class DC_OA_DispatchOfficialDocManagerBLL : DC_OA_DispatchOfficialDocManagerIBLL
    {
        private DC_OA_DispatchOfficialDocManagerService dC_OA_DispatchOfficialDocManagerService = new DC_OA_DispatchOfficialDocManagerService();
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_OA_DispatchOfficialDocEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                return dC_OA_DispatchOfficialDocManagerService.GetPageList(pagination, queryJson);
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
                return dC_OA_DispatchOfficialDocManagerService.GetDealIndexPageList(pagination, queryJson);
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
                return dC_OA_DispatchOfficialDocManagerService.GetLR_NWF_TaskLogList(keyValue);
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
        /// 获取DC_OA_DispatchOfficialDoc表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_OA_DispatchOfficialDocEntity GetDC_OA_DispatchOfficialDocEntity(string keyValue)
        {
            try
            {
                return dC_OA_DispatchOfficialDocManagerService.GetDC_OA_DispatchOfficialDocEntity(keyValue);
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
        public NWFTaskLogEntity GetLR_NWF_TaskLogEntity(string keyValue)
        {
            try
            {
                return dC_OA_DispatchOfficialDocManagerService.GetLR_NWF_TaskLogEntity(keyValue);
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
        public DC_OA_DispatchOfficialDocEntity GetEntityByProcessId(string processId)
        {
            try
            {
                return dC_OA_DispatchOfficialDocManagerService.GetEntityByProcessId(processId);
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
                dC_OA_DispatchOfficialDocManagerService.DeleteEntity(keyValue);
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
                return dC_OA_DispatchOfficialDocManagerService.GetProcessStep();
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
        public void SaveEntity(string keyValue, DC_OA_DispatchOfficialDocEntity entity, List<NWFTaskLogEntity> lR_NWF_TaskLogList)
        {
            try
            {
                dC_OA_DispatchOfficialDocManagerService.SaveEntity(keyValue, entity, lR_NWF_TaskLogList);
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
                dC_OA_DispatchOfficialDocManagerService.DoComplete(keyValue);
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
        public void SaveSetting(string keyValue, DC_OA_DispatchOfficialDocEntity entity)
        {
            try
            {
                dC_OA_DispatchOfficialDocManagerService.SaveSetting(keyValue, entity);
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
        public bool IsSettingTemplate(string keyValue)
        {
            try
            {
                return dC_OA_DispatchOfficialDocManagerService.IsSettingTemplate(keyValue);
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

        public string GetDepartmentNameById(string departmentId)
        {
            try
            {
                return dC_OA_DispatchOfficialDocManagerService.GetDepartmentNameById(departmentId);
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
                return dC_OA_DispatchOfficialDocManagerService.GetAdviceByProcessId(keyValue, signaturePath);
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

        public List<EasyUiTreeModel> GetDepartmentTreeNode(string keyValue, int isSend)
        {
            try
            {
                return dC_OA_DispatchOfficialDocManagerService.GetDepartmentTreeNode(keyValue, isSend);
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

        public void SendTo(string keyValue, string sendto, string sendtoid, string copyto, string copytoid, string ReviewUserName,
            string ReviewUserId, string ProofreadUserName, string ProofreadUserId, string PrintNum)
        {
            try
            {
                dC_OA_DispatchOfficialDocManagerService.SendTo(keyValue, sendto, sendtoid, copyto, copytoid, ReviewUserName,
             ReviewUserId, ProofreadUserName, ProofreadUserId, PrintNum);
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

        public void savenewfile(string keyValue, string guid)
        {
            dC_OA_DispatchOfficialDocManagerService.savenewfile(keyValue, guid);
        }
        public string getnewfile(string keyValue)
        {
            return dC_OA_DispatchOfficialDocManagerService.getnewfile(keyValue);
        }
        public bool IsSend(string keyValue)
        {
            return dC_OA_DispatchOfficialDocManagerService.IsSend(keyValue);
        }
        #endregion
    }
}