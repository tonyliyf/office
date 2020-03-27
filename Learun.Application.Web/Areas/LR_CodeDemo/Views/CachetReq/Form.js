/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-04-02 16:09
 * 描  述：CachetReq
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
            $('#F_Dept').lrselect({
                type: 'tree',
                allowSearch: true,
                url: top.$.rootUrl + '/LR_OrganizationModule/Department/GetTree',
                param: {} 
            });
            $('#F_Applicant').lrselect({
                value: 'F_UserId',
                text: 'F_RealName',
                title: 'F_RealName',
                allowSearch: true
            });
            $('#F_Dept').on('change', function () {
                var value = $(this).lrselectGet();
                if (value == '')
                {
                    $('#F_Applicant').lrselectRefresh({
                        url: '',
                        data: []
                    });
                }
                else
                {
                    $('#F_Applicant').lrselectRefresh({
                        url: top.$.rootUrl + '/LR_OrganizationModule/User/GetList',
                        param: { departmentId: value }
                    });
                }
            })
            $('#F_CacheType').lrDataSourceSelect({ code: 'GetStampInfo',value: 'f_stampid',text: 'f_stampname' });
        },
        initData: function () {
            if (!!keyValue) {
                $.lrSetForm(top.$.rootUrl + '/LR_CodeDemo/CachetReq/GetFormData?keyValue=' + keyValue, function (data) {
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
        $.lrSaveForm(top.$.rootUrl + '/LR_CodeDemo/CachetReq/SaveForm?keyValue=' + keyValue, postData, function (res) {
            // 保存成功后才回调
            if (!!callBack) {
                callBack();
            }
        });
    };
    page.init();
}
