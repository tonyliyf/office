/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-04-25 17:27
 * 描  述：DC_EngineProject_ConstructionRecordMonth
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
            $('#F_PIId').lrDataSourceSelect({ code: 'DC_EngineProject_ProjectInfo',value: 'f_projectitemnumber',text: 'f_projectname' });
            $('#F_Month').lrDataItemSelect({ code: 'years' });
            // 刷新
            $('#lr_refresh').on('click', function () {
                location.reload();
            });
            // 新增
            $('#lr_add').on('click', function () {
                learun.layerForm({
                    id: 'form',
                    title: '新增',
                    url: top.$.rootUrl + '/ProjectManager/DC_EngineProject_ConstructionRecordMonth/Form',
                    width: 600,
                    height: 630,
                    callBack: function (id) {
                        return top[id].acceptClick(refreshGirdData);
                    }
                });
            });
            //导出
            $('#lr-export1').on('click', function () {
                learun.download({
                    method: "POST",
                    url: top.$.rootUrl + '/ProjectManager/DC_EngineProject_ConstructionRecordMonth/ExportExcel',
                    param: {
                        fileName: "设备信息表",
                        columnJson: JSON.stringify($('#gridtable').jfGridGet('settingInfo').headData),
                        queryJson: JSON.stringify(query)
                    }
                });
            });
            // 编辑
            $('#lr_edit').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_EPCRMId');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'form',
                        title: '编辑',
                        url: top.$.rootUrl + '/ProjectManager/DC_EngineProject_ConstructionRecordMonth/Form?keyValue=' + keyValue,
                        width: 600,
                        height: 630,
                        callBack: function (id) {
                            return top[id].acceptClick(refreshGirdData);
                        }
                    });
                }
            });
            // 删除
            $('#lr_delete').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_EPCRMId');
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否确认删除该项！', function (res) {
                        if (res) {
                            learun.deleteForm(top.$.rootUrl + '/ProjectManager/DC_EngineProject_ConstructionRecordMonth/DeleteForm', { keyValue: keyValue}, function () {
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
                url: top.$.rootUrl + '/ProjectManager/DC_EngineProject_ConstructionRecordMonth/GetPageList',
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
                    { label: "月度", name: "F_Month", width: 100, align: "left",
                        formatterAsync: function (callback, value, row, op,$cell) {
                             learun.clientdata.getAsync('dataItem', {
                                 key: value,
                                 code: 'years',
                                 callback: function (_data) {
                                     callback(_data.text);
                                 }
                             });
                        }},
                    { label: "完成投资额", name: "F_InvestmentCompletion", width: 100, align: "left"},
                    { label: "完成投资比例", name: "F_InvestmentRatio", width: 100, align: "left"},
                    { label: "成本控制情况", name: "F_CostControlInfo", width: 100, align: "left"},
                    { label: "合同名称", name: "F_ContractName", width: 100, align: "left"},
                    { label: "合同履约评价", name: "F_ContractPerformanceEvaluation", width: 100, align: "left",
                        formatterAsync: function (callback, value, row, op,$cell) {
                             learun.clientdata.getAsync('dataItem', {
                                 key: value,
                                 code: 'ContractPerformanceEvaluation',
                                 callback: function (_data) {
                                     callback(_data.text);
                                 }
                             });
                        }},
                    { label: "合同履约情况", name: "F_ContractPerformanceInfo", width: 100, align: "left"},
                ],
                mainId:'F_EPCRMId',
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
