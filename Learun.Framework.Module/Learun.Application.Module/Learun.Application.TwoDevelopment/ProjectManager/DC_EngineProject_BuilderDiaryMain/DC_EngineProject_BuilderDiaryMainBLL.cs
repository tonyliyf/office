using Learun.Util;
using System;
using System.Data;
using System.Collections.Generic;
using Learun.Application.TwoDevelopment.EcologyDemo;

namespace Learun.Application.TwoDevelopment.ProjectManager
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-03-25 10:59
    /// 描 述：DC_EngineProject_BuilderDiaryMain
    /// </summary>
    public class DC_EngineProject_BuilderDiaryMainBLL : DC_EngineProject_BuilderDiaryMainIBLL
    {
        private DC_EngineProject_BuilderDiaryMainService dC_EngineProject_BuilderDiaryMainService = new DC_EngineProject_BuilderDiaryMainService();

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
                return dC_EngineProject_BuilderDiaryMainService.ExportData(queryJson);
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
        public IEnumerable<formtable_main_134Entity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                return dC_EngineProject_BuilderDiaryMainService.GetPageList(pagination, queryJson);
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
        /// 获取DC_EngineProject_BuilderDiaryDetail表数据
        /// <summary>
        /// <returns></returns>
        public IEnumerable<DC_EngineProject_BuilderDiaryDetailEntity> GetDC_EngineProject_BuilderDiaryDetailList(string keyValue)
        {
            try
            {
                return dC_EngineProject_BuilderDiaryMainService.GetDC_EngineProject_BuilderDiaryDetailList(keyValue);
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
        /// 获取DC_EngineProject_BuilderDiaryMain表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_EngineProject_BuilderDiaryMainEntity GetDC_EngineProject_BuilderDiaryMainEntity(string keyValue)
        {
            try
            {
                return dC_EngineProject_BuilderDiaryMainService.GetDC_EngineProject_BuilderDiaryMainEntity(keyValue);
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
        /// 获取DC_EngineProject_BuilderDiaryDetail表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_EngineProject_BuilderDiaryDetailEntity GetDC_EngineProject_BuilderDiaryDetailEntity(string keyValue)
        {
            try
            {
                return dC_EngineProject_BuilderDiaryMainService.GetDC_EngineProject_BuilderDiaryDetailEntity(keyValue);
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

        public DataTable GetMainRecord(string Projectid, string code)
        {
            try
            {
                return dC_EngineProject_BuilderDiaryMainService.GetMainRecord(Projectid, code);
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
        public DataTable MaxTime(string Projectid)
        {
            try
            {
                return dC_EngineProject_BuilderDiaryMainService.MaxTime(Projectid);
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
        public DataTable MinTime(string Projectid)
        {
            try
            {
                return dC_EngineProject_BuilderDiaryMainService.MinTime(Projectid);
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

        public formtable_main_134Entity SelectRecord(string id)
        {
            try
            {
                return dC_EngineProject_BuilderDiaryMainService.SelectRecord(id);
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
                dC_EngineProject_BuilderDiaryMainService.DeleteEntity(keyValue);
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
        public void SaveEntity(string keyValue, DC_EngineProject_BuilderDiaryMainEntity entity,List<DC_EngineProject_BuilderDiaryDetailEntity> dC_EngineProject_BuilderDiaryDetailList)
        {
            try
            {
                dC_EngineProject_BuilderDiaryMainService.SaveEntity(keyValue, entity,dC_EngineProject_BuilderDiaryDetailList);
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
