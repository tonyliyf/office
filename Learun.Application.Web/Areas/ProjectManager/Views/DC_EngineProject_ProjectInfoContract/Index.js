/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-03-15 15:20
 * 描  述：DC_EngineProject_ProjectInfoContract
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
            $('#multiple_condition_query').lrMultipleQuery(function (queryJson) {
                page.search(queryJson);
            }, 220, 400);
            $('#F_ContractType').lrDataItemSelect({ code: 'EngineeringContractType' });
            // 刷新
            $('#lr_refresh').on('click', function () {
                location.reload();
            });
            // 新增
            $('#lr_add').on('click', function () {
                learun.layerForm({
                    id: 'form',
                    title: '新增',
                    url: top.$.rootUrl + '/ProjectManager/DC_EngineProject_ProjectInfoContract/Form?F_PIId=' + F_PIId,
                    width: 600,
                    height: 500,
                    callBack: function (id) {
                        return top[id].acceptClick(refreshGirdData);
                    }
                });
            });
            // 编辑
            $('#lr_edit').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_PICId');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'form',
                        title: '编辑',
                        url: top.$.rootUrl + '/ProjectManager/DC_EngineProject_ProjectInfoContract/Form?F_PIId=' + F_PIId + '&keyValue=' + keyValue,
                        width: 600,
                        height: 500,
                        callBack: function (id) {
                            return top[id].acceptClick(refreshGirdData);
                        }
                    });
                }
            });

            //查看附件
            $('#lr_file').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_PICId')
                if (learun.checkrow(keyValue)) {
                    var FIDS = $('#gridtable').jfGridValue('F_ContractAppendices')
                

                    top.learun.frameTab.open({
                        F_ModuleId: FIDS, F_Icon: '',
                        F_FullName: '附件信息查看', F_UrlAddress: '/LR_CodeDemo/FileViewer/Index?FIDS=' + FIDS 
                    });
                }
            })
            // 删除
            $('#lr_delete').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_PICId');
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否确认删除该项！', function (res) {
                        if (res) {
                            learun.deleteForm(top.$.rootUrl + '/ProjectManager/DC_EngineProject_ProjectInfoContract/DeleteForm', { keyValue: keyValue }, function () {
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
                    url: top.$.rootUrl + '/ProjectManager/DC_EngineProject_ProjectInfoContract/ExportExcel',
                    param: {
                        fileName: "信息表",
                        columnJson: JSON.stringify($('#gridtable').jfGridGet('settingInfo').headData),
                        queryJson: JSON.stringify(query)
                    }
                });
            });
            // 打印
            $('#lr_print').on('click', function () {
                $('#gridtable').jqprintTable();
            });
        },
        // 初始化列表
        initGird: function () {
            $('#gridtable').jfGrid({
                url: top.$.rootUrl + '/ProjectManager/DC_EngineProject_ProjectInfoContract/GetPageList',
                headData: [
                    {
                        label: "项目名称", name: "F_PIId", width: 250, align: "left",
                        formatterAsync: function (callback, value, row, op, $cell) {
                            learun.clientdata.getAsync('custmerData', {
                                url: '/LR_SystemModule/DataSource/GetDataTable?code=' + 'ProjectInfo',
                                key: value,
                                keyId: 'f_piid',
                                callback: function (_data) {
                                    callback(_data['f_projectname']);
                                }
                            });
                        }
                    }, 
                    {
                        label: "合同分类", name: "F_ContractType", width: 100, align: "left",
                        formatterAsync: function (callback, value, row, op, $cell) {
                            learun.clientdata.getAsync('dataItem', {
                                key: value,
                                code: 'EngineeringContractType',
                                callback: function (_data) {
                                    callback(_data.text);
                                }
                            });
                        }
                    },
                    { label: "合同编号", name: "F_ContractCode", width: 100, align: "left" },
                    { label: "合同名称", name: "F_ContractName", width: 100, align: "left" },
                    { label: "合同金额(万元)", name: "F_ContractMoney", width: 100, align: "left" },
                    {
                        label: "结算方式", name: "F_SettlementMethod", width: 100, align: "left",
                        formatterAsync: function (callback, value, row, op, $cell) {
                            learun.clientdata.getAsync('dataItem', {
                                key: value,
                                code: 'SettlementMethod',
                                callback: function (_data) {
                                    callback(_data.text);
                                }
                            });
                        }
                    },
                    {
                        label: "付款方式", name: "F_PayMethod", width: 100, align: "left",
                        formatterAsync: function (callback, value, row, op, $cell) {
                            learun.clientdata.getAsync('dataItem', {
                                key: value,
                                code: 'PayMethod',
                                callback: function (_data) {
                                    callback(_data.text);
                                }
                            });
                        }
                    },
                    { label: "甲方单位", name: "F_PartyAUnit", width: 100, align: "left" },
                    { label: "甲方负责人", name: "F_PartyABlameMan", width: 100, align: "left" },
                    { label: "乙方单位", name: "F_PartyBUnit", width: 100, align: "left" },
                    { label: "乙方负责人", name: "F_PartyBBlameMan", width: 100, align: "left" },
                    {
                        label: "签订时间", name: "F_SigningTime", width: 100, align: "center", formatter: function (value) {
                            if (value && value.length > 10) {
                                return value.substr(0, 10)
                            } else {
                                return value
                            }
                        }
                    },
                    { label: "备注", name: "F_Remarks", width: 100, align: "left" },
                ],
                mainId: 'F_PICId',
                isPage: true,
                dblclick: function (rowdata) {

                    var keyValue = $('#gridtable').jfGridValue('F_PICId');
                    if (learun.checkrow(keyValue)) {
                        learun.layerForm({
                            id: 'form',
                            title: '查看',
                            url: top.$.rootUrl + '/ProjectManager/DC_EngineProject_ProjectInfoContract/Form1?F_PIId=' + F_PIId + '&keyValue=' + keyValue,
                            width: 600,
                            height: 500,
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
