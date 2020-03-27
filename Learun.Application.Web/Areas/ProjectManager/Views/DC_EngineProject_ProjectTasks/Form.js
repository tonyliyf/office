/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-03-19 14:16
 * 描  述：DC_EngineProject_ProjectTasks
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
            $('#F_TaskState').lrDataItemSelect({ code: 'EProTaskState' });
            $('#F_IfMilestone').lrDataItemSelect({ code: 'YesOrNo' });
            $('#F_ProjectStage').lrselect({
                type: 'tree',
                allowSearch: true,
            
                url: top.$.rootUrl + '/ProjectManager/DC_EngineProject_ProjectInfoApprovalData/GetTree',
                param: {}
            });
            $('#F_TaskDepartment').lrselect({
                type: 'tree',
                allowSearch: true,
                url: top.$.rootUrl + '/LR_OrganizationModule/Department/GetTree',
                param: {}
            });
            $('#F_TaskLeader').lrformselect({
                layerUrl: top.$.rootUrl + '/LR_OrganizationModule/User/SelectOnlyForm',
                layerUrlW: 400,
                layerUrlH: 300,
                dataUrl: top.$.rootUrl + '/LR_OrganizationModule/User/GetListByUserIds'
            });
            $('#F_Attachments').lrUploader();
        },
        initData: function () {
            if (!!keyValue) {
                $.lrSetForm(top.$.rootUrl + '/ProjectManager/DC_EngineProject_ProjectTasks/GetFormData?keyValue=' + keyValue, function (data) {
                    for (var id in data) {
                        if (!!data[id].length && data[id].length > 0) {
                            $('#' + id).jfGridSet('refreshdata', data[id]);
                        }
                        else {
                            if (data[id].F_PlannedStartDate && data[id].F_PlannedStartDate.length > 10) {
                                data[id].F_PlannedStartDate = data[id].F_PlannedStartDate.substr(0, 10)
                            }
                            if (data[id].F_PlannedEndDate && data[id].F_PlannedEndDate.length > 10) {
                                data[id].F_PlannedEndDate = data[id].F_PlannedEndDate.substr(0, 10)
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
        var formdata = $('body').lrGetFormData();
        formdata.F_PIId = TID
        var postData = {
            strEntity: JSON.stringify(formdata)
        };
        $.lrSaveForm(top.$.rootUrl + '/ProjectManager/DC_EngineProject_ProjectTasks/SaveForm?keyValue=' + keyValue, postData, function (res) {
            // 保存成功后才回调
            if (!!callBack) {
                callBack();
            }
        });
    };
    page.init();
}
