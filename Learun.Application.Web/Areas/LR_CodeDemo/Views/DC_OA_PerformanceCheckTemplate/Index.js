/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-03-29 13:48
 * 描  述：DC_OA_PerformanceCheckTemplate
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
                    url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_PerformanceCheckTemplate/Form',
                    width: 600,
                    height: 400,
                    callBack: function (id) {
                        return top[id].acceptClick(refreshGirdData);
                    }
                });
            });
            // 编辑
            $('#lr_edit').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_TemplateId');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'form',
                        title: '编辑',
                        url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_PerformanceCheckTemplate/Form?keyValue=' + keyValue,
                        width: 600,
                        height: 400,
                        callBack: function (id) {
                            return top[id].acceptClick(refreshGirdData);
                        }
                    });
                }
            });
            // 删除
            $('#lr_delete').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_TemplateId');
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否确认删除该项！', function (res) {
                        if (res) {
                            learun.deleteForm(top.$.rootUrl + '/LR_CodeDemo/DC_OA_PerformanceCheckTemplate/DeleteForm', { keyValue: keyValue }, function () {
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
            $('#lr_info').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_Path');
                if (learun.checkrow(keyValue)) {
                    var view = ''
                    switch (keyValue) {
                        case "员工月度考核模板": view = "Form2"; break
                        case "员工年度考核模板": view = "Form1"; break
                        case "部室负责人月度考核模板": view = "Form3"; break
                        case "部室负责人年度考核模板": view = "Form4"; break
                        case "班子成员月度考核模板": view = "Form5"; break
                        case "班子成员年度考核模板": view = "Form6"; break
                        default:
                            break;
                    }
                    learun.layerForm({
                        id: 'form',
                        title: '预览',
                        url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_PerformanceCheck/' + view,
                        width: 800,
                        height: 1200,
                        btn: null
                    });
                }
            });
        },
        // 初始化列表
        initGird: function () {
            $('#gridtable').lrAuthorizeJfGrid({
                url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_PerformanceCheckTemplate/GetPageList',
                headData: [
                    { label: "考核模板名称", name: "F_TemplateName", width: 100, align: "left" },
                    { label: "被考核角色", name: "F_RoleNames", width: 250, align: "left" },
                    {
                        label: "考核模板类型", name: "F_TimeType", width: 100, align: "left",
                        formatterAsync: function (callback, value, row, op, $cell) {
                            learun.clientdata.getAsync('dataItem', {
                                key: value,
                                code: 'PerformanceCheckTemplate',
                                callback: function (_data) {
                                    callback(_data.text);
                                }
                            });
                        }
                    },
                    {
                        label: "考核类别", name: "F_Path", width: 100, align: "left",
                        formatterAsync: function (callback, value, row, op, $cell) {
                            learun.clientdata.getAsync('dataItem', {
                                key: value,
                                code: 'types',
                                callback: function (_data) {
                                    callback(_data.text);
                                }
                            });
                        }
                    },
                    //{ label: "被考核角色", name: "F_Roleid", width: 100, align: "left",
                    //    formatterAsync: function (callback, value, row, op,$cell) {
                    //         learun.clientdata.getAsync('custmerData', {
                    //             url: '/LR_SystemModule/DataSource/GetDataTable?code=' + 'PerformanceAppraisalTemplate',
                    //             key: value,
                    //             keyId: 'f_patid',
                    //             callback: function (_data) {
                    //                 callback(_data['f_templatename']);
                    //             }
                    //         });
                    //    }},

                    {
                        label: "是否启用", name: "F_Enabled", width: 100, align: "left",
                        formatterAsync: function (callback, value, row, op, $cell) {
                            learun.clientdata.getAsync('dataItem', {
                                key: value,
                                code: 'YesOrNo',
                                callback: function (_data) {
                                    callback(_data.text);
                                }
                            });
                        }
                    },
                    { label: "备注", name: "F_Description", width: 100, align: "left" },
                ],
                mainId: 'F_TemplateId',
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
