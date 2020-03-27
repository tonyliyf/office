/* * 版 本 Learun-ADMS V7.0.0 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-01-08 15:54
 * 描  述：DC_OA_OverSeeWorkTaskSplitDelete
 */
var TID = request('keyValue');
var TPID
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
                var keyValue = $('#gridtable').jfGridValue('F_SecondId');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: '__form',
                        title: '新增',
                        url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_OverSeeWorkTaskSplitDelete/ExecuteForm?TID=' + TPID,
                        width: 600,
                        height: 420,
                        callBack: function (id) {
                            return top[id].acceptClick(refreshGirdData);
                        }
                    });
                }
            });
            // 编辑
            $('#lr_edit').on('click', function () {
                var keyValue = $('#gridtable1').jfGridValue('F_ThirdId');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: '_____form',
                        title: '编辑',
                        url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_OverSeeWorkTaskSplitDelete/ExecuteForm?keyValue=' + keyValue + '&TID=' + TPID,
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
                var keyValue = $('#gridtable1').jfGridValue('F_ThirdId');
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否确认删除该项！', function (res) {
                        if (res) {
                            learun.deleteForm(top.$.rootUrl + '/LR_CodeDemo/DC_OA_OverSeeWorkTaskExecute/DeleteFormEx', { keyValue: keyValue }, function () {
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
                url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_OverSeeWorkTaskSplitDelete/GetListEx?keyValue=' + TID,
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
                onSelectRow: function (rowData) {
                    TPID = rowData.F_SecondId
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
        $('#gridtable1').jfGridSet('reload', { queryJson: JSON.stringify({ keyValue: TPID }) });
    };
    page.init();
}
