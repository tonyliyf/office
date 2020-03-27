/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-03-20 18:24
 * 描  述：DC_EngineProject_ProjectExaminationSupervise
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
            $('#F_PIId').lrDataSourceSelect({ code: 'DC_EngineProject_ProjectInfo',value: 'f_piid',text: 'f_projectname' });
            $('#F_InspectionSupervisionType').lrDataItemSelect({ code: 'InspectionSupervision' });
            learun.httpAsync('GET', top.$.rootUrl + '/LR_SystemModule/CodeRule/GetEnCode', { code: '10001' }, function (data) {
                if (!$('#F_PESCode').val()) {
                    $('#F_PESCode').val(data);
                }
            });
            $('#F_ExaminationDepartment').lrselect({
                type: 'tree',
                allowSearch: true,
                url: top.$.rootUrl + '/LR_OrganizationModule/Department/GetTree',
                param: {} 
            });
            $('#F_ExaminationUser').lrformselect({
                layerUrl: top.$.rootUrl + '/LR_OrganizationModule/User/SelectOnlyForm',
                layerUrlW: 400,
                layerUrlH: 300,
                dataUrl: top.$.rootUrl + '/LR_OrganizationModule/User/GetListByUserIds'
            });
            $('#F_ScenePictures').lrUploader();
            $('#F_Attachment').lrUploader();
            $('#F_IfCorrective').lrDataItemSelect({ code: 'YesOrNo' });
            $('#F_SupervisionStatus').lrDataItemSelect({ code: 'SupervisionStatus' });
        },
        initData: function () {
            if (!!keyValue) {
                $.lrSetForm(top.$.rootUrl + '/ProjectManager/DC_EngineProject_ProjectExaminationSupervise/GetFormData?keyValue=' + keyValue, function (data) {
                    for (var id in data) {
                        if (!!data[id].length && data[id].length > 0) {
                            $('#' + id ).jfGridSet('refreshdata', data[id]);
                        }
                        else {
                            
                            if (data[id].F_DesignateDate && data[id].F_DesignateDate.length > 10) {
                                data[id].F_DesignateDate = data[id].F_DesignateDate.substr(0, 10)
                            }
                            if (data[id].F_EaminationDate && data[id].F_EaminationDate.length > 10) {
                                data[id].F_EaminationDate = data[id].F_EaminationDate.substr(0, 10)
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
        $.lrSaveForm(top.$.rootUrl + '/ProjectManager/DC_EngineProject_ProjectExaminationSupervise/SaveForm?keyValue=' + keyValue, postData, function (res) {
            // 保存成功后才回调
            if (!!callBack) {
                callBack();
            }
        });
    };
    page.init();
}
