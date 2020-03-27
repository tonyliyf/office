using Dapper;
using Learun.DataBase.Repository;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;
using Learun.Application.TwoDevelopment.SystemDemo;
using Learun.Application.Base.SystemModule;
using System.IO;
using System.Collections;
using System.Text.RegularExpressions;

namespace Learun.Application.TwoDevelopment.AssetManager
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-02-16 13:45
    /// 描 述：DC_ASSETS_HouseRentMain
    /// </summary>
    public class DC_ASSETS_HouseRentMainService : RepositoryFactory
    {
        private DC_ASSETS_HouseRentDetailService detailService = new DC_ASSETS_HouseRentDetailService();
        private DC_ASSETS_HouseInfoIBLL dc_houseBll = new DC_ASSETS_HouseInfoBLL();
        private AnnexesFileIBLL annxesFileibll = new AnnexesFileBLL();
        #region 获取数据
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
                t.F_HRMId,
                t.F_RentYear,
                t.F_RentNumber,
                t.F_RentState,
                t.F_RentName,
                t.F_Unit,
                t.F_Remarks,
                t.F_Accessories
                ");
                strSql.Append("  FROM DC_ASSETS_HouseRentMain t ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["F_RentYear"].IsEmpty())
                {
                    dp.Add("F_RentYear", "%" + queryParam["F_RentYear"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_RentYear Like @F_RentYear ");
                }
                if (!queryParam["F_RentNumber"].IsEmpty())
                {
                    dp.Add("F_RentNumber", "%" + queryParam["F_RentNumber"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_RentNumber Like @F_RentNumber ");
                }
                if (!queryParam["F_RentName"].IsEmpty())
                {
                    dp.Add("F_RentName", "%" + queryParam["F_RentName"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_RentName Like @F_RentName ");
                }
                DataTable dt = this.BaseRepository().FindTable(strSql.ToString(), dp);
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("F_RentState", "HouseRentState");
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
        public IEnumerable<DC_ASSETS_HouseRentMainEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_HRMId,
                t.F_RentYear,
                t.F_RentNumber,
                t.F_RentState,
                t.F_RentName,
                t.F_Unit,
                t.F_Remarks,
                t.F_Accessories,
                t.F_RentTime
                ");
                strSql.Append("  FROM DC_ASSETS_HouseRentMain t ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["F_RentYear"].IsEmpty())
                {
                    dp.Add("F_RentYear", "%" + queryParam["F_RentYear"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_RentYear Like @F_RentYear ");
                }
                if (!queryParam["F_RentNumber"].IsEmpty())
                {
                    dp.Add("F_RentNumber", "%" + queryParam["F_RentNumber"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_RentNumber Like @F_RentNumber ");
                }
                if (!queryParam["F_RentName"].IsEmpty())
                {
                    dp.Add("F_RentName", "%" + queryParam["F_RentName"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_RentName Like @F_RentName ");
                }
                return this.BaseRepository().FindList<DC_ASSETS_HouseRentMainEntity>(strSql.ToString(), dp, pagination);
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
        public DataTable GetHouseInfo()
        {
            try
            {
                var strSql = new StringBuilder();

                strSql.Append(@"
               
SELECT
 top 6 m.F_RentName, m.F_CreateDatetime ,
 SUM(CASE WHEN F_LeaseState= '2'  THEN 1 ELSE 0 END) AS SuccessNumber,
 count(F_HRDId) totalnumber
FROM
 DC_ASSETS_HouseRentMain m
 JOIN DC_ASSETS_HouseRentDetail l ON m.F_HRMId = l.F_HRMId 

GROUP BY
 F_RentName,
 m.F_CreateDatetime 
ORDER BY
 m.F_CreateDatetime DESC
                ");
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
        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_ASSETS_HouseRentMainEntity> GetMainList()
        {
            try
            {

                return this.BaseRepository().FindList<DC_ASSETS_HouseRentMainEntity>().OrderBy(i => i.F_RentTime);
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
        public IEnumerable<DC_ASSETS_HouseRentDetail_InfoEntity> GetDetail_InfoList()
        {
            try
            {

                return this.BaseRepository().FindList<DC_ASSETS_HouseRentDetail_InfoEntity>();
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


        public IEnumerable<DC_ASSETS_HouseRentDetailEntity> GetDetail(string numbersName)
        {
            try
            {
                var strSql = new StringBuilder();

                strSql.Append(@"
               
SELECT
l.* 
FROM
 DC_ASSETS_HouseRentMain m
 JOIN DC_ASSETS_HouseRentDetail l ON m.F_HRMId = l.F_HRMId 


where 1 =1 
                ");

                var dp = new DynamicParameters(new { });

                dp.Add("F_RentName", numbersName, DbType.String);
                strSql.Append(" AND m.F_RentName Like @F_RentName ");

                return this.BaseRepository().FindList<DC_ASSETS_HouseRentDetailEntity>(strSql.ToString(), dp);
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
        public IEnumerable<RentHouseModel> GetDC_ASSETS_HouseRentDetailList(string keyValue)
        {
            try
            {
                //return this.BaseRepository().FindList<DC_ASSETS_HouseRentDetailEntity>(t => t.F_HRMId == keyValue);
                string sql = @"  select t1.F_HouseID,t2.F_HouseCode as code,t2.F_HouseName as name, t2.F_ProofUnit as unitname , t2.F_BuildingAddress as address , t2.F_HouseArea as area,
                              t1.F_RentReservePrice,t1.F_RentDeposit,t1.F_LeaseState
                              from DC_ASSETS_HouseRentDetail t1,DC_ASSETS_HouseInfo t2
                              where t1.F_HouseID=t2.F_HouseID and t1.F_HRMId=@F_HRMId";
                return this.BaseRepository().FindList<RentHouseModel>(sql, new { F_HRMId = keyValue });
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
        /// 获取DC_ASSETS_HouseRentMain表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_ASSETS_HouseRentMainEntity GetDC_ASSETS_HouseRentMainEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_ASSETS_HouseRentMainEntity>(keyValue);
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
                return this.BaseRepository().FindEntity<DC_ASSETS_HouseRentDetailEntity>(t => t.F_HRMId == keyValue);
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
            var db = this.BaseRepository().BeginTrans();
            try
            {
                var dC_ASSETS_HouseRentMainEntity = GetDC_ASSETS_HouseRentMainEntity(keyValue);
                db.Delete<DC_ASSETS_HouseRentMainEntity>(t => t.F_HRMId == keyValue);
                // detailService.DeleteEntity(dC_ASSETS_HouseRentMainEntity.F_HRMId);
                //db.Delete<DC_ASSETS_HouseRentDetailEntity>(t => t.F_HRMId == dC_ASSETS_HouseRentMainEntity.F_HRMId);
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
        public void SaveEntity(string keyValue, DC_ASSETS_HouseRentMainEntity entity, List<DC_ASSETS_HouseRentDetailEntity> dC_ASSETS_HouseRentDetailList)
        {
            var db = this.BaseRepository().BeginTrans();
            try
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    var dC_ASSETS_HouseRentMainEntityTmp = GetDC_ASSETS_HouseRentMainEntity(keyValue);
                    entity.Modify(keyValue);
                    db.Update(entity);
                    db.Delete<DC_ASSETS_HouseRentDetailEntity>(t => t.F_HRMId == dC_ASSETS_HouseRentMainEntityTmp.F_HRMId);
                    if (dC_ASSETS_HouseRentDetailList != null)
                    {
                        foreach (DC_ASSETS_HouseRentDetailEntity item in dC_ASSETS_HouseRentDetailList)
                        {
                            string oldUnit = dc_houseBll.GetOldUnitByHouseId(item.F_HouseID);
                            item.F_Transferor = oldUnit;
                            item.Create();
                            item.F_HRMId = dC_ASSETS_HouseRentMainEntityTmp.F_HRMId;
                            db.Insert(item);
                        }
                    }
                }
                else
                {
                    entity.Create();
                    db.Insert(entity);
                    if (dC_ASSETS_HouseRentDetailList != null)
                    {
                        foreach (DC_ASSETS_HouseRentDetailEntity item in dC_ASSETS_HouseRentDetailList)
                        {
                            string oldUnit = dc_houseBll.GetOldUnitByHouseId(item.F_HouseID);
                            item.F_Transferor = oldUnit;
                            item.F_LeaseState = "1";
                            item.Create();
                            item.F_HRMId = entity.F_HRMId;
                            db.Insert(item);
                        }
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



        /// <summary>
        /// 保存实体数据（新增、修改）
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public void SaveEntity(string keyValue, DC_ASSETS_HouseRentMainEntity entity)
        {
            var db = this.BaseRepository().BeginTrans();
            try
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    var dC_ASSETS_HouseRentMainEntityTmp = GetDC_ASSETS_HouseRentMainEntity(keyValue);
                    entity.Modify(keyValue);
                    db.Update(entity);

                }
                else
                {
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

        public IEnumerable<PieChartModel> StatisticsRentInfo()
        {
            string sql = "  select f_rentyear as name,count(*) as value from DC_ASSETS_HouseRentMain group by f_rentyear";
            return this.BaseRepository().FindList<PieChartModel>(sql, new { });
        }

        public bool ImportBuildingEntity(DataTable dtTable)
        {
            var db = this.BaseRepository().BeginTrans();
            DC_ASSETS_HouseRentMainEntity entity = null;
            DC_ASSETS_HouseRentDetailEntity rentEntity = null;
            DC_ASSETS_HouseRentDetail_InfoEntity DetailEntity = null;
            DC_ASSETS_HouseInfoEntity houseEntity = null;
            string rentnumbers = "0";
            string certNo = string.Empty;
            string Renter = string.Empty;//承租人
            string contractNo = string.Empty;//合同编号
            int f = 0;

            string temp = string.Empty;
            try
            {
               
                foreach (DataRow dt in dtTable.Rows)
                {
                    if (dt[0].ToString() == "批次") continue;
                    Renter = string.Empty;
                    if (dt[0].ToString() != rentnumbers)
                    {
                        rentnumbers = dt[0].ToString();
                        entity = db.FindEntity<DC_ASSETS_HouseRentMainEntity>(i => i.F_RentName == rentnumbers);
                        if (entity == null) continue;
                    }

                    if (dt[2].ToString() == "前进路北17号院内1-1")
                    {
                        string aa = "eee";
                    }

                    if (dt[7].ToString() != certNo)
                    {
                        certNo = dt[7].ToString();

                        houseEntity = db.FindEntity<DC_ASSETS_HouseInfoEntity>(i => i.F_CertificateNo == certNo);
                    }
                    if (houseEntity == null)
                    {
                        string aa = "";
                        continue;
                    }

                    rentEntity = null;
                    var rentList = db.FindList<DC_ASSETS_HouseRentDetailEntity>();
                    foreach (var item in rentList)
                    {
                        if (item.F_HouseID == houseEntity.F_HouseID && item.F_Location == dt[2].ToString())
                        {
                            rentEntity = item;

                            break;

                        }
                    }
                    if (rentEntity == null)
                    {
                        rentEntity = new DC_ASSETS_HouseRentDetailEntity();
                        rentEntity.F_HRMId = entity.F_HRMId;
                        rentEntity.F_HouseID = houseEntity.F_HouseID;
                        if (!string.IsNullOrEmpty(dt[11].ToString()))
                        {
                            rentEntity.F_RentArea = double.Parse(dt[11].ToString());
                        }
                        //rentEntity.F_RentReservePrice = double.Parse(dt[3].ToString());
                        //rentEntity.F_RentDeposit = double.Parse(dt[4].ToString());
                        rentEntity.F_Location = dt[2].ToString();
                        rentEntity.F_LeaseState = "2";//默认招租成功
                        if (!string.IsNullOrEmpty(dt[12].ToString()))
                        {
                            rentEntity.F_RentContractNo = dt[12].ToString() + ",";
                        }

                        if (!string.IsNullOrEmpty(dt[22].ToString()))
                        {
                            rentEntity.F_RentContractNo = dt[22].ToString();
                        }

                        if (!string.IsNullOrEmpty(dt[32].ToString()))
                        {
                            rentEntity.F_RentContractNo = "," + dt[21].ToString();
                        }
                        rentEntity.Create();
                        db.Insert(rentEntity);
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(dt[12].ToString()))
                        {
                            rentEntity.F_RentContractNo += dt[12].ToString() + ",";
                        }

                        if (!string.IsNullOrEmpty(dt[22].ToString()))
                        {
                            rentEntity.F_RentContractNo += dt[22].ToString();
                        }

                        if (!string.IsNullOrEmpty(dt[32].ToString()))
                        {
                            rentEntity.F_RentContractNo += "," + dt[21].ToString();
                        }

                        rentEntity.Modify(rentEntity.F_HRMId);
                        db.Update(rentEntity);
                    }

                    if (!string.IsNullOrEmpty(dt[8].ToString()))
                    {
                        Renter = dt[8].ToString();
                        DetailEntity = new DC_ASSETS_HouseRentDetail_InfoEntity();
                        DetailEntity.F_RentDetailId = rentEntity.F_HRDId;
                        DetailEntity.F_Renter = dt[8].ToString();
                        DetailEntity.F_RenterPhone = dt[9].ToString();
                        DetailEntity.F_DoThings = dt[10].ToString();
                        if (!string.IsNullOrEmpty(dt[11].ToString()))
                        {
                            DetailEntity.F_RentArea = double.Parse(dt[11].ToString());
                        }

                        DetailEntity.F_ContractNo = dt[12].ToString();
                        if (!string.IsNullOrEmpty(dt[13].ToString()))
                        {
                            DetailEntity.F_RentStartTime = DateTime.Parse(dt[13].ToString());
                        }
                        if (!string.IsNullOrEmpty(dt[15].ToString()))
                        {
                            DetailEntity.F_RentAge = int.Parse(dt[15].ToString());

                            DetailEntity.F_RentEndTime = ((DateTime)DetailEntity.F_RentStartTime).AddYears((int)DetailEntity.F_RentAge);
                        }

                        if (!string.IsNullOrEmpty(dt[16].ToString()))
                        {
                            DetailEntity.F_ActualPrice = double.Parse(dt[16].ToString());
                        }
                        DetailEntity.Create();
                        db.Insert(DetailEntity);
                    }

                    if (!string.IsNullOrEmpty(dt[18].ToString()) && dt[18].ToString() != Renter)
                    {
                        Renter = dt[18].ToString();
                        DetailEntity = new DC_ASSETS_HouseRentDetail_InfoEntity();
                        DetailEntity.F_RentDetailId = rentEntity.F_HRDId;
                        DetailEntity.F_Renter = dt[18].ToString();

                        DetailEntity.F_RenterPhone = dt[19].ToString();
                        DetailEntity.F_DoThings = dt[20].ToString();
                        if (!string.IsNullOrEmpty(dt[21].ToString()))
                        {
                            DetailEntity.F_RentArea = double.Parse(dt[21].ToString());
                        }

                        DetailEntity.F_ContractNo = dt[22].ToString();

                        if (!string.IsNullOrEmpty(dt[23].ToString()))
                        {
                            DetailEntity.F_RentStartTime = DateTime.Parse(dt[23].ToString());
                        }

                        if (!string.IsNullOrEmpty(dt[25].ToString()))
                        {
                            DetailEntity.F_RentAge = int.Parse(dt[25].ToString());

                            DetailEntity.F_RentEndTime = ((DateTime)DetailEntity.F_RentStartTime).AddYears((int)DetailEntity.F_RentAge);
                        }
                        // DetailEntity.F_ExpireReminderDate = ((DateTime)DetailEntity.F_RentStartTime).AddYears((int)DetailEntity.F_RentAge);
                        if (!string.IsNullOrEmpty(dt[26].ToString()))
                        {
                            DetailEntity.F_ActualPrice = double.Parse(dt[26].ToString());
                        }
                        DetailEntity.Create();
                        db.Insert(DetailEntity);
                    }

                    if (!string.IsNullOrEmpty(dt[28].ToString()) && dt[28].ToString() != Renter)
                    {
                        Renter = dt[28].ToString();
                        DetailEntity = new DC_ASSETS_HouseRentDetail_InfoEntity();
                        DetailEntity.F_RentDetailId = rentEntity.F_HRDId;
                        DetailEntity.F_Renter = dt[28].ToString();
                        DetailEntity.F_RenterPhone = dt[29].ToString();
                        DetailEntity.F_DoThings = dt[30].ToString();
                        if (!string.IsNullOrEmpty(dt[31].ToString()))
                        {
                            DetailEntity.F_RentArea = double.Parse(dt[21].ToString());
                        }

                        DetailEntity.F_ContractNo = dt[32].ToString();
                        if (!string.IsNullOrEmpty(dt[33].ToString()))
                        {
                            DetailEntity.F_RentStartTime = DateTime.Parse(dt[33].ToString());
                        }
                        if (!string.IsNullOrEmpty(dt[35].ToString()))
                        {
                            DetailEntity.F_RentAge = int.Parse(dt[35].ToString());
                            DetailEntity.F_RentEndTime = ((DateTime)DetailEntity.F_RentStartTime).AddYears((int)DetailEntity.F_RentAge);
                        }
                        if (!string.IsNullOrEmpty(dt[36].ToString()))
                        {
                            DetailEntity.F_ActualPrice = double.Parse(dt[36].ToString());
                        }
                        DetailEntity.Create();
                        db.Insert(DetailEntity);
                    }
                    f++;

                }
                db.Commit();
            }
            catch (Exception ex)
            {
                temp = f.ToString();
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


        public bool ImportRent(DataTable dtTable, ref string msg)
        {


            var db = this.BaseRepository().BeginTrans();
            DC_ASSETS_HouseRentMainEntity entity = null;
            DC_ASSETS_HouseRentDetailEntity rentEntity = null;
            DC_ASSETS_HouseRentDetail_InfoEntity DetailEntity = null;
            DC_ASSETS_HouseInfoEntity houseEntity = null;
            DC_ASSETS_HouseRentDetailEntity oldrentEntity = null;
            string rentnumbers = "0";
            string certNo = string.Empty;
            string Renter = string.Empty;//承租人
            string contractNo = string.Empty;//合同编号
            int f = 0;
           // string msg = string.Empty;

            string temp = string.Empty;
            try
            {
                foreach (DataRow dt in dtTable.Rows)
                {
                    if (dt[0].ToString() == "批次名称" || dt[0].ToString() == "") continue;
                    houseEntity = null;

                       certNo = dt[3].ToString().Trim().Replace("\n", "");

                        houseEntity = db.FindEntity<DC_ASSETS_HouseInfoEntity>(i => i.F_CertificateNo.Trim().Replace("\n", "").Contains(certNo) ||
                        certNo.Contains(i.F_CertificateNo.Trim().Replace("\n", "")));
                   

                    if (houseEntity == null)
                    {

                        msg += certNo;
                        msg += ",";
                    }

                }

                if(msg!=string.Empty)
                {
                    msg += "没有此房产证信息！";
                    return false;
                }

                certNo = string.Empty;
                houseEntity = null;
                foreach (DataRow dt in dtTable.Rows)
                {
                  
                    if (dt[0].ToString() == "批次名称" || dt[0].ToString() == "") continue;
                    Renter = string.Empty;
                    if (dt[0].ToString() != rentnumbers)
                    {
                        rentnumbers = dt[0].ToString();
                        entity = db.FindEntity<DC_ASSETS_HouseRentMainEntity>(i => i.F_RentName == rentnumbers);
                        if (entity == null) continue;
                    }

                    if (dt[3].ToString().Trim().Replace("\n", "") != certNo.Replace("\n", ""))
                    {
                        certNo = dt[3].ToString().Trim().Replace("\n", "");

                        houseEntity = db.FindEntity<DC_ASSETS_HouseInfoEntity>(i => i.F_CertificateNo.Trim().Replace("\n", "").Contains(certNo) ||
                        certNo.Contains(i.F_CertificateNo.Trim().Replace("\n", "")));
                    }
                    if (houseEntity == null)
                    {
                        string aa = "";
                        continue;
                    }

                    if (f == 46)
                    {
                        string eee = "";
                    }
                    rentEntity = null;
                    //var rentList = db.FindList<DC_ASSETS_HouseRentDetailEntity>();
                    //foreach (var item in rentList)
                    //{
                    //   // var mainentity = db.FindEntity<DC_ASSETS_HouseRentMainEntity>(i => i.F_HRMId == item.F_HRMId);
                    //    if (item.F_HouseID == houseEntity.F_HouseID && item.F_Location == dt[2].ToString()&&item.F_HRMId==entity.F_HRMId)
                    //    {
                    //        rentEntity = item;

                    //        break;

                    //    }
                    //}

                    //if ( oldrentEntity!=null&&oldrentEntity.F_HouseID == houseEntity.F_HouseID && oldrentEntity.F_Location == dt[2].ToString() && oldrentEntity.F_HRMId == entity.F_HRMId)
                    //{
                    //    rentEntity = oldrentEntity;
                    //}
                    if (rentEntity == null)
                    {

                        rentEntity = new DC_ASSETS_HouseRentDetailEntity();
                        rentEntity.F_HRMId = entity.F_HRMId;
                        rentEntity.F_HouseID = houseEntity.F_HouseID;
                        if (!string.IsNullOrEmpty(dt[4].ToString()))
                        {
                            rentEntity.F_RentArea = double.Parse(dt[4].ToString());
                        }
                        if (!string.IsNullOrEmpty(dt[5].ToString()))
                        {
                            rentEntity.F_RentReservePrice = double.Parse(dt[5].ToString());
                        }
                        if (!string.IsNullOrEmpty(dt[6].ToString()))
                        {
                            rentEntity.F_RentDeposit = double.Parse(dt[6].ToString());
                        }
                        rentEntity.F_Transferor = dt[1].ToString();
                        //rentEntity.F_RentDeposit = double.Parse(dt[4].ToString());
                        rentEntity.F_Location = dt[2].ToString();
                        // rentEntity.F_LeaseState = "2";//默认招租成功

                        if (!string.IsNullOrEmpty(dt[7].ToString()))
                        {
                            rentEntity.F_LeaseState = "2";

                        }
                        else
                        {
                            rentEntity.F_LeaseState = "3";
                        }
                        rentEntity.F_RentContractNo = dt[11].ToString();

                        rentEntity.Create();
                        db.Insert(rentEntity);
                        oldrentEntity = rentEntity;
                    }
                    else
                    {
                        //if (!string.IsNullOrEmpty(dt[11].ToString()))
                        //{
                        //    rentEntity.F_RentContractNo += "," + dt[11].ToString();
                        //}


                        //rentEntity.Modify(rentEntity.F_HRMId);
                        //db.Update(rentEntity);
                    }

                    if (!string.IsNullOrEmpty(dt[7].ToString()))
                    {
                        Renter = dt[7].ToString();
                        DetailEntity = new DC_ASSETS_HouseRentDetail_InfoEntity();
                        DetailEntity.F_RentDetailId = rentEntity.F_HRDId;
                        DetailEntity.F_Renter = dt[7].ToString();
                        DetailEntity.F_RenterPhone = dt[8].ToString();
                        DetailEntity.F_DoThings = dt[9].ToString();
                        if (!string.IsNullOrEmpty(dt[10].ToString()))
                        {
                            DetailEntity.F_RentArea = double.Parse(dt[10].ToString());
                        }

                        DetailEntity.F_ContractNo = dt[11].ToString();
                        if (!string.IsNullOrEmpty(dt[12].ToString()))
                        {
                            DetailEntity.F_RentStartTime = DateTime.Parse(dt[12].ToString());
                        }
                        if (!string.IsNullOrEmpty(dt[13].ToString()))
                        {
                            DetailEntity.F_RentAge = int.Parse(dt[13].ToString());

                            if (!string.IsNullOrEmpty(dt[12].ToString()))
                            {
                                DetailEntity.F_RentEndTime = ((DateTime)DetailEntity.F_RentStartTime).AddYears((int)DetailEntity.F_RentAge);
                            }
                        }

                        if (!string.IsNullOrEmpty(dt[14].ToString()))
                        {
                            DetailEntity.F_ActualPrice = double.Parse(dt[14].ToString());
                        }

                        if (!string.IsNullOrEmpty(dt[15].ToString()))
                        {
                            DetailEntity.F_RentDeposit = double.Parse(dt[15].ToString());
                        }

                        DetailEntity.Create();
                        db.Insert(DetailEntity);
                    }


                    f++;

                }
                db.Commit();
            }
            catch (Exception ex)
            {
                temp = f.ToString();
                SimpleLogUtil.WriteTextLog("aaa", temp.ToString(), DateTime.Now);
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
            msg = string.Empty;
            return true;


        }

        public bool ImportPlan(DataTable dtTable)
        {

            var db = this.BaseRepository().BeginTrans();
            DC_ASSETS_HouseRentMainEntity entity = null;
            DC_ASSETS_HouseRentDetailEntity rentEntity = null;
            DC_ASSETS_HouseRentDetail_InfoEntity DetailEntity = null;
            DC_ASSETS_HouseInfoEntity houseEntity = null;
            string rentnumbers = "0";
            string address = string.Empty;

            string temp = string.Empty;
            try
            {
                foreach (DataRow dt in dtTable.Rows)
                {
                    if (dt[7].ToString() == "批次") continue;
                    if (dt[7].ToString() != rentnumbers)
                    {
                        rentnumbers = dt[7].ToString();
                        entity = db.FindEntity<DC_ASSETS_HouseRentMainEntity>(i => i.F_RentName == rentnumbers);
                        if (entity == null) continue;

                    }

                    rentEntity = new DC_ASSETS_HouseRentDetailEntity();
                    if (dt[5].ToString() != address)
                    {
                        address = dt[5].ToString();

                        houseEntity = dc_houseBll.GetDC_ASSETS_HouseInfoByAddress(address, dt[1].ToString());
                    }
                    if (houseEntity == null)
                    {
                        string aa = "";
                        continue;
                    }
                    rentEntity.F_HRMId = entity.F_HRMId;
                    rentEntity.F_HouseID = houseEntity.F_HouseID;
                    rentEntity.F_RentArea = double.Parse(dt[2].ToString());
                    rentEntity.F_RentReservePrice = double.Parse(dt[3].ToString());
                    rentEntity.F_RentDeposit = double.Parse(dt[4].ToString());
                    rentEntity.F_Location = address + dt[6].ToString();
                    if (!string.IsNullOrEmpty(dt[8].ToString()))
                    {
                        rentEntity.F_LeaseState = "2";

                    }
                    else
                    {
                        rentEntity.F_LeaseState = "3";
                    }
                    rentEntity.Create();
                    db.Insert(rentEntity);

                    if (!string.IsNullOrEmpty(dt[8].ToString()))
                    {
                        DetailEntity = new DC_ASSETS_HouseRentDetail_InfoEntity();
                        DetailEntity.F_RentDetailId = rentEntity.F_HRDId;
                        DetailEntity.F_Renter = dt[8].ToString();
                        DetailEntity.F_ActualPrice = double.Parse(dt[9].ToString());
                        DetailEntity.Create();
                        db.Insert(DetailEntity);


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

            return true;


        }

        //public bool ImportCertiate(string FileDirectory, string numbersName, ref string Msg)
        //{
        //    var db = this.BaseRepository().BeginTrans();

        //    try
        //    {
        //        var DC_ASSETS_HouseRentDetailEntitylist = this.GetDetail(numbersName);
        //        var HouseInfolist = db.FindList<DC_ASSETS_HouseInfoEntity>();
        //        string[] fileNames = DirFileHelper.GetDirectories(FileDirectory + "/" + numbersName);
        //        bool bCheck = true;
        //        Hashtable ht = new Hashtable();

        //        //  string[] sources = DirFileHelper.GetDirectories(fileNames[0]);
        //        for (int i = 0; i < fileNames.Length; i++)
        //        {
        //            DirectoryInfo info = new DirectoryInfo(fileNames[i]);
        //            String path = info.Parent.Parent.FullName;
        //            // str1 = Regex.Replace(str2, @"\D+", "");
        //            string name = info.Name;
        //            //  string name = Regex.Replace(info.Name, @"\D+", ""); //获取当前路径最后一级文件夹名称

        //            DC_ASSETS_HouseRentDetailEntity detailEntity = null;
        //            foreach (var item in DC_ASSETS_HouseRentDetailEntitylist)
        //            {
        //                if (item.F_RentContractNo.Contains(name))
        //                {
        //                    detailEntity = item;
        //                    break;
        //                }

        //            }

        //            var Entity = db.FindEntity<DC_ASSETS_HouseInfoEntity>(p => p.F_CertificateNo.Contains(name));
        //            //var Entity = db.FindEntity<DC_ASSETS_HouseInfoEntity>(p =>name.Contains(p.F_CertificateNo));

        //            if (detailEntity == null)
        //            {
        //                Msg += name;
        //                Msg += ",";
        //                bCheck = false;
        //            }
        //            if (bCheck)
        //            {
        //                ht.Add(name, detailEntity.F_HRDId);

        //            }
        //            //1.获取文件夹名称 
        //            //文件夹名称为房产证数字，获取房产数据的id,如果没有查到，表明没有查到此
        //            //房产证的数据，然后记录下来，保存到Msg,查到了，用hashtable 保存 键房产证号，值房子id

        //        }
        //        if (!bCheck)
        //        {
        //            Msg += "依据上述房产证号，没有查到房产信息，请核实，再导入！导入失败！";
        //            DirFileHelper.ClearDirectory(FileDirectory + "/" + numbersName);

        //            return false;
        //        }
        //        //如果 Msg不为空，直接返回此号码，表明没有查到数据，不导入，返回false
        //        //如果房产证都找到了，构造附件实体类，按附件格式要求，
        //        //将房产信息移动相应目录下
        //        //然后保存实体类
        //        //然后删除临时文件夹

        //        for (int i = 0; i < fileNames.Length; i++)
        //        {
        //            DirectoryInfo info = new DirectoryInfo(fileNames[i]);
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
        //            //  DC_ASSETS_HouseInfoEntity entity = db.FindEntity<DC_ASSETS_HouseInfoEntity>(HouseId);

        //            DC_ASSETS_HouseRentDetailEntity detailEntity = db.FindEntity<DC_ASSETS_HouseRentDetailEntity>(HouseId);
        //            if (!string.IsNullOrEmpty(detailEntity.F_DetailFiles))
        //            {

        //                fileGuid = detailEntity.F_DetailFiles;
        //            }

        //            string[] filenames = Directory.GetFiles(fileNames[i]);
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

        //            if (string.IsNullOrEmpty(detailEntity.F_DetailFiles))
        //            {

        //                detailEntity.F_DetailFiles = fileGuid;
        //                detailEntity.Modify(detailEntity.F_HRDId);
        //                db.Update(detailEntity);
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

        public bool ImportCertiate(string FileDirectory, string numbersName, ref string Msg)
        {
            var db = this.BaseRepository().BeginTrans();

            try
            {
                var DC_ASSETS_HouseRentDetailEntitylist = this.GetDetail(numbersName);
                //var HouseInfolist = db.FindList<DC_ASSETS_HouseInfoEntity>();
                string[] fileNames = DirFileHelper.GetFileNames(FileDirectory + "/" + numbersName);
                bool bCheck = true;
                Hashtable ht = new Hashtable();

                //  string[] sources = DirFileHelper.GetDirectories(fileNames[0]);
                for (int i = 0; i < fileNames.Length; i++)
                {
                    DirectoryInfo info = new DirectoryInfo(fileNames[i]);
                    String path = info.Parent.Parent.FullName;
                    // str1 = Regex.Replace(str2, @"\D+", "");
                    string name = info.Name.Split('.')[0];
                    string names = name.Replace("【", "[").Replace("】", "]").Trim();
                    //  string name = Regex.Replace(info.Name, @"\D+", ""); //获取当前路径最后一级文件夹名称

                    DC_ASSETS_HouseRentDetailEntity detailEntity = null;
                    foreach (var item in DC_ASSETS_HouseRentDetailEntitylist)
                    {
                        if (!string.IsNullOrEmpty(item.F_RentContractNo))
                        {
                            if ((name == item.F_RentContractNo) || (names == item.F_RentContractNo))
                            {
                                detailEntity = item;
                                break;
                            }
                            //if (item.F_RentContractNo.Contains(name) || item.F_RentContractNo.Contains(names))
                            //{
                            //    detailEntity = item;
                            //    break;
                            //}

                        }
                        //if(item.F_RentContractNo.Contains(name)|| item.F_RentContractNo.Contains(names))
                        //{
                        //    detailEntity = item;
                        //    break;
                        //}

                    }

                    //var Entity = db.FindEntity<DC_ASSETS_HouseInfoEntity>(p => p.F_CertificateNo.Contains(name));
                    //var Entity = db.FindEntity<DC_ASSETS_HouseInfoEntity>(p =>name.Contains(p.F_CertificateNo));

                    if (detailEntity == null)
                    {
                        Msg += name;
                        Msg += ",";
                        bCheck = false;
                    }
                    if (bCheck)
                    {
                        ht.Add(name, detailEntity.F_HRDId);

                    }
                    //1.获取文件夹名称 
                    //文件夹名称为房产证数字，获取房产数据的id,如果没有查到，表明没有查到此
                    //房产证的数据，然后记录下来，保存到Msg,查到了，用hashtable 保存 键房产证号，值房子id

                }
                if (!bCheck)
                {
                    Msg += "依据上述房产证号，没有查到房产信息，请核实，再导入！导入失败！";
                    DirFileHelper.ClearDirectory(FileDirectory + "/" + numbersName);

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
                    string name = info.Name.Split('.')[0];
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
                    //  DC_ASSETS_HouseInfoEntity entity = db.FindEntity<DC_ASSETS_HouseInfoEntity>(HouseId);

                    DC_ASSETS_HouseRentDetailEntity detailEntity = db.FindEntity<DC_ASSETS_HouseRentDetailEntity>(HouseId);
                    if (!string.IsNullOrEmpty(detailEntity.F_DetailFiles))
                    {

                        fileGuid = detailEntity.F_DetailFiles;
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







                    //string[] filenames = Directory.GetFiles(fileNames[i]);
                    //for (int j = 0; j < filenames.Length; j++)
                    //{
                    //    long size = GetFileSize(filenames[j]);
                    //    string filename = Path.GetFileName(filenames[j]);//文件名  “Default.aspx”
                    //    string extension = Path.GetExtension(filenames[j]);//扩展名 “.aspx”
                    //    fileAnnexesEntity = new AnnexesFileEntity();
                    //    fileAnnexesEntity.F_Id = Guid.NewGuid().ToString();
                    //    fileAnnexesEntity.F_FileName = filename;
                    //    fileAnnexesEntity.F_CreateDate = DateTime.Now;
                    //    fileAnnexesEntity.F_FileExtensions = extension;
                    //    fileAnnexesEntity.F_FolderId = fileGuid;
                    //    fileAnnexesEntity.F_FileSize = size.ToString();
                    //    string virtualPath = string.Format("{0}/{1}/{2}/{3}{4}", filePath, user.userId, uploadDate, fileAnnexesEntity.F_Id, extension);
                    //    fileAnnexesEntity.F_FilePath = virtualPath;
                    //    fileAnnexesEntity.F_FileType = extension.Replace(".", "");
                    //    fileAnnexesEntity.F_CreateUserId = user.userId;
                    //    fileAnnexesEntity.F_CreateUserName = user.realName;
                    //    annxesFileibll.SaveEntity(fileGuid, fileAnnexesEntity);//保存附件
                    //    File.Move(filenames[j], virtualPath);//将文件过去

                    //}

                    if (string.IsNullOrEmpty(detailEntity.F_DetailFiles))
                    {

                        detailEntity.F_DetailFiles = fileGuid;
                        detailEntity.Modify(detailEntity.F_HRDId);
                        db.Update(detailEntity);
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

        public long GetFileSize(string sFullName)
        {
            long lSize = 0;
            if (File.Exists(sFullName))
                lSize = new FileInfo(sFullName).Length;
            return lSize;
        }
    }
}
