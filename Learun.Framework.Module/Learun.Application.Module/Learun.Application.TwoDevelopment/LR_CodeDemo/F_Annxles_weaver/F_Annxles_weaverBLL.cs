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
    /// 日 期：2019-12-16 10:45
    /// 描 述：F_Annxles_weaver
    /// </summary>
    public class F_Annxles_weaverBLL : F_Annxles_weaverIBLL
    {
        private F_Annxles_weaverService f_Annxles_weaverService = new F_Annxles_weaverService();

        #region 获取数据

        /// <summary>
        /// 获取列表数据
        /// <summary>
        /// <returns></returns>
        public IEnumerable<F_Annxles_weaverEntity> GetList( string queryJson )
        {
            try
            {
                return f_Annxles_weaverService.GetList(queryJson);
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
        public IEnumerable<F_Annxles_weaverEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                return f_Annxles_weaverService.GetPageList(pagination, queryJson);
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
        public F_Annxles_weaverEntity GetEntity(string keyValue)
        {
            try
            {
                return f_Annxles_weaverService.GetEntity(keyValue);
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
                f_Annxles_weaverService.DeleteEntity(keyValue);
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
        public void SaveEntity(string keyValue, F_Annxles_weaverEntity entity)
        {
            try
            {
                f_Annxles_weaverService.SaveEntity(keyValue, entity);
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

        public bool MoveMainRecord()
        {
            try
            {
                return f_Annxles_weaverService.MoveMainRecord();
            }
            catch (Exception ex)
            {
               
                return false;
            }


        }

        public  string GetWeaverFileUrl(int weaverid, string tablename, bool isimage)
        {
            try
            {
                return f_Annxles_weaverService.GetWeaverFileUrl(weaverid,tablename,isimage);
            }
            catch (Exception ex)
            {

                return null;
            }


        }


        #endregion

    }
}
