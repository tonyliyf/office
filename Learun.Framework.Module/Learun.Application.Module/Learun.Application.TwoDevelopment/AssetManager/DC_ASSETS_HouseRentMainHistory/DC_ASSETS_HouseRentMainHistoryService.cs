using Dapper;
using Learun.DataBase.Repository;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;
using Learun.Application.TwoDevelopment.SystemDemo;

namespace Learun.Application.TwoDevelopment.AssetManager
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-02-16 13:45
    /// 描 述：DC_ASSETS_HouseRentMain
    /// </summary>
    public class DC_ASSETS_HouseRentMainHistoryService : RepositoryFactory
    {
        private DC_ASSETS_HouseRentDetailService detailService = new DC_ASSETS_HouseRentDetailService();
      private DC_ASSETS_HouseInfoIBLL dc_houseBll = new DC_ASSETS_HouseInfoBLL();
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
        public IEnumerable<DC_ASSETS_HouseRentMainHistoryEntity> GetPageList(Pagination pagination, string queryJson)
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
                return this.BaseRepository().FindList<DC_ASSETS_HouseRentMainHistoryEntity>(strSql.ToString(), dp, pagination);
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
        public IEnumerable<DC_ASSETS_HouseRentMainHistoryEntity> GetMainList()
        {
            try
            {

                return this.BaseRepository().FindList<DC_ASSETS_HouseRentMainHistoryEntity>().OrderBy(i => i.F_RentTime); 
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
                              from DC_ASSETS_HouseRentDetailHistory t1,DC_ASSETS_HouseInfo t2
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
        public DC_ASSETS_HouseRentMainHistoryEntity GetDC_ASSETS_HouseRentMainEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_ASSETS_HouseRentMainHistoryEntity>(keyValue);
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
        public DC_ASSETS_HouseRentDetaiHistoryEntity GetDC_ASSETS_HouseRentDetailEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_ASSETS_HouseRentDetaiHistoryEntity>(t => t.F_HRMId == keyValue);
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
                db.Delete<DC_ASSETS_HouseRentMainHistoryEntity>(t => t.F_HRMId == keyValue);
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
        public void SaveEntity(string keyValue, DC_ASSETS_HouseRentMainHistoryEntity entity, List<DC_ASSETS_HouseRentDetaiHistoryEntity> dC_ASSETS_HouseRentDetailList)
        {
            var db = this.BaseRepository().BeginTrans();
            try
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    var dC_ASSETS_HouseRentMainEntityTmp = GetDC_ASSETS_HouseRentMainEntity(keyValue);
                    entity.Modify(keyValue);
                    db.Update(entity);
                    db.Delete<DC_ASSETS_HouseRentDetaiHistoryEntity>(t => t.F_HRMId == dC_ASSETS_HouseRentMainEntityTmp.F_HRMId);
                    if (dC_ASSETS_HouseRentDetailList != null)
                    {
                        foreach (DC_ASSETS_HouseRentDetaiHistoryEntity item in dC_ASSETS_HouseRentDetailList)
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
                        foreach (DC_ASSETS_HouseRentDetaiHistoryEntity item in dC_ASSETS_HouseRentDetailList)
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
        public void SaveEntity(string keyValue, DC_ASSETS_HouseRentMainHistoryEntity entity)
        {
            var db = this.BaseRepository().BeginTrans();
            try
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                   
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
        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public DataTable ExportData1(string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                var queryParam = queryJson.ToJObject();
                strSql.Append("select m.F_RentName, d.*,m.F_Unit from  DC_ASSETS_HouseRentDetailHistory d join  dc_assets_houseRentMainHistory m on m.F_HRMId =d.F_HRMId  ");
                strSql.Append("  WHERE 1=1  ");

                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["F_Transferor"].IsEmpty())
                {
                    dp.Add("F_Transferor", "%" + queryParam["F_Transferor"].ToString() + "%", DbType.String);
                    strSql.Append(" AND F_Transferor Like @F_Transferor ");
                }

                if (!queryParam["F_Address"].IsEmpty())
                {
                    dp.Add("F_Address", "%" + queryParam["F_Address"].ToString() + "%", DbType.String);
                    strSql.Append(" AND F_Location Like @F_Address ");
                }

                if (!queryParam["F_Assignee"].IsEmpty())
                {
                    dp.Add("F_Assignee", "%" + queryParam["F_Assignee"].ToString() + "%", DbType.String);
                    strSql.Append(" AND F_Unit Like @F_Assignee ");
                }
                if (!queryParam["F_HRMId"].IsEmpty())
                {
                    dp.Add("F_HRMId", "%" + queryParam["F_HRMId"].ToString() + "%", DbType.String);
                    strSql.Append(" AND d.F_HRMId Like @F_HRMId ");
                }
                DataTable dt = this.BaseRepository().FindTable(strSql.ToString(), dp);
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("F_LeaseState", "HouseRentState");
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

                    if(dt[2].ToString()== "前进路北17号院内1-1")
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
                    foreach(var item in rentList)
                    {
                        if(item.F_HouseID == houseEntity.F_HouseID &&item.F_Location == dt[2].ToString())
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

                    if(!string.IsNullOrEmpty(dt[8].ToString()))
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

                    if (!string.IsNullOrEmpty(dt[18].ToString())&& dt[18].ToString()!=Renter)
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


        public bool ImportRent(DataTable dtTable)
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

            string temp = string.Empty;
            try
            {
                foreach (DataRow dt in dtTable.Rows)
                {
                    if (dt[0].ToString() == "批次名称"|| dt[0].ToString() =="") continue;
                    Renter = string.Empty;
                    if (dt[0].ToString() != rentnumbers)
                    {
                        rentnumbers = dt[0].ToString();
                        entity = db.FindEntity<DC_ASSETS_HouseRentMainEntity>(i => i.F_RentName == rentnumbers);
                        if (entity == null) continue;
                    }
                
                    if (dt[3].ToString() != certNo)
                    {
                        certNo = dt[3].ToString();

                        houseEntity = db.FindEntity<DC_ASSETS_HouseInfoEntity>(i => i.F_CertificateNo == certNo);
                    }
                    if (houseEntity == null)
                    {
                        string aa = "";
                        continue;
                    }

                    if(f==46)
                    {
                        string eee = "";
                    }
                    rentEntity = null;
                    var rentList = db.FindList<DC_ASSETS_HouseRentDetailEntity>();
                    foreach (var item in rentList)
                    {
                       // var mainentity = db.FindEntity<DC_ASSETS_HouseRentMainEntity>(i => i.F_HRMId == item.F_HRMId);
                        if (item.F_HouseID == houseEntity.F_HouseID && item.F_Location == dt[2].ToString()&&item.F_HRMId==entity.F_HRMId)
                        {
                            rentEntity = item;

                            break;

                        }
                    }

                    if ( oldrentEntity!=null&&oldrentEntity.F_HouseID == houseEntity.F_HouseID && oldrentEntity.F_Location == dt[2].ToString() && oldrentEntity.F_HRMId == entity.F_HRMId)
                    {
                        rentEntity = oldrentEntity;
                    }
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
                        rentEntity.F_LeaseState = "2";//默认招租成功
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

        public bool ImportPlan(DataTable dtTable)
        {

            var db = this.BaseRepository().BeginTrans();
            DC_ASSETS_HouseRentMainHistoryEntity entity = null;
            DC_ASSETS_HouseRentDetaiHistoryEntity rentEntity = null;
            DC_ASSETS_HouseRentDetail_InfoHistoryEntity DetailEntity = null;
            string rentnumbers = "0";
            string address = string.Empty;
            DC_ASSETS_HouseRentMainHistoryEntity entity1 = new DC_ASSETS_HouseRentMainHistoryEntity();
            string temp = string.Empty;
            string F_HRMId = "";
       
            try
            {
                foreach (DataRow dt in dtTable.Rows)
                {
                    if (dt[7].ToString() == "批次") continue;
                    if (dt[1].ToString() == ""&& dt[2].ToString() == ""&& dt[3].ToString() == ""&& dt[7].ToString() == "") continue;
                    if (dt[7].ToString() != rentnumbers)
                    {
                        rentnumbers = dt[7].ToString();
                        entity = db.FindEntity<DC_ASSETS_HouseRentMainHistoryEntity>(i => i.F_RentName== rentnumbers);
                        //判断批次是否存在，存在则跳过，不存在则新增
                        if (entity == null)
                        {

                            entity1.F_RentName = dt[7].ToString();
                            //中标承租人不为空，招租状态为待租，为空为进行中
                            if (dt[8].ToString() == "")
                            {
                                entity1.F_RentState = "1";
                            }
                            entity1.F_RentState = "3";
                            entity1.F_Unit = "金润源";
                       
                            //添加招租计划
                            entity1.Create();
                            db.Insert(entity1);
                            F_HRMId = entity1.F_HRMId;


                        }
                        else {
                            F_HRMId = entity.F_HRMId;
                        }
                      
                    }
                    //entity = db.FindEntity<DC_ASSETS_HouseRentMainHistoryEntity>(i => i.F_RentName == rentnumbers);
                    rentEntity = new DC_ASSETS_HouseRentDetaiHistoryEntity();
        
                    rentEntity.F_HRMId = F_HRMId;
                    
                    if (dt[4].ToString() == "")
                    {
                        rentEntity.F_RentDeposit = 0;
                    }
                    else {
                      
                        rentEntity.F_RentDeposit = double.Parse(dt[4].ToString());
                    }
                    if (dt[2].ToString() == "")
                    {
                        rentEntity.F_RentArea = 0;
                    }
                    else
                    {
                        rentEntity.F_RentArea = double.Parse(dt[2].ToString());
                    }
                    if (dt[3].ToString() == "")
                    {
                        rentEntity.F_RentReservePrice = 0;
                    }
                    else
                    {
                        rentEntity.F_RentReservePrice = double.Parse(dt[3].ToString());
                    }
                    rentEntity.F_Renter= dt[8].ToString();
                    rentEntity.F_Location = dt[5].ToString()+ dt[6].ToString();
                    rentEntity.F_BuildingAddress = dt[6].ToString();
                    if (!string.IsNullOrEmpty(dt[8].ToString()))
                    {
                        rentEntity.F_LeaseState = "2";

                    }
                    else
                    {
                        rentEntity.F_LeaseState ="3";
                    }
                    //原单位F_FormerUnit
                    rentEntity.F_Transferor = dt[1].ToString();
                    rentEntity.F_FormerUnit = "金润源";
                     rentEntity.Create();
                    //添加租赁明细
                    db.Insert(rentEntity);

                    if(!string.IsNullOrEmpty(dt[8].ToString()))
                    {
                        DetailEntity = new DC_ASSETS_HouseRentDetail_InfoHistoryEntity();
                        DetailEntity.F_RentDetailId = rentEntity.F_HRDId;
                        DetailEntity.F_Renter = dt[8].ToString();
                        if (dt[9].ToString() == "")
                        {
                            DetailEntity.F_ActualPrice = 0;
                        }
                        else {
                            DetailEntity.F_ActualPrice = double.Parse(dt[9].ToString());
                        }
                        
                        DetailEntity.Create();
                        //租赁信息
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
    }
}
