using Dapper;
using Learun.DataBase.Repository;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Learun.Application.TwoDevelopment.AssetManager
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-08-16 10:05
    /// 描 述：DC_ASSETS_BuildingBaseInfo
    /// </summary>
    public class DC_ASSETS_BuildingBaseInfofoodService : RepositoryFactory
    {
        #region 构造函数和属性

        private string fieldSql;
        public DC_ASSETS_BuildingBaseInfofoodService()
        {
            fieldSql=@"
                t.F_BBIId,
                t.F_CommunityCode,
                t.F_AddressCode,
                t.F_Address,
                t.F_ConstructionCode,
                t.F_ConstructionName,
                t.F_ConstructionHeight,
                t.F_ConstructionFloorCount,
                t.F_UnitCount,
                t.F_ConstructionArea,
                t.F_UsageArea,
                t.F_CoverArea,
                t.F_UseCategories,
                t.F_StructureClassification,
                t.F_AvailableYears,
                t.F_UseSituation,
                t.F_CompletionTime,
                t.F_FireRating,
                t.F_BuildingRecordNumber,
                t.F_PictureAccessories,
                t.F_OtherAccessories,
                t.F_FormerUnit,
                t.F_FormerUnitContacts,
                t.F_ContactsPhone,
                t.F_IfUse,
                t.F_Remarks,
                t.F_CenterpointCoordinates,
                t.F_BoundaryCoordinates,
                t.F_CreateDepartmentId,
                t.F_CreateDepartment,
                t.F_CreateUserid,
                t.F_CreateUser,
                t.F_CreateDatetime,
                t.F_BuildingClass,
                t.F_BuildingValue,
                t.F_LBIId,
                t.F_OldUnit
            ";
        }
        #endregion

        #region 获取数据

        /// <summary>
        /// 获取列表数据
        /// <summary>
        /// <returns></returns>
        public IEnumerable<DC_ASSETS_BuildingBaseInfofoodEntity> GetList( string queryJson )
        {
            try
            {
                //参考写法
                //var queryParam = queryJson.ToJObject();
                // 虚拟参数
                //var dp = new DynamicParameters(new { });
                //dp.Add("startTime", queryParam["StartTime"].ToDate(), DbType.DateTime);
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(fieldSql);
                strSql.Append(" FROM DC_ASSETS_BuildingBaseInfofood t ");
                return this.BaseRepository().FindList<DC_ASSETS_BuildingBaseInfofoodEntity>(strSql.ToString());
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }
        }

        /// <summary>
        /// 获取列表分页数据
        /// <param name="pagination">分页参数</param>
        /// <summary>
        /// <returns></returns>
        public IEnumerable<DC_ASSETS_BuildingBaseInfofoodEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(fieldSql);
                strSql.Append(" FROM DC_ASSETS_BuildingBaseInfofood t ");
                return this.BaseRepository().FindList<DC_ASSETS_BuildingBaseInfofoodEntity>(strSql.ToString(), pagination);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }
        }

        /// <summary>
        /// 获取实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_ASSETS_BuildingBaseInfofoodEntity GetEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_ASSETS_BuildingBaseInfofoodEntity>(keyValue);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
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
                this.BaseRepository().Delete<DC_ASSETS_BuildingBaseInfofoodEntity>(t=>t.F_BBIId == keyValue);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }
        }

        /// <summary>
        /// 保存实体数据（新增、修改）
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public void SaveEntity(string keyValue, DC_ASSETS_BuildingBaseInfofoodEntity entity)
        {
            try
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    entity.Modify(keyValue);
                    this.BaseRepository().Update(entity);
                }
                else
                {
                    entity.Create();
                    this.BaseRepository().Insert(entity);
                }
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }
        }



        /// <summary>
        /// 获取DC_ASSETS_BuildingBaseInfo表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_ASSETS_BuildingBaseInfofoodEntity GetDC_ASSETS_BuildingBaseInfofood(string F_LBIId, string BuildingName)
        {
            try
            {

                var list = this.BaseRepository().FindEntity<DC_ASSETS_BuildingBaseInfofoodEntity>(i => i.F_LBIId == F_LBIId && i.F_ConstructionName == BuildingName);

                return list;

            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }
        }

        #endregion

    }
}
