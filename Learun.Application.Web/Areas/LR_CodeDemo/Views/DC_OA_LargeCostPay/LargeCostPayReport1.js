﻿var startDate = "1753-01-01";
var endDate = "3000-01-01";
var bootstrap = function ($, learun) {
    "use strict";

    var page = {
        init: function () {
            page.bind();
            page.initGrid();
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
            var lrMultipleQuery = function ($dom, search, height, width) {
                var $this = $dom;
                var contentHtml = $this.html();
                $this.addClass('lr-query-wrap');


                var _html = '';
                _html += '<div class="lr-query-btn"><i class="fa fa-search"></i>&nbsp;多条件查询</div>';
                _html += '<div class="lr-query-content">';
                //_html += '<div class="lr-query-formcontent">';
                _html += contentHtml;
                //_html += '</div>';
                _html += '<div class="lr-query-arrow"><div class="lr-query-inside"></div></div>';
                _html += '<div class="lr-query-content-bottom">';
                _html += '<a id="lr_btn_queryReset" class="btn btn-default">&nbsp;重&nbsp;&nbsp;置</a>';
                _html += '<a id="lr_btn_querySearch" class="btn btn-primary">&nbsp;查&nbsp;&nbsp;询</a>';
                _html += '</div>';
                _html += '</div>';
                $this.html(_html);
                $this.find('.lr-query-formcontent').show();

                $this.find('.lr-query-content').css({ 'width': width || 400, 'height': height || 300 });

                $this.find('.lr-query-btn').on('click', function () {
                    var $content = $this.find('.lr-query-content');
                    if ($content.hasClass('active')) {
                        $content.removeClass('active');
                    }
                    else {
                        $content.addClass('active');
                    }
                });

                $this.find('#lr_btn_querySearch').on('click', function () {
                    page.search()
                });

                $this.find('#lr_btn_queryReset').on('click', function () {
                    $('#groupBy').lrselectSet(null)
                });

                $(document).click(function (e) {
                    var et = e.target || e.srcElement;
                    var $et = $(et);
                    if (!$et.hasClass('lr-query-wrap') && $et.parents('.lr-query-wrap').length <= 0) {

                        $('.lr-query-content').removeClass('active');
                    }
                });
            };
            lrMultipleQuery($('#multiple_condition_query'), function (queryJson) {
                page.search(queryJson);
            }, 220, 400);
            $('#groupBy').lrselect({
                data: [{ id: '金源', text: '金源' }, { id: '金润源', text: '金润源' }, { id: '国资中心', text: '国资中心' }]
            }).lrselectSet('F_CreateDepartmentId')
            // 刷新
            $('#lr-replace').on('click', function () {
                location.reload();
            });
            //打印
            $('#lr-print').on('click', function () {
                $("#gridtable").jqprintTable({ title: '资产统计表' });
            });
            //导出
            $('#lr-export').on('click', function () {
                learun.download({
                    method: "POST",
                    url: '/Utility/ExportExcel',
                    param: {
                        fileName: "资产统计表",
                        columnJson: JSON.stringify($('#gridtable').jfGridGet('settingInfo').headData),
                        dataJson: JSON.stringify($('#gridtable').jfGridGet('settingInfo').rowdatas)
                    }
                });
            });
        },
        initGrid: function () {

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
            //选择分类
            param.groupBy = $('#groupBy').lrselectGet()

            var renderChart = function (id, data, text) {
                debugger;
                var myChart = echarts.init(document.getElementById(id));
                if (data.length > 0) {
                    var legendData = []
                    var seriesData = []
                    for (var field in data[0]) {
                        legendData.push(field)
                    }
                    for (var i = 0; i < data.length; i++) {
                        var tempdata = {}
                        for (var j = 0; j < legendData.length; j++) {
                            if (legendData[j] == 'money') {
                                tempdata.value = data[i][legendData[j]]
                            } else {
                                tempdata.name = data[i][legendData[j]]
                            }
                        }
                        seriesData.push(tempdata)
                    }
                    // 指定图表的配置项和数据
                    var option = {
                        title: {
                            text: '资产统计表',
                            x: 'center'
                        },
                        tooltip: {
                            trigger: 'item',
                            formatter: "{a} <br/>{b} : {c} ({d}%)"
                        },
                        legend: {
                            orient: 'vertical',
                            left: 'left',
                            data: data.map(function (c) { return c[legendData[0]] })
                        },
                        series: [
                            {
                                name: text,
                                type: 'pie',
                                radius: '55%',
                                center: ['50%', '60%'],
                                data: seriesData,
                                itemStyle: {
                                    emphasis: {
                                        shadowBlur: 10,
                                        shadowOffsetX: 0,
                                        shadowColor: 'rgba(0, 0, 0, 0.5)'
                                    }
                                }
                            }
                        ]
                    };
                    myChart.setOption(option);
                }
            }
            var explainField = function (columeName) {
                switch (columeName) {
                    case 'sum':
                        return '合计'
                    case 'f_createdepartmentid':
                    case 'f_createdepartment':
                        return '部门'
                    case 'f_reimbursementcontent':
                        return '报销名称'
                    case 'f_createdate':
                        return '报销日期'
                    case 'f_money':
                        return '支出金额'
                    case 'f_company':
                        return '公司名称'
                    case 'f_moneyuse':
                        return '资金用途'
                    case 'money':
                        return '资产合计(万元)'
                    case 'type':
                        return '管理单位'
                    default:
                        return ''
                }
            }
            $.post(top.$.rootUrl + '/LR_CodeDemo/DC_OA_LargeCostPay/GetLargeCostPayData1', param, function (res) {
                if (res.code == 200) {
                    var colume = {}
                    var headData = []
                    var resData = []
                    var resData2 =[]
                    var i = 0;
                 
                    if (res.data.length > 0) {
                        for (var id in res.data[0]) {
                            var hdata = { label: explainField(id), name: id, width: 200, align: "center" }
                            if (id == 'money') {

                               // renderChart('statistics_chart', res.data, param.groupBy)
                            }
                          headData.push(hdata)
                          
                        }
                        for (i = 0; i < res.data.length; i++) {
                            debugger;
                            if (i < res.data.length / 2)
                            {
                                resData.push(res.data[i]);
                            }
                            else
                            {
                                resData2.push(res.data[i]);

                            }

                        }
                    }
                   
                    $('#gridtable').removeClass('jfgrid-layout').removeClass('jfgrid-layout').html('');
                    $('#gridtable')[0].dfop = null
                    $('#gridtable').jfGrid({
                        headData: headData,
                        rowdatas: resData
                    });
                    $('#gridtable2').removeClass('jfgrid-layout').removeClass('jfgrid-layout').html('');
                    $('#gridtable2')[0].dfop = null
                    $('#gridtable2').jfGrid({
                        headData: headData,
                        rowdatas: resData2
                    });


                } else {
                    learun.alert.warning(res.info)
                }
            }, 'json')
        }
    };
    page.init();
}


