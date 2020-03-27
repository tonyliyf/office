/* * 版 本 Learun-ADMS V7.0.3 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-03-07 15:15
 * 描  述：DC_ASSETS_BusStopBillboardsRentDetail
 */
var refreshGirdData;
var num = false;
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
                url: top.$.rootUrl + '/AssetManager/DC_ASSETS_BusStopBillboards/GetTree',
                nodeClick: function (item) {
                                 
                    page.search({ F_BSBRMId: item.value });
                }
            });
            $('#multiple_condition_query').lrMultipleQuery(function (queryJson) {
                page.search(queryJson);
            }, 220, 400);
            // 新增
            $('#lr_add').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_BSBRDId');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'form',
                        title: '查看',
                        url: top.$.rootUrl + '/AssetManager/DC_ASSETS_BusStopBillboardsRentDetail/Form?keyValue=' + keyValue,
                        width: 600,
                        height: 600,
                        btn: null
                    });
                }
            });
            // 编辑
            $('#lr_edit').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_BSBRDId');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'form',
                        title: '编辑',
                        url: top.$.rootUrl + '/AssetManager/DC_ASSETS_BusStopBillboardsRentDetail/Form?keyValue=' + keyValue,
                        width: 600,
                        height: 630,
                        callBack: function (id) {
                            return top[id].acceptClick(refreshGirdData);
                        }
                    });
                }
            });
            // 租金
            $('#lr_delete').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_BSBRDId');
           
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: '___form',
                        title: '缴费记录',
                        url: top.$.rootUrl + '/AssetManager/DC_ASSETS_BusStopBillboardsRentIncome/index?F_BSBRDId=' + keyValue,
                        width: 800,
                        height: 600,
                        callBack: function (id) {
                            return top[id].acceptClick();
                        }
                    });
                }
            });
        },
        // 初始化列表
        initGird: function () {
            $('#gridtable').jfGrid({
                url: top.$.rootUrl + '/AssetManager/DC_ASSETS_BusStopBillboardsRentDetail/GetPageList',
                headData: [
                    { label: "租赁人姓名", name: "F_Renter", width: 100, align: "left" },
                    { label: "租赁人单位名称", name: "F_RenterCompany", width: 100, align: "left" },
                    { label: "租赁人联系电话", name: "F_RenterPhone", width: 100, align: "left" },
                    { label: "租赁人身份证号", name: "F_RenterIDNo", width: 100, align: "left" },
                    { label: "评估价", name: "F_ValuationPrice", width: 100, align: "left"},
                    { label: "招租底价", name: "F_RentReservePrice", width: 100, align: "left"},
                    { label: "竟租保证金", name: "F_RentDeposit", width: 100, align: "left"},
                    { label: "出租年限", name: "F_RentAge", width: 100, align: "left"},
                    { label: "实际价格", name: "F_ActualPrice", width: 100, align: "left"},
                    { label: "出租面积", name: "F_RentArea", width: 100, align: "left"},
                    { label: "租赁状态", name: "F_LeaseState", width: 100, align: "left",
                        formatterAsync: function (callback, value, row, op,$cell) {
                             learun.clientdata.getAsync('dataItem', {
                                 key: value,
                                 code: 'HouseRentState1',
                                 callback: function (_data) {
                                     callback(_data.text);
                                 }
                             });
                        }},
                    { label: "招标类型", name: "F_TenderType", width: 100, align: "left",
                        formatterAsync: function (callback, value, row, op,$cell) {
                             learun.clientdata.getAsync('dataItem', {
                                 key: value,
                                 code: 'ProjectTendering',
                                 callback: function (_data) {
                                     callback(_data.text);
                                 }
                             });
                        }},
                    
                    {
                        label: "租赁起始日", name: "F_RentStartTime", width: 100, align: "center", formatterAsync: function (callback, value, row, op, $cell) {
                            if (value.length <= 10) {
                                callback(value);
                            } else {
                                callback(value.substring(0, 10));
                            }
                        }
                    },
                  
                    {
                        label: "租赁结束日", name: "F_RentStartTime", width: 100, align: "center", formatterAsync: function (callback, value, row, op, $cell) {
                            if (value.length <= 10) {
                                callback(value);
                            } else {
                                callback(value.substring(0, 10));
                            }
                        }
                    },
                    { label: "租金提醒", name: "F_RentReminder", width: 100, align: "left"},
                    { label: "租金到期日期", name: "F_ExpireReminder", width: 100, align: "left"},
                  
                    { label: "备注", name: "F_Remarks", width: 100, align: "left"},
                ],
                mainId:'F_BSBRDId',
                isPage: true
            });
            page.search();
        },
        search: function (param) {
            if (num == false) {
                //触发广告到期消息发送事件
                $.post("/AssetManager/DC_ASSETS_BusStopBillboardsRentIncome/SendOsNoticeMsg")
                num = true;
            }
            param = param || {};
            $('#gridtable').jfGridSet('reload',{ queryJson: JSON.stringify(param) });
        }
    };
    refreshGirdData = function () {
        $('#gridtable').jfGridSet('reload');
    };
    page.init();
}
