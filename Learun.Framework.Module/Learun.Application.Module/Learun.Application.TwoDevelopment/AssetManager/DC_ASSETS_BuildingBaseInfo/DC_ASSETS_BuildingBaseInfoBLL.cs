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
    /// 日 期：2019-02-13 15:11
    /// 描 述：DC_ASSETS_BuildingBaseInfo
    /// </summary>
    public class DC_ASSETS_BuildingBaseInfoBLL : DC_ASSETS_BuildingBaseInfoIBLL
    {
        private DC_ASSETS_BuildingBaseInfoService dC_ASSETS_BuildingBaseInfoService = new DC_ASSETS_BuildingBaseInfoService();

        #region 获取数据


        /// <summary>
        /// 获取左侧树形数据
        /// <summary>
        /// <returns></returns>
        public List<TreeModel> GetTree(string keyValue)
        {
            try
            {
                DataTable list = dC_ASSETS_BuildingBaseInfoService.GetSqlTree(keyValue);
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
        /// 获取左侧树形数据
        /// <summary>
        /// <returns></returns>
        public List<TreeModel> GetTreeLandbase(string unit)
        {
            try
            {
                DataTable list = dC_ASSETS_BuildingBaseInfoService.GetTreeLandbase(unit);
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
        public IEnumerable<DC_ASSETS_BuildingBaseInfoEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                return dC_ASSETS_BuildingBaseInfoService.GetPageList(pagination, queryJson);
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
                return dC_ASSETS_BuildingBaseInfoService.ExportData(queryJson);
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
        public DataTable GetMapList(string Typecode, string Street, string pageSize, string index)
        {
            try
            {
                return dC_ASSETS_BuildingBaseInfoService.GetMapList(Typecode, Street, pageSize, index);
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
        public DataTable GetStreet()
        {
            try
            {
                return dC_ASSETS_BuildingBaseInfoService.GetStreet();
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
        /// 获取DC_ASSETS_BuildingBaseInfo表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_ASSETS_BuildingBaseInfoEntity GetDC_ASSETS_BuildingBaseInfoEntity(string keyValue)
        {
            try
            {
                return dC_ASSETS_BuildingBaseInfoService.GetDC_ASSETS_BuildingBaseInfoEntity(keyValue);
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
        /// 获取DC_ASSETS_BuildingBaseInfo表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_ASSETS_BuildingBaseInfoEntity GetDC_ASSETS_BuildingBaseInfo(string oldUnit, string BuildingName)
        {
            try
            {
                return dC_ASSETS_BuildingBaseInfoService.GetDC_ASSETS_BuildingInfo(oldUnit, BuildingName);
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
        /// 获取DC_ASSETS_BuildingBaseInfo表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_ASSETS_BuildingBaseInfoEntity GetDC_ASSETS_BuildingBaseInfoEntity(string F_LBIId, string BuildingName)
        {
            try
            {
                return dC_ASSETS_BuildingBaseInfoService.GetDC_ASSETS_BuildingBaseInfo(F_LBIId,BuildingName);
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
        /// 获取DC_ASSETS_BuildingBaseInfo表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_ASSETS_BuildingBaseInfoEntity GetDC_ASSETS_BuildingBaseInfo(string keyValue)
        {
            try
            {
                return dC_ASSETS_BuildingBaseInfoService.GetDC_ASSETS_BuildingBaseInfo(keyValue);
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
                dC_ASSETS_BuildingBaseInfoService.DeleteEntity(keyValue);
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
        public void SaveEntity(string keyValue, DC_ASSETS_BuildingBaseInfoEntity entity)
        {
            try
            {
                dC_ASSETS_BuildingBaseInfoService.SaveEntity(keyValue, entity);
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
                bool btrue= dC_ASSETS_BuildingBaseInfoService.ImportBuildingEntity(dt);
               // dC_ASSETS_BuildingBaseInfoService.UpdateBuildValue();
                return btrue;
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
