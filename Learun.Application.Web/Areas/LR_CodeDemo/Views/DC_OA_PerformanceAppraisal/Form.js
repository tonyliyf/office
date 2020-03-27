/* * 版 本 Learun-ADMS V7.0.3 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-01-24 09:40
 * 描  述：DC_OA_PerformanceAppraisal
 */
var acceptClick;
var keyValue = request('keyValue')
var tid = request('tid')
var bootstrap = function ($, learun) {
    "use strict";
    var page = {
        init: function () {
            $('.lr-form-wrap').lrscroll();
            page.bind();
            page.initData();
        },
        bind: function () {
            $('#F_IfTargetDefine').lrDataItemSelect({
                code: 'YesOrNo', select: function (item) {
                    //if (item) {
                    //    if (item.id == "1") {
                    //        $('#F_TargetContent,#F_Target,#F_TargetExplain').val('').attr('disabled', 'disabled')
                    //    } else {
                    //        $('#F_TargetContent,#F_Target,#F_TargetExplain').removeAttr('disabled')
                    //    }
                    //}
                }
            });


            var dfop = {
                // 是否允许搜索
                allowSearch: true
            }
            var $select = $('#F_ParentId').lrselect(dfop);
            $.get(top.$.rootUrl + '/LR_CodeDemo/DC_OA_PerformanceAppraisal/GetSelect?tid=' + tid, function (res) {
                if (res.code == 200) {
                    $select.lrselectRefresh({
                        value: 'F_PAId',
                        text: 'F_TargetName',
                        title: 'F_TargetName',
                        data: res.data
                    });
                } else {
                    learun.alert.error(res.info)
                }
            }, 'json')
        },
        initData: function () {
            if (!!keyValue) {
                $.lrSetForm(top.$.rootUrl + '/LR_CodeDemo/DC_OA_PerformanceAppraisal/GetFormData?keyValue=' + keyValue, function (data) {
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
        var fdata = $('body').lrGetFormData()
        fdata.F_PATId = tid
        var postData = {
            strEntity: JSON.stringify(fdata)
        };

        $.lrSaveForm(top.$.rootUrl + '/LR_CodeDemo/DC_OA_PerformanceAppraisal/SaveForm?keyValue=' + keyValue, postData, function (res) {
            // 保存成功后才回调
            if (!!callBack) {
                callBack();
            }
        });
    };
    page.init();
}
