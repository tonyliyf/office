/* * 版 本 Learun-ADMS V7.0.3 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-01-25 17:08
 * 描  述：DC_OA_PerformanceUserWorkPlan
 */
var acceptClick
var refreshGirdData;
var keyValue = request('keyValue')
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
            // 编辑
            $('#lr_edit').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('F_PUWPId');
                if (learun.checkrow(keyValue)) {
                    if ($('#gridtable').jfGridValue('F_IfTargetDefine') != 1) {
                        learun.alert.error('该项非自填项不可编辑')
                        return
                    }
                    learun.layerForm({
                        id: '1212____form',
                        title: '编辑',
                        url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_PerformanceUserWorkPlan/Form?keyValue=' + keyValue,
                        width: 600,
                        height: 400,
                        callBack: function (id) {
                            return top[id].acceptClick(refreshGirdData);
                        }
                    });
                }
            });
        },
        // 初始化列表
        initGird: function () {
            $('#gridtable').jfGrid({
                url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_PerformanceUserWorkPlan/GetList',
                headData: [
                    { label: "指标名称", name: "F_TargetName", width: 100, align: "left" },
                    {
                        label: "指标内容", name: "F_TargetContent", width: 100, align: "left", formatter: function (value, row) {
                            if (row.F_IfTargetDefine == 1) {
                                return "<p style='color:#CCC'>" + value + "</p>"
                            } else {
                                return value;
                            }
                        }
                    },
                    {
                        label: "指标目标", name: "F_Target", width: 200, align: "left", formatter: function (value, row) {
                            if (row.F_IfTargetDefine == 1) {
                                return "<p style='color:#CCC'>" + value + "</p>"
                            } else {
                                return value;
                            }
                        }
                    },
                    {
                        label: "评分说明", name: "F_TargetExplain", width: 100, align: "left", formatter: function (value, row) {
                            if (row.F_IfTargetDefine == 1) {
                                return "<p style='color:#CCC'>" + value + "</p>"
                            } else {
                                return value;
                            }
                        }
                    },
                    {
                        label: "是否自填项", name: "F_IfTargetDefine", width: 100, align: "left",
                        formatterAsync: function (callback, value, row, op, $cell) {
                            learun.clientdata.getAsync('dataItem', {
                                key: value,
                                code: 'YesOrNo',
                                callback: function (_data) {
                                    var text;
                                    if (_data.text == "是") {
                                        text = '<span class="label label-success">自填项</span>'
                                    } else {
                                        text = '<span class="label label-default">非自填项</span>'
                                    }
                                    callback(text);
                                }
                            });
                        }
                    },
                ],
                mainId: 'F_PUWPId',
                isTree: true,
                parentId: 'F_ParentId'
            });
            page.search();
        },
        search: function (param) {
            param = param || {};
            $('#gridtable').jfGridSet('reload', { keyValue: keyValue });
        }
    };
    refreshGirdData = function () {
        page.search()
    };
    acceptClick = function (cb) {
        $.post(top.$.rootUrl + '/LR_CodeDemo/DC_OA_PerformanceUserWork/BeginCheck', { wid: keyValue }, function (res) {
            if (res.code == 200) {
                learun.alert.success(res.info)
            } else {
                learun.alert.error(res.info)
            }
            learun.layerClose(window.name)
            cb()
        }, 'json')
    }
    page.init();
}
