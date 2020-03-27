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
            $('#dataTree').lrtree({
                url: top.$.rootUrl + '/Portal/GetDeptUserTree',
                nodeClick: function (item) {
              
                    page.search({ F_UserId: item.id });

                }
            });
            // 刷新
            $('#lr_refresh').on('click', function () {
                location.reload();
            });
        },
        // 初始化列表
        initGird: function () {
            $('#gridtable').jfGrid({
                url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_PerformanceCheck/GetPageList7',
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
                isPage: true,
                dblclick: function (rowdata) {

                    parent.a(rowdata.F_CheckUserid)
                },
                onSelectRow: function (rowdata) {
                    parent.b(rowdata.F_CheckUserid,rowdata.F_CheckUserDeptId)
                }
            
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
