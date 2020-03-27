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
            //$('#executeState').lrDataItemSelect({ code: 'OS_F_State' });

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
                //debugger;
                page.search(queryJson);
            }, 220, 400);

            // 刷新
            $('#lr-replace').on('click', function () {
                location.reload();
            });
            //打印
            $('#lr-print').on('click', function () {
                $("#gridtable").jqprintTable({ title: '督办任务统计表' });
            });
            //导出
            $('#lr-export').on('click', function () {
                learun.download({
                    method: "POST",
                    url: '/Utility/ExportExcel',
                    param: {
                        fileName: "督办报表",
                        columnJson: JSON.stringify($('#gridtable').jfGridGet('settingInfo').headData),
                        dataJson: JSON.stringify($('#gridtable').jfGridGet('settingInfo').rowdatas)
                    }
                });
            });
        },
        initGrid: function () {
            $("#gridtable").height($(window).height() - 170);
            $('#gridtable').jfGrid({
                url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_OverSeeWork/StatisticsWorkByCurrentMonth',
                headData: [
                    {
                        name: "createDate", label: "创建日期", width: 100, align: "center", formatter: function (value) {
                            if (value && value.length > 10) {
                                return value.substr(0, 10)
                            } else {
                                return value
                            }
                        }
                    },
                    { label: "工作主题", name: "workTitle", width: 100, align: "center" },
                    { name: "workType", label: "督办工作类型", width: 100, align: "center" },
                    { name: "workContent", label: "工作事项", width: 300, align: "center" },
                    { name: "executeState", label: "状态", width: 100, align: "center" },
                    { name: "executeContent", label: "执行情况", width: 300, align: "center" },
                    //{ name: "workSplit1", label: "任务项", width: 300, align: "center" },
                    //{ name: "workSplit2", label: "任务分解项", width: 300, align: "center" },
                    {
                        name: "endTime", label: "时间节点", width: 100, align: "center", formatterAsync: function (callback, value, row, op, $cell) {
                            if (value.length <= 10) {
                                callback(value);
                            } else {
                                callback(value.substring(0, 10));
                            }
                        }
                    },
                    {
                        name: "dutyDepartment", label: "责任单位", width: 100, align: "center"
                    },
                    {
                        name: "dutyLeader", label: "责任领导", width: 100, align: "center"
                    },
                    {
                        name: "mainDepartment", label: "主办单位", width: 100, align: "center"
                    },
                    {
                        name: "mainDepartmentDutyOwner", label: "主办人", width: 100, align: "center"
                    },
                    {
                        name: "mainDepartmentLeader", label: "主办领导", width: 100, align: "center"
                    },
                    { name: "helpDepartment", label: "协办单位", width: 100, align: "center" },
                    { name: "helpDutyOwner", label: "协办人", width: 100, align: "center" },
                ],
                reloadSelected: true,
                onRenderComplete: function (rowDatas) {
                    page.mergeRow('gridtable', 'orderBy')
                    page.mergeRow('gridtable', 'workTitle')
                    page.mergeRow('gridtable', 'createDate')
                },
                mainId: 'id'
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
            param.executeState = $("#executeState").val()
            param.workTitle = $("#workTitle").val()
            if (!startDate) {
                param.startDate = now.getFullYear() + "-" + addZero(now.getMonth() + 1) + "-01 00:00:00"
                param.endDate = nextMonth.getFullYear() + "-" + addZero(nextMonth.getMonth() + 1) + "-" + addZero(nextMonth.getDate()) + " 00:00:00"
            }
            $('#gridtable').jfGridSet('reload', param);

        },
        mergeRow: function (table, colume) {

            var $cells = $('#jfgrid_right_' + table).find('.jfgrid-data-cell[colname="' + colume + '"]')
            var prevIndex = 0
            var prevText = ''
            for (var i = 0; i < $cells.length; i++) {
                var $cell = $($cells[i])
                if (i == 0) {
                    prevText = $cell.html()
                } else {
                    if (prevText != $cell.html() || i == $cells.length - 1) {
                        var span = i - prevIndex
                        if (i == $cells.length - 1) {
                            span++
                            for (var j = 0; j < span; j++) {
                                var cell = $cells.filter('[rowindex="' + (prevIndex + j) + '"]').addClass('cell-merged')
                                if (j == 0) {
                                    cell.css('height', (28 * span) + 'px').css('line-height', (28 * span) + 'px')
                                } else {
                                    cell.remove()
                                }
                            }
                        } else if (span > 1) {
                            for (var j = 0; j < span; j++) {
                                var cell = $cells.filter('[rowindex="' + (prevIndex + j) + '"]')
                                if (j == 0) {
                                    cell.css('height', (28 * span) + 'px').css('line-height', (28 * span) + 'px')
                                } else {
                                    cell.remove()
                                }
                            }
                        }
                        prevIndex = i
                        prevText = $cell.html()
                    }
                }
            }
        }
    };
    page.init();
}


