/* * 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力软信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-04-17 11:09
 * 描  述：DC_OA_MeetingRecord
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
            learun.httpAsync('GET', top.$.rootUrl + '/LR_SystemModule/CodeRule/GetEnCode', { code: 'MeetingRecordNum' }, function (data) {
                if (!$('#F_MRNum').val()) {
                    $('#F_MRNum').val(data);
                }
            });
            $('#F_MRType').lrDataItemSelect({ code: 'ConventionNum' });
            $('#F_ConveningDepartment').lrselect({
                type: 'tree',
                allowSearch: true,
                url: top.$.rootUrl + '/LR_OrganizationModule/Department/GetTree',
                param: {} 
            });
            $('#F_Convenor').lrselect({
                value: 'F_UserId',
                text: 'F_RealName',
                title: 'F_RealName',
                allowSearch: true
            });
            $('#F_ConveningDepartment').on('change', function () {
                var value = $(this).lrselectGet();
                if (value == '')
                {
                    $('#F_Convenor').lrselectRefresh({
                        url: '',
                        data: []
                    });
                }
                else
                {
                    $('#F_Convenor').lrselectRefresh({
                        url: top.$.rootUrl + '/LR_OrganizationModule/User/GetList',
                        param: { departmentId: value }
                    });
                }
            })
            $('#F_MNId').lrDataSourceSelect({
                code: 'DeptNotice_title', value: 'f_id', text: 'f_title', select: function (ret) {
                    var key = ret.f_id;
                    if (!!key) {
                        $.lrSetForm(top.$.rootUrl + '/LR_CodeDemo/DC_OA_MeetingRecord/GetDeptNoticeEntity?keyValue=' + key, function (data) {
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
            });
            $('#F_Attachments').lrUploader();
         
            $('#F_CreateUserid')[0].lrvalue = learun.clientdata.get(['userinfo']).userId;
            $('#F_CreateUserid').val(learun.clientdata.get(['userinfo']).realName);
            $('#F_CreateDatetime').val(learun.formatDate(new Date(), 'yyyy-MM-dd hh:mm:ss'));

            $('#F_CreateDepartmentId')[0].lrvalue = learun.clientdata.get(['userinfo']).departmentId;
            learun.clientdata.getAsync('department', {
                key: learun.clientdata.get(['userinfo']).departmentId,
                callback: function (_data) {
                    $('#F_CreateDepartmentId').val(_data.name);
                }
            });
            $("#F_CreateDepartmentId1").hide();
            $("#F_CreateUserid1").hide();
            $("#F_CreateDatetime1").hide();
        },
        initData: function () {
            if (!!keyValue) {
                $.lrSetForm(top.$.rootUrl + '/LR_CodeDemo/DC_OA_MeetingRecord/GetFormData?keyValue=' + keyValue, function (data) {
                    for (var id in data) {
                        if (!!data[id].length && data[id].length > 0) {
                            $('#' + id ).jfGridSet('refreshdata', data[id]);
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
        $.lrSaveForm(top.$.rootUrl + '/LR_CodeDemo/DC_OA_MeetingRecord/SaveForm?keyValue=' + keyValue, postData, function (res) {
            // 保存成功后才回调
            if (!!callBack) {
                callBack();
            }
        });
    };
    page.init();
}
