/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn) 
 * Copyright (c) 2013-2018 上海力软信息技术有限公司 
 * 创建人：超级管理员 
 * 日  期：2019-04-16 10:54 
 * 描  述：DC_ASSETS_BusStopBillboardsMaintenanceRecords 
 */
var refreshGirdData;
var query;
var bootstrap = function ($, learun) {
    "use strict";
    var startTime="1753-01-01";
    var endTime="3000-01-01";
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
            $('#F_ApplicationDepartmentId').lrDepartmentSelect();
            $('#F_ApplicationUserId').lrUserSelect(0);
 
            // 刷新 
            $('#lr_refresh').on('click', function () {
                location.reload();
            });
            //导出
            $('#lr-export').on('click', function () {

                learun.download({
                    method: "POST",
                    url: top.$.rootUrl + '/AssetManager/DC_ASSETS_BusStopBillboardsMaintenanceRecords/ExportExcel',
                    param: {
                        fileName: "广告牌维修记录表",
                        columnJson: JSON.stringify($('#gridtable').jfGridGet('settingInfo').headData),
                        queryJson: JSON.stringify(query)
                    }
                });
            });

        },
        // 初始化列表 
        initGird: function () {
            $('#gridtable').jfGrid({
                url: top.$.rootUrl + '/AssetManager/DC_ASSETS_BusStopBillboardsMaintenanceRecords/GetPageList',
                headData: [
                    { label: "广告牌名称", name: "F_BSBId", width: 100, align: "left" },
                    { label: "维修单号", name: "F_MaintenanceNumber", width: 100, align: "left" },
                    { label: "申请部门", name: "F_ApplicationDepartmentId", width: 100, align: "left" },
                    { label: "申请人", name: "F_ApplicationUserId", width: 100, align: "left" },
                    {
                        label: "申请时间", name: "F_ApplicationDate", width: 100, align: "left", formatterAsync: function (callback, value, row, op, $cell) {
                            if (value.length <= 10) {
                                callback(value);
                            } else {
                                callback(value.substring(0, 10));
                            }
                        }
                    },
                    { label: "故障描述", name: "F_FaultDescription", width: 100, align: "left" },      
                    {
                        label: "维修状态", name: "F_MaintenanceState", width: 100, align: "left",
                        formatterAsync: function (callback, value, row, op, $cell) {
                            learun.clientdata.getAsync('dataItem', {
                                key: value,
                                code: 'MaintenanceState',
                                callback: function (_data) {
                                    callback(_data.text);
                                }
                            });
                        }
                    },

                    { label: "备注", name: "F_Remarks", width: 100, align: "left" },
                ],
                mainId: 'F_BSBMRId',
                isPage: true
            });
            page.search();
        },
        search: function (param) {
            param = param || {};
            param.StartTime = startTime;
            param.EndTime = endTime;
            query = param;
            $('#gridtable').jfGridSet('reload', { queryJson: JSON.stringify(param) });
        }
    };
    refreshGirdData = function () {
        $('#gridtable').jfGridSet('reload');
    };
    page.init();
} 