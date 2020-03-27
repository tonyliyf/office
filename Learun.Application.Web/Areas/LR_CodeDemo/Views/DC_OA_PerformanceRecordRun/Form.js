/* * 版 本 Learun-ADMS V7.0.3 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-01-24 17:30
 * 描  述：DC_OA_PerformanceRecordRun
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
            $('#F_PATId').lrDataSourceSelect({ code: 'PerformanceAppraisalTemplate', value: 'f_patid', text: 'f_templatename' });
            $('#F_AppraisalCycleType').lrDataItemSelect({ code: 'Appraisal' });
            $('#F_IfRemind').lrDataItemSelect({ code: 'YesOrNo' });
            $('#F_IfRemind').lrselectSet("1");
            $('#F_PRRDepartmentId')[0].lrvalue = learun.clientdata.get(['userinfo']).departmentId;
            learun.clientdata.getAsync('department', {
                key: learun.clientdata.get(['userinfo']).departmentId,
                callback: function (_data) {
                    $('#F_PRRDepartmentId').val(_data.name);
                }
            });
            $('#F_PRRUserId')[0].lrvalue = learun.clientdata.get(['userinfo']).userId;
            $('#F_PRRUserId').val(learun.clientdata.get(['userinfo']).realName);
            $('#F_PRRCreateDate').val(learun.formatDate(new Date(), 'yyyy-MM-dd hh:mm:ss'));
            $('#F_IfSelfJudge').lrDataItemSelect({
                code: 'YesOrNo', select: function (item) {
                    if (item) {
                        if (item.id == "1") {
                            //$('#F_TargetContent,#F_Target,#F_TargetExplain').val('').attr('disabled', 'disabled')
                            $('#div_SelfWeight').show()
                        } else {
                            $('#div_SelfWeight').hide()
                            $('#F_SelfWeight').val('0')
                        }
                    }
                }
            });
        },
        initData: function () {
            if (!!keyValue) {
                $.lrSetForm(top.$.rootUrl + '/LR_CodeDemo/DC_OA_PerformanceRecordRun/GetFormData?keyValue=' + keyValue, function (data) {
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
        $.lrSaveForm(top.$.rootUrl + '/LR_CodeDemo/DC_OA_PerformanceRecordRun/SaveForm?keyValue=' + keyValue, postData, function (res) {
            // 保存成功后才回调
            if (!!callBack) {
                callBack();
            }
        });
    };
    page.init();
}
