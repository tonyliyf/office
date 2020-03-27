using Learun.Util;
using System;
using System.Data;
using System.Collections.Generic;
using Learun.Application.Base.SystemModule;

namespace Learun.Application.TwoDevelopment.ProjectManager
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-03-25 15:19
    /// 描 述：DC_EngineProject_ProjectInfoApprovalData
    /// </summary>
    public class DC_EngineProject_ProjectInfoApprovalDataBLL : DC_EngineProject_ProjectInfoApprovalDataIBLL
    {
        private DC_EngineProject_ProjectInfoApprovalDataService dC_EngineProject_ProjectInfoApprovalDataService = new DC_EngineProject_ProjectInfoApprovalDataService();
        private DataItemIBLL dataItemIBLL = new DataItemBLL();
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
                return dC_EngineProject_ProjectInfoApprovalDataService.ExportData(queryJson);
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
        public IEnumerable<DC_EngineProject_ProjectInfoApprovalDataEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                return dC_EngineProject_ProjectInfoApprovalDataService.GetPageList(pagination, queryJson);
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
        public IEnumerable<DC_EngineProject_ProjectInfoApprovalInfo> GetPageInfoList(string queryJson)
        {
            try
            {
                return dC_EngineProject_ProjectInfoApprovalDataService.GetPageInfoList(queryJson);
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
        /// 获取DC_EngineProject_ProjectInfoApprovalData表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_EngineProject_ProjectInfoApprovalDataEntity GetDC_EngineProject_ProjectInfoApprovalDataEntity(string keyValue)
        {
            try
            {
                return dC_EngineProject_ProjectInfoApprovalDataService.GetDC_EngineProject_ProjectInfoApprovalDataEntity(keyValue);
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

        public DataTable GetSqlTree()
        {

            try
            {
                return dC_EngineProject_ProjectInfoApprovalDataService.GetSqlTree();
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


        public DataTable GetBeforeSqlTree()
        {

            try
            {
                return dC_EngineProject_ProjectInfoApprovalDataService.GetBeforSqlTree();
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
                DataTable list = dC_EngineProject_ProjectInfoApprovalDataService.GetSqlTree();
                List<TreeModel> treeList = new List<TreeModel>();
                foreach (DataRow item in list.Rows)
                {
                    TreeModel node = new TreeModel
                    {
                        id = item["f_itemid"].ToString(),
                        text = item["f_itemname"].ToString(),
                        value = item["f_itemcode"].ToString(),
                        showcheck = false,
                        checkstate = 0,
                        isexpand = true,
                        parentId = item["f_parentid"].ToString(),
                    };
                    treeList.Add(node);
                    var data = dataItemIBLL.GetDetailTree(item["F_ItemCode"].ToString());
                    if (data != null)
                    {
                        var dataTemp = data as List<TreeModel>;
                        foreach (var mode in dataTemp)
                        {
                            mode.parentId = item["f_itemid"].ToString();
                            treeList.Add(mode);
                        }


                    }


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


        public List<TreeModel> GetUnitTree()
        {
            try
            {
                DataTable list = dC_EngineProject_ProjectInfoApprovalDataService.GetUnitTree();
                DataTable list2 = dC_EngineProject_ProjectInfoApprovalDataService.GetUnitOtherTree();
                List<TreeModel> treeList = new List<TreeModel>();
                string[] unitType = new string[] { "勘测单位", "设计单位", "施工单位", "监理单位" };
                TreeModel noderoot = new TreeModel
                {
                    id = "0",
                    text = "合作方",
                    value = "0",
                    showcheck = false,
                    checkstate = 0,
                    isexpand = true,
                    parentId = "",
                };
                treeList.Add(noderoot);
                foreach (string temp in unitType)
                {
                    TreeModel node = new TreeModel
                    {
                        id = temp,
                        text = temp,
                        value = temp,
                        showcheck = false,
                        checkstate = 0,
                        isexpand = true,
                        parentId = "0",
                    };

                    treeList.Add(node);
                    DataRow[] drRows = list.Select("F_Unittype= '" + temp + "'");
                    if (drRows != null && drRows.Length > 0)
                    {
                        foreach (DataRow item in drRows)
                        {
                            TreeModel node1 = new TreeModel
                            {
                                id = item["F_PIUId"].ToString(),
                                text = item["F_UnitName"].ToString(),
                                value = item["F_PIUId"].ToString(),
                                showcheck = false,
                                checkstate = 0,
                                isexpand = true,
                                parentId = temp,
                            };
                            treeList.Add(node1);
                        }
                    }
                }

                TreeModel node2 = new TreeModel
                {
                    id = "供应商",
                    text = "供应商",
                    value = "供应商",
                    showcheck = false,
                    checkstate = 0,
                    isexpand = true,
                    parentId = "0",
                };
                treeList.Add(node2);



                foreach (DataRow item in list2.Rows)
                {
                    TreeModel node3 = new TreeModel
                    {
                        id = item["F_CUId"].ToString(),
                        text = item["F_UnitName"].ToString(),
                        value = item["F_CUId"].ToString(),
                        showcheck = false,
                        checkstate = 0,
                        isexpand = true,
                        parentId = "供应商",
                    };
                    treeList.Add(node3);
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
        public List<TreeModel> GetBeforeTree()
        {
            try
            {
                DataTable list = dC_EngineProject_ProjectInfoApprovalDataService.GetBeforSqlTree();
                List<TreeModel> treeList = new List<TreeModel>();
                foreach (DataRow item in list.Rows)
                {
                    TreeModel node = new TreeModel
                    {
                        id = item["f_itemid"].ToString(),
                        text = item["f_itemname"].ToString(),
                        value = item["f_itemcode"].ToString(),
                        showcheck = false,
                        checkstate = 0,
                        isexpand = true,
                        parentId = item["f_parentid"].ToString(),
                    };
                    treeList.Add(node);
                    var data = dataItemIBLL.GetDetailTree(item["F_ItemCode"].ToString());
                    if (data != null)
                    {
                        var dataTemp = data as List<TreeModel>;
                        foreach (var mode in dataTemp)
                        {
                            mode.parentId = item["f_itemid"].ToString();
                            treeList.Add(mode);
                        }


                    }


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
        public List<TreeModel> GetBeforeInfoTree()
        {
            try
            {
                DataTable list = dC_EngineProject_ProjectInfoApprovalDataService.GetBeforSqlTree();
                List<TreeModel> treeList = new List<TreeModel>();
                foreach (DataRow item in list.Rows)
                {
                    TreeModel node = new TreeModel
                    {
                        id = item["f_itemid"].ToString(),
                        text = item["f_itemname"].ToString(),
                        value = item["f_itemcode"].ToString(),
                        showcheck = false,
                        checkstate = 0,
                        isexpand = true,
                        parentId = item["f_parentid"].ToString(),
                    };
                    treeList.Add(node);
                    var data = dataItemIBLL.GetDetailTree(item["F_ItemCode"].ToString());
                    if (data != null)
                    {
                        var dataTemp = data as List<TreeModel>;
                        foreach (var mode in dataTemp)
                        {
                            mode.parentId = item["f_itemid"].ToString();
                            treeList.Add(mode);
                        }


                    }


                }
                return treeList;
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


        public DataTable GetProjectInfo(string queryJosn)
        {
            try
            {
                return dC_EngineProject_ProjectInfoApprovalDataService.GetProjectInfo(queryJosn);
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


        public DataTable GetBeforeProjectInfoss(string ProjectId)
        {
            try
            {
                return dC_EngineProject_ProjectInfoApprovalDataService.GetBeforeProjectInfoss(ProjectId);
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
        


        public DataTable GetProjectBeforeInfo(string queryJosn)
        {
            try
            {
                return dC_EngineProject_ProjectInfoApprovalDataService.GetProjectBeforeInfo(queryJosn);
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
                dC_EngineProject_ProjectInfoApprovalDataService.DeleteEntity(keyValue);
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
        public void SaveEntity(string keyValue, DC_EngineProject_ProjectInfoApprovalDataEntity entity)
        {
            try
            {
                dC_EngineProject_ProjectInfoApprovalDataService.SaveEntity(keyValue, entity);
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
