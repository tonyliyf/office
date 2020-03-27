/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-03-09 13:57
 * 描  述：DC_EngineProject_ProjectInfo
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
            //// 初始化左侧树形数据
            //$('#dataTree').lrtree({
            //    url: top.$.rootUrl + '/ProjectManager/DC_EngineProject_ProjectInfo/GetTree',
            //    nodeClick: function (item) {
            //        page.search({ F_JRYCompany: item.value });
            //    }
            //});
            // 时间搜索框
            //$('#datesearch').lrdate({
            //    dfdata: [
            //        { name: '今天', begin: function () { return learun.getDate('yyyy-MM-dd 00:00:00') }, end: function () { return learun.getDate('yyyy-MM-dd 23:59:59') } },
            //        { name: '近7天', begin: function () { return learun.getDate('yyyy-MM-dd 00:00:00', 'd', -6) }, end: function () { return learun.getDate('yyyy-MM-dd 23:59:59') } },
            //        { name: '近1个月', begin: function () { return learun.getDate('yyyy-MM-dd 00:00:00', 'm', -1) }, end: function () { return learun.getDate('yyyy-MM-dd 23:59:59') } },
            //        { name: '近3个月', begin: function () { return learun.getDate('yyyy-MM-dd 00:00:00', 'm', -3) }, end: function () { return learun.getDate('yyyy-MM-dd 23:59:59') } }
            //    ],
            //    // 月
            //    mShow: false,
            //    premShow: false,
            //    // 季度
            //    jShow: false,
            //    prejShow: false,
            //    // 年
            //    ysShow: false,
            //    yxShow: false,
            //    preyShow: false,
            //    yShow: false,
            //    // 默认
            //    dfvalue: '1',
            //    selectfn: function (begin, end) {
            //        startTime = begin;
            //        endTime = end;
            //        page.search();
            //    }
            //});

            //$('#multiple_condition_query').lrMultipleQuery(function (queryJson) {
            //    page.search(queryJson);
            //}, 220, 400);
            //$('#F_JRYCompany').lrDataSourceSelect({ code: 'company', value: 'f_companyid', text: 'f_shortname' });
            // 刷新
            //$('#lr_refresh').on('click', function () {
            //    location.reload();
            //});
            // 新增
            $('#lr_add1').on('click', function () {
                learun.layerForm({
                    id: 'form',
                    title: '新增',
                    url: top.$.rootUrl + '/ProjectManager/DC_EngineProject_ProjectInfo/Form',
                    width: 600,
                    height: 500,
                    callBack: function (id) {
                        return top[id].acceptClick(refreshGirdData);
                    }
                });
            });
            // 编辑
            $('#lr_edit1').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_PIId');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'form',
                        title: '编辑',
                        url: top.$.rootUrl + '/ProjectManager/DC_EngineProject_ProjectInfo/Form?keyValue=' + keyValue,
                        width: 600,
                        height: 500,
                        callBack: function (id) {
                            return top[id].acceptClick(refreshGirdData);
                        }
                    });
                }
            });
            // 删除
            $('#lr_delete1').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_PIId');
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否确认删除该项！', function (res) {
                        if (res) {
                            learun.deleteForm(top.$.rootUrl + '/ProjectManager/DC_EngineProject_ProjectInfo/DeleteForm', { keyValue: keyValue }, function () {
                                refreshGirdData();
                            });
                        }
                    });
                }
            });
            // 打印
            $('#lr_print1').on('click', function () {
                $('#gridtable').jqprintTable();
            });
        },
        // 初始化列表
        initGird: function () {
            $('#gridtable').jfGrid({
                url: top.$.rootUrl + '/ProjectManager/DC_EngineProject_ProjectInfo/GetPageList',
                headData: [
                    { label: "项目编号", name: "F_ProjectItemNumber", width: 100, align: "left" },
                    { label: "项目名称", name: "F_ProjectName", width: 100, align: "left" },
                    {
                        label: "项目所属公司", name: "F_JRYCompany", width: 100, align: "left",
                        formatterAsync: function (callback, value, row, op, $cell) {
                            learun.clientdata.getAsync('custmerData', {
                                url: '/LR_SystemModule/DataSource/GetDataTable?code=' + 'company',
                                key: value,
                                keyId: 'f_companyid',
                                callback: function (_data) {
                                    callback(_data['f_shortname']);
                                }
                            });
                        }
                    },
                    {
                        label: "项目建设类型", name: "F_ProjectBuildType", width: 100, align: "left",
                        formatterAsync: function (callback, value, row, op, $cell) {
                            learun.clientdata.getAsync('dataItem', {
                                key: value,
                                code: 'EngineeringProjectBuildType',
                                callback: function (_data) {
                                    callback(_data.text);
                                }
                            });
                        }
                    },
                    {
                        label: "项目规模管理分类", name: "F_ProjectSizeClassify", width: 100, align: "left",
                        formatterAsync: function (callback, value, row, op, $cell) {
                            learun.clientdata.getAsync('dataItem', {
                                key: value,
                                code: 'EngineeringProjectScale',
                                callback: function (_data) {
                                    callback(_data.text);
                                }
                            });
                        }
                    },
                    {
                        label: "项目状态", name: "F_ProjectState", width: 100, align: "left",
                        formatterAsync: function (callback, value, row, op, $cell) {
                            learun.clientdata.getAsync('dataItem', {
                                key: value,
                                code: 'OS_F_State',
                                callback: function (_data) {
                                    callback(_data.text);
                                }
                            });
                        }
                    },
                    { label: "立项年度", name: "F_ProjectYear", width: 100, align: "left" },
                    {
                        label: "行政区域", name: "F_CommunityCode", width: 100, align: "left",
                        formatterAsync: function (callback, value, row, op, $cell) {
                            learun.clientdata.getAsync('dataItem', {
                                key: value,
                                code: '',
                                callback: function (_data) {
                                    callback(_data.text);
                                }
                            });
                        }
                    },
                    { label: "项目地址", name: "F_ProjectAddress", width: 100, align: "left" },
                    {
                        label: "立项日期", name: "F_ProjectApprovalDate", width: 100, align: "center", formatter: function (value) {
                            if (value && value.length > 10) {
                                return value.substr(0, 10)
                            } else {
                                return value
                            }
                        }
                    },
                    {
                        label: "计划开工时间", name: "F_PlannedStartDate", width: 100, align: "center", formatter: function (value) {
                            if (value && value.length > 10) {
                                return value.substr(0, 10)
                            } else {
                                return value
                            }
                        }
                    },
                    {
                        label: "计划完工时间", name: "F_PlannedEndDate", width: 100, align: "center", formatter: function (value) {
                            if (value && value.length > 10) {
                                return value.substr(0, 10)
                            } else {
                                return value
                            }
                        }
                    },
                 
                ],
                mainId: 'F_PIId',
                isPage: true,
                dblclick: function (rowdata) {
                    $('#ifr1').attr('src', '../DC_EngineProject_ProjectInfoApprovalData/Indexz?keyValue=' + rowdata.F_PIId);
                }
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