/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-02-13 11:36
 * 描  述：DC_ASSETS_LandBaseInfo
 */
var acceptClick;
var keyValue = request('keyValue');
var F_BoundaryCoordinates = "[]"
var F_CenterpointCoordinates = "[]"
var bootstrap = function ($, learun) {
    "use strict";
    var page = {
        init: function () {
            page.bind();
          },
        bind: function () {
            $('#F_Contract').lrUploader();
          
        }
      
    };
    // 保存数据
    acceptClick = function (callBack) {
        if (!$('body').lrValidform()) {
            return false;
        }
      // debugger;
        var keyValue = $('#F_Contract').lrUploaderGet();
        $.lrSaveForm(top.$.rootUrl + '/AssetManager/DC_ASSETS_HouseRentMain/Import?keyValue='+ keyValue, function (res) {
            // 保存成功后才回调
            if (!!callBack) {
                callBack();
            }
        });
    };
    page.init();
}
