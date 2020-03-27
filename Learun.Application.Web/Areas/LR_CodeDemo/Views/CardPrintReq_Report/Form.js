/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-03-15 11:59
 * 描  述：用章报表
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
            $('#F_Dept')[0].lrvalue = learun.clientdata.get(['userinfo']).departmentId;
            learun.clientdata.getAsync('department', {
                key: learun.clientdata.get(['userinfo']).departmentId,
                callback: function (_data) {
                    $('#F_Dept').val(_data.name);
                }
            });
            $('#F_Applicant')[0].lrvalue = learun.clientdata.get(['userinfo']).userId;
            $('#F_Applicant').val(learun.clientdata.get(['userinfo']).realName);
            $('#F_CacheType').lrDataSourceSelect({ code: 'GetStampInfo',value: 'f_stampname',text: 'f_stampname' });
        },
        initData: function () {
            if (!!keyValue) {
                $.lrSetForm(top.$.rootUrl + '/LR_CodeDemo/CardPrintReq_Report/GetFormData?keyValue=' + keyValue, function (data) {
                    for (var id in data) {
                        if (!!data[id].length && data[id].length > 0) {
                            $('#' + id ).jfGridSet('refreshdata', data[id]);
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
        var postData = {
            strEntity: JSON.stringify($('body').lrGetFormData())
        };
        $.lrSaveForm(top.$.rootUrl + '/LR_CodeDemo/CardPrintReq_Report/SaveForm?keyValue=' + keyValue, postData, function (res) {
            // 保存成功后才回调
            if (!!callBack) {
                callBack();
            }
        });
    };
    page.init();
}
