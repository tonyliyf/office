/* * 版 本 Learun-ADMS V7.0.3 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-02-19 15:47
 * 描  述：DC_OA_UseHoliday
 */
var acceptClick;
var keyValue = request('keyValue');
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
                $.lrSetForm(top.$.rootUrl + '/LR_CodeDemo/DC_OA_UseHoliday/GetFormData?keyValue=' + keyValue, function (data) {
                    for (var id in data) {
                        if (!!data[id].length && data[id].length > 0) {
                            $('#' + id).jfGridSet('refreshdata', data[id]);
                        }
                        else {
                            $('[data-table="' + id + '"]').lrSetFormData(data[id]);
                            learun.clientdata.getAsync('company', {
                                key: data[id].F_CompanyId,
                                callback: function (item) {
                                    $('#company').val(item.name);
                                }
                            });
                            learun.clientdata.getAsync('department', {
                                key: data[id].F_DepartmentId,
                                callback: function (item) {
                                    $('#department').val(item.name);
                                }
                            });
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
        var postData = {
            days: $('#F_Password').val()
        };
        $.lrSaveForm(top.$.rootUrl + '/LR_CodeDemo/DC_OA_UseHoliday/SaveForm?keyValue=' + keyValue, postData, function (res) {
            // 保存成功后才回调
            if (!!callBack) {
                callBack();
            }
        });
    };
    page.init();
}
