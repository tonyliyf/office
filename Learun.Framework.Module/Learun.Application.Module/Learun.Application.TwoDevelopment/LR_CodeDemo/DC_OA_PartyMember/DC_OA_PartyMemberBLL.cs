using Learun.Util;
using System;
using System.Data;
using System.Collections.Generic;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 DYT-OA V1.0 企业敏捷开发框架
    /// Copyright (c) 2018-2019 武汉东雅图科技技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-01-09 15:20
    /// 描 述：DC_OA_PartyMember
    /// </summary>
    public class DC_OA_PartyMemberBLL : DC_OA_PartyMemberIBLL
    {
        private DC_OA_PartyMemberService dC_OA_PartyMemberService = new DC_OA_PartyMemberService();

        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_OA_PartyMemberEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                return dC_OA_PartyMemberService.GetPageList(pagination, queryJson);
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
        /// 获取DC_OA_PartyMember表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_OA_PartyMemberEntity GetDC_OA_PartyMemberEntity(string keyValue)
        {
            try
            {
                return dC_OA_PartyMemberService.GetDC_OA_PartyMemberEntity(keyValue);
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
                DataTable list = dC_OA_PartyMemberService.GetSqlTree();
                List<TreeModel> treeList = new List<TreeModel>();
                foreach (DataRow item in list.Rows)
                {
                    TreeModel node = new TreeModel
                    {
                        id = item["f_partybranchguid"].ToString(),
                        text = item["f_partybranchname"].ToString(),
                        value = item["f_partybranchguid"].ToString(),
                        showcheck = false,
                        checkstate = 0,
                        isexpand = true,
                        parentId = item["f_ppartybranchcode"].ToString()
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
        public IEnumerable<DC_OA_PartyMemberDependentsEntity> GetDC_OA_PartyMemberDependentsList(string keyValue)
        {
            try
            {
                return dC_OA_PartyMemberService.GetDC_OA_PartyMemberDependentsList(keyValue);
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
                dC_OA_PartyMemberService.DeleteEntity(keyValue);
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
        public void SaveEntity(string keyValue, DC_OA_PartyMemberEntity entity, List<DC_OA_PartyMemberDependentsEntity> dC_OA_PartyMemberDependentsList)
        {
            try
            {
                dC_OA_PartyMemberService.SaveEntity(keyValue, entity, dC_OA_PartyMemberDependentsList);
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
