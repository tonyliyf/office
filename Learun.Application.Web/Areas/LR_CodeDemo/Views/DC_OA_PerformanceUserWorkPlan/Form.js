/* * 版 本 Learun-ADMS V7.0.3 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-01-25 17:08
 * 描  述：DC_OA_PerformanceUserWorkPlan
 */
var acceptClick;
var keyValue = request('keyValue');
var formData
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
                $.lrSetForm(top.$.rootUrl + '/LR_CodeDemo/DC_OA_PerformanceUserWorkPlan/GetFormData?keyValue=' + keyValue, function (data) {
                    for (var id in data) {
                        if (!!data[id].length && data[id].length > 0) {
                            $('#' + id).jfGridSet('refreshdata', data[id]);
                        }
                        else {
                            var d = data[id]
                            formData = d
                            if (d.F_IfTargetDefine == 1) {
                                $('#F_TargetName').val(d.F_TargetName)
                                $('#F_TargetContent').attr('placeholder', d.F_TargetContent)
                                $('#F_Target').attr('placeholder', d.F_Target)
                                $('#F_TargetExplain').attr('placeholder', d.F_TargetExplain)
                            } else {
                                $('[data-table="' + id + '"]').lrSetFormData(data[id]);
                            }
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
        var fd = $('body').lrGetFormData()
        if (!fd.F_TargetContent) {
            fd.F_TargetContent = formData.F_TargetContent
        }
        if (!fd.F_Target) {
            fd.F_Target = formData.F_Target
        }
        if (!fd.F_TargetExplain) {
            fd.F_TargetExplain = formData.F_TargetExplain
        }
        var postData = {
            strEntity: JSON.stringify(fd)
        };
        $.lrSaveForm(top.$.rootUrl + '/LR_CodeDemo/DC_OA_PerformanceUserWorkPlan/SaveForm?keyValue=' + keyValue, postData, function (res) {
            // 保存成功后才回调
            if (!!callBack) {
                callBack();
            }
        });
    };
    page.init();
}
