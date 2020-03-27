﻿/* * 版 本 Learun-ADMS V7.0.3 敏捷开发框架(http://www.learun.cn) 
 * Copyright (c) 2013-2018 信息技术有限公司 
 * 创建人：超级管理员 
 * 日  期：2019-02-28 18:15 
 * 描  述：fsdf 
 */
var acceptClick;
var keyValue = request('keyValue');
var TID = request('TID')
var bootstrap = function ($, learun) {
    "use strict";
    var page = {
        init: function () {
            $('.lr-form-wrap').lrscroll();
            page.bind();
            page.initData();
        },
        bind: function () {
        },
        initData: function () {
            if (!!keyValue) {
                $.lrSetForm(top.$.rootUrl + '/LR_CodeDemo/DC_OA_OverSeeWorkTaskExecute/GetFormDataEx?keyValue=' + keyValue, function (data) {
                    for (var id in data) {
                        if (!!data[id].length && data[id].length > 0) {
                            $('#' + id).jfGridSet('refreshdata', data[id]);
                        }
                        else {
                            $('[data-table="' + id + '"]').lrSetFormData(data[id]);
                        }
                    }
                });
            }
        }
    };
    // 保存数据 
    acceptClick = function (callBack) {
        if (!$('body').lrValidform()) {
            return false;
        }
        var data = $('body').lrGetFormData()
        data.F_SecondId = TID
        var postData = {
            strEntity: JSON.stringify(data)
        };
        $.lrSaveForm(top.$.rootUrl + '/LR_CodeDemo/DC_OA_OverSeeWorkTaskExecute/SaveFormEx?keyValue=' + keyValue, postData, function (res) {
            // 保存成功后才回调 
            if (!!callBack) {
                callBack();
            }
        });
    };
    page.init();
} 