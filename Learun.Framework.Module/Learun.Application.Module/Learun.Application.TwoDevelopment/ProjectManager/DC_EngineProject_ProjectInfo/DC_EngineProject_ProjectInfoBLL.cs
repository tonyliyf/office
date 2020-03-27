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
    /// 日 期：2019-03-09 13:57
    /// 描 述：DC_EngineProject_ProjectInfo
    /// </summary>
    public class DC_EngineProject_ProjectInfoBLL : DC_EngineProject_ProjectInfoIBLL
    {
        private DC_EngineProject_ProjectInfoService dC_EngineProject_ProjectInfoService = new DC_EngineProject_ProjectInfoService();

        #region 获取数据
        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public DataTable ExportData1(string queryJson)
        {
            try
            {
                return dC_EngineProject_ProjectInfoService.ExportData1(queryJson);
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
        public DataTable ExportData(string queryJson)
        {
            try
            {
                return dC_EngineProject_ProjectInfoService.ExportData(queryJson);
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
        public IEnumerable<DC_EngineProject_ProjectInfoEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                return dC_EngineProject_ProjectInfoService.GetPageList(pagination, queryJson);
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
        /// 获取DC_EngineProject_ProjectInfo表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_EngineProject_ProjectInfoEntity GetDC_EngineProject_ProjectInfoEntity(string keyValue)
        {
            try
            {
                return dC_EngineProject_ProjectInfoService.GetDC_EngineProject_ProjectInfoEntity(keyValue);
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
        /// 获取左侧树形数据
        /// <summary>
        /// <returns></returns>
        public List<TreeModel> GetTree()
        {
            try
            {
                DataTable list = dC_EngineProject_ProjectInfoService.GetSqlTree();
                List<TreeModel> treeList = new List<TreeModel>();
                foreach (DataRow item in list.Rows)
                {
                    TreeModel node = new TreeModel
                    {
                        id = item["f_companyid"].ToString(),
                        text = item["f_fullname"].ToString(),
                        value = item["f_companyid"].ToString(),
                        showcheck = false,
                        checkstate = 0,
                        isexpand = true,
                        parentId = item["f_parentid"].ToString()
                    };
                    treeList.Add(node);
                }
                return treeList.ToTree();
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
        /// 获取左侧树形数据
        /// <summary>
        /// <returns></returns>
        public List<TreeModel> GetPorjectTree()
        {
            try
            {
                DataTable list = dC_EngineProject_ProjectInfoService.GetProjectSqlTree();
                List<TreeModel> treeList = new List<TreeModel>();
                TreeModel root = new TreeModel();
                root.id = "0";
                root.text = "项目信息列表";
                root.value = "0";

                foreach (DataRow item in list.Rows)
                {
                    TreeModel node = new TreeModel
                    {
                        id = item["F_PIId"].ToString(),
                        text = item["F_ProjectName"].ToString(),
                        value = item["F_PIId"].ToString(),
                        showcheck = false,
                        checkstate = 0,
                        isexpand = true,
                        parentId ="0"
                    };
                    treeList.Add(node);
                }
                return treeList.ToTree();
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
        /// 修改实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public void UpdeteEntity(string keyValue)
        {
            try
            {
                dC_EngineProject_ProjectInfoService.UpdeteEntity(keyValue);
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

        ///// <summary>
        ///// 修改实体数据
        ///// <param name="keyValue">主键</param>
        ///// <summary>
        ///// <returns></returns>
        //public string UpdeteEntity1(string keyValue)
        //{
        //    try
        //    {
        //        dC_EngineProject_ProjectInfoService.UpdeteEntity1(keyValue);
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
        /// <summary>
        /// 删除实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public void DeleteEntity(string keyValue)
        {
            try
            {
                dC_EngineProject_ProjectInfoService.DeleteEntity(keyValue);
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
        public void SaveEntity(string keyValue, DC_EngineProject_ProjectInfoEntity entity)
        {
            try
            {
                dC_EngineProject_ProjectInfoService.SaveEntity(keyValue, entity);
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

        public IEnumerable<DC_EngineProject_ProjectInfoEntity> StatisticsProjectInfo(DateTime startDate, DateTime endDate)
        {
            try
            {
                return dC_EngineProject_ProjectInfoService.StatisticsProjectInfo(startDate, endDate);
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
        public DataTable StatisticsProjectInfoByCategory(DateTime startDate, DateTime endDate)
        {
            try
            {
                return dC_EngineProject_ProjectInfoService.StatisticsProjectInfoByCategory(startDate, endDate);
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

        public IEnumerable<DC_EngineProject_ProjectInfoEntity> GetProjectInfo(string F_ProjectAddress)
        {
            try
            {
                return dC_EngineProject_ProjectInfoService.GetProjectInfo(F_ProjectAddress);
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
        public IEnumerable<DC_EngineProject_ProjectInfoEntity> GetProjectInfo1()
        {
            try
            {
                return dC_EngineProject_ProjectInfoService.GetProjectInfo1();
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

        public DataTable GetProjectContract(string ProjectId, string F_ItemValue, string F_PICId)
        {
            try
            {
                return dC_EngineProject_ProjectInfoService.GetProjectContract(ProjectId, F_ItemValue, F_PICId);
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
        public DataTable GetProjectContract1(string ProjectId)
        {
            try
            {
                return dC_EngineProject_ProjectInfoService.GetProjectContract1(ProjectId);
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

        public DataTable GetProjectOS_F_State()
        {
            try
            {
                return dC_EngineProject_ProjectInfoService.GetProjectOS_F_State();
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

    }
}
