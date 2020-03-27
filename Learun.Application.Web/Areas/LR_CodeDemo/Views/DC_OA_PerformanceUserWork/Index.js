﻿/* * 版 本 Learun-ADMS V7.0.3 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-01-26 11:12
 * 描  述：DC_OA_PerformanceUserWork
 */
var rid
var refreshGirdData;
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
                url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_PerformanceUserWork/GetTree',
                nodeClick: function (item) {
                    rid = item.value
                }
            });
            // 刷新
            $('#lr_refresh').on('click', function () {
                location.reload();
            });
            //  执行
            $('#btn_excute').on('click', function () {
                if (!rid) {
                    learun.alert.error('请选择考核项')
                    return
                }
                learun.layerConfirm('是否确认执行！', function (res) {
                    if (res) {
                        learun.deleteForm(top.$.rootUrl + '/LR_CodeDemo/DC_OA_PerformanceUserWork/DoExcute', { rid: rid }, function () {
                            location.reload()
                        });
                    }
                });

            });
            //发起考核
            $('#btn_begin').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_PUWId');
                if (learun.checkrow(keyValue)) {
                    if ($('#gridtable').jfGridValue('isChecker') == true) {
                        learun.alert.warning('当前项仅供被考核人填写')
                        return
                    }
                    if ($('#gridtable').jfGridValue('F_PEPoint') != '工作计划') {
                        learun.alert.warning('当前考核已经发起')
                        return
                    }
                    learun.layerForm({
                        id: 'form',
                        title: '编辑',
                        url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_PerformanceUserWorkPlan/Index?keyValue=' + keyValue,
                        width: 800,
                        height: 800,
                        callBack: function (id) {
                            return top[id].acceptClick(function () {
                                location.reload()
                            });
                        }
                    });
                }
            });
            //查看指标
            $('#btn_info').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_PUWId');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: '_ass_a_form',
                        title: '查看',
                        url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_PerformanceExecute/Info?keyValue=' + keyValue,
                        width: 1400,
                        height: 800,
                        callBack: function (id) {
                            return top[id].acceptClick();
                        }
                    });
                }
            })

            //查看流程
            $('#btn_info1').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_PUWId');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: '_ass_a_form',
                        title: '查看',
                        url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_PerformanceExecute/AuditInfoWnd?keyValue=' + keyValue,
                        width: 800,
                        height: 600,
                        btn: null,
                        callBack: function (id) {
                            return top[id].acceptClick();
                        }
                    });
                }
            })
        },
        // 初始化列表
        initGird: function () {
            $('#gridtable').jfGrid({
                url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_PerformanceUserWork/GetPageList',
                headData: [
                    { label: "考核名称", name: "F_PUWName", width: 260, align: "center" },
                    {
                        label: "被考核人", name: "F_PUWUserId", width: 220, align: "center",
                        formatterAsync: function (callback, value, row, op, $cell) {
                            learun.clientdata.getAsync('user', {
                                key: value,
                                callback: function (_data) {
                                    callback(_data.name);
                                }
                            });
                        }
                    },
                    {
                        label: "被考核人部门", name: "F_PUWDepartmentId", width: 210, align: "center",
                        formatterAsync: function (callback, value, row, op, $cell) {
                            learun.clientdata.getAsync('department', {
                                key: value,
                                callback: function (_data) {
                                    callback(_data.name);
                                }
                            });
                        }
                    },
                    { label: "考核周期", name: "F_AppraisalCycleValue", width: 220, align: "center" },
                    { label: "自评权重", name: "F_SelfWeight", width: 100, align: "center" },
                    {
                        label: "任务状态", name: "F_PEPoint", width: 100, align: "center",
                        formatterAsync: function (callback, value, row, op, $cell) {
                            callback('<span class="label label-success">' + value + '</span>');
                        }
                    },
                ],
                mainId: 'F_PUWId',
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
