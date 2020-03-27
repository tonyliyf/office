/* * 版 本 Learun-ADMS V7.0.3 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2018-11-15
 * 描  述：密码验证
 */
var strRoot = window.location.protocol + "//" + window.location.host
var acceptClick;
var keyValue = request('keyValue');
var bootstrap = function ($, learun) {
    "use strict";
    var page = {
        init: function () {
            page.bind();
        },
        bind: function () {

        }
    };
    // 保存数据
    acceptClick = function (callBack) {
        if (!$('#form').lrValidform()) {
            return false;
        }
        var postData = $('#form').lrGetFormData();
        var F_Password = $.md5(postData.F_Password);
        $.post(strRoot + '/LR_CodeDemo/WebOffice/EqualForm', { keyValue: keyValue, Password: F_Password }, function (res) {
            if (res.code == 200) {
                // 正确之后才回调
                if (!!callBack) {
                    callBack();
                }
            } else {
                alert('密码不正确')
            }
            learun.layerClose(window.name)
        }, 'json');
    };
    page.init();
}
