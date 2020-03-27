using Learun.Util;
using System;
using System.Data;
using System.Collections.Generic;
using Learun.Application.Organization;
using System.Linq;

namespace Learun.Application.TwoDevelopment.EcologyDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-08-02 15:15
    /// 描 述：HrmSubCompany
    /// </summary>
    public class HrmSubCompanyBLL : HrmSubCompanyIBLL
    {
        private HrmSubCompanyService hrmSubCompanyService = new HrmSubCompanyService();
        private CompanyIBLL companyBll = new CompanyBLL();

        #region 获取数据

        /// <summary>
        /// 获取列表数据
        /// <summary>
        /// <returns></returns>
        public IEnumerable<HrmSubCompanyEntity> GetList( string queryJson )
        {
            try
            {
                return hrmSubCompanyService.GetList(queryJson);
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
        public IEnumerable<HrmSubCompanyEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                return hrmSubCompanyService.GetPageList(pagination, queryJson);
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
        public HrmSubCompanyEntity GetEntity(int keyValue)
        {
            try
            {
                return hrmSubCompanyService.GetEntity(keyValue);
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
        public void DeleteEntity(int keyValue)
        {
            try
            {
                hrmSubCompanyService.DeleteEntity(keyValue);
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
        public void SaveEntity(int keyValue, HrmSubCompanyEntity entity)
        {
            try
            {
                hrmSubCompanyService.SaveEntity(keyValue, entity);
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

        public  void UpdateCompany()
        {

            IEnumerable<HrmSubCompanyEntity> list = hrmSubCompanyService.GetList("");
            IEnumerable<CompanyEntity> currentList = companyBll.GetList();
            foreach(HrmSubCompanyEntity item in list)
            {
                CompanyEntity entity = companyBll.GetEntityByWeaverid(item.id.ToString());
                if(null ==entity)
                {
                    entity = new CompanyEntity();
                    entity.F_FullName = item.subcompanyname;
                    entity.F_WeaverCompanyId = item.id.ToString();
                    entity.Create();
                }
                else
                {
                    if(entity.F_FullName != item.subcompanyname&&item.subcompanyname.ToLower()!="default")
                    {

                        entity.F_FullName = item.subcompanyname;
                        entity.Modify(entity.F_CompanyId);
                    }

                }
            }

        }

        #endregion

    }
}
