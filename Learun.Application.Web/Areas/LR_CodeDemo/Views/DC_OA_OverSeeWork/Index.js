/* * 版 本 Learun-ADMS V7.0.0 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-01-07 11:19
 * 描  述：DC_OA_OverSeeWork
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
            // 初始化左侧树形数据
            $('#dataTree').lrtree({
                url: top.$.rootUrl + '/LR_CodeDemo/WfTree/GetDeptTree',
                nodeClick: function (item) {
                    page.search({ F_DepartmentId: item.id });
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
                dfvalue: '-1',
                selectfn: function (begin, end) {
                    startTime = begin;
                    endTime = end;
                    page.search();
                }
            });
            $('#multiple_condition_query').lrMultipleQuery(function (queryJson) {
                page.search(queryJson);
            }, 220, 400);
            $('#F_State').lrDataItemSelect({ code: 'OS_F_State' });
            // 刷新
            $('#lr_refresh').on('click', function () {
                location.reload();
            });
            // 新增
            $('#lr_add').on('click', function () {
                learun.layerForm({
                    id: 'form',
                    title: '新增',
                    url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_OverSeeWork/Form',
                    width: 600,
                    height: 600,
                    callBack: function (id) {
                        return top[id].acceptClick(refreshGirdData);
                    }
                });
            });
            // 编辑
            $('#lr_edit').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_OSWId');
                if (learun.checkrow(keyValue)) {
                    var draft = $('#gridtable').jfGridValue('F_Draft')
                    if (draft == 0) {
                        learun.alert.warning('非草稿状态无法编辑')
                        return
                    }
                    learun.layerForm({
                        id: 'form',
                        title: '编辑',
                        url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_OverSeeWork/Form?keyValue=' + keyValue,
                        width: 600,
                        height: 600,
                        callBack: function (id) {
                            return top[id].acceptClick(refreshGirdData);
                        }
                    });
                }
            });
            // 删除
            $('#lr_delete').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_OSWId');
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否确认删除该项！', function (res) {
                        if (res) {
                            learun.deleteForm(top.$.rootUrl + '/LR_CodeDemo/DC_OA_OverSeeWork/DeleteForm', { keyValue: keyValue }, function () {
                                refreshGirdData();
                            });
                        }
                    });
                }
            });
            //下达
            $('#lr_send').click(function () {
                var keyValue = $('#gridtable').jfGridValue('F_OSWId')
                if (learun.checkrow(keyValue)) {
                    var draft = $('#gridtable').jfGridValue('F_State')
                    if (draft != '草稿') {
                        learun.alert.warning('非草稿状态无法下达')
                        return
                    }
                    learun.layerConfirm('是否确认下达！', function (res) {
                        if (res) {
                            learun.deleteForm(top.$.rootUrl + '/LR_CodeDemo/DC_OA_OverSeeWork/EnterOverSeeWork', { keyValue: keyValue }, function () {
                                refreshGirdData();
                            });
                        }
                    });
                }
            })
            // 打印
            $('#lr_print').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_OSWId')
                if (learun.checkrow(keyValue)) {
                    learun.DocLayerForm({
                        id: 'printform',
                        title: '打印',
                        url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_OverSeeWork/OverSeePrint?keyValue=' + keyValue,
                        width: 800,
                        height: 900,
                        btn: ['打印', '关闭'],
                        callBack: function (id) {
                            return top[id].printClick(function () {

                            });
                        },
                        callBack1: function (id) {
                            return top[id].acceptClick1(function () {

                            });
                        }
                    });
                }
            });
            //查看附件
            $('#lr_file').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_OSWId')
                if (learun.checkrow(keyValue)) {
                    var FIDS = $('#gridtable').jfGridValue('F_Attachments')
                    top.learun.frameTab.open({
                        F_ModuleId: FIDS, F_Icon: '',
                        F_FullName: '附件信息查看', F_UrlAddress: '/LR_CodeDemo/FileViewer/Index?FIDS=' + FIDS
                    });
                }
            })
        },
        // 初始化列表
        initGird: function () {
            $('#gridtable').jfGrid({
                url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_OverSeeWork/GetPageList',
                headData: [
                    {
                        label: "状态", name: "F_State", width: 100, align: "center", formatter: function (value) {
                            switch (value) {
                                case '执行中': return '<span class="label label-info">执行中</span>'
                                case '延期': return '<span class="label label-warning">延期</span>'
                                case '草稿': return '<span class="label label-warning">草稿</span>'
                                case '办结': return '<span class="label label-success">办结</span>'
                                case '逾期': return '<span class="label label-danger">逾期</span>'
                                case '临近': return '<span class="label label-warning">临近</span>'
                                default:
                                    return value
                            }
                        }
                    },
                    { label: "工作主题", name: "F_OSCaptain", width: 100, align: "center" },
                    { label: "督办类型", name: "F_OSWType", width: 120, align: "center" },
                    { label: "工作事项", name: "F_OSWContent", width: 400, align: "center" },
                    {
                        label: "负责人", name: "F_LeaderUser", width: 100, align: "center"
                    },
                    {
                        label: "开始时间", name: "F_BeginDate", width: 150, align: "center", formatterAsync: function (callback, value, row, op, $cell) {
                            if (value.length > 10) {
                                callback(value.substring(0, 10));
                            } else {
                                callback(value);
                            }
                        }
                    },
                    {
                        label: "结束时间", name: "F_EndDate", width: 150, align: "center", formatterAsync: function (callback, value, row, op, $cell) {
                            if (value.length <= 10) {
                                callback(value);
                            } else {
                                callback(value.substring(0, 10));
                            }
                        }
                    },
                    {
                        label: "牵头部门", name: "F_DepartmentId", width: 150, align: "center",
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
                        label: "责任领导", name: "F_HighLeaderId", width: 100, align: "center",
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
                        label: "督办人", name: "F_OverSeeUserId", width: 100, align: "center",
                        formatterAsync: function (callback, value, row, op, $cell) {
                            learun.clientdata.getAsync('user', {
                                key: value,
                                callback: function (_data) {
                                    callback(_data.name);
                                }
                            });
                        }
                    },
                    { label: "登记来源", name: "F_VisitFrom", width: 100, align: "center" },
                    { label: "备注", name: "F_Marks", width: 300, align: "center" },
                ],
                mainId: 'F_OSWId',
                isPage: true
            });
            page.search();
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
