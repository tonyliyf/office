/* * 版 本 Learun-ADMS V7.0.3 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-01-12 15:16
 * 描  述：发文管理
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
            learun.httpAsync('GET', top.$.rootUrl + '/LR_SystemModule/CodeRule/GetEnCode', { code: '10002' }, function (data) {
                if (!$('#F_FileCode').val()) {
                    $('#F_FileCode').val(data);
                }
            });
            $('#F_DenseGrade').lrDataItemSelect({ code: 'SecretLevel' });
            $('#F_DenseGrade').lrselectSet("4");
            $('#F_EmergencyLevel').lrDataItemSelect({ code: 'Degree' });
            $('#F_EmergencyLevel').lrselectSet("1");
            $('#F_DraftDepartmentId').lrselect({
                type: 'tree',
                allowSearch: true,
                url: top.$.rootUrl + '/LR_OrganizationModule/Department/GetTree',
                param: {}
            });
            $('#F_DraftUserId').DocSelect({
                value: 'F_UserId',
                text: 'F_RealName',
                title: 'F_RealName',
                allowSearch: true
            });
            $('#F_DraftDepartmentId').on('change', function () {
                var value = $(this).lrselectGet();
                if (value == '') {
                    $('#F_DraftUserId').lrselectRefresh({
                        url: '',
                        data: []
                    });
                }
                else {
                    $('#F_DraftUserId').lrselectRefresh({
                        url: top.$.rootUrl + '/LR_OrganizationModule/User/GetList',
                        param: { departmentId: value }
                    });
                }
            })
            $('#F_IfCompletion').lrDataItemSelect({ code: 'YesOrNo' });
            $('#F_IfCompletion').lrselectSet("2");
            var isCreate = parent.location.search.indexOf('type=create') >= 0;
            var isEdit = parent.location.search.indexOf('type=audit') >= 0;
            $('#F_FileContent').DocUploader();
            $('#F_FileContent_New').DocUploader({ downLoad: true });
            $('#F_Attachments').DocUploader({ downLoad: true });
            //$('#LR_NWF_TaskLog').jfGrid({
            //    headData: [
            //        {
            //            label: '审核名称', name: 'F_NodeName', width: 100, align: 'left'
            //        },
            //        {
            //            label: '审核人', name: 'F_TaskUserName', width: 100, align: 'left'
            //        },
            //        {
            //            label: '审核时间', name: 'F_CreateDate', width: 120, align: 'left'
            //        },
            //        {
            //            label: '审核信息', name: 'F_Des', width: 100, align: 'left'
            //        },
            //    ],
            //    isEdit: false,
            //    height: 400
            //});
        },
        initData: function () {
            if (!!keyValue) {
                $.lrSetForm(top.$.rootUrl + '/LR_CodeDemo/DC_OA_DispatchOfficialDocManager/GetFormData?keyValue=' + keyValue, function (data) {
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
            $.lrSetForm(top.$.rootUrl + '/LR_CodeDemo/DC_OA_DispatchOfficialDocManager/GetFormDataByProcessId?processId=' + processId, function (data) {
                for (var id in data) {
                    if (!!data[id] && data[id].length > 0) {
                        $('#' + id).jfGridSet('refreshdata', data[id]);
                    }
                    else {
                        if (id == 'DC_OA_DispatchOfficialDoc' && data[id]) {
                            keyValue = data[id].F_DODId;
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
        console.log(parent.taskId)
        var postData = {};
        var formData = $('[data-table="DC_OA_DispatchOfficialDoc"]').lrGetFormData();
        if (!!processId) {
            formData.F_DODId = processId;
        }
        postData.strEntity = JSON.stringify(formData);
        //postData.strlR_NWF_TaskLogList = JSON.stringify($('#LR_NWF_TaskLog').jfGridGet('rowdatas'));
        $.lrSaveForm(top.$.rootUrl + '/LR_CodeDemo/DC_OA_DispatchOfficialDocManager/SaveForm?keyValue=' + keyValue, postData, function (res) {
            // 保存成功后才回调
            if (!!callBack) {
                callBack(res, i);
            }
        });
    };
    page.init();
}
