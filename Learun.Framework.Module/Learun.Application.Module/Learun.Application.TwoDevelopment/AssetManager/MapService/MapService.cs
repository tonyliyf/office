using Dapper;
using Learun.Application.TwoDevelopment.ProjectManager;
using Learun.DataBase.Repository;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Learun.Application.TwoDevelopment.AssetManager
{
    public class MapService : RepositoryFactory
    {
        public List<MapMarkerModel> GetMapMarkers(int type)
        {
            List<MapMarkerModel> result = new List<MapMarkerModel>();
            int[] arr = { 1, 2, 3, 4 };
            if (!arr.Contains(type) || type == 1)
            {
                foreach (var item in this.BaseRepository()
    .FindList<DC_ASSETS_BuildingBaseInfoEntity>(c => c.F_CenterpointCoordinates != null && c.F_CenterpointCoordinates != "[]"))
                {
                    result.Add(new MapMarkerModel()
                    {
                        type = 1,
                        address = item.F_Address,
                        name = item.F_ConstructionName,
                        position = item.F_CenterpointCoordinates
                    });
                }
            }
            if (!arr.Contains(type) || type == 2)
            {
                foreach (var item in this.BaseRepository()
    .FindList<DC_ASSETS_LandBaseInfoEntity>(c => c.F_CenterpointCoordinates != null && c.F_CenterpointCoordinates != "[]"))
                {
                    result.Add(new MapMarkerModel()
                    {
                        type = 2,
                        address = item.F_ParcelAddress,
                        name = item.F_LandCertificate,
                        position = item.F_CenterpointCoordinates
                    });
                }
            }
            if (!arr.Contains(type) || type == 3)
            {
                foreach (var item in this.BaseRepository()
    .FindList<DC_ASSETS_BusStopBillboardsEntity>(c => c.F_CenterpointCoordinates != null && c.F_CenterpointCoordinates != "[]"))
                {
                    result.Add(new MapMarkerModel()
                    {
                        type = 3,
                        address = item.F_InstallationLocation,
                        name = item.F_BillboardsName,
                        position = item.F_CenterpointCoordinates
                    });
                }
            }
            if (!arr.Contains(type) || type == 4)
            {
                foreach (var item in this.BaseRepository()
    .FindList<DC_EngineProject_ProjectInfoEntity>(c => c.F_CenterpointCoordinates != null && c.F_CenterpointCoordinates != "[]"))
                {
                    result.Add(new MapMarkerModel()
                    {
                        type = 3,
                        address = item.F_ProjectAddress,
                        name = item.F_ProjectName,
                        position = item.F_CenterpointCoordinates
                    });
                }
            }
            return result;
        }

        /// <summary>
        /// 租金信息
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public DataTable HouseRentIncome(string code)
        {
            DataTable dt = null;
            dt = this.BaseRepository().FindTable(@"
               
  		select top 1 a.F_Year,a.F_ContractSignDate,a.F_ActualPrice,b.F_Renter,b.F_RenterPhone from DC_ASSETS_HouseRentIncome a  left join DC_ASSETS_HouseRentDetail  b
	
	on a.F_HRDId=b.F_HRDId  where b.F_HouseID='"+code+"'  ORDER BY a.F_CreateDatetime asc");

            return dt;

        }
        /// <summary>
        /// 房屋信息
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public DataTable House1(string code)
        {

            DataTable dt = null;
            dt = this.BaseRepository().FindTable(@"
               
select F_HouseName,F_HouseID from DC_ASSETS_HouseInfo where F_BBIId='" + code + "'");

            return dt;

        }
        /// <summary>
        /// 房屋信息
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public DataTable House(string code) {

            DataTable dt = null;
            dt = this.BaseRepository().FindTable(@"
               
select F_HouseID,F_CertificateNo,F_UseCategories,F_PowerOwner,F_Situation,F_Address,F_PoweNervous,F_UtilizeAge from DC_ASSETS_HouseInfo where F_HouseID='" + code+"'");

            return dt;

        }
        /// <summary>
        /// 获取建筑基本信息
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public DataTable BuildingBase(string code) {
            DataTable dt = null;
            dt = this.BaseRepository().FindTable(@"
               
				select
t1.F_BBIId,
t1.F_Address,
t1.F_ConstructionName,
t1.F_ConstructionArea,
t1.F_AvailableYears,
t1.F_FormerUnit,
t1.F_BuildingValue

 from 
DC_ASSETS_BuildingBaseInfo   t1  where t1.F_BBIId='" + code + "'");

            return dt;
        }

        public DataTable GetHouseList1(string code,string address) {

            DataTable dt = null;

            if (code.ToInt() > 0)
            {

                dt = this.BaseRepository().FindTable(@"
                select 
                t1.f_assetsnumber as code,
                t1.F_HouseName as housename,
                isnull((select top 1 f_areaname from lr_base_area 
                where f_areaid = t2.f_communitycode),'未填写') as areaname,
                t2.f_address as address,
                isnull((select top 1 f_itemname from lr_base_dataitemdetail 
                where F_ItemValue=t1.F_UseCategories and F_ItemId='aa85a173-5c75-488f-a97c-4dcefe025b18'),'未填写') as useby,
                isnull(t1.f_rentage,0) as rentage,
                isnull(t1.f_housearea,0) as area,
                isnull((select top 1 f_itemname from lr_base_dataitemdetail 
                where F_ItemValue=t3.f_leasestate and F_ItemId='c4417fca-b624-46a1-ac21-c291782519f5'),'未填写') as state,
                isnull((select top 1 f_actualprice from dc_assets_houserentincome where F_HRDId = t3.f_hrdid),0) as price,
				t2.F_CenterpointCoordinates as point,t2.F_FormerUnit,t4.F_Transferor,t2.F_BBIId
                from dc_assets_houseinfo t1
                left join dc_assets_buildingbaseinfo t2 on t1.F_BBIId=t2.f_bbiid
                left join dc_assets_houserentdetail t3 on t1.f_houseid = t3.f_houseid
                left join DC_ASSETS_LandBaseInfo t4 on t4.F_LBIId=t2.F_LBIId  
				
            ");

            }
            else {
                dt = this.BaseRepository().FindTable(@"
                select 
                t1.f_assetsnumber as code,
                t1.F_HouseName as housename,
                isnull((select top 1 f_areaname from lr_base_area 
                where f_areaid = t2.f_communitycode),'未填写') as areaname,
                t2.f_address as address,
                isnull((select top 1 f_itemname from lr_base_dataitemdetail 
                where F_ItemValue=t1.F_UseCategories and F_ItemId='aa85a173-5c75-488f-a97c-4dcefe025b18'),'未填写') as useby,
                isnull(t1.f_rentage,0) as rentage,
                isnull(t1.f_housearea,0) as area,
                isnull((select top 1 f_itemname from lr_base_dataitemdetail 
                where F_ItemValue=t3.f_leasestate and F_ItemId='c4417fca-b624-46a1-ac21-c291782519f5'),'未填写') as state,
                isnull((select top 1 f_actualprice from dc_assets_houserentincome where F_HRDId = t3.f_hrdid),0) as price,
				t2.F_CenterpointCoordinates as point,t2.F_FormerUnit,t4.F_Transferor,t2.F_BBIId
                from dc_assets_houseinfo t1
                left join dc_assets_buildingbaseinfo t2 on t1.F_BBIId=t2.f_bbiid
                left join dc_assets_houserentdetail t3 on t1.f_houseid = t3.f_houseid
                left join DC_ASSETS_LandBaseInfo t4 on t4.F_LBIId=t2.F_LBIId where t4.F_Transferor='" + address + "'");

            }
            DataColumn dc1 = new DataColumn("colour", typeof(string));
            dt.Columns.Add(dc1);
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                if (dt.Rows[i]["F_FormerUnit"].ToString() == "国资产中心")
                {
                    dt.Rows[i]["colour"] = "1";
                }
                else if (dt.Rows[i]["F_FormerUnit"].ToString() == "金源")
                {
                    dt.Rows[i]["colour"] = "2";

                }
                else if (dt.Rows[i]["F_FormerUnit"].ToString() == "金润源")
                {
                    dt.Rows[i]["colour"] = "3";

                }
                else
                {

                    dt.Rows[i]["colour"] = "4";
                }
            }
            return dt;

        }
        public DataTable GetHouseList(string type,string name,string index)
        {

            DataTable dt = null;

            if (type == "1")
            {
                int size = 0;
                if(index.IsEmpty())
                {
                    size = 0;
                }
                else
                {
                    size = (int.Parse(index)-1)*10;
                }
                dt = this.BaseRepository().FindTable(string.Format(@"
                select  top 10
							  t1.F_HouseID,
                t1.f_assetsnumber as code,
                t1.F_HouseName as housename,
                isnull((select top 1 f_areaname from lr_base_area 
                where f_areaid = t2.f_communitycode),'未填写') as areaname,
                t2.f_address as address,
                isnull((select top 1 f_itemname from lr_base_dataitemdetail 
                where F_ItemValue=t1.F_UseCategories and F_ItemId='aa85a173-5c75-488f-a97c-4dcefe025b18'),'未填写') as useby,
                isnull(t1.f_rentage,0) as rentage,
                isnull(t1.f_housearea,0) as area,
                isnull((select top 1 f_itemname from lr_base_dataitemdetail 
                where F_ItemValue=t3.f_leasestate and F_ItemId='c4417fca-b624-46a1-ac21-c291782519f5'),'未填写') as state,
                isnull((select top 1 f_actualprice from dc_assets_houserentincome where F_HRDId = t3.f_hrdid),0) as price,
				t2.F_CenterpointCoordinates as point,t2.F_FormerUnit,t4.F_Transferor
                from dc_assets_houseinfo t1
                left join dc_assets_buildingbaseinfo t2 on t1.F_BBIId=t2.f_bbiid
                left join dc_assets_houserentdetail t3 on t1.f_houseid = t3.f_houseid
                left join DC_ASSETS_LandBaseInfo t4 on t4.F_LBIId=t2.F_LBIId
				where  t1.F_HouseName like'%{0}%' 
								and t1.F_HouseID not in (								
								select  top {1}
							  t1.F_HouseID
              
                from dc_assets_houseinfo t1
                left join dc_assets_buildingbaseinfo t2 on t1.F_BBIId=t2.f_bbiid
                left join dc_assets_houserentdetail t3 on t1.f_houseid = t3.f_houseid
				where  t1.F_HouseName like'%{0}%' order by t1.F_HouseID)
               and t4.F_Transferor !='' order by t1.F_HouseID
            ", name,size));


            }
            else 
            {
                 dt =this.BaseRepository().FindTable(@"
                select 
                t1.f_assetsnumber as code,
                t1.F_HouseName as housename,
                isnull((select top 1 f_areaname from lr_base_area 
                where f_areaid = t2.f_communitycode),'未填写') as areaname,
                t2.f_address as address,
                isnull((select top 1 f_itemname from lr_base_dataitemdetail 
                where F_ItemValue=t1.F_UseCategories and F_ItemId='aa85a173-5c75-488f-a97c-4dcefe025b18'),'未填写') as useby,
                isnull(t1.f_rentage,0) as rentage,
                isnull(t1.f_housearea,0) as area,
                isnull((select top 1 f_itemname from lr_base_dataitemdetail 
                where F_ItemValue=t3.f_leasestate and F_ItemId='c4417fca-b624-46a1-ac21-c291782519f5'),'未填写') as state,
                isnull((select top 1 f_actualprice from dc_assets_houserentincome where F_HRDId = t3.f_hrdid),0) as price,
				t2.F_CenterpointCoordinates as point,t2.F_FormerUnit,t4.F_Transferor
                from dc_assets_houseinfo t1
                left join dc_assets_buildingbaseinfo t2 on t1.F_BBIId=t2.f_bbiid
                left join dc_assets_houserentdetail t3 on t1.f_houseid = t3.f_houseid
                left join DC_ASSETS_LandBaseInfo t4 on t4.F_LBIId=t2.F_LBIId
               	where  t4.F_Transferor!=''
				
            ");
            }

            DataColumn dc1 = new DataColumn("colour", typeof(string));
            dt.Columns.Add(dc1);
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                if (dt.Rows[i]["F_FormerUnit"].ToString() == "国资产中心")
                {
                    dt.Rows[i]["colour"] = "1";
                }
                else if (dt.Rows[i]["F_FormerUnit"].ToString() == "金源")
                {
                    dt.Rows[i]["colour"] = "2";

                }
                else if (dt.Rows[i]["F_FormerUnit"].ToString() == "金润源")
                {
                    dt.Rows[i]["colour"] = "3";

                }
                else {

                    dt.Rows[i]["colour"] = "4";
                }
            }


            return GetDistinctSelf1(dt);
        }

        public DataTable GetDistinctSelf1(DataTable SourceDt)
        {
            for (int i = SourceDt.Rows.Count - 2; i > 0; i--)
            {
                DataRow[] rows = SourceDt.Select("F_Transferor='" + SourceDt.Rows[i]["F_Transferor"] + "'");

                if (rows.Length > 1)
                {
                    SourceDt.Rows.RemoveAt(i);
                }
            }
           
            return SourceDt;


        }
        /// <summary>
        /// 加载土地数据
        /// </summary>
        /// <param name="type"></param>
        /// <param name="name"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public DataTable GetLandList1(string code,string address)
        {
            DataTable dt = null;
            //第一次加载加载所有数据
            if (code.ToInt() > 0)
            {
                dt = this.BaseRepository().FindTable(@"
                select  
                t1.f_lbiid,
                t1.F_LandName,
                t1.f_area,
                t1.f_parceladdress,
                t1.f_transferor,
                t1.F_LandUseNature,
                t1.F_LandUseRight,
                
                t1.f_assetsnumber as code,
                isnull((select top 1 F_AreaName from lr_base_area where F_AreaId=t1.F_CommunityCode),'未填写') as areaname,
                t1.f_parceladdress as [address],
                isnull((select top 1 f_itemname from lr_base_dataitemdetail
                where F_ItemValue=t1.F_LandUseRight and F_ItemId='9844c410-12ba-40aa-b799-c4562c070eca'),'未填写') as useright,
                isnull(t1.f_transferage,0) as transferage,
                isnull(t1.f_area,0) as area,
                isnull(t1.f_transferamount,0) as transferamount,
                isnull(((select top 1 f_itemname from lr_base_dataitemdetail 
                where F_ItemValue=t2.F_StartCompleteState and F_ItemId='0485d6c5-c885-4cd1-a1e1-3eb66122ab0a') ),'闲置') as state,
				t1.F_CenterpointCoordinates as point,t1.F_Assignee
                from dc_assets_landbaseinfo t1
                left join dc_assets_landbasestartcomplete t2 on t1.F_LBIId=t2.F_LBIId
				where t1.F_CenterpointCoordinates is not null and t1.F_CenterpointCoordinates !='[]' and F_Assignee!=''");
            }
            else {
                dt = this.BaseRepository().FindTable(@"
                select  
                t1.f_lbiid,
                t1.F_LandName,
                t1.f_area,
                t1.f_parceladdress,
                t1.f_transferor,
                t1.F_LandUseNature,
                t1.F_LandUseRight,
                t1.f_assetsnumber as code,
                isnull((select top 1 F_AreaName from lr_base_area where F_AreaId=t1.F_CommunityCode),'未填写') as areaname,
                t1.f_parceladdress as [address],
                isnull((select top 1 f_itemname from lr_base_dataitemdetail
                where F_ItemValue=t1.F_LandUseRight and F_ItemId='9844c410-12ba-40aa-b799-c4562c070eca'),'未填写') as useright,
                isnull(t1.f_transferage,0) as transferage,
                isnull(t1.f_area,0) as area,
                isnull(t1.f_transferamount,0) as transferamount,
                isnull(((select top 1 f_itemname from lr_base_dataitemdetail 
                where F_ItemValue=t2.F_StartCompleteState and F_ItemId='0485d6c5-c885-4cd1-a1e1-3eb66122ab0a') ),'闲置') as state,
				t1.F_CenterpointCoordinates as point,t1.F_Assignee
                from dc_assets_landbaseinfo t1
                left join dc_assets_landbasestartcomplete t2 on t1.F_LBIId=t2.F_LBIId
				where t1.F_CenterpointCoordinates is not null and t1.F_CenterpointCoordinates !='[]' and F_Assignee!='' and f_parceladdress like'%" + address + "%'");

            }
            DataColumn dc1 = new DataColumn("colour", typeof(string));
            dt.Columns.Add(dc1);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
             
                if (dt.Rows[i]["F_Assignee"].ToString() == "国资中心")
                {
                    dt.Rows[i]["colour"] = "5";
                }
                else if (dt.Rows[i]["F_Assignee"].ToString() == "金润")
                {
                    dt.Rows[i]["colour"] = "6";

                }
                else if (dt.Rows[i]["F_Assignee"].ToString() == "金润源")
                {
                    dt.Rows[i]["colour"] = "7";

                }
                else
                {
                    dt.Rows[i]["colour"] = "8";
                }
            }
        
            return dt;
        }


        /// <summary>
        /// 加载区域名称
        /// </summary>
        /// <param name="type"></param>
        /// <param name="name"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public DataTable GetLandList(string type,string name,string index)
        {
            DataTable dt = null;

            if (type == "1")
            {
                int size = 0;
                if (index.IsEmpty())
                {
                    size = 0;
                }
                else
                {
                    size = (int.Parse(index) - 1) * 10;
                }
                dt= this.BaseRepository().FindTable(string.Format(@"
                select top 10
								t1.F_LBIId,
                t1.f_assetsnumber as code,
                isnull((select top 1 F_AreaName from lr_base_area where F_AreaId=t1.F_CommunityCode),'未填写') as areaname,
                t1.f_parceladdress as [address],
                isnull((select top 1 f_itemname from lr_base_dataitemdetail
                where F_ItemValue=t1.F_LandUseRight and F_ItemId='9844c410-12ba-40aa-b799-c4562c070eca'),'未填写') as useright,
                isnull(t1.f_transferage,0) as transferage,
                isnull(t1.f_area,0) as area,
                isnull(t1.f_transferamount,0) as transferamount,
                isnull(((select top 1 f_itemname from lr_base_dataitemdetail 
                where F_ItemValue=t2.F_StartCompleteState and F_ItemId='0485d6c5-c885-4cd1-a1e1-3eb66122ab0a') ),'闲置') as state,
				t1.F_CenterpointCoordinates as point,t1.F_Assignee
                from dc_assets_landbaseinfo t1
                left join dc_assets_landbasestartcomplete t2 on t1.F_LBIId=t2.F_LBIId
				where t1.F_CenterpointCoordinates is not null and t1.F_CenterpointCoordinates !='[]' and t1.f_parceladdress like '%{0}%' and t1.F_LBIId not in (
				      select top {1}
								t1.F_LBIId
                from dc_assets_landbaseinfo t1
                left join dc_assets_landbasestartcomplete t2 on t1.F_LBIId=t2.F_LBIId
				where t1.F_CenterpointCoordinates is not null and t1.F_CenterpointCoordinates !='[]' and t1.f_parceladdress  like '%{0}%' and  F_Assignee!='' order by t1.F_LBIId) order by t1.F_LBIId
            ", name,size));
            }
            else 
            {


                dt= this.BaseRepository().FindTable(@"
                select  
                t1.f_assetsnumber as code,
                isnull((select top 1 F_AreaName from lr_base_area where F_AreaId=t1.F_CommunityCode),'未填写') as areaname,
                t1.f_parceladdress as [address],
                isnull((select top 1 f_itemname from lr_base_dataitemdetail
                where F_ItemValue=t1.F_LandUseRight and F_ItemId='9844c410-12ba-40aa-b799-c4562c070eca'),'未填写') as useright,
                isnull(t1.f_transferage,0) as transferage,
                isnull(t1.f_area,0) as area,
                isnull(t1.f_transferamount,0) as transferamount,
                isnull(((select top 1 f_itemname from lr_base_dataitemdetail 
                where F_ItemValue=t2.F_StartCompleteState and F_ItemId='0485d6c5-c885-4cd1-a1e1-3eb66122ab0a') ),'闲置') as state,
				t1.F_CenterpointCoordinates as point,t1.F_Assignee
                from dc_assets_landbaseinfo t1
                left join dc_assets_landbasestartcomplete t2 on t1.F_LBIId=t2.F_LBIId
				where t1.F_CenterpointCoordinates is not null and t1.F_CenterpointCoordinates !='[]' and F_Assignee!=''
            ");

            }

            DataColumn dc1 = new DataColumn("colour", typeof(string));
            dt.Columns.Add(dc1);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string num = dt.Rows[i]["address"].ToString();
                if (num.IndexOf('道') != -1)
                {

                    num = num.Split('道')[0] + "道";
                }
                else if (num.IndexOf('路') != -1)
                {

                    num = num.Split('路')[0] + "路";
                }
            

                dt.Rows[i]["address"] = num;

                if (dt.Rows[i]["F_Assignee"].ToString() == "国资中心")
                {
                    dt.Rows[i]["colour"] = "5";
                }
                else if (dt.Rows[i]["F_Assignee"].ToString() == "金润")
                {
                    dt.Rows[i]["colour"] = "6";

                }
                else if (dt.Rows[i]["F_Assignee"].ToString() == "金润源")
                {
                    dt.Rows[i]["colour"] = "7";

                }
                else {
                    dt.Rows[i]["colour"] = "8";
                }
            }


            int num3 = dt.Rows.Count;



            return GetDistinctSelf(dt);
        }
        //去重复
        public DataTable GetDistinctSelf(DataTable SourceDt)
        {
            for (int i = SourceDt.Rows.Count - 2; i > 0; i--)
            {
                DataRow[] rows = SourceDt.Select("address='" + SourceDt.Rows[i]["address"] + "'");
             
                if (rows.Length > 1)
                {
                    SourceDt.Rows.RemoveAt(i);
                }
            }
            int num4 = SourceDt.Rows.Count;

            return SourceDt;


        }

        public DataTable BoardList(string code, string address) {

            DataTable dt = null;

            //第一次加载
            if (code.ToInt() > 0)
            {

                dt = this.BaseRepository().FindTable(@"
                select
                t1.f_billboardsnumber as code,
                t1.F_BillboardsName as name,
                t1.F_BillboardsCategory,
                isnull((select top 1 f_areaname from lr_base_area where F_AreaId=t1.F_CommunityCode),'未填写') as areaname,
                t1.F_InstallationLocation as address,
                isnull((select top 1 f_itemname from lr_base_dataitemdetail 
                where f_itemvalue=t1.f_usestate and F_ItemId='cbf2def3-53aa-425b-8b62-2e4a5e3ffb32'),'未填写') as usestate,
                isnull((select top 1 f_itemname from lr_base_dataitemdetail 
                where f_itemvalue=t2.F_LeaseState and F_ItemId='c4417fca-b624-46a1-ac21-c291782519f5'),'未填写') as rentstate,
                isnull((select top 1 f_actualprice from dc_assets_busstopbillboardsrentincome where F_BSBRDId=t2.F_BSBRDId),0) as price,
				t1.F_CenterpointCoordinates as point
                from dc_assets_busstopbillboards t1
                left join dc_assets_busstopbillboardsrentdetail t2 on t1.F_BSBId=t2.F_BSBId
				where t1.F_CenterpointCoordinates is not null and t1.F_CenterpointCoordinates !='[]'");

            }
            else {

                dt = this.BaseRepository().FindTable(@"
                select
                t1.f_billboardsnumber as code,
                t1.F_BillboardsName as name,
                t1.F_BillboardsCategory,
                isnull((select top 1 f_areaname from lr_base_area where F_AreaId=t1.F_CommunityCode),'未填写') as areaname,
                t1.F_InstallationLocation as address,
                isnull((select top 1 f_itemname from lr_base_dataitemdetail 
                where f_itemvalue=t1.f_usestate and F_ItemId='cbf2def3-53aa-425b-8b62-2e4a5e3ffb32'),'未填写') as usestate,
                isnull((select top 1 f_itemname from lr_base_dataitemdetail 
                where f_itemvalue=t2.F_LeaseState and F_ItemId='c4417fca-b624-46a1-ac21-c291782519f5'),'未填写') as rentstate,
                isnull((select top 1 f_actualprice from dc_assets_busstopbillboardsrentincome where F_BSBRDId=t2.F_BSBRDId),0) as price,
				t1.F_CenterpointCoordinates as point
                from dc_assets_busstopbillboards t1
                left join dc_assets_busstopbillboardsrentdetail t2 on t1.F_BSBId=t2.F_BSBId
				where t1.F_CenterpointCoordinates is not null and t1.F_CenterpointCoordinates !='[]' and t1.F_BillboardsName like '%"+ address + "%'");

            }

            DataColumn dc1 = new DataColumn("colour", typeof(string));
            dt.Columns.Add(dc1);
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                if (dt.Rows[i]["F_BillboardsCategory"].ToString() == "LED户外广告显示屏")
                {
                    dt.Rows[i]["colour"] = "9";
                }
                else if (dt.Rows[i]["F_BillboardsCategory"].ToString() == "港湾式公交站台")
                {
                    dt.Rows[i]["colour"] = "10";

                }
                else if (dt.Rows[i]["F_BillboardsCategory"].ToString() == "小丝公交站台改造")
                {
                    dt.Rows[i]["colour"] = "11";

                }

            }

            return dt;

        }

        public DataTable GetAdBoardList(string type,string name,string index)
        {

            DataTable dt = null;

            if (type =="1")
            {
                int size = 0;
                if (index.IsEmpty())
                {
                    size = 0;
                }
                else
                {
                    size = (int.Parse(index) - 1) * 10;
                }
                dt= this.BaseRepository().FindTable(string.Format(@"
             select top 10
                t1.F_BSBId,
                t1.f_billboardsnumber as code,
                t1.F_BillboardsName as name,
                t1.F_BillboardsCategory,
                isnull((select top 1 f_areaname from lr_base_area where F_AreaId=t1.F_CommunityCode),'未填写') as areaname,
                t1.F_InstallationLocation as address,
                isnull((select top 1 f_itemname from lr_base_dataitemdetail 
                where f_itemvalue=t1.f_usestate and F_ItemId='cbf2def3-53aa-425b-8b62-2e4a5e3ffb32'),'未填写') as usestate,
                isnull((select top 1 f_itemname from lr_base_dataitemdetail 
                where f_itemvalue=t2.F_LeaseState and F_ItemId='c4417fca-b624-46a1-ac21-c291782519f5'),'未填写') as rentstate,
                isnull((select top 1 f_actualprice from dc_assets_busstopbillboardsrentincome where F_BSBRDId=t2.F_BSBRDId),0) as price,
				t1.F_CenterpointCoordinates as point
                from dc_assets_busstopbillboards t1
                left join dc_assets_busstopbillboardsrentdetail t2 on t1.F_BSBId=t2.F_BSBId
				where t1.F_CenterpointCoordinates is not null and t1.F_CenterpointCoordinates !='[]' and t1.F_BillboardsName like '%{0}%'
				and t1.F_BSBId not in (
				
				select top {1}
                t1.F_BSBId
                from dc_assets_busstopbillboards t1
                left join dc_assets_busstopbillboardsrentdetail t2 on t1.F_BSBId=t2.F_BSBId
				where t1.F_CenterpointCoordinates is not null and t1.F_CenterpointCoordinates !='[]' and t1.F_BillboardsName like '%{0}%'
				  order by  t1.F_BSBId
			)  order by  t1.F_BSBId
				
           ", name,size));
            }
            else 
            {
                dt= this.BaseRepository().FindTable(@"
                select
                t1.f_billboardsnumber as code,
                t1.F_BillboardsName as name,
                t1.F_BillboardsCategory,
                isnull((select top 1 f_areaname from lr_base_area where F_AreaId=t1.F_CommunityCode),'未填写') as areaname,
                t1.F_InstallationLocation as address,
                isnull((select top 1 f_itemname from lr_base_dataitemdetail 
                where f_itemvalue=t1.f_usestate and F_ItemId='cbf2def3-53aa-425b-8b62-2e4a5e3ffb32'),'未填写') as usestate,
                isnull((select top 1 f_itemname from lr_base_dataitemdetail 
                where f_itemvalue=t2.F_LeaseState and F_ItemId='c4417fca-b624-46a1-ac21-c291782519f5'),'未填写') as rentstate,
                isnull((select top 1 f_actualprice from dc_assets_busstopbillboardsrentincome where F_BSBRDId=t2.F_BSBRDId),0) as price,
				t1.F_CenterpointCoordinates as point
                from dc_assets_busstopbillboards t1
                left join dc_assets_busstopbillboardsrentdetail t2 on t1.F_BSBId=t2.F_BSBId
				where t1.F_CenterpointCoordinates is not null and t1.F_CenterpointCoordinates !='[]'
           ");

            }
            DataColumn dc1 = new DataColumn("colour", typeof(string));
            dt.Columns.Add(dc1);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                    dt.Rows[i]["colour"] = "9";

                string num = dt.Rows[i]["name"].ToString();
                if (num.IndexOf('道') != -1)
                {

                    num = num.Split('道')[0] + "道";
                }
                dt.Rows[i]["name"] = num;
                if (dt.Rows[i]["F_BillboardsCategory"].ToString() == "LED户外广告显示屏")
                {
                    dt.Rows[i]["colour"] = "9";
                }
                else if (dt.Rows[i]["F_BillboardsCategory"].ToString() == "港湾式公交站台")
                {
                    dt.Rows[i]["colour"] = "10";

                }
                else if (dt.Rows[i]["F_BillboardsCategory"].ToString() == "小丝公交站台改造")
                {
                    dt.Rows[i]["colour"] = "11";

                }

            }

            return GetDistinctSelf2(dt);
        }

        //广告牌去重复
        public DataTable GetDistinctSelf2(DataTable SourceDt)
        {
            for (int i = SourceDt.Rows.Count - 2; i > 0; i--)
            {
                DataRow[] rows = SourceDt.Select("name='" + SourceDt.Rows[i]["name"] + "'");

                if (rows.Length > 1)
                {
                    SourceDt.Rows.RemoveAt(i);
                }
            }
          

            return SourceDt;


        }
        public DataTable GetProjectList(string type,string name,string index)
        {
            if (type == "1")
            {
                int size = 0;
                if (index.IsEmpty())
                {
                    size = 0;
                }
                else
                {
                    size = (int.Parse(index) - 1) * 10;
                }
                return this.BaseRepository().FindTable(string.Format(@"
                select  top 10
                t1.F_PIId,
                t1.f_projectitemnumber as code,
                t1.f_projectbuildtype as type,
                t1.f_projectname as name,
                isnull((select top 1 f_areaname from lr_base_area
                where f_areaid = t1.f_communitycode),'未填写') as areaname,
                t1.f_projectaddress as address,
                convert(varchar(100),t1.f_plannedstartdate,23) as startdate,
                convert(varchar(100),t1.f_plannedenddate,23) as enddate,
                isnull((select top 1 f_taskstate from dc_engineproject_projecttasks 
                where f_piid=t1.f_piid order by F_CreateDatetime desc),'未填写') as state,
                isnull((select top 1 f_projectstage from dc_engineproject_projecttasksprogress where F_PIId = 
                (select top 1 f_taskstate from dc_engineproject_projecttasks 
                where f_piid=t1.f_piid order by F_CreateDatetime desc) order by F_CreateDatetime desc),'未填写') as progress,
				t1.F_CenterpointCoordinates as point
                from dc_engineproject_projectinfo t1
				where t1.F_CenterpointCoordinates is not null and t1.F_CenterpointCoordinates !='[]' and f_projectname like '%{0}%'
				and   t1.F_PIId not in (
				
				 select  top {1}
                t1.F_PIId
               
                from dc_engineproject_projectinfo t1
				where t1.F_CenterpointCoordinates is not null and t1.F_CenterpointCoordinates !='[]' and f_projectname like '%{0}%'
				order by   t1.F_PIId
				
				)  order by   t1.F_PIId
            ", name,size));
               
            }
            else 
            {
                return this.BaseRepository().FindTable(@"
                select 
                t1.f_projectitemnumber as code,
                t1.f_projectbuildtype as type,
                t1.f_projectname as name,
                isnull((select top 1 f_areaname from lr_base_area
                where f_areaid = t1.f_communitycode),'未填写') as areaname,
                t1.f_projectaddress as address,
                convert(varchar(100),t1.f_plannedstartdate,23) as startdate,
                convert(varchar(100),t1.f_plannedenddate,23) as enddate,
                isnull((select top 1 f_taskstate from dc_engineproject_projecttasks 
                where f_piid=t1.f_piid order by F_CreateDatetime desc),'未填写') as state,
                isnull((select top 1 f_projectstage from dc_engineproject_projecttasksprogress where F_PIId = 
                (select top 1 f_taskstate from dc_engineproject_projecttasks 
                where f_piid=t1.f_piid order by F_CreateDatetime desc) order by F_CreateDatetime desc),'未填写') as progress,
				t1.F_CenterpointCoordinates as point
                from dc_engineproject_projectinfo t1
				where t1.F_CenterpointCoordinates is not null and t1.F_CenterpointCoordinates !='[]'
            ");


            }
        }
    }
}
