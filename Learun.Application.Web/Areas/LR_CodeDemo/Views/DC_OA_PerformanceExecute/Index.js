/* * 版 本 Learun-ADMS V7.0.3 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-01-26 12:10
 * 描  述：DC_OA_PerformanceExecute
 */
var refreshGirdData;
var bootstrap = function ($, learun) {
    "use strict";
    var page = {
        init: function () {
            page.initGird();
            page.bind();
        },
        bind: function () {
            $('#lr_form_tabs').lrFormTab();
            $('#lr_form_tabs ul li').eq(0).trigger('click');

        },
        // 初始化列表
        initGird: function () {

        },
        search: function () {

        }
    };
    refreshGirdData = function () {

    };
    page.init();
}
