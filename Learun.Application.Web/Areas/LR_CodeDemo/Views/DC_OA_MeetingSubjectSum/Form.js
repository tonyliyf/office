/* * 版 本 Learun-ADMS V7.0.3 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-02-27 14:02
 * 描  述：DC_OA_MeetingSubjectSum
 */
var acceptClick;
var keyValue = request('keyValue');
var setFormData;
// 验证数据是否填写完整
var validForm;
// 保存数据
var save;
var bootstrap = function ($, learun) {
    "use strict";
    var page = {
        init: function () {
            $('.lr-form-wrap').lrscroll();
            page.bind();
            page.initData();
        },
        bind: function () {
            $('#DC_OA_MeetingSubject').jfGrid({
                headData: [
                    { label: "汇报单位", name: "F_ReportCompany", width: 100, align: "center", edit: { type: 'input' } },
                    { label: "议题", name: "F_Content", width: 500, align: "center" },
                    { label: "列席单位", name: "F_AttendCompany", width: 300, align: "center", edit: { type: 'input' } },
                    { label: "预计时长(分钟)", name: "F_MeetingDuring", width: 100, align: "center", edit: { type: 'input' } },
                    { label: "开始时间", name: "F_StartTime", width: 100, align: "center", edit: { type: 'input' } }
                ],
                isEdit: true,
                height: 400
            });
            $('#F_Files').lrUploader();
        },
        initData: function () {

        }
    };
    setFormData = function (processId) {
        if (parent.location.search.indexOf('type=create') >= 0) {
            $.get(top.$.rootUrl + '/LR_CodeDemo/DC_OA_MeetingSubjectSum/GetInitData', function (res) {
                if (res.code == 200) {
                    $('#DC_OA_MeetingSubject').jfGridSet('refreshdata', res.data);
                } else {
                    learun.alert.error(res.info)
                }
            }, 'json')
        }
        if (!!processId) {
            $.lrSetForm(top.$.rootUrl + '/LR_CodeDemo/DC_OA_MeetingSubjectSum/GetFormData?keyValue=' + processId, function (data) {
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
    validForm = function () {
        if (!$('body').lrValidform()) {
            return false;
        }
        return true;
    };
    save = function (processId, callBack, i) {
        var postData = {};
        var formData = $('[data-table="DC_OA_MeetingSubjectSum"]').lrGetFormData();
        if (!!processId) {
            formData.F_SubjectSumId = processId;
        }
        postData.strEntity = JSON.stringify(formData);
        postData.strdC_OA_MeetingSubjectList = JSON.stringify($('#DC_OA_MeetingSubject').jfGridGet('rowdatas'));
        $.lrSaveForm(top.$.rootUrl + '/LR_CodeDemo/DC_OA_MeetingSubjectSum/SaveForm?keyValue=' + keyValue, postData, function (res) {
            if (!!callBack) {
                callBack(res, i);
            }
        });
    };
    page.init();
}
