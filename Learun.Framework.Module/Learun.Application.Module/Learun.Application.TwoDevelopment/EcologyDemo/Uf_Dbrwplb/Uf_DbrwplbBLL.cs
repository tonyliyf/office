using Learun.Util;
using System;
using System.Data;
using System.Collections.Generic;

namespace Learun.Application.TwoDevelopment.EcologyDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2020-01-02 10:05
    /// 描 述：督办任务评论
    /// </summary>
    public class Uf_DbrwplbBLL : Uf_DbrwplbIBLL
    {
        private Uf_DbrwplbService uf_DbrwplbService = new Uf_DbrwplbService();

        #region 获取数据

        /// <summary>
        /// 获取列表数据
        /// <summary>
        /// <returns></returns>
        public IEnumerable<uf_dbrwplbEntity> GetList(string taskid, string subtaskid)
        {
            try
            {
                return uf_DbrwplbService.GetList(taskid, subtaskid);
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

        public DataSet GettableList(string taskid, string subtaskid)
        {
            try
            {
                return uf_DbrwplbService.GettableList(taskid, subtaskid);
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
        public IEnumerable<uf_dbrwplbEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                return uf_DbrwplbService.GetPageList(pagination, queryJson);
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
        public uf_dbrwplbEntity GetEntity(string keyValue)
        {
            try
            {
                return uf_DbrwplbService.GetEntity(keyValue);
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
                uf_DbrwplbService.DeleteEntity(keyValue);
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
        public void SaveEntity(string keyValue, uf_dbrwplbEntity entity)
        {
            try
            {
                uf_DbrwplbService.SaveEntity(keyValue, entity);
            }
            catch (Exception ex)
            {
                SimpleLogUtil.WriteTextLog("uf_dbrwplbEntity", ex.Message, DateTime.Now);
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
        /// 保存实体数据（评论回复）
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public void SavePLHF(string keyValue, uf_dbrwplbEntity entity, string replyid)
        {
            try
            {
                uf_DbrwplbService.SavePLHF(keyValue, entity, replyid);
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
