/* * 版 本 Learun-ADMS V7.0.3 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-02-28 15:06
 * 描  述：维修车辆统计报表
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
            $('#F_DeptId').lrDepartmentSelect();

            $('#F_ReplyId').lrUserSelect(0);

            $('#F_CompanyId').lrDataSourceSelect({ code: 'company', value: 'f_companyid', text: 'f_shortname' });
            // 刷新
            $('#lr-replace').on('click', function () {
                location.reload();
            });
            //打印
            $('#lr-print').on('click', function () {
                $("#gridtable").jqprintTable({ title: '车辆使用统计表' });
            });
            //导出
            $('#lr-export').on('click', function () {
                learun.download({
                    method: "POST",
                    url: '/Utility/ExportExcel',
                    param: {
                        fileName: "车辆使用统计表",
                        columnJson: JSON.stringify($('#gridtable').jfGridGet('settingInfo').headData),
                        dataJson: JSON.stringify($('#gridtable').jfGridGet('settingInfo').rowdatas)
                    }
                });
            });
        },
        // 初始化列表
        initGird: function () {
            $('#gridtable').jfGrid({
                url: top.$.rootUrl + '/LR_ReportModule/VehicleRepairRecord/GetPageList',
                headData: [
                    { label: "司机", name: "F_driver", width: 100, align: "center" }, 
                    { label: "车牌号", name: "F_license", width: 100, align: "center" },       
                    { label: "维修类型", name: "F_breakdownType", width: 100, align: "center" },                   
                    { label: "维修地点", name: "F_VehicleLocation", width: 130, align: "center" },
                    { label: "预计维修金额", name: "F_Money", width: 100, align: "center" },
                    { label: "申请公司", name: "F_CompanyId", width: 100, align: "center" },
                    { label: "申请部门", name: "F_DeptId", width: 130, align: "center" }, 
                    {
                        label: "预计维修开始时间", name: "F_VehicleStartDate", width: 120, align: "center", formatterAsync: function (callback, value, row, op, $cell) {

                            var str = /^[\u4e00 - \u9fa5]{0,}$/;
                            if (value.length > 9) {
                                //判断所截字符含有中文
                                if (!str.test(value.substring(0, 10))) {
                                  
                                    callback(value.substring(0, 9));
                                }
                                else {
                               
                                    callback(value.substring(0, 10));
                                }                             
                            } else {
                                callback(value);
                            }
                        }
                    },
                    {
                        label: "预计维修结束时间", name: "F_VehicleEndDate", width: 120, align: "center", formatterAsync: function (callback, value, row, op, $cell) {
                            var str = /^[\u4e00 - \u9fa5]{0,}$/;
                            if (value.length > 9)
                            {
                                //判断所截字符含有中文
                                if (!str.test(value.substring(0, 10))) {

                                    callback(value.substring(0, 9));
                                }
                                else {

                                    callback(value.substring(0, 10));
                                }
                            } else {
                                callback(value);
                            }
                        }
                    },
                    { label: "维修原因", name: "F_breakdown", width: 100, align: "center" },
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
    page.init();
}
