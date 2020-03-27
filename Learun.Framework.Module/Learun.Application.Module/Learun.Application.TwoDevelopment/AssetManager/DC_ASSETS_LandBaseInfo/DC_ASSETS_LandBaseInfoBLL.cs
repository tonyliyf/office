using Learun.Util;
using System;
using System.Data;
using System.Collections.Generic;

namespace Learun.Application.TwoDevelopment.AssetManager
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-02-13 11:36
    /// 描 述：DC_ASSETS_LandBaseInfo
    /// </summary>
    public class DC_ASSETS_LandBaseInfoBLL : DC_ASSETS_LandBaseInfoIBLL
    {
        private DC_ASSETS_LandBaseInfoService dC_ASSETS_LandBaseInfoService = new DC_ASSETS_LandBaseInfoService();

        #region 获取数据


        /// <summary>
        /// 获取左侧树形数据
        /// <summary>
        /// <returns></returns>
        public List<TreeModel> GetTree(string unit)
        {
            try
            {
                DataTable list = dC_ASSETS_LandBaseInfoService.GetSqlTree(unit);
                List<TreeModel> treeList = new List<TreeModel>();
                foreach (DataRow item in list.Rows)
                {
                    TreeModel node = new TreeModel
                    {
                        id = item["id"].ToString(),
                        text = item["name"].ToString(),
                        value = item["id"].ToString(),
                        showcheck = false,
                        checkstate = 0,
                        isexpand = false,
                        parentId = item["pid"].ToString()
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
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public DataTable ExportData(string queryJson)
        {
            try
            {
                return dC_ASSETS_LandBaseInfoService.ExportData(queryJson);
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
        public DataTable ExportLandHouseData(string queryJson)
        {
            try
            {
                return dC_ASSETS_LandBaseInfoService.ExportData(queryJson);
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
        public DataTable ExportHouseData(string queryJson)
        {
            try
            {
                return dC_ASSETS_LandBaseInfoService.ExportData(queryJson);
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
        public IEnumerable<DC_ASSETS_LandBaseInfoEntity> GetPageList(Pagination pagination, string queryJson,string type)
        {
            try
            {
                return dC_ASSETS_LandBaseInfoService.GetPageList(pagination, queryJson,type);
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

        public bool ImportEntity(DataTable dt)
        {

            try
            {
                return  dC_ASSETS_LandBaseInfoService.ImportLandEntity(dt);
               
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

        public bool ImportEntity2NoBuilding(DataTable dt)
        {

            try
            {
                return dC_ASSETS_LandBaseInfoService.ImportEntity2NoBuilding(dt);

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
        /// 获取DC_ASSETS_LandBaseInfo表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_ASSETS_LandBaseInfoEntity GetDC_ASSETS_LandBaseInfoEntity(string keyValue)
        {
            try
            {
                return dC_ASSETS_LandBaseInfoService.GetDC_ASSETS_LandBaseInfoEntity(keyValue);
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
        /// 获取DC_ASSETS_LandBaseInfo表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_ASSETS_LandBaseInfoEntity GetDC_ASSETS_LandBaseInfoEntity(string landname, string ceticate)
        {
            try
            {
                return dC_ASSETS_LandBaseInfoService.GetDC_ASSETS_LandBaseInfoEntity(landname,ceticate);
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
                dC_ASSETS_LandBaseInfoService.DeleteEntity(keyValue);
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
        public void SaveEntity(string keyValue, DC_ASSETS_LandBaseInfoEntity entity)
        {
            try
            {
                dC_ASSETS_LandBaseInfoService.SaveEntity(keyValue, entity);
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
        public IEnumerable<PieChartModel> StatisticsLandInfo()
        {
            try
            {
                return dC_ASSETS_LandBaseInfoService.StatisticsLandInfo();
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
        public DataTable StatisticsLandInfoByArea(DateTime startDate, DateTime endDate)
        {
            try
            {
                return dC_ASSETS_LandBaseInfoService.StatisticsLandInfoByArea(startDate,endDate);
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
        public DataTable StatisticsLandInfoByAreaEx(DateTime startDate, DateTime endDate)
        {
            try
            {
                return dC_ASSETS_LandBaseInfoService.StatisticsLandInfoByAreaEx(startDate,endDate);
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

        public DataTable GetExportData(string queryJson)
        {

            try
            {
                return dC_ASSETS_LandBaseInfoService.ExportData(queryJson);
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
        public DataTable GetExportComLandbase()
        {

            try
            {
                return dC_ASSETS_LandBaseInfoService.GetExportComLandbase();
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
        
        public DataTable GetComLandbase(string queryJson)
        {

            try
            {
                return dC_ASSETS_LandBaseInfoService.GetComLandbase(queryJson);
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

        public DataTable GetLandInfo()
        {
            try
            {
                return dC_ASSETS_LandBaseInfoService.GetLandInfo();
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
        
        public DataTable GetLandAssigneeList(string F_Assignee, string SearchValue)
        {
            try
            {
                return dC_ASSETS_LandBaseInfoService.GetLandAssigneeList(F_Assignee, SearchValue);
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
       public DataTable GetLandAssigneeData(string F_Assignee, string F_Transferor)
        {

            try
            {
                return dC_ASSETS_LandBaseInfoService.GetLandAssigneeData(F_Assignee, F_Transferor);
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

       public DataTable GetLandAssigneeSearch(string F_Assignee, string SearchValue)
        {

            try
            {
                return dC_ASSETS_LandBaseInfoService.GetLandAssigneeSearch(F_Assignee, SearchValue);
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
