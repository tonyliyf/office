using Learun.Util;
using System;
using System.Data;
using System.Collections.Generic;
using Learun.Application.Organization;

namespace Learun.Application.TwoDevelopment.EcologyDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-08-02 15:33
    /// 描 述：HrmDepartment
    /// </summary>
    public class HrmDepartmentBLL : HrmDepartmentIBLL
    {
        private HrmDepartmentService hrmDepartmentService = new HrmDepartmentService();
        private DepartmentBLL deptBll = new DepartmentBLL();
        private CompanyIBLL companyBll = new CompanyBLL();
        private HrmSubCompanyService hrmSubCompanyService = new HrmSubCompanyService();

        #region 获取数据

        /// <summary>
        /// 获取列表数据
        /// <summary>
        /// <returns></returns>
        public IEnumerable<HrmDepartmentEntity> GetList(string queryJson)
        {
            try
            {
                return hrmDepartmentService.GetList(queryJson);
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
        public IEnumerable<HrmDepartmentEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                return hrmDepartmentService.GetPageList(pagination, queryJson);
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
        public HrmDepartmentEntity GetEntity(int keyValue)
        {
            try
            {
                return hrmDepartmentService.GetEntity(keyValue);
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
                hrmDepartmentService.DeleteEntity(keyValue);
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
        public void SaveEntity(int keyValue, HrmDepartmentEntity entity)
        {
            try
            {
                hrmDepartmentService.SaveEntity(keyValue, entity);
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

        public void UpdateDept()
        {

            IEnumerable<HrmDepartmentEntity> list = hrmDepartmentService.GetList("");
            IEnumerable<DepartmentEntity> currentList = deptBll.GetList();
            foreach (HrmDepartmentEntity item in list)
            {


                //HrmSubCompanyEntity companyEntity = hrmSubCompanyService.GetEntity((int)item.subcompanyid1);
                    CompanyEntity companyEntity = companyBll.GetEntityByWeaverid(item.subcompanyid1.ToString());
                    DepartmentEntity entity = deptBll.GetEntityByWeaverid(item.id.ToString());
                
                if (null == entity)
                {
                    entity = new DepartmentEntity();
                    entity.F_FullName = item.departmentname;
                    entity.F_CompanyId = companyEntity.F_CompanyId;
                    entity.F_WeaverDeptId = item.id.ToString();

                }
                else
                {
                    if( entity.F_FullName !=item.departmentname||entity.F_CompanyId!=companyEntity.F_CompanyId)
                    {
                        entity.F_FullName = item.departmentname;
                        entity.F_CompanyId = companyEntity.F_CompanyId;
                        entity.Modify(entity.F_DepartmentId);

                    }


                }
            }



        }

        #endregion

    }
}
