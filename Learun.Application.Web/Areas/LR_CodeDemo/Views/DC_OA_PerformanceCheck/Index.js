/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-03-29 15:44
 * 描  述：DC_OA_PerformanceCheck
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
            //新增年度
            $('#lr_add_year').click(function () {
                learun.layerForm({
                    id: 'form',
                    title: '新增',
                    url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_PerformanceCheck/Form?type=1&role=1',
                    width: 800,
                    height: 1200,
                    callBack: function (id) {
                        return top[id].acceptClick(refreshGirdData);
                    }
                });
            })
            $('#lr_add_month').click(function () {
                learun.layerForm({
                    id: 'form',
                    title: '新增',
                    url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_PerformanceCheck/Form?type=2&role=1',
                    width: 800,
                    height: 1200,
                    callBack: function (id) {
                        return top[id].acceptClick(refreshGirdData);
                    }
                });
            })
            $('#lr_info').click(function () {
                var keyValue = $('#gridtable').jfGridValue('F_EmpolyeeCheckId');
                var F_TimeType = $('#gridtable').jfGridValue('F_TimeType');
                var t = (F_TimeType == "年度" ? 1 : 2)
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'form',
                        title: '查看',
                        url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_PerformanceCheck/Form?role=1&keyValue=' + keyValue + '&type=' + t,
                        width: 800,
                        height: 1200,
                        btn: null
                    });
                }
            })
            $('#lr_edit').click(function () {
                var keyValue = $('#gridtable').jfGridValue('F_EmpolyeeCheckId');
                var F_TimeType = $('#gridtable').jfGridValue('F_TimeType');
                var t = (F_TimeType == "年度" ? 1 : 2)
                var state = $('#gridtable').jfGridValue('F_CheckSate');
                if (state != 0) {
                    learun.alert.warning('已经发起状态不允许操作!')
                    return false
                }
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'form',
                        title: '编辑',
                        url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_PerformanceCheck/Form?role=1&keyValue=' + keyValue + '&type=' + t,
                        width: 800,
                        height: 1200,
                        callBack: function (id) {
                            return top[id].acceptClick(refreshGirdData);
                        }
                    });
                }
            })

            $('#lr_delete').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_EmpolyeeCheckId');
                var state = $('#gridtable').jfGridValue('F_CheckSate');
                if (state != 0) {
                    learun.alert.warning('已经发起状态不允许操作!')
                    return false
                }
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否确认删除该项！', function (res) {
                        if (res) {
                            learun.deleteForm(top.$.rootUrl + '/LR_CodeDemo/DC_OA_PerformanceCheck/DeleteForm', { keyValue: keyValue }, function () {
                                refreshGirdData();
                            });
                        }
                    });
                }
            });

            $('#lr_send').click(function () {
                var keyValue = $('#gridtable').jfGridValue('F_EmpolyeeCheckId');
                var state = $('#gridtable').jfGridValue('F_CheckSate');
                if (state != 0) {
                    learun.alert.warning('已经发起状态不允许操作!')
                    return false
                }
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'form',
                        title: '选择考核人',
                        url: top.$.rootUrl + '/LR_OrganizationModule/User/SelectOnlyForm',
                        width: 400,
                        height: 400,
                        callBack: function (id) {
                            return top[id].acceptClick(function (postitem) {
                                learun.layerConfirm('是否确认发起考核！', function (res) {
                                    if (res) {
                                        learun.deleteForm(top.$.rootUrl + '/LR_CodeDemo/DC_OA_PerformanceCheck/Commit', { keyValue: keyValue, checkerId: postitem.value }, function () {
                                            refreshGirdData();
                                        });
                                    }
                                });
                            });
                        }
                    });
                }
            })
        },
        // 初始化列表
        initGird: function () {
            $('#gridtable').jfGrid({
                url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_PerformanceCheck/GetPageList',
                headData: [
                    {
                        label: "被考核人", name: "F_CheckUserid", width: 100, align: "center",
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
                        label: "被考核人部门", name: "F_CheckUserDeptId", width: 200, align: "center",
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
                        label: "被考核人公司", name: "F_CheckUserCompayId", width: 200, align: "center",
                        formatterAsync: function (callback, value, row, op, $cell) {
                            learun.clientdata.getAsync('company', {
                                key: value,
                                callback: function (_data) {
                                    callback(_data.name);
                                }
                            });
                        }
                    },
                    {
                        label: "考核模板", name: "F_CheckTemplateRefid", width: 150, align: "center",
                        formatterAsync: function (callback, value, row, op, $cell) {
                            learun.clientdata.getAsync('custmerData', {
                                url: '/LR_SystemModule/DataSource/GetDataTable?code=' + 'performancechecktemplate',
                                key: value,
                                keyId: 'id',
                                callback: function (_data) {
                                    callback(_data['name']);
                                }
                            });
                        }
                    },
                    { label: "得分", name: "F_CheckNumber", width: 50, align: "center" },
                    {
                        label: "考核开始时间", name: "F_CheckStartTime", width: 100, align: "center", formatter: function (value) {
                            if (value && value.length > 10) {
                                return value.substr(0, 10)
                            } else {
                                return value
                            }
                        }
                    },
                    {
                        label: "考核结束时间", name: "F_CheckEndTime", width: 100, align: "center", formatter: function (value) {
                            if (value && value.length > 10) {
                                return value.substr(0, 10)
                            } else {
                                return value
                            }
                        }
                    },
                    {
                        label: "考核人", name: "F_AuditUserid", width: 100, align: "center",
                        formatterAsync: function (callback, value, row, op, $cell) {
                            learun.clientdata.getAsync('user', {
                                key: value,
                                callback: function (_data) {
                                    callback(_data.name);
                                }
                            });
                        }
                    },
                ],
                mainId: 'F_EmpolyeeCheckId',
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
