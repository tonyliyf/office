/* * 版 本 Learun-ADMS V7.0.0 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2018-12-31 21:17
 * 描  述：车辆信息管理
 */
var acceptClick;
var keyValue = request('fid');
var bootstrap = function ($, learun) {
    "use strict";
    var page = {
        init: function () {

            $("#lr_verifycode_img").attr("src", top.$.rootUrl + "/LR_CodeDemo/FileViewer/VerifyCode?fid="+ keyValue);
            $(".jqzoom").attr("href", top.$.rootUrl + "/LR_CodeDemo/FileViewer/VerifyCode?fid="+ keyValue);
            page.bind();
            page.initData();
        },
        bind: function () {
           
        },
        initData: function () {
            
        }
    };
    // 保存数据

    page.init();
}
