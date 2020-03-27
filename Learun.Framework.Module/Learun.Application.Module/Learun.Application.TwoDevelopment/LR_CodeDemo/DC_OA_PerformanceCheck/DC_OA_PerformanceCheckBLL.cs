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
    /// 日 期：2019-03-29 15:44
    /// 描 述：DC_OA_PerformanceCheck
    /// </summary>
    public class DC_OA_PerformanceCheckBLL : DC_OA_PerformanceCheckIBLL
    {
        private DC_OA_PerformanceCheckService dC_OA_PerformanceCheckService = new DC_OA_PerformanceCheckService();

        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_OA_PerformanceCheckEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                return dC_OA_PerformanceCheckService.GetPageList(pagination, queryJson);
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
        public IEnumerable<DC_OA_PerformanceCheckEntity> GetPageListH(string queryJson)
        {
            try
            {
                return dC_OA_PerformanceCheckService.GetPageListH(queryJson);
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
        public IEnumerable<DC_OA_PerformanceCheckEntity> GetPageList7(Pagination pagination, string queryJson)
        {
            try
            {
                return dC_OA_PerformanceCheckService.GetPageList7(pagination, queryJson);
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
        public IEnumerable<DC_OA_PerformanceCheckEntity> GetPageList8(Pagination pagination, string queryJson)
        {
            try
            {
                return dC_OA_PerformanceCheckService.GetPageList8(pagination, queryJson);
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
        public IEnumerable<DC_OA_PerformanceCheckEntity> GetPageList1(Pagination pagination, string queryJson)
        {
            try
            {
                return dC_OA_PerformanceCheckService.GetPageList1(pagination, queryJson);
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
        /// 获取页面显示列表数据(部门领导)
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_OA_PerformanceCheckEntity> GetPageList3(Pagination pagination, string queryJson)
        {
            try
            {
                return dC_OA_PerformanceCheckService.GetPageList3(pagination, queryJson);
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
        /// 获取页面显示列表数据(部门领导)
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_OA_PerformanceCheckEntity> GetPageList4(Pagination pagination, string queryJson)
        {
            try
            {
                return dC_OA_PerformanceCheckService.GetPageList4(pagination, queryJson);
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
        /// 获取页面显示列表数据(部门领导)
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_OA_PerformanceCheckEntity> GetPageList5(Pagination pagination, string queryJson)
        {
            try
            {
                return dC_OA_PerformanceCheckService.GetPageList5(pagination, queryJson);
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
        /// 获取页面显示列表数据(部门领导)
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_OA_PerformanceCheckEntity> GetPageList6(Pagination pagination, string queryJson)
        {
            try
            {
                return dC_OA_PerformanceCheckService.GetPageList6(pagination, queryJson);
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
        public DataTable GetPageList2(string queryJson)
        {
            try
            {
                return dC_OA_PerformanceCheckService.GetPageList2(queryJson);
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
        public DataTable GetPageList12(string queryJson)
        {
            try
            {
                return dC_OA_PerformanceCheckService.GetPageList12(queryJson);
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
        /// 获取DC_OA_PerformanceCheck表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_OA_PerformanceCheckEntity GetDC_OA_PerformanceCheckEntity(string keyValue)
        {
            try
            {
                return dC_OA_PerformanceCheckService.GetDC_OA_PerformanceCheckEntity(keyValue);
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
                DataTable list = dC_OA_PerformanceCheckService.GetSqlTree();
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
                dC_OA_PerformanceCheckService.DeleteEntity(keyValue);
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
        public void SaveEntity(string keyValue, DC_OA_PerformanceCheckEntity entity)
        {
            try
            {
                dC_OA_PerformanceCheckService.SaveEntity(keyValue, entity);
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
        public DC_OA_PerformanceCheckTemplateEntity GetTemplateEntity(int type)
        {
            try
            {
                return dC_OA_PerformanceCheckService.GetTemplateEntity(type);
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
        public bool Commit(string keyValue, string checkerid)
        {
            try
            {
                return dC_OA_PerformanceCheckService.Commit(keyValue, checkerid);
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
        public bool SaveEntityEx(string keyValue, DC_OA_PerformanceCheckEntity entity)
        {
            try
            {
                 return dC_OA_PerformanceCheckService.SaveEntityEx(keyValue, entity);
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
