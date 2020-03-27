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
    /// 日 期：2019-08-16 09:48
    /// 描 述：粮食土地房屋信息管理
    /// </summary>
    public class DC_ASSETS_LandBaseInfofoodBLL : DC_ASSETS_LandBaseInfofoodIBLL
    {
        private DC_ASSETS_LandBaseInfofoodService dC_ASSETS_LandBaseInfofoodService = new DC_ASSETS_LandBaseInfofoodService();

        #region 获取数据

        /// <summary>
        /// 获取列表数据
        /// <summary>
        /// <returns></returns>
        public IEnumerable<DC_ASSETS_LandBaseInfofoodEntity> GetList( string queryJson )
        {
            try
            {
                return dC_ASSETS_LandBaseInfofoodService.GetList(queryJson);
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
        /// 获取列表分页数据
        /// <param name="pagination">分页参数</param>
        /// <summary>
        /// <returns></returns>
        public IEnumerable<DC_ASSETS_HouseInfofoodEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                return dC_ASSETS_LandBaseInfofoodService.GetPageList(pagination, queryJson);
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

        public IEnumerable<DC_ASSETS_HouseInfofoodEntity> GetLandfoodInfo(string F_Transferor)
        {

            try
            {
                return dC_ASSETS_LandBaseInfofoodService.GetLandfoodInfo(F_Transferor);
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
        /// 获取实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_ASSETS_LandBaseInfofoodEntity GetEntity(string keyValue)
        {
            try
            {
                return dC_ASSETS_LandBaseInfofoodService.GetEntity(keyValue);
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
        /// 获取实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DataTable GetLandfoodlist(string SearchValue)
        {
            try
            {
                return dC_ASSETS_LandBaseInfofoodService.GetLandfoodlist(SearchValue);
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
        public DC_ASSETS_LandBaseInfofoodEntity GetDC_ASSETS_LandBaseInfofoodEntity(string landname, string ceticate)
        {
            try
            {
                return dC_ASSETS_LandBaseInfofoodService.GetDC_ASSETS_LandBaseInfofoodEntity(landname, ceticate);
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
                dC_ASSETS_LandBaseInfofoodService.DeleteEntity(keyValue);
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
        public void SaveEntity(string keyValue, DC_ASSETS_LandBaseInfofoodEntity entity)
        {
            try
            {
                dC_ASSETS_LandBaseInfofoodService.SaveEntity(keyValue, entity);
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
                return dC_ASSETS_LandBaseInfofoodService.ImportLandEntity(dt);

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
