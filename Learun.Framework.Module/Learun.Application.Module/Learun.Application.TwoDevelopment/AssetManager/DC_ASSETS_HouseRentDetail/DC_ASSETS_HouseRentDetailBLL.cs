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
    /// 日 期：2019-02-16 14:32
    /// 描 述：DC_ASSETS_HouseRentDetail
    /// </summary>
    public class DC_ASSETS_HouseRentDetailBLL : DC_ASSETS_HouseRentDetailIBLL
    {
        private DC_ASSETS_HouseRentDetailService dC_ASSETS_HouseRentDetailService = new DC_ASSETS_HouseRentDetailService();

        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_ASSETS_HouseRentDetailEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                return dC_ASSETS_HouseRentDetailService.GetPageList(pagination, queryJson);
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
        public IEnumerable<DC_ASSETS_HouseRentDetailEntity> GetList()
        {
            try
            {
                return dC_ASSETS_HouseRentDetailService.GetList();
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
        public IEnumerable<DC_ASSETS_HouseRentDetailEntity> GetRentPageList(Pagination pagination, string queryJson)
        {

            try
            {
                return dC_ASSETS_HouseRentDetailService.GetRentPageList(pagination, queryJson);
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

        public IEnumerable<DC_ASSETS_HouseRentDetailEntity> GetRentList(string ids)
        {

            try
            {
                return dC_ASSETS_HouseRentDetailService.GetRentList(ids);
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

        public IEnumerable<DC_ASSETS_HouseRentDetailEntity> GetHouseRentDetailInfo (string KeyValue,string SearchValue)
        {

            try
            {
                return dC_ASSETS_HouseRentDetailService.GetHouseRentDetailInfo(KeyValue, SearchValue);
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

        public IEnumerable<DC_ASSETS_HouseRentDetailEntity> GetHouseRentDetailList()
        {
            try
            {
                return dC_ASSETS_HouseRentDetailService.GetHouseRentDetailList();
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

        public IEnumerable<DC_ASSETS_HouseRentIncomeEntity> GetHouseRentDetailInfoList()
        {
            try
            {
                return dC_ASSETS_HouseRentDetailService.GetHouseRentDetailInfoList();
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

        public IEnumerable<DC_ASSETS_HouseRentDetail_InfoEntity> GetDC_ASSETS_HouseRentDetailInfoList(string keyValue)
        {

            try
            {
                return dC_ASSETS_HouseRentDetailService.GetDC_ASSETS_HouseRentDetailInfoList(keyValue);
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
                return dC_ASSETS_HouseRentDetailService.ExportData(queryJson);
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
            /// 获取DC_ASSETS_HouseRentDetail表实体数据
            /// <param name="keyValue">主键</param>
            /// <summary>
            /// <returns></returns>
            public DC_ASSETS_HouseRentDetailEntity GetHouseRentDetailEntity(string keyValue)
        {
            try
            {
                return dC_ASSETS_HouseRentDetailService.GetHouseRentDetailEntity(keyValue);
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
            /// 获取DC_ASSETS_HouseRentDetail表实体数据
            /// <param name="keyValue">主键</param>
            /// <summary>
            /// <returns></returns>
            public DC_ASSETS_HouseRentDetailEntity GetHouseRentDetail(string keyValue)
        {
            try
            {
                return dC_ASSETS_HouseRentDetailService.GetHouseRentDetail(keyValue);
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
        /// 获取DC_ASSETS_HouseRentDetail表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_ASSETS_HouseRentDetailEntity GetDC_ASSETS_HouseRentDetailEntity(string keyValue)
        {
            try
            {
                return dC_ASSETS_HouseRentDetailService.GetDC_ASSETS_HouseRentDetailEntity(keyValue);
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
        /// 获取DC_ASSETS_HouseRentDetail表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_ASSETS_HouseRentDetailEntity GetDC_ASSETS_HouseRentDetailEntityByHouseId(string keyValue)
        {
            try
            {
                return dC_ASSETS_HouseRentDetailService.GetDC_ASSETS_HouseRentDetailEntityByHouseId(keyValue);
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
                DataTable list = dC_ASSETS_HouseRentDetailService.GetSqlTree();
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
                        parentId = item["parentid"].ToString()
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

        public double GetMinRentPrice(string keyValue)
        {
            try
            {
                return dC_ASSETS_HouseRentDetailService.GetMinRentPrice(keyValue);
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
                dC_ASSETS_HouseRentDetailService.DeleteEntity(keyValue);
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
        public void SaveEntity(string keyValue, DC_ASSETS_HouseRentDetailEntity entity)
        {
            try
            {
                dC_ASSETS_HouseRentDetailService.SaveEntity(keyValue, entity);
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
        public void SaveEntity(string keyValue, DC_ASSETS_HouseRentDetailEntity entity, List<DC_ASSETS_HouseRentDetail_InfoEntity> dC_ASSETS_HouseRentDetailInfoList)
        {
            try
            {
                dC_ASSETS_HouseRentDetailService.SaveEntity(keyValue, entity, dC_ASSETS_HouseRentDetailInfoList);
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
