/* * 版 本 Learun-ADMS V7.0.3 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-01-24 09:28
 * 描  述：DC_OA_PerformanceAppraisalTemplate
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
            learun.httpAsync('GET', top.$.rootUrl + '/LR_SystemModule/CodeRule/GetEnCode', { code: 'PerformanceAppraisalCode' }, function (data) {
                if (!$('#F_TemplateCode').val()) {
                    $('#F_TemplateCode').val(data);
                }
            });
            $('#F_AppraisalCycleType').lrDataItemSelect({ code: 'Appraisal' });
            $('#F_PATDepartmentId')[0].lrvalue = learun.clientdata.get(['userinfo']).userId;
            $('#F_PATDepartmentId').val(learun.clientdata.get(['userinfo']).realName);
            $('#F_PATCreateDate').val(learun.formatDate(new Date(), 'yyyy-MM-dd hh:mm:ss'));
            $('#F_PATUserId')[0].lrvalue = learun.clientdata.get(['userinfo']).userId;
            $('#F_PATUserId').val(learun.clientdata.get(['userinfo']).realName);
        },
        initData: function () {
            if (!!keyValue) {
                $.lrSetForm(top.$.rootUrl + '/LR_CodeDemo/DC_OA_PerformanceAppraisalTemplate/GetFormData?keyValue=' + keyValue, function (data) {
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
        var postData = {
            strEntity: JSON.stringify($('body').lrGetFormData())
        };
        $.lrSaveForm(top.$.rootUrl + '/LR_CodeDemo/DC_OA_PerformanceAppraisalTemplate/SaveForm?keyValue=' + keyValue, postData, function (res) {
            // 保存成功后才回调
            if (!!callBack) {
                callBack();
            }
        });
    };
    page.init();
}
