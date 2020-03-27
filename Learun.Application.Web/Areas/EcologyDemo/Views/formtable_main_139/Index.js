/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-11-08 09:46
 * 描  述：formtable_main_139
 */
var refreshGirdData;
var bootstrap = function ($, learun) {
    "use strict";
    var startTime;
    var endTime;
    var page = {
        init: function () {
            page.initGird();
            page.bind();
        },
        bind: function () {
            // 时间搜索框
            $('#datesearch').lrdate({
                dfdata: [
                    { name: '今天', begin: function () { return learun.getDate('yyyy-MM-dd 00:00:00') }, end: function () { return learun.getDate('yyyy-MM-dd 23:59:59') } },
                    { name: '近7天', begin: function () { return learun.getDate('yyyy-MM-dd 00:00:00', 'd', -6) }, end: function () { return learun.getDate('yyyy-MM-dd 23:59:59') } },
                    { name: '近1个月', begin: function () { return learun.getDate('yyyy-MM-dd 00:00:00', 'm', -1) }, end: function () { return learun.getDate('yyyy-MM-dd 23:59:59') } },
                    { name: '近3个月', begin: function () { return learun.getDate('yyyy-MM-dd 00:00:00', 'm', -3) }, end: function () { return learun.getDate('yyyy-MM-dd 23:59:59') } }
                ],
                // 月
                mShow: false,
                premShow: false,
                // 季度
                jShow: false,
                prejShow: false,
                // 年
                ysShow: false,
                yxShow: false,
                preyShow: false,
                yShow: false,
                // 默认
                dfvalue: '1',
                selectfn: function (begin, end) {
                    startTime = begin;
                    endTime = end;
                    page.search();
                }
            });
            $('#multiple_condition_query').lrMultipleQuery(function (queryJson) {
                page.search(queryJson);
            }, 220, 400);
            // 刷新
            $('#lr_refresh').on('click', function () {
                location.reload();
            });
            //// 新增
            //$('#lr_add').on('click', function () {
            //    learun.layerForm({
            //        id: 'form',
            //        title: '新增',
            //        url: top.$.rootUrl + '/EcologyDemo/formtable_main_139/Form',
            //        width: 600,
            //        height: 400,
            //        callBack: function (id) {
            //            return top[id].acceptClick(refreshGirdData);
            //        }
            //    });
            //});
            //// 编辑
            //$('#lr_edit').on('click', function () {
            //    var keyValue = $('#gridtable').jfGridValue('id');
            //    if (learun.checkrow(keyValue)) {
            //        learun.layerForm({
            //            id: 'form',
            //            title: '编辑',
            //            url: top.$.rootUrl + '/EcologyDemo/formtable_main_139/Form?keyValue=' + keyValue,
            //            width: 600,
            //            height: 400,
            //            callBack: function (id) {
            //                return top[id].acceptClick(refreshGirdData);
            //            }
            //        });
            //    }
            //});
            //查看
            $('#lr_add').on('click', function () {
                var keyValue = $('#gridtable').jfGridValue('id');
                if (learun.checkrow(keyValue)) {
                    learun.layerForm({
                        id: 'form',
                        title: '查看',
                        url: top.$.rootUrl + '/EcologyDemo/formtable_main_139/Form?keyValue=' + keyValue,
                        width: 600,
                        height: 600,
                        btn: null
                    });
                }
            });
            //// 删除
            //$('#lr_delete').on('click', function () {
            //    var keyValue = $('#gridtable').jfGridValue('id');
            //    if (learun.checkrow(keyValue)) {
            //        learun.layerConfirm('是否确认删除该项！', function (res) {
            //            if (res) {
            //                learun.deleteForm(top.$.rootUrl + '/EcologyDemo/formtable_main_139/DeleteForm', { keyValue: keyValue}, function () {
            //                    refreshGirdData();
            //                });
            //            }
            //        });
            //    }
            //});
            //// 打印
            //$('#lr_print').on('click', function () {
            //    $('#gridtable').jqprintTable();
            //});
        },
        // 初始化列表
        initGird: function () {
            $('#gridtable').jfGrid({
                url: top.$.rootUrl + '/EcologyDemo/formtable_main_139/GetPageList',
                headData: [
                    { label: "房屋名称", name: "F_HouseName", width: 100, align: "left" },
                    { label: "申请人", name: "lastname", width: 100, align: "left" },
                    { label: "维修地点", name: "wxdd", width: 100, align: "left"},
                    { label: "维修日期", name: "wxrq", width: 100, align: "left"},
                    { label: "预计维修金额", name: "yjwxje", width: 100, align: "left"},
                    { label: "故障描述", name: "gzms", width: 100, align: "left"},
                ],
                mainId:'id',
                isPage: true,
                dblclick: function (rowdata) {
                    var keyValue = $('#gridtable').jfGridValue('id');
                    learun.layerForm({
                        id: 'form',
                        title: '查看',
                        url: top.$.rootUrl + '/EcologyDemo/formtable_main_139/Form?keyValue=' + keyValue,
                        width: 600,
                        height: 570,
                        callBack: function (id) {
                            return top[id].acceptClick(refreshGirdData);
                        }
                    });

                }
            });
        },
        search: function (param) {
            param = param || {};
            param.StartTime = startTime;
            param.EndTime = endTime;
            $('#gridtable').jfGridSet('reload',{ queryJson: JSON.stringify(param) });
        }
    };
    refreshGirdData = function () {
        $('#gridtable').jfGridSet('reload');
    };
    page.init();
}
