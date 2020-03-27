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
    /// 日 期：2019-01-07 11:19
    /// 描 述：DC_OA_OverSeeWork
    /// </summary>
    public class DC_OA_OverSeeWorkBLL : DC_OA_OverSeeWorkIBLL
    {
        private DC_OA_OverSeeWorkService dC_OA_OverSeeWorkService = new DC_OA_OverSeeWorkService();

        #region 获取数据
        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_OA_OverSeeWorkEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                return dC_OA_OverSeeWorkService.GetPageList(pagination, queryJson);
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

        public IEnumerable<DC_OA_OverSeeWorkEntity> GetOverSeeWork()
        {
            try
            {
                return dC_OA_OverSeeWorkService.GetOverSeeWork();
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
        public List<WorkStatisticsModel> StatisticsWorkByCurrentMonth(DateTime startDate, DateTime endDate, string executeState, string workTitle)
        {
            try
            {
                return dC_OA_OverSeeWorkService.StatisticsWorkByCurrentMonth(startDate, endDate, executeState, workTitle);
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
                return dC_OA_OverSeeWorkService.GetDC_OA_OverSeeWorkEntity(keyValue);
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
                DataTable list = dC_OA_OverSeeWorkService.GetSqlTree();
                List<TreeModel> treeList = new List<TreeModel>();
                foreach (DataRow item in list.Rows)
                {
                    TreeModel node = new TreeModel
                    {
                        id = item["f_departmentid"].ToString(),
                        text = item["f_fullname"].ToString(),
                        value = item["f_departmentid"].ToString(),
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
                dC_OA_OverSeeWorkService.DeleteEntity(keyValue);
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
                dC_OA_OverSeeWorkService.SaveEntity(keyValue, entity);
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
        public IEnumerable<EChartModel> StatisticForEChart()
        {
            try
            {
                return dC_OA_OverSeeWorkService.StatisticForEChart();
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

        public IEnumerable<WorkCategoryModel> StatisticsByCategory(DateTime startDate, DateTime endDate)
        {
            try
            {
                return dC_OA_OverSeeWorkService.StatisticsByCategory(startDate, endDate);
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
        public IEnumerable<EChartModel> StatisticsByCategoryEx(DateTime startDate, DateTime endDate)
        {
            try
            {
                return dC_OA_OverSeeWorkService.StatisticsByCategoryEx(startDate, endDate);
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

        public void EnterOverSeeWork(string keyValue)
        {
            try
            {
                dC_OA_OverSeeWorkService.EnterOverSeeWork(keyValue);
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
        public int GetCount(string state)
        {
            try
            {
                return dC_OA_OverSeeWorkService.GetCount(state);
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
        public int GetCount1(string state)
        {
            try
            {
                return dC_OA_OverSeeWorkService.GetCount1(state);
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
        public int GetCount2(string state)
        {
            try
            {
                return dC_OA_OverSeeWorkService.GetCount2(state);
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
        public void AddScore(string keyValue, double score, string advice)
        {
            try
            {
                dC_OA_OverSeeWorkService.AddScore(keyValue, score, advice);
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
        public void GetScore(string keyValue, out double score, out string advice)
        {
            try
            {
                dC_OA_OverSeeWorkService.GetScore(keyValue, out score, out advice);
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
        public DataTable GetPlatformListByState(string state)
        {
            try
            {
                return dC_OA_OverSeeWorkService.GetPlatformListByState(state);
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

        public Dictionary<string, List<int>> GetTaskByTypeAndMonth()
        {
            try
            {
                return dC_OA_OverSeeWorkService.GetTaskByTypeAndMonth();
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
        public DataTable GetTaskPercentByCategory()
        {
            try
            {
                return dC_OA_OverSeeWorkService.GetTaskPercentByCategory();
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

        public int GetTaskCountByCategory(string category)
        {
            try
            {
                return dC_OA_OverSeeWorkService.GetTaskCountByCategory(category);
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
        public int GetMyTaskCount()
        {
            try
            {
                return dC_OA_OverSeeWorkService.GetMyTaskCount();
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
        public int GetMyTaskCountEx()
        {
            try
            {
                return dC_OA_OverSeeWorkService.GetMyTaskCountEx();
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
