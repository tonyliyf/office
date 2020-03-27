/* * 版 本 Learun-ADMS V7.0.3 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-01-25 17:08
 * 描  述：DC_OA_PerformanceUserWorkPlan
 */
var acceptClick
var refreshGirdData;
var keyValue = request('keyValue')
var bootstrap = function ($, learun) {
    "use strict";
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
        },
        // 初始化列表
        initGird: function () {
            $.get(top.$.rootUrl + '/LR_CodeDemo/DC_OA_PerformanceExecute/GetHeadData?wid=' + keyValue, function (res) {
                if (res.code == 200) {
                    for (var key in res.data) {
                        $('#' + key).val(res.data[key])
                    }
                } else {
                    learun.alert.error(res.info)
                }
            }, 'json')
            $.get(top.$.rootUrl + '/LR_CodeDemo/DC_OA_PerformanceExecute/GetColumes?wid=' + keyValue, function (res) {
                if (res.code == 200) {
                    $('#gridtable').jfGrid({
                        url: top.$.rootUrl + '/LR_CodeDemo/DC_OA_PerformanceExecute/GetRows',
                        headData: res.data,
                        mainId: 'F_PUWPId',
                        isTree: true,
                        parentId: 'F_ParentId'
                    });
                    page.search();
                } else {
                    learun.alert.error(res.info)
                }
            }, 'json')

        },
        search: function (param) {
            param = param || {};
            $('#gridtable').jfGridSet('reload', { wid: keyValue });
        }
    };
    refreshGirdData = function () {
        page.search()
    };
    acceptClick = function () {
        learun.layerClose(window.name)
    }
    page.init();
}
