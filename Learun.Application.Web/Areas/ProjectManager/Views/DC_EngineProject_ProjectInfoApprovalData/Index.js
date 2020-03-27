﻿/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
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
                url: top.$.rootUrl + '/ProjectManager/DC_EngineProject_ProjectInfoApprovalData/GetTree',
                nodeClick: function (item) {
                    page.search({ F_ProjectStage: item.id });
                }
            });


            //查看附件
            $('#lr_file').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_PICADId')
                if (learun.checkrow(keyValue)) {
                    var FIDS = $('#gridtable').jfGridValue('F_Attachment')
                    var FIDS1 = $('#gridtable').jfGridValue('F_DataPhoto')
                    
                    top.learun.frameTab.open({
                        F_ModuleId: FIDS, F_Icon: '',
                        F_FullName: '附件信息查看', F_UrlAddress: '/LR_CodeDemo/FileViewer/Index?FIDS=' + FIDS + ',' + FIDS1 
                    });
                }
            })
        
         
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
                    url: top.$.rootUrl + '/ProjectManager/DC_EngineProject_ProjectInfoApprovalData/Form?F_PIId=' + F_PIId,
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
                        url: top.$.rootUrl + '/ProjectManager/DC_EngineProject_ProjectInfoApprovalData/Form?F_PIId=' + F_PIId + '&keyValue=' + keyValue,
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
                    { label: "项目名称", name: "F_PIId", width: 250, align: "left",
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
                    { label: "项目阶段", name: "F_ProjectStage", width: 200, align: "left",
                        formatterAsync: function (callback, value, row, op,$cell) {
                            learun.clientdata.getAsync('custmerData', {
                                url: '/LR_SystemModule/DataSource/GetDataTable?code=' + 'GetDetailItemCascade',
                                key: value,
                                keyId: 'f_itemdetailid',
                                callback: function (_data) {
                                    callback(_data['f_itemname']);
                                 }
                             });
                        }},
                    { label: "资料编号", name: "F_DataCode", width: 150, align: "left"},
                    { label: "资料名称", name: "F_DataName", width: 150, align: "left"},
                    { label: "记录人", name: "F_CreateUserid", width: 100, align: "left",
                        formatterAsync: function (callback, value, row, op,$cell) {
                             learun.clientdata.getAsync('user', {
                                 key: value,
                                 callback: function (_data) {
                                     callback(_data.name);
                                 }
                             });
                        }},
                    { label: "记录部门", name: "F_CreateDepartmentId", width: 100, align: "left",
                        formatterAsync: function (callback, value, row, op,$cell) {
                            learun.clientdata.getAsync('department', {
                                 key: value,
                                 callback: function (_data) {
                                     callback(_data.name);
                                 }
                             });
                        }},
                    { label: "备注", name: "F_Remarks", width: 100, align: "left"},
                ],
                mainId:'F_PICADId',
                isPage: true,
                dblclick: function (rowdata) {
                    var keyValue = $('#gridtable').jfGridValue('F_PICADId');
                    if (learun.checkrow(keyValue)) {
                        learun.layerForm({
                            id: 'form',
                            title: '查看',
                            url: top.$.rootUrl + '/ProjectManager/DC_EngineProject_ProjectInfoApprovalData/Form1?F_PIId=' + F_PIId + '&keyValue=' + keyValue,
                            width: 600,
                            height: 400,
                            callBack: function (id) {
                                return top[id].acceptClick(refreshGirdData);
                            }
                        });
                    }
                }
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