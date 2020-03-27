/* * 版 本 Learun-ADMS V7.0.0 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-01-07 17:28
 * 描  述：DC_OA_OverSeeWorkTaskSplit
 */
var refreshGirdData;
var currentTaskId;
var bootstrap = function ($, learun) {
    "use strict";
    var startTime="1753-01-01";
    var endTime="3000-01-01";
    var page = {
        init: function () {
            page.initGird();
            page.bind();
        },
        bind: function () {
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
            // 刷新
            $('#lr_refresh').on('click', function () {
                location.reload();
            });
            $('#lr_taskSplit').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_PIId');
                if (learun.checkrow(keyValue)) {
                    currentTaskId = keyValue
                    learun.layerForm({
                        id: '__form',
                        title: '任务分解',
                        url: top.$.rootUrl + '/ProjectManager/DC_EngineProject_ProjectTasks/Index?keyValue=' + keyValue,
                        width: 1500,
                        height: 600,
                        btn: null,
                        end: function (id) {
                            page.renderGantt()
                        }
                    })
                }
            });
        },
        // 初始化列表
        initGird: function () {
            $('#gridtable').jfGrid({
                url: top.$.rootUrl + '/ProjectManager/DC_EngineProject_ProjectInfo/GetPageList',
                headData: [
                    { label: "项目编号", name: "F_ProjectItemNumber", width: 150, align: "center" },
                    { label: "项目名称", name: "F_ProjectName", width: 100, align: "center" },
                    {
                        label: "项目所属公司", name: "F_JRYCompany", width: 100, align: "center",
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
                        label: "项目建设类型", name: "F_ProjectBuildType", width: 100, align: "center",
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
                        label: "项目规模管理分类", name: "F_ProjectSizeClassify", width: 100, align: "center",
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
                        label: "项目状态", name: "F_ProjectState", width: 100, align: "center",
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
                    { label: "立项年度", name: "F_ProjectYear", width: 100, align: "center" },
                    {
                        label: "行政区域", name: "F_CommunityCode", width: 100, align: "center",
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
                    { label: "项目地址", name: "F_ProjectAddress", width: 100, align: "center" },
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
                dblclick: function (rowdata) {
                    currentTaskId = rowdata.F_PIId
                    page.renderGantt()
                },
                mainId: 'F_PIId',
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
        //,
        //renderGantt: function () {
        //    $.post(top.$.rootUrl + '/ProjectManager/DC_EngineProject_ProjectTasks/GetGanttData', { keyValue: currentTaskId }, function (data) {
        //        var source = data
        //        var maxLength = 200
        //        source = AppendSource(source, maxLength)
        //        $("#gantt").gantt({
        //            source: source,
        //            scale: "days",
        //            minScale: "days",
        //            maxScale: "days",
        //            onItemClick: function (data) {
        //                learun.layerForm({
        //                    id: 'form',
        //                    title: '节点详情',
        //                    url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_OverSeeWorkTaskSplit/Form2?keyValue=' + data.id,
        //                    width: 800,
        //                    height: 800,
        //                    btn: null
        //                })
        //            },
        //            itemsPerPage: maxLength
        //        })
        //    }, 'json')
        //}
    };
    refreshGirdData = function () {
        $('#gridtable').jfGridSet('reload');
    };
    page.init();
}

function AppendSource(source, maxLength) {
    if (source.length < maxLength) {
        var itemAppend = { values: [] }
        for (var i = 0, j = maxLength - source.length; i < j; i++) {
            source.push(itemAppend)
        }
    }
    return source
}
function GetFitDataLength() {
    var height = $('#gantt').height()
    if (height < 41 + 96 + 1) {
        return 0
    }
    return Math.floor((height - 96 - 41 - 1) / 24)
}
