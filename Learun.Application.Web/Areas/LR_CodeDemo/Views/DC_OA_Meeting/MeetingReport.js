var startDate
var endDate
var bootstrap = function ($, learun) {
    "use strict";

    var page = {
        init: function () {
            page.initGrid();
            page.bind();
        },
        bind: function () {
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
                    startDate = begin;
                    endDate = end;
                    page.search();
                }
            });
            // 刷新
            $('#lr-replace').on('click', function () {
                location.reload();
            });
            //打印
            $('#lr-print').on('click', function () {
                $("#gridtable").jqprintTable({ title: '会议统计表' });
            });
            //导出
            $('#lr-export').on('click', function () {
                learun.download({
                    method: "POST",
                    url: '/Utility/ExportExcel',
                    param: {
                        fileName: "会议报表",
                        columnJson: JSON.stringify($('#gridtable').jfGridGet('settingInfo').headData),
                        dataJson: JSON.stringify($('#gridtable').jfGridGet('settingInfo').rowdatas)
                    }
                });
            });
        },
        initGrid: function () {
            $("#gridtable").height($(window).height() - 170);
            $('#gridtable').jfGrid({
                url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_Meeting/GetPageList',
                headData: [
                    { name: "title", label: "标题", width: 100, align: "center" },
                    { name: "topic", label: "主题", width: 300, align: "center" },
                    { name: "content", label: "内容", width: 300, align: "center" },
                    { name: "managername", label: "支持人", width: 100, align: "center" },
                    {
                        name: "starttime", label: "起始时间", width: 100, align: "center", formatter: function (value, row) {
                            if (value.length > 10) {
                                return (value.substring(0, 10));
                            } else {
                                return (value);
                            }
                        }
                    },
                    {
                        name: "endtime", label: "结束时间", width: 100, align: "center", formatter: function (value, row) {
                            if (value.length > 10) {
                                return (value.substring(0, 10));
                            } else {
                                return (value);
                            }
                        }
                    },
                    { name: "roomname", label: "会议室", width: 100, align: "center" },

                ],
                reloadSelected: true,
                //mainId: 'billNo'
            });

            page.search();
        },
        search: function (param) {
            function addZero(i) {
                return (i >= 10) ? i : ("0" + i)
            }
            param = param || {};
            var now = new Date();
            var nextMonth = new Date();
            if (nextMonth.getMonth() == 11) {
                nextMonth.setMonth(0)
                nextMonth.setFullYear(nextMonth.getFullYear() + 1)
            } else {
                nextMonth.setMonth(nextMonth.getMonth() + 1)
            }
            param.StartTime = startDate
            param.EndTime = endDate
            if (!startDate) {
                param.StartTime = now.getFullYear() + "-" + addZero(now.getMonth() + 1) + "-01 00:00:00"
                param.EndTime = nextMonth.getFullYear() + "-" + addZero(nextMonth.getMonth() + 1) + "-" + addZero(nextMonth.getDate()) + " 00:00:00"
            }
            $('#gridtable').jfGridSet('reload', { queryJson: JSON.stringify(param) });
        }
    };
    page.init();
}


