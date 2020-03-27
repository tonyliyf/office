/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-03-12 12:57
 * 描  述：DC_OA_PerformanceUserWorkInterview
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


            $('#dataTree').lrtree({
                url: top.$.rootUrl + '/Portal/GetDeptUserTree',
                nodeClick: function (item) {
                    page.search({ F_UserId: item.id });

                }
            });
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
                dfvalue: '1',
                selectfn: function (begin, end) {
                    startTime = begin;
                    endTime = end;
                    page.search();
                }
            });
            $('#multiple_condition_query').lrMultipleQuery(function (queryJson) {
                page.search(queryJson);
            }, 220, 400);
            $('#F_BeInterviewDepartment').lrDepartmentSelect();
            $('#F_BeInterviewUser').lrUserSelect(0);
            $('#F_InterviewUser').lrUserSelect(0);
            // 刷新
            $('#lr_refresh').on('click', function () {
                location.reload();
            });
            // 新增
            $('#lr_add').on('click', function () {
                learun.layerForm({
                    id: 'form',
                    title: '新增',
                    url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_PerformanceUserWorkInterview/Form',
                    width: 600,
                    height: 500,
                    callBack: function (id) {
                        return top[id].acceptClick(refreshGirdData);
                    }
                });
            });
            // 编辑
            $('#lr_edit').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_PUWIId');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'form',
                        title: '编辑',
                        url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_PerformanceUserWorkInterview/Form?keyValue=' + keyValue,
                        width: 600,
                        height: 500,
                        callBack: function (id) {
                            return top[id].acceptClick(refreshGirdData);
                        }
                    });
                }
            });
            // 删除
            $('#lr_delete').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_PUWIId');
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否确认删除该项！', function (res) {
                        if (res) {
                            learun.deleteForm(top.$.rootUrl + '/LR_CodeDemo/DC_OA_PerformanceUserWorkInterview/DeleteForm', { keyValue: keyValue }, function () {
                                refreshGirdData();
                            });
                        }
                    });
                }
            });
            //被考核人确认
            $('#btn1').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_PUWIId');
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否确认！', function (res) {
                        if (res) {
                            learun.deleteForm(top.$.rootUrl + '/LR_CodeDemo/DC_OA_PerformanceUserWorkInterview/Execute', { cid: keyValue, r: 1 }, function () {
                                refreshGirdData();
                            });
                        }
                    });
                }
            });
            //被考核人确认
            $('#btn2').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_PUWIId');
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否确认！', function (res) {
                        if (res) {
                            learun.deleteForm(top.$.rootUrl + '/LR_CodeDemo/DC_OA_PerformanceUserWorkInterview/Execute', { cid: keyValue, r: 2 }, function () {
                                refreshGirdData();
                            });
                        }
                    });
                }
            });
            // 考核办意见
            $('#btn3').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_PUWIId');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'form',
                        title: '意见',
                        url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_PerformanceUserWorkInterview/AdviceForm?keyValue=' + keyValue,
                        width: 600,
                        height: 500,
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
        },
        // 初始化列表
        initGird: function () {
            $('#gridtable').jfGrid({
                url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_PerformanceUserWorkInterview/GetPageList',
                headData: [
                    {
                        label: "部门", name: "F_BeInterviewDepartment", width: 120, align: "left",
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
                        label: "被面谈人姓名", name: "F_BeInterviewUser", width: 70, align: "left",
                        formatterAsync: function (callback, value, row, op, $cell) {
                            learun.clientdata.getAsync('user', {
                                key: value,
                                callback: function (_data) {
                                    callback(_data.name);
                                }
                            });
                        }
                    },
                    { label: "岗位", name: "F_BeInterviewPost", width: 100, align: "left" },
                    {
                        label: "面谈人姓名", name: "F_InterviewUser", width: 80, align: "left",
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
                        label: "面谈时间", name: "F_InterviewDate", width: 80, align: "left", formatterAsync: function (callback, value, row, op, $cell) {
                            if (value.length > 10) {
                                callback(value.substring(0, 10));
                            } else {
                                callback(value);
                            }
                        }
                    },
                    { label: "面谈地点", name: "F_InterviewAddress", width: 100, align: "left" },
                    { label: "上周绩效情况", name: "F_InterviewContentA", width: 400, align: "left" },
                    { label: "考核周期成绩", name: "F_InterviewContentB", width: 350, align: "left" },
                    { label: "考核周期工作改进方案", name: "F_InterviewContentC", width: 400, align: "left" },
                    {
                        label: "计划是否一致", name: "F_InterviewContentD", width: 60, align: "left",
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
                ],
                mainId: 'F_PUWIId',
                isPage: true
            });
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
