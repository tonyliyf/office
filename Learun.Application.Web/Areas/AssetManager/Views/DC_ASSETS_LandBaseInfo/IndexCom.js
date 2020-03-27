/* * 版 本 Learun-ADMS V7.0.3 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-02-13 11:36
 * 描  述：DC_ASSETS_LandBaseInfo
 */
var refreshGirdData;
var query;
var keyValue = request('keyValue');
var openDownFileWnd
var openMapWnd
var bootstrap = function ($, learun) {
    "use strict";
    var page = {
        init: function () {
            page.initGird();
            page.bind();
        },
        bind: function () {
        

            $('#multiple_condition_query').lrMultipleQuery(function (queryJson) {
                page.search(queryJson);
            }, 250, 400);
            // 刷新
            $('#lr_refresh').on('click', function () {
                location.reload();
            });
            //导出
            $('#lr-export').on('click', function () {
                learun.download({
                    method: "POST",
                    url: top.$.rootUrl + '/AssetManager/DC_ASSETS_LandBaseInfo/GetExportComLandbase',
                    param: {
                        fileName: "综合信息表",
                        columnJson: JSON.stringify($('#gridtable').jfGridGet('settingInfo').headData),
                        queryJson: JSON.stringify(query)
                    }
                });
            });
            $('#F_Assignee').lrDataItemSelect({ code: 'oldManager' });
            
        },
        // 初始化列表
        initGird: function () {
            $('#gridtable').jfGrid({
                url: top.$.rootUrl + '/AssetManager/DC_ASSETS_LandBaseInfo/GetComLandbase',
                headData: [
                    { label: "单位名称", name: "f_transferor", width: 150, align: "center" },
                    { label: "土地名称", name: "f_landname", width: 130, align: "center" },
                    { label: "土地坐落", name: "f_parceladdress", width: 130, align: "center" },
                    { label: "土地所有权人", name: "f_assignee", width: 120, align: "center" },
                    { label: "权属证号", name: "f_landcertificate", width: 80, align: "center" },
                    { label: "使用权面积", name: "f_area", width: 80, align: "center" },
                    { label: "使用权类型", name: "f_landuseright", width: 80, align: "center" },
                    { label: "地类用途", name: "f_landusenature", width: 80, align: "center" },
                    { label: "账面价值", name: "f_transferamount", width: 80, align: "center" },
                    { label: "建筑名称", name: "f_constructionname", width: 130, align: "center" },
                    { label: "建筑面积", name: "f_constructionarea", width: 130, align: "center" },
                    { label: "总楼层", name: "f_constructionfloorcount", width: 180, align: "center" },
                    { label: "房屋名称", name: "f_housename", width: 80, align: "center" },
                    { label: "房产证号", name: "f_certificateno", width: 80, align: "center" },
                    { label: "房产价值", name: "f_buildingvalue", width: 80, align: "center" },
                     { label: "今年租赁人", name: "f_renter", width: 80, align: "center" },
                    { label: "今年租金", name: "f_actualprice", width: 80, align: "center" },
                     { label: "去年租赁人", name: "f_renter1", width: 80, align: "center" },
                    { label: "去年租金", name: "f_actualprice1", width: 80, align: "center" },
                     { label: "前年租赁人", name: "f_renter2", width: 80, align: "center" },
                    { label: "前年租金", name: "f_actualprice2", width: 80, align: "center" },
                ],
                mainId: 'f_lbiid',
                isPage: true
            });
            page.search();
        },
        search: function (param) {
            param = param || {};
            query = param;
            $('#gridtable').jfGridSet('reload', { queryJson: JSON.stringify(param) });
        },
    };
    refreshGirdData = function () {
        $('#gridtable').jfGridSet('reload');
    };
    page.init();
}
