using Dapper;
using Learun.Application.Organization;
using Learun.DataBase.Repository;
using Learun.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;
using Learun.Application.Base.SystemModule;
using Learun.Application.TwoDevelopment.SystemDemo;

namespace Learun.Application.TwoDevelopment.AssetManager
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-02-13 11:36
    /// 描 述：DC_ASSETS_LandBaseInfo
    /// </summary>
    public class DC_ASSETS_LandBaseInfoService : RepositoryFactory
    {

        private CodeRuleIBLL codeRuleIBLL = new CodeRuleBLL();
        #region 获取数据
        private CompanyIBLL companyIBLL = new CompanyBLL();




        /// <summary>
        /// 获取树形数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetSqlTree(string unit)
        {
            try
            {
                if (string.IsNullOrEmpty(unit))
                {
                    return this.BaseRepository().FindTable(@"SELECT distinct F_Transferor as id , '' as  pid , F_Transferor as name from DC_ASSETS_LandBaseInfo  where F_Transferor !='' GROUP BY F_Assignee,F_Transferor

union
SELECT  f_lbiid as id , F_Transferor as pid , F_LandName as name from DC_ASSETS_LandBaseInfo where F_Transferor !='' GROUP BY f_lbiid,F_LandName,F_Assignee,F_Transferor  ");
                }
                else
                {
                    string sql = string.Format(@"SELECT distinct F_Transferor as id , '' as  pid , F_Transferor as name from DC_ASSETS_LandBaseInfo  where F_Transferor !='' and F_Transferor like '%{0}%'  GROUP BY F_Assignee,F_Transferor

union
SELECT  f_lbiid as id , F_Transferor as pid , F_LandName as name from DC_ASSETS_LandBaseInfo where F_Transferor !='' and F_Transferor like '%{0}%' GROUP BY f_lbiid,F_LandName,F_Assignee,F_Transferor", unit);

                    return this.BaseRepository().FindTable(sql);

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
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_ASSETS_LandBaseInfoEntity> GetPageList(Pagination pagination, string queryJson,string type)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT  top 1000000 ");
                strSql.Append(@"
                t.*
                ");
                strSql.Append("  FROM DC_ASSETS_LandBaseInfo t ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });

                if (!queryParam["F_Assignee"].IsEmpty())
                {
                    dp.Add("F_Assignee", "%" + queryParam["F_Assignee"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_Assignee Like @F_Assignee ");
                }
                if (!queryParam["F_LandNumber"].IsEmpty())
                {
                    dp.Add("F_LandNumber", "%" + queryParam["F_LandNumber"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_LandNumber Like @F_LandNumber ");
                }
                if (!queryParam["F_LandCertificate"].IsEmpty())
                {
                    dp.Add("F_LandCertificate", "%" + queryParam["F_LandCertificate"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_LandCertificate Like @F_LandCertificate ");
                }
                if (!queryParam["F_LandName"].IsEmpty())
                {
                    dp.Add("F_LandName", "%" + queryParam["F_LandName"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_LandName Like @F_LandName ");
                }
                if (!queryParam["F_Transferor"].IsEmpty())
                {
                    dp.Add("F_Transferor", "%" + queryParam["F_Transferor"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_Transferor Like @F_Transferor ");
                }
                if (!queryParam["F_LandUseRight"].IsEmpty())
                {
                    dp.Add("F_LandUseRight", "%" + queryParam["F_LandUseRight"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_LandUseRight Like @F_LandUseRight ");
                }
                //if(type=="1")
                //{
                //    strSql.Append(" And (select count(*) from DC_ASSETS_BuildingBaseInfo g where t.F_LBIId = g.F_LBIId)= 0");
                //}
                //else
                //{
                //    strSql.Append(" And t.F_LBIId in (select g.F_LBIId from DC_ASSETS_BuildingBaseInfo g)");
                //}
                strSql.Append(" order by F_Transferor,F_LandName");

                return this.BaseRepository().FindList<DC_ASSETS_LandBaseInfoEntity>(strSql.ToString(), dp, pagination);
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
        public DC_ASSETS_LandBaseInfoEntity GetDC_ASSETS_LandBaseInfoEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_ASSETS_LandBaseInfoEntity>(keyValue);
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
        public DC_ASSETS_LandBaseInfoEntity GetDC_ASSETS_LandBaseInfoEntity(string landname, string ceticate)
        {
            try
            {
                var list = this.BaseRepository().FindEntity<DC_ASSETS_LandBaseInfoEntity>(i => i.F_LandCertificate == ceticate && i.F_LandName==landname);

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

        public bool IsExitsEntity(string certiface)
        {

            var list = this.BaseRepository().FindEntity<DC_ASSETS_LandBaseInfoEntity>(i => i.F_LandCertificate == certiface);
            if (list != null)
            {
                return true;
            }
            else
            {
                return false;

            }

        }
        public DataTable GetExportComLandbase()
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT * FROM( SELECT ");
                strSql.Append(@"
                b.F_Transferor,b.F_LandName,b.F_ParcelAddress,b.F_Assignee,b.F_LandCertificate,b.F_Area,b.F_LandUseRight,b.F_LandUseNature,b.F_TransferAmount
,d.F_ConstructionName,d.F_ConstructionFloorCount,d.F_ConstructionArea,h.F_HouseName,h.F_CertificateNo,h.F_BuildingValue,h.F_HouseID
                ");
                strSql.Append("  from DC_ASSETS_LandBaseInfo b left join DC_ASSETS_BuildingBaseInfo d on d.F_LBIId=b.F_LBIId  left join DC_ASSETS_HouseInfo h on  d.F_BBIId=h.F_BBIId ) t");
                strSql.Append("  WHERE 1=1 ");
                
                var strSql1 = new StringBuilder();

                strSql1.Append("select d.F_HouseID,d.F_Renter,h.F_YearNumber,h.F_ActualPrice,h.F_CreateDatetime from DC_ASSETS_HouseRentDetail d left join DC_ASSETS_HouseRentIncome h on d.F_HRDId=h.F_HRDId GROUP BY F_HouseID,h.F_YearNumber,h.F_ActualPrice,d.F_Renter,h.F_CreateDatetime ORDER BY h.F_CreateDatetime DESC");


                DataTable dt = this.BaseRepository().FindTable(strSql.ToString());

                DataTable dt1 = this.BaseRepository().FindTable(strSql1.ToString());

                //为已有DataTable添加一新列
                DataColumn dc1 = new DataColumn("f_actualprice", typeof(string));
                DataColumn dc2 = new DataColumn("f_actualprice1", typeof(string));
                DataColumn dc3 = new DataColumn("f_actualprice2", typeof(string));
                DataColumn dc4 = new DataColumn("f_renter", typeof(string));
                DataColumn dc5 = new DataColumn("f_renter1", typeof(string));
                DataColumn dc6 = new DataColumn("f_renter2", typeof(string));

                dt.Columns.Add(dc4);
                dt.Columns.Add(dc1);
                dt.Columns.Add(dc5);
                dt.Columns.Add(dc2);
                dt.Columns.Add(dc6);
                dt.Columns.Add(dc3);

                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    DataRow[] drArr3 = dt1.Select("F_HouseID='" + dt.Rows[i]["F_HouseID"] + "'", "F_CreateDatetime DESC");//排序

                    if (drArr3.Length > 0)
                    {
                        for (int a = 0; a < drArr3.Length; a++)
                        {
                            if (a == 0)
                            {
                                dt.Rows[i]["f_actualprice"] = drArr3[a]["F_ActualPrice"];
                                dt.Rows[i]["f_renter"] = drArr3[a]["F_Renter"];

                            }
                            else if (a == 1)
                            {

                                dt.Rows[i]["f_actualprice1"] = drArr3[a]["F_ActualPrice"];
                                dt.Rows[i]["f_renter1"] = drArr3[a]["F_Renter"];
                            }
                            else if (a == 2)
                            {

                                dt.Rows[i]["f_actualprice2"] = drArr3[a]["F_ActualPrice"];
                                dt.Rows[i]["f_renter2"] = drArr3[a]["F_Renter"];
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
                Dictionary<string, string> dic = new Dictionary<string, string>();
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
        public DataTable ExportData(string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                 F_Transferor,F_LandName,F_ParcelAddress,F_Assignee,F_LandCertificate,F_Area,F_TransferAmount,F_Remarks
                ");
                strSql.Append("  FROM DC_ASSETS_LandBaseInfo t ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["F_LandNumber"].IsEmpty())
                {
                    dp.Add("F_LandNumber", "%" + queryParam["F_LandNumber"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_LandNumber Like @F_LandNumber ");
                }
                if (!queryParam["F_LandCertificate"].IsEmpty())
                {
                    dp.Add("F_LandCertificate", "%" + queryParam["F_LandCertificate"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_LandCertificate Like @F_LandCertificate ");
                }
                DataTable dt = this.BaseRepository().FindTable(strSql.ToString(), dp);
             //   Dictionary<string, string> dic = new Dictionary<string, string>();
             //   dic.Add("F_LandUseNature", "LandUseBy");
               // dic.Add("F_LandUseRight", "LandUseRight");
              //  DataConvertSerivers sevices = new DataConvertSerivers();
             //   sevices.ConvertDataByDataItem(dt, dic);
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


        public DataTable GetLandInfo()
        {

            try
            {
                var strSql = new StringBuilder();
              
                strSql.Append(@"
                 select F_Assignee,count(*) as number from  DC_ASSETS_LandBaseInfo l GROUP BY F_Assignee
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
        
        public DataTable GetLandAssigneeList(string F_Assignee,string SearchValue)
        {

            try
            {
                var strSql = new StringBuilder();

                strSql.Append(@"
               SELECT F_Transferor from DC_ASSETS_LandBaseInfo where F_Assignee='" + F_Assignee + "'");

                if(!string.IsNullOrEmpty(SearchValue))
                {
                    strSql.Append(string.Format(" And F_Transferor like '%{0}%'", SearchValue));

                }
                strSql.Append ("GROUP BY F_Transferor");

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
       public DataTable GetLandAssigneeData(string F_Assignee, string F_Transferor)
        {

            try
            {
                var strSql = new StringBuilder();

                strSql.Append(@"
             	 SELECT
		a.F_Assignee,
	a.F_LandName,
	a.F_ParcelAddress,
	a.F_Transferor,
	a.F_LandCertificate,
	a.F_Area,
	a.F_TransferAmount,
	a.F_Remarks,
	a.F_CenterpointCoordinates,
    a.F_PictureAccessories,
    a.F_ContractAccessories,
  c.F_HouseID	
FROM
	DC_ASSETS_LandBaseInfo a
left join DC_ASSETS_BuildingBaseInfo b on a.F_LBIId=b.F_LBIId
	left join DC_ASSETS_HouseInfo c on c.F_BBIId=b.F_BBIId
	WHERE
	F_Assignee = '" + F_Assignee + "'AND F_Transferor = '"+ F_Transferor + "' ");

                SimpleLogUtil.WriteTextLog("landinfo", strSql.ToString(), DateTime.Now);
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
        public DataTable GetLandAssigneeSearch(string F_Assignee, string SearchValue)
        {
            try
            {
                var strSql = new StringBuilder();

                strSql.Append(@"
SELECT
	a.F_Assignee,
	a.F_LandName,
	a.F_ParcelAddress,
	a.F_Transferor,
	a.F_LandCertificate,
	a.F_Area,
	a.F_TransferAmount,
	a.F_Remarks,
	a.F_CenterpointCoordinates,
    a.F_PictureAccessories,
    a.F_ContractAccessories,
	c.F_HouseID 
FROM
	DC_ASSETS_LandBaseInfo a
	LEFT JOIN DC_ASSETS_BuildingBaseInfo b ON a.F_LBIId = b.F_LBIId
	LEFT JOIN DC_ASSETS_HouseInfo c ON c.F_BBIId = b.F_BBIId 
WHERE
	F_Assignee = '" + F_Assignee + "' AND ( F_LandName LIKE '%"+ SearchValue + "%' OR F_ParcelAddress LIKE '%" + SearchValue + "%' OR F_Transferor LIKE '%" + SearchValue + "%')");

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


        public DataTable GetComLandbase(string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT * FROM ( SELECT ");
                strSql.Append(@"
                b.F_Transferor,b.F_LandName,b.F_ParcelAddress,b.F_Assignee,b.F_LandCertificate,b.F_Area,b.F_LandUseRight,b.F_LandUseNature,b.F_TransferAmount
,d.F_ConstructionName,d.F_ConstructionFloorCount,d.F_ConstructionArea,h.F_HouseName,h.F_CertificateNo,h.F_BuildingValue,h.F_HouseID
                ");
                strSql.Append("  from DC_ASSETS_LandBaseInfo b left join DC_ASSETS_BuildingBaseInfo d on d.F_LBIId=b.F_LBIId  left join DC_ASSETS_HouseInfo h on  d.F_BBIId=h.F_BBIId ) t");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["F_Assignee"].IsEmpty())
                {
                    dp.Add("F_Assignee", "%" + queryParam["F_Assignee"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_Assignee Like @F_Assignee ");
                }
                if (!queryParam["F_LandName"].IsEmpty())
                {
                    dp.Add("F_LandName", "%" + queryParam["F_LandName"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_LandName Like @F_LandName ");
                }
                if (!queryParam["F_ConstructionName"].IsEmpty())
                {
                    dp.Add("F_ConstructionName", "%" + queryParam["F_ConstructionName"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_ConstructionName Like @F_ConstructionName ");
                }
                if (!queryParam["F_HouseName"].IsEmpty())
                {
                    dp.Add("F_HouseName", "%" + queryParam["F_HouseName"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_HouseName Like @F_HouseName ");
                }
                var strSql1 = new StringBuilder();
             
                strSql1.Append("select d.F_HouseID,d.F_Renter,h.F_YearNumber,h.F_ActualPrice,h.F_CreateDatetime from DC_ASSETS_HouseRentDetail d left join DC_ASSETS_HouseRentIncome h on d.F_HRDId=h.F_HRDId GROUP BY F_HouseID,h.F_YearNumber,h.F_ActualPrice,d.F_Renter,h.F_CreateDatetime ORDER BY h.F_CreateDatetime DESC");


                DataTable dt = this.BaseRepository().FindTable(strSql.ToString(), dp);

                DataTable dt1 = this.BaseRepository().FindTable(strSql1.ToString());

                //为已有DataTable添加一新列
                DataColumn dc1 = new DataColumn("f_actualprice", typeof(string));
                DataColumn dc2 = new DataColumn("f_actualprice1", typeof(string));
                DataColumn dc3 = new DataColumn("f_actualprice2", typeof(string));
                DataColumn dc4 = new DataColumn("f_renter", typeof(string));
                DataColumn dc5 = new DataColumn("f_renter1", typeof(string));
                DataColumn dc6 = new DataColumn("f_renter2", typeof(string));

                dt.Columns.Add(dc4);
                dt.Columns.Add(dc1);
                dt.Columns.Add(dc5);
                dt.Columns.Add(dc2);
                dt.Columns.Add(dc6);
                dt.Columns.Add(dc3);
           
                for (int i=0;i<dt.Rows.Count; i++) {

                    DataRow[] drArr3 = dt1.Select("F_HouseID='" + dt.Rows[i]["F_HouseID"] +"'", "F_CreateDatetime DESC");//排序

                    if (drArr3.Length>0) {
                        for (int a=0;a< drArr3.Length; a++) {
                            if (a == 0)
                            {
                                dt.Rows[i]["f_actualprice"] = drArr3[a]["F_ActualPrice"];
                                dt.Rows[i]["f_renter"] = drArr3[a]["F_Renter"];
                                
                            }
                            else if (a == 1)
                            {

                                dt.Rows[i]["f_actualprice1"] = drArr3[a]["F_ActualPrice"];
                                dt.Rows[i]["f_renter1"] = drArr3[a]["F_Renter"];
                            }
                            else if (a == 2)
                            {

                                dt.Rows[i]["f_actualprice2"] = drArr3[a]["F_ActualPrice"];
                                dt.Rows[i]["f_renter2"] = drArr3[a]["F_Renter"];
                            }
                            else {
                                break;
                            }
                        }
                    }
                }

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
                this.BaseRepository().Delete<DC_ASSETS_LandBaseInfoEntity>(t => t.F_LBIId == keyValue);
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


        //public bool ImportLandEntity(DataTable dtTable)
        //{
        //    var db = this.BaseRepository().BeginTrans();
        //    DC_ASSETS_LandBaseInfoEntity entity = null;
        //    var departmentid = "23ac3ac1-097f-4007-8bd2-20fea87fe377";
        //    var userid = "d232107b-3b0a-44c2-992c-964e895f6af3";
        //    int f = 0;
        //    try
        //    {
        //        foreach (DataRow dt in dtTable.Rows)
        //        {
        //            entity = new DC_ASSETS_LandBaseInfoEntity();
        //            if (dt[0].ToString().Trim() == "序号") continue;
        //            if (dt[2].ToString().Trim().IsEmpty()) continue;
        //            ///土地证
        //            entity.F_LandCertificate = dt[5].ToString();
        //           //原单位
        //            entity.F_Transferor = dt[1].ToString();
        //            //土地名称
        //            entity.F_LandName = dt[2].ToString();
        //            //土地坐落
        //            entity.F_ParcelAddress = dt[3].ToString();
        //            //土地所有权
        //            entity.F_Assignee = dt[4].ToString();
        //            //权属证号
        //            entity.F_LandCertificate = dt[5].ToString();
        //            //使用权面积
        //            if (!dt[6].ToString().IsEmpty())
        //            {
        //                entity.F_Area = double.Parse(dt[6].ToString());
        //            }
        //            else
        //            {
        //                entity.F_Area = 0.0;
        //            }
        //            string temp = "1";
        //            //使用权类型
        //            if(dt[7].ToString().Trim()== "划拨")
        //            {
        //                temp = "2";
        //            }
        //            else if (dt[7].ToString().Trim() == "转让")
        //            {
        //                temp = "3";
        //            }
        //            entity.F_LandUseRight = temp;
        //            //土地类用途
        //            temp = "1";
        //            if (dt[8].ToString().Trim() == "办公类")
        //            {
        //                temp = "2";
        //            }
        //            else if (dt[8].ToString().Trim() == "城镇住宅用地")
        //            {
        //                temp = "3";
        //            }
        //            else if (dt[8].ToString().Trim() == "工业用地")
        //            {
        //                temp = "4";
        //            }
        //            else if (dt[8].ToString().Trim() == "其他商服用地")
        //            {
        //                temp = "5";
        //            }
        //            entity.F_LandUseNature = temp;
        //            //账面价值 
        //            if (!dt[9].ToString().IsEmpty())
        //            {
        //                entity.F_TransferAmount = double.Parse(dt[9].ToString());
        //            }
        //            else
        //            {
        //                entity.F_TransferAmount = 0.0;
        //            }

        //            entity.F_CreateDepartmentId = departmentid;
        //            entity.F_CreateUserid = userid;
        //            entity.F_AssetsNumber = codeRuleIBLL.GetBillCode("10011");
        //            codeRuleIBLL.UseRuleSeed("10011");
        //            entity.F_Remarks = dt[10].ToString();
        //            entity.Create();
        //            db.Insert(entity);

        //            f++;

        //        }

        //        db.Commit();
        //    }
        //    catch (Exception ex)
        //    {
        //        string temp = f.ToString();
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

        //    return true;


        //}

        public bool ImportLandEntity(DataTable dtTable)
        {
            var db = this.BaseRepository().BeginTrans();
            DC_ASSETS_LandBaseInfoEntity entity = null;
            DC_ASSETS_BuildingBaseInfoEntity buildingEntity = null;
            DC_ASSETS_HouseInfoEntity houseEntity = null;
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
                    if (f ==4)
                    {
                        string eee = string.Empty;
                    }
                    if (landname != dt[2].ToString())
                    {
                        landname = dt[2].ToString();
                        entity = new DC_ASSETS_LandBaseInfoEntity();
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
                        //使用权面积
                        if (!string.IsNullOrEmpty(dt[6].ToString().Trim()))
                        {
                            entity.F_Area = double.Parse(dt[6].ToString());
                        }
                        else
                        {
                            entity.F_Area = 0.0;
                        }
                        string temp = "1";
                        //使用权类型
                        if (dt[7].ToString().Trim() == "划拨")
                        {
                            temp = "2";
                        }
                        else if (dt[7].ToString().Trim() == "转让")
                        {
                            temp = "3";
                        }
                        entity.F_LandUseRight = temp;
                        //土地类用途
                        temp = "1";
                        if (dt[8].ToString().Trim() == "办公类")
                        {
                            temp = "2";
                        }
                        else if (dt[8].ToString().Trim() == "城镇住宅用地")
                        {
                            temp = "3";
                        }
                        else if (dt[8].ToString().Trim() == "工业用地")
                        {
                            temp = "4";
                        }
                        else if (dt[8].ToString().Trim() == "其他商服用地")
                        {
                            temp = "5";
                        }
                        entity.F_LandUseNature = temp;
                        //账面价值 
                        if (!string.IsNullOrEmpty(dt[9].ToString().Trim()))
                        {
                            entity.F_TransferAmount = double.Parse(dt[9].ToString());
                        }
                        else
                        {
                            entity.F_TransferAmount = 0.0;
                        }

                        entity.F_CreateDepartmentId = departmentid;
                        entity.F_CreateUserid = userid;
                        entity.F_AssetsNumber = codeRuleIBLL.GetBillCode("10011");
                        codeRuleIBLL.UseRuleSeed("10011");
                        // entity.F_Remarks = dt[10].ToString();
                        entity.Create();
                        db.Insert(entity);
                        landid = entity.F_LBIId;
                    }

                    if (buildname != dt[10].ToString())
                    {
                        buildingEntity = new DC_ASSETS_BuildingBaseInfoEntity();
                        buildname = dt[10].ToString();
                        buildingEntity.F_LBIId = landid;
                        buildingEntity.F_ConstructionName = buildname;
                        buildingEntity.F_Address = dt[12].ToString();
                      
                        buildingEntity.F_CommunityCode = "420583102";
                        buildingEntity.F_FormerUnit = dt[1].ToString();
                        if (!string.IsNullOrEmpty(dt[15].ToString().Trim()))
                        {
                            buildingEntity.F_ConstructionFloorCount = int.Parse(dt[15].ToString());
                        }
                        if (!string.IsNullOrEmpty(dt[17].ToString().Trim()))
                        {
                            buildingEntity.F_ConstructionArea = double.Parse(dt[17].ToString());
                        }

                        buildingEntity.F_BuildingClass = "经营性";
                        //if (!dt[18].IsEmpty())
                        //{
                        //    if (dt[18].ToString() == "商业")
                        //    {
                        //        buildingEntity.F_BuildingClass = "经营性";
                        //    }
                        //    else
                        //    {
                        //        buildingEntity.F_BuildingClass = "非经营性";

                        //    }
                        //}

                        if (!string.IsNullOrEmpty(dt[18].ToString().Trim()))
                        {
                            buildingEntity.F_BuildingValue = double.Parse(dt[18].ToString());
                        }
                        buildingEntity.F_IfUse = 0;
                        buildingEntity.Create();
                        db.Insert(buildingEntity);
                        buildid = buildingEntity.F_BBIId;
                    }

                    houseEntity = new DC_ASSETS_HouseInfoEntity();
                    houseEntity.F_BBIId = buildid;
                    houseEntity.F_HouseName = dt[11].ToString();
                  //  houseEntity.F_AssetsNumber = buildingEntity.F_ConstructionCode;

                    houseEntity.F_UseCategories = "4";
                    houseEntity.F_RoomUsage = "3";
                    houseEntity.F_RentPurpose = "4";
                    if (dt[14].ToString() != string.Empty)
                    {
                        houseEntity.F_CertificateNo = dt[14].ToString();
                    }
                    if (!string.IsNullOrEmpty(dt[17].ToString().Trim()))
                    {
                        houseEntity.F_HouseArea = double.Parse(dt[17].ToString());
                    }

                    if (!string.IsNullOrEmpty(dt[18].ToString().Trim()))
                    {
                        houseEntity.F_BuildingValue = double.Parse(dt[18].ToString());
                    }
                    houseEntity.F_Remarks = dt[19].ToString();
                    // houseEntity.F_BuildingValue = buildingEntity.F_BuildingValue;
                    houseEntity.F_IfUse = "0";
                    houseEntity.Create();
                    db.Insert(houseEntity);
                    f++;


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


        //}

        public bool ImportEntity2NoBuilding(DataTable dtTable)
        {
            var db = this.BaseRepository().BeginTrans();
            DC_ASSETS_LandBaseInfoEntity entity = null;
        
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
                    if (dt[1].ToString().Trim().IsEmpty()) continue;
                    if (f > 37)
                    {
                        string eee = string.Empty;
                    }
                    if (landname != dt[1].ToString())
                    {
                        landname = dt[1].ToString();
                        entity = new DC_ASSETS_LandBaseInfoEntity();
                        //原单位
                        entity.F_Transferor = dt[3].ToString();
                        ///土地证
                        //entity.F_LandCertificate = dt[5].ToString();

                        //土地名称
                        entity.F_LandName = dt[1].ToString();
                        //土地坐落
                        entity.F_ParcelAddress = dt[2].ToString();
                        //土地所有权
                        entity.F_Assignee = dt[3].ToString();
                        //权属证号
                        entity.F_LandCertificate = dt[4].ToString();
                        //使用权面积
                        if (!string.IsNullOrEmpty(dt[6].ToString().Trim()))
                        {
                            entity.F_Area = double.Parse(dt[6].ToString());
                        }
                        else
                        {
                            entity.F_Area = 0.0;
                        }
                        string temp = "1";
                        ////使用权类型
                        //if (dt[9].ToString().Trim() == "划拨")
                        //{
                        //    temp = "2";
                        //}
                        //else if (dt[9].ToString().Trim() == "转让")
                        //{
                        //    temp = "3";
                        //}
                        entity.F_LandUseRight = temp;
                        //土地类用途
                        temp = "1";
                        //if (dt[10].ToString().Trim() == "办公类")
                        //{
                        //    temp = "2";
                        //}
                        //else if (dt[10].ToString().Trim() == "城镇住宅用地")
                        //{
                        //    temp = "3";
                        //}
                        //else if (dt[10].ToString().Trim() == "工业用地")
                        //{
                        //    temp = "4";
                        //}
                        //else if (dt[10].ToString().Trim() == "其他商服用地")
                        //{
                        //    temp = "5";
                        //}
                        entity.F_LandUseNature = temp;
                        //账面价值 
                        if (!string.IsNullOrEmpty(dt[6].ToString().Trim()))
                        {
                            entity.F_TransferAmount = double.Parse(dt[6].ToString());
                        }
                        else
                        {
                            entity.F_TransferAmount = 0.0;
                        }

                        entity.F_CreateDepartmentId = departmentid;
                        entity.F_CreateUserid = userid;
                        entity.F_AssetsNumber = codeRuleIBLL.GetBillCode("10011");
                        codeRuleIBLL.UseRuleSeed("10011");
                        // entity.F_Remarks = dt[10].ToString();
                        entity.Create();
                        db.Insert(entity);
                        landid = entity.F_LBIId;
                    }
                
                  
                    f++;


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







        //public bool ImportEntity(DataTable dtTable)
        //{
        //    var db = this.BaseRepository().BeginTrans();
        //    DC_ASSETS_LandBaseInfoEntity entity = null;
        //    var departmentid = "23ac3ac1-097f-4007-8bd2-20fea87fe377";
        //    var userid = "d232107b-3b0a-44c2-992c-964e895f6af3";
        //    Hashtable ht = new Hashtable();
        //    ht.Add("金润源", "金润源");
        //    ht.Add("金源公司", "金源投资");
        //    ht.Add("国资经营中心", "金润源");
        //    ht.Add("粮食公司", "枝江市国家粮食储备");
        //    ht.Add("硕丰公司", "硕丰建设");
        //    ht.Add("路桥公司", "枝江路桥工程");
        //    ht.Add("水务公司", "金润源水务");
        //    int f = 0;
        //    try
        //    {
        //        foreach (DataRow dt in dtTable.Rows)
        //        {
        //            if (!this.IsExitsEntity(dt[3].ToString()))
        //            {
        //                entity = new DC_ASSETS_LandBaseInfoEntity();
        //                entity.F_LandCertificate = dt[3].ToString();
        //                entity.F_ContractNumber = dt[2].ToString();
        //                CompanyEntity companyEntity = companyIBLL.GetList().Where(i => i.F_ShortName == ht[dt[1].ToString()].ToString()).SingleOrDefault();
        //                entity.F_Assignee = companyEntity.F_CompanyId;
        //                entity.F_ParcelAddress = dt[4].ToString();
        //                entity.F_Area = 0;
        //                if (dt[5].ToString() != string.Empty)
        //                    entity.F_Area = double.Parse(dt[5].ToString());

        //                if (dt[6].ToString() != string.Empty)
        //                {
        //                    entity.F_TransferAmount = double.Parse(dt[6].ToString()) * 10000;
        //                }
        //                else
        //                {
        //                    entity.F_TransferAmount = 0;
        //                }
        //                if (dt[7].ToString() != string.Empty)
        //                {
        //                    entity.F_StartDate = DateTime.Parse(dt[7].ToString());
        //                    entity.F_CreateDatetime = entity.F_StartDate;
        //                }
        //                else
        //                    entity.F_CreateDatetime = DateTime.Now;
        //                if (dt[8].ToString() != string.Empty)
        //                {
        //                    entity.F_StartLimit = DateTime.Parse(dt[8].ToString());
        //                }

        //                if (dt[9].ToString() != string.Empty)
        //                {
        //                    entity.F_CompletionDate = DateTime.Parse(dt[9].ToString());
        //                }
        //                entity.F_CreateDepartmentId = departmentid;
        //                entity.F_CreateUserid = userid;
        //                entity.F_AssetsNumber = codeRuleIBLL.GetBillCode("10011");
        //                codeRuleIBLL.UseRuleSeed("10011");

        //                entity.Create();
        //                db.Insert(entity);
        //            }
        //            f++;
        //        }

        //        db.Commit();
        //    }
        //    catch (Exception ex)
        //    {
        //        string temp = f.ToString();
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

        //    return true;
        //}

        /// <summary>
        /// 保存实体数据（新增、修改）
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public void SaveEntity(string keyValue, DC_ASSETS_LandBaseInfoEntity entity)
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

        public IEnumerable<PieChartModel> StatisticsLandInfo()
        {
            string sql = @"  SELECT     isnull(t1.F_ItemName,'未归类') as name,count(*) as value
                      FROM DC_ASSETS_LandBaseInfo t2 left join [LR_Base_DataItemDetail] t1 on t1.F_ItemId = 'ba5161d1-baae-485b-9861-ce7aa1aff90c' 
                        and t1.F_ItemValue = t2.F_LandUseNature
                      group by t1.F_ItemName";
            return this.BaseRepository().FindList<PieChartModel>(sql, new { });
        }

        public DataTable StatisticsLandInfoByArea(DateTime startDate, DateTime endDate)
        {
            DataTable dt = this.BaseRepository().FindTable(@"
                select t.areaname,count(*) as [count],sum(t.area) as area,sum(t.amount) as amount from 
                (SELECT  isnull((select top 1 f_areaname
                from lr_base_area where f_areaid = t2.f_communitycode),'未填写') as areaname,t2.F_Area as area,t2.F_TransferAmount as amount
                FROM DC_ASSETS_LandBaseInfo t2 left join [LR_Base_DataItemDetail] t1 on t1.F_ItemId = 'ba5161d1-baae-485b-9861-ce7aa1aff90c' 
                and t1.F_ItemValue = t2.F_LandUseNature where t2.f_createdatetime > @startDate and t2.f_createdatetime < @endDate) t
                group by t.areaname
            ", new { startDate = startDate, endDate = endDate });
            DataRow row = dt.NewRow();
            row["areaname"] = "合计";
            row["count"] = DBNull.Value;
            row["area"] = dt.AsEnumerable().Sum(c => Convert.ToDecimal(c["area"]));
            row["amount"] = dt.AsEnumerable().Sum(c => Convert.ToDecimal(c["amount"]));
            dt.Rows.Add(row);
            return dt;
        }
        public DataTable StatisticsLandInfoByAreaEx(DateTime startDate, DateTime endDate)
        {
            DataTable dt = this.BaseRepository().FindTable(@"
               select t.areaname,t.type,count(*) as [count],sum(t.area) as area,sum(t.amount) as amount from 
                (SELECT  isnull((select top 1 f_areaname
                from lr_base_area where f_areaid = t2.f_communitycode),'未填写') as areaname,t2.F_Area as area,t2.F_TransferAmount as amount,
                isnull(t1.f_itemname,'未填写') as type
                FROM DC_ASSETS_LandBaseInfo t2 left join [LR_Base_DataItemDetail] t1 on t1.F_ItemId = 'ba5161d1-baae-485b-9861-ce7aa1aff90c' 
                and t1.F_ItemValue = t2.F_LandUseNature where t2.f_createdatetime > @startDate and t2.f_createdatetime < @endDate) t
                group by t.areaname,t.type
            ", new { startDate = startDate, endDate = endDate });
            return dt;
        }
        #endregion

    }
    public class PieChartModel
    {
        public string value { get; set; }
        public string name { get; set; }
    }
}
