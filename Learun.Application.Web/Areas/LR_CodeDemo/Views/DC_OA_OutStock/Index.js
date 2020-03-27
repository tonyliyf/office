/* * 版 本 Learun-ADMS V7.0.3 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-01-10 15:49
 * 描  述：DC_OA_OutStock
 */
var refreshGirdData;
var bootstrap = function ($, learun) {
    "use strict";
    var startTime;
    var endTime;
    var page = {
        init: function () {
            page.initGird();
            page.bind();
        },
        bind: function () {
            // 时间搜索框
            $('#datesearch').lrdate({
                dfdata: [
                    { name: '今天', begin: function () { return learun.getDate('yyyy-MM-dd 00:00:00') }, end: function () { return learun.getDate('yyyy-MM-dd 23:59:59') } },
                    { name: '近7天', begin: function () { return learun.getDate('yyyy-MM-dd 00:00:00', 'd', -6) }, end: function () { return learun.getDate('yyyy-MM-dd 23:59:59') } },
                    { name: '近1个月', begin: function () { return learun.getDate('yyyy-MM-dd 00:00:00', 'm', -1) }, end: function () { return learun.getDate('yyyy-MM-dd 23:59:59') } },
                    { name: '近3个月', begin: function () { return learun.getDate('yyyy-MM-dd 00:00:00', 'm', -3) }, end: function () { return learun.getDate('yyyy-MM-dd 23:59:59') } }
                ],
                // 月
                mShow: false,
                premShow: false,
                // 季度
                jShow: false,
                prejShow: false,
                // 年
                ysShow: false,
                yxShow: false,
                preyShow: false,
                yShow: false,
                // 默认
                dfvalue: '-1',
                selectfn: function (begin, end) {
                    startTime = begin;
                    endTime = end;
                    page.search();
                }
            });
            $('#multiple_condition_query').lrMultipleQuery(function (queryJson) {
                page.search(queryJson);
            }, 220, 400);
            $('#DC_OA_OutStockState').lrDataItemSelect({ code: 'StockOutNo' });
            // 刷新
            $('#lr_refresh').on('click', function () {
                location.reload();
            });
            // 新增
            $('#lr_add').on('click', function () {
                learun.layerForm({
                    id: 'form',
                    title: '新增',
                    url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_OutStock/Form',
                    width: 700,
                    height: 650,
                    callBack: function (id) {
                        return top[id].acceptClick(refreshGirdData);
                    }
                });
            });
            // 编辑
            $('#lr_edit').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('DC_OA_OutStockId');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'form',
                        title: '编辑',
                        url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_OutStock/Form?keyValue=' + keyValue,
                        width: 700,
                        height: 650,
                        callBack: function (id) {
                            return top[id].acceptClick(refreshGirdData);
                        }
                    });
                }
            });
            // 删除
            $('#lr_delete').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('DC_OA_OutStockId');
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否确认删除该项！', function (res) {
                        if (res) {
                            learun.deleteForm(top.$.rootUrl + '/LR_CodeDemo/DC_OA_OutStock/DeleteForm', { keyValue: keyValue }, function () {
                                refreshGirdData();
                            });
                        }
                    });
                }
            });
            //  出库
            $('#btn_stockOut').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('DC_OA_OutStockId');
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否确认出库，出库后不能修改！', function (res) {
                        if (res) {
                            learun.postForm(top.$.rootUrl + '/LR_CodeDemo/DC_OA_OutStock/OutStock', { keyValue: keyValue }, function () {
                                refreshGirdData();
                            });
                        }
                    });
                }

            });
        },
        // 初始化列表
        initGird: function () {
            $('#gridtable').jfGrid({
                url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_OutStock/GetPageList',
                headData: [
                    { label: "出库单据", name: "DC_OA_OutStockNo", width: 250, align: "left" },
                    { label: "日期", name: "DC_OA_OutStockTime", width: 200, align: "left" },
                    { label: "金额（元）", name: "DC_OA_OutStockMoney", width: 300, align: "left" },
                    {
                        label: "出库状态", name: "DC_OA_OutStockState", width: 300, align: "left",
                        formatterAsync: function (callback, value, row, op, $cell) {
                            learun.clientdata.getAsync('dataItem', {
                                key: value,
                                code: 'StockOutNo',
                                callback: function (_data) {
                                    //callback(_data.text);
                                    if (_data.text == "未出库") {
                                        callback('<span class=\"label label-success\" style=\"cursor: pointer;\">未出库</span>');
                                    } else {
                                        callback('<span class=\"label label-default\" style=\"cursor: pointer;\">已出库</span>');
                                    }
                                }
                            });
                        }
                    },
                ],
                mainId: 'DC_OA_OutStockId',
                isPage: true
            });
            page.search();
        },
        search: function (param) {
            param = param || {};
            param.StartTime = startTime;
            param.EndTime = endTime;
            $('#gridtable').jfGridSet('reload', { queryJson: JSON.stringify(param) });
        }
    };
    refreshGirdData = function () {
        $('#gridtable').jfGridSet('reload');
    };
    page.init();
}
