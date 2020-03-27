/* * 版 本 Learun-ADMS V7.0.3 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-02-13 10:08
 * 描  述：DC_ASSETS_ContactUnit
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
            $('#F_UnitType').lrDataItemSelect({ code: 'UnitType' });
            // 刷新
            $('#lr_refresh').on('click', function () {
                location.reload();
            });
            // 新增
            $('#lr_add').on('click', function () {
                learun.layerForm({
                    id: 'form',
                    title: '新增',
                    url: top.$.rootUrl + '/AssetManager/DC_ASSETS_ContactUnit/Form',
                    width: 600,
                    height: 560,
                    callBack: function (id) {
                        return top[id].acceptClick(refreshGirdData);
                    }
                });
            });
            // 编辑
            $('#lr_edit').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_CUId');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'form',
                        title: '编辑',
                        url: top.$.rootUrl + '/AssetManager/DC_ASSETS_ContactUnit/Form?keyValue=' + keyValue,
                        width: 600,
                        height: 560,
                        callBack: function (id) {
                            return top[id].acceptClick(refreshGirdData);
                        }
                    });
                }
            });
            // 删除
            $('#lr_delete').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_CUId');
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否确认删除该项！', function (res) {
                        if (res) {
                            learun.deleteForm(top.$.rootUrl + '/AssetManager/DC_ASSETS_ContactUnit/DeleteForm', { keyValue: keyValue}, function () {
                                refreshGirdData();
                            });
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
                url: top.$.rootUrl + '/AssetManager/DC_ASSETS_ContactUnit/GetPageList',
                headData: [
                    { label: "单位名称", name: "F_UnitName", width: 200, align: "center"},
                    { label: "单位编号", name: "F_UnitCode", width: 100, align: "center"},
                    { label: "单位类型", name: "F_UnitType", width: 100, align: "center",
                        formatterAsync: function (callback, value, row, op,$cell) {
                             learun.clientdata.getAsync('dataItem', {
                                 key: value,
                                 code: 'UnitType',
                                 callback: function (_data) {
                                     callback(_data.text);
                                 }
                             });
                        }},
                    { label: "联系人", name: "F_Contacts", width: 100, align: "center"},
                    { label: "联系电话", name: "F_ContactPhone", width: 150, align: "center"},
                    { label: "传真", name: "F_ContactFax", width: 100, align: "center"},
                    { label: "邮编", name: "F_PostCode", width: 100, align: "center"},
                    { label: "电子邮箱", name: "F_ContactEmail", width: 100, align: "center"},
                    { label: "联系地址", name: "F_ContactAddress", width: 200, align: "center"},
                    { label: "税号", name: "F_DutyNumber", width: 200, align: "center"},
                    { label: "开户行", name: "F_DepositBank", width: 200, align: "center"},
                    { label: "开户行账户", name: "F_ContactAccount", width: 200, align: "center"},
                    { label: "备注", name: "F_Remarks", width: 300, align: "center"},
                    { label: "使用状态", name: "F_UseState", width: 100, align: "center",
                        formatterAsync: function (callback, value, row, op,$cell) {
                             learun.clientdata.getAsync('dataItem', {
                                 key: value,
                                 code: 'UseState',
                                 callback: function (_data) {
                                     callback(_data.text);
                                 }
                             });
                        }},
                ],
                mainId:'F_CUId',
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
