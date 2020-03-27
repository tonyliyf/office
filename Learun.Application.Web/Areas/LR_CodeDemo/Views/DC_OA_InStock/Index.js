/* * 版 本 Learun-ADMS V7.0.0 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-01-03 15:50
 * 描  述：DC_OA_InStock
 */
var refreshGirdData;
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
            }, 220, 400);
            $('#DC_OA_InStockState').lrDataItemSelect({ code: 'officeWoodsInstockState' });
            // 刷新
            $('#lr_refresh').on('click', function () {
                location.reload();
            });
            // 新增
            $('#lr_add').on('click', function () {
                learun.layerForm({
                    id: 'form',
                    title: '新增',
                    url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_InStock/Form',
                    width: 700,
                    height: 650,
                    callBack: function (id) {
                        return top[id].acceptClick(refreshGirdData);
                    }
                });
            });
            // 编辑
            $('#lr_edit').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('DC_OA_InStockId');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'form',
                        title: '编辑',
                        url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_InStock/Form?keyValue=' + keyValue,
                        width: 700,
                        height: 650,
                        callBack: function (id) {
                            return top[id].acceptClick(refreshGirdData);
                        }
                    });
                }
            });

            // 入库
            $('#lr_InStock').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('DC_OA_InStockId');
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否确认入库，入库后不能修改！', function (res) {
                        if (res) {
                            learun.postForm(top.$.rootUrl + '/LR_CodeDemo/DC_OA_InStock/InStock', { keyValue: keyValue }, function () {
                                refreshGirdData();
                            });
                        }
                    });
                }
               
            });
            // 删除
            $('#lr_delete').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('DC_OA_InStockId');
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否确认删除该项！', function (res) {
                        if (res) {
                            learun.deleteForm(top.$.rootUrl + '/LR_CodeDemo/DC_OA_InStock/DeleteForm', { keyValue: keyValue}, function () {
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
                url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_InStock/GetPageList',
                headData: [
                    { label: "入库单据", name: "DC_OA_InStockNo", width: 250, align: "left"},
                    { label: "日期", name: "DC_OA_InStockTime", width: 200, align: "left"},
                    { label: "金额(元）", name: "DC_OAInStockMoney", width: 200, align: "left"},
                    { label: "经办人", name: "F_CurrentUserId", width: 300, align: "left",
                        formatterAsync: function (callback, value, row, op,$cell) {
                             learun.clientdata.getAsync('user', {
                                 key: value,
                                 callback: function (_data) {
                                     callback(_data.name);
                                 }
                             });
                        }},
                    { label: "入库状态", name: "DC_OA_InStockState", width: 100, align: "left",
                        formatterAsync: function (callback, value, row, op,$cell) {
                             learun.clientdata.getAsync('dataItem', {
                                 key: value,
                                 code: 'officeWoodsInstockState',
                                 callback: function (_data) {
                                    
                                     if (_data.text =="未入库") {
                                         callback('<span class=\"label label-success\" style=\"cursor: pointer;\">未入库</span>');
                                     } else{
                                         callback('<span class=\"label label-default\" style=\"cursor: pointer;\">已入库</span>');
                                     }
                                    // callback(text);
                                 }
                             });
                        }},
                ],
                mainId:'DC_OA_InStockId',
                isPage: true
            });
            page.search();
        },
        search: function (param) {
            param = param || {};
            $('#gridtable').jfGridSet('reload',{ queryJson: JSON.stringify(param) });
        }
    };
    refreshGirdData = function () {
        $('#gridtable').jfGridSet('reload');
    };
    page.init();
}
