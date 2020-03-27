using Dapper;
using Learun.DataBase.Repository;
using Learun.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Learun.Application.TwoDevelopment.AssetManager
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-08-16 09:48
    /// 描 述：粮食土地房屋信息管理
    /// </summary>
    public class DC_ASSETS_LandBaseInfofoodService : RepositoryFactory
    {
        #region 构造函数和属性

        private string fieldSql;
        public DC_ASSETS_LandBaseInfofoodService()
        {
            fieldSql = @"
                t.F_LBIId,
                t.F_LandCertificate,
                t.F_LandNumber,
                t.F_AssetsNumber,
                t.F_Area,
                t.F_LandUseNature,
                t.F_LandUseRight,
                t.F_TransferAge,
                t.F_SellingPrice,
                t.F_TransferAmount,
                t.F_ParcelAddress,
                t.F_CenterpointCoordinates,
                t.F_BoundaryCoordinates,
                t.F_PictureAccessories,
                t.F_DeliveryDate,
                t.F_StartDate,
                t.F_StartLimit,
                t.F_CompletionDate,
                t.F_Transferor,
                t.F_Assignee,
                t.F_ContractNumber,
                t.F_ContractName,
                t.F_ContractAccessories,
                t.F_SalesConfirmation,
                t.F_NoteDescription,
                t.F_NoteAccessories,
                t.F_OtherAccessories,
                t.F_Remarks,
                t.F_CreateDepartmentId,
                t.F_CreateDepartment,
                t.F_CreateUserid,
                t.F_CreateUser,
                t.F_CreateDatetime,
                t.F_IfStockLand,
                t.F_CommunityCode,
                t.F_LandName
            ";
        }
        #endregion

        #region 获取数据

        /// <summary>
        /// 获取列表数据
        /// <summary>
        /// <returns></returns>
        public IEnumerable<DC_ASSETS_LandBaseInfofoodEntity> GetList(string queryJson)
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
                strSql.Append(" FROM DC_ASSETS_LandBaseInfofood t ");
                return this.BaseRepository().FindList<DC_ASSETS_LandBaseInfofoodEntity>(strSql.ToString());
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
 l.F_Remarks,
              isnull(t.F_HouseID,c.F_LBIId) F_HouseID,
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
								
														
																
								from DC_ASSETS_LandBaseInfofood l left join  DC_ASSETS_BuildingBaseInfofood c on l.F_LBIId =c.F_LBIId  left join 
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
        /// 获取列表分页数据
        /// <param name="pagination">分页参数</param>
        /// <summary>
        /// <returns></returns>
        public IEnumerable<DC_ASSETS_HouseInfofoodEntity> GetLandfoodInfo(string F_Transferor)
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
 l.F_Remarks,
              isnull(t.F_HouseID,c.F_LBIId) F_HouseID,
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
								
														
																
								from DC_ASSETS_LandBaseInfofood l left join  DC_ASSETS_BuildingBaseInfofood c on l.F_LBIId =c.F_LBIId  left join 
								 DC_ASSETS_HouseInfofood t on  c.F_BBIId=t.F_BBIId 
								
								

                ");

                strSql.Append("  WHERE 1=1 ");

                // 虚拟参数
                var dp = new DynamicParameters(new { });


                dp.Add("F_Transferor", F_Transferor, DbType.String);
                strSql.Append(" AND l.F_Transferor like @F_Transferor ");




                strSql.Append(" order by  F_Transferor,F_LandCertificate, t.F_HouseName");
                return this.BaseRepository().FindList<DC_ASSETS_HouseInfofoodEntity>(strSql.ToString(), dp);
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
        public DC_ASSETS_LandBaseInfofoodEntity GetEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_ASSETS_LandBaseInfofoodEntity>(keyValue);
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
                this.BaseRepository().Delete<DC_ASSETS_LandBaseInfofoodEntity>(t => t.F_LBIId == keyValue);
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
        /// 获取DC_ASSETS_LandBaseInfo表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_ASSETS_LandBaseInfofoodEntity GetDC_ASSETS_LandBaseInfofoodEntity(string landname, string ceticate)
        {
            try
            {
                var list = this.BaseRepository().FindEntity<DC_ASSETS_LandBaseInfofoodEntity>(i => i.F_LandCertificate == ceticate && i.F_LandName == landname);

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


        /// <summary>
        /// 保存实体数据（新增、修改）
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public void SaveEntity(string keyValue, DC_ASSETS_LandBaseInfofoodEntity entity)
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


        public bool ImportLandEntity(DataTable dtTable)
        {

            var db = this.BaseRepository().BeginTrans();

            Hashtable ht = new Hashtable();
            ht.Add("马家店", "420583001");
            ht.Add("安福寺", "420583101");
            ht.Add("白洋", "420583102");
            ht.Add("顾家店", "420583103");
            ht.Add("董市", "420583104");
            ht.Add("仙女", "420583105");
            ht.Add("问安", "420583106");
            ht.Add("七星台", "420583107");
            ht.Add("百里洲", "420583108");
            ht.Add("江口", "420583109");


            DC_ASSETS_LandBaseInfofoodEntity entity = null;
            DC_ASSETS_BuildingBaseInfofoodEntity buildingEntity = null;
            DC_ASSETS_HouseInfofoodEntity houseEntity = null;
            var departmentid = "23ac3ac1-097f-4007-8bd2-20fea87fe377";
            var userid = "d232107b-3b0a-44c2-992c-964e895f6af3";
            var landid = string.Empty;
            var buildid = string.Empty;
            var landname = string.Empty;
            var buildname = string.Empty;
            int f = 0;
            try
            {
                foreach (DataRow dt in dtTable.Rows)
                {
                    if (dt[0].ToString().Trim() == "序号") continue;
                    if (dt[2].ToString().Trim().IsEmpty()) continue;
                    if (f == 4)
                    {
                        string eee = string.Empty;
                    }
                    if (true)
                    {
                        landname = dt[2].ToString();
                        entity = new DC_ASSETS_LandBaseInfofoodEntity();
                        //原单位
                        entity.F_Transferor = dt[1].ToString();
                        ///土地证
                        //entity.F_LandCertificate = dt[5].ToString();

                        //土地名称
                        entity.F_LandName = dt[2].ToString();
                        //土地坐落
                        entity.F_ParcelAddress = dt[3].ToString();
                        //土地所有权
                        entity.F_Assignee = dt[4].ToString();
                        //权属证号
                        entity.F_LandCertificate = dt[5].ToString();
                        entity.F_CommunityCode = ht[dt[1].ToString()].ToString();
                        //使用权面积
                        if (!string.IsNullOrEmpty(dt[6].ToString().Trim()))
                        {
                            entity.F_Area = double.Parse(dt[6].ToString());
                        }
                        else
                        {
                            entity.F_Area = 0.0;
                        }

                        //账面价值 
                        if (!string.IsNullOrEmpty(dt[7].ToString().Trim()))
                        {
                            entity.F_TransferAmount = double.Parse(dt[7].ToString());
                        }
                        else
                        {
                            entity.F_TransferAmount = 0.0;
                        }

                        if (!string.IsNullOrEmpty(dt[8].ToString().Trim()))
                        {
                            entity.F_StartDate = DateTime.Parse(dt[8].ToString().Trim());
                        }

                        string temp = "1";
                        //使用权类型
                        if (dt[9].ToString().Trim() == "划拨")
                        {
                            temp = "2";
                        }
                        else if (dt[9].ToString().Trim() == "转让")
                        {
                            temp = "3";
                        }
                        entity.F_LandUseRight = temp;
                        //土地类用途
                        temp = "1";
                        if (dt[10].ToString().Trim() == "办公类")
                        {
                            temp = "2";
                        }
                        else if (dt[10].ToString().Trim() == "城镇住宅用地")
                        {
                            temp = "3";
                        }
                        else if (dt[10].ToString().Trim() == "工业用地")
                        {
                            temp = "4";
                        }
                        else if (dt[10].ToString().Trim() == "其他商服")
                        {
                            temp = "5";
                        }
                        entity.F_LandUseNature = temp;


                        entity.F_CreateDepartmentId = departmentid;
                        entity.F_CreateUserid = userid;

                        entity.F_Remarks = dt[11].ToString();
                        entity.Create();
                        db.Insert(entity);
                        landid = entity.F_LBIId;
                    }

                    //if (buildname != dt[10].ToString())
                    //{
                    //    buildingEntity = new DC_ASSETS_BuildingBaseInfofoodEntity();
                    //    buildname = dt[10].ToString();
                    //    buildingEntity.F_LBIId = landid;
                    //    buildingEntity.F_ConstructionName = buildname;
                    //    buildingEntity.F_Address = dt[12].ToString();

                    //    buildingEntity.F_CommunityCode = "420583102";
                    //    buildingEntity.F_FormerUnit = dt[1].ToString();
                    //    if (!string.IsNullOrEmpty(dt[15].ToString().Trim()))
                    //    {
                    //        buildingEntity.F_ConstructionFloorCount = int.Parse(dt[15].ToString());
                    //    }
                    //    if (!string.IsNullOrEmpty(dt[17].ToString().Trim()))
                    //    {
                    //        buildingEntity.F_ConstructionArea = double.Parse(dt[17].ToString());
                    //    }

                    //    buildingEntity.F_BuildingClass = "经营性";
                    //    //if (!dt[18].IsEmpty())
                    //    //{
                    //    //    if (dt[18].ToString() == "商业")
                    //    //    {
                    //    //        buildingEntity.F_BuildingClass = "经营性";
                    //    //    }
                    //    //    else
                    //    //    {
                    //    //        buildingEntity.F_BuildingClass = "非经营性";

                    //    //    }
                    //    //}

                    //    if (!string.IsNullOrEmpty(dt[18].ToString().Trim()))
                    //    {
                    //        buildingEntity.F_BuildingValue = double.Parse(dt[18].ToString());
                    //    }
                    //    buildingEntity.F_IfUse = 0;
                    //    buildingEntity.Create();
                    //    db.Insert(buildingEntity);
                    //    buildid = buildingEntity.F_BBIId;
                    //}

                    //houseEntity = new DC_ASSETS_HouseInfofoodEntity();
                    //houseEntity.F_BBIId = buildid;
                    //houseEntity.F_HouseName = dt[11].ToString();
                    ////  houseEntity.F_AssetsNumber = buildingEntity.F_ConstructionCode;

                    //houseEntity.F_UseCategories = "4";
                    //houseEntity.F_RoomUsage = "3";
                    //houseEntity.F_RentPurpose = "4";
                    //if (dt[14].ToString() != string.Empty)
                    //{
                    //    houseEntity.F_CertificateNo = dt[14].ToString();
                    //}
                    //if (!string.IsNullOrEmpty(dt[17].ToString().Trim()))
                    //{
                    //    houseEntity.F_HouseArea = double.Parse(dt[17].ToString());
                    //}

                    //if (!string.IsNullOrEmpty(dt[18].ToString().Trim()))
                    //{
                    //    houseEntity.F_BuildingValue = double.Parse(dt[18].ToString());
                    //}
                    //houseEntity.F_Remarks = dt[19].ToString();
                    //// houseEntity.F_BuildingValue = buildingEntity.F_BuildingValue;
                    //houseEntity.F_IfUse = "0";
                    //houseEntity.Create();
                    //db.Insert(houseEntity);
                    //f++;


                }
                db.Commit();
            }
            catch (Exception ex)
            {
                string temp = f.ToString();
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

            return true;


        }



        public DataTable GetLandfoodlist(string SearchValue)
        {

            try
            {
                var strSql = new StringBuilder();

                strSql.Append(@"
               SELECT F_Transferor from DC_ASSETS_LandBaseInfofood where 1=1  ");

                if (!string.IsNullOrEmpty(SearchValue))
                {
                    strSql.Append(string.Format(" And F_Transferor like '%{0}%'", SearchValue));

                }
                strSql.Append("GROUP BY F_Transferor");

                DataTable dt = this.BaseRepository().FindTable(strSql.ToString());

                return dt;
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
