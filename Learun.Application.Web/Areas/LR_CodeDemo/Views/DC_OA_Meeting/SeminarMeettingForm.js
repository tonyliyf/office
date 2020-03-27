/* * 版 本 Learun-ADMS V7.0.3 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-02-27 15:58
 * 描  述：DC_OA_Meeting
 */
var acceptClick;
var keyValue = request('keyValue');
// 设置权限
var setAuthorize;
// 设置表单数据
var setFormData;
// 验证数据是否填写完整
var validForm;
// 保存数据
var save;
var bootstrap = function ($, learun) {
    "use strict";
    // 设置权限
    setAuthorize = function (data) {
    };
    var page = {
        init: function () {
            $('.lr-form-wrap').lrscroll();
            page.bind();
            page.initData();
        },
        bind: function () {
            $('#DC_OA_MeetingManageId').lrformselect({
                layerUrl: top.$.rootUrl + '/LR_OrganizationModule/User/SelectOnlyForm',
                layerUrlW: 400,
                layerUrlH: 300,
                dataUrl: top.$.rootUrl + '/LR_OrganizationModule/User/GetListByUserIds'
            });
            $('#DC_OA_MeetingRoomRefId').lrDataSourceSelect({ code: 'OA_MeettingRoom', value: 'dc_oa_meetingroomid', text: 'dc_oa_meetingroomname' });
            $('#F_Files').lrUploader();
            $('#DC_OA_MeetingIds').lrformselect({
                layerUrl: top.$.rootUrl + '/LR_OrganizationModule/User/SelectForm',
                layerUrlW: 800,
                layerUrlH: 520,
                dataUrl: top.$.rootUrl + '/LR_OrganizationModule/User/GetListByUserIds'
            });
            $('#F_SubjectSumId').lrDataSourceSelect({
                code: 'SeminarMeettingSubList',
                value: 'id',
                text: 'name',
                select: function (rowData) {
                    if (rowData) { 
                        $.get(top.$.rootUrl + '/LR_CodeDemo/DC_OA_MeetingSubjectSum/GetFormData?keyValue=' + rowData.id, function (res) {
                            if (res.code == 200) {
                                $('#DC_OA_MeetingSubject').jfGridSet('refreshdata', res.data.DC_OA_MeetingSubject);
                            } else {
                                learun.alert.error(res.info)
                            }
                        }, 'json')
                    }
                }
            });
            $('#DC_OA_MeetingSubject').jfGrid({
                headData: [
                    { label: "汇报单位", name: "F_ReportCompany", width: 100, align: "center" },
                    { label: "议题", name: "F_Content", width: 500, align: "center" },
                    { label: "列席单位", name: "F_AttendCompany", width: 100, align: "center" },
                    { label: "预计时长", name: "F_MeetingDuring", width: 100, align: "center" },
                    { label: "开始时间", name: "F_StartTime", width: 100, align: "center" }
                ],
                isEdit: false,
                height: 400
            });
        },
        initData: function () {
            if (!!keyValue) {
                $.lrSetForm(top.$.rootUrl + '/LR_CodeDemo/DC_OA_Meeting/GetFormData?keyValue=' + keyValue, function (data) {
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
    // 设置表单数据
    setFormData = function (processId) {
        if (!!processId) {
            $.lrSetForm(top.$.rootUrl + '/LR_CodeDemo/DC_OA_Meeting/GetFormDataByProcessIdEx?processId=' + processId, function (data) {
                for (var id in data) {
                    if (!!data[id] && data[id].length > 0) {
                        $('#' + id).jfGridSet('refreshdata', data[id]);
                    }
                    else {
                        if (id == 'DC_OA_Meeting' && data[id]) {
                            keyValue = data[id].DC_OA_MeetingId;
                        }
                        $('[data-table="' + id + '"]').lrSetFormData(data[id]);
                    }
                }
            });
        }
    }
    // 验证数据是否填写完整
    validForm = function () {
        if (!$('body').lrValidform()) {
            return false;
        }
        return true;
    };
    // 保存数据
    save = function (processId, callBack, i) {
        var formData = $('body').lrGetFormData();
        if (!!processId) {
            formData.DC_OA_MeetingId = processId;
        }
        formData.F_MeetingType = '2'
        var postData = {
            strEntity: JSON.stringify(formData)
        };
        $.lrSaveForm(top.$.rootUrl + '/LR_CodeDemo/DC_OA_Meeting/SaveForm?keyValue=' + keyValue, postData, function (res) {
            // 保存成功后才回调
            if (!!callBack) {
                callBack(res, i);
            }
        });
    };
    page.init();
}
