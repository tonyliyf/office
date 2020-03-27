/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-03-20 12:20
 * 描  述：DC_EngineProject_ProjectTasksProgress
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
            $('#F_MeasurementUnit').lrDataItemSelect({ code: 'ProjectMeasurementUnit' });
            $('#F_Attachments').lrUploader();
            $('#F_ProjectStage').lrselect({
                type: 'tree',
                allowSearch: true,
                url: top.$.rootUrl + '/ProjectManager/DC_EngineProject_ProjectInfoApprovalData/GetTree',
                param: {}
            });
            $('#F_ProgressState').lrDataItemSelect({ code: 'ProgressState' });
        },
        initData: function () {
            if (!!keyValue) {
                $.lrSetForm(top.$.rootUrl + '/ProjectManager/DC_EngineProject_ProjectTasksProgress/GetFormData?keyValue=' + keyValue, function (data) {
                    for (var id in data) {
                        if (!!data[id].length && data[id].length > 0) {
                            $('#' + id).jfGridSet('refreshdata', data[id]);
                        }
                        else {
                            if (data[id].F_ActualStartDate && data[id].F_ActualStartDate.length > 10) {
                                data[id].F_ActualStartDate = data[id].F_ActualStartDate.substr(0, 10)
                            }
                            if (data[id].F_ActualEndDate && data[id].F_ActualEndDate.length > 10) {
                                data[id].F_ActualEndDate = data[id].F_ActualEndDate.substr(0, 10)
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
        var formdata = $('body').lrGetFormData()
        formdata.F_PTId = TID
        var postData = {
            strEntity: JSON.stringify(formdata)
        };
        $.lrSaveForm(top.$.rootUrl + '/ProjectManager/DC_EngineProject_ProjectTasksProgress/SaveForm?keyValue=' + keyValue, postData, function (res) {
            // 保存成功后才回调
            if (!!callBack) {
                callBack();
            }
        });
    };
    page.init();
}
