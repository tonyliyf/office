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
    /// 日 期：2019-01-25 16:49
    /// 描 述：DC_OA_Attence
    /// </summary>
    public class DC_OA_AttenceBLL : DC_OA_AttenceIBLL
    {
        private DC_OA_AttenceService dC_OA_AttenceService = new DC_OA_AttenceService();

        #region 获取数据 

        /// <summary> 
        /// 获取页面显示列表数据 
        /// <summary> 
        /// <param name="queryJson">查询参数</param> 
        /// <returns></returns> 
        public IEnumerable<DC_OA_AttenceEntity> GetPageList(Pagination pagination, string queryJson,string isPower)
        {
            try
            {
                return dC_OA_AttenceService.GetPageList(pagination, queryJson,isPower);
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


        public DataTable GetAttenceRocord(string Month, string userid)
        {

            try
            {
                return dC_OA_AttenceService.GetAttenceRocord(Month, userid);
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

        public DataTable GetAttenceRocord(DateTime dtStart, DateTime dtEnd, string userids)
        {
            try
            {
                return dC_OA_AttenceService.GetAttenceMonth(dtStart, dtEnd,userids);
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
        public IEnumerable<DC_OA_AttenceEntity> GetPageList(string queryJson)
        {
            try
            {
                return dC_OA_AttenceService.GetPageList(queryJson);
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

        public DataTable GetDataSource(string queryJson)
        {

            try
            {
                return dC_OA_AttenceService.GetDataSource(queryJson);
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
        /// 获取DC_OA_Attence表实体数据 
        /// <param name="keyValue">主键</param> 
        /// <summary> 
        /// <returns></returns> 
        public DC_OA_AttenceEntity GetDC_OA_AttenceEntity(string keyValue)
        {
            try
            {
                return dC_OA_AttenceService.GetDC_OA_AttenceEntity(keyValue);
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
                DataTable list = dC_OA_AttenceService.GetSqlTree();
                List<TreeModel> treeList = new List<TreeModel>();
                foreach (DataRow item in list.Rows)
                {
                    TreeModel node = new TreeModel
                    {
                        id = item["f_companyid"].ToString(),
                        text = item["f_fullname"].ToString(),
                        value = item["f_companyid"].ToString(),
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
                dC_OA_AttenceService.DeleteEntity(keyValue);
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
        public void SaveEntity(string keyValue, DC_OA_AttenceEntity entity)
        {
            try
            {
                dC_OA_AttenceService.SaveEntity(keyValue, entity);
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

        public bool InsertDC_OA_AttenceByMonth(DateTime dtStart, DateTime dtEnd)
        {

            try
            {
                return  dC_OA_AttenceService.InsertDC_OA_AttenceByMonth(dtStart,dtEnd);
               
            }
            catch (Exception ex)
            {
                return false;
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
