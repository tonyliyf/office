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
    /// 日 期：2019-02-14 10:05
    /// 描 述：DC_ASSETS_BusStopBillboards
    /// </summary>
    public class DC_ASSETS_BusStopBillboardsBLL : DC_ASSETS_BusStopBillboardsIBLL
    {
        private DC_ASSETS_BusStopBillboardsService dC_ASSETS_BusStopBillboardsService = new DC_ASSETS_BusStopBillboardsService();

        #region 获取数据

        /// <summary>
        /// 获取左侧树形数据
        /// <summary>
        /// <returns></returns>
        public List<TreeModel> GetTree()
        {
            try
            {
                DataTable list = dC_ASSETS_BusStopBillboardsService.GetSqlTree();
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
                        isexpand = true,
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
                return dC_ASSETS_BusStopBillboardsService.ExportData(queryJson);
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
        public DataTable GetHouseboardsList()
        {
            try
            {
                return dC_ASSETS_BusStopBillboardsService.GetHouseboardsList();
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
        public DataTable GetboardsAssigneeSearch(string F_BillboardsCategory, string SearchValue)
        {

            try
            {
                return dC_ASSETS_BusStopBillboardsService.GetboardsAssigneeSearch(F_BillboardsCategory, SearchValue);
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
        public DataTable GetboardsAssigneeDetail1(string State, string SearchValue)
        {

            try
            {
                return dC_ASSETS_BusStopBillboardsService.GetboardsAssigneeDetail1(State, SearchValue);
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
        public IEnumerable<DC_ASSETS_BusStopBillboardsEntity> GetPageList(string queryJson)
        {
            try
            {
                return dC_ASSETS_BusStopBillboardsService.GetPageList(queryJson);
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
        public DataTable GetboardsInfo()
        {
            try
            {
                return dC_ASSETS_BusStopBillboardsService.GetboardsInfo();
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
        /// 获取DC_ASSETS_BusStopBillboards表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_ASSETS_BusStopBillboardsEntity GetDC_ASSETS_BusStopBillboardsEntity(string keyValue)
        {
            try
            {
                return dC_ASSETS_BusStopBillboardsService.GetDC_ASSETS_BusStopBillboardsEntity(keyValue);
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
                dC_ASSETS_BusStopBillboardsService.DeleteEntity(keyValue);
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
        public void SaveEntity(string keyValue, DC_ASSETS_BusStopBillboardsEntity entity)
        {
            try
            {
                dC_ASSETS_BusStopBillboardsService.SaveEntity(keyValue, entity);
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
                return dC_ASSETS_BusStopBillboardsService.ImportLandEntity(dt);

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
