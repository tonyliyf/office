using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Nancy;
using Learun.Util;
using Learun.Application.TwoDevelopment.AssetManager;
using Learun.Application.Base.SystemModule;
using System.Collections;
using System.Data;
using Learun.Application.TwoDevelopment.EcologyDemo;

namespace Learun.Application.WebApi
{
    public class AssetManagerInfoApi : BaseApi
    {
        private UrlRepalceUtil urlRelpace = new UrlRepalceUtil();
        private DC_ASSETS_LandBaseInfoIBLL landbll = new DC_ASSETS_LandBaseInfoBLL();
        private DC_ASSETS_LandHandUpInfoIBLL landbl2 = new DC_ASSETS_LandHandUpInfoBLL();
        private DC_ASSETS_HouseInfoIBLL landbl3 = new DC_ASSETS_HouseInfoBLL();
        private DC_ASSETS_HouseRentMainIBLL landbl4 = new DC_ASSETS_HouseRentMainBLL();
        private DC_ASSETS_BusStopBillboardsRentMainIBLL landbl5 = new DC_ASSETS_BusStopBillboardsRentMainBLL();
        private DC_ASSETS_HouseInfoIBLL landbl6 = new DC_ASSETS_HouseInfoBLL();
        private DC_ASSETS_LandHandUpInfoIBLL landbl7 = new DC_ASSETS_LandHandUpInfoBLL();
        private DC_ASSETS_BusStopBillboardsIBLL landbl8 = new DC_ASSETS_BusStopBillboardsBLL();
        private DC_ASSETS_LandBaseInfofoodIBLL foodBll = new DC_ASSETS_LandBaseInfofoodBLL();
        private DC_ASSETS_HouseRentMainHistoryIBLL HouseRentMainHistoryBLL = new DC_ASSETS_HouseRentMainHistoryBLL();
        private DC_ASSETS_HouseRentDetaiHistoryIBLL detailRentBLL = new DC_ASSETS_HouseRentDetaiHistoryBLL();

        private DC_ASSETS_HouseRentMainIBLL HouseRentMainBLL = new DC_ASSETS_HouseRentMainBLL();
        private DC_ASSETS_HouseRentDetailIBLL RentBLL = new DC_ASSETS_HouseRentDetailBLL();
        private DC_ASSETS_HouseRentDetailIBLL rentDetailBll = new DC_ASSETS_HouseRentDetailBLL();
        private DC_ASSETS_HouseRentIncomeIBLL dC_ASSETS_HouseRentIncomeIBLL = new DC_ASSETS_HouseRentIncomeBLL();

        private formtable_main_131IBLL mainBll = new formtable_main_131BLL();

        private DC_ASSETS_BusStopBillboardsRentMainIBLL boardsRentMain = new DC_ASSETS_BusStopBillboardsRentMainBLL();
        private DC_ASSETS_BusStopBillboardsRentDetailIBLL boardsRentDetail = new DC_ASSETS_BusStopBillboardsRentDetailBLL();
        public AssetManagerInfoApi()
         : base("/learun/adms/AssetManager/AssetManagerInfoApi")
        {
            Get["/LandInfo"] = GetLandInfo;//土地图表展示
            Get["/LandUpInfo"] = GetLandUpInfo;//招拍挂土地图表展示
            Get["/boardsInfo"] = GetboardsInfo;//广告图表展示
            Get["/HouseInfo"] = GetHouseInfo;//房屋图表展示
            Get["/boardInfo"] = GetboardInfo;//广告租赁信息
            Get["/GetLandfoodList"] = GetLandfoodList;//粮食土地单位列表
            Get["/GetLandfoodInfo"] = GetLandfoodInfo;//粮食土地信息
            Get["/LandAssigneeList"] = GetLandAssigneeList;
            Get["/LandAssigneedata"] = GetLandAssigneeData;
            Get["/LandAssigneeSearch"] = GetLandAssigneeSearch;
            Get["/DC_ASSETS_HouseInfo"] = GetDC_ASSETS_HouseInfo;
            Get["/LandHandlist"] = GetLandHandlist;
            Get["/LandHandSearch"] = GetLandHandSearch;
            Get["/HouseAssigneeListt"] = GetHouseAssigneeListt;
            Get["/HouseAssigneeSearch"] = GetHouseAssigneeSearch;
            Get["/HouseboardsList"] = GetHouseboardsList;
            Get["/boardsAssigneeSearch"] = GetboardsAssigneeSearch;
            Get["/HouseAssigneeDetail"] = GetHouseAssigneeDetail;
            Get["/boardsAssigneeDetail"] = GetboardsAssigneeDetail;


            Get["/GetHouseHistroyRentInfo"] = GetHouseHistroyRentInfo;
            Get["/GetHouseHistroyRentDetailInfo"] = GetHouseHistroyRentDetailInfo;

            Get["/GetMainList"] = GetMainList;
            Get["/GetHouseRentDetailInfo"] = GetHouseRentDetailInfo;
            Get["/GetHouseRenterInfo"] = GetHouseRenterInfo;
            Get["/GetHouseRenterIncome"] = GetHouseRenterIncome;

            Get["/GetRepairList"] = GetRepairList;



            Get["/GetBoardMainList"] = GetBoardMainList;
            Get["/GetBoardDetailList"] = GetBoardDetailList;
       




        }


        #region 首页图表信息
        /// <summary>
        /// 土地信息
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        public Response GetLandInfo(dynamic _)
        {
            var data = landbll.GetLandInfo();

            var jsondata = new
            {
                data = data,

            };
            return Success(data);

        }

        /// <summary>
        ///  //招拍挂土地信息
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>

        public Response GetLandUpInfo(dynamic _)
        {
            var data = landbl2.GetLandUpInfo();

            var jsondata = new
            {
                data = data,

            };
            return Success(data);

        }

        /// <summary>
        /// 广告信息
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        public Response GetboardsInfo(dynamic _)
        {
            var data = landbl8.GetboardsInfo();

            var jsondata = new
            {
                data = data,

            };
            return Success(data);

        }

        /// <summary>
        /// 房屋信息
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        public Response GetHouseInfo(dynamic _)
        {
            var data = landbl4.GetHouseInfo();

            var jsondata = new
            {
                data = data,

            };
            return Success(data);

        }

        /// <summary>
        /// 广告租赁信息
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        public Response GetboardInfo(dynamic _)
        {
            var data = landbl5.GetboardInfo();

            var jsondata = new
            {
                data = data,

            };
            return Success(data);

        }

        #endregion 

        #region 土地信息接口
        /// <summary>
        /// 土地统计图展示原单位列表
        /// </summary>
        /// <param name="F_Assignee">受让人</param>
        /// <returns></returns>
        public Response GetLandAssigneeList(dynamic _)
        {
            string temp = this.GetReqData();

            var queryParam = temp.ToJObject();

            if (!queryParam["F_Assignee"].IsEmpty())
            {
                var data = landbll.GetLandAssigneeList(queryParam["F_Assignee"].ToString(),queryParam["SearchValue"].ToString());
              
                return Success(data);
            }

            else
            {

                return null;
            }
        }
        /// <summary>
        /// 土地统计图显示数据
        /// </summary>
        /// <param name="F_Assignee">受让人</param>
        /// <param name="F_Transferor">出让人（原单位）</param>
        /// <returns></returns>
        public Response GetLandAssigneeData(dynamic _)
        {
            string temp = this.GetReqData();

            var queryParam = temp.ToJObject();

            if (!queryParam["F_Assignee"].IsEmpty() && !queryParam["F_Transferor"].IsEmpty())
            {
                var data = landbll.GetLandAssigneeData(queryParam["F_Assignee"].ToString(), queryParam["F_Transferor"].ToString());

                foreach (DataRow dr in data.Rows)
                {

                    dr["F_PictureAccessories"] = urlRelpace.GetUrl(dr["F_PictureAccessories"].ToString());
                    dr["F_ContractAccessories"] = urlRelpace.GetUrl(dr["F_ContractAccessories"].ToString());

                }

                return Success(data);
            }

            else
            {

                return null;
            }
        }
        /// <summary>
        /// 土地统计图搜索框
        /// </summary>
        /// <param name="F_Assignee">受让人</param>
        /// <param name="SearchValue">搜索框输入值</param>
        /// <returns></returns>
        public Response GetLandAssigneeSearch(dynamic _)
        {
            string temp = this.GetReqData();

            var queryParam = temp.ToJObject();

            if (!queryParam["F_Assignee"].IsEmpty())
            {
                var data = landbll.GetLandAssigneeSearch(queryParam["F_Assignee"].ToString(), queryParam["SearchValue"].ToString());

                foreach (DataRow dr in data.Rows)
                {

                    dr["F_PictureAccessories"] = urlRelpace.GetUrl(dr["F_PictureAccessories"].ToString());
                    dr["F_ContractAccessories"] = urlRelpace.GetUrl(dr["F_ContractAccessories"].ToString());

                }
                return Success(data);
            }

            else
            {

                return null;
            }
        }
        /// <summary>
        /// 土地统计图查看房屋
        /// </summary>
        /// <param name="F_HouseID">房屋主键</param>
        /// <returns></returns>
        public Response GetDC_ASSETS_HouseInfo(dynamic _)
        {
            string temp = this.GetReqData();

            var queryParam = temp.ToJObject();

            if (!queryParam["F_HouseID"].IsEmpty())
            {
                var data = landbl6.GetDC_ASSETS_HouseInfo(queryParam["F_HouseID"].ToString());

               
                   data.F_PictureAccessories = urlRelpace.GetUrl(data.F_PictureAccessories);
               // dr["F_PictureAccessories"] = urlRelpace.GetUrl(dr["F_PictureAccessories"].ToString());


             
                return Success(data);
            }

            else
            {

                return null;
            }
        }

        #endregion

        #region 土地招拍挂信息接口
        /// <summary>
        /// 土地招拍挂摘牌单位列表
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        public Response GetLandHandlist(dynamic _) {

            var data = landbl7.GetLandHandlist();
            return Success(data);
        }
        /// <summary>
        /// 土地招拍挂搜索框和点击摘牌单位
        /// </summary>
        /// <param name="F_Assignee">摘牌单位</param>
        /// <param name="SearchValue">搜索框输入值</param>
        /// <returns></returns>
        public Response GetLandHandSearch(dynamic _)
        {

            string temp = this.GetReqData();

            var queryParam = temp.ToJObject();

            if (!queryParam["F_Assignee"].IsEmpty())
            {
                var data = landbl7.GetLandHandSearch(queryParam["F_Assignee"].ToString(), queryParam["SearchValue"].ToString());
                return Success(data);
            }

            else
            {
                return null;
            }
        }

        #endregion

        # region 粮食土地接口
        /// <summary>
        ///获得粮食土地单位列表
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        public Response GetLandfoodList(dynamic _)
        {
            string temp = this.GetReqData();

            var queryParam = temp.ToJObject();
            var data = foodBll.GetLandfoodlist(queryParam["SearchValue"].ToString());
            return Success(data);
        }
        /// <summary>
        ///获得粮食土地信息列表
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        public Response GetLandfoodInfo(dynamic _)
        {
            string temp = this.GetReqData();

            var queryParam = temp.ToJObject();
            var data = foodBll.GetLandfoodInfo(queryParam["F_Transferor"].ToString());
            foreach(var item in  data)
            {
                item.F_PictureAccessories = urlRelpace.GetUrl(item.F_PictureAccessories);

            }
            return Success(data);
        }

        #endregion

        #region 房屋信息接口
        ///
        /// <summary>
        /// 房屋统计原单位列表
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        public Response GetHouseAssigneeListt(dynamic _)
        {

            string temp = this.GetReqData();

            var queryParam = temp.ToJObject();

            if (!queryParam["F_FormerUnit"].IsEmpty())
            {
                var data = landbl6.GetHouseAssigneeListt(queryParam["F_FormerUnit"].ToString(),queryParam["SearchValue"].ToString());
                return Success(data);
            }

            else
            {
                return null;
            }
        }
        /// <summary>
        /// 房屋统计图搜索框和点击原单位
        /// </summary>
        /// <param name="F_FormerUnit">受让人</param>
        /// <param name="SearchValue">搜索框输入值</param>
        /// <returns></returns>
        public Response GetHouseAssigneeSearch(dynamic _)
        {
            string temp = this.GetReqData();

            var queryParam = temp.ToJObject();

            if (!queryParam["F_FormerUnit"].IsEmpty())
            {

                LogUtil.WriteTextLog("GetHouse", queryParam["F_FormerUnit"].ToString(), DateTime.Now);
                LogUtil.WriteTextLog("GetHouse", queryParam["SearchValue"].ToString(), DateTime.Now);
                var data = landbl6.GetHouseAssigneeSearch(queryParam["F_FormerUnit"].ToString(), queryParam["SearchValue"].ToString());

                foreach (DataRow dr in data.Rows)
                {

                    dr["F_PictureAccessories"] = urlRelpace.GetUrl(dr["F_PictureAccessories"].ToString());
                  

                }
                return Success(data);
            }
            else
            {

                return null;
            }
        }

        #endregion

        #region 广告信息及招租信息


        ///
        /// <summary>
        /// 广告类别
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        public Response GetBoardMainList(dynamic _)
        {

            var data = boardsRentMain.GetMainList();
            return Success(data);

        }


        ///
        /// <summary>
        /// 广告明细
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        public Response GetBoardDetailList(dynamic _)
        {

            string temp = this.GetReqData();
            var queryParam = temp.ToJObject();
            SimpleLogUtil.WriteTextLog("BoardRentDetail", queryParam["keyValue"].ToString(), DateTime.Now);
            if (!queryParam["keyValue"].IsEmpty())
            {
                var data = boardsRentDetail.GetBoardDetailList(queryParam["keyValue"].ToString(), queryParam["SearchValue"].ToString());
              
                var jsondata = new
                {
                    data = data,

                };
                return Success(data);
            }
            return null;
           

        }
        ///
        /// <summary>
        /// 广告类别
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        public Response GetHouseboardsList(dynamic _)
        {
       
                var data = landbl8.GetHouseboardsList();

                return Success(data);


        }
        /// <summary>
        ///  广告统计搜索框搜索和点击类别查询
        /// </summary>
        /// <param name="F_BillboardsCategory">广告牌类别</param>
        /// <param name="SearchValue">搜索框输入值</param>
        /// <returns></returns>
        public Response GetboardsAssigneeSearch(dynamic _)
        {
            string temp = this.GetReqData();

        var queryParam = temp.ToJObject();


            LogUtil.WriteTextLog("boards", queryParam["F_BillboardsCategory"].ToString(), DateTime.Now);
            if (!queryParam["F_BillboardsCategory"].IsEmpty())
            {
                var data = landbl8.GetboardsAssigneeSearch(queryParam["F_BillboardsCategory"].ToString(), queryParam["SearchValue"].ToString());
                LogUtil.WriteTextLog("F_BillboardsCategory", data.Rows.Count.ToString(), DateTime.Now);
                return Success(data);
             
            }
            else
            {

                return null;
            }
        }

        ///
        /// <summary>
        /// 广告招租统计数据查询
        /// </summary>
        /// <param name="State">房屋租赁状态，0招租未成功，1招租已成功</param>
        /// <returns></returns>
        public Response GetboardsAssigneeDetail(dynamic _)
        {

            string temp = this.GetReqData();

            var queryParam = temp.ToJObject();
            LogUtil.WriteTextLog("State", queryParam["State"].ToString(), DateTime.Now);

            if (!queryParam["State"].IsEmpty())
            {
                var data = landbl8.GetboardsAssigneeDetail1(queryParam["State"].ToString(), queryParam["SearchValue"].ToString());
                return Success(data);
            }

            else
            {
                return null;
            }
        }

        #endregion

        #region 房屋招租信息
       
        /// <summary>
        /// 房屋招租统计数据查询
        /// </summary>
        /// <param name="State">房屋租赁状态，0招租未成功，1招租已成功</param>
        /// <returns></returns>
        public Response GetHouseAssigneeDetail(dynamic _)
        {

            string temp = this.GetReqData();

            var queryParam = temp.ToJObject();

            LogUtil.WriteTextLog("houseRentstate", queryParam["State"].ToString(), DateTime.Now);
            if (!queryParam["State"].IsEmpty())
            {
                var data = landbl6.GetHouseAssigneeDetail(queryParam["State"].ToString(), queryParam["SearchValue"].ToString());
                return Success(data);
            }

            else
            {
                return null;
            }
        }

        #endregion

        #region 房屋租赁信息

        /// <summary>
        /// 房屋批次信息
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        public Response GetMainList(dynamic _)
        {
            var data = HouseRentMainBLL.GetMainList();

            var jsondata = new
            {
                data = data,

            };
            return Success(data);
        }

        //房屋租赁明细
        public Response GetHouseRentDetailInfo(dynamic _)
        {
            string temp = this.GetReqData();
            var queryParam = temp.ToJObject();
            if (!queryParam["keyValue"].IsEmpty())
            {
                var data = RentBLL.GetHouseRentDetailInfo(queryParam["keyValue"].ToString(),queryParam["SearchValue"].ToString());



                foreach( var item  in data)
                {

                  item.F_DetailFiles = urlRelpace.GetUrl(item.F_DetailFiles);


                }
                var jsondata = new
                {
                    data = data,

                };
                return Success(data);
            }
            return null;

        }

        
        //租户信息
        public Response GetHouseRenterInfo(dynamic _)
        {
            string temp = this.GetReqData();
            var queryParam = temp.ToJObject();
            if (!queryParam["keyValue"].IsEmpty())
            {
                var data = rentDetailBll.GetDC_ASSETS_HouseRentDetailInfoList(queryParam["keyValue"].ToString());
                var jsondata = new
                {
                    data = data,

                };
                return Success(data);
            }
            return null;

        }

        public Response GetHouseRenterIncome(dynamic _)
        {
            string temp = this.GetReqData();
            var queryParam = temp.ToJObject();
            if (!queryParam["keyValue"].IsEmpty())
            {
                var data = dC_ASSETS_HouseRentIncomeIBLL.GetDC_ASSETS_HouseRentIncomeEntityList(queryParam["keyValue"].ToString());
                var jsondata = new
                {
                    data = data,

                };
                return Success(data);
            }
            return null;

        }

        #endregion 

        #region 房屋历史租赁信息


        //招租批次信息
        public Response GetHouseHistroyRentInfo(dynamic _)
        {
            var data = HouseRentMainHistoryBLL.GetMainList();

            var jsondata = new
            {
                data = data,

            };
            return Success(data);

        }

        //招租历史明细
        public Response GetHouseHistroyRentDetailInfo(dynamic _)
        {
            string temp = this.GetReqData();
            var queryParam = temp.ToJObject();
            if (!queryParam["keyValue"].IsEmpty())
            {
                var data = detailRentBLL.GetRentDetailinfo(queryParam["keyValue"].ToString(),queryParam["SearchValue"].ToString());
                foreach (var item in data)
                {
                    item.F_DetailFiles = urlRelpace.GetUrl(item.F_DetailFiles);
                   
                }
                var jsondata = new
                {
                    data = data,

                };
                return Success(data);
            }
            return null;
            

        }

        #endregion


        #region 设备维修记录

        public Response GetRepairList(dynamic _)
        {
            string temp = this.GetReqData();
            var queryParam = temp.ToJObject();
            string temp2 = string.Empty;
            if(!string.IsNullOrEmpty(queryParam["SearchValue"].ToString()))
            {
                temp2 = queryParam["SearchValue"].ToString();

            }
          
                var data = mainBll.GetList(temp2);
             
                var jsondata = new
                {
                    data = data,

                };
                return Success(data);
           
        


        }

        #endregion 

    }
}