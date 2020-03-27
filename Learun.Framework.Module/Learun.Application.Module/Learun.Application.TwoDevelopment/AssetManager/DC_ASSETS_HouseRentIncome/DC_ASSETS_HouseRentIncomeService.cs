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
    /// 日 期：2019-02-16 17:45
    /// 描 述：DC_ASSETS_HouseRentIncome
    /// </summary>
    public class DC_ASSETS_HouseRentIncomeService : RepositoryFactory
    {
        #region 获取数据
        private DC_ASSETS_HouseRentDetailService rentDetail = new DC_ASSETS_HouseRentDetailService();
        private DC_Assets_HouseRentCPIService cpiService = new DC_Assets_HouseRentCPIService();

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public DC_ASSETS_HouseRentIncomeEntityComplex GetList(string F_HRInId)
        {
            try
            {
                var strSql = new StringBuilder();

                strSql.Append("SELECT top 3 i.F_ContractNumber,i.F_ActualPrice,i.F_YearNumber,d.F_RentStartTime,d.F_RentEndTime,d.F_RenterPhone,d.F_Renter,h.F_HouseName FROM DC_ASSETS_HouseRentIncome i,DC_ASSETS_HouseRentDetail d,DC_ASSETS_HouseInfo h WHERE i.F_HRDId = d.F_HRDId AND d.F_HouseID = h.F_HouseID and h.F_HouseID = '" + F_HRInId + "' ORDER BY i.F_CreateDatetime DESC");

                IEnumerable<DC_ASSETS_ComLandBaseInfo> num = this.BaseRepository().FindList<DC_ASSETS_ComLandBaseInfo>(strSql.ToString());

                DC_ASSETS_HouseRentIncomeEntityComplex list = new DC_ASSETS_HouseRentIncomeEntityComplex();
                int i = 0;
                foreach (DC_ASSETS_ComLandBaseInfo obj in num)
                {

                    if (i == 0)
                    {
                        list.F_ContractNumber = obj.F_ContractNumber;
                        list.F_ActualPrice = obj.F_ActualPrice;
                        list.F_YearNumber = obj.F_YearNumber;
                        list.F_Renter = obj.F_Renter;
                        list.F_RenterPhone = obj.F_RenterPhone;
                        list.F_RentStartTime = obj.F_RentStartTime;
                        list.F_RentEndTime = obj.F_RentEndTime;
                        list.F_Code = obj.F_YearNumber + "年租金";
                        list.F_HouseName = obj.F_HouseName;
                        i++;
                    }
                    else if (i == 1)
                    {
                        list.F_ContractNumber1 = obj.F_ContractNumber;
                        list.F_ActualPrice1 = obj.F_ActualPrice;
                        list.F_YearNumber1 = obj.F_YearNumber;
                        list.F_Renter1 = obj.F_Renter;
                        list.F_RenterPhone1 = obj.F_RenterPhone;
                        list.F_RentStartTime1 = obj.F_RentStartTime;
                        list.F_RentEndTime1 = obj.F_RentEndTime;
                        list.F_Code1 = obj.F_YearNumber + "年租金";
                        list.F_HouseName1 = obj.F_HouseName;
                        i++;
                    }
                    else if (i == 2)
                    {

                        list.F_ContractNumber2 = obj.F_ContractNumber;
                        list.F_ActualPrice2 = obj.F_ActualPrice;
                        list.F_YearNumber2 = obj.F_YearNumber;
                        list.F_Renter2 = obj.F_Renter;
                        list.F_RenterPhone2 = obj.F_RenterPhone;
                        list.F_RentStartTime2 = obj.F_RentStartTime;
                        list.F_RentEndTime2 = obj.F_RentEndTime;
                        list.F_Code2 = obj.F_YearNumber + "年租金";
                        list.F_HouseName2 = obj.F_HouseName;
                        i++;
                    }

                }


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
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_ASSETS_HouseRentIncomeEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.* 
                ");
                strSql.Append("  FROM DC_ASSETS_HouseRentIncome t ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["StartTime"].IsEmpty() && !queryParam["EndTime"].IsEmpty())
                {
                    dp.Add("startTime", queryParam["StartTime"].ToDate(), DbType.DateTime);
                    dp.Add("endTime", queryParam["EndTime"].ToDate(), DbType.DateTime);
                    strSql.Append(" AND ( t.F_PaymentDate >= @startTime AND t.F_PaymentDate <= @endTime ) ");
                }
                if (!queryParam["F_YearNumber"].IsEmpty())
                {
                    dp.Add("F_YearNumber", "%" + queryParam["F_YearNumber"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_YearNumber Like @F_YearNumber ");
                }
                if (!queryParam["F_Year"].IsEmpty())
                {
                    dp.Add("F_Year", "%" + queryParam["F_Year"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_Year Like @F_Year ");
                }
                if (!queryParam["F_ContractNumber"].IsEmpty())
                {
                    dp.Add("F_ContractNumber", "%" + queryParam["F_ContractNumber"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_ContractNumber Like @F_ContractNumber ");
                }
                if (!queryParam["F_HRDId"].IsEmpty())
                {
                    dp.Add("F_HRDId", queryParam["F_HRDId"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_HRDId = @F_HRDId ");
                }
                return this.BaseRepository().FindList<DC_ASSETS_HouseRentIncomeEntity>(strSql.ToString(), dp, pagination);
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


        public IEnumerable<DC_ASSETS_HouseRentIncomeEntity> GetDC_ASSETS_HouseRentIncomeEntityList(string keyValue)
        {

            try
            {
                var strSql = new StringBuilder();

                string sql = @"  select  * 
                              from DC_ASSETS_HouseRentIncome t1
                              where  t1.F_HRDId=@F_RentDetailId";
                return this.BaseRepository().FindList<DC_ASSETS_HouseRentIncomeEntity>(sql, new { F_RentDetailId = keyValue });

             
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
        /// 获取DC_ASSETS_HouseRentIncome表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_ASSETS_HouseRentIncomeEntity GetDC_ASSETS_HouseRentIncomeEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_ASSETS_HouseRentIncomeEntity>(keyValue);
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
        /// 获取DC_ASSETS_HouseRentIncome表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public List<DC_ASSETS_HouseRentIncomeEntity> GetDC_ASSETS_HouseRentIncomeEntityByHDid(string keyValue)
        {
            var db = this.BaseRepository().BeginTrans();
            List<DC_ASSETS_HouseRentIncomeEntity> list;
            try
            {
                DC_Assets_HouseRentCPIEntity current = cpiService.GetDC_Assets_HouseRentCPIEntityByYear(DateTime.Now.Year.ToString());
                DC_ASSETS_HouseRentIncomeEntity temp;
                list = db.FindList<DC_ASSETS_HouseRentIncomeEntity>(t => t.F_HRDId == keyValue).AsList<DC_ASSETS_HouseRentIncomeEntity>(); ;
                int count = 0;
                foreach (var item in list)
                {
                    count++;
                    current = cpiService.GetDC_Assets_HouseRentCPIEntityByYear(((DateTime)item.F_PlanPayDate).Year.ToString());
                    if (current != null && current.F_Year != null)
                    {
                        if (item.F_CPI != current.F_Value)
                        {
                            item.F_CPI = current.F_Value;
                            if (item.F_ActualPrice.HasValue)
                            {
                                var tempww = (double)(item.F_ActualPrice * item.F_CPI);
                                item.F_PlanPrice = Math.Round(tempww, 2);
                                //item.F_PlanPrice = item.F_ActualPrice * item.F_CPI;
                                item.Modify(item.F_HRInId);
                                db.Update(item);
                            }
                        }

                    }
                }
                if (count > 0)
                {
                    db.Commit();
                    return list;
                }
                else
                {

                    list = new List<DC_ASSETS_HouseRentIncomeEntity>();
                    var detail = rentDetail.GetHouseRentDetailEntity(keyValue);
                    var detailInfo = rentDetail.GetDC_ASSETS_HouseRentDetailInfoList(keyValue);

                    foreach (var info in detailInfo)
                    {
                        if (info.F_RentAge != 0)
                        {
                            for (int i = 0; i < info.F_RentAge; i++)
                            {
                                temp = new DC_ASSETS_HouseRentIncomeEntity();
                                temp.F_ContractNumber = info.F_ContractNo;
                                temp.F_Renter = info.F_Renter;
                                temp.F_PlanPayDate = ((DateTime)info.F_RentStartTime).AddYears(i + 1).AddDays(-1);
                                current = cpiService.GetDC_Assets_HouseRentCPIEntityByYear(((DateTime)temp.F_PlanPayDate).Year.ToString());
                                if (current != null && current.F_Year != null)
                                {                                
                                    temp.F_CPI = current.F_Value;
                                    if (info.F_ActualPrice.HasValue)
                                    {
                                        var tempww = (double)(info.F_ActualPrice * temp.F_CPI);
                                        temp.F_PlanPrice = Math.Round(tempww, 2);
                                    }

                                }
                                else
                                {
                                    temp.F_PlanPrice = info.F_ActualPrice;//如果没设CPI指数，默认为最低价格
                                    temp.F_CPI = 1;//如果没有设置，默认为1
                                   // temp.F_CPI = 1;

                                 }
                                temp.F_HRDId = keyValue;
                                temp.F_RentDetailId = info.F_RentInfoId;
                                temp.Create();
                                db.Insert(temp);
                                list.Add(temp);

                            }

                        }



                    }
                    db.Commit();


                }

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
                this.BaseRepository().Delete<DC_ASSETS_HouseRentIncomeEntity>(t => t.F_HRInId == keyValue);
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
        public void SaveEntity(string keyValue, DC_ASSETS_HouseRentIncomeEntity entity)
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

        public IEnumerable<EChartModel> StatisticsForEChart()
        {
            return this.BaseRepository().FindList<EChartModel>(@"
               select left(CONVERT(varchar(100), f_createdatetime, 112),6) as [month],sum(f_actualprice) as [money],'房屋' as [type]
            from dc_assets_houserentincome group by left(CONVERT(varchar(100), f_createdatetime, 112),6)
            union
            select  left(CONVERT(varchar(100), f_createdatetime, 112),6) as [month],sum(f_actualprice) as [money],'广告牌' as [type]
            from dc_assets_busstopbillboardsrentincome group by left(CONVERT(varchar(100), f_createdatetime, 112),6)
            ");
        }


        /// <summary>
        /// 保存实体数据（新增、修改）
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public void SaveEntity(string keyValue,  List<DC_ASSETS_HouseRentIncomeEntity> list)
        {
           

            var db = this.BaseRepository().BeginTrans();
            try
            {
                
                    foreach (DC_ASSETS_HouseRentIncomeEntity item in list)
                    {
                        item.Modify(item.F_HRInId);
                        db.Update(item);
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
    }
}
