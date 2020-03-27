/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-03-25 15:19
 * 描  述：DC_EngineProject_ProjectInfoApprovalData
 */
var refreshGirdData;
var F_PIId = request('keyValue');
var query;
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
                url: top.$.rootUrl + '/ProjectManager/DC_EngineProject_ProjectInfoApprovalData/GetBeforeTree',
                nodeClick: function (item) {
                    page.search({ F_ProjectStage: item.id });
                }
            });
        
            //$('#dataTree').lrselect({
            //    type: 'tree',
            //    allowSearch: true,
            //    url: top.$.rootUrl + '/ProjectManager/DC_EngineProject_ProjectInfoApprovalData/GetTree',
            //    param: {}
            //});
            $('#multiple_condition_query').lrMultipleQuery(function (queryJson) {
                page.search(queryJson);
            }, 220, 400);
            $('#F_PIId').lrDataSourceSelect({ code: 'ProjectInfo',value: 'f_piid',text: 'f_projectname' });
             // 刷新
            $('#lr_refresh').on('click', function () {
                location.reload();
            });
            // 新增
            $('#lr_add').on('click', function () {
                learun.layerForm({
                    id: 'form',
                    title: '新增',
                    url: top.$.rootUrl + '/ProjectManager/DC_EngineProject_ProjectInfoApprovalData/Formz?F_PIId=' + F_PIId,
                    width: 600,
                    height: 400,
                    callBack: function (id) {
                        alert(id);
                        return top[id].acceptClick(refreshGirdData);
                    }
                });
            });
            // 编辑
            $('#lr_edit').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_PICADId');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'form',
                        title: '编辑',
                        url: top.$.rootUrl + '/ProjectManager/DC_EngineProject_ProjectInfoApprovalData/Formz?F_PIId=' + F_PIId + '&keyValue=' + keyValue,
                        width: 600,
                        height: 400,
                        callBack: function (id) {
                            return top[id].acceptClick(refreshGirdData);
                        }
                    });
                }
            });
            // 删除
            $('#lr_delete').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_PICADId');
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否确认删除该项！', function (res) {
                        if (res) {
                            learun.deleteForm(top.$.rootUrl + '/ProjectManager/DC_EngineProject_ProjectInfoApprovalData/DeleteForm', { keyValue: keyValue}, function () {
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
                    url: top.$.rootUrl + '/ProjectManager/DC_EngineProject_ProjectInfoApprovalData/ExportExcel',
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
            $('#gridtable').jfGrid({
                url: top.$.rootUrl + '/ProjectManager/DC_EngineProject_ProjectInfoApprovalData/GetPageList',
                headData: [
                    { label: "项目名称", name: "F_PIId", width: 180, align: "left",
                        formatterAsync: function (callback, value, row, op,$cell) {
                             learun.clientdata.getAsync('custmerData', {
                                 url: '/LR_SystemModule/DataSource/GetDataTable?code=' + 'ProjectInfo',
                                 key: value,
                                 keyId: 'f_piid',
                                 callback: function (_data) {
                                     callback(_data['f_projectname']);
                                 }
                             });
                        }},
                    {
                        label: "项目阶段", name: "F_ProjectStage", width: 200, align: "left",
                        formatterAsync: function (callback, value, row, op, $cell) {
                            learun.clientdata.getAsync('custmerData', {
                                url: '/LR_SystemModule/DataSource/GetDataTable?code=' + 'GetDetailItemCascade',
                                key: value,
                                keyId: 'f_itemdetailid',
                                callback: function (_data) {
                                    callback(_data['f_itemname']);
                                }
                            });
                        }
                    },
                    { label: "资料编号", name: "F_DataCode", width: 150, align: "left"},
                    { label: "资料名称", name: "F_DataName", width: 150, align: "left"},
                    { label: "负责部门", name: "F_TaskDepartment", width: 100, align: "left",
                        formatterAsync: function (callback, value, row, op,$cell) {
                             learun.clientdata.getAsync('user', {
                                 key: value,
                                 callback: function (_data) {
                                     callback(_data.name);
                                 }
                             });
                        }
                    },
                    {
                        label: "任务负责人", name: "F_TaskLeader", width: 100, align: "left",
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
                    {
                        label: "实际完成时间", name: "F_ActualEndDate", width: 100, align: "center", formatter: function (value) {
                            if (value && value.length > 10) {
                                return value.substr(0, 10)
                            } else {
                                return value
                            }
                        }
                    },
                    { label: "备注", name: "F_Remarks", width: 100, align: "left"},
                ],
                mainId:'F_PICADId',
                isPage: true
            });
            page.search();
        },
        search: function (param) {
            param = param || {};
            param.F_PIId = F_PIId;
            query = param;
            $('#gridtable').jfGridSet('reload', { queryJson: JSON.stringify(param) });

        }
    };
    refreshGirdData = function () {
        $('#gridtable').jfGridSet('reload');
    };
    page.init();
}
