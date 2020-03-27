/* * 版 本 Learun-ADMS V7.0.0 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-01-03 17:44
 * 描  述：会议室管理
 */
var refreshGirdData;
var keyValue = request('keyValue')
var acceptClick;
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
            // 刷新
            $('#lr_refresh').on('click', function () {
                location.reload();
            });
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
                dfvalue: '-1',
                selectfn: function (begin, end) {
                    startTime = begin;
                    endTime = end;
                    page.search();
                }
            });
            $('#multiple_condition_query').lrMultipleQuery(function (queryJson) {
                page.search(queryJson);
            }, 220, 400);
        },
        // 初始化列表
        initGird: function () {
            $('#gridtable').jfGrid({
                url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_OverSeeWorkTaskSplit/GetProcessPageList',
                headData: [
                    { label: "标题", name: "F_Title", width: 500, align: "center" },
                    { label: "创建人", name: "F_CreateUserName", width: 120, align: "center" },
                    {
                        label: "创建时间", name: "F_CreateDate", width: 120, align: "center", formatter: function (value) {
                            return value.length > 10 ? value.substr(0, 10) : value
                        }
                    }
                ],
                mainId: 'F_Id',
                isPage: true
            });
            page.search();
        },
        search: function (param) {
            param = param || {};
            param.StartTime = startTime;
            param.EndTime = endTime;
            $('#gridtable').jfGridSet('reload', { queryJson: JSON.stringify(param) });
        }
    };
    refreshGirdData = function () {
        $('#gridtable').jfGridSet('reload');
    };
    acceptClick = function (callBack) {
        var fid = $('#gridtable').jfGridValue('F_Id');
        if (!learun.checkrow(fid)) {
            learun.alert.warning('请选择一个流程')
            return false
        }
        $.get(top.$.rootUrl + '/LR_CodeDemo/DC_OA_OverSeeWorkTaskSplit/ConnectProcess?keyValue=' + keyValue + '&processId=' + fid, function (res) {
            if (res.code == 200) {
                learun.layerClose(window.name)
                learun.alert.success('关联成功')
                callBack()
            } else {
                learun.alert.error(res.info)
            }
        }, 'json')
    };
    page.init();
}
