/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-02-05 15:24
 * 描  述：DC_OA_PurchaseAudit
 */
var selectedRow;
var refreshGirdData;
var isPower = request('isPower')
var bootstrap = function ($, learun) {
    "use strict";
    var page = {
        init: function () {
            page.initGird();
            page.bind();
        },
        bind: function () {
            // 查询
            $('#btn_Search').on('click', function () {
                var keyword = $('#txt_Keyword').val();
                page.search({ keyword: keyword });
            });
            // 刷新
            $('#lr_refresh').on('click', function () {
                location.reload();
            });
            // 新增
            $('#lr_add').on('click', function () {
                selectedRow = null;
                learun.layerForm({
                    id: 'form',
                    title: '新增',
                    url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_PurchaseAudit/Form',
                    width: 700,
                    height: 400,
                    callBack: function (id) {
                        return top[id].acceptClick(refreshGirdData);
                    }
                });
            });
            // 编辑
            $('#lr_edit').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_PurchaseAuditId');
                selectedRow = $('#gridtable').jfGridGet('rowdata');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'form',
                        title: '编辑',
                        url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_PurchaseAudit/Form?keyValue=' + keyValue,
                        width: 700,
                        height: 400,
                        callBack: function (id) {
                            return top[id].acceptClick(refreshGirdData);
                        }
                    });
                }
            });
            // 删除
            $('#lr_delete').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_PurchaseAuditId');
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否确认删除该项！', function (res) {
                        if (res) {
                            learun.deleteForm(top.$.rootUrl + '/LR_CodeDemo/DC_OA_PurchaseAudit/DeleteForm', { keyValue: keyValue }, function () {
                            });
                        }
                    });
                }
            });
            $('#lr_open').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_PurchaseAuditId');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'form',
                        title: '查看文件',
                        url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_PurchaseAudit/OpenDoc?keyValue=' + keyValue,
                        width: 1080,
                        height: 850,
                        callBack: function (id) {
                            return top[id].acceptClick(refreshGirdData);
                        }
                    });
                }
            });
            // 打印
            $('#lr_print').on('click', function () {
                $('#gridtable').jqprintTable();
            });
            $('#lr_file').click(function () {
                var keyValue = $('#gridtable').jfGridValue('F_PurchaseAuditId');
                if (learun.checkrow(keyValue)) {
                    var FIDS = $('#gridtable').jfGridValue('F_PurchaseFile') + ','
                        + $('#gridtable').jfGridValue('F_PurchaseListFile') + ',' + $('#gridtable').jfGridValue('F_PurchaseImageFile')
                    top.learun.frameTab.open({
                        F_ModuleId: $('#gridtable').jfGridValue('F_PurchaseFile'), F_Icon: '',
                        F_FullName: '附件信息查看', F_UrlAddress: '/LR_CodeDemo/FileViewer/Index?FIDS=' + FIDS
                    });
                }
            })
        },
        initGird: function () {
            $('#gridtable').jfGrid({
                url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_PurchaseAudit/GetPageList?isPower=' + isPower,
                headData: [
                    { label: '采购项目名称', name: 'F_PurchaseName', width: 200, align: "center" },
                    { label: '采购项目编号', name: 'F_PurchaseProjectNo', width: 200, align: "center" },
                    { label: '采购项目分类', name: 'F_PurchaseProjectType', width: 150, align: "center" },
                    { label: '采购物资分类', name: 'F_PurchaseWoodType', width: 100, align: "center" },
                    {
                        label: '采购部门', name: 'F_CurrentDeptId', width: 200, align: "center",
                        formatterAsync: function (callback, value, row, op, $cell) {
                            learun.clientdata.getAsync('department', {
                                key: value,
                                callback: function (_data) {
                                    callback(_data.name);
                                }
                            });
                        }
                    },
                    {
                        label: "采购代理机构", name: "F_PurchaseCompanyId", width: 150, align: "left",
                        formatterAsync: function (callback, value, row, op, $cell) {
                            learun.clientdata.getAsync('custmerData', {
                                url: '/LR_SystemModule/DataSource/GetDataTable?code=' + 'GetPurchaseToCompany',
                                key: value,
                                keyId: 'f_unitname',
                                callback: function (_data) {
                                    callback(_data['f_cuid']);
                                }
                            });
                        }
                    },

                    { label: '代理服务费（单位元）', name: 'F_ServiceMoney', width: 100, align: "center" },
                    {
                        label: '经办人', name: 'F_CreateUserId', width: 200, align: "center",
                        formatterAsync: function (callback, value, row, op, $cell) {
                            learun.clientdata.getAsync('user', {
                                key: value,
                                callback: function (_data) {
                                    callback(_data.name);
                                }
                            });
                        }
                    },

                    { label: '预算金额（单位万元）', name: 'F_DealMoney', width: 200, align: "center" },
                    { label: '采购方式', name: 'F_PurchaseMethod', width: 200, align: "center" },

                    { label: '交易平台', name: 'F_buyPlatform', width: 200, align: "center" },
                    { label: '投标保证金', name: 'F_DepositMoney', width: 200, align: "center" },
                    { label: '经办人联系电话', name: 'F_DealUserPhone', width: 200, align: "center" },
                ],
                mainId: 'F_PurchaseAuditId',
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
