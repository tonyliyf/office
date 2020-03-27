/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-05-06 16:59
 * 描  述：货车站点统计报表
 */
var refreshGirdData;
var bootstrap = function ($, learun) {
    "use strict";
    var map = {};
    var startTime;
    var endTime;
    var page = {
        init: function () {
           page.initGird('');
            page.bind();
        },
        bind: function () {

            // 查询 
            $('#btn_Search').on('click', function () {
                var keyword = $('#txt_Keyword').val();
                page.search({ keyword: keyword });
            });
            // 刷新
            $('#lr_refresh').on('click', function () {
                location.reload();
            });
            // 打印
            $('#lr_print').on('click', function () {
                $('#gridtable').jqprintTable();
            });
            // 导出
            $('#lr_outport').on('click', function () {
                learun.download({
                    method: 'POST',
                    url: '/Utility/ExportExcel',
                    param: {
                        fileName: '货车站点统计',
                        columnJson: JSON.stringify($('#gridtable').jfGridGet('settingInfo').headData),
                        dataJson: JSON.stringify($('#gridtable').jfGridGet('settingInfo').rowdatas)
                    }
                });
            });
        },
        // 初始化列表
        initGird: function (param) {

            param = param || {};
          //  param.StartTime = startTime;
          //  param.EndTime = endTime;

            //获取数据
            var url = top.$.rootUrl + '/ProjectManager/DC_ProjectInfoReport/GetProjectColumnInfo';
            learun.httpAsync("get", url, { queryJson: JSON.stringify(param) }, function (data) {

                var headData = new Array();
                if (data.length > 0) {
                    Object.keys(data[0]).forEach(function (key) {
                        headData.push({ label: key, name: key, width: 100, align: "left" })
                    });
                }

                console.log('data', data);
                console.log('headData', headData);
               
               // $('lr-layout-grid').append(' <div class="lr-layout-body" id="gridtable"></div >');
                $('#gridtable').jfGrid({
                    rowdatas: data,
                    headData: headData
                });
                //  $('#gridtable').jfGridSet('reload', { queryJson: JSON.stringify(param) });
            })


        },
        search: function (param) {
            //param = param || {};
            //param.StartTime = startTime;
            //param.EndTime = endTime;
            //$('#gridtable').jfGridSet('reload',{ queryJson: JSON.stringify(param) });
            this.initGird(param)
        }
    };
    refreshGirdData = function () {
        $('#gridtable').jfGridSet('reload');
    };
    page.init();
}
