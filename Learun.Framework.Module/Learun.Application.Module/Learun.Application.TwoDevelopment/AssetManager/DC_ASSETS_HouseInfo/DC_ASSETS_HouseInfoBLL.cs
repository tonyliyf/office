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
    /// 日 期：2019-02-13 17:40
    /// 描 述：DC_ASSETS_HouseInfo
    /// </summary>
    public class DC_ASSETS_HouseInfoBLL : DC_ASSETS_HouseInfoIBLL
    {
        private DC_ASSETS_HouseInfoService dC_ASSETS_HouseInfoService = new DC_ASSETS_HouseInfoService();

        #region 获取数据



        /// <summary>
        /// 获取左侧树形数据
        /// <summary>
        /// <returns></returns>
        public List<TreeModel> GetTree(string keyValue)
        {
            try
            {
                DataTable list = dC_ASSETS_HouseInfoService.GetSqlTree(keyValue);
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
                return dC_ASSETS_HouseInfoService.ExportData(queryJson);
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


        public bool ImportCertiate(string FileDirectory, string numbersName, ref string Msg)
        {
            try
            {
                return dC_ASSETS_HouseInfoService.ImportCertiate(FileDirectory, numbersName,ref Msg);
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
                return dC_ASSETS_HouseInfoService.ExportLandHouseData(queryJson);
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
                return dC_ASSETS_HouseInfoService.ExportHouseData(queryJson);
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
                return dC_ASSETS_HouseInfoService.GetboardsInfo();
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
        public DataTable GetHouseAssigneeListt(string F_FormerUnit, string SearchValue)
        {
            try
            {
                return dC_ASSETS_HouseInfoService.GetHouseAssigneeListt(F_FormerUnit, SearchValue);
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
        public DataTable GetHouseAssigneeDetail(string State, string SearchValue)
        {
            try
            {
                return dC_ASSETS_HouseInfoService.GetHouseAssigneeDetail(State, SearchValue);
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
        public DataTable GetHouseAssigneeSearch(string F_FormerUnit, string SearchValue)
        {

            try
            {
                return dC_ASSETS_HouseInfoService.GetHouseAssigneeSearch(F_FormerUnit, SearchValue);
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
        public IEnumerable<DC_ASSETS_HouseInfoEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                return dC_ASSETS_HouseInfoService.GetPageList(pagination, queryJson);
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
        public IEnumerable<DC_ASSETS_HouseInfoEntity> GetTotalPageList(Pagination pagination, string queryJson)
        {
            try
            {
                return dC_ASSETS_HouseInfoService.GetTotalPageList(pagination, queryJson);
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
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<HouseRentInfo> GetHouseRentInfoPageList(string queryJson)
        {
            try
            {
                return dC_ASSETS_HouseInfoService.GetHouseRentInfoPageList(queryJson);
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
        public IEnumerable<DC_ASSETS_HouseInfoEntity> GetTotalNoLandPageList(Pagination pagination, string queryJson)
        {
            try
            {
                return dC_ASSETS_HouseInfoService.GetTotalNoLandPageList(pagination, queryJson);
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
        /// 获取DC_ASSETS_HouseInfo表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_ASSETS_HouseInfoEntity GetDC_ASSETS_HouseInfoEntity(string keyValue)
        {
            try
            {
                return dC_ASSETS_HouseInfoService.GetDC_ASSETS_HouseInfoEntity(keyValue);
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
        /// 获取DC_ASSETS_HouseInfo表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_ASSETS_HouseInfoEntity GetDC_ASSETS_HouseInfoByAddress(string address, string unit)
        {
            try
            {
                return dC_ASSETS_HouseInfoService.GetDC_ASSETS_HouseInfoByAddress(address,unit);
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
        /// 获取DC_ASSETS_HouseInfo表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_ASSETS_HouseInfoEntity GetDC_ASSETS_HouseInfo(string keyValue)
        {
            try
            {
                return dC_ASSETS_HouseInfoService.GetDC_ASSETS_HouseInfo(keyValue);
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
        /// 获取DC_ASSETS_HouseInfo表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_ASSETS_HouseInfoEntity GetHouseInfoLandbase(string keyValue)
        {
            try
            {
                return dC_ASSETS_HouseInfoService.GetHouseInfoLandbase(keyValue);
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
        /// 获取DC_ASSETS_HouseInfo表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public string GetOldUnitByHouseId(string HouseID)
        {
            try
            {
                return dC_ASSETS_HouseInfoService.GetOldUnitByHouseId(HouseID);
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
        /// 获取DC_ASSETS_HouseInfo表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public string GetOwnerByHouseId(string HouseID)
        {
            try
            {
                return dC_ASSETS_HouseInfoService.GetOwnerByHouseId(HouseID);
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
                dC_ASSETS_HouseInfoService.DeleteEntity(keyValue);
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
        /// 删除实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public void UpdateComHouse()
        {
            try
            {
                dC_ASSETS_HouseInfoService.UpdateComHouse();
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
        public void SaveEntity(string keyValue, DC_ASSETS_HouseInfoEntity entity)
        {
            try
            {
                dC_ASSETS_HouseInfoService.SaveEntity(keyValue, entity);
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
        public void SaveTotalEntity(string keyValue, DC_ASSETS_LandBaseInfoEntity Landentity, DC_ASSETS_BuildingBaseInfoEntity Buildingentity, DC_ASSETS_HouseInfoEntity entity)
        {
            try
            {
                dC_ASSETS_HouseInfoService.SaveTotalEntity(keyValue, Landentity,Buildingentity, entity);
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
        public void SaveTotalEntity(string keyValue, DC_ASSETS_BuildingBaseInfoEntity Buildingentity, DC_ASSETS_HouseInfoEntity entity)
        {
            try
            {
                dC_ASSETS_HouseInfoService.SaveTotalEntity(keyValue, Buildingentity, entity);
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

        public DataTable StatisticsHouseInfo(DateTime startDate,DateTime endDate)
        {
            try
            {
                return dC_ASSETS_HouseInfoService.StatisticsHouseInfo(startDate,endDate);
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
        public DataTable StatisticsHouseInfoEx(DateTime startDate, DateTime endDate)
        {
            try
            {
                return dC_ASSETS_HouseInfoService.StatisticsHouseInfoEx(startDate, endDate);
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
