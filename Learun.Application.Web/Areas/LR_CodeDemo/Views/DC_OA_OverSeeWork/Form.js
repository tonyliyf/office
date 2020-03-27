/* * 版 本 Learun-ADMS V7.0.0 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-01-07 11:19
 * 描  述：DC_OA_OverSeeWork
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
            learun.httpAsync('GET', top.$.rootUrl + '/LR_SystemModule/CodeRule/GetEnCode', { code: '10000' }, function (data) {
                if (!$('#F_OSWCode').val()) {
                    $('#F_OSWCode').val(data);
                }
            });
            $('#F_Attachments').lrUploader();
            $('#F_DepartmentId').lrselect({
                type: 'tree',
                allowSearch: true,
                url: top.$.rootUrl + '/LR_OrganizationModule/Department/GetTree',
                param: {}
            });
            $('#F_LeaderUserId').lrformselect({
                layerUrl: top.$.rootUrl + '/LR_OrganizationModule/User/SelectForm',
                layerUrlW: 800,
                layerUrlH: 520,
                dataUrl: top.$.rootUrl + '/LR_OrganizationModule/User/GetListByUserIds'
            });
            //$('#F_DepartmentId').on('change', function () {
            //    var value = $(this).lrselectGet();
            //    if (value == '') {
            //        $('#F_LeaderUserId').lrselectRefresh({
            //            url: '',
            //            data: []
            //        });
            //    }
            //    else {
            //        $('#F_LeaderUserId').lrselectRefresh({
            //            url: top.$.rootUrl + '/LR_OrganizationModule/User/GetList',
            //            param: { departmentId: value }
            //        });
            //    }
            //})
            $('#F_OverSeeUserId').lrformselect({
                layerUrl: top.$.rootUrl + '/LR_OrganizationModule/User/SelectOnlyForm',
                layerUrlW: 400,
                layerUrlH: 300,
                dataUrl: top.$.rootUrl + '/LR_OrganizationModule/User/GetListByUserIds'
            });
            $('#F_HighLeaderId').lrformselect({
                layerUrl: top.$.rootUrl + '/LR_OrganizationModule/User/SelectOnlyForm',
                layerUrlW: 400,
                layerUrlH: 300,
                dataUrl: top.$.rootUrl + '/LR_OrganizationModule/User/GetListByUserIds'
            });


            $('#F_VisitFrom').lrDataItemSelect({ code: 'VisitFrom' }).lrselectSet(0);

            $('#F_OSWType').lrDataItemSelect({ code: 'OverSeeType' });
        },
        initData: function () {
            if (!!keyValue) {
                $.lrSetForm(top.$.rootUrl + '/LR_CodeDemo/DC_OA_OverSeeWork/GetFormData?keyValue=' + keyValue, function (data) {
                    for (var id in data) {
                        if (!!data[id].length && data[id].length > 0) {
                            $('#' + id).jfGridSet('refreshdata', data[id]);
                        }
                        else {
                            if (data[id].F_BeginDate && data[id].F_BeginDate.length > 10) {
                                data[id].F_BeginDate = data[id].F_BeginDate.substr(0, 10)
                            }
                            if (data[id].F_EndDate && data[id].F_EndDate.length > 10) {
                                data[id].F_EndDate = data[id].F_EndDate.substr(0, 10)
                            }
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
        $.lrSaveForm(top.$.rootUrl + '/LR_CodeDemo/DC_OA_OverSeeWork/SaveForm?keyValue=' + keyValue, postData, function (res) {
            // 保存成功后才回调
            if (!!callBack) {
                callBack();
            }
        });
    };
    page.init();
}
