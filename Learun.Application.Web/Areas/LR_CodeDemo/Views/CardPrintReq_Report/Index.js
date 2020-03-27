/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-03-15 11:59
 * 描  述：用章报表
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
            $('#F_Applicant').lrUserSelect(0);
            $('#F_Dept').lrDepartmentSelect();
            // 刷新
            $('#lr_refresh').on('click', function () {
                location.reload();
            });
          
            //导出
            $('#lr-export').on('click', function () {
                learun.download({
                    method: "POST",
                    url: '/Utility/ExportExcel',
                    param: {
                        fileName: "采购结果审核报表",
                        columnJson: JSON.stringify($('#gridtable').jfGridGet('settingInfo').headData),
                        dataJson: JSON.stringify($('#gridtable').jfGridGet('settingInfo').rowdatas)
                    }
                });
            });
        },
        // 初始化列表
        initGird: function () {
            $('#gridtable').lrAuthorizeJfGrid({
                url: top.$.rootUrl + '/LR_CodeDemo/CardPrintReq_Report/GetPageList',
                headData: [
                    { label: "标题", name: "f_title", width: 100, align: "left"},
                    { label: "申请部门", name: "f_dept", width: 100, align: "left",
                        formatterAsync: function (callback, value, row, op,$cell) {
                             learun.clientdata.getAsync('department', {
                                 key: value,
                                 callback: function (_data) {
                                     callback(_data.name);
                                 }
                             });
                        }},
                    { label: "申请人", name: "f_applicant", width: 100, align: "left",
                        formatterAsync: function (callback, value, row, op,$cell) {
                             learun.clientdata.getAsync('user', {
                                 key: value,
                                 callback: function (_data) {
                                     callback(_data.name);
                                 }
                             });
                        }},
                    { label: "公章类型", name: "f_cachetype", width: 100, align: "left",
                        formatterAsync: function (callback, value, row, op,$cell) {
                             learun.clientdata.getAsync('custmerData', {
                                 url: '/LR_SystemModule/DataSource/GetDataTable?code=' + 'GetStampInfo',
                                 key: value,
                                 keyId: 'f_stampname',
                                 callback: function (_data) {
                                     callback(_data['f_stampname']);
                                 }
                             });
                        }},
                    { label: "授函单位", name: "f_letterunit", width: 100, align: "left"},
                    { label: "函件名称", name: "f_lettername", width: 100, align: "left"},
                    { label: "申请时间", name: "f_datatime", width: 100, align: "left"},
                    { label: "相关项目", name: "f_project", width: 100, align: "left"},
                    { label: "相关客户", name: "f_customer", width: 100, align: "left"},
                    { label: "使用原因", name: "f_usereason", width: 100, align: "left"},
                ],
                mainId:'F_Id',
                isPage: true
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
