var startDate="1753-01-01";
var endDate="3000-01-01";

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
                $("#gridtable").jqprintTable({ title: '工程项目分类报表' });
            });
            //导出
            $('#lr-export').on('click', function () {
                learun.download({
                    method: "POST",
                    url: '/Utility/ExportExcel',
                    param: {
                        fileName: "工程项目分类报表",
                        columnJson: JSON.stringify($('#gridtable').jfGridGet('settingInfo').headData),
                        dataJson: JSON.stringify($('#gridtable').jfGridGet('settingInfo').rowdatas)
                    }
                });
            });
        },
        initGrid: function () {
            $("#gridtable").height($(window).height() - 170);
            $('#gridtable').jfGrid({
                url: top.$.rootUrl + '/ProjectManager/DC_EngineProject_ProjectInfo/StatisticsProjectInfoByCategory',
                headData: [
                    { name: "company", label: "项目所属公司", width: 100, align: "center" },
                    { name: "state", label: "项目状态", width: 100, align: "center" },
                    { name: "count", label: "数量", width: 100, align: "center" },
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
            param.startDate = startDate
            param.endDate = endDate
            //if (!startDate) {
            //    param.startDate = now.getFullYear() + "-" + addZero(now.getMonth() + 1) + "-01 00:00:00"
            //    param.endDate = nextMonth.getFullYear() + "-" + addZero(nextMonth.getMonth() + 1) + "-" + addZero(nextMonth.getDate()) + " 00:00:00"
            //}
            $('#gridtable').jfGridSet('reload', param);
            var myChart = echarts.init(document.getElementById("statistics_chart"));
            var option = {
                tooltip: {
                    trigger: 'axis'
                },
                legend: {
                    data: ['日常督办', '重点建设项目', '投资项目', '政府工作报告', '总经理办公室'],
                    textStyle: { color: "#000" }
                },

                calculable: true,
                xAxis: [{
                    type: 'category',
                    data: ['执行中', '完成', '逾期', '临近', '暂停', '终止'],
                    axisLine: {
                        lineStyle: {
                            type: 'solid',
                            color: '#919191',//左边线的颜色
                            width: '2'//坐标线的宽度
                        }
                    }
                }],
                yAxis: [{
                    type: 'value',
                    axisLine: {
                        lineStyle: {
                            type: 'solid',
                            color: '#919191',//左边线的颜色
                            width: '1'//坐标线的宽度
                        }
                    }
                }],
                series: [{
                    name: '日常督办',
                    type: 'bar',
                    data: [2, 4, 6, 13, 6, 7],
                    itemStyle: {
                        //通常情况下：
                        normal: {
                            //每个柱子的颜色即为colorList数组里的每一项，如果柱子数目多于colorList的长度，则柱子颜色循环使用该数组
                            color: function (params) {
                                var colorList = ['rgb(164,205,238)'];
                                return colorList[params.dataIndex];
                            }
                        }
                    }
                },
                {
                    name: '重点建设项目',
                    type: 'bar',
                    data: [5, 11, 9, 2, 5, 12]
                }, {
                    name: '投资项目',
                    type: 'bar',
                    data: [6, 9, 0, 26, 4, 8]
                }, {
                    name: '政府工作报告',
                    type: 'bar',
                    data: [3, 1, 9, 24, 1, 8]
                }, {
                    name: '总经理办公室',
                    type: 'bar',
                    data: [3, 5, 9, 6, 4, 5]
                }

                ]
            }
            $.post('StatisticsProjectInfoByCategoryEx', param, function (data) {
                option.legend.data = data.categoryList
                var series = []
                for (var i = 0; i < data.SeriesData.length; i++) {
                    series.push({
                        name: data.SeriesData[i].Key,
                        type: 'bar',
                        data: data.SeriesData[i].Value
                    })
                }
                option.series = series
                option.xAxis[0].data = data.stateList
                myChart.setOption(option)
            }, 'json')
        }
    };
    page.init();
}


