/* * 版 本 Learun-ADMS V7.0.0 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-01-08 15:54
 * 描  述：DC_OA_OverSeeWorkTaskSplitDelete
 */
var TID = request('keyValue');
var refreshGirdData;
var bootstrap = function ($, learun) {
    "use strict";
    var page = {
        init: function () {
            page.initGird();
            page.bind();
        },
        bind: function () {
            // 刷新
            $('#lr_refresh').on('click', function () {
                location.reload();
            });
            // 新增
            $('#lr_add').on('click', function () {
                learun.layerForm({
                    id: '__form',
                    title: '新增',
                    url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_OverSeeWorkTaskSplitDelete/Form?TID=' + TID,
                    width: 600,
                    height: 420,
                    callBack: function (id) {
                        return top[id].acceptClick(refreshGirdData);
                    }
                });
            });
            // 编辑
            $('#lr_edit').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_SecondId');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: '_____form',
                        title: '编辑',
                        url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_OverSeeWorkTaskSplitDelete/Form?keyValue=' + keyValue + '&TID=' + TID,
                        width: 600,
                        height: 420,
                        callBack: function (id) {
                            return top[id].acceptClick(refreshGirdData);
                        }
                    });
                }
            });
            // 删除
            $('#lr_delete').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_SecondId');
                var isParent = $('#gridtable').jfGridValue('F_ParentId');
                if (learun.checkrow(keyValue)) {
                    var text = isParent && isParent.length > 0 ? '是否确认删除该项！' : '是否连同子节点一起删除！'
                    learun.layerConfirm(text, function (res) {
                        if (res) {
                            learun.deleteForm(top.$.rootUrl + '/LR_CodeDemo/DC_OA_OverSeeWorkTaskSplitDelete/DeleteForm', { keyValue: keyValue }, function () {
                                refreshGirdData();
                            });
                        }
                    });
                }
            });
            // 提醒
            $('#lr_notice').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_SecondId');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: '_____form',
                        title: '提醒',
                        url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_OverSeeWorkTaskSplitDelete/NoticeForm?keyValue=' + keyValue,
                        width: 600,
                        height: 420,
                        callBack: function (id) {
                            return top[id].acceptClick(function () { });
                        }
                    });
                }
            });
            //关联流程
            $('#lr_process').click(function () {
                var keyValue = $('#gridtable').jfGridValue('F_SecondId');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: '____processform__',
                        title: '流程列表',
                        url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_OverSeeWorkTaskSplit/ProcessForm?keyValue=' + keyValue,
                        width: 800,
                        height: 420,
                        callBack: function (id) {
                            return top[id].acceptClick(refreshGirdData);
                        }
                    });
                }
            })
            $('#lr_processinfo').click(function () {
                var keyValue = $('#gridtable').jfGridValue('F_SecondId')
                var pid = $('#gridtable').jfGridValue('F_ProcessId');
                if (learun.checkrow(keyValue)) {
                    if (!pid) {
                        learun.alert.warning('未关联流程')
                        return
                    }
                    learun.layerForm({
                        id: '__processform__',
                        title: '流程信息',
                        url: top.$.rootUrl + '/LR_CodeDemo/WfPrint/Index?taskId=&processId=' + pid,
                        width: 800,
                        height: 420,
                        btm:null
                    });
                }
            })
        },
        // 初始化列表
        initGird: function () {
            $('#gridtable1').jfGrid({
                url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_OverSeeWorkTaskExecute/GetPageListEx',
                headData: [
                    {
                        label: "执行时间", name: "F_ExecuteDate", width: 100, align: "center", formatterAsync: function (callback, value, row, op, $cell) {
                            if (value.length <= 10) {
                                callback(value);
                            } else {
                                callback(value.substring(0, 10));
                            }
                        }
                    },
                    { label: "执行内容", name: "F_ExecuteContent", width: 100, align: "center" }
                ],
                mainId: 'F_ThirdId',
                isPage: true
            });
            $('#gridtable').jfGrid({
                url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_OverSeeWorkTaskSplitDelete/GetList?keyValue=' + TID,
                headData: [
                    { label: "序号", name: "F_code", width: 100, align: "center" },
                    { label: "任务名称", name: "F_TaskName", width: 100, align: "center" },
                    { label: "任务描述", name: "F_TaskContent", width: 300, align: "center" },
                    {
                        label: "起始时间", name: "F_TaskNodeDateFirst", width: 100, align: "center", formatterAsync: function (callback, value, row, op, $cell) {
                            if (value.length <= 10) {
                                callback(value);
                            } else {
                                callback(value.substring(0, 10));
                            }
                        }
                    },
                    {
                        label: "结束时间", name: "F_TaskNodeDate", width: 100, align: "center", formatterAsync: function (callback, value, row, op, $cell) {
                            if (value.length <= 10) {
                                callback(value);
                            } else {
                                callback(value.substring(0, 10));
                            }
                        }
                    },
                    { label: "主办单位", name: "F_OneDepartment", width: 150, align: "center" },
                    { label: "主办人", name: "F_OneUser", width: 100, align: "center" },
                    { label: "主办领导", name: "F_OneLeader", width: 100, align: "center" },
                    { label: "协办单位", name: "F_TwoDepartment", width: 150, align: "center" },
                    { label: "协办人", name: "F_TwoUser", width: 100, align: "center" },
                ],
                mainId: 'F_SecondId',
                parentId: 'F_ParentId',
                isTree: true,
                dblclick: function (rowData) {
                    $('#gridtable1').jfGridSet('reload', { queryJson: JSON.stringify({ keyValue: rowData.F_SecondId }) });
                }
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
