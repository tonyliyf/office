/* * 版 本 Learun-ADMS V7.0.3 敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 信息技术有限公司
 * 创建人：超级管理员
 * 日  期：2019-02-19 12:12
 * 描  述：LeaveReq_Edit
 */
var acceptClick;
var keyValue = request('keyValue');
var YHRestDays
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
            $.get(top.$.rootUrl + '/LR_CodeDemo/DC_OA_UseHoliday/GetRestYHoliday', function (res) {
                YHRestDays = res.data.result
                $('#txt_rest').val(res.data.result)
            }, 'json')
            $('#F_UserId')[0].lrvalue = learun.clientdata.get(['userinfo']).userId;
            $('#F_UserId').val(learun.clientdata.get(['userinfo']).realName);
            $('#F_CompanyId')[0].lrvalue = learun.clientdata.get(['userinfo']).companyId;
            learun.clientdata.getAsync('company', {
                key: learun.clientdata.get(['userinfo']).companyId,
                callback: function (_data) {
                    $('#F_CompanyId').val(_data.name);
                }
            });
            $('#F_Dept')[0].lrvalue = learun.clientdata.get(['userinfo']).userId;
            $('#F_Dept').val(learun.clientdata.get(['userinfo']).realName);
            $('#F_ApplyDate').val(learun.formatDate(new Date(), 'yyyy-MM-dd hh:mm:ss'));
            $('#F_Degree').lrDataItemSelect({ code: 'Degree' });
            $('#F_LeaveType').lrDataItemSelect({
                code: 'LeaveType', select: function (rowData) {
                    if (rowData && rowData.id == '4') {
                        $('#div_rest').show()
                    } else {
                        $('#div_rest').hide()
                    }
                }
            });
            $('#F_Files').lrUploader();
            $('#select1').lrDataItemSelect({ code: 'AmPm', select: page.calcTime });
            $('#select2').lrDataItemSelect({ code: 'AmPm', select: page.calcTime });
            $('#F_StartDate,#F_EndDate').change(page.calcTime)
            $.get(top.$.rootUrl + '/LR_OrganizationModule/Post/GetEntityNameByUserId', function (data) {
                $('#F_PostId').val(data.data)
            }, 'json')
        },
        initData: function () {
            if (!!keyValue) {
                $.lrSetForm(top.$.rootUrl + '/LR_CodeDemo/LeaveReq_Edit/GetFormData?keyValue=' + keyValue, function (data) {
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
        },
        calcTime() {
            var beginTime = $('#F_StartDate').val()
            if (!beginTime) {
                return
            }
            var endTime = $('#F_EndDate').val()
            if (!endTime) {
                return
            }
            var select1 = $('#select1').lrselectGet()
            if (!select1) {
                return
            }
            var select2 = $('#select2').lrselectGet()
            if (!select2) {
                return
            }

            var date1 = new Date(beginTime)
            var date2 = new Date(endTime)
            var days = Math.floor((date2.getTime() - date1.getTime()) / (24 * 3600 * 1000))
            if (select1 == 2) {
                days -= 0.5
            }
            if (select2 == 2) {
                days += 0.5
            }

            days +=0.5

            $('#F_LeaveDays').val(days)
        }
    };
    // 设置表单数据
    setFormData = function (processId) {
        if (!!processId) {
            $.lrSetForm(top.$.rootUrl + '/LR_CodeDemo/LeaveReq_Edit/GetFormDataByProcessId?processId=' + processId, function (data) {
                for (var id in data) {
                    if (!!data[id] && data[id].length > 0) {
                        $('#' + id).jfGridSet('refreshdata', data[id]);
                    }
                    else {
                        if (data[id].F_StartDate && data[id].F_StartDate.length > 13) {
                            var hour = data[id].F_StartDate.substr(11, 2)
                            if (hour == 10) {
                                $('#select1').lrselectSet(1)
                            } else {
                                $('#select1').lrselectSet(2)
                            }
                        }
                        if (data[id].F_EndDate && data[id].F_EndDate.length > 13) {
                            var hour = data[id].F_EndDate.substr(11, 2)
                            if (hour == 10) {
                                $('#select2').lrselectSet(1)
                            } else {
                                $('#select2').lrselectSet(2)
                            }
                        }
                        if (id == 'LeaveReq' && data[id]) {
                            keyValue = data[id].F_Id;
                        }
                        if (data[id].F_StartDate.length>=10) {
                            data[id].F_StartDate = data[id].F_StartDate.substr(0, 10)
                        }
                        if (data[id].F_EndDate.length >= 10) {
                            data[id].F_EndDate = data[id].F_EndDate.substr(0, 10)
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
        var formData = $('body').lrGetFormData();
        if (formData.F_LeaveType == "4" && +formData.F_LeaveDays > YHRestDays) {
            learun.alert.warning('年假天数不足!')
            return false
        }
        return true;
    };
    // 保存数据
    save = function (processId, callBack, i) {
        //debugger
        var formData = $('body').lrGetFormData();
        if (!!processId) {
            formData.F_Id = processId;
        }
        if ($('#select1').lrselectGet() == 1) {
            formData.F_StartDate += ' 08:00:00'
        } else {
            formData.F_StartDate += ' 14:00:00'
        }
        if ($('#select2').lrselectGet() == 1) {
            formData.F_EndDate += ' 08:00:00'
        } else {
            formData.F_EndDate += ' 14:00:00'
        }
        var postData = {
            strEntity: JSON.stringify(formData)
        };
        $.lrSaveForm(top.$.rootUrl + '/LR_CodeDemo/LeaveReq_Edit/SaveForm?keyValue=' + keyValue, postData, function (res) {
            // 保存成功后才回调
            if (!!callBack) {
                callBack(res, i);
            }
        });
    };
    page.init();
}
