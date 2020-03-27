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
    /// 日 期：2019-08-16 10:22
    /// 描 述：DC_ASSETS_HouseInfofood
    /// </summary>
    public class DC_ASSETS_HouseInfofoodService : RepositoryFactory
    {
        #region 构造函数和属性

        private string fieldSql;
        public DC_ASSETS_HouseInfofoodService()
        {
            fieldSql=@"
                t.F_HouseID,
                t.F_BBIId,
                t.F_UnitCode,
                t.F_AssetsNumber,
                t.F_HouseCode,
                t.F_HouseName,
                t.F_UnitNumber,
                t.F_FloorNumber,
                t.F_RoomNumber,
                t.F_UseCategories,
                t.F_RoomUsage,
                t.F_BuildingAddress,
                t.F_ProofUnit,
                t.F_CertificateNo,
                t.F_ProofDate,
                t.F_PropertyOwner,
                t.F_PropertyOwnerPhone,
                t.F_PropertyOwnerCertificateType,
                t.F_PropertyOwnerCerfificateNo,
                t.F_PurchaseDate,
                t.F_UseStatus,
                t.F_HouseArea,
                t.F_RentPurpose,
                t.F_RentAge,
                t.F_PictureAccessories,
                t.F_IfUse,
                t.F_Remarks,
                t.F_Fwzlbaz,
                t.F_RentCertificateNo,
                t.F_CreateDepartmentId,
                t.F_CreateDepartment,
                t.F_CreateUserid,
                t.F_CreateUser,
                t.F_CreateDatetime,
                t.F_LandCertificateNo,
                t.F_BuildingValue,
                t.F_LandArea,
                t.F_PowerOwner,
                t.F_Situation,
                t.F_Address,
                t.F_PoweNervous,
                t.F_UtilizeAge
            ";
        }
        #endregion

        #region 获取数据

        /// <summary>
        /// 获取列表数据
        /// <summary>
        /// <returns></returns>
        public IEnumerable<DC_ASSETS_HouseInfofoodEntity> GetList( string queryJson )
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
                strSql.Append(" FROM DC_ASSETS_HouseInfofood t ");
                return this.BaseRepository().FindList<DC_ASSETS_HouseInfofoodEntity>(strSql.ToString());
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
        public IEnumerable<DC_ASSETS_HouseInfofoodEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();

                strSql.Append(@"
                SELECT  top 50000 
                     l.f_transferor,
                      l.f_landname,
                         l.F_ParcelAddress,
                          l.F_Assignee,
                           l.F_LandCertificate,
								 l.F_Area,
                         l.F_LandUseRight,
								 l.F_LandUseNature,
								 l.F_TransferAmount,
                       t.F_HouseName,
                 t.F_CertificateNo,
                   t.F_BuildingAddress,
               c.F_ConstructionArea,
               t.F_UseCategories,
           t.F_BuildingValue,
 c.F_ConstructionFloorCount,
  t.F_FloorNumber,
 c.F_FormerUnitContacts,
								 c.F_ContactsPhone,
 t.F_Remarks,
              t.F_HouseID,
                t.F_AssetsNumber,
                t.F_BBIId,
                t.F_UnitCode,
                t.F_HouseCode,
             
                t.F_UnitNumber,
              
                t.F_RoomNumber,
               
                t.F_RoomUsage,
             
                t.F_ProofUnit,
                
                t.F_ProofDate,
                t.F_PropertyOwner,
                t.F_PropertyOwnerPhone,
                t.F_PropertyOwnerCertificateType,
                t.F_PropertyOwnerCerfificateNo,
                t.F_PurchaseDate,
                t.F_UseStatus,
                t.F_HouseArea,
                
                t.F_RentPurpose,
                t.F_RentAge,
                t.F_IfUse,
                t.F_PictureAccessories as F_PictureAccessories_HouseInfo,
                t.F_Fwzlbaz,
                t.F_RentCertificateNo,
               
               
                 l.F_LBIId,
								 
								
								
								
								
                                 l.F_CommunityCode,
                                 l.F_CenterpointCoordinates,
                                 l.F_ContractNumber,            
                                 l. F_ContractAccessories, 
                                 l.F_SalesConfirmation, 
                                 l.F_PictureAccessories,
                                l.F_NoteDescription,
                                 l.F_NoteAccessories,
                                 l.F_OtherAccessories 
								
															
								
									from DC_ASSETS_LandBaseInfofood l left join  DC_ASSETS_BuildingBaseInfofood c on l.F_LBIId =c.F_LBIId join 
								 DC_ASSETS_HouseInfofood t on  c.F_BBIId=t.F_BBIId 
								
								

                ");

                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["F_Assignee"].IsEmpty())
                {
                    dp.Add("F_Assignee", "%" + queryParam["F_Assignee"].ToString() + "%", DbType.String);
                    strSql.Append(" AND l.F_Assignee Like @F_Assignee ");
                }

                if (!queryParam["F_Transferor"].IsEmpty())
                {
                    dp.Add("F_Transferor", "%" + queryParam["F_Transferor"].ToString() + "%", DbType.String);
                    strSql.Append(" AND l.F_Transferor like @F_Transferor ");
                }
                if (!queryParam["F_HouseName"].IsEmpty())
                {
                    dp.Add("F_HouseName", "%" + queryParam["F_HouseName"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_HouseName Like @F_HouseName ");
                }

                if (!queryParam["F_LandName"].IsEmpty())
                {
                    dp.Add("F_LandName", "%" + queryParam["F_LandName"].ToString() + "%", DbType.String);
                    strSql.Append(" AND l.F_LandName Like @F_LandName ");
                }
                if (!queryParam["F_ParcelAddress"].IsEmpty())
                {
                    dp.Add("F_ParcelAddress", queryParam["F_ParcelAddress"].ToString(), DbType.String);
                    strSql.Append(" AND l.F_ParcelAddress = @F_ParcelAddress ");
                }
                if (!queryParam["F_LandCertificate"].IsEmpty())
                {
                    dp.Add("F_LandCertificate", "%" + queryParam["F_LandCertificate"].ToString() + "%", DbType.String);
                    strSql.Append(" AND F_LandCertificate Like @F_LandCertificate ");
                }
                if (!queryParam["F_CertificateNo"].IsEmpty())
                {
                    dp.Add("F_CertificateNo", "%" + queryParam["F_CertificateNo"].ToString() + "%", DbType.String);
                    strSql.Append(" AND F_CertificateNo Like @F_CertificateNo ");
                }

                if (!queryParam["F_BBIId"].IsEmpty())
                {
                    dp.Add("F_BBIId", queryParam["F_BBIId"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_BBIId = @F_BBIId ");
                }


                strSql.Append(" order by  F_Transferor,F_LandCertificate, t.F_HouseName");
                return this.BaseRepository().FindList<DC_ASSETS_HouseInfofoodEntity>(strSql.ToString(), dp, pagination);
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
        public DC_ASSETS_HouseInfofoodEntity GetEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_ASSETS_HouseInfofoodEntity>(keyValue);
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
        public void SaveTotalEntity(string keyValue, DC_ASSETS_LandBaseInfofoodEntity Landentity, DC_ASSETS_BuildingBaseInfofoodEntity Buildingentity, DC_ASSETS_HouseInfofoodEntity entity)
        {

            var db = this.BaseRepository().BeginTrans();
            try
            {
                if (!string.IsNullOrEmpty(keyValue))
                {

                    Landentity.Modify(Buildingentity.F_LBIId);
                    db.Update<DC_ASSETS_LandBaseInfofoodEntity>(Landentity);
                    if (!Buildingentity.F_BBIId.IsEmpty())
                    {
                        Buildingentity.Modify(Buildingentity.F_BBIId);
                        entity.Modify(keyValue);
                        db.Update<DC_ASSETS_BuildingBaseInfofoodEntity>(Buildingentity);
                        db.Update(entity);
                    }
                    else
                    {
                        Buildingentity.F_LBIId = keyValue;
                        Buildingentity.Create();
                        entity.F_BBIId = Buildingentity.F_BBIId;
                        entity.Create();
                        db.Insert(Buildingentity);
                        db.Insert(entity);

                    }

                }
                else
                {
                    if (!string.IsNullOrEmpty(Landentity.F_LBIId))
                    {
                        Landentity.Modify(Landentity.F_LBIId);
                        db.Update<DC_ASSETS_LandBaseInfofoodEntity>(Landentity);

                    }
                    else
                    {
                        Landentity.Create();
                        db.Insert(Landentity);
                    }

                    if (!string.IsNullOrEmpty(Buildingentity.F_BBIId))
                    {
                        Buildingentity.F_LBIId = Landentity.F_LBIId;
                        Buildingentity.Modify(Buildingentity.F_BBIId);
                        db.Update<DC_ASSETS_BuildingBaseInfofoodEntity>(Buildingentity);

                    }
                    else
                    {
                        Buildingentity.F_LBIId = Landentity.F_LBIId;
                        Buildingentity.Create();
                        db.Insert(Buildingentity);
                    }
                    entity.F_BBIId = Buildingentity.F_BBIId;
                    entity.Create();
                    db.Insert(entity);

                }
                db.Commit();
            }
            catch (Exception ex)
            {
                db.Rollback();
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
                this.BaseRepository().Delete<DC_ASSETS_HouseInfofoodEntity>(t=>t.F_HouseID == keyValue);
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
        public void SaveEntity(string keyValue, DC_ASSETS_HouseInfofoodEntity entity)
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

        #endregion

    }
}
