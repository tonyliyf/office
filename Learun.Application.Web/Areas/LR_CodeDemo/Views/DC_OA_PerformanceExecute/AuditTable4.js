/* * 版 本 Learun-ADMS V7.0.3 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-01-26 12:10
 * 描  述：DC_OA_PerformanceExecute
 */
var refreshGirdData;
var bootstrap = function ($, learun) {
    "use strict";
    var page = {
        init: function () {
            page.initGird('gridtable');
            page.bind();
        },
        bind: function () {
            $('#lr_form_tabs').lrFormTab();
            $('#lr_form_tabs ul li').eq(0).trigger('click');
            // 刷新
            $('#lr_refresh').on('click', function () {
                location.reload();
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
            //  评估
            $('#btn_evaluate').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_PUWId');
                if (learun.checkrow(keyValue)) {
                    if ($('#gridtable').jfGridValue('F_PEPoint') != '考核评估') {
                        learun.alert.error('当前任务状态不可评估')
                        return
                    }
                    learun.DocLayerForm({
                        id: 'flowForm',
                        title: '评估意见',
                        url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_PerformanceExecute/AdviceForm?keyValue=' + keyValue,
                        width: 400,
                        height: 400,
                        btn: ["同意", "不同意", "关闭"],
                        callBack: function (id) {
                            return top[id].acceptClick(function () {
                                location.reload()
                            });
                        },
                        callBack1: function (id) {
                            return top[id].acceptClick1(function () {
                                location.reload()
                            });
                        }
                    });
                }
            });
            //  自评
            $('#btn_evaluateSelft1').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_PUWId');
                if (learun.checkrow(keyValue)) {
                    if ($('#gridtable').jfGridValue('F_PEPoint') != '考核自评') {
                        learun.alert.error('当前任务状态不可自评')
                        return
                    }
                    learun.layerForm({
                        id: '_ass_a_form',
                        title: '考核自评',
                        url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_PerformanceExecute/Evaluate1Index?keyValue=' + keyValue,
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
            //  评价
            $('#btn_evaluate2').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_PUWId');
                if (learun.checkrow(keyValue)) {
                    if ($('#gridtable').jfGridValue('F_PEPoint') != '考核评价') {
                        learun.alert.error('当前任务状态不可评价')
                        return
                    }
                    learun.layerForm({
                        id: '_ass_a_form',
                        title: '考核自评',
                        url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_PerformanceExecute/Evaluate2Index?keyValue=' + keyValue,
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
            //  审核
            $('#btn_audit').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_PUWId');
                if (learun.checkrow(keyValue)) {
                    if ($('#gridtable').jfGridValue('F_PEPoint') != '考核审核') {
                        learun.alert.error('当前任务状态不可审核')
                        return
                    }
                    learun.DocLayerForm({
                        id: 'flowForm',
                        title: '审核',
                        url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_PerformanceExecute/AuditForm?keyValue=' + keyValue,
                        width: 400,
                        height: 400,
                        btn: ["同意", "不同意", "关闭"],
                        callBack: function (id) {
                            return top[id].acceptClick(function () {
                                location.reload()
                            });
                        },
                        callBack1: function (id) {
                            return top[id].acceptClick1(function () {
                                location.reload()
                            });
                        }
                    });
                }
            });
        },
        // 初始化列表
        initGird: function () {
            $('#gridtable').jfGrid({
                url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_PerformanceExecute/GetPageList',
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
            page.search();
        },
        search: function (param) {
            param = param || {};
            param.F_PEPoint = '考核审核'
            $('#gridtable').jfGridSet('reload', { queryJson: JSON.stringify(param) });
        }
    };
    refreshGirdData = function () {
        $('#gridtable').jfGridSet('reload');
    };
    page.init();
}
