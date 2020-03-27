/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn) 
 * Copyright (c) 2013-2018 上海力软信息技术有限公司 
 * 创建人：超级管理员 
 * 日  期：2019-02-07 14:22 
 * 描  述：DC_OA_PurchasePublic 
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
            // 刷新 
            $('#lr_refresh').on('click', function () {
                location.reload();
            });
            // 新增 
            $('#lr_add').on('click', function () {
                learun.layerForm({
                    id: 'form',
                    title: '新增',
                    url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_PurchasePublic/Form',
                    width: 650,
                    height: 600,
                    callBack: function (id) {
                        return top[id].acceptClick(refreshGirdData);
                    }
                });
            });

            $('#lr_open').on('click', function () {

                var keyValue = $('#gridtable').jfGridValue('F_PurchasePublicId');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'form',
                        title: '查看开标公告',
                        url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_PurchasePublic/OpenDoc?keyValue=' + keyValue,
                        width: 1080,
                        height: 850,
                        callBack: function (id) {
                            return top[id].acceptClick(refreshGirdData);
                        }
                    });
                }
            });

            $('#lr_openTitle').on('click', function () {

                var keyValue = $('#gridtable').jfGridValue('F_PurchasePublicId');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'form',
                        title: '查看开标页头',
                        url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_PurchasePublic/OpenDocTitle?keyValue=' + keyValue,
                        width: 1080,
                        height: 850,
                        callBack: function (id) {
                            return top[id].acceptClick(refreshGirdData);
                        }
                    });
                }
            });

            // 编辑 
            $('#lr_edit').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_PurchasePublicId');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'form',
                        title: '编辑',
                        url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_PurchasePublic/Form?keyValue=' + keyValue,
                        width: 650,
                        height: 600,
                        callBack: function (id) {
                            return top[id].acceptClick(refreshGirdData);
                        }
                    });
                }
            });
            // 删除 
            $('#lr_delete').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_PurchasePublicId');
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否确认删除该项！', function (res) {
                        if (res) {
                            learun.deleteForm(top.$.rootUrl + '/LR_CodeDemo/DC_OA_PurchasePublic/DeleteForm', { keyValue: keyValue }, function () {
                                refreshGirdData();
                            });
                        }
                    });
                }
            });

            // 修改状态
            $('#lr_complete').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_PurchasePublicId');
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否确认已完成，提交后不能再修改！', function (res) {
                        if (res) {
                            learun.postForm(top.$.rootUrl + '/LR_CodeDemo/DC_OA_PurchasePublic/update', { keyValue: keyValue }, function () {
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
                url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_PurchasePublic/GetPageList',
                headData: [
                    { label: "采购项目", name: "F_PurchaseName", width: 150, align: "center" },
                    { label: "项目编号", name: "F_PurchaseProjectNo", width: 120, align: "center" },
                    { label: "采购单位", name: "F_CurrentCompanyName", width: 200, align: "center" },
                    { label: "采购部门", name: "F_CurrentDeptName", width: 150, align: "center" },
                    { label: "交易方式", name: "F_PurchaseMethod", width: 80, align: "center" },
                    { label: "交易平台", name: "F_buyPlatform", width: 80, align: "center" },
                    { label: "交易预算(万元)", name: "F_DealMoney", width: 100, align: "center" },
                    { label: "采购经办人", name: "F_CreateUserName", width: 100, align: "center" },
                    { label: "联系电话", name: "F_DealUserPhone", width: 100, align: "center" },
                    {
                        label: "状态", name: "Is_agree", width: 80, align: "center",
                        formatter: function (cellvalue, row) {
                               if (cellvalue == "2") {
                                    return '<span class=\"label label-success\" style=\"cursor: pointer;\">已提交</span>';
                                } else {
                                    return '<span class=\"label label-default\" style=\"cursor: pointer;\">未提交</span>';
                                }
                           
                        }
                    },
                ],
                mainId: 'F_PurchasePublicId',
                isPage: true
            });
            page.search();
        },
        search: function (param) {
            param = param || {};
            $('#gridtable').jfGridSet('reload', { queryJson: JSON.stringify(param) });
        }
    };
    refreshGirdData = function () {
        $('#gridtable').jfGridSet('reload');
    };
    page.init();
} 