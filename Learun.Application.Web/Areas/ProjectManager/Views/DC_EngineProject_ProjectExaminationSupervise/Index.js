/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-03-20 18:24
 * 描  述：DC_EngineProject_ProjectExaminationSupervise
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
            // 初始化左侧树形数据
            $('#dataTree').lrtree({
                url: top.$.rootUrl + '/ProjectManager/DC_EngineProject_ProjectExaminationSupervise/GetTree',
                nodeClick: function (item) {
                    page.search({ F_PIId: item.value });
                }
            });
            // 刷新
            $('#lr_refresh').on('click', function () {
                location.reload();
            });
            // 新增
            $('#lr_add').on('click', function () {
                learun.layerForm({
                    id: 'form',
                    title: '新增',
                    url: top.$.rootUrl + '/ProjectManager/DC_EngineProject_ProjectExaminationSupervise/Form',
                    width: 600,
                    height: 700,
                    callBack: function (id) {
                        return top[id].acceptClick(refreshGirdData);
                    }
                });
            });
            // 编辑
            $('#lr_edit').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_PESId');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'form',
                        title: '编辑',
                        url: top.$.rootUrl + '/ProjectManager/DC_EngineProject_ProjectExaminationSupervise/Form?keyValue=' + keyValue,
                        width: 600,
                        height: 700,
                        callBack: function (id) {
                            return top[id].acceptClick(refreshGirdData);
                        }
                    });
                }
            });
            // 删除
            $('#lr_delete').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_PESId');
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否确认删除该项！', function (res) {
                        if (res) {
                            learun.deleteForm(top.$.rootUrl + '/ProjectManager/DC_EngineProject_ProjectExaminationSupervise/DeleteForm', { keyValue: keyValue }, function () {
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
                    url: top.$.rootUrl + '/ProjectManager/DC_EngineProject_ProjectExaminationSupervise/ExportExcel',
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
                url: top.$.rootUrl + '/ProjectManager/DC_EngineProject_ProjectExaminationSupervise/GetPageList',
                headData: [
                    {
                        label: "项目名称", name: "F_PIId", width: 100, align: "center",
                        formatterAsync: function (callback, value, row, op, $cell) {
                            learun.clientdata.getAsync('custmerData', {
                                url: '/LR_SystemModule/DataSource/GetDataTable?code=' + 'DC_EngineProject_ProjectInfo',
                                key: value,
                                keyId: 'f_piid',
                                callback: function (_data) {
                                    callback(_data['f_projectname']);
                                }
                            });
                        }
                    },
                    {
                        label: "检查督办类型", name: "F_InspectionSupervisionType", width: 100, align: "center",
                        formatterAsync: function (callback, value, row, op, $cell) {
                            learun.clientdata.getAsync('dataItem', {
                                key: value,
                                code: 'InspectionSupervision',
                                callback: function (_data) {
                                    callback(_data.text);
                                }
                            });
                        }
                    },
                    { label: "编 码", name: "F_PESCode", width: 100, align: "center" },
                    {
                        label: "检查时间", name: "F_EaminationDate", width: 100, align: "center", formatter: function (value) {
                            if (value && value.length > 0) {
                                return value.substr(0, 10)
                            } else {
                                return value
                            }
                        }
                    },
                    {
                        label: "检查部门", name: "F_ExaminationDepartment", width: 130, align: "center",
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
                        label: "检查人员", name: "F_ExaminationUser", width: 100, align: "center",
                        formatterAsync: function (callback, value, row, op, $cell) {
                            learun.clientdata.getAsync('user', {
                                key: value,
                                callback: function (_data) {
                                    callback(_data.name);
                                }
                            });
                        }
                    },
                    { label: "检查部位", name: "F_ExaminationPosition", width: 100, align: "center" },
                    { label: "检查结果", name: "F_ExaminationResult", width: 100, align: "center" },
                    { label: "督办意见", name: "F_SupervisionOpinion", width: 100, align: "center" },
                    {
                        label: "是否整改", name: "F_IfCorrective", width: 100, align: "center",
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
                        label: "整改时间", name: "F_DesignateDate", width: 100, align: "center", formatter: function (value) {
                            if (value && value.length > 0) {
                                return value.substr(0, 10)
                            } else {
                                return value
                            }
                        }
                    },
                    { label: "指派单位", name: "F_DesignateUnit", width: 100, align: "center" },
                    { label: "指派人员", name: "F_DesignateUser", width: 100, align: "center" },
                    { label: "整改结果反馈", name: "F_ResultFeedback", width: 100, align: "center" },
                    {
                        label: "检查督办状态", name: "F_SupervisionStatus", width: 100, align: "center",
                        formatterAsync: function (callback, value, row, op, $cell) {
                            learun.clientdata.getAsync('dataItem', {
                                key: value,
                                code: 'SupervisionStatus',
                                callback: function (_data) {
                                    callback(_data.text);
                                }
                            });
                        }
                    },
                    { label: "备注", name: "F_Remarks", width: 100, align: "center" },
                ],
                mainId: 'F_PESId',
                isPage: true
            });
            page.search();
        },
        search: function (param) {
            param = param || {};
            query = param;
            $('#gridtable').jfGridSet('reload', { queryJson: JSON.stringify(param) });
        }
    };
    refreshGirdData = function () {
        $('#gridtable').jfGridSet('reload');
    };
    page.init();
}
