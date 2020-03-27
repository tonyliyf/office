using Dapper;
using Learun.DataBase.Repository;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Learun.Application.TwoDevelopment.SystemDemo;


namespace Learun.Application.TwoDevelopment.AssetManager
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-02-16 14:32
    /// 描 述：DC_ASSETS_HouseRentDetail
    /// </summary>
    public class DC_ASSETS_HouseRentDetailService : RepositoryFactory
    {
        #region 获取数据

        private DC_ASSETS_HouseInfoService houseservice = new DC_ASSETS_HouseInfoService();
        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_ASSETS_HouseRentDetailEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_HRDId,
                d.F_HouseName as F_HouseID,
                t.F_ValuationPrice,
                t.F_RentReservePrice,
                t.F_RentDeposit,
                t.F_CreateUser,
                t.F_RentAge,
                t.F_RentArea,
                t.F_LeaseState,
                t.F_RentStartTime,
                t.F_RentEndTime,
                t.F_RentReminder,
                t.F_RentReminderDate,
                t.F_ExpireReminder,
                t.F_ExpireReminderDate,
                t.F_Renter,
                t.F_RenterCompany,
                t.F_RenterIDNo,
                t.F_RenterPhone,
                t.F_Remarks,
                t.F_DetailFiles,
                d.F_BuildingAddress as F_BuildingAddress
                ");
                strSql.Append("  FROM DC_ASSETS_HouseRentDetail t  left join DC_ASSETS_HouseInfo d on t.F_HouseID=d.F_HouseID");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["F_Renter"].IsEmpty())
                {
                    dp.Add("F_Renter", "%" + queryParam["F_Renter"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_Renter Like @F_Renter ");
                }
                if (!queryParam["F_HRMId"].IsEmpty())
                {
                    dp.Add("F_HRMId", queryParam["F_HRMId"].ToString(), DbType.String);
                    if (queryParam["F_HRMId"].ToString().Length < 10)
                    {
                        strSql.Append(" AND t.F_RentYear = @F_HRMId ");
                    }
                    else
                    {
                        strSql.Append(" AND t.F_HRMId = @F_HRMId ");
                    }
                }
                return this.BaseRepository().FindList<DC_ASSETS_HouseRentDetailEntity>(strSql.ToString(), dp, pagination);
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
        /// 已租的房屋合同信息
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DC_ASSETS_HouseRentDetailEntity> GetList()
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_HRDId,
                d.F_HouseName as F_HouseID,
                t.F_ValuationPrice,
                t.F_RentReservePrice,
                t.F_RentDeposit,
                t.F_CreateUser,
                t.F_RentAge,
                t.F_RentArea,
                t.F_LeaseState,
                t.F_RentStartTime,
                t.F_RentEndTime,
                t.F_RentReminder,
                t.F_RentReminderDate,
                t.F_ExpireReminder,
                t.F_ExpireReminderDate,
                t.F_Renter,
                t.F_RenterCompany,
                t.F_RenterIDNo,
                t.F_RenterPhone,
                t.F_Remarks,
                t.F_DetailFiles,
                d.F_BuildingAddress as F_BuildingAddress
                ");
                strSql.Append("  FROM DC_ASSETS_HouseRentDetail t  left join DC_ASSETS_HouseInfo d on t.F_HouseID=d.F_HouseID");
                strSql.Append("  WHERE t.F_LeaseState='2' ");
                
                return this.BaseRepository().FindList<DC_ASSETS_HouseRentDetailEntity>(strSql.ToString());
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
        public IEnumerable<DC_ASSETS_HouseRentDetailEntity> GetRentPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();

                //                strSql.Append(@"
                // select  top 500000 *  from (SELECT   l.F_Transferor,b.F_ConstructionName,h.F_HouseName,isnull(l.F_ParcelAddress,b.F_Address)F_Address,b.F_ConstructionArea, m.F_RentYear,m.F_RentName ,d.*  FROM  dc_assets_landbaseinfo l join  DC_ASSETS_BuildingBaseInfo b 
                //on l.F_LBIId =b.F_LBIId join DC_ASSETS_HouseInfo h on b.F_BBIId =h.F_BBIId
                //join dc_assets_houseRentDetail d on d.F_HouseID =h.F_HouseID
                //join dc_assets_houseRentMain m on m.F_HRMId =d.F_HRMId
                //union 
                //select   b.F_OldUnit as F_Transferor, b.F_ConstructionName,h.F_HouseName,b.F_Address,b.F_ConstructionArea,m.F_RentYear ,m.F_RentName, d.* from  DC_ASSETS_BuildingBaseInfo b  join  DC_ASSETS_HouseInfo h on b.F_BBIId =h.F_BBIId
                //join dc_assets_houseRentDetail d on d.F_HouseID =h.F_HouseID
                //join dc_assets_houseRentMain m on m.F_HRMId =d.F_HRMId
                //where b.F_LBIId is null) b
                //                ");

                strSql.Append("select m.F_RentName, d.*,h.F_CertificateNo from  dc_assets_houseRentDetail d join  dc_assets_houseRentMain m on m.F_HRMId =d.F_HRMId join DC_ASSETS_HouseInfo h on d.F_HouseID =h.F_HouseID ");


                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["F_Transferor"].IsEmpty())
                {
                    dp.Add("F_Transferor", "%" + queryParam["F_Transferor"].ToString() + "%", DbType.String);
                    strSql.Append(" AND F_Transferor Like @F_Transferor ");
                }

                if (!queryParam["F_ConstructionName"].IsEmpty())
                {
                    dp.Add("F_ConstructionName", "%" + queryParam["F_ConstructionName"].ToString() + "%", DbType.String);
                    strSql.Append(" AND F_ConstructionName Like @F_ConstructionName ");
                }

                if (!queryParam["F_HouseName"].IsEmpty())
                {
                    dp.Add("F_HouseName", "%" + queryParam["F_HouseName"].ToString() + "%", DbType.String);
                    strSql.Append(" AND F_HouseName Like @F_HouseName ");
                }

                if (!queryParam["F_Address"].IsEmpty())
                {
                    dp.Add("F_Address", "%" + queryParam["F_Address"].ToString() + "%", DbType.String);
                    strSql.Append(" AND F_Location Like @F_Address ");
                }
                if (!queryParam["F_HRMId"].IsEmpty())
                {
                    dp.Add("F_HRMId", "%" + queryParam["F_HRMId"].ToString() + "%", DbType.String);
                    if (queryParam["F_HRMId"].ToString().Length < 10)
                    {
                        strSql.Append(" AND F_RentYear like @F_HRMId ");
                    }
                    else
                    {
                        strSql.Append(" AND d.F_HRMId like @F_HRMId ");
                    }
                }

               // strSql.Append(" order by F_RentName,F_Transferor,F_ConstructionName,F_HouseName");
                return this.BaseRepository().FindList<DC_ASSETS_HouseRentDetailEntity>(strSql.ToString(), dp, pagination);
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
        public IEnumerable<DC_ASSETS_HouseRentDetailEntity> GetRentList( string ids)
        {
            try
            {
                var strSql = new StringBuilder();

                //                strSql.Append(@"
                // select  top 500000 *  from (SELECT   l.F_Transferor,b.F_ConstructionName,h.F_HouseName,isnull(l.F_ParcelAddress,b.F_Address)F_Address,b.F_ConstructionArea, m.F_RentYear,m.F_RentName ,d.*  FROM  dc_assets_landbaseinfo l join  DC_ASSETS_BuildingBaseInfo b 
                //on l.F_LBIId =b.F_LBIId join DC_ASSETS_HouseInfo h on b.F_BBIId =h.F_BBIId
                //join dc_assets_houseRentDetail d on d.F_HouseID =h.F_HouseID
                //join dc_assets_houseRentMain m on m.F_HRMId =d.F_HRMId
                //union 
                //select   b.F_OldUnit as F_Transferor, b.F_ConstructionName,h.F_HouseName,b.F_Address,b.F_ConstructionArea,m.F_RentYear ,m.F_RentName, d.* from  DC_ASSETS_BuildingBaseInfo b  join  DC_ASSETS_HouseInfo h on b.F_BBIId =h.F_BBIId
                //join dc_assets_houseRentDetail d on d.F_HouseID =h.F_HouseID
                //join dc_assets_houseRentMain m on m.F_HRMId =d.F_HRMId
                //where b.F_LBIId is null) b
                //                ");

                strSql.Append("select m.F_RentName, d.*,h.F_CertificateNo from  dc_assets_houseRentDetail d join  dc_assets_houseRentMain m on m.F_HRMId =d.F_HRMId join DC_ASSETS_HouseInfo h on d.F_HouseID =h.F_HouseID ");


                strSql.Append("  WHERE  F_LeaseState!=2 ");
              
        
                if (!ids.IsEmpty())
                {
                    string[] temps = ids.Split(',');
                    var temp = string.Empty;
                    foreach(var item in temps)
                    {
                        temp += "'";
                        temp += item;
                        temp += "',";
                    }
                 strSql.Append(string.Format(" AND d.F_HRMId in ({0})", temp.Substring(0,temp.Length-1)));
                    return this.BaseRepository().FindList<DC_ASSETS_HouseRentDetailEntity>(strSql.ToString());

                }

                return null;
                // strSql.Append(" order by F_RentName,F_Transferor,F_ConstructionName,F_HouseName");
                
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
        public IEnumerable<DC_ASSETS_HouseRentDetailEntity> GetHouseRentDetailInfo(string KeyValue,string SearchValue)
        {
            try
            {
                var strSql = new StringBuilder();

              

                strSql.Append("select m.F_RentName, d.*,h.F_CertificateNo,m.F_Unit as F_FormerUnit  from  dc_assets_houseRentDetail d join  dc_assets_houseRentMain m on m.F_HRMId =d.F_HRMId join DC_ASSETS_HouseInfo h on d.F_HouseID =h.F_HouseID ");

                strSql.Append(string.Format(" where 1=1  AND d.F_HRMId ='{0}'", KeyValue));

                if (!string.IsNullOrEmpty(SearchValue))
                {

                    strSql.Append(string.Format(" AND ( m.F_Unit like '%{0}%' or d.F_Renter like '%{0}%' or d.F_Transferor like'%{0}%')", SearchValue));
                }

                SimpleLogUtil.WriteTextLog("HouseRentDetail", strSql.ToString(), DateTime.Now);
                return this.BaseRepository().FindList<DC_ASSETS_HouseRentDetailEntity>(strSql.ToString());

              

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



        public IEnumerable<DC_ASSETS_HouseRentIncomeEntity> GetHouseRentDetailInfoList()
        {
            try
            {
                //获取已租数据
                var strSql = new StringBuilder();
                strSql.Append(@"select  c.*,h.F_HouseName,i.F_RenterPhone ,d.F_Location as F_Address from DC_ASSETS_HouseRentDetail d inner join  DC_ASSETS_HouseInfo h
on d.F_HouseID =h.F_HouseID  inner join DC_ASSETS_HouseRentDetail_Info i

on d.F_HRDId = i.F_RentDetailId inner join DC_ASSETS_BuildingBaseInfo b
on b.F_BBIId =h.F_BBIId inner join  DC_ASSETS_HouseRentIncome c on c.F_RentDetailId = i.F_RentInfoId where   d.F_LeaseState =2");

                return this.BaseRepository().FindList<DC_ASSETS_HouseRentIncomeEntity>(strSql.ToString());
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




        public IEnumerable<DC_ASSETS_HouseRentDetailEntity> GetHouseRentDetailList()
        {
            try
            {
                //获取已租数据
                var strSql = new StringBuilder();
                strSql.Append(@"select  d.*,h.F_HouseName from DC_ASSETS_HouseRentDetail d inner join  DC_ASSETS_HouseInfo h
on d.F_HouseID =h.F_HouseID and d.F_LeaseState =2");

                return this.BaseRepository().FindList<DC_ASSETS_HouseRentDetailEntity>(strSql.ToString());
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

                //                strSql.Append(@"
                // select  top 500000 *  from (SELECT   l.F_Transferor,b.F_ConstructionName,h.F_HouseName,isnull(l.F_ParcelAddress,b.F_Address)F_Address,b.F_ConstructionArea, m.F_RentYear,m.F_RentName ,d.*  FROM  dc_assets_landbaseinfo l join  DC_ASSETS_BuildingBaseInfo b 
                //on l.F_LBIId =b.F_LBIId join DC_ASSETS_HouseInfo h on b.F_BBIId =h.F_BBIId
                //join dc_assets_houseRentDetail d on d.F_HouseID =h.F_HouseID
                //join dc_assets_houseRentMain m on m.F_HRMId =d.F_HRMId
                //union 
                //select   b.F_OldUnit as F_Transferor, b.F_ConstructionName,h.F_HouseName,b.F_Address,b.F_ConstructionArea,m.F_RentYear ,m.F_RentName, d.* from  DC_ASSETS_BuildingBaseInfo b  join  DC_ASSETS_HouseInfo h on b.F_BBIId =h.F_BBIId
                //join dc_assets_houseRentDetail d on d.F_HouseID =h.F_HouseID
                //join dc_assets_houseRentMain m on m.F_HRMId =d.F_HRMId
                //where b.F_LBIId is null) b
                //                ");

                strSql.Append(@"
select m.F_RentName, d.F_Transferor,d.F_Location,h.F_CertificateNo,d.F_RentArea,d.F_RentReservePrice,d.F_RentDeposit


 ,i.F_Renter as Renter,i.F_RenterPhone as phone,i.F_DoThings ,i.F_RentArea as Area,i.F_ContractNo as ContractNo,i.F_RentStartTime as starttime ,i.F_RentAge as age,i.F_ActualPrice as price,i.F_RentDeposit as Deposit,i.F_Manager,i.F_Remarks as marks from  dc_assets_houseRentDetail d join  dc_assets_houseRentMain m on m.F_HRMId =d.F_HRMId join DC_ASSETS_HouseInfo h 
                 on d.F_HouseID =h.F_HouseID  left join DC_ASSETS_HouseRentDetail_Info i on d.F_HRDId =i.F_RentDetailId ");


                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["F_Transferor"].IsEmpty())
                {
                    dp.Add("F_Transferor", "%" + queryParam["F_Transferor"].ToString() + "%", DbType.String);
                    strSql.Append(" AND F_Transferor Like @F_Transferor ");
                }

                if (!queryParam["F_ConstructionName"].IsEmpty())
                {
                    dp.Add("F_ConstructionName", "%" + queryParam["F_ConstructionName"].ToString() + "%", DbType.String);
                    strSql.Append(" AND F_ConstructionName Like @F_ConstructionName ");
                }

                if (!queryParam["F_HouseName"].IsEmpty())
                {
                    dp.Add("F_HouseName", "%" + queryParam["F_HouseName"].ToString() + "%", DbType.String);
                    strSql.Append(" AND F_HouseName Like @F_HouseName ");
                }

                if (!queryParam["F_Address"].IsEmpty())
                {
                    dp.Add("F_Address", "%" + queryParam["F_Address"].ToString() + "%", DbType.String);
                    strSql.Append(" AND F_Location Like @F_Address ");
                }
                if (!queryParam["F_HRMId"].IsEmpty())
                {
                    dp.Add("F_HRMId", "%" + queryParam["F_HRMId"].ToString() + "%", DbType.String);
                    if (queryParam["F_HRMId"].ToString().Length < 10)
                    {
                        strSql.Append(" AND F_RentYear like @F_HRMId ");
                    }
                    else
                    {
                        strSql.Append(" AND d.F_HRMId like @F_HRMId ");
                    }
                }

                strSql.Append(" order by F_RentName,F_Transferor,F_Location,F_CertificateNo,Renter,ContractNo");
                return this.BaseRepository().FindTable(strSql.ToString(), dp);
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
        /// 获取DC_ASSETS_HouseRentDetail表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_ASSETS_HouseRentDetailEntity GetDC_ASSETS_HouseRentDetailEntity(string keyValue)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("select top 1 * from DC_ASSETS_HouseRentDetail where F_HouseID='"+ keyValue + "' ORDER BY F_HouseID DESC,F_CreateDatetime DESC   ");
               
               
                IEnumerable<DC_ASSETS_HouseRentDetailEntity> HouseRentDetail = this.BaseRepository().FindList<DC_ASSETS_HouseRentDetailEntity>(strSql.ToString());
                DC_ASSETS_HouseRentDetailEntity num = null;

                foreach (DC_ASSETS_HouseRentDetailEntity obj in HouseRentDetail) {

                    num = obj;
                }

                return num;
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
        /// 获取DC_ASSETS_HouseRentDetail表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_ASSETS_HouseRentDetailEntity GetDC_ASSETS_HouseRentDetailEntityByHouseId(string keyValue)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("select top 1 * from DC_ASSETS_HouseRentDetail where F_HouseID='" + keyValue + "' ORDER BY F_CreateDatetime DESC   ");


                IEnumerable<DC_ASSETS_HouseRentDetailEntity> HouseRentDetail = this.BaseRepository().FindList<DC_ASSETS_HouseRentDetailEntity>(strSql.ToString());
                DC_ASSETS_HouseRentDetailEntity num = null;

                foreach (DC_ASSETS_HouseRentDetailEntity obj in HouseRentDetail)
                {

                    num = obj;
                }


                return num;
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
        /// 获取DC_ASSETS_HouseRentDetail表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_ASSETS_HouseRentDetailEntity GetHouseRentDetailEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_ASSETS_HouseRentDetailEntity>(keyValue);
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
        /// 获取DC_ASSETS_HouseRentDetail表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_ASSETS_HouseRentDetailEntity GetHouseRentDetail(string keyValue)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append(@"select top(1) a.F_HRMId,a.F_HouseID,a.F_RentArea,a.F_RentReservePrice,a.F_RentDeposit,a.F_Location,a.F_LeaseState,a.F_RentContractNo,a.F_Remarks,a.F_DetailFiles,a.F_HRDId,b.F_RentTime from DC_ASSETS_HouseRentDetail a 

left join DC_ASSETS_HouseRentMain b on a.F_HRMId=b.F_HRMId   where F_HouseID='" + keyValue + "'   ORDER BY b.F_RentTime DESC ");
                //return this.BaseRepository().FindList<DC_ASSETS_HouseRentDetailEntity>(sql,ToString());
                var Details = this.BaseRepository().FindEntity<DC_ASSETS_HouseRentDetailEntity>(strSql.ToString(),null);
              

                
                // DataTable data= this.BaseRepository().FindTable(strSql.ToString());
                //DC_ASSETS_HouseRentDetailEntity Detail = new DC_ASSETS_HouseRentDetailEntity();
                //if (data.Rows.Count>0) {
                //    Detail.F_HRMId = data.Rows[0][0].ToString();
                //    Detail.F_HouseID = data.Rows[0][1].ToString();
                //    Detail.F_RentArea = data.Rows[0][2].ToDouble();
                //    Detail.F_RentReservePrice = data.Rows[0][3].ToDouble();
                //    Detail.F_RentDeposit = data.Rows[0][4].ToDouble();
                //    Detail.F_Location = data.Rows[0][5].ToString();
                //    Detail.F_LeaseState = data.Rows[0][6].ToString();
                //    Detail.F_RentContractNo = data.Rows[0][7].ToString();
                //    Detail.F_Remarks = data.Rows[0][8].ToString();
                //    Detail.F_DetailFiles = data.Rows[0][9].ToString();
                //    Detail.F_HRDId= data.Rows[0][10].ToString();
                //}


                return Details;
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
        /// 获取DC_ASSETS_HouseRentDetail表数据
        /// <summary>
        /// <returns></returns>
        public IEnumerable<DC_ASSETS_HouseRentDetail_InfoEntity> GetDC_ASSETS_HouseRentDetailInfoList(string keyValue)
        {
            try
            {
                string sql = @"  select  * 
                              from DC_ASSETS_HouseRentDetail_Info t1
                              where  t1.F_RentDetailId=@F_RentDetailId";
                return this.BaseRepository().FindList<DC_ASSETS_HouseRentDetail_InfoEntity>(sql, new { F_RentDetailId = keyValue });
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
        /// 获取树形数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetSqlTree()
        {
            try
            {
                return this.BaseRepository().FindTable(@"  select * from (select distinct F_RentYear as id ,0 as parentid,F_RentYear as [name] ,0 as F_RentNumber from DC_ASSETS_HouseRentMain
  union select F_HRMId as id ,F_RentYear as parentid,F_RentName as [name],F_RentNumber  from DC_ASSETS_HouseRentMain) b order by parentid,cast(F_RentNumber as int) ");
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
                this.BaseRepository().Delete<DC_ASSETS_HouseRentDetail_InfoEntity>(t => t.F_RentDetailId == keyValue);
                this.BaseRepository().Delete<DC_ASSETS_HouseRentDetailEntity>(t => t.F_HRDId == keyValue);
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
        public void SaveEntity(string keyValue, DC_ASSETS_HouseRentDetailEntity entity)
        {
            try
            {
                string oldUnit = houseservice.GetOldUnitByHouseId(entity.F_HouseID);
                entity.F_Transferor = oldUnit;
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
        public void SaveEntity(string keyValue, DC_ASSETS_HouseRentDetailEntity entity, List<DC_ASSETS_HouseRentDetail_InfoEntity> dC_ASSETS_HouseRentDetailInfoList)
        {
            //try
            //{
            //    if (!string.IsNullOrEmpty(keyValue))
            //    {
            //        entity.Modify(keyValue);
            //        this.BaseRepository().Update(entity);
            //    }
            //    else
            //    {
            //        entity.Create();
            //        this.BaseRepository().Insert(entity);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    if (ex is ExceptionEx)
            //    {
            //        throw;
            //    }
            //    else
            //    {
            //        throw ExceptionEx.ThrowServiceException(ex);
            //    }
            //}


            var db = this.BaseRepository().BeginTrans();
            try
            {
                string oldUnit = houseservice.GetOldUnitByHouseId(entity.F_HouseID);
                entity.F_Transferor = oldUnit;
                if (!string.IsNullOrEmpty(keyValue))
                {

                    entity.Modify(keyValue);
                    this.BaseRepository().Update(entity);
                    
                    db.Delete<DC_ASSETS_HouseRentDetail_InfoEntity>(t => t.F_RentDetailId == keyValue);
                    foreach (DC_ASSETS_HouseRentDetail_InfoEntity item in dC_ASSETS_HouseRentDetailInfoList)
                    {
                        item.Create();
                        item.F_RentDetailId = keyValue;
                        db.Insert(item);
                    }
                }
                else
                {
                    entity.Create();
                    db.Insert(entity);
                    foreach (DC_ASSETS_HouseRentDetail_InfoEntity item in dC_ASSETS_HouseRentDetailInfoList)
                    {
                        item.Create();
                        item.F_RentDetailId = entity.F_HRDId;
                        db.Insert(item);
                    }
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

        public double GetMinRentPrice(string keyValue)
        {
            return Convert.ToDouble(this.BaseRepository().FindObject("select top 1 F_ActualPrice from [DC_ASSETS_HouseRentIncome] where F_HRDId='" + keyValue + "' order by  F_PaymentDate desc") ?? 0f);
        }
        #endregion

    }
}
