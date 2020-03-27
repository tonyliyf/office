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
    /// 日 期：2019-08-02 15:29
    /// 描 述：HrmResource
    /// </summary>
    public class HrmResourceBLL : HrmResourceIBLL
    {
        private HrmResourceService hrmResourceService = new HrmResourceService();
        private HrmDepartmentService hrmDepartmentService = new HrmDepartmentService();
        private DepartmentBLL deptBll = new DepartmentBLL();
        private CompanyIBLL companyBll = new CompanyBLL();
        private UserIBLL useBll = new UserBLL();
        private HrmSubCompanyService hrmSubCompanyService = new HrmSubCompanyService();

        #region 获取数据

        /// <summary>
        /// 获取列表数据
        /// <summary>
        /// <returns></returns>
        public IEnumerable<HrmResourceEntity> GetList( string queryJson )
        {
            try
            {
                return hrmResourceService.GetList(queryJson);
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
        public IEnumerable<HrmResourceEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                return hrmResourceService.GetPageList(pagination, queryJson);
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
        public HrmResourceEntity GetEntity(int keyValue)
        {
            try
            {
                return hrmResourceService.GetEntity(keyValue);
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
                hrmResourceService.DeleteEntity(keyValue);
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
        public void SaveEntity(int keyValue, HrmResourceEntity entity)
        {
            try
            {
                hrmResourceService.SaveEntity(keyValue, entity);
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

        public void UpdateEntity()
        {

            IEnumerable<HrmResourceEntity> list = hrmResourceService.GetList("");
            foreach(HrmResourceEntity item in list)
            {
                UserEntity userEntity = useBll.GetEntityByWeaverid(item.id.ToString());
                CompanyEntity companyEntity = companyBll.GetEntityByWeaverid(item.subcompanyid1.ToString());
                DepartmentEntity entity = deptBll.GetEntityByWeaverid(item.departmentid.ToString());
                if (null ==userEntity)
                {
                    userEntity.F_Account = item.loginid;
                    userEntity.F_RealName = item.lastname;
                    userEntity.F_CompanyId = companyEntity.F_CompanyId;
                    userEntity.F_DepartmentId = entity.F_DepartmentId;
                    userEntity.Create();

                }
                else

                {
                    if(userEntity.F_Account!=item.loginid||userEntity.F_CompanyId!=companyEntity.F_CompanyId||userEntity.F_RealName!=item.lastname||userEntity.F_DepartmentId!=entity.F_DepartmentId)
                    {
                        userEntity.F_Account = item.loginid;
                        userEntity.F_CompanyId = companyEntity.F_CompanyId;
                        userEntity.F_RealName = item.lastname;
                        userEntity.F_DepartmentId = entity.F_DepartmentId;
                        userEntity.Modify(userEntity.F_UserId);

                    }



                }


            }


        }

        #endregion

    }
}
