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
    var startTime;
    var endTime;
    var page = {
        init: function () {
            page.initGird();
            page.bind();
        },
        bind: function () {
            $.get(top.$.rootUrl + '/LR_CodeDemo/DC_OA_OverSeeWork/GetCount1', function (res) {
                $('#filter_container').find('button').each(function (i, v) {
                    $(v).html($(v).attr('text') + '(' + res.data[i] + ')')
                })
            }, 'json')
            $('#filter_container').find('button').click(function () {
                $(this).addClass('active').siblings().removeClass('active')
                page.search({ State: $(this).attr('text') })
            })

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
            //$('#lr_taskSplit').on('click', function () {
            //    var keyValue = $('#gridtable').jfGridValue('F_OSWId');
            //    if (learun.checkrow(keyValue)) {
            //        currentTaskId = keyValue
            //        page.renderGantt()
            //    }
            //});
            $('#lr_taskSplit').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_OSWId');
                if (learun.checkrow(keyValue)) {
                    currentTaskId = keyValue
                    learun.layerForm({
                        id: 'form',
                        title: '任务项',
                        url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_OverSeeWorkTaskSplitDelete/ExecuteIndex?keyValue=' + keyValue,
                        width: 1500,
                        height: 600,
                        btn: null,
                        end: function (id) {
                            page.renderGantt()
                        }
                    })
                }
            });
            $('#lr_taskDo').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_OSWId');
                //  debugger;
                if (learun.checkrow(keyValue)) {
                    currentTaskId = keyValue


                    learun.httpAsync('Post', top.$.rootUrl + '/LR_CodeDemo/DC_OA_OverSeeWorkTaskSplit/Createflow?keyValue=' + keyValue, {}, function (data) {
                        var key = data.key;
                        learun.frameTab.closeByParam('tabProcessId', key);
                        learun.frameTab.open({ F_ModuleId: key, F_Icon: 'fa magic', F_FullName: '创建流程-', F_UrlAddress: '/LR_NewWorkFlow/NWFProcess/NWFContainerForm?processId=' + key + '&tabIframeId=' + key + '&type=draftCreate' });
                    });


                    //learun.postForm(top.$.rootUrl + '/LR_CodeDemo/DC_OA_OverSeeWorkTaskSplit/Createflow?keyValue=' + keyValue, function (data) {


                    //    var key = data.key;
                    //   // learun.frameTab.closeByParam('tabProcessId', key);
                    //    learun.frameTab.open({ F_ModuleId: key, F_Icon: 'fa magic', F_FullName: '创建流程-' , F_UrlAddress: '/LR_NewWorkFlow/NWFProcess/NWFContainerForm?processId=' +key + '&tabIframeId=' +key + '&type=draftCreate' });
                    //   // alert(data.key);
                    //})
                }
            });

            $('#lr_delay').click(function () {
                var keyValue = $('#gridtable').jfGridValue('F_OSWId');
                if (learun.checkrow(keyValue)) {
                    currentTaskId = keyValue


                    learun.httpAsync('Post', top.$.rootUrl + '/LR_CodeDemo/DC_OA_OverSeeWorkTaskSplit/Createflow1?keyValue=' + keyValue, {}, function (data) {
                        var key = data.key;
                        learun.frameTab.closeByParam('tabProcessId', key);
                        learun.frameTab.open({ F_ModuleId: key, F_Icon: 'fa magic', F_FullName: '创建流程-', F_UrlAddress: '/LR_NewWorkFlow/NWFProcess/NWFContainerForm?processId=' + key + '&tabIframeId=' + key + '&type=draftCreate' });
                    });


                    //learun.postForm(top.$.rootUrl + '/LR_CodeDemo/DC_OA_OverSeeWorkTaskSplit/Createflow?keyValue=' + keyValue, function (data) {


                    //    var key = data.key;
                    //   // learun.frameTab.closeByParam('tabProcessId', key);
                    //    learun.frameTab.open({ F_ModuleId: key, F_Icon: 'fa magic', F_FullName: '创建流程-' , F_UrlAddress: '/LR_NewWorkFlow/NWFProcess/NWFContainerForm?processId=' +key + '&tabIframeId=' +key + '&type=draftCreate' });
                    //   // alert(data.key);
                    //})
                }
            })
        },


        // 初始化列表
        initGird: function () {
            $('#gridtable').jfGrid({
                url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_OverSeeWorkTaskSplit/GetPageListEx',
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
                dblclick: function (rowdata) {
                    currentTaskId = rowdata.F_OSWId
                    page.renderGantt()
                },
                mainId: 'F_OSWId',
                isPage: true
            });
            page.search({ State: '执行中' });
        },
        search: function (param) {
            param = param || {};
            param.StartTime = startTime;
            param.EndTime = endTime;
            $('#gridtable').jfGridSet('reload', { queryJson: JSON.stringify(param) });
        },
        renderGantt: function () {
            $.get(top.$.rootUrl + '/LR_CodeDemo/DC_OA_OverSeeWorkTaskSplit/GetGanttData?keyValue=' + currentTaskId, function (data) {
                var source = data.data
                var maxLength = 200
                source = AppendSource(source, maxLength)
                $("#gantt").gantt({
                    source: source,
                    scale: "days",
                    minScale: "days",
                    maxScale: "days",
                    onItemClick: function (data) {
                        learun.layerForm({
                            id: 'form',
                            title: '节点详情',
                            url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_OverSeeWorkTaskSplit/Form2?keyValue=' + data.id,
                            width: 800,
                            height: 800,
                            btn: null
                        })
                    },
                    //onAddClick: function (dt, rowId) {
                    //    if (!rowId) {
                    //        learun.layerForm({
                    //            id: 'form',
                    //            title: '新增子任务',
                    //            url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_OverSeeWorkTaskSplit/Form?TID=' + currentTaskId,
                    //            width: 800,
                    //            height: 800,
                    //            callBack: function (id) {
                    //                return top[id].acceptClick(page.renderGantt);
                    //            }
                    //        })
                    //    } else {
                    //        learun.layerForm({
                    //            id: 'form',
                    //            title: '新增任务节点',
                    //            url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_OverSeeWorkTaskSplit/Form2?TID=' + currentTaskId + '&PID=' + rowId,
                    //            width: 800,
                    //            height: 800,
                    //            callBack: function (id) {
                    //                return top[id].acceptClick(page.renderGantt);
                    //            }
                    //        })
                    //    }
                    //},
                    itemsPerPage: maxLength
                })
            }, 'json')
        }
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
