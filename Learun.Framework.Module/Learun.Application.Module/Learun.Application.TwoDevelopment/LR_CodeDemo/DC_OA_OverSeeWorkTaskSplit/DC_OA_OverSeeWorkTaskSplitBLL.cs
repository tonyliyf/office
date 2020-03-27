using Learun.Util;
using System;
using System.Data;
using System.Collections.Generic;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.0 企业敏捷开发框架
    /// Copyright (c) 2018-2019 武汉东雅图科技技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-01-07 17:28
    /// 描 述：DC_OA_OverSeeWorkTaskSplit
    /// </summary>
    public class DC_OA_OverSeeWorkTaskSplitBLL : DC_OA_OverSeeWorkTaskSplitIBLL
    {
        private DC_OA_OverSeeWorkTaskSplitService dC_OA_OverSeeWorkTaskSplitService = new DC_OA_OverSeeWorkTaskSplitService();

        #region 获取数据
        public List<GanttEntity> GetGanttData(string keyValue)
        {
            try
            {
                return dC_OA_OverSeeWorkTaskSplitService.GetGanttData(keyValue);
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
        public IEnumerable<DC_OA_OverSeeWorkEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                return dC_OA_OverSeeWorkTaskSplitService.GetPageList(pagination, queryJson);
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

        public IEnumerable<DC_OA_OverSeeWorkEntity> GetPageListEx(Pagination pagination, string queryJson)
        {
            try
            {
                return dC_OA_OverSeeWorkTaskSplitService.GetPageListEx(pagination, queryJson);
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
        /// 获取DC_OA_OverSeeWork表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_OA_OverSeeWorkEntity GetDC_OA_OverSeeWorkEntity(string keyValue)
        {
            try
            {
                return dC_OA_OverSeeWorkTaskSplitService.GetDC_OA_OverSeeWorkEntity(keyValue);
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
                DataTable list = dC_OA_OverSeeWorkTaskSplitService.GetSqlTree();
                List<TreeModel> treeList = new List<TreeModel>();
                foreach (DataRow item in list.Rows)
                {
                    TreeModel node = new TreeModel
                    {
                        id = item["f_oswid"].ToString(),
                        text = item["f_leaderuser"].ToString(),
                        value = item["f_oswid"].ToString(),
                        showcheck = false,
                        checkstate = 0,
                        isexpand = true,
                        parentId = item["f_oswid"].ToString()
                    };
                    treeList.Add(node);                }
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
                dC_OA_OverSeeWorkTaskSplitService.DeleteEntity(keyValue);
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
        public void SaveEntity(string keyValue, DC_OA_OverSeeWorkEntity entity)
        {
            try
            {
                dC_OA_OverSeeWorkTaskSplitService.SaveEntity(keyValue, entity);
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
        public void ConnectProcess(string keyValue, string processId)
        {
            try
            {
                dC_OA_OverSeeWorkTaskSplitService.ConnectProcess(keyValue, processId);
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
