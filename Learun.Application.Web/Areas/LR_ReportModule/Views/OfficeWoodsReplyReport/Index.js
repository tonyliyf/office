/* * 版 本 Learun-ADMS V7.0.3 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-02-27 16:45
 * 描  述：办公物品汇总报表
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
               // 月
                mShow: true,
                premShow: true,
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
                selectfn: function () {
                  page.search();
                }
            });

            $('#multiple_condition_query').lrMultipleQuery(function (queryJson) {
                page.search(queryJson);
            }, 220, 400);
            $('#F_Company').lrDataSourceSelect({ code: 'company', value: 'f_companyid', text: 'f_shortname' });
            $('#F_Dept').lrDepartmentSelect();
            // 刷新
            $('#lr-replace').on('click', function () {
                location.reload();
            });
            //打印
            $('#lr-print').on('click', function () {
                $("#gridtable").jqprintTable({ title: '办公物品汇总报表' });
            });
            //导出
            $('#lr-export').on('click', function () {
                learun.download({
                    method: "POST",
                    url: '/Utility/ExportExcel',
                    param: {
                        fileName: "办公物品汇总报表",
                        columnJson: JSON.stringify($('#gridtable').jfGridGet('settingInfo').headData),
                        dataJson: JSON.stringify($('#gridtable').jfGridGet('settingInfo').rowdatas)
                    }
                });
            });
        },
        // 初始化列表
        initGird: function () {
            $('#gridtable').jfGrid({
                url: top.$.rootUrl + '/LR_ReportModule/OfficeWoodsReplyReport/GetPageList',
                headData: [
                    { label: "申请单位", name: "companyname", width: 250, align: "center" },
                    { label: "申请部门", name: "deptname", width: 200, align: "center" },
                    { label: "申请月份", name: "f_replymonth", width: 160, align: "center" },
                    { label: "物品名称", name: "f_woodname", width: 250, align: "center" },
                    { label: "物品类型", name: "dc_oa_woodstype", width: 250, align: "center" },
                    { label: "物品价格", name: "dc_price", width: 250, align: "center" },
                    { label: "物品单位", name: "dc_unit", width: 250, align: "center" },
                    { label: "数量", name: "f_nums", width: 100, align: "center" },
                                  
                ],
                reloadSelected: true,
                mainId:'F_OfficeWoodsReplyId'
              });
            page.search();
        },
        search: function (param) {
            param = param || {};
            param.StartTime = $('#datesearch').dfvalue;
           $('#gridtable').jfGridSet('reload',{ queryJson: JSON.stringify(param) });
        }
    };
   
    page.init();
}
