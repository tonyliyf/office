/* * 版 本 Learun-ADMS V7.0.3 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-02-16 14:32
 * 描  述：DC_ASSETS_HouseRentDetail
 */
var refreshGirdData;
var query;
var bootstrap = function ($, learun) {
    "use strict";
    var page = {
        init: function () {
            page.initGird();
            page.bind();
        },
        bind: function () {
            // 初始化左侧树形数据
            $('#dataTree').lrtree({
                url: top.$.rootUrl + '/AssetManager/DC_ASSETS_HouseRentDetail/GetTree',
                nodeClick: function (item) {
                    if (item.value != 0) {
                        page.search({ F_HRMId: item.value });
                    }
                }
            });
            $('#multiple_condition_query').lrMultipleQuery(function (queryJson) {
                page.search(queryJson);
            }, 220, 400);
            // 刷新
            $('#lr_refresh').on('click', function () {
                location.reload();
            });
            //导出
            $('#lr-export1').on('click', function () {
                learun.download({
                    method: "POST",
                    url: top.$.rootUrl + '/AssetManager/DC_ASSETS_HouseRentDetail/ExportExcel',
                    param: {
                        fileName: "房屋租赁信息表",
                        columnJson: JSON.stringify($('#gridtable').jfGridGet('settingInfo').headData),
                        queryJson: JSON.stringify(query)
                    }
                });
            });
            // 新增
            $('#lr_add').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_HRDId');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'form',
                        title: '查看',
                        url: top.$.rootUrl + '/AssetManager/DC_ASSETS_HouseRentDetail/FormInfo?keyValue=' + keyValue,
                        width:900,
                        height: 800,
                        btn: null
                    });
                }
            });
            // 编辑
            $('#lr_edit').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_HRDId');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'form',
                        title: '编辑',
                        url: top.$.rootUrl + '/AssetManager/DC_ASSETS_HouseRentDetail/FormInfo?keyValue=' + keyValue,
                        width:900,
                        height: 800,
                        callBack: function (id) {
                            return top[id].acceptClick(refreshGirdData);
                        }
                    });
                }
            });
            // 租金
            $('#lr_delete').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_HRDId');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: '___form',
                        title: '缴费记录',
                        url: top.$.rootUrl + '/AssetManager/DC_ASSETS_HouseRentIncome/index?keyValue=' + keyValue,
                        width: 800,
                        height: 800,
                        callBack: function (id) {
                            return top[id].acceptClick();
                        }
                    });
                }
            });
            // 打印
            $('#lr_print').on('click', function () {
                $('#gridtable').jqprintTable();
            });
        },
        // 初始化列表
        initGird: function () {
            $('#gridtable').jfGrid({
                url: top.$.rootUrl + '/AssetManager/DC_ASSETS_HouseRentDetail/GetPageList',
                headData: [
                    { label: "房屋名称", name: "F_HouseID", width: 100, align: "center" },
                    { label: "房屋坐落", name: "F_BuildingAddress", width: 100, align: "center" },
                    { label: "评估价", name: "F_ValuationPrice", width: 100, align: "center" },
                    { label: "招租底价", name: "F_RentReservePrice", width: 100, align: "center" },
                    { label: "竞租保证金", name: "F_RentDeposit", width: 100, align: "center" },
                    //{ label: "原租赁价", name: "F_CreateUser", width: 100, align: "center" },
                  
                     { label: "出租面积", name: "F_RentArea", width: 100, align: "center" },
                    {
                        label: "租赁状态", name: "F_LeaseState", width: 100, align: "center",
                        formatterAsync: function (callback, value, row, op, $cell) {
                            learun.clientdata.getAsync('dataItem', {
                                key: value,
                                code: 'HouseRentState1',
                                callback: function (_data) {
                                    callback(_data.text);
                                }
                            });
                        }
                    },
                    
                    { label: "备注", name: "F_Remarks", width: 300, align: "center" },
                ],
                mainId: 'F_HRDId',
                isPage: true
            });
            page.search();
        },
        search: function (param) {
            param = param || {};
            query = param;
            $('#gridtable').jfGridSet('reload', { queryJson: JSON.stringify(param) });
        }
    };
    refreshGirdData = function () {
        $('#gridtable').jfGridSet('reload');
    };
    page.init();
}
