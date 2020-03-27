/* * 版 本 Learun-ADMS V7.0.3 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-01-16 17:54
 * 描  述：考勤参数设置
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
            $('#multiple_condition_query').lrMultipleQuery(function (queryJson) {
                page.search(queryJson);
            }, 220, 400);
            $('#DC_OAAttenceType').lrDataItemSelect({ code: 'AttenceType' });
            // 刷新
            $('#lr_refresh').on('click', function () {
                location.reload();
            });
            // 新增
            $('#lr_add').on('click', function () {
                learun.layerForm({
                    id: 'form',
                    title: '新增',
                    url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_AttenceSetting/Form',
                    width: 600,
                    height: 550,
                    callBack: function (id) {
                        return top[id].acceptClick(refreshGirdData);
                    }
                });
            });
            // 编辑
            $('#lr_edit').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('DC_OA_AttenceSettingId');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'form',
                        title: '编辑',
                        url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_AttenceSetting/Form?keyValue=' + keyValue,
                        width: 600,
                        height: 550,
                        callBack: function (id) {
                            return top[id].acceptClick(refreshGirdData);
                        }
                    });
                }
            });
            // 删除
            $('#lr_delete').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('DC_OA_AttenceSettingId');
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否确认删除该项！', function (res) {
                        if (res) {
                            learun.deleteForm(top.$.rootUrl + '/LR_CodeDemo/DC_OA_AttenceSetting/DeleteForm', { keyValue: keyValue}, function () {
                                refreshGirdData();
                            });
                        }
                    });
                }
            });

            // 是否启用
            $('#lr_enable').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('DC_OA_AttenceSettingId');
                if (learun.checkrow(keyValue)) {
                    learun.layerConfirm('是否启用该项！', function (res) {
                        if (res) {
                            learun.postForm(top.$.rootUrl + '/LR_CodeDemo/DC_OA_AttenceSetting/UpdateState', { keyValue: keyValue }, function () {
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
                url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_AttenceSetting/GetPageList',
                headData: [
                    { label: "考勤中心地址", name: "DC_OA_AttenceCenterPlace", width: 200, align: "left"},
                    { label: "经度", name: "DC_OA_AttenceLongitude", width: 150, align: "left"},
                    { label: "纬度", name: "DC_OA_AttenceLatitude", width: 150, align: "left"},
                    { label: "考勤类型", name: "DC_OAAttenceType", width: 100, align: "left",
                        formatterAsync: function (callback, value, row, op,$cell) {
                             learun.clientdata.getAsync('dataItem', {
                                 key: value,
                                 code: 'AttenceType',
                                 callback: function (_data) {
                                     callback(_data.text);
                                 }
                             });
                        }
                    },
                    {
                        label: "启用", name: "F_EnabledMark", width: 100, align: "left",

                        formatter: function (cellvalue, row) {

                            if (cellvalue == 1) {
                                return '<span class=\"label label-success\" style=\"cursor: pointer;\">启用</span>';
                            } else if (cellvalue == 0) {
                                return '<span class=\"label label-default\" style=\"cursor: pointer;\">禁用</span>';
                            }
                        }
                    },

                    { label: "有效范围(米）", name: "DC_OA_AttenceDistance", width: 100, align: "left"},
                    { label: "早上签到", name: "DC_OA_AttenceTimeUp1", width: 100, align: "left"},
                    { label: "早上签退", name: "DC_OA_AttenceTimeOut1", width: 100, align: "left"},
                    { label: "下午签到", name: "DC_OA_AttencetTimeUp2", width: 100, align: "left"},
                    { label: "下午签退", name: "DC_OA_AttenceTimeOut2", width: 100, align: "left"},
                    { label: "中班签到", name: "DC_OA_AttenceTimeUp3", width: 100, align: "left"},
                    { label: "中班签退", name: "DC_OA_AttenceTimeOut3", width: 100, align: "left"},
                    { label: "晚班签到", name: "DC_OA_AttenceTimeUp4", width: 100, align: "left"},
                    { label: "晚班签退", name: "DC_OA_AttenceTimeOut4", width: 100, align: "left"},
                ],
                mainId:'DC_OA_AttenceSettingId',
                isPage: true
            });
            page.search();
        },
        search: function (param) {
            param = param || {};
            $('#gridtable').jfGridSet('reload',{ queryJson: JSON.stringify(param) });
        }
    };
    refreshGirdData = function () {
        $('#gridtable').jfGridSet('reload');
    };
    page.init();
}
