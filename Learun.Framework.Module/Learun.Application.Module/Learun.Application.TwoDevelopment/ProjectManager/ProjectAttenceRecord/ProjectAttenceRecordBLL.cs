using Learun.Util;
using System;
using System.Data;
using System.Collections.Generic;

namespace Learun.Application.TwoDevelopment.ProjectManager
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-07-30 15:42
    /// 描 述：项目考勤记录
    /// </summary>
    public class ProjectAttenceRecordBLL : ProjectAttenceRecordIBLL
    {
        private ProjectAttenceRecordService projectAttenceRecordService = new ProjectAttenceRecordService();

        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<Project_AttenceRecordEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                return projectAttenceRecordService.GetPageList(pagination, queryJson);
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
                bool btrue = projectAttenceRecordService.Import_LandHandUpInfoEntity(dt);
                // dC_ASSETS_LandHandUpInfoService.UpdateBuildValue();
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
        /// <summary>
        /// 获取Project_AttenceRecord表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public Project_AttenceRecordEntity GetProject_AttenceRecordEntity(string keyValue)
        {
            try
            {
                return projectAttenceRecordService.GetProject_AttenceRecordEntity(keyValue);
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
        /// 获取DC_EngineProject_ProjectInfo表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_EngineProject_ProjectInfoEntity GetDC_EngineProject_ProjectInfoEntity(string keyValue)
        {
            try
            {
                return projectAttenceRecordService.GetDC_EngineProject_ProjectInfoEntity(keyValue);
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
                DataTable list = projectAttenceRecordService.GetSqlTree();
                List<TreeModel> treeList = new List<TreeModel>();



                TreeModel rootNode = new TreeModel
                {
                    id = "0",
                    text = "项目信息",
                    value = "0",
                    showcheck = false,
                    checkstate = 0,
                    isexpand = true,
                    parentId = "-1"
               };
                treeList.Add(rootNode);

            foreach (DataRow item in list.Rows)
                {
                    TreeModel node = new TreeModel
                    {
                        id = item["f_piid"].ToString(),
                        text = item["f_projectname"].ToString(),
                        value ="0",
                        showcheck = false,
                        checkstate = 0,
                        isexpand = true,
                        parentId = "0"
                    };
                    treeList.Add(node);                }
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
                projectAttenceRecordService.DeleteEntity(keyValue);
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
        public void SaveEntity(string keyValue, Project_AttenceRecordEntity entity,DC_EngineProject_ProjectInfoEntity dC_EngineProject_ProjectInfoEntity)
        {
            try
            {
                projectAttenceRecordService.SaveEntity(keyValue, entity,dC_EngineProject_ProjectInfoEntity);
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

        public DataTable GetRecord(string Projectid,string Month, string code)
        {
            try
            {
               return projectAttenceRecordService.GetRecord(Projectid, Month,code);
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
        public DataTable GetRecord1(string Projectid, string Month)
        {
            try
            {
                return projectAttenceRecordService.GetRecord1(Projectid, Month);
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
