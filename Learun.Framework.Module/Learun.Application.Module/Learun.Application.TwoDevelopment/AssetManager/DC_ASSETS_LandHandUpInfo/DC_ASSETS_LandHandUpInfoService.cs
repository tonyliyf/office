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
    /// 日 期：2019-05-23 12:01
    /// 描 述：DC_ASSETS_LandHandUpInfo
    /// </summary>
    public class DC_ASSETS_LandHandUpInfoService : RepositoryFactory
    {
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
                 t. F_ManagerDept,
                 t.F_State,
                t.F_LandNo,
               t.F_ContractNo,
                t.F_Area, t.F_TotalMoney,
                 t.F_LandUseRight,
                t.F_StartDate,
                t.F_StartEndDate,
                t.F_EndDate,
                  t.F_Address,
                t.F_LandHandUpid
                              
               
                
                ");
                strSql.Append("  FROM DC_ASSETS_LandHandUpInfo t ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["StartTime"].IsEmpty() && !queryParam["EndTime"].IsEmpty())
                {
                    dp.Add("startTime", queryParam["StartTime"].ToDate(), DbType.DateTime);
                    dp.Add("endTime", queryParam["EndTime"].ToDate(), DbType.DateTime);
                    strSql.Append(" AND ( t.F_StartDate >= @startTime AND t.F_StartDate <= @endTime ) ");
                }
                DataTable dt = this.BaseRepository().FindTable(strSql.ToString(), dp);
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("F_State", "LandHandUpInfoState");
                dic.Add("F_LandUseRight", "LandUseRight");
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
        public IEnumerable<DC_ASSETS_LandHandUpInfoEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.*
                ");
                strSql.Append("  FROM DC_ASSETS_LandHandUpInfo t ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["StartTime"].IsEmpty() && !queryParam["EndTime"].IsEmpty())
                {

                    if (queryParam["StartTime"].ToString() != "1753-01-01" && queryParam["EndTime"].ToString() != "3000-01-01")
                    {
                        dp.Add("startTime", queryParam["StartTime"].ToDate(), DbType.DateTime);
                        dp.Add("endTime", queryParam["EndTime"].ToDate(), DbType.DateTime);
                        strSql.Append(" AND ( t.F_StartDate >= @startTime AND t.F_StartDate <= @endTime ) ");
                    }
                   
                }
                if (!queryParam["F_ManagerDept"].IsEmpty())
                {
                    dp.Add("F_ManagerDept", queryParam["F_ManagerDept"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_ManagerDept = @F_ManagerDept ");
                }

                if (!queryParam["F_State"].IsEmpty())
                {
                    dp.Add("F_State", queryParam["F_State"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_State = @F_State ");
                }
                if (!queryParam["F_ContractNo"].IsEmpty())
                {
                    dp.Add("F_ContractNo", queryParam["F_ContractNo"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_ContractNo = @F_ContractNo ");
                }
                if (!queryParam["F_LandNo"].IsEmpty())
                {
                    dp.Add("F_LandNo", queryParam["F_LandNo"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_LandNo = @F_LandNo ");
                }
                return this.BaseRepository().FindList<DC_ASSETS_LandHandUpInfoEntity>(strSql.ToString(),dp, pagination);
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
        /// <returns></returns>
        public DataTable GetLandUpInfo()
        {
            try
            {
                var strSql = new StringBuilder();
              
                strSql.Append(@"
               select F_ManagerDept,count(*) as number from  DC_ASSETS_LandHandUpInfo l GROUP BY F_ManagerDept
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
        /// <returns></returns>
        public DataTable GetLandHandlist()
        {
            try
            {
                var strSql = new StringBuilder();

                strSql.Append(@"
               select F_ManagerDept number from  DC_ASSETS_LandHandUpInfo  GROUP BY F_ManagerDept
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
        public DataTable GetLandHandSearch(string F_Assignee, string SearchValue)
        {
            try
            {
                var strSql = new StringBuilder();

                strSql.Append(@"
               select F_LandNo,F_ContractNo,F_Address,F_State,F_Area,F_TotalMoney,F_ManagerDept,F_StartDate,F_StartEndDate,F_EndDate,F_Remarks,F_LandUseRight from DC_ASSETS_LandHandUpInfo where F_ManagerDept='" + F_Assignee + "' and (F_LandNo like '%"+ SearchValue + "%' or F_ContractNo like '%"+ SearchValue + "%' or F_Address like '%"+ SearchValue + "%')");

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
        /// 获取DC_ASSETS_LandHandUpInfo表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_ASSETS_LandHandUpInfoEntity GetDC_ASSETS_LandHandUpInfoEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_ASSETS_LandHandUpInfoEntity>(keyValue);
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


        public bool Import_LandHandUpInfoEntity(DataTable dtTable)
        {
            var db = this.BaseRepository().BeginTrans();
            DC_ASSETS_LandHandUpInfoEntity entity = null;
            //  var departmentid = "23ac3ac1-097f-4007-8bd2-20fea87fe377";
            //  var userid = "d232107b-3b0a-44c2-992c-964e895f6af3";
            string[] temp = { "国资经营中心","金润源", "金源公司", "金源","高投" };
            string temp1 = string.Empty;
            int f = 0;
            try
            {
                foreach (DataRow dt in dtTable.Rows)
                {
                    entity = new DC_ASSETS_LandHandUpInfoEntity();
                    if (dt[0].ToString().Trim() == "序号") continue;
                    temp1 = dt[1].ToString().Trim();
                    if (!temp.AsList().Contains(temp1)) continue;
                    if(temp1=="金源公司")
                    {
                        temp1 = "金源";
                    }
                    if (temp1 == "国资经营中心")
                    {
                        temp1 = "国资中心";
                    }
                    if (temp1 == "高投")
                    {
                        temp1 = "金润源";
                    }
                    entity.F_ManagerDept = temp1;
                    if(dt[2].ToString()=="抵押")
                    {
                        entity.F_State = "6";
                    }
                    else if(dt[2].ToString()== "需解除合同")
                    {
                        entity.F_State = "1";

                    }
                    else
                    {
                        entity.F_State = "3";
                    }

                    entity.F_LandNo = dt[3].ToString();
                    if(dt[4].ToString()=="")
                    {
                        string aa = "11";
                    }
                    entity.F_ContractNo = dt[4].ToString();
                    if (!dt[5].IsEmpty())
                    {
                        entity.F_Area = double.Parse(dt[5].ToString());
                    }
                    if (!dt[6].IsEmpty())
                    {
                        entity.F_TotalMoney = double.Parse(dt[6].ToString());
                    }
                    entity.F_LandUseRight = dt[7].ToString();
                    // entity.F_Address = dt[4].ToString();

                    if (!dt[8].IsEmpty())
                    {
                        entity.F_StartDate =DateTime.Parse(dt[8].ToString());

                    }
                    if (!dt[9].IsEmpty())
                    {
                        entity.F_StartEndDate = DateTime.Parse(dt[9].ToString());

                    }
                    if (!dt[10].IsEmpty())
                    {
                        entity.F_EndDate = DateTime.Parse(dt[10].ToString());

                    }
                    entity.F_Address = dt[11].ToString();
                    entity.F_Remarks = dt[12].ToString();
                    //entity.F_State = dt[11].ToString();
                    entity.Create();
                    db.Insert(entity);

                    f++;

                }

                db.Commit();
            }
            catch (Exception ex)
            {
               temp1 = f.ToString();
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
                this.BaseRepository().Delete<DC_ASSETS_LandHandUpInfoEntity>(t=>t.F_LandHandUpid == keyValue);
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
        public void SaveEntity(string keyValue, DC_ASSETS_LandHandUpInfoEntity entity)
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
