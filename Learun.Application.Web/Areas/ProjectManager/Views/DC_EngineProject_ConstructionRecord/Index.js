/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-04-25 15:22
 * 描  述：DC_EngineProject_ConstructionRecord
 */
var refreshGirdData;
var query;
var bootstrap = function ($, learun) {
    "use strict";
    var page = {
        init: function () {
            page.initGird();
            page.bind();
        },
        bind: function () {
            $('#multiple_condition_query').lrMultipleQuery(function (queryJson) {
                page.search(queryJson);
            }, 220, 400);
            $('#F_PIId').lrDataSourceSelect({ code: 'DC_EngineProject_ProjectInfo', value: 'f_piid',text: 'f_projectname' });
            // 刷新
            $('#lr_refresh').on('click', function () {
                location.reload();
            });
            // 新增
            $('#lr_add').on('click', function () {
                learun.layerForm({
                    id: 'form',
                    title: '新增',
                    url: top.$.rootUrl + '/ProjectManager/DC_EngineProject_ConstructionRecord/Form',
                    width: 600,
                    height: 650,
                    callBack: function (id) {
                        return top[id].acceptClick(refreshGirdData);
                    }
                });
            });
            // 编辑
            $('#lr_edit').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_EPCRId');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'form',
                        title: '编辑',
                        url: top.$.rootUrl + '/ProjectManager/DC_EngineProject_ConstructionRecord/Form?keyValue=' + keyValue,
                        width: 600,
                        height: 650,
                        callBack: function (id) {
                            return top[id].acceptClick(refreshGirdData);
                        }
                    });
                }
            });
            //导出
            $('#lr-export1').on('click', function () {
                learun.download({
                    method: "POST",
                    url: top.$.rootUrl + '/ProjectManager/DC_EngineProject_ConstructionRecord/ExportExcel',
                    param: {
                        fileName: "设备信息表",
                        columnJson: JSON.stringify($('#gridtable').jfGridGet('settingInfo').headData),
                        queryJson: JSON.stringify(query)
                    }
                });
            });
            // 删除
            $('#lr_delete').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_EPCRId');
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否确认删除该项！', function (res) {
                        if (res) {
                            learun.deleteForm(top.$.rootUrl + '/ProjectManager/DC_EngineProject_ConstructionRecord/DeleteForm', { keyValue: keyValue}, function () {
                                refreshGirdData();
                            });
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
                url: top.$.rootUrl + '/ProjectManager/DC_EngineProject_ConstructionRecord/GetPageList',
                headData: [
                    { label: "项目名称", name: "F_PIId", width: 100, align: "left",
                        formatterAsync: function (callback, value, row, op,$cell) {
                             learun.clientdata.getAsync('custmerData', {
                                 url: '/LR_SystemModule/DataSource/GetDataTable?code=' + 'DC_EngineProject_ProjectInfo',
                                 key: value,
                                 keyId: 'f_piid',
                                 callback: function (_data) {
                                     callback(_data['f_projectname']);
                                 }
                             });
                        }},
                    { label: "安全施工评价", name: "F_SafetyCivilizationEvaluation", width: 100, align: "left",
                        formatterAsync: function (callback, value, row, op,$cell) {
                             learun.clientdata.getAsync('dataItem', {
                                 key: value,
                                 code: 'F_SafetyCivilizationEvaluation',
                                 callback: function (_data) {
                                     callback(_data.text);
                                 }
                             });
                        }},
                    { label: "施工质量评价", name: "F_QualityEvaluation", width: 100, align: "left",
                        formatterAsync: function (callback, value, row, op,$cell) {
                             learun.clientdata.getAsync('dataItem', {
                                 key: value,
                                 code: 'F_QualityEvaluation',
                                 callback: function (_data) {
                                     callback(_data.text);
                                 }
                             });
                        }},
                    { label: "施工检查情况", name: "F_SafetyCivilizationInfo", width: 100, align: "left"},
                    { label: "质量检查验收情况", name: "F_QualityInfo", width: 100, align: "left"},
                    { label: "劳动力安排人数", name: "F_LaborNumber", width: 100, align: "left"},
                    { label: "劳动力安排情况", name: "F_LaborInfo", width: 100, align: "left"},
                    { label: "监理方到岗情况", name: "F_SupervisorsComeInfo", width: 100, align: "left"},
                    { label: "施工方到岗情况", name: "F_ConstructorComeInfo", width: 100, align: "left"},
                    { label: "项目业主方到岗情况", name: "F_ProjectOwnerComeInfo", width: 100, align: "left"},
                ],
                mainId:'F_EPCRId',
                isPage: true
            });
            page.search();
        },
        search: function (param) {
            param = param || {};
            query = param;
            $('#gridtable').jfGridSet('reload',{ queryJson: JSON.stringify(param) });
        }
    };
    refreshGirdData = function () {
        $('#gridtable').jfGridSet('reload');
    };
    page.init();
}
