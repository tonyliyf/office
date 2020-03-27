using Dapper;
using Learun.DataBase.Repository;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Learun.Application.TwoDevelopment.SystemDemo;
using System.IO;
using System.Collections;
using Learun.Application.Base.SystemModule;
using System.Text.RegularExpressions;

namespace Learun.Application.TwoDevelopment.AssetManager
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-02-13 17:40
    /// 描 述：DC_ASSETS_HouseInfo
    /// </summary>
    public class DC_ASSETS_HouseInfoService : RepositoryFactory
    {
        #region 获取数据

        private DC_ASSETS_BuildingBaseInfoService dC_ASSETS_BuildingBaseInfoIBLL = new DC_ASSETS_BuildingBaseInfoService();
        private DC_ASSETS_LandBaseInfoIBLL dC_ASSETS_LandBaseInfoIBLL = new DC_ASSETS_LandBaseInfoBLL();
        private AnnexesFileIBLL annxesFileibll = new AnnexesFileBLL();
        /// <summary>
        /// 获取树形数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetSqlTree(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindTable("select F_HouseID as id , 0 as pid , F_HouseName as name  from  DC_ASSETS_HouseInfo where F_BBIId='" + keyValue + "'");
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
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public DataTable ExportData(string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_HouseID,
                t.F_AssetsNumber,
                c.F_ConstructionName as F_BBIId,
                t.F_UnitCode,
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
                t.F_IfUse,
                t.F_PictureAccessories,
                t.F_Fwzlbaz,
                t.F_RentCertificateNo,
                t.F_Remarks,
                t.F_LandCertificateNo,
                t.F_BuildingValue
                ");
                strSql.Append("  FROM DC_ASSETS_HouseInfo t  left join DC_ASSETS_BuildingBaseInfo c on c.F_BBIId=t.F_BBIId");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["F_PropertyOwner"].IsEmpty())
                {
                    dp.Add("F_PropertyOwner", "%" + queryParam["F_PropertyOwner"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_PropertyOwner Like @F_PropertyOwner ");
                }
                if (!queryParam["F_HouseName"].IsEmpty())
                {
                    dp.Add("F_HouseName", "%" + queryParam["F_HouseName"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_HouseName Like @F_HouseName ");
                }
                if (!queryParam["F_BuildingAddress"].IsEmpty())
                {
                    dp.Add("F_BuildingAddress", queryParam["F_BuildingAddress"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_BuildingAddress = @F_BuildingAddress ");
                }


                if (!queryParam["F_BBIId"].IsEmpty())
                {
                    dp.Add("F_BBIId", queryParam["F_BBIId"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_BBIId = @F_BBIId ");
                }
                DataTable dt = this.BaseRepository().FindTable(strSql.ToString(), dp);
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("F_UseCategories", "HouseUsedBy");
                dic.Add("F_RoomUsage", "F_RoomUsage");
                dic.Add("F_PropertyOwnerCertificateType", "CertificateType");
                dic.Add("F_UseStatus", "YesOrNo");
                dic.Add("F_RentPurpose", "RentPurpose");
                dic.Add("F_IfUse", "YesOrNo");
                dic.Add("F_RentCertificateNo", "RentCertificateNo");
                DataConvertSerivers sevices = new DataConvertSerivers();
                sevices.ConvertDataByDataItem(dt, dic);
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



        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public DataTable ExportLandHouseData(string queryJson)
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
           c.F_BuildingValue,
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
								
								
								
								
								FROM DC_ASSETS_HouseInfo t  inner join DC_ASSETS_BuildingBaseInfo c on c.F_BBIId=t.F_BBIId inner join DC_ASSETS_LandBaseInfo l on l.F_LBIId =c.F_LBIId
								

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
                if (!queryParam["F_ParcelAddress"].IsEmpty())
                {
                    dp.Add("F_ParcelAddress", queryParam["F_ParcelAddress"].ToString(), DbType.String);
                    strSql.Append(" AND l.F_ParcelAddress = @F_ParcelAddress ");
                }
                if (!queryParam["F_LandCertificate"].IsEmpty())
                {
                    dp.Add("F_LandCertificate", "%" + queryParam["F_LandCertificate"].ToString() + "%", DbType.String);
                    strSql.Append(" AND F_LandCertificate Like @F_HouseName ");
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
                DataTable dt = this.BaseRepository().FindTable(strSql.ToString(), dp);
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("F_UseCategories", "HouseUsedBy");
                dic.Add("F_RoomUsage", "F_RoomUsage");
                dic.Add("F_PropertyOwnerCertificateType", "CertificateType");
                dic.Add("F_UseStatus", "YesOrNo");
                dic.Add("F_LandUseRight", "LandUseRight");
                dic.Add("F_LandUseNature", "LandUseBy");
                dic.Add("F_RentPurpose", "RentPurpose");
                dic.Add("F_IfUse", "YesOrNo");
                //   dic.Add("F_RentCertificateNo", "RentCertificateNo");
                DataConvertSerivers sevices = new DataConvertSerivers();
                sevices.ConvertDataByDataItem(dt, dic);
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





        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public DataTable ExportHouseData(string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();

                strSql.Append(@"
               SELECT  top 50000 
                c.F_Oldunit,
                c.F_ConstructionName,
                 t.F_HouseName,
                  c.F_Address,
                   t.F_FormerUnit,
                   t.F_CertificateNo,
                   c.F_ConstructionFloorCount,
                    t.F_FloorNumber,
                    t.F_HouseArea,
                    t.F_BuildingValue,
                     c.F_BuildingClass,
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
                t.F_UseCategories,
                t.F_RoomUsage,
              
                t.F_ProofUnit,
               
                t.F_ProofDate,
                t.F_PropertyOwner,
                t.F_PropertyOwnerPhone,
                t.F_PropertyOwnerCertificateType,
                t.F_PropertyOwnerCerfificateNo,
                t.F_PurchaseDate,
                t.F_UseStatus,
               
               
                t.F_RentPurpose,
                t.F_RentAge,
                t.F_IfUse,
                t.F_PictureAccessories as F_PictureAccessories_HouseInfo,
                t.F_Fwzlbaz,
                t.F_RentCertificateNo,
              
								 
								
								 c.F_UsageArea,
								 c.F_ConstructionArea,
							
							
								 
                                 
                                 c.F_CenterpointCoordinates
													
								FROM DC_ASSETS_HouseInfo t  inner join DC_ASSETS_BuildingBaseInfo c on c.F_BBIId=t.F_BBIId 
								

                ");

                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["F_FormerUnit"].IsEmpty())
                {
                    dp.Add("F_FormerUnit", "%" + queryParam["F_FormerUnit"].ToString() + "%", DbType.String);
                    strSql.Append(" AND c.F_FormerUnit Like @F_FormerUnit ");
                }

                if (!queryParam["F_Oldunit"].IsEmpty())
                {
                    dp.Add("F_Oldunit", "%" + queryParam["F_Oldunit"].ToString() + "%", DbType.String);
                    strSql.Append(" AND c.F_Oldunit like @F_Oldunit ");
                }
                if (!queryParam["F_HouseName"].IsEmpty())
                {
                    dp.Add("F_HouseName", "%" + queryParam["F_HouseName"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_HouseName Like @F_HouseName ");
                }
                if (!queryParam["F_Address"].IsEmpty())
                {
                    dp.Add("F_Address", queryParam["F_Address"].ToString(), DbType.String);
                    strSql.Append(" AND c.F_Address = @F_Address ");
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
                strSql.Append(" And (select count(*) from DC_ASSETS_LandBaseInfo g where c.F_LBIId = g.F_LBIId)= 0");
                strSql.Append(" order by  F_Oldunit,F_CertificateNo,t.F_HouseName");
                DataTable dt = this.BaseRepository().FindTable(strSql.ToString(), dp);
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("F_UseCategories", "HouseUsedBy");
                dic.Add("F_RoomUsage", "F_RoomUsage");
                dic.Add("F_PropertyOwnerCertificateType", "CertificateType");
                dic.Add("F_UseStatus", "YesOrNo");
                dic.Add("F_RentPurpose", "RentPurpose");
                dic.Add("F_BuildingClass", "BuildingClass");
                dic.Add("F_IfUse", "YesOrNo");
                //   dic.Add("F_RentCertificateNo", "RentCertificateNo");
                DataConvertSerivers sevices = new DataConvertSerivers();
                sevices.ConvertDataByDataItem(dt, dic);
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



        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public DataTable GetboardsInfo()
        {
            try
            {
                var strSql = new StringBuilder();

                strSql.Append(@"
                               SELECT  F_Assignee,count(*) as number 
                FROM
                	(
                SELECT
                	h.F_HouseID, 
                 F_Assignee

                FROM
                	dc_assets_landbaseinfo l


                LEFT JOIN DC_ASSETS_BuildingBaseInfo b ON l.F_LBIId = b.F_LBIId
                	JOIN DC_ASSETS_HouseInfo h ON b.F_BBIId = 

                h.F_BBIId UNION
                SELECT
                	h.F_HouseID,
                	h.F_FormerUnit as F_Assignee

                FROM
                	DC_ASSETS_BuildingBaseInfo b
                	JOIN 

                DC_ASSETS_HouseInfo h ON b.F_BBIId = h.F_BBIId 
                WHERE
                	b.F_LBIId IS NULL 
                	) b  group by F_Assignee


                                ");

                return this.BaseRepository().FindTable(strSql.ToString());


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
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public DataTable GetHouseAssigneeListt(string F_FormerUnit, string SearchValue)
        {
            try
            {
                var strSql = new StringBuilder();

                strSql.Append(@"
          		SELECT  * 
FROM
 (
SELECT

 l.F_Transferor  as F_Oldunit ,
 l.F_Assignee as F_FormerUnit
 
FROM
 dc_assets_landbaseinfo l
 

LEFT JOIN DC_ASSETS_BuildingBaseInfo b ON l.F_LBIId = b.F_LBIId
 JOIN DC_ASSETS_HouseInfo h ON b.F_BBIId = h.F_BBIId 
 UNION
SELECT

 b.F_OldUnit,
  h.F_FormerUnit

FROM
 DC_ASSETS_BuildingBaseInfo b
 JOIN 

DC_ASSETS_HouseInfo h ON b.F_BBIId = h.F_BBIId 
WHERE
 b.F_LBIId IS NULL 
 ) b where F_FormerUnit='" + F_FormerUnit + "' ");
                if (!string.IsNullOrEmpty(SearchValue))
                {

                    strSql.Append(string.Format(" And F_OldUnit like '%{0}%'", SearchValue));

                }

                strSql.Append(" GROUP BY F_Oldunit,F_FormerUnit ");

               
                return this.BaseRepository().FindTable(strSql.ToString());


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
        /// 查询上半年1到6月的数据或者模糊查询
        /// </summary>
        /// <param name="State"></param>
        /// <returns></returns>
        public DataTable GetHouseAssigneeDetail(string State, string SearchValue)
        {
            try
            {
                var strSql = new StringBuilder();

                //查询上半年1到6月招租成功的数据
                //F_LeaseState（1，待租，2，已租，3失败）
                if (State == "1")
                {
                    strSql.Append(@"SELECT
	d.F_HouseFloorCount,
	d.F_Oldunit,
	d.F_Address,
	d.F_BuildingClass,
	d.F_FormerUnitContacts,
	d.F_ContactsPhone,
	d.F_HouseName,
	d.F_FloorNumber,
	d.F_CertificateNo,
	d.F_BuildingValue,
	d.F_HouseArea,
	d.F_Remarks 
FROM
	DC_ASSETS_HouseRentMain m
	LEFT JOIN DC_ASSETS_HouseRentDetail l ON m.F_HRMId = l.F_HRMId
	LEFT JOIN DC_ASSETS_HouseInfo d ON l.F_HouseID = d.F_HouseID 
WHERE
	l.F_LeaseState = '2' 
	AND datepart ( yyyy, m.F_RentTime ) = datepart ( yyyy, GETDATE ( ) ) 
	AND datepart ( mm, m.F_RentTime ) BETWEEN 1 
	AND 6 	AND (d.F_Oldunit like '%" + SearchValue + "%' or F_Address like '%" + SearchValue + "%' or F_HouseName like '%" + SearchValue + "%')");

                }
                else
                {
                    //查询上半年1到6月招租成功不成功的数据
                    strSql.Append(@"SELECT
	d.F_HouseFloorCount,
	d.F_Oldunit,
	d.F_Address,
	d.F_BuildingClass,
	d.F_FormerUnitContacts,
	d.F_ContactsPhone,
	d.F_HouseName,
	d.F_FloorNumber,
	d.F_CertificateNo,
	d.F_BuildingValue,
	d.F_HouseArea,
	d.F_Remarks 
FROM
	DC_ASSETS_HouseRentMain m
	LEFT JOIN DC_ASSETS_HouseRentDetail l ON m.F_HRMId = l.F_HRMId
	LEFT JOIN DC_ASSETS_HouseInfo d ON l.F_HouseID = d.F_HouseID 
WHERE
	l.F_LeaseState != '2' 
	AND datepart ( yyyy, m.F_RentTime ) = datepart ( yyyy, GETDATE ( ) ) 
	AND datepart ( mm, m.F_RentTime ) BETWEEN 1 
	AND 6 AND (d.F_Oldunit like '%" + SearchValue + "%' or F_Address like '%" + SearchValue + "%' or F_HouseName like '%" + SearchValue + "%')");



                }
                return this.BaseRepository().FindTable(strSql.ToString());


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
        public DataTable GetHouseAssigneeSearch(string F_FormerUnit, string SearchValue)
        {
            try
            {
                var strSql = new StringBuilder();

                if (string.IsNullOrEmpty(SearchValue))
                {
                    strSql.Append(string.Format(@"SELECT
	* 
FROM
	(
SELECT
	l.F_Transferor AS F_Oldunit,
	h.F_Address,
	h.F_BuildingClass,
	h.F_FormerUnitContacts,
	h.F_ContactsPhone,
	h.F_HouseName,
	h.F_FloorNumber,
	h.F_CertificateNo,
	h.F_BuildingValue,
	h.F_HouseArea,
	h.F_Remarks,
    h.F_PictureAccessories,
    l.F_CenterpointCoordinates
FROM
	dc_assets_landbaseinfo l
	LEFT JOIN DC_ASSETS_BuildingBaseInfo b ON l.F_LBIId = b.F_LBIId
	JOIN DC_ASSETS_HouseInfo h ON b.F_BBIId = h.F_BBIId WHERE l.F_Transferor = '{0}'
  UNION    
  SELECT    
  b.F_OldUnit,   
   h.F_Address,   
  h.F_BuildingClass,   
  h.F_FormerUnitContacts,   
  h.F_ContactsPhone,   
   
  h.F_HouseName,   
  h.F_FloorNumber,   
  h.F_CertificateNo,   
  h.F_BuildingValue,   
  h.F_HouseArea,   
  h.F_Remarks, 
h.F_PictureAccessories,
 b.F_CenterpointCoordinates
  FROM DC_ASSETS_BuildingBaseInfo b    
  JOIN DC_ASSETS_HouseInfo h ON b.F_BBIId = h.F_BBIId WHERE b.F_LBIId IS NULL AND h.F_OldUnit ='{0}') b", F_FormerUnit));
                }
                else
                {

                    strSql.Append(string.Format(@"SELECT
	* 
FROM
	(
SELECT
	l.F_Transferor AS F_Oldunit,
	h.F_Address,
	h.F_BuildingClass,
	h.F_FormerUnitContacts,
	h.F_ContactsPhone,
	h.F_HouseName,
	h.F_FloorNumber,
	h.F_CertificateNo,
	h.F_BuildingValue,
	h.F_HouseArea,
	h.F_Remarks,
    h.F_PictureAccessories
FROM
	dc_assets_landbaseinfo l
	LEFT JOIN DC_ASSETS_BuildingBaseInfo b ON l.F_LBIId = b.F_LBIId
	JOIN DC_ASSETS_HouseInfo h ON b.F_BBIId = h.F_BBIId WHERE l.F_Transferor ='{0}' AND ( l.F_Transferor LIKE '%{1}%' OR h.F_HouseName LIKE '%{1}%' OR h.F_Address LIKE '%{1}%') UNION    
  SELECT    
  b.F_OldUnit,   
   h.F_Address,   
  h.F_BuildingClass,   
  h.F_FormerUnitContacts,   
  h.F_ContactsPhone,   

  h.F_HouseName,   
  h.F_FloorNumber,   
  h.F_CertificateNo,   
  h.F_BuildingValue,   
  h.F_HouseArea,   
  h.F_Remarks,
  h.F_PictureAccessories   
  FROM DC_ASSETS_BuildingBaseInfo b    
  JOIN DC_ASSETS_HouseInfo h ON b.F_BBIId = h.F_BBIId WHERE b.F_LBIId IS NULL AND h.F_Oldunit ='{0}' AND ( b.F_Oldunit LIKE '%{1}%' OR h.F_HouseName LIKE '%{1}%' OR h.F_Address LIKE '%{1}%') ) b", F_FormerUnit, SearchValue));

                }

                SimpleLogUtil.WriteTextLog("houseinfo", strSql.ToString(), DateTime.Now);
                return this.BaseRepository().FindTable(strSql.ToString());


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
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_ASSETS_HouseInfoEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT  top 50000   ");
                strSql.Append(@"
                t.F_HouseID,
                t.F_AssetsNumber,
                t.F_BBIId,
                t.F_UnitCode,
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
                t.F_IfUse,
                t.F_PictureAccessories,
                t.F_Fwzlbaz,
                t.F_RentCertificateNo,
                t.F_Remarks,
                t.F_LandCertificateNo,
                t.F_BuildingValue,
                t.F_LandArea,
                c.F_Oldunit

                ");
                strSql.Append("  FROM DC_ASSETS_HouseInfo t  left join DC_ASSETS_BuildingBaseInfo c on c.F_BBIId=t.F_BBIId");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["F_PropertyOwner"].IsEmpty())
                {
                    dp.Add("F_PropertyOwner", "%" + queryParam["F_PropertyOwner"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_PropertyOwner Like @F_PropertyOwner ");
                }
                if (!queryParam["F_HouseName"].IsEmpty())
                {
                    dp.Add("F_HouseName", "%" + queryParam["F_HouseName"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_HouseName Like @F_HouseName ");
                }
                if (!queryParam["F_BuildingAddress"].IsEmpty())
                {
                    dp.Add("F_BuildingAddress", queryParam["F_BuildingAddress"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_BuildingAddress = @F_BuildingAddress ");
                }

                if (!queryParam["F_Oldunit"].IsEmpty())
                {
                    dp.Add("F_Oldunit", "%" + queryParam["F_Oldunit"].ToString() + "%", DbType.String);
                    strSql.Append(" AND c.F_Oldunit like @F_Oldunit ");
                }
                if (!queryParam["F_BBIId"].IsEmpty())
                {
                    dp.Add("F_BBIId", queryParam["F_BBIId"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_BBIId = @F_BBIId ");
                }
                strSql.Append(" order by c.F_Oldunit, t.f_bbiid,t.F_HouseName");
                return this.BaseRepository().FindList<DC_ASSETS_HouseInfoEntity>(strSql.ToString(), dp, pagination);
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
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_ASSETS_HouseInfoEntity> GetTotalPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();

                strSql.Append(@"
                SELECT  top 500000 
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
 t.F_FormerUnitContacts,
								 t.F_ContactsPhone,t.F_BuildingClass,
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
                t.F_HouseFloorCount,
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
								
								
								
								
								FROM DC_ASSETS_HouseInfo t  inner join DC_ASSETS_BuildingBaseInfo c on c.F_BBIId=t.F_BBIId inner join DC_ASSETS_LandBaseInfo l on l.F_LBIId =c.F_LBIId
								

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


                if (!queryParam["F_BuildingClass"].IsEmpty())
                {
                    dp.Add("BuildingClass", queryParam["F_BuildingClass"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_BuildingClass = @BuildingClass ");
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


                strSql.Append(" order by  l.F_Transferor,F_LandCertificate, t.F_HouseName");
                return this.BaseRepository().FindList<DC_ASSETS_HouseInfoEntity>(strSql.ToString(), dp, pagination);
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
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<HouseRentInfo> GetHouseRentInfoPageList(string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();

                strSql.Append(@"
                
                   
                select  top 500000 *  from (SELECT   h.F_HouseID, l.F_Transferor,b.F_ConstructionName,h.F_HouseName,isnull(l.F_ParcelAddress,b.F_Address)F_Address,b.F_ConstructionArea  FROM  dc_assets_landbaseinfo l left join  DC_ASSETS_BuildingBaseInfo b 
on l.F_LBIId =b.F_LBIId join DC_ASSETS_HouseInfo h on b.F_BBIId =h.F_BBIId
union 
select  h.F_HouseID, b.F_OldUnit as F_Transferor, b.F_ConstructionName,h.F_HouseName,h.F_Address,b.F_ConstructionArea from  DC_ASSETS_BuildingBaseInfo b  join  DC_ASSETS_HouseInfo h on b.F_BBIId =h.F_BBIId where b.F_LBIId is null) b
      
								

                ");

                strSql.Append("  WHERE 1=1 ");
                // var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!string.IsNullOrEmpty(queryJson))
                {
                    dp.Add("F_Transferor", "%" + queryJson + "%", DbType.String);

                    strSql.Append(@" AND (F_Transferor like @F_Transferor or  F_ConstructionName
                         Like @F_Transferor or F_Address = @F_Transferor or F_HouseName = @F_Transferor)");

                }


                //if (!queryParam["F_Transferor"].IsEmpty())
                //{
                //    dp.Add("F_Transferor", "%" + queryParam["F_Transferor"].ToString() + "%", DbType.String);
                //    strSql.Append(" AND F_Transferor like @F_Transferor ");
                //}
                //if (!queryParam["F_ConstructionName"].IsEmpty())
                //{
                //    dp.Add("F_ConstructionName", "%" + queryParam["F_ConstructionName"].ToString() + "%", DbType.String);
                //    strSql.Append(" AND F_ConstructionName Like @F_ConstructionName ");
                //}
                //if (!queryParam["F_Address"].IsEmpty())
                //{
                //    dp.Add("F_ParcelAddress", queryParam["F_Address"].ToString(), DbType.String);
                //    strSql.Append(" AND F_Address = @F_Address ");
                //}



                strSql.Append(" order by F_Transferor,F_ConstructionName,F_HouseName");
                return this.BaseRepository().FindList<HouseRentInfo>(strSql.ToString(), dp);
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
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_ASSETS_HouseInfoEntity> GetTotalNoLandPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();

                strSql.Append(@"
                SELECT  top 50000 
                t.F_Oldunit,
                c.F_ConstructionName,
                 t.F_HouseName,
                  t.F_Address,
                   t.F_FormerUnit,
                   t.F_CertificateNo,
                   c.F_ConstructionFloorCount,
                    t.F_FloorNumber,
                    t.F_HouseArea,
                    t.F_BuildingValue,
                     t.F_BuildingClass,
                  t.F_FormerUnitContacts,
								 t.F_ContactsPhone,
                 t.F_Remarks,

                 
                 
                
               t.F_HouseID,
                t.F_AssetsNumber,
                t.F_BBIId,
                t.F_UnitCode,
                t.F_HouseCode,
                
                t.F_UnitNumber,
               
                t.F_RoomNumber,
                t.F_UseCategories,
                t.F_RoomUsage,
              
                t.F_ProofUnit,
               
                t.F_ProofDate,
                t.F_PropertyOwner,
                t.F_PropertyOwnerPhone,
                t.F_PropertyOwnerCertificateType,
                t.F_PropertyOwnerCerfificateNo,
                t.F_PurchaseDate,
                t.F_UseStatus,
                t.F_HouseFloorCount,
               
                t.F_RentPurpose,
                t.F_RentAge,
                t.F_IfUse,
                t.F_PictureAccessories ,
                t.F_Fwzlbaz,
                t.F_RentCertificateNo,
              
								 
								
								 c.F_UsageArea,
								 c.F_ConstructionArea,
							
							
								 
                                 
                                 c.F_CenterpointCoordinates
													
								FROM DC_ASSETS_HouseInfo t  inner join DC_ASSETS_BuildingBaseInfo c on c.F_BBIId=t.F_BBIId 
								

                ");

                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["F_FormerUnit"].IsEmpty())
                {
                    dp.Add("F_FormerUnit", "%" + queryParam["F_FormerUnit"].ToString() + "%", DbType.String);
                    strSql.Append(" AND c.F_FormerUnit Like @F_FormerUnit ");
                }

                if (!queryParam["F_Oldunit"].IsEmpty())
                {
                    dp.Add("F_Oldunit", "%" + queryParam["F_Oldunit"].ToString() + "%", DbType.String);
                    strSql.Append(" AND c.F_Oldunit like @F_Oldunit ");
                }

                if (!queryParam["F_BuildingClass"].IsEmpty())
                {
                    dp.Add("BuildingClass", queryParam["F_BuildingClass"].ToString(), DbType.String);
                    strSql.Append(" AND  t.F_BuildingClass = @BuildingClass ");
                }
                if (!queryParam["F_HouseName"].IsEmpty())
                {
                    dp.Add("F_HouseName", "%" + queryParam["F_HouseName"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_HouseName Like @F_HouseName ");
                }
                if (!queryParam["F_Address"].IsEmpty())
                {
                    dp.Add("F_Address", queryParam["F_Address"].ToString(), DbType.String);
                    strSql.Append(" AND c.F_Address = @F_Address ");
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
                strSql.Append(" And ( c.F_LBIId ='' or c.F_LBIId is null )");
                strSql.Append(" order by  t.F_Oldunit,F_CertificateNo,t.F_HouseName");
                return this.BaseRepository().FindList<DC_ASSETS_HouseInfoEntity>(strSql.ToString(), dp, pagination);
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
        /// 获取DC_ASSETS_HouseInfo表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_ASSETS_HouseInfoEntity GetDC_ASSETS_HouseInfoEntity(string keyValue)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_HouseID,
                t.F_AssetsNumber,
                t.F_BBIId,
                t.F_UnitCode,
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
                t.F_IfUse,
                t.F_PictureAccessories,
                t.F_Fwzlbaz,
                t.F_RentCertificateNo,
                t.F_Remarks,
                t.F_LandCertificateNo,
                t.F_BuildingValue

                ");
                strSql.Append("  FROM DC_ASSETS_HouseInfo t  ");
                strSql.Append("  WHERE t.F_HouseID='" + keyValue + "'");

                IEnumerable<DC_ASSETS_HouseInfoEntity> num = this.BaseRepository().FindList<DC_ASSETS_HouseInfoEntity>(strSql.ToString());
                DC_ASSETS_HouseInfoEntity num1 = null;
                foreach (DC_ASSETS_HouseInfoEntity obj in num)
                {
                    num1 = this.BaseRepository().FindEntity<DC_ASSETS_HouseInfoEntity>(obj.F_HouseID);
                }

                return num1;
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
        /// 获取DC_ASSETS_HouseInfo表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_ASSETS_HouseInfoEntity GetDC_ASSETS_HouseInfoByAddress(string address, string unit)
        {
            try
            {
                var strSql = new StringBuilder();

                strSql.Append(@"
                   select * from  ( SELECT  t.* ,l.F_ParcelAddress as address
											
								
								FROM DC_ASSETS_HouseInfo t  inner join DC_ASSETS_BuildingBaseInfo c on c.F_BBIId=t.F_BBIId inner join DC_ASSETS_LandBaseInfo l on l.F_LBIId =c.F_LBIId
								
								union all
								
								 SELECT  
								   t.*,
                 t.F_Address as address
                
													
								FROM DC_ASSETS_HouseInfo t  inner join DC_ASSETS_BuildingBaseInfo c on c.F_BBIId=t.F_BBIId ) b

                ");

                strSql.Append("  WHERE address='" + address + "'");

                IEnumerable<DC_ASSETS_HouseInfoEntity> num = this.BaseRepository().FindList<DC_ASSETS_HouseInfoEntity>(strSql.ToString());
                //  DC_ASSETS_HouseInfoEntity num1 = null;
                foreach (DC_ASSETS_HouseInfoEntity obj in num)
                {
                    return obj;
                }
                return null;

                // return num1;
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
        /// 获取DC_ASSETS_HouseInfo表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_ASSETS_HouseInfoEntity GetDC_ASSETS_HouseInfo(string keyValue)
        {
            try
            {

                return this.BaseRepository().FindEntity<DC_ASSETS_HouseInfoEntity>(keyValue);
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
        /// 获取DC_ASSETS_HouseInfo表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public string GetOldUnitByHouseId(string keyValue)
        {
            try
            {

                DC_ASSETS_HouseInfoEntity entity = this.BaseRepository().FindEntity<DC_ASSETS_HouseInfoEntity>(keyValue);
                DC_ASSETS_BuildingBaseInfoEntity building = this.BaseRepository().FindEntity<DC_ASSETS_BuildingBaseInfoEntity>(entity.F_BBIId);
                if (string.IsNullOrEmpty(building.F_LBIId))
                {

                    return building.F_Oldunit;
                }
                else
                {

                    DC_ASSETS_LandBaseInfoEntity landinfo = this.BaseRepository().FindEntity<DC_ASSETS_LandBaseInfoEntity>(building.F_LBIId);

                    return landinfo.F_Transferor;
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
        /// 获取DC_ASSETS_HouseInfo表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public string GetOwnerByHouseId(string keyValue)
        {
            try
            {

                DC_ASSETS_HouseInfoEntity entity = this.BaseRepository().FindEntity<DC_ASSETS_HouseInfoEntity>(keyValue);
                DC_ASSETS_BuildingBaseInfoEntity building = this.BaseRepository().FindEntity<DC_ASSETS_BuildingBaseInfoEntity>(entity.F_BBIId);
                if (string.IsNullOrEmpty(building.F_LBIId))
                {

                    return entity.F_FormerUnit;
                }
                else
                {

                    DC_ASSETS_LandBaseInfoEntity landinfo = this.BaseRepository().FindEntity<DC_ASSETS_LandBaseInfoEntity>(building.F_LBIId);

                    return landinfo.F_Assignee;
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
        /// 获取DC_ASSETS_HouseInfo表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_ASSETS_HouseInfoEntity GetHouseInfoLandbase(string keyValue)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_HouseID,
                t.F_AssetsNumber,
                t.F_BBIId,
                t.F_UnitCode,
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
                t.F_IfUse,
                t.F_PictureAccessories as F_PictureAccessories_HouseInfo,
                t.F_Fwzlbaz,
                t.F_RentCertificateNo,
                t.F_Remarks,
                t.F_LandCertificateNo,
                t.F_BuildingValue

                ");
                strSql.Append("  FROM DC_ASSETS_HouseInfo t  ");
                strSql.Append("  WHERE t.F_BBIId='" + keyValue + "'");

                IEnumerable<DC_ASSETS_HouseInfoEntity> num = this.BaseRepository().FindList<DC_ASSETS_HouseInfoEntity>(strSql.ToString());
                DC_ASSETS_HouseInfoEntity num1 = null;
                foreach (DC_ASSETS_HouseInfoEntity obj in num)
                {
                    num1 = this.BaseRepository().FindEntity<DC_ASSETS_HouseInfoEntity>(obj.F_HouseID);
                }

                return num1;
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
                this.BaseRepository().Delete<DC_ASSETS_HouseRentDetailEntity>(t => t.F_HouseID == keyValue);
                this.BaseRepository().Delete<DC_ASSETS_HouseInfoEntity>(t => t.F_HouseID == keyValue);
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

        public long GetFileSize(string sFullName)
        {
            long lSize = 0;
            if (File.Exists(sFullName))
                lSize = new FileInfo(sFullName).Length;
            return lSize;
        }


        //public bool ImportCertiate(string FileDirectory, ref string Msg)
        //{
        //    var db = this.BaseRepository().BeginTrans();

        //    try
        //    {
        //        var HouseInfolist = db.FindList<DC_ASSETS_HouseInfoEntity>();
        //        string[] fileNames = DirFileHelper.GetDirectories(FileDirectory);
        //        bool bCheck = true;
        //        Hashtable ht = new Hashtable();

        //        string[] sources = DirFileHelper.GetDirectories(fileNames[0]);
        //        for (int i = 0; i < sources.Length; i++)
        //        {
        //            DirectoryInfo info = new DirectoryInfo(sources[i]);
        //            String path = info.Parent.Parent.FullName;
        //            // str1 = Regex.Replace(str2, @"\D+", "");
        //            string name = Regex.Replace(info.Name, @"\D+", ""); //获取当前路径最后一级文件夹名称
        //            var Entity = db.FindEntity<DC_ASSETS_HouseInfoEntity>(p => p.F_CertificateNo.Contains(name));
        //            //var Entity = db.FindEntity<DC_ASSETS_HouseInfoEntity>(p =>name.Contains(p.F_CertificateNo));

        //            if (Entity == null)
        //            {
        //                Msg += name;
        //                Msg += ",";
        //                bCheck = false;
        //            }
        //            if (bCheck)
        //            {
        //                ht.Add(name, Entity.F_HouseID);

        //            }
        //            //1.获取文件夹名称 
        //            //文件夹名称为房产证数字，获取房产数据的id,如果没有查到，表明没有查到此
        //            //房产证的数据，然后记录下来，保存到Msg,查到了，用hashtable 保存 键房产证号，值房子id

        //        }
        //        if (!bCheck)
        //        {
        //            Msg += "依据上述房产证号，没有查到房产信息，请核实，再导入！导入失败！";
        //            DirFileHelper.ClearDirectory(FileDirectory);

        //            return false;
        //        }
        //        //如果 Msg不为空，直接返回此号码，表明没有查到数据，不导入，返回false
        //        //如果房产证都找到了，构造附件实体类，按附件格式要求，
        //        //将房产信息移动相应目录下
        //        //然后保存实体类
        //        //然后删除临时文件夹

        //        for (int i = 0; i < sources.Length; i++)
        //        {
        //            DirectoryInfo info = new DirectoryInfo(sources[i]);
        //            String path = info.Parent.Parent.FullName;
        //            string name = info.Name;
        //            string fileGuid = Guid.NewGuid().ToString();
        //            UserInfo user = LoginUserInfo.Get();

        //            // / 获取文件完整文件名(包含绝对路径)
        //            //文件存放路径格式：/Resource/ResourceFile/{userId}/{date}/{guid}.{后缀名}
        //            string filePath = Config.GetValue("AnnexesFile");
        //            string uploadDate = DateTime.Now.ToString("yyyyMMdd");
        //            //string FileEextension = Path.GetExtension(fileName);
        //            // string virtualPath = string.Format("{0}/{1}/{2}/{3}{4}", filePath, user.userId, uploadDate, fileGuid, FileEextension);
        //            string FloderPath = string.Format("{0}/{1}/{2}/", filePath, user.userId, uploadDate);
        //            //创建文件夹
        //            // string path = Path.GetDirectoryName(virtualPath);
        //            //Directory.CreateDirectory(path);
        //            AnnexesFileEntity fileAnnexesEntity = new AnnexesFileEntity();

        //            //创建文件夹
        //            if (!Directory.Exists(FloderPath))
        //            {
        //                Directory.CreateDirectory(FloderPath);
        //            }

        //            string HouseId = ht[name].ToString();
        //            DC_ASSETS_HouseInfoEntity entity = db.FindEntity<DC_ASSETS_HouseInfoEntity>(HouseId);
        //            if (!string.IsNullOrEmpty(entity.F_PictureAccessories))
        //            {

        //                fileGuid = entity.F_PictureAccessories;
        //            }

        //            string[] filenames = Directory.GetFiles(sources[i]);
        //            for (int j = 0; j < filenames.Length; j++)
        //            {
        //                long size = GetFileSize(filenames[j]);
        //                string filename = Path.GetFileName(filenames[j]);//文件名  “Default.aspx”
        //                string extension = Path.GetExtension(filenames[j]);//扩展名 “.aspx”
        //                fileAnnexesEntity = new AnnexesFileEntity();
        //                fileAnnexesEntity.F_Id = Guid.NewGuid().ToString();
        //                fileAnnexesEntity.F_FileName = filename;
        //                fileAnnexesEntity.F_CreateDate = DateTime.Now;
        //                fileAnnexesEntity.F_FileExtensions = extension;
        //                fileAnnexesEntity.F_FolderId = fileGuid;
        //                fileAnnexesEntity.F_FileSize = size.ToString();
        //                string virtualPath = string.Format("{0}/{1}/{2}/{3}{4}", filePath, user.userId, uploadDate, fileAnnexesEntity.F_Id, extension);
        //                fileAnnexesEntity.F_FilePath = virtualPath;
        //                fileAnnexesEntity.F_FileType = extension.Replace(".", "");
        //                fileAnnexesEntity.F_CreateUserId = user.userId;
        //                fileAnnexesEntity.F_CreateUserName = user.realName;
        //                annxesFileibll.SaveEntity(fileGuid, fileAnnexesEntity);//保存附件
        //                File.Move(filenames[j], virtualPath);//将文件过去

        //            }

        //            if (string.IsNullOrEmpty(entity.F_PictureAccessories))
        //            {

        //                entity.F_PictureAccessories = fileGuid;
        //                entity.Modify(entity.F_HouseID);
        //                db.Update(entity);
        //            }



        //        }
        //        DirFileHelper.ClearObservateDirectory(FileDirectory);
        //        db.Commit();

        //        return true;
        //    }

        //    catch (Exception ex)
        //    {
        //        db.Rollback();
        //        if (ex is ExceptionEx)
        //        {
        //            throw;
        //        }
        //        else
        //        {
        //            throw ExceptionEx.ThrowServiceException(ex);
        //        }
        //    }
        //}



        public bool ImportCertiate(string FileDirectory,string numbersName, ref string Msg)
        {
            var db = this.BaseRepository().BeginTrans();

            try
            {
                var HouseInfolist = db.FindList<DC_ASSETS_HouseInfoEntity>();
                string[] fileNames = DirFileHelper.GetFileNames(FileDirectory + "/" + numbersName);
                bool bCheck = true;
                Hashtable ht = new Hashtable();

               // string[] sources = DirFileHelper.GetDirectories(fileNames[0]);
                for (int i = 0; i < fileNames.Length; i++)
                {
                    DirectoryInfo info = new DirectoryInfo(fileNames[i]);
                    String path = info.Parent.Parent.FullName;
                    // str1 = Regex.Replace(str2, @"\D+", "");
                    string name = Regex.Replace(info.Name, @"\D+", ""); //获取当前路径最后一级文件夹名称
                    var Entity = db.FindEntity<DC_ASSETS_HouseInfoEntity>(p => p.F_CertificateNo.Contains(name));
                    //var Entity = db.FindEntity<DC_ASSETS_HouseInfoEntity>(p =>name.Contains(p.F_CertificateNo));

                    if (Entity == null)
                    {
                        Msg += name;
                        Msg += ",";
                        bCheck = false;
                    }
                    if (bCheck)
                    {
                        ht.Add(name, Entity.F_HouseID);

                    }
                    //1.获取文件夹名称 
                    //文件夹名称为房产证数字，获取房产数据的id,如果没有查到，表明没有查到此
                    //房产证的数据，然后记录下来，保存到Msg,查到了，用hashtable 保存 键房产证号，值房子id

                }
                if (!bCheck)
                {
                    Msg += "依据上述房产证号，没有查到房产信息，请核实，再导入！导入失败！";
                    DirFileHelper.ClearDirectory(FileDirectory);

                    return false;
                }
                //如果 Msg不为空，直接返回此号码，表明没有查到数据，不导入，返回false
                //如果房产证都找到了，构造附件实体类，按附件格式要求，
                //将房产信息移动相应目录下
                //然后保存实体类
                //然后删除临时文件夹

                for (int i = 0; i < fileNames.Length; i++)
                {
                    DirectoryInfo info = new DirectoryInfo(fileNames[i]);
                    String path = info.Parent.Parent.FullName;
                    string name = Regex.Replace(info.Name, @"\D+", "");
                    string fileGuid = Guid.NewGuid().ToString();
                    UserInfo user = LoginUserInfo.Get();

                    // / 获取文件完整文件名(包含绝对路径)
                    //文件存放路径格式：/Resource/ResourceFile/{userId}/{date}/{guid}.{后缀名}
                    string filePath = Config.GetValue("AnnexesFile");
                    string uploadDate = DateTime.Now.ToString("yyyyMMdd");
                    //string FileEextension = Path.GetExtension(fileName);
                    // string virtualPath = string.Format("{0}/{1}/{2}/{3}{4}", filePath, user.userId, uploadDate, fileGuid, FileEextension);
                    string FloderPath = string.Format("{0}/{1}/{2}/", filePath, user.userId, uploadDate);
                    //创建文件夹
                    // string path = Path.GetDirectoryName(virtualPath);
                    //Directory.CreateDirectory(path);
                    AnnexesFileEntity fileAnnexesEntity = new AnnexesFileEntity();

                    //创建文件夹
                    if (!Directory.Exists(FloderPath))
                    {
                        Directory.CreateDirectory(FloderPath);
                    }

                    string HouseId = ht[name].ToString();
                    DC_ASSETS_HouseInfoEntity entity = db.FindEntity<DC_ASSETS_HouseInfoEntity>(HouseId);
                    if (!string.IsNullOrEmpty(entity.F_PictureAccessories))
                    {

                        fileGuid = entity.F_PictureAccessories;
                    }

                   
                        long size = GetFileSize(fileNames[i]);
                        string filename = Path.GetFileName(fileNames[i]);//文件名  “Default.aspx”
                        string extension = Path.GetExtension(fileNames[i]);//扩展名 “.aspx”
                        fileAnnexesEntity = new AnnexesFileEntity();
                        fileAnnexesEntity.F_Id = Guid.NewGuid().ToString();
                        fileAnnexesEntity.F_FileName = filename;
                        fileAnnexesEntity.F_CreateDate = DateTime.Now;
                        fileAnnexesEntity.F_FileExtensions = extension;
                        fileAnnexesEntity.F_FolderId = fileGuid;
                        fileAnnexesEntity.F_FileSize = size.ToString();
                        string virtualPath = string.Format("{0}/{1}/{2}/{3}{4}", filePath, user.userId, uploadDate, fileAnnexesEntity.F_Id, extension);
                        fileAnnexesEntity.F_FilePath = virtualPath;
                        fileAnnexesEntity.F_FileType = extension.Replace(".", "");
                        fileAnnexesEntity.F_CreateUserId = user.userId;
                        fileAnnexesEntity.F_CreateUserName = user.realName;
                        annxesFileibll.SaveEntity(fileGuid, fileAnnexesEntity);//保存附件
                        File.Move(fileNames[i], virtualPath);//将文件过去
              

                    if (string.IsNullOrEmpty(entity.F_PictureAccessories))
                    {

                        entity.F_PictureAccessories = fileGuid;
                        entity.Modify(entity.F_HouseID);
                        db.Update(entity);
                    }



                }
                DirFileHelper.ClearObservateDirectory(FileDirectory);
                db.Commit();

                return true;
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



        /// <summary>
        /// 修改房屋账面价值
        /// <summary>
        /// <returns></returns>
        public void UpdateComHouse()
        {

            try
            {
                string temp = string.Empty;
                //建筑sql语句
                var strSql = new StringBuilder();
                strSql.Append("select F_ConstructionArea,F_BuildingValue,F_BBIId from   DC_ASSETS_BuildingBaseInfo");
                //房屋sql语句
                var strSql1 = new StringBuilder();
                strSql1.Append("select * from   DC_ASSETS_HouserInfo");
                var buildings = this.BaseRepository().FindList<DC_ASSETS_BuildingBaseInfoEntity>();
                var Houseings = this.BaseRepository().FindList<DC_ASSETS_HouseInfoEntity>();
                var Landinfos = this.BaseRepository().FindList<DC_ASSETS_LandBaseInfoEntity>();
                double F_sumArea = 0.0;
                double totalValue = 0.0;

                //foreach (var item in buildings)
                //{
                //    if (item.F_BuildingValue == 0 || item.F_ConstructionArea == 0) continue;

                //    var houseItems = Houses.Where(i => i.F_BBIId == item.F_BBIId);

                //    if (houseItems != null && houseItems.Count() > 0)
                //    {

                //        foreach (var houseItem in houseItems)
                //        {
                //            houseItem.F_BuildingValue = houseItem.F_HouseArea / item.F_ConstructionArea * item.F_BuildingValue;
                //            houseItem.Modify(houseItem.F_HouseID);
                //            this.BaseRepository().Update(houseItem);
                //        }

                //    }
                //}

                //foreach(var item in Landinfos)
                //{
                //   // if (item.F_TransferAmount <= 0) continue;
                //    var builds = buildings.Where(i => i.F_LBIId == item.F_LBIId);

                foreach (var build in buildings)
                {
                    temp = string.Format("select  isnull(sum(F_HouseArea), 0) area  from dc_assets_houseinfo where F_BBIId = '{0}' ", build.F_BBIId);
                    F_sumArea = (double)this.BaseRepository().FindObject(temp);
                    var houses = Houseings.Where(i => i.F_BBIId == build.F_BBIId);
                    totalValue = 0;
                    int j = 0;
                    foreach (var houseItem in houses)
                    {
                        if (houseItem.F_BuildingValue > 0)
                        {
                            totalValue = (double)houseItem.F_BuildingValue;
                            j++;
                        }
                    }
                    if (j == 1)
                    {
                        foreach (var houseItem in houses)
                        {
                            if (houseItem.F_HouseArea.HasValue)
                            {
                                houseItem.F_BuildingValue = Math.Round((double)houseItem.F_HouseArea / F_sumArea * totalValue, 2);
                                houseItem.Modify(houseItem.F_HouseID);
                                this.BaseRepository().Update(houseItem);
                            }
                        }
                    }
                }



                //}

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
        public void SaveEntity(string keyValue, DC_ASSETS_HouseInfoEntity entity)
        {
            try
            {
                if (entity.F_BBIId == "")
                {
                    entity.F_BBIId = null;
                }
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
        /// 保存实体数据（新增、修改）
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public void SaveTotalEntity(string keyValue, DC_ASSETS_LandBaseInfoEntity Landentity, DC_ASSETS_BuildingBaseInfoEntity Buildingentity, DC_ASSETS_HouseInfoEntity entity)
        {

            var db = this.BaseRepository().BeginTrans();
            try
            {
                if (!string.IsNullOrEmpty(keyValue))
                {

                    //var DC_ASSETS_HouseInfoData = this.GetDC_ASSETS_HouseInfo(keyValue);
                    //Buildingentity.F_BBIId = DC_ASSETS_HouseInfoData.F_BBIId;
                    //var DC_ASSETS_BuildingBaseInfoData = dC_ASSETS_BuildingBaseInfoIBLL.GetDC_ASSETS_BuildingBaseInfo(Buildingentity.F_BBIId);
                    //Landentity.F_LBIId = DC_ASSETS_BuildingBaseInfoData.F_BBIId;
                    //var DC_ASSETS_LandBaseInfoData = dC_ASSETS_LandBaseInfoIBLL.GetDC_ASSETS_LandBaseInfoEntity(DC_ASSETS_BuildingBaseInfoData.F_LBIId);
                    // DC_ASSETS_LandBaseInfoData.F_LandName = Landentity.F_LandName;
                    // DC_ASSETS_BuildingBaseInfoData.F_ConstructionFloorCount = Buildingentity.F_ConstructionFloorCount;

                    if (!string.IsNullOrEmpty(Landentity.F_LBIId))
                    {
                        Landentity.Modify(Landentity.F_LBIId);
                        db.Update<DC_ASSETS_LandBaseInfoEntity>(Landentity);
                        Buildingentity.F_LBIId = Landentity.F_LBIId;
                        Buildingentity.Modify(Buildingentity.F_BBIId);
                        db.Update<DC_ASSETS_BuildingBaseInfoEntity>(Buildingentity);
                    }
                    else
                    {
                        Landentity.Create();
                        db.Insert(Landentity);

                        Buildingentity.F_LBIId = Landentity.F_LBIId;
                        Buildingentity.Create();
                        db.Insert(Buildingentity);

                    }
                    entity.F_BBIId = Buildingentity.F_BBIId;
                    // Buildingentity.F_LBIId = Landentity.F_LBIId;
                    entity.Modify(keyValue);

                    db.Update(entity);


                }
                else
                {
                    if (!string.IsNullOrEmpty(Landentity.F_LBIId))
                    {
                        Landentity.Modify(Landentity.F_LBIId);
                        db.Update<DC_ASSETS_LandBaseInfoEntity>(Landentity);

                        if (!string.IsNullOrEmpty(Buildingentity.F_BBIId))
                        {
                            Buildingentity.F_LBIId = Landentity.F_LBIId;
                            Buildingentity.Modify(Buildingentity.F_BBIId);
                            db.Update<DC_ASSETS_BuildingBaseInfoEntity>(Buildingentity);

                        }
                        else
                        {
                            Buildingentity.F_LBIId = Landentity.F_LBIId;
                            Buildingentity.Create();
                            db.Insert(Buildingentity);
                        }

                    }
                    else
                    {
                        Landentity.Create();
                        db.Insert(Landentity);

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


        /// <summary>
        /// 保存实体数据（新增、修改）
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public void SaveTotalEntity(string keyValue, DC_ASSETS_BuildingBaseInfoEntity Buildingentity, DC_ASSETS_HouseInfoEntity entity)
        {

            var db = this.BaseRepository().BeginTrans();
            try
            {
                if (!string.IsNullOrEmpty(keyValue))
                {

                    //var DC_ASSETS_HouseInfoData = this.GetDC_ASSETS_HouseInfo(keyValue);
                    //Buildingentity.F_BBIId = DC_ASSETS_HouseInfoData.F_BBIId;
                    //var DC_ASSETS_BuildingBaseInfoData = dC_ASSETS_BuildingBaseInfoIBLL.GetDC_ASSETS_BuildingBaseInfo(Buildingentity.F_BBIId);
                    //Landentity.F_LBIId = DC_ASSETS_BuildingBaseInfoData.F_BBIId;
                    //var DC_ASSETS_LandBaseInfoData = dC_ASSETS_LandBaseInfoIBLL.GetDC_ASSETS_LandBaseInfoEntity(DC_ASSETS_BuildingBaseInfoData.F_LBIId);
                    // DC_ASSETS_LandBaseInfoData.F_LandName = Landentity.F_LandName;
                    // DC_ASSETS_BuildingBaseInfoData.F_ConstructionFloorCount = Buildingentity.F_ConstructionFloorCount;

                    Buildingentity.Modify(Buildingentity.F_BBIId);
                    entity.Modify(keyValue);

                    db.Update<DC_ASSETS_BuildingBaseInfoEntity>(Buildingentity);
                    db.Update(entity);


                }
                else
                {


                    if (!string.IsNullOrEmpty(Buildingentity.F_BBIId))
                    {

                        Buildingentity.Modify(Buildingentity.F_BBIId);
                        db.Update<DC_ASSETS_BuildingBaseInfoEntity>(Buildingentity);

                    }
                    else
                    {
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


        public bool IsExitsEntity(string name)
        {

            var list = this.BaseRepository().FindEntity<DC_ASSETS_HouseInfoEntity>(i => i.F_HouseName == name);
            if (list != null)
            {
                return true;
            }
            else
            {
                return false;

            }

        }

        #endregion

        public DataTable StatisticsHouseInfo(DateTime startDate, DateTime endDate)
        {
            DataTable dt = this.BaseRepository().FindTable(@"
              select t.areaname,t.type,count(*) as count,sum(t.area) as area from
              (select 
              isnull((select top 1 f_areaname from lr_base_area where f_areaid = t2.f_communitycode),'未填写') as areaname,
              isnull(t3.f_itemname,'未填写') as type,
              isnull(t1.f_housearea,0) as area
              from dc_assets_houseinfo t1 
              left join dc_assets_buildingbaseinfo t2 
              on t1.f_bbiid = t2.f_bbiid
              left join lr_base_dataitemdetail t3
              on t1.f_usecategories  = t3.f_itemvalue and t3.f_itemid='9f7afe86-1d59-45fd-a913-2e5cfa67d7e9'
              where t1.F_CreateDatetime >= @startDate and t1.F_CreateDatetime<=@endDate) t
              group by t.areaname,t.type
            ", new { startDate = startDate, endDate = endDate });
            DataRow row = dt.NewRow();
            row["areaname"] = "合计";
            row["type"] = DBNull.Value;
            row["count"] = dt.AsEnumerable().Sum(c => Convert.ToInt32(c["count"]));
            row["area"] = dt.AsEnumerable().Sum(c => Convert.ToDecimal(c["area"]));
            dt.Rows.Add(row);
            return dt;
        }
        public DataTable StatisticsHouseInfoEx(DateTime startDate, DateTime endDate)
        {
            return this.BaseRepository().FindTable(@"
              select t.areaname,t.type,count(*) as count,sum(t.area) as area from
              (select 
              isnull((select top 1 f_areaname from lr_base_area where f_areaid = t2.f_communitycode),'未填写') as areaname,
              isnull(t3.f_itemname,'未填写') as type,
              isnull(t1.f_housearea,0) as area
              from dc_assets_houseinfo t1 
              left join dc_assets_buildingbaseinfo t2 
              on t1.f_bbiid = t2.f_bbiid
              left join lr_base_dataitemdetail t3
              on t1.f_usecategories  = t3.f_itemvalue and t3.f_itemid='9f7afe86-1d59-45fd-a913-2e5cfa67d7e9'
              where t1.F_CreateDatetime >= @startDate and t1.F_CreateDatetime<=@endDate) t
              group by t.areaname,t.type
            ", new { startDate = startDate, endDate = endDate });
        }
    }
}
