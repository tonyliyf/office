/* * 版 本 Learun-ADMS V7.0.3 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-01-18 12:08
 * 描  述：test
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
    var isLook
    var isEdit
    var page = {
        init: function () {
            isLook = parent.location.search.indexOf('type=look') >= 0;
            isEdit = parent.location.search.indexOf('type=audit') >= 0;
            if (isLook || isEdit) {
                $('#form div input,#form div div').attr('readonly', 'readonly')
            }
            $('.lr-form-wrap').lrscroll();
            page.bind();
            page.initData();
        },
        bind: function () {
            $('#F_DocTemplate').lrDataItemSelect({ code: 'FileDeal' });
            $('#F_DenseGrade').lrDataItemSelect({ code: 'SecretLevel' });
            learun.httpAsync('GET', top.$.rootUrl + '/LR_SystemModule/CodeRule/GetEnCode', { code: '10001' }, function (data) {
                if (!$('#F_ReceiveCode').val()) {
                    $('#F_ReceiveCode').val(data);
                }
            });
            var isCreate = parent.location.search.indexOf('type=create') >= 0;
            $('#F_Attachments').DocUploader({ upLoad: isCreate, downLoad: !isCreate, extensions: 'pdf,doc,docx' });
            $('#F_DepartmentId')[0].lrvalue = learun.clientdata.get(['userinfo']).departmentId;
            learun.clientdata.getAsync('department', {
                key: learun.clientdata.get(['userinfo']).departmentId,
                callback: function (_data) {
                    $('#F_DepartmentId').val(_data.name);
                }
            });
            $('#F_CreateUserId')[0].lrvalue = learun.clientdata.get(['userinfo']).userId;
            $('#F_CreateUserId').val(learun.clientdata.get(['userinfo']).realName);
            $('#F_CreateDate').val(learun.formatDate(new Date(), 'yyyy-MM-dd hh:mm:ss'));
        },
        initData: function () {
            if (!!keyValue) {
                $.lrSetForm(top.$.rootUrl + '/LR_CodeDemo/test/GetFormData?keyValue=' + keyValue, function (data) {
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
            $.lrSetForm(top.$.rootUrl + '/LR_CodeDemo/DC_OA_ReceiveOfficialDocManager/GetFormDataByProcessId?processId=' + processId, function (data) {
                for (var id in data) {
                    if (!!data[id] && data[id].length > 0) {
                        $('#' + id).jfGridSet('refreshdata', data[id]);
                    }
                    else {
                        if (id == 'DC_OA_ReceiveOfficialDoc' && data[id]) {
                            keyValue = data[id].F_RODId;
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
            formData.F_RODId = processId;
        }
        var postData = {
            strEntity: JSON.stringify(formData)
        };
        $.lrSaveForm(top.$.rootUrl + '/LR_CodeDemo/DC_OA_ReceiveOfficialDocManager/SaveForm?keyValue=' + keyValue, postData, function (res) {
            // 保存成功后才回调
            if (!!callBack) {
                callBack(res, i);
            }
        });
    };
    page.init();
}
