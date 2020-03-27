/* * 版 本 Learun-ADMS V7.0.3 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-01-24 17:30
 * 描  述：DC_OA_PerformanceRecordRun
 */
var refreshGirdData;
var bootstrap = function ($, learun) {
    "use strict";
    var page = {
        init: function () {
            page.initGird();
            page.bind();
        },
        bind: function () {
            // 刷新
            $('#lr_refresh').on('click', function () {
                location.reload();
            });
            // 新增
            $('#lr_add').on('click', function () {
                learun.layerForm({
                    id: 'form',
                    title: '新增',
                    url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_PerformanceRecordRun/Form',
                    width: 600,
                    height: 400,
                    callBack: function (id) {
                        return top[id].acceptClick(refreshGirdData);
                    }
                });
            });
            // 编辑
            $('#lr_edit').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_PRRId');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'form',
                        title: '编辑',
                        url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_PerformanceRecordRun/Form?keyValue=' + keyValue,
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
                var keyValue = $('#gridtable').jfGridValue('F_PRRId');
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否确认删除该项！', function (res) {
                        if (res) {
                            learun.deleteForm(top.$.rootUrl + '/LR_CodeDemo/DC_OA_PerformanceRecordRun/DeleteForm', { keyValue: keyValue }, function () {
                                refreshGirdData();
                            });
                        }
                    });
                }
            });
            //  添加被考核人
            $('#btn_adduser').on('click', function () {
                var tid = $('#gridtable').jfGridValue('F_PATId');
                var rid = $('#gridtable').jfGridValue('F_PRRId');
                if (learun.checkrow(rid)) {
                    learun.layerForm({
                        id: 'form',
                        title: '添加被考核人员',
                        url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_PerformanceRecordRun/SelectForm?tid=' + tid + '&rid=' + rid,
                        width: 800,
                        height: 520,
                        callBack: function (id) {
                            return top[id].acceptClick();
                        }
                    });
                }
            });
            //  添加考核人
            $('#btn_adduser1').on('click', function () {
                var rid = $('#gridtable').jfGridValue('F_PRRId');
                if (learun.checkrow(rid)) {
                    learun.layerForm({
                        id: '11__form',
                        title: '添加考核人',
                        url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_PRREvaluationUserRelation/index?rid=' + rid,
                        width: 800,
                        height: 800,
                        callBack: function (id) {
                            return top[id].acceptClick();
                        }
                    });
                }
            });
        },
        // 初始化列表
        initGird: function () {
            $('#gridtable').jfGrid({
                url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_PerformanceRecordRun/GetPageList',
                headData: [
                    {
                        label: "考核模板", name: "F_PATId", width: 100, align: "center",
                        formatterAsync: function (callback, value, row, op, $cell) {
                            learun.clientdata.getAsync('custmerData', {
                                url: '/LR_SystemModule/DataSource/GetDataTable?code=' + 'PerformanceAppraisalTemplate',
                                key: value,
                                keyId: 'f_patid',
                                callback: function (_data) {
                                    callback(_data['f_templatename']);
                                }
                            });
                        }
                    },
                    {
                        label: "考核周期", name: "F_AppraisalCycleType", width: 140, align: "center",
                        formatterAsync: function (callback, value, row, op, $cell) {
                            learun.clientdata.getAsync('dataItem', {
                                key: value,
                                code: 'Appraisal',
                                callback: function (_data) {
                                    callback(_data.text);
                                }
                            });
                        }
                    },
                    { label: "考核名称", name: "F_PerformanceName", width: 600, align: "center" },
                    {
                        label: "起始时间", name: "F_PRRStartDatetime", width: 150, align: "center", formatter: function (v, r) {
                            if (v && v.length > 0) {
                                return v.substr(0, 10)
                            } else {
                                return v
                            }
                        }
                    },
                    {
                        label: "终止时间", name: "F_PRREndDatetime", width: 150, align: "center", formatter: function (v, r) {
                            if (v && v.length > 0) {
                                return v.substr(0, 10)
                            } else {
                                return v
                            }
                        }
                    },
                    //{ label: "自评权重", name: "F_SelfWeight", width: 100, align: "center" },
                    {
                        label: "是否定期提醒", name: "F_IfRemind", width: 100, align: "center",
                        formatterAsync: function (callback, value, row, op, $cell) {
                            learun.clientdata.getAsync('dataItem', {
                                key: value,
                                code: 'YesOrNo',
                                callback: function (_data) {
                                    callback(_data.text);
                                }
                            });
                        }
                    }
                ],
                mainId: 'F_PRRId',
                isPage: true
            });
            page.search();
        },
        search: function (param) {
            param = param || {};
            $('#gridtable').jfGridSet('reload', { queryJson: JSON.stringify(param) });
        }
    };
    refreshGirdData = function () {
        $('#gridtable').jfGridSet('reload');
    };
    page.init();
}
