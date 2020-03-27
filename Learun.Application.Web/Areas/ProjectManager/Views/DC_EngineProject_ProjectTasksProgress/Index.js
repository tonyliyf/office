/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-03-20 12:20
 * 描  述：DC_EngineProject_ProjectTasksProgress
 */
var refreshGirdData;
var TID;
var query;
var bootstrap = function ($, learun) {
    "use strict";
    var page = {
        init: function () {
            page.initGird();
            page.bind();
        },
        bind: function () {
            $('#dataTree').lrtree({
                url: top.$.rootUrl + '/ProjectManager/DC_EngineProject_ProjectTasksProgress/GetTree',
                nodeClick: function (item) {
           
                    $('#gridtable1').jfGridSet('reload', { queryJson: JSON.stringify({ TID: item.id }) });
                }
            });
            // 刷新
            $('#lr_refresh').on('click', function () {
                location.reload();
            });
            //// 新增
            //$('#lr_add').on('click', function () {
              
            //    if (TID && TID.length > 0) {
            //        learun.layerForm({
            //            id: 'form',
            //            title: '新增',
            //            url: top.$.rootUrl + '/ProjectManager/DC_EngineProject_ProjectTasksProgress/Form?TID=' + TID,
            //            width: 600,
            //            height: 400,
            //            callBack: function (id) {
            //                return top[id].acceptClick(refreshGirdData);
            //            }
            //        });
            //    } else {
            //        learun.alert.warning('未选中任务')
            //    }
            //});
            // 新增
            $('#lr_add').on('click', function () {
                learun.layerForm({
                    id: 'form',
                    title: '新增',
                    url: top.$.rootUrl + '/ProjectManager/DC_EngineProject_ProjectTasksProgress/Form?TID=' + TID,
                    width: 600,
                    height: 450,
                    callBack: function (id) {
                        return top[id].acceptClick(refreshGirdData);
                    }
                });
            });
            // 编辑
            $('#lr_edit').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_PTPId');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'form',
                        title: '编辑',
                        url: top.$.rootUrl + '/ProjectManager/DC_EngineProject_ProjectTasksProgress/Form?keyValue=' + keyValue + '&TID=' + TID,
                        width: 600,
                        height: 450,
                        callBack: function (id) {
                            return top[id].acceptClick(refreshGirdData);
                        }
                    });
                }
            });
            // 删除
            $('#lr_delete').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_PTPId');
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否确认删除该项！', function (res) {
                        if (res) {
                            learun.deleteForm(top.$.rootUrl + '/ProjectManager/DC_EngineProject_ProjectTasksProgress/DeleteForm', { keyValue: keyValue }, function () {
                                refreshGirdData();
                            });
                        }
                    });
                }
            });
            //导出
            $('#lr-export1').on('click', function () {
                learun.download({
                    method: "POST",
                    url: top.$.rootUrl + '/ProjectManager/DC_EngineProject_ProjectTasksProgress/ExportExcel',
                    param: {
                        fileName: "信息表",
                        columnJson: JSON.stringify($('#gridtable').jfGridGet('settingInfo').headData),
                        queryJson: JSON.stringify(query)
                    }
                });
            });
        },
        // 初始化列表
        initGird: function () {
            $('#gridtable').lrAuthorizeJfGrid({
                url: top.$.rootUrl + '/ProjectManager/DC_EngineProject_ProjectTasksProgress/GetPageList',
                headData: [
                    { label: "任务名称", name: "F_TaskName", width: 140, align: "center" },
                    { label: "任务编号", name: "F_TaskItemNumber", width: 120, align: "center" },
                    //{
                    //    label: "计量单位", name: "F_MeasurementUnit", width: 100, align: "center",
                    //    formatterAsync: function (callback, value, row, op, $cell) {
                    //        learun.clientdata.getAsync('dataItem', {
                    //            key: value,
                    //            code: 'ProjectMeasurementUnit',
                    //            callback: function (_data) {
                    //                callback(_data.text);
                    //            }
                    //        });
                    //    }
                    //},
                    //{ label: "工程量", name: "F_ProjectQuantities", width: 100, align: "center" },
                    //{ label: "综合单价", name: "F_UnitPrice", width: 100, align: "center" },
                    //{ label: "合计", name: "F_CostTotal", width: 100, align: "center" },
                    //{
                    //    label: "计划开工日期", name: "F_PlannedStartDate", width: 100, align: "center", formatter: function (value) {
                    //        if (value && value.length > 10) {
                    //            return value.substr(0, 10)
                    //        } else {
                    //            return value
                    //        }
                    //    }
                    //},
                    {
                        label: "计划完成日期", name: "F_ActualStartDate", width: 120, align: "center", formatter: function (value) {
                            if (value && value.length > 10) {
                                return value.substr(0, 10)
                            } else {
                                return value
                            }
                        }
                    },
                    //{
                    //    label: "实际开工日期", name: "F_PlannedEndDate", width: 100, align: "center", formatter: function (value) {
                    //        if (value && value.length > 10) {
                    //            return value.substr(0, 10)
                    //        } else {
                    //            return value
                    //        }
                    //    }
                    //},
                    {
                        label: "实际完成日期", name: "F_ActualEndDate", width: 120, align: "center", formatter: function (value) {
                            if (value && value.length > 10) {
                                return value.substr(0, 10)
                            } else {
                                return value
                            }
                        }
                    },
                    { label: "备注", name: "F_Remarks", width: 300, align: "center" },
                ],
                mainId: 'F_PTPId',
                isPage: true
            });

            $('#gridtable1').jfGrid({
                url: top.$.rootUrl + '/ProjectManager/DC_EngineProject_ProjectTasks/GetPageList',
                headData: [
                    { label: "任务名称", name: "F_TaskName", width: 100, align: "center" },
                    { label: "任务编号", name: "F_TaskItemNumber", width: 150, align: "center" },
                    {
                        label: "计量单位", name: "F_MeasurementUnit", width: 100, align: "center",
                        formatterAsync: function (callback, value, row, op, $cell) {
                            learun.clientdata.getAsync('dataItem', {
                                key: value,
                                code: 'ProjectMeasurementUnit',
                                callback: function (_data) {
                                    callback(_data.text);
                                }
                            });
                        }
                    },
                    { label: "工程量", name: "F_ProjectQuantities", width: 100, align: "center" },
                    { label: "综合单价", name: "F_UnitPrice", width: 100, align: "center" },
                    { label: "合计", name: "F_CostTotal", width: 100, align: "center" },
                    {
                        label: "任务状态", name: "F_TaskState", width: 100, align: "center",
                        formatterAsync: function (callback, value, row, op, $cell) {
                            learun.clientdata.getAsync('dataItem', {
                                key: value,
                                code: 'EProTaskState',
                                callback: function (_data) {
                                    callback(_data.text);
                                }
                            });
                        }
                    },
                    {
                        label: "是否里程碑", name: "F_IfMilestone", width: 100, align: "center",
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
                    {
                        label: "任务负责部门", name: "F_TaskDepartment", width: 100, align: "center",
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
                        label: "任务负责人", name: "F_TaskLeader", width: 100, align: "center",
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
                        label: "计划开始时间", name: "F_PlannedStartDate", width: 100, align: "center", formatter: function (value) {
                            if (value && value.length > 10) {
                                return value.substr(0, 10)
                            } else {
                                return value
                            }
                        }
                    },
                    {
                        label: "计划结束时间", name: "F_PlannedEndDate", width: 100, align: "center", formatter: function (value) {
                            if (value && value.length > 10) {
                                return value.substr(0, 10)
                            } else {
                                return value
                            }
                        }
                    },
                    { label: "备注", name: "F_Remarks", width: 100, align: "center" },
                ],
                mainId: 'F_PTId',
                isPage: true,
                dblclick: function (row) {
                    TID = row.F_PTId
                    $('#gridtable').jfGridSet('reload', { queryJson: JSON.stringify({ TID: row.F_PTId }) });
                }
            });
            page.search();
        },
        search: function (param) {
            param = param || {};
            query = param;
            $('#gridtable1').jfGridSet('reload', { queryJson: JSON.stringify(param) });
        }
    };
    refreshGirdData = function () {
        $('#gridtable').jfGridSet('reload');
    };
    page.init();
}
